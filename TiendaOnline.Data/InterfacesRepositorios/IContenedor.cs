using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.Data.InterfacesRepositorios
{
   public interface IContenedor:IDisposable
    {
        IVendedorRepository vendedor { get; }
        IProductoRepository producto { get; }
        IUsuarioRepository usuario { get; }
        void Save();
    }
}
