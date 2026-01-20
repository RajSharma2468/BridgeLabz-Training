using Models;
using Algorithms;

namespace Services
{
    public class AadhaarService
    {
        private AadhaarRecord[] records;
        private int index = 0;

        public AadhaarService(int size)
        {
            records = new AadhaarRecord[size];
        }

        public void AddRecord(long aadhaar, string name)
        {
            records[index++] = new AadhaarRecord(aadhaar, name);
        }

        public void SortRecords()
        {
            RadixSorter.Sort(records);
        }

        public int SearchRecord(long aadhaar)
        {
            return BinarySearcher.Search(records, aadhaar);
        }

        public AadhaarRecord[] GetAllRecords()
        {
            return records;
        }
    }
}
