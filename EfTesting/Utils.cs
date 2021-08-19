using System;
using System.Data.Entity;
using System.Reflection;

namespace EfTesting
{
    public static class Utils
    {
        public static object GetMember(this object obj, string fieldName)
        {
            var field = obj.GetType().BaseType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance );
            object fieldValue = field.GetValue(obj);
            
            return fieldValue;
        }

        public static object GetProperty(this object obj, string propName)
        {
            var field = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            object fieldValue = field.GetValue(obj);

            return fieldValue;
        }

        public static void WriteDebugProvider(this DbContext context)
        {
            var provider = context.GetMember("_internalContext").GetProperty("ProviderName");
            var providerFactory = context.GetMember("_internalContext").GetProperty("ProviderFactory");

            Console.WriteLine("For context {0}", context);
            Console.WriteLine(" - Provider: {0}", provider);
            Console.WriteLine(" - ProviderFactory {0}", providerFactory);
        }
    }
}
