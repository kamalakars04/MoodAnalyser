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
        [TestMethod]
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
        [TestMethod]
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
        //[DataRow(null)]
        //[TestMethod]
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
        [TestMethod]
        public void GiveEmptyAndGetExceptionMessage(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("MoodAnalyser exception : Mood cannot be empty", actual);
        }
    }
}
