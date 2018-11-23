using System.Configuration;

namespace rule.engine
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "default")]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("member", IsRequired = true)]
        public string Member
        {
            get
            {
                return this["member"] as string;
            }
        }

        [ConfigurationProperty("target", IsRequired = true)]
        public string Target
        {
            get
            {
                return this["target"] as string;
            }
        }

        [ConfigurationProperty("operator", IsRequired = true)]
        public string Operator
        {
            get
            {
                return this["operator"] as string;
            }
        }
    }
}
