using System;
using PX.Data;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Impact Codes")]
    public class QIImpactCode : IBqlTable
    {
        #region QIImpactCodeID
        [PXDBIdentity]
        public virtual int? QIImpactCodeID { get; set; }
        public abstract class qIImpactCodeID : PX.Data.BQL.BqlInt.Field<qIImpactCodeID> { }
        #endregion

        #region QIImpactCodeCD
        [PXDBString(30, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = "Impact Code", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string QIImpactCodeCD { get; set; }
        public abstract class qIImpactCodeCD : PX.Data.BQL.BqlString.Field<qIImpactCodeCD> { }
        #endregion

        #region Descr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXDefault]
        [PXUIField(DisplayName = "Impact Code Description", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
        #endregion

        #region AllowTimeline
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Allow Timeline")]
        public virtual bool? AllowTimeline { get; set; }
        public abstract class allowTimeline : PX.Data.BQL.BqlBool.Field<allowTimeline> { }
        #endregion

        #region AllowCost
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Allow Cost")]
        public virtual bool? AllowCost { get; set; }
        public abstract class allowCost : PX.Data.BQL.BqlBool.Field<allowCost> { }
        #endregion

        #region AllowRevenue
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Allow Revenue")]
        public virtual bool? AllowRevenue { get; set; }
        public abstract class allowRevenue : PX.Data.BQL.BqlBool.Field<allowRevenue> { }
        #endregion

        #region AllowRelationship
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Allow Relationship")]
        public virtual bool? AllowRelationship { get; set; }
        public abstract class allowRelationship : PX.Data.BQL.BqlBool.Field<allowRelationship> { }
        #endregion

        #region AllowOther
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Allow Other")]
        public virtual bool? AllowOther { get; set; }
        public abstract class allowOther : PX.Data.BQL.BqlBool.Field<allowOther> { }
        #endregion

        #region Active
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
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