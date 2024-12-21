var input = File.ReadLines("input.txt").ToList();
string vooruit = "XMAS";
string achteruit = "SAMX";

Part1(input); //2603
Part2(input); //1965

void Part1(List<string> inp)
{
    var antwoord = 0;
    var huidigeRij = 0;

    foreach (var line in inp)
    {
        antwoord += VindHorizontaal(line, vooruit, huidigeRij);
        antwoord += VindHorizontaal(line, achteruit, huidigeRij);
        antwoord += VindVerticaal(line, inp, huidigeRij, vooruit);
        antwoord += VindVerticaal(line, inp, huidigeRij, achteruit);
        antwoord += VindDiagonaalRechts(line, inp, huidigeRij, vooruit);
        antwoord += VindDiagonaalRechts(line, inp, huidigeRij, achteruit);
        antwoord += VindDiagonaalLinks(line, inp, huidigeRij, vooruit);
        antwoord += VindDiagonaalLinks(line, inp, huidigeRij, achteruit);

        huidigeRij++;
    }

    Console.WriteLine($"Day 4 - Part 1: {antwoord}"); //2603

    int VindHorizontaal(string line, string zoekwoord, int huidigeRij)
    {
        int startpositie = 0;
        int matchAantal = 0;
        int retval = 0;


        while ((startpositie + zoekwoord.Length) <= line.Length)
        {
            matchAantal = MatchesHorizontaal(line, zoekwoord, startpositie);

            retval += matchAantal == zoekwoord.Length ? 1 : 0;
            startpositie++;
        }

        return retval;
    }

    int MatchesHorizontaal(string zoeklijn, string zoekwoord, int startpositie)
    {
        int zoekpositie = startpositie;
        var retval = 0;

        foreach (var character in zoekwoord)
        {
            char charInFocusVoorVergelijking = zoeklijn[zoekpositie];

            if (charInFocusVoorVergelijking.Equals(character))
            {
                retval++;
            }

            zoekpositie++;
        }

        return retval;
    }

    int VindVerticaal(string s, List<string> lijstMetInputRegels, int huidigeRij, string zoekwoord)
    {
        int startpositie = 0;
        int matchAantal = 0;
        int retval = 0;

        while (startpositie < s.Length && (huidigeRij + zoekwoord.Length <= lijstMetInputRegels.Count))
        {
            matchAantal = AantalMatchesVanZoekwoordVerticaal(huidigeRij, zoekwoord, lijstMetInputRegels, startpositie);

            retval += matchAantal == zoekwoord.Length ? 1 : 0;
            startpositie++;
        }

        return retval;
    }

    int VindDiagonaalRechts(string inputRegel, List<string> lijstMetInputRegels, int huidigeRij, string zoekwoord)
    {
        int startpositie = 0;
        int matchAantal = 0;
        int retval = 0;
        int zoekrichtingRechts = 1;

        bool ZoekwoordPastHorizontaalRechts()
        {
            return (startpositie + zoekwoord.Length) <= inputRegel.Length;
        }

        bool ZoekwoordPastVerticaal()
        {
            return huidigeRij + zoekwoord.Length <= lijstMetInputRegels.Count;
        }

        bool ZoekwoordPastGeheelInInputRegels()
        {
            return ZoekwoordPastHorizontaalRechts() && ZoekwoordPastVerticaal();
        }

        while (ZoekwoordPastGeheelInInputRegels())
        {
            matchAantal = AantalMatchesVanZoekwoordDiagonaal(huidigeRij, zoekwoord, lijstMetInputRegels, startpositie,
                zoekrichtingRechts);

            retval += matchAantal == zoekwoord.Length ? 1 : 0;
            startpositie++;
        }

        return retval;
    }

    int VindDiagonaalLinks(string inputRegel, List<string> lijstMetInputRegels, int huidigeRij, string zoekwoord)
    {
        int startpositie = 0;
        int matchAantal = 0;
        int retval = 0;
        int zoekrichtingRechts = -1;

        bool ZoekwoordPastHorizontaalLinks()
        {
            return (startpositie - (zoekwoord.Length - 1)) >= 0;
        }

        bool ZoekwoordPastVerticaal()
        {
            return huidigeRij + zoekwoord.Length <= lijstMetInputRegels.Count;
        }

        bool ZoekwoordPastGeheelInInputRegels()
        {
            return ZoekwoordPastHorizontaalLinks() && ZoekwoordPastVerticaal();
        }

        while (startpositie < inputRegel.Length && ZoekwoordPastVerticaal())
        {
            if (!ZoekwoordPastHorizontaalLinks())
            {
                startpositie++;
                continue;
            }

            matchAantal = AantalMatchesVanZoekwoordDiagonaal(huidigeRij, zoekwoord, lijstMetInputRegels, startpositie,
                zoekrichtingRechts);

            retval += matchAantal == zoekwoord.Length ? 1 : 0;
            startpositie++;
        }

        return retval;
    }

    int AantalMatchesVanZoekwoordDiagonaal(int huidigeRij, string zoekwoord, List<string> lijstMetInputRegels,
        int startpositie, int zoekrichting)
    {
        int zoekrij = huidigeRij;
        return ZoekCharacterMatchInOnderliggendRij(zoekwoord, lijstMetInputRegels, zoekrij, startpositie, zoekrichting);
    }

    int AantalMatchesVanZoekwoordVerticaal(int huidigeRij, string zoekwoord, List<string> lijstMetInputRegels,
        int startpositie)
    {
        int zoekrij = huidigeRij;
        return ZoekCharacterMatchInOnderliggendRij(zoekwoord, lijstMetInputRegels, zoekrij, startpositie, 0);
    }

    int ZoekCharacterMatchInOnderliggendRij(string s, List<string> lijstMetInputregels, int zoekrij, int startpositie,
        int diagonaleAfwijking)
    {
        int zoekpositie = startpositie;
        int matchAantal = 0;
        foreach (var character in s)
        {
            char charInFocusVoorVergelijking = lijstMetInputregels[zoekrij][zoekpositie];

            if (charInFocusVoorVergelijking.Equals(character))
            {
                matchAantal++;
            }

            zoekrij++;
            zoekpositie += diagonaleAfwijking;
            
        }

        return matchAantal;
    }
}

