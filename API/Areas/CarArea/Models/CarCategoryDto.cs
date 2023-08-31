using Entities.CoreServicesModels.CarModels;

namespace API.Areas.CarArea.Models
{
    public class CarCategoryDto : CarCategoryModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }

    public class CarCategoryCreateOrEditDto : CarCategoryCreateOrEditModel
    {
        public int? Fk_Account { get; set; }

        public List<IFormFile> AttachmentFiles { get; set; }
        public List<int> RmvAttachments { get; set; }
    }

}