using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var a = File.ReadAllLines("kieses.be").Select(x => x.Trim().Split().Select(y => int.Parse(y)).ToList()).ToList();
        int n = a[0][0];
        a.RemoveAt(0);
        var range = Enumerable.Range(1, n).ToList();
        var ki = a.Select(x => x[0]);
        var kit = a.Select(x => x[1]);
        using (StreamWriter sw = new StreamWriter("kieses.ki"))
        {
            var f1 = range.Except(kit).ToList();
            sw.WriteLine(f1.Count + " " + string.Join(" ", f1));
            var f2 = ki.Intersect(kit).OrderBy(x => x).ToList();
            sw.WriteLine(f2.Count + " " + string.Join(" ", f2));
            var f3 = range.Select(x => new { x, y = gu(x, a) }).OrderByDescending(x => x.y).ToList();
            sw.WriteLine(f3.First().x);
        }
    }
    static int gu(int id, List<List<int>> a)
    {
        return a.Where(x => x[0] == id).Select(x => gu(x[1], a)).Sum() + 1;
    }
}

