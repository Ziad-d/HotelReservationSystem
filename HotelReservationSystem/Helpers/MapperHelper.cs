using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ExaminationSystem.Helpers
{
    public static class MapperHelper
    {
        public static IMapper Mapper { get; set; }

        public static IEnumerable<TDest> Map<TDest>(this IQueryable source)
        {
            return source.ProjectTo<TDest>(Mapper.ConfigurationProvider);
        }

        public static TDest MapOne<TDest>(this object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public static TDest MapOne<TDest>(this object source, TDest destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}
