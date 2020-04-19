using System;
using System.Collections.Generic;
using System.Linq;

namespace core_compile
{
    public class SemanticVisitor : Visitor<object>
    {
        public List<string> Diagnostics = new List<string>();
        public Dictionary<string, DeclarationType> SymbolTable = new Dictionary<string, DeclarationType>();
        
        public override object Visit(MultipleDeclarationsNode node)
        {
            foreach (var dcl in node.DeclarationNodes)
            {
                Visit((dynamic)dcl);
            }
            return null;
        }

        public override object Visit(MultipleStatementsNode node)
        {
            foreach (var stmt in node.StatementNodes)
            {
                Visit((dynamic)stmt);
            }
            return null;
        }

        public override object Visit(DeclarationNode node)
        {
            switch (node.DeclarationType)
            {
                case DeclarationType.Integer:
                    AddToSymbolTable(node.Id, DeclarationType.Integer);
                    break;
                case DeclarationType.Pin:
                    AddToSymbolTable(node.Id, DeclarationType.Pin);
                    if ((int) node.Value.Value > 13 || (int) node.Value.Value < 0)
                        Diagnostics.Add("Error: Invalid Pin declaration " + node.Value.Value +  " for Arduino Uno");
                    break;
            }

            return null;
        }

        private void AddToSymbolTable(string id, DeclarationType type)
        {
            if (!SymbolTable.ContainsKey(id))
                SymbolTable[id] = type;
            else
                Diagnostics.Add("Error: Duplicate declaration of " + type + " " + id);
        }

        public override object Visit(AssignStatementNode node)
        {
            var type = LookUpSymbol(node.Id);
            if (type != null)
            {
                if (node.Value.ValueKind == ValueKind.Id)
                    if (LookUpSymbol((string)node.Value.Value) != type)
                        Diagnostics.Add("Error: Variable " + node.Value.Value + " of type " + LookUpSymbol((string)node.Value.Value) + " can't be assigned to type of " + type);
            }
            if (node.Expression.Values.Any())
                if (node.Value.ValueKind != node.Expression.Values[0].ValueKind)
                    Diagnostics.Add("Error: Invalid expression between " + node.Value.ValueKind + " and " + node.Expression.Values[0]);
            
            return null;
        }

        private DeclarationType? LookUpSymbol(string id)
        {
            if (SymbolTable.ContainsKey(id))
                return SymbolTable[id];
            Diagnostics.Add("ReferenceError: Can't find variable " + id);
            return null;
        }


        public override object Visit(IfStatementNode node)
        {
            Visit(node.Value);
            Visit(node.Expression);
            Visit(node.MultipleStatementsNode);
            return null;
        }

        public override object Visit(RepeatStatementNode node)
        {
            Visit(node.Value);
            Visit(node.MultipleStatementsNode);
            return null;
        }

        public override object Visit(OutputStatementNode node)
        {
            var type = LookUpSymbol(node.Id);
            if (type != null)
                if (type != DeclarationType.Pin)
                    Diagnostics.Add("OutputError: Can't use Integer variable as output");
            return null;
        }

        public override object Visit(ExpressionNode node)
        {
            foreach (var value in node.Values)
            {
                Visit(value);
            }
            return null;
        }

        public override object Visit(ValueNode node)
        {
            return null;
        }

        public override object Visit(StartNode node)
        {
            Visit(node.MultipleDeclarationNode);
            Visit(node.MultipleStatementsNode);
            return Diagnostics;
        }
    }
}