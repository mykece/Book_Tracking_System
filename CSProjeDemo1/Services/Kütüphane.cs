using CSProjeDemo1.Enum;
using CSProjeDemo1.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services
{
    public class Kütüphane
    {
        public List<Kitap> Kitaplar { get; }
        public List<Uye> Uyeler { get; }
        public Kütüphane()
        {
            Kitaplar = new List<Kitap>();
            Uyeler = new List<Uye>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        public void KitapSil(Kitap kitap)
        {
            Kitaplar.Remove(kitap);
        }

        public void KataloguGoruntule()
        {
            Console.WriteLine("Kütüphane Kataloğu:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"- {kitap.Baslik} ({kitap.ISBN}) - {kitap.Tur()}, Durum: {kitap.Durum}");
            }
        }

        public void UyeEkle(Uye uye)
        {
            Uyeler.Add(uye);
        }

        public Uye OturumAc(string kullaniciAdi, string parola)
        {
            return Uyeler.Find(u => u.KullaniciAdi == kullaniciAdi && u.Parola == parola);
        }

        public void UyeleriGoruntule()
        {
            Console.WriteLine("Üyeler:");
            foreach (var uye in Uyeler)
            {
                Console.WriteLine($"- {uye.Ad} {uye.Soyad}");
            }
        }

        public void OduncAlinanKitaplarGoruntule()
        {
            Console.WriteLine("Ödünç Alınan Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                if (kitap.Durum == Durum.OduncAlindi)
                {
                    Console.WriteLine($"- {kitap.Baslik} ({kitap.Tur()})");
                }
            }
        }

        public void KutuphaneDurumuGoruntule()
        {
            KataloguGoruntule();
            UyeleriGoruntule();
            OduncAlinanKitaplarGoruntule();
        }
    }
}
