//
// ConstantNode.cs
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

using System;
using System.Collections.Generic;
using Lury.Compiling.Utils;

using LToken = Lury.Compiling.Lexer.Token;

namespace Lury.Compiling.Parser.Tree
{
    public class ConstantNode : Node
    {
        #region -- Public Properties --

        public LToken Token { get; }

        public ConstantNodeType Type { get; }

        #endregion

        #region -- Constructors --

        public ConstantNode(LToken token, ConstantNodeType type)
        {
            this.Token = token;
            this.Type = type;
        }

        #endregion

        #region -- Public Methods --

        public string GetRegularizedTokenText()
        {
            switch (this.Type)
            {
                case ConstantNodeType.True:
                case ConstantNodeType.False:
                case ConstantNodeType.Nil:
                case ConstantNodeType.This:
                case ConstantNodeType.Super:
                case ConstantNodeType.Identifier:
                    return this.Token.Text;

                case ConstantNodeType.Integer:
                case ConstantNodeType.Floating:
                    return this.Token.Text.Replace("_", "");

                case ConstantNodeType.Imaginary:
                    return this.Token.Text.Replace("_", "").TrimEnd('i');

                case ConstantNodeType.String:
                    return this.Token.Text.ConvertFromEscapedString();

                default:
                    throw new InvalidOperationException("ノードタイプが不明です.");
            }
        }

        public override IEnumerable<LToken> GetTokens()
        {
            yield return this.Token;
        }

        public override IEnumerable<Node> GetNodes()
        {
            yield break;
        }

        #endregion
    }

    public enum ConstantNodeType
    {
        Unknown,
        Integer,
        Floating,
        Imaginary,
        True,
        False,
        String,
        Nil,
        This,
        Super,
        Identifier,
    }
}
