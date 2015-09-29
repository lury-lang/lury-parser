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
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

using LToken = Lury.Compiling.Lexer.Token;

namespace Lury.Compiling.Parser.Tree
{
    public class ConstantNode : Node
    {
        #region -- Public Properties --

        public LToken Token { get; private set; }

        public ConstantNodeType Type { get; private set; }

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
                    return StringHelper.ConvertToInternalString(this.Token.Text);

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

    static class StringHelper
    {
        #region -- Private Static Fields --

        private static readonly Regex unicode_hex = new Regex(@"\\x[0-9A-Fa-f]{1,4}", RegexOptions.Compiled);
        private static readonly Regex unicode_hex4 = new Regex(@"\\u[0-9A-Fa-f]{4}", RegexOptions.Compiled);
        private static readonly Regex unicode_hex8 = new Regex(@"\\U[0-9A-Fa-f]{8}", RegexOptions.Compiled);

        #endregion

        #region -- Public Methods --

        public static string ConvertToInternalString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value");

            if (value.Length < 2)
                throw new ArgumentException("value");

            char marker = value[0];

            ReplaceUnicodeChar(ref value);

            var sb = new StringBuilder(value);
            TrimMarker(sb, marker);
            ReplaceEscapeChar(sb);

            return sb.ToString();
        }

        #endregion

        #region -- Private Methods --

        private static void TrimMarker(StringBuilder value, char marker)
        {
            if (value[0] != marker || value[value.Length - 1] != marker)
                throw new ArgumentException("value");

            value.Remove(0, 1);
            value.Remove(value.Length - 1, 1);
        }

        private static void ReplaceEscapeChar(StringBuilder value)
        {
            value.Replace(@"\\", "\\");
            value.Replace(@"\'", "'");
            value.Replace(@"\""", "\"");
            value.Replace(@"\a", "\a");
            value.Replace(@"\b", "\b");
            value.Replace(@"\f", "\f");
            value.Replace(@"\n", "\n");
            value.Replace(@"\r", "\r");
            value.Replace(@"\t", "\t");
            value.Replace(@"\v", "\v");
        }

        private static void ReplaceUnicodeChar(ref string value)
        {
            // Refer to:
            // http://stackoverflow.com/questions/183907

            // type \xX - \xXXXX
            value = unicode_hex.Replace(value, m => ((char)Int16.Parse(m.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            // type: \uXXXX
            value = unicode_hex4.Replace(value, m => ((char)Int32.Parse(m.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            // type: \UXXXXXXXX
            value = unicode_hex8.Replace(value, m => ToUTF16(m.Value.Substring(2)));
        }

        private static string ToUTF16(string hex)
        {
            int value = int.Parse(hex, NumberStyles.HexNumber);

            if (value < 0 || value > 0x10ffff)
                throw new ArgumentException("hex");

            if (value <= 0x00ff)
                return ((char)value).ToString();
            else
            {
                int w = value - 0x10000;
                char high = (char)(0xd800 | (w >> 10) & 0x03ff);
                char low = (char)(0xdc00 | (w >> 0) & 0x03ff);
                return new string(new char[2] { high, low });
            }
        }

        #endregion
    }
}
