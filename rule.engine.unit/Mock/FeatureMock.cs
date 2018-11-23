using rule.engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.unit.Mock
{
    public class FeatureMock : IFeature
    {
        public bool ApplicableMock { get; set; }
        public bool LicensableMock { get; set; }
        public string Name { get; set; }

        public IList<IRuleset> Rulesets { get; set; }

        public bool AppliesTo(string name)
        {
            return ApplicableMock;
        }

        public bool Licensable(IList<File> files, IList<Process> processes)
        {
            return LicensableMock;
        }
    }
}
