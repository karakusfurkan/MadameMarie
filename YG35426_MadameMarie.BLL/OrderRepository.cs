using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{
    public class OrderRepository : IRepository<Order>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Order eklenecek)
        {
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Order.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Order guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Order eski = db.Order.Find(guncellenecek.ID);
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

        public Order IDileGetir(int id)
        {
            return db.Order.Find(id);
        }

        public List<Order> Listele()
        {
            return db.Order.Where(o => o.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Order silinecek = db.Order.Find(id);
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
