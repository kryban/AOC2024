using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

Part1(input);
Part2(input); 

void Part1(string s)
{
    int antwoord = FilterMulEnVoegToeAanAntwoord(s);
    
    Console.WriteLine("Day 3 - Part1: {0}", antwoord.ToString()); //167090022
}

void Part2(string s)
{
    int antwoord = 0;
    var doOrDont = @"(don't\(\)|do\(\))";
    
    List<string> doList = [];
    bool naarDoList = true;
    
    var splittedSubs = Regex.Split(s, doOrDont);
    
    foreach (var sub in splittedSubs)
    {
        DoOrNotDo(sub, ref naarDoList);
        
        //deze blijft net zo lang staan totdat tegendeel bewezen is in DoOrNotDo
        if (naarDoList)
        { 
            doList.Add(sub);
        }
    }

    foreach (var substr in doList)
    {
        antwoord += FilterMulEnVoegToeAanAntwoord(substr);
    }
    
    Console.WriteLine("Day 3 - Part2: {0}", antwoord.ToString()); //89823704
}

static int FilterMulEnVoegToeAanAntwoord(string s)
{
    int retval = 0;
    var mulSelectie = @"mul\(\b\d{1,3}\b,\b\d{1,3}\b\)";
    var getallenSelectie = @"\b\d{1,3}\b,\b\d{1,3}\b";

    MatchCollection matches = Regex.Matches(s, mulSelectie);

    matches.Select(match => match.Value).ToList().ForEach((value) =>
    {
        VoegToeAanAntwoord(value, ref retval);
    });

    void VoegToeAanAntwoord(string value, ref int antw)
    {
        var getallen = Regex.Match(value, getallenSelectie)
            .Value
            .Split(",");
    
        var getal = int.Parse(getallen[0]) * int.Parse(getallen[1]);

        antw += getal;
    }

    return retval;
}

static void DoOrNotDo(string input, ref bool naarDoList)
{
    if(input.Contains(@"do()"))
        naarDoList = true;
    
    if(input.Contains(@"don't()"))
        naarDoList = false;
}
