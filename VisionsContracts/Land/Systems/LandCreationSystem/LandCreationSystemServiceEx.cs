using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.LandCreationSystem;
using static VisionsContracts.Land.LandService;

namespace VisionsContracts.Land.Systems.LandCreationSystem
{
    public partial class LandCreationSystemService
    {
        public Task<string> InitialiseDefaultLandLimitsAsync()
        {
            return this.SetInitialLandLimitsRequestAsync(10, 10);
        }

        public async Task<string> SetInitialLandItemsInGroupsAndRandomlyPositionedRequestAsync()
        {
            var initialLandItems = InitialLandService.GetRandomInitialLandItems(10, 10, 10);
            var landGroupIds = new BigInteger[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }.ToList();
            //var landGroupIds = new BigInteger[] { 8 }.ToList();
            var txnHash = "";
            for (int i = 0; i < initialLandItems.Count; i++)
            {
                txnHash = await SetInitialLandItemsRequestAsync(initialLandItems[i], landGroupIds[i], 17);
            }

            return txnHash;

        }

        public static void ValidateEnoughBalanceToExpandLand(BigInteger landCost, BigInteger softTokenBalance)
        {

            if (softTokenBalance < landCost)
            {
                throw new LandExpandNotEnoughBalanceException(landCost, softTokenBalance);
            }
        }
    }
}
