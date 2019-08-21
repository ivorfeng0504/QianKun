using System;
using System.Collections.Generic;
using System.Text;
using QianKunHelper;

namespace CheckManagerModel
{
    public static class Const
    {
        /// <summary>
        /// Redis-HashId-品牌ID所属云
        /// </summary>
        public const string HashIdOfCloud = "Ezp.cloud.store";
        /// <summary>
        /// 腾讯云
        /// </summary>
        public const string Tcloud = "Ezp.T_cloud";
        /// <summary>
        /// UCloud
        /// </summary>
        public const string Ucloud = "Ezp.U_cloud";
        /// <summary>
        /// 微软东一
        /// </summary>
        public const string M1cloud = "Ezp.M1_cloud";
        /// <summary>
        /// 微软东二
        /// </summary>
        public const string M2cloud = "Ezp.M2_cloud";
        /// <summary>
        /// Redis-HashId-品牌基本信息
        /// </summary>
        public const string HashIdOfBrand = "{0}.brand.{1}";

        /// <summary>
        /// 数据库类型；0:MySql;1:SqlServer;2:Oracel
        /// </summary>
        public static int DataBaseType
        {
            get
            {
                var dbType = ConfigurationManager.AppSettings["DbType"];
                if (string.IsNullOrWhiteSpace(dbType))
                    throw new Exception("DbType is empty");
                return int.Parse(dbType);
            }
        }
    }
}
