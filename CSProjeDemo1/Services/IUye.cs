using CSProjeDemo1.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services
{
    public interface IUye
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public List<Kitap> OduncKitaplar { get; set; }

        bool KitapOduncAl(Kitap kitap);
        bool KitapIadeEt(Kitap kitap);
        List<Kitap> OduncAlinanKitaplariGoruntule();
    }
}
