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
            var ast = TestHelpers.MakeAstRoot("int test = 3 * 3 + 2;");
            var dclNode = ast.GetChildren(0) as DeclarationNode;
            
            // Note to self: Don't think about precedence for now! 
            var dclNodePrimaryExpression = (ExpressionNode)dclNode.PrimaryExpression;
            Assert.That(dclNodePrimaryExpression.Operator, Is.EqualTo(Operator.Addition));
        }
        
        [Test]
        public void TopMostExpressionNode_ShouldBeWithHighestPrecedence()
        {
            var ast = TestHelpers.MakeAstRoot("int test = 3 * 3 + 2 > 34 && 3 * 7 != 9;");
            var dclNode = ast.GetChildren(0) as DeclarationNode;
            
            // Note to self: Don't think about precedence for now! 
            var dclNodePrimaryExpression = (ExpressionNode)dclNode.PrimaryExpression;
            Assert.That(dclNodePrimaryExpression.Operator, Is.EqualTo(Operator.AND));
        }

        [Test]
        public void AssignmentNode_ShouldConsistOfTwoExpressions()    
        {
            var ast = TestHelpers.MakeAstRoot("int test = 1 * 2 + 3;");
            var dclNode = ast.GetChildren(0) as DeclarationNode;

            var multiExpres = (ExpressionNode)dclNode.PrimaryExpression;
            
            Assert.That(multiExpres.Left, Is.TypeOf<ExpressionNode>());
            Assert.That(((ExpressionNode)multiExpres.Left).Operator, Is.EqualTo(Operator.Multiplication));
            Assert.That(multiExpres.Right, Is.TypeOf<IntNode>());
        }

        [Test]
        public void ExpressionNode_ShouldBeIdentifierWithidenInSymbol()
        {
            var ast = TestHelpers.MakeAstRoot("int ged = iden + 3;");
            var gedDcl = ast.GetChildren(0) as DeclarationNode;

            var idenAndThree = (ExpressionNode)gedDcl.PrimaryExpression;
            var iden = (IdentfierNode)idenAndThree.Left;
            Assert.That(iden, Is.TypeOf<IdentfierNode>());
            Assert.That(iden.Symbol, Is.EqualTo("iden"));

            Assert.That(true, Is.True);
        }
    }
}