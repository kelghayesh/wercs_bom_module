using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using NLog;
using PG.Gps.DepotClient.Model;
using PG.Gps.DepotClient.Model.Wercs;

namespace PG.Gps.DepotClient.PG.Gps.DepotClient.Model
{
    public class DepotClientMappingProfile : Profile
    {
        private static readonly Logger LOG = LogManager.GetCurrentClassLogger();

        public DepotClientMappingProfile()
        {
            // call to register mappings.
            AddDefaultPicklistMappings();

            AddMapping_PartToDepotPart();


            AddMapping_RequestToWercsSdsRequest();
            AddMapping_PartToWercsPartPhysChem();
            AddMapping_DangerousGoodsToWercsDangerousGoods();
			AddMapping_DepotClientBillOfSubstanceResultToBillOfSubstance();
			AddMapping_SearchPartResultToDepotPart();
			AddMapping_SearchCompositionResultToDepotCompositionPart();
			AddMapping_DepotClientAssessmentSpecResultToAssessmentSpecResult();
			AddMapping_DepotClientBillOfSubstanceEntryResultToBillOfSubstanceEntry();
		}

        // each method will add a mapping from a type, to a type.


        /// <summary>
        /// This will map (string -> Picklist) and (Picklist -> string) for all classes that extend Picklist, but do not declare extra fields.
        /// </summary>
        private void AddDefaultPicklistMappings()
        {
            var pickListType = typeof(Picklist);
            var picklists = pickListType.Assembly.GetTypes()
                                        .Where(type => type.IsSubclassOf(pickListType)
                                                    && type.GetFields().Count(x => x.DeclaringType == type) == 0);

            LOG.Trace("Adding default Picklist maps for: {0}", new object[] { string.Join(", ", picklists.Select(pt => pt.Name)) });

            var bagMethodName = "AddDefaultPicklistBagMappings";
            var bagMethod = GetType().GetMethod(bagMethodName, BindingFlags.NonPublic | BindingFlags.Instance);

            var strType = typeof(string);
            foreach (var type in picklists)
            {
                // (string -> PicklistDto)
                CreateMap(strType, type)
                    .ForMember("Name", m => m.MapFrom(src => src))
                    .ForAllOtherMembers(x => x.Ignore());

                // (Picklist -> string)
                CreateMap(type, strType)
                    .ConstructUsing(src => (src as Picklist)?.Name)
                    .ForAllOtherMembers(x => x.Ignore());


                bagMethod?.MakeGenericMethod(type).Invoke(this, null);
                if ("N".Equals("Y")) AddDefaultPicklistBagMappings<Picklist>(); // this should not be called, just placed here so you can find where it is called
            }
        }

        /// <summary>
        /// This will map (string -> PicklistBag&lt;Picklist&gt;) and (PicklistBag&lt;Picklist&gt; -> string) for all classes that extend PicklistBag, but do not declare extra fields.
        /// </summary>
        private void AddDefaultPicklistBagMappings<PicklistType>() where PicklistType : Picklist
        {
            var pickListBagType = typeof(PicklistBag<PicklistType>);
            var picklistBags = pickListBagType.Assembly.GetTypes()
                                           .Where(type => type.IsSubclassOf(pickListBagType)
                                                       && type.GetFields().Count(x => x.DeclaringType == type) == 0);

            if (!picklistBags.Any())
                return;

            LOG.Trace("Adding default PicklistBag maps for: {0}", new object[] { string.Join(", ", picklistBags.Select(pt => pt.Name)) });

            var strType = typeof(string);
            foreach (var type in picklistBags)
            {
                // (string -> Picklist)
                CreateMap(strType, type)
                    .ForMember("Value", m => m.MapFrom(src => src)) // AutoMapper should already know how to convert string to Picklist type
                    .ForAllOtherMembers(x => x.Ignore());

                // (PicklistBag<Picklist> -> string)
                CreateMap(type, strType)
                    .ConstructUsing(src => (src as PicklistBag<PicklistType>)?.Value?.Name)
                    .ForAllOtherMembers(x => x.Ignore());
            }
        }

