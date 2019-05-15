using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;

namespace YG35426_MadameMarie
{
    public partial class Default : System.Web.UI.Page
    {
        ProductRepository productRepo = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptUrunler.DataSource = productRepo.Listele().OrderByDescending(p => p.ID).Take(5);
            rptUrunler.DataBind();
        }
    }
}