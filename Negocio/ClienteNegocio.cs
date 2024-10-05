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
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Doc");
                datos.setearParametro("@Doc", C);
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

        public bool verificarCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT Documento FROM Clientes WHERE Documento = @Doc");
            datos.setearParametro("@Doc", dni);
            datos.ejecutarLectura();

            if (datos.Lector.Read())
            {
                return false;
            }

            return true;

        }

        public void guardarCliente(Clientes cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Doc, @Nom, @Ape, @Ema, @Dir, @Ciu, @CP)");

                datos.setearParametro("@Doc", cliente.Documento);
                datos.setearParametro("@Nom", cliente.Nombre);
                datos.setearParametro("@Ape", cliente.Apellido);
                datos.setearParametro("@Ema", cliente.Email);
                datos.setearParametro("@Dir", cliente.Direccion);
                datos.setearParametro("@Ciu", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);

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
    }
}
