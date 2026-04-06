using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog5
{
    internal class Menhely
    {

        Allat[] allatok;
        public void Beolvas()
        {
            string file = "allatok.txt";
            allatok = new Allat[File.ReadAllLines(file).Length];

            int db = 0;

            try
            {
                StreamReader sr = new StreamReader(file); 
                while (!sr.EndOfStream)
                {
                    var s= sr.ReadLine().Split(";");
                    allatok[db]= new Allat(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]) , int.Parse(s[4]), int.Parse(s[5]) );
                    db++;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Hiba, a megadott fájl nem található!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Listaz()
        {
            foreach (var item in allatok)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public double AtlagEletkor()
        {
            double avg = 0;
            foreach (var item in allatok)
            {
                avg += item.Eletkor;
            }
            return avg/ allatok.Length;
        }

        public string LegmagasabbKoltseg(int ora)
        {
            int max = 0;
            for (int i = 1; i < allatok.Length; i++)
            {
                if (allatok[i].GondozasiKoltseg(ora) > allatok[max].GondozasiKoltseg(ora))
                {
                    max = i; 
                }
            }
            return $"Legdrágább: {allatok[max].Id} - {allatok[max].Nev} ({allatok[max].Faj}), {allatok[max].Eletkor} kor, óradíj: {allatok[max].Oradij}, ételigény: {allatok[max].Eteligeny}g";
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
            return $"Legalacsonyabb ételigény: {allatok[min].Id} - {allatok[min].Nev} ({allatok[min].Faj}), {allatok[min].Eletkor} kor, óradíj: {allatok[min].Oradij}, ételigény: {allatok[min].Eteligeny}g";
        }

        public string KeresNevAlapjan(string nev)
        {
            Allat[] lista;
            lista = new Allat[allatok.Length];
            int i = 0;
            bool van = false;
            foreach (var item in allatok)
            {
                if (item.Nev.ToLower().Contains(nev))
                {
                    lista[i] = item;
                    van = true;
                    i++;
                }
            }
            if (van)
            {
                foreach (var item in lista)
                {
                    return $" {item.Id} - {item.Nev} ({item.Faj}), {item.Eletkor} kor, óradíj: {item.Oradij}, ételigény: {item.Eteligeny}g";
                }
            }
           
            return "Nincs találat!";
        }

        public void FajSzerint(string faj)
        {
            foreach (var a in allatok)
            {
                if (a.Faj.ToLower() == faj.ToLower())
                {
                    Console.WriteLine(a);
                }
            }
        }

        public void UjAllatHozzaadasa(Allat uj)
        {
            Allat[] ujtmb = new Allat[allatok.Length +1];
            for (int i = 0; i < allatok.Length; i++)
            {
                ujtmb[i] = allatok[i];
            }

            ujtmb[ujtmb.Length -1 ] = uj;

            allatok = ujtmb;
        }

        public string Mentes(string fileNev)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileNev))
                {
                    foreach (var a in allatok)
                    {
                        sw.WriteLine($"{a.Id};{a.Faj};{a.Nev};{a.Eletkor};{a.Oradij};{a.Eteligeny}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt a mentés során: " + ex.Message);
            }


            return "";
        }
    }
}