		/// <summary>
		/// Creates a mapping profile from Part to DepotPart
		/// </summary>
		private void AddMapping_PartToDepotPart()
		{
			CreateMap<Part, DepotPart>()
					.ForPath(dest => dest.PartId, m => m.MapFrom(src => src.Id))
					.ForPath(dest => dest.PartKey, m => m.MapFrom(src => src.Key))
					.ForPath(dest => dest.PartVaultId, m => m.MapFrom(src => src.VaultId))
					.ForPath(dest => dest.PartSrcKey, m => m.MapFrom(src => src.SrcKey))
					.ForPath(dest => dest.PartSrcRevision, m => m.MapFrom(src => src.SrcRevision))
					.ForPath(dest => dest.PartImportStatus, m => m.MapFrom(src => src.ImportStatus))
					.ForPath(dest => dest.PartName, m => m.MapFrom(src => src.Name))
					//.ForPath(dest => dest.PartTypeCode, m => m.MapFrom(src => src.PartType.?))
					.ForPath(dest => dest.PartTypeName, m => m.MapFrom(src => src.PartType.Name))
					.ForPath(dest => dest.PartGbuName, m => m.MapFrom(src => src.Gbu.Name))
					.ForPath(dest => dest.PartConfidentialTypeName, m => m.MapFrom(src => Enum.GetName(typeof(ConfidentialType), src.ConfidentialTypeId)))
					.ForPath(dest => dest.PartCasNumber, m => m.MapFrom(src => src.CasNumber))
					.ForPath(dest => dest.PartIsExperimental, m => m.MapFrom(src => src.IsExperimental))
					.ForPath(dest => dest.PartSecurityClassification, m => m.MapFrom(src => src.SecurityClassification))
					.ForPath(dest => dest.PartStatusName, m => m.MapFrom(src => src.PartStatus.Name))
					.ForPath(dest => dest.PartPlmTypeName, m => m.MapFrom(src => src.PlmType.Name))
					.ForPath(dest => dest.PartPlmPolicyName, m => m.MapFrom(src => src.PlmPolicy.Name))
					.ForPath(dest => dest.PartPlmStateName, m => m.MapFrom(src => src.PlmState.Name))
					.ForPath(dest => dest.PartPlmStageName, m => m.MapFrom(src => src.PlmStage.Name))
					.ForPath(dest => dest.PartIngredientClassName, m => m.MapFrom(src => src.IngredientClass.Name))
					.ForPath(dest => dest.PartCategoryName, m => m.MapFrom(src => src.Category.Name))
					.ForPath(dest => dest.PartSubCategoryName, m => m.MapFrom(src => src.SubCategory.Name))
					.ForPath(dest => dest.PartSegmentName, m => m.MapFrom(src => src.Segments == null ? null : src.Segments.FirstOrDefault()))
					.ForPath(dest => dest.PartSectorName, m => m.MapFrom(src => src.Sector.Name))
					.ForPath(dest => dest.PartSubSectorName, m => m.MapFrom(src => src.SubSector.Name))
					.ForPath(dest => dest.PartPrimaryOrganizationName, m => m.MapFrom(src => src.PrimaryOrganization.Name))
					.ForPath(dest => dest.PartMasterPartId, m => m.MapFrom(src => src.MasterPartId))
					.ForPath(dest => dest.PartMasterPartKey, m => m.MapFrom(src => src.MasterPart == null ? null : src.MasterPart.Key))
					.ForPath(dest => dest.BusinessAreas, m => m.MapFrom(src => src.BusinessAreas))
					.ForPath(dest => dest.ProductCategoryPlatforms, m => m.MapFrom(src => src.ProductCategoryPlatforms))
					.ForPath(dest => dest.PartReviewedStatusName, m => m.MapFrom(src => src.ReviewedStatus.Name))
					// TODO: need to convert  List<PicklistBag> to List<Picklist>
					.ForAllOtherMembers(x => x.Ignore());
		}


