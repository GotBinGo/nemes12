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
        var a = File.ReadAllLines("jatek.be");
        int n = int.Parse(a[0].Split()[1]);
        var ab = a[1].Split().ToList();
        int sum = 0;
        while (n > 0)
        {
            var b = ab.Select((x, i) => new { i, val = int.Parse(x) }).ToList();
            var c = b.Zip(b.Skip(1), (x, y) => new { x, y, su = x.val + y.val }).OrderByDescending(x => x.su).First();
            ab.RemoveAt(c.y.i);
            ab.RemoveAt(c.x.i);
            n--;
            sum += c.su;
        }

        using (StreamWriter sw = new StreamWriter("jatek.ki"))
            sw.WriteLine(sum);
    }
}

