//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/mads/dev/aau/p4-compiler/alang_compile/core_compile/ALang.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AntlrGen {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ALangParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IALangVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] ALangParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommands([NotNull] ALangParser.CommandsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommand([NotNull] ALangParser.CommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction([NotNull] ALangParser.FunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParams([NotNull] ALangParser.ParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] ALangParser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.inputparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInputparams([NotNull] ALangParser.InputparamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.codeblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCodeblock([NotNull] ALangParser.CodeblockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.code"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCode([NotNull] ALangParser.CodeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.imports"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImports([NotNull] ALangParser.ImportsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.dcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDcl([NotNull] ALangParser.DclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.udtryk"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUdtryk([NotNull] ALangParser.UdtrykContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmt([NotNull] ALangParser.StmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctioncall([NotNull] ALangParser.FunctioncallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.returnstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnstmt([NotNull] ALangParser.ReturnstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.assignstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignstmt([NotNull] ALangParser.AssignstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.arithmeticexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArithmeticexpr([NotNull] ALangParser.ArithmeticexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfstmt([NotNull] ALangParser.IfstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] ALangParser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.predexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredexpr([NotNull] ALangParser.PredexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.logicexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicexpr([NotNull] ALangParser.LogicexprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.repeatstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeatstmt([NotNull] ALangParser.RepeatstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.outputstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOutputstmt([NotNull] ALangParser.OutputstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] ALangParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ALangParser.state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitState([NotNull] ALangParser.StateContext context);
}
} // namespace AntlrGen
