using Orkidea.MH.WebMiddle.Business;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orkidea.MH.WebMiddle.WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            return BizUsuario.Get();
        }

        // GET: api/Usuario/5
        public Usuario Get(string id)
        {
            return BizUsuario.Get(id);
        }

        // POST: api/Usuario
        public void Post(Usuario usuario)
        {
            BizUsuario.Add(usuario);
        }

        // PUT: api/Usuario/5
        public void Put(Usuario usuario)
        {
            BizUsuario.Edit(usuario);
        }

        // DELETE: api/Usuario/5
        public void Delete(string id)
        {            
            BizUsuario.Delete(new Usuario() { idUsuario = id});
        }
    }
}
