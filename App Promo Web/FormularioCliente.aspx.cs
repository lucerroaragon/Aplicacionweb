using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace App_Promo_Web
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(Request.QueryString["IdArticulo"]);
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Clientes cliente = new Clientes();
            cliente = clienteNegocio.obtenerCliente(int.Parse(txtDocumento.Text));

            if (cliente.Documento != null)
            {
                txtDocumento.Text = cliente.Documento;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtCiudad.ReadOnly = false;
                txtCP.ReadOnly = false;
            }
            else
            {
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtCiudad.ReadOnly = false;
                txtCP.ReadOnly = false;

                btnValidar.Visible = false;
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {

                Clientes cliente = new Clientes();
                cliente.Documento = txtDocumento.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Ciudad = txtCiudad.Text;
                cliente.CP = int.Parse(txtCP.Text);

                if (clienteNegocio.verificarCliente(cliente.Documento))
                    clienteNegocio.guardarCliente(cliente);

                Response.Redirect("CanjeadoExitoso.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}