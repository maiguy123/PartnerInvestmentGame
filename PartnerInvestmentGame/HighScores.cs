using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame
{
    public class HighScores
    {
        public HighScores() { }
        public HighScores(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public string Name { get; set; }
        public double Score { get; set; }
    }
}
