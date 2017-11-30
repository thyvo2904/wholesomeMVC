using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Index
/// </summary>
public class Index
{
    private double protein { get; set; }
    private double fiber { get; set; }
    private double vitaminD { get; set; }
    private double potassium { get; set; }
    private double calcium { get; set; }
    private double iron { get; set; }
    private double kCal { get; set; }
    private double satFat { get; set; }
    private double addedSugar { get; set; }
    private double sodium { get; set; }

    private double nR6 { get; set; }
    private double liMT { get; set; }
    private double NRF6 { get; set; }

    public Index(double protein, double fiber, double vitaminD,
        double potassium, double calcium, double iron, double kCal, double satFat,
        double addedSugar, double sodium)
    {
        this.protein = protein;
        this.fiber = fiber;
        this.vitaminD = vitaminD;
        this.potassium = potassium;
        this.calcium = calcium;
        this.iron = iron;
        this.kCal = kCal;
        this.satFat = satFat;
        this.addedSugar = addedSugar;
        this.sodium = sodium;
    }
}
