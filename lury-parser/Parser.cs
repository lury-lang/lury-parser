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
using System.Linq;
using Lury.Compiling.Logger;
using Lury.Compiling.Parser.Tree;
using Lury.Compiling.Utils;

using LToken = Lury.Compiling.Lexer.Token;

namespace Lury.Compiling.Parser
{
    /// <summary>
    /// 字句列を入力として構文構造を解析します。
    /// </summary>
    /// <remarks>
    /// <see cref="Parser"/> クラスは字句解析の結果である字句列を入力として、構文解析を行い、
    /// 字句列に対応する一意の構文木を生成します。字句列は <see cref="Lury.Compiling.Lexer.Token"/> オブジェクトを
    /// 列挙可能なオブジェクトとして入力します。出力となる構文木は <see cref="Node"/> オブジェクトの読み取り専用のリストとして、
    /// <see cref="Parser.TreeOutput"/> プロパティに格納されます。<see cref="Parser.TreeOutput"/> プロパティを呼び出す前に、
    /// <see cref="Parser.Parse"/> メソッドを実行する必要があります。
    /// 
    /// インタラクティブモードは、対話型アプリケーションで使用される場合に用いられます。
    /// このモードでは、1 回の入力で最大で 1 つの文構造を入力できます。
    /// </remarks>
    public class Parser
    {
        #region -- Private Fields --

        private readonly IEnumerable<LToken> input;
        private IReadOnlyList<Node> output;

        #endregion

        #region -- Public Properties --

        /// <summary>
        /// 構文解析の結果、出力された構文木 <see cref="Node"/> オブジェクトの読み取り専用のリストを取得します。
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// <see cref="Parser.Parse"/> メソッドが実行される前にプロパティにアクセスされました。
        /// </exception>
        public IReadOnlyList<Node> TreeOutput
        {
            get
            {
                if (!this.IsFinished)
                    throw new InvalidOperationException("Please execute method Parse before you access this property.");

                return this.output;
            }
        }

        /// <summary>
        /// 構文解析時に用いられたロガーを表す <see cref="OutputLogger"/> オブジェクトを取得します。
        /// </summary>
        public OutputLogger Logger { get; private set; }

        /// <summary>
        /// 構文解析が終了したかを表す真偽値を取得します。
        /// </summary>
        public bool IsFinished { get; private set; }

        /// <summary>
        /// 構文解析器がインタラクティブモードであるかを表す真偽値を取得します。
        /// </summary>
        public bool InteractiveMode { get; private set; }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// 解析される字句列を指定して新しい <see cref="Parser"/> クラスのインスタンスを初期化します。
        /// </summary>
        /// <param name="input">
        /// 構文解析される字句列を表す <see cref="Lury.Compiling.Lexer.Token"/> オブジェクトの列挙子。
        /// </param>
        /// <param name="interactiveMode">インタラクティブモードとして構文解析を行うかを表す真偽値。</param>
        /// <exception cref="ArgumentNullException">パラメータ input が null です。</exception>
        public Parser(IEnumerable<LToken> input, bool interactiveMode = false)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            this.input = input;
            this.InteractiveMode = interactiveMode;
            this.Logger = new OutputLogger();
        }

        #endregion

        #region -- Public Methods --

        /// <summary>
        /// 構文解析を行い、結果を <see cref="Parser.TreeOutput"/> に格納します。
        /// </summary>
        /// <returns>エラーが報告されず正常に解析が終了した時 true、それ以外のとき false。</returns>
        public bool Parse()
        {
            if (this.IsFinished)
                throw new InvalidOperationException("Parsing is already finished.");

            try
            {
                if (this.InteractiveMode)
                {
                    this.output = (IReadOnlyList<Node>)new InteractiveParser().yyparse(new Lex2yyInput(this.input, this.InteractiveMode));
                }
                else
                {
                    this.output = (IReadOnlyList<Node>)new FileParser().yyparse(new Lex2yyInput(this.input, this.InteractiveMode));
                }

                return true;
            }
            catch (yyException ex)
            {
                this.ReportException(ex);
                return false;
            }
            finally
            {
                this.IsFinished = true;
            }
        }

        #endregion

        #region -- Private Methods --

        private void ReportException(yyException ex)
        {
            if (ex is yySyntaxError)
            {
                LToken token = ((Token2yyToken)ex.Token).Token;

                this.Logger.ReportError(
                    ParserError.SyntaxError,
                    token.Text,
                    token.SourceCode,
                    token.CodePosition,
                    string.Join("\n", token.SourceCode.GeneratePointingStrings(token.CodePosition.CharPosition, token.Length)));
            }
            else if (ex is yyUnexpectedEof)
            {
                var lastToken = this.input.Last();
                this.Logger.ReportError(
                    ParserError.UnexpectedEOF,
                    null,
                    lastToken.SourceCode,
                    lastToken.CodePosition,
                    string.Join("\n", lastToken.SourceCode.GeneratePointingStrings(lastToken.CodePosition.CharPosition, 0)));
            }

            // WIP
        }

        #endregion
    }
}
