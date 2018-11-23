using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.Interfaces
{
    public interface IRuleset
    {
        IList<Func<File, bool>> FileConditionals { get; set; }
        IList<Func<Process, bool>> ProcessConditionals { get; set; }

        bool AppliesTo(IList<File> files, IList<Process> processes);
    }
}
