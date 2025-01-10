using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Land.Systems.VrgdaSystem.ContractDefinition;
using VisionsContracts.Land.Systems.VrgdaSystem.Model;

namespace VisionsContracts.Land.Systems.VrgdaSystem
{

    public partial class VrgdaSystemService
    {
        public static readonly VrgdaParameters DEFAULT_VRGDA_PARAMETERS =
            new VrgdaParameters()
            {
                PerTimeUnit = BigInteger.Parse("100000000000000000000"),
                PriceDecayPercent = BigInteger.Parse("31000000000000"),
                TargetPrice = 1,
            };

        public Task<string> SetDefaultVrgdaParametersAsync()
        {
            return SetVrgdaParametersRequestAsync(GetSetVrgdaParametersFunction(DEFAULT_VRGDA_PARAMETERS));
        }

        public Task<TransactionReceipt> SetDefaultVrgdaParametersAndWaitForReceiptAsync()
        {
            return SetVrgdaParametersRequestAndWaitForReceiptAsync(GetSetVrgdaParametersFunction(DEFAULT_VRGDA_PARAMETERS));
        }

        public SetVrgdaParametersFunction GetSetVrgdaParametersFunction(VrgdaParameters vrgdaParameters)
        {
            return new SetVrgdaParametersFunction()
            {
                PerTimeUnit = vrgdaParameters.PerTimeUnit,
                PriceDecayPercent = vrgdaParameters.PriceDecayPercent,
                TargetPrice = vrgdaParameters.TargetPrice,
            };
        }
    }
}
