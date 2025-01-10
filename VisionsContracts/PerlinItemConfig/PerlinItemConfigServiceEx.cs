using Nethereum.ABI.EIP712.EIP2612;
using Nethereum.ABI.EIP712;
using Nethereum.Model;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Items;
using VisionsContracts.Items.Model;
using VisionsContracts.LandPlacingStrategies;
using VisionsContracts.PerlinItemConfig.ContractDefinition;

namespace VisionsContracts.PerlinItemConfig
{

    public class DistributedItems
    {
        public static List<DistributedItem> GetDistributedItems()
        {
            return new List<DistributedItem>
            {
                new DistributedItem { Id = DefaultItems.Trees.BANANA_TREE.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Trees.SUGAR_TREE.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Trees.SIMPLE_TREE.Id, Probability = 0.15 },
                new DistributedItem { Id = DefaultItems.Trees.OLIVE_TREE.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Trees.AVOCADO_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.FUNKY_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.MAPLE_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.PALM_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.ORANGE_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.CACAO_TREE.Id, Probability = 0.3 },
                //new DistributedItem { Id = DefaultItems.Trees.WISHY_WASHY_TREE.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Bushes.RASPBERRY_BUSH.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Bushes.COFFEE_BUSH.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Grass.GRASS_WHEAT.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Grass.GRASS_TOMATO.Id, Probability = 0.3 },
                new DistributedItem { Id = DefaultItems.Grass.GRASS_SALAD.Id, Probability = 0.3 },
                
                
                new DistributedItem { Id = DefaultItems.Animals.COW.Id, Probability = 0.5 },
                new DistributedItem { Id = DefaultItems.Animals.CHICKEN.Id, Probability = 0.6 },
                //new DistributedItem { Id = DefaultItems.Animals.LADY_BUG.Id, Probability = 0.3 },

               
                new DistributedItem { Id = DefaultItems.RawMaterials.CRYSTAL.Id, Probability = 0.7 },
                new DistributedItem { Id = DefaultItems.RawMaterials.STICKS.Id, Probability = 0.55 },
                new DistributedItem { Id = DefaultItems.RawMaterials.BISMUTH.Id, Probability = 0.95 },
                new DistributedItem { Id = DefaultItems.RawMaterials.BLACK_TRAPEZOID.Id, Probability = 0.15 },
                new DistributedItem { Id = DefaultItems.RawMaterials.CLAY.Id, Probability = 0.8 },
                

            };
        }
    }
  
    public class DistributedItem
    {
        public int Id { get; set; }
        public double Probability { get; set; }
    }

    /// <summary>
    /// The ItemDistributor class is designed to distribute a list of items across multiple groups, 
    /// considering each item's probability and pre-defined Perlin ID priority ranges. 

    /// DistributedItem Class: This class represents an item with an Id and Probability.The GetDistributedItems method provides a list of these items.
     ///ItemDistributor Class: Responsible for distributing items across groups based on their probabilities and predefined Perlin ID priority ranges.

    /// High, Middle, Low Priority Perlin IDs:
    /// Inputs are categorized based on their probability into high, middle, and low priority groups.
    /// Each group is associated with specific Perlin IDs (high: 12, 13, 14, 15; middle: 11, 10, 16, 17; low: remaining IDs).

    ///Distribution Process: The class first sorts items in descending order of their probability.
    ///It then distributes items to groups, starting with high-priority items.
    ///The number of items assigned to each priority range is equal to the count of Perlin IDs in that range.
    ///Inputs that can't be assigned to the current group due to all suitable Perlin IDs being taken are queued for priority assignment in the next group.
    ///DistributeItemsByPriority Method: This method handles the assignment of items to groups.
    ///It first tries to assign items from the queue of unassigned items (nextGroupPriorityItems).
    ///If an item is successfully assigned, it's removed from the queue. Otherwise, the item is enqueued for the next group.

    ///Ensuring Unique Assignments within a Group:
    ///The method ensures that no item is assigned the same Perlin ID more than once within a group by using a HashSet for each group to track assigned Perlin IDs.
    ///This implementation ensures a balanced distribution of items across groups according to their probabilities,
    /// with priority given to higher-probability items and unique Perlin ID assignments within each group.
    /// Unassigned items in one group are given precedence in subsequent groups, ensuring all items are eventually distributed.
    /// </summary>
    public class ItemDistributor
    {
        private readonly List<DistributedItem> _items;
        private readonly int _numberOfGroups;
        private readonly List<int> _highPriorityPerlinIds = new List<int> { 12, 13, 14, 15 };
        private readonly List<int> _middlePriorityPerlinIds = new List<int> { 11, 10, 16, 17 };
        private readonly List<int> _lowPriorityPerlinIds; // Remaining Perlin IDs

