﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Construction
{
    class SyntaxAnalyzer
    {
        private bool errorFlag = false;
        List<token> Tokens;
        public int tokenIndex;
        public TreeNode currentNode;
        public bool syntaxAnlysis(List<token> tokens)
        {
            currentNode = Program.compiler.CFG.Nodes.Add("<S>");
            Tokens = tokens;
            tokenIndex = 0;
            try
            {
                if (Namespace_Dec())
                {
                    if (S())
                    {
                        return true;
                    }

                }
            }
            catch
            {
                if (Tokens.Count > 0)
                {
                    Program.compiler.error_classPart.Text = Tokens[tokenIndex].classString;
                    Program.compiler.error_valuePart.Text = Tokens[tokenIndex].wordString;
                    Program.compiler.error_lineNo.Text = Tokens[tokenIndex].lineNumber.ToString();
                    Program.compiler.syntaxErrorBox.Visible = true;
                }

                return false;
            }
            if (Tokens.Count > 0)
            {
                currentNode.Nodes.Add("ERROR");
                Program.compiler.error_classPart.Text = Tokens[tokenIndex].classString;
                Program.compiler.error_valuePart.Text = Tokens[tokenIndex].wordString;
                Program.compiler.error_lineNo.Text = Tokens[tokenIndex].lineNumber.ToString();
                Program.compiler.syntaxErrorBox.Visible = true;
            }
            return false;
        }

        // Extra Function
        private bool cp(string classpart)
        {
            if (Tokens[tokenIndex].classString == classpart)
            {

                tokenIndex++;
                currentNode.Nodes.Add("(" + classpart + ")", "( " + classpart + " )");
                return true;
            }
            else return false;
        }

        private bool cp2(string classpart)
        {
            if (Tokens[tokenIndex].classString == classpart)
            {
                return true;
            }
            else return false;
        }

        private bool S()
        {

            if (cp2("_end_marker"))
            {
                Program.compiler.CFG.Nodes.Add("( " + "_end_marker" + " )");
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }


        /*------------------------------------ GENERAL RULES --------------------------*/
        private bool Const()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Const> -> Int_Const | Float_Const | String_Const | Char_Const | Bool_Const 
            switch (Tokens[tokenIndex].classString)
            {
                case "_int_constant":
                case "_float_constant":
                case "_string_constant":
                case "_char_constant":
                case "_boolean":
                    tokenIndex++;
                    currentNode = currentNode.Parent;
                    currentNode = currentNode.Parent; return true;

                default:
                    return false;

            }
        }

        private bool Id_Constant()
        {

            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Id_Constant> -> Id|<Const>
            if (cp("_identifier"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Const())
            {
                currentNode = currentNode.Parent; return true;
            }

            else return false;
        }

        private bool Array_Init()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_Init> -> [] | Null
            // Follow Set
            if (cp2("_identifier") || cp2("_bracket_parentheses_open"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_bracket_square_open"))
            {
                if (cp("_bracket_square_close"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }


            else return false;


        }

        private bool Array_Index()
        {
            currentNode = currentNode.Nodes.Add("< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_Index> -> [<Id_Constant>] | Null
            // Follow Set
            if (cp2("_assignment"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_bracket_square_open"))
            {
                if (exp())
                {
                    if (cp("_bracket_square_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool Access_Modifier()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Access_Modifier> -> _access_modifier|Null
            // Follow Set
            if (cp2("_static") || cp2("_shared") || cp2("_const") || cp2("_void") || cp2("_identifier") || cp2("_class"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_accessmodifier"))
            {

                currentNode = currentNode.Parent; return true;
            }

            else return false;
        }

        private bool List_Param()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<List_Param> -> <DT_Id><Array_Init> Id<List_Param_B>|Null

            // Follow Set
            if (cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (DT_Id())
            {
                if (Array_Init())
                {
                    if (cp("_identifier"))
                    {
                        if (List_Param_B())
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool List_Param_B()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<List_Param_B> -> Null |, <DT_Id> <Array_Init> Id<List_Param>

            // Follow Set
            if (cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }

            else if (cp("_comma"))
            {
                if (DT_Id())
                {
                    if (Array_Init())
                    {
                        if (cp("_identifier"))
                        {
                            if (List_Param_B())
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else return false;
        }

        private bool DT_Id()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<DT_Id> -> DT|Id
            if (cp("_datatype"))
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_identifier"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool Static_Shared()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Static_Shared> -> _static | _shared
            if (cp("_static"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_shared"))
            {

                currentNode = currentNode.Parent; return true;
            }
            else
                return false;
        }

        private bool Static_Shared_Constant()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Static_Shared _Constant> -> <Static_Shared> | const
            if (Static_Shared())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Const())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool Return_Type()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Return_Type> -> <DT_Id>| void
            if (DT_Id())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_void"))
            {

                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool List_Const()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <List_Const>-><exp><List_Const_B> | Null
            // Follow Set
            if (cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (exp())
            {
                if (List_Const_B())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return false;

        }

        private bool List_Const_B()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <List_Const_B>->,< exp><List_Const>|Null
            // Follow Set
            if (cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_comma"))
            {
                if (exp())
                {
                    if (List_Const_B())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool Asgn()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_identifier"))
            {
                if (Array_Index())
                {
                    if (cp("_assignment"))
                    {
                        if (exp())
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool Asgn2()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");

            if (Array_Index())
            {
                if (cp("_assignment"))
                {
                    if (exp())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;

        }

        private bool S_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <S_St> -> Id<Id_S_St> | DT<DT_S_St> | <While_St> | <For_St> | <Do_While_St> 
            // | <Foreach_St> | <If_Else> | <Return> | <GoTo> | inc_dec id | const DT <Variable_Link>
            if (cp("_identifier"))
            {
                if (Id_S_St())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_datatype"))
            {
                if (DT_S_St())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (While_St())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (For_St())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Do_While_St())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Foreach_St())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (If_Else())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Return())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (GoTo())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_inc_dec"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_terminator"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (cp("_const"))
            {
                if (cp("_datatype"))
                {
                    if (Variable_Link())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool Id_S_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Object_Link())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_colon"))
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_inc_dec"))
            {
                if (cp("_terminator"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (Asgn2())
            {
                if (cp("_terminator"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (Class_Member_Child())
            {
                if (cp("_terminator"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }


            else return false;
        }


        private bool DT_S_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Array_Link())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_identifier"))
            {
                if (DT_S_St2())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }

        private bool DT_S_St2()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");


            if (Variable_Link2())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (DT_S_ST3())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }
        private bool DT_S_ST3()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Object_Creation_Exp())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Asgn2())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool M_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // Follow Set
            if (cp2("_bracket_curly_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            if (S_St())
            {
                if (M_St())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return false;
        }


        private bool Body()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (S_St())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_bracket_curly_open"))
            {
                if (M_St())
                {
                    if (cp("_bracket_curly_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }

                    else { return false; }
                }
                else return false;
            }
            else return false;
        }


        /*------------------------------------ DECLARATION --------------------------*/
        // VARIABLE DECLARATION
        private bool Variable_Dec()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Variable_Dec> -> DT <Variable_Link>
            if (cp("_datatype"))
            {

                if (Variable_Link())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Variable_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Variable_Link> -> Id <Varaiable_Link2>
            if (cp("_identifier"))
            {
                if (Variable_Link2())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Variable_Link2()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Varaiable_Link2> -> =  <Variable_Value>| <List_Variable>
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            // to be confirmed
            {
                if (Variable_Value())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (List_Variable())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool Variable_Value()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Variable_Assign> -> Id <Variable_Link2> | <Const>
            if (Id_Constant())
            {
                if (List_Variable())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (cp("_new"))
            {
                if (cp("_datatype"))
                {
                    if (cp("_bracket_parentheses_open"))
                    {
                        if (cp("_bracket_parentheses_close"))
                        {
                            if (List_Variable())
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool List_Variable()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <List_Variable> -> , Id <Variable_Link2> <List_Variable> | ;
            if (cp("_comma"))
            {
                if (cp("_identifier"))
                {
                    if (Variable_Link2())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;

        }

        // OBJECT DECLARATION
        //private bool Object_Dec()
        //{
        //    //<Object_Dec>-><DT_Id> <Object_Link>
        //    if (DT_Id())
        //    {
        //        if (Object_Link())
        //        {
        //            currentNode = currentNode.Parent; return true;
        //        }
        //        else return false;
        //    }
        //    else return false;

        //}

        private bool Object_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Object_Link> ->Id <Object_Creation_Exp>
            if (cp("_identifier"))
            {
                if (Object_Creation_Exp())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;

        }

        private bool Object_List()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Object_List> -> , Id<Object_Creation_Exp>|;
            if (cp("_comma"))
            {
                if (cp("_identifier"))
                {
                    if (Object_Creation_Exp())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;

                }
                else return false;
            }
            else if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool Object_Creation_Exp()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Object_Creation_Exp> -> = new <DT_Id> (<List_Const>) <Object_List> |<Object_List>
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            {
                if (cp("_new"))
                {
                    if (cp("_identifier"))
                    {
                        if (cp("_bracket_parentheses_open"))
                        {
                            if (List_Const())
                            {
                                if (cp("_bracket_parentheses_close"))
                                {
                                    if (Object_List())
                                    {
                                        currentNode = currentNode.Parent; return true;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Object_List())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;

        }

        // METHOD DECLARATION

        private bool Method_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Return_Type())
            {
                if (Method_Link2())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Method_Link2()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >"); if (cp("_identifier"))
            {
                if (Method_Link3())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;

            }
            else return false;
        }

        private bool Method_Link3()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");

            if (cp("_bracket_parentheses_open"))
            {
                if (List_Param())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        if (cp("_bracket_curly_open"))
                        {
                            if (M_St())
                            {
                                if (cp("_bracket_curly_close"))
                                {
                                    currentNode = currentNode.Parent; return true;
                                }
                                else
                                { return false; }

                            }
                            else return false;

                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }


        // ARRAY DECLARATION
        private bool Array_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_Link> ->  [] Id  <List_Array>
            if (cp("_bracket_square_open"))
            {
                if (cp("_bracket_square_close"))
                {
                    if (cp("_identifier"))
                    {
                        if (List_Array())
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool List_Array()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<List_Array>->;|=<Array_Asign>
            if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            {
                if (Array_Assign())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return false;
        }

        private bool Array_Assign()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_Asign> -> new <DT_Id> [<A-temp> | <Array_C>
            if (cp("_new"))
            {
                if (DT_Id())
                {
                    if (cp("_bracket_square_open"))
                    {
                        if (A_Temp())
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else if (Array_C())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        private bool A_Temp()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<A-temp> -> <Id_Constant>] <Array_Const> | ]<Array_C>

            if (Id_Constant())
            {
                if (cp("_bracket_square_close"))
                {
                    if (Array_Const())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Array_C())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;

        }

        private bool Array_Const()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_Const> -> <Array_C>|;
            if (Array_C())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;

        }

        private bool Array_C()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_C> -> { <Const> <Array_C2>
            if (cp("_bracket_curly_open"))
            {
                if (Const())
                {
                    if (Array_C2())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;

        }

        private bool Array_C2()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Array_C2> -> , <Const> <Array_C2> | };
            if (cp("_comma"))
            {
                if (Const())
                {
                    if (Array_C2())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_bracket_curly_close"))
            {
                if (cp("_terminator"))
                {

                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }


        // CONSTRUCTION DECLARATION
        private bool Constructor_Dec()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Constructor _Dec> ->  Id(<List_Param>) <Constructor_Base> { <M_St> }
            if (cp("_identifier"))
            {
                if (cp("_bracket_parentheses_open"))
                {
                    if (List_Param())
                    {
                        if (cp("_bracket_parentheses_close"))
                        {
                            if (Constructor_Base())
                            {
                                if (cp("_bracket_curly_open"))
                                {
                                    if (M_St())
                                    {
                                        if (cp("_bracket_curly_close"))
                                        {
                                            currentNode = currentNode.Parent; return true;
                                        }
                                        else return false;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool Constructor_Base()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Constructor _Base> -> Null | : <Constructor_BT> (<List_Param>)

            // follow set
            if (cp2("_bracket_curly_open"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_colon"))
            {
                if (Constructor_BT())
                {
                    if (cp("_bracket_parentheses_open"))
                    {
                        if (List_Param())
                        {
                            if (cp("_bracket_parentheses_close"))
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool Constructor_BT()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Constructor _BT> -> base | this
            if (cp("_base"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_this"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }

        // NAMESPACE DECLARATION
        private bool Namespace_Dec()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Namespace_Dec> -> namespace Id {<Namespace_Member> }
            if (cp("_namespace"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_bracket_curly_open"))
                    {
                        if (Namespace_Member())
                        {
                            if (cp("_bracket_curly_close"))
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool Namespace_Member()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Namespace_Member> -> <Class_Dec><Namespace_Member> | <Namespace_Dec><Namespace_Member> | Null
            // follow set
            if (cp2("_bracket_curly_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }

            else if (Class_Dec())
            {
                if (Namespace_Member())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (Namespace_Dec())
            {
                if (Namespace_Member())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }

        // CLASS DECLARATION
        private bool Class_Dec()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");

            if (Access_Modifier())
            {
                if (Class_Link())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            // Null case
            else return false;
        }
        private bool Class_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");

            if (cp("_class"))
            {
                if (cp("_identifier"))
                {
                    if (Class_Base())
                    {
                        if (cp("_bracket_curly_open"))
                        {
                            if (Class_Body())
                            {
                                if (cp("_bracket_curly_close"))
                                {
                                    currentNode = currentNode.Parent; return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        private bool Class_Base()
        {

            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // follow set
            if (cp2("_bracket_curly_open"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_colon"))
            {
                if (cp("_identifier"))
                {

                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return false;

        }
        private bool Class_Body()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // Follow Set
            if (cp2("_bracket_curly_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (Class_Member())
            {
                if (Class_Body())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;

            }

            else return false;
        }
        private bool Class_Member()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Access_Modifier())
            {
                if (Member_Link())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else return false;
        }
        private bool Member_Link()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Static_Shared())
            {
                if (SS_A())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_const"))
            {
                if (Variable_Dec())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_virtual_override"))
            {
                if (Method_Link())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (Constructor_Dec())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Class_Link())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }
        private bool SS_A()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_datatype"))
            {
                if (DT_OArray())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_identifier"))
            {
                if (Id_OArray())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_void"))
            {
                if (cp("_identifier"))
                {
                    if (Method_Link3())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;

                }
                else return false;
            }
            else return false;
        }

        private bool Id_OArray()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_identifier"))
            {
                if (Id_A())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (Array_Link())
            {
                currentNode = currentNode.Parent; return true;
            }

            else return false;
        }

        private bool DT_OArray()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_identifier"))
            {
                if (DT_A())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (Array_Link())
            {
                currentNode = currentNode.Parent; return true;
            }

            else return false;
        }
        private bool DT_A()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Variable_Link2())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Method_Link3())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }
        private bool Id_A()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (Method_Link3())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (Object_Creation_Exp())
            {
                currentNode = currentNode.Parent; return true;
            }
            else return false;
        }
        /*------------------------------------ STATEMENTS --------------------------*/

        // Expression
        private bool exp()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <exp> -> <O>
            if (O())
            {
                currentNode = currentNode.Parent; return true;
            }

            else return false;
        }

        private bool O()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <O> -> <A> <O’>
            if (A())
            {
                if (O_())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return false;
        }
        // all rules till id_op use follow set

        private bool O_()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <O’> -> || <A> <O’> | Null
            if (cp("_or"))
            {
                if (A())
                {
                    if (O_())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;

            }
            // Follow set
            else if (cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool A()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <A> -> <RE> <A’>
            if (RE())
            {
                if (A_())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool A_()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <A’> -> && <RE> <A’> | Null
            if (cp("_and"))
            {
                if (RE())
                {
                    if (A_())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            // Null case
            else return false;
        }

        private bool RE()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <RE> -> <PM> <RE’>
            if (PM())
            {
                if (RE_())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool RE_()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <RE’> -> Rel_Op <PM> <RE’> | Null
            if (cp("_relational"))
            {
                if (PM())
                {
                    if (RE_())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }

                else return false;
            }
            else if (cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            // Null case
            else return false;
        }

        private bool PM()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <PM> -> <MD> <PM’>
            if (MD())
            {
                if (PM_())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool PM_()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <PM’> -> P_M <MD> <PM’> | Null
            if (cp("_plus_minus"))
            {
                if (MD())
                {
                    if (PM_())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            // Null case
            else return false;
        }

        private bool MD()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <MD> -> <OP> <MD’>
            if (OP())
            {
                if (MD_())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool MD_()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <MD’> -> M_D_M <OP> <MD’> | Null
            if (cp("_multiply_divide_mode"))
            {
                if (OP())
                {
                    if (MD_())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else if (cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool OP()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <OP> -> Id<id_op>  | <Const> |!<OP> | (<exp>) | Inc_Dec  Id
            if (cp("_identifier"))
            {
                if (id_op())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (Const())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_not"))
            {
                if (OP())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp("_bracket_parentheses_open"))
            {
                if (exp())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_inc_dec"))
            {
                if (cp("_identifier"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }
            else if (cp2("_multiply_divide_mode") || cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else return false;
        }

        private bool id_op()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <id_op> -> Null | (<List_Const>) | [ <Id_Constant> ] | <Class_Member_Child> | Inc_Dec
            if (cp("_bracket_parentheses_open"))
            {
                if (List_Const())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_bracket_square_open"))
            {
                if (Id_Constant())
                {
                    if (cp("_bracket_square_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Class_Member_Child())
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp("_inc_dec"))
            {
                currentNode = currentNode.Parent; return true;
            }
            else if (cp2("_multiply_divide_mode") || cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") || cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close") || cp2("_bracket_square_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            // Null case
            else return false;
        }

        // CLASS MEMBER ACCESS
        private bool Class_Member_Child()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Class_Member_Child> -> .Id <Id_CMC> | (<List_Const>) | Null

            // follow set
            if (cp2("bracket_curly_close") || cp2("_else") || cp2("_multiply_divide_mode") || cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") ||
           cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_dot"))
            {
                if (cp("_identifier"))
                {
                    if (Id_CMC())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_bracket_parentheses_open"))
            {
                if (List_Const())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (Asgn2())
            {
                currentNode = currentNode.Parent; return true;
            }


            else return false;
        }

        private bool Id_CMC()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Id_CMC> -> <Class_Member_Child> | [<Id_Constant>] <Class_Member_Child>

            // follow set
            if (cp2("bracket_curly_close") || cp2("_else") || cp2("_multiply_divide_mode") || cp2("_plus_minus") || cp2("_relational") || cp2("_and") || cp2("_or") ||
                cp2("_comma") || cp2("_terminator") || cp2("_bracket_parentheses_close"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (Class_Member_Child())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (cp("_bracket_square_open"))
            {
                if (Id_Constant())
                {
                    if (cp("_bracket_square_close"))
                    {
                        if (Class_Member_Child())
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else if (Class_Member_Child())
            {
                currentNode = currentNode.Parent; return true;
            }



            else return false;
        }

        // while
        private bool While_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            if (cp("_while"))
            {
                if (cp("_bracket_parentheses_open"))
                {
                    if (exp())
                    {
                        if (cp("_bracket_parentheses_close"))
                        {
                            if (Body())
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // for
        private bool For_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <For_St>->for(<AD><C>;<A_D>)<Body>
            if (cp("_for"))
            {
                if (cp("_bracket_parentheses_open"))
                {
                    if (AD())
                    {
                        if (C())
                        {
                            if (cp("_terminator"))
                            {
                                if (A_D())
                                {
                                    if (cp("_bracket_parentheses_close"))
                                    {
                                        if (Body())
                                        {
                                            currentNode = currentNode.Parent; return true;
                                        }
                                        else return false;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool AD()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <AD>-> <Variable_Dec>|<Asgn>;|;
            if (Variable_Dec())
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Asgn())
            {
                if (cp("_terminator"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (cp("_terminator"))
            {
                currentNode = currentNode.Parent; return true;
            }


            else return false;

        }

        private bool C()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <C>-><exp>|Null
            // follow set
            if (cp2("_terminator"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            // need to review
            else if (exp())
            {
                currentNode = currentNode.Parent; return true;
            }

            else return false;

        }

        private bool A_D()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <A_D>-> Id <Id_A_D> | Inc_Dec Id |Null

            // follow set
            if (cp2("_bracket_parentheses_open"))
            {
                currentNode.Nodes.Add("(NULL)", "( " + "NULL" + " )");
                currentNode = currentNode.Parent;
                return true;
            }
            else if (cp("_identifier"))
            {
                if (Id_A_D())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else if (cp("_inc_dec"))
            {
                if (cp("_identifier"))
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }


            else return false;

        }

        private bool Id_A_D()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Id_A_D> -> Inc_Dec | <Array_Index> AsgOp <exp>
            if (cp("_inc_dec"))
            {
                currentNode = currentNode.Parent; return true;
            }

            else if (Array_Index())
            {
                if (cp("_assignment"))
                {
                    if (exp())
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        // Foreach
        private bool Foreach_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Foreach_St>-> foreach(<Foreach_Assg> )<Body>
            if (cp("_foreach"))
            {
                if (cp("_bracket_parentheses_open"))
                {
                    if (Foreach_Assg())
                    {
                        if (cp("_bracket_parentheses_close"))
                        {
                            if (Body())
                            {
                                currentNode = currentNode.Parent; return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool Foreach_Assg()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Foreach_Assg>-> DT Id in Id
            if (cp("_datatype"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_in"))
                    {
                        if (cp("_identifier"))
                        {
                            currentNode = currentNode.Parent; return true;
                        }
                        else return false;
                    }
                    else return false;
                }

                else return false;
            }
            else return false;
        }

        // Do while
        private bool Do_While_St()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            //<Do_While_St>->do{<M_St>}while(<exp>);

            if (cp("_do"))
            {
                if (cp("_bracket_curly_open"))
                {
                    if (M_St())
                    {
                        if (cp("_bracket_curly_close"))
                        {
                            if (cp("_while"))
                            {
                                if (cp("_bracket_parentheses_open"))
                                {
                                    if (exp())
                                    {
                                        if (cp("_bracket_parentheses_close"))
                                        {
                                            if (cp("_terminator"))
                                            {
                                                currentNode = currentNode.Parent; return true;
                                            }
                                            else return false;
                                        }
                                        else return false;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // RETURN
        private bool Return()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <Return> -> return <exp>;
            if (cp("_return"))
            {
                if (exp())
                {
                    if (cp("_terminator"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // GOTO
        private bool GoTo()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <GoTo> -> goto Id
            if (cp("_goto"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_terminator"))
                    {
                        currentNode = currentNode.Parent; return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // IF ELSE
        private bool If_Else()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <If_Else>-> if(<exp>)<Body><O_Else>
            if (cp("_if"))
            {
                if (cp("_bracket_parentheses_open"))
                {
                    if (exp())
                    {
                        if (cp("_bracket_parentheses_close"))
                        {
                            if (Body())
                            {
                                if (O_Else())
                                {
                                    currentNode = currentNode.Parent; return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool O_Else()
        {
            currentNode = currentNode.Nodes.Add("<" + System.Reflection.MethodBase.GetCurrentMethod().Name + ">", "< " + System.Reflection.MethodBase.GetCurrentMethod().Name + " >");
            // <O_Else>-> else <Body>|Null

            // follow set

            if (tokenIndex >= Tokens.Count()) { currentNode = currentNode.Parent; return true; }
            if (cp("_else"))
            {
                if (Body())
                {
                    currentNode = currentNode.Parent; return true;
                }
                else return false;
            }

            else return true;
        }


    }
}
