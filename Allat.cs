using System;
using System.Collections.Generic;
using System.Text;

namespace prog5
{
    internal class Allat
    {
        public int ID;
        public string Faj;
        public string Nev;
        public int Eletkor;
        public int Oradij;
        public int Eteligeny;

        public Allat(int ID, string faj, string nev, int eletkor, int oradij, int eteligeny)
        {
            this.ID = ID;
            this.Faj = faj;
            this.Nev = nev;
            this.Eletkor = eletkor;
            this.Oradij = oradij;
            this.Eteligeny = eteligeny;
        }
        public double GondozasiKoltseg(int ora)
        {
         
            if (Eletkor > 10)
            {
                return Oradij* ora* 1.2;
            }
            

            return Oradij* ora ;
        }

        public double NapiEtel()
        {
            return Eteligeny / 1000.0;
        }
    }
}
