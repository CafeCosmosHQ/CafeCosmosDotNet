using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Numerics;
using System;
using LandItem = VisionsContracts.Land.Model.LandItem;
using Nethereum.Mud.Contracts.Core.Namespaces;
using Nethereum.Mud;
using VisionsContracts.Land.Tables;
using VisionsContracts.LandNFTs;
using Nethereum.Mud.TableRepository;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition;

namespace VisionsContracts.Land
{

    public class LandNamespaceResource: NamespaceResource
    {
        public LandNamespaceResource() : base("") { }
    }

    public class LandNamespace : NamespaceBase<LandNamespaceResource, LandSystems, LandTablesServices>
    {
        public bool TestNet { get; private set; }

        public LandNamespace(IWeb3 web3, string contractAddress, bool testNet = true) : base(web3, contractAddress)
        {
            TestNet = testNet;
            Systems = new LandSystems(web3, contractAddress, testNet);
            Tables = new LandTablesServices(web3, contractAddress);
           
        }

        public async Task<InMemoryTableRepository> GetLandItemsFromStoreAsync(int landId)
        {
            Console.WriteLine("LandInfo");
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            var landInfo = await Tables.LandInfo.GetTableRecordAsync(
                                                                        new LandInfoTableRecord.LandInfoKey()
                                                                        {
                                                                            LandId = landId
                                                                        });
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            var limitX = landInfo.Values.LimitX;
            var limitY = landInfo.Values.LimitY;
           

            var landCellKeys = new List<LandCellTableRecord.LandCellKey>();
            for (int x = 0; x < limitX; x++)
            {
                for (int y = 0; y < limitY; y++)
                {
                    landCellKeys.Add
                    (
                            new LandCellTableRecord.LandCellKey()
                            {
                                LandId = landId,
                                X = x,
                                Y = y
                            }
                    );
                }
            }

            Console.WriteLine("LandCells");
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

            var landCells = await Tables.LandCell.GetTableRecordsMulticallRpcAsync(landCellKeys);

            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            var landItemKeys = new List<LandItemTableRecord.LandItemKey>();

            foreach (var landCell in landCells)
            {
                for (int z = 0; z < landCell.Values.ZItemCount; z++)
                {
                    //if(z!=0 && landCell.Values.ZItemCount == z) continue;
                    landItemKeys.Add(new LandItemTableRecord.LandItemKey()
                    {
                        LandId = landId,
                        X = landCell.Keys.X,
                        Y = landCell.Keys.Y,
                        Z = z
                    });
                }
            }
            Console.WriteLine("LandItems");
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            var landItems = await Tables.LandItem.GetTableRecordsMulticallRpcAsync(landItemKeys);
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

            Console.WriteLine("Setting memory");
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            var inMemoryRepository = new InMemoryTableRepository();
            await inMemoryRepository.SetRecordsAsync(landItems);
            await inMemoryRepository.SetRecordsAsync(landCells);
            await inMemoryRepository.SetRecordAsync(landInfo);
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            return inMemoryRepository;

        }

        public async Task<List<LandItem>> GetAllLandItemVOsFromLandTableRepositoryAsync(ITableRepository tableRepository)
        {
            var landItemRecords = await Tables.LandItem.GetTableRecordsAsync(tableRepository);
            LandInfoTableRecord landInfo = await GetFirstLandInfoRecordFromTableRepositoryAsync(tableRepository);
            var landItemsModel = LandItemMapping.MapToLandItemModel(landItemRecords.ToList());
            return PadLandItems(landItemsModel, landInfo.Values.LimitX - 1, landInfo.Values.LimitY - 1, landInfo.Values.YBound);
        }

        public async Task<LandInfoTableRecord> GetFirstLandInfoRecordFromTableRepositoryAsync(ITableRepository tableRepository)
        {
            var landInfos = await Tables.LandInfo.GetTableRecordsAsync(tableRepository);
            var landInfo = landInfos.FirstOrDefault();
            return landInfo;
        }

        public async Task<LandInfo> GetFirstLandInfoFromTableRepository(ITableRepository tableRepository)
        {
            var landInfoRecord = await GetFirstLandInfoRecordFromTableRepositoryAsync(tableRepository);
            var landInfo = LandInfoMapping.MapToLandInfoModel(landInfoRecord);
            return landInfo;
        }


        public async Task<List<LandItem>> GetLandItemsAsync(int landId, BlockParameter blockParameter = null)
        {
            var landInfo = await Systems.LandConfig.GetLandInfoQueryAsync(landId, blockParameter);

            var land = await FetchAllLandItemsAsync(landId);

            //var landPage = await Systems.LandView.GetLandItems3dQueryAsync(landId, blockParameter);
            return PadLandItems(ConvertLand3dToLandItemCollection(land), landInfo.LandInfo.LimitX - 1, landInfo.LandInfo.LimitY - 1, landInfo.LandInfo.YBound);
        }

