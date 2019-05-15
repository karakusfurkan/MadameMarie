using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;

namespace YG35426_MadameMarie.Admin
{
    public partial class Kategoriler : System.Web.UI.Page
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Request.QueryString["ID"] != null && Request.QueryString["cmd"] == "delete")
            {
                bool sonuc = categoryRepo.Sil(int.Parse(Request.QueryString["ID"]));
                Response.Write(sonuc ? "<script>alert('Harika! Silindi!');</script>" : "<script>alert('Hay Aksi! Silinemedi!');</script>");
            }
            rptKategoriler.DataSource = categoryRepo.Listele();
            rptKategoriler.DataBind();
        }
    }
}