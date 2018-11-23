using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rule.engine.Models;

namespace rule.engine.unit
{
    [TestClass]
    public class ForRule
    {
        public Rule Rule { get; set; }

        public ForRule()
        {
            Rule = new Rule();
        }

        [TestMethod]
        public void Should_Compile_Conditional_When_Using_dotNET_ExpressionType_Operator()
        {
            bool expected = true;
            bool actual;

            Rule.Operator = "Equals";
            Rule.Member = "Name";
            Rule.Target = "Fake";

            var conditional = Rule.Compile<File>();
            var fake = new File { Name = "Fake" };

            actual = conditional(fake);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Compile_Conditional_When_Using_Member_Type_Method_Operator()
        {

        }

        [TestMethod]
        public void Should_Not_Compile_Conditional_When_Member_Nonexistent()
        {

        }

        [TestMethod]
        public void Should_Not_Compile_Conditional_When_Target_Invalid()
        {

        }
    }
}
