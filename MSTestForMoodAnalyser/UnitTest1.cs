namespace MSTestForMoodAnalyser
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MoodAnalyser;

    [TestClass]
    public class UnitTest1
    {
        // Object of MoodAnalyse
        MoodAnalyse moodAnalyse;

        /// <summary>
        /// TC 1.1 Tests the analyse mood method by giving sad and expecting sad
        /// </summary>
        /// <param name="message">Passes message The message.</param>
        [DataRow("Iam in sad mood")]
        [TestMethod, TestCategory("sad mood"), TestCategory("TC 1")]
        public void GiveSadAndGetSad(string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);

            // Act
            var actual = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual("sad mood", actual);
        }

        /// <summary>
        /// TC 1.2 doesnt give sad and get happy.
        /// </summary>
        /// <param name="message">Passes message The message.</param>
        [DataRow("Iam in happy mood")]
        [TestMethod, TestCategory("Happy mood"), TestCategory("TC 1")]
        public void GiveHappyAndGetHappy(string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);
             
            // Act
            var actual = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual("happy mood", actual);
        }

        /// <summary>
        /// TC 3.1 when Gives null then get exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow(null)]
        [TestMethod, TestCategory("CustomException"), TestCategory("TC 3")]
        public void GiveNullAndGetExceptionMessage(string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);
            try
            {
                // Act
                var actual = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : Null mood not accepted", e.Message);
            }
        }

        /// <summary>
        /// TC 3.2 When Gives empty then gets exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow("")]
        [TestMethod, TestCategory("CustomException"), TestCategory("TC 3")]
        public void GiveEmptyAndGetExceptionMessage(string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);
            try
            {
                // Act
                var actual = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : Mood cannot be empty", e.Message);
            }
        }

        /// <summary>
        /// TC 4.1 Given MoodAnalyser Class Name then Should Return MoodAnalyser object
        /// </summary>
        /// <param name="className">The className</param>
        /// <param name="constructor">The constructor</param>
        [DataRow("MoodAnalyse", "MoodAnalyse")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 4")]
        public void CreateObjectOfMoodAnalyse(string className, string constructor)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse();

            // Act
            var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, null);

            // Assert
            obj.Equals(moodAnalyse);
        }

        /// <summary>
        /// TC 4.2 Given invalid MoodAnalyser Class Name then Should Return exception
        /// </summary>
        /// <param name="className">className to be called</param>
        /// <param name="constructor">constructor to be called</param>
        [DataRow("MoodAnalyser.MoodAnalys", "MoodAnalyse")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 4")]
        public void CreateObjectOfMoodAnalyseInvalidClassName(string className, string constructor)
        {
            // Try creating object with wrong name and catch custom exception
            try
            {
                // Act
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, null);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such class found", e.Message);
            }
        }

        /// <summary>
        /// TC 4.3 Given invalid MoodAnalyser Constructor Name then Should Return exception
        /// </summary>
        /// <param name="className">className to be called</param>
        /// <param name="constructor">constructor to be called</param>
        /// <param name="message">Passes message The message.</param>
        [DataRow("MoodAnalyser.MoodAnalyse", "MoodAnalys", null)]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 4")]
        public void CreateObjectOfMoodAnalyseInvalidConstructor(string className, string constructor, string message)
        {
            try
            {
                // Act
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, message);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such constructor found", e.Message);
            }
        }

        /// <summary>
        /// TC 5.1 When given valid class name,constructor return object
        /// </summary>
        /// <param name="className">className to be called</param>
        /// <param name="constructor">constructor to be called</param>
        /// <param name="message">Message to check for mood</param>
        [DataRow("MoodAnalyse", "MoodAnalyse", "message")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 5")]
        public void CreateParameterizedObjectOfMoodAnalyse(string className, string constructor, string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);

            // Act
            var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, message);

            // Assert
            obj.Equals(moodAnalyse);
        }

        /// <summary>
        /// TC 5.2 When given invalid class name then throw exception
        /// </summary>
        /// <param name="className">className to be called</param>
        /// <param name="constructor">constructor to be called</param>
        /// <param name="message">Message to check for mood</param>
        [DataRow("MoodAnalys", "MoodAnalyse", "message")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 5")]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidClassName(string className, string constructor, string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);
            try
            {
                // Act
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, message);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such class found", e.Message);
            }
        }

        /// <summary>
        /// TC 5.3 When given invalid constructor then throw exception
        /// </summary>
        /// <param name="className">className to be called</param>
        /// <param name="constructor">constructor to be called</param>
        /// <param name="message">Message to check for mood</param>
        [DataRow("MoodAnalyse", "MoodAnalys", "message")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 5")]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidConstructor(string className, string constructor, string message)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse(message);
            try
            {
                // Act
                var obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, constructor, message);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such constructor found", e.Message);
            }
        }

        /// <summary>
        /// TC 6.1 When given valid class name , constructor ,message as happy and valid method name then should return happy mood
        /// </summary>
        /// <param name="message">Message to check mood</param>
        /// <param name="methodName">Method name to be called</param>
        [DataRow("Happy", "AnalyseMood")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 6")]
        public void InvokeMethodOfMoodAnalyser(string message, string methodName)
        {
            // Arrange
            moodAnalyse = new MoodAnalyse("Happy");

            // Act
            object actual = MoodAnalyserReflector.InvokeMethod(message, methodName);

            // Assert
            Assert.AreEqual("happy mood", actual);
        }

        /// <summary>
        /// TC 6.2 When given valid class name , constructor ,message and invalid method name then should throw exception 
        /// </summary>
        /// <param name="message">Message to check mood</param>
        /// <param name="methodName">Method name to be called</param>
        [DataRow("Happy", "InvalidMethod")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 6")]
        public void InvokeMethodOfMoodAnalyserInvalid(string message, string methodName)
        {
            try
            {
                // Act
                moodAnalyse = new MoodAnalyse("Happy");
                object expected = moodAnalyse.AnalyseMood();
                object actual = MoodAnalyserReflector.InvokeMethod(message, methodName);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such method found", e.Message);
            }
        }

        /// <summary>
        /// TC 7.1 When given proper fieldName and Happy message then should return happy mood
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        [DataRow("Happy", "message")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 7")]
        public void ChangeMoodDynamicallyValid(string message, string fieldName)
        {
            // ACT
            object actual = MoodAnalyserReflector.ChangeMoodDynamically(message, fieldName);

            // Assert
            Assert.AreEqual("happy mood", actual);
        }

        /// <summary>
        ///  TC 7.2 When given improper fieldName and Happy message then should throw exception
        /// </summary>
        /// <param name="message">Message to check mood</param>
        /// <param name="fieldName">field name to be changed</param>
        [DataRow("Happy", "InvalidField")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 7")]
        public void ChangeMoodDynamicallyInValid(string message, string fieldName)
        {
            try
            {
                // ACT
                object actual = MoodAnalyserReflector.ChangeMoodDynamically(message, fieldName);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : No such field found", e.Message);
            }
        }

        /// <summary>
        /// TC 7.3 When given Proper fieldName and null message then throw error of mood cannot be null
        /// </summary>
        /// <param name="message">Message to check mood</param>
        /// <param name="fieldName">field name to be changed</param>
        [DataRow(null, "message")]
        [TestMethod, TestCategory("Reflection"), TestCategory("TC 7")]
        public void ChangeMoodDynamicallySetNull(string message, string fieldName)
        {
            try
            {
                // ACT
                object actual = MoodAnalyserReflector.ChangeMoodDynamically(message, fieldName);
            }
            catch (MoodAnalyserExceptions e)
            {
                // Assert
                Assert.AreEqual("MoodAnalyser exception : Null mood not accepted", e.Message);
            }
        }
    }
}

