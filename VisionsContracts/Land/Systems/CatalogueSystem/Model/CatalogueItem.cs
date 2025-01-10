using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VisionsContracts.Items;
using VisionsContracts.Items.Model;

namespace VisionsContracts.Land.Systems.CatalogueSystem.Model
{

    public class TotalPurchaseCostBalance
    {
        public BigInteger TotalCost { get; set; }
        public Decimal TotalCostInEtherUnit => Web3.Convert.FromWei(TotalCost);
        public BigInteger Balance { get; set; }
        public Decimal BalanceInEtherUnit => Web3.Convert.FromWei(Balance);
    }

  


    public class CatalogueItem
    {
        public BigInteger ItemId { get; set; }
        public BigInteger Price { get; set; }
        public Decimal PriceInMainUnit => Web3.Convert.FromWei(Price);
        public BigInteger CatalogueId { get; set; }
        public bool Exists { get; set; } = true;

        private Item _item;

        public Item Item
        {
            get
            {
                if (_item == null)
                {
                    _item = DefaultItems.FindItemById(ItemId);
                }
                return _item;
            }
        }

        public CatalogueItem()
        {
        }

        public CatalogueItem(BigInteger itemId, decimal priceInMainUnit, BigInteger catalogueId)
        {
            this.ItemId = itemId;
            this.Price = Web3.Convert.ToWei(priceInMainUnit);
            this.CatalogueId = catalogueId;
        }

        public CatalogueItem(Item item, decimal priceInEtherUnit, BigInteger catalogueId)
        {
            this.ItemId = item.Id;
            this.Price = Web3.Convert.ToWei(priceInEtherUnit);
            this.CatalogueId = catalogueId;
        }
    }

    public class Catalogue
    {
        public BigInteger CatalogueId { get; set; }
        public string Name { get; set; }
    }
}
