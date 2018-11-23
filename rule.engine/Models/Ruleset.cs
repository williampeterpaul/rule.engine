using rule.engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rule.engine
{
    public class Ruleset : IRuleset
    {
        public IList<Func<File, bool>> FileConditionals { get; set; }
        public IList<Func<Process, bool>> ProcessConditionals { get; set; }

        public Ruleset()
        {
            FileConditionals = new List<Func<File, bool>>();
            ProcessConditionals = new List<Func<Process, bool>>();
        }

        private bool AppliesTo(IList<File> files)
        {
            return FileConditionals.All(conditional => files.Any(file => conditional(file) == true));
        }

        private bool AppliesTo(IList<Process> processes)
        {
            return ProcessConditionals.All(conditional => processes.Any(process => conditional(process) == true));
        }

        public bool AppliesTo(IList<File> files, IList<Process> processes)
        {
            return AppliesTo(files) && AppliesTo(processes);
        }
    }
}
