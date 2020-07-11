namespace Oddity.API.Models
{
    public abstract class ModelBase
    {
        protected OddityCore Context { get; set; }

        public void SetContext(OddityCore context)
        {
            Context = context;
        }
    }
}
