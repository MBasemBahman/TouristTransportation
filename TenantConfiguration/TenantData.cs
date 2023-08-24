namespace TenantConfiguration
{
    public static class TenantData
    {
        public enum TenantEnvironments
        {
            Development,
        }

        public enum TenantApis
        {
            Authentication,
            CompanyTrip,
            Hotel,
            Post,
            MainData,
            Account,
            Car,
            Trip
        }

        public enum TenantViews
        {
            Home,

            // User
            User,
            RefreshToken,
            UserDevice,
            Verification,
            
            // Hotel
            Hotel,
            HotelAttachment,
            
            // Post
            Post,
            PostAttachment,
        }
    }
}
