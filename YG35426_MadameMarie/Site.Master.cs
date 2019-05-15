using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;

namespace YG35426_MadameMarie
{
    public partial class Site : System.Web.UI.MasterPage
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            rptKategoriler.DataSource = categoryRepo.Listele();
            rptKategoriler.DataBind();
        }
    }
}