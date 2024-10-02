using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace App_Promo_Web
{
    public partial class VoucherCanjeado : System.Web.UI.Page
    {
        public Articulo arti { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            VouchersNogocio voucherNegocio = new VouchersNogocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Vouchers voucher = new Vouchers();
            Clientes cliente = new Clientes();


            string IdVoucher = Request.QueryString["IdVoucher"];

            voucher = voucherNegocio.obtenerVoucher(IdVoucher);
            cliente = clienteNegocio.obtenerCliente(voucher.IdCliente);
            arti = articuloNegocio.obtenerArticulo(voucher.IdArticulo);

            txtCodigo.Text = voucher.CodigoVoucher;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtFecha.Text = voucher.FechaCanje.ToString();
            txtArticulo.Text = arti.marca.Nombre;
            txtCodigo.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtArticulo.ReadOnly = true;

        }
    }
}