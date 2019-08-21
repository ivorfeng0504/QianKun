using System;
using System.Data;

namespace CheckManagerModel
{
    public class BrandInfo
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CrmNum { get; set; }
        public int PosNum { get; set; }
        public string CrmDbConnectiong { get; set; }
        public string RtlDbConnectiong { get; set; }
        public bool IsWarn => CrmNum != PosNum;
        public DbType DbType { get; set; }
    }
}
