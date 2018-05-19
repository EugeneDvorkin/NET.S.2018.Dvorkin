namespace Task5
{
    public class ConverterToPlain : DocumentPartVisitor
    {
        public string Line { get; private set; }

        protected override string Visit(PlainText plain)
        {
            return Line += plain.Text;
        }

        protected override string Visit(Hyperlink hyperlink)
        {
            return Line += hyperlink.Text + " [" + hyperlink.Url + "]";
        }

        protected override string Visit(BoldText bold)
        {
            return Line += "**" + bold.Text + "**";
        }
    }
}