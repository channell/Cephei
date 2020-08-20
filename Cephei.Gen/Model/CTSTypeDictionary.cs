using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen.Model
{
    public class CTSTypeDictionary
    {
        private Dictionary<string, string> _dictionary;
        private Dictionary<string, string> _nativeDictionary;

        public CTSTypeDictionary()
        {
            string[,] src = { {"QL_INTEGER",      "Int32"},
                                    {"QL_BIG_INTEGER",  "Int64"},
                                    {"QL_REAL",         "Double"},
                                    {"Decimal",         "Double"},
                                    {"Time",            "Double"},
                                    {"DiscountFactor",  "Double"},
                                    {"Rate",            "Double"},
                                    {"Spread",          "Double"},
                                    {"Volatility",      "Double"},
                                    {"Real",            "Double"},
                                    {"Integer",         "Int32"},
                                    {"int",             "Int32"},
                                    {"BigInteger",      "Int64"},
                                    {"unsigned long",   "UInt64"},
                                    {"Date",            "DateTime"},
                                    {"Size",            "UInt64"},
                                    {"Natural",         "UInt32"},
                                    {"BigNatural",      "UInt64"},
                                    {"bool",            "Boolean"},
                                    {"double",          "Double"},
                                    {"std::string",     "String"},
                                    {"Probability",     "Double"}
                                 };

            string[,] nativesrc = { {"QL_INTEGER",  "QuantLib::QL_INTEGER"},
                                    {"QL_BIG_INTEGER",  "QuantLib::QL_BIG_INTEGER"},
                                    {"QL_REAL",         "QuantLib::QL_REAL"},
                                    {"Decimal",         "QuantLib::Decimal"},
                                    {"Time",            "QuantLib::Time"},
                                    {"DiscountFactor",  "QuantLib::DiscountFactor"},
                                    {"Rate",            "QuantLib::Rate"},
                                    {"Spread",          "QuantLib::Spread"},
                                    {"Volatility",      "QuantLib::Volatility"},
                                    {"Real",            "QuantLib::Real"},
                                    {"Integer",         "QuantLib::Integer"},
                                    {"int",             "int"},
                                    {"BigInteger",      "QuantLib::BigInteger"},
                                    {"unsigned long",   "unsigned long"},
                                    {"Date",            "QuantLib::Date"},
                                    {"Size",            "QuantLib::Size"},
                                    {"Natural",         "QuantLib::Natural"},
                                    {"BigNatural",      "QuantLib::BigNatural"},
                                    {"bool",            "bool"},
                                    {"double",          "double"},
                                    {"std::string",     "std::string"},
                                    {"Probability",     "QuantLib::Probability"}
                                 };

            _dictionary = new Dictionary<string, string>();
            _nativeDictionary = new Dictionary<string, string>();

            for (int c = 0; c < src.GetLength(0); c++)
            {
                _dictionary.Add(src[c, 0], src[c, 1]);
                _nativeDictionary.Add(nativesrc[c, 0], nativesrc[c, 1]);
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
        public string GetNative(string key)
        {
            if (_nativeDictionary.ContainsKey(key))
                return _nativeDictionary[key];
            return key;
        }
    }
}
