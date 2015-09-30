// created by jay 0.7 (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
// edited by Tomona Nanase in 2014, 2015

#line 2 "FileParser.jay"

//
// FileParser.jay / FileParser.cs
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
    partial class FileParser
    {
        private int yacc_verbose_flag = 0;
        
#line default

        /** error output stream.
          * It should be changeable.
          */
        public System.IO.TextWriter ErrorOutput = System.Console.Out;

        /** simplified error message.
          * @see <a href="#yyerror(java.lang.String, java.lang.String[])">yyerror</a>
          */
        public void yyerror (string message)
        {
            yyerror(message, null);
        }

#pragma warning disable 649
        /* An EOF token */
        public int eof_token;
#pragma warning restore 649

        /** (syntax) error message.
          * Can be overwritten to control message format.
          * @param message text to be displayed.
          * @param expected vector of acceptable tokens, if available.
          */
        public void yyerror(string message, string[] expected)
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

  protected const int yyFinal = 39;
//t // Put this array into a separate class so it is only initialized if debugging is actually used
//t // Use MarshalByRefObject to disable inlining
//t class YYRules : MarshalByRefObject {
//t  public static readonly string [] yyRule = {
//t    "$accept : program",
//t    "program :",
//t    "program : program_lines",
//t    "program_lines : program_line",
//t    "program_lines : program_lines program_line",
//t    "program_line : statement",
//t    "program_line : NewLine",
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
//t        public static string yyname (int token)
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
        protected int[] yyExpectingTokens(int state)
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

        protected string[] yyExpecting(int state)
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
        internal Object yyparse(yyParser.yyInput yyLex, yydebug.yyDebug yyd)
        {
//t            this.debug = yyd;
            return yyparse(yyLex);
        }

        /** initial size and increment of the state/value stack [default 256].
          * This is not final so that it can be overwritten outside of invocations
          * of yyparse().
          */
        protected int yyMax;

        /** executed at the beginning of a reduce action.
          * Used as $$ = yyDefault($1), prior to the user-specified action, if any.
          * Can be overwritten to provide deep copy, etc.
          * @param first value for $1, or null.
          * @return first.
          */
        protected Object yyDefault(Object first)
        {
            return first;
        }

        static int[] global_yyStates;
        static object[] global_yyVals;
#pragma warning disable 649
        protected bool use_global_stacks;
#pragma warning restore 649
        object[] yyVals;					// value stack
        object yyVal;						// value stack ptr
        int yyToken;						// current input
        int yyTop;
        yyParser.IToken currentToken;

        /** the generated parser.
          * Maintains a state and a value stack, currently with fixed maximum size.
          * @param yyLex scanner.
          * @return result of the last reduction, if any.
          * @throws yyException on irrecoverable parse error.
          */
        internal Object yyparse (yyParser.yyInput yyLex)
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
                                    throw new yyParser.yyUnexpectedEof(currentToken);

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

                                throw new yyParser.yySyntaxError("irrecoverable syntax error", currentToken);

                            case 3:
                                if (yyToken == 0)
                                {
//t                                    if (debug != null)
//t                                        debug.reject();
//t
                                    throw new yyParser.yySyntaxErrorAtEof("irrecoverable syntax error at end-of-file",
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
#line 105 "FileParser.jay"
  {
            yyVal = new Node[0];
        }
  break;
case 4:
  case_4();
  break;
case 6:
#line 122 "FileParser.jay"
  {
    		yyVal = new Node[0];
    	}
  break;
case 7:
#line 129 "FileParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 8:
#line 133 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 9:
#line 139 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 10:
  case_10();
  break;
case 11:
#line 156 "FileParser.jay"
  {
            yyVal = null;
        }
  break;
case 12:
#line 160 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 13:
  case_13();
  break;
case 18:
#line 183 "FileParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 19:
#line 187 "FileParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 21:
  case_21();
  break;
case 22:
#line 202 "FileParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 23:
#line 206 "FileParser.jay"
  {
            yyVal = new IfStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 24:
#line 212 "FileParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 25:
#line 216 "FileParser.jay"
  {
            yyVal = new ElifStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 27:
#line 223 "FileParser.jay"
  {
            yyVal = new ElseStatementNode((LToken)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 28:
#line 229 "FileParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 29:
#line 233 "FileParser.jay"
  {
            yyVal = new WhileStatementNode((LToken)yyVals[-4+yyTop], (Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop], (StatementNode)yyVals[0+yyTop]);
        }
  break;
case 30:
#line 239 "FileParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 31:
#line 243 "FileParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-5+yyTop], (Node)yyVals[-4+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 32:
#line 247 "FileParser.jay"
  {
            yyVal = new FunctionStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 33:
#line 253 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 34:
  case_34();
  break;
case 35:
#line 264 "FileParser.jay"
  {
            yyVal = new Node[] { new ParameterNode((Node)yyVals[0+yyTop]) };
        }
  break;
case 36:
  case_36();
  break;
case 37:
#line 276 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 38:
#line 282 "FileParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-6+yyTop], (Node)yyVals[-5+yyTop], (IEnumerable<Node>)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 39:
#line 286 "FileParser.jay"
  {
            yyVal = new ClassStatementNode((LToken)yyVals[-3+yyTop], (Node)yyVals[-2+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 40:
#line 292 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 41:
#line 298 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 42:
  case_42();
  break;
case 43:
#line 310 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 44:
  case_44();
  break;
case 51:
#line 330 "FileParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Pass);
        }
  break;
case 53:
#line 339 "FileParser.jay"
  {
			yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 54:
#line 343 "FileParser.jay"
  {
			yyVal = new UnaryStatementNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], StatementNodeType.Return);
		}
  break;
case 55:
#line 349 "FileParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Break);
        }
  break;
case 56:
#line 355 "FileParser.jay"
  {
            yyVal = new NullaryStatementNode((LToken)yyVals[0+yyTop], StatementNodeType.Continue);
        }
  break;
case 57:
#line 361 "FileParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 58:
#line 365 "FileParser.jay"
  {
            yyVal = new ImportStatementNode((LToken)yyVals[-2+yyTop], (LToken)yyVals[-1+yyTop], (IEnumerable<Node>)yyVals[0+yyTop]);
        }
  break;
case 59:
#line 371 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 60:
  case_60();
  break;
case 62:
#line 386 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 63:
  case_63();
  break;
case 75:
#line 415 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Comma);
        }
  break;
case 77:
#line 422 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Assign);
        }
  break;
case 78:
#line 426 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignAddition);
        }
  break;
case 79:
#line 430 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignSubtraction);
        }
  break;
case 80:
#line 434 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignMultiplication);
        }
  break;
case 81:
#line 438 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignDivision);
        }
  break;
case 82:
#line 442 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignIntDivision);
        }
  break;
case 83:
#line 446 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignPower);
        }
  break;
case 84:
#line 450 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignModulo);
        }
  break;
case 85:
#line 454 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticAnd);
        }
  break;
case 86:
#line 458 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticOr);
        }
  break;
case 87:
#line 462 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignArithmeticXor);
        }
  break;
case 88:
#line 466 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignConcatenation);
        }
  break;
