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
//t    "statement : compound_statement NewLine",
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
#line 113 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[-1+yyTop] };
        }
  break;
case 4:
#line 119 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 5:
  case_5();
  break;
case 6:
#line 136 "InteractiveParser.jay"
  {
            yyVal = null;
        }
  break;
case 7:
#line 140 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 8:
  case_8();
  break;
case 13:
#line 163 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 14:
#line 167 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 16:
  case_16();
  break;
case 17:
#line 182 "InteractiveParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 18:
#line 186 "InteractiveParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 19:
#line 192 "InteractiveParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 20:
#line 196 "InteractiveParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 22:
#line 203 "InteractiveParser.jay"
  {
            yyVal = new ElseStatementNode((LToken)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 23:
#line 209 "InteractiveParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 24:
#line 213 "InteractiveParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 25:
#line 219 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 26:
#line 223 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-5+yyTop], (Node)yyVals[-4+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 27:
#line 227 "InteractiveParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 28:
#line 233 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 29:
  case_29();
  break;
case 30:
#line 244 "InteractiveParser.jay"
  {
            yyVal = new Node[] { new ParameterNode((Node)yyVals[0+yyTop]) };
        }
  break;
case 31:
  case_31();
  break;
case 32:
#line 256 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 33:
#line 262 "InteractiveParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 34:
#line 266 "InteractiveParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 35:
#line 272 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 36:
#line 278 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 37:
  case_37();
  break;
case 38:
#line 290 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 39:
  case_39();
  break;
case 46:
#line 310 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Pass);
        }
  break;
case 48:
#line 319 "InteractiveParser.jay"
  {
			yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 49:
#line 323 "InteractiveParser.jay"
  {
			yyVal = new UnaryStatementNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 50:
#line 329 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Break);
        }
  break;
case 51:
#line 335 "InteractiveParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Continue);
        }
  break;
case 52:
#line 341 "InteractiveParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 53:
#line 345 "InteractiveParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-2+yyTop], (LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 54:
#line 351 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 55:
  case_55();
  break;
case 57:
#line 366 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 58:
  case_58();
  break;
case 70:
#line 395 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Comma);
        }
  break;
case 72:
#line 402 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Assign);
        }
  break;
case 73:
#line 406 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignAddition);
        }
  break;
case 74:
#line 410 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignSubtraction);
        }
  break;
case 75:
#line 414 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignMultiplication);
        }
  break;
case 76:
#line 418 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignDivision);
        }
  break;
case 77:
#line 422 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignIntDivision);
        }
  break;
case 78:
#line 426 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignPower);
        }
  break;
case 79:
#line 430 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignModulo);
        }
  break;
case 80:
#line 434 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticAnd);
        }
  break;
case 81:
#line 438 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticOr);
        }
  break;
case 82:
#line 442 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticXor);
        }
  break;
case 83:
#line 446 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignConcatenation);
        }
  break;
case 84:
#line 450 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignLeftShift);
        }
  break;
case 85:
#line 454 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignRightShift);
        }
  break;
case 87:
#line 461 "InteractiveParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 88:
#line 465 "InteractiveParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 90:
#line 472 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 91:
#line 476 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 93:
#line 483 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 94:
#line 487 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 96:
#line 494 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 97:
#line 498 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 99:
#line 505 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThan);
        }
  break;
case 100:
#line 509 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThan);
        }
  break;
case 101:
#line 513 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThanEqual);
        }
  break;
case 102:
#line 517 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThanEqual);
        }
  break;
case 103:
#line 521 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Equal);
        }
  break;
case 104:
#line 525 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.NotEqual);
        }
  break;
case 105:
#line 529 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Is);
        }
  break;
case 106:
#line 533 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 107:
#line 537 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-3+yyTop], (Node)yyVals[-1+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 109:
#line 544 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticOr);
        }
  break;
case 111:
#line 551 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticXor);
        }
  break;
case 113:
#line 558 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticAnd);
        }
  break;
case 115:
#line 565 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LeftShift);
        }
  break;
case 116:
#line 569 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.RightShift);
        }
  break;
case 118:
#line 576 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Addition);
        }
  break;
case 119:
#line 580 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Subtraction);
        }
  break;
case 120:
#line 584 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Concatenation);
        }
  break;
case 122:
#line 591 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Multiplication);
        }
  break;
case 123:
#line 595 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IntDivision);
        }
  break;
case 124:
#line 599 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Division);
        }
  break;
case 125:
#line 603 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Modulo);
        }
  break;
case 127:
#line 610 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.IncrementPrefix);
        }
  break;
case 128:
#line 614 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.DecrementPrefix);
        }
  break;
case 129:
#line 618 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignNegative);
        }
  break;
case 130:
#line 622 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignPositive);
        }
  break;
case 131:
#line 626 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.BitwiseNot);
        }
  break;
case 133:
#line 633 "InteractiveParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Power);
        }
  break;
case 134:
  case_134();
  break;
case 135:
#line 646 "InteractiveParser.jay"
  {
			yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.Ref);
		}
  break;
case 137:
  case_137();
  break;
case 138:
#line 658 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.IncrementPostfix);
        }
  break;
case 139:
#line 662 "InteractiveParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.DecrementPostfix);
        }
  break;
case 140:
#line 666 "InteractiveParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-2+yyTop]);
        }
  break;
case 141:
#line 670 "InteractiveParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop]);
        }
  break;
case 142:
#line 676 "InteractiveParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 143:
  case_143();
  break;
case 146:
#line 692 "InteractiveParser.jay"
  {
            yyVal = new ArgumentNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-1+yyTop]);
        }
  break;
case 147:
#line 698 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 149:
#line 703 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.False);
        }
  break;
case 150:
#line 707 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.True);
        }
  break;
case 151:
#line 711 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Nil);
        }
  break;
case 152:
#line 715 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.This);
        }
  break;
case 153:
#line 719 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Super);
        }
  break;
case 154:
#line 723 "InteractiveParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
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
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.String);
        }
  break;
case 157:
#line 737 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Imaginary);
        }
  break;
case 158:
#line 741 "InteractiveParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Floating);
        }
  break;
case 159:
#line 745 "InteractiveParser.jay"
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
void case_5()
#line 121 "InteractiveParser.jay"
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

void case_8()
#line 142 "InteractiveParser.jay"
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

