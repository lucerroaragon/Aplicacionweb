<%@ Page Title="Voucher Canjeado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherCanjeado.aspx.cs" Inherits="App_Promo_Web.VoucherCanjeado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h1 class="display-4">¡Ocurrió un problema!</h1>
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        <p class="lead">El código de voucher ingresado ya ha sido utilizado o no existe.</p>
        <p>Por favor, verifica el código o contáctanos para más información.</p>
        <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
    </div>
</asp:Content>