case 89:
#line 470 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignLeftShift);
        }
  break;
case 90:
#line 474 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.AssignRightShift);
        }
  break;
case 92:
#line 481 "FileParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 93:
#line 485 "FileParser.jay"
  {
            yyVal = new TernaryNode((LToken)yyVals[-3+yyTop], (LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[-4+yyTop], (Node)yyVals[0+yyTop], TernaryNodeType.Condition);
        }
  break;
case 95:
#line 492 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 96:
#line 496 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalOr);
        }
  break;
case 98:
#line 503 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 99:
#line 507 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LogicalAnd);
        }
  break;
case 101:
#line 514 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 102:
#line 518 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.LogicalNot);
        }
  break;
case 104:
#line 525 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThan);
        }
  break;
case 105:
#line 529 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThan);
        }
  break;
case 106:
#line 533 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LessThanEqual);
        }
  break;
case 107:
#line 537 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.GreaterThanEqual);
        }
  break;
case 108:
#line 541 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Equal);
        }
  break;
case 109:
#line 545 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.NotEqual);
        }
  break;
case 110:
#line 549 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Is);
        }
  break;
case 111:
#line 553 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 112:
#line 557 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-3+yyTop], (Node)yyVals[-1+yyTop], BinaryNodeType.IsNot);
        }
  break;
case 114:
#line 564 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticOr);
        }
  break;
case 116:
#line 571 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticXor);
        }
  break;
case 118:
#line 578 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.ArithmeticAnd);
        }
  break;
case 120:
#line 585 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.LeftShift);
        }
  break;
case 121:
#line 589 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.RightShift);
        }
  break;
case 123:
#line 596 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Addition);
        }
  break;
case 124:
#line 600 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Subtraction);
        }
  break;
case 125:
#line 604 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Concatenation);
        }
  break;
case 127:
#line 611 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Multiplication);
        }
  break;
case 128:
#line 615 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.IntDivision);
        }
  break;
case 129:
#line 619 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Division);
        }
  break;
case 130:
#line 623 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Modulo);
        }
  break;
case 132:
#line 630 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.IncrementPrefix);
        }
  break;
case 133:
#line 634 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.DecrementPrefix);
        }
  break;
case 134:
#line 638 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignNegative);
        }
  break;
case 135:
#line 642 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.SignPositive);
        }
  break;
case 136:
#line 646 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[0+yyTop], UnaryNodeType.BitwiseNot);
        }
  break;
case 138:
#line 653 "FileParser.jay"
  {
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], (Node)yyVals[0+yyTop], BinaryNodeType.Power);
        }
  break;
case 139:
#line 659 "FileParser.jay"
  {
			yyVal = new EvalNode((Node)yyVals[0+yyTop]);
		}
  break;
case 140:
#line 663 "FileParser.jay"
  {
			yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.Ref);
		}
  break;
case 142:
  case_142();
  break;
case 143:
#line 675 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.IncrementPostfix);
        }
  break;
case 144:
#line 679 "FileParser.jay"
  {
            yyVal = new UnaryNode((LToken)yyVals[0+yyTop], (Node)yyVals[-1+yyTop], UnaryNodeType.DecrementPostfix);
        }
  break;
case 145:
#line 683 "FileParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-2+yyTop]);
        }
  break;
case 146:
#line 687 "FileParser.jay"
  {
            yyVal = new CallNode((Node)yyVals[-3+yyTop], (IEnumerable<Node>)yyVals[-1+yyTop]);
        }
  break;
case 147:
#line 693 "FileParser.jay"
  {
            yyVal = new Node[] { (Node)yyVals[0+yyTop] };
        }
  break;
case 148:
  case_148();
  break;
case 151:
#line 709 "FileParser.jay"
  {
            yyVal = new ArgumentNode((LToken)yyVals[-2+yyTop], (Node)yyVals[-1+yyTop]);
        }
  break;
case 152:
#line 715 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
        }
  break;
case 154:
#line 720 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.False);
        }
  break;
case 155:
#line 724 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.True);
        }
  break;
case 156:
#line 728 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Nil);
        }
  break;
case 157:
#line 732 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.This);
        }
  break;
case 158:
#line 736 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Super);
        }
  break;
case 159:
#line 740 "FileParser.jay"
  {
            yyVal = yyVals[-1+yyTop];
        }
  break;
case 160:
#line 746 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.String);
        }
  break;
case 161:
#line 750 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.String);
        }
  break;
case 162:
#line 754 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Imaginary);
        }
  break;
case 163:
#line 758 "FileParser.jay"
  {
            yyVal = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Floating);
        }
  break;
case 164:
#line 762 "FileParser.jay"
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
#line 111 "FileParser.jay"
{
	        var newList = new List<Node>((IEnumerable<Node>)yyVals[-1+yyTop]);
	        newList.AddRange((IEnumerable<Node>)yyVals[0+yyTop]);
	        yyVal = newList;
        }

void case_10()
#line 141 "FileParser.jay"
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

void case_13()
#line 162 "FileParser.jay"
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

