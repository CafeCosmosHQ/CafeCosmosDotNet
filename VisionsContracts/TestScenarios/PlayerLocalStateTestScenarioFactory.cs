using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem;
using System;
using System.Collections.Generic;
using System.Numerics;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.LandConfigSystem.ContractDefinition;
using VisionsContracts.LandLocalState;

namespace VisionsContracts.TestScenarios
{
    public class PlayerLocalStateTestScenarioFactory
    {
        public enum TestScenario
        {
            StartLandWithAllInventoryItems,
            StartLandWithNoInventoryItems,
            StartLandWithFloorWithUtensilsAndAllInventoryItems,
            GrassLandWithAllInventoryItems,
            AllFloorWithAllInventoryItems,
            OneCellAllInventoryItems,
            PlantGrownLandWithAllInventoryItems,
            CrystalLandWithAllInventoryItems
        }

        public enum LandScenario
        {
            StartLand,
            AllFloor,
            OneCell,
            CookingLand,
            GrassLand,
            PlantGrownLand,
            CrystalLand
        }

        public static PlayerLocalState GetLocalState(LandScenario landScenario)
        {
            switch (landScenario)
            {
                case LandScenario.StartLand:
                    return new PlayerLocalState(

                         new LandInfo()
                         {
                             IsInitialized = true,
                             LimitX = 10,
                             LimitY = 10,
                             YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                         },

                         new List<Items.Model.InventoryItem>(),
                         LandScenarios.GetDefaultStartUpLand()
                    );

                case LandScenario.AllFloor:
                    return new PlayerLocalState(

                         new LandInfo()
                         {
                             IsInitialized = true,
                             LimitX = 10,
                             LimitY = 10,
                             YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                         },

                         new List<Items.Model.InventoryItem>(),
                        LandScenarios.GetFloorland()
                    );

                case LandScenario.OneCell:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 2,
                                     LimitY = 2,
                                     YBound = new List<BigInteger> { 2, 2}

                                 },

                            new List<Items.Model.InventoryItem>(),
                            LandScenarios.Get1CellLand()
                   );

                case LandScenario.CookingLand:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                                 },

                            new List<Items.Model.InventoryItem>(),
                            LandScenarios.GetCookingland()
                   );

                case LandScenario.GrassLand:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            new List<Items.Model.InventoryItem>(),
                            LandScenarios.GetGrassLand()
                   );

                case LandScenario.CrystalLand:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            new List<Items.Model.InventoryItem>(),
                            LandScenarios.GetCrystalLand()
                   );

                    case LandScenario.PlantGrownLand:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            new List<Items.Model.InventoryItem>(),
                            LandScenarios.GetPlantGrownLand()
                            );

            }
            throw new NotImplementedException();

        }

        public static PlayerLocalState GetPlayerLocalState(TestScenario testScenario)
        {
            switch (testScenario)
            {
                case TestScenario.StartLandWithAllInventoryItems:
                    return new PlayerLocalState(
                    
                         new LandInfo()
                        {
                            IsInitialized = true,
                            LimitX = 10,
                            LimitY = 10,
                             YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                         },
                        
                         InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                         LandScenarios.GetDefaultStartUpLand()
                    );

                case TestScenario.StartLandWithNoInventoryItems:
                    return new PlayerLocalState(

                         new LandInfo()
                         {
                             IsInitialized = true,
                             LimitX = 10,
                             LimitY = 10,
                             YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                         },

                         new List<Items.Model.InventoryItem>(),
                         LandScenarios.GetDefaultStartUpLand()
                    );

                case TestScenario.StartLandWithFloorWithUtensilsAndAllInventoryItems:
                    return new PlayerLocalState(

                                            new LandInfo()
                                            {
                                                IsInitialized = true,
                                                LimitX = 10,
                                                LimitY = 10,
                                                YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                                            },

                                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                                            LandScenarios.GetDefaultStartUpLandWithFloorBarTableAndUtensils()
                                       );

                case TestScenario.AllFloorWithAllInventoryItems:
                    return new PlayerLocalState(

                                            new LandInfo()
                                            {
                                                IsInitialized = true,
                                                LimitX = 10,
                                                LimitY = 10,
                                                YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }

                                            },

                                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                                            LandScenarios.GetFloorland()
                                       );

                case TestScenario.OneCellAllInventoryItems:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 2,
                                     LimitY = 2,
                                     YBound = new List<BigInteger> { 2, 2 }

                                 },

                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                            LandScenarios.Get1CellLand()
                   );

                case TestScenario.GrassLandWithAllInventoryItems:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                            LandScenarios.GetGrassLand()
                   );

                    case TestScenario.PlantGrownLandWithAllInventoryItems:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                            LandScenarios.GetPlantGrownLand()
                            );

                    case TestScenario.CrystalLandWithAllInventoryItems:
                    return new PlayerLocalState(
                                 new LandInfo()
                                 {
                                     IsInitialized = true,
                                     LimitX = 10,
                                     LimitY = 10,
                                     YBound = new List<BigInteger> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
                                 },
                            InventoryScenarios.GetAllInventoryItemsWith20ItemsPerItem(),
                            LandScenarios.GetCrystalLand()
                            );  

            }
            throw new NotImplementedException();
        }
    }
}
