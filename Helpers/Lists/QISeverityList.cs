using PX.Data;

namespace QualityInsights
{
    public static class QISeverityList
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new string[] { Low, Medium, High, Urgent },
                new string[] { LowDesc, MediumDesc, HighDesc, UrgentDesc })

            { }
        }
        //StringCode
        public const string Low = "L";
        public class low
            : PX.Data.BQL.BqlString.Constant<low>
        { public low() : base(Low) { } }

        public const string Medium = "M";
        public class medium
            : PX.Data.BQL.BqlString.Constant<medium>
        { public medium() : base(Medium) { } }

        public const string High = "H";
        public class high
            : PX.Data.BQL.BqlString.Constant<high>
        { public high() : base(High) { } }

        public const string Urgent = "U";
        public class urgent
            : PX.Data.BQL.BqlString.Constant<urgent>
        { public urgent() : base(Urgent) { } }

        //StringDescription
        public const string LowDesc = "Low";
        public const string MediumDesc = "Medium";
        public const string HighDesc = "High";
        public const string UrgentDesc = "Urgent";
    }
}
