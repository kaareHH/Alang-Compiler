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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="ALangParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IALangListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] ALangParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] ALangParser.StartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommands([NotNull] ALangParser.CommandsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommands([NotNull] ALangParser.CommandsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommand([NotNull] ALangParser.CommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommand([NotNull] ALangParser.CommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] ALangParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] ALangParser.FunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParams([NotNull] ALangParser.ParamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParams([NotNull] ALangParser.ParamsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam([NotNull] ALangParser.ParamContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam([NotNull] ALangParser.ParamContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.inputparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInputparams([NotNull] ALangParser.InputparamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.inputparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInputparams([NotNull] ALangParser.InputparamsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.codeblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCodeblock([NotNull] ALangParser.CodeblockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.codeblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCodeblock([NotNull] ALangParser.CodeblockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.code"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCode([NotNull] ALangParser.CodeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.code"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCode([NotNull] ALangParser.CodeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.imports"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImports([NotNull] ALangParser.ImportsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.imports"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImports([NotNull] ALangParser.ImportsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.dcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDcl([NotNull] ALangParser.DclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.dcl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDcl([NotNull] ALangParser.DclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.udtryk"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUdtryk([NotNull] ALangParser.UdtrykContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.udtryk"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUdtryk([NotNull] ALangParser.UdtrykContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmt([NotNull] ALangParser.StmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmt([NotNull] ALangParser.StmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctioncall([NotNull] ALangParser.FunctioncallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.functioncall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctioncall([NotNull] ALangParser.FunctioncallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.returnstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnstmt([NotNull] ALangParser.ReturnstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.returnstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnstmt([NotNull] ALangParser.ReturnstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.assignstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignstmt([NotNull] ALangParser.AssignstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.assignstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignstmt([NotNull] ALangParser.AssignstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.arithmeticexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArithmeticexpr([NotNull] ALangParser.ArithmeticexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.arithmeticexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArithmeticexpr([NotNull] ALangParser.ArithmeticexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfstmt([NotNull] ALangParser.IfstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfstmt([NotNull] ALangParser.IfstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondition([NotNull] ALangParser.ConditionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondition([NotNull] ALangParser.ConditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.predexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPredexpr([NotNull] ALangParser.PredexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.predexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPredexpr([NotNull] ALangParser.PredexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.logicexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicexpr([NotNull] ALangParser.LogicexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.logicexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicexpr([NotNull] ALangParser.LogicexprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.repeatstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeatstmt([NotNull] ALangParser.RepeatstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.repeatstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeatstmt([NotNull] ALangParser.RepeatstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.outputstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOutputstmt([NotNull] ALangParser.OutputstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.outputstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOutputstmt([NotNull] ALangParser.OutputstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] ALangParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] ALangParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState([NotNull] ALangParser.StateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState([NotNull] ALangParser.StateContext context);
}
} // namespace AntlrGen