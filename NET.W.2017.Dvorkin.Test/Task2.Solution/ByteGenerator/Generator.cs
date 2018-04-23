using System;

namespace Task_2
{
    public static class Generator
    {

        public static byte[] GenerateFileContent(int contentLength)
        {
            if (contentLength<0)
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