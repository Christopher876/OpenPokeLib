using System;

namespace OpenPokeLib.Utils
{
    public class GetItemInfo
    {
        public static Tuple<string,string> ReadInfo(string filename)
        {
            var text = System.IO.File.ReadAllLines(filename);
            var name = text[0];
            var description = text[1];
            return new Tuple<string, string>(name, description);
        }
    }
}