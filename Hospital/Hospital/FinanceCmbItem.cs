using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    public class FinanceCmbItem {
        public string Type { get; set; }
        public int Cost { get; set; }

        public override string ToString() {
            return Type;
        }
    }
}
