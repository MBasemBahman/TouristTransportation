using Entities.DBModels.HotelModels;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelSelectedFeaturesParameters : RequestParameters
    {
        public int Fk_Hotel { get; set; }   
        public int Fk_HotelFeature { get; set; }   
    }

    public class HotelSelectedFeaturesModel : AuditEntity
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }
    
        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }
    
        [DisplayName(nameof(HotelFeature))]
        [ForeignKey(nameof(HotelFeature))]
        public int Fk_HotelFeature { get; set; }
    
        [DisplayName(nameof(HotelFeature))]
        public HotelFeatureModel HotelFeature { get; set; }
    }

    public class HotelSelectedFeaturesCreateOrEditModel
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }
    
        [DisplayName(nameof(HotelFeature))]
        [ForeignKey(nameof(HotelFeature))]
        public int Fk_HotelFeature { get; set; }
    }
}
