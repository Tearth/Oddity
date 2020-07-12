using System.Collections.Generic;
using System.Reflection;

namespace Oddity.API.Models
{
    public abstract class ModelBase
    {
        protected OddityCore Context { get; set; }

        public void SetContext(OddityCore context)
        {
            Context = context;
            SetContextInNestedObjects(context);
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
