using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace App_Promo_Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is _Default))
            {
                if (!(Seguridad.SessionVoucherActivo(Session["IdVoucher"])))
                {
                    Response.Redirect("default.aspx", false);
                }
            }
        }
    }
}