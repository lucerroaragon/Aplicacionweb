using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        private List<string> NegocioList;
        public void agregar(int id, string urlImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            Imagen img = new Imagen();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@Id, @Url)");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Url", urlImagen);
                datos.ejecutarAccion();

                foreach (string s in NegocioList)
                {
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@Id, @Url)");
                    datos.setearParametro("@Id", id);
                    datos.setearParametro("@Url",urlImagen);
                    datos.ejecutarAccion();
                }
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

        public void obtenerLista(List<string> urlImgenes)
        {
             NegocioList = urlImgenes;
        }
    }
}
