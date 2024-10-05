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


                string carouselId = $"carousel_{articulo.IdArticulo}";
                string carouselHtml = $@"
                <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
                <div class='carousel-inner'>";
                 
                for (int i = 0; i < articulo.imagenes.Count; i++) 
                {
                    var imagen = articulo.imagenes[i];
                    string activeClass = i == 0 ? "active" : "";

                    carouselHtml += $@"
                    <div class='carousel-item {activeClass}'>
                        <img src='{imagen}' class='d-block w-100 img-custom' alt='{articulo.Nombre}'>
                    </div>";

                }
                carouselHtml += @"
            </div>
            <button class='carousel-control-prev' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='prev'>
                <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                <span class='visually-hidden'>Previous</span>
            </button>
            <button class='carousel-control-next' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='next'>
                <span class='carousel-control-next-icon' aria-hidden='true'></span>
                <span class='visually-hidden'>Next</span>
            </button>
        </div>";

                // Card HTML con el carrusel
                string cardHtml = $@"
        <div class='col-md-4 mb-4'>
            <div class='card h-100'>
                {carouselHtml}
                <div class='card-body'>
                    <h5 class='card-title'>{articulo.Nombre}</h5>
                    <p class='card-text'>{articulo.Descripcion}</p>
                    <a href='FormularioCliente.aspx?IdArticulo={articulo.IdArticulo}' class='btn btn-primary btn-flex'>Canjear</a>
                </div>
            </div>
        </div>";

                articulosContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }

    }
}
