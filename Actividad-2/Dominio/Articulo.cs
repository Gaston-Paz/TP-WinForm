using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Articulo
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Marca TipoMarca { get; set; }

        public Categoria TipoCategoria { get; set; }

        public string UrlImagen { get; set; }

        public float Precio { get; set; }
    }
}
