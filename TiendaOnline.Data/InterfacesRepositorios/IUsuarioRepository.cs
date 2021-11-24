using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Data.InterfacesRepositorios
{
  public  interface IUsuarioRepository:IRepository<Usuario>
    {
        void BloquearUsuario(string usuario);
        void DesbloquearUsuario(string usuario);
        
    }
}
