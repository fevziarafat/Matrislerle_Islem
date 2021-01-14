using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static void Main(string[] args)
        {
            MatrisIslemleri a = new MatrisIslemleri();
            var dizia = a.MatrisOlustur();
            Console.WriteLine("\n");
            Console.WriteLine("*****       A Matrisi     ******");
            a.MatrisYazdir(dizia);
            var dizib = a.MatrisOlustur();
            Console.WriteLine("\n");
            Console.WriteLine("*****       B Matrisi     ******");
            a.MatrisYazdir(dizib);
            a.MatrisIslemKarar(dizia, dizib);
            a.MatrisSonKarar(dizia, dizib);
            Console.ReadLine();
        }


    }

   public class MatrisIslemleri
    {
        public void MatrisSonKarar(int[,] dizia, int[,] dizib)
            {
                Console.Write("Yeni bir işlem yapmak istiyormusunuz?  [eE hH] = ");
                var devam = Convert.ToChar(Console.ReadLine());
                if (devam == 'e' || devam == 'E')
                    MatrisIslemKarar(dizia, dizib);
                else if (devam == 'h' || devam == 'H') Console.WriteLine("*** Hoşçakalın ***");
            }

            public void MatrisIslemKarar(int[,] dizia, int[,] dizib)
            {
                Console.WriteLine();
                Console.Write("Bu iki matris üzerinde hangi işlemleri yapmak istiyorsunuz?  [+ - * ] = ");
                var donenmatris = new int[dizia.GetUpperBound(1) + 1, dizia.GetUpperBound(1) + 1];
                char islem;
                islem = Convert.ToChar(Console.ReadLine());
                switch (islem)
                {
                    case '+':
                        MatrisYazdir(MatrisTopla(dizia, dizib));
                        break;
                    case '-':
                        MatrisYazdir(Matrisfark(dizia, dizib));
                        break;
                    case '*':
                        MatrisYazdir(MatrisCarp(dizia, dizib));
                        break;
                }
            }
            private static int[,] Matrisfark(int[,] dizia, int[,] dizib)
            {
                Console.WriteLine("\n");
                Console.WriteLine("*** Çıkarma Matrisi ***");
                Console.WriteLine("***********************");
                var donenmatriscikar = new int[dizia.GetUpperBound(1) + 1, dizia.GetUpperBound(1) + 1];
                for (var i = 0; i < dizia.GetUpperBound(1) + 1; i++)
                    for (var j = 0; j < dizia.GetUpperBound(1) + 1; j++)
                        donenmatriscikar[i, j] = dizia[i, j] - dizib[i, j];
                return donenmatriscikar;
            }

            private static int[,] MatrisTopla(int[,] dizia, int[,] dizib)
            {
                Console.WriteLine("\n");
                Console.WriteLine("*** Toplam Matrisi ***");
                Console.WriteLine("***********************");
                var donenmatris = new int[dizia.GetUpperBound(1) + 1, dizia.GetUpperBound(1) + 1];
                for (var i = 0; i < dizia.GetUpperBound(1) + 1; i++)
                    for (var j = 0; j < dizia.GetUpperBound(1) + 1; j++)
                        donenmatris[i, j] = dizia[i, j] + dizib[i, j];
                return donenmatris;
            }

            private static int[,] MatrisCarp(int[,] dizia, int[,] dizib)
            {
                Console.WriteLine("\n");
                Console.WriteLine("*** Çarpım Matrisi ***");
                Console.WriteLine("***********************");
                var donenmatriscarp = new int[dizia.GetUpperBound(1) + 1, dizia.GetUpperBound(1) + 1];
                for (var i = 0; i < dizia.GetUpperBound(1) + 1; i++)
                    for (var j = 0; j < dizia.GetUpperBound(1) + 1; j++)
                        donenmatriscarp[i, j] = dizia[i, j] * dizib[i, j];
                return donenmatriscarp;
            }

            public void MatrisYazdir(int[,] dizi)
            {
                Console.WriteLine("\n");
                for (var i = 0; i < dizi.GetUpperBound(1) + 1; i++)
                {
                    for (var j = 0; j < dizi.GetUpperBound(1) + 1; j++) Console.Write("  " + dizi[i, j]);
                    Console.WriteLine("\n");
                }
            }

            public int[,] MatrisOlustur()
            {
                int a;
                Console.Write("Matris kaç boyutlu olacak(iki matriste aynı boyutta olmalı) = ");
                a = Convert.ToInt32(Console.ReadLine());
                var dizi = new int[a, a];
                var rnd = new Random();
                for (var i = 0; i < a; i++)
                    for (var j = 0; j < a; j++)
                        dizi[i, j] = rnd.Next(20);
                return dizi;
            }
        }
    }

