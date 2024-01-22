using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR.BackwardCompatibility;
using PX.Objects.FA;
using PX.Objects.IN;
using static PX.CS.RMReport.FK;

namespace QualityInsights
{
    [PX.Objects.GL.TableAndChartDashboardType]
    public class QIIncidentEntry : PXGraph<QIIncidentEntry>
    {

        public PXSetup<QISetup> QIPreferences;
        public PXSetup<QIIncidentClass> IncidentClass;
        public PXSetup<QIReviewCode> ReviewCode;
        public PXSetup<QIActionCode> ActionCode;
        public PXSetup<QIImpactCode> ImpactCode;

        public QIIncidentEntry()
        {
            QISetup setup = QIPreferences.Current;
            QIIncidentClass incidentClass = IncidentClass.Current;
            QIReviewCode reviewCode = ReviewCode.Current;
            QIActionCode actionCode = ActionCode.Current;
            QIImpactCode impactCode = ImpactCode.Current;
        }


        #region Views
        [PXViewName(QIMessages.Incident)]
        [PXCopyPasteHiddenFields(typeof(QIIncident.reviewedDate), typeof(QIIncident.plannedDate), typeof(QIIncident.closeDate), typeof(QIIncident.severity), typeof(QIIncident.priority), typeof(QIIncident.ownerID), typeof(QIIncident.workgroupID))]
        public SelectFrom<QIIncident>.View Incident;

        [PXCopyPasteHiddenFields(typeof(QIIncident.reviewedDate), typeof(QIIncident.plannedDate), typeof(QIIncident.closeDate), typeof(QIIncident.severity), typeof(QIIncident.priority), typeof(QIIncident.ownerID), typeof(QIIncident.workgroupID))]
        public SelectFrom<QIIncident>.Where<QIIncident.qIIncidentNbr.IsEqual<QIIncident.qIIncidentNbr.FromCurrent>>.View CurrentDocument;

        [PXImport]
        [PXFilterable]
        [PXViewName(QIMessages.IncidentDetail)]
        [PXCopyPasteHiddenView]
        public SelectFrom<QIIncidentDetail>.Where<QIIncidentDetail.qIIncidentNbr.IsEqual<QIIncident.qIIncidentNbr.FromCurrent>>.OrderBy<Asc<QIIncidentDetail.lineNbr>>.View IncidentDetail;

        [PXViewName(QIMessages.IncidentReview)]
        [PXCopyPasteHiddenView]
        public SelectFrom<QIIncidentReview>.Where<QIIncidentReview.qIIncidentNbr.IsEqual<QIIncident.qIIncidentNbr.FromCurrent>>.OrderBy<Asc<QIIncidentReview.lineNbr>>.View IncidentReview;

        [PXViewName(QIMessages.IncidentAction)]
        [PXCopyPasteHiddenView]
        public SelectFrom<QIIncidentAction>.Where<QIIncidentAction.qIIncidentNbr.IsEqual<QIIncident.qIIncidentNbr.FromCurrent>>.OrderBy<Asc<QIIncidentAction.lineNbr>>.View IncidentAction;

        [PXViewName(QIMessages.IncidentImpact)]
        [PXCopyPasteHiddenView]
        public SelectFrom<QIIncidentImpact>.Where<QIIncidentImpact.qIIncidentNbr.IsEqual<QIIncident.qIIncidentNbr.FromCurrent>>.OrderBy<Asc<QIIncidentImpact.lineNbr>>.View IncidentImpact;

        [PXViewName(QIMessages.IncidentDepartmentImpact)]
        [PXCopyPasteHiddenView]
        public SelectFrom<QIIncidentDepartmentImpact>.Where<QIIncidentDepartmentImpact.qIIncidentNbr.IsEqual<QIIncidentImpact.qIIncidentNbr.FromCurrent>
            .And<QIIncidentDepartmentImpact.lineNbr.IsEqual<QIIncidentImpact.lineNbr.FromCurrent>>>
            .OrderBy<Asc<QIIncidentDepartmentImpact.departmentID>>
            .View IncidentDepartmentImpact;

