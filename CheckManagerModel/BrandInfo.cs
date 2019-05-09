using System;

namespace CheckManagerModel
{
    public class BrandInfo
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CrmNum { get; set; }
        public int PosNum { get; set; }

        public bool IsWarn => CrmNum != PosNum;
    }
}
