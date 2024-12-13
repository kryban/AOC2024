// See https://aka.ms/new-console-template for more information
using System.Net;

var input = File.ReadAllLines("input.txt");

Part1(input);

void Part1(string[] args)
{
    var antwoord = 0;
    var mustIncrease = false; 
    foreach (var line in args)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToList();
        bool foutAangetroffen = false;

        foreach (var huidige in numbers)
        {
            int i = numbers.IndexOf(huidige);
            int volgendIndex = i+1;
            
            if(volgendIndex > numbers.Count-1 || foutAangetroffen)
                continue;
            
            int volgende = numbers[volgendIndex];
            
            mustIncrease = i == 0 ? huidige < volgende : mustIncrease;

            if (mustIncrease)
            {
                if (volgende - huidige > 0 && volgende - huidige < 4)
                {
                    continue;
                }
            }
            else
            {
                if (huidige - volgende > 0 && huidige - volgende  < 4)
                {
                    continue;
                }
            }
            foutAangetroffen = true;
        }

        antwoord = foutAangetroffen ? antwoord : antwoord+1;
    }
    Console.WriteLine("Day 2 - Part 1: {0}", antwoord); //246
}