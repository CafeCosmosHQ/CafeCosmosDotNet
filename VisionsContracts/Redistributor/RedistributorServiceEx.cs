using Nethereum.RPC.Eth.Blocks;
using Nethereum.RPC.Eth.DTOs;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Items.Model;

namespace VisionsContracts.Redistributor
{
    public partial class RedistributorService
    {
        public Task<string> CreateDefaultSubSectionsRequestAsync()
        {
            return CreateSubSectionsRequestAsync(DefaultRedistributionSections.GetDefaultSubsectionCreations());
        }

        public Task<TransactionReceipt> CreateDefaultSubSectionsRequestAndWaitForReceiptAsync()
        {
            return CreateSubSectionsRequestAndWaitForReceiptAsync(DefaultRedistributionSections.GetDefaultSubsectionCreations());
        }
    }
}
