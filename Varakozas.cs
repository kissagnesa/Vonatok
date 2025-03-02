using System;
using System.Collections.Generic;
using System.Linq;

public class Varakozas
{
    public string Vonal { get; set; }
    public string Allomas { get; set; }
    public string ErkezoIrany { get; set; }
    public string InduloIrany { get; set; }
    public int MaxKeses { get; set; }

    public Varakozas(string vonal, string allomas, string erkezoIrany, string induloIrany, int maxKeses)
    {
        Vonal = vonal;
        Allomas = allomas;
        ErkezoIrany = erkezoIrany;
        InduloIrany = induloIrany;
        MaxKeses = maxKeses;
    }

    public Varakozas(string sor)
    {
        string[] adatok = sor.Split('\t');
        Vonal = adatok[0];
        Allomas = adatok[1];
        ErkezoIrany = adatok[2];
        InduloIrany = adatok[3];
        MaxKeses = int.Parse(adatok[4]);
    }

    public override string ToString()
    {
        return $"{Vonal} - {Allomas} - Érkező: {ErkezoIrany} - Induló: {InduloIrany} - Max késés: {MaxKeses} perc";
    }

    public bool VarakozikE(string erkezo)
    {
        if (ErkezoIrany == "Összes")
        {
            return true;
        }
        string[] erkezoAllomasok = ErkezoIrany.Split(',');
        return erkezoAllomasok.Contains(erkezo);
    }
}