using System.Collections.Generic;
using VisionsContracts.Items.Model;

namespace VisionsContracts.Items
{
    public interface ICreationCategoryList
    {
        List<ItemCreation> GetAllCreationItems();
    }

    public abstract class CreationCategoryList<T, TItemCategoryList> : ICreationCategoryList 
        where T : CreationCategoryList<T, TItemCategoryList>, new()
        where TItemCategoryList : ItemsCategoryList<TItemCategoryList>, new()
    {
        public static T Instance { get; private set; } = new T();
        public abstract List<ItemCreation> GetAllCreationItems();
    }

}