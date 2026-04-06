using System.Diagnostics.Tracing;

namespace prog5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menhely menhelyek = new();
            menhelyek.Beolvas();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("- - - Állatmenhely Menü - - -");
                Console.WriteLine("1. Állatok listázása");
                Console.WriteLine("2. Átlagéletkor");
                Console.WriteLine("3. Legmagasabb gondozási költség");
                Console.WriteLine("4. Legalacsonyabb ételigény");
                Console.WriteLine("5. Keresés névrészlet alapján");
                Console.WriteLine("6. Szűrés faj szerint");
                Console.WriteLine("7. Új állat felvétele");
                Console.WriteLine("8. Mentés fileba");
                Console.WriteLine("9. Kilépés");
                Console.Write("Válasz: ");
                int valasz = int.Parse(Console.ReadLine());
                int ora = 0;
                string nev, faj = string.Empty;
                switch (valasz)
                {
                    case 1:
                        menhelyek.Listaz();
                        Console.ReadKey();

                        break;
                
                    case 2:
                        Console.WriteLine($"Átlagéletkor:{menhelyek.AtlagEletkor()}" );
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Hány órát számoljunk? ");
                        ora = int.Parse(Console.ReadLine());
                        Console.WriteLine(menhelyek.LegmagasabbKoltseg(ora));
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine(menhelyek.LegalacsonyabbEteligeny());
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("Névrészlet: ");
                        nev = Console.ReadLine();

                        Console.WriteLine(menhelyek.KeresNevAlapjan(nev));
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("Faj: ");
                        string f = Console.ReadLine();
                        menhelyek.FajSzerint(f);

                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Write("faj: ");
                        faj = Console.ReadLine();

                        Console.Write("név: ");
                        nev = Console.ReadLine();

                        Console.Write("életkor: ");
                        int eletkor = int.Parse(Console.ReadLine());
                        Console.Write("oradíj: ");
                        int oradij = int.Parse(Console.ReadLine());
                        Console.Write("ételigény: ");
                        int eteligeny = int.Parse(Console.ReadLine());
                        Random rnd = new();
                        int id = rnd.Next(100, 1000);
                        Allat uj = new Allat(id, faj, nev, eletkor, oradij, eteligeny);
                        
                        menhelyek.UjAllatHozzaadasa(uj);

                        Console.WriteLine("Állat hozzáadva!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
