using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood(string message)
        {
            logger.Debug("User entered the analyse mood method");
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
    }
}
