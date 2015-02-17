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

        using (StreamWriter sw = new StreamWriter("elore.ki"))
        {
            var table = a.Select(x => new { x, f1 = x.val.Max(), f2 = x.val.Average(), f3 = la(x.val, k) });
            sw.WriteLine(table.OrderByDescending(x => x.f1).First().x.i);
            sw.WriteLine(table.OrderByDescending(x => x.f2).First().x.i);
            var tn = table.OrderByDescending(x => x.f3).First();
            sw.WriteLine(tn.f3 == -1 ? -1 : tn.x.i);

            for (int i = 0; i < a[0].val.Count; i++)
            {
                var col = new List<int>();
                for (int j = 0; j < a.Count; j++)
                {
                    col.Add(a[j].val[i]);
                }
                var ap = col.Select((val, id) => new { id, val }).OrderByDescending(x => x.val).ToList();
                var p = ap[0].val == ap[1].val ? -1 : ap[0].id;
                if (p != -1)
                    a[p].n[0]++;
            }
            var b = a.Select(x => new { i = x.i, n = x.n[0], val = x.val }).OrderByDescending(x => x.n).ToList();
            var ki = (b[0].n == b[1].n && 0 == b[1].n) ? -1 : b[0].i;
            sw.WriteLine(ki);
        }
    }
    static int la(List<int> list, int k)
    {
        var p = string.Join("", list.Select(x => x > k ? 1 : 0)).Split('0').Max(x => x.Length);
        return  p == 0 ? -1:  p ;
    }
}

