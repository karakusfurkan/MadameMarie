using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG35426_MadameMarie.BLL
{
    public interface IRepository<T> where T:class
    {
        List<T> Listele();
        bool Ekle(T eklenecek);
        bool Guncelle(T guncellenecek);
        bool Sil(int id);
        T IDileGetir(int id);
    }
}
