using Nethereum.Mud;
using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;


namespace VisionsContracts.Land.Tables
{
    public partial class LandInfoTableService : TableService<LandInfoTableRecord, LandInfoTableRecord.LandInfoKey, LandInfoTableRecord.LandInfoValue>
    {

        public virtual Task<LandInfoTableRecord> GetTableRecordAsync(BigInteger landId)
        {


            var key = new LandInfoTableRecord.LandInfoKey
            {
                LandId = landId
            };

            return GetTableRecordAsync(key);
        }


    }




}
