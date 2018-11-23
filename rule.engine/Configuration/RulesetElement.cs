using System.Configuration;

namespace rule.engine
{
    public class RulesetElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public int Id
        {
            get
            {
                return (int)base["id"];
            }
        }

        [ConfigurationProperty("file", IsDefaultCollection = false)]
        public RuleElementCollection FileRules
        {
            get
            {
                return this["file"] as RuleElementCollection;
            }
        }

        [ConfigurationProperty("process", IsDefaultCollection = false)]
        public RuleElementCollection ProcessRules
        {
            get
            {
                return this["process"] as RuleElementCollection;
            }
        }
    }
}
