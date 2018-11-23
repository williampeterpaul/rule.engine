using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rule.engine.Interfaces;

namespace rule.engine.unit
{
    [TestClass]
    public class ForRuleset
    {
        public IRuleset Ruleset { get; set; }

        public ForRuleset()
        {
            Ruleset = new Ruleset();
        }

        [TestMethod]
        public void Should_Assert_Applicable_When_All_Conditionals_Apply()
        {
            bool expected = true;
            bool actual;

            IList<File> fakeFiles = new List<File>
            {
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "Name", Extension = "Extension"},
            };

            IList<Process> fakeProcesses = new List<Process>
            {
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
            };

            Ruleset.FileConditionals = new List<Func<File, bool>> { fileExists => true };
            Ruleset.ProcessConditionals = new List<Func<Process, bool>> { processExists => true };

            actual = Ruleset.AppliesTo(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Not_Applicable_When_No_Conditionals_Apply()
        {
            bool expected = false;
            bool actual;

            IList<File> fakeFiles = new List<File>
            {
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "Name", Extension = "Extension"},
            };

            IList<Process> fakeProcesses = new List<Process>
            {
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
            };

            Ruleset.FileConditionals = new List<Func<File, bool>> { fileExists => false };
            Ruleset.ProcessConditionals = new List<Func<Process, bool>> { processExists => false };

            actual = Ruleset.AppliesTo(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Not_Applicable_When_All_File_Conditionals_Apply_But_Not_All_Process_Conditionals_Apply()
        {
            bool expected = false;
            bool actual;

            IList<File> fakeFiles = new List<File>
            {
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "Name", Extension = "Extension"},
            };

            IList<Process> fakeProcesses = new List<Process>
            {
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
            };

            Ruleset.FileConditionals = new List<Func<File, bool>> { fileExists => true, otherFileExists => true };
            Ruleset.ProcessConditionals = new List<Func<Process, bool>> { processExists => false, otherProcessExits => true };

            actual = Ruleset.AppliesTo(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Not_Applicable_When_All_Process_Conditionals_Apply_But_Not_All_File_Conditionals_Apply()
        {
            bool expected = false;
            bool actual;

            IList<File> fakeFiles = new List<File>
            {
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "Name", Extension = "Extension"},
            };

            IList<Process> fakeProcesses = new List<Process>
            {
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
            };

            Ruleset.FileConditionals = new List<Func<File, bool>> { fileExists => false, otherFileExits => true };
            Ruleset.ProcessConditionals = new List<Func<Process, bool>> { processExists => true, otherProcessExists => true };

            actual = Ruleset.AppliesTo(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }
    }
}
