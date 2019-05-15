using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{
    public class DiscountRepository : IRepository<Discount>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Discount eklenecek)
        {
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Discount.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Discount guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Discount eski = db.Discount.Find(guncellenecek.ID);
                db.Entry(eski).CurrentValues.SetValues(guncellenecek);
                eski.isActive = true;
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public Discount IDileGetir(int id)
        {
            return db.Discount.Find(id);
        }

        public List<Discount> Listele()
        {
            return db.Discount.Where(d => d.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Discount silinecek = db.Discount.Find(id);
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