		private void AddMapping_RequestToWercsSdsRequest()
        {
            CreateMap<Request, WercsSdsRequest>()
                .ForPath(dest => dest.RequestNumber, m => m.MapFrom(src => src.RequestNumber))
                .ForPath(dest => dest.EstimatedProductSegmentsNames, m => m.MapFrom(src => src.EstimatedProductSegments == null ? null : string.Join(", ", src.EstimatedProductSegments.Select(pt => pt.Segment.Name))))
                .ForPath(dest => dest.BusinessAreasNames, m => m.MapFrom(src => src.BusinessAreas == null ? null : string.Join(", ", src.BusinessAreas.Select(pt => pt.BusinessArea.Name))))

                .ForPath(dest => dest.BusinessAreasNames, m => m.MapFrom(src => src.BusinessAreas == null ? null : string.Join(", ", src.BusinessAreas.Select(pt => pt.BusinessArea.Name))))

                .ForPath(dest => dest.ProductCategoryPlatformsNames, m => m.MapFrom(src => src.ProductCategoryPlatforms == null ? null : string.Join(", ", src.ProductCategoryPlatforms.Select(pt => pt.ProductCategoryPlatform.Name))))
                .ForPath(dest => dest.SrcFunctionsNames, m => m.MapFrom(src => src.SrcFunctions == null ? null : string.Join(", ", src.SrcFunctions.Select(pt => pt.SrcFunction.Name))))
                .ForPath(dest => dest.FunctionsNames, m => m.MapFrom(src => src.Functions == null ? null : string.Join(", ", src.Functions.Select(pt => pt.Function.Name))))
                .ForPath(dest => dest.AssessmentsNumbers, m => m.MapFrom(src => src.Assessments == null ? null : string.Join(", ", src.Assessments.Select(pt => pt.AssessmentNumber))))
                .ForPath(dest => dest.Assessments, m => m.MapFrom(src => src.Assessments))

                .ForAllOtherMembers(x => x.Ignore());
        }

        private void AddMapping_DangerousGoodsToWercsDangerousGoods()
        {
            CreateMap<DangerousGoods, WercsDangerousGoods>()
                    //.ForPath(dest => dest.PartId, m => m.MapFrom(src => src.Id))
                    .ForPath(dest => dest.DangerousGoodsClassifId, m => m.MapFrom(src => src.DangerousGoodsClassifId))
                    .ForPath(dest => dest.DangerousGoodsClassificationPickName, m => m.MapFrom(src => src.DangerousGoodsClassification == null ? null : src.DangerousGoodsClassification.Name))
                    .ForPath(dest => dest.PackingGroupId, m => m.MapFrom(src => src.PackingGroupId))
                    .ForPath(dest => dest.PackingGroupPickName, m => m.MapFrom(src => src.PackingGroup == null ? null : src.PackingGroup.Name))
                    .ForPath(dest => dest.ProperShippingNameId, m => m.MapFrom(src => src.ProperShippingNameId))
                    .ForPath(dest => dest.ProperShippingNamePickName, m => m.MapFrom(src => src.ProperShippingName == null ? null : src.ProperShippingName.Name))
                    .ForPath(dest => dest.CanShipInLimitedQuantity, m => m.MapFrom(src => src.CanShipInLimitedQuantity))
                    .ForPath(dest => dest.TechnicalName1Id, m => m.MapFrom(src => src.TechnicalName1Id))
                    .ForPath(dest => dest.TechnicalName1PickName, m => m.MapFrom(src => src.TechnicalName1 == null ? null : src.TechnicalName1.Name))
                    .ForPath(dest => dest.TechnicalName2Id, m => m.MapFrom(src => src.TechnicalName2Id))
                    .ForPath(dest => dest.TechnicalName2PickName, m => m.MapFrom(src => src.TechnicalName2 == null ? null : src.TechnicalName2.Name))
                    .ForPath(dest => dest.UnNumberId, m => m.MapFrom(src => src.UnNumberId))
                    .ForPath(dest => dest.UnNumberPickName, m => m.MapFrom(src => src.UnNumber == null ? null : src.UnNumber.Name))
                    .ForPath(dest => dest.OtherUnNumber, m => m.MapFrom(src => src.OtherUnNumber))
                    .ForPath(dest => dest.HazardClasses, m => m.MapFrom(src => src.HazardClasses))

                    .ForPath(dest => dest.CreatedAt, m => m.MapFrom(src => src.CreatedAt))
                    .ForPath(dest => dest.ModifiedAt, m => m.MapFrom(src => src.ModifiedAt))
                    .ForPath(dest => dest.Version, m => m.MapFrom(src => src.Version))

                    .ForAllOtherMembers(m => m.Ignore());
        }

