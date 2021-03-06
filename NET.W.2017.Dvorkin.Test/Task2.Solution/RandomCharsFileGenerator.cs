﻿using System;
using System.Linq;
using System.Text;

namespace Task_2
{
    public class RandomCharsFileGenerator : Files
    {
        public override string WorkingDirectory => "Files with random chars";

        public override string FileExtension => ".txt";

        protected override byte[] GenerateFileContent(int contentLength)
        {
            if (contentLength < 0)
            {
                throw new ArgumentException($"{nameof(contentLength)} less than 0");
            }

            var generatedString = RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private static string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }
}