namespace Szakdoga.Common.Mappers
{
    /// <summary>
    /// Maps between <typeparamref name="TModel"/> and<typeparamref name="TDto"/>.
    /// </summary>
    /// <typeparam name="TModel">The modelType.</typeparam>
    /// <typeparam name="TDto">The Dto</typeparam>
    public interface IMapper<TModel, TDto>
    {
        /// <summary>
        /// Maps from Model to Dto.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <returns>The output dto.</returns>
        public TDto? MapToDto(TModel? model);

        /// <summary>
        /// Maps from Dto to model.
        /// </summary>
        /// <param name="dto">The input dto.</param>
        /// <returns>The converted <typeparamref name="TModel"/>.</returns>
        public TModel? MapToModel(TDto? dto);

        /// <summary>
        /// Maps from Dto to model and with reference.
        /// </summary>
        /// <param name="dto">The input dto.</param>
        /// <param name="reference">The converted <typeparamref name="TModel"/>.</param>
        /// <returns></returns>
        public TModel? MapToModel(TDto? dto, TModel? reference);

    }
}
