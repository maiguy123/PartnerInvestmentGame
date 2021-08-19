using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartnerInvestmentGame;
using System;

namespace ScoresRepoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ScoresRepo repo = new ScoresRepo();
            HighScores score = new HighScores();
            score.Name = "Bob";
            score.Score = 16;

            Assert.IsTrue(repo.AddScore(score));

            
        }
    }
}
