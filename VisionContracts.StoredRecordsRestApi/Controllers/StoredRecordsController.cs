using Microsoft.AspNetCore.Mvc;
using Nethereum.Mud.Repositories.Postgres;
using Nethereum.Mud.TableRepository;
using System.Numerics;

namespace VisionContracts.StoredRecordsRestApi
{

    [ApiController]
    [Route("storedrecords")]
    public class StoredRecordsController : ControllerBase
    {
        
        private readonly ILogger<StoredRecordsController> _logger;
        private readonly MudPostgresStoreRecordsDbContext context;
        private readonly StoredRecordsDTOService storedRecordsDTOService;

        public StoredRecordsController(ILogger<StoredRecordsController> logger, MudPostgresStoreRecordsDbContext context)
        {
            _logger = logger;
            this.context = context;
            this.storedRecordsDTOService = new StoredRecordsDTOService(new MudPostgresStoreRecordsTableRepository(context));
        }

        [HttpPost(Name = "get")]
        public async Task<IEnumerable<StoredRecordDTO>> GetStoredRecords(TablePredicate tablePredicate)
        {
           return await  storedRecordsDTOService.GetStoredRecords(tablePredicate);
        }
    }


   
}
