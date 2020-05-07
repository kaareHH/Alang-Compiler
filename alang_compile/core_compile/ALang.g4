grammar ALang;
/*
 *  Parser Rules
 */
start               : commands EOF
                    ;

commands            : dcl commands
                    | function commands
                    | imports commands
                    |
                    ;
                    
dcl                 : TYPE ID '=' primaryExpression ';'
                    | TYPE ID ';'
                    ;

function            : 'function' ID '->' params '|' TYPE stmts 'endfunction'
                    ;

imports             : 'import' ALANGFILENAME ';'
                    ;

primaryExpression   : expression OPALL primaryExpression
                    | expression
                    ;
                    
expression          : value
                    | '(' primaryExpression ')'
                    ;
                    
params              : param
                    | param ',' params
                    |
                    ;

param               : TYPE ID
                    ;

stmts               : dcl stmts
                    | ifstmt stmts
                    | repeatstmt stmts
                    | outputstmt stmts
                    | returnstmt stmts
                    | functioncall stmts
                    | assignstmt stmts
                    |
                    ;
                    

assignstmt          : ID '=' primaryExpression ';'
                    ;


ifstmt              : 'if' alternative 'endif'
                    ;

alternative         : primaryExpression 'then' stmts alternative    
                    | primaryExpression 'then' stmts 'else if' alternative
                    | primaryExpression 'then' stmts 'else' stmts
                    |
                    ;
iflol              : 'if' primaryExpression 'then' stmts ('else if' primaryExpression 'then' stmts)* 'endif'
                    | 'if' primaryExpression 'then' stmts ('else if' primaryExpression 'then' stmts)* 'else' stmts 'endif'
                    ;
                    
repeatstmt:         'repeat' value 'times' stmts 'endrepeat';

outputstmt:         'toggle' ID ';'
                    | ID ONOFF ';'
                    ;

returnstmt          : 'return' primaryExpression ';'
                    ;
                    
functioncall        : ID '->' inputparams ';'
                    ;
                    
inputparams         : value
                    | value ',' inputparams
                    |
                    ;

value: ID | INTEGERS | PIN | TIME | BOOLEAN | FLOAT;

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
    | 'int'
    | 'float'
    | 'pin'
    | 'bool'
    | 'time'
    ;

LPAREN : '(' ;
RPAREN : ')' ;
COMMA : ',' ;

ASSIGNOPERATOR: '=';

// OPERATORS

OPALL: OPERATOR | BOOLOPERATOR | PREDOPERATOR;
fragment OPERATOR: ('+' | '-' | '*' | '/' | '%');
fragment BOOLOPERATOR: '&&' | '||' | '^';
fragment PREDOPERATOR: '==' | '>=' | '<=' | '>' | '<' | '!=';

// DATA TYPES
BOOLEAN: 'true' | 'false';

INTEGERS: '0' | DIGITS;
fragment DIGITS: '1' ..'9' '0' ..'9'*;
PIN: '0' ..'9' | '1' '0' ..'3';
ONOFF: 'ON' | 'OFF';
TIME                :  NUM NUM ':' NUM NUM
                    |  NUM NUM ':' NUM NUM ':' NUM NUM
                    ;
fragment NUM        : '0'..'9';
FLOAT: NUM* '.' NUM+ ;

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
