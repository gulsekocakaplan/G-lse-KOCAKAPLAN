
/* 2 siteden intihal kontorlünde bulundum. https://www.paraphraser.io/tr/intihal-programi#google_vignette BU SİTEDE % 12 İNTİHAL 
 https://copyleaks.com/ BU SİTEDE İSE % 14 İNTİHAL ÇIKTI* Sizin pdflerinizden ve youtube-web de bulunan örneklerden faydalandım./
/*PROJE AMACI VE PROJE ADINI ALTTAKİ YORUM SATIRINDA ANLATACAĞIM
 *  PROJEMİN ADI -> KÜTÜPHANE OTOMASYONU
 * Bu projede  Üyeler ve Kitapların katalog olarak listelenmesini ve bu listede
 * kitapların ödünç alınmış mı yoksa mevcut mu olduğunun ekrana yazdırılmasını istedim.Üye ve kitap ekleyebilmeyi denedim , bu şekilde dışardan yeni kitap eklenebilecek.
 * üye bilgilerinde private kullandım, bu sayede bilgilere sadece sınıf içerisinden erişilebilir ve veriler sadece belirli koşullarda değiştirilebilir.
 * Interface'ler, farklı sınıflar arasında benzer işlevselliği paylaşmaya yardımcı olur.Interfrace sınıflar arasında bir soyutlama sağlar. Bu sayede, farklı sınıflar aynı arayüzü uygulayabilir.
 * Arayüz kullanmak, kodun daha iyi test edilebilir olmasını sağlar.Interface kullanmak, kodun daha anlaşılır olmasını sağlar. Giriş bölümünde temel bir kullanıcı kimlik doğrulama işlemi gerçekleştirilir. 
 * Bu programla üyelerin güvemliğini sağlamak ve düzenli,anlaşılır bir sistem kurmak istedim.
*/
interface IKutuphane
{
    void UyeEkle(Uye uye);
    void KitapEkle(Kitap kitap);
    void UyeGiris(int uyeNumarasi, string sifre);
    void KitapOduncAl(int kitapIndex, int uyeNumarasi);
    void KataloguGoruntule();
    void KitapEklemeEkranı();
    void YeniUyeEklemeEkranı();
}

class Yazar
{
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public override string ToString()
    {
        return $"{Ad} {Soyad}";
    }
}


//TO STRİNG METODU YAZARIN VE ÜYELERİN ADINI SOYADINI BİRLEŞTİREREK GERİ DÖNDÜRÜR.
//Nesnenin okunabilir bir şekilde ekrana yazdırılmasını sağlar.
class Uye
{
    private int uyeNumarasi;
    private string uyeAdi;
    private string sifre;

    public int UyeNumarasi
    {
        get { return uyeNumarasi; }
        set { uyeNumarasi = value; }
    }

    public string UyeAdi
    {
        get { return uyeAdi; }
        set { uyeAdi = value; }
    }

    public string Sifre
    {
        get { return sifre; }
        set { sifre = value; }
    }

    public override string ToString()
    {
        return $"{UyeAdi} (Üye No: {UyeNumarasi})";
    }
}

class Kitap
{
    public string KitapAdi { get; set; }
    public Yazar Yazar { get; set; }
    public bool OduncAlindiMi { get; set; }

    public override string ToString()
    {
        string durum = OduncAlindiMi ? "Ödünç Alındı" : "Mevcut";
        return $"{KitapAdi} - Yazar: {Yazar} - Durum: {durum}";
    }
}


class KutuphaneOtomasyonu : IKutuphane
{
    private List<Uye> uyeler;
    private List<Kitap> kitaplar;

    public KutuphaneOtomasyonu()
    {
        uyeler = new List<Uye>();
        kitaplar = new List<Kitap>();
    }

    public void UyeEkle(Uye uye)
    {
        uyeler.Add(uye);
        Console.WriteLine("Üye eklendi: " + uye);
    }

    public void KitapEkle(Kitap kitap)
    {
        kitaplar.Add(kitap);
        Console.WriteLine("Kitap eklendi: " + kitap);
    }
    /* Bu yorum metninin üst tarafında kalan alanda 4 adet sınıf kullandım.
   Yazar sınıfında 2 adet özellik bulunuyor ve ToString metodu kullandım.
 Kitap sınıfında yine 3 özeelik var. Bu özeelliklerden " OduncAlindiMi" kitabın ödünç alınıp alınmadığını belirten bir Boolen değeri.
 KÜTÜPHANE OTOMASYONU SINIFI:
 2 TANE LİSTE BULUNUR -> UYELER VE KİTAPLAR
 1 adet kurucu metod vardır. Kurucu metot (constructor), bir sınıf nesnesi oluşturulduğunda otomatik olarak çağrılan özel bir metottur.
 Bu metot kullanılırsa kütüphane otomasyonu başlatıldığında boş üye ve kitap listeleri ile başlanır.
 */
    public void UyeGiris(int uyeNumarasi, string sifre)
    {
        Uye uye = uyeler.Find(u => u.UyeNumarasi == uyeNumarasi && u.Sifre == sifre);

        if (uye != null)
        {
            Console.WriteLine("Giriş başarılı. Hoş geldiniz, " + uye.UyeAdi);
        }
        else
        {
            Console.WriteLine("Üye bulunamadı veya şifre yanlış.");
        }
    }

