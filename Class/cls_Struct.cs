using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPart.Class
{
    public static class cls_Struct
    {
        #region Enum
        public enum ActionMode
        {
            Default = 0, Add, Edit, Copy, Delete, View, Other
        }
        //ZOZO23--------------1
        public enum VoucherType
        {
            PO = 1, RC, JOB, RO, PJOB, SQ, BS, RS, PS, TS, RSR
        }

        public enum MenuItem
        {
            PO = 1, RC, JOB, RO, PJOB, SQ, hPO, hRC, hJOB, hRO, hSQ, hSOH, hSO
        }
        //ZOZO23--------------2
        public enum TypeEditItem
        {
            T1 = 1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, SetPrice, SetPriceDisCount, SaleDisCount, UpdateQty
        }

        public enum TypePay
        {
            Cash = 0, Card, Trans, Cheque, Deposit, Other
        }
        #endregion

        #region BRANDS
        public struct StructBrands
        {
            public int BRAND_ID;
            public string BRAND_CODE;
            public string BRAND_NAME;
            public string DESCRIPTION;
            public string ADDITION_DESCRIPTION;
            public DateTime SETUP_PRICE_DATE;
            public int TAX_INVOICE_VAT_STATUS;
            public int CURRENT_VAT_STATUS;
            public int SALE_CODE;
            public int PRINT_TYPE;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
            public int REVISION;
        }
        #endregion

        #region COMPLEMENTARY
        public struct StructComplementarys
        {
            public int COMPLEMENTARY_ID;
            public string COMPLEMENTARY_CODE;
            public string COMPLEMENTARY_NAME;
            public string COMPLEMENTARY_DESCRIPTION;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
            public int REVISION;
        }
        #endregion

        #region ITEMSPECIAL
        public struct StructItemSpecials
        {
            public int ITEMS_SPECIAL_ID;
            public string ITEMS_SPECIAL_CODE;
            public string ITEMS_SPECIAL_NAME;
            public string ITEMS_SPECIAL_DESCRIPTION;
            public string ITEMS_SPECIAL_HEADER1;
            public string ITEMS_SPECIAL_HEADER2;
            public string ITEMS_SPECIAL_HEADER3;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
            public int REVISION;
        }
        #endregion

        #region Product Code
        public struct StructPDT
        {
            public int ITEM_ID;
            public string ITEM_CODE;
            public string MAKER_BARCODE_NO;
            public bool SET_STATUS;
            public bool COMPONENT_STATUS;
            public int BRAND_ID;
            public int PROMOTION_ID;
            public string GENUIN_PART_ID;
            public string BRAND_PART_ID;
            public string PO_NAME;
            public string PO_BRAND;
            public string PO_MODEL;
            public int CATEGORY_ID;
            public int TYPE_ID;
            public string ABBREVIATE_NAME;
            public string FULL_NAME;
            public string MODEL1;
            public string MODEL2;
            public string MODEL3;
            public string FULL_NAME_PRINT;
            public string MODEL_PRINT;
            public string BRAND_PRINT;
            public int QTY;
            public int PO_GROUP_ID;
            public string LAST_BUY_CODE;
            public string CURRENT_SALE_CODE;
            public double CURRENT_QTY;
            public double CURRENT_QTY_VAT;
            public string CURRENT_VAT_STATUS;
            public string TAX_INVOICE_VAT_STATUS;
            public DateTime SETUP_PRICE_DATE;
            public string ENABLED_PRICE_STATUS;
            public DateTime ENABLED_PRICE_STATUS_DATE;
            public bool SERIAL_NO_STATUS;
            public double MINIMUM_QTY;
            public double MAXIMUM_QTY;
            public DateTime COUNTING_DATE;
            public DateTime MINIMUM_DATE;
            public double MINIMUM_ORDER_QTY;
            public double MINIMUM_SALE_QTY;
            public double INVOICE_PRICE;
            public DateTime INVOICE_DATE;
            public double DEFECT_QTY;
            public double RESERVE_QTY;
            public int SIZE_ID;
            public string SIZE_INNER;
            public string SIZE_OUTSIDE;
            public string SIZE_THICK;
            public string REMARK;
            public bool ACTIVE_STOCK;
            public bool CUSTOMER_DISCOUNT_STATUS;
            public int DISPLAY_SEQUENSE_NO;
            public bool DISPLAY_HIDING_STATUS;
            public DateTime CREATED_DATE;
            public int CREATED_BY;
            public DateTime UPDATED_DATE;
            public int UPDATED_BY;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
        }
        #endregion

        #region M_CUSTOMERS
        public struct StructCUSTOMERS
        {
            public int CUSTOMER_ID;
            public string CUSTOMER_CODE;
            public string CUSTOMER_NAME;
            public string DETAIL_1;
            public string DETAIL_2;
            public string DETAIL_3;
            public string REMARK;
            public string E_MAIL;
            public string ADDRESS_1;
            public string ADDRESS_2;
            public string ADDRESS_3;
            public string ADDRESS_4;
            public string LOCATION;
            public string TAX_ID;
            public DateTime START_CONTRACT_DATE;
            public DateTime LAST_CONTRACT_DATE;
            public bool SALE_ENABLED_STATUS;
            public string PRICE_STEP;
            public double CREDIT_LIMIT;
            public Int16 CUSTOMER_CREDIT_TERM;
            public string BILL_TYPE_CODE;

        }
        #endregion

        #region M_VENDORS
        public struct StructVENDORS
        {
            public int VENDOR_ID;
            public string VENDOR_CODE;
            public string VENDOR_NAME;
            public string DETAIL_1;
            public string DETAIL_2;
            public string DETAIL_3;
            public string REMARK;
            public string E_MAIL;
            public string ADDRESS_1;
            public string ADDRESS_2;
            public string ADDRESS_3;
            public string ADDRESS_4;
            public string LOCATION;
            public string TAX_ID;
            public DateTime START_CONTRACT_DATE;
            public DateTime LAST_CONTRACT_DATE;
            public string MAP_FILE_NAME;
            public byte[] MAP_IMAGE;
            public string MDETAIL_1;
            public string MDETAIL_2;
        }
        #endregion

        #region M_DOCUMENTS
        public struct StructDOC
        {
            public int DOCUMENT_ID;
            public string DOCUMENT_CODE;
            public string DOCUMENT_NAME;
            public string DOCUMENT_DESCRIPTION;
            public string DOCUMENT_ADDRESS;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public int REVISION;
        }
        #endregion

        #region M_UNITS
        public struct StructUNIT
        {
            public int UNIT_ID;
            public string UNIT_CODE;
            public string UNIT_NAME;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public int REVISION;
        }
        #endregion 

        #region M_PO_GROUPS
        public struct StructGroupPO
        {
            public int PO_GROUP_ID;
            public string PO_GROUP_CODE;
            public string PO_GROUP_NAME;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public int REVISION;
        }
        #endregion

        #region COMPLEMENTARY
        public struct StructSubstitutes
        {
            public int SUBSTITUTE_ID;
            public string SUBSTITUTE_CODE;
            public string SUBSTITUTE_NAME;
            public string SUBSTITUTE_DESCRIPTION;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
            public int REVISION;
        }
        #endregion

        public struct StructVersatiles
        {
            public int VERSATILE_ID;
            public string VERSATILE_CODE;
            public string VERSATILE_NAME;
            public string VERSATILE_DESCRIPTION;
            public int CREATE_BY;
            public DateTime CREATE_DATE;
            public int UPDATE_BY;
            public DateTime UPDATE_DATE;
            public bool DELETED;
            public int DELETE_BY;
            public DateTime DELETE_DATE;
            public int REVISION;
        }

        #region Search
        #region Job
        public struct StructJOB
        {
            public int JOB_ID;
            public string JOB_NO;
            public DateTime JOB_DATE;
            public int JOB_TYPE;
            public string JOB_OPEN;
            public int JOB_OPERATOR;
            public byte JOB_STATUS;
            public byte PRINT_NO;
            public int LIST_NO;
            public string BARCODE;
        }

        public struct GetListJOB
        {
            public int Operator;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte JobStatus;
            public string Barcode;
        }
        #endregion

        #region RO
        public struct StructRO
        {
            public int ROH_ID;
            public string RO_NO;
            public DateTime RO_DATE;
            public int CUS_ID;
            public byte VAT_STATUS;
            public byte RO_STATUS;
            public byte PRINT_NO;
            public int LIST_NO;
            public string BARCODE;
            public decimal SUM_DOC;
            public decimal DISCLST_DOC;
            public decimal VAT_DOC;
            public decimal NET_DOC;
        }
        public struct GetListRO
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte ROStatus;
            public string Barcode;
        }
        #endregion

        #region RC
        public struct StructRC
        {
            public int RCH_ID;
            public string RC_NO;
            public DateTime RC_DATE;
            public byte RC_STATUS;
            public string INV_NO;
            public DateTime INV_DATE;
            public byte SELL_TYPE;
            public int CUS_ID;
            public int CATEGORY_ID;
            public int CREDIT_TERM;
            public byte VAT_STATUS;
            public int LIST_NO;
            public string BARCODE;
            public decimal DISCLST;
            public decimal SUM_DOC;
            public decimal VAT_DOC;
            public decimal NET_DOC;
            public decimal SUM_REAL;
            public decimal VAT_REAL;
            public decimal NET_REAL;
        }

        public struct GetListRC
        {
            public int Operator;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte RCStatus;
            public byte Selltype;
            public string Barcode;
        }
        #endregion

        #region PO
        public struct StructPO
        {
            public int POH_ID;
            public string PO_NO;
            public DateTime PO_DATE;
            public int CUS_ID;
            public int BILLER;
            public byte PRINT_NO;
            public int LIST_NO;
            public string BARCODE;
            public byte PO_TYPE;
            public int METHOD_ORDER;
            public int METHOD_TRANS;
            public byte DUETYPE;
            public DateTime DUEDATE;
            public byte PO_STATUS;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal DISCLST;
            public decimal NETSUM;
        }

        public struct GetListPO
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public int POStatus;
            public string Barcode;
        }
        #endregion

        //ZOZO23----------------------------------1
        #region SQ

        public struct StructSQ
        {
            public int SQH_ID;
            public string SQ_NO;
            public DateTime SQ_DATE;
            public byte SQ_STATUS;
            public int CUS_ID;
            public byte VAT_STATUS;
            public int LIST_NO;
            public string BARCODE;
            public string NOTE;
            public bool Active;
        }
        public struct GetListSQ
        {
            public int Operator;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte SQStatus;
            public string Barcode;
        }

        public struct GetHistorySQ
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte HStatus;        
            public int ItemId;
        }
        #endregion
        //ZOZO23----------------------------------2

        public struct GetHistoryRO
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte HStatus;
            public int ItemId;
        }

        public struct GetHistoryRC
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte HStatus;
            public byte Selltype;
            public int ItemId;
        }

        public struct GetHistoryPO
        {
            public int Customer;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte HStatus;
            public int ItemId;
        }

        public struct GetHistoryJOB
        {
            public int Operator;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte HStatus;
            public int ItemId;
        }

        #endregion

        #region Sale
        public struct StructBS
        {
            public int BSH_ID;
            public string BSH_NO;
            public DateTime BSH_DATE;
            public int CUS_ID;
            public byte BSH_STATUS;
            public Int16 PRINT_NO;
            public Int16 LIST_NO;
            public Int16 DELETE_NO;
            public int SALE_PER;
            public int RES_PER;
            public string PRINT_TYPE;
            public string CASHIER;
            //public byte PAYMENT_TYPE;
            public bool IS_ETAX;
            public bool IS_CASH;
            public decimal CASH_AMT;
            public decimal CARD_AMT;
            public decimal TRANS_AMT;
            public decimal CHEQUE_AMT;
            public decimal DEPOSIT_AMT;
            public decimal OTHER_AMT;
            public decimal SUM_AMT;
            public double PER_VAT;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal NETSUM;
        }

        public struct StructRS
        {
            public int RSH_ID;
            public string RSH_NO;
            public DateTime RSH_DATE;
            public int BSH_ID;
            public int CUS_ID;
            public int RSH_ADDRESS;
            public byte RSH_STATUS;
            public Int16 PRINT_NO;
            public Int16 LIST_NO;
            public Int16 DELETE_NO;
            public int SALE_PER;
            public int RES_PER;
            public double PER_VAT;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal NETSUM;
            public string TBSH_NO;
        }

        public struct StructPS
        {
            public int PSH_ID;
            public string PSH_NO;
            public DateTime PSH_DATE;
            public int CUS_ID;
            public byte PSH_STATUS;
            public Int16 PRINT_NO;
            public Int16 LIST_NO;
            public Int16 DELETE_NO;
            public int SALE_PER;
            public int RES_PER;
            public decimal CASH_AMT;
            public decimal CARD_AMT;
            public decimal TRANS_AMT;
            public decimal CHEQUE_AMT;
            public decimal OTHER_AMT;
            public decimal SUM_AMT;
            public decimal DEPOSIT_AMT;
            public bool IS_CLEAR;
            public double PER_VAT;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal NETSUM;
        }

        public struct StructTS
        {
            public int TSH_ID;
            public string TSH_NO;
            public DateTime TSH_DATE;
            public int CUS_ID;
            public int BS_ID;
            public byte TSH_STATUS;
            public Int16 PRINT_NO;
            public Int16 LIST_NO;
            public Int16 DELETE_NO;
            public int SALE_PER;
            public int RES_PER;
            public char PRINT_TYPE;
            public bool IS_ETAX;
            public bool IS_REFUND;
            //public byte PAYMENT_TYPE;
            public decimal CASH_AMT;
            public decimal CARD_AMT;
            public decimal TRANS_AMT;
            public decimal CHEQUE_AMT;
            public decimal OTHER_AMT;
            public decimal SUM_AMT;
            public double PER_VAT;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal NETSUM;
        }

        public struct StructRSR
        {
            public int RSRH_ID;
            public string RSRH_NO;
            public DateTime RSRH_DATE;
            public int TSH_ID;
            public int CUS_ID;
            public int RSRH_ADDRESS;
            public byte RSRH_STATUS;
            public Int16 PRINT_NO;
            public Int16 LIST_NO;
            public Int16 DELETE_NO;
            public int SALE_PER;
            public int RES_PER;
            public double PER_VAT;
            public decimal SUMCOG;
            public decimal VATSUM;
            public decimal NETSUM;

        }

        public struct StructCusTaxInv
        {
            public int ADDRESS_ID;
            public string ADDRESS_CODE;
            public int CUSTOMER_ID;
            public string ADDRESS_1;
            public string ADDRESS_2;
            public string ADDRESS_3;
            public string ADDRESS_4;
            public string TAX_ID;
            public string BRANCH;
            public string CUSTOMER_NAME;
            public string TEL;
            public string E_MAIL;
            public string FAX;
            public string CONTRACT;
        }

        public struct GetListBS
        {
            public int Customer;
            public int Personal;
            public int BSstatus;
            public int DateType;
            public DateTime DateFrom;
            public DateTime DateTo;
        }

        public struct GetListPS
        {
            public int Customer;
            public byte DateType;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte PSStatus;
            public int Per;
            public byte PayType;
            public string PSno;
        }

        public struct GetListTS
        {
            public int Customer;
            public byte DateType;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte TSStatus;
            public int Per;
            public byte PayType;
            public string TSno;
        }

        public struct GetListRS
        {
            public int Customer;
            public byte DateType;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte RSStatus;
            public string RSno;
        }

        public struct GetListRSR
        {
            public int Customer;
            public byte DateType;
            public DateTime DateFrom;
            public DateTime DateTo;
            public byte RSStatus;
            public string RSno;
        }
        #endregion

    }
}
