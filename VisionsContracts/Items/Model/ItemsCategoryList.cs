using System.Collections.Generic;
using VisionsContracts.Items.Model;


namespace VisionsContracts.Items
{


    public abstract class ItemsCategoryList<T> : IItemsCategoryList where T : ItemsCategoryList<T>, new()
    {
            public static T Instance { get; private set; } = new T();
            public abstract List<Item> GetDefaultItems();
    }


}
