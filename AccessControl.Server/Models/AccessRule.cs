namespace AccessControl.Server.Models {
    public class AccessRule {

        public long Id{ get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        public IList<Device> Devices { get; set; }
        public IList<Schedule> Schedules { get; set; }
    }
}
