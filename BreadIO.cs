using System;
using System.IO;

/*
This code may be used for any purpose, no attribution required.
You may also modify the code in any way you like.

By: IEditCheezIts from Sometimes Bread.
*/

namespace BreadIO
{
    public static class BreadIO
    {

        /// <summary>
        /// Standard File Reading System used in Sometimes Bread Games. Should not be called too often as performance is not guaranteed. For better performance, use FastRead() instead.
        /// </summary>
        /// <param name="path"></param>
        public static string Read(string path)
        {
            if(File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string readString;
                    try
                    {
                        readString = sr.ReadToEnd();
                    }
                    catch(IOException)
                    {
                        return "IO Exception Error";
                    }
                    catch(OutOfMemoryException)
                    {
                        return "Out of memory Exception";
                    }
                    return readString;
                }
            }
            else
            {
                return "File Not Found at " + path + " or path is an empty string";
            }
        }

        /// <summary>
        /// Faster File Reading System used in Sometimes Bread Games. This can be called often (not reccomended for the sake of the poor HDD/SSD, but can be done). More Prone to errors than Read() since there are no error checks, but has better performance.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FastRead(string path)
        {
            using (StreamReader sr = File.OpenText(path)
            {
                return sr.ReadToEnd();
            }
        }

    }
}
