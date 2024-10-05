using Dominio;
using System;
using System.Web.UI;
using Negocio;

namespace App_Promo_Web
{
    public partial class VoucherCanjeado : System.Web.UI.Page
    {
        public Articulo arti { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VouchersNogocio voucherNegocio = new VouchersNogocio();
                string IdVoucher = Request.QueryString["IdVoucher"];

                if (!string.IsNullOrEmpty(IdVoucher))
                {
                    var voucher = voucherNegocio.obtenerVoucher(IdVoucher);

                    if (voucher != null)
                    {
                        lblError.Text = "El código de voucher ingresado ya ha sido utilizado o no existe.";
                        lblError.Visible = true;
                    }
                    else
                    {
                        // Aquí puedes mostrar información sobre el artículo canjeado si es necesario.
                        // arti = articuloNegocio.obtenerArticulo(voucher.IdArticulo ?? 0);
                    }
                }
                else
                {
                    lblError.Text = "No se proporcionó un código de voucher válido.";
                    lblError.Visible = true;
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
