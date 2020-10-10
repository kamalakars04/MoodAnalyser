using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MSTestForMoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyse moodAnalyse;
        /// <summary>
        /// Tests the analyse mood method by giving sad and expecting sad
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
        /// doesnt give sad and get happy.
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
        /// Gives null and get happy.
        /// </summary>
        /// <param name="message">The message.</param>
        [DataRow(null)]
        [TestMethod]
        public void GiveNullAndGetHappy(string message)
        {
            //Arrange
            moodAnalyse = new MoodAnalyse(message);
            //Act
            var actual = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("happy mood", actual);
        }
    }
}
