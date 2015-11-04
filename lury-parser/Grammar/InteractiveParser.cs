// created by jay 0.7 (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
// edited by Tomona Nanase in 2014, 2015

#line 2 "InteractiveParser.jay"

//
// InteractiveParser.jay / InteractiveParser.cs
//
// Author:
//       Tomona Nanase <nanase@users.noreply.github.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2014-2015 Tomona Nanase
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using Lury.Compiling.Parser.Tree;

using LToken = Lury.Compiling.Lexer.Token;

namespace Lury.Compiling.Parser
{
    internal partial class InteractiveParser
    {
        private int yacc_verbose_flag = 0;
        
#line default

        /** error output stream.
          * It should be changeable.
          */
        internal System.IO.TextWriter ErrorOutput = System.Console.Out;

        /** simplified error message.
          * @see <a href="#yyerror(java.lang.String, java.lang.String[])">yyerror</a>
          */
        internal void yyerror (string message)
        {
            yyerror(message, null);
        }

#pragma warning disable 649
        /* An EOF token */
        internal int eof_token;
#pragma warning restore 649

        /** (syntax) error message.
          * Can be overwritten to control message format.
          * @param message text to be displayed.
          * @param expected vector of acceptable tokens, if available.
          */
        internal void yyerror(string message, string[] expected)
        {
            if ((yacc_verbose_flag > 0) && (expected != null) && (expected.Length  > 0))
            {
                ErrorOutput.Write(message + ", expecting");

                for (int n = 0; n < expected.Length; ++ n)
                    ErrorOutput.Write(" " + expected[n]);

                ErrorOutput.WriteLine();
             }
             else
                 ErrorOutput.WriteLine(message);
        }

//t        /** debugging support, requires the package jay.yydebug.
//t          * Set to null to suppress debugging messages.
//t          */
//t        internal yydebug.yyDebug debug;

  protected const int yyFinal = 38;
//t // Put this array into a separate class so it is only initialized if debugging is actually used
//t // Use MarshalByRefObject to disable inlining
//t class YYRules : MarshalByRefObject {
//t  public static readonly string [] yyRule = {
//t    "$accept : statement",
//t    "statement : statement_list NewLine",
//t    "statement : compound_statement",
//t    "statement_list : simple_statement",
//t    "statement_list : simple_statement simple_statements",
//t    "simple_statements : ';'",
//t    "simple_statements : ';' simple_statement",
//t    "simple_statements : ';' simple_statement simple_statements",
//t    "compound_statement : if_statement",
//t    "compound_statement : while_statement",
//t    "compound_statement : function_definition",
//t    "compound_statement : class_definition",
//t    "suite : statement_list NewLine",
//t    "suite : NewLine Indent statements Dedent",
//t    "statements : statement",
//t    "statements : statements statement",
//t    "if_statement : KeywordIf expression ':' suite",
//t    "if_statement : KeywordIf expression ':' suite elif_statements",
//t    "elif_statements : KeywordElif expression ':' suite",
//t    "elif_statements : KeywordElif expression ':' suite elif_statements",
//t    "elif_statements : else_statement",
//t    "else_statement : KeywordElse ':' suite",
//t    "while_statement : KeywordWhile expression ':' suite",
//t    "while_statement : KeywordWhile expression ':' suite else_statement",
//t    "function_definition : KeywordDef function_name '(' parameter_list ')' ':' suite",
//t    "function_definition : KeywordDef function_name '(' ')' ':' suite",
//t    "function_definition : KeywordDef function_name ':' suite",
//t    "function_name : identifier_all",
//t    "function_name : function_name '.' identifier_all",
//t    "parameter_list : parameter",
//t    "parameter_list : parameter_list ',' parameter",
//t    "parameter : identifier_all",
//t    "class_definition : KeywordClass class_name '(' inheritance_list ')' ':' suite",
//t    "class_definition : KeywordClass class_name ':' suite",
//t    "class_name : identifier_all",
//t    "inheritance_list : object_name",
//t    "inheritance_list : inheritance_list ',' object_name",
//t    "object_name : identifier_all",
//t    "object_name : object_name '.' identifier_all",
//t    "simple_statement : pass_statement",
//t    "simple_statement : expression_statement",
//t    "simple_statement : return_statement",
//t    "simple_statement : break_statement",
//t    "simple_statement : continue_statement",
//t    "simple_statement : import_statement",
//t    "pass_statement : KeywordPass",
//t    "expression_statement : expression",
//t    "return_statement : KeywordReturn",
//t    "return_statement : KeywordReturn expression",
//t    "break_statement : KeywordBreak",
//t    "continue_statement : KeywordContinue",
//t    "import_statement : KeywordImport import_names",
//t    "import_statement : KeywordPublic KeywordImport import_names",
//t    "import_names : import_name",
//t    "import_names : import_names ',' import_name",
//t    "import_name : module_name",
//t    "module_name : identifier_all",
//t    "module_name : module_name '.' identifier_all",
//t    "identifier_all : Identifier",
//t    "identifier_all : contextual_keyword",
//t    "contextual_keyword : IdentifierGet",
//t    "contextual_keyword : IdentifierSet",
//t    "contextual_keyword : IdentifierFile",
//t    "contextual_keyword : IdentifierLine",
//t    "contextual_keyword : IdentifierExit",
//t    "contextual_keyword : IdentifierSuccess",
//t    "contextual_keyword : IdentifierFailure",
//t    "expression : comma_expression",
//t    "comma_expression : assignment_expression",
//t    "comma_expression : assignment_expression ',' comma_expression",
//t    "assignment_expression : conditional_expression",
//t    "assignment_expression : conditional_expression '=' assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentAdd assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentSub assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentMultiply assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentDivide assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentIntDivide assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentPower assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentModulo assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentAnd assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentOr assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentXor assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentConcat assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentLeftShift assignment_expression",
//t    "assignment_expression : conditional_expression AssignmentRightShift assignment_expression",
//t    "conditional_expression : bool_or_expression",
//t    "conditional_expression : bool_or_expression '?' bool_or_expression ':' bool_or_expression",
//t    "conditional_expression : bool_or_expression KeywordIf bool_or_expression KeywordElse bool_or_expression",
//t    "bool_or_expression : bool_and_expression",
//t    "bool_or_expression : bool_or_expression KeywordOr bool_and_expression",
//t    "bool_or_expression : bool_or_expression OrShort bool_and_expression",
//t    "bool_and_expression : bool_not_expression",
//t    "bool_and_expression : bool_and_expression KeywordAnd bool_not_expression",
//t    "bool_and_expression : bool_and_expression AndShort bool_not_expression",
//t    "bool_not_expression : comparison_expression",
//t    "bool_not_expression : KeywordNot bool_not_expression",
//t    "bool_not_expression : '!' bool_not_expression",
//t    "comparison_expression : or_expression",
//t    "comparison_expression : comparison_expression '<' or_expression",
//t    "comparison_expression : comparison_expression '>' or_expression",
//t    "comparison_expression : comparison_expression LessThan or_expression",
//t    "comparison_expression : comparison_expression MoreThan or_expression",
//t    "comparison_expression : comparison_expression Equal or_expression",
//t    "comparison_expression : comparison_expression NotEqual or_expression",
//t    "comparison_expression : comparison_expression KeywordIs or_expression",
//t    "comparison_expression : comparison_expression IsNot or_expression",
//t    "comparison_expression : comparison_expression KeywordIs KeywordNot or_expression",
//t    "or_expression : xor_expression",
//t    "or_expression : or_expression '|' xor_expression",
//t    "xor_expression : and_expression",
//t    "xor_expression : xor_expression '^' and_expression",
//t    "and_expression : shift_expression",
//t    "and_expression : and_expression '&' shift_expression",
//t    "shift_expression : addition_expression",
//t    "shift_expression : shift_expression LeftShift addition_expression",
//t    "shift_expression : shift_expression RightShift addition_expression",
//t    "addition_expression : multiplication_expression",
//t    "addition_expression : addition_expression '+' multiplication_expression",
//t    "addition_expression : addition_expression '-' multiplication_expression",
//t    "addition_expression : addition_expression '~' multiplication_expression",
//t    "multiplication_expression : unary_expression",
//t    "multiplication_expression : multiplication_expression '*' unary_expression",
//t    "multiplication_expression : multiplication_expression IntDivide unary_expression",
//t    "multiplication_expression : multiplication_expression '/' unary_expression",
//t    "multiplication_expression : multiplication_expression '%' unary_expression",
//t    "unary_expression : power_expression",
//t    "unary_expression : Increment unary_expression",
//t    "unary_expression : Decrement unary_expression",
//t    "unary_expression : '-' unary_expression",
//t    "unary_expression : '+' unary_expression",
//t    "unary_expression : '~' unary_expression",
//t    "power_expression : callref_expression",
//t    "power_expression : power_expression Power callref_expression",
//t    "callref_expression : postfix_expression",
//t    "callref_expression : KeywordRef postfix_expression",
//t    "postfix_expression : primary",
//t    "postfix_expression : postfix_expression '.' identifier_all",
//t    "postfix_expression : postfix_expression Increment",
//t    "postfix_expression : postfix_expression Decrement",
//t    "postfix_expression : postfix_expression '(' ')'",
//t    "postfix_expression : postfix_expression '(' argument_list ')'",
//t    "argument_list : argument",
//t    "argument_list : argument_list ',' argument",
//t    "argument : assignment_expression",
//t    "argument : named_argument",
//t    "named_argument : identifier_all ':' expression",
//t    "primary : identifier_all",
//t    "primary : literal",
//t    "primary : KeywordTrue",
//t    "primary : KeywordFalse",
//t    "primary : KeywordNil",
//t    "primary : KeywordThis",
//t    "primary : KeywordSuper",
//t    "primary : '(' expression ')'",
//t    "literal : StringLiteral",
//t    "literal : WysiwygStringLiteral",
//t    "literal : ImaginaryNumber",
//t    "literal : FloatNumber",
//t    "literal : Integer",
//t  };
//t public static string getRule (int index) {
//t    return yyRule [index];
//t }
//t}
  protected static readonly string [] yyNames = {    
    "end-of-file",null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,"'!'",null,null,null,"'%'","'&'",
    null,"'('","')'","'*'","'+'","','","'-'","'.'","'/'",null,null,null,
    null,null,null,null,null,null,null,"':'","';'","'<'","'='","'>'",
    "'?'",null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,"'^'",null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,"'|'",null,"'~'",null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,null,null,null,null,null,null,null,null,null,null,null,null,null,
    null,"NewLine","Indent","Dedent","EndOfFile","IdentifierGet",
    "IdentifierSet","IdentifierFile","IdentifierLine","IdentifierExit",
    "IdentifierSuccess","IdentifierFailure","KeywordAbstract",
    "KeywordAnd","KeywordBreak","KeywordCase","KeywordCatch",
    "KeywordClass","KeywordContinue","KeywordDef","KeywordDefault",
    "KeywordDelete","KeywordElif","KeywordElse","KeywordEnum",
    "KeywordExtended","KeywordFalse","KeywordFinally","KeywordFor",
    "KeywordIf","KeywordImport","KeywordIn","KeywordInterface",
    "KeywordInvariant","KeywordIs","KeywordLazy","KeywordNameof",
    "KeywordNew","KeywordNil","KeywordNot","KeywordOr","KeywordOut",
    "KeywordOverride","KeywordPass","KeywordPrivate","KeywordProperty",
    "KeywordProtected","KeywordPublic","KeywordRef","KeywordReflect",
    "KeywordReturn","KeywordScope","KeywordSealed","KeywordStatic",
    "KeywordSuper","KeywordSwitch","KeywordThis","KeywordThrow",
    "KeywordTrue","KeywordTry","KeywordUnittest","KeywordUnless",
    "KeywordUntil","KeywordVar","KeywordWhile","KeywordWith",
    "KeywordYield","Identifier","StringLiteral","EmbedStringLiteral",
    "WysiwygStringLiteral","ImaginaryNumber","FloatNumber","Integer",
    "RangeOpen","RangeClose","Increment","AssignmentAdd","Decrement",
    "AssignmentSub","AnnotationReturn","AssignmentConcat",
    "AssignmentPower","Power","AssignmentMultiply","AssignmentIntDivide",
    "IntDivide","AssignmentDivide","AssignmentModulo",
    "AssignmentLeftShift","LeftShift","LessThan","AssignmentRightShift",
    "RightShift","MoreThan","Equal","Lambda","NotEqual","NotIn","IsNot",
    "AndShort","AssignmentAnd","AssignmentXor","OrShort","AssignmentOr",
    "NilCoalesce",
  };

//t        /** index-checked interface to yyNames[].
//t          * @param token single character or %token value.
//t          * @return token name or [illegal] or [unknown].
//t          */
//t        internal static string yyname (int token)
//t        {
//t            if ((token < 0) || (token > yyNames.Length))
//t                return "[illegal]";
//t
//t            string name;
//t
//t            if ((name = yyNames[token]) != null)
//t                return name;
//t
//t            return "[unknown]";
//t        }

#pragma warning disable 414
        int yyExpectingState;
#pragma warning restore 414

