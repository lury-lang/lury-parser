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

using System;
using System.Collections.Generic;
using Lury.Compiling.Logger;
using Lury.Compiling.Parser.Tree;

using LToken = Lury.Compiling.Lexer.Token;

namespace Lury.Compiling.Parser
{
    public class Parser
    {
        #region -- Private Fields --

        private IEnumerable<Node> output;

        #endregion

        #region -- Public Properties --

        public IEnumerable<Node> TreeOutput
        {
            get
            {
                if (!this.IsFinished)
                    throw new InvalidOperationException("先に Parse メソッドを実行してください。");

                return this.output;
            }
        }

        public OutputLogger Logger { get; private set; }

        public bool IsFinished { get; private set; }

        #endregion

        #region -- Public Methods --

        public bool Parse(IEnumerable<LToken> input)
        {
            if (this.IsFinished)
                throw new InvalidOperationException("Parsing is already finished.");

            var parser = new FileParser();

            this.output = (IEnumerable<Node>)parser.yyparse(new Lex2yyInput(input));

            this.IsFinished = true;
            return true;
        }

        #endregion
    }
}
