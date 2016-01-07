using System.Collections.Generic;

namespace TrueMedLib
{
    public class Constituents
    {
        public string generic_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public string strength { get; set; }
    }

    public class MedicineDetail
    {
        public Medicine medicine { get; set; }
        public List<Constituents> constituents { get; set; }
    }
}
