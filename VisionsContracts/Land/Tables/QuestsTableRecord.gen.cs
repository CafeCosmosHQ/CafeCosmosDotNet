using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Mud;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace VisionsContracts.Land.Tables
{
    public partial class QuestsTableService : TableSingletonService<QuestsTableRecord,QuestsTableRecord.QuestsValue>
    { 
        public QuestsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class QuestsTableRecord : TableRecordSingleton<QuestsTableRecord.QuestsValue> 
    {
        public QuestsTableRecord() : base("Quests")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'NumberOfQuests'.
        /// </summary>
        public virtual BigInteger NumberOfQuests => Values.NumberOfQuests;
        /// <summary>
        /// Direct access to the value property 'NumberOfQuestsGroups'.
        /// </summary>
        public virtual BigInteger NumberOfQuestsGroups => Values.NumberOfQuestsGroups;
        /// <summary>
        /// Direct access to the value property 'NumberOfRewards'.
        /// </summary>
        public virtual BigInteger NumberOfRewards => Values.NumberOfRewards;
        /// <summary>
        /// Direct access to the value property 'ActiveQuestGroups'.
        /// </summary>
        public virtual List<BigInteger> ActiveQuestGroups => Values.ActiveQuestGroups;

        public partial class QuestsValue
        {
            [Parameter("uint256", "numberOfQuests", 1)]
            public virtual BigInteger NumberOfQuests { get; set; }
            [Parameter("uint256", "numberOfQuestsGroups", 2)]
            public virtual BigInteger NumberOfQuestsGroups { get; set; }
            [Parameter("uint256", "numberOfRewards", 3)]
            public virtual BigInteger NumberOfRewards { get; set; }
            [Parameter("uint256[]", "activeQuestGroups", 4)]
            public virtual List<BigInteger> ActiveQuestGroups { get; set; }          
        }
    }
}
