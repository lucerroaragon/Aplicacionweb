using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace App_Promo_Web
{
    public partial class CatalogoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> articulos = articuloNegocio.listarTodos();

            foreach (var articulo in articulos)
            {
                string cardHtml = $@"
        <div class='col-md-4 mb-4'>
            <div class='card h-100'> <!-- Clase h-100 añadida aquí -->
                <img src='{articulo.imagen?.Url ?? "default.jpg"}' class='card-img-top' alt='{articulo.Nombre}'>
                <div class='card-body'>
                    <h5 class='card-title'>{articulo.Nombre}</h5>
                    <p class='card-text'>{articulo.Descripcion}</p>
                    <a href='FormularioCliente.aspx?IdArticulo={articulo.IdArticulo}' class='btn btn-primary'>Canjear</a>
                </div>
            </div>
        </div>";

                articulosContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }

    }
}
