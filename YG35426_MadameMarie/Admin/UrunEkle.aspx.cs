using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YG35426_MadameMarie.BLL;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.Admin
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        BrandRepository brandRepo = new BrandRepository();
        DiscountRepository discountRepo = new DiscountRepository();
        ProductRepository productRepo = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            ddlKategoriler.DataSource = categoryRepo.Listele();
            ddlKategoriler.DataTextField = "CategoryName";
            ddlKategoriler.DataValueField = "ID";
            ddlKategoriler.DataBind();
            ddlKategoriler.Items.Insert(0, new ListItem("- Kategori Seçiniz -", "0"));

            ddlMarkalar.DataSource = brandRepo.Listele();
            ddlMarkalar.DataTextField = "BrandName";
            ddlMarkalar.DataValueField = "ID";
            ddlMarkalar.DataBind();
            ddlMarkalar.Items.Insert(0, new ListItem("- Marka Seçiniz -", "0"));

            IndirimDoldur();
            if (Request.QueryString["ID"] != null)
            {
                Product gelenUrun = productRepo.IDileGetir(int.Parse(Request.QueryString["ID"]));
                txtAciklama.Text = gelenUrun.Description;
                txtFiyat.Text = string.Format("{0:00}", gelenUrun.UnitPrice);
                txtStokMiktari.Text = gelenUrun.UnitsInStock.ToString();
                txtUrunAdi.Text = gelenUrun.ProductName;
                ddlIndirim.SelectedValue = gelenUrun.DiscountID.ToString();
                ddlKategoriler.SelectedValue = gelenUrun.CategoryID.ToString();
                ddlMarkalar.SelectedValue = gelenUrun.BrandID.ToString();
                btnKaydet.Text = "Ürünü Güncelle";
            }
            
        }
        void IndirimDoldur()
        {
            ddlIndirim.DataSource = discountRepo.Listele().Select(i => new
            {
                Indirim = "%" + (1 - i.Discount1) * 100,
                ID = i.ID
            });
            ddlIndirim.DataTextField = "Indirim";
            ddlIndirim.DataValueField = "ID";
            ddlIndirim.DataBind();
            ddlIndirim.Items.Insert(0, new ListItem("- İndirim Yok-", "0"));
        }
        string resimAdi;
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Product eklenecek = new Product();
            eklenecek.BrandID = int.Parse(ddlMarkalar.SelectedValue);
            eklenecek.CategoryID = int.Parse(ddlKategoriler.SelectedValue);
            eklenecek.Description = txtAciklama.Text;
            eklenecek.DiscountID = int.Parse(ddlIndirim.SelectedValue);
            eklenecek.ProductName = txtUrunAdi.Text;
            eklenecek.UnitPrice = decimal.Parse(txtFiyat.Text);
            eklenecek.UnitsInStock = int.Parse(txtStokMiktari.Text);
            if (btnKaydet.Text == "Ürünü Kaydet")
            {
                #region FotoEkleme
                HttpFileCollection files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    if (file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string uzanti = Path.GetExtension(file.FileName);
                        resimAdi = Guid.NewGuid() + uzanti;
                        file.SaveAs(Server.MapPath("~/Admin/UrunFoto/big/" + resimAdi));
                        Bitmap resim = new Bitmap(Server.MapPath("~/Admin/UrunFoto/big/" + resimAdi));
                        resim = HelperMethods.ResimBoyutlandir(resim, 150);
                        resim.Save(Server.MapPath("~/Admin/UrunFoto/small/" + resimAdi));
                    }
                }
                #endregion
                eklenecek.PhotoPath = resimAdi;
                bool sonuc = productRepo.Ekle(eklenecek);
                if (sonuc)
                {
                    Response.Write("<script>alert('Ürün başarıyla eklendi!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Hata Oluştu!');</script>");
                }
            }
            else
            {
                eklenecek.ID = int.Parse(Request.QueryString["ID"]);

                if (FileUpload1.HasFile)
                {
                    Product gelen = productRepo.IDileGetir(int.Parse(Request.QueryString["ID"]));
                    File.Delete(Server.MapPath("~/Admin/UrunFoto/small/" + gelen.PhotoPath));
                    File.Delete(Server.MapPath("~/Admin/UrunFoto/big/" + gelen.PhotoPath));

                    //Foto Ekleme
                    HttpFileCollection files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];

                        string uzanti = Path.GetExtension(file.FileName);
                        string resimAdi = Guid.NewGuid() + uzanti;
                        file.SaveAs(Server.MapPath("~/Admin/UrunFoto/big/" + resimAdi));
                        Bitmap resim = new Bitmap(Server.MapPath("~/Admin/UrunFoto/big/" + resimAdi));
                        resim = HelperMethods.ResimBoyutlandir(resim, 150);
                        resim.Save(Server.MapPath("~/Admin/UrunFoto/small/" + resimAdi));
                        eklenecek.PhotoPath = resimAdi;
                    }
                }
                else
                {
                    Product eskiUrun = productRepo.IDileGetir(int.Parse(Request.QueryString["ID"]));
                    eklenecek.PhotoPath = eskiUrun.PhotoPath;
                }

                bool sonuc = productRepo.Guncelle(eklenecek);
                if (sonuc)
                {
                    Response.Redirect("Urunler.aspx");
                }
                else
                    Response.Write("<script>alert('Hata Oluştu!');</script>");
            }
        }
    }
}