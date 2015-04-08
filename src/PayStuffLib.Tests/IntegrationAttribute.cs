// ReSharper disable once CheckNamespace
namespace NUnit.Framework
{
    public class IntegrationAttribute : CategoryAttribute
    {
        public IntegrationAttribute()
            : this("Integration")
        {

        }

        protected IntegrationAttribute(string category)
            : base(category)
        {

        }
    }
}