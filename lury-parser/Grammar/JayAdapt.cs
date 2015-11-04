//
// JayAdapt.cs
//
// Author:
//       Tomona Nanase <nanase@users.noreply.github.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2015 Tomona Nanase
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

using System.Collections.Generic;

using LToken = Lury.Compiling.Lexer.Token;
using PFToken = Lury.Compiling.Parser.FileParser.Token;
using PIToken = Lury.Compiling.Parser.InteractiveParser.Token;

namespace Lury.Compiling.Parser
{
    internal class Lex2yyInput : yyInput
    {
        private readonly IEnumerator<LToken> tokenEnumerator;
        private readonly bool interactiveMode;

        public Lex2yyInput(IEnumerable<LToken> token, bool interactiveMode)
        {
            this.tokenEnumerator = token.GetEnumerator();
            this.interactiveMode = interactiveMode;
        }

        public bool Advance()
        {
            return this.tokenEnumerator.MoveNext();
        }

        public IToken GetToken()
        {
            return this.interactiveMode ?
                (IToken)new Token2InteractiveToken(this.tokenEnumerator.Current) :
                (IToken)new Token2FileToken(this.tokenEnumerator.Current);
        }

        public object GetValue()
        {
            return this.tokenEnumerator.Current;
        }
    }

    internal abstract class Token2yyToken : IToken
    {
        public LToken Token { get; private set; }

        public Token2yyToken(LToken token)
        {
            this.Token = token;
        }

        public int TokenNumber
        {
            get
            {
                if (this.Token.Entry.Name.Length == 1)
                    return (int)this.Token.Entry.Name[0];

                return this.TokenMap[this.Token.Entry.Name];
            }
        }

        protected abstract Dictionary<string, int> TokenMap { get; }
    }

    internal class Token2FileToken : Token2yyToken
    {
        public Token2FileToken(LToken token)
            : base(token)
        {
        }

        protected override Dictionary<string, int> TokenMap { get { return tokenMap; } }

        #region -- Private Static Fields --

