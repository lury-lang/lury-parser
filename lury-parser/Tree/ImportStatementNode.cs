﻿//
// UnaryStatementNode.cs
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
    public class ImportStatementNode : StatementNode
    {
        #region -- Public Properties --

        public LToken PublicToken { get; private set; }

        public LToken StatementToken { get; private set; }

        public IEnumerable<Node> ImportedNode { get; private set; }

        #endregion

        #region -- Constructors --

        public ImportStatementNode(LToken publicToken, LToken statementToken, IEnumerable<Node> importedNode)
            : base(StatementNodeType.Import)
        {
            this.PublicToken = publicToken;
            this.StatementToken = statementToken;
            this.ImportedNode = importedNode;
        }

        public ImportStatementNode(LToken statementToken, IEnumerable<Node> importedNode)
            : this(null, statementToken, importedNode)
        {
        }

        #endregion

        #region -- Public Methods --

        public override IEnumerable<LToken> GetTokens()
        {
            yield return this.PublicToken;
            yield return this.StatementToken;
        }

        public override IEnumerable<Node> GetNodes()
        {
            return this.ImportedNode;
        }

        #endregion
    }
}
