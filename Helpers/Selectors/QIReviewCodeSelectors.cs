using PX.Data;

namespace QualityInsights
{
    public class QIReviewCodeRawAttribute : PXSelectorAttribute
    {
        public QIReviewCodeRawAttribute()
            : base(typeof(Search<QIReviewCode.qIReviewCodeID>),
                                  typeof(QIReviewCode.qIReviewCodeCD),
                                  typeof(QIReviewCode.descr))
        {
            DescriptionField = typeof(QIReviewCode.descr);
            SubstituteKey = typeof(QIReviewCode.qIReviewCodeCD);
        }
    }

    public class QIReviewCodeActiveAttribute : PXSelectorAttribute
    {
        public QIReviewCodeActiveAttribute()
            : base(typeof(Search<QIReviewCode.qIReviewCodeID,
                                 Where<QIReviewCode.active, Equal<True>>>),
                                  typeof(QIReviewCode.qIReviewCodeCD),
                                  typeof(QIReviewCode.descr))
        {
            DescriptionField = typeof(QIReviewCode.descr);
            SubstituteKey = typeof(QIReviewCode.qIReviewCodeCD);
        }
    }
}