        private static readonly Dictionary<string, int> tokenMap = new Dictionary<string, int>()
            {
                { "NewLine", PFToken.NewLine },
                { "Indent", PFToken.Indent },
                { "Dedent", PFToken.Dedent },
                { "EndOfFile", PFToken.NewLine },  // EndOfFile -> NewLine
                { "IdentifierGet", PFToken.IdentifierGet },
                { "IdentifierSet", PFToken.IdentifierSet },
                { "IdentifierFile", PFToken.IdentifierFile },
                { "IdentifierLine", PFToken.IdentifierLine },
                { "IdentifierExit", PFToken.IdentifierExit },
                { "IdentifierSuccess", PFToken.IdentifierSuccess },
                { "IdentifierFailure", PFToken.IdentifierFailure },
                { "KeywordAbstract", PFToken.KeywordAbstract },
                { "KeywordAnd", PFToken.KeywordAnd },
                { "KeywordBreak", PFToken.KeywordBreak },
                { "KeywordCase", PFToken.KeywordCase },
                { "KeywordCatch", PFToken.KeywordCatch },
                { "KeywordClass", PFToken.KeywordClass },
                { "KeywordContinue", PFToken.KeywordContinue },
                { "KeywordDef", PFToken.KeywordDef },
                { "KeywordDefault", PFToken.KeywordDefault },
                { "KeywordDelete", PFToken.KeywordDelete },
                { "KeywordElif", PFToken.KeywordElif },
                { "KeywordElse", PFToken.KeywordElse },
                { "KeywordEnum", PFToken.KeywordEnum },
                { "KeywordExtended", PFToken.KeywordExtended },
                { "KeywordFalse", PFToken.KeywordFalse },
                { "KeywordFinally", PFToken.KeywordFinally },
                { "KeywordFor", PFToken.KeywordFor },
                { "KeywordIf", PFToken.KeywordIf },
                { "KeywordImport", PFToken.KeywordImport },
                { "KeywordIn", PFToken.KeywordIn },
                { "KeywordInterface", PFToken.KeywordInterface },
                { "KeywordInvariant", PFToken.KeywordInvariant },
                { "KeywordIs", PFToken.KeywordIs },
                { "KeywordLazy", PFToken.KeywordLazy },
                { "KeywordNameof", PFToken.KeywordNameof },
                { "KeywordNew", PFToken.KeywordNew },
                { "KeywordNil", PFToken.KeywordNil },
                { "KeywordNot", PFToken.KeywordNot },
                { "KeywordOr", PFToken.KeywordOr },
                { "KeywordOut", PFToken.KeywordOut },
                { "KeywordOverride", PFToken.KeywordOverride },
                { "KeywordPass", PFToken.KeywordPass },
                { "KeywordPrivate", PFToken.KeywordPrivate },
                { "KeywordProperty", PFToken.KeywordProperty },
                { "KeywordProtected", PFToken.KeywordProtected },
                { "KeywordPublic", PFToken.KeywordPublic },
                { "KeywordRef", PFToken.KeywordRef },
                { "KeywordReflect", PFToken.KeywordReflect },
                { "KeywordReturn", PFToken.KeywordReturn },
                { "KeywordScope", PFToken.KeywordScope },
                { "KeywordSealed", PFToken.KeywordSealed },
                { "KeywordStatic", PFToken.KeywordStatic },
                { "KeywordSuper", PFToken.KeywordSuper },
                { "KeywordSwitch", PFToken.KeywordSwitch },
                { "KeywordThis", PFToken.KeywordThis },
                { "KeywordThrow", PFToken.KeywordThrow },
                { "KeywordTrue", PFToken.KeywordTrue },
                { "KeywordTry", PFToken.KeywordTry },
                { "KeywordUnittest", PFToken.KeywordUnittest },
                { "KeywordUnless", PFToken.KeywordUnless },
                { "KeywordUntil", PFToken.KeywordUntil },
                { "KeywordVar", PFToken.KeywordVar },
                { "KeywordWhile", PFToken.KeywordWhile },
                { "KeywordWith", PFToken.KeywordWith },
                { "KeywordYield", PFToken.KeywordYield },
                { "Identifier", PFToken.Identifier },
                { "StringLiteral", PFToken.StringLiteral },
                { "EmbedStringLiteral", PFToken.EmbedStringLiteral },
                { "WysiwygStringLiteral", PFToken.WysiwygStringLiteral },
                { "ImaginaryNumber", PFToken.ImaginaryNumber },
                { "FloatNumber", PFToken.FloatNumber },
                { "Integer", PFToken.Integer },
                { "RangeOpen", PFToken.RangeOpen },
                { "RangeClose", PFToken.RangeClose },
                { "Increment", PFToken.Increment },
                { "AssignmentAdd", PFToken.AssignmentAdd },
                { "Decrement", PFToken.Decrement },
                { "AssignmentSub", PFToken.AssignmentSub },
                { "AnnotationReturn", PFToken.AnnotationReturn },
                { "AssignmentConcat", PFToken.AssignmentConcat },
                { "AssignmentPower", PFToken.AssignmentPower },
                { "Power", PFToken.Power },
                { "AssignmentMultiply", PFToken.AssignmentMultiply },
                { "AssignmentIntDivide", PFToken.AssignmentIntDivide },
                { "IntDivide", PFToken.IntDivide },
                { "AssignmentDivide", PFToken.AssignmentDivide },
                { "AssignmentModulo", PFToken.AssignmentModulo },
                { "AssignmentLeftShift", PFToken.AssignmentLeftShift },
                { "LeftShift", PFToken.LeftShift },
                { "LessThan", PFToken.LessThan },
                { "AssignmentRightShift", PFToken.AssignmentRightShift },
                { "RightShift", PFToken.RightShift },
                { "MoreThan", PFToken.MoreThan },
                { "Equal", PFToken.Equal },
                { "Lambda", PFToken.Lambda },
                { "NotEqual", PFToken.NotEqual },
                { "NotIn", PFToken.NotIn },
                { "IsNot", PFToken.IsNot },
                { "AndShort", PFToken.AndShort },
                { "AssignmentAnd", PFToken.AssignmentAnd },
                { "AssignmentXor", PFToken.AssignmentXor },
                { "OrShort", PFToken.OrShort },
                { "AssignmentOr", PFToken.AssignmentOr },
                { "NilCoalesce", PFToken.NilCoalesce },
            };

        #endregion
    }

    internal class Token2InteractiveToken : Token2yyToken
    {
        public Token2InteractiveToken(LToken token)
            : base(token)
        {
        }

        protected override Dictionary<string, int> TokenMap { get { return tokenMap; } }

        #region -- Private Static Fields --

