using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macondo.AccesoDatos;
using Orkidea.MH.IntegracionContable.Entities;
using System.Data;
using System.Globalization;
using System.Configuration;

namespace Orkidea.MH.IntegracionContable.Business
{
    public class BizTrm
    {
        public string _connStrPos { get; set; }
        private string _connStrErp { get; set; }

        public BizTrm(string connStrPos, string connStrErp)
        {
            _connStrPos = connStrPos;
            _connStrErp = connStrErp;
        }

        public List<Trm> GetList()
        {
            string oSql = "Select * from orkTrm order by fecha desc";
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);            

            List<Trm> list = new List<Trm>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Trm()
                {
                    fecha = DateTime.Parse(row[0].ToString()),                    
                    dolar = double.Parse(row[1].ToString()),
                    euro = double.Parse(row[2].ToString())
                });
            }

            return list;
        }

        public Trm GetStoreTrm(DateTime fecha)
        {
            string oSql = string.Format( "Select * from orkTrm where fecha = '{0}'", fecha.ToString("yyyy-MM-dd"));
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            Trm trm = new Trm();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                trm = new Trm()
                {
                    fecha = DateTime.Parse(row[0].ToString()),
                    dolar = double.Parse(row[1].ToString()),
                    euro = double.Parse(row[2].ToString())
                };
            }

            return trm;
        }

        public double GetOficialTrm(DateTime fecha, string moneda)
        {
            string oSql = string.Format("Select valor from MOEDAS_CONVERSAO where data = '{0}' and moeda = '{1}'", fecha.ToString("yyyy-MM-dd"), moneda);
            try
            {
                return double.Parse(SqlServer.ExecuteScalar(_connStrPos, CommandType.Text, oSql).ToString());            
            }
            catch (Exception)
            {

                return 0;
            }
            
        }        

        public bool Add(Trm item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                //CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("insert into OrkTrm ");
                oSql.AppendLine(string.Format("select '{0}',{1}, {2}", item.fecha.ToString("yyyy-MM-dd"), item.dolar.ToString("0.00", CultureInfo.InvariantCulture), item.euro.ToString("0.00", CultureInfo.InvariantCulture)));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Edit(Trm item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                //CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("Update OrkTrm set ");
                oSql.AppendLine(string.Format("dolar =  {0}, euro = {1} where fecha = '{2}'", item.dolar.ToString("0.00", CultureInfo.InvariantCulture), item.euro.ToString("0.00", CultureInfo.InvariantCulture), item.fecha.ToString("yyyy-MM-dd")));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Remove(Trm item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.AppendLine("delete from OrkTrm ");
                oSql.AppendLine(string.Format("where fecha = '{0}'", item.fecha.ToString("yyyy-MM-dd")));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public Asiento LiquidateDifferenceOnChange(string filial, Trm valoresLiquidar)
        {
            List<HistoricoPadrao> histPadrao = GetHistoricosPadrao();

            #region Encabezado Asiento
            Asiento asiento = new Asiento()
            {
                codigoFilial = filial,
                fecha = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                terminal = "1"
            };
            #endregion

            #region Detalle
            Trm trmTienda = GetStoreTrm(valoresLiquidar.fecha);

            double valorUSDSegunTienda = valoresLiquidar.dolar * trmTienda.dolar;
            double valorEURSegunTienda = valoresLiquidar.euro * trmTienda.euro;

            double valorUSDOficial = valoresLiquidar.dolar * GetOficialTrm(valoresLiquidar.fecha, "USD");
            double valorEUROficial = valoresLiquidar.euro * GetOficialTrm(valoresLiquidar.fecha, "EUR");

            double diferenciaUSD = Math.Abs(valorUSDOficial - valorUSDSegunTienda);
            double diferenciaEUR = Math.Abs(valorEUROficial - valorEURSegunTienda);

            string historicoCajaPesos = "", historicoCajaDolar = "", historicoCajaEuros = "", historicoDifGasto = "", historicoDifIngreso = "";

            historicoCajaPesos = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("difCambioTipoLancCajaTiendasPesos")).FirstOrDefault().historicoPadrao;
            historicoCajaDolar = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("difCambioTipoLancCajaTiendasDolar")).FirstOrDefault().historicoPadrao;
            historicoCajaEuros = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("difCambioTipoLancCajaTiendasEuros")).FirstOrDefault().historicoPadrao;
            historicoDifIngreso = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("difCambioTipoLancIngreso")).FirstOrDefault().historicoPadrao;
            historicoDifGasto = histPadrao.Where(x => x.codigoHistorico.Trim() == obtenerParametro("difCambioTipoLancGasto")).FirstOrDefault().historicoPadrao;


            #region Dolares
            if (valoresLiquidar.dolar > 0)
            {
                AsientoDetalle reclasificacionCrUSD = new AsientoDetalle()
                {
                    contaContabil = obtenerParametro("difCambioCuentaCajaTiendasPesos"),
                    lxTipoLancamento = obtenerParametro("difCambioTipoLancCajaTiendasPesos"),
                    cambioNaData = 1,
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = obtenerParametro("difCambioTipoLancCajaTiendasPesos"),
                    historico = historicoCajaPesos,
                    credito = valorUSDSegunTienda,
                    debito = 0,
                    creditoMoeda = valorUSDSegunTienda,
                    debitoMoeda = 0,
                    moeda = "COP",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(reclasificacionCrUSD);

                AsientoDetalle reclasificacionDbUSD = new AsientoDetalle()
                {
                    contaContabil = obtenerParametro("difCambioCuentaCajaTiendasDolar"),
                    lxTipoLancamento = obtenerParametro("difCambioTipoLancCajaTiendasDolar"),
                    cambioNaData = GetOficialTrm(valoresLiquidar.fecha, "USD"),
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = obtenerParametro("difCambioTipoLancCajaTiendasDolar"),
                    historico = historicoCajaDolar,
                    credito = 0,
                    debito = valorUSDOficial,
                    creditoMoeda = 0,
                    debitoMoeda = valoresLiquidar.dolar,
                    moeda = "USD",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(reclasificacionDbUSD);

                AsientoDetalle DiferenciaCambioUSD = new AsientoDetalle()
                {
                    contaContabil = valorUSDOficial < valorUSDSegunTienda ? obtenerParametro("difCambioGasto") : obtenerParametro("difCambioIngreso"),
                    lxTipoLancamento = valorUSDOficial < valorUSDSegunTienda ? obtenerParametro("difCambioTipoLancGasto") : obtenerParametro("difCambioTipoLancIngreso"),
                    cambioNaData = 1,
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = valorUSDOficial < valorUSDSegunTienda ? obtenerParametro("difCambioTipoLancGasto") : obtenerParametro("difCambioTipoLancIngreso"),
                    historico = valorUSDOficial < valorUSDSegunTienda ? historicoDifGasto : historicoDifIngreso,
                    credito = valorUSDOficial < valorUSDSegunTienda? 0 :diferenciaUSD,
                    debito = valorUSDOficial > valorUSDSegunTienda ? 0 : diferenciaUSD,
                    creditoMoeda = valorUSDOficial < valorUSDSegunTienda ? 0 : diferenciaUSD,
                    debitoMoeda = valorUSDOficial > valorUSDSegunTienda ? 0 : diferenciaUSD,
                    moeda = "COP",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(DiferenciaCambioUSD);
            }
            #endregion

            #region Euros
            if (valoresLiquidar.euro > 0)
            {
                AsientoDetalle reclasificacionCrEUR = new AsientoDetalle()
                {
                    contaContabil = obtenerParametro("difCambioCuentaCajaTiendasPesos"),
                    lxTipoLancamento = obtenerParametro("difCambioTipoLancCajaTiendasPesos"),
                    cambioNaData = 1,
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = obtenerParametro("difCambioTipoLancCajaTiendasPesos"),
                    historico = historicoCajaPesos,
                    credito = valorEURSegunTienda,
                    debito = 0,
                    creditoMoeda = valorEURSegunTienda,
                    debitoMoeda = 0,
                    moeda = "COP",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(reclasificacionCrEUR);

                AsientoDetalle reclasificacionDbEUR = new AsientoDetalle()
                {
                    contaContabil = obtenerParametro("difCambioCuentaCajaTiendasEuros"),
                    lxTipoLancamento = obtenerParametro("difCambioTipoLancCajaTiendasEuros"),
                    cambioNaData = GetOficialTrm(valoresLiquidar.fecha, "EUR"),
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = obtenerParametro("difCambioTipoLancCajaTiendasEuros"),
                    historico = historicoCajaEuros,
                    credito = 0,
                    debito = valorEUROficial,
                    creditoMoeda = 0,
                    debitoMoeda = valoresLiquidar.euro,
                    moeda = "EUR",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(reclasificacionDbEUR);

                AsientoDetalle DiferenciaCambioEUR = new AsientoDetalle()
                {
                    contaContabil = valorEUROficial < valorEURSegunTienda ? obtenerParametro("difCambioGasto") : obtenerParametro("difCambioIngreso"),
                    lxTipoLancamento = valorUSDOficial < valorUSDSegunTienda ? obtenerParametro("difCambioTipoLancGasto") : obtenerParametro("difCambioTipoLancIngreso"),
                    cambioNaData = 1,
                    codClifor = obtenerParametro("clienteGenerico"),
                    codigoHistorico = valorEUROficial < valorEURSegunTienda ? obtenerParametro("difCambioTipoLancGasto") : obtenerParametro("difCambioTipoLancIngreso"),
                    historico = valorEUROficial < valorEURSegunTienda ? historicoDifGasto : historicoDifIngreso,
                    credito = valorEUROficial < valorEURSegunTienda ? 0 : diferenciaEUR,
                    debito = valorEUROficial > valorEURSegunTienda ? 0 : diferenciaEUR,
                    creditoMoeda = valorEUROficial < valorEURSegunTienda ? 0 : diferenciaEUR,
                    debitoMoeda = valorEUROficial > valorEURSegunTienda ? 0 : diferenciaEUR,
                    moeda = "COP",
                    dataDigitacao = valoresLiquidar.fecha.ToString("yyyy-MM-dd"),
                    permiteAlteracao = 1,
                    rateioCentroCusto = filial,
                    rateioFilial = filial,
                };

                asiento.lineas.Add(DiferenciaCambioEUR);
            }
            #endregion          

            #region Informacion complementaria
            BizCuentasTipoPago bizCuentasTipoPago = new BizCuentasTipoPago(_connStrPos, _connStrErp);
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
                    try
                    {
                        if (string.IsNullOrEmpty(item.codClifor))
                            item.nombreCliente = string.Empty;
                        else
                            item.nombreCliente = terceros.Where(x => x.codClifor.Trim() == item.codClifor.Trim()).FirstOrDefault().desCliente;
                    }
                    catch (Exception)
                    {
                        item.nombreCliente = string.Format("{0} *** No se pudo encontrar el tercero ***", item.codClifor.Trim());                        
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
                        item.desConta = string.Format("No se pudo encontrar la cuenta {0}", item.contaContabil.Trim());
                    }

                #endregion
            }

            #endregion
            
            #endregion
            return asiento;
        }

        public string SaveJournalEntry(Asiento asiento)
        {
            string lanzamiento = "";
            StringBuilder log = new StringBuilder();
            int errores = 0;
            try
            {
                // validacion de periodos pendientes
                if (DiferenciaEncambioIntegrada(asiento.codigoFilial, asiento.fecha))
                {
                    log.AppendLine(string.Format("Ya existe un calculo de diferencia en cambio para la tienda {0} en el periodo {1}|{2}|{3}", asiento.codigoFilial, asiento.fecha, errores.ToString(), 0));
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


                log.AppendLine(string.Format("Inicia proceso de diferencia en cambio para la tienda {0}, periodo {1}", asiento.terminal, asiento.fecha));
                log.AppendLine("");

                string sqlEncabezado = string.Format("exec orkCrearEncabezadoAsiento '{0}', '{1}'", asiento.fecha, asiento.codigoFilial);

                lanzamiento = SqlServer.ExecuteScalar(_connStrErp, CommandType.Text, sqlEncabezado).ToString();
                log.AppendLine(string.Format("Se crea el encabezado para el asiento con numero {0}", lanzamiento));

                string sqlCreaLog = string.Format("insert into orkHistoricoIntegracion select '{0}', {1}, '{2}', getdate(), 'D'", asiento.codigoFilial, asiento.terminal, asiento.fecha);
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

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, string.Format("delete from orkHistoricoIntegracion where filial = '{0}' and periodoIntegrado = '{1}' and tipoIntegracion = 'D'", asiento.codigoFilial, asiento.fecha));
                return "se eliminó el asiento";
            }
            catch (Exception ex)
            {
                return string.Format("No se pudo eliminar el asiento porque {0}", ex.Message);
            }
        }

        private bool DiferenciaEncambioIntegrada(string filial, string fecha)
        {
            bool res = false;

            StringBuilder oSql = new StringBuilder();

            oSql.AppendLine("select count(1) from orkHistoricoIntegracion ");
            oSql.AppendLine(string.Format("where fechaProceso = '{0}' and filial= '{1}' and tipoIntegracion != 'I'", filial, fecha));

            var asientos = SqlServer.ExecuteScalar(_connStrPos, CommandType.Text, oSql.ToString());

            if ((int)asientos > 0)
                res = true;

            return res;
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

        private List<Tercero> ObtenerTerceros(string terceros)
        {
            string oSql = string.Format("select CLIFOR, clifor  + ' ::: ' + NOME_CLIFOR NOME_CLIFOR from CADASTRO_CLI_FOR where CLIFOR in ({0})", terceros);
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            List<Tercero> list = new List<Tercero>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Tercero()
                {
                    codClifor = row[0].ToString(),
                    desCliente = row[1].ToString()
                });
            }

            return list;
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
    }
}
