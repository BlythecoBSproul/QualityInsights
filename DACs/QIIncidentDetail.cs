using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;

namespace QualityInsights
{
    [Serializable]
    [PXCacheName("QI Incident Detail")]
    public class QIIncidentDetail : IBqlTable
    {
        #region QIIncidentNbr
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDBDefault(typeof(QIIncident.qIIncidentNbr))]
        [PXSelector(typeof(Search<QIIncident.qIIncidentNbr>), ValidateValue = false)]
        [PXParent(typeof(SelectFrom<QIIncident>.
                    Where<QIIncident.qIIncidentNbr.
                        IsEqual<QIIncidentDetail.qIIncidentNbr.FromCurrent>>))]
        [PXUIField(DisplayName = "Incident Nbr.")]
        public virtual string QIIncidentNbr { get; set; }
        public abstract class qIIncidentNbr : PX.Data.BQL.BqlString.Field<qIIncidentNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(QIIncident.detailLineCntr))]
        [PXUIField(DisplayName = "Line Nbr", Enabled = false)]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region LineType
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [QILineType.List]
        [PXDefault]
        [PXUIField(DisplayName = "Line Type")]
        public virtual string LineType { get; set; }
        public abstract class lineType : PX.Data.BQL.BqlString.Field<lineType> { }
        #endregion

        #region InventoryID
        [Inventory]
        [PXUIField(DisplayName = "Inventory ID")]
        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region Desc
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Desc { get; set; }
        public abstract class desc : PX.Data.BQL.BqlString.Field<desc> { }
        #endregion

        #region Quantity
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Quantity")]
        public virtual Decimal? Quantity { get; set; }
        public abstract class quantity : PX.Data.BQL.BqlDecimal.Field<quantity> { }
        #endregion

        #region UOM
        [PXDefault(typeof(Search<InventoryItem.salesUnit, Where<InventoryItem.inventoryID, Equal<Current<inventoryID>>>>))]
        [INUnit(typeof(inventoryID), DisplayName = "UOM")]
        public virtual string UOM { get; set; }
        public abstract class uOM : PX.Data.BQL.BqlString.Field<uOM> { }
        #endregion

        #region UnitPrice
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Unit Price")]
        public virtual Decimal? UnitPrice { get; set; }
        public abstract class unitPrice : PX.Data.BQL.BqlDecimal.Field<unitPrice> { }
        #endregion

        #region DiscPct
        [PXDBDecimal(6, MinValue = -100, MaxValue = 100)]
        [PXUIField(DisplayName = "Discount Percent")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIVerify(typeof(Where<discPct, GreaterEqual<decimalMinus100>, And<discPct, LessEqual<decimal100>>>), PXErrorLevel.Error, PX.Objects.AR.Messages.DiscountPercentShouldBeBetweenMinus100And100, CheckOnRowSelected = true)]

        public virtual Decimal? DiscPct { get; set; }
        public abstract class discPct : PX.Data.BQL.BqlDecimal.Field<discPct> { }
        #endregion

        #region DiscAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Discount Amount")]
        public virtual Decimal? DiscAmt { get; set; }
        public abstract class discAmt : PX.Data.BQL.BqlDecimal.Field<discAmt> { }
        #endregion

        #region ExtPrice
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Ext. Price", Enabled = false)]
        [PXFormula(typeof(Mult<quantity, unitPrice>))]
        [PXUIVerify(typeof(Where<extPrice, GreaterEqual<decimal0>>), PXErrorLevel.Error, PX.Objects.CS.Messages.FieldShouldNotBeNegative, typeof(extPrice), MessageArgumentsAreFieldNames = true, CheckOnRowSelected = true)]
        public virtual Decimal? ExtPrice { get; set; }
        public abstract class extPrice : PX.Data.BQL.BqlDecimal.Field<extPrice> { }
        #endregion

        #region LineAmt
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXFormula(typeof(Sub<extPrice, discAmt>))]
        [PXUIVerify(typeof(Where<lineAmt, GreaterEqual<decimal0>>), PXErrorLevel.Error, PX.Objects.CS.Messages.FieldShouldNotBeNegative, typeof(lineAmt), MessageArgumentsAreFieldNames = true, CheckOnRowSelected = true)]
        [PXUIField(DisplayName = "Line Amount", Enabled = false)]
        public virtual Decimal? LineAmt { get; set; }
        public abstract class lineAmt : PX.Data.BQL.BqlDecimal.Field<lineAmt> { }
        #endregion

        #region UnitCost
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = "Unit Cost")]
        public virtual Decimal? UnitCost { get; set; }
        public abstract class unitCost : PX.Data.BQL.BqlDecimal.Field<unitCost> { }
        #endregion

        #region LineCost
        [PXDBDecimal(2)]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXFormula(typeof(Mult<quantity, unitCost>))]
        [PXUIVerify(typeof(Where<lineCost, GreaterEqual<decimal0>>), PXErrorLevel.Error, PX.Objects.CS.Messages.FieldShouldNotBeNegative, typeof(lineCost), MessageArgumentsAreFieldNames = true, CheckOnRowSelected = true)]
        [PXUIField(DisplayName = "Line Cost", Enabled = false)]
        public virtual Decimal? LineCost { get; set; }
        public abstract class lineCost : PX.Data.BQL.BqlDecimal.Field<lineCost> { }
        #endregion

        #region LotSerialNbr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXSelector(typeof(Search<INItemLotSerial.lotSerialNbr, Where<INItemLotSerial.inventoryID, Equal<Current<inventoryID>>>>),
            typeof(INItemLotSerial.lotSerialNbr),
            typeof(INItemLotSerial.expireDate),
            typeof(INItemLotSerial.qtyActual),
            typeof(INItemLotSerial.qtyAvail),
            typeof(INItemLotSerial.qtyHardAvail),
            typeof(INItemLotSerial.qtyOnHand))]
        [PXUIField(DisplayName = "Lot/Serial Nbr.")]
        public virtual string LotSerialNbr { get; set; }
        public abstract class lotSerialNbr : PX.Data.BQL.BqlString.Field<lotSerialNbr> { }
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