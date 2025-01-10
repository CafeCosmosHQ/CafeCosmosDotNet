using Nethereum.ABI.Model;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionsContracts.Land.Systems.LandERC1155HolderSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandERC1155HolderSystem
{
    public partial class LandERC1155HolderSystemService
    {
        public List<FunctionABI> GetAllDiamondFunctionABIs()
        {
            return GetAllDiamondFunctionTypes().Select(x => ABITypedRegistry.GetFunctionABI(x)).ToList();
        }

        public string[] GetAllFunctionDiamondSignatures()
        {
            return GetAllDiamondFunctionABIs().Select(x => x.Sha3Signature).ToArray();
        }

        public List<Type> GetAllDiamondFunctionTypes()
        {
            return new List<Type>
            {
                typeof(OnERC1155BatchReceivedFunction),
                typeof(OnERC1155ReceivedFunction)
            };
        }
    }
}
