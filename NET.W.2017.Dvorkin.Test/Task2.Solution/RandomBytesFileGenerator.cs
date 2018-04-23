using System;

namespace Task_2
{
    public class RandomBytesFileGenerator : Files
    {
        public string WorkingDirectory => "Files with random bytes";

        public string FileExtension => ".bytes";

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{FileExtension}";

                WriteBytesToFile(WorkingDirectory, generatedFileName, generatedFileContent);
            }
        }

        internal override byte[] GenerateFileContent(int contentLength)
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