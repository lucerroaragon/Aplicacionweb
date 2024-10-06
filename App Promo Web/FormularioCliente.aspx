<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="App_Promo_Web.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            let isValid = true;

            // Documento
            const txtDocumento = document.getElementById('txtDocumento');
            const docPattern = /^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$/;
            if (txtDocumento.value === "" || !docPattern.test(txtDocumento.value)) {
                txtDocumento.classList.add("is-invalid");
                txtDocumento.classList.remove("is-valid");
                isValid = false;
            } else {
                txtDocumento.classList.remove("is-invalid");
                txtDocumento.classList.add("is-valid");
            }

            // Nombre
            const txtNombre = document.getElementById('txtNombre');
            if (txtNombre.value.trim() === "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                isValid = false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            // Apellido
            const txtApellido = document.getElementById('txtApellido');
            if (txtApellido.value.trim() === "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                isValid = false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            // Email
            const txtEmail = document.getElementById('txtEmail');
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (txtEmail.value === "" || !emailPattern.test(txtEmail.value)) {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                isValid = false;
            } else {
                txtEmail.classList.remove("is-invalid");
                txtEmail.classList.add("is-valid");
            }

            // Dirección
            const txtDireccion = document.getElementById('txtDireccion');
            if (txtDireccion.value.trim() === "") {
                txtDireccion.classList.add("is-invalid");
                txtDireccion.classList.remove("is-valid");
                isValid = false;
            } else {
                txtDireccion.classList.remove("is-invalid");
                txtDireccion.classList.add("is-valid");
            }

            // Ciudad
            const txtCiudad = document.getElementById('txtCiudad');
            if (txtCiudad.value.trim() === "") {
                txtCiudad.classList.add("is-invalid");
                txtCiudad.classList.remove("is-valid");
                isValid = false;
            } else {
                txtCiudad.classList.remove("is-invalid");
                txtCiudad.classList.add("is-valid");
            }

            // Código Postal
            const txtCP = document.getElementById('txtCP');
            if (isNaN(txtCP.value) || txtCP.value.trim() === "") {
                txtCP.classList.add("is-invalid");
                txtCP.classList.remove("is-valid");
                isValid = false;
            } else {
                txtCP.classList.remove("is-invalid");
                txtCP.classList.add("is-valid");
            }

            return isValid;
        }

        function validar1() {
            let isValid = true;

            // Documento
            const txtDocumento = document.getElementById('txtDocumento');
            const docPattern = /^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$/;
            if (txtDocumento.value === "" || !docPattern.test(txtDocumento.value)) {
                txtDocumento.classList.add("is-invalid");
                txtDocumento.classList.remove("is-valid");
                isValid = false;
            } else {
                txtDocumento.classList.remove("is-invalid");
                txtDocumento.classList.add("is-valid");
            }
        }
</script>

    <div class="form-header text-center">
        <h1 class="form-title">Completa tu información</h1>
        <p class="form-description">Por favor, completa los datos a continuación para procesar el canje de tu artículo seleccionado.</p>
    </div>

    <form class="row g-3">

        <!-- Documento -->
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtDocumento_TextChanged" ClientIDMode="Static" ID="txtDocumento" class="form-control" placeholder="dni" />
                <%--<asp:RequiredFieldValidator ErrorMessage="DNI requerido" ControlToValidate="txtDocumento" runat="server" CssClass="text-danger" />--%>
                <asp:RegularExpressionValidator ErrorMessage="Solo números, formato inválido" ControlToValidate="txtDocumento" ValidationExpression="^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Nombre y Apellido -->
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNombre" class="form-control" ReadOnly="true" placeholder="nombre" />
                <asp:RequiredFieldValidator ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" runat="server" CssClass="text-danger" />
            </div>
            <div class="col-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" class="form-control" ReadOnly="true" placeholder="apellido" />
                <asp:RequiredFieldValidator ErrorMessage="Apellido requerido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Email y Dirección -->
        <div class="col-md-6">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtEmail" class="form-control" ReadOnly="true" placeholder="email" />
            <asp:RequiredFieldValidator ErrorMessage="Email requerido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" />
            <asp:RegularExpressionValidator ErrorMessage="Formato de email inválido" ControlToValidate="txtEmail" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" runat="server" CssClass="text-danger" />
        </div>

        <div class="col-md-6">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDireccion" class="form-control" ReadOnly="true" placeholder="Calle y altura" />
            <asp:RequiredFieldValidator ErrorMessage="Dirección requerida" ControlToValidate="txtDireccion" runat="server" CssClass="text-danger" />
        </div>

        <!-- Ciudad y Código Postal -->
        <div class="row g-3">
            <div class="col-md-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCiudad" class="form-control" ReadOnly="true" placeholder="ciudad" />
                <asp:RequiredFieldValidator ErrorMessage="Ciudad requerida" ControlToValidate="txtCiudad" runat="server" CssClass="text-danger" />
            </div>
            <div class="col-md-2">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCP" class="form-control" ReadOnly="true" placeholder="cp" />
                <asp:RequiredFieldValidator ErrorMessage="Código Postal requerido" ControlToValidate="txtCP" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <!-- Botones -->
        <div class="row g-4">
            <div class="md-2">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
            </div>
        </div>

    </form>

</asp:Content>