        [PXViewName(PX.Objects.CR.Messages.Activities)]
        [PXFilterable]
        public CRActivityList<QIIncident> Activities;

        #endregion

        #region Actions

        public PXSave<QIIncident> Save;
        public PXCancel<QIIncident> Cancel;
        public PXInsert<QIIncident> Insert;
        public PXCopyPasteAction<QIIncident> CopyPaste;
        public PXDelete<QIIncident> Delete;
        public PXFirst<QIIncident> First;
        public PXPrevious<QIIncident> Previous;
        public PXNext<QIIncident> Next;
        public PXLast<QIIncident> Last;

        #endregion

        #region Workflow Actions


        #endregion

        #region Event Handlers - QI Incident Header
        protected void _(Events.FieldUpdated<QIIncident, QIIncident.bAccountType> e)
        {
            if (e.Row == null) return;
            QIIncident row = e.Row;
            
            e.Cache.SetValueExt<QIIncident.bAccountID>(row, null);
        }

        protected void _(Events.FieldUpdated<QIIncident, QIIncident.originType> e)
        {
            if (e.Row == null) return;
            QIIncident row = e.Row;

            e.Cache.SetValueExt<QIIncident.originNoteID>(row, null);
        }

        #endregion

        #region Event Handlers - QI Incident Detail 
        protected void _(Events.FieldUpdated<QIIncidentDetail, QIIncidentDetail.inventoryID> e)
        {
            if (e.Row == null) return;
            QIIncidentDetail row = e.Row;
            if (row.InventoryID != null)
            {
                InventoryItem item = PXSelectorAttribute.Select<QIIncidentDetail.inventoryID>(e.Cache, row) as InventoryItem;
                e.Cache.SetValueExt<QIIncidentDetail.desc>(row, item.Descr);
                e.Cache.SetValueExt<QIIncidentDetail.uOM>(row, item.SalesUnit);
            }

            e.Cache.SetDefaultExt<QIIncidentDetail.unitPrice>(e.Row);
        }

        protected void _(Events.FieldDefaulting<QIIncidentDetail, QIIncidentDetail.unitPrice> e)
        {
            if (e.Row == null) return;
            QIIncidentDetail row = e.Row;
            if (row.InventoryID != null)
            {
                InventoryItemCurySettings curySettings =
                                     InventoryItemCurySettings.PK.Find(
                                     this, row.InventoryID, "USD");
                if (curySettings != null)
                {
                    e.NewValue = curySettings.BasePrice;
                }
            }
        }

        protected void _(Events.FieldUpdated<QIIncidentDetail, QIIncidentDetail.discPct> e)
        {
            if (e.Row == null) return;
            QIIncidentDetail row = e.Row;
            if (row.DiscPct != 0)
            {
                var newDiscAmt = (decimal)(row.ExtPrice * (row.DiscPct / 100));
                e.Cache.SetValue<QIIncidentDetail.discAmt>(row, newDiscAmt);
                e.Cache.SetDefaultExt<QIIncidentDetail.lineAmt>(e.Row);
            }
            else
            {
                var zeroDiscAmt = (decimal)0;
                e.Cache.SetValue<QIIncidentDetail.discAmt>(row, zeroDiscAmt);
                e.Cache.SetDefaultExt<QIIncidentDetail.lineAmt>(e.Row);
            }
        }

