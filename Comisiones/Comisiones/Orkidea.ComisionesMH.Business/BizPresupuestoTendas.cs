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
    public class BizPresupuestoTendas
    {
        public List<CSS_PRESUPUESTO_TIENDAS> getPresupuestoVentasList()
        {
            List<CSS_PRESUPUESTO_TIENDAS> lstCSS_PRESUPUESTO_TIENDAS = new List<CSS_PRESUPUESTO_TIENDAS>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstCSS_PRESUPUESTO_TIENDAS = ctx.CSS_PRESUPUESTO_TIENDAS.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstCSS_PRESUPUESTO_TIENDAS;
        }

        public List<CSS_PRESUPUESTO_TIENDAS> getPresupuestoVentasList(FILIAIS filialTarget, int año)
        {
            List<CSS_PRESUPUESTO_TIENDAS> lstPresupuesto = new List<CSS_PRESUPUESTO_TIENDAS>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstPresupuesto = ctx.CSS_PRESUPUESTO_TIENDAS.Where(x =>
                        x.tienda == filialTarget.COD_FILIAL && año.Equals(año)).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstPresupuesto;
        }

        public CSS_PRESUPUESTO_TIENDAS getPresupuestoVentas(CSS_PRESUPUESTO_TIENDAS presupuestoTarget)
        {
            CSS_PRESUPUESTO_TIENDAS Presupuesto = new CSS_PRESUPUESTO_TIENDAS();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    Presupuesto = ctx.CSS_PRESUPUESTO_TIENDAS.Where(x =>
                        x.tienda == presupuestoTarget.tienda && x.mes.Equals(presupuestoTarget.mes) && x.ano.Equals(presupuestoTarget.ano)).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return Presupuesto;
        }

        public void SavePresupuestoVentas(CSS_PRESUPUESTO_TIENDAS presupuestoVentasTarget)
        {

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the ParametroVendedor exists
                    CSS_PRESUPUESTO_TIENDAS oPresupuestoVentas = getPresupuestoVentas(presupuestoVentasTarget);

                    if (oPresupuestoVentas != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PRESUPUESTO_TIENDAS.Attach(oPresupuestoVentas);
                        _GenericEntityValidation.EnumeratePropertyDifferences(oPresupuestoVentas, presupuestoVentasTarget);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        // else create
                        ctx.CSS_PRESUPUESTO_TIENDAS.Add(presupuestoVentasTarget);
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
        public void DeletePresupuestoVentas(CSS_PRESUPUESTO_TIENDAS ParametroVendedorTarget)
        {
            try
            {
                using (var ctx = new MHERPEntities())
                {
                    //verify if the school exists
                    CSS_PRESUPUESTO_TIENDAS oPresupuesto = getPresupuestoVentas(ParametroVendedorTarget);

                    if (oPresupuesto != null)
                    {
                        // if exists then edit 
                        ctx.CSS_PRESUPUESTO_TIENDAS.Attach(oPresupuesto);
                        ctx.CSS_PRESUPUESTO_TIENDAS.Remove(oPresupuesto);
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
