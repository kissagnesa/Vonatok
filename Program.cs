using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Vonatok
{
    public static void Main(string[] args)
    {
        List<Varakozas> varakozasok = BeolvasVarakozasok("varakozas.txt");

        // 1. feladat
        Console.WriteLine("1. feladat: Várakozások beolvasása");
        foreach (Varakozas varakozas in varakozasok)
        {
            Console.WriteLine(varakozas);
        }

        // 2. feladat
        Console.WriteLine("\n2. feladat: Várakozások száma: " + varakozasok.Count);

        // 3. feladat
        Console.WriteLine("\n3. feladat: Kérek egy vonalszámot: ");
        string vonal = Console.ReadLine();
        List<Varakozas> adottVonalVarakozasok = varakozasok.FindAll(v => v.Vonal == vonal);
        if (adottVonalVarakozasok.Count > 0)
        {
            Console.WriteLine("Várakozások a(z) " + vonal + " vonalon:");
            foreach (Varakozas varakozas in adottVonalVarakozasok)
            {
                Console.WriteLine(varakozas);
            }
        }
        else
        {
            Console.WriteLine("Nincs várakozás ezen a vonalon.");
        }

        // 4. feladat
        Console.WriteLine("\n4. feladat: Esztergom felől érkező vonatokra várakozó állomások:");
        var esztergomVarakozasok = varakozasok.FindAll(v => v.VarakozikE("Esztergom"));
        if (esztergomVarakozasok.Count > 0)
        {
            foreach (Varakozas varakozas in esztergomVarakozasok)
            {
                Console.WriteLine(varakozas.Allomas);
            }
        }
        else
        {
            Console.WriteLine("Nincs ilyen állomás.");
        }

        Console.ReadKey();
    }

    public static List<Varakozas> BeolvasVarakozasok(string fajlnev)
    {
        List<Varakozas> varakozasok = new List<Varakozas>();
        try
        {
            string[] sorok = File.ReadAllLines(fajlnev);
            for (int i = 1; i < sorok.Length; i++) // Az első sor a fejléc
            {
                varakozasok.Add(new Varakozas(sorok[i]));
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("A 'varakozas.txt' fájl nem található.");
        }
        return varakozasok;
    }
}