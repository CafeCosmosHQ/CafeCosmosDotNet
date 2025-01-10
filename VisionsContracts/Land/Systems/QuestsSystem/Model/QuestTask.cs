using Nethereum.ABI;
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Mud.Contracts.World.ContractDefinition;
using Nethereum.RLP;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VisionsContracts.CraftingSystem.Model;
using VisionsContracts.Items;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.CraftingSystem;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Land.Systems.QuestsSystem.ContractDefinition;
using VisionsContracts.Transformations;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{
    public enum TaskType
    {
        Craft = 0, //craft something
        Transform = 1, // transform something or transform category (ie multiple things like cooking in an oven, any oven)
        Collect = 2, // remove something from land
        Stack = 3 // place a seed onto soil
    }

    public class QuestTask
    {
        public static readonly string CategoryType = Nethereum.Util.Sha3Keccack.Current.CalculateHash("category");

        private string _taskIdHex;
        public string TaskIdHex
        {
            get
            {
                if(_taskIdHex == null)
                {
                    _taskIdHex = TaskId.ToHex();
                   
                }
                return _taskIdHex;
            }
        }

        public string Name { get; set; } = string.Empty;

        //The task id is the hash of the quest id, the task type and the key 
        //this way we can find the task in the quest by just knowing the quest id and the task type and the hash of the TaskAction
        //for example if crating something with will be able to find an active quest, quest task by just knowing the quest id and the key of the item being crafted
        public byte[] TaskId { get; set; }
        public BigInteger QuestId { get; set; }

        //The type of the task, for example crafting, transforming, collecting, placing
        public BigInteger TaskType { get; set; }

        //The combined key of the task, for example the key of the item being crafted, transformed, collected, placed, this will be a hash or a unique identifier (depending the task type and the size of the key)
        //for example a transformation will have multiple keys, the base and the input
        public byte[] Key { get; set; }

        //The quantity of the task, for example the quantity of the item being crafted, transformed, collected, placed
        public BigInteger Quantity { get; set; }

        //The keys of the tasks, for example the keys of the items being crafted, transformed, collected, placed
        //for example a transformation will have multiple keys, the base and the input
        //and crafting will have only the output id, this way we should be able to find either the transformation, crafting etc using these keys
        //and the task type
        public List<byte[]> TaskKeys { get; set; }

        public bool Exists { get; set; }
        public void SetTaskType(TaskType taskType)
        {
            TaskType = (int)taskType;
        }

        public bool IsCraftingTask()
        {
            return GetTaskType() == Model.TaskType.Craft;
        }

        public bool IsTransformingTask()
        {
            return GetTaskType() == Model.TaskType.Transform && !IsTransformingCategoryTask();
        }

        public bool IsTransformingCategoryTask()
        {
            return GetTaskType() == Model.TaskType.Transform && TaskKeys.First().ToHex() == CategoryType;
        }

        public bool IsStackingTask()
        {
            return GetTaskType() == Model.TaskType.Stack;
        }

        public bool IsCollectingTask()
        {
            return GetTaskType() == Model.TaskType.Collect;
        }

        public object GetTaskRequirement()
        {
            if (GetTaskType() == Model.TaskType.Craft)
            {
               return DefaultCraftingRecipes.FindByOutput(new IntType("uint256").Decode<int>(TaskKeys.First()));
            }

            if (GetTaskType() == Model.TaskType.Transform)
            {
                var firstKey = TaskKeys.First();
                if (firstKey.ToHex() == CategoryType)
                {
                    return DefaultTransformationCategories.FindCategory(new IntType("uint256").Decode<int>(TaskKeys.Last()));
                }
                else
                {
                    var baseId = new IntType("uint256").Decode<int>(TaskKeys.First());
                    var inputId = new IntType("uint256").Decode<int>(TaskKeys.Last());
                    return DefaultTransformations.FindTransformation(baseId, inputId);
                }
            }
            if (GetTaskType() == Model.TaskType.Stack)
            {
                var baseId = new IntType("uint256").Decode<int>(TaskKeys.First());
                var inputId = new IntType("uint256").Decode<int>(TaskKeys.Last());
                return DefaultStackings.FindStackable(baseId, inputId);
            }
            if (GetTaskType() == Model.TaskType.Collect)
            {
                var itemId = new IntType("uint256").Decode<int>(TaskKeys.First());
                return DefaultItems.FindItemById(itemId);
            }
            
            return null;
        }

        public TaskType GetTaskType()
        {
            return (TaskType)(int)TaskType;
        }

        public void InitialiseTaskKey()
        {
            TaskId = CreateQuestTaskKey();
            _taskIdHex = TaskId.ToHex();
        }

        public byte[] CreateQuestTaskKey()
        {
            return new ABIEncode().GetSha3ABIEncoded(
                 new ABIValue("uint256", QuestId),
                 new ABIValue("uint256", TaskType),
                 new ABIValue("bytes32", Key));
        }


        public QuestTask(BigInteger questId, Transformation transformation, BigInteger quantity, bool exists = true)
        {
            QuestId = questId;
            TaskType = (int)Model.TaskType.Transform;
            Key = GetTransformationKey(transformation);
            TaskKeys = new List<byte[]>() { 
                new IntType("uint256").Encode(transformation.Base),
                new IntType("uint256").Encode(transformation.Input)
            };
            Quantity = quantity;
            InitialiseTaskKey();
             Exists = exists;
        }

        public QuestTask(BigInteger questId, TransformationCategory transformationCategory, BigInteger quantity, bool exists = true)
        {
            QuestId = questId;
            TaskType = (int)Model.TaskType.Transform;
            Key = GetTransformationCategoryKey(transformationCategory);
            TaskKeys = new List<byte[]>() {
                CategoryType.HexToByteArray(),
                new IntType("uint256").Encode(transformationCategory.CategoryId)
            };
            Quantity = quantity;
            InitialiseTaskKey();
            Exists = exists;
        }

        public QuestTask(BigInteger questId, Stacking stacking, BigInteger quantity, bool exists = true)
        {
            QuestId = questId;
            TaskType = (int)Model.TaskType.Stack;
            TaskKeys = new List<byte[]>
            {
                new IntType("uint256").Encode(stacking.Base),
                new IntType("uint256").Encode(stacking.Input)
            };
            Key = GetStackingKey(stacking);
           
            Quantity = quantity;
            TaskId = CreateQuestTaskKey();
            InitialiseTaskKey();
            Exists = exists;
        }

        public QuestTask(BigInteger questId, CraftingRecipe craftingRecipe, BigInteger quantity, bool exists = true)
        {
            QuestId = questId;
            TaskType = (int)Model.TaskType.Craft;
            TaskKeys = new List<byte[]>
            {
                new IntType("uint256").Encode(craftingRecipe.Output.Id),
            };
            Key = GetCraftingKey(craftingRecipe);

            Quantity = quantity;
            TaskId = CreateQuestTaskKey();
            InitialiseTaskKey();
            Exists = exists;
        }

        public QuestTask(BigInteger questId, Item collectedItemFromLand, BigInteger quantity, bool exists = true)
        {
            QuestId = questId;
            TaskType = (int)Model.TaskType.Collect;
            TaskKeys = new List<byte[]>
            {
                new IntType("uint256").Encode(collectedItemFromLand.Id),
            };
            Key = GetCollectKey(collectedItemFromLand);

            Quantity = quantity;
            TaskId = CreateQuestTaskKey();
            InitialiseTaskKey();
            Exists = exists;
        }

        public byte[] GetTransformationKey(Transformation transformation)
        {
            return new ABIEncode().GetSha3ABIEncodedPacked(transformation.Base, transformation.Input);
        }

        public byte[] GetStackingKey(Stacking stacking)
        {
            return new ABIEncode().GetSha3ABIEncodedPacked(stacking.Base, stacking.Input);
        }

        public byte[] GetTransformationCategoryKey(TransformationCategory transformationCategory)
        {
            return new ABIEncode().GetSha3ABIEncodedPacked(CategoryType.HexToByteArray(), transformationCategory.CategoryId);
        }

        public byte[] GetCraftingKey(CraftingRecipe craftingRecipe)
        {
            return new Bytes32TypeEncoder().Encode(craftingRecipe.Output.Id);
        }

        public byte[] GetCollectKey(Item item)
        {
            return new Bytes32TypeEncoder().Encode(item.Id);
        }

        public QuestTask()
        {
        }
    }
}



