using System.Text.RegularExpressions;

namespace Day01;

class Program
{
    static void Main(string[] args)
    {
        //read input
        string input = System.IO.File.ReadAllText("input.txt");
        List<int> inputList = input.Split(",").ToList().Select(int.Parse).ToList();
        int answer = 0;
        int index = 0;
        List<int> right = inputList.Where((item, index) => index % 2 != 0).Order().ToList();
        List<int> left = inputList.Where((item, index) => index % 2 == 0).Order().ToList();
        
        foreach (int leftitem in left)
        {
             answer = answer + Math.Abs(leftitem - right[index++]);;
        }
        
        Console.WriteLine(answer); //1590491
    }
}