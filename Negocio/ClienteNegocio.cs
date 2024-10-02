using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public Clientes obtenerCliente(int C)
        {
            AccesoDatos datos = new AccesoDatos();
            Clientes cliente = new Clientes();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes\r\nWHERE Id = @id");
                datos.setearParametro("@Id", C);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.IdCliente = (int)datos.Lector["Id"];
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CP = (int)datos.Lector["CP"];
                }
                return cliente;
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
