using System.Collections.Generic;
using CheckManagerModel;

namespace CheckManagerDAL.IDal
{
    public interface IBrandInfoDal
    {
        List<BrandInfo> GetBrandInfoList();
    }
}