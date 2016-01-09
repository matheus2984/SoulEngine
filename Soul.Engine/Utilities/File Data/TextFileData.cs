using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Soul.Engine.Utilities.File_Data
{
    public sealed class TextFileData : IEnumerable<string>, IDisposable
    {
        private readonly IFileCryptography fileCryptography;
        private readonly string filePath;
        private readonly string relativePath;
        private readonly StreamReader streamReader;
        private int CurrentLine { get; set; }

        public TextFileData(string filePath, IFileCryptography crypto = null)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File '" + filePath + "' not found.");

            fileCryptography = crypto;
            this.filePath = filePath;
            relativePath = Path.GetDirectoryName(Path.GetFullPath(filePath));

            if (fileCryptography != null)
            {
                byte[] data = File.ReadAllBytes(filePath);
                fileCryptography.Decrypt(data);
                streamReader = new StreamReader(new MemoryStream(data));
                return;
            }

            streamReader = new StreamReader(filePath);
        }

        public void Dispose()
        {
            streamReader.Close();
        }

        public IEnumerator<string> GetEnumerator()
        {
            string line;

            // Until EOF
            while ((line = streamReader.ReadLine()) != null)
            {
                CurrentLine++;

                line = line.Trim();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Ignore very short or commented lines
                if (line.Length < 2 || line[0] == '!' || line[0] == ';' || line[0] == '#' || line.StartsWith("//") ||
                    line.StartsWith("--"))
                    continue;

                // Include files
                bool require = false, divert = false;
                if (line.StartsWith("include ") || (require = line.StartsWith("require ")) ||
                    (divert = line.StartsWith("divert ")))
                {
                    string fileName = line.Substring(line.IndexOf(' ')).Trim(' ', '"');
                    string includeFilePath = Path.Combine((!fileName.StartsWith("/") ? relativePath : ""),
                        fileName.TrimStart('/'));

                    // Prevent recursive including
                    if (includeFilePath != filePath)
                        // Silently ignore failed includes, only raise an
                        // exception on require.
                        if (File.Exists(includeFilePath))
                        {
                            using (var fr = new TextFileData(includeFilePath, fileCryptography))
                                foreach (string incLine in fr)
                                    yield return incLine;

                            // Stop reading current file if divert was successful
                            if (divert)
                                yield break;
                        }
                        else if (require)
                            throw new FileNotFoundException("Required file '" + includeFilePath + "' not found.");

                    continue;
                }

                yield return line;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}