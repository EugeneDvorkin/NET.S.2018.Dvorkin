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

        internal abstract byte[] GenerateFileContent(int contentLength);
    }
}