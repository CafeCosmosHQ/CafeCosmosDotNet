using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using VisionsContracts.Items;
using VisionsContracts.Land.Model;

namespace VisionsContracts.LandLocalState
{
    public static class TablesAndChairsService
    {
        public static void ReCheckAllTablesAndChairs(this PlayerLocalState playerLocalState)
        {
            playerLocalState.LandTablesAndChairs  = new List<LandTablesAndChairs>();
            playerLocalState.PlayerLandInfo.ActiveTables = 0;

            var land = playerLocalState.UpdatedLand; // keep a reference of the original land objects
            playerLocalState.UpdatedLand = new List<LandItem>(); // clear the updated land objects so we can re-add them and recalculate the tables and chairs

            foreach (var item in land.OrderBy(x => x.StackIndex))
            {
                playerLocalState.UpdatedLand.Add(item);
                if (item.ItemId >= 0) //if chunked we cannot use uints (-1), and they are not going to have any tables or chairs
                {
                    CheckPlaceTableOrChair(playerLocalState, (uint)item.ItemId, (uint)item.X, (uint)item.Y);
                }
            }
        }

        public static void CheckPlaceTableOrChair(this PlayerLocalState playerLocalState, uint itemId, uint x, uint y)
        {
            if (DefaultItems.IsTable(itemId))
            {
                PlaceTable(playerLocalState, x, y);
            }
            else if (DefaultItems.IsChair(itemId))
            {
                PlaceChair(playerLocalState, x, y);
            }
        }

        public static void CheckRemoveTableOrChair(this PlayerLocalState playerLocalState, uint itemId, uint x, uint y)
        {
            if (DefaultItems.IsTable(itemId))
            {
                RemoveTable(playerLocalState, x, y);
            }
            else if (DefaultItems.IsChair(itemId))
            {
                RemoveChair(playerLocalState, x, y);
            }
        }

        private static BigInteger GetItemId(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var item = playerLocalState.UpdatedLand.Where(item => item.X == x && item.Y == y).OrderByDescending( x => x.StackIndex).FirstOrDefault();
            if (item != null) return item.ItemId;
            return 0;
        }

        private static bool IsChair(PlayerLocalState playerLocalState, uint x, uint y)
        {
            return DefaultItems.IsChair(GetItemId(playerLocalState, x, y));
        }

        private static bool IsTable(PlayerLocalState playerLocalState, uint x, uint y)
        {
            return DefaultItems.IsTable(GetItemId(playerLocalState, x, y));
        }

        public static List<BigInteger> GetTablesOfChairs(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var item = playerLocalState.LandTablesAndChairs.FirstOrDefault(item => item.X == x && item.Y == y);
            if (item != null && item.TablesOfChairs.Count > 1) return item.TablesOfChairs;
            return new List<BigInteger> { 0, 0, 0 };
        }

        public static void SetTablesOfChairs(PlayerLocalState playerLocalState, uint x, uint y, uint[] coords)
        {
            var item = playerLocalState.LandTablesAndChairs.FirstOrDefault(item => item.X == x && item.Y == y);
            if (item == null)
            {
                item = new LandTablesAndChairs();
                item.X = x;
                item.Y = y;
                playerLocalState.LandTablesAndChairs.Add(item);
            }
            item.TablesOfChairs = new List<BigInteger> { coords[0], coords[1], coords[2] };
        }

        public static List<BigInteger> GetChairsOfTables(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var item = playerLocalState.LandTablesAndChairs.FirstOrDefault(item => item.X == x && item.Y == y);
            if (item != null && item.ChairsOfTables.Count > 1) return item.ChairsOfTables;
            return new List<BigInteger> { 0, 0, 0 };
        }

        public static void SetChairsOfTables(PlayerLocalState playerLocalState, uint x, uint y, uint[] coords)
        {
            var item = playerLocalState.LandTablesAndChairs.FirstOrDefault(item => item.X == x && item.Y == y);
            if (item == null)
            {
                item = new LandTablesAndChairs();
                item.X = x;
                item.Y = y;
                playerLocalState.LandTablesAndChairs.Add(item);
            }
            item.ChairsOfTables = new List<BigInteger> { coords[0], coords[1], coords[2] };
        }

        public static void SetActiveTables(PlayerLocalState playerLocalState, uint activeTables)
        {
            playerLocalState.PlayerLandInfo.ActiveTables = activeTables;
        }

        public static void IncrementActiveTables(PlayerLocalState playerLocalState)
        {
            playerLocalState.PlayerLandInfo.ActiveTables++;
        }

        public static void DecrementActiveTables(PlayerLocalState playerLocalState)
        {
            playerLocalState.PlayerLandInfo.ActiveTables--;
        }

