using TestTaskBE.BusinessLogic.Interfaces.Mappings;

namespace TestTaskBE.BusinessLogic.Interfaces.Factories
{
    public interface IMapperFactory
    {
        IMapper<TFrom, TTo> GetMapper<TFrom, TTo>()
            where TFrom : class, new()
            where TTo : class, new();
    }
}
