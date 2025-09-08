namespace AccessControl.Server.Models {
    public class User {

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateStartLimit { get; set; }
        public DateTime? DateEndLimit { get; set; }
        public DateTime? DataLastLog{ get; set; }
        public uint? Pin{ get; set; }
        public ulong? Card{ get; set; }

        public List<AccessRule> AccessRules { get; set; }
    }
}
