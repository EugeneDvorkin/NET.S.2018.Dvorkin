namespace Task5
{
    public abstract class DocumentPartVisitor
    {
        public void DynamicVisit(DocumentPart part) => Visit((dynamic) part);

        protected abstract string Visit(PlainText plain);

        protected abstract string Visit(Hyperlink hyperlink);

        protected abstract string Visit(BoldText bold);
    }
}