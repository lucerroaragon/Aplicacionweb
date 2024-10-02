<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherCanjeado.aspx.cs" Inherits="App_Promo_Web.VoucherCanjeado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4">
        <h2>¡El voucher fue cajeado!</h2>
        <p>¡Tu codigo de voucher puede estar mal, volve a intentarlo!</p>

        <p>No pierdas la oportunidad de llevarte uno de los muchos premios que tenemos para ti. ¡Buena suerte!</p>
    </div>

    <div class="row g-3">
        <div class="col-md-3">
            <p></p>
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" class="form-control" placeholder="nombre" type="text" />
        </div>
        <div class="col-3">
            <p></p>
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" class="form-control" placeholder="apellido" />
        </div>
    </div>
    <div class="row g-3">
        <div class="col-md-4">
            <p></p>
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txtEmail" class="form-control" type="email" />
        </div>
        <div class="col-md-2">
            <p></p>
            <label for="txtCodigo" class="form-label">Código</label>
            <asp:TextBox runat="server" ID="txtCodigo" class="form-control" type="text" />
        </div>
    </div>
    <div class="row g-3">
        <div class="col-md-3">
            <p></p>
            <label for="txtArticulo" class="form-label">Articulo</label>
            <asp:TextBox runat="server" ID="txtArticulo" class="form-control" type="text" />
        </div>
        <div class="col-md-3">
            <p></p>
            <label for="txtFecha" class="form-label">Fecha</label>
            <asp:TextBox runat="server" ID="txtFecha" class="form-control" type="text" />
        </div>
    </div>

    
    <div class="card" style="width: 25rem;">
        <img src="<%: arti.imagen.Url %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"><%: arti.Nombre %></h5>
            <p class="card-text"><%: arti.Descripcion %></p>
        </div>
    </div>



</asp:Content>
