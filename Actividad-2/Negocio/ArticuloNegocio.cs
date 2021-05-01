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
                string SelectColum = "SELECT A.Codigo, A.Nombre, A.Descripcion, C.Descripcion Categoria, M.Descripcion Marca, A.Precio, A.ImagenUrl ";
                string FromDB = "FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id";
                

                datos.setearConsulta(SelectColum+FromDB);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    aux.TipoCategoria = new Categoria((string)datos.Lector.GetString(3));
                    aux.TipoMarca = new Marca((string)datos.Lector.GetString(4));

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.UrlImagen + "', " + nuevo.TipoMarca.Id + ", "+ nuevo.TipoCategoria.Id + ", "+ nuevo.Precio+")";
                datos.setearConsulta("insert into articulos (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) " + valores);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string task = "UPDATE ARTICULOS SET ";
                string valores = "Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenUrl, Precio = @precio";
                string where = "WHERE Id = ";
                datos.setearConsulta(task + valores + where);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Articulo buscarArticulo(string filtro, string valor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string SelectColum = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, C.Descripcion Categoria, M.Descripcion Marca, A.Precio, A.ImagenUrl ";
                string FromDB = "FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id ";
                string WhereDB = "WHERE A.Codigo = '" + valor + "'";

                datos.setearConsulta(SelectColum + FromDB + WhereDB);
                datos.ejecutarLectura();

                datos.Lector.Read();

                Articulo aux = new Articulo();
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];

                aux.TipoCategoria = new Categoria((string)datos.Lector.GetString(4));
                aux.TipoMarca = new Marca((string)datos.Lector.GetString(5));

                aux.Precio = (decimal)datos.Lector["Precio"];
                aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
