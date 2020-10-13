using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserExceptions">constructor not found
        /// or
        /// class not found</exception>

        public static Object CreateMoodAnalyserObject(string className, string constructor , string message)
        {
            //getting the type of class MoodAnalyse
            Type type = typeof(MoodAnalyse);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor passed is correct
                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type, message);
                }
                //If the constructor passed doesnt exist then throw error
                else
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            //If the class passed doesnt exist throw custom exception
            else
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }
        }

        public static Object InvokeMethod(string className, string constuctor, string message, string methodName)
        {
            object mood = CreateMoodAnalyserObject(className, constuctor, message);
            Type type = typeof(MoodAnalyse);
            try
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                Object obj = methodInfo.Invoke(mood, null);
                return obj;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }
    }
}