        /** computes list of expected tokens on error by tracing the tables.
          * @param state for which to compute the list.
          * @return list of token names.
          */
        internal int[] yyExpectingTokens(int state)
        {
            int token, n, len = 0;
            bool[] ok = new bool[yyNames.Length];

            if ((n = yySindex[state]) != 0)
                for (token = n < 0 ? -n : 0; (token < yyNames.Length) && (n + token < yyTable.Length); ++token)
                    if (yyCheck[n + token] == token && !ok[token] && yyNames[token] != null)
                    {
                        ++ len;
                        ok[token] = true;
                    }

            if ((n = yyRindex[state]) != 0)
                for (token = n < 0 ? -n : 0; (token < yyNames.Length) && (n + token < yyTable.Length); ++token)
                    if (yyCheck[n + token] == token && !ok[token] && yyNames[token] != null)
                    {
                        ++ len;
                        ok[token] = true;
                    }

            int[] result = new int[len];

            for (n = token = 0; n < len;  ++token)
                if (ok[token]) result[n++] = token;

            return result;
        }

        internal string[] yyExpecting(int state)
        {
            int[] tokens = yyExpectingTokens(state);
            string[] result = new string[tokens.Length];

            for (int n = 0; n < tokens.Length; n++)
                result[n++] = yyNames[tokens[n]];

            return result;
        }

        /** the generated parser, with debugging messages.
          * Maintains a state and a value stack, currently with fixed maximum size.
          * @param yyLex scanner.
          * @param yydebug debug message writer implementing yyDebug, or null.
          * @return result of the last reduction, if any.
          * @throws yyException on irrecoverable parse error.
          */
        internal Object yyparse(yyInput yyLex, yyDebug yyd)
        {
//t            this.debug = yyd;
            return yyparse(yyLex);
        }

        /** initial size and increment of the state/value stack [default 256].
          * This is not final so that it can be overwritten outside of invocations
          * of yyparse().
          */
        internal int yyMax;

        /** executed at the beginning of a reduce action.
          * Used as $$ = yyDefault($1), prior to the user-specified action, if any.
          * Can be overwritten to provide deep copy, etc.
          * @param first value for $1, or null.
          * @return first.
          */
        internal Object yyDefault(Object first)
        {
            return first;
        }

        static int[] global_yyStates;
        static object[] global_yyVals;
#pragma warning disable 649
        bool use_global_stacks;
#pragma warning restore 649
        object[] yyVals;					// value stack
        object yyVal;						// value stack ptr
        int yyToken;						// current input
        int yyTop;
        IToken currentToken;

        /** the generated parser.
          * Maintains a state and a value stack, currently with fixed maximum size.
          * @param yyLex scanner.
          * @return result of the last reduction, if any.
          * @throws yyException on irrecoverable parse error.
          */
        internal Object yyparse (yyInput yyLex)
        {
            if (yyMax <= 0)
                yyMax = 256;		            // initial size

            int yyState = 0;                   // state stack ptr
            int[] yyStates;               	    // state stack 
            yyVal = null;
            yyToken = -1;
            int yyErrorFlag = 0;				// #tks to shift

            if (use_global_stacks && global_yyStates != null)
            {
                yyVals = global_yyVals;
                yyStates = global_yyStates;
            }
            else
            {
                yyVals = new object[yyMax];
                yyStates = new int[yyMax];

                if (use_global_stacks)
                {
                    global_yyVals = yyVals;
                    global_yyStates = yyStates;
                }
            }


            /* yyLoop: */
            for (yyTop = 0;; ++ yyTop)
            {
                if (yyTop >= yyStates.Length)
                {			// dynamically increase
                    global::System.Array.Resize(ref yyStates, yyStates.Length+yyMax);
                    global::System.Array.Resize(ref yyVals, yyVals.Length+yyMax);
                }

                yyStates[yyTop] = yyState;
                yyVals[yyTop] = yyVal;
//t
//t                if (debug != null)
//t                    debug.push(yyState, yyVal);

                /* yyDiscarded: */
                while (true)
                {	// discarding a token does not change stack
                    int yyN;

                    if ((yyN = yyDefRed[yyState]) == 0)
                    {	// else [default] reduce (yyN)
                        if (yyToken < 0)
                        {
                            currentToken = yyLex.Advance() ? yyLex.GetToken() : null;
                            yyToken = (currentToken != null) ? currentToken.TokenNumber : 0;
//t
//t                            if (debug != null)
//t                                debug.lex(yyState, yyToken, yyname(yyToken), yyLex.GetValue());
                        }

                        if ((yyN = yySindex[yyState]) != 0 && ((yyN += yyToken) >= 0)
                            && (yyN < yyTable.Length) && (yyCheck[yyN] == yyToken))
                        {
//t                            if (debug != null)
//t                                debug.shift(yyState, yyTable[yyN], yyErrorFlag - 1);
//t
                            yyState = yyTable[yyN];		// shift to yyN
                            yyVal = yyLex.GetValue();
                            yyToken = -1;

                            if (yyErrorFlag > 0)
                                --yyErrorFlag;

                            goto continue_yyLoop;
                        }

                        if ((yyN = yyRindex[yyState]) != 0 && (yyN += yyToken) >= 0
                            && yyN < yyTable.Length && yyCheck[yyN] == yyToken)
                            yyN = yyTable[yyN];			// reduce (yyN)
                        else
                            switch (yyErrorFlag)
                            {
                            case 0:
                                yyExpectingState = yyState;
                                // yyerror(String.Format("syntax error, got token `{0}'", yyname (yyToken)),
                                //         yyExpecting(yyState));
//t
//t                                if (debug != null)
//t                                    debug.error("syntax error");

                                if (yyToken == 0 /*eof*/ || yyToken == eof_token)
                                    throw new yyUnexpectedEof(currentToken);

                                goto case 1;

                            case 1:
                            case 2:
                                yyErrorFlag = 3;

                                do
                                {
                                    if ((yyN = yySindex[yyStates[yyTop]]) != 0
                                        && (yyN += Token.yyErrorCode) >= 0 && yyN < yyTable.Length
                                        && yyCheck[yyN] == Token.yyErrorCode)
                                    {
//t                                        if (debug != null)
//t                                            debug.shift(yyStates[yyTop], yyTable[yyN], 3);
//t
                                        yyState = yyTable[yyN];
                                        yyVal = yyLex.GetValue();
                                        goto continue_yyLoop;
                                    }
//t
//t                                    if (debug != null)
//t                                        debug.pop(yyStates[yyTop]);
                                }
                                while (--yyTop >= 0);
//t
//t                                if (debug != null)
//t                                    debug.reject();

                                throw new yySyntaxError("irrecoverable syntax error", currentToken);

                            case 3:
                                if (yyToken == 0)
                                {
//t                                    if (debug != null)
//t                                        debug.reject();
//t
                                    throw new yySyntaxErrorAtEof("irrecoverable syntax error at end-of-file",
                                                                          currentToken);
                                }

//t                                if (debug != null)
//t                                    debug.discard(yyState, yyToken, yyname(yyToken), yyLex.GetValue());
//t
                                yyToken = -1;
                                goto continue_yyDiscarded;		// leave stack alone
                            }
                    }

                    int yyV = yyTop + 1 - yyLen[yyN];
//t
//t                    if (debug != null)
//t                        debug.reduce(yyState, yyStates[yyV - 1], yyN, YYRules.getRule (yyN), yyLen[yyN]);

                    yyVal = yyV > yyTop ? null : yyVals[yyV]; // yyVal = yyDefault(yyV > yyTop ? null : yyVals[yyV]);

                    switch (yyN)
                    {

case 1:
#line 105 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 2:
#line 109 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 3:
#line 115 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 4:
  case_4();
  break;
case 5:
#line 132 "InteractiveParser.jay"
  {
            yyVal = null;
        }
  break;
case 6:
#line 136 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 7:
  case_7();
  break;
case 12:
#line 159 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 13:
#line 163 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 15:
  case_15();
  break;
case 16:
#line 178 "InteractiveParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 17:
#line 182 "InteractiveParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 18:
#line 188 "InteractiveParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 19:
#line 192 "InteractiveParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 21:
#line 199 "InteractiveParser.jay"
  {
            yyVal = new ElseStatementNode((LToken)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 22:
#line 205 "InteractiveParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 23:
#line 209 "InteractiveParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 24:
#line 215 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 25:
#line 219 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-5+yyTop], (Node)yyVals[-4+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 26:
#line 223 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 27:
#line 229 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 28:
  case_28();
  break;
case 29:
#line 240 "InteractiveParser.jay"
  {
            yyVal = new Node[] { new ParameterNode((Node)yyVals[0+yyTop]) };
        }
  break;
case 30:
  case_30();
  break;
case 31:
#line 252 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 32:
#line 258 "InteractiveParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 33:
#line 262 "InteractiveParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 34:
#line 268 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 35:
#line 274 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 36:
  case_36();
  break;
case 37:
#line 286 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 38:
  case_38();
  break;
case 45:
#line 306 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Pass);
        }
  break;
case 47:
#line 315 "InteractiveParser.jay"
  {
			yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 48:
#line 319 "InteractiveParser.jay"
  {
			yyVal = new UnaryStatementNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 49:
#line 325 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Break);
        }
  break;
case 50:
#line 331 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Continue);
        }
  break;
case 51:
#line 337 "InteractiveParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 52:
#line 341 "InteractiveParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-2+yyTop], (LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 53:
#line 347 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 54:
  case_54();
  break;
case 56:
#line 362 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 57:
  case_57();
  break;
case 69:
#line 391 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Comma);
        }
  break;
case 71:
#line 398 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Assign);
        }
  break;
case 72:
#line 402 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignAddition);
        }
  break;
case 73:
#line 406 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignSubtraction);
        }
  break;
case 74:
#line 410 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignMultiplication);
        }
  break;
case 75:
#line 414 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignDivision);
        }
  break;
case 76:
#line 418 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignIntDivision);
        }
  break;
