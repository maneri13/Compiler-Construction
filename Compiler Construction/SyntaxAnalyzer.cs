using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    class SyntaxAnalyzer
    {
        List<token> Tokens;
        public int tokenIndex;


        public bool syntaxAnlysis(List<token> tokens)
        {
            Tokens = tokens;
            tokenIndex = 0;
            try
            {
                if (Variable_Dec())
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
        private bool List_Const()
        {
            return false;
        }
        private bool Id_Constant()
        {
            return false;
        }
        private bool Class_Member_Child()
        {
            return false;
        }


        /*------------------------------------ DECLARATION --------------------------*/
        // VARIABLE DECLARATION
        private bool Variable_Dec()
        {
            // <Variable_Dec> -> DT <Variable_Link>
            if (Tokens[tokenIndex].classString == "_datatype")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_assignment" && Tokens[tokenIndex].wordString == "=") // to be confirmed
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_comma")
            {
                tokenIndex++;
                if (Tokens[tokenIndex].classString == "_identifier")
                {
                    tokenIndex++;
                    if (Variable_Link2())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Tokens[tokenIndex].classString == "_terminator")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_or")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_and")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_relational")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_plus_minus")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_multiply_divide_mode")
            {
                tokenIndex++;
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
            if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
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
            else if (Tokens[tokenIndex].classString == "_not")
            {
                tokenIndex++;
                if (OP())
                {
                    return true;
                }
                else return false;
            }
            else if (Tokens[tokenIndex].classString == "_bracket_parentheses_open")
            {
                tokenIndex++;
                if (exp())
                {
                    if (Tokens[tokenIndex].classString == "_bracket_parentheses_close")
                    {
                        tokenIndex++;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Tokens[tokenIndex].classString == "_inc_dec")
            {
                tokenIndex++;
                if (Tokens[tokenIndex].classString == "_identifier")
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
            if (Tokens[tokenIndex].classString == "_bracket_parentheses_open")
            {
                tokenIndex++;
                if (List_Const())
                {
                    if (Tokens[tokenIndex].classString == "_bracket_parentheses_close")
                    {
                        tokenIndex++;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Tokens[tokenIndex].classString == "_bracket_square_open")
            {
                if (Id_Constant())
                {
                    if (Tokens[tokenIndex].classString == "_bracket_square_close")
                    {
                        tokenIndex++;
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
            else if (Tokens[tokenIndex].classString == "_inc_dec")
            {
                return true;
            }
            // Null case
            else return true;
        }

    }
}
