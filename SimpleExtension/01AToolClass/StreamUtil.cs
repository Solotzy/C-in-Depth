using System.IO;

namespace _01AToolClass
{
    //public static class StreamUtil
    //{
    //    const int BufferSize = 8192;

    //    public static void CopyTo(this Stream input, Stream output)
    //    {
    //        byte[] buffer = new byte[BufferSize];
    //        int read;
    //        while ((read = input.Read(buffer,0,buffer.Length))>0)
    //        {
    //            output.Write(buffer, 0, read);
    //        }
    //    }

    //    public static byte[] ReadFully(this Stream input)
    //    {
    //        using (MemoryStream tempStream = new MemoryStream())
    //        {
    //            input.CopyTo(tempStream);
    //            return tempStream.ToArray();
    //        }
    //    }
    //}
}