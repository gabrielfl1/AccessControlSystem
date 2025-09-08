namespace AccessControl.Server.Models {
    public class Device {

        public long Id{ get; set; }
        public string Ip{ get; set; }
        public string Login{ get; set; }
        public string Password{ get; set; }
        public string Serial{ get; set; }
        public bool Status { get; set; }

        public IList<AccessRule> AccessRules { get; set; }

    }
}
