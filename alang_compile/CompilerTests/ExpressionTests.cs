using core_compile.AbstractSyntaxTree;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class ExpressionTests
    {
        [Test]
        public void AdditionExpression_ShouldHaveHigherPrecedenceThanMultiplication()
        {
            var ast = TestHelpers.MakeAstRoot("int test = 2 * 2 + 2;");
            var dclNode = ast.GetChildren(0) as DeclarationNode;
            
            // Note to self: Don't think about precedence for now! 
            Assert.That(dclNode.PrimaryExpression.Operator, Is.EqualTo(Operator.Multiplication));
        }
    }
}