        public ItemDistributor(List<DistributedItem> items, int numberOfGroups, int perlinValueStart, int perlinValueEnd)
        {
            _items = items.OrderByDescending(item => item.Probability).ToList();
            _numberOfGroups = numberOfGroups;
            _lowPriorityPerlinIds = Enumerable.Range(perlinValueStart, perlinValueEnd - perlinValueStart + 1)
                                              .Except(_highPriorityPerlinIds)
                                              .Except(_middlePriorityPerlinIds)
                                              .ToList();
        }

        public List<PerlinConfig> DistributeItemsAcrossGroups()
        {
            var groupConfigs = new List<PerlinConfig>[_numberOfGroups];
            var assignedPerlinIds = new HashSet<int>[_numberOfGroups];
            for (int i = 0; i < _numberOfGroups; i++)
            {
                groupConfigs[i] = new List<PerlinConfig>();
                assignedPerlinIds[i] = new HashSet<int>();
            }

            // Distribute items by priority, starting with high-priority items
            DistributeItemsByPriority(_items.Take(_highPriorityPerlinIds.Count), _highPriorityPerlinIds, groupConfigs, assignedPerlinIds);  // Distribute high priority items, we only take the first 4 items as we have 4 high priority perlin ids
            DistributeItemsByPriority(_items.Skip(_highPriorityPerlinIds.Count).Take(_middlePriorityPerlinIds.Count), _middlePriorityPerlinIds, groupConfigs, assignedPerlinIds);  // Distribute middle priority items
            DistributeItemsByPriority(_items.Skip(_highPriorityPerlinIds.Count + _middlePriorityPerlinIds.Count), _lowPriorityPerlinIds, groupConfigs, assignedPerlinIds);  //distibute low priority items


            return groupConfigs.SelectMany(group => group).ToList();
        }

        private void DistributeItemsByPriority(IEnumerable<DistributedItem> items, List<int> perlinIds, List<PerlinConfig>[] groupConfigs, HashSet<int>[] assignedPerlinIds)
        {
            var nextGroupPriorityItems = new Queue<DistributedItem>(); // Inputs that couldn't be assigned to the current group
            foreach (var groupId in Enumerable.Range(0, _numberOfGroups))
            {
                for(int i = 0; i < nextGroupPriorityItems.Count; i++) // Try to assign items from the queue first
                {
                    var nextGroupPriorityItem = nextGroupPriorityItems.Peek();
                    var availablePerlinIds = perlinIds.Where(id => !assignedPerlinIds[groupId].Contains(id)).ToList();
                    if (availablePerlinIds.Any())
                    {
                        int perlinId = availablePerlinIds.First(); // Prioritize unassigned Perlin IDs
                        groupConfigs[groupId].Add(new PerlinConfig
                        {
                            GroupId = (uint)(groupId + 1), // Group IDs are 1-indexed for smart contract compatibility
                            PerlinId = (uint)perlinId,
                            ItemId = nextGroupPriorityItem.Id
                        });
                        assignedPerlinIds[groupId].Add(perlinId);
                        nextGroupPriorityItems.Dequeue(); // Remove the item from the queue
                    }
                }
                items = items.Reverse(); // Reverse the order of items to flip priority on items with the same probability
                items = items.OrderByDescending(item => item.Probability).ToList(); // Sort items by probability again
                foreach (var item in items) // Assign items to the current group
                {
                    if (groupConfigs[groupId].Any(x => x.ItemId == item.Id))
                    {
                        continue;
                    }
                    var availablePerlinIds = perlinIds.Where(id => !assignedPerlinIds[groupId].Contains(id)).ToList(); // Exclude assigned Perlin IDs
                    if (availablePerlinIds.Any()) 
                    {
                        int perlinId = availablePerlinIds.First(); // Prioritize unassigned Perlin IDs
                        groupConfigs[groupId].Add(new PerlinConfig
                        {
                            GroupId = (uint)(groupId + 1), // Group IDs are 1-indexed for smart contract compatibility
                            PerlinId = (uint)perlinId,
                            ItemId = item.Id
                        });
                        assignedPerlinIds[groupId].Add(perlinId);
                    }
                    else
                    {
                        nextGroupPriorityItems.Enqueue(item); // Enqueue the item for the next group as there are no available Perlin IDs
                    }
                }
            }
        }
    }

