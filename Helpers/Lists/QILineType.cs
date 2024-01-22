using PX.Data;

namespace QualityInsights
{
    public static class QILineType
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new string[] { FinishedGoods, PartsAndMaterials, Labor, EquipmentRental, Downtime, ExternalServices, WarrantyReturn, EnvironmentImpact, AdminstrativeCosts, ComplianceFines, Miscellaneous },
                new string[] { FinishedGoodsDesc, PartsAndMaterialsDesc, LaborDesc, EquipmentRentalDesc, DowntimeDesc, ExternalServicesDesc, WarrantyReturnDesc, EnvironmentImpactDesc, AdminstrativeCostsDesc, ComplianceFinesDesc, MiscellaneousDesc })

            { }
        }
        //StringCode

        public const string FinishedGoods = "FG";
        public class finishedGoods
            : PX.Data.BQL.BqlString.Constant<finishedGoods>
        { public finishedGoods() : base(FinishedGoods) { } }

        public const string PartsAndMaterials = "PM";
        public class partsAndMaterials
            : PX.Data.BQL.BqlString.Constant<partsAndMaterials>
        { public partsAndMaterials() : base(PartsAndMaterials) { } }

        public const string Labor = "LA";
        public class labor
            : PX.Data.BQL.BqlString.Constant<labor>
        { public labor() : base(Labor) { } }

        public const string EquipmentRental = "ER";
        public class equipmentRental
            : PX.Data.BQL.BqlString.Constant<equipmentRental>
        { public equipmentRental() : base(EquipmentRental) { } }

        public const string Downtime = "DT";
        public class downtime
            : PX.Data.BQL.BqlString.Constant<downtime>
        { public downtime() : base(Downtime) { } }

        public const string ExternalServices = "ES";
        public class externalServices
            : PX.Data.BQL.BqlString.Constant<externalServices>
        { public externalServices() : base(ExternalServices) { } }

        public const string WarrantyReturn = "WR";
        public class warrantyReturn
            : PX.Data.BQL.BqlString.Constant<warrantyReturn>
        { public warrantyReturn() : base(WarrantyReturn) { } }

        public const string EnvironmentImpact = "EI";
        public class environmentImpact
            : PX.Data.BQL.BqlString.Constant<environmentImpact>
        { public environmentImpact() : base(EnvironmentImpact) { } }

        public const string AdminstrativeCosts = "AC";
        public class adminstrativeCosts
            : PX.Data.BQL.BqlString.Constant<adminstrativeCosts>
        { public adminstrativeCosts() : base(AdminstrativeCosts) { } }

        public const string ComplianceFines = "CF";
        public class complianceFines
            : PX.Data.BQL.BqlString.Constant<complianceFines>
        { public complianceFines() : base(ComplianceFines) { } }

        public const string Miscellaneous = "MI";
        public class miscellaneous
            : PX.Data.BQL.BqlString.Constant<miscellaneous>
        { public miscellaneous() : base(Miscellaneous) { } }

        //StringDescription
        public const string FinishedGoodsDesc = "Finished Goods";
        public const string PartsAndMaterialsDesc = "Parts and Materials";
        public const string LaborDesc = "Labor Costs";
        public const string EquipmentRentalDesc = "Equipment Rental/Usage";
        public const string DowntimeDesc = "Downtime Costs";
        public const string ExternalServicesDesc = "External Services";
        public const string WarrantyReturnDesc = "Warranty/Return Costs";
        public const string EnvironmentImpactDesc = "Environment Impact Fees";
        public const string AdminstrativeCostsDesc = "Administrative Costs";
        public const string ComplianceFinesDesc = "Compliance Fines";
        public const string MiscellaneousDesc = "Miscellaneous";

    }
}
