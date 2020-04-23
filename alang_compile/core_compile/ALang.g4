grammar ALang;
/*
 *  Parser Rules
 */
start               : imports commands EOF
                    ;
                    
imports             : ('import' ALANGFILENAME ';')*
                    ;

commands            : command*
                    ;

command             : dcl
                    | function
                    ;
                    
dcl                 : TYPE ID '=' expression ';'
                    | TYPE ID ';'
                    ;

expression          : arithmeticexpr
                    | logicexpr
                    | predexpr
                    ;
                    
function            : 'function' ID '->' params '|' TYPE codeblock 'endfunction'
                    ;

params              : (param(',' param)*)?
                    ;

param               : TYPE ID
                    ;

codeblock           : code*
                    ;

code                : dcl
                    | stmt
                    ;
                    
stmt                : assignstmt
                    | ifstmt
                    | repeatstmt
                    | outputstmt
                    | returnstmt
                    | functioncall
                    ;

assignstmt          : ID '=' expression ';'
                    | ID '+=' expression ';'
                    ;

ifstmt              : 'if' condition 'then' codeblock 'endif'
                    | 'if' condition 'then' codeblock 'else' codeblock 'endif'
                    | 'if' condition 'then' codeblock ('else if' condition 'then' codeblock)+ 'endif'
                    | 'if' condition 'then' codeblock ('else if' condition 'then' codeblock)+ 'else' codeblock 'endif'
                    ;
                    
repeatstmt: REPEAT value TIMES codeblock ENDREPEAT;

outputstmt: TOGGLE ID ENDTERM;

returnstmt          : 'return' expression ';'
                    ;
                    
functioncall        : ID '->' inputparams ';'
                    ;
                    
inputparams         : (value(',' value)*)?
                    ;

arithmeticexpr      : arithmeticexpr OPERATOR arithmeticexpr
                    | value
                    | '(' arithmeticexpr ')'
                    ;

condition           : predexpr
                    | logicexpr
                    | BOOLEAN
                    | ID
                    ;

predexpr            : ID PREDOPERATOR TIME
                    | arithmeticexpr PREDOPERATOR arithmeticexpr
                    ;

logicexpr           : ID BOOLOPERATOR ID
                    | BOOLEAN BOOLOPERATOR BOOLEAN
                    | predexpr BOOLOPERATOR predexpr
                    | '('logicexpr')' BOOLOPERATOR '('logicexpr')'
                    | BOOLEAN
                    | '('logicexpr')'
                    ;


value: ID | INTEGERS | PIN | TIME;

state : '(' ID (',' ID)* ')';

//TERMINALS
ENDIF: 'endif';

ENDREPEAT: 'endrepeat';

ENDTERM: ';';

IF: 'if';

ELSEIF: 'else if';

ELSE: 'else';

REPEAT: 'repeat';

TIMES: 'times';

THEN: 'then';

TYPE: 'void'
    | 'number'
    | 'pin'
    | 'bool'
    | 'time'
    ;

INCLUDE  : 'include ' ;
LPAREN : '(' ;
RPAREN : ')' ;
COMMA : ',' ;

ASSIGNOPERATOR: '=';

// OPERATORS
OPERATOR: ('+' | '-' | '*' | '/' | '%');
BOOLOPERATOR: '&&' | '||' | '^';
PREDOPERATOR: '==' | '>=' | '<=' | '>' | '<' | '!=';

// DATA TYPES
BOOLEAN: 'true' | 'false';

INTEGERS: '0' | DIGITS;
fragment DIGITS: '1' ..'9' '0' ..'9'*;

PIN: '0' ..'9' | '1' '0' ..'3';

TOGGLE: 'on' | 'off';

TIME                :  NUM NUM ':' NUM NUM
                    |  NUM NUM ':' NUM NUM ':' NUM NUM
                    ;

fragment NUM        : '0'..'9';
// IDENTIFIERS
ID: (LOWERCASE | UPPERCASE)+;
fragment UPPERCASE: [A-Z];
fragment LOWERCASE: [a-z];


ALANGFILENAME: ([a-zA-Z0-9])+ '.alang'
             ;

 // SKIPS
 WHITESPACE          : (' '|'\t'|'\r'? '\n'|'\r')+ -> skip ;
 BLOCKCOMMENT        :   '#*' .*? '*#' -> skip ;
 LINECOMMENT         :   '#' ~[\r\n]* -> skip ;
 //NEWLINE             : ('\r'? '\n' | '\r')+ -> skip ;
