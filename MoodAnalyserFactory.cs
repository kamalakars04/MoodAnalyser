using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserExceptions">
        /// constructor not found
        /// or
        /// class not found
        /// </exception>
        public static Object CreateMoodAnalyserObject(string className, string constructor)
        {
            //getting the type of class MoodAnalyse
            Type type = typeof(MoodAnalyse);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor passed is correct
                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type);
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
    }
}
