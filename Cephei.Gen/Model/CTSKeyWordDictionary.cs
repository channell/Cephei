using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen.Model
{
    public class CTSKeyWordDictionary
    {
        private Dictionary<string, string> _dictionary;

        public CTSKeyWordDictionary()
        {
            string[,] src = {   {"in",      "p_in"},
                                    {"params",  "p_params"},
                                 };

            _dictionary = new Dictionary<string, string>();

            for (int c = 0; c < src.GetLength(0); c++)
            {
                _dictionary.Add(src[c, 0], src[c, 1]);
            }

        }
        public string this[string key]
        {
            get
            {
                if (_dictionary.ContainsKey(key))
                    return _dictionary[key];
                return key;
            }
        }
    }
}