    public partial class PerlinItemConfigService
    {

        public Task<string> InitialisePerlinMappingsRequestAsync()
        {
            var mappings = GetMappings();
            return SetItemsRequestAsync(
                    mappings
              );
        }

        public static List<PerlinConfig> GetMappings()
        {
            var items = DistributedItems.GetDistributedItems();
            var distributor = new ItemDistributor(items, 6, 7, 20);
            return distributor.DistributeItemsAcrossGroups();
        }

        public List<PerlinConfig> GetMappingsOld() 
        {
            return new List<PerlinConfig>()
            { 

                new PerlinConfig() { GroupId=1, PerlinId = 0, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 1, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 2, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 3, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 4, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 5, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 6, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 7, ItemId =  DefaultItems.Trees.BANANA_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 8, ItemId =  DefaultItems.RawMaterials.BISMUTH.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 9, ItemId =  DefaultItems.Trees.BIG_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 10, ItemId = DefaultItems.Grass.GRASS_TOMATO.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 11, ItemId = DefaultItems.Grass.GRASS_SALAD.Id  },
                new PerlinConfig() { GroupId=1, PerlinId = 12, ItemId = DefaultItems.Grass.GRASS_WHEAT.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 13, ItemId = DefaultItems.RawMaterials.BISMUTH.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 14, ItemId = DefaultItems.Trees.OLIVE_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 15, ItemId = DefaultItems.Trees.BIG_TREE.Id } ,
                new PerlinConfig() { GroupId=1, PerlinId = 16, ItemId = DefaultItems.Trees.BANANA_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 17, ItemId = DefaultItems.Grass.GRASS_TOMATO.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 18, ItemId = DefaultItems.Trees.SIMPLE_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 19, ItemId = DefaultItems.Grass.GRASS_SALAD.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 20, ItemId = DefaultItems.Grass.GRASS_WHEAT.Id},
                new PerlinConfig() { GroupId=1, PerlinId = 21, ItemId = DefaultItems.Trees.OLIVE_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 22, ItemId = DefaultItems.Trees.BANANA_TREE.Id },
                new PerlinConfig() { GroupId=1, PerlinId = 23, ItemId = 0},
                new PerlinConfig() { GroupId=1, PerlinId = 24, ItemId = 0 },
                new PerlinConfig() { GroupId=1, PerlinId = 25, ItemId = 0 },


                new PerlinConfig() { GroupId=2, PerlinId = 0, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 1, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 2, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 3, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 4, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 5, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 6, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 7, ItemId = DefaultItems.RawMaterials.BLACK_TRAPEZOID.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 8, ItemId =  DefaultItems.Animals.CHICKEN.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 9, ItemId =  DefaultItems.RawMaterials.CRYSTAL.Id  },
                new PerlinConfig() { GroupId=2, PerlinId = 10, ItemId = DefaultItems.Animals.COW.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 11, ItemId = DefaultItems.Animals.CHICKEN.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 12, ItemId = DefaultItems.RawMaterials.CRYSTAL.Id  },
                new PerlinConfig() { GroupId=2, PerlinId = 13, ItemId = DefaultItems.Bushes.COFFEE_BUSH.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 14, ItemId = DefaultItems.Bushes.RASPBERRY_BUSH.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 15, ItemId = DefaultItems.RawMaterials.STICKS.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 16, ItemId = DefaultItems.RawMaterials.CLAY.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 17, ItemId = DefaultItems.RawMaterials.CRYSTAL.Id  },
                new PerlinConfig() { GroupId=2, PerlinId = 18, ItemId = DefaultItems.RawMaterials.BLACK_TRAPEZOID.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 19, ItemId = DefaultItems.Animals.COW.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 20, ItemId = DefaultItems.Bushes.RASPBERRY_BUSH.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 21, ItemId = DefaultItems.Bushes.COFFEE_BUSH.Id },
                new PerlinConfig() { GroupId=2, PerlinId = 22, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 23, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 24, ItemId = 0 },
                new PerlinConfig() { GroupId=2, PerlinId = 25, ItemId = 0 },



            };
        
        }


    }
}
