namespace IridiumJS.Parser.Ast
{
    public class LabelledStatement : Statement
    {
        public Identifier Label;
        public Statement Body;
    }
}