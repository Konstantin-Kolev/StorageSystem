using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StorageSystem.Services.Mappings
{
    public static class MappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(AutoMapperConfig.MapperInstance.ConfigurationProvider, null, membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(AutoMapperConfig.MapperInstance.ConfigurationProvider, parameters);
        }

        public static Destination To<Destination>(this object source) =>
            AutoMapperConfig.MapperInstance.Map<Destination>(source);
    }
}
