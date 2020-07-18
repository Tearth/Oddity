using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oddity.Models
{
    public abstract class ModelBase
    {
        protected OddityCore Context { get; set; }

        public void SetContext(OddityCore context)
        {
            Context = context;
            SetContextInNestedObjects(context);
        }

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
