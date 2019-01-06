using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ReceitaWsSample.Context;
using ReceitaWsSample.Models;

namespace ReceitaWsSample.Services
{
    public class SocioAdministradorService
    {
        private DatabaseContext _context = new DatabaseContext();

        public void Insere (SocioAdministrador model)
        {
            _context.SociosAdministradores.Add(model);
            _context.SaveChanges();
        }

        public void Insere (ICollection<SocioAdministrador> modelList)
        {
            _context.SociosAdministradores.AddRange(modelList);
            _context.SaveChanges();
        }
    }
}