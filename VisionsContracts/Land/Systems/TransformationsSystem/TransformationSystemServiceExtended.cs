using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Transformations;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Land.Systems.TransformationsSystem
{
    public partial class TransformationsSystemService
    {
        private int NumberOfTransactionsPerGroup = 30;
        public async Task<string> SetDefaultTransformationsRequestAsync()
        { 

            var transformations = DefaultTransformations.GetAllTransformations().Select(x => ConvertFromModel(x)).ToList();
            string lastTransaction = null;
            for(int i = 0; i < transformations.Count; i+=NumberOfTransactionsPerGroup)
            {
                lastTransaction = await SetTransformationsRequestAsync(
                    transformations.GetRange(i, 
                    Math.Min(NumberOfTransactionsPerGroup, transformations.Count - i)));
            }

            return lastTransaction;
        }

        public async Task<TransactionReceipt> SetDefaultTransformationsRequestAndWaitForReceiptAsync()
        {
            var lastTransaction = await SetDefaultTransformationsRequestAsync(); ;
            return await Web3.TransactionReceiptPolling.PollForReceiptAsync(lastTransaction);
        }

        public ContractDefinition.TransformationDTO ConvertFromModel(Transformation transformation)
        {
            var transformationContract = new ContractDefinition.TransformationDTO()
            {
                Base = transformation.Base,
                Input = transformation.Input,
                Next = transformation.Next,
                InputNext = transformation.InputNext,
                Yield = transformation.Yield,
                YieldQuantity = transformation.YieldQuantity,
                UnlockTime = transformation.UnlockTime,
                Timeout = transformation.Timeout,
                TimeoutYield = transformation.TimeoutYield,
                TimeoutYieldQuantity = transformation.TimeoutYieldQuantity,
                TimeoutNext = transformation.TimeoutNext,
                IsRecipe = transformation.IsRecipe,
                IsWaterCollection = transformation.IsWaterCollection,
                Xp = transformation.Xp,
                Exists = transformation.Exists
            };
            return transformationContract;
        }

    }
}
