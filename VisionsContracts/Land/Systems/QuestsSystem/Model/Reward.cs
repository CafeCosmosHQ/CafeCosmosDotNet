using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{

    public enum RewardType
    {
        Item = 0,
        XP = 1,
        SoftToken = 2,
        HardToken = 3
    }

    public class DefaultRewards
    {
        public static readonly RewardXP RewardXP65 = new RewardXP(1, 65);
        
        public static readonly RewardSoftToken RewardSoftToken30 = new RewardSoftToken(2, 30);
        public static readonly RewardSoftToken RewardSoftToken35 = new RewardSoftToken(3, 35);
        public static readonly RewardSoftToken RewardSoftToken40 = new RewardSoftToken(4, 40);
        public static readonly RewardSoftToken RewardSoftToken25 = new RewardSoftToken(5, 25);
        public static readonly RewardSoftToken RewardSoftToken45 = new RewardSoftToken(6, 45);
        public static readonly RewardSoftToken RewardSoftToken15 = new RewardSoftToken(7, 15);

        public static readonly RewardXP RewardXP7 = new RewardXP(8, 7);
        public static readonly RewardXP RewardXP5 = new RewardXP(9, 5);
        public static readonly RewardSoftToken RewardSoftToken20 = new RewardSoftToken(10, 20);


        public static List<Reward> GetAll()
        {
            return new List<Reward>()
            {
                RewardXP65,
                RewardSoftToken30,
                RewardSoftToken35,
                RewardSoftToken40,
                RewardSoftToken25,
                RewardSoftToken45,
                RewardSoftToken15,
                RewardXP7,
                RewardXP5,
                RewardSoftToken20
            };
        }

    }


    public class Reward
    {
        public BigInteger Id { get; set; }
        public  BigInteger ItemId { get; set; }
        public  BigInteger RewardType { get; set; }
        public  BigInteger Quantity { get; set; }
    }

    public class RewardXP : Reward
    {
        public RewardXP(BigInteger id, BigInteger quantity)
        {
            Id = id;
            ItemId = 0;
            RewardType = (int)Model.RewardType.XP;
            Quantity = quantity;
        }
    }

    public class RewardSoftToken: Reward
    {
        public RewardSoftToken(BigInteger id, BigInteger quantityInEthUnits)
        {
            Id = id;
            ItemId = 0;
            RewardType = (int)Model.RewardType.SoftToken;
            Quantity = Web3.Convert.ToWei(quantityInEthUnits);
        }
    }

}
