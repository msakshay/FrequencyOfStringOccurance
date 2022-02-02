using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'frequency' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING s as parameter.
     */

    public static List<int> frequency(string s)
    {
        List<int> lst = new List<int>();
        int[] result = new int[26];


        for(int i=0;i<s.Length;)
        {
            int count=1;
            int number;
            if (i + 1 < s.Length && s[i + 1] == '(' )
            {
                int countStartIndex = i + 2;
                int countEndIndex = s.IndexOf(')', i + 2);
                count = Convert.ToInt32(s.Substring(countStartIndex, countEndIndex - countStartIndex));
                //count = Convert.ToInt32(Convert.ToString(s[i + 2]));
                number = Convert.ToInt32(s.Substring(i, 1));
                result[number-1] += count;
                i += 2 + countEndIndex- countStartIndex+1;
                continue;
            }

            if (i + 2 < s.Length && s[i+2] == '#' && i+3<s.Length&&s[i+3]=='(')
            {
                int countStartIndex = i + 4;
                int countEndIndex = s.IndexOf(')', i + 4);
                count = Convert.ToInt32(s.Substring(countStartIndex, countEndIndex - countStartIndex));
                //count = Convert.ToInt32(Convert.ToString(s[i + 4]));
                number = Convert.ToInt32(s.Substring(i, 2));
                result[number-1] += count;
                //i = i + 6;
                i += 4 + countEndIndex - countStartIndex + 1;
                continue;
            }
            if (i + 2 < s.Length && s[i + 2] == '#')
            {
                number = Convert.ToInt32(s.Substring(i, 2));
                result[number - 1] += count;
                i = i + 3;
                continue;
            }
            else
            {
                number = Convert.ToInt32(s.Substring(i, 1));
                result[number - 1] += count;
                i = i + 1;
            }
        }


        return result.ToList();

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string s = Console.ReadLine();

        //List<int> result = Result.frequency(s);

        //textWriter.WriteLine(String.Join("\n", result));

        //textWriter.Flush();
        //textWriter.Close();

        string s = "1(2)22#(34)22#5";
        List<int> result = Result.frequency(s);
        foreach(int val in result)
        {
            Console.Write(val + " ");
        }

        Console.ReadLine();


    }
}
