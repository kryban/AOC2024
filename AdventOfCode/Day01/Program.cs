using System.Text.RegularExpressions;

namespace Day01;

class Program
{
    static void Main(string[] args)
    {
        //read input
        string input = System.IO.File.ReadAllText("input.txt");
        List<int> inputList = input.Split(",").ToList().Select(int.Parse).ToList();
        
        List<int> right = inputList.Where((item, index) => index % 2 != 0).Order().ToList();
        List<int> left = inputList.Where((item, index) => index % 2 == 0).Order().ToList();

        PartOne(left, right);
        PartTwo(left, right);
    }

    private static void PartOne(List<int> left, List<int> right)
    {
        int answer = 0;
        int i = 0;
        
        foreach (int leftitem in left)
        {
            //calculate difference and add to answer
            answer = answer + Math.Abs(leftitem - right[i++]);;
        }
        
        Console.WriteLine("Day1 - Part1: {0}",answer); //1590491
    }
    
    private static void PartTwo(List<int> left, List<int> right)
    {
        int answer = 0;
        
        foreach (int leftitem in left)
        {
            //calculate difference and add to answer
            answer = answer + (leftitem * right.Count(x => x == leftitem));
        }
        
        Console.WriteLine("Day1 - Part2: {0}",answer); //22588371
    }
}