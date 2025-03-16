using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSProjeDemo1.Models.BaseModel;

namespace CSProjeDemo1.Models;

public class KitapBilim : Kitap
{
    public KitapBilim(string isbn, string baslik, string yazar, int yayinYili) : base(isbn, baslik, yazar, yayinYili)
    {
    }

    public override string Tur()
    {
        return "Bilim";
    }
}
