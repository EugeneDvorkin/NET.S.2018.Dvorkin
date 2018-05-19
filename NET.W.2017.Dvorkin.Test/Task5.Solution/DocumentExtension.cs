namespace Task5
{
    public static class DocumentExtension
    {
        public static string ToPlainText(this Document document)
        {
            var visitor = new ConverterToPlain();
            foreach (DocumentPart part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ToHtml(this Document document)
        {
            var visitor = new ConverterToHtml();
            foreach (DocumentPart part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ToLaTeX(this Document document)
        {
            var visitor = new ConverterToLaTex();
            foreach (DocumentPart part in document.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }
    }
}