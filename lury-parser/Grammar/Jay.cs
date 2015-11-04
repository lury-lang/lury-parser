// created by jay 0.7 (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de

using System;

namespace Lury.Compiling.Parser
{
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

    internal class yyDebugSimple : yyDebug
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

    /** thrown for irrecoverable syntax errors and stack overflow.
      */
    internal class yyException : System.Exception
    {
        public IToken Token { get; private set; }

        public yyException(string message, IToken token)
            : base (message)
        {
            this.Token = token;
        }
    }

    internal class yySyntaxError : yyException
    {
        public yySyntaxError(string message, IToken token)
            : base (message, token)
        {
        }
    }

    internal class yySyntaxErrorAtEof : yyException
    {
        public yySyntaxErrorAtEof(string message, IToken token)
            : base (message, token)
        {
        }
    }

    internal class yyUnexpectedEof : yyException
    {
        public yyUnexpectedEof(IToken token)
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
        Object GetValue();
    }

    internal interface IToken
    {
        int TokenNumber { get; }
    }
}
