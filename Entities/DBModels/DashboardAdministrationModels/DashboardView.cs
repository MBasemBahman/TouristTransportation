﻿using Entities.EnumData;

namespace Entities.DBModels.DashboardAdministrationModels
{
    [Index(nameof(ViewPath), IsUnique = true)]
    public class DashboardView : LookUpEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(ViewPath))]
        public string ViewPath { get; set; }

        [DisplayName(nameof(Premissions))]
        public IList<AdministrationRolePremission> Premissions { get; set; }
    }
}
