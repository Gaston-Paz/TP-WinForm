using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria";
                string FromDB = "FROM ARTICULOS AS A, MARCAS AS M, CATEGORIAS AS C";
                string WhereCond = "WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                datos.setearConsulta(SelectColum+FromDB+WhereCond);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (string)datos.Lector["A.Codigo"];
                    aux.Nombre = (string)datos.Lector["A.Nombre"];
                    aux.Descripcion = (string)datos.Lector["A.Descripcion"];

                    aux.TipoMarca = new Marca((string)datos.Lector["Marca"]);
                    aux.TipoCategoria = new Categoria((string)datos.Lector["Categoria"]);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
