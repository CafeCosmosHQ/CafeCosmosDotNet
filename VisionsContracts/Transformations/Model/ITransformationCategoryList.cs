using System.Collections.Generic;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Transformations.Model
{
    public interface ITransformationCategoryList
    {
        List<Transformation> GetAllTransformations();
    }

}
