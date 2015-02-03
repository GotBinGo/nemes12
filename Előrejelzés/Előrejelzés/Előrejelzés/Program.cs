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
        var tmp = new List<int>();
        tmp.Add(0);
        var a = File.ReadAllLines("elore.be").Select(x => x.Split().Select(y => int.Parse(y)).ToList()).ToList().Select((val, i) => new { n = tmp.ToList(), i, val }).ToList();
        int k = a[0].val[2];

        a.RemoveAt(0);
        StreamWriter sw = new StreamWriter("elore.ki");
        {
            int maxIndex = -1;
            int maxValue = -1;
            a.ForEach(x => { if (x.val.Max() > maxValue) { maxValue = x.val.Max(); maxIndex = x.i; } });
            sw.WriteLine(maxIndex);
        }
        {
            double maxIndex = -1;
            double maxValue = -1;
            a.ForEach(x => { if (x.val.Average() > maxValue) { maxValue = x.val.Average(); maxIndex = x.i; } });
            sw.WriteLine(maxIndex);
        }
        {
            double maxIndex = -1;
            double maxValue = -1;
            a.ForEach(x => { if (la(x.val, k) > maxValue) { maxValue = la(x.val, k); maxIndex = x.i; } });
            sw.WriteLine(maxIndex);
        }

        for (int i = 0; i < a[0].val.Count; i++)
        {
            var col = new List<int>();
            for (int j = 0; j < a.Count; j++)
            {
                col.Add(a[j].val[i]);
            }
            var p = lg(col);
            if(p!= -1)
                a[p].n[0]++;
            
        }
        var b = a.Select(x => new { i = x.i, n = x.n[0], val = x.val });
        var c = b.OrderByDescending(x=>x.n).ToList();
        var ki = (c[0].n == c[1].n && 0== c[1].n) ? -1 : c[0].i;

        sw.WriteLine(ki);
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
        if (nm == 0)
            return -1;
        return nm;
    }
    static int lg(List<int> list)
    {
        var a = list.Select((val, i) => new { i, val }).OrderByDescending(x=>x.val).ToList();
        return a[0].val == a[1].val ? -1 : a[0].i;
    }
}

