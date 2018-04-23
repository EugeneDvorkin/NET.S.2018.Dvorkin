using System;
using System.IO;

namespace Task_2
{
    public abstract class Files
    {
        public abstract string WorkingDirectory { get; }
        public abstract string FileExtension { get; }

        private void WriteBytesToFile(string WorkingDirectory,string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{FileExtension}";

                WriteBytesToFile(WorkingDirectory, generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);
    }
}