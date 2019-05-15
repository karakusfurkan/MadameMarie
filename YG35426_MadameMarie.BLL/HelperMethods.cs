using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG35426_MadameMarie.BLL
{
    public class HelperMethods
    {
        public static Bitmap ResimBoyutlandir(Bitmap resim, int boyut)
        {
            Bitmap sresim = resim;
            using (Bitmap OrjinalResim = resim)
            {
                double yukseklik = OrjinalResim.Height;
                double genislik = OrjinalResim.Width;
                double oran = 0;
                if (genislik >= boyut)
                {
                    oran = genislik / yukseklik;
                    genislik = boyut;
                    yukseklik = genislik / oran;
                    Size ydeger = new Size(Convert.ToInt32(genislik), Convert.ToInt32(yukseklik));
                    Bitmap yresim = new Bitmap(OrjinalResim, ydeger);
                    sresim = yresim;
                }
            }
            return sresim;
        }
    }
}
