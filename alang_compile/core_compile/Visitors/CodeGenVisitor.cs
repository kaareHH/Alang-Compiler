using System;
using AntlrGen;

namespace core_compile
{
    internal class CodeGenVisitor : ALangBaseVisitor<object>
    {
        public string Code { get; set; } = "";
        public int IndentLevel { get; set; }

        public string Indent => new String(' ', IndentLevel*2);

        public override object VisitStart(ALangParser.StartContext context)
        {
            emit("#include<stdio.h>\n\n");
            emit("int main(void)\n{\n");
            IndentLevel++;
            VisitChildren(context);
            emit(Indent + "return 0;");
            emit("\n}");
            Console.WriteLine(Code);
            WriteToFile("test.c");
            return null;
        }

        private void WriteToFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, Code);
        }

        public override object VisitDcls(ALangParser.DclsContext context)
        {
            VisitChildren(context);
            return null;
        }

        public override object VisitDcl(ALangParser.DclContext context)
        {
            if (context.TYPE().ToString() == "int")
            {
                emit(Indent + context.TYPE() + " " + context.ID() + " " + "=" + " ");
                context.value().Accept(this);
                emit(";\n");
            }
            else
            {
                emit(Indent + "int" + " " + context.ID() + " = ");
                context.value().Accept(this);
                emit(";\n");
            }
            
            return null;
        }

        public override object VisitAssignstmt(ALangParser.AssignstmtContext context)
        {
            emit(Indent + context.ID() + " = ");
            context.value().Accept(this);
            context.expr().Accept(this);
            emit(";\n");
            return null;
        }

        public override object VisitIfstmt(ALangParser.IfstmtContext context)
        {
            emit(Indent + "if((");
            context.value().Accept(this);
            context.expr().Accept(this);
            emit(") != 0)" + "\n" + Indent + "{\n");
            IndentLevel++;
            context.stmts().Accept(this);
            IndentLevel--;
            emit("\n" + Indent + "}\n");
            return null;
        }

        public override object VisitRepeatstmt(ALangParser.RepeatstmtContext context)
        {
            emit(Indent + "for(int i=0;i<");
            context.value().Accept(this);
            emit(";i++)\n" + Indent + "{\n");
            IndentLevel++;
            context.stmts().Accept(this);
            IndentLevel--;
            emit("\n" + Indent + "}\n");
            return null;
        }

        public override object VisitOutputstmt(ALangParser.OutputstmtContext context)
        {
            emit(Indent + "printf(\"");
            emit(context.ID() + " " + context.TOGGLE() + "\");\n");
            return null;
        }

        public override object VisitExpr(ALangParser.ExprContext context)
        {
            for (int i = 0; i < context.OPERATOR().Length; i++)
            {
                emit(context.OPERATOR()[i] + " ");
                context.value()[i].Accept(this);
            }

            return null;
        }

        public override object VisitValue(ALangParser.ValueContext context)
        {
            if (context.INTEGERS() != null)
            {
                emit(context.INTEGERS().ToString());
            } else if (context.PIN() != null)
            {
                emit(context.PIN().ToString());
            }
            else
            {
                emit(context.ID().ToString());
            }
            
            emit(" ");
            
            return null;
        }

        private void emit(string text)
        {
            Code += text;
        }
    }
}