        public async Task<List<List<List<LandItemDTO>>>> FetchAllLandItemsAsync(BigInteger landId, int initialMaxRange = 20)
        {
            var landPage = new List<List<List<LandItemDTO>>>();
            var maxRange = initialMaxRange; // Initial max range
            var startX = 0;

            while (true)
            {
                var (result, adjustedMaxRange) = await FetchPagedLandItemsAsync(landId, startX, maxRange);

                if (result == null || result.PagedLand3d.Count == 0)
                {
                    break; // Stop if no more data
                }

                landPage.AddRange(result.PagedLand3d);

                // Persist the adjusted maxRange for subsequent calls
                maxRange = adjustedMaxRange;

                // If the result has fewer items than maxRange, we are at the end
                if (result.PagedLand3d.Count < maxRange)
                {
                    break;
                }

                startX += result.PagedLand3d.Count; // Update start index
            }

            return landPage;
        }

        private async Task<(GetLandItems3dPagedOutputDTO? result, int adjustedMaxRange)> FetchPagedLandItemsAsync(BigInteger landId, int startX, int maxRange)
        {
            while (true)
            {
                try
                {
                    var result = await Systems.LandView.GetLandItems3dPagedQueryAsync(landId, startX, maxRange);
                    return (result, maxRange); // Return the result and the current maxRange
                }
                catch (Exception ex)
                {
                    if (maxRange == 1)
                    {
                        throw; // Re-throw the exception if maxRange cannot be reduced further
                    }

                    // Adjust maxRange on failure
                    maxRange = Math.Max(1, maxRange / 2);
                    Console.WriteLine($"Error fetching data: {ex.Message}. Reducing maxRange to {maxRange}.");
                }
            }
        }

        public static List<LandItem> PadLandItems(List<LandItem> landItems)
        {
            var maxX = landItems.Max(x => x.X);
            var maxY = landItems.Max(x => x.Y);
            return PadLandItems(landItems, maxX, maxY, new List<BigInteger>());
        }

        public static List<LandItem> PadLandItems(List<LandItem> landItems, BigInteger maxX, BigInteger maxY, List<BigInteger> yBound)
        {
            for (int x = 0; x <= maxX; x++)
            {
                for (var y = 0; y <= maxY; y++)
                {
                    if (!landItems.Any(o => o.X == x && o.Y == y))
                    {
                        if (yBound != null && yBound.Count > x)
                        {
                            if (x < yBound[y])
                            {
                                landItems.Add(new LandItem() { ItemId = 0, X = x, Y = y, StackIndex = 0 });
                            }
                            else
                            {
                                landItems.Add(new LandItem() { ItemId = -1, X = x, Y = y, StackIndex = 0 });
                            }
                        }
                        else
                        {
                            landItems.Add(new LandItem() { ItemId = 0, X = x, Y = y, StackIndex = 0 });
                        }

                    }
                }
            }
            return landItems;
        }

        public static List<List<List<LandItem>>> ConvertTo3dArray(List<LandItem> landItems)
        {

            return landItems.GroupBy(y => y.Y)
                              .OrderBy(y => y.Key)
                                      .Select(yRow =>
                                               yRow.GroupBy(x => x.X)
                                               .OrderBy(x => x.Key).
                                                     Select(xColumn => xColumn.OrderBy(z => z.StackIndex).ToList())
                                     .ToList())
                                .ToList();
        }

        public static List<LandItem> ConvertLand3dToLandItemCollection(List<List<List<LandItemDTO>>> land3d)
        {
            var landItemCollection = new List<LandItem>();
            for (var x = 0; x < land3d.Count; x++)
            {
                var xRow = land3d[x];
                for (var y = 0; y < xRow.Count; y++)
                {
                    var yRow = xRow[y];
                    for (var z = 0; z < yRow.Count; z++)
                    {
                        landItemCollection.Add(LandItemMapping.MapToLandItemModel(yRow[z]));
                    }
                }
            }
            return landItemCollection;
        }


        public static List<LandItem> ConvertLand3dToLandItemCollection(List<List<List<LandItem>>> land3d)
        {
            var landItemCollection = new List<LandItem>();
            for (var x = 0; x < land3d.Count; x++)
            {
                var xRow = land3d[x];
                for (var y = 0; y < xRow.Count; y++)
                {
                    var yRow = xRow[y];
                    for (var z = 0; z < yRow.Count; z++)
                    {
                        landItemCollection.Add(yRow[z]);
                    }
                }
            }
            return landItemCollection;
        }

        public static async Task<BigInteger> GetFirstLandIdFromOwnerAsync(IWeb3 web3, string playerAddress, string landNFTAddress)
        {
            var landNFTsService = new LandNFTsService(web3, landNFTAddress);
            var tokensBalances = await landNFTsService.BalanceOfQueryAsync(playerAddress);
            if (tokensBalances != 0)
            {
                var firstLandId = await landNFTsService.TokenOfOwnerByIndexQueryAsync(playerAddress, 0);
                return firstLandId;
            }
            throw new Exception("No land found for address");
        }

        public async Task<List<InventoryItem>> GetAllInventoryItemsFromTableRepositoryAsync(ITableRepository tableRepository, BigInteger landId)
        {
            var inventoryItemsRecords = await Tables.Inventory.GetTableRecordsAsync(tableRepository);
           
            var inventoryItemsList = new List<InventoryItem>();
            foreach (var inventoryItem in inventoryItemsRecords)
            {
                if (inventoryItem.Keys.LandId == landId)
                {
                    inventoryItemsList.Add(new InventoryItem()
                    {
                        ItemId = inventoryItem.Keys.Item,
                        Count = inventoryItem.Values.Quantity
                    });
                }
            }
            return inventoryItemsList;
        }
    }

}

   

