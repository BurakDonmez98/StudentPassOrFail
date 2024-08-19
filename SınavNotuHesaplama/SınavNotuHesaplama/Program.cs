using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            int toplamYuzde = 0;
            double sonuc = 0;
            char harfNotu;
            string durum;

            Console.WriteLine("Çıkış için 'E' tuşuna ardından 'Enter' tuşuna basınız.");
            Console.WriteLine("Not hesaplamak için 'H' tuşuna ardından 'Enter' tuşuna basınız.");
            string secim = Console.ReadLine();

            if (string.Equals(secim, "E", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Çıkış Yapmayı tercih ettiniz, program kapanıyor...");
                break;
            }
            else if (string.Equals(secim, "H", StringComparison.OrdinalIgnoreCase))
            {
                string ders = BirStringDegerAl("Dersin adını giriniz: ");
                int notSayisi = PozitifIntDegerAl("Kaç adet not gireceğinizi numerik şekilde yazınız: ");

                for (int i = 1; i <= notSayisi; i++)
                {
                    int dersNotu = PozitifIntDegerAl(i + ". Ders Notunuzu giriniz: ");
                    int dersYuzdesi = GecerliYuzdeYuzDegeriAl(i + ". Dersinizin yüzdesini numerik olarak giriniz: ", ref toplamYuzde);
                    sonuc += (dersNotu * dersYuzdesi) / 100.0;
                }

                harfNotu = GetHarfNotu(sonuc);
                durum = GetDurum(sonuc);
                Console.WriteLine($"Ders Notunuz = {Math.Abs(sonuc)}, Harf Notu = {harfNotu}, Durum: {durum}");
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek. Lütfen 'H' veya 'E' giriniz.");
            }
        }
    }

    static char GetHarfNotu(double not)
    {
        if (not >= 90)
        {
            return 'A';
        }
        else if (not >= 80)
        {
            return 'B';
        }
        else if (not >= 70)
        {
            return 'C';
        }
        else if (not >= 60)
        {
            return 'D';
        }
        else
        {
            return 'F';
        }
    }

    static string GetDurum(double not)
    {
        return not >= 60 ? "Geçti" : "Kaldı";
    }

    static int PozitifIntDegerAl(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= 0 && result <= 100)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Lütfen 0-100 arası pozitif bir tam sayı giriniz.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Lütfen geçerli bir tam sayı giriniz.");
            }
        }
    }

    static string BirStringDegerAl(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Metin boş olamaz. Lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Beklenmedik bir hata oluştu: {ex.Message}");
            }
        }
    }

    static int GecerliYuzdeYuzDegeriAl(string prompt, ref int toplamYuzde)
    {
        int dersYuzdesi;
        while (true)
        {
            dersYuzdesi = PozitifIntDegerAl(prompt);

            if (toplamYuzde + dersYuzdesi > 100)
            {
                Console.WriteLine("Yüzdeler toplamı 100'ü geçiyor. Lütfen tekrar giriniz.");
            }
            else
            {
                toplamYuzde += dersYuzdesi;
                return dersYuzdesi;
            }
        }
    }
}
