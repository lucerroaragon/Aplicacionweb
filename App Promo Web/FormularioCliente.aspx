<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="App_Promo_Web.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row g-3">
        <div class="col-md-1">
            <label for="txtId" class="form-label">ID</label>
            <asp:TextBox runat="server" ID="txtId" class="form-control" placeholder="id" />
        </div>
        <div class="col-md-3">
            <label for="txtDocumento" class="form-label">Documento</label>
            <asp:TextBox runat="server" ID="txtDocumento" class="form-control" placeholder="dni" />
        </div>
    </div>
    <div class="row g-3">
        <div class="col-md-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" class="form-control" placeholder="nombre" type="text" />
        </div>
        <div class="col-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" class="form-control" placeholder="apellido" />
        </div>
    </div>
    <div class="col-md-6">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox runat="server" ID="txtEmail" class="form-control" type="email" />
    </div>
    <div class="col-md-6">
        <label for="txtDireccion" class="form-label">Dirección</label>
        <asp:TextBox runat="server" ID="txtDireccion" class="form-control" placeholder="Calle y altura" type="text" />
    </div>
    <div class="row g-3">
        <div class="col-md-4">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox runat="server" ID="txtCiudad" class="form-control" placeholder="ciudad" type="text" />
        </div>
        <div class="col-md-2">
            <label for="txtCP" class="form-label">Código Postal</label>
            <asp:TextBox runat="server" ID="txtCP" class="form-control" placeholder="cp" />
        </div>
    </div>

    <div class="row g-4">
        <div class="md-2">
            <p></p>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
        </div>
    </div>
</asp:Content>