case 77:
#line 422 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignPower);
        }
  break;
case 78:
#line 426 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignModulo);
        }
  break;
case 79:
#line 430 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticAnd);
        }
  break;
case 80:
#line 434 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticOr);
        }
  break;
case 81:
#line 438 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticXor);
        }
  break;
case 82:
#line 442 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignConcatenation);
        }
  break;
case 83:
#line 446 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignLeftShift);
        }
  break;
case 84:
#line 450 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignRightShift);
        }
  break;
case 86:
#line 457 "InteractiveParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 87:
#line 461 "InteractiveParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 89:
#line 468 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 90:
#line 472 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 92:
#line 479 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 93:
#line 483 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 95:
#line 490 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 96:
#line 494 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 98:
#line 501 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThan);
        }
  break;
case 99:
#line 505 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThan);
        }
  break;
case 100:
#line 509 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThanEqual);
        }
  break;
case 101:
#line 513 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThanEqual);
        }
  break;
case 102:
#line 517 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Equal);
        }
  break;
case 103:
#line 521 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.NotEqual);
        }
  break;
case 104:
#line 525 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Is);
        }
  break;
case 105:
#line 529 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 106:
#line 533 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-3+yyTop], (Node)yyVals[-1+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 108:
#line 540 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticOr);
        }
  break;
case 110:
#line 547 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticXor);
        }
  break;
case 112:
#line 554 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticAnd);
        }
  break;
case 114:
#line 561 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LeftShift);
        }
  break;
case 115:
#line 565 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.RightShift);
        }
  break;
case 117:
#line 572 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Addition);
        }
  break;
case 118:
#line 576 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Subtraction);
        }
  break;
case 119:
#line 580 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Concatenation);
        }
  break;
case 121:
#line 587 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Multiplication);
        }
  break;
case 122:
#line 591 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IntDivision);
        }
  break;
case 123:
#line 595 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Division);
        }
  break;
case 124:
#line 599 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Modulo);
        }
  break;
case 126:
#line 606 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.IncrementPrefix);
        }
  break;
case 127:
#line 610 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.DecrementPrefix);
        }
  break;
case 128:
#line 614 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignNegative);
        }
  break;
case 129:
#line 618 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignPositive);
        }
  break;
case 130:
#line 622 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.BitwiseNot);
        }
  break;
case 132:
#line 629 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Power);
        }
  break;
case 133:
  case_133();
  break;
case 134:
#line 642 "InteractiveParser.jay"
  {
			yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.Ref);
		}
  break;
case 136:
  case_136();
  break;
case 137:
#line 654 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.IncrementPostfix);
        }
  break;
case 138:
#line 658 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.DecrementPostfix);
        }
  break;
case 139:
#line 662 "InteractiveParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-2+yyTop]);
        }
  break;
case 140:
#line 666 "InteractiveParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop]);
        }
  break;
case 141:
#line 672 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 142:
  case_142();
  break;
case 145:
#line 688 "InteractiveParser.jay"
  {
            yyVal = new ArgumentNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-1+yyTop]);
        }
  break;
case 146:
#line 694 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 148:
#line 699 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.False);
        }
  break;
case 149:
#line 703 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.True);
        }
  break;
case 150:
#line 707 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Nil);
        }
  break;
case 151:
#line 711 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.This);
        }
  break;
case 152:
#line 715 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Super);
        }
  break;
case 153:
#line 719 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 154:
#line 725 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.String);
        }
  break;
case 155:
#line 729 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.String);
        }
  break;
case 156:
#line 733 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Imaginary);
        }
  break;
case 157:
#line 737 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Floating);
        }
  break;
case 158:
#line 741 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Integer);
        }
  break;
#line default

                    }

                    yyTop -= yyLen[yyN];
                    yyState = yyStates[yyTop];
                    int yyM = yyLhs[yyN];

                    if (yyState == 0 && yyM == 0)
                    {
//t                        if (debug != null)
//t                            debug.shift(0, yyFinal);
//t
                        yyState = yyFinal;

                        if (yyToken < 0)
                        {
                            currentToken = yyLex.Advance() ? yyLex.GetToken() : null;
                            yyToken = (currentToken != null) ? currentToken.TokenNumber : 0;

//t                            if (debug != null)
//t                                debug.lex(yyState, yyToken,yyname(yyToken), yyLex.GetValue());
                        }

                        if (yyToken == 0)
                        {
//t                            if (debug != null)
//t                                debug.accept(yyVal);
//t
                            return yyVal;
                        }

                        goto continue_yyLoop;
                    }

                    if (((yyN = yyGindex[yyM]) != 0) && ((yyN += yyState) >= 0)
                        && (yyN < yyTable.Length) && (yyCheck[yyN] == yyState))
                        yyState = yyTable[yyN];
                    else
                        yyState = yyDgoto[yyM];

//t                    if (debug != null)
//t                        debug.shift(yyStates[yyTop], yyState);
//t
                    goto continue_yyLoop;

                    continue_yyDiscarded: ;	// implements the named-loop continue: 'continue yyDiscarded'
                }

                continue_yyLoop: ;		// implements the named-loop continue: 'continue yyLoop'
            }
        }

/*
 All more than 3 lines long rules are wrapped into a method
*/
void case_4()
#line 117 "InteractiveParser.jay"
{
            if (yyVals[0+yyTop] == null)
                yyVal = new Node[] { (Node)yyVals[-1+yyTop] };
            else
            {
                var newList = new List<Node>() { (Node)yyVals[-1+yyTop] };
                newList.AddRange((IEnumerable<Node>)yyVals[0+yyTop]);
                yyVal = newList;
            }
        }

void case_7()
#line 138 "InteractiveParser.jay"
{
            if (yyVals[0+yyTop] == null)
                yyVal = new Node[] { (Node)yyVals[-1+yyTop] };
            else
            {
                var newList = new List<Node>() { (Node)yyVals[-2+yyTop] };
                newList.AddRange((IEnumerable<Node>)yyVals[-1+yyTop]);
                yyVal = newList;
            }
        }

