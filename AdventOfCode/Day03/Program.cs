using System.Text.RegularExpressions;

string input = File.ReadAllText("voorbeeldPart2.txt");

List<string> dos = [];
List<string> donts = [];

Part1(input);
Part2(input); 

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

    Console.WriteLine("Day 3 - Part1: {0}", antwoord.ToString()); //167090022
}

void Part2(string s)
{
    
    //(?<=don't\(\)).*
    //xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))dddddon't())))))
    int antwoord = 0;
    var mulSelectie = @"mul\(\b\d{1,3}\b,\b\d{1,3}\b\)";
    var getallenSelectie = @"\b\d{1,3}\b,\b\d{1,3}\b";
    var doOrDont = @"don't\(\)|do\(\)";
    
    var doList = s.Split("do()");
    
    Console.WriteLine("Day 3 - Part2: {0}", antwoord.ToString()); //
}

