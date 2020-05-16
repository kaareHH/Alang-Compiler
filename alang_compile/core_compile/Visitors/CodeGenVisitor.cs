using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Visitors
{
    public class CodeGenVisitor : IVisitor
    {
        public string program { get; set; } = "";
        public Hashtable globalPins = new Hashtable();

        public void WriteToFile([Optional] string filename)
        {
            string path =  "../../../../"+ (filename ?? "defaultOutputFile.cpp");
            var filestring = path;
            var filepath = Path.GetFullPath(filestring);
            
            using var file = new StreamWriter(filepath);
            file.Write(program);
        }

        public void Visit(AssignmentNode node)
        {
            emit(node.Identifier);
            emit("=");
            node.Expression.Accept(this);
            emit(";");
        }

        public void Visit(AstNode node)
        {
            emit("I should not be able to write this line");
            emit(node.Start);
            emit(node.Stop);
        }

        public void Visit(CompilationNode node)
        {
            emit("unsigned long " + timeNow());
            node.AcceptChildren(this);

        }

        private const int COMPILELEEPTIME = 1;
        private const int ADAYINMILLIS = 86400000;

        private static string timeNow()
        {
            var now = DateTime.Now.AddSeconds(COMPILELEEPTIME).TimeOfDay;
            var nowMS = (long)now.TotalMilliseconds;
            return $" TIME = (millis() + {nowMS.ToString()}) % {ADAYINMILLIS};";

        }

        
        private void emit(object code)
        {
            string text;
            if (code is string)
                text = code as string;
            else
                text = code.ToString();
            
            program += text;
        }
        public void Visit(DeclarationNode node)
        {
            emit(node.Type.ToEnumString());
            emit(" ");
            emit(node.Identifier);
            emit("=");
            node.RightHandSide.Accept(this);
            emit(";");

            if(node.Type == LanguageType.Pin)
                globalPins.Add(node.Identifier, node);
                
        }

        public void Visit(ExpressionNode node)
        {
            if (node.Parenthesized)
                emit("(");
            node.Left.Accept(this);
            emit(node.Operator.ToOperatorString());
            node.Right.Accept(this);
            if (node.Parenthesized)
                emit(")");
        }

        public void Visit(FunctionCallNode node)
        {
            emit(node.Name);
            emit("(");
            node.AcceptChildren(this);
            emit(");");
            
        }


        public void Visit(FunctionNode node)
        {
            emit(node.Type.ToEnumString());
            emit(" ");
            emit(node.Identifier);
            emit("(");
            if (node.Params != null)
                node.Params.Accept(this);
            emit("){\n");
            if(node.Identifier == "loop")
                emit(timeNow());
            if(node.Identifier == "setup")
                SetupBoilerPlate(node);
            node.AcceptChildren(this);
            emit("\n}\n");
        }

        private void SetupBoilerPlate(FunctionNode node)
        {
            foreach (DictionaryEntry dicObject in globalPins)
            {
                var pinNode = dicObject.Value as DeclarationNode;
                emit($"pinMode(");
                pinNode.RightHandSide.Accept(this);
                emit(", OUTPUT);");
            }
        }

        public void Visit(IdentfierNode node)
        {
            emit(node.Symbol);
        }

        public void Visit(IfNode node)
        {
            emit("if(");
            node.Condition.Accept(this);
            emit("){");
            node.AcceptChildren(this);
            emit("}");
            if (node.Alternate != null)
            {
                emit("else{");
                node.Alternate.Accept(this);
                emit("}");
            }
        }

        public void Visit(ImportNode node)
        {
            emit("//maybeimport lul\n");
        }

        public void Visit(IntNode node)
        {
            emit(node.Value);
        }

        public void Visit(NullNode node)
        {
            throw new SomethingWentWrongException(node,"I am a NullNode. SPURGT");
        }

        public void Visit(OutputNode node)
        {
            var output = node.State ? "HIGH" : "LOW";
            emit($"digitalWrite({node.Value},{output});");
        }

        public void Visit(ParameterNode node)
        {
            emit($"{node.Type.ToEnumString()} {node.Identifier}");
            
            var sibling = node.RightSibling as ParameterNode;
            while (sibling != null){
                emit($", {sibling.Type.ToEnumString()} {sibling.Identifier}");
                sibling = sibling.RightSibling as ParameterNode;
            }
            
        }

        public void Visit(PinNode node)
        {
            emit(node.Value);
        }

        public void Visit(TimeNode node)
        {
            emit(node.Value);
        }

        public void Visit(ValueNode node)
        {
            node.Value.Accept(this);
        }

        public void Visit(WhileNode node)
        {
            emit("while (");
            node.Condition.Accept(this);
            emit("){");
            node.AcceptChildren(this);
            emit("}");
        }
    }

    public class SomethingWentWrongException : Exception
    {
        public AstNode Node;
        
        public SomethingWentWrongException(AstNode node, string message = "") : base(message)
        {
            Node = node;
        }
    }

    public class errorHandler
    {
        public void TryCompile()
        {
            var codegen = new CodeGenVisitor();
            var ast = new CompilationNode();

            try
            {
                ast.Accept(codegen);
            }
            catch (SomethingWentWrongException e)
            {
                Console.WriteLine(e.Node.Start);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}