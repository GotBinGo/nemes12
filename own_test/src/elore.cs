﻿using System;
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
        var a = File.ReadAllLines("elore.be").Select(x => x.Split().Select(y => int.Parse(y)).ToList()).Select((val, i) => new { n = tmp.ToList(), i, val }).ToList();
        int k = a[0].val[2];
        a.RemoveAt(0);

        StreamWriter sw = new StreamWriter("elore.ki");
        var kn = a.Select(x => new {x, f1 = x.val.Max(), f2 = x.val.Average(), f3 = la(x.val, k) });
        sw.WriteLine(kn.OrderByDescending(x => x.f1).First().x.i);
        sw.WriteLine(kn.OrderByDescending(x => x.f2).First().x.i);        
        var tn = kn.OrderByDescending(x => x.f3).First();
        sw.WriteLine(tn.f3 == -1 ? -1 : tn.x.i );
        
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
        
        sw.Flush();
    }
    static int la(List<int> list, int k)
    {
        int nm = -1;
        int n = 0;
        for (int i = 0; i < list.Count; i++)
        {
            n = list[i] > k ? n + 1 : 0;
            nm = n > nm ? n : nm;			
        }
        if (nm == 0)
            return -1;
        return nm;
    }
}