void case_15()
#line 168 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-1+yyTop]);
            newList.AddRange((IEnumerable<Node>)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_28()
#line 231 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_30()
#line 242 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_36()
#line 276 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_38()
#line 288 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_54()
#line 349 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_57()
#line 364 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_133()
#line 633 "InteractiveParser.jay"
{
            if (yyVals[0+yyTop] is ConstantNode)
                yyVal = yyVals[0+yyTop];
            else
    			yyVal = new EvalNode((Node)yyVals[0+yyTop]);
		}

void case_136()
#line 647 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_142()
#line 674 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

#line default
   static readonly short [] yyLhs  = {              -1,
    0,    0,    1,    1,    4,    4,    4,    2,    2,    2,
    2,    9,    9,   10,   10,    5,    5,   12,   12,   12,
   13,    6,    6,    7,    7,    7,   14,   14,   15,   15,
   17,    8,    8,   18,   19,   19,   20,   20,    3,    3,
    3,    3,    3,    3,   21,   22,   23,   23,   24,   25,
   26,   26,   27,   27,   28,   29,   29,   16,   16,   30,
   30,   30,   30,   30,   30,   30,   11,   31,   31,   32,
   32,   32,   32,   32,   32,   32,   32,   32,   32,   32,
   32,   32,   32,   32,   33,   33,   33,   34,   34,   34,
   35,   35,   35,   36,   36,   36,   37,   37,   37,   37,
   37,   37,   37,   37,   37,   37,   38,   38,   39,   39,
   40,   40,   41,   41,   41,   42,   42,   42,   42,   43,
   43,   43,   43,   43,   44,   44,   44,   44,   44,   44,
   45,   45,   46,   46,   47,   47,   47,   47,   47,   47,
   49,   49,   50,   50,   51,   48,   48,   48,   48,   48,
   48,   48,   48,   52,   52,   52,   52,   52,
  };
   static readonly short [] yyLen = {           2,
    2,    1,    1,    2,    1,    2,    3,    1,    1,    1,
    1,    2,    4,    1,    2,    4,    5,    4,    5,    1,
    3,    4,    5,    7,    6,    4,    1,    3,    1,    3,
    1,    7,    4,    1,    1,    3,    1,    3,    1,    1,
    1,    1,    1,    1,    1,    1,    1,    2,    1,    1,
    2,    3,    1,    3,    1,    1,    3,    1,    1,    1,
    1,    1,    1,    1,    1,    1,    1,    1,    3,    1,
    3,    3,    3,    3,    3,    3,    3,    3,    3,    3,
    3,    3,    3,    3,    1,    5,    5,    1,    3,    3,
    1,    3,    3,    1,    2,    2,    1,    3,    3,    3,
    3,    3,    3,    3,    3,    4,    1,    3,    1,    3,
    1,    3,    1,    3,    3,    1,    3,    3,    3,    1,
    3,    3,    3,    3,    1,    2,    2,    2,    2,    2,
    1,    3,    1,    2,    1,    3,    2,    2,    3,    4,
    1,    3,    1,    1,    3,    1,    1,    1,    1,    1,
    1,    1,    3,    1,    1,    1,    1,    1,
  };
   static readonly short [] yyDefRed = {            0,
   60,   61,   62,   63,   64,   65,   66,   49,    0,   50,
    0,  149,    0,    0,  150,    0,   45,    0,    0,    0,
  152,  151,  148,    0,   58,  154,  155,  156,  157,  158,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    2,
    0,    8,    9,   10,   11,   46,  146,   39,   40,   41,
   42,   43,   44,   59,   67,    0,    0,    0,    0,   91,
    0,    0,    0,    0,    0,    0,    0,  120,    0,  131,
    0,  135,  147,   34,    0,    0,   27,    0,   56,    0,
   53,    0,   95,    0,    0,   48,    0,  126,  127,   96,
  129,  128,  130,    0,    1,    0,    4,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  137,
  138,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  153,    0,   69,   72,   73,   82,   77,
   74,   76,   75,   78,   83,   84,   79,   81,   80,   71,
    0,    0,    0,    0,   92,   93,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  122,  121,  123,  124,  132,  136,  139,
    0,  143,    0,  141,  144,    0,    0,   33,   37,    0,
    0,   26,   28,    0,    0,   31,   29,    0,   54,   57,
    0,    7,    0,    0,    0,    0,    0,  140,    0,   12,
    0,    0,    0,    0,    0,    0,    0,    0,   17,   20,
   23,    0,    0,  145,  142,   14,    0,    0,    0,   38,
   25,   30,    0,    0,    0,   13,   15,   32,   24,    0,
   21,    0,   19,
  };
  protected static readonly short [] yyDgoto  = {            38,
  207,   40,   41,   97,   42,   43,   44,   45,  208,  247,
   46,  239,  240,   76,  215,   47,  217,   75,  210,  211,
   48,   49,   50,   51,   52,   53,   80,   81,   82,   54,
   55,   56,   57,   58,   59,   60,   61,   62,   63,   64,
   65,   66,   67,   68,   69,   70,   71,   72,  203,  204,
  205,   73,
  };
  protected static readonly short [] yySindex = {         3255,
    0,    0,    0,    0,    0,    0,    0,    0, -174,    0,
 -174,    0, 3552, -174,    0, 3552,    0, -253,  854, 3552,
    0,    0,    0, 3552,    0,    0,    0,    0,    0,    0,
 3673, 3673, 3552, 3673, 3673, 3673, 3552,    0, -219,    0,
  -11,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,   30,  682,  -61, -252,    0,
  -41,  -46,  -10,   56, -278,   22,  -34,    0, -225,    0,
  -35,    0,    0,    0,  -16,   65,    0,   59,    0,   84,
    0,   73,    0, -174,  -35,    0,   79,    0,    0,    0,
    0,    0,    0,   90,    0, 3438,    0, 3552, 3552, 3552,
 3552, 3552, 3552, 3552, 3552, 3552, 3552, 3552, 3552, 3552,
 3552, 3552, 3552, 3552, 3552, 3552, 3552, 3552, 3588, 3673,
 3673, 3673, 3673, 3673, 3673, 3673, 3673, 3673, 3673, 3673,
 3673, 3673, 3673, 3673, 3673, 3673, 3673, 3673,  831,    0,
    0, -174, 3464, 3356, -174, 3356, -174,  -21, 3356, -174,
 -174,   84, 3356,    0,  -11,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
 -213, -252, -252,  -58,    0,    0, 3673,  -46,  -46,  -46,
  -46,  -46,  -46,  -46,  -46,  -10,   56, -278,   22,   22,
  -34,  -34,  -34,    0,    0,    0,    0,    0,    0,    0,
   80,    0,   28,    0,    0, -118, -116,    0,    0,   29,
   96,    0,    0,   86,   41,    0,    0, -172,    0,    0,
 -132,    0, 3552, 3552,  -46, 3552, 3552,    0, 3255,    0,
 -174,   94, -174, 3356, -174,   95, 3552,   97,    0,    0,
    0, -273, -273,    0,    0,    0, 3007,   96, 3356,    0,
    0,    0, 3356,   98, 3356,    0,    0,    0,    0, 3356,
    0, -172,    0,
  };
  protected static readonly short [] yyRindex = {            0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  -53,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
 -100,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,   -9,  -32,  211, 1158,    0,
 3047, 2168, 2044, 1805, 1658, 1389,  922,    0,  599,    0,
  449,    0,    0,    0,    0,    0,    0,    0,    0,  -49,
    0,  -29,    0,    0,  478,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  -99,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  -43,    0,    0,  -98,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0, 1929, 3129,    0,    0,    0,    0, 2283, 2312, 2407,
 2526, 2646, 2675, 2779, 2889, 2139, 1900, 1776, 1418, 1536,
  951, 1046, 1294,    0,    0,    0,    0,    0,    0,    0,
  570,    0,    0,    0,    0,    0,    0,    0,    0,    0,
   68,    0,    0,    0,    0,    0,    0,    1,    0,    0,
   75,    0,    0,    0, 3018,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  332,  714,    0,    0,    0,    0,   72,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  151,    0,
  };
  protected static readonly short [] yyGindex = {         -200,
    4,    0,   64,    6,    0,    0,    0,    0, -110,    0,
   -6,  -97,  -59,    0,    0,   26,  -72,    0,    0,  -67,
    0,    0,    0,    0,    0,    0,   82,   17,    0,    0,
   74,  -48,    0,  -91,    7,   12,    0,  -23,   43,   47,
   49,   -5,    2,   45,    0,   46,  167,    0,    0,  -40,
    0,    0,
  };
  protected static readonly short [] yyTable = {           224,
   16,  116,  138,   39,  143,   47,   78,  136,   70,   51,
  142,   70,  137,   86,   55,   52,  117,   87,  125,  214,
  126,  171,  114,  145,  174,   70,   70,   83,  246,   55,
   94,   68,   84,   16,   74,  212,   77,   95,  218,   79,
   16,  144,  221,   16,   90,   16,  257,   96,   68,   68,
  157,  158,  159,  160,  161,  162,  163,  164,  165,  166,
  167,  168,  169,  170,  132,  223,  133,  130,  228,  232,
  131,  227,  231,   98,   22,   88,   89,  127,   91,   92,
   93,  236,  114,  128,  235,  115,    1,    2,    3,    4,
    5,    6,    7,  129,  202,  178,  179,  180,  181,  182,
  183,  184,  185,  118,  148,  237,  238,   22,   35,   79,
  147,   35,   36,  139,   22,   36,  149,   22,  151,   22,
  172,  173,  146,  251,  189,  190,   16,  150,  175,  176,
  154,  242,  243,  191,  192,  193,  153,  226,  258,  229,
  230,  233,  259,  234,  261,  115,  238,  134,   25,  262,
   18,  249,  253,  225,  255,  260,    3,    5,    6,  155,
  222,  241,  252,  248,  263,  152,  219,  199,  201,  186,
  209,  156,  213,  216,  187,   79,  220,  188,  202,  194,
  195,  196,  197,   18,  198,   85,  245,    0,    0,    0,
   18,    0,    0,   18,    0,   18,    0,    0,    0,    0,
   22,    0,    0,   47,    0,    0,    0,   51,    0,    0,
    0,    0,    0,   52,    0,    0,    0,    0,    0,  244,
    0,    0,    0,  113,   70,    0,    0,   55,    0,    0,
  254,    0,   39,    0,  114,    0,    0,  114,    0,    1,
    2,    3,    4,    5,    6,    7,    0,   68,  119,    0,
   39,   85,  201,    0,   85,    0,  209,    0,  250,   16,
  216,   16,   16,   16,   16,   16,   16,   16,   85,   85,
   16,   85,    0,   16,   16,   16,   18,    0,    0,    0,
    0,    0,   16,    0,    0,   16,   16,    0,    0,    0,
    0,    0,    0,    0,   16,   16,  140,  115,  141,   16,
  115,   25,    0,   16,   16,  120,   16,  135,  121,  122,
   16,  123,   16,  124,   16,    0,    0,    0,    0,    0,
   16,    0,    0,   16,   16,    0,   16,   16,   16,   16,
    0,    0,   16,   22,   16,   22,   22,   22,   22,   22,
   22,   22,    0,    0,   22,    0,    0,   22,   22,   22,
    0,    0,    0,    0,    0,    0,   22,    0,    0,   22,
   22,    0,    0,    0,    0,    0,    0,    0,   22,   22,
    0,    0,   87,   22,    0,   87,    0,   22,   22,    0,
   22,    0,    0,    0,   22,    0,   22,    0,   22,   87,
   87,    0,   87,    0,   22,    0,    0,   22,   22,    0,
   22,   22,   22,   22,    0,    0,   22,    0,   22,   18,
    0,   18,   18,   18,   18,   18,   18,   18,    0,    0,
   18,    0,    0,   18,   18,   18,    0,    0,    0,    0,
    0,    0,   18,    0,    0,   18,   18,    0,    0,    0,
    0,    0,    0,    0,   18,   18,    0,    0,    0,   18,
    0,    0,    0,   18,   18,    0,   18,    0,    0,    0,
   18,    0,   18,    0,   18,    0,    0,   85,    0,    0,
   18,    0,    0,   18,   18,    0,   18,   18,   18,   18,
    0,    0,   18,    0,   18,  133,  133,    0,    0,  133,
  133,  133,  133,  133,    0,  133,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  133,  133,  133,  133,
  133,  133,    0,    0,  134,  134,    0,    0,  134,  134,
  134,  134,  134,    0,  134,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  134,  134,  134,  134,  134,
  134,    0,  133,   85,    0,   85,    0,   85,   85,    0,
   85,   85,    0,   85,   85,   85,    0,    0,   85,    0,
    0,    0,    0,    0,    0,    0,    0,   85,   85,    0,
   85,  134,  133,    0,  133,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,   87,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  134,    0,  134,    0,    0,  146,  146,    0,  146,
  146,  146,  146,  146,  146,  146,  146,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  146,
  146,  146,  146,    0,    0,  125,  125,    0,    0,  125,
  125,  125,  125,  125,    0,  125,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  125,  125,  125,  125,
  125,  125,    0,  146,   87,    0,   87,    0,   87,   87,
    0,   87,   87,    0,   87,   87,   87,    0,    0,   87,
    0,    0,    0,    0,    0,    0,    0,    0,   87,   87,
    0,   87,  125,  146,    0,  146,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  133,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  133,    0,    0,
    0,    0,  125,    0,  125,    0,    0,  133,    0,    0,
    0,    0,    0,  133,  134,    0,    0,    0,  133,    0,
    0,    0,  112,    0,  133,    0,  134,    0,    0,    0,
    0,    0,    0,    0,   86,    0,  134,   86,    0,    0,
    0,    0,  134,    0,    0,    0,    0,  134,    0,    0,
    0,   86,   86,  134,   86,    0,    0,    0,    0,    0,
    0,  133,    0,  133,    0,  133,  133,  133,  133,  133,
  133,  133,  133,  133,  133,  133,  133,  133,  133,  133,
    0,  133,    0,  133,  133,  133,  133,  133,  133,    0,
  134,    0,  134,    0,  134,  134,  134,  134,  134,  134,
  134,  134,  134,  134,  134,  134,  134,  134,  134,    0,
  134,    0,  134,  134,  134,  134,  134,  134,  146,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  146,  125,    0,    0,    0,  146,
    0,    0,    0,    0,    0,  146,    0,  125,    0,    0,
   37,    0,    0,    0,    0,    0,    0,  125,    0,    0,
    0,    0,    0,  125,    0,    0,    0,    0,  125,    0,
    0,    0,    0,   37,  125,    0,    0,    0,    0,    0,
    0,  146,  146,  146,  146,    0,  146,  146,  146,  146,
  146,  146,  146,  146,  146,  146,  146,  146,  146,  146,
  146,    0,  146,    0,  146,  146,  146,  146,  146,  146,
    0,  125,    0,  125,    0,  125,  125,    0,  125,  125,
  125,  125,  125,  125,  125,  125,  125,  125,  125,  125,
    0,  125,    0,  125,  125,  125,  125,  125,  125,  116,
    0,    0,  116,    0,  116,  116,  116,    0,    0,    0,
   86,    0,    0,    0,    0,    0,    0,    0,    0,  116,
  116,  116,  116,  116,  116,    0,    0,    0,  117,    0,
    0,  117,    0,  117,  117,  117,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  117,  117,
  117,  117,  117,  117,   99,  116,  100,    0,  101,  102,
    0,  103,  104,    0,  105,  106,  107,    0,    0,  108,
    0,    0,    0,    0,    0,    0,    0,    0,  109,  110,
    0,  111,    0,    0,  117,  116,   86,  116,   86,    0,
   86,   86,    0,   86,   86,    0,   86,   86,   86,    0,
    0,   86,    0,    0,    0,    0,    0,    0,    0,    0,
   86,   86,    0,   86,  117,    0,  117,    0,    0,    0,
    0,    0,    0,  118,    0,    0,  118,    0,  118,  118,
  118,    1,    2,    3,    4,    5,    6,    7,    0,    0,
    0,    0,    0,  118,  118,  118,  118,  118,  118,    0,
    0,    0,   12,    0,    1,    2,    3,    4,    5,    6,
    7,    0,    0,    0,   15,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   19,   12,    0,    0,    0,  118,
   21,    0,   22,    0,   23,    0,    0,   15,    0,    0,
    0,    0,    0,   25,   26,    0,   27,   28,   29,   30,
    0,    0,    0,   21,    0,   22,    0,   23,    0,  118,
    0,  118,    0,    0,    0,    0,   25,   26,  116,   27,
   28,   29,   30,    0,    0,    0,    0,    0,    0,    0,
  116,    0,    0,    0,    0,    0,    0,    0,   88,    0,
  116,   88,    0,    0,    0,    0,  116,  117,    0,    0,
    0,  116,    0,    0,    0,   88,   88,  116,   88,  117,
   88,    0,    0,    0,    0,    0,    0,    0,    0,  117,
    0,    0,    0,    0,    0,  117,    0,    0,    0,    0,
  117,    0,    0,    0,    0,    0,  117,    0,    0,    0,
    0,    0,    0,    0,  116,    0,  116,    0,  116,  116,
    0,  116,  116,    0,  116,  116,  116,  116,  116,  116,
  116,  116,  116,    0,  116,    0,  116,  116,  116,  116,
  116,  116,    0,  117,    0,  117,    0,  117,  117,    0,
  117,  117,    0,  117,  117,  117,  117,  117,  117,  117,
  117,  117,  118,  117,    0,  117,  117,  117,  117,  117,
  117,    0,    0,    0,  118,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  118,    0,    0,    0,    0,    0,
  118,  119,    0,    0,  119,  118,  119,  119,  119,    0,
    0,  118,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  119,  119,  119,  119,  119,  119,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  118,    0,
  118,    0,  118,  118,    0,  118,  118,  119,  118,  118,
  118,  118,  118,  118,  118,  118,  118,    0,  118,    0,
  118,  118,  118,  118,  118,  118,    0,    0,    0,    0,
    0,    0,    0,    0,   88,    0,    0,  119,    0,  119,
    0,    0,    0,    0,    0,    0,  113,    0,    0,  113,
    0,    0,  113,    0,    0,    0,   88,    0,    0,    0,
    0,    0,   88,    0,    0,    0,  113,  113,  113,  113,
  113,  113,    0,   88,    0,  114,    0,    0,  114,    0,
    0,  114,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  114,  114,  114,  114,  114,
  114,    0,  113,    0,    0,    0,    0,    0,    0,    0,
   88,    0,   88,    0,   88,   88,    0,   88,   88,    0,
   88,   88,   88,    0,    0,   88,    0,    0,    0,    0,
    0,  114,  113,    0,   88,   88,   88,   88,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  114,    0,    0,    0,    0,    0,    0,    0,    0,
  119,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  119,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  119,  115,    0,    0,  115,    0,  119,  115,
    0,    0,    0,  119,    0,    0,    0,    0,    0,  119,
    0,    0,    0,  115,  115,  115,  115,  115,  115,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  119,    0,  119,  115,
  119,  119,    0,  119,  119,    0,  119,  119,  119,  119,
  119,  119,  119,  119,  119,  113,  119,    0,  119,  119,
  119,  119,  119,  119,    0,    0,    0,  113,    0,  115,
    0,    0,    0,    0,    0,    0,    0,  113,    0,    0,
    0,    0,    0,  113,  114,    0,    0,    0,  113,    0,
    0,    0,    0,    0,  113,    0,  114,    0,    0,    0,
    0,    0,    0,    0,    0,  111,  114,    0,  111,    0,
    0,  111,  114,    0,    0,    0,    0,  114,    0,    0,
    0,    0,    0,  114,    0,  111,  111,  111,  111,  111,
  111,  113,    0,  113,    0,  113,  113,    0,  113,  113,
    0,  113,  113,  113,  113,  113,  113,  113,  113,  113,
    0,  113,    0,  113,  113,  113,  113,  113,  113,    0,
  114,  111,  114,    0,  114,  114,    0,  114,  114,    0,
  114,  114,  114,  114,  114,  114,  114,  114,  114,    0,
  114,    0,  114,  114,  114,  114,  114,  114,    0,    0,
    0,  111,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  115,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  115,    0,    0,    0,    0,    0,
    0,    0,    0,  112,  115,    0,  112,    0,    0,  112,
  115,    0,    0,    0,    0,  115,    0,    0,    0,    0,
    0,  115,    0,  112,  112,  112,  112,  112,  112,    0,
    0,    0,    0,    0,    0,  109,    0,    0,  109,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  109,  109,  109,  109,  109,  109,  115,  112,
  115,    0,  115,  115,    0,  115,  115,    0,  115,  115,
  115,  115,  115,  115,  115,  115,  115,    0,  115,    0,
  115,  115,  115,  115,  115,  115,    0,    0,  109,  112,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  111,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  111,    0,  109,    0,
    0,    0,    0,    0,    0,    0,  111,    0,    0,    0,
  110,    0,  111,  110,    0,    0,    0,  111,    0,    0,
    0,    0,    0,  111,    0,    0,    0,  110,  110,  110,
  110,  110,  110,    0,    0,    0,    0,    0,    0,   89,
    0,    0,   89,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   89,   89,    0,   89,
  111,   89,  111,  110,  111,  111,    0,  111,  111,    0,
  111,  111,  111,    0,  111,  111,    0,  111,  111,    0,
  111,    0,  111,  111,  111,  111,  111,  111,    0,    0,
    0,    0,    0,  110,    0,    0,    0,    0,    0,    0,
    0,    0,  112,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  112,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  112,    0,    0,    0,    0,    0,
  112,  109,    0,    0,    0,  112,    0,    0,    0,    0,
    0,  112,    0,  109,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  109,  107,    0,    0,  107,    0,  109,
    0,    0,    0,    0,  109,    0,    0,    0,    0,    0,
  109,  107,  107,  107,  107,  107,  107,    0,  112,    0,
  112,    0,  112,  112,    0,  112,  112,    0,  112,  112,
  112,    0,  112,  112,    0,  112,  112,    0,  112,    0,
  112,  112,  112,  112,  112,  112,    0,  109,    0,  109,
    0,  109,  109,    0,  109,  109,    0,  109,  109,  109,
    0,  109,  109,    0,  109,  109,  110,  109,    0,  109,
  109,  109,  109,  109,  109,    0,    0,  107,  110,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  110,  108,
    0,    0,  108,    0,  110,   89,    0,    0,    0,  110,
    0,    0,    0,    0,    0,  110,  108,  108,  108,  108,
  108,  108,    0,    0,    0,    0,    0,   89,   97,    0,
    0,   97,    0,   89,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   89,   97,   97,   97,   97,   97,
   97,    0,  110,    0,  110,    0,  110,  110,    0,  110,
  110,    0,  110,  110,  110,    0,  110,  110,    0,  110,
  110,    0,  110,    0,  110,  110,  110,  110,  110,  110,
    0,   89,  108,   89,    0,   89,   89,    0,   89,   89,
    0,   89,   89,   89,    0,    0,   89,    0,    0,    0,
    0,    0,    0,    0,    0,   89,   89,   89,   89,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  107,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  107,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  107,  104,    0,    0,  104,    0,  107,    0,
    0,    0,    0,  107,    0,    0,    0,    0,    0,  107,
  104,  104,  104,  104,  104,  104,    0,    0,    0,    0,
    0,    0,  100,    0,    0,  100,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  100,
  100,  100,  100,  100,  100,    0,  107,    0,  107,    0,
  107,  107,    0,  107,  107,    0,  107,  107,  107,    0,
  107,  107,    0,  107,  107,  108,  107,    0,  107,  107,
  107,  107,  107,  107,    0,    0,    0,  108,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  108,    0,    0,
    0,    0,    0,  108,   97,    0,    0,    0,  108,    0,
    0,    0,    0,    0,  108,    0,   97,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   97,  101,    0,    0,
  101,    0,   97,    0,    0,    0,    0,   97,    0,    0,
    0,    0,    0,   97,  101,  101,  101,  101,  101,  101,
    0,  108,    0,  108,    0,  108,  108,    0,  108,  108,
    0,  108,  108,  108,    0,  108,  108,    0,  108,  108,
    0,  108,    0,  108,  108,  108,  108,  108,  108,    0,
   97,    0,   97,    0,   97,   97,    0,   97,   97,    0,
   97,   97,   97,    0,   97,   97,    0,   97,   97,    0,
   97,    0,   97,   97,   97,   97,   97,   97,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  104,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  104,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  104,    0,    0,    0,    0,  102,  104,  100,  102,
    0,    0,  104,    0,    0,    0,    0,    0,  104,    0,
  100,    0,    0,  102,  102,  102,  102,  102,  102,    0,
  100,    0,    0,    0,    0,    0,  100,    0,    0,    0,
    0,  100,    0,    0,    0,    0,    0,  100,    0,    0,
    0,    0,    0,    0,    0,  104,    0,  104,    0,  104,
  104,    0,  104,  104,    0,  104,  104,  104,    0,  104,
  104,    0,  104,  104,    0,  104,    0,  104,  104,  104,
  104,  104,  104,    0,  100,    0,  100,    0,  100,  100,
    0,  100,  100,    0,  100,  100,  100,    0,  100,  100,
    0,  100,  100,  101,  100,    0,  100,  100,  100,  100,
  100,  100,    0,    0,    0,  101,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  101,  103,    0,    0,  103,
    0,  101,    0,    0,    0,    0,  101,    0,    0,    0,
    0,    0,  101,  103,  103,  103,  103,  103,  103,    0,
    0,    0,    0,    0,    0,  105,    0,    0,  105,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  105,  105,  105,  105,  105,  105,    0,  101,
    0,  101,    0,  101,  101,    0,  101,  101,    0,  101,
  101,  101,    0,  101,  101,    0,  101,  101,    0,  101,
    0,  101,  101,  101,  101,  101,  101,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  102,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  102,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  102,    0,    0,    0,    0,    0,
  102,    0,    0,    0,    0,  102,    0,    0,    0,   98,
    0,  102,   98,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   98,   98,   98,   98,
   98,   98,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  102,    0,
  102,    0,  102,  102,    0,  102,  102,    0,  102,  102,
  102,    0,  102,  102,    0,  102,  102,    0,  102,    0,
  102,  102,  102,  102,  102,  102,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  103,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  103,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  103,    0,    0,    0,    0,   99,
  103,  105,   99,    0,    0,  103,    0,    0,    0,    0,
    0,  103,    0,  105,    0,    0,   99,   99,   99,   99,
   99,   99,    0,  105,    0,    0,    0,    0,    0,  105,
    0,    0,    0,    0,  105,    0,    0,    0,    0,    0,
  105,    0,    0,    0,    0,    0,    0,    0,  103,    0,
  103,    0,  103,  103,    0,  103,  103,    0,  103,  103,
  103,    0,  103,  103,    0,  103,  103,    0,  103,    0,
  103,  103,  103,  103,  103,  103,    0,  105,    0,  105,
    0,  105,  105,    0,  105,  105,    0,  105,  105,  105,
    0,  105,  105,    0,  105,  105,    0,  105,    0,  105,
  105,  105,  105,  105,  105,   98,    0,    0,    0,   33,
    0,    0,    0,    0,    0,    0,   37,   98,    0,   34,
    0,   35,    0,    0,    0,    0,    0,   98,  106,    0,
    0,  106,    0,   98,    0,    0,    0,    0,   98,    0,
    0,    0,    0,    0,   98,  106,  106,  106,  106,  106,
  106,    0,    0,    0,    0,    0,    0,   94,    0,    0,
   94,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   94,   94,    0,   94,    0,   94,
    0,   98,    0,   98,    0,   98,   98,    0,   98,   98,
    0,   98,   98,   98,    0,   98,   98,    0,   98,   98,
    0,   98,   36,   98,   98,   98,   98,   98,   98,    0,
    0,    0,    0,    0,    0,   99,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,   99,    0,    0,
    0,    0,    0,    0,    0,    0,    0,   99,    0,   90,
    0,    0,   90,   99,    0,    0,    0,    0,   99,    0,
    0,    0,    0,    0,   99,    0,   90,   90,    0,   90,
    0,   90,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   99,    0,   99,    0,   99,   99,    0,   99,   99,
    0,   99,   99,   99,    0,   99,   99,    0,   99,   99,
    0,   99,    0,   99,   99,   99,   99,   99,   99,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  256,    0,    1,    2,    3,
    4,    5,    6,    7,  106,    0,    8,    0,    0,    9,
   10,   11,    0,    0,    0,    0,  106,   33,   12,    0,
    0,   13,   14,    0,   37,    0,  106,   34,    0,   35,
   15,   16,  106,   94,    0,   17,    0,  106,    0,   18,
   19,    0,   20,  106,    0,   94,   21,    0,   22,    0,
   23,    0,    0,    0,    0,   94,   24,    0,    0,   25,
   26,   94,   27,   28,   29,   30,    0,    0,   31,    0,
   32,    0,   94,    0,    0,    0,    0,    0,    0,    0,
  106,    0,  106,    0,  106,  106,    0,  106,  106,    0,
  106,  106,  106,    0,  106,  106,    0,  106,  106,    0,
  106,    0,  106,  106,  106,  106,  106,  106,    0,   94,
   36,   94,    0,   94,   94,   90,   94,   94,   33,   94,
   94,   94,    0,    0,   94,   37,    0,    0,   34,    0,
   35,    0,   94,   94,   94,   94,   94,   90,    0,    0,
    0,    0,    0,   90,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   90,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   90,    0,   90,    0,   90,   90,    0,   90,   90,
   33,   90,   90,   90,    0,    0,   90,   37,    0,    0,
   34,   36,   35,    0,    0,   90,   90,   90,   90,    0,
    0,    0,    0,    0,    0,    0,   33,    0,    0,    0,
    0,    0,    0,   37,  200,    0,   34,    0,   35,    0,
    0,    0,    0,    0,    0,    1,    2,    3,    4,    5,
    6,    7,    0,    0,    8,    0,    0,    9,   10,   11,
    0,    0,    0,    0,    0,    0,   12,    0,    0,   13,
   14,    0,    0,    0,    0,    0,    0,    0,   15,   16,
    0,    0,    0,   17,    0,    0,    0,   18,   19,    0,
   20,    0,    0,   36,   21,    0,   22,    0,   23,    0,
    0,    0,    0,    0,   24,    0,    0,   25,   26,    0,
   27,   28,   29,   30,   33,    0,   31,    0,   32,   36,
    0,   37,    0,    0,   34,    0,   35,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  206,    0,    0,    0,    1,    2,    3,    4,
    5,    6,    7,    0,    0,    8,    0,   37,    0,   10,
   34,    0,   35,    0,    0,    0,    0,   12,    0,    0,
    0,   14,    0,    0,    0,    0,    0,    0,    0,   15,
   16,    0,    0,    0,   17,    0,    0,    0,   18,   19,
    0,   20,    0,    0,    0,   21,    0,   22,    0,   23,
    0,    0,    0,    0,    0,    0,    0,   36,   25,   26,
    0,   27,   28,   29,   30,    0,    0,   31,    0,   32,
    0,    0,    0,    0,    0,    0,    0,    0,    1,    2,
    3,    4,    5,    6,    7,    0,    0,    8,    0,    0,
    0,   10,   37,   36,    0,   34,    0,   35,    0,   12,
    0,    0,    0,   14,    1,    2,    3,    4,    5,    6,
    7,   15,   16,    0,    0,    0,   17,    0,    0,    0,
   18,   19,    0,   20,    0,   12,    0,   21,    0,   22,
    0,   23,    0,    0,    0,    0,    0,   15,   16,    0,
   25,   26,    0,   27,   28,   29,   30,   19,    0,   31,
    0,   32,    0,   21,    0,   22,    0,   23,    0,    0,
    0,    0,    0,    0,    0,    0,   25,   26,    0,   27,
   28,   29,   30,    0,    0,   31,    0,   32,   36,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    1,    2,    3,    4,    5,    6,    7,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,   12,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,   15,   16,    0,    1,    2,
    3,    4,    5,    6,    7,   19,    0,    0,    0,    0,
    0,   21,    0,   22,    0,   23,    0,    0,    0,   12,
    0,    0,    0,    0,   25,   26,    0,   27,   28,   29,
   30,   15,  177,   31,    0,   32,    0,    0,    0,    0,
    0,   19,    0,    0,    0,    0,    0,   21,    0,   22,
    0,   23,    0,    0,    0,    0,    0,    0,    0,    0,
   25,   26,    0,   27,   28,   29,   30,    0,    0,   31,
    0,   32,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    1,    2,    3,    4,    5,    6,    7,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   12,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   15,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   19,    0,    0,    0,
    0,    0,   21,    0,   22,    0,   23,    0,    0,    0,
    0,    0,    0,    0,    0,   25,   26,    0,   27,   28,
   29,   30,    0,    0,   31,    0,   32,
  };
  protected static readonly short [] yyCheck = {            58,
    0,   63,   37,    0,   40,   59,   13,   42,   41,   59,
   46,   44,   47,   20,   44,   59,  269,   24,   60,   41,
   62,  113,  296,   40,  116,   58,   59,   16,  229,   59,
   37,   41,  286,   33,    9,  146,   11,  257,  149,   14,
   40,   58,  153,   43,   33,   45,  247,   59,   58,   59,
   99,  100,  101,  102,  103,  104,  105,  106,  107,  108,
  109,  110,  111,  112,   43,  279,   45,  346,   41,   41,
  349,   44,   44,   44,    0,   31,   32,  124,   34,   35,
   36,   41,  296,   94,   44,  359,  261,  262,  263,  264,
  265,  266,  267,   38,  143,  119,  120,  121,  122,  123,
  124,  125,  126,  356,   40,  278,  279,   33,   41,   84,
   46,   44,   41,  339,   40,   44,   58,   43,   46,   45,
  114,  115,   58,  234,  130,  131,  126,   44,  117,  118,
   41,  223,  224,  132,  133,  134,   58,   58,  249,  258,
  257,   46,  253,   58,  255,  359,  279,  126,  323,  260,
    0,   58,   58,  177,   58,   58,  257,  257,  257,   96,
  155,  221,  235,  231,  262,   84,  150,  142,  143,  127,
  145,   98,  147,  148,  128,  150,  151,  129,  227,  135,
  136,  137,  138,   33,  139,   19,  227,   -1,   -1,   -1,
   40,   -1,   -1,   43,   -1,   45,   -1,   -1,   -1,   -1,
  126,   -1,   -1,  257,   -1,   -1,   -1,  257,   -1,   -1,
   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,  226,
   -1,   -1,   -1,  285,  257,   -1,   -1,  257,   -1,   -1,
  237,   -1,  229,   -1,  296,   -1,   -1,  296,   -1,  261,
  262,  263,  264,  265,  266,  267,   -1,  257,  290,   -1,
  247,   41,  227,   -1,   44,   -1,  231,   -1,  233,  259,
  235,  261,  262,  263,  264,  265,  266,  267,   58,   59,
  270,   61,   -1,  273,  274,  275,  126,   -1,   -1,   -1,
   -1,   -1,  282,   -1,   -1,  285,  286,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,  295,  332,  359,  334,  299,
  359,  323,   -1,  303,  304,  347,  306,  342,  350,  351,
  310,  353,  312,  355,  314,   -1,   -1,   -1,   -1,   -1,
  320,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,   -1,  332,  259,  334,  261,  262,  263,  264,  265,
  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,   -1,   -1,  282,   -1,   -1,  285,
  286,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,
   -1,   -1,   41,  299,   -1,   44,   -1,  303,  304,   -1,
  306,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,   58,
   59,   -1,   61,   -1,  320,   -1,   -1,  323,  324,   -1,
  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,  259,
   -1,  261,  262,  263,  264,  265,  266,  267,   -1,   -1,
  270,   -1,   -1,  273,  274,  275,   -1,   -1,   -1,   -1,
   -1,   -1,  282,   -1,   -1,  285,  286,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,  295,   -1,   -1,   -1,  299,
   -1,   -1,   -1,  303,  304,   -1,  306,   -1,   -1,   -1,
  310,   -1,  312,   -1,  314,   -1,   -1,  257,   -1,   -1,
  320,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,   -1,  332,   -1,  334,   37,   38,   -1,   -1,   41,
   42,   43,   44,   45,   -1,   47,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,   -1,   37,   38,   -1,   -1,   41,   42,
   43,   44,   45,   -1,   47,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   58,   59,   60,   61,   62,
   63,   -1,   94,  333,   -1,  335,   -1,  337,  338,   -1,
  340,  341,   -1,  343,  344,  345,   -1,   -1,  348,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  357,  358,   -1,
  360,   94,  124,   -1,  126,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  124,   -1,  126,   -1,   -1,   37,   38,   -1,   40,
   41,   42,   43,   44,   45,   46,   47,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   60,
   61,   62,   63,   -1,   -1,   37,   38,   -1,   -1,   41,
   42,   43,   44,   45,   -1,   47,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,   94,  333,   -1,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,   -1,  348,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  357,  358,
   -1,  360,   94,  124,   -1,  126,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  269,   -1,   -1,
   -1,   -1,  124,   -1,  126,   -1,   -1,  279,   -1,   -1,
   -1,   -1,   -1,  285,  257,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   61,   -1,  296,   -1,  269,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   41,   -1,  279,   44,   -1,   -1,
   -1,   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,
   -1,   58,   59,  296,   61,   -1,   -1,   -1,   -1,   -1,
   -1,  333,   -1,  335,   -1,  337,  338,  339,  340,  341,
  342,  343,  344,  345,  346,  347,  348,  349,  350,  351,
   -1,  353,   -1,  355,  356,  357,  358,  359,  360,   -1,
  333,   -1,  335,   -1,  337,  338,  339,  340,  341,  342,
  343,  344,  345,  346,  347,  348,  349,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,  269,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  285,  257,   -1,   -1,   -1,  290,
   -1,   -1,   -1,   -1,   -1,  296,   -1,  269,   -1,   -1,
   40,   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,
   -1,   -1,   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   40,  296,   -1,   -1,   -1,   -1,   -1,
   -1,  332,  333,  334,  335,   -1,  337,  338,  339,  340,
  341,  342,  343,  344,  345,  346,  347,  348,  349,  350,
  351,   -1,  353,   -1,  355,  356,  357,  358,  359,  360,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
  342,  343,  344,  345,  346,  347,  348,  349,  350,  351,
   -1,  353,   -1,  355,  356,  357,  358,  359,  360,   38,
   -1,   -1,   41,   -1,   43,   44,   45,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   58,
   59,   60,   61,   62,   63,   -1,   -1,   -1,   38,   -1,
   -1,   41,   -1,   43,   44,   45,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,
   60,   61,   62,   63,  333,   94,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,   -1,  348,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  357,  358,
   -1,  360,   -1,   -1,   94,  124,  333,  126,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,
   -1,  348,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  357,  358,   -1,  360,  124,   -1,  126,   -1,   -1,   -1,
   -1,   -1,   -1,   38,   -1,   -1,   41,   -1,   43,   44,
   45,  261,  262,  263,  264,  265,  266,  267,   -1,   -1,
   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,   -1,
   -1,   -1,  282,   -1,  261,  262,  263,  264,  265,  266,
  267,   -1,   -1,   -1,  294,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  304,  282,   -1,   -1,   -1,   94,
  310,   -1,  312,   -1,  314,   -1,   -1,  294,   -1,   -1,
   -1,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,   -1,   -1,  310,   -1,  312,   -1,  314,   -1,  124,
   -1,  126,   -1,   -1,   -1,   -1,  323,  324,  257,  326,
  327,  328,  329,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   41,   -1,
  279,   44,   -1,   -1,   -1,   -1,  285,  257,   -1,   -1,
   -1,  290,   -1,   -1,   -1,   58,   59,  296,   61,  269,
   63,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,
   -1,   -1,   -1,   -1,   -1,  285,   -1,   -1,   -1,   -1,
  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  333,   -1,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,  346,  347,  348,
  349,  350,  351,   -1,  353,   -1,  355,  356,  357,  358,
  359,  360,   -1,  333,   -1,  335,   -1,  337,  338,   -1,
  340,  341,   -1,  343,  344,  345,  346,  347,  348,  349,
  350,  351,  257,  353,   -1,  355,  356,  357,  358,  359,
  360,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,
  285,   38,   -1,   -1,   41,  290,   43,   44,   45,   -1,
   -1,  296,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   94,  343,  344,
  345,  346,  347,  348,  349,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  257,   -1,   -1,  124,   -1,  126,
   -1,   -1,   -1,   -1,   -1,   -1,   38,   -1,   -1,   41,
   -1,   -1,   44,   -1,   -1,   -1,  279,   -1,   -1,   -1,
   -1,   -1,  285,   -1,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,  296,   -1,   38,   -1,   -1,   41,   -1,
   -1,   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   58,   59,   60,   61,   62,
   63,   -1,   94,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,   -1,  348,   -1,   -1,   -1,   -1,
   -1,   94,  124,   -1,  357,  358,  359,  360,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  124,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   38,   -1,   -1,   41,   -1,  285,   44,
   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,
   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,  335,   94,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,  346,
  347,  348,  349,  350,  351,  257,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,   -1,   -1,  269,   -1,  124,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,
   -1,   -1,   -1,  285,  257,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   -1,  296,   -1,  269,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   38,  279,   -1,   41,   -1,
   -1,   44,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,
   -1,   -1,   -1,  296,   -1,   58,   59,   60,   61,   62,
   63,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,  346,  347,  348,  349,  350,  351,
   -1,  353,   -1,  355,  356,  357,  358,  359,  360,   -1,
  333,   94,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,  346,  347,  348,  349,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,   -1,
   -1,  124,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   38,  279,   -1,   41,   -1,   -1,   44,
  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   -1,   58,   59,   60,   61,   62,   63,   -1,
   -1,   -1,   -1,   -1,   -1,   41,   -1,   -1,   44,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   58,   59,   60,   61,   62,   63,  333,   94,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,  346,  347,  348,  349,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   94,  124,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  269,   -1,  124,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,
   41,   -1,  285,   44,   -1,   -1,   -1,  290,   -1,   -1,
   -1,   -1,   -1,  296,   -1,   -1,   -1,   58,   59,   60,
   61,   62,   63,   -1,   -1,   -1,   -1,   -1,   -1,   41,
   -1,   -1,   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,   -1,   61,
  333,   63,  335,   94,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,   -1,
   -1,   -1,   -1,  124,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,
  285,  257,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  279,   41,   -1,   -1,   44,   -1,  285,
   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,
  296,   58,   59,   60,   61,   62,   63,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,  333,   -1,  335,
   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,  345,
   -1,  347,  348,   -1,  350,  351,  257,  353,   -1,  355,
  356,  357,  358,  359,  360,   -1,   -1,  124,  269,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,   41,
   -1,   -1,   44,   -1,  285,  257,   -1,   -1,   -1,  290,
   -1,   -1,   -1,   -1,   -1,  296,   58,   59,   60,   61,
   62,   63,   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,
   -1,   44,   -1,  285,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  296,   58,   59,   60,   61,   62,
   63,   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,
  341,   -1,  343,  344,  345,   -1,  347,  348,   -1,  350,
  351,   -1,  353,   -1,  355,  356,  357,  358,  359,  360,
   -1,  333,  124,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,   -1,   -1,  348,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  357,  358,  359,  360,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   41,   -1,   -1,   44,   -1,  285,   -1,
   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,
   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,   -1,
   -1,   -1,   41,   -1,   -1,   44,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   58,
   59,   60,   61,   62,   63,   -1,  333,   -1,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,
  347,  348,   -1,  350,  351,  257,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,   -1,   -1,  269,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,
   -1,   -1,   -1,  285,  257,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   -1,  296,   -1,  269,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,
   44,   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,
   -1,   -1,   -1,  296,   58,   59,   60,   61,   62,   63,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,   -1,  347,  348,   -1,  350,  351,
   -1,  353,   -1,  355,  356,  357,  358,  359,  360,   -1,
  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  257,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  279,   -1,   -1,   -1,   -1,   41,  285,  257,   44,
   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,
  269,   -1,   -1,   58,   59,   60,   61,   62,   63,   -1,
  279,   -1,   -1,   -1,   -1,   -1,  285,   -1,   -1,   -1,
   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  333,   -1,  335,   -1,  337,
  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,  347,
  348,   -1,  350,  351,   -1,  353,   -1,  355,  356,  357,
  358,  359,  360,   -1,  333,   -1,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,  347,  348,
   -1,  350,  351,  257,  353,   -1,  355,  356,  357,  358,
  359,  360,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,   44,
   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   58,   59,   60,   61,   62,   63,   -1,
   -1,   -1,   -1,   -1,   -1,   41,   -1,   -1,   44,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   58,   59,   60,   61,   62,   63,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,
  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   41,
   -1,  296,   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,   41,
  285,  257,   44,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   -1,  269,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,  279,   -1,   -1,   -1,   -1,   -1,  285,
   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,
  296,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,  333,   -1,  335,
   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,  345,
   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,  355,
  356,  357,  358,  359,  360,  257,   -1,   -1,   -1,   33,
   -1,   -1,   -1,   -1,   -1,   -1,   40,  269,   -1,   43,
   -1,   45,   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,
   -1,   44,   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   -1,  296,   58,   59,   60,   61,   62,
   63,   -1,   -1,   -1,   -1,   -1,   -1,   41,   -1,   -1,
   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   58,   59,   -1,   61,   -1,   63,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,   -1,  347,  348,   -1,  350,  351,
   -1,  353,  126,  355,  356,  357,  358,  359,  360,   -1,
   -1,   -1,   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  269,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   41,
   -1,   -1,   44,  285,   -1,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   -1,  296,   -1,   58,   59,   -1,   61,
   -1,   63,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,   -1,  347,  348,   -1,  350,  351,
   -1,  353,   -1,  355,  356,  357,  358,  359,  360,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  259,   -1,  261,  262,  263,
  264,  265,  266,  267,  257,   -1,  270,   -1,   -1,  273,
  274,  275,   -1,   -1,   -1,   -1,  269,   33,  282,   -1,
   -1,  285,  286,   -1,   40,   -1,  279,   43,   -1,   45,
  294,  295,  285,  257,   -1,  299,   -1,  290,   -1,  303,
  304,   -1,  306,  296,   -1,  269,  310,   -1,  312,   -1,
  314,   -1,   -1,   -1,   -1,  279,  320,   -1,   -1,  323,
  324,  285,  326,  327,  328,  329,   -1,   -1,  332,   -1,
  334,   -1,  296,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,  333,
  126,  335,   -1,  337,  338,  257,  340,  341,   33,  343,
  344,  345,   -1,   -1,  348,   40,   -1,   -1,   43,   -1,
   45,   -1,  356,  357,  358,  359,  360,  279,   -1,   -1,
   -1,   -1,   -1,  285,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  296,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   33,  343,  344,  345,   -1,   -1,  348,   40,   -1,   -1,
   43,  126,   45,   -1,   -1,  357,  358,  359,  360,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   33,   -1,   -1,   -1,
   -1,   -1,   -1,   40,   41,   -1,   43,   -1,   45,   -1,
   -1,   -1,   -1,   -1,   -1,  261,  262,  263,  264,  265,
  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,   -1,   -1,  282,   -1,   -1,  285,
  286,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,
   -1,   -1,   -1,  299,   -1,   -1,   -1,  303,  304,   -1,
  306,   -1,   -1,  126,  310,   -1,  312,   -1,  314,   -1,
   -1,   -1,   -1,   -1,  320,   -1,   -1,  323,  324,   -1,
  326,  327,  328,  329,   33,   -1,  332,   -1,  334,  126,
   -1,   40,   -1,   -1,   43,   -1,   45,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,  261,  262,  263,  264,
  265,  266,  267,   -1,   -1,  270,   -1,   40,   -1,  274,
   43,   -1,   45,   -1,   -1,   -1,   -1,  282,   -1,   -1,
   -1,  286,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,
  295,   -1,   -1,   -1,  299,   -1,   -1,   -1,  303,  304,
   -1,  306,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  126,  323,  324,
   -1,  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  261,  262,
  263,  264,  265,  266,  267,   -1,   -1,  270,   -1,   -1,
   -1,  274,   40,  126,   -1,   43,   -1,   45,   -1,  282,
   -1,   -1,   -1,  286,  261,  262,  263,  264,  265,  266,
  267,  294,  295,   -1,   -1,   -1,  299,   -1,   -1,   -1,
  303,  304,   -1,  306,   -1,  282,   -1,  310,   -1,  312,
   -1,  314,   -1,   -1,   -1,   -1,   -1,  294,  295,   -1,
  323,  324,   -1,  326,  327,  328,  329,  304,   -1,  332,
   -1,  334,   -1,  310,   -1,  312,   -1,  314,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  323,  324,   -1,  326,
  327,  328,  329,   -1,   -1,  332,   -1,  334,  126,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  261,  262,  263,  264,  265,  266,  267,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  282,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  294,  295,   -1,  261,  262,
  263,  264,  265,  266,  267,  304,   -1,   -1,   -1,   -1,
   -1,  310,   -1,  312,   -1,  314,   -1,   -1,   -1,  282,
   -1,   -1,   -1,   -1,  323,  324,   -1,  326,  327,  328,
  329,  294,  295,  332,   -1,  334,   -1,   -1,   -1,   -1,
   -1,  304,   -1,   -1,   -1,   -1,   -1,  310,   -1,  312,
   -1,  314,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  323,  324,   -1,  326,  327,  328,  329,   -1,   -1,  332,
   -1,  334,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  261,  262,  263,  264,  265,  266,  267,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  282,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  294,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  304,   -1,   -1,   -1,
   -1,   -1,  310,   -1,  312,   -1,  314,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  323,  324,   -1,  326,  327,
  328,  329,   -1,   -1,  332,   -1,  334,
  };

        // %token constants
        internal class Token
        {
            public const int NewLine = 257;
            public const int Indent = 258;
            public const int Dedent = 259;
            public const int EndOfFile = 260;
            public const int IdentifierGet = 261;
            public const int IdentifierSet = 262;
            public const int IdentifierFile = 263;
            public const int IdentifierLine = 264;
            public const int IdentifierExit = 265;
            public const int IdentifierSuccess = 266;
            public const int IdentifierFailure = 267;
            public const int KeywordAbstract = 268;
            public const int KeywordAnd = 269;
            public const int KeywordBreak = 270;
            public const int KeywordCase = 271;
            public const int KeywordCatch = 272;
            public const int KeywordClass = 273;
            public const int KeywordContinue = 274;
            public const int KeywordDef = 275;
            public const int KeywordDefault = 276;
            public const int KeywordDelete = 277;
            public const int KeywordElif = 278;
            public const int KeywordElse = 279;
            public const int KeywordEnum = 280;
            public const int KeywordExtended = 281;
            public const int KeywordFalse = 282;
            public const int KeywordFinally = 283;
            public const int KeywordFor = 284;
            public const int KeywordIf = 285;
            public const int KeywordImport = 286;
            public const int KeywordIn = 287;
            public const int KeywordInterface = 288;
            public const int KeywordInvariant = 289;
            public const int KeywordIs = 290;
            public const int KeywordLazy = 291;
            public const int KeywordNameof = 292;
            public const int KeywordNew = 293;
            public const int KeywordNil = 294;
            public const int KeywordNot = 295;
            public const int KeywordOr = 296;
            public const int KeywordOut = 297;
            public const int KeywordOverride = 298;
            public const int KeywordPass = 299;
            public const int KeywordPrivate = 300;
            public const int KeywordProperty = 301;
            public const int KeywordProtected = 302;
            public const int KeywordPublic = 303;
            public const int KeywordRef = 304;
            public const int KeywordReflect = 305;
            public const int KeywordReturn = 306;
            public const int KeywordScope = 307;
            public const int KeywordSealed = 308;
            public const int KeywordStatic = 309;
            public const int KeywordSuper = 310;
            public const int KeywordSwitch = 311;
            public const int KeywordThis = 312;
            public const int KeywordThrow = 313;
            public const int KeywordTrue = 314;
            public const int KeywordTry = 315;
            public const int KeywordUnittest = 316;
            public const int KeywordUnless = 317;
            public const int KeywordUntil = 318;
            public const int KeywordVar = 319;
            public const int KeywordWhile = 320;
            public const int KeywordWith = 321;
            public const int KeywordYield = 322;
            public const int Identifier = 323;
            public const int StringLiteral = 324;
            public const int EmbedStringLiteral = 325;
            public const int WysiwygStringLiteral = 326;
            public const int ImaginaryNumber = 327;
            public const int FloatNumber = 328;
            public const int Integer = 329;
            public const int RangeOpen = 330;
            public const int RangeClose = 331;
            public const int Increment = 332;
            public const int AssignmentAdd = 333;
            public const int Decrement = 334;
            public const int AssignmentSub = 335;
            public const int AnnotationReturn = 336;
            public const int AssignmentConcat = 337;
            public const int AssignmentPower = 338;
            public const int Power = 339;
            public const int AssignmentMultiply = 340;
            public const int AssignmentIntDivide = 341;
            public const int IntDivide = 342;
            public const int AssignmentDivide = 343;
            public const int AssignmentModulo = 344;
            public const int AssignmentLeftShift = 345;
            public const int LeftShift = 346;
            public const int LessThan = 347;
            public const int AssignmentRightShift = 348;
            public const int RightShift = 349;
            public const int MoreThan = 350;
            public const int Equal = 351;
            public const int Lambda = 352;
            public const int NotEqual = 353;
            public const int NotIn = 354;
            public const int IsNot = 355;
            public const int AndShort = 356;
            public const int AssignmentAnd = 357;
            public const int AssignmentXor = 358;
            public const int OrShort = 359;
            public const int AssignmentOr = 360;
            public const int NilCoalesce = 361;
            public const int yyErrorCode = 256;
        }

#line 744 "InteractiveParser.jay"
    }
#line default

} // close outermost namespace, that MUST HAVE BEEN opened in the prolog