        private void AddMapping_PartToWercsPartPhysChem()
        {
            CreateMap<Part, WercsPartPhysChem>()
                    //.ForPath(dest => dest.PartId, m => m.MapFrom(src => src.Id))
                    .ForPath(dest => dest.Key, m => m.MapFrom(src => src.Key))
                    .ForPath(dest => dest.SrcKey, m => m.MapFrom(src => src.SrcKey))
                    .ForPath(dest => dest.SrcRevision, m => m.MapFrom(src => src.SrcRevision))

                    .ForPath(dest => dest.IsExperimental, m => m.MapFrom(src => src.IsExperimental))
                    .ForPath(dest => dest.IsThermallyUnstable, m => m.MapFrom(src => src.IsThermallyUnstable))

                    .ForPath(dest => dest.IsProduedByFormula, m => m.MapFrom(src => src.IsProduedByFormula))

                    .ForPath(dest => dest.Name, m => m.MapFrom(src => src.Name))
                    .ForPath(dest => dest.EnvironmentalClassPickName, m => m.MapFrom(src => src.EnvironmentalClass))
                    .ForPath(dest => dest.GpsModifiedByUserName, m => m.MapFrom(src => src.GpsModifiedBy == null ? null : src.GpsModifiedBy.Username))

                    .ForPath(dest => dest.BusinessArea, m => m.MapFrom(src => src.BusinessAreas.FirstOrDefault()))
                    .ForPath(dest => dest.ProductForm, m => m.MapFrom(src => src.ProductForms.FirstOrDefault()))

                    .ForPath(dest => dest.PartProductCategoryPlatformName, m => m.MapFrom(src => src.ProductCategoryPlatforms == null ? null : string.Join(", ", src.ProductCategoryPlatforms.Select(pt => pt.Value.Name))))

                    .ForPath(dest => dest.PartTypePickName, m => m.MapFrom(src => src.PartType == null ? null : src.PartType.Name))
                    .ForPath(dest => dest.Description, m => m.MapFrom(src => src.Description))
                    .ForPath(dest => dest.McpManufacturerName, m => m.MapFrom(src => src.McpManufacturerName))

                    .ForPath(dest => dest.IngredientClassPickName, m => m.MapFrom(src => src.IngredientClass == null ? null : src.IngredientClass.Name))

                    //this just maps the same attributes in the source to dest. Need to test
                    .ForPath(dest => dest.Attributes, m => m.MapFrom(src => src.Attributes == null ? null : src.Attributes))

                    .ForPath(dest => dest.ColorPickName, m => m.MapFrom(src => src.Color == null ? null : src.Color.Name))
                    .ForPath(dest => dest.ColorIntensityPickName, m => m.MapFrom(src => src.ColorIntensity == null ? null : src.ColorIntensity.Name))
                    .ForPath(dest => dest.Odor, m => m.MapFrom(src => src.Odour))
                    .ForPath(dest => dest.HeatOfCombustion, m => m.MapFrom(src => src.HeatOfCombustion))
                    .ForPath(dest => dest.HeatOfDecomposition, m => m.MapFrom(src => src.HeatOfDecomposition))
                    .ForPath(dest => dest.CanConstructionId, m => m.MapFrom(src => src.CanConstructionId))
                    .ForPath(dest => dest.CanConstructionPickName, m => m.MapFrom(src => src.CanConstruction == null ? null : src.CanConstruction.Name))
                    .ForPath(dest => dest.GaugePressure, m => m.MapFrom(src => src.GaugePressure))
                    .ForPath(dest => dest.AerosolTypeId, m => m.MapFrom(src => src.AerosolTypeId))
                    .ForPath(dest => dest.AerosolTypePickName, m => m.MapFrom(src => src.AerosolType == null ? null : src.AerosolType.Name))
                    .ForPath(dest => dest.IsAerosolTestDataNeededId, m => m.MapFrom(src => src.IsAerosolTestDataNeededId))
                    .ForPath(dest => dest.IsAerosolTestDataNeededPickName, m => m.MapFrom(src => src.IsAerosolTestDataNeeded == null ? null : src.IsAerosolTestDataNeeded.Name))
                    .ForPath(dest => dest.IgnitionDistance, m => m.MapFrom(src => src.IgnitionDistance))
                    .ForPath(dest => dest.FlameHeight, m => m.MapFrom(src => src.FlameHeight))
                    .ForPath(dest => dest.FlameDuration, m => m.MapFrom(src => src.FlameDuration))
                    .ForPath(dest => dest.VaporPressure, m => m.MapFrom(src => src.VaporPressure))
                    .ForPath(dest => dest.VaporDensity, m => m.MapFrom(src => src.VaporDensity))
                    .ForPath(dest => dest.RelativeDensity, m => m.MapFrom(src => src.RelativeDensity))
                    .ForPath(dest => dest.Ph, m => m.MapFrom(src => src.Ph))
                    .ForPath(dest => dest.PhMax, m => m.MapFrom(src => src.PhMax))
                    .ForPath(dest => dest.PhMin, m => m.MapFrom(src => src.PhMin))
                    .ForPath(dest => dest.PhDilutionId, m => m.MapFrom(src => src.PhDilutionId))
                    .ForPath(dest => dest.PhDilutionPickName, m => m.MapFrom(src => src.PhDilution == null ? null : src.PhDilution.Name))
                    .ForPath(dest => dest.CorrosivetoMetalsId, m => m.MapFrom(src => src.CorrosivetoMetalsId))
                    .ForPath(dest => dest.CorrosivetoMetalsPickName, m => m.MapFrom(src => src.CorrosivetoMetals == null ? null : src.CorrosivetoMetals.Name))
                    .ForPath(dest => dest.TechnicalBasis, m => m.MapFrom(src => src.TechnicalBasis))
                    .ForPath(dest => dest.AvailableOxygen, m => m.MapFrom(src => src.AvailableOxygen))
                    .ForPath(dest => dest.BoilingPointId, m => m.MapFrom(src => src.BoilingPointId))
                    .ForPath(dest => dest.BoilingPointPickName, m => m.MapFrom(src => src.BoilingPoint == null ? null : src.BoilingPoint.Name))

                    .ForPath(dest => dest.BoilingPointValue, m => m.MapFrom(src => src.BoilingPointValue))

                    .ForPath(dest => dest.ClosedCupFlashpointId, m => m.MapFrom(src => src.ClosedCupFlashpointId))
                    .ForPath(dest => dest.ClosedCupFlashpointPickName, m => m.MapFrom(src => src.ClosedCupFlashpoint == null ? null : src.ClosedCupFlashpoint.Name))

                    .ForPath(dest => dest.ClosedCupFlashpointValue, m => m.MapFrom(src => src.ClosedCupFlashpointValue))

                    .ForPath(dest => dest.OrganicPeroxide, m => m.MapFrom(src => src.OrganicPeroxide))
                    .ForPath(dest => dest.DoestheProductContainsOxidizer, m => m.MapFrom(src => src.DoestheProductContainsOxidizer))
                    .ForPath(dest => dest.OxidizerSodiumPerCarbonate, m => m.MapFrom(src => src.OxidizerSodiumPerCarbonate))
                    .ForPath(dest => dest.OxidizerHydrogenPeroxide, m => m.MapFrom(src => src.OxidizerHydrogenPeroxide))
                    .ForPath(dest => dest.BurnRate, m => m.MapFrom(src => src.BurnRate))
                    .ForPath(dest => dest.SustainCombustion, m => m.MapFrom(src => src.SustainCombustion))
                    .ForPath(dest => dest.EvaporationRate, m => m.MapFrom(src => src.EvaporationRate))
                    //.ForPath(dest => dest.KinematicViscosity, m => m.MapFrom(src => src.KinematicViscosity))
                    .ForPath(dest => dest.ReserveAcidity, m => m.MapFrom(src => src.ReserveAcidity))
                    .ForPath(dest => dest.ReserveAlkalinity, m => m.MapFrom(src => src.ReserveAlkalinity))
                    .ForPath(dest => dest.ReserveAlkalinityAcidityUomId, m => m.MapFrom(src => src.ReserveAlkalinityAcidityUomId))
                    .ForPath(dest => dest.ReserveAlkalinityAcidityUomPickName, m => m.MapFrom(src => src.ReserveAlkalinityAcidityUom == null ? null : src.ReserveAlkalinityAcidityUom.Name))
                    .ForPath(dest => dest.ReserveAlkalAcidPhTitration, m => m.MapFrom(src => src.ReserveAlkalAcidPhTitration))

                    //ContainsFlammableLiquid >> DeviceContainsFlammableLiquid with depot-client changes on 2020-10-01
                    .ForPath(dest => dest.ContainsFlammableLiquid, m => m.MapFrom(src => src.DeviceContainsFlammableLiquid))

                    .ForPath(dest => dest.PhAvailabilityId, m => m.MapFrom(src => src.PhAvailabilityId))
                    .ForPath(dest => dest.PhAvailabilityPickName, m => m.MapFrom(src => src.PhAvailability == null ? null : src.PhAvailability.Name))
                    .ForPath(dest => dest.SelfAcceleratingDecompTemp, m => m.MapFrom(src => src.SelfAcceleratingDecompTemp))
                    .ForPath(dest => dest.BatteryTypeId, m => m.MapFrom(src => src.BatteryTypeId))
                    .ForPath(dest => dest.BatteryTypePickName, m => m.MapFrom(src => src.BatteryType == null ? null : src.BatteryType.Name))
                    .ForPath(dest => dest.IsBattery, m => m.MapFrom(src => src.IsBattery))
                    .ForPath(dest => dest.ContainsBattery, m => m.MapFrom(src => src.ContainsBattery))

                    .ForPath(dest => dest.BatteryChemicalComposition, m => m.MapFrom(src => src.BatteryChemicalComposition))
                    .ForPath(dest => dest.NumberOfCells, m => m.MapFrom(src => src.NumberOfCells))
                    .ForPath(dest => dest.BatteryWeight, m => m.MapFrom(src => src.BatteryWeight))
                    .ForPath(dest => dest.BatteryWeightUomId, m => m.MapFrom(src => src.BatteryWeightUomId))
                    .ForPath(dest => dest.BatteryWeightUomPickName, m => m.MapFrom(src => src.BatteryWeightUom == null ? null : src.BatteryWeightUom.Name))
                    .ForPath(dest => dest.GramsOfLithiumId, m => m.MapFrom(src => src.GramsOfLithiumId))
                    .ForPath(dest => dest.GramsOfLithiumPickName, m => m.MapFrom(src => src.GramsOfLithium == null ? null : src.GramsOfLithium.Name))
                    .ForPath(dest => dest.NominalVoltage, m => m.MapFrom(src => src.NominalVoltage))
                    .ForPath(dest => dest.NominalVoltageUomId, m => m.MapFrom(src => src.NominalVoltageUomId))
                    .ForPath(dest => dest.NominalVoltageUomPickName, m => m.MapFrom(src => src.Color.Name))

                    .ForPath(dest => dest.NominalVoltageUomPickName, m => m.MapFrom(src => src.NominalVoltageUom.Name))

                    .ForPath(dest => dest.NumCellsShippedInsideDevice, m => m.MapFrom(src => src.NumCellsShippedInsideDevice))
                    .ForPath(dest => dest.NumCellsShippedOutsideDevice, m => m.MapFrom(src => src.NumCellsShippedOutsideDevice))
                    .ForPath(dest => dest.TypicalCapacity, m => m.MapFrom(src => src.TypicalCapacity))
                    .ForPath(dest => dest.TypicalCapacityUomId, m => m.MapFrom(src => src.TypicalCapacityUomId))
                    .ForPath(dest => dest.TypicalCapacityUomPickName, m => m.MapFrom(src => src.TypicalCapacityUom == null ? null : src.TypicalCapacityUom.Name))
                    .ForPath(dest => dest.IsAButtonBattery, m => m.MapFrom(src => src.IsAButtonBattery))
                    .ForPath(dest => dest.LithiumBatteryEnergy, m => m.MapFrom(src => src.LithiumBatteryEnergy))
                    .ForPath(dest => dest.LithiumBatteryEnergyUomId, m => m.MapFrom(src => src.LithiumBatteryEnergyUomId))
                    .ForPath(dest => dest.LithiumBatteryEnergyUomPickName, m => m.MapFrom(src => src.LithiumBatteryEnergyUom == null ? null : src.LithiumBatteryEnergyUom.Name))
                    .ForPath(dest => dest.Conductivity, m => m.MapFrom(src => src.Conductivity))
                    .ForPath(dest => dest.IsAqueousSolution, m => m.MapFrom(src => src.IsAqueousSolution))

                    //777
                    //.ForPath(dest => dest.HazardClassNames, m => m.MapFrom(src => src.HazardClasses == null ? null : src..Select(pt => pt.Value.Name)))

                    /*
                    .ForPath(dest => dest.ColorName, m => m.MapFrom(src => src.Color.Name))
                    .ForPath(dest => dest.ColorName, m => m.MapFrom(src => src.Color.Name))
                    .ForPath(dest => dest.ColorName, m => m.MapFrom(src => src.Color.Name))
                    */

                    //.ForPath(dest => dest.PartConfidentialTypeName, m => m.MapFrom(src => Enum.GetName(typeof(ConfidentialType), src.ConfidentialTypeId)))

                    /*
                    .ForPath(dest => dest.PartCasNumber, m => m.MapFrom(src => src.CasNumber))
                    .ForPath(dest => dest.IsExperimental, m => m.MapFrom(src => src.IsExperimental))
                    .ForPath(dest => dest.EnvironmentalClass, m => m.MapFrom(src => src.EnvironmentalClass))
                    .ForPath(dest => dest.PartStatusName, m => m.MapFrom(src => src.PartStatus))
                    .ForPath(dest => dest.PartPlmTypeName, m => m.MapFrom(src => src.PlmType))
                    .ForPath(dest => dest.PartPlmPolicyName, m => m.MapFrom(src => src.PlmPolicy))
                    .ForPath(dest => dest.PartPlmStateName, m => m.MapFrom(src => src.PlmState))
                    .ForPath(dest => dest.PartPlmStageName, m => m.MapFrom(src => src.PlmStage))
                    .ForPath(dest => dest.PartIngredientClassName, m => m.MapFrom(src => src.IngredientClass))
                    .ForPath(dest => dest.PartCategoryName, m => m.MapFrom(src => src.Category))
                    .ForPath(dest => dest.PartSubCategoryName, m => m.MapFrom(src => src.SubCategory))
                    .ForPath(dest => dest.PartSegmentName, m => m.MapFrom(src => src.Segments == null ? null : src.Segments.FirstOrDefault()))
                    .ForPath(dest => dest.PartSectorName, m => m.MapFrom(src => src.Sector))
                    .ForPath(dest => dest.PartSubSectorName, m => m.MapFrom(src => src.SubSector))
                    .ForPath(dest => dest.PartPrimaryOrganizationName, m => m.MapFrom(src => src.PrimaryOrganization))
                    .ForPath(dest => dest.PartMasterPartId, m => m.MapFrom(src => src.MasterPartId))
                    .ForPath(dest => dest.PartMasterPartKey, m => m.MapFrom(src => src.MasterPart == null ? null : src.MasterPart.Key))
                    .ForPath(dest => dest.BusinessAreas, m => m.MapFrom(src => src.BusinessAreas))
                    .ForPath(dest => dest.ProductCategoryPlatforms, m => m.MapFrom(src => src.ProductCategoryPlatforms))
                    .ForPath(dest => dest.ProductTechnologyPlatforms, m => m.MapFrom(src => src.ProductTechnologyPlatforms))
                    .ForPath(dest => dest.PartReviewedStatusName, m => m.MapFrom(src => src.ReviewedStatus))
                    */
                    // TODO: need to convert  List<PicklistBag> to List<Picklist>
                    .ForAllOtherMembers(m => m.Ignore());
        }