void case_21()
#line 192 "FileParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-1+yyTop]);
            newList.AddRange((IEnumerable<Node>)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_34()
#line 255 "FileParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_36()
#line 266 "FileParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_42()
#line 300 "FileParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_44()
#line 312 "FileParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_60()
#line 373 "FileParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

void case_63()
#line 388 "FileParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_142()
#line 668 "FileParser.jay"
{
            Node n = new ConstantNode((LToken)yyVals[0+yyTop], ConstantNodeType.Identifier);
            yyVal = new BinaryNode((LToken)yyVals[-1+yyTop], (Node)yyVals[-2+yyTop], n, BinaryNodeType.Dot);
        }

void case_148()
#line 695 "FileParser.jay"
{
            var newList = new List<Node>((IEnumerable<Node>)yyVals[-2+yyTop]);
            newList.Add((Node)yyVals[0+yyTop]);
            yyVal = newList;
        }

#line default
   static readonly short [] yyLhs  = {              -1,
    0,    0,    1,    1,    2,    2,    3,    3,    4,    4,
    7,    7,    7,    5,    5,    5,    5,   12,   12,   13,
   13,    8,    8,   15,   15,   15,   16,    9,    9,   10,
   10,   10,   17,   17,   18,   18,   20,   11,   11,   21,
   22,   22,   23,   23,    6,    6,    6,    6,    6,    6,
   24,   25,   26,   26,   27,   28,   29,   29,   30,   30,
   31,   32,   32,   19,   19,   33,   33,   33,   33,   33,
   33,   33,   14,   34,   34,   35,   35,   35,   35,   35,
   35,   35,   35,   35,   35,   35,   35,   35,   35,   35,
   36,   36,   36,   37,   37,   37,   38,   38,   38,   39,
   39,   39,   40,   40,   40,   40,   40,   40,   40,   40,
   40,   40,   41,   41,   42,   42,   43,   43,   44,   44,
   44,   45,   45,   45,   45,   46,   46,   46,   46,   46,
   47,   47,   47,   47,   47,   47,   48,   48,   49,   49,
   50,   50,   50,   50,   50,   50,   52,   52,   53,   53,
   54,   51,   51,   51,   51,   51,   51,   51,   51,   55,
   55,   55,   55,   55,
  };
   static readonly short [] yyLen = {           2,
    0,    1,    1,    2,    1,    1,    2,    1,    1,    2,
    1,    2,    3,    1,    1,    1,    1,    2,    4,    1,
    2,    4,    5,    4,    5,    1,    3,    4,    5,    7,
    6,    4,    1,    3,    1,    3,    1,    7,    4,    1,
    1,    3,    1,    3,    1,    1,    1,    1,    1,    1,
    1,    1,    1,    2,    1,    1,    2,    3,    1,    3,
    1,    1,    3,    1,    1,    1,    1,    1,    1,    1,
    1,    1,    1,    1,    3,    1,    3,    3,    3,    3,
    3,    3,    3,    3,    3,    3,    3,    3,    3,    3,
    1,    5,    5,    1,    3,    3,    1,    3,    3,    1,
    2,    2,    1,    3,    3,    3,    3,    3,    3,    3,
    3,    4,    1,    3,    1,    3,    1,    3,    1,    3,
    3,    1,    3,    3,    3,    1,    3,    3,    3,    3,
    1,    2,    2,    2,    2,    2,    1,    3,    1,    2,
    1,    3,    2,    2,    3,    4,    1,    3,    1,    1,
    3,    1,    1,    1,    1,    1,    1,    1,    3,    1,
    1,    1,    1,    1,
  };
   static readonly short [] yyDefRed = {            0,
    6,   66,   67,   68,   69,   70,   71,   72,   55,    0,
   56,    0,  155,    0,    0,  156,    0,   51,    0,    0,
    0,  158,  157,  154,    0,   64,  160,  161,  162,  163,
  164,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    3,    5,    0,    8,    0,   14,   15,   16,   17,   52,
  152,   45,   46,   47,   48,   49,   50,   65,   73,    0,
    0,    0,    0,   97,    0,    0,    0,    0,    0,    0,
    0,  126,    0,  137,    0,  141,  153,   40,    0,    0,
   33,    0,   62,    0,   59,    0,  101,    0,    0,   54,
    0,  132,  133,  102,  135,  134,  136,    0,    4,    7,
    0,   10,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  143,  144,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  159,    0,
   75,   78,   79,   88,   83,   80,   82,   81,   84,   89,
   90,   85,   87,   86,   77,    0,    0,    0,    0,   98,
   99,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  128,  127,
  129,  130,  138,  142,  145,    0,  149,    0,  147,  150,
    0,    0,   39,   43,    0,    0,   32,   34,    0,    0,
   37,   35,    0,   60,   63,    0,   13,    0,    0,    0,
    0,    0,  146,    0,   18,    0,    0,    0,    0,    0,
    0,    0,    0,   23,   26,   29,    0,    0,  151,  148,
   20,    0,    0,    0,   44,   31,   36,    0,    0,    0,
   19,   21,   38,   30,    0,   27,    0,   25,
  };
  protected static readonly short [] yyDgoto  = {            39,
   40,   41,   42,  212,   44,   45,  102,   46,   47,   48,
   49,  213,  252,   50,  244,  245,   80,  220,   51,  222,
   79,  215,  216,   52,   53,   54,   55,   56,   57,   84,
   85,   86,   58,   59,   60,   61,   62,   63,   64,   65,
   66,   67,   68,   69,   70,   71,   72,   73,   74,   75,
   76,  208,  209,  210,   77,
  };
  protected static readonly short [] yySindex = {         3007,
    0,    0,    0,    0,    0,    0,    0,    0,    0, -202,
    0, -202,    0, 3678, -202,    0, 3678,    0, -249,  854,
 3678,    0,    0,    0, 3678,    0,    0,    0,    0,    0,
    0, 3768, 3768, 3678, 3768, 3768, 3768, 3678,    0, 3007,
    0,    0, -212,    0,   19,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    5,
  682,  -61, -252,    0,  -41,  -44,   13,   74, -310,  -10,
  -34,    0, -225,    0,  -35,    0,    0,    0,   43,   26,
    0,   66,    0,   81,    0,   73,    0, -202,  -35,    0,
   68,    0,    0,    0,    0,    0,    0,   89,    0,    0,
 3523,    0, 3678, 3678, 3678, 3678, 3678, 3678, 3678, 3678,
 3678, 3678, 3678, 3678, 3678, 3678, 3678, 3678, 3678, 3678,
 3678, 3678, 3678, 3714, 3768, 3768, 3768, 3768, 3768, 3768,
 3768, 3768, 3768, 3768, 3768, 3768, 3768, 3768, 3768, 3768,
 3768, 3768, 3768,  831,    0,    0, -202, 3603, 3438, -202,
 3438, -202,  -21, 3438, -202, -202,   81, 3438,    0,   19,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0, -253, -252, -252,  -58,    0,
    0, 3768,  -44,  -44,  -44,  -44,  -44,  -44,  -44,  -44,
   13,   74, -310,  -10,  -10,  -34,  -34,  -34,    0,    0,
    0,    0,    0,    0,    0,   77,    0,   29,    0,    0,
 -127, -124,    0,    0,   33,   90,    0,    0,   79,   35,
    0,    0, -255,    0,    0, -141,    0, 3678, 3678,  -44,
 3678, 3678,    0, 3356,    0, -202,   82, -202, 3438, -202,
   85, 3678,   87,    0,    0,    0, -278, -278,    0,    0,
    0, 3255,   90, 3438,    0,    0,    0, 3438,   94, 3438,
    0,    0,    0,    0, 3438,    0, -255,    0,
  };
  protected static readonly short [] yyRindex = {          148,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  -49,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  153,
    0,    0,    0,    0, -103,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,   -1,
  -29,  211, 1158,    0, 3047, 2168, 2044, 1805, 1658, 1389,
  922,    0,  599,    0,  449,    0,    0,    0,    0,    0,
    0,    0,    0,  -45,    0,  -37,    0,    0,  478,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  -96,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  -43,    0,    0,  -95,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0, 1929, 3129,    0,    0,
    0,    0, 2283, 2312, 2407, 2526, 2646, 2675, 2779, 2889,
 2139, 1900, 1776, 1418, 1536,  951, 1046, 1294,    0,    0,
    0,    0,    0,    0,    0,  570,    0,    0,    0,    0,
    0,    0,    0,    0,    0,   59,    0,    0,    0,    0,
    0,    0,    1,    0,    0,   75,    0,    0,    0, 3018,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  332,  714,    0,    0,
    0,    0,   61,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  151,    0,
  };
  protected static readonly short [] yyGindex = {            0,
    0,  133, -135,   27,    0,   76,   14,    0,    0,    0,
    0, -126,    0,   17,  -92,  -50,    0,    0,   -6,  -62,
    0,    0,  -57,    0,    0,    0,    0,    0,    0,   92,
   28,    0,    0,   78,  -19,    0,  -65,  -51,   37,    0,
   41,   50,   52,   53,  -13,  -28,   15,    0,   42,  168,
    0,    0,  -42,    0,    0,
  };
  protected static readonly short [] yyTable = {           229,
   22,  121,  143,   78,  148,   81,   61,  141,   83,   53,
  147,   76,  142,   57,   76,   58,  122,  119,  130,  219,
  131,   61,  242,  243,  217,  228,   43,  223,   76,   76,
   82,  226,  137,   22,  138,  135,   88,   90,  136,   74,
   22,   91,  119,   22,  100,   22,   92,   93,  103,   95,
   96,   97,  176,   87,   98,  179,   74,   74,    2,    3,
    4,    5,    6,    7,    8,  153,   43,  177,  178,  233,
   94,  152,  232,  237,   28,  241,  236,  101,  240,  132,
  120,   83,  150,  151,  162,  163,  164,  165,  166,  167,
  168,  169,  170,  171,  172,  173,  174,  175,  251,   41,
  149,   42,   41,  123,   42,  120,  133,   28,  196,  197,
  198,  134,  256,  144,   28,  139,  262,   28,  156,   28,
   26,  194,  195,  154,  155,  158,   22,  263,  207,  159,
  234,  264,  235,  266,  231,  238,  239,  243,  267,  254,
  204,  206,  258,  214,  260,  218,  221,    1,   83,  225,
   24,  265,    2,    9,  199,  200,  201,  202,  180,  181,
   11,   12,  247,  248,  183,  184,  185,  186,  187,  188,
  189,  190,   99,  227,  268,  246,  160,  257,  253,  157,
  161,  191,  224,   24,  192,  203,  193,   89,    0,  250,
   24,    0,    0,   24,    0,   24,    0,    0,    0,    0,
   28,    0,    0,    0,    0,    0,    0,   53,    0,    0,
    0,   57,  207,   58,    0,    0,    0,    0,    0,   61,
    0,    0,  230,  118,    0,  206,    0,   76,    0,  214,
    0,  255,    0,  221,  119,    0,    0,  119,    0,    2,
    3,    4,    5,    6,    7,    8,    0,  249,  124,    0,
    0,   91,    0,    0,   91,   74,    0,   22,  259,   22,
   43,   22,   22,   22,   22,   22,   22,   22,   91,   91,
   22,   91,    0,   22,   22,   22,   24,    0,   43,    0,
    0,    0,   22,    0,    0,   22,   22,    0,    0,    0,
    0,    0,    0,    0,   22,   22,  145,  120,  146,   22,
  120,   26,    0,   22,   22,  125,   22,  140,  126,  127,
   22,  128,   22,  129,   22,    0,    0,    0,    0,    0,
   22,    0,    0,   22,   22,    0,   22,   22,   22,   22,
    0,   28,   22,   28,   22,   28,   28,   28,   28,   28,
   28,   28,    0,    0,   28,    0,    0,   28,   28,   28,
    0,    0,    0,    0,    0,    0,   28,    0,    0,   28,
   28,    0,    0,    0,    0,    0,    0,    0,   28,   28,
    0,    0,   93,   28,    0,   93,    0,   28,   28,    0,
   28,    0,    0,    0,   28,    0,   28,    0,   28,   93,
   93,    0,   93,    0,   28,    0,    0,   28,   28,    0,
   28,   28,   28,   28,    0,    0,   28,   24,   28,   24,
    0,   24,   24,   24,   24,   24,   24,   24,    0,    0,
   24,    0,    0,   24,   24,   24,    0,    0,    0,    0,
    0,    0,   24,    0,    0,   24,   24,    0,    0,    0,
    0,    0,    0,    0,   24,   24,    0,    0,    0,   24,
    0,    0,    0,   24,   24,    0,   24,    0,    0,    0,
   24,    0,   24,    0,   24,    0,    0,   91,    0,    0,
   24,    0,    0,   24,   24,    0,   24,   24,   24,   24,
    0,    0,   24,    0,   24,  139,  139,    0,    0,  139,
  139,  139,  139,  139,    0,  139,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  139,  139,  139,  139,
  139,  139,    0,    0,  140,  140,    0,    0,  140,  140,
  140,  140,  140,    0,  140,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  140,  140,  140,  140,  140,
  140,    0,  139,   91,    0,   91,    0,   91,   91,    0,
   91,   91,    0,   91,   91,   91,    0,    0,   91,    0,
    0,    0,    0,    0,    0,    0,    0,   91,   91,    0,
   91,  140,  139,    0,  139,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,   93,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  140,    0,  140,    0,    0,  152,  152,    0,  152,
  152,  152,  152,  152,  152,  152,  152,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  152,
  152,  152,  152,    0,    0,  131,  131,    0,    0,  131,
  131,  131,  131,  131,    0,  131,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  131,  131,  131,  131,
  131,  131,    0,  152,   93,    0,   93,    0,   93,   93,
    0,   93,   93,    0,   93,   93,   93,    0,    0,   93,
    0,    0,    0,    0,    0,    0,    0,    0,   93,   93,
    0,   93,  131,  152,    0,  152,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  139,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  139,    0,    0,
    0,    0,  131,    0,  131,    0,    0,  139,    0,    0,
    0,    0,    0,  139,  140,    0,    0,    0,  139,    0,
    0,    0,  117,    0,  139,    0,  140,    0,    0,    0,
    0,    0,    0,    0,   92,    0,  140,   92,    0,    0,
    0,    0,  140,    0,    0,    0,    0,  140,    0,    0,
    0,   92,   92,  140,   92,    0,    0,    0,    0,    0,
    0,  139,    0,  139,    0,  139,  139,  139,  139,  139,
  139,  139,  139,  139,  139,  139,  139,  139,  139,  139,
    0,  139,    0,  139,  139,  139,  139,  139,  139,    0,
  140,    0,  140,    0,  140,  140,  140,  140,  140,  140,
  140,  140,  140,  140,  140,  140,  140,  140,  140,    0,
  140,    0,  140,  140,  140,  140,  140,  140,  152,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  152,  131,    0,    0,    0,  152,
    0,    0,    0,    0,    0,  152,    0,  131,    0,    0,
   38,    0,    0,    0,    0,    0,    0,  131,    0,    0,
    0,    0,    0,  131,    0,    0,    0,    0,  131,    0,
    0,    0,    0,   38,  131,    0,    0,    0,    0,    0,
    0,  152,  152,  152,  152,    0,  152,  152,  152,  152,
  152,  152,  152,  152,  152,  152,  152,  152,  152,  152,
  152,    0,  152,    0,  152,  152,  152,  152,  152,  152,
    0,  131,    0,  131,    0,  131,  131,    0,  131,  131,
  131,  131,  131,  131,  131,  131,  131,  131,  131,  131,
    0,  131,    0,  131,  131,  131,  131,  131,  131,  122,
    0,    0,  122,    0,  122,  122,  122,    0,    0,    0,
   92,    0,    0,    0,    0,    0,    0,    0,    0,  122,
  122,  122,  122,  122,  122,    0,    0,    0,  123,    0,
    0,  123,    0,  123,  123,  123,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  123,  123,
  123,  123,  123,  123,  104,  122,  105,    0,  106,  107,
    0,  108,  109,    0,  110,  111,  112,    0,    0,  113,
    0,    0,    0,    0,    0,    0,    0,    0,  114,  115,
    0,  116,    0,    0,  123,  122,   92,  122,   92,    0,
   92,   92,    0,   92,   92,    0,   92,   92,   92,    0,
    0,   92,    0,    0,    0,    0,    0,    0,    0,    0,
   92,   92,    0,   92,  123,    0,  123,    0,    0,    0,
    0,    0,    0,  124,    0,    0,  124,    0,  124,  124,
  124,    2,    3,    4,    5,    6,    7,    8,    0,    0,
    0,    0,    0,  124,  124,  124,  124,  124,  124,    0,
    0,    0,   13,    0,    2,    3,    4,    5,    6,    7,
    8,    0,    0,    0,   16,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   20,   13,    0,    0,    0,  124,
   22,    0,   23,    0,   24,    0,    0,   16,    0,    0,
    0,    0,    0,   26,   27,    0,   28,   29,   30,   31,
    0,    0,    0,   22,    0,   23,    0,   24,    0,  124,
    0,  124,    0,    0,    0,    0,   26,   27,  122,   28,
   29,   30,   31,    0,    0,    0,    0,    0,    0,    0,
  122,    0,    0,    0,    0,    0,    0,    0,   94,    0,
  122,   94,    0,    0,    0,    0,  122,  123,    0,    0,
    0,  122,    0,    0,    0,   94,   94,  122,   94,  123,
   94,    0,    0,    0,    0,    0,    0,    0,    0,  123,
    0,    0,    0,    0,    0,  123,    0,    0,    0,    0,
  123,    0,    0,    0,    0,    0,  123,    0,    0,    0,
    0,    0,    0,    0,  122,    0,  122,    0,  122,  122,
    0,  122,  122,    0,  122,  122,  122,  122,  122,  122,
  122,  122,  122,    0,  122,    0,  122,  122,  122,  122,
  122,  122,    0,  123,    0,  123,    0,  123,  123,    0,
  123,  123,    0,  123,  123,  123,  123,  123,  123,  123,
  123,  123,  124,  123,    0,  123,  123,  123,  123,  123,
  123,    0,    0,    0,  124,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  124,    0,    0,    0,    0,    0,
  124,  125,    0,    0,  125,  124,  125,  125,  125,    0,
    0,  124,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  125,  125,  125,  125,  125,  125,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  124,    0,
  124,    0,  124,  124,    0,  124,  124,  125,  124,  124,
  124,  124,  124,  124,  124,  124,  124,    0,  124,    0,
  124,  124,  124,  124,  124,  124,    0,    0,    0,    0,
    0,    0,    0,    0,   94,    0,    0,  125,    0,  125,
    0,    0,    0,    0,    0,    0,  119,    0,    0,  119,
    0,    0,  119,    0,    0,    0,   94,    0,    0,    0,
    0,    0,   94,    0,    0,    0,  119,  119,  119,  119,
  119,  119,    0,   94,    0,  120,    0,    0,  120,    0,
    0,  120,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  120,  120,  120,  120,  120,
  120,    0,  119,    0,    0,    0,    0,    0,    0,    0,
   94,    0,   94,    0,   94,   94,    0,   94,   94,    0,
   94,   94,   94,    0,    0,   94,    0,    0,    0,    0,
    0,  120,  119,    0,   94,   94,   94,   94,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  120,    0,    0,    0,    0,    0,    0,    0,    0,
  125,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  125,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  125,  121,    0,    0,  121,    0,  125,  121,
    0,    0,    0,  125,    0,    0,    0,    0,    0,  125,
    0,    0,    0,  121,  121,  121,  121,  121,  121,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  125,    0,  125,  121,
  125,  125,    0,  125,  125,    0,  125,  125,  125,  125,
  125,  125,  125,  125,  125,  119,  125,    0,  125,  125,
  125,  125,  125,  125,    0,    0,    0,  119,    0,  121,
    0,    0,    0,    0,    0,    0,    0,  119,    0,    0,
    0,    0,    0,  119,  120,    0,    0,    0,  119,    0,
    0,    0,    0,    0,  119,    0,  120,    0,    0,    0,
    0,    0,    0,    0,    0,  117,  120,    0,  117,    0,
    0,  117,  120,    0,    0,    0,    0,  120,    0,    0,
    0,    0,    0,  120,    0,  117,  117,  117,  117,  117,
  117,  119,    0,  119,    0,  119,  119,    0,  119,  119,
    0,  119,  119,  119,  119,  119,  119,  119,  119,  119,
    0,  119,    0,  119,  119,  119,  119,  119,  119,    0,
  120,  117,  120,    0,  120,  120,    0,  120,  120,    0,
  120,  120,  120,  120,  120,  120,  120,  120,  120,    0,
  120,    0,  120,  120,  120,  120,  120,  120,    0,    0,
    0,  117,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  121,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  121,    0,    0,    0,    0,    0,
    0,    0,    0,  118,  121,    0,  118,    0,    0,  118,
  121,    0,    0,    0,    0,  121,    0,    0,    0,    0,
    0,  121,    0,  118,  118,  118,  118,  118,  118,    0,
    0,    0,    0,    0,    0,  115,    0,    0,  115,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  115,  115,  115,  115,  115,  115,  121,  118,
  121,    0,  121,  121,    0,  121,  121,    0,  121,  121,
  121,  121,  121,  121,  121,  121,  121,    0,  121,    0,
  121,  121,  121,  121,  121,  121,    0,    0,  115,  118,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  117,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  117,    0,  115,    0,
    0,    0,    0,    0,    0,    0,  117,    0,    0,    0,
  116,    0,  117,  116,    0,    0,    0,  117,    0,    0,
    0,    0,    0,  117,    0,    0,    0,  116,  116,  116,
  116,  116,  116,    0,    0,    0,    0,    0,    0,   95,
    0,    0,   95,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,   95,   95,    0,   95,
  117,   95,  117,  116,  117,  117,    0,  117,  117,    0,
  117,  117,  117,    0,  117,  117,    0,  117,  117,    0,
  117,    0,  117,  117,  117,  117,  117,  117,    0,    0,
    0,    0,    0,  116,    0,    0,    0,    0,    0,    0,
    0,    0,  118,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  118,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  118,    0,    0,    0,    0,    0,
  118,  115,    0,    0,    0,  118,    0,    0,    0,    0,
    0,  118,    0,  115,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  115,  113,    0,    0,  113,    0,  115,
    0,    0,    0,    0,  115,    0,    0,    0,    0,    0,
  115,  113,  113,  113,  113,  113,  113,    0,  118,    0,
  118,    0,  118,  118,    0,  118,  118,    0,  118,  118,
  118,    0,  118,  118,    0,  118,  118,    0,  118,    0,
  118,  118,  118,  118,  118,  118,    0,  115,    0,  115,
    0,  115,  115,    0,  115,  115,    0,  115,  115,  115,
    0,  115,  115,    0,  115,  115,  116,  115,    0,  115,
  115,  115,  115,  115,  115,    0,    0,  113,  116,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  116,  114,
    0,    0,  114,    0,  116,   95,    0,    0,    0,  116,
    0,    0,    0,    0,    0,  116,  114,  114,  114,  114,
  114,  114,    0,    0,    0,    0,    0,   95,  103,    0,
    0,  103,    0,   95,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   95,  103,  103,  103,  103,  103,
  103,    0,  116,    0,  116,    0,  116,  116,    0,  116,
  116,    0,  116,  116,  116,    0,  116,  116,    0,  116,
  116,    0,  116,    0,  116,  116,  116,  116,  116,  116,
    0,   95,  114,   95,    0,   95,   95,    0,   95,   95,
    0,   95,   95,   95,    0,    0,   95,    0,    0,    0,
    0,    0,    0,    0,    0,   95,   95,   95,   95,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  113,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  113,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  113,  110,    0,    0,  110,    0,  113,    0,
    0,    0,    0,  113,    0,    0,    0,    0,    0,  113,
  110,  110,  110,  110,  110,  110,    0,    0,    0,    0,
    0,    0,  106,    0,    0,  106,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  106,
  106,  106,  106,  106,  106,    0,  113,    0,  113,    0,
  113,  113,    0,  113,  113,    0,  113,  113,  113,    0,
  113,  113,    0,  113,  113,  114,  113,    0,  113,  113,
  113,  113,  113,  113,    0,    0,    0,  114,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  114,    0,    0,
    0,    0,    0,  114,  103,    0,    0,    0,  114,    0,
    0,    0,    0,    0,  114,    0,  103,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  103,  107,    0,    0,
  107,    0,  103,    0,    0,    0,    0,  103,    0,    0,
    0,    0,    0,  103,  107,  107,  107,  107,  107,  107,
    0,  114,    0,  114,    0,  114,  114,    0,  114,  114,
    0,  114,  114,  114,    0,  114,  114,    0,  114,  114,
    0,  114,    0,  114,  114,  114,  114,  114,  114,    0,
  103,    0,  103,    0,  103,  103,    0,  103,  103,    0,
  103,  103,  103,    0,  103,  103,    0,  103,  103,    0,
  103,    0,  103,  103,  103,  103,  103,  103,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  110,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  110,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  110,    0,    0,    0,    0,  108,  110,  106,  108,
    0,    0,  110,    0,    0,    0,    0,    0,  110,    0,
  106,    0,    0,  108,  108,  108,  108,  108,  108,    0,
  106,    0,    0,    0,    0,    0,  106,    0,    0,    0,
    0,  106,    0,    0,    0,    0,    0,  106,    0,    0,
    0,    0,    0,    0,    0,  110,    0,  110,    0,  110,
  110,    0,  110,  110,    0,  110,  110,  110,    0,  110,
  110,    0,  110,  110,    0,  110,    0,  110,  110,  110,
  110,  110,  110,    0,  106,    0,  106,    0,  106,  106,
    0,  106,  106,    0,  106,  106,  106,    0,  106,  106,
    0,  106,  106,  107,  106,    0,  106,  106,  106,  106,
  106,  106,    0,    0,    0,  107,    0,    0,    0,    0,
    0,    0,    0,    0,    0,  107,  109,    0,    0,  109,
    0,  107,    0,    0,    0,    0,  107,    0,    0,    0,
    0,    0,  107,  109,  109,  109,  109,  109,  109,    0,
    0,    0,    0,    0,    0,  111,    0,    0,  111,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  111,  111,  111,  111,  111,  111,    0,  107,
    0,  107,    0,  107,  107,    0,  107,  107,    0,  107,
  107,  107,    0,  107,  107,    0,  107,  107,    0,  107,
    0,  107,  107,  107,  107,  107,  107,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  108,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  108,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  108,    0,    0,    0,    0,    0,
  108,    0,    0,    0,    0,  108,    0,    0,    0,  104,
    0,  108,  104,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,  104,  104,  104,  104,
  104,  104,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,  108,    0,
  108,    0,  108,  108,    0,  108,  108,    0,  108,  108,
  108,    0,  108,  108,    0,  108,  108,    0,  108,    0,
  108,  108,  108,  108,  108,  108,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,  109,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  109,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  109,    0,    0,    0,    0,  105,
  109,  111,  105,    0,    0,  109,    0,    0,    0,    0,
    0,  109,    0,  111,    0,    0,  105,  105,  105,  105,
  105,  105,    0,  111,    0,    0,    0,    0,    0,  111,
    0,    0,    0,    0,  111,    0,    0,    0,    0,    0,
  111,    0,    0,    0,    0,    0,    0,    0,  109,    0,
  109,    0,  109,  109,    0,  109,  109,    0,  109,  109,
  109,    0,  109,  109,    0,  109,  109,    0,  109,    0,
  109,  109,  109,  109,  109,  109,    0,  111,    0,  111,
    0,  111,  111,    0,  111,  111,    0,  111,  111,  111,
    0,  111,  111,    0,  111,  111,    0,  111,    0,  111,
  111,  111,  111,  111,  111,  104,    0,    0,    0,   34,
    0,    0,    0,    0,    0,    0,   38,  104,    0,   35,
    0,   36,    0,    0,    0,    0,    0,  104,  112,    0,
    0,  112,    0,  104,    0,    0,    0,    0,  104,    0,
    0,    0,    0,    0,  104,  112,  112,  112,  112,  112,
  112,    0,    0,    0,    0,    0,    0,  100,    0,    0,
  100,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,  100,  100,    0,  100,    0,  100,
    0,  104,    0,  104,    0,  104,  104,    0,  104,  104,
    0,  104,  104,  104,    0,  104,  104,    0,  104,  104,
    0,  104,   37,  104,  104,  104,  104,  104,  104,    0,
    0,    0,    0,    0,    0,  105,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  105,    0,    0,
    0,    0,    0,    0,    0,    0,    0,  105,    0,   96,
    0,    0,   96,  105,    0,    0,    0,    0,  105,    0,
    0,    0,    0,    0,  105,    0,   96,   96,    0,   96,
    0,   96,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  105,    0,  105,    0,  105,  105,    0,  105,  105,
    0,  105,  105,  105,    0,  105,  105,    0,  105,  105,
    0,  105,    0,  105,  105,  105,  105,  105,  105,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    1,    0,    0,    0,    2,    3,    4,
    5,    6,    7,    8,  112,    0,    9,    0,    0,   10,
   11,   12,    0,    0,    0,    0,  112,   34,   13,    0,
    0,   14,   15,    0,   38,    0,  112,   35,    0,   36,
   16,   17,  112,  100,    0,   18,    0,  112,    0,   19,
   20,    0,   21,  112,    0,  100,   22,    0,   23,    0,
   24,    0,    0,    0,    0,  100,   25,    0,    0,   26,
   27,  100,   28,   29,   30,   31,    0,    0,   32,    0,
   33,    0,  100,    0,    0,    0,    0,    0,    0,    0,
  112,    0,  112,    0,  112,  112,    0,  112,  112,    0,
  112,  112,  112,    0,  112,  112,    0,  112,  112,    0,
  112,    0,  112,  112,  112,  112,  112,  112,    0,  100,
   37,  100,    0,  100,  100,   96,  100,  100,   34,  100,
  100,  100,    0,    0,  100,   38,    0,    0,   35,    0,
   36,    0,  100,  100,  100,  100,  100,   96,    0,    0,
    0,    0,    0,   96,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   96,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   96,    0,   96,    0,   96,   96,    0,   96,   96,
   34,   96,   96,   96,    0,    0,   96,   38,    0,    0,
   35,   37,   36,    0,    0,   96,   96,   96,   96,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  261,    0,    2,    3,    4,    5,    6,
    7,    8,    0,    0,    9,    0,    0,   10,   11,   12,
    0,    0,    0,    0,    0,    0,   13,    0,    0,   14,
   15,    0,    0,    0,    0,    0,    0,    0,   16,   17,
    0,    0,    0,   18,    0,   34,    0,   19,   20,    0,
   21,    0,   38,   37,   22,   35,   23,   36,   24,    0,
    0,    0,    0,    0,   25,    0,    0,   26,   27,    0,
   28,   29,   30,   31,    0,    0,   32,    0,   33,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    2,    3,    4,    5,
    6,    7,    8,    0,    0,    9,    0,    0,   10,   11,
   12,    0,    0,    0,    0,   34,    0,   13,    0,    0,
   14,   15,   38,  205,    0,   35,    0,   36,   37,   16,
   17,    0,    0,    0,   18,    0,    0,    0,   19,   20,
    0,   21,    0,    0,    0,   22,    0,   23,    0,   24,
    0,    0,    0,    0,    0,   25,    0,    0,   26,   27,
    0,   28,   29,   30,   31,    0,    0,   32,    0,   33,
    0,    0,    0,    0,  211,    0,    0,    0,    2,    3,
    4,    5,    6,    7,    8,    0,    0,    9,    0,    0,
   34,   11,    0,    0,    0,    0,    0,   38,    0,   13,
   35,    0,   36,   15,    0,    0,    0,    0,   37,    0,
    0,   16,   17,    0,    0,    0,   18,    0,    0,    0,
   19,   20,    0,   21,    0,    0,    0,   22,    0,   23,
    0,   24,    0,   38,    0,    0,   35,    0,   36,    0,
   26,   27,    0,   28,   29,   30,   31,    0,    0,   32,
    0,   33,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    2,    3,    4,    5,    6,    7,    8,
    0,    0,    9,    0,    0,    0,   11,    0,    0,    0,
    0,    0,    0,   37,   13,    0,    0,   38,   15,    0,
   35,    0,   36,    0,    0,    0,   16,   17,    0,    0,
    0,   18,    0,    0,    0,   19,   20,    0,   21,    0,
    0,    0,   22,    0,   23,    0,   24,    0,    0,   37,
    0,    0,    0,    0,    0,   26,   27,    0,   28,   29,
   30,   31,    0,    0,   32,    0,   33,    0,    0,    0,
    0,    0,    0,    2,    3,    4,    5,    6,    7,    8,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,   13,    0,    0,    0,    0,    0,
    0,    0,    0,   37,    0,    0,   16,   17,    0,    0,
    0,    0,    0,    0,    0,    0,   20,    0,    0,    0,
    0,    0,   22,    0,   23,    0,   24,    0,    0,    0,
    0,    0,    0,    0,    0,   26,   27,    0,   28,   29,
   30,   31,    0,    0,   32,    0,   33,    0,    2,    3,
    4,    5,    6,    7,    8,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,   13,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   16,   17,    0,    2,    3,    4,    5,    6,    7,
    8,   20,    0,    0,    0,    0,    0,   22,    0,   23,
    0,   24,    0,    0,    0,   13,    0,    0,    0,    0,
   26,   27,    0,   28,   29,   30,   31,   16,  182,   32,
    0,   33,    0,    0,    0,    0,    0,   20,    0,    0,
    0,    0,    0,   22,    0,   23,    0,   24,    2,    3,
    4,    5,    6,    7,    8,    0,   26,   27,    0,   28,
   29,   30,   31,    0,    0,   32,    0,   33,    0,   13,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   16,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   20,    0,    0,    0,    0,    0,   22,    0,   23,
    0,   24,    0,    0,    0,    0,    0,    0,    0,    0,
   26,   27,    0,   28,   29,   30,   31,    0,    0,   32,
    0,   33,
  };
  protected static readonly short [] yyCheck = {            58,
    0,   63,   37,   10,   40,   12,   44,   42,   15,   59,
   46,   41,   47,   59,   44,   59,  269,  296,   60,   41,
   62,   59,  278,  279,  151,  279,    0,  154,   58,   59,
   14,  158,   43,   33,   45,  346,  286,   21,  349,   41,
   40,   25,  296,   43,  257,   45,   32,   33,   44,   35,
   36,   37,  118,   17,   38,  121,   58,   59,  261,  262,
  263,  264,  265,  266,  267,   40,   40,  119,  120,   41,
   34,   46,   44,   41,    0,   41,   44,   59,   44,  124,
  359,   88,   40,   58,  104,  105,  106,  107,  108,  109,
  110,  111,  112,  113,  114,  115,  116,  117,  234,   41,
   58,   41,   44,  356,   44,  359,   94,   33,  137,  138,
  139,   38,  239,  339,   40,  126,  252,   43,   46,   45,
  323,  135,  136,   58,   44,   58,  126,  254,  148,   41,
  258,  258,  257,  260,   58,   46,   58,  279,  265,   58,
  147,  148,   58,  150,   58,  152,  153,    0,  155,  156,
    0,   58,    0,  257,  140,  141,  142,  143,  122,  123,
  257,  257,  228,  229,  124,  125,  126,  127,  128,  129,
  130,  131,   40,  160,  267,  226,  101,  240,  236,   88,
  103,  132,  155,   33,  133,  144,  134,   20,   -1,  232,
   40,   -1,   -1,   43,   -1,   45,   -1,   -1,   -1,   -1,
  126,   -1,   -1,   -1,   -1,   -1,   -1,  257,   -1,   -1,
   -1,  257,  232,  257,   -1,   -1,   -1,   -1,   -1,  257,
   -1,   -1,  182,  285,   -1,  232,   -1,  257,   -1,  236,
   -1,  238,   -1,  240,  296,   -1,   -1,  296,   -1,  261,
  262,  263,  264,  265,  266,  267,   -1,  231,  290,   -1,
   -1,   41,   -1,   -1,   44,  257,   -1,  257,  242,  259,
  234,  261,  262,  263,  264,  265,  266,  267,   58,   59,
  270,   61,   -1,  273,  274,  275,  126,   -1,  252,   -1,
   -1,   -1,  282,   -1,   -1,  285,  286,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  294,  295,  332,  359,  334,  299,
  359,  323,   -1,  303,  304,  347,  306,  342,  350,  351,
  310,  353,  312,  355,  314,   -1,   -1,   -1,   -1,   -1,
  320,   -1,   -1,  323,  324,   -1,  326,  327,  328,  329,
   -1,  257,  332,  259,  334,  261,  262,  263,  264,  265,
  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,   -1,   -1,  282,   -1,   -1,  285,
  286,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,
   -1,   -1,   41,  299,   -1,   44,   -1,  303,  304,   -1,
  306,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,   58,
   59,   -1,   61,   -1,  320,   -1,   -1,  323,  324,   -1,
  326,  327,  328,  329,   -1,   -1,  332,  257,  334,  259,
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
   -1,   -1,   -1,  257,   -1,   -1,   -1,  261,  262,  263,
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
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  259,   -1,  261,  262,  263,  264,  265,
  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,  275,
   -1,   -1,   -1,   -1,   -1,   -1,  282,   -1,   -1,  285,
  286,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  294,  295,
   -1,   -1,   -1,  299,   -1,   33,   -1,  303,  304,   -1,
  306,   -1,   40,  126,  310,   43,  312,   45,  314,   -1,
   -1,   -1,   -1,   -1,  320,   -1,   -1,  323,  324,   -1,
  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  261,  262,  263,  264,
  265,  266,  267,   -1,   -1,  270,   -1,   -1,  273,  274,
  275,   -1,   -1,   -1,   -1,   33,   -1,  282,   -1,   -1,
  285,  286,   40,   41,   -1,   43,   -1,   45,  126,  294,
  295,   -1,   -1,   -1,  299,   -1,   -1,   -1,  303,  304,
   -1,  306,   -1,   -1,   -1,  310,   -1,  312,   -1,  314,
   -1,   -1,   -1,   -1,   -1,  320,   -1,   -1,  323,  324,
   -1,  326,  327,  328,  329,   -1,   -1,  332,   -1,  334,
   -1,   -1,   -1,   -1,  257,   -1,   -1,   -1,  261,  262,
  263,  264,  265,  266,  267,   -1,   -1,  270,   -1,   -1,
   33,  274,   -1,   -1,   -1,   -1,   -1,   40,   -1,  282,
   43,   -1,   45,  286,   -1,   -1,   -1,   -1,  126,   -1,
   -1,  294,  295,   -1,   -1,   -1,  299,   -1,   -1,   -1,
  303,  304,   -1,  306,   -1,   -1,   -1,  310,   -1,  312,
   -1,  314,   -1,   40,   -1,   -1,   43,   -1,   45,   -1,
  323,  324,   -1,  326,  327,  328,  329,   -1,   -1,  332,
   -1,  334,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  261,  262,  263,  264,  265,  266,  267,
   -1,   -1,  270,   -1,   -1,   -1,  274,   -1,   -1,   -1,
   -1,   -1,   -1,  126,  282,   -1,   -1,   40,  286,   -1,
   43,   -1,   45,   -1,   -1,   -1,  294,  295,   -1,   -1,
   -1,  299,   -1,   -1,   -1,  303,  304,   -1,  306,   -1,
   -1,   -1,  310,   -1,  312,   -1,  314,   -1,   -1,  126,
   -1,   -1,   -1,   -1,   -1,  323,  324,   -1,  326,  327,
  328,  329,   -1,   -1,  332,   -1,  334,   -1,   -1,   -1,
   -1,   -1,   -1,  261,  262,  263,  264,  265,  266,  267,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  282,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,  126,   -1,   -1,  294,  295,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,  304,   -1,   -1,   -1,
   -1,   -1,  310,   -1,  312,   -1,  314,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  323,  324,   -1,  326,  327,
  328,  329,   -1,   -1,  332,   -1,  334,   -1,  261,  262,
  263,  264,  265,  266,  267,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,  282,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  294,  295,   -1,  261,  262,  263,  264,  265,  266,
  267,  304,   -1,   -1,   -1,   -1,   -1,  310,   -1,  312,
   -1,  314,   -1,   -1,   -1,  282,   -1,   -1,   -1,   -1,
  323,  324,   -1,  326,  327,  328,  329,  294,  295,  332,
   -1,  334,   -1,   -1,   -1,   -1,   -1,  304,   -1,   -1,
   -1,   -1,   -1,  310,   -1,  312,   -1,  314,  261,  262,
  263,  264,  265,  266,  267,   -1,  323,  324,   -1,  326,
  327,  328,  329,   -1,   -1,  332,   -1,  334,   -1,  282,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  294,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  304,   -1,   -1,   -1,   -1,   -1,  310,   -1,  312,
   -1,  314,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
  323,  324,   -1,  326,  327,  328,  329,   -1,   -1,  332,
   -1,  334,
  };

#line 765 "FileParser.jay"
        }
