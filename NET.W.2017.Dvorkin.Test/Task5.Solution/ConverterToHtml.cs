namespace Task5
{
    public class ConverterToHtml : DocumentPartVisitor
    {
        public string Line { get; private set; }

        protected override string Visit(PlainText plain)
        {
            return Line += plain.Text;
        }

        protected override string Visit(Hyperlink hyperlink)
        {
            return Line += "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>";
        }

        protected override string Visit(BoldText bold)
        {
            return Line += "<b>" + bold.Text + "</b>";
        }
    }
}