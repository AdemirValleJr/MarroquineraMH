using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Macondo.AccesoDatos;
using Orkidea.MH.IntegracionContable.Entities;

namespace Orkidea.MH.IntegracionContable.Business
{
    public class BizIntegracion
    {
        private string _connStrPos { get; set; }
        private string _connStrErp { get; set; }

        public BizIntegracion(string connStrPos, string connStrErp)
        {
            _connStrPos = connStrPos;
            _connStrErp = connStrErp;
        }

        public List<string> GetPendingPeriods(string tienda, string tipoIntegracion)
        {
            List<string> list = new List<string>();
            string limiteInferior = obtenerParametro("IntegraDesde");

            StringBuilder oSql = new StringBuilder();

            oSql.AppendLine(string.Format("select distinct a.DATA_VENDA from LOJA_VENDA a where CODIGO_FILIAL = '{0}' and DATA_VENDA >= '{1}' ", tienda, limiteInferior ));
            oSql.AppendLine(string.Format("and DATA_VENDA not in (select periodoIntegrado from orkHistoricoIntegracion where filial = '{0}' and tipoIntegracion = '{1}') order by DATA_VENDA", tienda, tipoIntegracion));

            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql.ToString());

            foreach (DataRow row in ds.Tables[0].Rows)
                list.Add(DateTime.Parse(row[0].ToString()).ToString("yyyy-MM-dd"));

            return list;
        }

