using prog5;

string file = "allatok.txt";
Menhely menhely = new();
menhely.Beolvas(file);

bool ciklus = true;

while (ciklus)
{
    Console.WriteLine("- - - Állatmenhely Menü - - -");
    Console.WriteLine("1. Állatok listázása");
    Console.WriteLine("2. Átlagéletkor");
    Console.WriteLine("3. Legmagasabb gondozási költség");
    Console.WriteLine("4. Legalacsonyabb ételigény");
    Console.WriteLine("5. Keresés névrészlet alapján");
    Console.WriteLine("6. Szűrés faj szerint");
    Console.WriteLine("7. Új állat felvétele");
    Console.WriteLine("8. Mentés fileba");
    Console.WriteLine("9. kilépés");
    Console.Write("válasz: ");

    int valasz = int.Parse(Console.ReadLine());
    string nev = string.Empty;
    switch (valasz)
    {
        case 1:
            menhely.Listaz();
            Console.WriteLine("\n");
            break;
        case 2:
            Console.WriteLine(menhely.AtlagEletkor() + "\n");
            break;

        case 3:
            Console.WriteLine($"{menhely.LegmagasabbKoltseg()}\n");
            break;
        case 4:
            Console.WriteLine($"{menhely.LegalacsonyabbEteligeny()}\n");
            break;

        case 5:
            Console.WriteLine("\nadjon meg egy nevet:");
            nev = Console.ReadLine();
            menhely.KeresNevAlapjan(nev);
            break;
         case 6:
            break;


        case 9:
            ciklus = false;
            break;
        default:
            break;
    }
}