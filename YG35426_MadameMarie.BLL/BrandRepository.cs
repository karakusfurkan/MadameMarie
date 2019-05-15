using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG35426_MadameMarie.MODEL;

namespace YG35426_MadameMarie.BLL
{

    public class BrandRepository : IRepository<Brand>
    {
        MadameMarieEntities db = new MadameMarieEntities();
        public bool Ekle(Brand eklenecek)
        {
            bool sonuc = false;
            try
            {
                eklenecek.isActive = true;
                db.Brand.Add(eklenecek);
                db.SaveChanges();
                return sonuc = true;
            }
            catch
            {
                return sonuc;
            }
        }

        public bool Guncelle(Brand guncellenecek)
        {
            bool sonuc = false;
            try
            {
                Brand eski = db.Brand.Find(guncellenecek.ID);
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

        public Brand IDileGetir(int id)
        {
            return db.Brand.Find(id);
        }

        public List<Brand> Listele()
        {
            return db.Brand.Where(b => b.isActive == true).ToList();
        }

        public bool Sil(int id)
        {
            bool sonuc = false;
            try
            {
                Brand silinecek = db.Brand.Find(id);
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
