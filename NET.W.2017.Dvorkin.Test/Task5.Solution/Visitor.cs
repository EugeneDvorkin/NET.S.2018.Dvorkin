namespace Task5.Solution
{
    public abstract class Visitor
    {
        public void TypeVisit(DocumentPart documentPart) => Visit((dynamic)documentPart);
        protected abstract void Visit(BoldText boldText);

        protected abstract void Visit(Hyperlink hyperlink);

        protected abstract void Visit(PlainText plainText);
    }
}