void case_16()
#line 172 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-1+yyTop]);
            newList.AddRange((IEnumerable<Node>)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_29()
#line 235 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_31()
#line 246 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_37()
#line 280 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_39()
#line 292 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_55()
#line 353 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_58()
#line 368 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_134()
#line 637 "InteractiveParser.jay"
{
            if (yyVals[0+yyTop] is ConstantNode)
                yyVal = yyVals[0+yyTop];
            else
    			yyVal = new EvalNode((Node)yyVals[0+yyTop]);
		}

void case_137()
#line 651 "InteractiveParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_143()
#line 678 "InteractiveParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

#line default
   static readonly short [] yyLhs  = {              -1,
    0,    0,    0,    1,    1,    4,    4,    4,    2,    2,
    2,    2,    9,    9,   10,   10,    5,    5,   12,   12,
   12,   13,    6,    6,    7,    7,    7,   14,   14,   15,
   15,   17,    8,    8,   18,   19,   19,   20,   20,    3,
    3,    3,    3,    3,    3,   21,   22,   23,   23,   24,
   25,   26,   26,   27,   27,   28,   29,   29,   16,   16,
   30,   30,   30,   30,   30,   30,   30,   11,   31,   31,
   32,   32,   32,   32,   32,   32,   32,   32,   32,   32,
   32,   32,   32,   32,   32,   33,   33,   33,   34,   34,
   34,   35,   35,   35,   36,   36,   36,   37,   37,   37,
   37,   37,   37,   37,   37,   37,   37,   38,   38,   39,
   39,   40,   40,   41,   41,   41,   42,   42,   42,   42,
   43,   43,   43,   43,   43,   44,   44,   44,   44,   44,
   44,   45,   45,   46,   46,   47,   47,   47,   47,   47,
   47,   49,   49,   50,   50,   51,   48,   48,   48,   48,
   48,   48,   48,   48,   52,   52,   52,   52,   52,
  };
   static readonly short [] yyLen = {           2,
    2,    1,    2,    1,    2,    1,    2,    3,    1,    1,
    1,    1,    2,    4,    1,    2,    4,    5,    4,    5,
    1,    3,    4,    5,    7,    6,    4,    1,    3,    1,
    3,    1,    7,    4,    1,    1,    3,    1,    3,    1,
    1,    1,    1,    1,    1,    1,    1,    1,    2,    1,
    1,    2,    3,    1,    3,    1,    1,    3,    1,    1,
    1,    1,    1,    1,    1,    1,    1,    1,    1,    3,
    1,    3,    3,    3,    3,    3,    3,    3,    3,    3,
    3,    3,    3,    3,    3,    1,    5,    5,    1,    3,
    3,    1,    3,    3,    1,    2,    2,    1,    3,    3,
    3,    3,    3,    3,    3,    3,    4,    1,    3,    1,
    3,    1,    3,    1,    3,    3,    1,    3,    3,    3,
    1,    3,    3,    3,    3,    1,    2,    2,    2,    2,
    2,    1,    3,    1,    2,    1,    3,    2,    2,    3,
    4,    1,    3,    1,    1,    3,    1,    1,    1,    1,
    1,    1,    1,    3,    1,    1,    1,    1,    1,
  };
   static readonly short [] yyDefRed = {            0,
   61,   62,   63,   64,   65,   66,   67,   50,    0,   51,
    0,  150,    0,    0,  151,    0,   46,    0,    0,    0,
  153,  152,  149,    0,   59,  155,  156,  157,  158,  159,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    9,   10,   11,   12,   47,  147,   40,   41,   42,
   43,   44,   45,   60,   68,    0,    0,    0,    0,   92,
    0,    0,    0,    0,    0,    0,    0,  121,    0,  132,
    0,  136,  148,   35,    0,    0,   28,    0,   57,    0,
   54,    0,   96,    0,    0,   49,    0,  127,  128,   97,
  130,  129,  131,    0,    1,    3,    0,    5,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  138,  139,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  154,    0,   70,   73,   74,   83,
   78,   75,   77,   76,   79,   84,   85,   80,   82,   81,
   72,    0,    0,    0,    0,   93,   94,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  123,  122,  124,  125,  133,  137,
  140,    0,  144,    0,  142,  145,    0,    0,   34,   38,
    0,    0,   27,   29,    0,    0,   32,   30,    0,   55,
   58,    0,    8,    0,    0,    0,    0,    0,  141,    0,
   13,    0,    0,    0,    0,    0,    0,    0,    0,   18,
   21,   24,    0,    0,  146,  143,   15,    0,    0,    0,
   39,   26,   31,    0,    0,    0,   14,   16,   33,   25,
    0,   22,    0,   20,
  };
  protected static readonly short [] yyDgoto  = {            38,
  208,   40,   41,   98,   42,   43,   44,   45,  209,  248,
   46,  240,  241,   76,  216,   47,  218,   75,  211,  212,
   48,   49,   50,   51,   52,   53,   80,   81,   82,   54,
   55,   56,   57,   58,   59,   60,   61,   62,   63,   64,
   65,   66,   67,   68,   69,   70,   71,   72,  204,  205,
  206,   73,
  };
  protected static readonly short [] yySindex = {         3343,
    0,    0,    0,    0,    0,    0,    0,    0, -124,    0,
 -124,    0, 3640, -124,    0, 3640,    0, -263,  799, 3640,
    0,    0,    0, 3640,    0,    0,    0,    0,    0,    0,
 3761, 3761, 3640, 3761, 3761, 3761, 3640,    0, -214, -212,
  -12,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    7,  297,  -61, -252,    0,
  -41,  -51,  -14,   50, -268,   -3,  -34,    0, -230,    0,
  -35,    0,    0,    0,    8,   37,    0,   53,    0,   68,
    0,   67,    0, -124,  -35,    0,   59,    0,    0,    0,
    0,    0,    0,   73,    0,    0, 3526,    0, 3640, 3640,
 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3640,
 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3640, 3676,
 3761, 3761, 3761, 3761, 3761, 3761, 3761, 3761, 3761, 3761,
 3761, 3761, 3761, 3761, 3761, 3761, 3761, 3761, 3761,  354,
    0,    0, -124, 3552, 3444, -124, 3444, -124,  -21, 3444,
 -124, -124,   68, 3444,    0,  -12,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0, -210, -252, -252,  -58,    0,    0, 3761,  -51,  -51,
  -51,  -51,  -51,  -51,  -51,  -51,  -14,   50, -268,   -3,
   -3,  -34,  -34,  -34,    0,    0,    0,    0,    0,    0,
    0,   61,    0,   41,    0,    0, -142, -136,    0,    0,
   43,   76,    0,    0,   66,   48,    0,    0, -242,    0,
    0, -153,    0, 3640, 3640,  -51, 3640, 3640,    0, 3343,
    0, -124,   70, -124, 3444, -124,   72, 3640,   74,    0,
    0,    0, -280, -280,    0,    0,    0, 3095,   76, 3444,
    0,    0,    0, 3444,   77, 3444,    0,    0,    0,    0,
 3444,    0, -242,    0,
  };
  protected static readonly short [] yyRindex = {            0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  -53,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  239,
 -123,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,   -9,  -32,  428, 1246,    0,
 3135, 2256, 2132, 1893, 1746, 1477, 1010,    0,  687,    0,
  537,    0,    0,    0,    0,    0,    0,    0,    0,  -49,
    0,  -20,    0,    0,  566,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0, -113,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  -44,    0,    0, -110,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0, 2017, 3217,    0,    0,    0,    0, 2371, 2400,
 2495, 2614, 2734, 2763, 2867, 2977, 2227, 1988, 1864, 1506,
 1624, 1039, 1134, 1382,    0,    0,    0,    0,    0,    0,
    0,  658,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   49,    0,    0,    0,    0,    0,    0,    1,    0,
    0,   75,    0,    0,    0, 3106,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  802,  892,    0,    0,    0,    0,   56,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  151,    0,
  };
  protected static readonly short [] yyGindex = {         -154,
    4,    0,   51,  -23,    0,    0,    0,    0, -125,    0,
   -6, -103,  -72,    0,    0,   19,  -75,    0,    0,  -68,
    0,    0,    0,    0,    0,    0,   82,   18,    0,    0,
   79,  -48,    0,  -79,  -17,   58,    0,   32,   54,   52,
   55,  -30,  -28,   36,    0,   39,  164,    0,    0,  -42,
    0,    0,
  };
  protected static readonly short [] yyTable = {           225,
   17,  117,  139,   39,  144,   48,   78,  137,   71,   52,
  143,   71,  138,   86,   53,  115,  118,   87,  126,  215,
  127,  213,   84,   56,  219,   71,   71,   74,  222,   77,
   94,   69,   79,   17,  172,  238,  239,  175,   56,  133,
   17,  134,   95,   17,   96,   17,   97,  146,   69,   69,
   99,  158,  159,  160,  161,  162,  163,  164,  165,  166,
  167,  168,  169,  170,  171,  145,   88,   89,  224,   91,
   92,   93,  128,   83,   23,  247,  149,  131,  116,  129,
  132,  229,  148,  233,  228,  115,  232,  130,  237,   36,
   90,  236,   36,  258,  147,  203,   37,  173,  174,   37,
  190,  191,   79,  119,  192,  193,  194,   23,  140,  252,
  150,  151,  152,  155,   23,  230,  154,   23,  227,   23,
  231,  234,  135,  235,  259,  239,   17,  250,  260,  254,
  262,  256,  223,    4,  261,  263,    1,    2,    3,    4,
    5,    6,    7,    6,  243,  244,    7,  156,  116,  242,
   19,  179,  180,  181,  182,  183,  184,  185,  186,  264,
  253,  200,  202,  249,  210,  153,  214,  217,  220,   79,
  221,  195,  196,  197,  198,  176,  177,  157,  199,  203,
  188,  187,   85,   19,  189,  246,    0,    0,    0,    0,
   19,    0,    0,   19,    0,   19,    0,    0,   25,    0,
   23,    0,    0,   48,    0,    0,    0,   52,    0,  226,
    0,    0,   53,    0,    0,    0,    0,    0,    0,    0,
  245,    0,    0,  114,   71,    0,    0,    0,    0,    0,
    0,  255,    0,   39,  115,    0,   56,  115,    2,    1,
    2,    3,    4,    5,    6,    7,  202,   69,  120,    0,
  210,   39,  251,    0,  217,    0,    0,   17,    0,   17,
    0,   17,   17,   17,   17,   17,   17,   17,    0,    0,
   17,    2,    0,   17,   17,   17,   19,    0,    2,    0,
    0,    2,   17,    2,    0,   17,   17,    0,    0,    0,
    0,    0,    0,    0,   17,   17,  141,  116,  142,   17,
  116,   25,    0,   17,   17,  121,   17,  136,  122,  123,
   17,  124,   17,  125,   17,    0,    0,    0,    0,    0,
   17,    0,    0,   17,   17,    0,   17,   17,   17,   17,
    0,   23,   17,   23,   17,   23,   23,   23,   23,   23,
   23,   23,    0,    0,   23,    0,    0,   23,   23,   23,
    0,    0,    0,    0,    0,    0,   23,  113,    0,   23,
   23,    0,    0,    0,    2,    0,    0,    0,   23,   23,
    0,    0,    0,   23,    0,    0,    0,   23,   23,    0,
   23,    0,    0,    0,   23,    0,   23,    0,   23,    0,
    0,    0,    0,   37,   23,    0,    0,   23,   23,    0,
   23,   23,   23,   23,    0,    0,   23,   19,   23,   19,
    0,   19,   19,   19,   19,   19,   19,   19,    0,    0,
   19,    0,    0,   19,   19,   19,    0,    0,    0,    0,
    0,    0,   19,    0,    0,   19,   19,    0,    0,    0,
    0,    0,    0,    0,   19,   19,    0,    0,    0,   19,
    0,    0,    0,   19,   19,    0,   19,    0,    0,    0,
   19,    0,   19,    0,   19,    0,    0,    0,   86,    0,
   19,   86,    0,   19,   19,    0,   19,   19,   19,   19,
    0,    0,   19,    0,   19,   86,   86,    0,   86,    0,
    0,    0,    0,    0,    0,    0,    0,    2,    0,    2,
    2,    2,    2,    2,    2,    2,    0,    0,    2,    0,
    0,    2,    2,    2,    0,    0,    0,    0,    0,    0,
    2,    0,    0,    2,    2,    0,    0,    0,    0,    0,
    0,    0,    2,    2,    0,    0,    0,    2,    0,    0,
    0,    2,    2,    0,    2,    0,    0,    0,    2,    0,
    2,    0,    2,    0,    0,    0,    0,    0,    2,    0,
    0,    2,    2,    0,    2,    2,    2,    2,    0,    0,
    2,    0,    2,  134,  134,    0,    0,  134,  134,  134,
  134,  134,    0,  134,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  134,  134,  134,  134,  134,  134,
    0,    0,  135,  135,    0,    0,  135,  135,  135,  135,
  135,    0,  135,    0,    1,    2,    3,    4,    5,    6,
    7,    0,    0,  135,  135,  135,  135,  135,  135,  100,
  134,  101,    0,  102,  103,   12,  104,  105,    0,  106,
  107,  108,    0,    0,  109,    0,    0,   15,    0,    0,
    0,    0,    0,  110,  111,    0,  112,   19,    0,  135,
  134,    0,  134,   21,    0,   22,    0,   23,    0,    0,
    0,    0,    0,    0,    0,    0,   25,   26,    0,   27,
   28,   29,   30,    0,   86,    0,    0,    0,    0,  135,
    0,  135,    0,    0,  147,  147,    0,  147,  147,  147,
  147,  147,  147,  147,  147,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  147,  147,  147,
  147,    0,    0,  126,  126,    0,    0,  126,  126,  126,
  126,  126,    0,  126,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  126,  126,  126,  126,  126,  126,
    0,  147,    0,    0,    0,    0,    0,    0,    0,    0,
   86,    0,   86,    0,   86,   86,    0,   86,   86,    0,
   86,   86,   86,    0,    0,   86,    0,    0,    0,    0,
  126,  147,    0,  147,   86,   86,    0,   86,    0,    0,
    0,    0,    0,  134,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  134,    0,    0,    0,    0,
  126,    0,  126,    0,    0,  134,    0,    0,    0,    0,
    0,  134,  135,    0,    0,    0,  134,    0,    0,    0,
    0,    0,  134,    0,  135,    0,    0,    0,   37,    0,
    0,    0,   88,    0,  135,   88,    0,    0,    0,    0,
  135,    0,    0,    0,    0,  135,    0,    0,    0,   88,
   88,  135,   88,    0,    0,    0,    0,    0,    0,  134,
    0,  134,    0,  134,  134,  134,  134,  134,  134,  134,
  134,  134,  134,  134,  134,  134,  134,  134,    0,  134,
    0,  134,  134,  134,  134,  134,  134,    0,  135,    0,
  135,    0,  135,  135,  135,  135,  135,  135,  135,  135,
  135,  135,  135,  135,  135,  135,  135,    0,  135,    0,
  135,  135,  135,  135,  135,  135,  147,    0,    0,    0,
    0,    0,   87,    0,    0,   87,    0,    0,    0,    0,
    0,    0,  147,  126,    0,    0,    0,  147,    0,   87,
   87,    0,   87,  147,    0,  126,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  126,    0,    0,    0,    0,
    0,  126,    0,    0,    0,    0,  126,    0,    0,    0,
    0,    0,  126,    0,    0,    0,    0,    0,    0,  147,
  147,  147,  147,    0,  147,  147,  147,  147,  147,  147,
  147,  147,  147,  147,  147,  147,  147,  147,  147,    0,
  147,    0,  147,  147,  147,  147,  147,  147,    0,  126,
    0,  126,    0,  126,  126,    0,  126,  126,  126,  126,
  126,  126,  126,  126,  126,  126,  126,  126,    0,  126,
    0,  126,  126,  126,  126,  126,  126,  117,    0,    0,
  117,    0,  117,  117,  117,    0,    0,    0,   88,    1,
    2,    3,    4,    5,    6,    7,    0,  117,  117,  117,
  117,  117,  117,    0,    0,    0,  118,    0,    0,  118,
   12,  118,  118,  118,    0,    0,    0,    0,    0,    0,
    0,    0,   15,    0,    0,    0,  118,  118,  118,  118,
  118,  118,    0,  117,    0,    0,    0,    0,   21,    0,
   22,    0,   23,    0,    0,    0,    0,    0,    0,    0,
    0,   25,   26,    0,   27,   28,   29,   30,    0,    0,
    0,    0,  118,  117,   88,  117,   88,    0,   88,   88,
    0,   88,   88,    0,   88,   88,   88,    0,   87,   88,
    0,    0,    0,    0,    0,    0,    0,    0,   88,   88,
    0,   88,  118,    0,  118,    0,    0,    0,    0,    0,
    0,  119,    0,    0,  119,    0,  119,  119,  119,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  119,  119,  119,  119,  119,  119,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   87,    0,   87,  119,   87,   87,
    0,   87,   87,    0,   87,   87,   87,    0,    0,   87,
    0,    0,    0,    0,    0,    0,    0,    0,   87,   87,
    0,   87,    0,    0,    0,    0,    0,  119,    0,  119,
    0,    0,    0,    0,    0,    0,  117,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  117,    0,
    0,    0,    0,    0,    0,    0,   89,    0,  117,   89,
    0,    0,    0,    0,  117,  118,    0,    0,    0,  117,
    0,    0,    0,   89,   89,  117,   89,  118,   89,    0,
    0,    0,    0,    0,    0,    0,    0,  118,    0,    0,
    0,    0,    0,  118,    0,    0,    0,    0,  118,    0,
    0,    0,    0,    0,  118,    0,    0,    0,    0,    0,
    0,    0,  117,    0,  117,    0,  117,  117,    0,  117,
  117,    0,  117,  117,  117,  117,  117,  117,  117,  117,
  117,    0,  117,    0,  117,  117,  117,  117,  117,  117,
    0,  118,    0,  118,    0,  118,  118,    0,  118,  118,
    0,  118,  118,  118,  118,  118,  118,  118,  118,  118,
  119,  118,    0,  118,  118,  118,  118,  118,  118,    0,
    0,    0,  119,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  119,    0,    0,    0,    0,    0,  119,  120,
    0,    0,  120,  119,  120,  120,  120,    0,    0,  119,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  120,
  120,  120,  120,  120,  120,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  119,    0,  119,    0,
  119,  119,    0,  119,  119,  120,  119,  119,  119,  119,
  119,  119,  119,  119,  119,    0,  119,    0,  119,  119,
  119,  119,  119,  119,    0,    0,    0,    0,    0,    0,
    0,    0,   89,    0,    0,  120,    0,  120,    0,    0,
    0,    0,    0,    0,  114,    0,    0,  114,    0,    0,
  114,    0,    0,    0,   89,    0,    0,    0,    0,    0,
   89,    0,    0,    0,  114,  114,  114,  114,  114,  114,
    0,   89,    0,  115,    0,    0,  115,    0,    0,  115,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  115,  115,  115,  115,  115,  115,    0,
  114,    0,    0,    0,    0,    0,    0,    0,   89,    0,
   89,    0,   89,   89,    0,   89,   89,    0,   89,   89,
   89,    0,    0,   89,    0,    0,    0,    0,    0,  115,
  114,    0,   89,   89,   89,   89,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  115,
    0,    0,    0,    0,    0,    0,    0,    0,  120,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  120,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  120,  116,    0,    0,  116,    0,  120,  116,    0,    0,
    0,  120,    0,    0,    0,    0,    0,  120,    0,    0,
    0,  116,  116,  116,  116,  116,  116,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  120,    0,  120,  116,  120,  120,
    0,  120,  120,    0,  120,  120,  120,  120,  120,  120,
  120,  120,  120,  114,  120,    0,  120,  120,  120,  120,
  120,  120,    0,    0,    0,  114,    0,  116,    0,    0,
    0,    0,    0,    0,    0,  114,    0,    0,    0,    0,
    0,  114,  115,    0,    0,    0,  114,    0,    0,    0,
    0,    0,  114,    0,  115,    0,    0,    0,    0,    0,
    0,    0,    0,  112,  115,    0,  112,    0,    0,  112,
  115,    0,    0,    0,    0,  115,    0,    0,    0,    0,
    0,  115,    0,  112,  112,  112,  112,  112,  112,  114,
    0,  114,    0,  114,  114,    0,  114,  114,    0,  114,
  114,  114,  114,  114,  114,  114,  114,  114,    0,  114,
    0,  114,  114,  114,  114,  114,  114,    0,  115,  112,
  115,    0,  115,  115,    0,  115,  115,    0,  115,  115,
  115,  115,  115,  115,  115,  115,  115,    0,  115,    0,
  115,  115,  115,  115,  115,  115,    0,    0,    0,  112,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  116,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  116,    0,    0,    0,    0,    0,    0,    0,
    0,  113,  116,    0,  113,    0,    0,  113,  116,    0,
    0,    0,    0,  116,    0,    0,    0,    0,    0,  116,
    0,  113,  113,  113,  113,  113,  113,    0,    0,    0,
    0,    0,    0,  110,    0,    0,  110,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  110,  110,  110,  110,  110,  110,  116,  113,  116,    0,
  116,  116,    0,  116,  116,    0,  116,  116,  116,  116,
  116,  116,  116,  116,  116,    0,  116,    0,  116,  116,
  116,  116,  116,  116,    0,    0,  110,  113,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  112,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  112,    0,  110,    0,    0,    0,
    0,    0,    0,    0,  112,    0,    0,    0,  111,    0,
  112,  111,    0,    0,    0,  112,    0,    0,    0,    0,
    0,  112,    0,    0,    0,  111,  111,  111,  111,  111,
  111,    0,    0,    0,    0,    0,    0,   90,    0,    0,
   90,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   90,   90,    0,   90,  112,   90,
  112,  111,  112,  112,    0,  112,  112,    0,  112,  112,
  112,    0,  112,  112,    0,  112,  112,    0,  112,    0,
  112,  112,  112,  112,  112,  112,    0,    0,    0,    0,
    0,  111,    0,    0,    0,    0,    0,    0,    0,    0,
  113,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  113,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  113,    0,    0,    0,    0,    0,  113,  110,
    0,    0,    0,  113,    0,    0,    0,    0,    0,  113,
    0,  110,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  110,  108,    0,    0,  108,    0,  110,    0,    0,
    0,    0,  110,    0,    0,    0,    0,    0,  110,  108,
  108,  108,  108,  108,  108,    0,  113,    0,  113,    0,
  113,  113,    0,  113,  113,    0,  113,  113,  113,    0,
  113,  113,    0,  113,  113,    0,  113,    0,  113,  113,
  113,  113,  113,  113,    0,  110,    0,  110,    0,  110,
  110,    0,  110,  110,    0,  110,  110,  110,    0,  110,
  110,    0,  110,  110,  111,  110,    0,  110,  110,  110,
  110,  110,  110,    0,    0,  108,  111,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  111,  109,    0,    0,
  109,    0,  111,   90,    0,    0,    0,  111,    0,    0,
    0,    0,    0,  111,  109,  109,  109,  109,  109,  109,
    0,    0,    0,    0,    0,   90,   98,    0,    0,   98,
    0,   90,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,   90,   98,   98,   98,   98,   98,   98,    0,
  111,    0,  111,    0,  111,  111,    0,  111,  111,    0,
  111,  111,  111,    0,  111,  111,    0,  111,  111,    0,
  111,    0,  111,  111,  111,  111,  111,  111,    0,   90,
  109,   90,    0,   90,   90,    0,   90,   90,    0,   90,
   90,   90,    0,    0,   90,    0,    0,    0,    0,    0,
    0,    0,    0,   90,   90,   90,   90,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  108,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  108,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  108,  105,    0,    0,  105,    0,  108,    0,    0,    0,
    0,  108,    0,    0,    0,    0,    0,  108,  105,  105,
  105,  105,  105,  105,    0,    0,    0,    0,    0,    0,
  101,    0,    0,  101,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  101,  101,  101,
  101,  101,  101,    0,  108,    0,  108,    0,  108,  108,
    0,  108,  108,    0,  108,  108,  108,    0,  108,  108,
    0,  108,  108,  109,  108,    0,  108,  108,  108,  108,
  108,  108,    0,    0,    0,  109,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  109,    0,    0,    0,    0,
    0,  109,   98,    0,    0,    0,  109,    0,    0,    0,
    0,    0,  109,    0,   98,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   98,  102,    0,    0,  102,    0,
   98,    0,    0,    0,    0,   98,    0,    0,    0,    0,
    0,   98,  102,  102,  102,  102,  102,  102,    0,  109,
    0,  109,    0,  109,  109,    0,  109,  109,    0,  109,
  109,  109,    0,  109,  109,    0,  109,  109,    0,  109,
    0,  109,  109,  109,  109,  109,  109,    0,   98,    0,
   98,    0,   98,   98,    0,   98,   98,    0,   98,   98,
   98,    0,   98,   98,    0,   98,   98,    0,   98,    0,
   98,   98,   98,   98,   98,   98,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  105,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  105,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  105,
    0,    0,    0,    0,  103,  105,  101,  103,    0,    0,
  105,    0,    0,    0,    0,    0,  105,    0,  101,    0,
    0,  103,  103,  103,  103,  103,  103,    0,  101,    0,
    0,    0,    0,    0,  101,    0,    0,    0,    0,  101,
    0,    0,    0,    0,    0,  101,    0,    0,    0,    0,
    0,    0,    0,  105,    0,  105,    0,  105,  105,    0,
  105,  105,    0,  105,  105,  105,    0,  105,  105,    0,
  105,  105,    0,  105,    0,  105,  105,  105,  105,  105,
  105,    0,  101,    0,  101,    0,  101,  101,    0,  101,
  101,    0,  101,  101,  101,    0,  101,  101,    0,  101,
  101,  102,  101,    0,  101,  101,  101,  101,  101,  101,
    0,    0,    0,  102,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  102,  104,    0,    0,  104,    0,  102,
    0,    0,    0,    0,  102,    0,    0,    0,    0,    0,
  102,  104,  104,  104,  104,  104,  104,    0,    0,    0,
    0,    0,    0,  106,    0,    0,  106,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  106,  106,  106,  106,  106,  106,    0,  102,    0,  102,
    0,  102,  102,    0,  102,  102,    0,  102,  102,  102,
    0,  102,  102,    0,  102,  102,    0,  102,    0,  102,
  102,  102,  102,  102,  102,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  103,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  103,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  103,    0,    0,    0,    0,    0,  103,    0,
    0,    0,    0,  103,    0,    0,    0,   99,    0,  103,
   99,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   99,   99,   99,   99,   99,   99,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  103,    0,  103,    0,
  103,  103,    0,  103,  103,    0,  103,  103,  103,    0,
  103,  103,    0,  103,  103,    0,  103,    0,  103,  103,
  103,  103,  103,  103,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  104,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  104,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  104,    0,    0,    0,    0,  100,  104,  106,
  100,    0,    0,  104,    0,    0,    0,    0,    0,  104,
    0,  106,    0,    0,  100,  100,  100,  100,  100,  100,
    0,  106,    0,    0,    0,    0,    0,  106,    0,    0,
    0,    0,  106,    0,    0,    0,    0,    0,  106,    0,
    0,    0,    0,    0,    0,    0,  104,    0,  104,    0,
  104,  104,    0,  104,  104,    0,  104,  104,  104,    0,
  104,  104,    0,  104,  104,    0,  104,    0,  104,  104,
  104,  104,  104,  104,    0,  106,    0,  106,    0,  106,
  106,    0,  106,  106,    0,  106,  106,  106,    0,  106,
  106,    0,  106,  106,    0,  106,    0,  106,  106,  106,
  106,  106,  106,   99,    0,    0,    0,   33,    0,    0,
    0,    0,    0,    0,   37,   99,    0,   34,    0,   35,
    0,    0,    0,    0,    0,   99,  107,    0,    0,  107,
    0,   99,    0,    0,    0,    0,   99,    0,    0,    0,
    0,    0,   99,  107,  107,  107,  107,  107,  107,    0,
    0,    0,    0,    0,    0,   95,    0,    0,   95,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,   95,   95,    0,   95,    0,   95,    0,   99,
    0,   99,    0,   99,   99,    0,   99,   99,    0,   99,
   99,   99,    0,   99,   99,    0,   99,   99,    0,   99,
   36,   99,   99,   99,   99,   99,   99,    0,    0,    0,
    0,    0,    0,  100,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  100,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  100,    0,   91,    0,    0,
   91,  100,    0,    0,    0,    0,  100,    0,    0,    0,
    0,    0,  100,    0,   91,   91,    0,   91,    0,   91,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  100,
    0,  100,    0,  100,  100,    0,  100,  100,    0,  100,
  100,  100,    0,  100,  100,    0,  100,  100,    0,  100,
    0,  100,  100,  100,  100,  100,  100,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  257,    0,    1,    2,    3,    4,    5,
    6,    7,  107,    0,    8,    0,    0,    9,   10,   11,
    0,    0,    0,    0,  107,   33,   12,    0,    0,   13,
   14,    0,   37,    0,  107,   34,    0,   35,   15,   16,
  107,   95,    0,   17,    0,  107,    0,   18,   19,    0,
   20,  107,    0,   95,   21,    0,   22,    0,   23,    0,
    0,    0,    0,   95,   24,    0,    0,   25,   26,   95,
   27,   28,   29,   30,    0,    0,   31,    0,   32,    0,
   95,    0,    0,    0,    0,    0,    0,    0,  107,    0,
  107,    0,  107,  107,    0,  107,  107,    0,  107,  107,
  107,    0,  107,  107,    0,  107,  107,    0,  107,    0,
  107,  107,  107,  107,  107,  107,    0,   95,   36,   95,
    0,   95,   95,   91,   95,   95,   33,   95,   95,   95,
    0,    0,   95,   37,    0,    0,   34,    0,   35,    0,
   95,   95,   95,   95,   95,   91,    0,    0,    0,    0,
    0,   91,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,   91,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,   91,
    0,   91,    0,   91,   91,    0,   91,   91,   33,   91,
   91,   91,    0,    0,   91,   37,    0,    0,   34,   36,
   35,    0,    0,   91,   91,   91,   91,    0,    0,    0,
    0,    0,    0,    0,   33,    0,    0,    0,    0,    0,
    0,   37,  201,    0,   34,    0,   35,    0,    0,    0,
    0,    0,    0,    1,    2,    3,    4,    5,    6,    7,
    0,    0,    8,    0,    0,    9,   10,   11,    0,    0,
    0,    0,    0,    0,   12,    0,    0,   13,   14,    0,
    0,    0,    0,    0,    0,    0,   15,   16,    0,    0,
    0,   17,    0,    0,    0,   18,   19,    0,   20,    0,
    0,   36,   21,    0,   22,    0,   23,    0,    0,    0,
    0,    0,   24,    0,    0,   25,   26,    0,   27,   28,
   29,   30,   33,    0,   31,    0,   32,   36,    0,   37,
    0,    0,   34,    0,   35,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  207,    0,    0,    0,    1,    2,    3,    4,    5,    6,
    7,    0,    0,    8,    0,   37,    0,   10,   34,    0,
   35,    0,    0,    0,    0,   12,    0,    0,    0,   14,
    0,    0,    0,    0,    0,    0,    0,   15,   16,    0,
    0,    0,   17,    0,    0,    0,   18,   19,    0,   20,
    0,    0,    0,   21,    0,   22,    0,   23,    0,    0,
    0,    0,    0,    0,    0,   36,   25,   26,    0,   27,
   28,   29,   30,    0,    0,   31,    0,   32,    0,    0,
    0,    0,    0,    0,    0,    0,    1,    2,    3,    4,
    5,    6,    7,    0,    0,    8,    0,    0,    0,   10,
   37,   36,    0,   34,    0,   35,    0,   12,    0,    0,
    0,   14,    1,    2,    3,    4,    5,    6,    7,   15,
   16,    0,    0,    0,   17,    0,    0,    0,   18,   19,
    0,   20,    0,   12,    0,   21,    0,   22,    0,   23,
    0,    0,    0,    0,    0,   15,   16,    0,   25,   26,
    0,   27,   28,   29,   30,   19,    0,   31,    0,   32,
    0,   21,    0,   22,    0,   23,    0,    0,    0,    0,
    0,    0,    0,    0,   25,   26,    0,   27,   28,   29,
   30,    0,    0,   31,    0,   32,   36,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    1,    2,    3,    4,    5,    6,    7,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   12,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,   15,   16,    0,    1,    2,    3,    4,
    5,    6,    7,   19,    0,    0,    0,    0,    0,   21,
    0,   22,    0,   23,    0,    0,    0,   12,    0,    0,
    0,    0,   25,   26,    0,   27,   28,   29,   30,   15,
  178,   31,    0,   32,    0,    0,    0,    0,    0,   19,
    0,    0,    0,    0,    0,   21,    0,   22,    0,   23,
    0,    0,    0,    0,    0,    0,    0,    0,   25,   26,
    0,   27,   28,   29,   30,    0,    0,   31,    0,   32,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    1,    2,    3,    4,    5,    6,    7,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,   12,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   15,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   19,    0,    0,    0,    0,    0,
   21,    0,   22,    0,   23,    0,    0,    0,    0,    0,
    0,    0,    0,   25,   26,    0,   27,   28,   29,   30,
    0,    0,   31,    0,   32,
  };
  protected static readonly short [] yyCheck = {            58,
    0,   63,   37,    0,   40,   59,   13,   42,   41,   59,
   46,   44,   47,   20,   59,  296,  269,   24,   60,   41,
   62,  147,  286,   44,  150,   58,   59,    9,  154,   11,
   37,   41,   14,   33,  114,  278,  279,  117,   59,   43,
   40,   45,  257,   43,  257,   45,   59,   40,   58,   59,
   44,  100,  101,  102,  103,  104,  105,  106,  107,  108,
  109,  110,  111,  112,  113,   58,   31,   32,  279,   34,
   35,   36,  124,   16,    0,  230,   40,  346,  359,   94,
  349,   41,   46,   41,   44,  296,   44,   38,   41,   41,
   33,   44,   44,  248,   58,  144,   41,  115,  116,   44,
  131,  132,   84,  356,  133,  134,  135,   33,  339,  235,
   58,   44,   46,   41,   40,  258,   58,   43,   58,   45,
  257,   46,  126,   58,  250,  279,  126,   58,  254,   58,
  256,   58,  156,  257,   58,  261,  261,  262,  263,  264,
  265,  266,  267,  257,  224,  225,  257,   97,  359,  222,
    0,  120,  121,  122,  123,  124,  125,  126,  127,  263,
  236,  143,  144,  232,  146,   84,  148,  149,  151,  151,
  152,  136,  137,  138,  139,  118,  119,   99,  140,  228,
  129,  128,   19,   33,  130,  228,   -1,   -1,   -1,   -1,
   40,   -1,   -1,   43,   -1,   45,   -1,   -1,  323,   -1,
  126,   -1,   -1,  257,   -1,   -1,   -1,  257,   -1,  178,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  227,   -1,   -1,  285,  257,   -1,   -1,   -1,   -1,   -1,
   -1,  238,   -1,  230,  296,   -1,  257,  296,    0,  261,
  262,  263,  264,  265,  266,  267,  228,  257,  290,   -1,
  232,  248,  234,   -1,  236,   -1,   -1,  257,   -1,  259,
   -1,  261,  262,  263,  264,  265,  266,  267,   -1,   -1,
  270,   33,   -1,  273,  274,  275,  126,   -1,   40,   -1,
   -1,   43,  282,   45,   -1,  285,  286,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,  295,  332,  359,  334,  299,
  359,  323,   -1,  303,  304,  347,  306,  342,  350,  351,
  310,  353,  312,  355,  314,   -1,   -1,   -1,   -1,   -1,
  320,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,  257,  332,  259,  334,  261,  262,  263,  264,  265,
  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,   -1,   -1,  282,   61,   -1,  285,
  286,   -1,   -1,   -1,  126,   -1,   -1,   -1,  294,  295,
   -1,   -1,   -1,  299,   -1,   -1,   -1,  303,  304,   -1,
  306,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,   -1,
   -1,   -1,   -1,   40,  320,   -1,   -1,  323,  324,   -1,
  326,  327,  328,  329,   -1,   -1,  332,  257,  334,  259,
   -1,  261,  262,  263,  264,  265,  266,  267,   -1,   -1,
  270,   -1,   -1,  273,  274,  275,   -1,   -1,   -1,   -1,
   -1,   -1,  282,   -1,   -1,  285,  286,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,  295,   -1,   -1,   -1,  299,
   -1,   -1,   -1,  303,  304,   -1,  306,   -1,   -1,   -1,
  310,   -1,  312,   -1,  314,   -1,   -1,   -1,   41,   -1,
  320,   44,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,   -1,  332,   -1,  334,   58,   59,   -1,   61,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  259,   -1,  261,
  262,  263,  264,  265,  266,  267,   -1,   -1,  270,   -1,
   -1,  273,  274,  275,   -1,   -1,   -1,   -1,   -1,   -1,
  282,   -1,   -1,  285,  286,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  294,  295,   -1,   -1,   -1,  299,   -1,   -1,
   -1,  303,  304,   -1,  306,   -1,   -1,   -1,  310,   -1,
  312,   -1,  314,   -1,   -1,   -1,   -1,   -1,  320,   -1,
   -1,  323,  324,   -1,  326,  327,  328,  329,   -1,   -1,
  332,   -1,  334,   37,   38,   -1,   -1,   41,   42,   43,
   44,   45,   -1,   47,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,
   -1,   -1,   37,   38,   -1,   -1,   41,   42,   43,   44,
   45,   -1,   47,   -1,  261,  262,  263,  264,  265,  266,
  267,   -1,   -1,   58,   59,   60,   61,   62,   63,  333,
   94,  335,   -1,  337,  338,  282,  340,  341,   -1,  343,
  344,  345,   -1,   -1,  348,   -1,   -1,  294,   -1,   -1,
   -1,   -1,   -1,  357,  358,   -1,  360,  304,   -1,   94,
  124,   -1,  126,  310,   -1,  312,   -1,  314,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  323,  324,   -1,  326,
  327,  328,  329,   -1,  257,   -1,   -1,   -1,   -1,  124,
   -1,  126,   -1,   -1,   37,   38,   -1,   40,   41,   42,
   43,   44,   45,   46,   47,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   60,   61,   62,
   63,   -1,   -1,   37,   38,   -1,   -1,   41,   42,   43,
   44,   45,   -1,   47,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,
   -1,   94,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,   -1,  348,   -1,   -1,   -1,   -1,
   94,  124,   -1,  126,  357,  358,   -1,  360,   -1,   -1,
   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,
  124,   -1,  126,   -1,   -1,  279,   -1,   -1,   -1,   -1,
   -1,  285,  257,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   -1,  269,   -1,   -1,   -1,   40,   -1,
   -1,   -1,   41,   -1,  279,   44,   -1,   -1,   -1,   -1,
  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   58,
   59,  296,   61,   -1,   -1,   -1,   -1,   -1,   -1,  333,
   -1,  335,   -1,  337,  338,  339,  340,  341,  342,  343,
  344,  345,  346,  347,  348,  349,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   -1,  333,   -1,
  335,   -1,  337,  338,  339,  340,  341,  342,  343,  344,
  345,  346,  347,  348,  349,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,  269,   -1,   -1,   -1,
   -1,   -1,   41,   -1,   -1,   44,   -1,   -1,   -1,   -1,
   -1,   -1,  285,  257,   -1,   -1,   -1,  290,   -1,   58,
   59,   -1,   61,  296,   -1,  269,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,
   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   -1,   -1,   -1,   -1,   -1,   -1,  332,
  333,  334,  335,   -1,  337,  338,  339,  340,  341,  342,
  343,  344,  345,  346,  347,  348,  349,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,  342,  343,
  344,  345,  346,  347,  348,  349,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   38,   -1,   -1,
   41,   -1,   43,   44,   45,   -1,   -1,   -1,  257,  261,
  262,  263,  264,  265,  266,  267,   -1,   58,   59,   60,
   61,   62,   63,   -1,   -1,   -1,   38,   -1,   -1,   41,
  282,   43,   44,   45,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  294,   -1,   -1,   -1,   58,   59,   60,   61,
   62,   63,   -1,   94,   -1,   -1,   -1,   -1,  310,   -1,
  312,   -1,  314,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  323,  324,   -1,  326,  327,  328,  329,   -1,   -1,
   -1,   -1,   94,  124,  333,  126,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,  257,  348,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  357,  358,
   -1,  360,  124,   -1,  126,   -1,   -1,   -1,   -1,   -1,
   -1,   38,   -1,   -1,   41,   -1,   43,   44,   45,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  333,   -1,  335,   94,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,   -1,  348,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  357,  358,
   -1,  360,   -1,   -1,   -1,   -1,   -1,  124,   -1,  126,
   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  269,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   41,   -1,  279,   44,
   -1,   -1,   -1,   -1,  285,  257,   -1,   -1,   -1,  290,
   -1,   -1,   -1,   58,   59,  296,   61,  269,   63,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,
   -1,   -1,   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,
   -1,   -1,   -1,   -1,  296,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,
  341,   -1,  343,  344,  345,  346,  347,  348,  349,  350,
  351,   -1,  353,   -1,  355,  356,  357,  358,  359,  360,
   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,
   -1,  343,  344,  345,  346,  347,  348,  349,  350,  351,
  257,  353,   -1,  355,  356,  357,  358,  359,  360,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,  285,   38,
   -1,   -1,   41,  290,   43,   44,   45,   -1,   -1,  296,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   58,
   59,   60,   61,   62,   63,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,  335,   -1,
  337,  338,   -1,  340,  341,   94,  343,  344,  345,  346,
  347,  348,  349,  350,  351,   -1,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,  124,   -1,  126,   -1,   -1,
   -1,   -1,   -1,   -1,   38,   -1,   -1,   41,   -1,   -1,
   44,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,
  285,   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,
   -1,  296,   -1,   38,   -1,   -1,   41,   -1,   -1,   44,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,   -1,
   94,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,   -1,  348,   -1,   -1,   -1,   -1,   -1,   94,
  124,   -1,  357,  358,  359,  360,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  124,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  279,   38,   -1,   -1,   41,   -1,  285,   44,   -1,   -1,
   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,   -1,
   -1,   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  333,   -1,  335,   94,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,  346,  347,  348,
  349,  350,  351,  257,  353,   -1,  355,  356,  357,  358,
  359,  360,   -1,   -1,   -1,  269,   -1,  124,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,
   -1,  285,  257,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   38,  279,   -1,   41,   -1,   -1,   44,
  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   -1,   58,   59,   60,   61,   62,   63,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,  346,  347,  348,  349,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   -1,  333,   94,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,  346,  347,  348,  349,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,  124,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   38,  279,   -1,   41,   -1,   -1,   44,  285,   -1,
   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,
   -1,   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,
   -1,   -1,   -1,   41,   -1,   -1,   44,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   58,   59,   60,   61,   62,   63,  333,   94,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,  346,
  347,  348,  349,  350,  351,   -1,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,   -1,   94,  124,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  269,   -1,  124,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   41,   -1,
  285,   44,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   -1,   -1,   -1,   58,   59,   60,   61,   62,
   63,   -1,   -1,   -1,   -1,   -1,   -1,   41,   -1,   -1,
   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   58,   59,   -1,   61,  333,   63,
  335,   94,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,   -1,
   -1,  124,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,  285,  257,
   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,
   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  279,   41,   -1,   -1,   44,   -1,  285,   -1,   -1,
   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   58,
   59,   60,   61,   62,   63,   -1,  333,   -1,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,
  347,  348,   -1,  350,  351,   -1,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,  333,   -1,  335,   -1,  337,
  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,  347,
  348,   -1,  350,  351,  257,  353,   -1,  355,  356,  357,
  358,  359,  360,   -1,   -1,  124,  269,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,
   44,   -1,  285,  257,   -1,   -1,   -1,  290,   -1,   -1,
   -1,   -1,   -1,  296,   58,   59,   60,   61,   62,   63,
   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,   44,
   -1,  285,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  296,   58,   59,   60,   61,   62,   63,   -1,
  333,   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,
  343,  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,
  353,   -1,  355,  356,  357,  358,  359,  360,   -1,  333,
  124,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,   -1,   -1,  348,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  357,  358,  359,  360,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  279,   41,   -1,   -1,   44,   -1,  285,   -1,   -1,   -1,
   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   58,   59,
   60,   61,   62,   63,   -1,   -1,   -1,   -1,   -1,   -1,
   41,   -1,   -1,   44,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   58,   59,   60,
   61,   62,   63,   -1,  333,   -1,  335,   -1,  337,  338,
   -1,  340,  341,   -1,  343,  344,  345,   -1,  347,  348,
   -1,  350,  351,  257,  353,   -1,  355,  356,  357,  358,
  359,  360,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  279,   -1,   -1,   -1,   -1,
   -1,  285,  257,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   -1,  269,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,   44,   -1,
  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,
   -1,  296,   58,   59,   60,   61,   62,   63,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  269,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  279,
   -1,   -1,   -1,   -1,   41,  285,  257,   44,   -1,   -1,
  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,  269,   -1,
   -1,   58,   59,   60,   61,   62,   63,   -1,  279,   -1,
   -1,   -1,   -1,   -1,  285,   -1,   -1,   -1,   -1,  290,
   -1,   -1,   -1,   -1,   -1,  296,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  333,   -1,  335,   -1,  337,  338,   -1,
  340,  341,   -1,  343,  344,  345,   -1,  347,  348,   -1,
  350,  351,   -1,  353,   -1,  355,  356,  357,  358,  359,
  360,   -1,  333,   -1,  335,   -1,  337,  338,   -1,  340,
  341,   -1,  343,  344,  345,   -1,  347,  348,   -1,  350,
  351,  257,  353,   -1,  355,  356,  357,  358,  359,  360,
   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  279,   41,   -1,   -1,   44,   -1,  285,
   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,
  296,   58,   59,   60,   61,   62,   63,   -1,   -1,   -1,
   -1,   -1,   -1,   41,   -1,   -1,   44,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   58,   59,   60,   61,   62,   63,   -1,  333,   -1,  335,
   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,  345,
   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,  355,
  356,  357,  358,  359,  360,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   -1,   -1,   -1,   -1,   -1,  285,   -1,
   -1,   -1,   -1,  290,   -1,   -1,   -1,   41,   -1,  296,
   44,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   58,   59,   60,   61,   62,   63,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,
  347,  348,   -1,  350,  351,   -1,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  269,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  279,   -1,   -1,   -1,   -1,   41,  285,  257,
   44,   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,
   -1,  269,   -1,   -1,   58,   59,   60,   61,   62,   63,
   -1,  279,   -1,   -1,   -1,   -1,   -1,  285,   -1,   -1,
   -1,   -1,  290,   -1,   -1,   -1,   -1,   -1,  296,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,  335,   -1,
  337,  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,
  347,  348,   -1,  350,  351,   -1,  353,   -1,  355,  356,
  357,  358,  359,  360,   -1,  333,   -1,  335,   -1,  337,
  338,   -1,  340,  341,   -1,  343,  344,  345,   -1,  347,
  348,   -1,  350,  351,   -1,  353,   -1,  355,  356,  357,
  358,  359,  360,  257,   -1,   -1,   -1,   33,   -1,   -1,
   -1,   -1,   -1,   -1,   40,  269,   -1,   43,   -1,   45,
   -1,   -1,   -1,   -1,   -1,  279,   41,   -1,   -1,   44,
   -1,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   58,   59,   60,   61,   62,   63,   -1,
   -1,   -1,   -1,   -1,   -1,   41,   -1,   -1,   44,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   58,   59,   -1,   61,   -1,   63,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,
  126,  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,
   -1,   -1,   -1,  257,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  269,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  279,   -1,   41,   -1,   -1,
   44,  285,   -1,   -1,   -1,   -1,  290,   -1,   -1,   -1,
   -1,   -1,  296,   -1,   58,   59,   -1,   61,   -1,   63,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,
  344,  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,
   -1,  355,  356,  357,  358,  359,  360,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  259,   -1,  261,  262,  263,  264,  265,
  266,  267,  257,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,  269,   33,  282,   -1,   -1,  285,
  286,   -1,   40,   -1,  279,   43,   -1,   45,  294,  295,
  285,  257,   -1,  299,   -1,  290,   -1,  303,  304,   -1,
  306,  296,   -1,  269,  310,   -1,  312,   -1,  314,   -1,
   -1,   -1,   -1,  279,  320,   -1,   -1,  323,  324,  285,
  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,   -1,
  296,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,   -1,
  335,   -1,  337,  338,   -1,  340,  341,   -1,  343,  344,
  345,   -1,  347,  348,   -1,  350,  351,   -1,  353,   -1,
  355,  356,  357,  358,  359,  360,   -1,  333,  126,  335,
   -1,  337,  338,  257,  340,  341,   33,  343,  344,  345,
   -1,   -1,  348,   40,   -1,   -1,   43,   -1,   45,   -1,
  356,  357,  358,  359,  360,  279,   -1,   -1,   -1,   -1,
   -1,  285,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  296,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  333,
   -1,  335,   -1,  337,  338,   -1,  340,  341,   33,  343,
  344,  345,   -1,   -1,  348,   40,   -1,   -1,   43,  126,
   45,   -1,   -1,  357,  358,  359,  360,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   33,   -1,   -1,   -1,   -1,   -1,
   -1,   40,   41,   -1,   43,   -1,   45,   -1,   -1,   -1,
   -1,   -1,   -1,  261,  262,  263,  264,  265,  266,  267,
   -1,   -1,  270,   -1,   -1,  273,  274,  275,   -1,   -1,
   -1,   -1,   -1,   -1,  282,   -1,   -1,  285,  286,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,   -1,   -1,
   -1,  299,   -1,   -1,   -1,  303,  304,   -1,  306,   -1,
   -1,  126,  310,   -1,  312,   -1,  314,   -1,   -1,   -1,
   -1,   -1,  320,   -1,   -1,  323,  324,   -1,  326,  327,
  328,  329,   33,   -1,  332,   -1,  334,  126,   -1,   40,
   -1,   -1,   43,   -1,   45,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  257,   -1,   -1,   -1,  261,  262,  263,  264,  265,  266,
  267,   -1,   -1,  270,   -1,   40,   -1,  274,   43,   -1,
   45,   -1,   -1,   -1,   -1,  282,   -1,   -1,   -1,  286,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,   -1,
   -1,   -1,  299,   -1,   -1,   -1,  303,  304,   -1,  306,
   -1,   -1,   -1,  310,   -1,  312,   -1,  314,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  126,  323,  324,   -1,  326,
  327,  328,  329,   -1,   -1,  332,   -1,  334,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  261,  262,  263,  264,
  265,  266,  267,   -1,   -1,  270,   -1,   -1,   -1,  274,
   40,  126,   -1,   43,   -1,   45,   -1,  282,   -1,   -1,
   -1,  286,  261,  262,  263,  264,  265,  266,  267,  294,
  295,   -1,   -1,   -1,  299,   -1,   -1,   -1,  303,  304,
   -1,  306,   -1,  282,   -1,  310,   -1,  312,   -1,  314,
   -1,   -1,   -1,   -1,   -1,  294,  295,   -1,  323,  324,
   -1,  326,  327,  328,  329,  304,   -1,  332,   -1,  334,
   -1,  310,   -1,  312,   -1,  314,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  323,  324,   -1,  326,  327,  328,
  329,   -1,   -1,  332,   -1,  334,  126,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  261,  262,  263,  264,  265,  266,  267,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  282,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  294,  295,   -1,  261,  262,  263,  264,
  265,  266,  267,  304,   -1,   -1,   -1,   -1,   -1,  310,
   -1,  312,   -1,  314,   -1,   -1,   -1,  282,   -1,   -1,
   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,  294,
  295,  332,   -1,  334,   -1,   -1,   -1,   -1,   -1,  304,
   -1,   -1,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  323,  324,
   -1,  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  261,  262,  263,  264,  265,  266,  267,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,  282,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  304,   -1,   -1,   -1,   -1,   -1,
  310,   -1,  312,   -1,  314,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,   -1,  332,   -1,  334,
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

#line 748 "InteractiveParser.jay"
    }
#line default

} // close outermost namespace, that MUST HAVE BEEN opened in the prolog
