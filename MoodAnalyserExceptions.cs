using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserExceptions : Exception
    {
        public enum ExceptionType
        {
            NULL_TYPE,EMPTY_TYPE
        }

        ExceptionType type;
        public MoodAnalyserExceptions(ExceptionType type, string message) : base(String.Format("MoodAnalyser exception : {0}", message))
        {
            this.type = type;
        }
    }
}
