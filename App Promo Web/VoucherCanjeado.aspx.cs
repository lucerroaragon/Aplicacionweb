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
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                string IdVoucher = Request.QueryString["IdVoucher"];

                if (!string.IsNullOrEmpty(IdVoucher))
                {
                    var voucher = voucherNegocio.obtenerVoucher(IdVoucher);

                    if (voucher != null)
                    {
                        var cliente = clienteNegocio.obtenerCliente(voucher.IdCliente ?? 0); // Usa 0 como valor predeterminado
                        arti = articuloNegocio.obtenerArticulo(voucher.IdArticulo ?? 0); // Usa 0 como valor predeterminado

                        
                    }
                    else
                    {
                        lblError.Text = "Voucher no encontrado.";
                        lblError.Visible = true; 
                    }
                }
                else
                {
                    lblError.Text = "No se proporcionó un código de voucher valido.";
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