		private void AddMapping_DepotClientBillOfSubstanceResultToBillOfSubstance()
		{
			CreateMap<DepotClientBillOfSubstanceResult, BillOfSubstance>()
				.ForPath(dest => dest.ProductPart, m => m.MapFrom(src => src.ProductPart))
				.ForPath(dest => dest.ContainsReaction, m => m.MapFrom(src => src.ContainsReaction))
				.ForPath(dest => dest.ContainsEnvironmentalLoss, m=> m.MapFrom(src => src.ContainsEnvironmentalLoss))
				.ForPath(dest => dest.IsSDSSpecific, m => m.MapFrom(src => src.IsSDSSpecific))
				.ForPath(dest => dest.Warnings, m => m.MapFrom(src => src.Warnings))
				.ForPath(dest => dest.Errors, m => m.MapFrom(src => src.Errors))
				.ForPath(dest => dest.FlattenedBillOfMaterials, m => m.MapFrom(src => src.FlattenedBillOfMaterials))
				.ForPath(dest => dest.CalculatedBillOfSubstance, m => m.MapFrom(src => src.CalculatedBillOfSubstance))
				.ForPath(dest => dest.DesignBillOfSubstance, m => m.MapFrom(src => src.DesignBillOfSubstance))
				.ForAllOtherMembers(x => x.Ignore());
		}

