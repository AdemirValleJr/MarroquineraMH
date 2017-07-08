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

            //oSql.Append("SELECT TIPOMOVTO tipoMovimiento, DOC documento, PRODUTO idProducto, COR_PRODUTO idColor, FILIAL idTienda, LEFT(CONVERT(VARCHAR, EMISSAO, 120), 10) fecha, OP_PED_ROMAN idPedidoRemision, TT_MOV totalMov, TT_saldo totalSaldo, ");
            oSql.Append("SELECT TIPOMOVTO tipoMovimiento, DOC documento, PRODUTO idProducto, LEFT(CONVERT(VARCHAR, EMISSAO, 120), 10) fecha, ");
            oSql.Append("COR_PRODUTO idColor, FILIAL idTienda, OP_PED_ROMAN idPedidoRemision, TT_MOV totalMov, TT_saldo totalSaldo, ");
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
            oSql.Append("ORDER BY EMISSAO, TIPOMOVTO, DOC, FILIAL, PRODUTO, COR_PRODUTO,  OP_PED_ROMAN");


            return DbMngmt<KardexTiendaProductoColor>.executeSqlQueryToList(oSql.ToString());
        }


        public static IList<SellTru> ReporteSellThru(string productFilters, string storeFilters, string groupers)
        {

            //Obtener productos a consultar
            #region filtro productos
            string productFilter = string.Empty;

            string[] filters = productFilters.Split('@');
            bool gotFilter = false, addAnd = false;
            StringBuilder oSql = new StringBuilder();

            if (!string.IsNullOrEmpty(productFilters.Split('@')[7]))
                productFilter = string.Format(" = '{0}'", productFilters.Split('@')[7]);
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    if (!string.IsNullOrEmpty(filters[i]))
                    {
                        if (!gotFilter)
                        {
                            gotFilter = true;
                        }

                        switch (i)
                        {
                            case 0:
                                oSql.Append(string.Format("CODIGO_GRUPO = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 1:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("CODIGO_SUBGRUPO = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 2:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("SEXO_TIPO = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 3:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("MODELAGEM = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 4:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("CLIFOR = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 5:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("COLECAO = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            case 6:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("COD_TIPO_PRODUTO = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            default:
                                break;
                        }
                    }
                }

                productFilter = oSql.ToString();
            }
            #endregion            

            // filtro por color
            string colorFilter = string.Empty; 

            if (!string.IsNullOrEmpty(productFilters.Split('@')[8]))
            {
                if (!string.IsNullOrEmpty(productFilter))                                 
                    colorFilter = " AND ";

                colorFilter += string.Format("cor_produto = '{0}' ", productFilters.Split('@')[8]);
            }

            // filtro por fecha
            string dateFilter = string.Empty;

            if (!string.IsNullOrEmpty(productFilters.Split('@')[9]))
            {
                if (!string.IsNullOrEmpty(productFilter + colorFilter))                    
                    dateFilter = " AND ";

                dateFilter += string.Format("data_venda <= '{0}'", productFilters.Split('@')[9]);
            }

            //Obtener tiendas a consultar
            string storeFilter = string.Empty;

            if (!string.IsNullOrEmpty(storeFilters.Split('@')[1]))
            {
                if (!string.IsNullOrEmpty(productFilter + colorFilter + dateFilter))
                    storeFilter = " AND ";

                storeFilter += string.Format("COD_FILIAL = '{0}' ", storeFilters.Split('@')[1]);
            }
            else if (!string.IsNullOrEmpty(storeFilters.Split('@')[0]))
            {
                if (!string.IsNullOrEmpty(productFilter + colorFilter + dateFilter))
                    storeFilter = " AND ";

                storeFilter += string.Format("REDE_LOJAS = ({0}) ", storeFilters.Split('@')[0]);
            }
            else
                storeFilter = "";

            //Obtener campos agrupadores
            #region Columnas
            string[] agrupador = groupers.Split('@');
            string agrupadores = "";

            if (!string.IsNullOrEmpty(agrupador[0]))
                agrupadores = "DESC_REDE_LOJAS";

            if (!string.IsNullOrEmpty(agrupador[1]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "FILIAL";
                else
                    agrupadores += ", FILIAL";

            if (!string.IsNullOrEmpty(agrupador[2]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "GRUPO_PRODUTO";
                else
                    agrupadores += ", GRUPO_PRODUTO";

            if (!string.IsNullOrEmpty(agrupador[3]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "SUBGRUPO_PRODUTO";
                else
                    agrupadores += ", SUBGRUPO_PRODUTO";

            if (!string.IsNullOrEmpty(agrupador[4]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_MODELO";
                else
                    agrupadores += ", DESC_MODELO";

            if (!string.IsNullOrEmpty(agrupador[5]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "FABRICANTE";
                else
                    agrupadores += ", FABRICANTE";

            if (!string.IsNullOrEmpty(agrupador[6]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "COLECAO";
                else
                    agrupadores += ", COLECAO";

            if (!string.IsNullOrEmpty(agrupador[7]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_SEXO_TIPO";
                else
                    agrupadores += ", DESC_SEXO_TIPO";

            if (!string.IsNullOrEmpty(agrupador[8]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "TIPO_PRODUTO";
                else
                    agrupadores += ", TIPO_PRODUTO";

            if (!string.IsNullOrEmpty(agrupador[9]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_COR";
                else
                    agrupadores += ", DESC_COR";

            if (!string.IsNullOrEmpty(agrupador[10]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_PRODUTO";
                else
                    agrupadores += ", DESC_PRODUTO";

            if (!string.IsNullOrEmpty(agrupadores))
                agrupadores += ", ";

            #endregion


            // Obtener sell thru
            StringBuilder oSqlSellThru = new StringBuilder();
            oSqlSellThru.Append(string.Format("SELECT {0} ", agrupadores));
            oSqlSellThru.Append(" SEMANAS, SUM(ESTOQUE) STOCK, SUM(qtde) Venta, AVG(qtde) ventaPromedio, round(cast(SUM(qtde) as decimal(14,2))/(SUM(ESTOQUE)+ SUM(qtde)), 2) sellThru, ");
            oSqlSellThru.Append(" round(cast(SUM(ESTOQUE)as decimal(14,2))/ SUM(qtde), 2) mesesInventario ");
            oSqlSellThru.Append(" FROM ORK_SELLTHRU ");
            oSqlSellThru.Append(string.Format("WHERE {0} ", productFilter));
            oSqlSellThru.Append(colorFilter);
            oSqlSellThru.Append(string.Format("{0} ", dateFilter));
            oSqlSellThru.Append(string.Format("{0} ", storeFilter));            
            oSqlSellThru.Append(string.Format("GROUP BY {0} SEMANAS ", agrupadores));

            return DbMngmt<SellTru>.executeSqlQueryToList(oSqlSellThru.ToString());
        }
    }
}
