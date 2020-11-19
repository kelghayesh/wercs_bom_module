using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Gps.DepotClient.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG.Gps.DepotClient.Model.Wercs
{
    //PartPhysChem is a subset of the native (data transfer object) Part defined in GpsDepotClientModel.cs. The native part is what's received from the API
    //[Table("PartPhysChem")]
    public class WercsPartPhysChem
    {
        public string Key { get; set; }
        //public int? PlmTypeId { get; set; }
        //public int? PlmPolicyId { get; set; }
        //public int? PlmStateId { get; set; }
        //public int? PlmStageId { get; set; }
        public int? FormulationTypeId { get; set; }
        public string FormulationTypePickName { get; set; }
        public string SrcKey { get; set; }
        public string SrcRevision { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string McpManufacturerName { get; set; }
        public string TradeName { get; set; }
        public int? EnvironmentalClassId { get; set; }
        public string EnvironmentalClassPickName { get; set; }
        public int PartTypeId { get; set; }
        public string PartTypePickName { get; set; }
        public string PartStatusPickName { get; set; }
        public bool? IsForPass { get; set; }
        public bool? IsAllergen { get; set; }
        public int? PrimaryOrganizationId { get; set; }
        public string PrimaryOrganizationPickName { get; set; }
        public int? PartStatusId { get; set; }
        public int? GbuId { get; set; }
        public string GbuPickName { get; set; }
        public string RegistrationNumber { get; set; }
        public string ProductFormDetail { get; set; }
        public string ImportErrorMessage { get; set; }

        public PartBusinessArea BusinessArea { get; set; }
        public string BusinessAreaPickName { get; set; }

        public string PartProductCategoryPlatformName { get; set; }
        public string CategoryPickName { get; set; }
        public string ReachStatusPickName { get; set; }
        public string IngredientClassPickName { get; set; }

        public System.Collections.Generic.ICollection<PartAttribute> Attributes { get; set; } //What's this??! Always null

        public User GpsModifiedByUserName { get; set; }
       public bool? IsProduedByFormula { get; set; }
        public bool? IsExperimental { get; set; }
        //public int? AerosolTypeId { get; set; }
        //public string AerosolTypePickName { get; set; }
        public string ColorPickName { get; set; }
        public string ColorIntensityPickName { get; set; }
        public string Odor { get; set; }
        public string HeatOfCombustion { get; set; }
        public string HeatOfDecomposition { get; set; }
        public int? CanConstructionId { get; set; }
        public string CanConstructionPickName { get; set; }
        public string GaugePressure { get; set; }
        public int? AerosolTypeId { get; set; }
        public string AerosolTypePickName { get; set; }
        public int? IsAerosolTestDataNeededId { get; set; }
        public string IsAerosolTestDataNeededPickName { get; set; }
        public string IgnitionDistance { get; set; }
        public string FlameHeight { get; set; }
        public string FlameDuration { get; set; }
        public string VaporPressure { get; set; }
        public string VaporDensity { get; set; }
        public double? Ph { get; set; }
        public double? PhMax { get; set; }
        public double? PhMin { get; set; }
        public int? PhDilutionId { get; set; }
        public string PhDilutionPickName { get; set; }
        public int? CorrosivetoMetalsId { get; set; }
        public string CorrosivetoMetalsPickName { get; set; }
        public string TechnicalBasis { get; set; }
        public string AvailableOxygen { get; set; }
        public int? BoilingPointId { get; set; }
        public string BoilingPointPickName { get; set; }
        public string BoilingPointValue { get; set; }
        public int? ClosedCupFlashpointId { get; set; }
        public string ClosedCupFlashpointPickName { get; set; }
        public string ClosedCupFlashpointValue { get; set; }
        public string OrganicPeroxide { get; set; }
        public string DoestheProductContainsOxidizer { get; set; }
        public bool? OxidizerSodiumPerCarbonate { get; set; }
        public bool? OxidizerHydrogenPeroxide { get; set; }
        public string BurnRate { get; set; }
        public string SustainCombustion { get; set; }
        public string EvaporationRate { get; set; }
        public string KinematicViscosity { get; set; }
        public double? ReserveAcidity { get; set; }
        public double? ReserveAlkalinity { get; set; }
        public int? ReserveAlkalinityAcidityUomId { get; set; }
        public string ReserveAlkalinityAcidityUomPickName { get; set; }
        public string ReserveAlkalAcidPhTitration { get; set; }
        public bool? ContainsFlammableLiquid { get; set; }
        public int? PhAvailabilityId { get; set; }
        public string PhAvailabilityPickName { get; set; }
        public string SelfAcceleratingDecompTemp { get; set; }
        public string RelativeDensity { get; set; }
        public int? BatteryTypeId { get; set; }
        public string BatteryTypePickName { get; set; }
        //
        public bool? IsBattery { get; set; }
        public bool? ContainsBattery { get; set; }
        public string BatteryChemicalComposition { get; set; }
        public double? NumberOfCells { get; set; }
        public string BatteryWeight { get; set; }
        public int? BatteryWeightUomId { get; set; }
        public string BatteryWeightUomPickName { get; set; }
        public int? GramsOfLithiumId { get; set; }
        public string GramsOfLithiumPickName { get; set; }
        public string NominalVoltage { get; set; }
        public int? NominalVoltageUomId { get; set; }
        public string NominalVoltageUomPickName { get; set; }
        public double? NumCellsShippedInsideDevice { get; set; }
        public double? NumCellsShippedOutsideDevice { get; set; }
        public string TypicalCapacity { get; set; }
        public int? TypicalCapacityUomId { get; set; }
        public string TypicalCapacityUomPickName { get; set; }
        public bool? IsAButtonBattery { get; set; }
        public string LithiumBatteryEnergy { get; set; }
        public int? LithiumBatteryEnergyUomId { get; set; }
        public string LithiumBatteryEnergyUomPickName { get; set; }
        public string Conductivity { get; set; }
        public bool? IsAqueousSolution { get; set; }

        //777
        public PartProductForm ProductForm { get; set; }
        public string ProductFormPickName { get; set; }
        public bool? IsThermallyUnstable { get; set; }
        public List<string> HazardClassNames { get; set; }

    }
}
