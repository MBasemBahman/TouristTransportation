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
            Post = 20,
            PostAttachment = 21,
            PostReaction = 22,
            Hotel = 23,
            HotelAttachment = 24,
            CarClass = 25,
            CarCategory = 26,
            TripState = 27,
            HotelFeatureCategory = 28,
            HotelFeature = 29,
            CompanyTrip = 30,
            CompanyTripAttachment = 31,
            CompanyTripBooking = 32,
            CompanyTripBookingState = 33,
            Trip = 34,
            TripPoint = 35
        }

        public enum AccountProfileItems
        {
            Details = 1,
            Trips = 2,
            CompanyTripBooking = 3
        }

        public enum CompanyTripProfileItems
        {
            Details = 1,
            Attachments = 2,
            CompanyTripBooking = 3
        }
        
        public enum TripProfileItems
        {
            Details = 1,
            TripPoints = 2,
        }

        public enum TripReturnItems
        {
            Index = 1,
            AccountProfile = 2,
        }
        
        public enum CompanyTripBookingCreateOrEditTargetProfile
        {
            Account = 1,
            CompanyTrip = 2
        }

        public enum ReactionEnum
        {
            Like = 1,
        }

        public enum AccountStateEnum
        {
            Active = 1,
            Pending = 2,
            Pan = 3
        }

        public enum AccountTypeEnum
        {
            Client = 1,
            Driver = 2,
            Seller = 3,
        }

        public enum LanguageEnum
        {
            en,
            fr,
            de,
            ru,
            tl
        }

        public enum CompanyTripStateEnum
        {
            Pending = 1,
            Active = 2,
            Canceled = 3,
            Expired = 4
        }

        public enum CompanyTripBookingStateEnum
        {
            Pending = 1,
            PendingOnPayment = 2,
            Booked = 3,
            Canceled = 4,
        }



        public enum TripStateEnum
        {
            Pending = 1,
            PendingOnPayment = 2,
            Booked = 3,
            Done = 4,
            Canceled = 5
        }
    }
}
