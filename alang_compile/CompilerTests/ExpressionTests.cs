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
            var dclNodePrimaryExpression = (ExpressionNode)dclNode.PrimaryExpression;
            Assert.That(dclNodePrimaryExpression.Operator, Is.EqualTo(Operator.Multiplication));
        }

        [Test]
        public void AssignmentNode_ShouldConsistOfThreeExpression()    
        {
            var ast = TestHelpers.MakeAstRoot("int test = 1 * 2 + 3;");
            var dclNode = ast.GetChildren(0) as DeclarationNode;

            var multiExpres = (ExpressionNode)dclNode.PrimaryExpression;
            
            var OneLit = multiExpres.Left as IntNode;
            Assert.That(OneLit, Is.Not.Null);
            Assert.That(OneLit, Is.TypeOf<IntNode>());
            
            Assert.That(OneLit.Value, Is.EqualTo(1));
            Assert.That(multiExpres.Operator, Is.EqualTo(Operator.Multiplication));
            
            var plusExpression = multiExpres.Right as ExpressionNode;
            Assert.That(plusExpression.Operator, Is.EqualTo(Operator.Addition));
            
            var TwoLit = plusExpression.Left as IntNode;
            Assert.That(TwoLit, Is.TypeOf<IntNode>());
            Assert.That(TwoLit.Value, Is.EqualTo(2));
            
            var ThreeLit = plusExpression.Right;
            Assert.That(((IntNode)ThreeLit).Value, Is.EqualTo(3));
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