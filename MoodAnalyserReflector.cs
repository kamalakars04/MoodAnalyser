namespace MoodAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns>Object of class</returns>
        /// <exception cref="MoodAnalyserExceptions">constructor not found
        /// or
        /// class not found</exception>
        public static Object CreateMoodAnalyserObject(string className, string constructor, string message)
        {
            // getting the type of class MoodAnalyse
            Type type = typeof(MoodAnalyse);

            // If the class name exists in given assembly 
            // else throw exception
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                // If the constructor passed is correct then create object
                // Else throw error
                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type, message);
                }
                else
                {
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
                }
            }
            else
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }
        }

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>The object returned by method</returns>
        /// <exception cref="MoodAnalyserExceptions">No such method found</exception>
        public static Object InvokeMethod(string message, string methodName)
        {
            // Get the type of class
            Type type = typeof(MoodAnalyse);
            object mood = Activator.CreateInstance(type, message);

            // Try to get the method and if doesnt exist then throw exception
            // If exception is thrown then catch exception
            try
            {
                // Get the method info using reflection
                MethodInfo methodInfo = type.GetMethod(methodName);

                // Invoke the method using reflection
                object obj = methodInfo.Invoke(mood, null);
                return obj;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        /// <summary>
        /// Changes the field of mood dynamically.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>The object returned by method</returns>
        /// <exception cref="MoodAnalyserExceptions">
        /// No such field found
        /// or
        /// Mood cannot be empty
        /// </exception>
        public static Object ChangeMoodDynamically(string message, string fieldName)
        {
            // Get the type of the class
            Type type = typeof(MoodAnalyse);

            // Create an object of class
            object mood = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            // catch the exception if thrown
            try
            {
                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);
                
                // set the field value of a particular field in particular object
                fieldInfo.SetValue(mood, message);
                
                // Get the method using reflection
                MethodInfo method = type.GetMethod("AnalyseMood");

                // Invoke the method using reflection
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_FIELD, "No such field found");
            }
            catch
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NULL_TYPE, "Null mood not accepted");
            }
        }
    }
}
