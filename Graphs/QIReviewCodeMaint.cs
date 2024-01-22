using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    public class QIReviewCodeMaint : PXGraph<QIReviewCodeMaint>
    {

        #region Selects
        [PXImport]
        [PXFilterable]
        public SelectFrom<QIReviewCode>.View ReviewCode;
        #endregion

        #region Actions
        public PXSave<QIReviewCode> Save;
        public PXCancel<QIReviewCode> Cancel;
        public PXChangeID<QIReviewCode, QIReviewCode.qIReviewCodeCD> ChangeID;
        #endregion

        #region Event Handlers
        protected void QIReviewCode_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            if (e.Row == null) return;
            var row = (QIReviewCode)e.Row;

            if (cache.GetStatus(e.Row) != PXEntryStatus.Inserted)
            {
                PXUIFieldAttribute.SetEnabled<QIReviewCode.qIReviewCodeCD>(cache, e.Row, false);
            }
        }
        #endregion

    }
}