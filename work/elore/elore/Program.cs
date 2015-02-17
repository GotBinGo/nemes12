using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var tmp = new List<int>();
        tmp.Add(0);
        var a = File.ReadAllLines("elore.be").Select(x => x.Split().Select(y => int.Parse(y)).ToList()).Select((val, i) => new { n = tmp.ToList(), i, val }).ToList();
        int k = a[0].val[2];
        a.RemoveAt(0);

        var table = a.Select(x => new { x, f1 = x.val.Max(), f2 = x.val.Average(), f3 = la(x.val, k) });
        var tn = table.OrderByDescending(x => x.f3).First();
        for (int i = 0; i < a[0].val.Count; i++)
        {
            var col = new List<int>();
            for (int j = 0; j < a.Count; j++)
                col.Add(a[j].val[i]);

            var sor = col.Select((val, id) => new { id, val }).OrderByDescending(x => x.val).ToList();
            var max_or_error = sor[0].val == sor[1].val ? -1 : sor[0].id;
            if (max_or_error != -1)
                a[max_or_error].n[0]++;
        }
        var sor2 = a.Select(x => new { i = x.i, n = x.n[0], val = x.val }).OrderByDescending(x => x.n).ToList();
        var max_or_error2 = (sor2[0].n == sor2[1].n && 0 == sor2[1].n) ? -1 : sor2[0].i;

        using (StreamWriter sw = new StreamWriter("elore.ki"))
        {
            sw.WriteLine(table.OrderByDescending(x => x.f1).First().x.i);
            sw.WriteLine(table.OrderByDescending(x => x.f2).First().x.i);
            sw.WriteLine(tn.f3 == -1 ? -1 : tn.x.i);
            sw.WriteLine(max_or_error2);
        }
    }
    static int la(List<int> list, int k)
    {
        var p = string.Join("", list.Select(x => x > k ? 1 : 0)).Split('0').Max(x => x.Length);
        return p == 0 ? -1 : p;
    }
}

