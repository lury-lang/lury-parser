//
// TernaryNode.cs
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
    public class TernaryNode : Node
    {
        #region -- Public Properties --

        public LToken OperatorTokenX { get; private set; }

        public LToken OperatorTokenY { get; private set; }

        public Node OperandX { get; private set; }

        public Node OperandY { get; private set; }

        public Node OperandZ { get; private set; }

        public TernaryNodeType Type { get; private set; }

        #endregion

        #region -- Constructors --

        public TernaryNode(
            LToken operatorTokenX,
            LToken operatorTokenY,
            Node operandX,
            Node operandY,
            Node operandZ,
            TernaryNodeType type)
        {
            this.OperatorTokenX = operatorTokenX;
            this.OperatorTokenY = operatorTokenY;
            this.OperandX = operandX;
            this.OperandY = operandY;
            this.OperandZ = operandZ;
            this.Type = type;
        }

        #endregion

        #region -- Public Methods --

        public override IEnumerable<LToken> GetTokens()
        {
            yield return this.OperatorTokenX;
            yield return this.OperatorTokenY;
        }

        public override IEnumerable<Node> GetNodes()
        {
            yield return this.OperandX;
            yield return this.OperandY;
            yield return this.OperandZ;
        }

        #endregion
    }

    public enum TernaryNodeType
    {
        Unknown,
        Condition,
    }
}
