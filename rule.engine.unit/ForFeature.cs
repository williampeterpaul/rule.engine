using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rule.engine.Interfaces;
using rule.engine.unit.Mock;

namespace rule.engine.unit
{
    [TestClass]
    public class ForFeature
    {
        public IFeature Feature { get; set; }

        public ForFeature()
        {
            Feature = new Feature("Fake");
        }

        [TestMethod]
        public void Should_Assert_Licensable_When_One_Of_Many_Rulesets_Apply()
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

            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = true });
            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = false });
            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = false });

            actual = Feature.Licensable(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Not_Licensable_When_No_Rulesets_Apply()
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

            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = false });
            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = false });
            Feature.Rulesets.Add(new RulesetMock { ApplicableMock = false });

            actual = Feature.Licensable(fakeFiles, fakeProcesses);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Applicable_When_Name_Identical()
        {
            bool expected = true;
            bool actual;

            actual = Feature.AppliesTo("Fake");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Assert_Not_Applicable_When_Name_Not_Identical()
        {
            bool expected = false;
            bool actual;

            actual = Feature.AppliesTo("Not Identical");

            Assert.AreEqual(expected, actual);
        }
    }
}
