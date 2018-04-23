using System;

namespace Task_2
{
    public class RandomBytesFileGenerator : Files
    {
        public override string WorkingDirectory => "Files with random bytes";

        public override string FileExtension => ".bytes";

        //public override void GenerateFiles(int filesCount, int contentLength)
        //{
            
        //}

        protected override byte[] GenerateFileContent(int contentLength)
        {
            if (contentLength < 0)
            {
                throw new ArgumentException($"{nameof(contentLength)} less than 0");
            }

            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}