using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.EP;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QIIncidentDepartmentImpact")]
    public class QIIncidentDepartmentImpact : IBqlTable
    {
        #region QIIncidentNbr
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDBDefault(typeof(QIIncidentImpact.qIIncidentNbr))]
        [PXSelector(typeof(Search<QIIncident.qIIncidentNbr>), ValidateValue = false)]
        [PXParent(typeof(SelectFrom<QIIncidentImpact>.
                    Where<QIIncidentImpact.qIIncidentNbr.
                        IsEqual<QIIncidentDepartmentImpact.qIIncidentNbr.FromCurrent>.
                        And<QIIncidentImpact.lineNbr.
                        IsEqual<QIIncidentDepartmentImpact.lineNbr.FromCurrent>>>))]
        [PXUIField(DisplayName = "Incident Nbr.")]
        public virtual string QIIncidentNbr { get; set; }
        public abstract class qIIncidentNbr : PX.Data.BQL.BqlString.Field<qIIncidentNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(QIIncidentImpact.lineNbr))]
        [PXUIField(DisplayName = "Line Nbr", Enabled = false)]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region DepartmentID
        [PXDBString(10, IsUnicode = true, IsKey = true)]
        [PXSelector(typeof(EPDepartment.departmentID), DescriptionField = typeof(EPDepartment.description))]
        [PXUIField(DisplayName = "Department ID")]
        public virtual string DepartmentID { get; set; }
        public abstract class departmentID : PX.Data.BQL.BqlString.Field<departmentID> { }
        #endregion

        #region ImpactPct
        [PXDBDecimal(6, MinValue = 0, MaxValue = 100)]
        [PXFormula(null, typeof(SumCalc<QIIncidentImpact.impactPctTotal>))]
        [PXUIField(DisplayName = "Impact Percentage")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual Decimal? ImpactPct { get; set; }
        public abstract class impactPct : PX.Data.BQL.BqlDecimal.Field<impactPct> { }
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