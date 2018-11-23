using System.Configuration;

namespace rule.engine
{
    public class FeatureSection : ConfigurationSection
    {
        [ConfigurationProperty("featureCollection", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
        public FeatureElementCollection Features
        {
            get
            {
                return base["featureCollection"] as FeatureElementCollection;
            }
        }
    }
}
