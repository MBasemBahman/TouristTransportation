using Entities.AuthenticationModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.AuditModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.DashboardAdministrationModels;
using Entities.DBModels.LogModels;
using Entities.DBModels.SharedModels;
using Entities.DBModels.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelBuilderConfig.Configurations.DashboardAdministrationModels;
using ModelBuilderConfig.Configurations.UserModels;
using Newtonsoft.Json;

namespace BaseDB
{
    public class BaseContext : DbContext
    {
        private readonly UserAuthenticatedDto _user;   
        public BaseContext(DbContextOptions options, UserAuthenticatedDto user) : base(options)
        {
            _user = user;
        }

        #region LogModels

        public DbSet<Log> Logs { get; set; }

        #endregion

        #region UserModels

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        #endregion

        #region DashboardAdministrationModels

        public DbSet<AdministrationRolePremission> AdministrationRolePremissions { get; set; }
        public DbSet<DashboardAccessLevel> DashboardAccessLevels { get; set; }
        public DbSet<DashboardAdministrationRole> DashboardAdministrationRoles { get; set; }
        public DbSet<DashboardAdministrator> DashboardAdministrators { get; set; }
        public DbSet<DashboardView> DashboardViews { get; set; }

        #endregion

        #region Account
        public DbSet<Account> Accounts { get; set; }
        #endregion
        
        #region CompanyTrip
        public DbSet<CompanyTrip> CompanyTrips { get; set; }
        public DbSet<CompanyTripBooking> CompanyTripBookings { get; set; }
        #endregion

        #region Audit Models
        public DbSet<Audit> Audits { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("CreatedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(AuditEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("LastModifiedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            #region UserModels
            _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
            #endregion

            #region DashboardAdministrationModels

            _ = modelBuilder.ApplyConfiguration(new DashboardAccessLevelConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAccessLevelLangConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministrationRoleConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministrationRoleLangConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AdministrationRolePremissionConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DashboardAdministratorConfiguration());

            #endregion
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _ = OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default
        )
        {
            List<AuditEntry> auditEntries = OnBeforeSaving();
            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaving(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            DateTime utcNow = DateTime.UtcNow;

            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity is AuditEntity audittrackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            audittrackable.LastModifiedAt = utcNow;
                            audittrackable.LastModifiedBy = _user?.Name;
                            entry.Property(nameof(AuditEntity.CreatedAt)).IsModified = false;
                            break;

                        case EntityState.Added:
                            audittrackable.CreatedAt = utcNow;
                            audittrackable.CreatedBy = _user?.Name;
                            audittrackable.LastModifiedBy = _user?.Name;
                            audittrackable.LastModifiedAt = utcNow;
                            break;
                    }
                }
                else if (entry.Entity is BaseEntity basetrackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.Property(nameof(BaseEntity.CreatedAt)).IsModified = false;
                            break;

                        case EntityState.Added:
                            basetrackable.CreatedAt = utcNow;
                            break;
                    }
                }
            }


            ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = new();
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                AuditEntry auditEntry = new(entry)
                {
                    TableName = entry.Metadata.GetTableName() // EF Core 3.1: entry.Metadata.GetTableName();
                };
                if (entry.Properties.Any(a => a.Metadata.Name == "LastModifiedBy") &&
                      entry.Properties.Where(a => a.Metadata.Name == "LastModifiedBy").FirstOrDefault().CurrentValue != null)
                {
                    auditEntry.CreatedBy = entry.Properties.Where(a => a.Metadata.Name == "LastModifiedBy").FirstOrDefault().CurrentValue.ToString();
                }
                else if (entry.Properties.Any(a => a.Metadata.Name == "CreatedBy") &&
                  entry.Properties.Where(a => a.Metadata.Name == "CreatedBy").FirstOrDefault().CurrentValue != null)
                {
                    auditEntry.CreatedBy = entry.Properties.Where(a => a.Metadata.Name == "CreatedBy").FirstOrDefault().CurrentValue.ToString();
                }

                auditEntries.Add(auditEntry);

                foreach (PropertyEntry property in entry.Properties)
                {
                    // The following condition is ok with EF Core 2.2 onwards.
                    // If you are using EF Core 2.1, you may need to change the following condition to support navigation properties: https://github.com/dotnet/efcore/issues/17700
                    // if (property.IsTemporary || (entry.State == EntityState.Added && property.Metadata.IsForeignKey()))
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (AuditEntry auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                _ = Audits.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaving(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
            {
                return Task.CompletedTask;
            }

            foreach (AuditEntry auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (PropertyEntry prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                _ = Audits.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }


        public class AuditEntry
        {
            public AuditEntry(EntityEntry entry)
            {
                Entry = entry;
            }

            public EntityEntry Entry { get; }
            public string TableName { get; set; }
            public string CreatedBy { get; set; }
            public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
            public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
            public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
            public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

            public bool HasTemporaryProperties => TemporaryProperties.Any();

            public Audit ToAudit()
            {
                Audit audit = new()
                {
                    TableName = TableName,
                    CreatedBy = CreatedBy,
                    CreatedAt = DateTime.UtcNow,
                    KeyValues = JsonConvert.SerializeObject(KeyValues),
                    OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                    NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues)
                };
                return audit;
            }
        }
    }
}