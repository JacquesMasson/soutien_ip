using System;

namespace Cryptanalysis
{
public class Vigenere
{
    public const float FrenchIndexOfCoincidence = 0.0778F;
    private string key;
    public Vigenere(string key)
    {
        if (key != "") this.key = key;
        else throw new ArgumentException("key is empty");
    }

    public string EqualLength(string msg)
    {
        string res = "";
        int i = 0;
        int j = 0;
        while (i < msg.Length)
        {
            if (Tools.LetterIndex(msg[i]) != -1)
            {
                if (j == key.Length) j = 0;
                res += key[j];
                j += 1;
            }
            else
            {
                res += msg[i];
            }
            i += 1;
        }
        return res;
    }
    public string Encrypt(string msg)
    {
        string res = "";
        string keyl = EqualLength(msg);
        for (int i = 0; i < msg.Length; i++)
        {
            res += Tools.RotChar(msg[i], Tools.LetterIndex(keyl[i]));
        }
        return res;
    }

    public string Decrypt(string cypherText)
    {
        string res = "";
        string keyl = EqualLength(cypherText);
        for (int i = 0; i < cypherText.Length; i++)
        {
            res += Tools.RotChar(cypherText[i], -Tools.LetterIndex(keyl[i]));
        }
        return res;
    }

    public static string GuessKeyWithLength(string cypherText, int keyLength)
    {
        throw new NotImplementedException();
    }
    
    public static float IndexOfCoincidence(string str)
    {
        throw new NotImplementedException();
    }

    public static int GuessKeyLength(string cypherText)
    {
        throw new NotImplementedException();
    }
    
    public static string GuessKey(string cypherText)
    {
        throw new NotImplementedException();
    }
}
}
