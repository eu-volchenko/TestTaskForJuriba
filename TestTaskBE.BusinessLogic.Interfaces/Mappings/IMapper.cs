using System.Collections.Generic;

namespace TestTaskBE.BusinessLogic.Interfaces.Mappings
{
    public interface IMapper<TFrom, TTo> where TFrom : class, new()
            where TTo : class, new()
    {
        List<TTo> Map(TFrom dataToMap);
    }
}
