using System.Configuration;

namespace rule.engine
{
    public class RulesetElementCollection : ConfigurationElementCollection
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RulesetElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RulesetElement)element).Id;
        }

        protected override string ElementName
        {
            get
            {
                return "ruleset";
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName == "ruleset";
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        public RulesetElement this[int index]
        {
            get
            {
                return BaseGet(index) as RulesetElement;
            }
        }

        public new RulesetElement this[string key]
        {
            get
            {
                return BaseGet(key) as RulesetElement;
            }
        }
    }
}
