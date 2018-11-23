using rule.engine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rule.engine
{
    public class Feature : IFeature
    {
        public string Name { get; set; }

        public IList<IRuleset> Rulesets { get; set; }

        public Feature(string name)
        {
            Name = name;
            Rulesets = new List<IRuleset>();
        }

        public bool AppliesTo(string name)
        {
            return Equals(name, Name);
        }

        public bool Licensable(IList<File> files, IList<Process> processes)
        {
            return Rulesets.Any(set => set.AppliesTo(files, processes));
        }
    }
}
