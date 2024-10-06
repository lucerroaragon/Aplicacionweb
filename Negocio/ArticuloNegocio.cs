using Dominio;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Net;
using System.Security.Cryptography;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarTodos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedListarArticulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    int idArticulo = (int)datos.Lector["IdArticulo"];

                    // Busca si ya existe en la lista
                    Articulo aux = lista.FirstOrDefault(a => a.IdArticulo == idArticulo);


                    if (aux == null)
                    {
                        aux = new Articulo
                        {
                            IdArticulo = idArticulo,
                            CodArticulo = (string)datos.Lector["Codigo"],
                            Nombre = (string)datos.Lector["Nombre"],
                            marca = new Marca
                            {
                                IdMarca = (int)datos.Lector["IdMarca"],
                                Nombre = (string)datos.Lector["Marca"]
                            },
                            categoria = new Categoria
                            {
                                IdCategoria = (int)datos.Lector["IdCategoria"],
                                Nombre = (string)datos.Lector["Categoria"]
                            },
                            Precio = (decimal)datos.Lector["Precio"],
                            Descripcion = (string)datos.Lector["Descripcion"],
                            imagenes = new List<string>()
                        };



                        lista.Add(aux);
                    }

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        string imageUrl = (string)datos.Lector["ImagenUrl"];
                        aux.imagenes.Add(imageUrl);
                    }
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
;        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            Imagen img = new Imagen();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Id,Codigo, Nombre, Descripcion,Precio,IdMarca, IdCategoria) VALUES (@Id,@Codigo, @Nombre, @Descripcion,@Precio, @IdMarca, @IdCategoria)");
                datos.setearParametro("@Id", nuevo.IdArticulo);
                datos.setearParametro("@Codigo", nuevo.CodArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.IdCategoria);

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

            int idNuevo = obtenerUltimoId();

            imagenNegocio.agregar(idNuevo, nuevo.imagen.Url);

        }

        public Articulo obtenerArticulo(int id)
        {
            Articulo aux = new Articulo();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Id AS IdArticulo, A.Codigo, A.Nombre, M.Descripcion AS Marca, M.Id AS IdMarca, C.Descripcion AS Categoria, C.Id AS IdCategoria, A.Precio, A.Descripcion, MAX(I.ImagenUrl) AS ImagenUrl FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo WHERE A.Id = @Id GROUP BY A.Id, A.Codigo, A.Nombre, M.Descripcion, M.Id, C.Descripcion, C.Id, A.Precio, A.Descripcion");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.marca = new Marca();
                    aux.marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.marca.Nombre = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.imagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.imagen.Url = (string)datos.Lector["ImagenUrl"];
                }
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


        public void modificar(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion ,Precio = @Precio,IdMarca = @IdMarca, IdCategoria = @IdCategoria Where Id = @IdArticulo");
                datos.setearParametro("@Codigo", arti.CodArticulo);
                datos.setearParametro("@Nombre", arti.Nombre);
                datos.setearParametro("@Descripcion", arti.Descripcion);
                datos.setearParametro("@Precio", arti.Precio);
                datos.setearParametro("@IdMarca", arti.marca.IdMarca);
                datos.setearParametro("@IdCategoria", arti.categoria.IdCategoria);
                datos.setearParametro("@IdArticulo", arti.IdArticulo);

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

            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setearConsulta("update IMAGENES set ImagenUrl = @Url Where IdArticulo = @IdArticulo");
                datos2.setearParametro("@IdArticulo", arti.IdArticulo);
                datos2.setearParametro("@Url", arti.imagen.Url);

                datos2.ejecutarAccion();
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


        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int obtenerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;
            try
            {
                datos.setearConsulta("select top(1) id from ARTICULOS ORDER by id DESC");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id = (int)datos.Lector["id"];
                }
                return id;
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

        public object filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}