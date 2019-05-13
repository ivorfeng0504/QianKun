namespace CheckManagerModel.DbModels
{
    public class Pf_sys_db_shard_nodes
    {
        public int Id { get; set; }
        public int DbShardingId { get; set; }
        public string IsMaster { get; set; }
        public string DbConnString { get; set; }
    }
}
