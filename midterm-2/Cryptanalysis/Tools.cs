using System;

namespace Cryptanalysis
{
public static class Tools
{
    public static int Modulus(int a, int b)
    {
        if (b < 0)
            b = -b;
        
        var mod = a % b;
        return mod < 0 ? b + mod : mod;
    }

    public static int LetterIndex(char c)
    {
        int i = Convert.ToInt32(c);
        int ni = i;
        if (ni >= 65 && ni <= 90 ) ni -= 65;
        else if (ni >= 97 && ni <= 122) ni -= 97;
        else ni = -1;
        return ni;
    }
    
    public static char RotChar(char c, int n)
    {
        int gc = Convert.ToInt32(c);
        char res = c;
        if (gc >= 65 && gc <= 90 || gc >= 97 && gc <= 122)
        {
            int i = LetterIndex(c);
            
            if (i + n < 0)
            {
                int j = 0;
                while (i >= 0)
                {
                    i -= 1;
                    j += 1;
                }

                n += j;
                i = 25 + n;
            }
            else if (i + n > 25)
            {
                int j = 0;
                while (i <= 25)
                {
                    i += 1;
                    j += 1;
                }

                n -= j;
                i = 0 + n;
            }
            else
            {
                i += n;
            }

            if (Convert.ToInt32(c) <= 90) i += 65;
            if (Convert.ToInt32(c) >= 97) i += 97;
            res = Convert.ToChar(i);
        }

        return res;
    }

    public static int[] Histogram(string str)
    {
        int[] res = new int[26];
        int c = 0;
        for (int i = 0; i < str.Length; i++)
        {
            c = LetterIndex(str[i]);
            if (c!=-1) res[c] += 1;
        }
        return res;
    }
    
    public static string FilterLetters(string str)
    {
        string res = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 65 && str[i] <= 90 || str[i] >= 97 && str[i] <= 122) res += str[i];
        }

        return res;
    }

    public static string Extract(string str, int start, int step)
    {
        string res = "";
        for (int i = start; i < str.Length; i+=step)
        {
            res += str[i];
        }
        return res;
    }
}
}
