using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer_JANA
{
    public class Analyzer
    {
        private char[] input { get; set; }
        private string output { get; set; }
        private string current { get; set; }
        private string delimiter { get; set; }
        private bool hasError { get; set; }
        private int column { get; set; }

        private string[] errorCodes = {"[No Errors]",
            "[LEXICAL ERROR] Improper use of reserved symbol \"{0}\"." };

        private string[] RW = { "get", "out", "clean", "tolower", "toupper", "exit", "main",
            "false", "stop", "true", "choice", "fall", "attempt", "handle", "do", "else", "elseif",
            "test", "then", "if", "iterate", "strlen", "until", "boolean", "char", "class", "int",
            "inherits", "new", "public", "private", "real", "return", "static", "string", "struct",
            "void" };

        private char[] separators = { ' ', '\n', ','};

        // Regular Expressions
        private string space = "\\s";
        private string paren = "(";
        private string hyphen = "\\-";
        private string semic = ";";
        private string newline = "\\n";
        private string zero = "0";
        private string und = "_";
        private string colon = ":";
        private string lowalpha = "[a-z]";
        private string upalpha = "[A-Z]";
        private string digit = "[1-9]";
        private string ASCII = ".";
        private string otherSY1 = "\\+";
        private string otherSY2 = "\\-|>";
        private string relop = "=|!";
        private string delRW_1 = ";|\\s";
        private string delRW_2 = ":|\\s|\\n";
        private string delRW_3 = "\\{|\\s|\\n";
        private string delRW_4 = "(|\\s";
        private string delSY_1 = "\\s|[1-9]";
        private string delSY_2 = "\\s|[A-Z]|[a-z]";
        private string delSY_3 = "\\s|[A-Z]|[a-z]|[1-9]";
        private string delSY_4 = "\\s|.";
        private string delSY_5 = ";|\\n";
        private string delSY_6 = "\\s|[A-Z]|[a-z]|[1-9]|.";
        private string delSY_7 = "\\s|[A-Z]|[a-z]|[1-9]|.|;|\\n";
        private string delSY_8 = "\\n|";
        private string delSY_9 = "\\s|.|;|\\n|";
        private string delSY_10 = "\\s|.|;";
        private string delSY_11 = ":|\\s|\\n||\"";
        private string delid = ";|\\s|=|\\[|";
        private string delit = ";|\\s|\\.";
        private string delch = ";|\\s|'";
        private string delstr = ";|\\s|\"";

        // Identifiers
        private string id = "^([a-z]|[A-Z])([a-z]|[A-Z]|[1-9]|[0]|_){0,9}";
        private string comment = "^(/\\*).*(\\*/)$";

        // Data Values
        private string intType = "^(~)*[1-9][0-9]{0,9}$";
        private string floatType = "^(~)*[1-9][0-9]{0,9}\\.[1-9][0-9]{0,4}$";
        private string charType = "'.'";
        private string stringType = "^\".* \"$";

        public string analyze(string statement)
        {
            bool isSpace = false;
            output = "[ID: 00] No errors.";
            input = statement.Trim().ToCharArray();
            current = "";

            foreach (var c in input)
            {
                if (c != ' ')
                {
                    current += c.ToString();
                    isSpace = false;
                }
                else
                {
                    if (!isSpace)
                    {
                        frmMain.Self.dGridResults.Rows.Add(current, current);
                        current = "";
                    }

                    isSpace = true;
                }
            }

            frmMain.Self.dGridResults.Rows.Add(current, current);
            current = "";

            return output;
        }
    }
}