        protected void _(Events.FieldUpdated<QIIncidentDetail, QIIncidentDetail.discAmt> e)
        {
            if (e.Row == null) return;
            QIIncidentDetail row = e.Row;
            if (row.DiscAmt != 0)
            {
                var newDiscPct = (decimal)(row.DiscAmt / row.ExtPrice) * 100;
                e.Cache.SetValue<QIIncidentDetail.discPct>(row, newDiscPct);
                e.Cache.SetDefaultExt<QIIncidentDetail.lineAmt>(e.Row);
            }
            else
            {
                var zeroDiscPct = (decimal)0;
                e.Cache.SetValue<QIIncidentDetail.discPct>(row, zeroDiscPct);
                e.Cache.SetDefaultExt<QIIncidentDetail.lineAmt>(e.Row);
            }
        }

        #endregion

        #region Event Handlers - Review
        protected void _(Events.FieldUpdated<QIIncidentReview, QIIncidentReview.qIReviewCodeID> e)
        {
            if (e.Row == null) return;
            QIIncidentReview row = e.Row;
            if (row.QIReviewCodeID != null)
            {
                QIReviewCode code = PXSelect<QIReviewCode, Where<QIReviewCode.qIReviewCodeID, Equal<@P.AsInt>>>.Select(this, row.QIReviewCodeID);
                if (code != null)
                {
                    e.Cache.SetValueExt<QIIncidentReview.summaryDescr>(row, code.Descr);
                }
            }
        }
        #endregion

        #region Event Handlers - Action
        protected void _(Events.FieldUpdated<QIIncidentAction, QIIncidentAction.qIActionCodeID> e)
        {
            if (e.Row == null) return;
            QIIncidentAction row = e.Row;
            if (row.QIActionCodeID != null)
            {
                QIActionCode code = PXSelect<QIActionCode, Where<QIActionCode.qIActionCodeID, Equal<@P.AsInt>>>.Select(this, row.QIActionCodeID);
                if(code != null)
                {
                    e.Cache.SetValueExt<QIIncidentAction.summaryDescr>(row, code.Descr);
                }
            }
        }
        #endregion

        #region Event Handlers - Impact
        protected void _(Events.FieldUpdated<QIIncidentImpact, QIIncidentImpact.qIImpactCodeID> e)
        {
            if (e.Row == null) return;
            QIIncidentImpact row = e.Row;
            if (row.QIImpactCodeID != null)
            {
                QIImpactCode code = PXSelect<QIImpactCode, Where<QIImpactCode.qIImpactCodeID, Equal<@P.AsInt>>>.Select(this, row.QIImpactCodeID);
                if(code != null)
                {
                    e.Cache.SetValueExt<QIIncidentImpact.summaryDescr>(row, code.Descr);
                }
            }
        }

        protected void _(Events.RowSelected<QIIncidentImpact> e)
        {
            if (e.Row == null) return;
            QIIncidentImpact row = e.Row;
            if (row.QIImpactCodeID != null)
            {
                QIImpactCode code = PXSelect<QIImpactCode, Where<QIImpactCode.qIImpactCodeID, Equal<@P.AsInt>>>.Select(this, row.QIImpactCodeID);
                if(code != null)
                {
                    bool allowTimeline = code.AllowTimeline.GetValueOrDefault();
                    bool allowRevenue = code.AllowRevenue.GetValueOrDefault();
                    bool allowCost = code.AllowCost.GetValueOrDefault();
                    bool allowRelationship = code.AllowRelationship.GetValueOrDefault();
                    bool allowOther = code.AllowOther.GetValueOrDefault();

                    PXUIFieldAttribute.SetEnabled<QIIncidentImpact.timeline>(e.Cache, row, allowTimeline);
                    PXUIFieldAttribute.SetEnabled<QIIncidentImpact.revenue>(e.Cache, row, allowRevenue);
                    PXUIFieldAttribute.SetEnabled<QIIncidentImpact.cost>(e.Cache, row, allowCost);
                    PXUIFieldAttribute.SetEnabled<QIIncidentImpact.relationship>(e.Cache, row, allowRelationship);
                    PXUIFieldAttribute.SetEnabled<QIIncidentImpact.other>(e.Cache, row, allowOther);
                }
            }
        }
        #endregion

    }
}