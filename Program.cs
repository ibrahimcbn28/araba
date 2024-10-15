using System;
using System.Collections.Generic;

public class Arac
{
    public string Plaka { get; set; }
    public string Tip { get; set; } // Araba veya Kamyonet
    public double Fiyat { get; set; }
    public bool KiralikMi { get; set; }

    public Arac(string plaka, string tip, double fiyat, bool kiralikMi)
    {
        Plaka = plaka;
        Tip = tip;
        Fiyat = fiyat;
        KiralikMi = kiralikMi;
    }

    public override string ToString()
    {
        return $"Plaka: {Plaka}, Tip: {Tip}, Fiyat: {Fiyat}, Kiralık: {KiralikMi}";
    }
}

public class AracYonetimi
{
    private List<Arac> araclar = new List<Arac>();

    public void AracEkle(Arac arac)
    {
        araclar.Add(arac);
        Console.WriteLine("Araç eklendi: " + arac.Plaka);
    }

    public void AracSil(string plaka)
    {
        araclar.RemoveAll(a => a.Plaka == plaka);
        Console.WriteLine("Araç silindi: " + plaka);
    }

    public void AracListele()
    {
        foreach (var arac in araclar)
        {
            Console.WriteLine(arac);
        }
    }

    public void SatinalmaIslemi(string plaka, double indirim1, double indirim2, double indirim3)
    {
        var arac = araclar.Find(a => a.Plaka == plaka);
        if (arac != null)
        {
            double toplamIndirim = arac.Fiyat * (indirim1 + indirim2 + indirim3) / 100;
            double sonFiyat = arac.Fiyat - toplamIndirim;
            Console.WriteLine($"Araç satın alındı! Plaka: {arac.Plaka}, İndirim: {toplamIndirim}, Son Fiyat: {sonFiyat}");
        }
        else
        {
            Console.WriteLine("Araç bulunamadı.");
        }
    }

    public void KiralamaIslemi(string plaka, double indirim1, double indirim2, int gunSayisi)
    {
        var arac = araclar.Find(a => a.Plaka == plaka);
        if (arac != null && arac.KiralikMi)
        {
            double kiraBedeli = arac.Fiyat * gunSayisi;
            double toplamIndirim = kiraBedeli * (indirim1 + indirim2) / 100;
            double sonFiyat = kiraBedeli - toplamIndirim;
            Console.WriteLine($"Araç kiralandı! Plaka: {arac.Plaka}, Gün Sayısı: {gunSayisi}, İndirim: {toplamIndirim}, Son Kira Bedeli: {sonFiyat}");
        }
        else
        {
            Console.WriteLine("Kiralık araç bulunamadı veya bu araç kiralanamaz.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AracYonetimi yonetim = new AracYonetimi();

        // Araç ekleme
        yonetim.AracEkle(new Arac("28RA310", "Araba", 950000, false));
        yonetim.AracEkle(new Arac("28İC658", "Kamyonet", 650000, true));

        // Araç listeleme
        Console.WriteLine("Mevcut Araçlar:");
        yonetim.AracListele();

        // Satın alma işlemi
        yonetim.SatinalmaIslemi("28RA310", 5, 10, 15);

        // Kiralama işlemi
        yonetim.KiralamaIslemi("28İC658", 10, 5, 7);

        // Araç silme
        yonetim.AracSil("28RA310");

        // Araç listeleme
        Console.WriteLine("Güncel Araçlar:");
        yonetim.AracListele();
    }
}
