using System;

namespace Open_Lab_03._03
{
    public class Comparator
    {
        public bool CompareCharactersCount(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
