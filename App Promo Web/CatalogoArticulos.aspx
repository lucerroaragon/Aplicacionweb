<%@ Page Title="Catálogo de Artículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoArticulos.aspx.cs" Inherits="App_Promo_Web.CatalogoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="mt-4">Elegí tu premio</h2>
        <div class="row" id="articulosContainer" runat="server">
        </div>
    </div>
</asp:Content>
