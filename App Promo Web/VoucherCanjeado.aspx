<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherCanjeado.aspx.cs" Inherits="App_Promo_Web.VoucherCanjeado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mt-4">
     
        <h2>
            <% if (lblError.Visible) { %>
                ¡Código de voucher incorrecto o ya utilizado!
            <% } else { %>
                ¡El voucher fue canjeado exitosamente!
            <% } %>
        </h2>
        <% if (lblError.Visible) { %>
            <p><%= lblError.Text %></p>
        <% } else { %>
            <p>¡Tu código de voucher ha sido canjeado correctamente! ¡Disfruta de tu premio!</p>
        <% } %>
        
 
        <p>¡No pierdas la oportunidad de llevarte uno de los muchos premios que tenemos para ti. ¡Buena suerte!</p>
    </div>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>


    <div class="mt-4">
        <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
    </div>
</asp:Content>

