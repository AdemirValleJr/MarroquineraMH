using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizReportesInventario
    {
        public static IList<KardexTiendaProductoColor> ReporteKardexFilialProdutoCor(string idtienda, string producto, string color)
        {

            Tienda tienda = BizTienda.GetSingle(idtienda);

            StringBuilder oSql = new StringBuilder();

            oSql.Append("SELECT TIPOMOVTO tipoMovimiento, DOC documento, PRODUTO idProducto, COR_PRODUTO idColor, FILIAL idTienda, LEFT(CONVERT(VARCHAR, EMISSAO, 120), 10) fecha, OP_PED_ROMAN idPedidoRemision, TT_MOV totalMov, TT_saldo totalSaldo, ");
            oSql.Append("EN_1 mov01, EN_2 mov02, EN_3 mov03, EN_4 mov04, EN_5 mov05, EN_6 mov06, EN_7 mov07, EN_8 mov08, EN_9 mov09, EN_10 mov10, ");
            oSql.Append("EN_11 mov11, EN_12 mov12, EN_13 mov13, EN_14 mov14, EN_15 mov15, EN_16 mov16, EN_17 mov17, EN_18 mov18, EN_19 mov19, EN_20 mov20, ");
            oSql.Append("EN_21 mov21, EN_22 mov22, EN_23 mov23, EN_24 mov24, EN_25 mov25, EN_26 mov26, EN_27 mov27, EN_28 mov28, EN_29 mov29, EN_30 mov30, ");
            oSql.Append("EN_31 mov31, EN_32 mov32, EN_33 mov33, EN_34 mov34, EN_35 mov35, EN_36 mov36, EN_37 mov37, EN_38 mov38, EN_39 mov39, EN_40 mov40, ");
            oSql.Append("EN_41 mov41, EN_42 mov42, EN_43 mov43, EN_44 mov44, EN_45 mov45, EN_46 mov46, EN_47 mov47, EN_48 mov48, ");
            oSql.Append("saldo1 saldo01, saldo2 saldo02, saldo3 saldo03, saldo4 saldo04, saldo5 saldo05, saldo6 saldo06, saldo7 saldo07, saldo8 saldo08, saldo9 saldo09, saldo10, ");
            oSql.Append("saldo11, saldo12, saldo13, saldo14, saldo15, saldo16, saldo17, saldo18, saldo19, saldo20, ");
            oSql.Append("saldo21, saldo22, saldo23, saldo24, saldo25, saldo26, saldo27, saldo28, saldo29, saldo30, ");
            oSql.Append("saldo31, saldo32, saldo33, saldo34, saldo35, saldo36, saldo37, saldo38, saldo39, saldo40, ");
            oSql.Append("saldo41, saldo42, saldo43, saldo44, saldo45, saldo46, saldo47, saldo48, PRECO precio, VALOR valor ");
            oSql.Append(string.Format("FROM FX_MONTA_CARDEX_PA('{0}', '{1}', '{2}', 0)  ", producto, color, tienda.descripcion));
            oSql.Append("ORDER BY EMISSAO desc, TIPOMOVTO, DOC, FILIAL, PRODUTO, COR_PRODUTO,  OP_PED_ROMAN");


            return DbMngmt<KardexTiendaProductoColor>.executeSqlQueryToList(oSql.ToString());
        }


        public static void ReporteStock(string idTienda, string idGrupo, string idSubgrupo, string idModelo, string idFabricante, string idGenero, string idTemporada, string idTipoProducto, string idProducto, string talla) {

            StringBuilder camposSql = new StringBuilder();
            camposSql.Append("Select ");



        }

        

    }
}
