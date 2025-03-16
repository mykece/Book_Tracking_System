using CSProjeDemo1.Models.BaseModel;
using CSProjeDemo1.Models;
using CSProjeDemo1.Services;
using CSProjeDemo1.Enum;
using System.Data;

public class Program
{
    private static void Main(string[] args)
    {
        Kütüphane kutuphane = new Kütüphane();


        Kitap[] kitaplar = new Kitap[]
        {
            new KitapBilim("9780061122415", "Cosmos", "Carl Sagan", 1980),
            new KitapBilim("9780393069946", "A Brief History of Time", "Stephen Hawking", 1988),
            new KitapRoman("9780141439556", "To Kill a Mockingbird", "Harper Lee", 1960),
            new KitapRoman("9780307594004", "1984", "George Orwell", 1949),
            new KitapTarih("9780140449186", "The Histories", "Herodotus", -440)
        };

        // Dizideki kitapları kütüphaneye ekledi
        foreach (var kitap in kitaplar)
        {
            kutuphane.KitapEkle(kitap);
        }

        // Örnek üyeler oluşturdu ve kütüphaneye ekledi
        Uye[] uyeler = new Uye[]
        {
            new Uye("kullanici1", "sifre1", "Ahmet", "Yılmaz"),
            new Uye("kullanici2", "sifre2", "Ayşe", "Demir"),
            new Uye("kullanici3", "sifre3", "Mehmet", "Kaya")
        };

        foreach (var uye in uyeler)
        {
            kutuphane.UyeEkle(uye);
        }

        Uye girisYapanUye = null;
        bool oturumAcik = false;

        // Kullanıcıya menüyü gösteriyor
        while (true)
        {
            if (!oturumAcik)
            {
                Console.WriteLine("Kütüphane Programına Hoş Geldiniz!");
                Console.WriteLine("1. Oturum Aç");
                Console.WriteLine("2. Çıkış");
            }
            else
            {
                Console.WriteLine($"Hoş geldiniz, {girisYapanUye.Ad} {girisYapanUye.Soyad}!");
                Console.WriteLine("3. Kitapları Listele");
                Console.WriteLine("4. Kitap Ödünç Al");
                Console.WriteLine("5. Kitap İade Et");
                Console.WriteLine("6. Üyenin Ödünç Aldığı Kitapları Listele");
                Console.WriteLine("7. Kütüphane Durumunu Görüntüle");
                Console.WriteLine("8. Oturumu Kapat");
            }

            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    if (!oturumAcik)
                    {
                        Console.Write("Kullanıcı Adı: ");
                        string kullaniciAdi = Console.ReadLine();
                        Console.Write("Parola: ");
                        string parola = Console.ReadLine();
                        girisYapanUye = kutuphane.OturumAc(kullaniciAdi, parola);
                        if (girisYapanUye != null)
                        {
                            oturumAcik = true;
                            Console.WriteLine($"Giriş başarılı. Hoş geldiniz, {girisYapanUye.Ad} {girisYapanUye.Soyad}!");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz kullanıcı adı veya parola. Lütfen tekrar deneyin.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Oturum zaten açık. Lütfen önce oturumu kapatın.");
                    }
                    break;
                case "2":
                    if (!oturumAcik)
                    {
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Önce oturumu kapatın.");
                    }
                    break;
                case "3":
                    if (oturumAcik)
                    {
                        kutuphane.KataloguGoruntule();
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;
                case "4":
                    if (oturumAcik)
                    {
                        Console.Write("Ödünç almak istediğiniz kitabın ISBN numarasını girin: ");
                        string isbn = Console.ReadLine();
                        Kitap oduncAlinacakKitap = kutuphane.Kitaplar.Find(k => k.ISBN == isbn);
                        if (oduncAlinacakKitap != null)
                        {
                            if (oduncAlinacakKitap.Durum == Durum.OduncAlinabilir)
                            {
                                if (girisYapanUye.KitapOduncAl(oduncAlinacakKitap))
                                {
                                    oduncAlinacakKitap.Durum = Durum.OduncAlindi; // Kitabın durumunu ödünç alındı olarak güncelledi
                                }
                            }
                            else
                            {
                                Console.WriteLine("Bu kitap şu anda uygun değil veya zaten ödünç alınmış.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bu ISBN numarasına sahip bir kitap bulunamadı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;


                case "5":
                    if (oturumAcik)
                    {
                        Console.Write("İade etmek istediğiniz kitabın ISBN numarasını girin: ");
                        string isbn = Console.ReadLine();
                        Kitap iadeEdilecekKitap = girisYapanUye.OduncKitaplar.Find(k => k.ISBN == isbn);
                        if (iadeEdilecekKitap != null)
                        {
                            girisYapanUye.KitapIadeEt(iadeEdilecekKitap);
                            kutuphane.KitapEkle(iadeEdilecekKitap);
                        }
                        else
                        {
                            Console.WriteLine("Bu ISBN numarasına sahip bir kitap ödünç alınmamış.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;
                case "6":
                    if (oturumAcik)
                    {
                        girisYapanUye.OduncAlinanKitaplariGoruntule();
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;
                case "7":
                    if (oturumAcik)
                    {
                        kutuphane.KutuphaneDurumuGoruntule();
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;
                case "8":
                    if (oturumAcik)
                    {
                        oturumAcik = false;
                        girisYapanUye = null;
                        Console.WriteLine("Oturum kapatıldı.");
                    }
                    else
                    {
                        Console.WriteLine("Önce oturum açmanız gerekmektedir.");
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }

            Console.WriteLine();

           // Sleep();
        }
        void Sleep() 
        {
            Thread.Sleep(3000);
            Console.Clear();
        }

    }
}