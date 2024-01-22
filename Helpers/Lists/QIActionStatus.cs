using PX.Data;

namespace QualityInsights
{
    public static class QIActionStatus
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new string[] { NotStarted, BeingImplemented, Completed },
                new string[] { NotStartedDesc, BeingImplementedDesc, CompletedDesc })

            { }
        }
        //StringCode
        public const string NotStarted = "N";
        public class notStarted
            : PX.Data.BQL.BqlString.Constant<notStarted>
        { public notStarted() : base(NotStarted) { } }

        public const string BeingImplemented = "B";
        public class beingImplemented
            : PX.Data.BQL.BqlString.Constant<beingImplemented>
        { public beingImplemented() : base(BeingImplemented) { } }

        public const string Completed = "C";
        public class completed
            : PX.Data.BQL.BqlString.Constant<completed>
        { public completed() : base(Completed) { } }

        //StringDescription
        public const string NotStartedDesc = "Not Started";
        public const string BeingImplementedDesc = "Being Implemented";
        public const string CompletedDesc = "Completed";
    }
}
