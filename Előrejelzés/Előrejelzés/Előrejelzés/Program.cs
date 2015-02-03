using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var a = File.ReadAllLines("elore.be").Select(x => x.Split().Select(y => int.Parse(y)).ToList()).ToList().Select((val, i) => new {n = 0, i, val}).ToList();
        int k = a[0].val[2];

        a.RemoveAt(0);
        StreamWriter sw = new StreamWriter("elore.ki");
        {
            int maxIndex = -1;
            int maxValue = -1;
            a.ForEach(x => { if (x.val.Max() > maxValue) { maxValue = x.val.Max(); maxIndex = x.i; } });
        }
        {
            double maxIndex = -1;
            double maxValue = -1;
            a.ForEach(x => { if (x.val.Average() > maxValue) { maxValue = x.val.Average(); maxIndex = x.i; } });
        }
        {
            double maxIndex = -1;
            double maxValue = -1;
            a.ForEach(x => { if (la(x.val, k) > maxValue) { maxValue = la(x.val, k); maxIndex = x.i; } });
        }
        sw.Flush();
    }
    static int la(List<int> list, int k)
    {
        int nm = -1;
        int n = 0;
        for (int i = 0; i < list.Count; i++)
        {
            n = list[i] > k ? n+1 : 0;
            nm = n > nm ? n : nm;
        }        
        return nm;
    }   
}