#line default

    namespace yydebug
    {
        using System;

        internal interface yyDebug
        {
            void push(int state, Object value);
            void lex(int state, int token, string name, Object value);
            void shift(int from, int to, int errorFlag);
            void pop(int state);
            void discard(int state, int token, string name, Object value);
            void reduce(int from, int to, int rule, string text, int len);
            void shift(int from, int to);
            void accept(Object value);
            void error(string message);
            void reject();
        }

        class yyDebugSimple : yyDebug
        {
            void println(string s)
            {
                Console.Error.WriteLine(s);
            }

            public void push(int state, Object value)
            {
                println("push\tstate " + state + "\tvalue " + value);
            }

            public void lex(int state, int token, string name, Object value)
            {
                println("lex\tstate " + state + "\treading " + name + "\tvalue " + value);
            }

            public void shift(int from, int to, int errorFlag)
            {
                switch (errorFlag)
                {
                default:				// normally
                    println("shift\tfrom state " + from + " to " + to);
                    break;

                case 0:
                case 1:
                case 2:		// in error recovery
                    println("shift\tfrom state " + from + " to " + to + "\t" + errorFlag + " left to recover");
                    break;

                case 3:				// normally
                    println("shift\tfrom state "+from+" to "+to+"\ton error");
                    break;
                }
            }

            public void pop(int state)
            {
                println("pop\tstate " + state + "\ton error");
            }

            public void discard(int state, int token, string name, Object value)
            {
                println("discard\tstate " + state + "\ttoken " + name + "\tvalue " + value);
            }

            public void reduce(int from, int to, int rule, string text, int len)
            {
                println("reduce\tstate " + from + "\tuncover " + to + "\trule (" + rule + ") " + text);
            }

            public void shift(int from, int to)
            {
                println("goto\tfrom state " + from + " to " + to);
            }

            public void accept(Object value)
            {
                println("accept\tvalue " + value);
            }

            public void error(string message)
            {
                println("error\t" + message);
            }

            public void reject()
            {
                println("reject");
            }
        }
    }

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

    namespace yyParser
    {
        using System;

        /** thrown for irrecoverable syntax errors and stack overflow.
          */
        internal class yyException : System.Exception
        {
            public IToken Token { get; private set; }

            public yyException (string message, IToken token)
                : base (message)
            {
                this.Token = token;
            }
        }

        internal class yySyntaxError : yyException
        {
            public yySyntaxError (string message, IToken token)
                : base (message, token)
            {
            }
        }

        internal class yySyntaxErrorAtEof : yyException
        {
            public yySyntaxErrorAtEof (string message, IToken token)
                : base (message, token)
            {
            }
        }

        internal class yyUnexpectedEof : yyException
        {
            public yyUnexpectedEof (IToken token)
                : base (null, token)
            {
            }
        }

        /** must be implemented by a scanner object to supply input to the parser.
          */
        internal interface yyInput
         {
            /** move on to next token.
              * @return false if positioned beyond tokens.
              * @throws IOException on input error.
              */
            bool Advance(); // throws java.io.IOException;

            /** classifies current token.
              * Should not be called if advance() returned false.
              * @return current %token or single character.
              */
            IToken GetToken();

            /** associated with current token.
              * Should not be called if advance() returned false.
              * @return value for token().
              */
            Object GetValue ();
        }

        internal interface IToken
        {
            int TokenNumber { get; }
        }
    }
} // close outermost namespace, that MUST HAVE BEEN opened in the prolog
