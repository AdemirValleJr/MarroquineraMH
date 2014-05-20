using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;
using Orkidea.ComisionesMH.Utilities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizParametroTienda
    {
        public List<CSS_PARAMETRO_TIENDA> getParametroTiendaList()
        {
            List<CSS_PARAMETRO_TIENDA> lstCSS_PARAMETRO_TIENDA = new List<CSS_PARAMETRO_TIENDA>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstCSS_PARAMETRO_TIENDA = ctx.CSS_PARAMETRO_TIENDA.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstCSS_PARAMETRO_TIENDA;
        }

        public CSS_PARAMETRO_TIENDA getParametroTienda(CSS_PARAMETRO_TIENDA filialTarget)
        {
            CSS_PARAMETRO_TIENDA filial = new CSS_PARAMETRO_TIENDA();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    filial = ctx.CSS_PARAMETRO_TIENDA.Where(x =>
                        x.tienda == filialTarget.tienda).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return filial;
        }

        public void SaveParametroVendedor(CSS_PARAMETRO_TIENDA ParametroTiendaTarget)
        {

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the ParametroVendedor exists
                    CSS_PARAMETRO_TIENDA oParametroTienda = getParametroTienda(ParametroTiendaTarget);

                    if (oParametroTienda != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PARAMETRO_TIENDA.Attach(oParametroTienda);
                        _GenericEntityValidation.EnumeratePropertyDifferences(oParametroTienda, ParametroTiendaTarget);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        // else create
                        ctx.CSS_PARAMETRO_TIENDA.Add(ParametroTiendaTarget);
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
        /// <param name="ParametroTiendaTarget"></param>
        public void DeleteParametroTienda(CSS_PARAMETRO_TIENDA ParametroTiendaTarget)
        {
            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the school exists
                    CSS_PARAMETRO_TIENDA oParametroTienda = getParametroTienda(ParametroTiendaTarget);

                    if (oParametroTienda != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PARAMETRO_TIENDA.Attach(oParametroTienda);
                        ctx.CSS_PARAMETRO_TIENDA.Remove(oParametroTienda);
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
