using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var b = File.ReadAllLines("pakol.be").Select(x => x.Trim().Split().Select(y => int.Parse(y)).ToList()).ToList()[1];
        int n = 0;
        for (int i = 0; i < b.Count; i++)
        {
            while (b[i] != i + 1)
            {
                var tmp = b[b[i] - 1];
                b[b[i] - 1] = b[i];
                b[i] = tmp;
                n++;
            }
        }
        using (StreamWriter sw = new StreamWriter("pakol.ki"))
        {
            sw.WriteLine(n);
        }
    }
}
