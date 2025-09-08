namespace AccessControl.Server.Models {
    public class Log {

        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdDevice { get; set; }
        public DateTime Time { get; set; }
        public int Status { get; set; } = 0;
    }
}
