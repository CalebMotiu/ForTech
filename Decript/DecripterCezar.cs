using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Decript
{
    public class DecripterCezar
    {
        public static void Decript(string txt)
        {
            string txtCriptat = txt;
            txtCriptat = txtCriptat.Replace("^","");
            txtCriptat = txtCriptat.Replace("~", "");
            Decript1(txtCriptat);
        }
        public static void Decript1(string txtCriptat)
        {
            txtCriptat = txtCriptat.Replace("{", " ");
            txtCriptat = txtCriptat.Replace("}", " ");
            txtCriptat = txtCriptat.Replace("(", " ");
            txtCriptat = txtCriptat.Replace(")", " ");
            Decript2(txtCriptat);

        }
        
        public static void Decript2(string txtCriptat) 
        {
            for (int i = 0; i < txtCriptat.Length; i++)
            {  
                if (int.TryParse(Convert.ToString(txtCriptat[i]), out int result))
                {
                   txtCriptat = txtCriptat.Replace(txtCriptat[i],Constants.Alphabet[result]);
                }
            }
            Decript3(txtCriptat);
        }

        public static void Decript3(string txtCriptat)
        {
            
                char[] charArray = txtCriptat.ToCharArray();
                Array.Reverse(charArray);
                txtCriptat= charArray.ToString();
            for (int i = 0; i < charArray.Length; i++)
            {
                 Decript4(charArray[i], Constants.Alphabet.IndexOf(Constants.Key[i % Constants.Key.Length]));
            }

        }
        public static void Decript4(char encryptedLetter, int shift)
            { 
                int indexOfEncryptedLetter = Constants.Alphabet.IndexOf(encryptedLetter);
                indexOfEncryptedLetter -= shift;
                if (indexOfEncryptedLetter < 0)
                {
                    indexOfEncryptedLetter += Constants.Alphabet.Length;
                }
            char decriptat = Constants.Alphabet[indexOfEncryptedLetter];
            Console.Write(decriptat);
            }
       
       
    }
}
