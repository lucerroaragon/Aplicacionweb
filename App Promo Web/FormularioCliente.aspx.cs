﻿using System;
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
            }
            else
            {
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtCiudad.ReadOnly = false;
                txtCP.ReadOnly = false;
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VouchersNogocio voucherNegocio = new VouchersNogocio();

            try
            {
                Clientes cliente = new Clientes();

                if (clienteNegocio.verificarCliente(txtDocumento.Text))
                {
                    cliente.Documento = txtDocumento.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);
                    clienteNegocio.guardarCliente(cliente);

                    cliente = clienteNegocio.obtenerCliente(int.Parse(txtDocumento.Text));
                    voucherNegocio.canjearVoucher(Session["IdVoucher"].ToString(), cliente.IdCliente, int.Parse(Request.QueryString["IdArticulo"]));
                }
                else
                {
                    cliente = clienteNegocio.obtenerCliente(int.Parse(txtDocumento.Text));
                    voucherNegocio.canjearVoucher(Session["IdVoucher"].ToString(), cliente.IdCliente, int.Parse(Request.QueryString["IdArticulo"]));
                }

                Response.Redirect("CanjeadoExitoso.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Session.Clear();
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}