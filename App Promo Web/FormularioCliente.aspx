<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="App_Promo_Web.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            const txtDocumento = document.getElementById('txtDocumento');
            if (txtDocumento.value == "") {
                txtDocumento.classList.add("is-invalid");
                txtDocumento.classList.remove("is-valid");
                return false;
            }
            txtDocumento.classList.remove("is-valid");
            txtDocumento.classList.add("is-invalid");
            return true;
        }
    </script>

    <div class="form-header text-center">
        <h1 class="form-title">Completa tu información</h1>
        <p class="form-description">Por favor, completa los datos a continuación para procesar el canje de tu artículo seleccionado.</p>
    </div>

    <form class="row g-3">
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDocumento" class="form-control" placeholder="dni" />
                <%--<asp:RequiredFieldValidator ErrorMessage="Dni requerido" ControlToValidate="txtDocumento" runat="server" />--%>
            </div>
            <div class="col-md-3">
                <asp:Button Text="Validar" CssClass="btn btn-primary" OnClick="Button1_Click" ID="btnValidar" runat="server" />
            </div>
            <%--<div class="col-3 form-description">
                <label for="lbl1" class="form-label g-3">Ingrese su DNI y precione Enter.</label>
            </div>--%>
        </div>
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" ReadOnly="true" placeholder="nombre" type="text" />
                <%--<asp:RequiredFieldValidator ErrorMessage="Nombre Requerido" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <div class="col-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" ReadOnly="true" placeholder="apellido" />
                <%--<asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" />--%>
            </div>
        </div>
        <div class="col-md-6">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" ReadOnly="true" type="email" />
            <%--<asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" />--%>
        </div>
        <div class="col-md-6">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" ReadOnly="true" placeholder="Calle y altura" type="text" />
            <%--<asp:RequiredFieldValidator ErrorMessage="Dirección requerida" ControlToValidate="txtDireccion" runat="server" />--%>
        </div>
        <div class="row g-3">
            <div class="col-md-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCiudad" class="form-control" ReadOnly="true" placeholder="ciudad" type="text" />
                <%--<asp:RequiredFieldValidator ErrorMessage="Ciudad requerida" ControlToValidate="txtCiudad" runat="server" />--%>
            </div>
            <div class="col-md-2">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" ReadOnly="true" placeholder="cp" />
                <%--<asp:RequiredFieldValidator ErrorMessage="Ingrese CP" ControlToValidate="txtCP" runat="server" />--%>
            </div>
        </div>

        <div class="row g-4">
            <div class="md-2">
                <p></p>
                <asp:Button Text="Participar" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
            </div>
        </div>
    </form>
</asp:Content>
