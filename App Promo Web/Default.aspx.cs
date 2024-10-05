using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace App_Promo_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            Vouchers voucher = new Vouchers();
            VouchersNogocio voucherNegocio = new VouchersNogocio();
            voucher = voucherNegocio.obtenerVoucher(txtCodigo.Text);

            if (voucher != null && voucher.CodigoVoucher != null)  // Verifica si se encontró el voucher
            {
                if (voucher.IdCliente == null)  // Verifica si el voucher aún no ha sido utilizado (IdCliente es null)
                {
                    Session.Add("IdVoucher", txtCodigo.Text);
                    Response.Redirect("CatalogoArticulos.aspx"); // Redirige a la página del catálogo
                }
                else if (voucher.IdCliente > 0)  // Verifica si el voucher ya ha sido utilizado (IdCliente tiene un valor)
                {
                    Session.Add("IdVoucher", txtCodigo.Text); // Guardo el Id de voucher en sesión
                    Response.Redirect("VoucherCanjeado.aspx");
                }
            }
            else
            {
                lblError.Text = "Voucher no encontrado";
            }
        }



    }
}