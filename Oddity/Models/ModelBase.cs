using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oddity.Models
{
    /// <summary>
    /// Represents an abstract class for all models.
    /// </summary>
    public abstract class ModelBase
    {
        protected OddityCore Context { get; set; }

        /// <summary>
        /// Sets the Oddity context used in lazy properties.
        /// </summary>
        /// <param name="context">Oddity context.</param>
        public void SetContext(OddityCore context)
        {
            Context = context;
            SetContextInNestedObjects(context);
        }

        /// <summary>
        /// Makes a shallow copy of all properties into the target model (remember that it's filled, not instantiated again).
        /// </summary>
        /// <param name="target">Target model which will be filled.</param>
        public void CopyTo(ModelBase target)
        {
            foreach (var property in GetType().GetRuntimeProperties().Where(p => p.CanWrite))
            {
                property.SetValue(target, property.GetValue(this, null), null);
            }
        }

        private void SetContextInNestedObjects(OddityCore context)
        {
            foreach (var property in GetType().GetRuntimeProperties())
            {
                if (property.GetValue(this) is ModelBase underlyingInstance)
                {
                    underlyingInstance.SetContext(context);
                }
                else if (property.GetValue(this) is IEnumerable<ModelBase> collection)
                {
                    foreach (var element in collection)
                    {
                        element.SetContext(context);
                    }
                }
            }
        }
    }
}
