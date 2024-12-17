// See https://aka.ms/new-console-template for more information

var input = File.ReadLines("voorbeeld.txt").ToList();

Part1(input);

void Part1(List<string> inp)
{
    var antwoord = 0;
    var huidigeRij = 0;

    foreach (var line in inp)
    {
        antwoord += VindHorizontaalVooruit(line);
        antwoord += VindHorizontaalAchteruit(line);
        antwoord += VindVerticaalVooruit(line, inp, huidigeRij);
    }
    
    Console.WriteLine($"Day 4 - Part 1: {antwoord}");
}


int VindHorizontaalVooruit(string s)
{
    return (s.Contains("XMAS")) ? 1 : 0;
}

int VindHorizontaalAchteruit(string s)
{
    return (s.Contains("SAMX")) ? 1 : 0;
}

int VindVerticaalVooruit(string s, List<string> lijst, int huidigeRij)
{
    string zoekwoord = "XMAS";
    int zoekrij = huidigeRij;
    int startpositie = 0;
    int matchAantal = 0;
    int retval = 0;

    // horizontaal niet verder zoeken dat een rij lang is
    // verticaal niet verder zoeken dat de laatste letter op de laatste rij
    while (startpositie < s.Length && (huidigeRij+zoekwoord.Length < lijst.Count))
    {
        zoekrij = huidigeRij;
        matchAantal = 0;
        
        foreach (var character in zoekwoord)
        {
            char charInFocus = lijst[zoekrij][startpositie];
            
            if(charInFocus.Equals(character))
            {
                matchAantal++;
            }
            
            zoekrij++;
        }   
        
        retval += matchAantal == zoekwoord.Length ? 1 : 0;
        startpositie++;
    }

    return retval;
}