using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VouchersNogocio
    {
        public Vouchers obtenerVoucher(string cV)
        {
            AccesoDatos datos = new AccesoDatos();
            Vouchers voucher = new Vouchers();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher LIKE @Codigo");
                datos.setearParametro("@Codigo", "%" + cV + "%");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    if(!(datos.Lector["IdCliente"] is DBNull))
                    {
                        voucher.IdCliente = (int)datos.Lector["IdCliente"];
                        voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                        voucher.IdArticulo = (int)datos.Lector["IdArticulo"];
                    }
                }
                return voucher;
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
