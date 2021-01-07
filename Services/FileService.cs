using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace ReceitaFederal.Services
{
    class FileService
    {
        static string FileNotFoundMsg = "File not found";

        public static string[] GetFilesInDir(string path)
        {
            return Directory.GetFiles(path);
        }
        public static string ReadInChunks(long offset, long limit, string path)
        {
            StringBuilder resultAsString = new StringBuilder();
            MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(path);
            MemoryMappedViewStream memoryMappedViewStream = memoryMappedFile.CreateViewStream(offset, limit,MemoryMappedFileAccess.Read);
            {
                for (long i = offset; i < limit; i++)
                {
                    //Reads a byte from a stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
                    int result = memoryMappedViewStream.ReadByte();
                    if (result == -1)
                    {
                        break;
                    }
                    char letter = (char)result;
                    resultAsString.Append(letter);
                }
            }
            Console.WriteLine(resultAsString.ToString());
            memoryMappedViewStream.Close();
            memoryMappedFile.Dispose();
            return resultAsString.ToString();
        }


        public static void ReadFile(string path)
        {
            if (File.Exists(path) == false)
            {
                Console.WriteLine(FileNotFoundMsg);
                return;
            }

            //long FileSizeInBytes = new FileInfo(path).Length;

            long FileSizeInBytes = new FileInfo(path).Length;

            long offset = 0;
            long Limit = 10000;

            while (offset <= FileSizeInBytes)
            {
                ReadInChunks(offset, Limit, path);
                offset += Limit;
                Limit += 100000;
            }

            Console.WriteLine(new FileInfo(path).Length);
        }


        public static string GetProjectRootPath()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        }
    }
}
