using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Construction
{
    class AminWork 
    {
        List<token> Tokens;
        public int tokenIndex;
        public bool syntaxAnlysis(List<token> tokens)
        {
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
            if (cp("_end_marker"))
            {
                return true;
            }
            else return false;
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
                // Follow Set
            else if (cp2("_identifier"))
            {
                return true;
            }

            else return false;


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
                // Follow Set
            else if (cp2("_assignment"))
            {
                return true;
            }
            else return false;
        }

        private bool Access_Modifier()
        {
            
            //<Access_Modifier> -> _access_modifier|Null
            if (cp("_accessmodifier"))
            {
                
                return true;
            }
                // Follow Set
            else if (cp2("_static") || cp2("_shared") || cp2("_const") || cp2("_void") || cp2("_identifier") || cp2("_class"))
            {
                return true;
            }
            else return false;
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
                // Follow Set
            else if (cp2("_bracket_parentheses_close"))
            {
                return true;
            }
            else return false;
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
                            if (List_Param_B())
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
                // Follow Set
            else if (cp2("_bracket_parentheses_close"))
            {
                return true;
            }
            else return false;
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
                // Follow Set
            else if (cp2("_bracket_parentheses_close"))
            {
                return true;
            }
            else return false;
            
        }

        private bool List_Const_B()
        {
            // <List_Const_B>->,< exp><List_Const>|Null
            if (cp("_comma"))
            {
                if (exp())
                {
                    if (List_Const_B())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
                // Follow Set
            else if (cp2("_bracket_parentheses_close"))
            {
                return true;
            }
            else return false;
        }

        private bool Asgn()
        {
            if (cp("_identifier"))
            {
                if (Array_Index())
                {
                    if (cp("_assignment"))
                    {
                        if (exp())
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

        private bool S_St()
        {
            // <S_St> -> Id<Id_S_St> | DT<DT_S_St> | <While_St> | <For_St> | <Do_While_St> 
            // | <Foreach_St> | <If_Else> | <Return> | <GoTo> | inc_dec id | const DT <Variable_Link>
            if (cp("_identifier"))
            {
                if (Id_S_St())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_datatype"))
            {
                if (DT_S_St())
                {
                    return true;
                }
                else return false;
            }

            else if (While_St())
            {
                return true;
            }

            else if (For_St())
            {
                return true;
            }

            else if (Do_While_St())
            {
                return true;
            }

            else if (Foreach_St())
            {
                return true;
            }

            else if (If_Else())
            {
                return true;
            }

            else if (Return())
            {
                return true;
            }

            else if (GoTo())
            {
                return true;
            }

            else if (cp("_inc_dec"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_terminator"))
                    {
                        return true;
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
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            else return false;
        }

        private bool Id_S_St()
        {
            if (Array_Link())
            {
                return true;
            }

            else if (Object_Link())
            {
                return true;
            }

            else if (cp("_colon"))
            {
                return true;
            }

            else if (cp("_inc_dec"))
            {
                if (cp("_terminator"))
                {
                    return true;
                }
                else return false;
            }

            else if (Class_Member_Child())
            {
                return true;
            }

            else return false;
        }

        private bool DT_S_St()
        {
            if (Array_Link())
            {
                return true;
            }

            else if (cp("_identifier"))
            {
                if (DT_S_St2())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool DT_S_St2()
        {
            if (Object_Creation_Exp())
            {
                return true;
            }

            else if (Variable_Link2())
            {
                return true;
            }
            else return false;
        }

        private bool M_St()
        {
            if (S_St())
            {
                if (M_St())
                {
                    return true;
                }
                else return false;
            }
                // Follow Set
            else if (cp2("_bracket_curly_close"))
            {
                return true;
            }
            else return false;
        }

        private bool Body()
        {
            if (cp("_terminator"))
            {
                return true;
            }

            else if (S_St())
            {
                return true;
            }

            else if (cp("_bracket_curly_open"))
            {
                if (M_St())
                {
                    if (cp("_bracket_curly_close"))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
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
            // <Varaiable_Link2> -> =  <Variable_Value>| <List_Variable>
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            // to be confirmed
            {
                if (Variable_Value())
                {
                    return true;
                }
                else return false;
            }
            else if (List_Variable())
            {
                return true;
            }
            else return false;
        }

        private bool Variable_Value()
        {
            // <Variable_Assign> -> Id <Variable_Link2> | <Const>
            if (Id_Constant())
            {
                if (List_Variable())
                {
                    return true;
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
        //private bool Object_Dec()
        //{
        //    //<Object_Dec>-><DT_Id> <Object_Link>
        //    if (DT_Id())
        //    {
        //        if (Object_Link())
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    else return false;

        //}

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

        // METHOD DECLARATION

        private bool Method_Link()
        {
            if (Return_Type())
            {
                if (Method_Link2())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Method_Link2()
        {
            if (cp("_identifier"))
            {
                if (Method_Link3())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool Method_Link3()
        {
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

        // ARRAY DECLARATION
        private bool Array_Link()
        {
            //<Array_Link> ->  [] Id  <List_Array>
            if (cp("_bracket_square_open"))
            {
                if (cp("_bracket_square_close"))
                {
                    if (cp("_identifier"))
                    {
                        if (List_Array())
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

        private bool List_Array()
        {
            //<List_Array>->;|=<Array_Asign>
            if (cp("_terminator"))
            {
                return true;
            }

            else if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            {
                if (Array_Assign())
                {
                    return true;
                }
                else return false;
            }

            else return false;
        }

        private bool Array_Assign()
        {

            //<Array_Asign> -> new <DT_Id> [<A-temp> | <Array_C>
            if (cp("_new"))
            {
                if (DT_Id())
                {
                    if (cp("_bracket_square_open"))
                    {
                        if (A_Temp())
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }

            else if (Array_C())
            {
                return true;
            }
            else return false;
        }

        private bool A_Temp()
        {
            //<A-temp> -> <Id_Constant>] <Array_Const> | ]<Array_C>

            if (Id_Constant())
            {
                if (cp("_bracket_square_close"))
                {
                    if (Array_Const())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Array_C())
            {
                return true;
            }
            else return false;

        }

        private bool Array_Const()
        {
            //<Array_Const> -> <Array_C>|;
            if (Array_C())
            {
                return true;
            }
            else if (cp("_terminator"))
            {
                return true;
            }
            else return false;

        }

        private bool Array_C()
        {
            //<Array_C> -> { <Const> <Array_C2>
            if (cp("_bracket_curly_open"))
            {
                if (Const())
                {
                    if (Array_C2())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;

        }

        private bool Array_C2()
        {
            //<Array_C2> -> , <Const> <Array_C2> | };
            if (cp("_comma"))
            {
                if (Const())
                {
                    if (Array_C2())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (cp("_bracket_curly_close"))
            {
                if (cp("_terminator"))
                {

                    return true;
                }
                else return false;
            }
            else return false;
        }


        // CONSTRUCTION DECLARATION
        private bool Constructor_Dec()
        {
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
                else return false;
            }
            else return false;
        }

        private bool Constructor_Base()
        {
            // <Constructor _Base> -> Null | : <Constructor_BT> (<List_Param>)
            if (cp("_colon"))
            {
                if (Constructor_BT())
                {
                    if (cp("_bracket_parentheses_open"))
                    {
                        if (List_Param())
                        {
                            if (cp("_bracket_parentheses_close"))
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
            else return true;
        }

        private bool Constructor_BT()
        {
            // <Constructor _BT> -> base | this
            if (cp("_base"))
            {
                return true;
            }
            else if (cp("_this"))
            {
                return true;
            }
            else return false;
        }

        // NAMESPACE DECLARATION
        private bool Namespace_Dec()
        {
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

        private bool Namespace_Member()
        {
            // <Namespace_Member> -> <Class_Dec><Namespace_Member> | <Namespace_Dec><Namespace_Member> | Null
            if (Class_Dec())
            {
                if (Namespace_Member())
                {
                    return true;
                }
                else return false;
            }
            else if (Namespace_Dec())
            {
                if (Namespace_Member())
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }

        // CLASS DECLARATION
        private bool Class_Dec()
        {
            
            if (Access_Modifier())
            {
                if (Class_Link())
                {
                    return true;
                }
                else return false;
            }
            // Null case
            else return false;
        }
        private bool Class_Link()
        {
            
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
        private bool Class_Base()
        {
            
            if (cp("_colon"))
            {
                if (cp("_identifier"))
                {
                    
                    return true;
                }
                else return false;
            }
            else
            {
                
                return true; 
            }
        }
        private bool Class_Body()
        {
            if (Class_Member())
            {
                if (Class_Body())
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }
        private bool Class_Member()
        {
            if (Access_Modifier())
            {
                if (Member_Link())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private bool Member_Link()
        {
            if (Static_Shared())
            {
                if (SS_A())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_const"))
            {
                if (Variable_Dec())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_virtual_override"))
            {
                if (Method_Link())
                {
                    return true;
                }
                else return false;
            }
            else if (Constructor_Dec())
            {
                return true;
            }
            else if (Class_Link())
            {
                return true;
            }
            else return false;
        }
        private bool SS_A()
        {
            if (cp("_datatype"))
            {
                if (DT_OArray())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_identifier"))
            {
                if (Id_OArray())
                {
                    return true;
                }
                else return false;
            }
            else if (cp("_void"))
            {
                if (cp("_identifier"))
                {
                    if (Method_Link3())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private bool Id_OArray()
        {
            if (cp("_identifier"))
            {
                if (Id_A())
                {
                    return true;
                }
                else return false;
            }

            else if (Array_Link())
            {
                return true;
            }

            else return false;
        }

        private bool DT_OArray()
        {
            if (cp("_identifier"))
            {
                if (DT_A())
                {
                    return true;
                }
                else return false;
            }

            else if (Array_Link())
            {
                return true;
            }

            else return false;
        }
        private bool DT_A()
        {
            if (Variable_Link2())
            {
                return true;
            }
            else if (Method_Link3())
            {
                return true;
            }
            else return false;
        }
        private bool Id_A()
        {
            if (Method_Link3())
            {
                return true;
            }
            else if (Object_Creation_Exp())
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

        // CLASS MEMBER ACCESS
        private bool Class_Member_Child()
        {
            // <Class_Member_Child> -> .Id <Id_CMC> | (<List_Const>) | Null
            if (cp("_dot"))
            {
                if (cp("_identifier"))
                {
                    if (Id_CMC())
                    {
                        if (cp("_terminator"))
                        {
                            return true;
                        }
                        else return false;
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
                        if (cp("_terminator"))
                        {
                            return true;
                        }
                        else return false;
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

        private bool Id_CMC()
        {
            // <Id_CMC> -> [<Id_Constant>] <Class_Member_Child> | <Class_Member_Child>
            if (cp("_bracket_square_open"))
            {
                if (Id_Constant())
                {
                    if (cp("_bracket_square_close"))
                    {
                        if (Class_Member_Child())
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            
            else if (Class_Member_Child())
            {
                return true;
            }
            
            else return false;
        }

        // while
        private bool While_St()
        {
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

        // for
        private bool For_St()
        {
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
                else return false;
            }
            else return false;
        }

        private bool AD()
        {
            // <AD>-> <Variable_Dec>|<Asgn>;|;
            if (Variable_Dec())
            {
                return true;
            }

            else if (Asgn())
            {
                if (cp("_terminator"))
                {
                    return true;
                }
                else return false;
            }

            else if (cp("_terminator"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool C()
        {
            // <C>-><exp>|Null
            // need to review
            if (exp())
            {
                return true;
            }
            else return true;

        }

        private bool A_D()
        {
            // <A_D>-> Id <Id_A_D> | Inc_Dec Id |Null

            if (cp("_identifier"))
            {
                if (Id_A_D())
                {
                    return true;
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

            else return true;

        }

        private bool Id_A_D()
        {
            // <Id_A_D> -> Inc_Dec | <Array_Index> AsgOp <exp>
            if (cp("_inc_dec"))
            {
                return true;
            }

            else if (Array_Index())
            {
                if (cp("_assignment"))
                {
                    if (exp())
                    {
                        return true;
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

        private bool Foreach_Assg()
        {
            //<Foreach_Assg>-> DT Id in Id
            if (cp("_datatype"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_in"))
                    {
                        if (cp("_identifier"))
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

        // Do while
        private bool Do_While_St()
        {
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
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        // RETURN
        private bool Return()
        {
            // <Return> -> return <exp>;
            if (cp("_return"))
            {
                if (exp())
                {
                    if (cp("_terminator"))
                    {
                        return true;
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
            // <GoTo> -> goto Id
            if (cp("_goto"))
            {
                if (cp("_identifier"))
                {
                    if (cp("_terminator"))
                    {
                        return true;
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

        private bool O_Else()
        {
            // <O_Else>-> else <Body>|Null
            if (tokenIndex >= Tokens.Count()) { return true; }
            if (cp("_else"))
            {
                if (Body())
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }
    }
}
