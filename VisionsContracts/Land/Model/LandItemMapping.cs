using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition;
using VisionsContracts.Land.Tables;

namespace VisionsContracts.Land.Model
{
    public class LandItemMapping
    {
        public static LandItem MapToLandItemModel(LandItemDTO landItemDTO)
        {
            return new LandItem
            {
                X = landItemDTO.X,
                Y = landItemDTO.Y,
                ItemId = landItemDTO.ItemId,
                PlacementTime = landItemDTO.PlacementTime,
                StackIndex = landItemDTO.StackIndex,
                IsRotated = landItemDTO.IsRotated,
                DynamicUnlockTime = landItemDTO.DynamicUnlockTime,
                DynamicTimeoutTime = landItemDTO.DynamicTimeoutTime
            };
        }

        public static LandItemDTO MapToLandItemDTO(LandItem landItem)
        {
            return new LandItemDTO
            {
                X = landItem.X,
                Y = landItem.Y,
                ItemId = landItem.ItemId,
                PlacementTime = landItem.PlacementTime,
                StackIndex = landItem.StackIndex,
                IsRotated = landItem.IsRotated,
                DynamicUnlockTime = landItem.DynamicUnlockTime,
                DynamicTimeoutTime = landItem.DynamicTimeoutTime
            };
        }

        public static LandItemTableRecord MapToLandItemTableRecord(LandItemDTO landItemDTO, BigInteger landId)
        {
            return new LandItemTableRecord
            {
               Keys = new LandItemTableRecord.LandItemKey
               {
                   LandId = landId,
                   X = landItemDTO.X,
                   Y = landItemDTO.Y,
                   Z = landItemDTO.StackIndex
               },

               Values = new LandItemTableRecord.LandItemValue
               {
                   ItemId = landItemDTO.ItemId,
                   PlacementTime = landItemDTO.PlacementTime,
                   IsRotated = landItemDTO.IsRotated,
                   DynamicUnlockTimes = landItemDTO.DynamicUnlockTime,
                   DynamicTimeoutTimes = landItemDTO.DynamicTimeoutTime
               }
            };
        }

        public static LandItemTableRecord MapToLandItemTableRecord(LandItem landItem, BigInteger landId)
        {
            return new LandItemTableRecord
            {
                Keys = new LandItemTableRecord.LandItemKey
                {
                    LandId = landId,
                    X = landItem.X,
                    Y = landItem.Y,
                    Z = landItem.StackIndex
                },

                Values = new LandItemTableRecord.LandItemValue
                {
                    ItemId = landItem.ItemId,
                    PlacementTime = landItem.PlacementTime,
                    IsRotated = landItem.IsRotated,
                    DynamicUnlockTimes = landItem.DynamicUnlockTime,
                    DynamicTimeoutTimes = landItem.DynamicTimeoutTime
                }
            };
        }

        public static List<LandItemTableRecord> MapToLandItemTableRecord(List<LandItemDTO> landItemDTOs, BigInteger landId)
        {
            List<LandItemTableRecord> landItemTableRecords = new List<LandItemTableRecord>();
            foreach (var landItemDTO in landItemDTOs)
            {
                landItemTableRecords.Add(MapToLandItemTableRecord(landItemDTO, landId));
            }
            return landItemTableRecords;
        }

        public static List<LandItemTableRecord> MapToLandItemTableRecord(List<LandItem> landItems, BigInteger landId)
        {
            List<LandItemTableRecord> landItemTableRecords = new List<LandItemTableRecord>();
            foreach (var landItem in landItems)
            {
                landItemTableRecords.Add(MapToLandItemTableRecord(landItem, landId));
            }
            return landItemTableRecords;
        }

        public static List<LandItem> MapToLandItemModel(List<LandItemTableRecord> landItemTableRecords)
        {
            List<LandItem> landItems = new List<LandItem>();
            foreach (var landItemTableRecord in landItemTableRecords)
            {
                landItems.Add(MapToLandItemModel(landItemTableRecord));
            }
            return landItems;
        }


        public static List<LandItem> MapToLandItemModel(List<LandItemDTO> landItemDTOs)
        {
            List<LandItem> landItems = new List<LandItem>();
            foreach (var landItemDTO in landItemDTOs)
            {
                landItems.Add(MapToLandItemModel(landItemDTO));
            }
            return landItems;

        }

        public static LandItemDTO MapToLandItemDTO(LandItemTableRecord landItemTableRecord)
        {
            return new LandItemDTO
            {
                X = landItemTableRecord.Keys.X,
                Y = landItemTableRecord.Keys.Y,
                ItemId = landItemTableRecord.Values.ItemId,
                PlacementTime = landItemTableRecord.Values.PlacementTime,
                StackIndex = landItemTableRecord.Keys.Z,
                IsRotated = landItemTableRecord.Values.IsRotated,
                DynamicUnlockTime = landItemTableRecord.Values.DynamicUnlockTimes,
                DynamicTimeoutTime = landItemTableRecord.Values.DynamicTimeoutTimes
            };
        }

        public static LandItem MapToLandItemModel(LandItemTableRecord landItemTableRecord)
        {
            return new LandItem
            {
                X = landItemTableRecord.Keys.X,
                Y = landItemTableRecord.Keys.Y,
                ItemId = landItemTableRecord.Values.ItemId,
                PlacementTime = landItemTableRecord.Values.PlacementTime,
                StackIndex = landItemTableRecord.Keys.Z,
                IsRotated = landItemTableRecord.Values.IsRotated,
                DynamicUnlockTime = landItemTableRecord.Values.DynamicUnlockTimes,
                DynamicTimeoutTime = landItemTableRecord.Values.DynamicTimeoutTimes
            };
        }
    }
}
