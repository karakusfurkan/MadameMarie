using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.Admin
{
    public partial class Urunler : System.Web.UI.Page
    {
        ProductRepository productRepo = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Request.QueryString["ID"] != null && Request.QueryString["cmd"] == "delete")
            {
                Product silinecek = productRepo.IDileGetir(int.Parse(Request.QueryString["ID"]));
                File.Delete(Server.MapPath("~/Admin/UrunFoto/big/" + silinecek.PhotoPath));
                File.Delete(Server.MapPath("~/Admin/UrunFoto/small/" + silinecek.PhotoPath));

                bool sonuc = productRepo.Sil(silinecek.ID);
                Response.Write(sonuc ? "<script>alert('Ürün Başarıyla Silindi!');</script>" : "<script>alert('Hata Oluştu!');</script>");
                Response.Redirect("Urunler.aspx");
            }
            rptUrunler.DataSource = productRepo.Listele();
            rptUrunler.DataBind();
        }
    }
}