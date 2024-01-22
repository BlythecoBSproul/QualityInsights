using PX.Data;

namespace QualityInsights
{
    public class QIIncidentClassRawAttribute : PXSelectorAttribute
    {
        public QIIncidentClassRawAttribute()
            : base(typeof(Search<QIIncidentClass.qIIncidentClassID>),
                                  typeof(QIIncidentClass.qIIncidentClassID),
                                  typeof(QIIncidentClass.description))
        {
            DescriptionField = typeof(QIIncidentClass.description);
        }
    }

    public class QIIncidentClassActiveAttribute : PXSelectorAttribute
    {
        public QIIncidentClassActiveAttribute()
            : base(typeof(Search<QIIncidentClass.qIIncidentClassID,
                                 Where<QIIncidentClass.active, Equal<True>>>),
                                  typeof(QIIncidentClass.qIIncidentClassID),
                                  typeof(QIIncidentClass.description))
        {
            DescriptionField = typeof(QIIncidentClass.description);
        }
    }
}
