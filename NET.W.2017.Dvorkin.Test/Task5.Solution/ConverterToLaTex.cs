namespace Task5
{
    public class ConverterToLaTex : DocumentPartVisitor
    {
        public string Line { get; private set; }

        protected override string Visit(PlainText plain)
        {
            return Line += plain.Text;
        }

        protected override string Visit(Hyperlink hyperlink)
        {
            return Line += "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}";
        }

        protected override string Visit(BoldText bold)
        {
            return Line += "\\textbf{" + bold.Text + "}";
        }
    }
}