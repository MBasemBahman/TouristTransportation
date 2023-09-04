using System.ComponentModel;
using Entities.CoreServicesModels.UserModels;
using Newtonsoft.Json;

namespace API.Models
{
    public class UserDto : UserModel
    {
        [JsonIgnore]
        public new int Id { get; set; }

        public int Fk_Account { get; set; }

        [JsonIgnore]
        public new string LastModifiedAt { get; set; }

        [JsonIgnore]
        public new string LastModifiedBy { get; set; }

        [JsonIgnore]
        public new string CreatedBy { get; set; }

        [JsonIgnore]
        public new string CreatedAt { get; set; }
    }

    public class AuthForEditDto : UserForEditDto
    {
        [DisplayName(nameof(ImageFile))] 
        public IFormFile ImageFile { get; set; }
    }
}
