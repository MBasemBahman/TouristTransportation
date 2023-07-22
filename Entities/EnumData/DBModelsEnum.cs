namespace Entities.EnumData
{
    public static class DBModelsEnum
    {
        public enum DashboardAccessLevelEnum
        {
            FullAccess = 1,
            DataControl = 2,
            Viewer = 3
        }

        public enum DashboardAdministrationRoleEnum
        {
            Developer = 1,
            Admin = 2,
        }

        public enum DashboardViewEnum
        {
            Home = 1,
            User = 2,
            DashboardAdministrator = 3,
            DashboardAccessLevel = 4,
            DashboardAdministrationRole = 5,
            DashboardView = 6,
            RefreshToken = 7,
            UserDevice = 8,
            Verification = 9,
            DBLogs = 10,
            Audit = 11,
            Account = 12,
            CompanyTripState = 13,
            AccountState = 14,
            AccountType = 15,
            Area = 16,
            Country = 17,
            Currency = 18,
            Supplier = 19,
            CarClass = 20,
            CarCategory = 21,
            TripState = 22,
            HotelFeatureCategory = 23,
            HotelFeature = 24
        }

        public enum AccountProfileItems
        {
            Details = 1,
            AccountCard = 2
        }

        public enum AccountReturnPage
        {
            Index = 1,
            Profile = 2
        }

        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        public enum ReactionEnum
        {
            Like = 1,
            Dislike = 2,
            Love = 3
        }

        public enum LanguageEnum
        {
            en,
            fr,
            de
        }
    }
}
