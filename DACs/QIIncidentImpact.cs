using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Incident Impact")]
    public class QIIncidentImpact : IBqlTable
    {
        #region QIIncidentNbr
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDBDefault(typeof(QIIncident.qIIncidentNbr))]
        [PXSelector(typeof(Search<QIIncident.qIIncidentNbr>), ValidateValue = false)]
        [PXParent(typeof(SelectFrom<QIIncident>.
                    Where<QIIncident.qIIncidentNbr.
                        IsEqual<QIIncidentImpact.qIIncidentNbr.FromCurrent>>))]
        [PXUIField(DisplayName = "Incident Nbr.")]
        public virtual string QIIncidentNbr { get; set; }
        public abstract class qIIncidentNbr : PX.Data.BQL.BqlString.Field<qIIncidentNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(QIIncident.impactLineCntr))]
        [PXUIField(DisplayName = "Line Nbr", Enabled = false)]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region QIImpactCodeID
        [PXDBInt()]
        [QIImpactCodeActive]
        [PXDefault]
        [PXUIField(DisplayName = "Impact Code")]
        public virtual int? QIImpactCodeID { get; set; }
        public abstract class qIImpactCodeID : PX.Data.BQL.BqlInt.Field<qIImpactCodeID> { }
        #endregion

        #region SummaryDescr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
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

        #region Timeline
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Timeline", Enabled = false)]
        public virtual bool? Timeline { get; set; }
        public abstract class timeline : PX.Data.BQL.BqlBool.Field<timeline> { }
        #endregion

        #region Cost
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Cost", Enabled = false)]
        public virtual bool? Cost { get; set; }
        public abstract class cost : PX.Data.BQL.BqlBool.Field<cost> { }
        #endregion

        #region Revenue
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Revenue", Enabled = false)]
        public virtual bool? Revenue { get; set; }
        public abstract class revenue : PX.Data.BQL.BqlBool.Field<revenue> { }
        #endregion

        #region Relationship
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Relationship", Enabled = false)]
        public virtual bool? Relationship { get; set; }
        public abstract class relationship : PX.Data.BQL.BqlBool.Field<relationship> { }
        #endregion

        #region Other
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Other", Enabled = false)]
        public virtual bool? Other { get; set; }
        public abstract class other : PX.Data.BQL.BqlBool.Field<other> { }
        #endregion

        #region ImpactTimeline
        [PXDBTimeSpanLong(Format = TimeSpanFormatType.DaysHoursMinitesCompact)]
        [PXDefault(TypeCode.Int32, "0", PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIEnabled(typeof(Where<timeline, Equal<True>>))]
        [PXUIField(DisplayName = "Impact Timeline")]
        public virtual int? ImpactTimeline { get; set; }
        public abstract class impactTimeline : PX.Data.BQL.BqlInt.Field<impactTimeline> { }
        #endregion

        #region ImpactCostAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIEnabled(typeof(Where<cost, Equal<True>>))]
        [PXUIField(DisplayName = "Impact Cost Amt")]
        public virtual Decimal? ImpactCostAmt { get; set; }
        public abstract class impactCostAmt : PX.Data.BQL.BqlDecimal.Field<impactCostAmt> { }
        #endregion

        #region ImpactRevenueAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIEnabled(typeof(Where<revenue, Equal<True>>))]
        [PXUIField(DisplayName = "Impact Revenue Amt")]
        public virtual Decimal? ImpactRevenueAmt { get; set; }
        public abstract class impactRevenueAmt : PX.Data.BQL.BqlDecimal.Field<impactRevenueAmt> { }
        #endregion

        #region DepartmentLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? DepartmentLineCntr { get; set; }
        public abstract class departmentLineCntr : PX.Data.BQL.BqlInt.Field<departmentLineCntr> { }
        #endregion

        #region ImpactPctTotal
        [PXDecimal(6, MinValue = 0, MaxValue = 100)]
        [PXUIField(DisplayName = "Impact Percentage Total", Enabled = false)]
        [PXUnboundDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? ImpactPctTotal { get; set; }
        public abstract class impactPctTotal : PX.Data.BQL.BqlDecimal.Field<impactPctTotal> { }
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