namespace Task5.Solution
{
    public class ConcretVisitor:Visitor
    {
        public string ConcretString { get; private set; }

        protected override void Visit(BoldText boldText)
        {
            ConcretString = boldText.Text;
        }

        protected override void Visit(Hyperlink hyperlink)
        {
            ConcretString = hyperlink.Url + hyperlink.Text;
        }

        protected override void Visit(PlainText plainText)
        {
            ConcretString = plainText.Text;
        }
    }
}