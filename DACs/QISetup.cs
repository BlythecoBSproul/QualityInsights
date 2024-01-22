using System;
using PX.Data;
using PX.Objects.CS;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Preferences")]
    public class QISetup : IBqlTable
    {
        #region QIIncidentNumberingID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXSelector(typeof(Numbering.numberingID), DescriptionField = typeof(Numbering.descr))]
        [PXDefault]
        [PXUIField(DisplayName = "Incident Numbering ID")]
        public virtual string QIIncidentNumberingID { get; set; }
        public abstract class qIIncidentNumberingID : PX.Data.BQL.BqlString.Field<qIIncidentNumberingID> { }
        #endregion

        #region DefaultQIIncidentClassID
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [QIIncidentClassActive]
        [PXUIField(DisplayName = "Default Incident Class")]
        public virtual string DefaultQIIncidentClassID { get; set; }
        public abstract class defaultQIIncidentClassID : PX.Data.BQL.BqlString.Field<defaultQIIncidentClassID> { }
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