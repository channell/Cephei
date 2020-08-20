using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen.Model
{
    public class Attribute
    {
        public string Name;
        public string Value;
        public int Pos;

        public Attribute(string name, string value, int pos)
        {
            Name = name;
            Value = value;
            Pos = pos;
        }
    }
}
