using System;

namespace CheckManagerModel.DbModels
{
    public class Rtl_prod_detail
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 所属集团
        /// </summary>
        public int CopId { get; set; }
        /// <summary>
        /// 所属品牌
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// 商品ID （SpuId）商品表外键
        /// </summary>
        public int ProdId { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string SkuNo { get; set; }

        /// <summary>
        /// 商品明细名称（商品规格名称）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EName { get; set; }
        /// <summary>
        /// 外部编码
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 商品规格图片
        /// </summary>
        public string PictureUrl { get; set; }
        /// <summary>
        /// 吊牌价
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// 零售价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OldSkuNo { get; set; }
        /// <summary>
        /// 商品属性19
        /// </summary>
        public string AttrVal { get; set; }
        /// <summary>
        /// 虚拟值（页面使用）1
        /// </summary>
        public string VirtualId { get; set; }
        /// <summary>
        /// 是否有效（1：有效；0：无效）
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModifiedUser { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastModifiedDate { get; set; }
    }
}
