namespace DataGenerator
{
    /// <summary>
    /// An <see langword="interface"/> for generating data from a source
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>A new value from the data source.</returns>
        object NextValue(IGenerateContext generateContext);
    }
}
