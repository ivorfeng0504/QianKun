using System;
using System.Collections.Generic;
using CheckManagerModel;

namespace CheckManagerBLL
{
    public class BrandInfoBll
    {
        public List<BrandInfo> GetBrandInfos()
        {
            return new List<BrandInfo>
            {
                new BrandInfo{BrandId =35,BrandName = "九牧王男装",CrmNum=1235,PosNum=895},
                new BrandInfo{BrandId =42,BrandName = "EVISU服饰",CrmNum=1235,PosNum=895},
                new BrandInfo{BrandId =24,BrandName = "红袖测试",CrmNum=1235,PosNum=895},
                new BrandInfo{BrandId =47,BrandName = "玛丽黛佳",CrmNum=1235,PosNum=895},
                new BrandInfo{BrandId =49,BrandName = "卡宾测试",CrmNum=1235,PosNum=895},
            };
        }
    }
}
