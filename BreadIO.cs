using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*
This code may be used for any purpose, no attribution required.
You may also modify the code in any way you like.

By: IEditCheezIts from Sometimes Bread.
*/


public class BreadIO
{ 
    //read files

    /// <summary>
    /// Standard File Reading System used in Sometimes Bread Games. Should not be called too often as performance is not guaranteed. For better performance, use FastRead() instead.
    /// </summary>
    /// <param name="path"></param>
    public static string Read(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string readString;
                try
                {
                    readString = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception)
                {
                    sr.Close();
                    return null;
                }
                return readString;
            }
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Faster File Reading System used in Sometimes Bread Games. This can be called often (not reccomended for the sake of the poor HDD/SSD, but can be done). More Prone to errors than Read() since there are no error checks, but has better performance.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string FastRead(string path)
    {
        using (StreamReader sr = File.OpenText(path))
        {
            return sr.ReadToEnd();
        }
    }

    /// <summary>
    /// Standard File Reading System for more secure files used in Sometimes Bread Games. Is not fully safe, but safer than non serialized files. Should not be called to often as performance is not guaranteed.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ReadSerialized(string path)
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            string readData = bf.Deserialize(fs) as string;
            fs.Close();
            return readData;
        }
        else
        {
            return null;
        }
    }

    //write to files

    /// <summary>
    /// Standard File Writing System used in Sometimes Bread Games. Its not really that much code but still. This can be called often (not reccomended for the sake of the poor HDD/SSD, but can be done).
    /// </summary>
    /// <param name="path"></param>
    /// <param name="text"></param>
    public static void Write(string path, string text)
    {
        File.WriteAllText(path, text);
    }

    //write serialized

    /// <summary>
    /// Standard File Writing System for more secure files used in Sometimes Bread Games. Is not fully safe, but safer than non serialized files. Should not be called too often as performance is not guaranteed.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="text"></param>
    public static void WriteSerialized(string path, string text)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        bf.Serialize(fs, text);
        fs.Close();
    }

}
