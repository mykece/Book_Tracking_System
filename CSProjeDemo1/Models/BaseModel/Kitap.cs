using CSProjeDemo1.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Models.BaseModel
{
    public abstract class Kitap
    {
        public string ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public int YayinYili { get; set; }
        public Durum Durum { get; set; }

        public Kitap(string isbn, string baslik, string yazar, int yayinYili)
        {
            ISBN = isbn;
            Baslik = baslik;
            Yazar = yazar;
            YayinYili = yayinYili;
            Durum = Durum.OduncAlinabilir;
        }

        public abstract string Tur();
    }
}
