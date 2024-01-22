using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.EP;
using PX.TM;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Incident Review")]
    public class QIIncidentReview : IBqlTable
    {
        #region QIIncidentNbr
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDBDefault(typeof(QIIncident.qIIncidentNbr))]
        [PXSelector(typeof(Search<QIIncident.qIIncidentNbr>), ValidateValue = false)]
        [PXParent(typeof(SelectFrom<QIIncident>.
                    Where<QIIncident.qIIncidentNbr.
                        IsEqual<QIIncidentReview.qIIncidentNbr.FromCurrent>>))]
        [PXUIField(DisplayName = "Incident Nbr.")]
        public virtual string QIIncidentNbr { get; set; }
        public abstract class qIIncidentNbr : PX.Data.BQL.BqlString.Field<qIIncidentNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(QIIncident.reviewLineCntr))]
        [PXUIField(DisplayName = "Line Nbr", Enabled = false)]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region QIReviewCodeID
        [PXDBInt()]
        [QIReviewCodeActive]
        [PXDefault]
        [PXUIField(DisplayName = "Review Code")]
        public virtual int? QIReviewCodeID { get; set; }
        public abstract class qIReviewCodeID : PX.Data.BQL.BqlInt.Field<qIReviewCodeID> { }
        #endregion

        #region SummaryDescr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXDefault(typeof(Search<QIReviewCode.descr, Where<QIReviewCode.qIReviewCodeID, Equal<Current<qIReviewCodeID>>>>), PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Summary Description")]
        public virtual string SummaryDescr { get; set; }
        public abstract class summaryDescr : PX.Data.BQL.BqlString.Field<summaryDescr> { }
        #endregion

        #region DetailedDescription
        [PXDBLocalizableString(IsUnicode = true)]
        [PXUIField(DisplayName = "Detailed Description")]
        public virtual string DetailedDescription { get; set; }
        public abstract class detailedDescription : PX.Data.BQL.BqlString.Field<detailedDescription> { }
        #endregion

        #region DetailedDescriptionAsPlainText
        [PXString(IsUnicode = true)]
        [PXUIField(Visible = false)]
        [PXDependsOnFields(typeof(detailedDescription))]
        public virtual string DetailedDescriptionAsPlainText { get; set; }
        public abstract class detailedDescriptionAsPlainText : PX.Data.BQL.BqlString.Field<detailedDescriptionAsPlainText> { }
        #endregion

        #region OwnerID
        [Owner(typeof(QIIncident.workgroupID))]
        [PXUIField(DisplayName = "Owner", Visibility = PXUIVisibility.SelectorVisible)]
        [PXChildUpdatable(AutoRefresh = true, TextField = "Owner", ShowHint = false)]
        public virtual int? OwnerID { get; set; }
        public abstract class ownerID : PX.Data.BQL.BqlInt.Field<ownerID> { }
        #endregion

        #region WorkgroupID
        [PXDBInt]
        [PXChildUpdatable(UpdateRequest = true)]
        [PXUIField(DisplayName = "Workgroup")]
        [PXCompanyTreeSelector]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion
    }
}