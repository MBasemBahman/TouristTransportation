using Entities.DBModels.AccountModels;
using Entities.EnumData;

namespace Entities.DBModels.MainDataModels;

public class Supplier : AuditEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName(nameof(Name))]
    public string Name { get; set; }

    [DisplayName(nameof(Accounts))]
    public List<Account> Accounts { get; set; }

    public List<SupplierLang> SupplierLangs { get; set; }
}

public class SupplierLang : AuditLangEntity<Supplier>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}