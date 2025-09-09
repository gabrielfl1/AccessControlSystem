using System.ComponentModel.DataAnnotations;

namespace AccessControl.Server.ViewModels {
    public class UserViewModel {

        [Required(ErrorMessage = "Informe o Nome")]
        public string Name { get; set; }

        public DateTime? DateStartLimit { get; set; }
        public DateTime? DateEndLimit { get; set; }
        public DateTime? DataLastLog { get; set; }
        public uint? Pin { get; set; }
        public ulong? Card { get; set; }
    }
}
