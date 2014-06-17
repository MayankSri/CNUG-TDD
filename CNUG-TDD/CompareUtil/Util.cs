using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareUtil {

    public class Util {
        
        public string Compare<T>(T a, T b) where T : IComparable {
            return a.Equals(b) ? "Equal" : "Not Equal";
        }
    }
}
