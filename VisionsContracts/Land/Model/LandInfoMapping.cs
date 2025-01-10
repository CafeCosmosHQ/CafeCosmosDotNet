using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Land.Model
{
    public class LandInfoMapping
    {
        public static LandInfo MapToLandInfoModel(LandInfoTableRecord record)
        {
            return new LandInfo
            {
                LimitX = record.Values.LimitX,
                LimitY = record.Values.LimitY,
                ActiveTables = record.Values.ActiveTables,
                ActiveStoves = record.Values.ActiveStoves,
                IsInitialized = record.Values.IsInitialized,
                Seed = record.Values.Seed,
                TokenBalance = record.Values.TokenBalance,
                CumulativeXp = record.Values.CumulativeXp,
                LastLevelClaimed = record.Values.LastLevelClaimed,
                YBound = record.Values.YBound
            };
        }

        public static LandInfoTableRecord MapToTableRecord(LandInfo landInfo, BigInteger landId)
        {
            return new LandInfoTableRecord
            {
                Keys = new LandInfoTableRecord.LandInfoKey()
                {
                    LandId = landId
                },
                Values = new LandInfoTableRecord.LandInfoValue()
                {
                    LimitX = landInfo.LimitX,
                    LimitY = landInfo.LimitY,
                    ActiveTables = landInfo.ActiveTables,
                    ActiveStoves = landInfo.ActiveStoves,
                    IsInitialized = landInfo.IsInitialized,
                    Seed = landInfo.Seed,
                    TokenBalance = landInfo.TokenBalance,
                    CumulativeXp = landInfo.CumulativeXp,
                    LastLevelClaimed = landInfo.LastLevelClaimed,
                    YBound = landInfo.YBound
                }
            };
        }

        public static LandInfo MapToLandInfoModel(LandInfoData landInfoData)
        {
            return new LandInfo
            {
                LimitX = landInfoData.LimitX,
                LimitY = landInfoData.LimitY,
                ActiveTables = landInfoData.ActiveTables,
                ActiveStoves = landInfoData.ActiveStoves,
                IsInitialized = landInfoData.IsInitialized,
                Seed = landInfoData.Seed,
                TokenBalance = landInfoData.TokenBalance,
                CumulativeXp = landInfoData.CumulativeXp,
                LastLevelClaimed = landInfoData.LastLevelClaimed,
                YBound = landInfoData.YBound
            };
        }
    }
}

