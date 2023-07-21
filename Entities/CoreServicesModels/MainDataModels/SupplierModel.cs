using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.MainDataModels
{
    public class SupplierParameters : RequestParameters
    {
        
    }

    public class SupplierModel : AuditEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }
    }

    public class SupplierCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        public List<SupplierLangModel> SupplierLangs { get; set; }
    }
    
    public class SupplierLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
