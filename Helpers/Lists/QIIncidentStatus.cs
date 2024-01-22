using PX.Data;

namespace QualityInsights
{
    public class QIIncidentStatus
    {

        public const string Hold = "OH";
        public const string NotStarted = "NS";
        public const string InReview = "IR";
        public const string InPlanning = "IP";
        public const string InImplementation = "II";
        public const string PendingClosure = "PC";
        public const string Closed = "CL";
        public const string Cancelled = "CA";

        public const string Hold_LABEL = "On Hold";
        public const string NotStarted_LABEL = "Not Started";
        public const string InReview_LABEL = "In Review";
        public const string InPlanning_LABEL = "In Planning";
        public const string InImplementation_LABEL = "In Implementation";
        public const string PendingClosure_LABEL = "Pending Closure";
        public const string Closed_LABEL = "Closed";
        public const string Cancelled_LABEL = "Cancelled";


        public static readonly string[] Values = new string[] { Hold, NotStarted, InReview, InPlanning, InImplementation, PendingClosure, Closed, Cancelled};
        public static readonly string[] Labels = new string[] { Hold_LABEL, NotStarted_LABEL, InReview_LABEL, InPlanning_LABEL, InImplementation_LABEL, PendingClosure_LABEL, Closed_LABEL, Cancelled_LABEL };

        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(Values, Labels) { }
        }
        public class hold : PX.Data.BQL.BqlString.Constant<hold>
        {
            public hold() : base(Hold) { }
        }

        public class notStarted : PX.Data.BQL.BqlString.Constant<notStarted>
        {
            public notStarted() : base(NotStarted) { }
        }

        public class inReview : PX.Data.BQL.BqlString.Constant<inReview>
        {
            public inReview() : base(InReview) { }
        }

        public class inPlanning : PX.Data.BQL.BqlString.Constant<inPlanning>
        {
            public inPlanning() : base(InPlanning) { }
        }

        public class inImplementation : PX.Data.BQL.BqlString.Constant<inImplementation>
        {
            public inImplementation() : base(InImplementation) { }
        }

        public class pendingClosure : PX.Data.BQL.BqlString.Constant<pendingClosure>
        {
            public pendingClosure() : base(PendingClosure) { }
        }

        public class closed : PX.Data.BQL.BqlString.Constant<closed>
        {
            public closed() : base(Closed) { }
        }

        public class cancelled : PX.Data.BQL.BqlString.Constant<cancelled>
        {
            public cancelled() : base(Cancelled) { }
        }

    }
}
