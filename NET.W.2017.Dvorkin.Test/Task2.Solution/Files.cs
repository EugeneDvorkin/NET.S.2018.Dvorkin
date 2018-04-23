using System;
using System.IO;

namespace Task_2
{
    public abstract class Files
    {
        //public string WorkingDirectory;
        //public string FileExtension;

        internal void WriteBytesToFile(string WorkingDirectory,string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        internal void GenerateFile(string workingDirectory, string fileExtension, int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{fileExtension}";

                WriteBytesToFile(workingDirectory, generatedFileName, generatedFileContent);
            }
        }

        internal abstract byte[] GenerateFileContent(int contentLength);
    }
}