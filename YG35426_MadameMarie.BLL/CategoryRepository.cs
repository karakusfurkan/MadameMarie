using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{
    public class CategoryRepository : IRepository<Category>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Category eklenecek)
        {
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Category.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Category guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Category eskiKategori = db.Category.Find(guncellenecek.ID);
                eskiKategori.CategoryName = guncellenecek.CategoryName;
                eskiKategori.Description = guncellenecek.Description;
                eskiKategori.isActive = true;
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public Category IDileGetir(int id)
        {
            return db.Category.Find(id);
        }

        public List<Category> Listele()
        {
            return db.Category.Where(c => c.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Category silinecek = db.Category.Find(id);
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
