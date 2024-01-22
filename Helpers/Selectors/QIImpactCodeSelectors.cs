using PX.Data;

namespace QualityInsights
{
    public class QIImpactCodeRawAttribute : PXSelectorAttribute
    {
        public QIImpactCodeRawAttribute()
            : base(typeof(Search<QIImpactCode.qIImpactCodeID>),
                                  typeof(QIImpactCode.qIImpactCodeCD),
                                  typeof(QIImpactCode.descr),
                                  typeof(QIImpactCode.active))
        {
            DescriptionField = typeof(QIImpactCode.descr);
            SubstituteKey = typeof(QIImpactCode.qIImpactCodeCD);
        }
    }

    public class QIImpactCodeActiveAttribute : PXSelectorAttribute
    {
        public QIImpactCodeActiveAttribute()
            : base(typeof(Search<QIImpactCode.qIImpactCodeID,
                                 Where<QIImpactCode.active, Equal<True>>>),
                                  typeof(QIImpactCode.qIImpactCodeCD),
                                  typeof(QIImpactCode.descr))
        {
            DescriptionField = typeof(QIImpactCode.descr);
            SubstituteKey = typeof(QIImpactCode.qIImpactCodeCD);
        }
    }
}
