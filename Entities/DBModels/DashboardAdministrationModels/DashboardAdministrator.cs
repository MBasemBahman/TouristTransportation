﻿using Entities.DBModels.UserModels;

namespace Entities.DBModels.DashboardAdministrationModels
{
    public class DashboardAdministrator : AuditEntity
    {
        #region User

        [DisplayName(nameof(User))]
        [ForeignKey(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName(nameof(User))]
        public User User { get; set; }

        #endregion

        [DisplayName(nameof(JobTitle))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string JobTitle { get; set; }

        #region DashboardAdministrationRole

        [ForeignKey(nameof(DashboardAdministrationRole))]
        [DisplayName(nameof(DashboardAdministrationRole))]
        public int Fk_DashboardAdministrationRole { get; set; }

        [DisplayName(nameof(DashboardAdministrationRole))]
        public DashboardAdministrationRole DashboardAdministrationRole { get; set; }

        #endregion
    }
}
