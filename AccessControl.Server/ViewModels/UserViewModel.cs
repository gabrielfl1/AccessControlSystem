using System.ComponentModel.DataAnnotations;

namespace AccessControl.Server.ViewModels {
    public class UserViewModel {

        [Required(ErrorMessage = "Informe o Nome")]
        public string Name { get; set; }
    }
}
