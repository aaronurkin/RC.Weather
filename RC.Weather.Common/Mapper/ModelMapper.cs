using AutoMapper;

namespace RC.Weather.Common.Mapper
{
    /// <summary>
    /// Encapsulates models mapping logic
    /// </summary>
    public class ModelMapper : IModelMapper
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes <see cref="AutoMapper.IMapper"/> instance with injected value
        /// </summary>
        /// <param name="mapper">Injected <see cref="AutoMapper.IMapper"/> instance</param>
        public ModelMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Maps object to a new <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Data source object</param>
        /// <returns>New <typeparamref name="TDestination"/> instance</returns>
        public TDestination Map<TDestination>(object source)
        {
            TDestination result = _mapper.Map<TDestination>(source);
            return result;
        }

        /// <summary>
        /// Maps <typeparamref name="TSource"/> instance to a new <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TSource">The type of a source object</typeparam>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Map source object of type <typeparamref name="TSource"/></param>
        /// <returns>New <typeparamref name="TDestination"/> instance</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            TDestination result = _mapper.Map<TSource, TDestination>(source);
            return result;
        }

        /// <summary>
        /// Maps <typeparamref name="TSource"/> instance to an existing <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TSource">The type of a source object</typeparam>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Map source object of type <typeparamref name="TSource"/></param>
        /// <param name="destination">An instance of type <typeparamref name="TDestination"/></param>
        /// <returns><typeparamref name="TDestination"/> instance</returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination result = _mapper.Map(source, destination);
            return result;
        }
    }
}
