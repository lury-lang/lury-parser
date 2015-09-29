//
// UnaryNode.cs
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

namespace Lury.Compiling.Parser.Tree
{
    public class UnaryNode : Node
    {
        #region -- Public Properties --

        public LToken OperatorToken { get; private set; }

        public Node Operand { get; private set; }

        public UnaryNodeType Type { get; private set; }

        #endregion

        #region -- Constructors --

        public UnaryNode(LToken operatorToken, Node operand, UnaryNodeType type)
        {
            this.OperatorToken = operatorToken;
            this.Operand = operand;
            this.Type = type;
        }

        #endregion

        #region -- Public Methods --

        public override IEnumerable<LToken> GetTokens()
        {
            yield return this.OperatorToken;
        }

        public override IEnumerable<Node> GetNodes()
        {
            yield return this.Operand;
        }

        #endregion
    }

    public enum UnaryNodeType
    {
        Unknown,
        SignNegative,
        SignPositive,
        BitwiseNot,
        LogicalNot,
        IncrementPostfix,
        DecrementPostfix,
        IncrementPrefix,
        DecrementPrefix,
        Ref,
        Out,
    }
}
