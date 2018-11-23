using System.Configuration;

namespace rule.engine
{
    public class RuleElementCollection : ConfigurationElementCollection
    {
        public RuleElement this[int index]
        {
            get
            {
                return (RuleElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null) BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        public void Add(RuleElement rule)
        {
            BaseAdd(rule);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement)element).Name;
        }
    }
}
