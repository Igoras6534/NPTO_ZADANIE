using System;
using Zadanie_5;
using kartoteka.impl;
using System.Collections.Generic;


namespace kartoteka.Mockup
{
    public class Kartoteka : IKartoteka
    {
        public void Dodaj(Osoba osoba)
        {
        }

        public void Usun(Osoba osoba)
        {
        }

        public int Rozmiar()
        {
            return 1;
        }
        public bool CzyZawiera(Osoba osoba)
        {
            return true;
        }

        public Osoba Pobierz(int index)
        {
            return new Osoba("Gall", "Anonim");
        }


    }


}



namespace kartoteka.impl
{
    public class Kartoteka : IKartoteka
    {
        private List<Osoba> osoby;

        public Kartoteka()
        {
            osoby = new List<Osoba>();
        }
        public void Dodaj(Osoba osoba)
        {
            osoby.Add(osoba);
        }

        public void Usun(Osoba osoba)
        {
            if (CzyZawiera(osoba))
            {
                osoby.Remove(osoba);
            }
            else
            {
                Console.WriteLine("Nie ma takiej osoby w kartotece");
            }
        }

        public int Rozmiar()
        {
            return osoby.Count;
        }
        public bool CzyZawiera(Osoba osoba)
        {
            return osoby.Contains(osoba);
        }

        public Osoba Pobierz(int index)
        {
            if (index < 0 || index >= osoby.Count)
            {
                Console.WriteLine("Nieprawidłowy Index");
                return null;
            }
            return osoby[index];
        }   
    }
}



namespace Zadanie_5
{
    public interface IKartoteka
    {
        void Dodaj(Osoba o);
        void Usun(Osoba o);
        int Rozmiar();
        bool CzyZawiera(Osoba o);
        Osoba Pobierz(int index);
    }
    public class Osoba
    {
        private string _imie;
        private string _nazwisko;

        public string Imie
        {
            get { return _imie; }
            set { _imie = value; }
        }
        public string Nazwisko
        {
            get { return _nazwisko; }
            set { _nazwisko = value; }
        }

        public Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Kartoteka kartoteka= new Kartoteka();

            Osoba osoba1 = new Osoba("Jan", "Kowalski");
            Osoba osoba2 = new Osoba("Ignacy", "Nowak");
            Osoba osoba3 = new Osoba("Daniel", "Zbir");
            Osoba osoba4 = new Osoba("Anna", "Nowa");


            kartoteka.Dodaj(osoba1);
            kartoteka.Dodaj(osoba2);
            kartoteka.Dodaj(osoba3);
            kartoteka.Dodaj(osoba4);

            Console.WriteLine("Rozmiar: "+kartoteka.Rozmiar());
            Console.WriteLine();

            kartoteka.Usun(osoba3);
            kartoteka.Usun(new Osoba("Nie","Istnieje"));
            Console.WriteLine("Rozmiar (po usunieciu): " + kartoteka.Rozmiar());
            Console.WriteLine();


            Console.WriteLine("Czy zawiera osoba1: "+kartoteka.CzyZawiera(osoba1));
            Console.WriteLine("Czy zawiera osoba3: "+kartoteka.CzyZawiera(osoba3));
            Console.WriteLine();



            Console.WriteLine("Osoba na pozycji 2: "+kartoteka.Pobierz(1).Imie+" "+kartoteka.Pobierz(1).Nazwisko);
            Console.WriteLine("Osoba na pozycji 3: "+kartoteka.Pobierz(2).Imie+" "+kartoteka.Pobierz(2).Nazwisko);

            Osoba osoba100 = kartoteka.Pobierz(100);


            Console.ReadKey();
        }
    }
}
