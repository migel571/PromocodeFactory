using AutoMapper;
using PromocodeFactory.Infrastructure.Pagging;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>> where TSource : class where TDestination : class
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
        {
            var collection = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source).ToList();

            return new PagedList<TDestination>(collection, source.TotalCount, source.CurrentPage, source.PageSize);
        }
    }
}
