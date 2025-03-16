using CSProjeDemo1.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Models
{
    public class KitapRoman : Kitap
    {
        public KitapRoman(string isbn, string baslik, string yazar, int yayinYili) : base(isbn, baslik, yazar, yayinYili)
        {
        }

        public override string Tur()
        {
            return "Roman";
        }
    }
}
