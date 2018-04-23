using System;
using System.IO;
using System.Threading;

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
                var generatedFileContent = Generator.GenerateFileContentByte(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{FileExtension}";

                WriteBytesToFile(WorkingDirectory, generatedFileName, generatedFileContent);
            }
        }
    }
}