        private static readonly Dictionary<string, int> tokenMap = new Dictionary<string, int>()
            {
                { "NewLine", PIToken.NewLine },
                { "Indent", PIToken.Indent },
                { "Dedent", PIToken.Dedent },
                { "EndOfFile", PIToken.NewLine },  // EndOfFile -> NewLine
                { "IdentifierGet", PIToken.IdentifierGet },
                { "IdentifierSet", PIToken.IdentifierSet },
                { "IdentifierFile", PIToken.IdentifierFile },
                { "IdentifierLine", PIToken.IdentifierLine },
                { "IdentifierExit", PIToken.IdentifierExit },
                { "IdentifierSuccess", PIToken.IdentifierSuccess },
                { "IdentifierFailure", PIToken.IdentifierFailure },
                { "KeywordAbstract", PIToken.KeywordAbstract },
                { "KeywordAnd", PIToken.KeywordAnd },
                { "KeywordBreak", PIToken.KeywordBreak },
                { "KeywordCase", PIToken.KeywordCase },
                { "KeywordCatch", PIToken.KeywordCatch },
                { "KeywordClass", PIToken.KeywordClass },
                { "KeywordContinue", PIToken.KeywordContinue },
                { "KeywordDef", PIToken.KeywordDef },
                { "KeywordDefault", PIToken.KeywordDefault },
                { "KeywordDelete", PIToken.KeywordDelete },
                { "KeywordElif", PIToken.KeywordElif },
                { "KeywordElse", PIToken.KeywordElse },
                { "KeywordEnum", PIToken.KeywordEnum },
                { "KeywordExtended", PIToken.KeywordExtended },
                { "KeywordFalse", PIToken.KeywordFalse },
                { "KeywordFinally", PIToken.KeywordFinally },
                { "KeywordFor", PIToken.KeywordFor },
                { "KeywordIf", PIToken.KeywordIf },
                { "KeywordImport", PIToken.KeywordImport },
                { "KeywordIn", PIToken.KeywordIn },
                { "KeywordInterface", PIToken.KeywordInterface },
                { "KeywordInvariant", PIToken.KeywordInvariant },
                { "KeywordIs", PIToken.KeywordIs },
                { "KeywordLazy", PIToken.KeywordLazy },
                { "KeywordNameof", PIToken.KeywordNameof },
                { "KeywordNew", PIToken.KeywordNew },
                { "KeywordNil", PIToken.KeywordNil },
                { "KeywordNot", PIToken.KeywordNot },
                { "KeywordOr", PIToken.KeywordOr },
                { "KeywordOut", PIToken.KeywordOut },
                { "KeywordOverride", PIToken.KeywordOverride },
                { "KeywordPass", PIToken.KeywordPass },
                { "KeywordPrivate", PIToken.KeywordPrivate },
                { "KeywordProperty", PIToken.KeywordProperty },
                { "KeywordProtected", PIToken.KeywordProtected },
                { "KeywordPublic", PIToken.KeywordPublic },
                { "KeywordRef", PIToken.KeywordRef },
                { "KeywordReflect", PIToken.KeywordReflect },
                { "KeywordReturn", PIToken.KeywordReturn },
                { "KeywordScope", PIToken.KeywordScope },
                { "KeywordSealed", PIToken.KeywordSealed },
                { "KeywordStatic", PIToken.KeywordStatic },
                { "KeywordSuper", PIToken.KeywordSuper },
                { "KeywordSwitch", PIToken.KeywordSwitch },
                { "KeywordThis", PIToken.KeywordThis },
                { "KeywordThrow", PIToken.KeywordThrow },
                { "KeywordTrue", PIToken.KeywordTrue },
                { "KeywordTry", PIToken.KeywordTry },
                { "KeywordUnittest", PIToken.KeywordUnittest },
                { "KeywordUnless", PIToken.KeywordUnless },
                { "KeywordUntil", PIToken.KeywordUntil },
                { "KeywordVar", PIToken.KeywordVar },
                { "KeywordWhile", PIToken.KeywordWhile },
                { "KeywordWith", PIToken.KeywordWith },
                { "KeywordYield", PIToken.KeywordYield },
                { "Identifier", PIToken.Identifier },
                { "StringLiteral", PIToken.StringLiteral },
                { "EmbedStringLiteral", PIToken.EmbedStringLiteral },
                { "WysiwygStringLiteral", PIToken.WysiwygStringLiteral },
                { "ImaginaryNumber", PIToken.ImaginaryNumber },
                { "FloatNumber", PIToken.FloatNumber },
                { "Integer", PIToken.Integer },
                { "RangeOpen", PIToken.RangeOpen },
                { "RangeClose", PIToken.RangeClose },
                { "Increment", PIToken.Increment },
                { "AssignmentAdd", PIToken.AssignmentAdd },
                { "Decrement", PIToken.Decrement },
                { "AssignmentSub", PIToken.AssignmentSub },
                { "AnnotationReturn", PIToken.AnnotationReturn },
                { "AssignmentConcat", PIToken.AssignmentConcat },
                { "AssignmentPower", PIToken.AssignmentPower },
                { "Power", PIToken.Power },
                { "AssignmentMultiply", PIToken.AssignmentMultiply },
                { "AssignmentIntDivide", PIToken.AssignmentIntDivide },
                { "IntDivide", PIToken.IntDivide },
                { "AssignmentDivide", PIToken.AssignmentDivide },
                { "AssignmentModulo", PIToken.AssignmentModulo },
                { "AssignmentLeftShift", PIToken.AssignmentLeftShift },
                { "LeftShift", PIToken.LeftShift },
                { "LessThan", PIToken.LessThan },
                { "AssignmentRightShift", PIToken.AssignmentRightShift },
                { "RightShift", PIToken.RightShift },
                { "MoreThan", PIToken.MoreThan },
                { "Equal", PIToken.Equal },
                { "Lambda", PIToken.Lambda },
                { "NotEqual", PIToken.NotEqual },
                { "NotIn", PIToken.NotIn },
                { "IsNot", PIToken.IsNot },
                { "AndShort", PIToken.AndShort },
                { "AssignmentAnd", PIToken.AssignmentAnd },
                { "AssignmentXor", PIToken.AssignmentXor },
                { "OrShort", PIToken.OrShort },
                { "AssignmentOr", PIToken.AssignmentOr },
                { "NilCoalesce", PIToken.NilCoalesce },
            };

        #endregion
    }
}
