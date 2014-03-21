using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;
using Orkidea.ComisionesMH.Utilities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizParametroVendedor
    {
        public List<CSS_PARAMETRO_VENDEDOR> getParametroVendedorList()
        {
            List<CSS_PARAMETRO_VENDEDOR> lstCSS_PARAMETRO_VENDEDOR = new List<CSS_PARAMETRO_VENDEDOR>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstCSS_PARAMETRO_VENDEDOR = ctx.CSS_PARAMETRO_VENDEDOR.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstCSS_PARAMETRO_VENDEDOR;
        }

        public CSS_PARAMETRO_VENDEDOR getParametroVendedor(CSS_PARAMETRO_VENDEDOR filialTarget)
        {
            CSS_PARAMETRO_VENDEDOR filial = new CSS_PARAMETRO_VENDEDOR();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    filial = ctx.CSS_PARAMETRO_VENDEDOR.Where(x =>
                        x.vendedor == filialTarget.vendedor).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return filial;
        }

        public void SaveParametroVendedor(CSS_PARAMETRO_VENDEDOR ParametroVendedorTarget)
        {

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the ParametroVendedor exists
                    CSS_PARAMETRO_VENDEDOR oParametroVendedor = getParametroVendedor(ParametroVendedorTarget);

                    if (oParametroVendedor != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PARAMETRO_VENDEDOR.Attach(oParametroVendedor);
                        _GenericEntityValidation.EnumeratePropertyDifferences(oParametroVendedor, ParametroVendedorTarget);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        // else create
                        ctx.CSS_PARAMETRO_VENDEDOR.Add(ParametroVendedorTarget);
                        ctx.SaveChanges();
                    }
                }

            }
            catch (DbEntityValidationException e)
            {
                StringBuilder oError = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    oError.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));

                    foreach (var ve in eve.ValidationErrors)
                    {
                        oError.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                string msg = oError.ToString();
                throw new Exception(msg);
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Delete a ParametroVendedor
        /// </summary>
        /// <param name="ParametroVendedorTarget"></param>
        public void DeleteParametroVendedor(CSS_PARAMETRO_VENDEDOR ParametroVendedorTarget)
        {
            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the school exists
                    CSS_PARAMETRO_VENDEDOR oParametroVendedor = getParametroVendedor(ParametroVendedorTarget);

                    if (oParametroVendedor != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PARAMETRO_VENDEDOR.Attach(oParametroVendedor);
                        ctx.CSS_PARAMETRO_VENDEDOR.Remove(oParametroVendedor);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    throw new Exception("No se puede eliminar este parámetro porque existe información asociada a este.");
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
