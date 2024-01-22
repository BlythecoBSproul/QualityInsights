using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    public class QIImpactCodeMaint : PXGraph<QIImpactCodeMaint>
    {

        #region Selects
        [PXImport]
        [PXFilterable]
        public SelectFrom<QIImpactCode>.View ImpactCode;
        #endregion

        #region Actions
        public PXSave<QIImpactCode> Save;
        public PXCancel<QIImpactCode> Cancel;
        public PXChangeID<QIImpactCode, QIImpactCode.qIImpactCodeCD> ChangeID;
        #endregion

        #region Event Handlers
        protected void QIImpactCode_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            if (e.Row == null) return;
            var row = (QIImpactCode)e.Row;

            if (cache.GetStatus(e.Row) != PXEntryStatus.Inserted)
            {
                PXUIFieldAttribute.SetEnabled<QIImpactCode.qIImpactCodeCD>(cache, e.Row, false);
            }
        }
        #endregion
    }
}