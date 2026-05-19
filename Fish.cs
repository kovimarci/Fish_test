using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishCs
{
    public class Fish
    {
        public int id { get; set; }
        public string type { get; set; }
        public double weight { get; set; }
        
        public Fish(int id, string type, double weight)
        {
            this.id = id;
            this.type = type;
            this.weight = weight;
        }
        public override string ToString()
        {
            return $"\t- {type}  [ {weight} kg ]";
        }
    }
}
