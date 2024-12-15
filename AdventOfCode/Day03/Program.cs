using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

Part1(input);

void Part1(string s)
{
    int antwoord = 0;
    var mulSelectie = @"mul\(\b\d{1,3}\b,\b\d{1,3}\b\)";
    var getallenSelectie = @"\b\d{1,3}\b,\b\d{1,3}\b";

    MatchCollection matches = Regex.Matches(s, mulSelectie);

    matches.Select(match => match.Value).ToList().ForEach((value) =>
    {
        VoegToeAanAntwoord(value, ref antwoord);
    });

    void VoegToeAanAntwoord(string value, ref int antw)
    {
        var getallen = Regex.Match(value, getallenSelectie)
            .Value
            .Split(",");
    
        var getal = int.Parse(getallen[0]) * int.Parse(getallen[1]);

        antw += getal;
    }

    Console.WriteLine("Day 1 - Part1: {0}", antwoord.ToString()); //167090022
}