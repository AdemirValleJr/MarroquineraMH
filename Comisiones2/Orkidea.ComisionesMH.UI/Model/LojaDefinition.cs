using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.Business;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.UI.Model
{
    public class LojaDefinition
    {
        BizAdministradorasCartao bizAdministradorasCartao = new BizAdministradorasCartao();
        BizCadastroCliFor bizCadastroCliFor = new BizCadastroCliFor();
        BizPropLojasVarejo bizPropLojasVarejo = new BizPropLojasVarejo();
        BizPresupuestoTendas bizPresupuestoTendas = new BizPresupuestoTendas();
        BizLojaVendedores bizLojaVendedores = new BizLojaVendedores();
        BizParametroTienda bizParametroTienda = new BizParametroTienda();

        public string COD_FILIAL { get; set; }
        public string UF { get; set; }
        public decimal IVA { get; set; }
        public decimal P_01 { get; set; }
        public decimal P_02 { get; set; }
        public decimal P_03 { get; set; }
        public decimal P_04 { get; set; }
        public decimal P_05 { get; set; }
        public decimal P_06 { get; set; }
        public decimal P_07 { get; set; }
        public decimal P_08 { get; set; }
        public decimal P_09 { get; set; }
        public decimal P_10 { get; set; }
        public decimal P_11 { get; set; }
        public decimal P_12 { get; set; }

        public CSS_PARAMETRO_TIENDA gerenteLoja { get; set; }
        public string porComisionAdministrador { get; set; }
        public string porComisionVendedor { get; set; }
        public List<PRODUTOS> lstProdBonos { get; set; }
        public List<TIPOS_PGTO> lstTiposPgtoBonos { get; set; }
        public List<ADMINISTRADORAS_CARTAO> lstAdministradorasCartao { get; set; }
        public List<LOJA_VENDEDORES> lstvendedores { get; set; }
        //public List<FORNECEDORES> lstFornecedores { get; set; }

        public decimal ventasLoja { get; set; }
        public bool cumplePresupuesto { get; set; }

        public LojaDefinition(CADASTRO_CLI_FOR cadastroCliFor)
        {
            #region Adminisrtador Tienda
            gerenteLoja = bizParametroTienda.getParametroTienda(new CSS_PARAMETRO_TIENDA() { tienda = cadastroCliFor.CLIFOR });
             
            #endregion

            CADASTRO_CLI_FOR impostoLoja = bizCadastroCliFor.getCadastroCliFor(new CADASTRO_CLI_FOR() { CLIFOR = cadastroCliFor.CLIFOR });

            lstAdministradorasCartao = bizAdministradorasCartao.getAdministradorasCartaoList();

            lstvendedores = bizLojaVendedores.GetVendedorList();//new FILIAIS() { COD_FILIAL = cadastroCliFor.CLIFOR });            

            #region Impuestos
            decimal imposto = 16;

            switch (impostoLoja.UF)
            {
                case "PA":
                    imposto = 18;
                    break;
                case "CR":
                    imposto = 21;
                    break;
                case "MX":
                    imposto = 4;
                    break;
                case "VZ":
                    imposto = 3;
                    break;
                default:
                    imposto = 16;
                    break;
            } 
            #endregion

            COD_FILIAL = cadastroCliFor.CLIFOR;
            IVA = imposto;
            UF = cadastroCliFor.UF;
            
            porComisionAdministrador = "0";// lsPropLojasVarejo.Where(x => x.PROPRIEDADE == "00028").Select(x => x.VALOR_PROPRIEDADE).FirstOrDefault();
            porComisionVendedor = "0";// lsPropLojasVarejo.Where(x => x.PROPRIEDADE == "00029").Select(x => x.VALOR_PROPRIEDADE).FirstOrDefault();

            #region Parametros app.config
            lstProdBonos = new List<PRODUTOS>();
            lstTiposPgtoBonos = new List<TIPOS_PGTO>();

            string[] prodBonos = ConfigurationManager.AppSettings["productosBonos"].ToString().Split(',');

            foreach (string item in prodBonos)
                lstProdBonos.Add(new PRODUTOS() { PRODUTO = item });

            string[] formaPagoBonos = ConfigurationManager.AppSettings["formaPagoBonos"].ToString().Split(',');

            foreach (string item in formaPagoBonos)
                lstTiposPgtoBonos.Add(new TIPOS_PGTO() { TIPO_PGTO = item }); 
            #endregion
        }

        public void calculaCumplimiento(FILIAIS tienda,  DateTime fecha)
        {            
            decimal presupuesto = 0;
            int año = fecha.Year;
            int mes = fecha.Month;
            List<CSS_PRESUPUESTO_TIENDAS> lstPresupuesto = bizPresupuestoTendas.getPresupuestoVentasList(tienda, año); ;

            #region Presupuesto para el mes

            P_01 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(1)).Select(x => x.presupuesto).FirstOrDefault();
            P_02 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(2)).Select(x => x.presupuesto).FirstOrDefault();
            P_03 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(3)).Select(x => x.presupuesto).FirstOrDefault();
            P_04 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(4)).Select(x => x.presupuesto).FirstOrDefault();
            P_05 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(5)).Select(x => x.presupuesto).FirstOrDefault();
            P_06 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(6)).Select(x => x.presupuesto).FirstOrDefault();
            P_07 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(7)).Select(x => x.presupuesto).FirstOrDefault();
            P_08 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(8)).Select(x => x.presupuesto).FirstOrDefault();
            P_09 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(9)).Select(x => x.presupuesto).FirstOrDefault();
            P_10 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(10)).Select(x => x.presupuesto).FirstOrDefault();
            P_11 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(11)).Select(x => x.presupuesto).FirstOrDefault();
            P_12 = lstPresupuesto.Where(x => x.ano.Equals(año) && mes.Equals(12)).Select(x => x.presupuesto).FirstOrDefault();

            try
            {
                switch (mes)
                {
                    case 1:
                        presupuesto = P_01;
                        break;
                    case 2:
                        presupuesto = P_02;
                        break;
                    case 3:
                        presupuesto = P_03;
                        break;
                    case 4:
                        presupuesto = P_04;
                        break;
                    case 5:
                        presupuesto = P_05;
                        break;
                    case 6:
                        presupuesto = P_06;
                        break;
                    case 7:
                        presupuesto = P_07;
                        break;
                    case 8:
                        presupuesto = P_08;
                        break;
                    case 9:
                        presupuesto = P_09;
                        break;
                    case 10:
                        presupuesto = P_10;
                        break;
                    case 11:
                        presupuesto = P_11;
                        break;
                    case 12:
                        presupuesto = P_12;
                        break;
                    default:
                        presupuesto = 0;
                        break;
                }
            }
            catch (Exception)
            {
                presupuesto = -1;
            } 
            #endregion

            if (presupuesto > 0)
                if (ventasLoja >= presupuesto)
                    cumplePresupuesto = true;
                else
                    cumplePresupuesto = false;
            else
                cumplePresupuesto = false;
        }
    }
}
