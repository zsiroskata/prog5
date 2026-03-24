using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace prog5
{
    internal class Menhely
    {
    Allat[] allatok;
    public void Beolvas(string file)
     {
            try
            {
                allatok = new Allat[File.ReadAllLines(file).Length - 1];
                StreamReader sr = new StreamReader(file);
                int db = 0;
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] s = sor.Split(";");
                    allatok[db] = new Allat(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]), int.Parse(s[4]), int.Parse(s[5]));
                    db++;
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Hiba, a megadott file nem található!");
            }
            catch (Exception e)
            {
                Console.WriteLine("ismeretlen hiba: " + e);
            }

        }
        public void Listaz()
        {
            for (int i = 0; i < allatok.Length; i++)
            {
                Console.WriteLine($"név: {allatok[i].Nev} -\tfaj: {allatok[i].Faj}\t - {allatok[i].Eletkor} éves");
            }
            
        }

        public int AtlagEletkor()
        {
            int sum = 0;
            for (int i = 0; i < allatok.Length; i++)
            {
                sum += allatok[i].Eletkor;
            }
            return sum / allatok.Length;

        }

        public string LegmagasabbKoltseg()
        {
            int max = 0;
            int ora = 1;
            for(int i = 1;i < allatok.Length; i++)
            {
                if (allatok[i].GondozasiKoltseg(ora) > allatok[max].GondozasiKoltseg(ora))
                {
                    max = i;
                }
            }
            return $"{allatok[max].Nev}";
        }
        public string LegalacsonyabbEteligeny()
        {
            int min = 0;
            for (int i = 1; i < allatok.Length; i++)
            {
                if (allatok[i].Eteligeny < allatok[min].Eteligeny)
                {
                    min = i;
                }
            }
            return $"{allatok[min].Nev}";
        }

        public void KeresNevAlapjan(string nev)
        {
           
            for (int i = 0; i < allatok.Length; i++)
            {
                if (allatok[i].Nev.Contains(nev))
                {
                    Console.WriteLine($"{allatok[i].Nev}");
                }
            }
        }
    }

   
}
