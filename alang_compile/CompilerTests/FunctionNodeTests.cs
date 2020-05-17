using NUnit.Framework;
using core_compile.AbstractSyntaxTree;


namespace CompilerTests
{
    [TestFixture]
    public class FunctionNodeTests
    {
        [Test]
        public void functionNode_HaveIntAndTimeParams()
        {
            var ast = TestHelpers.MakeAstRoot("function Torben -> int paramint, time paramtime | void endfunction");
            var functionNode = (FunctionNode) ast.GetChildren();
            var nodeParams = (ParameterNode)functionNode.Params;
            
            Assert.That(nodeParams.Type, Is.EqualTo(LanguageType.Int));
            Assert.That(nodeParams.Identifier, Is.EqualTo("paramint"));

            nodeParams = (ParameterNode)nodeParams.RightSibling;
            
            Assert.That(nodeParams.Type, Is.EqualTo(LanguageType.Time));
            Assert.That(nodeParams.Identifier, Is.EqualTo("paramtime"));


        }
    }
}