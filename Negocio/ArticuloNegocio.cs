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
                datos.setearConsulta("Select A.Id IdArticulo , A.Codigo, A.Nombre, M.Descripcion Marca,M.id IdMarca, C.Descripcion Categoria, C.Id IdCategoria, A.Precio, A.Descripcion, I.ImagenUrl  from ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.marca = new Marca();
                    aux.marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.marca.Nombre = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.imagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"]is DBNull))
                        aux.imagen.Url = (string)datos.Lector["ImagenUrl"];

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

        public void agregar ( Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            
            Imagen img = new Imagen();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion,Precio,IdMarca, IdCategoria) VALUES (@Codigo, @Nombre, @Descripcion,@Precio, @IdMarca, @IdCategoria)");
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
        public void modificar ( Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion ,Precio = @Precio,IdMarca = @IdMarca, IdCategoria = @IdCategoria Where Id = @IdArticulo");
                datos.setearParametro("@Codigo",arti.CodArticulo);
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