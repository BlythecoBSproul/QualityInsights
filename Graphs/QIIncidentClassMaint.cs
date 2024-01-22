using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    public class QIIncidentClassMaint : PXGraph<QIIncidentClassMaint>
    {

        #region Views
        public SelectFrom<QIIncidentClass>.View IncidentClass;
        public SelectFrom<QIIncidentClass>.Where<QIIncidentClass.qIIncidentClassID.IsEqual<QIIncidentClass.qIIncidentClassID.FromCurrent>>.View CurrentDocument;
        #endregion

        #region Actions
        public PXSave<QIIncidentClass> Save;
        public PXCancel<QIIncidentClass> Cancel;
        public PXInsert<QIIncidentClass> Insert;
        public PXCopyPasteAction<QIIncidentClass> CopyPaste;
        public PXDelete<QIIncidentClass> Delete;
        public PXFirst<QIIncidentClass> First;
        public PXPrevious<QIIncidentClass> Previous;
        public PXNext<QIIncidentClass> Next;
        public PXLast<QIIncidentClass> Last;
        #endregion

    }
}