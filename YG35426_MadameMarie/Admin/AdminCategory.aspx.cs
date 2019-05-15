using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.Admin
{
    public partial class AdminCategory : System.Web.UI.Page
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Request.QueryString["catID"] != null)
            {
                btnKaydet.Text = "Kategori Güncelle";
                int catID = int.Parse(Request.QueryString["catID"]);
                Category gelenKategori = categoryRepo.IDileGetir(catID);
                txtAciklama.Text = gelenKategori.Description;
                txtKategoriAdi.Text = gelenKategori.CategoryName;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kategori Kaydet")
            {
                bool sonuc = categoryRepo.Ekle(new Category
                {
                    CategoryName = txtKategoriAdi.Text,
                    Description = txtAciklama.Text
                });
                if (sonuc)
                {
                    Response.Write("<script>alert('Kategori başarıyla kaydedildi!');</script>");
                    txtAciklama.Text = txtKategoriAdi.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Hata Oluştu!');</script>");
                }
            }
            else
            {
                Category guncellenecek = categoryRepo.IDileGetir(int.Parse(Request.QueryString["catID"]));
                guncellenecek.CategoryName = txtKategoriAdi.Text;
                guncellenecek.Description = txtAciklama.Text;
                bool sonuc = categoryRepo.Guncelle(guncellenecek);
                if (sonuc)
                {
                    Response.Write("<script>alert('Harika! Güncellendi!');</script>");
                    txtAciklama.Text = txtKategoriAdi.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Hay aksi! Hata Oluştu!');</script>");
                }
            }
        }
    }
}