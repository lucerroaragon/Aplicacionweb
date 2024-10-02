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
            if (voucher.CodigoVoucher != null)
            {
                if (voucher.IdCliente == 0)
                {
                    Session.Add("IdVoucher", txtCodigo.Text);
                    Response.Redirect("FormularioCliente.aspx");
                }
                else if(voucher.IdCliente > 0)
                {
                    Session.Add("IdVoucher", txtCodigo.Text);
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