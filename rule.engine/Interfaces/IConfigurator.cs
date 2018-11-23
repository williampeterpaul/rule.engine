using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.Interfaces
{
    public interface IConfigurator
    {
        IList<Feature> GetFeatures();
    }
}
