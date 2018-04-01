using System;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamsDemo
{
    //// C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    //// Chapter 15: Streams and I/O
    //// Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    //// https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    /// <summary>
    /// Contains StreamsExtension methods.
    /// </summary>
    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream.

        /// <summary>
        /// Implement by byte copy logic using class FileStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied bytes.</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int result = 0;
            int i;
            FileStream sourceFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            FileStream destinationFile = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);
            while ((i = sourceFile.ReadByte()) != -1)
            {
                destinationFile.WriteByte((byte)i);
                result++;
            }

            sourceFile.Dispose();
            destinationFile.Dispose();

            return result;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Implement by byte copy logic using class MemoryStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied bytes.</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            // TODO: step 1. Use StreamReader to read entire file in string
            StreamReader sourceReader = new StreamReader(sourcePath, Encoding.Default);
            string sourceFile = sourceReader.ReadToEnd();

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            byte[] sourceFileArray = Encoding.Default.GetBytes(sourceFile);
            ////byte[] fileArray = Encoding.Convert(Encoding.Default, Encoding.Unicode, sourceFileArray);

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            MemoryStream memoryStream = new MemoryStream(sourceFileArray);
            memoryStream.Write(sourceFileArray, 0, sourceFileArray.Length);

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            byte[] destinationFileArray = memoryStream.ToArray();

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            string destinationFile = Encoding.Default.GetString(destinationFileArray);

            // TODO: step 6. Use StreamWriter here to write char array content in new file
            StreamWriter writer = new StreamWriter(destinationPath);
            writer.WriteLine(destinationFile);
            sourceReader.Dispose();
            memoryStream.Dispose();
            writer.Dispose();

            return destinationFileArray.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Implement by block copy logic using FileStream buffer.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied bytes.</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            FileStream sourceFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None, 200000);
            FileStream destinationFile = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 200000);
            byte[] sourceByte = new byte[sourceFile.Length];
            while (sourceFile.Position < sourceFile.Length)
            {
                sourceFile.Read(sourceByte, 0, sourceByte.Length);
            }

            destinationFile.Write(sourceByte, 0, sourceByte.Length);
            int result = sourceByte.Length;
            sourceFile.Dispose();
            destinationFile.Dispose();

            return result;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Implement by block copy logic using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied bytes.</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            StreamReader sourceFile = new StreamReader(sourcePath, Encoding.Default);
            byte[] sourceByte = Encoding.Default.GetBytes(sourceFile.ReadToEnd());
            ////byte[] fileArray = Encoding.Convert(Encoding.Default, Encoding.Unicode, sourceByte);
            MemoryStream memoryStream = new MemoryStream(sourceByte);
            memoryStream.Write(sourceByte, 0, sourceByte.Length);
            byte[] destinationFileArray = memoryStream.ToArray();
            Buffer.BlockCopy(sourceByte, 0, destinationFileArray, 0, sourceByte.Length);
            string destinationFileString = Encoding.Default.GetString(destinationFileArray);
            StreamWriter streamWriter = new StreamWriter(destinationPath);
            streamWriter.Write(destinationFileString);
            int result = destinationFileArray.Length;
            sourceFile.Dispose();
            memoryStream.Dispose();
            streamWriter.Dispose();

            return result;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Implement by block copy logic using class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied bytes.</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            FileStream sourceFile = new FileStream(sourcePath, FileMode.Open);
            byte[] sourceByte = new byte[sourceFile.Length];
            sourceFile.Read(sourceByte, 0, sourceByte.Length);
            FileStream destinationFile = new FileStream(destinationPath, FileMode.Create);
            BufferedStream bufferedStream = new BufferedStream(destinationFile, 2000000);
            bufferedStream.Write(sourceByte, 0, sourceByte.Length);
            int result = sourceByte.Length;
            sourceFile.Dispose();
            bufferedStream.Dispose();
            destinationFile.Dispose();

            return result;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>Count of copied lines.</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            StreamReader streamReader = new StreamReader(sourcePath);
            StreamWriter streamWriter = new StreamWriter(destinationPath);
            string line;
            int result = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                streamWriter.WriteLine(line);
                result++;
            }

            streamReader.Dispose();
            streamWriter.Dispose();

            return result;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Determines whether [is content equals] [the specified source path].
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns>
        ///   <c>true</c> if [is content equals] [the specified source path]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            bool result = File.ReadAllBytes(sourcePath).SequenceEqual(File.ReadAllBytes(destinationPath));

            return result;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        /// <summary>
        /// Inputs the validation.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="ArgumentException">
        /// sourcePath is null or empty
        /// or
        /// destinationPath is null or empty
        /// or
        /// sourcePath file doesn't exist.
        /// </exception>
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} is incorrect");
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} is incorrect");
            }

            if (File.Exists(sourcePath) == false)
            {
                throw new ArgumentException($"{nameof(sourcePath)} is not exists current file");
            }
        }

        #endregion

        #endregion
    }
}
