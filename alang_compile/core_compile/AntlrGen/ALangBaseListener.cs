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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IALangListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class ALangBaseListener : IALangListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.start"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStart([NotNull] ALangParser.StartContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.start"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStart([NotNull] ALangParser.StartContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.commands"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCommands([NotNull] ALangParser.CommandsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.commands"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCommands([NotNull] ALangParser.CommandsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.dcl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDcl([NotNull] ALangParser.DclContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.dcl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDcl([NotNull] ALangParser.DclContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction([NotNull] ALangParser.FunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction([NotNull] ALangParser.FunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.imports"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterImports([NotNull] ALangParser.ImportsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.imports"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitImports([NotNull] ALangParser.ImportsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.primaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrimaryExpression([NotNull] ALangParser.PrimaryExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.primaryExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrimaryExpression([NotNull] ALangParser.PrimaryExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] ALangParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] ALangParser.ExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.params"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParams([NotNull] ALangParser.ParamsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.params"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParams([NotNull] ALangParser.ParamsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.param"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam([NotNull] ALangParser.ParamContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.param"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam([NotNull] ALangParser.ParamContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.stmts"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmts([NotNull] ALangParser.StmtsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.stmts"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmts([NotNull] ALangParser.StmtsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.assignstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignstmt([NotNull] ALangParser.AssignstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.assignstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignstmt([NotNull] ALangParser.AssignstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.ifstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfstmt([NotNull] ALangParser.IfstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.ifstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfstmt([NotNull] ALangParser.IfstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.alternative"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAlternative([NotNull] ALangParser.AlternativeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.alternative"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAlternative([NotNull] ALangParser.AlternativeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.iflol"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIflol([NotNull] ALangParser.IflolContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.iflol"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIflol([NotNull] ALangParser.IflolContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.repeatstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRepeatstmt([NotNull] ALangParser.RepeatstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.repeatstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRepeatstmt([NotNull] ALangParser.RepeatstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.outputstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOutputstmt([NotNull] ALangParser.OutputstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.outputstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOutputstmt([NotNull] ALangParser.OutputstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.returnstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturnstmt([NotNull] ALangParser.ReturnstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.returnstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturnstmt([NotNull] ALangParser.ReturnstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.functioncall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctioncall([NotNull] ALangParser.FunctioncallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.functioncall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctioncall([NotNull] ALangParser.FunctioncallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.inputparams"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInputparams([NotNull] ALangParser.InputparamsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.inputparams"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInputparams([NotNull] ALangParser.InputparamsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="ALangParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] ALangParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="ALangParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] ALangParser.ValueContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace AntlrGen
