using Nethereum.Mud;
using Nethereum.Contracts;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;

namespace VisionsContracts.Land
{
    public interface ISystemCallMulticallInput : IMulticallInput
    {
        IResource SystemResource { get; }
        SystemCallData GetSystemCallData();
    }

}

   

