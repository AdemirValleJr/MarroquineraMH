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

            string[] filters = productFilters.Split(new[] { "--" }, StringSplitOptions.None);
            bool gotFilter = false, addAnd = false;
            StringBuilder oSql = new StringBuilder();

            if (!string.IsNullOrEmpty(productFilters.Split(new[] { "--" }, StringSplitOptions.None)[8]))
                productFilter = string.Format(" PRODUTO = '{0}'", productFilters.Split(new[] { "--" }, StringSplitOptions.None)[8].Replace('_', '.'));
            else
            {
                for (int i = 0; i < 8; i++)
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

                            case 7:
                                if (addAnd)
                                    oSql.Append(" and ");

                                oSql.Append(string.Format("COD_LINHA = '{0}' ", filters[i]));
                                addAnd = true;
                                break;

                            default:
                                break;
                        }
                    }
                }

                productFilter = oSql.ToString().Trim().Length> 0? string.Format("and {0}", oSql.ToString()):"";
            }
            #endregion            

            // filtro por color
            string colorFilter = string.Empty; 
            string colorSemanas = "'vacio'";

            if (!string.IsNullOrEmpty(productFilters.Split(new[] { "--" }, StringSplitOptions.None)[9]))
            {
                //if (!string.IsNullOrEmpty(productFilter))                                 
                    colorFilter = " AND ";

                colorFilter += string.Format("cor_produto = '{0}' ", productFilters.Split(new[] { "--" }, StringSplitOptions.None)[9]);
                colorSemanas = "a.cor_produto";
            }

            // filtro por fecha
            string dateFilter = string.Empty;
            string dateColumn = string.Empty;

            if (!string.IsNullOrEmpty(productFilters.Split(new[] { "--" }, StringSplitOptions.None)[10]) && !string.IsNullOrEmpty(productFilters.Split(new[] { "--" }, StringSplitOptions.None)[11]))
            {
                string dateFrom = productFilters.Split(new[] { "--" }, StringSplitOptions.None)[10];
                string dateTo = productFilters.Split(new[] { "--" }, StringSplitOptions.None)[11];

                dateFilter = string.Format("data_venda between '{0}' and '{1}'", dateFrom , dateTo);

                if (dateFrom.Split('-')[1] == dateTo.Split('-')[1])
                    dateColumn = "1";
                else
                    dateColumn = string.Format(" DATEDIFF(MM, '{0}','{1}')", dateFrom, dateTo);
            }

            //Obtener tiendas a consultar
            string storeFilter = string.Empty;

            if (!string.IsNullOrEmpty(storeFilters.Split(new[] { "--" }, StringSplitOptions.None)[1]))
            {
                //if (!string.IsNullOrEmpty(productFilter + colorFilter))
                    storeFilter = " AND ";

                storeFilter += string.Format("a.COD_FILIAL = '{0}' ", storeFilters.Split(new[] { "--" }, StringSplitOptions.None)[1]);
            }
            else if (!string.IsNullOrEmpty(storeFilters.Split(new[] { "--" }, StringSplitOptions.None)[0]))
            {
                //if (!string.IsNullOrEmpty(productFilter + colorFilter))
                    storeFilter = " AND ";

                storeFilter += string.Format("REDE_LOJAS = ({0}) ", storeFilters.Split(new[] { "--" }, StringSplitOptions.None)[0]);
            }
            else
                storeFilter = "";

            //Obtener campos agrupadores
            #region Columnas
            string[] agrupador = groupers.Split(new[] { "--" }, StringSplitOptions.None);
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
            {
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_COR, a.cor_produto";
                else
                    agrupadores += ", DESC_COR, a.cor_produto";

                colorSemanas = "a.cor_produto";
            }

            if (!string.IsNullOrEmpty(agrupador[10]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "DESC_PRODUTO";
                else
                    agrupadores += ", DESC_PRODUTO";

            if (!string.IsNullOrEmpty(agrupador[11]))
                if (string.IsNullOrEmpty(agrupadores))
                    agrupadores = "LINHA";
                else
                    agrupadores += ", LINHA";

            if (!string.IsNullOrEmpty(agrupadores))
                agrupadores += ", ";

            #endregion


            // Obtener sell thru
            StringBuilder oSqlSellThru = new StringBuilder();

            /*
            oSqlSellThru.Append(string.Format("SELECT {0} ", agrupadores));
            oSqlSellThru.Append(" SEMANAS, SUM(ESTOQUE) STOCK, SUM(qtde) Venta, AVG(qtde) ventaPromedio, round(cast(SUM(qtde) as decimal(14,2))/(SUM(ESTOQUE)+ SUM(qtde)), 2) sellThru, ");
            oSqlSellThru.Append(" round(cast(SUM(ESTOQUE)as decimal(14,2))/ SUM(qtde), 2) mesesInventario ");
            oSqlSellThru.Append(" FROM ORK_SELLTHRU ");
            oSqlSellThru.Append(string.Format("WHERE {0} ", productFilter));
            oSqlSellThru.Append(colorFilter);
            oSqlSellThru.Append(string.Format("{0} ", dateFilter));
            oSqlSellThru.Append(string.Format("{0} ", storeFilter));            
            oSqlSellThru.Append(string.Format("GROUP BY {0} SEMANAS ", agrupadores));
            */

            //oSqlSellThru.Append(string.Format("SELECT {0} ", agrupadores));
            //oSqlSellThru.Append("LEFT(CONVERT(VARCHAR, EMISSAO, 120), 10) EMISSAO, SEMANAS, SUM(ESTOQUE) STOCK, SUM(qtde) Venta ");
            //oSqlSellThru.Append(",case when SUM(ESTOQUE) + SUM(qtde) > 0 then round(cast(SUM(qtde) as decimal(14,2))/(SUM(ESTOQUE)+ SUM(qtde)), 2) else 0 end sellThru ");
            ////oSqlSellThru.Append(",case when SUM(qtde) > 0 then round(cast(SUM(ESTOQUE)as decimal(14,2))/ SUM(qtde), 2) else 0 end mesesInventario ");            
            //oSqlSellThru.Append(string.Format(",case when SUM(ESTOQUE) + SUM(qtde) > 0 then round(SUM(ESTOQUE)/(SUM(cast(qtde as decimal(14,2)))/{0}), 2) else 0 end mesesInventario ", dateColumn));
            //oSqlSellThru.Append("from (select a.CODIGO_GRUPO, a.GRUPO_PRODUTO, a.CODIGO_SUBGRUPO, a.SUBGRUPO_PRODUTO, a.SEXO_TIPO, a.DESC_SEXO_TIPO, a.MODELAGEM, a.DESC_MODELO, a.CLIFOR ");
            //oSqlSellThru.Append(", a.FABRICANTE, a.COLECAO, a.COD_TIPO_PRODUTO, a.TIPO_PRODUTO, a.PRODUTO, a.PRODUTO + ':' + a.DESC_PRODUTO DESC_PRODUTO  , a.COR_PRODUTO, a.DESC_COR ");
            //oSqlSellThru.Append(", a.REDE_LOJAS, a.DESC_REDE_LOJAS, a.COD_FILIAL, a.FILIAL, a.ESTOQUE, b.QTDE, a.COD_LINHA, a.LINHA, SEMANAS, EMISSAO ");
            //oSqlSellThru.Append("from ORK_SELLTHRU_STOCK a inner join (SELECT PRODUTO, COR_PRODUTO, COD_FILIAL, sum(QTDE) QTDE ");
            //oSqlSellThru.Append(string.Format("from ORK_SELLTHRU_VENTA where {0} group by PRODUTO, COR_PRODUTO, COD_FILIAL ) b ON ", dateFilter));
            //oSqlSellThru.Append("a.PRODUTO = b.PRODUTO AND a.COR_PRODUTO = b.COR_PRODUTO AND a.COD_FILIAL = b.COD_FILIAL ");
            //oSqlSellThru.Append("LEFT JOIN ORK_SELLTHRU_SEMANAS_INVENTARIO c ON a.PRODUTO = c.PRODUTO ) c ");

            //oSqlSellThru.Append(string.Format("WHERE {0} ", productFilter));
            //oSqlSellThru.Append(colorFilter);
            //oSqlSellThru.Append(string.Format("{0} ", storeFilter));
            //oSqlSellThru.Append(string.Format("GROUP BY {0} LEFT(CONVERT(VARCHAR, EMISSAO, 120), 10), SEMANAS ", agrupadores));

            oSqlSellThru.AppendLine("declare @ventas table (rede_lojas varchar(6), cod_filial varchar(5), produto varchar(15), cor_produto varchar(5), qtde int) ");
            oSqlSellThru.AppendLine("declare @stock table (rede_lojas varchar(6), cod_filial varchar(5), produto varchar(15), cor_produto varchar(5), stock int) ");
            oSqlSellThru.AppendLine("declare @baseSellThru table (rede_lojas varchar(6), cod_filial varchar(5), produto varchar(15), cor_produto varchar(5), qtde int, stock int) ");
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("insert into @ventas ");
            oSqlSellThru.AppendLine("SELECT a.REDE_LOJAS, COD_FILIAL, a.PRODUTO, COR_PRODUTO, sum(QTDE) QTDE ");
            oSqlSellThru.AppendLine("from ORK_SELLTHRU_VENTA a INNER JOIN ORK_PRODUTO b on a.produto = b.produto");
            oSqlSellThru.AppendLine(string.Format("where {0} ", dateFilter));
            oSqlSellThru.AppendLine(string.Format("{0} ", productFilter));
            oSqlSellThru.AppendLine(string.Format("{0} ", colorFilter));
            oSqlSellThru.AppendLine(string.Format("{0} ", storeFilter));
            oSqlSellThru.AppendLine("group by a.REDE_LOJAS, a.PRODUTO, COR_PRODUTO, COD_FILIAL ");
            oSqlSellThru.AppendLine("");            
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("insert into @stock ");
            oSqlSellThru.AppendLine("SELECT a.REDE_LOJAS, COD_FILIAL, a.PRODUTO, COR_PRODUTO, sum(estoque) QTDE  ");
            oSqlSellThru.AppendLine("from ORK_SELLTHRU_STOCK a INNER JOIN ORK_PRODUTO b on a.produto = b.produto");
            oSqlSellThru.AppendLine(string.Format("where {0} ", " 1 = 1"));
            oSqlSellThru.AppendLine(string.Format("{0} ", productFilter));
            oSqlSellThru.AppendLine(string.Format("{0} ", colorFilter));
            oSqlSellThru.AppendLine(string.Format("{0} ", storeFilter));
            oSqlSellThru.AppendLine("group by a.REDE_LOJAS, a.PRODUTO, COR_PRODUTO, COD_FILIAL ");
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("insert into @baseSellThru ");
            oSqlSellThru.AppendLine("select a.rede_lojas, a.cod_filial, a.produto, a.cor_produto, qtde, stock ");
            oSqlSellThru.AppendLine("from @ventas a inner join @stock b on a.produto = b.produto and a.cor_produto = b.cor_produto and a.cod_filial = b.cod_filial");
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine(string.Format("SELECT {0} ", agrupadores));
            oSqlSellThru.AppendLine("SUM(a.stock) STOCK, ");
            oSqlSellThru.AppendLine("SUM(qtde) Venta, ");
            oSqlSellThru.AppendLine("case when SUM(a.stock) + SUM(qtde) > 0 then round(cast(SUM(qtde) as decimal(14,2))/(SUM(a.stock)+ SUM(qtde)), 2) else 0 end sellThru, ");
            oSqlSellThru.AppendLine(string.Format("case when SUM(a.stock) > 0 and SUM(qtde) > 0 then round(SUM(a.stock)/(SUM(cast(qtde as decimal(14,2)))/{0}), 2) else 0 end mesesInventario, ", dateColumn));
            oSqlSellThru.AppendLine(string.Format("LEFT(CONVERT(VARCHAR, dbo.ORK_OBTENER_LLEGADA_INVENTARIO(a.produto, {0}), 120), 10) EMISSAO, ", colorSemanas));
            oSqlSellThru.AppendLine(string.Format("DATEDIFF(Wk, min(dbo.ORK_OBTENER_LLEGADA_INVENTARIO(a.produto, {0})), getdate()) SEMANAS ", colorSemanas));
            oSqlSellThru.AppendLine("from @baseSellThru a inner join ORK_PRODUTO b on a.produto = b.PRODUTO ");
            oSqlSellThru.AppendLine("inner join FILIAIS c ON a.cod_filial = c.cod_filial inner join LOJAS_REDE d ON c.REDE_LOJAS = d.REDE_LOJAS ");
            oSqlSellThru.AppendLine("INNER JOIN CORES_BASICAS e ON a.COR_PRODUTO = e.COR ");
            oSqlSellThru.AppendLine(string.Format("GROUP BY {0} a.produto", agrupadores));
            oSqlSellThru.AppendLine("");
            oSqlSellThru.AppendLine("");
            
            
            

            return DbMngmt<SellTru>.executeSqlQueryToList(oSqlSellThru.ToString());
        }
    }
}
