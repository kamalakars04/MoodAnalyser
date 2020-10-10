using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyse moodAnalyse = new MoodAnalyse();
            Console.WriteLine("Welcom to Mood Analyser");
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();
            moodAnalyse.AnalyseMood(message);
        }
    }
}
