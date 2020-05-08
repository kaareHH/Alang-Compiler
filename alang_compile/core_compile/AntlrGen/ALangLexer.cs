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
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class ALangLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, ENDIF=8, ENDREPEAT=9, 
		ENDTERM=10, IF=11, ELSEIF=12, ELSE=13, REPEAT=14, TIMES=15, THEN=16, TYPE=17, 
		LPAREN=18, RPAREN=19, COMMA=20, ASSIGNOPERATOR=21, OPALL=22, BOOLEAN=23, 
		INTEGERS=24, PIN=25, ONOFF=26, TIME=27, FLOAT=28, ID=29, ALANGFILENAME=30, 
		WHITESPACE=31, BLOCKCOMMENT=32, LINECOMMENT=33;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "ENDIF", "ENDREPEAT", 
		"ENDTERM", "IF", "ELSEIF", "ELSE", "REPEAT", "TIMES", "THEN", "TYPE", 
		"LPAREN", "RPAREN", "COMMA", "ASSIGNOPERATOR", "OPALL", "OPERATOR", "BOOLOPERATOR", 
		"PREDOPERATOR", "BOOLEAN", "INTEGERS", "DIGITS", "PIN", "ONOFF", "TIME", 
		"NUM", "FLOAT", "ID", "UPPERCASE", "LOWERCASE", "ALANGFILENAME", "WHITESPACE", 
		"BLOCKCOMMENT", "LINECOMMENT"
	};


	public ALangLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ALangLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'function'", "'->'", "'|'", "'endfunction'", "'import'", "'toggle'", 
		"'return'", "'endif'", "'endrepeat'", "';'", "'if'", "'else if'", "'else'", 
		"'repeat'", "'times'", "'then'", null, "'('", "')'", "','", "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, "ENDIF", "ENDREPEAT", 
		"ENDTERM", "IF", "ELSEIF", "ELSE", "REPEAT", "TIMES", "THEN", "TYPE", 
		"LPAREN", "RPAREN", "COMMA", "ASSIGNOPERATOR", "OPALL", "BOOLEAN", "INTEGERS", 
		"PIN", "ONOFF", "TIME", "FLOAT", "ID", "ALANGFILENAME", "WHITESPACE", 
		"BLOCKCOMMENT", "LINECOMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "ALang.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ALangLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '#', '\x16A', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x5', '\x12', '\xCE', '\n', 
		'\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x5', '\x17', '\xDB', '\n', '\x17', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', 
		'\x3', '\x19', '\x5', '\x19', '\xE4', '\n', '\x19', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x5', '\x1A', '\xEF', '\n', '\x1A', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x5', '\x1B', 
		'\xFA', '\n', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x5', '\x1C', '\xFE', 
		'\n', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\a', '\x1D', '\x102', '\n', 
		'\x1D', '\f', '\x1D', '\xE', '\x1D', '\x105', '\v', '\x1D', '\x3', '\x1E', 
		'\x3', '\x1E', '\x3', '\x1E', '\x5', '\x1E', '\x10A', '\n', '\x1E', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x5', 
		'\x1F', '\x111', '\n', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x5', 
		' ', '\x122', '\n', ' ', '\x3', '!', '\x3', '!', '\x3', '\"', '\a', '\"', 
		'\x127', '\n', '\"', '\f', '\"', '\xE', '\"', '\x12A', '\v', '\"', '\x3', 
		'\"', '\x3', '\"', '\x6', '\"', '\x12E', '\n', '\"', '\r', '\"', '\xE', 
		'\"', '\x12F', '\x3', '#', '\x3', '#', '\x6', '#', '\x134', '\n', '#', 
		'\r', '#', '\xE', '#', '\x135', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', 
		'%', '\x3', '&', '\x6', '&', '\x13D', '\n', '&', '\r', '&', '\xE', '&', 
		'\x13E', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', 
		'&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x5', '\'', '\x14A', '\n', 
		'\'', '\x3', '\'', '\x3', '\'', '\x6', '\'', '\x14E', '\n', '\'', '\r', 
		'\'', '\xE', '\'', '\x14F', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', 
		'(', '\x3', '(', '\x3', '(', '\a', '(', '\x158', '\n', '(', '\f', '(', 
		'\xE', '(', '\x15B', '\v', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', 
		'(', '\x3', '(', '\x3', ')', '\x3', ')', '\a', ')', '\x164', '\n', ')', 
		'\f', ')', '\xE', ')', '\x167', '\v', ')', '\x3', ')', '\x3', ')', '\x3', 
		'\x159', '\x2', '*', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', 
		'\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', 
		'\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', 
		'\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', 
		'+', '\x17', '-', '\x18', '/', '\x2', '\x31', '\x2', '\x33', '\x2', '\x35', 
		'\x19', '\x37', '\x1A', '\x39', '\x2', ';', '\x1B', '=', '\x1C', '?', 
		'\x1D', '\x41', '\x2', '\x43', '\x1E', '\x45', '\x1F', 'G', '\x2', 'I', 
		'\x2', 'K', ' ', 'M', '!', 'O', '\"', 'Q', '#', '\x3', '\x2', '\t', '\x6', 
		'\x2', '\'', '\'', ',', '-', '/', '/', '\x31', '\x31', '\x4', '\x2', '>', 
		'>', '@', '@', '\x3', '\x2', '\x43', '\\', '\x3', '\x2', '\x63', '|', 
		'\x5', '\x2', '\x32', ';', '\x43', '\\', '\x63', '|', '\x4', '\x2', '\v', 
		'\v', '\"', '\"', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x2', '\x180', 
		'\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', 
		')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'M', '\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'Q', '\x3', '\x2', '\x2', '\x2', '\x3', 'S', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\\', '\x3', '\x2', '\x2', '\x2', '\a', '_', '\x3', 
		'\x2', '\x2', '\x2', '\t', '\x61', '\x3', '\x2', '\x2', '\x2', '\v', 'm', 
		'\x3', '\x2', '\x2', '\x2', '\r', 't', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'{', '\x3', '\x2', '\x2', '\x2', '\x11', '\x82', '\x3', '\x2', '\x2', 
		'\x2', '\x13', '\x88', '\x3', '\x2', '\x2', '\x2', '\x15', '\x92', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x94', '\x3', '\x2', '\x2', '\x2', '\x19', 
		'\x97', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x9F', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\xA4', '\x3', '\x2', '\x2', '\x2', '\x1F', '\xAB', '\x3', 
		'\x2', '\x2', '\x2', '!', '\xB1', '\x3', '\x2', '\x2', '\x2', '#', '\xCD', 
		'\x3', '\x2', '\x2', '\x2', '%', '\xCF', '\x3', '\x2', '\x2', '\x2', '\'', 
		'\xD1', '\x3', '\x2', '\x2', '\x2', ')', '\xD3', '\x3', '\x2', '\x2', 
		'\x2', '+', '\xD5', '\x3', '\x2', '\x2', '\x2', '-', '\xDA', '\x3', '\x2', 
		'\x2', '\x2', '/', '\xDC', '\x3', '\x2', '\x2', '\x2', '\x31', '\xE3', 
		'\x3', '\x2', '\x2', '\x2', '\x33', '\xEE', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '\xF9', '\x3', '\x2', '\x2', '\x2', '\x37', '\xFD', '\x3', '\x2', 
		'\x2', '\x2', '\x39', '\xFF', '\x3', '\x2', '\x2', '\x2', ';', '\x109', 
		'\x3', '\x2', '\x2', '\x2', '=', '\x110', '\x3', '\x2', '\x2', '\x2', 
		'?', '\x121', '\x3', '\x2', '\x2', '\x2', '\x41', '\x123', '\x3', '\x2', 
		'\x2', '\x2', '\x43', '\x128', '\x3', '\x2', '\x2', '\x2', '\x45', '\x133', 
		'\x3', '\x2', '\x2', '\x2', 'G', '\x137', '\x3', '\x2', '\x2', '\x2', 
		'I', '\x139', '\x3', '\x2', '\x2', '\x2', 'K', '\x13C', '\x3', '\x2', 
		'\x2', '\x2', 'M', '\x14D', '\x3', '\x2', '\x2', '\x2', 'O', '\x153', 
		'\x3', '\x2', '\x2', '\x2', 'Q', '\x161', '\x3', '\x2', '\x2', '\x2', 
		'S', 'T', '\a', 'h', '\x2', '\x2', 'T', 'U', '\a', 'w', '\x2', '\x2', 
		'U', 'V', '\a', 'p', '\x2', '\x2', 'V', 'W', '\a', '\x65', '\x2', '\x2', 
		'W', 'X', '\a', 'v', '\x2', '\x2', 'X', 'Y', '\a', 'k', '\x2', '\x2', 
		'Y', 'Z', '\a', 'q', '\x2', '\x2', 'Z', '[', '\a', 'p', '\x2', '\x2', 
		'[', '\x4', '\x3', '\x2', '\x2', '\x2', '\\', ']', '\a', '/', '\x2', '\x2', 
		']', '^', '\a', '@', '\x2', '\x2', '^', '\x6', '\x3', '\x2', '\x2', '\x2', 
		'_', '`', '\a', '~', '\x2', '\x2', '`', '\b', '\x3', '\x2', '\x2', '\x2', 
		'\x61', '\x62', '\a', 'g', '\x2', '\x2', '\x62', '\x63', '\a', 'p', '\x2', 
		'\x2', '\x63', '\x64', '\a', '\x66', '\x2', '\x2', '\x64', '\x65', '\a', 
		'h', '\x2', '\x2', '\x65', '\x66', '\a', 'w', '\x2', '\x2', '\x66', 'g', 
		'\a', 'p', '\x2', '\x2', 'g', 'h', '\a', '\x65', '\x2', '\x2', 'h', 'i', 
		'\a', 'v', '\x2', '\x2', 'i', 'j', '\a', 'k', '\x2', '\x2', 'j', 'k', 
		'\a', 'q', '\x2', '\x2', 'k', 'l', '\a', 'p', '\x2', '\x2', 'l', '\n', 
		'\x3', '\x2', '\x2', '\x2', 'm', 'n', '\a', 'k', '\x2', '\x2', 'n', 'o', 
		'\a', 'o', '\x2', '\x2', 'o', 'p', '\a', 'r', '\x2', '\x2', 'p', 'q', 
		'\a', 'q', '\x2', '\x2', 'q', 'r', '\a', 't', '\x2', '\x2', 'r', 's', 
		'\a', 'v', '\x2', '\x2', 's', '\f', '\x3', '\x2', '\x2', '\x2', 't', 'u', 
		'\a', 'v', '\x2', '\x2', 'u', 'v', '\a', 'q', '\x2', '\x2', 'v', 'w', 
		'\a', 'i', '\x2', '\x2', 'w', 'x', '\a', 'i', '\x2', '\x2', 'x', 'y', 
		'\a', 'n', '\x2', '\x2', 'y', 'z', '\a', 'g', '\x2', '\x2', 'z', '\xE', 
		'\x3', '\x2', '\x2', '\x2', '{', '|', '\a', 't', '\x2', '\x2', '|', '}', 
		'\a', 'g', '\x2', '\x2', '}', '~', '\a', 'v', '\x2', '\x2', '~', '\x7F', 
		'\a', 'w', '\x2', '\x2', '\x7F', '\x80', '\a', 't', '\x2', '\x2', '\x80', 
		'\x81', '\a', 'p', '\x2', '\x2', '\x81', '\x10', '\x3', '\x2', '\x2', 
		'\x2', '\x82', '\x83', '\a', 'g', '\x2', '\x2', '\x83', '\x84', '\a', 
		'p', '\x2', '\x2', '\x84', '\x85', '\a', '\x66', '\x2', '\x2', '\x85', 
		'\x86', '\a', 'k', '\x2', '\x2', '\x86', '\x87', '\a', 'h', '\x2', '\x2', 
		'\x87', '\x12', '\x3', '\x2', '\x2', '\x2', '\x88', '\x89', '\a', 'g', 
		'\x2', '\x2', '\x89', '\x8A', '\a', 'p', '\x2', '\x2', '\x8A', '\x8B', 
		'\a', '\x66', '\x2', '\x2', '\x8B', '\x8C', '\a', 't', '\x2', '\x2', '\x8C', 
		'\x8D', '\a', 'g', '\x2', '\x2', '\x8D', '\x8E', '\a', 'r', '\x2', '\x2', 
		'\x8E', '\x8F', '\a', 'g', '\x2', '\x2', '\x8F', '\x90', '\a', '\x63', 
		'\x2', '\x2', '\x90', '\x91', '\a', 'v', '\x2', '\x2', '\x91', '\x14', 
		'\x3', '\x2', '\x2', '\x2', '\x92', '\x93', '\a', '=', '\x2', '\x2', '\x93', 
		'\x16', '\x3', '\x2', '\x2', '\x2', '\x94', '\x95', '\a', 'k', '\x2', 
		'\x2', '\x95', '\x96', '\a', 'h', '\x2', '\x2', '\x96', '\x18', '\x3', 
		'\x2', '\x2', '\x2', '\x97', '\x98', '\a', 'g', '\x2', '\x2', '\x98', 
		'\x99', '\a', 'n', '\x2', '\x2', '\x99', '\x9A', '\a', 'u', '\x2', '\x2', 
		'\x9A', '\x9B', '\a', 'g', '\x2', '\x2', '\x9B', '\x9C', '\a', '\"', '\x2', 
		'\x2', '\x9C', '\x9D', '\a', 'k', '\x2', '\x2', '\x9D', '\x9E', '\a', 
		'h', '\x2', '\x2', '\x9E', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x9F', 
		'\xA0', '\a', 'g', '\x2', '\x2', '\xA0', '\xA1', '\a', 'n', '\x2', '\x2', 
		'\xA1', '\xA2', '\a', 'u', '\x2', '\x2', '\xA2', '\xA3', '\a', 'g', '\x2', 
		'\x2', '\xA3', '\x1C', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA5', '\a', 
		't', '\x2', '\x2', '\xA5', '\xA6', '\a', 'g', '\x2', '\x2', '\xA6', '\xA7', 
		'\a', 'r', '\x2', '\x2', '\xA7', '\xA8', '\a', 'g', '\x2', '\x2', '\xA8', 
		'\xA9', '\a', '\x63', '\x2', '\x2', '\xA9', '\xAA', '\a', 'v', '\x2', 
		'\x2', '\xAA', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', 
		'v', '\x2', '\x2', '\xAC', '\xAD', '\a', 'k', '\x2', '\x2', '\xAD', '\xAE', 
		'\a', 'o', '\x2', '\x2', '\xAE', '\xAF', '\a', 'g', '\x2', '\x2', '\xAF', 
		'\xB0', '\a', 'u', '\x2', '\x2', '\xB0', ' ', '\x3', '\x2', '\x2', '\x2', 
		'\xB1', '\xB2', '\a', 'v', '\x2', '\x2', '\xB2', '\xB3', '\a', 'j', '\x2', 
		'\x2', '\xB3', '\xB4', '\a', 'g', '\x2', '\x2', '\xB4', '\xB5', '\a', 
		'p', '\x2', '\x2', '\xB5', '\"', '\x3', '\x2', '\x2', '\x2', '\xB6', '\xB7', 
		'\a', 'x', '\x2', '\x2', '\xB7', '\xB8', '\a', 'q', '\x2', '\x2', '\xB8', 
		'\xB9', '\a', 'k', '\x2', '\x2', '\xB9', '\xCE', '\a', '\x66', '\x2', 
		'\x2', '\xBA', '\xBB', '\a', 'k', '\x2', '\x2', '\xBB', '\xBC', '\a', 
		'p', '\x2', '\x2', '\xBC', '\xCE', '\a', 'v', '\x2', '\x2', '\xBD', '\xBE', 
		'\a', 'h', '\x2', '\x2', '\xBE', '\xBF', '\a', 'n', '\x2', '\x2', '\xBF', 
		'\xC0', '\a', 'q', '\x2', '\x2', '\xC0', '\xC1', '\a', '\x63', '\x2', 
		'\x2', '\xC1', '\xCE', '\a', 'v', '\x2', '\x2', '\xC2', '\xC3', '\a', 
		'r', '\x2', '\x2', '\xC3', '\xC4', '\a', 'k', '\x2', '\x2', '\xC4', '\xCE', 
		'\a', 'p', '\x2', '\x2', '\xC5', '\xC6', '\a', '\x64', '\x2', '\x2', '\xC6', 
		'\xC7', '\a', 'q', '\x2', '\x2', '\xC7', '\xC8', '\a', 'q', '\x2', '\x2', 
		'\xC8', '\xCE', '\a', 'n', '\x2', '\x2', '\xC9', '\xCA', '\a', 'v', '\x2', 
		'\x2', '\xCA', '\xCB', '\a', 'k', '\x2', '\x2', '\xCB', '\xCC', '\a', 
		'o', '\x2', '\x2', '\xCC', '\xCE', '\a', 'g', '\x2', '\x2', '\xCD', '\xB6', 
		'\x3', '\x2', '\x2', '\x2', '\xCD', '\xBA', '\x3', '\x2', '\x2', '\x2', 
		'\xCD', '\xBD', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xC2', '\x3', '\x2', 
		'\x2', '\x2', '\xCD', '\xC5', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xC9', 
		'\x3', '\x2', '\x2', '\x2', '\xCE', '$', '\x3', '\x2', '\x2', '\x2', '\xCF', 
		'\xD0', '\a', '*', '\x2', '\x2', '\xD0', '&', '\x3', '\x2', '\x2', '\x2', 
		'\xD1', '\xD2', '\a', '+', '\x2', '\x2', '\xD2', '(', '\x3', '\x2', '\x2', 
		'\x2', '\xD3', '\xD4', '\a', '.', '\x2', '\x2', '\xD4', '*', '\x3', '\x2', 
		'\x2', '\x2', '\xD5', '\xD6', '\a', '?', '\x2', '\x2', '\xD6', ',', '\x3', 
		'\x2', '\x2', '\x2', '\xD7', '\xDB', '\x5', '/', '\x18', '\x2', '\xD8', 
		'\xDB', '\x5', '\x31', '\x19', '\x2', '\xD9', '\xDB', '\x5', '\x33', '\x1A', 
		'\x2', '\xDA', '\xD7', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xD8', '\x3', 
		'\x2', '\x2', '\x2', '\xDA', '\xD9', '\x3', '\x2', '\x2', '\x2', '\xDB', 
		'.', '\x3', '\x2', '\x2', '\x2', '\xDC', '\xDD', '\t', '\x2', '\x2', '\x2', 
		'\xDD', '\x30', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDF', '\a', '(', 
		'\x2', '\x2', '\xDF', '\xE4', '\a', '(', '\x2', '\x2', '\xE0', '\xE1', 
		'\a', '~', '\x2', '\x2', '\xE1', '\xE4', '\a', '~', '\x2', '\x2', '\xE2', 
		'\xE4', '\a', '`', '\x2', '\x2', '\xE3', '\xDE', '\x3', '\x2', '\x2', 
		'\x2', '\xE3', '\xE0', '\x3', '\x2', '\x2', '\x2', '\xE3', '\xE2', '\x3', 
		'\x2', '\x2', '\x2', '\xE4', '\x32', '\x3', '\x2', '\x2', '\x2', '\xE5', 
		'\xE6', '\a', '?', '\x2', '\x2', '\xE6', '\xEF', '\a', '?', '\x2', '\x2', 
		'\xE7', '\xE8', '\a', '@', '\x2', '\x2', '\xE8', '\xEF', '\a', '?', '\x2', 
		'\x2', '\xE9', '\xEA', '\a', '>', '\x2', '\x2', '\xEA', '\xEF', '\a', 
		'?', '\x2', '\x2', '\xEB', '\xEF', '\t', '\x3', '\x2', '\x2', '\xEC', 
		'\xED', '\a', '#', '\x2', '\x2', '\xED', '\xEF', '\a', '?', '\x2', '\x2', 
		'\xEE', '\xE5', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xE7', '\x3', '\x2', 
		'\x2', '\x2', '\xEE', '\xE9', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xEB', 
		'\x3', '\x2', '\x2', '\x2', '\xEE', '\xEC', '\x3', '\x2', '\x2', '\x2', 
		'\xEF', '\x34', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF1', '\a', 'v', 
		'\x2', '\x2', '\xF1', '\xF2', '\a', 't', '\x2', '\x2', '\xF2', '\xF3', 
		'\a', 'w', '\x2', '\x2', '\xF3', '\xFA', '\a', 'g', '\x2', '\x2', '\xF4', 
		'\xF5', '\a', 'h', '\x2', '\x2', '\xF5', '\xF6', '\a', '\x63', '\x2', 
		'\x2', '\xF6', '\xF7', '\a', 'n', '\x2', '\x2', '\xF7', '\xF8', '\a', 
		'u', '\x2', '\x2', '\xF8', '\xFA', '\a', 'g', '\x2', '\x2', '\xF9', '\xF0', 
		'\x3', '\x2', '\x2', '\x2', '\xF9', '\xF4', '\x3', '\x2', '\x2', '\x2', 
		'\xFA', '\x36', '\x3', '\x2', '\x2', '\x2', '\xFB', '\xFE', '\a', '\x32', 
		'\x2', '\x2', '\xFC', '\xFE', '\x5', '\x39', '\x1D', '\x2', '\xFD', '\xFB', 
		'\x3', '\x2', '\x2', '\x2', '\xFD', '\xFC', '\x3', '\x2', '\x2', '\x2', 
		'\xFE', '\x38', '\x3', '\x2', '\x2', '\x2', '\xFF', '\x103', '\x4', '\x33', 
		';', '\x2', '\x100', '\x102', '\x4', '\x32', ';', '\x2', '\x101', '\x100', 
		'\x3', '\x2', '\x2', '\x2', '\x102', '\x105', '\x3', '\x2', '\x2', '\x2', 
		'\x103', '\x101', '\x3', '\x2', '\x2', '\x2', '\x103', '\x104', '\x3', 
		'\x2', '\x2', '\x2', '\x104', ':', '\x3', '\x2', '\x2', '\x2', '\x105', 
		'\x103', '\x3', '\x2', '\x2', '\x2', '\x106', '\x10A', '\x4', '\x32', 
		';', '\x2', '\x107', '\x108', '\a', '\x33', '\x2', '\x2', '\x108', '\x10A', 
		'\x4', '\x32', '\x35', '\x2', '\x109', '\x106', '\x3', '\x2', '\x2', '\x2', 
		'\x109', '\x107', '\x3', '\x2', '\x2', '\x2', '\x10A', '<', '\x3', '\x2', 
		'\x2', '\x2', '\x10B', '\x10C', '\a', 'Q', '\x2', '\x2', '\x10C', '\x111', 
		'\a', 'P', '\x2', '\x2', '\x10D', '\x10E', '\a', 'Q', '\x2', '\x2', '\x10E', 
		'\x10F', '\a', 'H', '\x2', '\x2', '\x10F', '\x111', '\a', 'H', '\x2', 
		'\x2', '\x110', '\x10B', '\x3', '\x2', '\x2', '\x2', '\x110', '\x10D', 
		'\x3', '\x2', '\x2', '\x2', '\x111', '>', '\x3', '\x2', '\x2', '\x2', 
		'\x112', '\x113', '\x5', '\x41', '!', '\x2', '\x113', '\x114', '\x5', 
		'\x41', '!', '\x2', '\x114', '\x115', '\a', '<', '\x2', '\x2', '\x115', 
		'\x116', '\x5', '\x41', '!', '\x2', '\x116', '\x117', '\x5', '\x41', '!', 
		'\x2', '\x117', '\x122', '\x3', '\x2', '\x2', '\x2', '\x118', '\x119', 
		'\x5', '\x41', '!', '\x2', '\x119', '\x11A', '\x5', '\x41', '!', '\x2', 
		'\x11A', '\x11B', '\a', '<', '\x2', '\x2', '\x11B', '\x11C', '\x5', '\x41', 
		'!', '\x2', '\x11C', '\x11D', '\x5', '\x41', '!', '\x2', '\x11D', '\x11E', 
		'\a', '<', '\x2', '\x2', '\x11E', '\x11F', '\x5', '\x41', '!', '\x2', 
		'\x11F', '\x120', '\x5', '\x41', '!', '\x2', '\x120', '\x122', '\x3', 
		'\x2', '\x2', '\x2', '\x121', '\x112', '\x3', '\x2', '\x2', '\x2', '\x121', 
		'\x118', '\x3', '\x2', '\x2', '\x2', '\x122', '@', '\x3', '\x2', '\x2', 
		'\x2', '\x123', '\x124', '\x4', '\x32', ';', '\x2', '\x124', '\x42', '\x3', 
		'\x2', '\x2', '\x2', '\x125', '\x127', '\x5', '\x41', '!', '\x2', '\x126', 
		'\x125', '\x3', '\x2', '\x2', '\x2', '\x127', '\x12A', '\x3', '\x2', '\x2', 
		'\x2', '\x128', '\x126', '\x3', '\x2', '\x2', '\x2', '\x128', '\x129', 
		'\x3', '\x2', '\x2', '\x2', '\x129', '\x12B', '\x3', '\x2', '\x2', '\x2', 
		'\x12A', '\x128', '\x3', '\x2', '\x2', '\x2', '\x12B', '\x12D', '\a', 
		'\x30', '\x2', '\x2', '\x12C', '\x12E', '\x5', '\x41', '!', '\x2', '\x12D', 
		'\x12C', '\x3', '\x2', '\x2', '\x2', '\x12E', '\x12F', '\x3', '\x2', '\x2', 
		'\x2', '\x12F', '\x12D', '\x3', '\x2', '\x2', '\x2', '\x12F', '\x130', 
		'\x3', '\x2', '\x2', '\x2', '\x130', '\x44', '\x3', '\x2', '\x2', '\x2', 
		'\x131', '\x134', '\x5', 'I', '%', '\x2', '\x132', '\x134', '\x5', 'G', 
		'$', '\x2', '\x133', '\x131', '\x3', '\x2', '\x2', '\x2', '\x133', '\x132', 
		'\x3', '\x2', '\x2', '\x2', '\x134', '\x135', '\x3', '\x2', '\x2', '\x2', 
		'\x135', '\x133', '\x3', '\x2', '\x2', '\x2', '\x135', '\x136', '\x3', 
		'\x2', '\x2', '\x2', '\x136', '\x46', '\x3', '\x2', '\x2', '\x2', '\x137', 
		'\x138', '\t', '\x4', '\x2', '\x2', '\x138', 'H', '\x3', '\x2', '\x2', 
		'\x2', '\x139', '\x13A', '\t', '\x5', '\x2', '\x2', '\x13A', 'J', '\x3', 
		'\x2', '\x2', '\x2', '\x13B', '\x13D', '\t', '\x6', '\x2', '\x2', '\x13C', 
		'\x13B', '\x3', '\x2', '\x2', '\x2', '\x13D', '\x13E', '\x3', '\x2', '\x2', 
		'\x2', '\x13E', '\x13C', '\x3', '\x2', '\x2', '\x2', '\x13E', '\x13F', 
		'\x3', '\x2', '\x2', '\x2', '\x13F', '\x140', '\x3', '\x2', '\x2', '\x2', 
		'\x140', '\x141', '\a', '\x30', '\x2', '\x2', '\x141', '\x142', '\a', 
		'\x63', '\x2', '\x2', '\x142', '\x143', '\a', 'n', '\x2', '\x2', '\x143', 
		'\x144', '\a', '\x63', '\x2', '\x2', '\x144', '\x145', '\a', 'p', '\x2', 
		'\x2', '\x145', '\x146', '\a', 'i', '\x2', '\x2', '\x146', 'L', '\x3', 
		'\x2', '\x2', '\x2', '\x147', '\x14E', '\t', '\a', '\x2', '\x2', '\x148', 
		'\x14A', '\a', '\xF', '\x2', '\x2', '\x149', '\x148', '\x3', '\x2', '\x2', 
		'\x2', '\x149', '\x14A', '\x3', '\x2', '\x2', '\x2', '\x14A', '\x14B', 
		'\x3', '\x2', '\x2', '\x2', '\x14B', '\x14E', '\a', '\f', '\x2', '\x2', 
		'\x14C', '\x14E', '\a', '\xF', '\x2', '\x2', '\x14D', '\x147', '\x3', 
		'\x2', '\x2', '\x2', '\x14D', '\x149', '\x3', '\x2', '\x2', '\x2', '\x14D', 
		'\x14C', '\x3', '\x2', '\x2', '\x2', '\x14E', '\x14F', '\x3', '\x2', '\x2', 
		'\x2', '\x14F', '\x14D', '\x3', '\x2', '\x2', '\x2', '\x14F', '\x150', 
		'\x3', '\x2', '\x2', '\x2', '\x150', '\x151', '\x3', '\x2', '\x2', '\x2', 
		'\x151', '\x152', '\b', '\'', '\x2', '\x2', '\x152', 'N', '\x3', '\x2', 
		'\x2', '\x2', '\x153', '\x154', '\a', '%', '\x2', '\x2', '\x154', '\x155', 
		'\a', ',', '\x2', '\x2', '\x155', '\x159', '\x3', '\x2', '\x2', '\x2', 
		'\x156', '\x158', '\v', '\x2', '\x2', '\x2', '\x157', '\x156', '\x3', 
		'\x2', '\x2', '\x2', '\x158', '\x15B', '\x3', '\x2', '\x2', '\x2', '\x159', 
		'\x15A', '\x3', '\x2', '\x2', '\x2', '\x159', '\x157', '\x3', '\x2', '\x2', 
		'\x2', '\x15A', '\x15C', '\x3', '\x2', '\x2', '\x2', '\x15B', '\x159', 
		'\x3', '\x2', '\x2', '\x2', '\x15C', '\x15D', '\a', ',', '\x2', '\x2', 
		'\x15D', '\x15E', '\a', '%', '\x2', '\x2', '\x15E', '\x15F', '\x3', '\x2', 
		'\x2', '\x2', '\x15F', '\x160', '\b', '(', '\x2', '\x2', '\x160', 'P', 
		'\x3', '\x2', '\x2', '\x2', '\x161', '\x165', '\a', '%', '\x2', '\x2', 
		'\x162', '\x164', '\n', '\b', '\x2', '\x2', '\x163', '\x162', '\x3', '\x2', 
		'\x2', '\x2', '\x164', '\x167', '\x3', '\x2', '\x2', '\x2', '\x165', '\x163', 
		'\x3', '\x2', '\x2', '\x2', '\x165', '\x166', '\x3', '\x2', '\x2', '\x2', 
		'\x166', '\x168', '\x3', '\x2', '\x2', '\x2', '\x167', '\x165', '\x3', 
		'\x2', '\x2', '\x2', '\x168', '\x169', '\b', ')', '\x2', '\x2', '\x169', 
		'R', '\x3', '\x2', '\x2', '\x2', '\x17', '\x2', '\xCD', '\xDA', '\xE3', 
		'\xEE', '\xF9', '\xFD', '\x103', '\x109', '\x110', '\x121', '\x128', '\x12F', 
		'\x133', '\x135', '\x13E', '\x149', '\x14D', '\x14F', '\x159', '\x165', 
		'\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace AntlrGen
