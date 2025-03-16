using CSProjeDemo1.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services
{
    public class Uye : IUye
    {
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public List<Kitap> OduncKitaplar { get; set; }

        public Uye(string kullaniciAdi, string parola, string ad, string soyad)
        {
            KullaniciAdi = kullaniciAdi;
            Parola = parola;
            Ad = ad;
            Soyad = soyad;
            OduncKitaplar = new List<Kitap>();

        }

        public bool KitapOduncAl(Kitap kitap)
        {
            if (kitap.Durum == Enum.Durum.OduncAlinabilir)
            {
                kitap.Durum = Enum.Durum.OduncAlindi;
                OduncKitaplar.Add(kitap);
                Console.WriteLine($"{kitap.Baslik} kitabı {Ad} {Soyad} tarafından ödünç alındı!");
                return true;
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} kitabı şu anda uygun değil.");
                return false;

            }
        }

        public bool KitapIadeEt(Kitap kitap)
        {
            if (OduncKitaplar.Contains(kitap))
            {
                kitap.Durum = Enum.Durum.OduncAlinabilir;
                OduncKitaplar.Remove(kitap);
                Console.WriteLine($"{kitap.Baslik} kitabı {Ad} {Soyad} tarafından iade edildi.");
                return true;
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} kitabı halihazırda sizin tarafınızdan ödünç alınmış");
                return false;

            }
        }
        public List<Kitap> OduncAlinanKitaplariGoruntule()
        {
            if (OduncKitaplar.Count == 0)
            {
                Console.WriteLine("Hiç kitap ödünç alınmamış.");
                return new List<Kitap>();
            }
            else
            {
                Console.WriteLine($"{Ad} {Soyad}'ın ödünç aldığı kitaplar:");
                foreach (var kitap in OduncKitaplar)
                {
                    Console.WriteLine($"- {kitap.Baslik} ({kitap.Tur()})");
                }
                return OduncKitaplar;
            }
        }

    }
}
