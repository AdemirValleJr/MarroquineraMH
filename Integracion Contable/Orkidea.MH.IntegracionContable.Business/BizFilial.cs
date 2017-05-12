using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orkidea.MH.IntegracionContable.Entities;
using System.Data;
using Macondo.AccesoDatos;
using System.Configuration;

namespace Orkidea.MH.IntegracionContable.Business
{
    public class BizFilial
    {
        public string _connStrPos { get; set; }

        public BizFilial(string connStrPos)
        {
            _connStrPos = connStrPos;
        }

        public List<Filial> GetList()
        {
            string[] redesTiendas = ConfigurationManager.AppSettings["redTiendas"].ToString().Split('-');

            StringBuilder redTiendas = new StringBuilder();

            for (int i = 0; i < redesTiendas.Length; i++)
            {
                redTiendas.Append(string.Format("'{0}'", redesTiendas[i]));

                if (i < redesTiendas.Length - 1)
                    redTiendas.Append(",");
            }
            
            string oSql = string.Format("Select cod_filial, filial from filiais where rede_lojas in ({0}) order by filial", redTiendas.ToString());
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<Filial> list = new List<Filial>();
            List<Terminal> listTerminals = GetTerminalList();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Filial()
                {
                    cod_filial = row[0].ToString(),
                    filial = row[1].ToString(),
                    terminal = listTerminals.Where(x => x.codigo_filial == row[0].ToString()).ToList()
                });
            }

            return list;
        }

        public List<Terminal> GetTerminalList()
        {
            string oSql = string.Format("select CODIGO_FILIAL, TERMINAL from LOJA_TERMINAIS order by CODIGO_FILIAL");
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<Terminal> list = new List<Terminal>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Terminal()
                {
                    codigo_filial = row[0].ToString(),
                    terminal = row[1].ToString()
                });
            }

            return list;
        }        
    }
}
