using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;

namespace YG35426_MadameMarie
{
    public partial class Urunler : System.Web.UI.Page
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        ProductRepository productRepo = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptKategoriler.DataSource = categoryRepo.Listele();
            rptKategoriler.DataBind();
            rptUrunler.DataSource = productRepo.Listele();
            rptUrunler.DataBind();
            if (Request.QueryString["bID"] != null)
            {
                rptUrunler.DataSource = productRepo.Listele().Where(p => p.BrandID == int.Parse(Request.QueryString["bID"])).ToList();
                rptUrunler.DataBind();
            }
        }

        protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rptMarkalar = e.Item.FindControl("rptMarkalar") as Repeater;
            HiddenField hdnCatID = (HiddenField)e.Item.FindControl("hdnCategoryID");
            BrandRepository brandRepo = new BrandRepository();
            rptMarkalar.DataSource = brandRepo.Listele().Where(b => b.CategoryID == int.Parse(hdnCatID.Value)).ToList();
            rptMarkalar.DataBind();
        }
    }
}