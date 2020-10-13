using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public string message=" ";

        public MoodAnalyse()
        {
            Console.WriteLine("Default constructor");
        }
        public MoodAnalyse(string message)
        {
            logger.Info("Initiated message through a contructor");
            this.message = message;
        }
        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try
            {
                logger.Debug("User entered the analyse mood method");
                //If input is empty then throw exception of empty type
                if (message == string.Empty)
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.EMPTY_TYPE, "Mood cannot be empty");
                if (message.ToLower().Contains("sad"))
                {
                    logger.Info("User mood is sad");
                    return "sad mood";
                }

                else 
                {
                    logger.Info("User mood is happy");
                    return "happy mood";
                }
            }
            //If input is null then throw exception of null type
            catch (NullReferenceException)
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NULL_TYPE, "Null mood not accepted");
            }
        }
    }
}
