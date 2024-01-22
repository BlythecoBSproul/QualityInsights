using System;
using PX.Data;
using PX.Data.EP;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.TM;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Incidents")]
    public class QIIncident : IBqlTable
    {
        #region QIIncidentClassID
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [PXDefault(typeof(QISetup.defaultQIIncidentClassID))]
        [QIIncidentClassActive]
        [PXUIField(DisplayName = "Incident Class")]
        public virtual string QIIncidentClassID { get; set; }
        public abstract class qIIncidentClassID : PX.Data.BQL.BqlString.Field<qIIncidentClassID> { }
        #endregion

        #region QIIncidentNbr
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [AutoNumber(typeof(Search<QISetup.qIIncidentNumberingID,
            Where<QISetup.qIIncidentNumberingID,
                Equal<Current<QISetup.qIIncidentNumberingID>>>>), typeof(incidentDate))]
        [PXUIField(DisplayName = "Incident Nbr")]
        public virtual string QIIncidentNbr { get; set; }
        public abstract class qIIncidentNbr : PX.Data.BQL.BqlString.Field<qIIncidentNbr> { }
        #endregion

        #region Description
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXDefault]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region IncidentDate
        [PXDBDate()]
        [PXDefault(typeof(AccessInfo.businessDate))]
        [PXUIField(DisplayName = "Incident Date")]
        public virtual DateTime? IncidentDate { get; set; }
        public abstract class incidentDate : PX.Data.BQL.BqlDateTime.Field<incidentDate> { }
        #endregion

        #region ReviewedDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Reviewed Date", Enabled = false)]
        public virtual DateTime? ReviewedDate { get; set; }
        public abstract class reviewedDate : PX.Data.BQL.BqlDateTime.Field<reviewedDate> { }
        #endregion

        #region PlannedDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Planned Date", Enabled = false)]
        public virtual DateTime? PlannedDate { get; set; }
        public abstract class plannedDate : PX.Data.BQL.BqlDateTime.Field<plannedDate> { }
        #endregion

        #region CloseDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Close Date", Enabled = false)]
        public virtual DateTime? CloseDate { get; set; }
        public abstract class closeDate : PX.Data.BQL.BqlDateTime.Field<closeDate> { }
        #endregion

        #region BAccountType
        [PXDBString(2, IsFixed = true)]
        [PXUIField(DisplayName = "Account Type", Visibility = PXUIVisibility.SelectorVisible)]
        [BAccountType.List()]
        public virtual string BAccountType { get; set; }
        public abstract class bAccountType : PX.Data.BQL.BqlString.Field<bAccountType> { }
        #endregion

        #region BAccountID
        [PXDBInt()]
        [PXSelector(typeof(Search2<BAccount.bAccountID,
            LeftJoin<Contact, On<Contact.contactID, Equal<BAccount.defContactID>>,
            LeftJoin<Address, On<Address.addressID, Equal<BAccount.defAddressID>>>>,
            Where<BAccount.type, Equal<Current<QIIncident.bAccountType>>>>),
            typeof(BAccount.acctCD),
            typeof(BAccount.acctName),
            typeof(BAccount.type),
            typeof(BAccount.classID),
            typeof(BAccount.status),
            typeof(Contact.phone1),
            typeof(Address.city),
            typeof(Address.state),
            typeof(Address.countryID),
            typeof(Contact.eMail),
            SubstituteKey = typeof(BAccount.acctCD),
            DescriptionField = typeof(BAccount.acctName))]
        [PXUIEnabled(typeof(Where<bAccountType, IsNotNull>))]
        [PXUIField(DisplayName = "Business Account")]
        public virtual int? BAccountID { get; set; }
        public abstract class bAccountID : PX.Data.BQL.BqlInt.Field<bAccountID> { }
        #endregion

        #region BAccountRefNbr
        [PXDBString(40, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Account Reference Nbr.")]
        public virtual string BAccountRefNbr { get; set; }
        public abstract class bAccountRefNbr : PX.Data.BQL.BqlString.Field<bAccountRefNbr> { }
        #endregion

        #region OriginType
        [PXDBString(40, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Doc Type")]
        public virtual string OriginType { get; set; }
        public abstract class originType : PX.Data.BQL.BqlString.Field<originType> { }
        #endregion

        #region OriginNoteID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Reference Nbr.")]
        public virtual Guid? OriginNoteID { get; set; }
        public abstract class originNoteID : PX.Data.BQL.BqlGuid.Field<originNoteID> { }
        #endregion

        #region Severity
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [QISeverityList.List]
        [PXDefault(QISeverityList.Medium)]
        [PXUIField(DisplayName = "Severity")]
        public virtual string Severity { get; set; }
        public abstract class severity : PX.Data.BQL.BqlString.Field<severity> { }
        #endregion

        #region Priority
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [QIPriorityList.List]
        [PXDefault(QIPriorityList.Medium)]
        [PXUIField(DisplayName = "Priority")]
        public virtual string Priority { get; set; }
        public abstract class priority : PX.Data.BQL.BqlString.Field<priority> { }
        #endregion

        #region OwnerID
        [Owner(typeof(QIIncident.workgroupID))]
        [PXDefault(typeof(AccessInfo.contactID), PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Owner", Visibility = PXUIVisibility.SelectorVisible)]
        [PXChildUpdatable(AutoRefresh = true, TextField = "Owner", ShowHint = false)]
        public virtual int? OwnerID { get; set; }
        public abstract class ownerID : PX.Data.BQL.BqlInt.Field<ownerID> { }
        #endregion

        #region WorkgroupID
        [PXDBInt]
        [PXDefault(typeof(Search<EPEmployee.defaultWorkgroupID, Where<EPEmployee.userID, Equal<Current<AccessInfo.userID>>>>),
            PersistingCheck = PXPersistingCheck.Nothing)]
        [PXChildUpdatable(UpdateRequest = true)]
        [PXUIField(DisplayName = "Workgroup")]
        [PXCompanyTreeSelector]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region ImpactCostTotalAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Impact Cost Total Amt", Enabled = false)]
        public virtual Decimal? ImpactCostTotalAmt { get; set; }
        public abstract class impactCostTotalAmt : PX.Data.BQL.BqlDecimal.Field<impactCostTotalAmt> { }
        #endregion

        #region ImpactRevenueTotalAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Impact Revenue Total Amt", Enabled = false)]
        public virtual Decimal? ImpactRevenueTotalAmt { get; set; }
        public abstract class impactRevenueTotalAmt : PX.Data.BQL.BqlDecimal.Field<impactRevenueTotalAmt> { }
        #endregion

        #region ImpactTimelineTotal
        [PXDBTimeSpanLong(Format = TimeSpanFormatType.DaysHoursMinitesCompact)]
        [PXDefault(TypeCode.Int32, "0")]
        [PXUIField(DisplayName = "Impact Timeline Total", Enabled = false)]
        public virtual int? ImpactTimelineTotal { get; set; }
        public abstract class impactTimelineTotal : PX.Data.BQL.BqlInt.Field<impactTimelineTotal> { }
        #endregion

        #region IdentificationDescription
        [PXDBLocalizableString(IsUnicode = true)]
        [PXUIField(DisplayName = "Identification Description")]
        public virtual string IdentificationDescription { get; set; }
        public abstract class identificationDescription : PX.Data.BQL.BqlString.Field<identificationDescription> { }
        #endregion

        #region IdentificationDescriptionAsPlainText
        [PXString(IsUnicode = true)]
        [PXUIField(Visible = false)]
        [PXDependsOnFields(typeof(identificationDescription))]
        public virtual string IdentificationDescriptionAsPlainText { get; set; }
        public abstract class identificationDescriptionAsPlainText : PX.Data.BQL.BqlString.Field<identificationDescriptionAsPlainText> { }
        #endregion

        #region DetailLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? DetailLineCntr { get; set; }
        public abstract class detailLineCntr : PX.Data.BQL.BqlInt.Field<detailLineCntr> { }
        #endregion

        #region ReviewLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? ReviewLineCntr { get; set; }
        public abstract class reviewLineCntr : PX.Data.BQL.BqlInt.Field<reviewLineCntr> { }
        #endregion

        #region PlanLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? PlanLineCntr { get; set; }
        public abstract class planLineCntr : PX.Data.BQL.BqlInt.Field<planLineCntr> { }
        #endregion

        #region ImpactLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? ImpactLineCntr { get; set; }
        public abstract class impactLineCntr : PX.Data.BQL.BqlInt.Field<impactLineCntr> { }
        #endregion

        #region Status
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [QIIncidentStatus.List]
        [PXDefault(QIIncidentStatus.Hold)]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region Hold
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Hold")]
        public virtual bool? Hold { get; set; }
        public abstract class hold : PX.Data.BQL.BqlBool.Field<hold> { }
        #endregion

        #region Started
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Started")]
        public virtual bool? Started { get; set; }
        public abstract class started : PX.Data.BQL.BqlBool.Field<started> { }
        #endregion

        #region Reviewed
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Reviewed")]
        public virtual bool? Reviewed { get; set; }
        public abstract class reviewed : PX.Data.BQL.BqlBool.Field<reviewed> { }
        #endregion

        #region Planned
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Planned")]
        public virtual bool? Planned { get; set; }
        public abstract class planned : PX.Data.BQL.BqlBool.Field<planned> { }
        #endregion

        #region Implemented
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Implemented")]
        public virtual bool? Implemented { get; set; }
        public abstract class implemented : PX.Data.BQL.BqlBool.Field<implemented> { }
        #endregion

        #region ImplementationSkipped
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Implementation Skipped")]
        public virtual bool? ImplementationSkipped { get; set; }
        public abstract class implementationSkipped : PX.Data.BQL.BqlBool.Field<implementationSkipped> { }
        #endregion

        #region Closed
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Closed")]
        public virtual bool? Closed { get; set; }
        public abstract class closed : PX.Data.BQL.BqlBool.Field<closed> { }
        #endregion

        #region Cancelled
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Cancelled")]
        public virtual bool? Cancelled { get; set; }
        public abstract class cancelled : PX.Data.BQL.BqlBool.Field<cancelled> { }
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