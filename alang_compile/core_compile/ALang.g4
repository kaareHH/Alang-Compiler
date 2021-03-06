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
                    | functioncall ';'
                    ;

function            : 'function' ID '->' params '|' TYPE stmts 'endfunction'
                    ;

imports             : 'import' ALANGFILENAME ';'
                    ;

primaryExpression   : predicateExpression ( BOOLOP predicateExpression ) *
                    | 
                    ;

predicateExpression : additiveExpression ( PREDOP additiveExpression ) *
                    ;

additiveExpression  : multiExpression ( ADDOP multiExpression ) *
                    ;

multiExpression     : primary ( MULOP primary ) * 
                    ;

primary             : value
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
                    | whilestmt stmts
                    | outputstmt stmts
                    | returnstmt stmts
                    | functioncall stmts
                    | assignstmt stmts
                    |
                    ;
                    

assignstmt          : ID '=' primaryExpression ';'
                    ;

ifstmt              : 'if' primaryExpression 'then' stmts 'endif'
                    | 'if' primaryExpression 'then' stmts 'else' stmts 'endif'
                    ;            
                    
whilestmt:         'while' primaryExpression 'do' stmts 'endwhile';

outputstmt          :'ON' '->' ID ';'
                    |'OFF' '->' ID ';'
                    ;

returnstmt          : 'return' primaryExpression ';'
                    ;
                    
functioncall        : ID '->' inputparams 
                    | ID '->'
                    ;
                    
inputparams         : value
                    | value ',' inputparams
                    ;

value               : ID 
                    | INTEGERS 
                    | PIN 
                    | TIME 
                    | functioncall
                    ;

//TERMINALS
ENDIF               : 'endif'
                    ;

ENDTERM             : ';'
                    ;

IF                  : 'if'
                    ;

ELSE                : 'else'
                    ;

THEN                : 'then'
                    ;

TYPE                : 'void'
                    | 'int'
                    | 'pin'
                    | 'time'
                    ;

LPAREN              : '(' 
                    ;
                    
RPAREN              : ')' 
                    ;
                    
COMMA               : ',' 
                    ;

ASSIGNOPERATOR      : '='
                    ;

// OPERATORS
ADDOP               : ('+' | '-')
                    ;
                    
MULOP               : ('*' | '/' | '%')
                    ;
                    
BOOLOP              : '&&' 
                    | '||'
                    ;
                    
PREDOP              : '==' 
                    | '>=' 
                    | '<=' 
                    | '>' 
                    | '<' 
                    | '!='
                    ;

// DATA TYPES
INTEGERS            : '0' 
                    | DIGITS
                    ;
                    
fragment DIGITS     : '1' ..'9' '0' ..'9'*
                    ;
                    
PIN                 : 'P'('0' ..'9' | '1' '0' ..'3')
                    ;

ON                  : 'ON' 
                    ;
                    
OFF                 : 'OFF'
                    ;
                    
TIME                :  NUM NUM ':' NUM NUM ':' NUM NUM
                    ;
                    
fragment NUM        : '0'..'9'
                    ;

// IDENTIFIERS
ID                  : (LOWERCASE | UPPERCASE)+
                    ;
                    
fragment UPPERCASE  : [A-Z]
                    ;
                    
fragment LOWERCASE  : [a-z]
                    ;

ALANGFILENAME       : ([a-zA-Z0-9])+ '.alang'
                    ;
    
 // SKIPS
 WHITESPACE         : [ \t]+ -> skip
                    ;
                    
 NEWLINE            :  (   '\r' '\n'? |   '\n') -> skip
                    ;
                    
 BLOCKCOMMENT       : '#*' .*? '*#' -> skip 
                    ;
                    
 LINECOMMENT        : '#' ~[\r\n]* -> skip 
                    ;
