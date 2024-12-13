// See https://aka.ms/new-console-template for more information

using System.Data.Common;
using System.Net;

var input = File.ReadAllLines("input.txt");

Part1(input);
Part2(input);

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

void Part2(string[] args)
{
    var antwoord = 0;
    foreach (var line in args)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToList();
        int i = 0;
        
        bool isSafe = false;

        isSafe = IsSafe(numbers);

        while (!isSafe && i < numbers.Count)
        {
            List<int> gecorrigeerdeNummers = [];
            gecorrigeerdeNummers.AddRange(numbers.Where((element, index) => index != i));
            isSafe = IsSafe(gecorrigeerdeNummers);
            i++;
        }

        antwoord = isSafe ? antwoord+1 : antwoord;
    }
    Console.WriteLine("Day 2 - Part 2: {0}", antwoord); //318
}

bool IsSafe(List<int> numbers)
{
    int volgende = 0;
    var mustIncrease = false; 
    bool retval = true;
    
    foreach (var huidige in numbers)
    {
        int i = numbers.IndexOf(huidige);
        int volgendIndex = i+1;
            
        if(volgendIndex > numbers.Count-1 || !retval)
            continue;
            
        volgende = numbers[volgendIndex];
            
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
            if (huidige - volgende > 0 && huidige - volgende < 4)
            {
                continue;
            }
        }
        
        retval = false;
    }
    return retval;
}