void Part2(List<string> lijstMetInput)
{
    int antwoord = 0;

    foreach (var rij in lijstMetInput)
    {
        for (int i = 0; i < rij.Length; i++)
        {
            if (rij[i].Equals('A'))
            {
                if (SurroundingsOK(lijstMetInput.IndexOf(rij), i, lijstMetInput))
                {
                    antwoord++;
                }
            }
        }
    }
    
    Console.WriteLine($"Day 4 - Part 2: {antwoord}"); //1965

    bool SurroundingsOK(int huidigeRij, int huidigeIndex, List<string> inp )
    {
        bool retval;

        char? linksBoven = GeefChar(huidigeRij - 1, huidigeIndex - 1, inp);
        char? rechtsOnder = GeefChar(huidigeRij + 1, huidigeIndex + 1, inp);
        
        char? rechtsBoven = GeefChar(huidigeRij - 1, huidigeIndex + 1, inp);
        char? linksOnder = GeefChar(huidigeRij + 1, huidigeIndex - 1, inp);
        
        if(linksBoven == null || rechtsOnder == null || rechtsBoven == null || linksOnder == null)
        {
            retval = false;
        }
        else
        {
            retval = (linksBoven.Equals('M') && rechtsOnder.Equals('S') ||linksBoven.Equals('S') && rechtsOnder.Equals('M') ) 
                     && (rechtsBoven.Equals('M') && linksOnder.Equals('S') ||rechtsBoven.Equals('S') && linksOnder.Equals('M') );
        }
        
        return retval;
    }
    
    char? GeefChar(int beoogdeRij, int beoogdeIndex, List<string> inputList)
    {
        if(beoogdeRij < 0 
           || beoogdeRij > inputList.Count - 1 
           || beoogdeIndex < 0 
           || beoogdeIndex > inputList[beoogdeRij].Length - 1)
        {
            return null;
        }
        
        return inputList[beoogdeRij][beoogdeIndex];
    }
}
