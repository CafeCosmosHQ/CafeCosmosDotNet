using ADRaffy.ENSNormalize;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Land.Systems.QuestsSystem.Model;


namespace VisionsContracts.Land.Systems.LevelingSystem.Model
{
    public class LevelReward
    {
        public int Level { get; set; }
        public int CumulativeXp { get; set; }
        public BigInteger Tokens { get; set; }
        public List<BigInteger> Items { get; set; } = new List<BigInteger>();

        public LevelReward(int level, int cumulativeXp, int tokensInEthUnit, List<BigInteger> items)
        {
            Level = level;
            CumulativeXp = cumulativeXp;
            Tokens = Web3.Convert.ToWei(tokensInEthUnit);
            Items = items;
        }

        public LevelReward(int level, int cumulativeXp, int tokensInEthUnit)
        {
            Level = level;
            CumulativeXp = cumulativeXp;
            Tokens = Web3.Convert.ToWei(tokensInEthUnit);
        }

        public LevelReward()
        {
        }
    }
}

