using PX.Data;

namespace QualityInsights
{
    public static class QIPriorityList
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new string[] { Low, Medium, High },
                new string[] { LowDesc, MediumDesc, HighDesc })

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

        //StringDescription
        public const string LowDesc = "Low";
        public const string MediumDesc = "Medium";
        public const string HighDesc = "High";
    }
}
