using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_2
{
    public class RandomCharsFileGenerator : Files
    {
        public string WorkingDirectory => "Files with random chars";

        public string FileExtension => ".txt";

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = Generator.GenerateFileContentString(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                WriteBytesToFile(WorkingDirectory, generatedFileName, generatedFileContent);
            }
        }
    }
}