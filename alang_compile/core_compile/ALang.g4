grammar ALang;
/*
 *  Parser Rules
 */
 start       : imports commands EOF
             ;

commands     : command*
             ;

command      : dcl
             | function
             ;

function     : 'function' ID '->' params '|' TYPE codeblock 'endfunction'
             ;

params       : (param(',' param)*)?
             ;

param        : TYPE ID
             ;


codeblock    : code*
             | code* 'return' value
             ;

code         : dcl
             | stmt
             ;

 imports     : ('import' ALANGFILENAME ENDTERM)*
             ;
 stmts       :  stmt*
             ;

dcl: TYPE ID '=' (expr | predicate | state) ';';

stmt: assignstmt | ifstmt | repeatstmt | outputstmt;

assignstmt: ID EQUAL (expr | predicate) ENDTERM;

expr: expr OPERATOR expr | value | '(' expr ')';

ifstmt: IF predicate THEN stmts (ELSEIF predicate THEN stmts)* (ELSE stmts)? ENDIF;

predicate: boolvalue | logicalexpr;

logicalexpr: boolvalue BOOLOPERATOR logicalexpr | boolvalue | '(' logicalexpr ')';

boolvalue: predexpr | boolliteral;

predexpr: expr PREDOPERATOR expr | '(' predexpr ')';

repeatstmt: REPEAT value TIMES stmts ENDREPEAT;

outputstmt: TOGGLE ID ENDTERM;

value: ID | INTEGERS | PIN;

state : '(' ID (',' ID)* ')';

boolliteral: ID | BOOLEAN;



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

EQUAL: '=';

INCLUDE  : 'include ' ;
LPAREN : '(' ;
RPAREN : ')' ;
COMMA : ',' ;

// OPERATORS
OPERATOR: ('+' | '-' | '*' | '/');
BOOLOPERATOR: '&' | '|' | '^';
PREDOPERATOR: '==' | '>=' | '<=' | '>' | '<' | '!=';

// DATA TYPES
BOOLEAN: 'true' | 'false';

INTEGERS: '0' | DIGITS;
fragment DIGITS: '1' ..'9' '0' ..'9'*;

PIN: '0' ..'9' | '1' '0' ..'3';

TOGGLE: 'on' | 'off';

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
