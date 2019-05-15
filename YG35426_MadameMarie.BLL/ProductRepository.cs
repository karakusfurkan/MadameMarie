using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{
    public class ProductRepository : IRepository<Product>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Product eklenecek)
        {
            
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Product.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Product guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Product eskiUrun = db.Product.FirstOrDefault(p => p.ID == guncellenecek.ID);
                db.Entry(eskiUrun).CurrentValues.SetValues(guncellenecek);
                eskiUrun.isActive = true;
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public Product IDileGetir(int id)
        {
            return db.Product.Find(id);
        }

        public List<Product> Listele()
        {
            return db.Product.Where(p => p.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Product silinecek = db.Product.Find(id);
                silinecek.isActive = false;
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }
    }
}
