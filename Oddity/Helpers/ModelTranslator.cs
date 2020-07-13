using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Oddity.Models;

namespace Oddity.Helpers
{
    public static class ModelTranslator
    {
        private static Dictionary<string, string> _map;

        static ModelTranslator()
        {
            InitializeMap();
        }

        public static string Map(string key)
        {
            return _map[key];
        }

        private static void InitializeMap()
        {
            _map = new Dictionary<string, string>();

            var assembly = typeof(ModelTranslator).GetTypeInfo().Assembly;
            var modelBaseClasses = assembly.DefinedTypes.Where(p => p.IsSubclassOf(typeof(ModelBase)));

            foreach (var modelBaseClass in modelBaseClasses)
            {
                var properties = modelBaseClass.DeclaredProperties;
                foreach (var property in properties)
                {
                    var jsonPropertyAttribute = property.CustomAttributes
                        .FirstOrDefault(p => p.AttributeType == typeof(JsonPropertyAttribute));

                    if (jsonPropertyAttribute != null && jsonPropertyAttribute.ConstructorArguments.Count > 0)
                    {
                        _map[property.Name] = (string)jsonPropertyAttribute.ConstructorArguments[0].Value;
                    }
                    else
                    {
                        _map[property.Name] = property.Name.ToLower();
                    }
                }
            }
        }
    }
}
