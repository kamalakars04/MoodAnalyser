using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MSTestForMoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyse moodAnalyse;
        /// <summary>
        /// TC 1.1 Tests the analyse mood method by giving sad and expecting sad
        /// </summary>
        [DataRow("Iam in sad mood")]
        [TestMethod , TestCategory("sad mood")]
        public void GiveSadAndGetSad(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("sad mood", actual);
        }

        /// <summary>
        /// TC 1.2 doesnt give sad and get happy.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow("Iam in happy mood")]
        [TestMethod , TestCategory("Happy mood")]
        public void GiveHappyAndGetHappy(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("happy mood", actual);
        }

        /// <summary>
        /// TC 3.1 when Gives null then get exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow(null)]
        [TestMethod , TestCategory("CustomException")]
        public void GiveNullAndGetExceptionMessage(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("MoodAnalyser exception : Null mood not accepted", actual);
        }

        /// <summary>
        /// TC 3.2 When Gives empty then gets exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow("")]
        [TestMethod , TestCategory("CustomException")]
        public void GiveEmptyAndGetExceptionMessage(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("MoodAnalyser exception : Mood cannot be empty", actual);
        }

        /// <summary>
        /// TC 4.1 Given MoodAnalyser Class Name then Should Return MoodAnalyser object
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        [DataRow("MoodAnalyse","MoodAnalyse")]
        [TestMethod , TestCategory("Reflection")]
        public void CreateObjectOfMoodAnalyse(string className , string constructor)
        {
            //Arrange
            string message = null;
            moodAnalyse = new MoodAnalyse();
            //Act
            var obj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
            //Assert
            obj.Equals(moodAnalyse);

        }

        /// <summary>
        /// TC 4.2 Given invalid MoodAnalyser Class Name then Should Return exception
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        [DataRow("MoodAnalyser.MoodAnalys", "MoodAnalyse")]
        [TestMethod, TestCategory("Reflection")]
        public void CreateObjectOfMoodAnalyseInvalidClassName(string className, string constructor)
        {
            //Act
            try
            {
                var obj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
            }
            //Assert
            catch(MoodAnalyserExceptions e)
            {
                Assert.AreEqual("MoodAnalyser exception : No such class found", e.Message);
            }
        }

        /// <summary>
        /// TC 4.3 Given invalid MoodAnalyser Constructor Name then Should Return exception
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        [DataRow("MoodAnalyser.MoodAnalyse", "MoodAnalys")]
        [TestMethod, TestCategory("Reflection")]
        public void CreateObjectOfMoodAnalyseInvalidConstructor(string className, string constructor)
        {
            //Act
            try
            {
                var obj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
            }
            //Assert
            catch (MoodAnalyserExceptions e)
            {
                Assert.AreEqual("MoodAnalyser exception : No such constructor found", e.Message);
            }
        }
    }
}
