using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using rule.engine.Configuration;
using rule.engine.Interfaces;

namespace rule.engine
{
    public class Program
    {
        public static void Main()
        {
            IConfigurator configurator = new Configurator();

            var features = configurator.GetFeatures();

            var fakeFileList = new List<File>
            {
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "Name", Extension = "Extension"},
                new File {Name = "test", Extension = "exe"},
            };

            var fakeProcList = new List<Process>
            {
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
                new Process {Name = "Name", Modules = "Modules"},
            };

            var licensable = features.Where(feature => feature.Licensable(fakeFileList, fakeProcList)).Select(feature => feature.Name).ToList();

            foreach (var item in licensable)
            {
                Console.WriteLine(item);
            }
        }

    }
}
