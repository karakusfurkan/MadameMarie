using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{
    public class InvoiceRepository : IRepository<Invoice>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Invoice eklenecek)
        {
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Invoice.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Invoice guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Invoice eski = db.Invoice.Find(guncellenecek.ID);
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

        public Invoice IDileGetir(int id)
        {
            return db.Invoice.Find(id);
        }

        public List<Invoice> Listele()
        {
            return db.Invoice.Where(i => i.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Invoice silinecek = db.Invoice.Find(id);
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
