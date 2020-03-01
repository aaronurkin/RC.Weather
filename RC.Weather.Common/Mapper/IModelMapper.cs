namespace RC.Weather.Common.Mapper
{
    /// <summary>
    /// Defines models mapping logic contract
    /// </summary>
    public interface IModelMapper
    {
        /// <summary>
        /// Maps object to a new <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Data source object</param>
        /// <returns>New <typeparamref name="TDestination"/> instance</returns>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Maps <typeparamref name="TSource"/> instance to a new <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TSource">The type of a source object</typeparam>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Map source object of type <typeparamref name="TSource"/></param>
        /// <returns>New <typeparamref name="TDestination"/> instance</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Maps <typeparamref name="TSource"/> instance to an existing <typeparamref name="TDestination"/> instance
        /// </summary>
        /// <typeparam name="TSource">The type of a source object</typeparam>
        /// <typeparam name="TDestination">The type of a destination object</typeparam>
        /// <param name="source">Map source object of type <typeparamref name="TSource"/></param>
        /// <param name="destination">An instance of type <typeparamref name="TDestination"/></param>
        /// <returns><typeparamref name="TDestination"/> instance</returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
