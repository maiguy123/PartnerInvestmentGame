using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame
{
    public class ScoresRepo
    {
        private List<HighScores> _scoresRepo = new List<HighScores>();

        //C
        public bool AddScore(HighScores score)
        {
            int startCounting = _scoresRepo.Count;
            _scoresRepo.Add(score);
            bool wasAdded = _scoresRepo.Count > startCounting;
            return wasAdded;
        }

        //R
        public List<HighScores> DisplayGames()
        {
            return _scoresRepo;
        }

        public void PrintScores()
        {
            List<HighScores> sortedList = _scoresRepo.OrderByDescending(o => o.Score).ToList();
            foreach (HighScores score in sortedList)
            {
                if (score.Score > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{score.Name,-30} {score.Score,-30}\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (score.Score < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{score.Name,-30} {score.Score,-30}\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine($"{score.Name,-30} {score.Score,-30}\n");
                }
            }
        }
    }
}
