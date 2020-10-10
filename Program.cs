using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Mood Analyser");
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
        }
    }
}
