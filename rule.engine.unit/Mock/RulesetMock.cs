using rule.engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.unit.Mock
{
    public class RulesetMock : IRuleset
    {
        public bool ApplicableMock { get; set; }

        public IList<Func<File, bool>> FileConditionals { get; set; }
        public IList<Func<Process, bool>> ProcessConditionals { get; set; }

        public bool AppliesTo(IList<File> files, IList<Process> processes)
        {
            return ApplicableMock;
        }
    }
}
