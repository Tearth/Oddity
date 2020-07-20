namespace Oddity.Models
{
    /// <summary>
    /// Base interface for all models containing its own ID.
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Gets or sets the model ID.
        /// </summary>
        string Id { get; set; }
    }
}
