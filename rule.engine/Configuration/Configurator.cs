using rule.engine.Interfaces;
using rule.engine.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;

namespace rule.engine.Configuration
{
    public class Configurator : IConfigurator
    {
        public IList<Feature> GetFeatures()
        {
            var features = new List<Feature>();
            var configuration = new FeatureElementCollection();

            try
            {
                configuration = ((FeatureSection)ConfigurationManager.GetSection("featureSection")).Features;
            }
            catch (ConfigurationException e)
            {
                Console.WriteLine($"Malformed configuration section: {e.Message}");

                throw;
            }

            foreach (RulesetElementCollection rulesetElementCollection in configuration)
            {
                var feature = new Feature(rulesetElementCollection.Name);

                foreach (RulesetElement rulesetElement in rulesetElementCollection)
                {
                    var ruleset = new Ruleset();

                    foreach (RuleElement ruleElement in rulesetElement.FileRules)
                    {
                        var conditional = GetConditional<File>(ruleElement);

                        ruleset.FileConditionals.Add(conditional);
                    }

                    foreach (RuleElement ruleElement in rulesetElement.ProcessRules)
                    {
                        var conditional = GetConditional<Process>(ruleElement);

                        ruleset.ProcessConditionals.Add(conditional);
                    }

                    feature.Rulesets.Add(ruleset);
                }

                features.Add(feature);
            }

            return features;
        }

        private Func<T, bool> GetConditional<T>(RuleElement element)
        {
            var rule = new Rule
            {
                Name = element.Name,
                Member = element.Member,
                Operator = element.Operator,
                Target = element.Target
            };

            return rule.Compile<T>();
        }

    }
}
