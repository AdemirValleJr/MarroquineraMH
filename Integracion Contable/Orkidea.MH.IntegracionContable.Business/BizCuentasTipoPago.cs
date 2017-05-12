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
    public class BizCuentasTipoPago
    {
        public string _connStrPos { get; set; }
        public string _connStrErp { get; set; }

        public BizCuentasTipoPago(string connStrPos, string connStrErp)
        {
            _connStrPos = connStrPos;
            _connStrErp = connStrErp;
        }

        public List<CuentaTipoPago> GetList()
        {
            string oSql = "Select * from orkCuentaTipoPago";
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<CuentaTipoPago> list = new List<CuentaTipoPago>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new CuentaTipoPago()
                {
                    tipo_pgto = row[0].ToString(),
                    conta_contabil = row[1].ToString(),
                    tipoLancamento = row[2].ToString(),
                    peso = double.Parse(row[3].ToString()),
                    lineaPorTercero = bool.Parse(row[4].ToString())
                });
            }

            return list;
        }

        public List<CuentaTipoPago> GetList( string tipoPago)
        {
            string oSql = string.Format("Select * from orkCuentaTipoPago where tipo_pgto = '{0}'", tipoPago);
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<CuentaTipoPago> list = new List<CuentaTipoPago>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new CuentaTipoPago()
                {
                    tipo_pgto = row[0].ToString(),
                    conta_contabil = row[1].ToString(),
                    tipoLancamento = row[2].ToString(),
                    peso = double.Parse(row[3].ToString()),
                    lineaPorTercero = bool.Parse(row[4].ToString())
                });
            }

            return list;
        }

        public List<CuentaAdministradora> GetAccountCardList(string tipoPago)
        {
            string oSql = string.Format("Select * from orkCuentaAdministradora where tipo_pgto = '{0}'", tipoPago);
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<CuentaAdministradora> list = new List<CuentaAdministradora>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new CuentaAdministradora()
                {
                    tipo_pgto = row[0].ToString(),
                    idAdministradora = row[1].ToString(),
                    conta_contabil = row[2].ToString(),                                        
                    tipoLancamento = row[3].ToString()
                });
            }

            return list;
        }

        public List<Administradora> GetCardList()
        {
            string oSql = "select TIPO_CARTAO, CODIGO_ADMINISTRADORA, ADMINISTRADORA from ADMINISTRADORAS_CARTAO ";
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<Administradora> list = new List<Administradora>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Administradora()
                {
                    tipoAdministradora = int.Parse(row[0].ToString()),
                    idAdministradora = row[1].ToString(),
                    administradora = row[2].ToString()                    
                });
            }

            return list;
        }

        public List<Conta_Plano> GetAccountList()
        {
            string oSql = "select CONTA_CONTABIL, rtrim(CONTA_CONTABIL) + ' :: ' + DESC_CONTA from CTB_CONTA_PLANO order by CONTA_CONTABIL";
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            List<Conta_Plano> list = new List<Conta_Plano>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Conta_Plano()
                {
                    conta_contabil = row[0].ToString(),
                    desc_conta = row[1].ToString()                    
                });
            }

            return list;
        }

        public List<Conta_Plano> GetAccountList(string cuentas)
        {
            string oSql = string.Format("select CONTA_CONTABIL, rtrim(CONTA_CONTABIL) + ' :: ' + DESC_CONTA from CTB_CONTA_PLANO where CONTA_CONTABIL in ({0})", cuentas);
            DataSet ds = SqlServer.ExecuteDataset(_connStrErp, CommandType.Text, oSql);

            List<Conta_Plano> list = new List<Conta_Plano>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Conta_Plano()
                {
                    conta_contabil = row[0].ToString(),
                    desc_conta = row[1].ToString()
                });
            }

            return list;
        }

        public List<TipoPgto> GetPayTypeNoCardList()
        {
            string[] tiposPagoTarjetas = ConfigurationManager.AppSettings["tiposPagoTarjetas"].ToString().Split('-');

            StringBuilder tipoTarjetas = new StringBuilder();

            for (int i = 0; i < tiposPagoTarjetas.Length; i++)
            {
                tipoTarjetas.Append(string.Format("'{0}'", tiposPagoTarjetas[i]));

                if (i < tiposPagoTarjetas.Length - 1)
                    tipoTarjetas.Append(",");
            }

            string oSql = string.Format("select TIPO_PGTO, DESC_TIPO_PGTO from TIPOS_PGTO where INATIVO = 0 and TIPO_PGTO not in ({0}) order by DESC_TIPO_PGTO", tipoTarjetas.ToString());
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<TipoPgto> list = new List<TipoPgto>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new TipoPgto()
                {
                    tipo_pgto = row[0].ToString(),
                    desc_tipo_pgto = row[1].ToString()
                });
            }

            return list;
        }

        public List<TipoPgto> GetPayTypeCardList()
        {
            string[] tiposPagoTarjetas = ConfigurationManager.AppSettings["tiposPagoTarjetas"].ToString().Split('-');

            StringBuilder tipoTarjetas = new StringBuilder();

            for (int i = 0; i < tiposPagoTarjetas.Length; i++)
            {
                tipoTarjetas.Append(string.Format("'{0}'", tiposPagoTarjetas[i]));

                if (i < tiposPagoTarjetas.Length - 1)
                    tipoTarjetas.Append(",");
            }

            string oSql = string.Format("select TIPO_PGTO, DESC_TIPO_PGTO from TIPOS_PGTO where INATIVO = 0 and TIPO_PGTO in ({0}) order by DESC_TIPO_PGTO", tipoTarjetas.ToString());
            DataSet ds = SqlServer.ExecuteDataset(_connStrPos, CommandType.Text, oSql);

            List<TipoPgto> list = new List<TipoPgto>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new TipoPgto()
                {
                    tipo_pgto = row[0].ToString(),
                    desc_tipo_pgto = row[1].ToString()
                });
            }

            return list;
        }

        public bool Add(CuentaTipoPago item) 
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("insert into OrkCuentaTipoPago ");
                oSql.AppendLine(string.Format("select '{0}','{1}', '{2}', {3}, '{4}' ", item.tipo_pgto, item.conta_contabil, item.tipoLancamento, item.peso.ToString("N", culture), item.lineaPorTercero.ToString()));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Edit(CuentaTipoPago item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("Update OrkCuentaTipoPago set ");
                oSql.AppendLine(string.Format("peso =  {0}, tipoLancamento = '{1}' where tipo_pgto = '{2}' and conta_contabil = '{3}', lineaPorTercero = '{4}' ", item.peso.ToString("N", culture), item.tipoLancamento, item.tipo_pgto, item.conta_contabil, item.lineaPorTercero.ToString()));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Remove(CuentaTipoPago item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.AppendLine("delete from OrkCuentaTipoPago ");
                oSql.AppendLine(string.Format("where tipo_pgto = '{0}' and conta_contabil = '{1}' ", item.tipo_pgto, item.conta_contabil));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Add(CuentaAdministradora item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("insert into orkCuentaAdministradora ");
                oSql.AppendLine(string.Format("select '{0}','{1}', '{2}', '{3}' ", item.tipo_pgto, item.idAdministradora, item.conta_contabil, item.tipoLancamento));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Edit(CuentaAdministradora item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("Update orkCuentaAdministradora set ");
                oSql.AppendLine(string.Format("conta_contabil =  '{0}', tipoLancamento = '{1}' where tipo_pgto = '{2}' and administradora = '{3}' ", item.conta_contabil, item.tipoLancamento, item.tipo_pgto, item.idAdministradora));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public bool Remove(CuentaAdministradora item)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();
                CultureInfo culture = new CultureInfo("en-us");

                oSql.AppendLine("delete from orkCuentaAdministradora ");
                oSql.AppendLine(string.Format("where tipo_pgto = '{0}' and administradora = '{1}' ", item.tipo_pgto, item.idAdministradora));

                SqlServer.ExecuteNonQuery(_connStrPos, CommandType.Text, oSql.ToString());
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }
    }
}