        public List<ReporteZ> GetZ(string filial, string terminal, string fecha)
        {
            List<ReporteZ> list = new List<ReporteZ>();

            string oSql = string.Format("exec CSS_REPORTE_Z '{0}', '{1}', '{2}'", fecha, filial, terminal);
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new ReporteZ()
                {
                    idTipoReporte = int.Parse(row[0].ToString()),
                    tipoReporte = row[1].ToString(),
                    tipoDocumento = row[2].ToString(),
                    numeroCupomFiscal = row[3].ToString(),
                    grupoTipoPagamento = int.Parse(row[4].ToString()),
                    descTipoPgto = row[5].ToString(),
                    administradora = row[6].ToString(),
                    numeroAprovacaoCartao = row[7].ToString(),
                    valor = double.Parse(row[8].ToString()),
                    ivaAsumido = double.Parse(row[9].ToString()),
                    numeroTitulo = row[10].ToString(),
                    terminal = terminal,
                    ticket = row[11].ToString(),
                    clifor = row[12].ToString(),
                    valorServicios = double.Parse(row[13].ToString())
                });
            }

            return list;
        }

        public List<HistoricoPadrao> GetHistoricosPadrao()
        {
            List<HistoricoPadrao> list = new List<HistoricoPadrao>();

            string oSql = "select CODIGO_HISTORICO, HISTORICO_PADRAO from CTB_HIST_PADRAO ";
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new HistoricoPadrao()
                {
                    codigoHistorico = row[0].ToString(),
                    historicoPadrao = row[1].ToString()
                });
            }

            return list;
        }

        public List<GruposTipoPgto> GetGruposPgto()
        {
            List<GruposTipoPgto> list = new List<GruposTipoPgto>();

            string oSql = "select * from CSS_VW_TIPOS ";
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new GruposTipoPgto()
                {
                    TipoPgto = row[0].ToString(),
                    desTipoPgto = row[1].ToString(),
                    grupoPgto = row[2].ToString()
                });
            }

            return list;
        }

        public List<Asiento> GenerateJournalEntry(Filial filial, string fecha)
        {
            BizCuentasTipoPago bizCuentasTipoPago = new BizCuentasTipoPago(_connStrPos, _connStrErp);

            List<HistoricoPadrao> histPadrao = GetHistoricosPadrao();
            List<GruposTipoPgto> gruposPgto = GetGruposPgto();
            List<CuentaTipoPago> cuentasTipo = bizCuentasTipoPago.GetList();
            List<TipoPgto> tiposTarjeta = bizCuentasTipoPago.GetPayTypeCardList();
            List<TipoPgto> tiposNoTarjeta = bizCuentasTipoPago.GetPayTypeNoCardList();

            List<TipoPgto> tercerosFormaPago = new List<TipoPgto>();
            string[] terceroFormaPago = obtenerParametro("terceroFormaPago").Split('|');

            foreach (string item in terceroFormaPago)
            {
                string[] itemData = item.Split('-');

                try
                {
                    tercerosFormaPago.Add(new TipoPgto() { tipo_pgto = itemData[0], desc_tipo_pgto = itemData[1] });
                }
                catch (Exception)
                {

                }
            }

            List<Administradora> administradoras = bizCuentasTipoPago.GetCardList();

            double porcentajeIva = (double.Parse(obtenerParametro("porcentajeIva")) + 100);

            List<Asiento> asientos = new List<Asiento>();

            foreach (Terminal terminal in filial.terminal)
            {
                List<ReporteZ> Z = GetZ(filial.cod_filial, terminal.terminal, fecha);
                List<ReporteZ> recibosCaja = Z.Where(x => x.idTipoReporte == 3).ToList();

                if (Z.Where(x => x.idTipoReporte.Equals(1)).Count() > 0)
                {
                    #region Encabezado Asiento
                    Asiento asiento = new Asiento()
                    {
                        codigoFilial = filial.cod_filial,
                        fecha = fecha,
                        terminal = terminal.terminal
                    };
                    #endregion

                    string tipoLancamento = string.Empty;
                    string textoHistorico = string.Empty;

                    #region Partidas

                    List<ReporteZ> mediosPago = new List<ReporteZ>();

                    mediosPago.AddRange(Z
                        .Where(x => x.idTipoReporte.Equals(1) && x.grupoTipoPagamento <= 96 && x.grupoTipoPagamento != 20 && x.grupoTipoPagamento != 21)
                        .ToList());

                    mediosPago.AddRange(Z
                        .Where(x => x.idTipoReporte.Equals(3) && x.grupoTipoPagamento != 4)
                        .ToList());

                    double servBrutos = mediosPago.Sum(x => x.valorServicios);
                    double servNetos = 0;
                    double ivaServicios = 0;

                    if (servBrutos > 0)
                    {
                        servNetos = Math.Round(((servBrutos * 100) / porcentajeIva), 0);
                        ivaServicios = servBrutos - servNetos;
                    }

                    #region VentasGravadas

                    double? ventaGravada = Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(73)).FirstOrDefault().valor;

                    if (ventaGravada != null && ventaGravada > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIngreso")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaVentaGravada = new AsientoDetalle()
                                {
                                    contaContabil = obtenerParametro("cuentaIngreso"),
                                    lxTipoLancamento = obtenerParametro("tipoLancIngreso"),
                                    cambioNaData = 1,
                                    codClifor = obtenerParametro("clienteGenerico"),
                                    codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIngreso"),
                                    historico = textoHistorico,
                                    credito = Math.Round(((double)ventaGravada), 0) - servNetos,
                                    debito = 0,
                                    creditoMoeda = Math.Round(((double)ventaGravada), 0) - servNetos,
                                    debitoMoeda = 0,
                                    moeda = "COP",
                                    dataDigitacao = fecha,
                                    permiteAlteracao = 1,
                                    rateioCentroCusto = filial.cod_filial,
                                    rateioFilial = filial.cod_filial,
                                };

                        asiento.lineas.Add(lineaVentaGravada);

                        if (servNetos > 0)
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIngresoServicios")).FirstOrDefault().historicoPadrao;

                            AsientoDetalle lineaVentaGravadaServicios = new AsientoDetalle()
                            {
                                contaContabil = obtenerParametro("cuentaIngresoServicios"),
                                lxTipoLancamento = obtenerParametro("tipoLancIngresoServicios"),
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIngreso"),
                                historico = textoHistorico,
                                credito = servNetos,
                                debito = 0,
                                creditoMoeda = servNetos,
                                debitoMoeda = 0,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaVentaGravadaServicios);
                        }
                    }
                    #endregion

                    #region VentasNoGravadas

                    double? ventaNoGravada = Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(71)).FirstOrDefault().valor;

                    if (ventaNoGravada != null && ventaNoGravada > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIngresoNoGravado")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaVentaNoGravada = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIngresoNoGravado"),
                            lxTipoLancamento = obtenerParametro("tipoLancIngresoNoGravado"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIngresoNoGravado"),
                            historico = textoHistorico,
                            credito = Math.Round(((double)ventaNoGravada), 0),
                            debito = 0,
                            creditoMoeda = Math.Round(((double)ventaNoGravada), 0),
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaVentaNoGravada);
                    }
                    #endregion

                    #region Devoluciones

                    double? devoluciones = Math.Abs(Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(75)).FirstOrDefault().valor);

                    if (devoluciones != null && devoluciones > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancDevolucion")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaDevolucion = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaDevolucion"),
                            lxTipoLancamento = obtenerParametro("tipoLancDevolucion"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancDevolucion"),
                            historico = textoHistorico,
                            credito = 0,
                            debito = Math.Round(((double)devoluciones), 0),
                            creditoMoeda = 0,
                            debitoMoeda = Math.Round(((double)devoluciones), 0),
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaDevolucion);

                    }
                    #endregion

                    #region ivaFacturado

                    double? ivaFacturado = Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(77)).FirstOrDefault().valor;

                    if (ivaFacturado != null && ivaFacturado > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIvaVenta")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaIvaVenta = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIvaVenta"),
                            lxTipoLancamento = obtenerParametro("tipoLancIvaVenta"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIvaVenta"),
                            historico = textoHistorico,
                            credito = Math.Round(((double)ivaFacturado), 0) - ivaServicios,
                            debito = 0,
                            creditoMoeda = Math.Round(((double)ivaFacturado), 0) - ivaServicios,
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaIvaVenta);
                    }

                    if (ivaServicios > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIvaVentaServicios")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaIvaServicios = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIvaVentaServicios"),
                            lxTipoLancamento = obtenerParametro("tipoLancIvaVentaServicios"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIvaVentaServicios"),
                            historico = textoHistorico,
                            credito = Math.Round(((double)ivaServicios), 0),
                            debito = 0,
                            creditoMoeda = Math.Round(((double)ivaServicios), 0),
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaIvaServicios);
                    }
                    #endregion

                    #region ivaDevolucion

                    double? ivaDevolucion = Math.Abs(Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(78)).FirstOrDefault().valor);

                    if (ivaDevolucion != null && ivaDevolucion > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIvaVenta")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }
                        AsientoDetalle lineaIvaVenta = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIvaDevolucion"),
                            lxTipoLancamento = obtenerParametro("tipoLancIvaDevolucion"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIvaDevolucion"),
                            historico = textoHistorico,
                            credito = 0,
                            debito = Math.Round(((double)ivaDevolucion), 0),
                            creditoMoeda = 0,
                            debitoMoeda = Math.Round(((double)ivaDevolucion), 0),
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaIvaVenta);
                    }
                    #endregion

                    #region ivaAsumido

                    double ivaAsumido = Z.Where(x => x.idTipoReporte.Equals(2) && x.grupoTipoPagamento.Equals(80)).FirstOrDefault().valor;

                    if (ivaAsumido != null && ivaAsumido > 0)
                    {
                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIvaAsumido")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }
                        AsientoDetalle lineaIvaAsumido = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIvaAsumido"),
                            lxTipoLancamento = obtenerParametro("tipoLancIvaAsumido"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancIvaAsumido"),
                            historico = textoHistorico,
                            credito = Math.Round(((double)ivaAsumido), 0),
                            debito = 0,
                            creditoMoeda = Math.Round(((double)ivaAsumido), 0),
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaIvaAsumido);

                        try
                        {
                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancContrapartidaIvaAsumido")).FirstOrDefault().historicoPadrao;
                        }
                        catch (Exception)
                        {
                            textoHistorico = "";
                        }

                        AsientoDetalle lineaContrapartidaIvaAsumido = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaContrapartidaIvaAsumido"),
                            lxTipoLancamento = obtenerParametro("tipoLancContrapartidaIvaAsumido"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancContrapartidaIvaAsumido"),
                            historico = textoHistorico,
                            credito = 0,
                            debito = Math.Round(((double)ivaAsumido), 0),
                            creditoMoeda = 0,
                            debitoMoeda = Math.Round(((double)ivaAsumido), 0),
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaContrapartidaIvaAsumido);
                    }
                    #endregion

                    #region Recibos de caja
                    if (recibosCaja.Count() > 0)
                    {
                        double valorBonos = 0;

                        foreach (ReporteZ item in recibosCaja)
                        {
                            #region Separados
                            if (EsReciboSeparados(filial.cod_filial, fecha, item.numeroCupomFiscal))
                            {
                                try
                                {
                                    textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancRecibosCaja")).FirstOrDefault().historicoPadrao;
                                }
                                catch (Exception)
                                {
                                    textoHistorico = "";
                                }

                                AsientoDetalle lineaNoGravados = new AsientoDetalle()
                                {
                                    contaContabil = obtenerParametro("cuentaRecibosCajaSeparados"),
                                    lxTipoLancamento = obtenerParametro("tipoLancRecibosCaja"),
                                    cambioNaData = 1,
                                    codClifor = ObtenerClienteSeparados(filial.cod_filial, fecha, item.numeroCupomFiscal),
                                    codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancRecibosCaja"),
                                    historico = textoHistorico,
                                    credito = item.valor,
                                    debito = 0,
                                    creditoMoeda = item.valor,
                                    debitoMoeda = 0,
                                    moeda = "COP",
                                    dataDigitacao = fecha,
                                    permiteAlteracao = 1,
                                    rateioCentroCusto = filial.cod_filial,
                                    rateioFilial = filial.cod_filial,
                                };

                                asiento.lineas.Add(lineaNoGravados);
                            }
                            else
                            {
                                valorBonos += item.valor;
                            }
                            #endregion
                        }

                        if (valorBonos > 0)
                        {
                            try
                            {
                                textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancRecibosCaja")).FirstOrDefault().historicoPadrao;
                            }
                            catch (Exception)
                            {
                                textoHistorico = "";
                            }

                            AsientoDetalle lineaNoGravados = new AsientoDetalle()
                            {
                                contaContabil = obtenerParametro("cuentaRecibosCajaBonos"),
                                lxTipoLancamento = obtenerParametro("tipoLancRecibosCaja"),
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : obtenerParametro("tipoLancRecibosCaja"),
                                historico = textoHistorico,
                                credito = valorBonos,
                                debito = 0,
                                creditoMoeda = valorBonos,
                                debitoMoeda = 0,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaNoGravados);
                        }
                    }
                    #endregion

                    #endregion

                    #region Contrapartidas

                    #region Medios de pago

                    //List<string> desTiposPgto = mediosPago.Select(x => x.descTipoPgto).Distinct().ToList();
                    List<string> desTiposPgto = Z.Where(x => x.idTipoReporte.Equals(4)).Select(x => x.numeroCupomFiscal).Distinct().ToList();
                    #endregion

                    #region Calculo por medio de pago

                    foreach (string desTipo in desTiposPgto)
                    {

                        TipoPgto tipoPgto = tiposNoTarjeta.Where(x => x.desc_tipo_pgto.Trim() == desTipo.Trim()).FirstOrDefault();

                        if (tipoPgto != null)
                        {
                            #region Medios diferentes de tarjetas
                            List<CuentaTipoPago> cuentas = cuentasTipo.Where(x => x.tipo_pgto.Trim() == tipoPgto.tipo_pgto.Trim()).ToList();

                            if (cuentas.Where(x => x.lineaPorTercero.Equals(true)).Count() > 0)
                            {
                                #region Linea por tercero
                                foreach (ReporteZ factura in mediosPago.Where(x => x.descTipoPgto.Trim() == desTipo.Trim()).ToList())
                                {
                                    foreach (CuentaTipoPago cuenta in cuentas)
                                    {
                                        try
                                        {
                                            textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == cuenta.tipoLancamento).FirstOrDefault().historicoPadrao;
                                        }
                                        catch (Exception)
                                        {
                                            textoHistorico = "";
                                        }

                                        double valor = Math.Abs(Math.Round((factura.valor * cuenta.peso) / 100, 0));

                                        AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                                        {
                                            contaContabil = cuenta.conta_contabil,
                                            lxTipoLancamento = cuenta.tipoLancamento,
                                            cambioNaData = 1,
                                            codClifor = factura.clifor,
                                            codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : cuenta.tipoLancamento,
                                            historico = textoHistorico,
                                            credito = 0,
                                            debito = valor,
                                            creditoMoeda = 0,
                                            debitoMoeda = valor,
                                            moeda = "COP",
                                            dataDigitacao = fecha,
                                            permiteAlteracao = 1,
                                            rateioCentroCusto = filial.cod_filial,
                                            rateioFilial = filial.cod_filial,
                                        };

                                        asiento.lineas.Add(lineaTipoPgto);
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region Linea con tercero generico o tercero exclusivo por forma de pago
                                //double valorTipo = mediosPago.Where(x => x.descTipoPgto.Trim() == desTipo.Trim()).Sum(x => x.valor);
                                double valorTipo = Z.Where(x => x.idTipoReporte.Equals(4) && x.numeroCupomFiscal.Trim() == desTipo.Trim()).Select(x => x.valor).First();

                                string tercero = "";
                                if (tercerosFormaPago.Where(x => x.tipo_pgto == tipoPgto.tipo_pgto).Count() > 0)
                                    tercero = tercerosFormaPago.Where(x => x.tipo_pgto == tipoPgto.tipo_pgto).FirstOrDefault().desc_tipo_pgto;
                                else
                                    tercero = obtenerParametro("clienteGenerico");

                                foreach (CuentaTipoPago cuenta in cuentas)
                                {
                                    /*Hallar si la cuenta necesita tercero*/

                                    string[] cuentasNoTercero = obtenerParametro("cuentasNoTercero").Split('|');

                                    foreach (string item in cuentasNoTercero)
                                    {
                                        if (cuenta.conta_contabil.Substring(0, item.Length) == item)
                                        {
                                            tercero = "";
                                        }
                                    }

                                    try
                                    {
                                        textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == cuenta.tipoLancamento).FirstOrDefault().historicoPadrao;
                                    }
                                    catch (Exception)
                                    {
                                        textoHistorico = "";

                                    }

                                    double valor = Math.Abs(Math.Round((valorTipo * cuenta.peso) / 100, 0));

                                    AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                                    {
                                        contaContabil = cuenta.conta_contabil,
                                        lxTipoLancamento = cuenta.tipoLancamento,
                                        cambioNaData = 1,
                                        codClifor = tercero,
                                        codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : cuenta.tipoLancamento,
                                        historico = textoHistorico,
                                        credito = 0,
                                        debito = valor,
                                        creditoMoeda = 0,
                                        debitoMoeda = valor,
                                        moeda = "COP",
                                        dataDigitacao = fecha,
                                        permiteAlteracao = 1,
                                        rateioCentroCusto = filial.cod_filial,
                                        rateioFilial = filial.cod_filial,
                                    };

                                    asiento.lineas.Add(lineaTipoPgto);
                                }
                                #endregion
                            }
                            #endregion
                        }

                        tipoPgto = tiposTarjeta.Where(x => x.desc_tipo_pgto.Trim() == desTipo.Trim()).FirstOrDefault();

                        if (tipoPgto != null)
                        {
                            #region Tarjetas
                            List<CuentaAdministradora> cuentasTarjetas = bizCuentasTipoPago.GetAccountCardList(tipoPgto.tipo_pgto);

                            string[] administradorasReporte = mediosPago.Where(x => x.descTipoPgto.Trim() == desTipo.Trim()).Select(x => x.administradora).Distinct().ToArray();

                            foreach (string administradora in administradorasReporte)
                            {
                                string idAdmin = administradoras.Where(x => x.administradora.Trim() == administradora.Trim()).FirstOrDefault().idAdministradora;

                                CuentaAdministradora cuentaAdministradora = cuentasTarjetas.Where(x => x.idAdministradora.Trim() == idAdmin.Trim()).FirstOrDefault();

                                if (cuentaAdministradora == null)
                                    throw new Exception(string.Format("la administradora {0} no tiene cuentas parametrizadas", administradora));

                                double valor = mediosPago.Where(x => x.descTipoPgto.Trim() == desTipo.Trim() && x.administradora.Trim() == administradora.Trim()).Sum(x => x.valor);

                                try
                                {
                                    textoHistorico = histPadrao.Where(x => x.codigoHistorico.Trim() == cuentaAdministradora.tipoLancamento).FirstOrDefault().historicoPadrao;
                                }
                                catch (Exception)
                                {
                                    textoHistorico = "";
                                }

                                string tercero = "";
                                if (tercerosFormaPago.Where(x => x.tipo_pgto == tipoPgto.tipo_pgto).Count() > 0)
                                    tercero = tercerosFormaPago.Where(x => x.tipo_pgto == tipoPgto.tipo_pgto).FirstOrDefault().desc_tipo_pgto;
                                else
                                    tercero = obtenerParametro("clienteGenerico");

                                string[] cuentasNoTercero = obtenerParametro("cuentasNoTercero").Split('|');

                                foreach (string item in cuentasNoTercero)
                                {
                                    if (cuentaAdministradora.conta_contabil.Substring(0, item.Length) == item)
                                    {
                                        tercero = "";
                                    }
                                }

                                AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                                {
                                    contaContabil = cuentaAdministradora.conta_contabil,
                                    lxTipoLancamento = cuentaAdministradora.tipoLancamento,
                                    cambioNaData = 1,
                                    codClifor = tercero,
                                    codigoHistorico = string.IsNullOrEmpty(textoHistorico) ? "" : cuentaAdministradora.tipoLancamento,
                                    historico = textoHistorico,
                                    credito = 0,
                                    debito = valor,
                                    creditoMoeda = 0,
                                    debitoMoeda = valor,
                                    moeda = "COP",
                                    dataDigitacao = fecha,
                                    permiteAlteracao = 1,
                                    rateioCentroCusto = filial.cod_filial,
                                    rateioFilial = filial.cod_filial,
                                };

                                asiento.lineas.Add(lineaTipoPgto);
                            }
                            #endregion
                        }
                    }

                    #endregion

                    #endregion

                    #region Informacion complementaria

                    if (asiento.lineas.Count() > 0)
                    {
                        #region Terceros
                        string[] tercerosAsiento = asiento.lineas.Select(x => x.codClifor).Distinct().ToArray();
                        List<Tercero> terceros = new List<Tercero>();
                        StringBuilder tercero = new StringBuilder();

                        for (int i = 0; i < tercerosAsiento.Length; i++)
                        {
                            if (tercerosAsiento[i] != obtenerParametro("clienteGenerico"))
                            {
                                tercero.Append(string.Format("'{0}'", tercerosAsiento[i]));

                                if (i < tercerosAsiento.Length - 1)
                                    tercero.Append(",");
                            }
                            else
                            {
                                terceros.Add(ObtenerTerceroGenerico(tercerosAsiento[i]));
                            }
                        }

                        if (tercero.Length > 0)
                            terceros.AddRange(ObtenerTerceros(tercero.ToString()));

                        foreach (AsientoDetalle item in asiento.lineas)
                            try
                            {
                                if (string.IsNullOrEmpty(item.codClifor))
                                    item.nombreCliente = string.Empty;
                                else
                                    item.nombreCliente = terceros.Where(x => x.nit.Trim() == item.codClifor.Trim()).FirstOrDefault().desCliente;
                            }
                            catch (Exception)
                            {
                                item.nombreCliente = string.Format("{0} *** No se pudo encontrar el tercero ***", item.codClifor.Trim());
                                //throw new Exception(string.Format("No se pudo encontrar el tercero {0}", item.codClifor.Trim()));
                            }
                        #endregion

                        #region Cuentas

                        string[] cuentasAsiento = asiento.lineas.Distinct().Select(x => x.contaContabil).ToArray();

                        StringBuilder cuenta = new StringBuilder();

                        for (int i = 0; i < cuentasAsiento.Length; i++)
                        {
                            cuenta.Append(string.Format("'{0}'", cuentasAsiento[i]));

                            if (i < cuentasAsiento.Length - 1)
                                cuenta.Append(",");
                        }

                        List<Conta_Plano> cuentas = bizCuentasTipoPago.GetAccountList(cuenta.ToString());

                        foreach (AsientoDetalle item in asiento.lineas)
                            try
                            {
                                item.desConta = cuentas.Where(x => x.conta_contabil.Trim() == item.contaContabil.Trim()).FirstOrDefault().desc_conta;
                            }
                            catch (Exception)
                            {
                                throw new Exception(string.Format("No se pudo encontrar la cuenta {0}", item.contaContabil.Trim()));
                            }

                        #endregion
                    }

                    #endregion

                    asientos.Add(asiento);
                }
            }

            return asientos;
        }

        public string SaveJournalEntry(Asiento asiento)
        {
            string lanzamiento = "";
            StringBuilder log = new StringBuilder();
            int errores = 0;
            try
            {
                // validacion de periodos pendientes
                string sqlValidaHistorico = string.Format("select count(1) from orkHistoricoIntegracion where filial = '{0}' and periodoIntegrado = '{1}' and terminal = {2}", asiento.codigoFilial, asiento.fecha, asiento.terminal);
                if ((int)SqlServer.ExecuteScalar(_connStrPos, CommandType.Text, sqlValidaHistorico) > 0)
                {
                    log.AppendLine(string.Format("El periodo {0} de la tienda {1} - terminal {2} ya fue integrada anteriormente|{3}|{4}", asiento.fecha, asiento.codigoFilial, asiento.terminal, errores.ToString(), 0));
                    return log.ToString();
                }

                // creacion de encabezado                

                double db = 0, cr = 0;

                db = asiento.lineas.Sum(x => x.debito);
                cr = asiento.lineas.Sum(x => x.credito);

                if (db != cr)
                {
                    errores++;
                    log.AppendLine("*** ATENCION!!! ASIENTO DESCUADRADO ***");
                    log.AppendLine("");
                }


                log.AppendLine(string.Format("Inicia proceso de integracion para {0}, terminal {1}", asiento.fecha, asiento.terminal));
                log.AppendLine("");

                string sqlEncabezado = string.Format("exec orkCrearEncabezadoAsiento '{0}', '{1}'", asiento.fecha, asiento.codigoFilial);

                lanzamiento = SqlServer.ExecuteScalar(_connStrErp, CommandType.Text, sqlEncabezado).ToString();
                log.AppendLine(string.Format("Se crea el encabezado para el asiento con numero {0}", lanzamiento));

                string sqlCreaLog = string.Format("insert into orkHistoricoIntegracion select '{0}', {1}, '{2}', getdate(), 'I'", asiento.codigoFilial, asiento.terminal, asiento.fecha);
                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, sqlCreaLog);

                // creacion de las lineas

                for (int i = 0; i < asiento.lineas.Count; i++)
                {
                    try
                    {
                        string sqlLinea =
                                        string.Format("exec orkCrearLineaAsiento {0}, {1}, '{2}', '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}', {11}, {12}, {13}, '{14}'",
                                        i + 1, lanzamiento, asiento.lineas[i].codClifor, asiento.lineas[i].contaContabil.Trim(), asiento.lineas[i].credito.ToString(), asiento.lineas[i].debito.ToString(),
                                        asiento.lineas[i].historico, asiento.lineas[i].codigoHistorico, asiento.lineas[i].rateioCentroCusto, asiento.lineas[i].moeda, asiento.lineas[i].lxTipoLancamento,
                                        asiento.lineas[i].debitoMoeda, asiento.lineas[i].creditoMoeda, asiento.lineas[i].cambioNaData, asiento.lineas[i].rateioFilial);

                        int insertLinea = SqlServer.ExecuteNonQuery(_connStrErp, CommandType.Text, sqlLinea);
                        log.AppendLine(string.Format("**Registro numero {0} (cuenta {1}) creado con exito", i.ToString(), asiento.lineas[i].contaContabil.Trim()));
                    }
                    catch (Exception ex)
                    {
                        log.AppendLine(string.Format("**No se pudo crear el registro numero {0} (cuenta {1}) porque {2}", i.ToString(), asiento.lineas[i].contaContabil.Trim(), ex.Message));
                        errores++;
                    }
                    log.AppendLine("");
                }
            }
            catch (Exception ex)
            {
                log.AppendLine(string.Format("**No se pudo crear el asiento porque|1|0 ", ex.Message));
            }

            log.AppendLine("");

            if (errores == 0)
                log.AppendLine(string.Format("Fin del proceso|{0}|{1}", errores.ToString(), lanzamiento));
            else
            {
                log.AppendLine("");
                log.AppendLine("");
                log.AppendLine(string.Format("**** EL ASIENTO CONTIENE ERRORES ¿DESEA CONSERVARLO ASÍ EN LINX?|{0}|{1}", errores.ToString(), lanzamiento));
            }

            return log.ToString();
        }

        public string DeleteJournalEntry(string lancamento, Asiento asiento)
        {
            try
            {
                string sqlLinea = string.Format("exec orkBorraAsiento {0}", lancamento);
                SqlServer.ExecuteNonQuery(_connStrErp, CommandType.Text, sqlLinea);

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, string.Format("delete from orkHistoricoIntegracion where filial = '{0}' and periodoIntegrado = '{1}' and tipoIntegracion = 'I'", asiento.codigoFilial, asiento.fecha));
                return "se eliminó el asiento";
            }
            catch (Exception ex)
            {
                return string.Format("No se pudo eliminar el asiento porque {0}", ex.Message);
            }            
        }

        private bool EsReciboSeparados(string filial, string fecha, string recibo)
        {
            bool res = false;

            StringBuilder oSql = new StringBuilder();

            oSql.AppendLine("select count(1) from LOJA_VENDA a ");
            oSql.AppendLine("inner join LOJA_VENDA_PGTO b on a.CODIGO_FILIAL = b.CODIGO_FILIAL and a.LANCAMENTO_CAIXA = b.LANCAMENTO_CAIXA ");
            oSql.AppendLine("inner join LOJA_VENDA_PRODUTO c on a.CODIGO_FILIAL = c.CODIGO_FILIAL and a.TICKET = c.TICKET ");
            oSql.AppendLine(string.Format("where a.CODIGO_FILIAL = '{0}' and a.DATA_VENDA = '{1}' and b.ID_EQUIPAMENTO  = '{2}' and c.PRODUTO = 'SE.SE.0005'", filial, fecha, recibo));

            var numSeparados = SqlServer.ExecuteScalar(_connStrPos, CommandType.Text, oSql.ToString());

            if ((int)numSeparados > 0)
                res = true;

            return res;
        }

        private string ObtenerClienteSeparados(string filial, string fecha, string recibo)
        {
            StringBuilder oSql = new StringBuilder();

            oSql.AppendLine("select a.CODIGO_CLIENTE from LOJA_VENDA a ");
            oSql.AppendLine("inner join LOJA_VENDA_PGTO b on a.CODIGO_FILIAL = b.CODIGO_FILIAL and a.LANCAMENTO_CAIXA = b.LANCAMENTO_CAIXA ");
            oSql.AppendLine("inner join LOJA_VENDA_PRODUTO c on a.CODIGO_FILIAL = c.CODIGO_FILIAL and a.TICKET = c.TICKET ");
            oSql.AppendLine(string.Format("where a.CODIGO_FILIAL = '{0}' and a.DATA_VENDA = '{1}' and b.ID_EQUIPAMENTO  = '{2}' and c.PRODUTO = 'SE.SE.0005'", filial, fecha, recibo));

            return SqlServer.ExecuteScalar(_connStrPos, CommandType.Text, oSql.ToString()).ToString();
        }

        private List<Tercero> ObtenerTerceros(string terceros)
        {
            string oSql = string.Format("select CLIFOR, ltrim(cgc_cpf) + ' ::: ' + RAZAO_SOCIAL NOME_CLIFOR, cgc_cpf from CADASTRO_CLI_FOR where cgc_cpf in ({0})", terceros);
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            List<Tercero> list = new List<Tercero>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Tercero()
                {
                    codClifor = row[0].ToString(),
                    desCliente = row[1].ToString(),
                    nit = row[2].ToString()
                });
            }

            return list;
        }

        private Tercero ObtenerTerceroGenerico(string tercero)
        {
            string oSql = string.Format("select CLIFOR, ltrim(cgc_cpf)  + ' ::: ' + RAZAO_SOCIAL NOME_CLIFOR from CADASTRO_CLI_FOR where clifor = '{0}'", tercero);
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            return new Tercero()
            {
                codClifor = ds.Tables[0].Rows[0][0].ToString(),
                desCliente = ds.Tables[0].Rows[0][1].ToString(),
                nit = ds.Tables[0].Rows[0][0].ToString()
            };
        }

        private string obtenerParametro(string parametro)
        {
            try
            {
                string valor = ConfigurationManager.AppSettings[parametro].ToString();
                return valor;
            }
            catch (Exception)
            {
                throw new Exception(string.Format("El parametro {0} no fue encontrado o no tiene valor. Verifique archivo '.config' ", parametro));
            }
        }


        /*
         public List<Asiento> LiquidateStoreSales(Filial filial, string fecha)
        {
            BizCuentasTipoPago bizCuentasTipoPago = new BizCuentasTipoPago(_connStrPos, _connStrErp);

            List<HistoricoPadrao> histPadrao = GetHistoricosPadrao();
            List<GruposTipoPgto> gruposPgto = GetGruposPgto();
            List<CuentaTipoPago> cuentasTipo = bizCuentasTipoPago.GetList();

            double porcentajeIva = (double.Parse(ConfigurationManager.AppSettings["porcentajeIva"]) + 100);

            List<Asiento> asientos = new List<Asiento>();

            foreach (Terminal terminal in filial.terminal)
            {
                #region Definiciones
                List<ReporteZ> Z = GetZ(filial.cod_filial, terminal.terminal, fecha);

                List<ReporteZ> ventasBrutas = Z.Where(x => x.idTipoReporte == 1 &&
                    x.tipoDocumento == "FA" && x.grupoTipoPagamento < 97).ToList();

                List<ReporteZ> ventasNoGravadas = Z.Where(x => x.idTipoReporte == 1 &&
                    x.tipoDocumento == "FA" && x.grupoTipoPagamento == 99 &&
                    x.descTipoPgto.Trim() == "APROVECHAMIENTO").ToList();

                List<ReporteZ> devolucionesBrutas = Z.Where(x => x.idTipoReporte == 1 &&
                    x.tipoDocumento == "DV").ToList();

                List<ReporteZ> recibosCaja = Z.Where(x => x.idTipoReporte == 3).ToList();

                double valorVentasBrutas = ventasBrutas.Sum(x => x.valor);
                double valorVentasNoGravadas = Math.Abs(ventasNoGravadas.Sum(x => x.valor));

                double valorVentasGravadas = Math.Round(((valorVentasBrutas * 100) / porcentajeIva), 0);
                double IvaVentasGravadas = valorVentasBrutas - valorVentasGravadas;

                double valorDevoluciones = Math.Abs(devolucionesBrutas.Sum(x => x.valor));
                double valorBaseDevoluciones = Math.Round(((valorDevoluciones * 100) / porcentajeIva), 0);
                double IvaDevoluciones = valorDevoluciones - valorBaseDevoluciones;

                double valorCambios = ventasBrutas.Where(x => x.grupoTipoPagamento == 21).Sum(x => x.valor);

                //double valorVentasNetas = valorVentasBrutas -valorDevoluciones;                    
                //double valorBaseVentasNetas = Math.Round(((valorVentasNetas * 100) / porcentajeIva), 0);
                #endregion

                #region Encabezado Asiento
                Asiento asiento = new Asiento()
                        {
                            codigoFilial = filial.cod_filial,
                            fecha = fecha,
                            terminal = terminal.terminal
                        };
                #endregion

                #region Detalle
                #region Ventas
                if (ventasBrutas.Count() > 0)
                {
                    #region Ingreso gravado
                    string historicoVenta = histPadrao.Where(x => x.codigoHistorico.Trim() == ConfigurationManager.AppSettings["tipoLancIngreso"]).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaIngresoVenta = new AsientoDetalle()
                            {
                                contaContabil = obtenerParametro( "cuentaIngreso"),
                                lxTipoLancamento = obtenerParametro("tipoLancIngreso"),
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = obtenerParametro("tipoLancIngreso"),
                                historico = historicoVenta,
                                credito = valorVentasGravadas,
                                debito = 0,
                                creditoMoeda = valorVentasGravadas,
                                debitoMoeda = 0,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                    asiento.lineas.Add(lineaIngresoVenta);
                    #endregion

                    #region Ingreso no gravado (aprovechamientos)
                    if (ventasNoGravadas.Count() > 0)
                    {
                        string historico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIngresoNoGravado")).FirstOrDefault().historicoPadrao;
                        AsientoDetalle lineaNoGravados = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaIngresoNoGravado"),
                            lxTipoLancamento = obtenerParametro("tipoLancIngresoNoGravado"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = obtenerParametro("tipoLancIngresoNoGravado"),
                            historico = historico,
                            credito = valorVentasNoGravadas,
                            debito = 0,
                            creditoMoeda = valorVentasNoGravadas,
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaNoGravados);
                    }
                    #endregion

                    #region Iva venta
                    string historicoIvaVenta = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancIvaVenta")).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaIvaVenta = new AsientoDetalle()
                            {
                                contaContabil = obtenerParametro("cuentaIvaVenta"),
                                lxTipoLancamento = obtenerParametro("tipoLancIvaVenta"),
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = obtenerParametro("tipoLancIvaVenta"),
                                historico = historicoIvaVenta,
                                credito = IvaVentasGravadas,
                                debito = 0,
                                creditoMoeda = IvaVentasGravadas,
                                debitoMoeda = 0,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                    asiento.lineas.Add(lineaIvaVenta);
                    #endregion

                    #region Lineas asiento por forma de pago
                    List<string> tiposPgto = ventasBrutas.Select(x => x.descTipoPgto).Distinct().ToList();

                    foreach (string tipo in tiposPgto)
                    {
                        string tipoPgto = gruposPgto.Where(x => x.desTipoPgto == tipo).Select(x => x.TipoPgto).FirstOrDefault();
                        double valorTipo = ventasBrutas.Where(x => x.descTipoPgto == tipo).Sum(x => x.valor);

                        List<CuentaTipoPago> cuentasPorTipo = cuentasTipo.Where(x => x.tipo_pgto == tipoPgto).ToList();

                        foreach (CuentaTipoPago item in cuentasPorTipo)
                        {
                            double valor = Math.Round((valorTipo * item.peso) / 100, 4);
                            string historicoDetalleVenta = histPadrao.Where(x => x.codigoHistorico.Trim() == item.tipoLancamento).FirstOrDefault().historicoPadrao;
                            AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                            {
                                contaContabil = item.conta_contabil,
                                lxTipoLancamento = item.tipoLancamento,
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = item.tipoLancamento,
                                historico = historicoDetalleVenta,
                                credito = 0,
                                debito = valor,
                                creditoMoeda = 0,
                                debitoMoeda = valor,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaTipoPgto);
                        }
                    }
                    #endregion

                    #region Linea de cambios
                    string historicoDetalleCambios = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancContrapartidaDevolucion")).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaCambios = new AsientoDetalle()
                    {
                        contaContabil = obtenerParametro("cuentaContrapartidaDevolucion"),
                        lxTipoLancamento = obtenerParametro("tipoLancContrapartidaDevolucion"),
                        cambioNaData = 1,
                        codClifor = obtenerParametro("clienteGenerico"),
                        codigoHistorico = obtenerParametro("tipoLancContrapartidaDevolucion"),
                        historico = historicoDetalleCambios,
                        credito = 0,
                        debito = valorCambios,
                        creditoMoeda = 0,
                        debitoMoeda = valorCambios,
                        moeda = "COP",
                        dataDigitacao = fecha,
                        permiteAlteracao = 1,
                        rateioCentroCusto = filial.cod_filial,
                        rateioFilial = filial.cod_filial,
                    };

                    asiento.lineas.Add(lineaCambios);
                    #endregion

                    #region Lineas asiento por forma de pago no gravadas
                    List<string> tiposPgtoApr = ventasNoGravadas.Select(x => x.descTipoPgto).Distinct().ToList();

                    foreach (string tipo in tiposPgtoApr)
                    {
                        string tipoPgto = gruposPgto.Where(x => x.desTipoPgto == tipo).Select(x => x.TipoPgto).FirstOrDefault();
                        double valorTipo = ventasNoGravadas.Where(x => x.descTipoPgto == tipo).Sum(x => x.valor);

                        List<CuentaTipoPago> cuentasPorTipo = cuentasTipo.Where(x => x.tipo_pgto == tipoPgto).ToList();

                        foreach (CuentaTipoPago item in cuentasPorTipo)
                        {
                            double valor = Math.Abs(Math.Round((valorTipo * item.peso) / 100, 4));
                            string historicoDetalleVenta = histPadrao.Where(x => x.codigoHistorico.Trim() == item.tipoLancamento).FirstOrDefault().historicoPadrao;
                            AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                            {
                                contaContabil = item.conta_contabil,
                                lxTipoLancamento = item.tipoLancamento,
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = item.tipoLancamento,
                                historico = historicoDetalleVenta,
                                credito = 0,
                                debito = valor,
                                creditoMoeda = 0,
                                debitoMoeda = valor,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaTipoPgto);
                        }
                    }
                    #endregion
                    asientos.Add(asiento);
                }
                #endregion

                #region Devoluciones
                if (devolucionesBrutas.Count() > 0)
                {
                    #region Devolucion Venta
                    string historicoDevolucion = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancDevolucion")).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaDevolucion = new AsientoDetalle()
                    {
                        contaContabil = obtenerParametro("cuentaDevolucion"),
                        lxTipoLancamento = obtenerParametro("tipoLancDevolucion"),
                        cambioNaData = 1,
                        codClifor = obtenerParametro("clienteGenerico"),
                        codigoHistorico = obtenerParametro("tipoLancDevolucion"),
                        historico = historicoDevolucion,
                        credito = 0,
                        debito = valorBaseDevoluciones,
                        creditoMoeda = 0,
                        debitoMoeda = valorBaseDevoluciones,
                        moeda = "COP",
                        dataDigitacao = fecha,
                        permiteAlteracao = 1,
                        rateioCentroCusto = filial.cod_filial,
                        rateioFilial = filial.cod_filial,
                    };

                    asiento.lineas.Add(lineaDevolucion);
                    #endregion

                    #region Iva devolucion
                    string historicoIvaDevolucion = histPadrao.Where(x => x.codigoHistorico.Trim() == ConfigurationManager.AppSettings["tipoLancIvaDevolucion"]).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaIvaDevolucion = new AsientoDetalle()
                    {
                        contaContabil = obtenerParametro("cuentaIvaDevolucion"),
                        lxTipoLancamento = obtenerParametro("tipoLancIvaDevolucion"),
                        cambioNaData = 1,
                        codClifor = obtenerParametro("clienteGenerico"),
                        codigoHistorico = obtenerParametro("tipoLancIvaDevolucion"),
                        historico = historicoIvaDevolucion,
                        credito = 0,
                        debito = IvaDevoluciones,
                        creditoMoeda = 0,
                        debitoMoeda = IvaDevoluciones,
                        moeda = "COP",
                        dataDigitacao = fecha,
                        permiteAlteracao = 1,
                        rateioCentroCusto = filial.cod_filial,
                        rateioFilial = filial.cod_filial,
                    };

                    asiento.lineas.Add(lineaIvaDevolucion);
                    #endregion

                    #region Contrapartida devolucion
                    string historicoContrapartidaDevolucion = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancContrapartidaDevolucion")).FirstOrDefault().historicoPadrao;
                    AsientoDetalle lineaContrapartidaDevolucion = new AsientoDetalle()
                    {
                        contaContabil = obtenerParametro("cuentaContrapartidaDevolucion"),
                        lxTipoLancamento = obtenerParametro("tipoLancContrapartidaDevolucion"),
                        cambioNaData = 1,
                        codClifor = obtenerParametro("clienteGenerico"),
                        codigoHistorico = obtenerParametro("tipoLancContrapartidaDevolucion"),
                        historico = historicoContrapartidaDevolucion,
                        credito = IvaDevoluciones + valorBaseDevoluciones,
                        debito = 0,
                        creditoMoeda = IvaDevoluciones + valorBaseDevoluciones,
                        debitoMoeda = 0,
                        moeda = "COP",
                        dataDigitacao = fecha,
                        permiteAlteracao = 1,
                        rateioCentroCusto = filial.cod_filial,
                        rateioFilial = filial.cod_filial,
                    };

                    asiento.lineas.Add(lineaContrapartidaDevolucion);
                    #endregion
                }
                #endregion

                #region Recibos de caja
                if (recibosCaja.Count() > 0)
                {
                    #region Recibo de caja
                    double valorBonos = 0;

                    foreach (ReporteZ item in recibosCaja)
                    {
                        if (EsReciboSeparados(filial.filial, fecha, item.numeroCupomFiscal))
                        {
                            string historico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancRecibosCaja")).FirstOrDefault().historicoPadrao;
                            AsientoDetalle lineaNoGravados = new AsientoDetalle()
                            {
                                contaContabil = obtenerParametro("cuentaRecibosCajaSeparados"),
                                lxTipoLancamento = obtenerParametro("tipoLancRecibosCaja"),
                                cambioNaData = 1,
                                codClifor = ObtenerClienteSeparados(filial.filial, fecha, item.numeroCupomFiscal),
                                codigoHistorico = obtenerParametro("tipoLancRecibosCaja"),
                                historico = historico,
                                credito = item.valor,
                                debito = 0,
                                creditoMoeda = item.valor,
                                debitoMoeda = 0,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaNoGravados);
                        }
                        else
                        {
                            valorBonos += item.valor;
                        }
                    }

                    if (valorBonos > 0)
                    {
                        string historico = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("tipoLancRecibosCaja")).FirstOrDefault().historicoPadrao;
                        AsientoDetalle lineaNoGravados = new AsientoDetalle()
                        {
                            contaContabil = obtenerParametro("cuentaRecibosCajaBonos"),
                            lxTipoLancamento = obtenerParametro("tipoLancRecibosCaja"),
                            cambioNaData = 1,
                            codClifor = obtenerParametro("clienteGenerico"),
                            codigoHistorico = obtenerParametro("tipoLancRecibosCaja"),
                            historico = historico,
                            credito = valorBonos,
                            debito = 0,
                            creditoMoeda = valorBonos,
                            debitoMoeda = 0,
                            moeda = "COP",
                            dataDigitacao = fecha,
                            permiteAlteracao = 1,
                            rateioCentroCusto = filial.cod_filial,
                            rateioFilial = filial.cod_filial,
                        };

                        asiento.lineas.Add(lineaNoGravados);
                    }
                    #endregion

                    #region Lineas asiento por forma de pago
                    List<string> tiposPgto = recibosCaja.Select(x => x.descTipoPgto).Distinct().ToList();

                    foreach (string tipo in tiposPgto)
                    {
                        string tipoPgto = gruposPgto.Where(x => x.desTipoPgto == tipo).Select(x => x.TipoPgto).FirstOrDefault();
                        double valorTipo = recibosCaja.Where(x => x.descTipoPgto == tipo).Sum(x => x.valor);

                        List<CuentaTipoPago> cuentasPorTipo = cuentasTipo.Where(x => x.tipo_pgto == tipoPgto).ToList();

                        foreach (CuentaTipoPago item in cuentasPorTipo)
                        {
                            double valor = Math.Round((valorTipo * item.peso) / 100, 4);
                            string historicoDetalleVenta = histPadrao.Where(x => x.codigoHistorico.Trim() == item.tipoLancamento).FirstOrDefault().historicoPadrao;
                            AsientoDetalle lineaTipoPgto = new AsientoDetalle()
                            {
                                contaContabil = item.conta_contabil,
                                lxTipoLancamento = item.tipoLancamento,
                                cambioNaData = 1,
                                codClifor = obtenerParametro("clienteGenerico"),
                                codigoHistorico = item.tipoLancamento,
                                historico = historicoDetalleVenta,
                                credito = 0,
                                debito = valor,
                                creditoMoeda = 0,
                                debitoMoeda = valor,
                                moeda = "COP",
                                dataDigitacao = fecha,
                                permiteAlteracao = 1,
                                rateioCentroCusto = filial.cod_filial,
                                rateioFilial = filial.cod_filial,
                            };

                            asiento.lineas.Add(lineaTipoPgto);
                        }
                    }
                    #endregion
                }
                #endregion

                #region Informacion complementaria

                if (asiento.lineas.Count() > 0)
                {
                    #region Terceros
                    string[] tercerosAsiento = asiento.lineas.Distinct().Select(x => x.codClifor).ToArray();

                    StringBuilder tercero = new StringBuilder();

                    for (int i = 0; i < tercerosAsiento.Length; i++)
                    {
                        tercero.Append(string.Format("'{0}'", tercerosAsiento[i]));

                        if (i < tercerosAsiento.Length - 1)
                            tercero.Append(",");
                    }

                    List<Tercero> terceros = ObtenerTerceros(tercero.ToString());

                    foreach (AsientoDetalle item in asiento.lineas)
                        item.nombreCliente = terceros.Where(x => x.codClifor.Trim() == item.codClifor.Trim()).FirstOrDefault().desCliente;
                    #endregion

                    #region Cuentas

                    string[] cuentasAsiento = asiento.lineas.Distinct().Select(x => x.contaContabil).ToArray();

                    StringBuilder cuenta = new StringBuilder();

                    for (int i = 0; i < cuentasAsiento.Length; i++)
                    {
                        cuenta.Append(string.Format("'{0}'", cuentasAsiento[i]));

                        if (i < cuentasAsiento.Length - 1)
                            cuenta.Append(",");
                    }

                    List<Conta_Plano> cuentas = bizCuentasTipoPago.GetAccountList(cuenta.ToString());

                    foreach (AsientoDetalle item in asiento.lineas)
                        item.desConta = cuentas.Where(x => x.conta_contabil.Trim() == item.contaContabil.Trim()).FirstOrDefault().desc_conta;
                    #endregion
                }

                #endregion
                #endregion
            }
            return asientos;
        }
         */
    }
}
