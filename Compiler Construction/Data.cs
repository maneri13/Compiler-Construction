using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    static class RegularExp
    {
        public static string Digits = "^[0-9]+$";
        public static string Signs = "[+-]";
        public static string Alphabet = @"^[a-zA-Z]+$";
        public static string AlphaNumeric = @"^[a-zA-Z0-9]+$";
        public static string Underscore = "[_]";
        public static string CharStart = "[']";
        public static string StringStart = "[\"]";
        public static string BackSlash = "[\\\\]";
        public static string EscSeq = "[nrtfbv]";
        public static string SpChar = "[\\\\\"\']";
        public static string At = "[@]";
        public static string Dot = "[.]";
    };
    static class Breakers
    {
        public static char[] breakers = { ' ','\t', '\n', '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', '$', ',', ';', ':', '(', ')',
        '{', '}', '[', ']', '.', '\'', '\"' };
    }
    static class ClassName
    {
        public static string[,] keywords = {
                               {"int","_datatype"},
                               {"float","_datatype"},
                               {"char", "_datatype"},
                               {"string", "_datatype"},
                               {"bool", "_datatype"},
                               {"if","_if"},
                               {"else","_else"},
                               {"break","_break"},
                               {"for","_for"},
                               {"while","_while"},
                               {"do","_do"},
                               {"foreach","_foreach"},
                               {"continue","_continue"},
                               {"goto","_goto"},
                               {"new","_new"},
                               {"namespace","_namespace"},
                               {"class","_class"},
                               {"this","_this"},
                               {"sealed","_sealed"},
                               {"abstract","_abstract"},
                               {"return","_return"},
                               {"void","_void"},
                               {"override","_virtual_override"},
                               {"virtual","_virtual_override"},
                               {"base","_base"},
                               {"static","_static"},
                               {"public","_accessmodifier"},
                               {"protected","_accessmodifier"},
                               {"private","_accessmodifier"},
                               {"true","_boolean"},
                               {"false","_boolean"},
                               {"null","_null"},
                               {"void", "_void"},
                               {"main", "_main"},
                               {"in", "_in"}
                           };


        public static string[,] Operators = {
                                                {"!","_not"},
                                                {"++","_inc_dec"},
                                                {"--","_inc_dec"},
                                                {"*","_multiply_devide_mode"},
                                                {"/","_multiply_devide_mode"},
                                                {"%","_multiply_devide_mode"},
                                                {"+","_plus_minus"},
                                                {"-","_plus_minus"},
                                                {">","_relational"},
                                                {"<","_relational"},
                                                {">=","_relational"},
                                                {"<=","_relational"},
                                                {"!=","_relational"},
                                                {"==","_relational"},
                                                {"&&","_and"},
                                                {"||","_or"},
                                                {"=","_assignment"},
                                                {"+=","_assignment"},
                                                {"*=","_assignment"},
                                                {"/=","_assignment"},
                                                {"%=","_assignment"},
                                                {"-=","_assignment"}                                                
                                            };
        public static string[,] punctuators = {
                                              { ",","_comma" },
                                              { ";","_terminator" },
                                              { ":","_colon" },                                           
                                              { "[","_bracket_square_open" },
                                              { "]","_bracket_square_close" },
                                              { "{","_bracket_curly_open" },
                                              { "}","_bracket_curly_close" },
                                              { "(","_bracket_parentheses_open" },
                                              { ")","_bracket_parentheses_close" },
                                              { ".","_dot" }
                                              };

        public enum nonKeywords {
            _identifier, _int_constant, _float_constant, _string_constant, _char_constant, _bool_constant, _invalid
        };

        public static string[] others =  {"_identifier", 
                                          "_int_constant",
                                          "_float_constant",
                                          "_string_constant",
                                          "_char_constant",
                                          "_bool_constant",
                                          "_invalid"
                                        };
    }
}
