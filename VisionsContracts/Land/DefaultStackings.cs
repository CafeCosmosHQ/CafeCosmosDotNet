using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VisionsContracts.Items;
using VisionsContracts.Land.Model;
using static VisionsContracts.Items.DefaultItems;
using Lettuce = VisionsContracts.Items.DefaultItems.Lettuce;
using Tomato = VisionsContracts.Items.DefaultItems.Tomato;
using Wheat = VisionsContracts.Items.DefaultItems.Wheat;

namespace VisionsContracts.Land
{
    public class DefaultStackings
    {
        public static List<Stacking> GetAllStackableItems()
        {
            return GetSoilStackings()
                .Concat(GetCounterStackings())
                .Concat(GetFloorStackings())
                .ToList();
        }

        public static List<Stacking> GetSoilStackings()
        {
            return new List<Stacking>()
            {
                            SoilTomatoSeedStacking,
                            SoilWheatSeedStacking,
                            SoilLettuceSeedStacking
            };
        }

        public static List<Stacking> GetCounterStackings()
        {
            var counterStackableItems = DefaultItems.GetCounterStackableItems();
            var counters = DefaultItems.GetCounters();
            var counterStackings = new List<Stacking>();
            foreach (var counter in counters)
            {
                foreach (var stackableItem in counterStackableItems)
                {
                    counterStackings.Add(new Stacking { Base = counter.Id, Input = stackableItem.Id });   
                }
            }
            return counterStackings;
        }

        public static List<Stacking> GetFloorStackings()
        {
            var floorStackableItems = DefaultItems.GetFloorStackableItems();
            var floors = DefaultItems.GetFloors();
            var floorStackings = new List<Stacking>();
            foreach (var floor in floors)
            {
                foreach (var stackableItem in floorStackableItems)
                {
                    floorStackings.Add(new Stacking { Base = floor.Id, Input = stackableItem.Id });
                }
            }
            return floorStackings;
        }

        public static bool IsStackable(BigInteger baseItemId, BigInteger inputItemId)
        {
            return FindStackable(baseItemId, inputItemId) != null;
        }

        public static Stacking FindStackable(BigInteger baseItemId, BigInteger inputItemId)
        {
            return GetAllStackableItems().FirstOrDefault(x => x.Input == inputItemId && x.Base == baseItemId);
        }

        public static readonly Stacking SoilTomatoSeedStacking = new Stacking { Base = Gardening.TILLED_SOIL.Id, Input = Tomato.TOMATO_SEED.Id };
        public static readonly Stacking SoilWheatSeedStacking = new Stacking { Base = Gardening.TILLED_SOIL.Id, Input = Wheat.WHEAT_SEED.Id };
        public static readonly Stacking SoilLettuceSeedStacking = new Stacking { Base = Gardening.TILLED_SOIL.Id, Input = Lettuce.LETTUCE_SEED.Id };
        

    }

}
