<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_Promo_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mt-4">
        <h2>¡Participa ahora y gana fabulosos premios!</h2>
        <p>¿Tienes un código? ¡Es tu momento de ganar!</p>
        <p>Para participar en esta increíble promoción, simplemente introduce el código que recibiste en el campo que verás a continuación y descubre al instante si eres uno de nuestros afortunados ganadores.</p>
        <p class="font-weight-bold">Sigue estos sencillos pasos:</p>
        <ul>
            <li>Busca el código único en tu ticket o producto promocional.</li>
            <li>Escribe tu código en el campo de abajo.</li>
            <li>Haz clic en el botón "Verificar" y sabrás si has ganado uno de nuestros premios increíbles.</li>
        </ul>
        <p>¡Es así de fácil! No pierdas la oportunidad de llevarte uno de los muchos premios que tenemos para ti. ¡Buena suerte!</p>
    </div>

    <div class="row h-100 d-flex align-items-center justify-content-center p-5 ">
        <div class="col-12 col-md-6 col-lg-4 p-4">
            <div class="mb-3">
                <label class="form-label">Ingrese el Codigo alfanumerico</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Codigo" required></asp:TextBox>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="btnVerificar" runat="server" Text="Verificar" CssClass="btn btn-primary" OnClick="btnVerificar_Click" />
        </div>
    </div>

</asp:Content>
