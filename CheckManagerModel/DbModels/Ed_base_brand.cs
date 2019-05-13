namespace CheckManagerModel.DbModels
{
    public class Ed_base_brand
    {
        public int Id { get; set; }
        public int CopId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int CmsDbShardingId { get; set; }
        public int RtlDbShardingId { get; set; }
        public int CrmDbShardingId { get; set; }
    }
}