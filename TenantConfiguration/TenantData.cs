﻿namespace TenantConfiguration
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
            Hotel,
            Post,
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
