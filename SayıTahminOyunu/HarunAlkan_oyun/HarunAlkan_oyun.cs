﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyun
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var devamMi = "evet";      // oyun tekrarını kontrol eden değişken
            var kacKisi = 0;            // oyunu oynayacak kişi sayısı
            var seviye = 0;             // seviue seçimi için kullanılan değişken
            var basla = "evet";
            var hak = 0;            // seçilen seviyeye göre kullanıcıya tanımlanan deneme hakkı.
            var randSayi = 0;       // oluşturulan random sayı
            var tahmin = 0;        //kullanıcının tahmini
            var denemeSayac = 0; // kalan tahmin hakkı kesaplamasında kullanılan sayaç değişkeni
            var TamPuan = 0;
            var icKont = 0;
            var siraKont = 0;      // sıralama kontrolünde kullanılan değişken
            var skor = "";
            var geciciPuan = 0;
            var geciciIsim = "";

            for (; devamMi == "evet";)   // en dışta bulunan ve oyunun tekrarını sağlayan for döngüsü
            {
                Console.WriteLine("*x*x*x*x*x* Sayı Tahmin Oyununa Hoşgeldiniz *x*x*x*x*x*", 20);
                Console.WriteLine("");

                Console.Write("Kaç kişilik bir oyun istiyorsunuz ? = ");        // kaç kişilik oyun olduğu ile ilgili kullanıcıdan sayı isteniyor.                
                kacKisi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                string[] isimler = new string[kacKisi];
                int[] puanlar = new int[kacKisi];

                if (devamMi == "evet" || basla == "evet")
                {

                    Random rand = new Random();

                    for (int i = 0; i < kacKisi; i++)
                    {
                        Console.Write("Oyuncunun Adı=");               // oyuncunun adının alındığı bölüm                       
                        isimler[i] = Convert.ToString(Console.ReadLine()); // isimlerin kaydedildiği dizi
                        Console.WriteLine("");
                        siraKont = siraKont + 1;

                        Console.WriteLine("*** Seviye seçimi yapın! ***");
                        Console.WriteLine("*x* Kolay=[1], 1-10 arası bir sayı ve 3 tahmin hakkı !!! *x*"); // seviye seçim bölümü
                        Console.WriteLine("*x* Orta=[2] , 1-20 arası bir sayı ve 5 tahmin hakkı !!! *x*");
                        Console.WriteLine("*x* Zor=[3]  , 1-30 arası bir sayı ve 7 tahmin hakkı !!! *x*");
                        Console.WriteLine("");
                        Console.Write("Seviye seçiminiz ? =");
                        seviye = Convert.ToInt32(Console.ReadLine());
                        switch (seviye)
                        {
                            case 1:
                                randSayi = rand.Next(1, 10);
                                hak = 3;
                                TamPuan = 10;
                                Console.WriteLine($"{randSayi}");
                                break;
                            case 2:
                                randSayi = rand.Next(1, 20);
                                hak = 5;
                                TamPuan = 20;
                                Console.WriteLine($"{randSayi}");
                                break;
                            case 3:
                                randSayi = rand.Next(1, 30);
                                hak = 7;
                                TamPuan = 30;
                                Console.WriteLine($"{randSayi}");
                                break;

                        }
                        for (int j = 0; j < hak; j++)
                        {
                            icKont = hak;
                            Console.Write("Tahmininiz =");              // kullanıcının tahmininin alındığı bölüm
                            tahmin = Convert.ToInt32(Console.ReadLine());   // tahmin 
                            denemeSayac = denemeSayac + 1;

                            if (tahmin == randSayi)                 // tahmin ve random sayının karşılaştırıldığı if döngüsü bölümü
                            {

                                puanlar[i] = TamPuan / denemeSayac;
                                Console.WriteLine($"Tebrikler {denemeSayac}'ncı tahmininizde bildiniz, Puanınız={puanlar[i]}!!! ");
                                Console.WriteLine("");
                                j = hak;
                                denemeSayac = 0;
                            }
                            else
                            {
                                // denemeSayac = denemeSayac + 1;  // kalan tahmin hakkı kesaplamasında kullanılan sayaç değişkeni

                                if (denemeSayac == hak)
                                {
                                    Console.WriteLine("*** Maalesef doğru sayıyı tahmin edemediniz!!!  Puan=0  ***");
                                    Console.WriteLine("");
                                    puanlar[i] = 0;
                                    denemeSayac = 0;
                                }
                                else if (denemeSayac < hak)
                                {
                                    Console.WriteLine($"*** {hak - denemeSayac} hakkınız kaldı!!! ***");
                                    Console.WriteLine("");
                                }
                            }
                        }



                        for (int l = 0; l < puanlar.Length - 1; l++)
                        {
                            for (int h = l; h < puanlar.Length; h++)
                            {

                                if (puanlar[l] < puanlar[h])
                                {
                                    geciciPuan = puanlar[h];
                                    puanlar[h] = puanlar[l];
                                    puanlar[l] = geciciPuan;

                                    geciciIsim = isimler[h];
                                    isimler[h] = isimler[l];
                                    isimler[l] = geciciIsim;
                                }
                            }

                        }


                        int f = 0;
                        int z = 1;

                        skor = Convert.ToString(" *x*x* Skor tablosu *x*x* ");
                        if (kacKisi == siraKont)
                        {

                            Console.WriteLine($"{skor,20}"); Console.WriteLine();

                            foreach (var item in puanlar)
                            {

                                Console.WriteLine($"{z}. Oyuncunun Adı={isimler[f]}, Oyuncunun puanı={item}");
                                f = f + 1;
                                z = z + 1;

                            }
                        }
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("*** Oyunumuzu oynadığınız için teşekkür ederiz ***");
                Console.WriteLine("");

                // Müzik (alıntı değildir).
                Console.Beep(352, 300); Console.Beep(396, 500);
                Console.Beep(396, 500); Console.Beep(352, 300);
                Console.Beep(330, 100); Console.Beep(297, 200);
                System.Threading.Thread.Sleep(125);
                Console.Beep(396, 500); Console.Beep(352, 100);
                Console.Beep(330, 300); Console.Beep(297, 300);
                Console.Beep(297, 300); Console.Beep(297, 300);
                System.Threading.Thread.Sleep(125);
                Console.Beep(330, 100); Console.Beep(396, 100);
                Console.Beep(440, 100); Console.Beep(396, 500);
                Console.Beep(396, 500); Console.Beep(352, 100);
                Console.Beep(330, 100); Console.Beep(297, 100);
                Console.Beep(352, 100); Console.Beep(330, 300);
                Console.Beep(297, 300); Console.Beep(297, 300);
                Console.Beep(297, 300);
                System.Threading.Thread.Sleep(125);
       

                //Aşağıda  kullanıcıdan devamMı değişkenine değer isteyerek yeni oyun başlamasını kontrol ediyoruz.
                Console.WriteLine("");
                Console.Write("Yeni bir oyun başlatmak istiyor musunuz ?= [evet] , [hayır]");
                devamMi = Convert.ToString(Console.ReadLine());


                Console.Clear();        // konsol ekranını temizler...

                if (devamMi == "evet")
                {
                    devamMi = "evet";           // devamMı değişkeninin value'si "evet" ise yeni bir oyun başlayacak.        
                }
                else if (devamMi == "hayır")
                {
                    devamMi = "hayır";          // devamMı değişkeninin value'si "hayır" ise yeni bir oyun sonlanacak.
                }

            }

            Console.ReadLine();
        }
    }
}
