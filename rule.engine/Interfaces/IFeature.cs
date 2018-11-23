using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.Interfaces
{
    public interface IFeature
    {
        string Name { get; set; }

        IList<IRuleset> Rulesets { get; set; }

        bool AppliesTo(string name);
        bool Licensable(IList<File> files, IList<Process> processes);
    }
}
