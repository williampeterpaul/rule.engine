using System.Configuration;

namespace rule.engine
{
    public class FeatureElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RulesetElementCollection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RulesetElementCollection)element).Name;
        }

        protected override string ElementName
        {
            get
            {
                return "feature";
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName == "feature";
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        public RulesetElementCollection this[int index]
        {
            get
            {
                return BaseGet(index) as RulesetElementCollection;
            }
        }

        public new RulesetElementCollection this[string key]
        {
            get
            {
                return BaseGet(key) as RulesetElementCollection;
            }
        }
    }
}
