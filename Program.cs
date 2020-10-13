namespace MoodAnalyser
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Mood Analyser");

            // Ask the user to enter his mood
            Console.WriteLine("Enter the state of mood");
            string message = Console.ReadLine();

            // Call AnalyseMood method to check for mood
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string mood = moodAnalyse.AnalyseMood();

            // Creating parameterless MoodAnalyser object at run time
            MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyse", "MoodAnalyse", null);

            // Creating parameterized MoodAnalyser object at run time
            MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyse", "MoodAnalyse", "Happy");

            // Invoking Method using reflections
            MoodAnalyserReflector.InvokeMethod("Happy", "AnalyseMood");

            // Giving the message using field in reflection dynamically
            MoodAnalyserReflector.ChangeMoodDynamically("Sad", "message");
        }
    }
}
