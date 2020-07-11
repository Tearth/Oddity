using System;
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
                var propertyTypeInfo = property.PropertyType.GetTypeInfo();
                if (propertyTypeInfo.IsSubclassOf(typeof(ModelBase)))
                {
                    var underlyingInstance = property.GetMethod.Invoke(this, null);
                    if (underlyingInstance != null)
                    {
                        var baseTypeInfo = propertyTypeInfo.BaseType.GetTypeInfo();
                        var setContextMethod = baseTypeInfo.GetDeclaredMethod("SetContext");
                        setContextMethod.Invoke(underlyingInstance, new object[] { context });
                    }
                }
            }
        }
    }
}
