using PX.Data;

namespace QualityInsights
{
    public class QIActionCodeRawAttribute : PXSelectorAttribute
    {
        public QIActionCodeRawAttribute()
            : base(typeof(Search<QIActionCode.qIActionCodeID>),
                                  typeof(QIActionCode.qIActionCodeCD),
                                  typeof(QIActionCode.descr),
                                  typeof(QIActionCode.active))
        {
            DescriptionField = typeof(QIIncidentClass.description);
            SubstituteKey = typeof(QIActionCode.qIActionCodeCD);
        }
    }

    public class QIActionCodeActiveAttribute : PXSelectorAttribute
    {
        public QIActionCodeActiveAttribute()
            : base(typeof(Search<QIActionCode.qIActionCodeID,
                                 Where<QIActionCode.active, Equal<True>>>),
                                  typeof(QIActionCode.qIActionCodeCD),
                                  typeof(QIActionCode.descr))
        {
            DescriptionField = typeof(QIActionCode.descr);
            SubstituteKey = typeof(QIActionCode.qIActionCodeCD);
        }
    }
}
