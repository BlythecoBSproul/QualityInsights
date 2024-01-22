using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    public class QIActionCodeMaint : PXGraph<QIActionCodeMaint>
    {

        #region Selects
        [PXImport]
        [PXFilterable]
        public SelectFrom<QIActionCode>.View ActionCode;
        #endregion

        #region Actions
        public PXSave<QIActionCode> Save;
        public PXCancel<QIActionCode> Cancel;
        public PXChangeID<QIActionCode, QIActionCode.qIActionCodeCD> ChangeID;
        #endregion

        #region Event Handlers
        protected void QIActionCode_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            if (e.Row == null) return;
            var row = (QIActionCode)e.Row;

            if (cache.GetStatus(e.Row) != PXEntryStatus.Inserted)
            {
                PXUIFieldAttribute.SetEnabled<QIActionCode.qIActionCodeCD>(cache, e.Row, false);
            }
        }
        #endregion
    }
}