        private static void PlaceTable(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var limitX = playerLocalState.PlayerLandInfo.LimitX;
            var limitY = playerLocalState.PlayerLandInfo.LimitY;
            uint[] coords = new uint[3] { 0, 0, 0 };
            
            if (limitX > x + 1 && IsChair(playerLocalState, x + 1, y) &&
                GetTablesOfChairs(playerLocalState, x + 1, y)[2] == 0)
            {
                coords = new uint[3] { x + 1, y, 1 };
                SetChairsOfTables(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetTablesOfChairs(playerLocalState, x + 1, y, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (x > 0 && IsChair(playerLocalState, x - 1, y) &&
                     GetTablesOfChairs(playerLocalState, x - 1, y)[2] == 0)
            {
                coords = new uint[3] { x - 1, y, 1 };
                SetChairsOfTables(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetTablesOfChairs(playerLocalState, x - 1, y, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (limitY > y + 1 && IsChair(playerLocalState, x, y + 1) &&
                     GetTablesOfChairs(playerLocalState, x, y + 1)[2] == 0)
            {
                coords = new uint[3] { x, y + 1, 1 };
                SetChairsOfTables(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetTablesOfChairs(playerLocalState, x, y + 1, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (y > 0 && IsChair(playerLocalState, x, y - 1) &&
                     GetTablesOfChairs(playerLocalState, x, y - 1)[2] == 0)
            {
                coords = new uint[3] { x, y - 1, 1 };
                SetChairsOfTables(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetTablesOfChairs(playerLocalState, x, y - 1, coords);
                IncrementActiveTables(playerLocalState);
            }
        }

        private static void PlaceChair(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var limitX = playerLocalState.PlayerLandInfo.LimitX;
            var limitY = playerLocalState.PlayerLandInfo.LimitY;
            uint[] coords = new uint[3] { 0, 0, 0 };

            if (limitX > x + 1 && IsTable(playerLocalState, x + 1, y) &&
                GetChairsOfTables(playerLocalState, x + 1, y)[2] == 0)
            {
                coords = new uint[3] { x + 1, y, 1 };
                SetTablesOfChairs(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetChairsOfTables(playerLocalState, x + 1, y, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (x > 0 && IsTable(playerLocalState, x - 1, y) &&
                     GetChairsOfTables(playerLocalState, x - 1, y)[2] == 0)
            {
                coords = new uint[3] { x - 1, y, 1 };
                SetTablesOfChairs(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetChairsOfTables(playerLocalState, x - 1, y, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (limitY > y + 1 && IsTable(playerLocalState, x, y + 1) &&
                     GetChairsOfTables(playerLocalState, x, y + 1)[2] == 0)
            {
                coords = new uint[3] { x, y + 1, 1 };
                SetTablesOfChairs(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetChairsOfTables(playerLocalState, x, y + 1, coords);
                IncrementActiveTables(playerLocalState);
            }
            else if (y > 0 && IsTable(playerLocalState, x, y - 1) &&
                     GetChairsOfTables(playerLocalState, x, y - 1)[2] == 0)
            {
                coords = new uint[3] { x, y - 1, 1 };
                SetTablesOfChairs(playerLocalState, x, y, coords);
                coords = new uint[3] { x, y, 1 };
                SetChairsOfTables(playerLocalState, x, y - 1, coords);
                IncrementActiveTables(playerLocalState);
            }
        }

        private static void RemoveTable(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var chairsOfTables = GetChairsOfTables(playerLocalState, x, y);
            
            if (chairsOfTables.Count > 1 && chairsOfTables[2] == 1)
            {
                var chairX = (uint)chairsOfTables[0];
                var chairY = (uint)chairsOfTables[1];
                var tablesOfChair = GetTablesOfChairs(playerLocalState, chairX, chairY);
                if (tablesOfChair[0] == x && tablesOfChair[1] == y && tablesOfChair[2] == 1)
                {
                    SetChairsOfTables(playerLocalState, x, y, new uint[3] { 0, 0, 0 });
                    SetTablesOfChairs(playerLocalState, chairX, chairY, new uint[3] { 0, 0, 0 });
                    DecrementActiveTables(playerLocalState);
                }
                else
                {
                    throw new Exception("tablesOfChairs has a different coordinate for the table");
                }
            }
        }

        private static void RemoveChair(PlayerLocalState playerLocalState, uint x, uint y)
        {
            var tablesOfChair = GetTablesOfChairs(playerLocalState, x, y);
            if (tablesOfChair.Count > 1 && tablesOfChair[2] == 1)
            {
                var tableX = (uint)tablesOfChair[0];
                var tableY = (uint)tablesOfChair[1];
                var chairsOfTables = GetChairsOfTables(playerLocalState, tableX, tableY);
                if (chairsOfTables[0] == x && chairsOfTables[1] == y && chairsOfTables[2] == 1)
                {
                    SetTablesOfChairs(playerLocalState, x, y, new uint[3] { 0, 0, 0 });
                    SetChairsOfTables(playerLocalState, tableX, tableY, new uint[3] { 0, 0, 0 });
                    DecrementActiveTables(playerLocalState);
                }
                else
                {
                    throw new Exception("chairsOfTables has different coordinates for the chair");
                }
                //we are placing the table again to check if there is another surrounding chair that can be connected to it
                PlaceTable(playerLocalState, tableX, tableY);   
            }
        }
    }
}
