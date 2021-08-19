using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame
{
    public enum InvestmentOptions { Doge, Tesla, GameStop, AMC, Nokia, BlockBuster, MySpace, Bond}
    public class Investments
    {
        Dictionary<InvestmentOptions, double> Cost = new Dictionary<InvestmentOptions, double>
        {
            {InvestmentOptions.Doge, 0.20},
            {InvestmentOptions.Tesla, 688},
            {InvestmentOptions.GameStop, 161.38},
            {InvestmentOptions.AMC, 37.59},
            {InvestmentOptions.BlockBuster, 0.30},
            {InvestmentOptions.MySpace, 45 },
            {InvestmentOptions.Bond, 10 }
        };
        
        Dictionary<InvestmentOptions, double> GainOrLoss = new Dictionary<InvestmentOptions, double>
        {
            {InvestmentOptions.Doge, 1.47},
            {InvestmentOptions.Tesla, 2.00},
            {InvestmentOptions.GameStop, 4.2},
            {InvestmentOptions.AMC, 0.67},
            {InvestmentOptions.BlockBuster, 0},
            {InvestmentOptions.MySpace, 0},
            {InvestmentOptions.Bond, 1.10 }
        };

        public Investments(InvestmentOptions name, int totalShares)
        {
            Name = name;
            TotalShares = totalShares;
        }

        public InvestmentOptions Name { get; set; }
        public int TotalShares { get; set; }
        public double TotalCost { get 
            {
                return Cost[Name] * TotalShares;
            } 
        }
        public double AmountGainOrLoss { get
            {
                return TotalCost * GainOrLoss[Name];
            } 
        }
    }
}
