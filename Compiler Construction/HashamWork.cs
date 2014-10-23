using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    internal class HashamWork
    {
        List<token> Tokens;
        public int tokenIndex;


        public bool syntaxAnlysis(List<token> tokens)
        {
            Tokens = tokens;
            tokenIndex = 0;
            try
            {
                if (Object_Dec())
                {
                    return true;
                }
            }
            catch
            {

                return false;
            }


            return false;
        }

        // Extra Function
        private bool cp(string classpart)
        {
            if (Tokens[tokenIndex].classString == classpart)
            {
                tokenIndex++;
                return true;
            }
            else return false;
        }

        // dummy rule
        private bool List_Const()
        {
            // <List_Const>-><exp><List_Const_B> | Null
            if (exp())
            {
                if (List_Const_B())
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }

        private bool List_Const_B()
        {
            // <List_Const_B>->,< exp><List_Const>|Null
            if (cp("_comma"))
            {
                if (exp())
                {
                    if (List_Const())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return true;
        }

        private bool Class_Member_Child()
        {
            return false;
        }

        /*------------------------------------ GENERAL RULES --------------------------*/
        private bool Const()
        {
            // <Const> -> Int_Const | Float_Const | String_Const | Char_Const | Bool_Const 
            switch (Tokens[tokenIndex].classString)
            {
                case "_int_constant":
                case "_float_constant":
                case "_string_constant":
                case "_char_constant":
                case "_bool_constant":
                    tokenIndex++;
                    return true;

                default:
                    return false;

            }
        }

        private bool Id_Constant()
        {
            //<Id_Constant> -> Id|<Const>
            if (cp("_identifier"))
            {
                return true;
            }
            else if (Const())
            {
                return true;
            }

            else return false;
        }

        private bool Array_Init()
        {
            //<Array_Init> -> [] | Null
            if (cp("_bracket_square_open"))
            {
                if (cp("_bracket_square_close"))
                {
                    return true;
                }
                else return false;
            }
            else return true;


        }

        private bool Array_Index()
        {
            //<Array_Index> -> [<Id_Constant>] | Null
            if (cp("_bracket_square_open"))
            {
                if (Id_Constant())
                {
                    if (cp("_bracket_square_close"))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return true;
        }

        private bool Access_Modifier()
        {
            //<Access_Modifier> -> _access_modifier|Null
            if (cp("_accessmodifier"))
            {
                return true;
            }
            else return true;
        }

        private bool List_Param()
        {
            //<List_Param> -> <DT_Id><Array_Init> Id<List_Param_B>|Null
            if (DT_Id())
            {
                if (Array_Init())
                {
                    if (cp("_identifier"))
                    {
                        if (List_Param_B())
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return true;
        }

        private bool List_Param_B()
        {
            //<List_Param_B> -> Null |, <DT_Id> <Array_Init> Id<List_Param>
            if (cp("_comma"))
            {
                if (DT_Id())
                {
                    if (Array_Init())
                    {
                        if (cp("_identifier"))
                        {
                            if (List_Param())
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return true;
        }

        private bool DT_Id()
        {
            //<DT_Id> -> DT|Id
            if (cp("_datatype"))
            {
                return true;
            }

            else if (cp("_identifier"))
            {
                return true;
            }
            else return false;
        }

        private bool Static_Shared()
        {
            //<Static_Shared> -> _static | _shared
            if (cp("_static"))
            {
                return true;
            }
            else if (cp("_shared"))
            {

                return true;
            }
            else
                return false;
        }

        private bool Static_Shared_Constant()
        {
            //<Static_Shared _Constant> -> <Static_Shared> | const
            if (Static_Shared())
            {
                return true;
            }
            else if (Const())
            {
                return true;
            }
            else return false;
        }

        private bool Return_Type()
        {
            //<Return_Type> -> <DT_Id>| void
            if (DT_Id())
            {
                return true;
            }
            else if (cp("_void"))
            {

                return true;
            }
            else return false;
        }

        /*------------------------------------ DECLARATION --------------------------*/
        // VARIABLE DECLARATION
        private bool Variable_Dec()
        {
            // <Variable_Dec> -> DT <Variable_Link>
            if (cp("_datatype"))
            {

                if (Variable_Link())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Variable_Link()
        {
            // <Variable_Link> -> Id <Varaiable_Link2>
            if (cp("_identifier"))
            {
                if (Variable_Link2())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Variable_Link2()
        {
            // <Varaiable_Link2> -> =  <Variable_Assign> <List_Variable> | <List_Variable>
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            // to be confirmed
            {
                if (Variable_Assign())
                {
                    if (List_Variable())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (List_Variable())
            {
                return true;
            }
            else return false;
        }

        private bool Variable_Assign()
        {
            // <Variable_Assign> -> Id <Variable_Link2> | <Const>
            if (cp("_identifier"))
            {
                return true;
            }
            else if (Const())
            {
                return true;
            }
            else return false;
        }

        private bool List_Variable()
        {
            // <List_Variable> -> , Id <Variable_Link2> <List_Variable> | ;
            if (cp("_comma"))
            {
                if (cp("_identifier"))
                {
                    if (Variable_Link2())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_terminator"))
            {
                return true;
            }
            else return false;

        }

        // OBJECT DECLARATION
        private bool Object_Dec()
        {
            //<Object_Dec>-><DT_Id> <Object_Link>
            if (DT_Id())
            {
                if (Object_Link())
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        private bool Object_Link()
        {
            //<Object_Link> ->Id <Object_Creation_Exp>
            if (cp("_identifier"))
            {
                if (Object_Creation_Exp())
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        private bool Object_List()
        {
            //<Object_List> -> , Id<Object_Creation_Exp>|;
            if (cp("_comma"))
            {
                if (cp("_identifier"))
                {
                    if (Object_Creation_Exp())
                    {
                        return true;
                    }
                    else return false;

                }
                else return false;
            }
            else if (cp("_terminator"))
            {
                return true;
            }
            else return false;
        }

        private bool Object_Creation_Exp()
        {
            // <Object_Creation_Exp> -> = new <DT_Id> (<List_Const>) <Object_List> |<Object_List>
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            {
                if (cp("_new"))
                {
                    if (DT_Id())
                    {
                        if (cp("_bracket_parentheses_open"))
                        {
                            if (List_Const())
                            {
                                if (cp("_bracket_parentheses_close"))
                                {
                                    if (Object_List())
                                    {
                                        return true;
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
                return true;
            }
            else return false;

        }

        /*------------------------------------ STATEMENTS --------------------------*/

        // Expression
        private bool exp()
        {
            // <exp> -> <O>
            if (O())
            {
                return true;
            }
            else return false;
        }

        private bool O()
        {
            // <O> -> <A> <O’>
            if (A())
            {
                if (O_())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool O_()
        {
            // <O’> -> || <A> <O’> | Null
            if (cp("_or"))
            {
                if (A())
                {
                    if (O_())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else return true;
        }

        private bool A()
        {
            // <A> -> <RE> <A’>
            if (RE())
            {
                if (A_())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool A_()
        {
            // <A’> -> && <RE> <A’> | Null
            if (cp("_and"))
            {
                if (RE())
                {
                    if (A_())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else return true;
        }

        private bool RE()
        {
            // <RE> -> <PM> <RE’>
            if (PM())
            {
                if (RE_())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool RE_()
        {
            // <RE’> -> Rel_Op <PM> <RE’> | Null
            if (cp("_relational"))
            {
                if (PM())
                {
                    if (RE_())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else return true;
        }

        private bool PM()
        {
            // <PM> -> <MD> <PM’>
            if (MD())
            {
                if (PM_())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool PM_()
        {
            // <PM’> -> P_M <MD> <PM’> | Null
            if (cp("_plus_minus"))
            {
                if (MD())
                {
                    if (PM_())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else return true;
        }

        private bool MD()
        {
            // <MD> -> <OP> <MD’>
            if (OP())
            {
                if (MD_())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool MD_()
        {
            // <MD’> -> M_D_M <OP> <MD’> | Null
            if (cp("_multiply_divide_mode"))
            {
                if (OP())
                {
                    if (MD_())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            // Null case
            else return true;
        }

        private bool OP()
        {
            // <OP> -> Id<id_op>  | <Const> |!<OP> | (<exp>) | Inc_Dec  Id
            if (cp("_identifier"))
            {
                if (id_op())
                {
                    return true;
                }
                else return false;
            }
            else if (Const())
            {
                return true;
            }
            else if (cp("_not"))
            {
                if (OP())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_bracket_parentheses_open"))
            {
                if (exp())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_inc_dec"))
            {
                if (cp("_identifier"))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool id_op()
        {
            // <id_op> -> Null | (<List_Const>) | [ <Id_Constant> ] | <Class_Member_Child> | Inc_Dec
            if (cp("_bracket_parentheses_open"))
            {
                if (List_Const())
                {
                    if (cp("_bracket_parentheses_close"))
                    {
                        return true;
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
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Class_Member_Child())
            {
                return true;
            }
            else if (cp("_inc_dec"))
            {
                return true;
            }
            // Null case
            else return true;
        }


    }

  
}
