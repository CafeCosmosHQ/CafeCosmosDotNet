using System.Collections.Generic;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Transformations.Model
{
    public abstract class TransformationCategoryList<T> : ITransformationCategoryList where T : TransformationCategoryList<T>, new()
    {
        public static T Instance { get; private set; } = new T();
        public abstract List<Transformation> GetAllTransformations();
    }

}
