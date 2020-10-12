using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Mood Analyser");
            //Ask the user to enter his mood
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();
            //Call AnalyseMood method to check for mood
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string mood = moodAnalyse.AnalyseMood();
            //Creating MoodAnalyser object at run time
            MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyse" , "MoodAnalyse" );
        }
    }
}