		private void AddMapping_SearchPartResultToDepotPart()
		{
			CreateMap<SearchPartResult, DepotPart>()
				.ForPath(dest => dest.Compositions, m => m.Ignore());
		}

		private void AddMapping_SearchCompositionResultToDepotCompositionPart()
		{
			CreateMap<SearchCompositionResult, DepotCompositionPart>()
				.ForPath(dest => dest.ParentPartKey, m => m.Ignore())
				.ForPath(dest => dest.ParentPath, m => m.Ignore())
				.ForPath(dest => dest.PartKeyPath, m => m.Ignore())
				.ForPath(dest => dest.CompositionTypePath, m => m.Ignore());
		}

		private void AddMapping_DepotClientAssessmentSpecResultToAssessmentSpecResult()
		{
			CreateMap<DepotClientAssessmentSpecResult, AssessmentSpecResult>()
				.ForPath(dest => dest.Part, m => m.MapFrom(src => src.Part))
				.ForPath(dest => dest.CalculatedComponents, m => m.MapFrom(src => src.CalculatedComponents))
				.ForPath(dest => dest.Warnings, m => m.MapFrom(src => src.Warnings))
				.ForPath(dest => dest.Errors, m => m.MapFrom(src => src.Errors))
				.ForAllOtherMembers(x => x.Ignore());
		}

		private void AddMapping_DepotClientBillOfSubstanceEntryResultToBillOfSubstanceEntry()
		{
			CreateMap<DepotClientBillOfSubstanceEntryResult, BillOfSubstanceEntry>()
				.ForPath(dest => dest.ParentPath, m => m.Ignore())
				.ForPath(dest => dest.ParentPartKey, m => m.Ignore())
				.ForPath(dest => dest.PartKeyPath, m => m.MapFrom(src => src.Path))
				.ForPath(dest => dest.CompositionTypePath, m => m.Ignore());
		}

	}
}
