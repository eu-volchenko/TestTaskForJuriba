using System;
using System.Linq;
using TestTaskBE.BusinessLogic.Interfaces.Factories;
using TestTaskBE.BusinessLogic.Interfaces.Mappings;

namespace TestTaskBE.BusinessLogic.Factories
{
    public class MapperFactory : IMapperFactory
    {
        public IMapper<TFrom, TTo> GetMapper<TFrom, TTo>()
            where TFrom : class, new()
            where TTo : class, new()
        {
            var type = typeof(IMapper<TFrom, TTo>);

            var neededType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(p => type.IsAssignableFrom(p));
            
            return (IMapper<TFrom, TTo>)Activator.CreateInstance(neededType);
        }
    }
}
