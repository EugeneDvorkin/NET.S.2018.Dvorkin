namespace Solution
{
    //класс для описания аргументов события
    public class PrinterEventArg
    {
        private string name;
        private string model;

        public PrinterEventArg(string name, string model)
        {
            this.name = name;
            this.model = model;
        }

        public string Name => name;

        public string Model => model;

    }
}