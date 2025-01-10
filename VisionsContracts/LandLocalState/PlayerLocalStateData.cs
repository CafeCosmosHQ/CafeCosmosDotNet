using Nethereum.Mud.TableRepository;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Model;

namespace VisionsContracts.LandLocalState
{
    public class LandLocalStateData
    {
        public InMemoryTableRepository TableRepository { get; set; }
        public string PlayerAddress { get; set; }
        public BigInteger LandId { get; set; }
        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
        public List<LandItem> LandItems { get; set; } = new List<LandItem>();
        public LandInfo LandInfo { get; set; }
        public string LandName { get; set; }

        
    }
}
