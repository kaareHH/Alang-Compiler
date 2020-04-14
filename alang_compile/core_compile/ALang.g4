grammar ALang;
/*
 *  Parser Rules
 */
 start       : dcls stmts EOF
             ;
 
 stmts       :  stmt*
             ;
             
 stmt        : assignstmt
             | ifstmt
             | repeatstmt
             | outputstmt
             ;
 
 dcls        : dcl*
             ;
 
 dcl         : TYPE ID EQUAL value ENDTERM
             ;
 
 assignstmt  : ID EQUAL value expr ENDTERM
             ;
 
 ifstmt      : IF value expr THEN stmts ENDIF
             ;
             
 repeatstmt  : REPEAT value TIMES stmts ENDREPEAT
             ;
 
 outputstmt  : TOGGLE ID
             ;
             
 expr        : (OPERATOR value)*
             ;
 
 value       : ID
             | INTEGERS
             | PIN
             ;
 
 //TERMINALS
 ENDIF       : 'endif'
             ;
             
 ENDREPEAT   : 'endrepeat'
             ;
             
 ENDTERM     : ';'
             ;
 
 IF          : 'if'
             ;
             
 REPEAT      : 'repeat'
             ;
             
 TIMES       : 'times'
             ;
             
 THEN        : 'then'
             ;
 
 TYPE        : 'int'
             | 'pin'
             ;
 EQUAL       : '='
             ;
             
 // OPERATORS
 OPERATOR    : ('+' | '-' | '*' | '/' )
             ;
  
 // DATA TYPES
INTEGERS : '0' | DIGITS ;
fragment DIGITS : '1'..'9' '0'..'9'* ;
             
 PIN         : '0'..'9' | '1''0'..'3' ;
 
 TOGGLE : 'on'
        | 'off';
 
 // IDENTIFIERS
 ID          : (LOWERCASE | UPPERCASE)+ ;
 fragment UPPERCASE  : [A-Z] ;
 fragment LOWERCASE  : [a-z] ;
 
 // SKIPS
 WHITESPACE          : (' '|'\t'|'\r'? '\n'|'\r')+ -> skip ;
 //NEWLINE             : ('\r'? '\n' | '\r')+ -> skip ;