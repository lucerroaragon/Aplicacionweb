<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="App_Promo_Web.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            const txtDocumento = document.getElementById('txtDocumento');
            if (txtDocumento.value === "") {
                txtDocumento.classList.add("is-invalid");
                txtDocumento.classList.remove("is-valid");
                return false;
            }
            txtDocumento.classList.remove("is-invalid");
            txtDocumento.classList.add("is-valid");
            return true;
        }
    </script>

   

    <div class="container d-flex justify-content-center align-items-center vh-100 ">
        <div class="row g-3 col-md-8">
            <div class="col-md-12 text-center mb-4 "  >
                <h1 class="form-title">Completa tu información</h1>
                <p class="form-description">Por favor, completa los datos a continuación para procesar el canje de tu artículo seleccionado.</p>
            </div>
            <div class="col-md-6">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDocumento" class="form-control" placeholder="DNI" />
            </div>
            <div class="col-md-3">
                <asp:Button Text="Validar" CssClass="btn btn-primary mt-4" OnClick="Button1_Click" ID="btnValidar" runat="server" />
            </div>
            <div class="col-md-6">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" ReadOnly="true" placeholder="Nombre" type="text" />
            </div>
            <div class="col-md-6">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" ReadOnly="true" placeholder="Apellido" />
            </div>
            <div class="col-md-6">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" ReadOnly="true" type="email" />
            </div>
            <div class="col-md-6">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" ReadOnly="true" placeholder="Calle y altura" type="text" />
            </div>
            <div class="col-md-6">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCiudad" class="form-control" ReadOnly="true" placeholder="Ciudad" type="text" />
            </div>
            <div class="col-md-6">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" ReadOnly="true" placeholder="CP" />
            </div>
            <div class="col-md-12 text-center mt-4">
                <asp:Button Text="Participar" CssClass="btn btn-primary btn-participa" OnClientClick="return validar()" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>

