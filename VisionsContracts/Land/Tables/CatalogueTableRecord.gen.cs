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
    public partial class CatalogueTableService : TableService<CatalogueTableRecord, CatalogueTableRecord.CatalogueKey, CatalogueTableRecord.CatalogueValue>
    { 
        public CatalogueTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<CatalogueTableRecord> GetTableRecordAsync(BigInteger catalogueId, BlockParameter blockParameter = null)
        {
            var _key = new CatalogueTableRecord.CatalogueKey();
            _key.CatalogueId = catalogueId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger catalogueId, string catalogueName)
        {
            var _key = new CatalogueTableRecord.CatalogueKey();
            _key.CatalogueId = catalogueId;

            var _values = new CatalogueTableRecord.CatalogueValue();
            _values.CatalogueName = catalogueName;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger catalogueId, string catalogueName)
        {
            var _key = new CatalogueTableRecord.CatalogueKey();
            _key.CatalogueId = catalogueId;

            var _values = new CatalogueTableRecord.CatalogueValue();
            _values.CatalogueName = catalogueName;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class CatalogueTableRecord : TableRecord<CatalogueTableRecord.CatalogueKey, CatalogueTableRecord.CatalogueValue> 
    {
        public CatalogueTableRecord() : base("Catalogue")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'CatalogueId'.
        /// </summary>
        public virtual BigInteger CatalogueId => Keys.CatalogueId;
        /// <summary>
        /// Direct access to the value property 'CatalogueName'.
        /// </summary>
        public virtual string CatalogueName => Values.CatalogueName;

        public partial class CatalogueKey
        {
            [Parameter("uint256", "catalogueId", 1)]
            public virtual BigInteger CatalogueId { get; set; }
        }

        public partial class CatalogueValue
        {
            [Parameter("string", "catalogueName", 1)]
            public virtual string CatalogueName { get; set; }          
        }
    }
}
