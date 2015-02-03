using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kieses
{
    class Program
    {
        static void Main(string[] args)
        {
            int asd = 0;
            var ao = File.ReadAllLines("kieses.be");
                var a = ao.Select(x => x.Split().Select(y => int.TryParse(x,out asd) ? 0: int.Parse(y)).ToList()).ToList();
            int n = a[0][0];
            a.RemoveAt(0);
            var ba = Enumerable.Range(1, n).ToList();
            List<int> ki = new List<int>();
            List<int> kit = new List<int>();
            a.ForEach(x=>{ki.Add(x[0]);kit.Add(x[1]);});

            StreamWriter sw = new StreamWriter("kieses.ki");

            var f1 = ba.Except(kit).ToList();

            sw.WriteLine(f1.Count + " " + string.Join(" ", f1));
            Console.WriteLine(f1.Count + " " + string.Join(" ", f1));
            var f2 = ki.Intersect(kit).ToList();
            sw.WriteLine(f2.Count + " " + string.Join(" ", f2));
            Console.WriteLine(f2.Count + " " + string.Join(" ", f2));
            var f3 = ba.Select(x=>new {x,y = gu(x,a)}).OrderByDescending(x=>x.y).ToList();
            sw.WriteLine(f3.First().x);
            Console.WriteLine(f3.First().x);
            sw.Flush();
            //ba.ForEach(x=>x);
           // var k = new {int a = 10};            
          //  k.a = 11;
        }
        static int gu(int id,List<List<int>> a)
        {
            int sum = 1;
            var b = a.Where(x => x[0] == id).ToList();
            b.ForEach(x=>sum += gu(x[1],a));
            return sum;
        }
    }
}
