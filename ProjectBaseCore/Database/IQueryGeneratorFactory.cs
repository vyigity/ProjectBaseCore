namespace ProjectBaseCore.Database
{
    public interface IQueryGeneratorFactory
    {
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object.
        /// </summary>
        IQueryGenerator GetDbObject();
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with provider.
        /// </summary>
        IQueryGenerator GetDbObject(ParameterMode ParameterProcessingMode);
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with parameter processing mode.
        /// </summary>
        IQueryGenerator GetDbObject(Provider provider);
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with provider and parameter processing mode.
        /// </summary>
        IQueryGenerator GetDbObject(Provider provider, ParameterMode ParameterProcessingMode);
    }
}