    /* uyeler.find metodu kullanılarak uyeler listesinde belirtilen özelliklere sahip bir Uye nesnesi aranır ve ıf koşulu kontrol edilir.
      eğer  Uye değişkeni null yani boş değilse "giriş başarılı" bildirisi ekrana yazdırılır aksi halde hata mesajı verir.*/
    public void KitapOduncAl(int kitapIndex, int uyeNumarasi)
    {
        if (kitapIndex >= 0 && kitapIndex < kitaplar.Count)
        {
            Kitap kitap = kitaplar[kitapIndex];

            if (!kitap.OduncAlindiMi)
            {
                kitap.OduncAlindiMi = true;
                Console.WriteLine(kitap.KitapAdi + " kitabı " + uyeNumarasi + " numaralı kişi tarafından ödünç alındı.");
            }
            else
            {
                Console.WriteLine(kitap.KitapAdi + " kitabı zaten ödünç alınmış.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz kitap index'i.");
        }
    }

    /*KitapIndex parametresi kütüphanede geçerli index olup olmadığını kontrol eder eğer geçerli indeks yoksa "Geçersiz kitap indexi" hatası verir.
     Böylece metot sonlanır. kitap.OduncAlindiMi kontrol edilir, kitabın  ödünç alınıp alınmadığına bakılır. Odunc alınmadıysa "true" olarak gösterilir
    Ödünç alma işlemi başarılı olursa ekrana "....kitabı x üye numaralı kişi tarafından ödünç alındı."  yazdırılır.*/
    public void KataloguGoruntule()
    {
        Console.WriteLine("Kütüphanede bulunan kitaplar:");
        foreach (Kitap kitap in kitaplar)
        {
            Console.WriteLine(kitap);
        }
    }

    /* foreach döngüsü kullanılarak kitaplar listesindeki kitap nesnesi üzerinde işlem yapılır.
     Burdaki temel amaç katalogdaki kitapları ekrana yazdırmaktır.*/
    public void KitapEklemeEkranı()
    {
        Console.WriteLine("Yeni kitap eklemek için bilgileri girin:");

        Console.Write("Kitap Adı: ");
        string kitapAdi = Console.ReadLine();

        Console.Write("Yazar Adı: ");
        string yazarAdi = Console.ReadLine();

        Console.Write("Yazar Soyadı: ");
        string yazarSoyad = Console.ReadLine();

        Yazar yazar = new Yazar { Ad = yazarAdi, Soyad = yazarSoyad };
        Kitap yeniKitap = new Kitap { KitapAdi = kitapAdi, Yazar = yazar, OduncAlindiMi = false };

        KitapEkle(yeniKitap);
    }

    public void YeniUyeEklemeEkranı()
    {
        Console.WriteLine("Lütfen üye olmak için bilgilerinizi giriniz:");
        Console.Write("Adınızı giriniz:");
        string uyeAdi = Console.ReadLine();

        Console.Write("Şifrenizi giriniz:");
        string uyeSifre = Console.ReadLine();
        int yeniUyeNumarasi = uyeler.Count + 1;
        Uye yeniUye = new Uye { UyeNumarasi = yeniUyeNumarasi, UyeAdi = uyeAdi, Sifre = uyeSifre };
        UyeEkle(yeniUye);
    }
}

// Üstte kalan alanalrda amaç kitap ve üye eklemektir. "uyeler" listesindeki mevcut üye sayısına 1 eklenerek yeni üye numarası belirlenir.
//OduncAlindiMi özelliği true olarak ayarlanarak yeni bir Kitap nesnesi oluşturulur.
class Program
{
    static void Main()
    {
        KutuphaneOtomasyonu kutuphane = new KutuphaneOtomasyonu();

        Uye uye1 = new Uye { UyeNumarasi = 1, UyeAdi = "Gülse", Sifre = "2580" };
        Uye uye2 = new Uye { UyeNumarasi = 2, UyeAdi = "Ceyda", Sifre = "1256" };

        Yazar yazar1 = new Yazar { Ad = "Jane", Soyad = "Austen" };
        Yazar yazar2 = new Yazar { Ad = "Sebahattin Ali", Soyad = "Şenyuva" };

        Kitap kitap1 = new Kitap { KitapAdi = "Aşk ve Gurur", Yazar = yazar1, OduncAlindiMi = false };
        Kitap kitap2 = new Kitap { KitapAdi = "Kürk Mantolu Madonna", Yazar = yazar2, OduncAlindiMi = false };

        kutuphane.UyeEkle(uye1);
        kutuphane.UyeEkle(uye2);

        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);

        kutuphane.KataloguGoruntule();

        kutuphane.UyeGiris(1, "2580");
        kutuphane.UyeGiris(3, "6758"); //böyle bir üye olmadığı için hatası alınır.
        kutuphane.KitapOduncAl(0, 1);

        kutuphane.KataloguGoruntule();

     
        kutuphane.KitapEklemeEkranı();
        kutuphane.KataloguGoruntule();

        /* sınıflar oluşturulur ve program sınıfının maini içinde  bu sınıftaki örnek nesneler oluşturulur. 
         Üye ve kitap nesneleri kütüphaneye eklenir.Kataloglar görüntülenir.
        Giriş kısmı gösterilir , başarılı olup olmadığı ekrana bastırılır.
        Kitap ekleme ekranı ile yeni kitap ekleyebiliriz.
        Bu kod örneğinde kütüphane otomasyonu simüle edilmiştir.*/
    }
}