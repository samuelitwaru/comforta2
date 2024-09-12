using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Customer" )]
   [XmlType(TypeName =  "Customer" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer : GxSilentTrnSdt
   {
      public SdtCustomer( )
      {
      }

      public SdtCustomer( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV1CustomerId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1CustomerId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CustomerId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Customer");
         metadata.Set("BT", "Customer");
         metadata.Set("PK", "[ \"CustomerId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerId\" ]");
         metadata.Set("Levels", "[ \"Locations\",\"Manager\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Customer\",\"CustomerLastLine\",\"CustomerManagerId\",\"CustomerId\",\"CustomerId\" ],[ \"Same\",\"Customer\",\"CustomerLastLineLocation\",\"CustomerLocationId\",\"CustomerId\",\"CustomerId\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerTypeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customerkvknumber_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customerpostaladdress_Z");
         state.Add("gxTpr_Customeremail_Z");
         state.Add("gxTpr_Customervisitingaddress_Z");
         state.Add("gxTpr_Customerphone_Z");
         state.Add("gxTpr_Customervatnumber_Z");
         state.Add("gxTpr_Customertypeid_Z");
         state.Add("gxTpr_Customertypename_Z");
         state.Add("gxTpr_Customerlastline_Z");
         state.Add("gxTpr_Customerlastlinelocation_Z");
         state.Add("gxTpr_Customerpostaladdress_N");
         state.Add("gxTpr_Customeremail_N");
         state.Add("gxTpr_Customervisitingaddress_N");
         state.Add("gxTpr_Customerphone_N");
         state.Add("gxTpr_Customertypeid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer sdt;
         sdt = (SdtCustomer)(source);
         gxTv_SdtCustomer_Customerid = sdt.gxTv_SdtCustomer_Customerid ;
         gxTv_SdtCustomer_Customerkvknumber = sdt.gxTv_SdtCustomer_Customerkvknumber ;
         gxTv_SdtCustomer_Customername = sdt.gxTv_SdtCustomer_Customername ;
         gxTv_SdtCustomer_Customerpostaladdress = sdt.gxTv_SdtCustomer_Customerpostaladdress ;
         gxTv_SdtCustomer_Customeremail = sdt.gxTv_SdtCustomer_Customeremail ;
         gxTv_SdtCustomer_Customervisitingaddress = sdt.gxTv_SdtCustomer_Customervisitingaddress ;
         gxTv_SdtCustomer_Customerphone = sdt.gxTv_SdtCustomer_Customerphone ;
         gxTv_SdtCustomer_Customervatnumber = sdt.gxTv_SdtCustomer_Customervatnumber ;
         gxTv_SdtCustomer_Customertypeid = sdt.gxTv_SdtCustomer_Customertypeid ;
         gxTv_SdtCustomer_Customertypename = sdt.gxTv_SdtCustomer_Customertypename ;
         gxTv_SdtCustomer_Customerlastline = sdt.gxTv_SdtCustomer_Customerlastline ;
         gxTv_SdtCustomer_Customerlastlinelocation = sdt.gxTv_SdtCustomer_Customerlastlinelocation ;
         gxTv_SdtCustomer_Manager = sdt.gxTv_SdtCustomer_Manager ;
         gxTv_SdtCustomer_Locations = sdt.gxTv_SdtCustomer_Locations ;
         gxTv_SdtCustomer_Mode = sdt.gxTv_SdtCustomer_Mode ;
         gxTv_SdtCustomer_Initialized = sdt.gxTv_SdtCustomer_Initialized ;
         gxTv_SdtCustomer_Customerid_Z = sdt.gxTv_SdtCustomer_Customerid_Z ;
         gxTv_SdtCustomer_Customerkvknumber_Z = sdt.gxTv_SdtCustomer_Customerkvknumber_Z ;
         gxTv_SdtCustomer_Customername_Z = sdt.gxTv_SdtCustomer_Customername_Z ;
         gxTv_SdtCustomer_Customerpostaladdress_Z = sdt.gxTv_SdtCustomer_Customerpostaladdress_Z ;
         gxTv_SdtCustomer_Customeremail_Z = sdt.gxTv_SdtCustomer_Customeremail_Z ;
         gxTv_SdtCustomer_Customervisitingaddress_Z = sdt.gxTv_SdtCustomer_Customervisitingaddress_Z ;
         gxTv_SdtCustomer_Customerphone_Z = sdt.gxTv_SdtCustomer_Customerphone_Z ;
         gxTv_SdtCustomer_Customervatnumber_Z = sdt.gxTv_SdtCustomer_Customervatnumber_Z ;
         gxTv_SdtCustomer_Customertypeid_Z = sdt.gxTv_SdtCustomer_Customertypeid_Z ;
         gxTv_SdtCustomer_Customertypename_Z = sdt.gxTv_SdtCustomer_Customertypename_Z ;
         gxTv_SdtCustomer_Customerlastline_Z = sdt.gxTv_SdtCustomer_Customerlastline_Z ;
         gxTv_SdtCustomer_Customerlastlinelocation_Z = sdt.gxTv_SdtCustomer_Customerlastlinelocation_Z ;
         gxTv_SdtCustomer_Customerpostaladdress_N = sdt.gxTv_SdtCustomer_Customerpostaladdress_N ;
         gxTv_SdtCustomer_Customeremail_N = sdt.gxTv_SdtCustomer_Customeremail_N ;
         gxTv_SdtCustomer_Customervisitingaddress_N = sdt.gxTv_SdtCustomer_Customervisitingaddress_N ;
         gxTv_SdtCustomer_Customerphone_N = sdt.gxTv_SdtCustomer_Customerphone_N ;
         gxTv_SdtCustomer_Customertypeid_N = sdt.gxTv_SdtCustomer_Customertypeid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("CustomerId", gxTv_SdtCustomer_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerKvkNumber", gxTv_SdtCustomer_Customerkvknumber, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtCustomer_Customername, false, includeNonInitialized);
         AddObjectProperty("CustomerPostalAddress", gxTv_SdtCustomer_Customerpostaladdress, false, includeNonInitialized);
         AddObjectProperty("CustomerPostalAddress_N", gxTv_SdtCustomer_Customerpostaladdress_N, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail", gxTv_SdtCustomer_Customeremail, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail_N", gxTv_SdtCustomer_Customeremail_N, false, includeNonInitialized);
         AddObjectProperty("CustomerVisitingAddress", gxTv_SdtCustomer_Customervisitingaddress, false, includeNonInitialized);
         AddObjectProperty("CustomerVisitingAddress_N", gxTv_SdtCustomer_Customervisitingaddress_N, false, includeNonInitialized);
         AddObjectProperty("CustomerPhone", gxTv_SdtCustomer_Customerphone, false, includeNonInitialized);
         AddObjectProperty("CustomerPhone_N", gxTv_SdtCustomer_Customerphone_N, false, includeNonInitialized);
         AddObjectProperty("CustomerVatNumber", gxTv_SdtCustomer_Customervatnumber, false, includeNonInitialized);
         AddObjectProperty("CustomerTypeId", gxTv_SdtCustomer_Customertypeid, false, includeNonInitialized);
         AddObjectProperty("CustomerTypeId_N", gxTv_SdtCustomer_Customertypeid_N, false, includeNonInitialized);
         AddObjectProperty("CustomerTypeName", gxTv_SdtCustomer_Customertypename, false, includeNonInitialized);
         AddObjectProperty("CustomerLastLine", gxTv_SdtCustomer_Customerlastline, false, includeNonInitialized);
         AddObjectProperty("CustomerLastLineLocation", gxTv_SdtCustomer_Customerlastlinelocation, false, includeNonInitialized);
         if ( gxTv_SdtCustomer_Manager != null )
         {
            AddObjectProperty("Manager", gxTv_SdtCustomer_Manager, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtCustomer_Locations != null )
         {
            AddObjectProperty("Locations", gxTv_SdtCustomer_Locations, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtCustomer_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerKvkNumber_Z", gxTv_SdtCustomer_Customerkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtCustomer_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerPostalAddress_Z", gxTv_SdtCustomer_Customerpostaladdress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_Z", gxTv_SdtCustomer_Customeremail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerVisitingAddress_Z", gxTv_SdtCustomer_Customervisitingaddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerPhone_Z", gxTv_SdtCustomer_Customerphone_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerVatNumber_Z", gxTv_SdtCustomer_Customervatnumber_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerTypeId_Z", gxTv_SdtCustomer_Customertypeid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerTypeName_Z", gxTv_SdtCustomer_Customertypename_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLastLine_Z", gxTv_SdtCustomer_Customerlastline_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLastLineLocation_Z", gxTv_SdtCustomer_Customerlastlinelocation_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerPostalAddress_N", gxTv_SdtCustomer_Customerpostaladdress_N, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_N", gxTv_SdtCustomer_Customeremail_N, false, includeNonInitialized);
            AddObjectProperty("CustomerVisitingAddress_N", gxTv_SdtCustomer_Customervisitingaddress_N, false, includeNonInitialized);
            AddObjectProperty("CustomerPhone_N", gxTv_SdtCustomer_Customerphone_N, false, includeNonInitialized);
            AddObjectProperty("CustomerTypeId_N", gxTv_SdtCustomer_Customertypeid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer sdt )
      {
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerid = sdt.gxTv_SdtCustomer_Customerid ;
         }
         if ( sdt.IsDirty("CustomerKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerkvknumber = sdt.gxTv_SdtCustomer_Customerkvknumber ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customername = sdt.gxTv_SdtCustomer_Customername ;
         }
         if ( sdt.IsDirty("CustomerPostalAddress") )
         {
            gxTv_SdtCustomer_Customerpostaladdress_N = (short)(sdt.gxTv_SdtCustomer_Customerpostaladdress_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerpostaladdress = sdt.gxTv_SdtCustomer_Customerpostaladdress ;
         }
         if ( sdt.IsDirty("CustomerEmail") )
         {
            gxTv_SdtCustomer_Customeremail_N = (short)(sdt.gxTv_SdtCustomer_Customeremail_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customeremail = sdt.gxTv_SdtCustomer_Customeremail ;
         }
         if ( sdt.IsDirty("CustomerVisitingAddress") )
         {
            gxTv_SdtCustomer_Customervisitingaddress_N = (short)(sdt.gxTv_SdtCustomer_Customervisitingaddress_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervisitingaddress = sdt.gxTv_SdtCustomer_Customervisitingaddress ;
         }
         if ( sdt.IsDirty("CustomerPhone") )
         {
            gxTv_SdtCustomer_Customerphone_N = (short)(sdt.gxTv_SdtCustomer_Customerphone_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerphone = sdt.gxTv_SdtCustomer_Customerphone ;
         }
         if ( sdt.IsDirty("CustomerVatNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervatnumber = sdt.gxTv_SdtCustomer_Customervatnumber ;
         }
         if ( sdt.IsDirty("CustomerTypeId") )
         {
            gxTv_SdtCustomer_Customertypeid_N = (short)(sdt.gxTv_SdtCustomer_Customertypeid_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypeid = sdt.gxTv_SdtCustomer_Customertypeid ;
         }
         if ( sdt.IsDirty("CustomerTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypename = sdt.gxTv_SdtCustomer_Customertypename ;
         }
         if ( sdt.IsDirty("CustomerLastLine") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastline = sdt.gxTv_SdtCustomer_Customerlastline ;
         }
         if ( sdt.IsDirty("CustomerLastLineLocation") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastlinelocation = sdt.gxTv_SdtCustomer_Customerlastlinelocation ;
         }
         if ( gxTv_SdtCustomer_Manager != null )
         {
            GXBCLevelCollection<SdtCustomer_Manager> newCollectionManager = sdt.gxTpr_Manager;
            SdtCustomer_Manager currItemManager;
            SdtCustomer_Manager newItemManager;
            short idx = 1;
            while ( idx <= newCollectionManager.Count )
            {
               newItemManager = ((SdtCustomer_Manager)newCollectionManager.Item(idx));
               currItemManager = gxTv_SdtCustomer_Manager.GetByKey(newItemManager.gxTpr_Customermanagerid);
               if ( StringUtil.StrCmp(currItemManager.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemManager.UpdateDirties(newItemManager);
                  if ( StringUtil.StrCmp(newItemManager.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemManager.gxTpr_Mode = "DLT";
                  }
                  currItemManager.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Manager.Add(newItemManager, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtCustomer_Locations != null )
         {
            GXBCLevelCollection<SdtCustomer_Locations> newCollectionLocations = sdt.gxTpr_Locations;
            SdtCustomer_Locations currItemLocations;
            SdtCustomer_Locations newItemLocations;
            short idx = 1;
            while ( idx <= newCollectionLocations.Count )
            {
               newItemLocations = ((SdtCustomer_Locations)newCollectionLocations.Item(idx));
               currItemLocations = gxTv_SdtCustomer_Locations.GetByKey(newItemLocations.gxTpr_Customerlocationid);
               if ( StringUtil.StrCmp(currItemLocations.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemLocations.UpdateDirties(newItemLocations);
                  if ( StringUtil.StrCmp(newItemLocations.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemLocations.gxTpr_Mode = "DLT";
                  }
                  currItemLocations.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Locations.Add(newItemLocations, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtCustomer_Customerid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCustomer_Customerid != value )
            {
               gxTv_SdtCustomer_Mode = "INS";
               this.gxTv_SdtCustomer_Customerid_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerkvknumber_Z_SetNull( );
               this.gxTv_SdtCustomer_Customername_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerpostaladdress_Z_SetNull( );
               this.gxTv_SdtCustomer_Customeremail_Z_SetNull( );
               this.gxTv_SdtCustomer_Customervisitingaddress_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerphone_Z_SetNull( );
               this.gxTv_SdtCustomer_Customervatnumber_Z_SetNull( );
               this.gxTv_SdtCustomer_Customertypeid_Z_SetNull( );
               this.gxTv_SdtCustomer_Customertypename_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerlastline_Z_SetNull( );
               this.gxTv_SdtCustomer_Customerlastlinelocation_Z_SetNull( );
               if ( gxTv_SdtCustomer_Manager != null )
               {
                  GXBCLevelCollection<SdtCustomer_Manager> collectionManager = gxTv_SdtCustomer_Manager;
                  SdtCustomer_Manager currItemManager;
                  short idx = 1;
                  while ( idx <= collectionManager.Count )
                  {
                     currItemManager = ((SdtCustomer_Manager)collectionManager.Item(idx));
                     currItemManager.gxTpr_Mode = "INS";
                     currItemManager.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtCustomer_Locations != null )
               {
                  GXBCLevelCollection<SdtCustomer_Locations> collectionLocations = gxTv_SdtCustomer_Locations;
                  SdtCustomer_Locations currItemLocations;
                  short idx = 1;
                  while ( idx <= collectionLocations.Count )
                  {
                     currItemLocations = ((SdtCustomer_Locations)collectionLocations.Item(idx));
                     currItemLocations.gxTpr_Mode = "INS";
                     currItemLocations.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtCustomer_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerKvkNumber" )]
      [  XmlElement( ElementName = "CustomerKvkNumber"   )]
      public string gxTpr_Customerkvknumber
      {
         get {
            return gxTv_SdtCustomer_Customerkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerkvknumber = value;
            SetDirty("Customerkvknumber");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtCustomer_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CustomerPostalAddress" )]
      [  XmlElement( ElementName = "CustomerPostalAddress"   )]
      public string gxTpr_Customerpostaladdress
      {
         get {
            return gxTv_SdtCustomer_Customerpostaladdress ;
         }

         set {
            gxTv_SdtCustomer_Customerpostaladdress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerpostaladdress = value;
            SetDirty("Customerpostaladdress");
         }

      }

      public void gxTv_SdtCustomer_Customerpostaladdress_SetNull( )
      {
         gxTv_SdtCustomer_Customerpostaladdress_N = 1;
         gxTv_SdtCustomer_Customerpostaladdress = "";
         SetDirty("Customerpostaladdress");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerpostaladdress_IsNull( )
      {
         return (gxTv_SdtCustomer_Customerpostaladdress_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerEmail" )]
      [  XmlElement( ElementName = "CustomerEmail"   )]
      public string gxTpr_Customeremail
      {
         get {
            return gxTv_SdtCustomer_Customeremail ;
         }

         set {
            gxTv_SdtCustomer_Customeremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customeremail = value;
            SetDirty("Customeremail");
         }

      }

      public void gxTv_SdtCustomer_Customeremail_SetNull( )
      {
         gxTv_SdtCustomer_Customeremail_N = 1;
         gxTv_SdtCustomer_Customeremail = "";
         SetDirty("Customeremail");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customeremail_IsNull( )
      {
         return (gxTv_SdtCustomer_Customeremail_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerVisitingAddress" )]
      [  XmlElement( ElementName = "CustomerVisitingAddress"   )]
      public string gxTpr_Customervisitingaddress
      {
         get {
            return gxTv_SdtCustomer_Customervisitingaddress ;
         }

         set {
            gxTv_SdtCustomer_Customervisitingaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervisitingaddress = value;
            SetDirty("Customervisitingaddress");
         }

      }

      public void gxTv_SdtCustomer_Customervisitingaddress_SetNull( )
      {
         gxTv_SdtCustomer_Customervisitingaddress_N = 1;
         gxTv_SdtCustomer_Customervisitingaddress = "";
         SetDirty("Customervisitingaddress");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customervisitingaddress_IsNull( )
      {
         return (gxTv_SdtCustomer_Customervisitingaddress_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerPhone" )]
      [  XmlElement( ElementName = "CustomerPhone"   )]
      public string gxTpr_Customerphone
      {
         get {
            return gxTv_SdtCustomer_Customerphone ;
         }

         set {
            gxTv_SdtCustomer_Customerphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerphone = value;
            SetDirty("Customerphone");
         }

      }

      public void gxTv_SdtCustomer_Customerphone_SetNull( )
      {
         gxTv_SdtCustomer_Customerphone_N = 1;
         gxTv_SdtCustomer_Customerphone = "";
         SetDirty("Customerphone");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerphone_IsNull( )
      {
         return (gxTv_SdtCustomer_Customerphone_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerVatNumber" )]
      [  XmlElement( ElementName = "CustomerVatNumber"   )]
      public string gxTpr_Customervatnumber
      {
         get {
            return gxTv_SdtCustomer_Customervatnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervatnumber = value;
            SetDirty("Customervatnumber");
         }

      }

      [  SoapElement( ElementName = "CustomerTypeId" )]
      [  XmlElement( ElementName = "CustomerTypeId"   )]
      public short gxTpr_Customertypeid
      {
         get {
            return gxTv_SdtCustomer_Customertypeid ;
         }

         set {
            gxTv_SdtCustomer_Customertypeid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypeid = value;
            SetDirty("Customertypeid");
         }

      }

      public void gxTv_SdtCustomer_Customertypeid_SetNull( )
      {
         gxTv_SdtCustomer_Customertypeid_N = 1;
         gxTv_SdtCustomer_Customertypeid = 0;
         SetDirty("Customertypeid");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customertypeid_IsNull( )
      {
         return (gxTv_SdtCustomer_Customertypeid_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerTypeName" )]
      [  XmlElement( ElementName = "CustomerTypeName"   )]
      public string gxTpr_Customertypename
      {
         get {
            return gxTv_SdtCustomer_Customertypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypename = value;
            SetDirty("Customertypename");
         }

      }

      [  SoapElement( ElementName = "CustomerLastLine" )]
      [  XmlElement( ElementName = "CustomerLastLine"   )]
      public short gxTpr_Customerlastline
      {
         get {
            return gxTv_SdtCustomer_Customerlastline ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastline = value;
            SetDirty("Customerlastline");
         }

      }

      [  SoapElement( ElementName = "CustomerLastLineLocation" )]
      [  XmlElement( ElementName = "CustomerLastLineLocation"   )]
      public short gxTpr_Customerlastlinelocation
      {
         get {
            return gxTv_SdtCustomer_Customerlastlinelocation ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastlinelocation = value;
            SetDirty("Customerlastlinelocation");
         }

      }

      [  SoapElement( ElementName = "Manager" )]
      [  XmlArray( ElementName = "Manager"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Manager"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Manager> gxTpr_Manager_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Manager == null )
            {
               gxTv_SdtCustomer_Manager = new GXBCLevelCollection<SdtCustomer_Manager>( context, "Customer.Manager", "Comforta2");
            }
            return gxTv_SdtCustomer_Manager ;
         }

         set {
            if ( gxTv_SdtCustomer_Manager == null )
            {
               gxTv_SdtCustomer_Manager = new GXBCLevelCollection<SdtCustomer_Manager>( context, "Customer.Manager", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Manager> gxTpr_Manager
      {
         get {
            if ( gxTv_SdtCustomer_Manager == null )
            {
               gxTv_SdtCustomer_Manager = new GXBCLevelCollection<SdtCustomer_Manager>( context, "Customer.Manager", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Manager ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager = value;
            SetDirty("Manager");
         }

      }

      public void gxTv_SdtCustomer_Manager_SetNull( )
      {
         gxTv_SdtCustomer_Manager = null;
         SetDirty("Manager");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_IsNull( )
      {
         if ( gxTv_SdtCustomer_Manager == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Locations" )]
      [  XmlArray( ElementName = "Locations"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Locations"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Locations> gxTpr_Locations_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Locations == null )
            {
               gxTv_SdtCustomer_Locations = new GXBCLevelCollection<SdtCustomer_Locations>( context, "Customer.Locations", "Comforta2");
            }
            return gxTv_SdtCustomer_Locations ;
         }

         set {
            if ( gxTv_SdtCustomer_Locations == null )
            {
               gxTv_SdtCustomer_Locations = new GXBCLevelCollection<SdtCustomer_Locations>( context, "Customer.Locations", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Locations> gxTpr_Locations
      {
         get {
            if ( gxTv_SdtCustomer_Locations == null )
            {
               gxTv_SdtCustomer_Locations = new GXBCLevelCollection<SdtCustomer_Locations>( context, "Customer.Locations", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Locations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations = value;
            SetDirty("Locations");
         }

      }

      public void gxTv_SdtCustomer_Locations_SetNull( )
      {
         gxTv_SdtCustomer_Locations = null;
         SetDirty("Locations");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_IsNull( )
      {
         if ( gxTv_SdtCustomer_Locations == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtCustomer_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerKvkNumber_Z" )]
      [  XmlElement( ElementName = "CustomerKvkNumber_Z"   )]
      public string gxTpr_Customerkvknumber_Z
      {
         get {
            return gxTv_SdtCustomer_Customerkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerkvknumber_Z = value;
            SetDirty("Customerkvknumber_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerkvknumber_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerkvknumber_Z = "";
         SetDirty("Customerkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtCustomer_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtCustomer_Customername_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPostalAddress_Z" )]
      [  XmlElement( ElementName = "CustomerPostalAddress_Z"   )]
      public string gxTpr_Customerpostaladdress_Z
      {
         get {
            return gxTv_SdtCustomer_Customerpostaladdress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerpostaladdress_Z = value;
            SetDirty("Customerpostaladdress_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerpostaladdress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerpostaladdress_Z = "";
         SetDirty("Customerpostaladdress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerpostaladdress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_Z" )]
      [  XmlElement( ElementName = "CustomerEmail_Z"   )]
      public string gxTpr_Customeremail_Z
      {
         get {
            return gxTv_SdtCustomer_Customeremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customeremail_Z = value;
            SetDirty("Customeremail_Z");
         }

      }

      public void gxTv_SdtCustomer_Customeremail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customeremail_Z = "";
         SetDirty("Customeremail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customeremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerVisitingAddress_Z" )]
      [  XmlElement( ElementName = "CustomerVisitingAddress_Z"   )]
      public string gxTpr_Customervisitingaddress_Z
      {
         get {
            return gxTv_SdtCustomer_Customervisitingaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervisitingaddress_Z = value;
            SetDirty("Customervisitingaddress_Z");
         }

      }

      public void gxTv_SdtCustomer_Customervisitingaddress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customervisitingaddress_Z = "";
         SetDirty("Customervisitingaddress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customervisitingaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPhone_Z" )]
      [  XmlElement( ElementName = "CustomerPhone_Z"   )]
      public string gxTpr_Customerphone_Z
      {
         get {
            return gxTv_SdtCustomer_Customerphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerphone_Z = value;
            SetDirty("Customerphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerphone_Z = "";
         SetDirty("Customerphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerVatNumber_Z" )]
      [  XmlElement( ElementName = "CustomerVatNumber_Z"   )]
      public string gxTpr_Customervatnumber_Z
      {
         get {
            return gxTv_SdtCustomer_Customervatnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervatnumber_Z = value;
            SetDirty("Customervatnumber_Z");
         }

      }

      public void gxTv_SdtCustomer_Customervatnumber_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customervatnumber_Z = "";
         SetDirty("Customervatnumber_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customervatnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerTypeId_Z" )]
      [  XmlElement( ElementName = "CustomerTypeId_Z"   )]
      public short gxTpr_Customertypeid_Z
      {
         get {
            return gxTv_SdtCustomer_Customertypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypeid_Z = value;
            SetDirty("Customertypeid_Z");
         }

      }

      public void gxTv_SdtCustomer_Customertypeid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customertypeid_Z = 0;
         SetDirty("Customertypeid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customertypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerTypeName_Z" )]
      [  XmlElement( ElementName = "CustomerTypeName_Z"   )]
      public string gxTpr_Customertypename_Z
      {
         get {
            return gxTv_SdtCustomer_Customertypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypename_Z = value;
            SetDirty("Customertypename_Z");
         }

      }

      public void gxTv_SdtCustomer_Customertypename_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customertypename_Z = "";
         SetDirty("Customertypename_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customertypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLastLine_Z" )]
      [  XmlElement( ElementName = "CustomerLastLine_Z"   )]
      public short gxTpr_Customerlastline_Z
      {
         get {
            return gxTv_SdtCustomer_Customerlastline_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastline_Z = value;
            SetDirty("Customerlastline_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerlastline_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerlastline_Z = 0;
         SetDirty("Customerlastline_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerlastline_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLastLineLocation_Z" )]
      [  XmlElement( ElementName = "CustomerLastLineLocation_Z"   )]
      public short gxTpr_Customerlastlinelocation_Z
      {
         get {
            return gxTv_SdtCustomer_Customerlastlinelocation_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerlastlinelocation_Z = value;
            SetDirty("Customerlastlinelocation_Z");
         }

      }

      public void gxTv_SdtCustomer_Customerlastlinelocation_Z_SetNull( )
      {
         gxTv_SdtCustomer_Customerlastlinelocation_Z = 0;
         SetDirty("Customerlastlinelocation_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerlastlinelocation_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPostalAddress_N" )]
      [  XmlElement( ElementName = "CustomerPostalAddress_N"   )]
      public short gxTpr_Customerpostaladdress_N
      {
         get {
            return gxTv_SdtCustomer_Customerpostaladdress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerpostaladdress_N = value;
            SetDirty("Customerpostaladdress_N");
         }

      }

      public void gxTv_SdtCustomer_Customerpostaladdress_N_SetNull( )
      {
         gxTv_SdtCustomer_Customerpostaladdress_N = 0;
         SetDirty("Customerpostaladdress_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerpostaladdress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_N" )]
      [  XmlElement( ElementName = "CustomerEmail_N"   )]
      public short gxTpr_Customeremail_N
      {
         get {
            return gxTv_SdtCustomer_Customeremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customeremail_N = value;
            SetDirty("Customeremail_N");
         }

      }

      public void gxTv_SdtCustomer_Customeremail_N_SetNull( )
      {
         gxTv_SdtCustomer_Customeremail_N = 0;
         SetDirty("Customeremail_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customeremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerVisitingAddress_N" )]
      [  XmlElement( ElementName = "CustomerVisitingAddress_N"   )]
      public short gxTpr_Customervisitingaddress_N
      {
         get {
            return gxTv_SdtCustomer_Customervisitingaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customervisitingaddress_N = value;
            SetDirty("Customervisitingaddress_N");
         }

      }

      public void gxTv_SdtCustomer_Customervisitingaddress_N_SetNull( )
      {
         gxTv_SdtCustomer_Customervisitingaddress_N = 0;
         SetDirty("Customervisitingaddress_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customervisitingaddress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerPhone_N" )]
      [  XmlElement( ElementName = "CustomerPhone_N"   )]
      public short gxTpr_Customerphone_N
      {
         get {
            return gxTv_SdtCustomer_Customerphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customerphone_N = value;
            SetDirty("Customerphone_N");
         }

      }

      public void gxTv_SdtCustomer_Customerphone_N_SetNull( )
      {
         gxTv_SdtCustomer_Customerphone_N = 0;
         SetDirty("Customerphone_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customerphone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerTypeId_N" )]
      [  XmlElement( ElementName = "CustomerTypeId_N"   )]
      public short gxTpr_Customertypeid_N
      {
         get {
            return gxTv_SdtCustomer_Customertypeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Customertypeid_N = value;
            SetDirty("Customertypeid_N");
         }

      }

      public void gxTv_SdtCustomer_Customertypeid_N_SetNull( )
      {
         gxTv_SdtCustomer_Customertypeid_N = 0;
         SetDirty("Customertypeid_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Customertypeid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtCustomer_Customerkvknumber = "";
         gxTv_SdtCustomer_Customername = "";
         gxTv_SdtCustomer_Customerpostaladdress = "";
         gxTv_SdtCustomer_Customeremail = "";
         gxTv_SdtCustomer_Customervisitingaddress = "";
         gxTv_SdtCustomer_Customerphone = "";
         gxTv_SdtCustomer_Customervatnumber = "";
         gxTv_SdtCustomer_Customertypename = "";
         gxTv_SdtCustomer_Mode = "";
         gxTv_SdtCustomer_Customerkvknumber_Z = "";
         gxTv_SdtCustomer_Customername_Z = "";
         gxTv_SdtCustomer_Customerpostaladdress_Z = "";
         gxTv_SdtCustomer_Customeremail_Z = "";
         gxTv_SdtCustomer_Customervisitingaddress_Z = "";
         gxTv_SdtCustomer_Customerphone_Z = "";
         gxTv_SdtCustomer_Customervatnumber_Z = "";
         gxTv_SdtCustomer_Customertypename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "customer", "GeneXus.Programs.customer_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Customerid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Customertypeid ;
      private short gxTv_SdtCustomer_Customerlastline ;
      private short gxTv_SdtCustomer_Customerlastlinelocation ;
      private short gxTv_SdtCustomer_Initialized ;
      private short gxTv_SdtCustomer_Customerid_Z ;
      private short gxTv_SdtCustomer_Customertypeid_Z ;
      private short gxTv_SdtCustomer_Customerlastline_Z ;
      private short gxTv_SdtCustomer_Customerlastlinelocation_Z ;
      private short gxTv_SdtCustomer_Customerpostaladdress_N ;
      private short gxTv_SdtCustomer_Customeremail_N ;
      private short gxTv_SdtCustomer_Customervisitingaddress_N ;
      private short gxTv_SdtCustomer_Customerphone_N ;
      private short gxTv_SdtCustomer_Customertypeid_N ;
      private string gxTv_SdtCustomer_Customerphone ;
      private string gxTv_SdtCustomer_Mode ;
      private string gxTv_SdtCustomer_Customerphone_Z ;
      private string gxTv_SdtCustomer_Customerkvknumber ;
      private string gxTv_SdtCustomer_Customername ;
      private string gxTv_SdtCustomer_Customerpostaladdress ;
      private string gxTv_SdtCustomer_Customeremail ;
      private string gxTv_SdtCustomer_Customervisitingaddress ;
      private string gxTv_SdtCustomer_Customervatnumber ;
      private string gxTv_SdtCustomer_Customertypename ;
      private string gxTv_SdtCustomer_Customerkvknumber_Z ;
      private string gxTv_SdtCustomer_Customername_Z ;
      private string gxTv_SdtCustomer_Customerpostaladdress_Z ;
      private string gxTv_SdtCustomer_Customeremail_Z ;
      private string gxTv_SdtCustomer_Customervisitingaddress_Z ;
      private string gxTv_SdtCustomer_Customervatnumber_Z ;
      private string gxTv_SdtCustomer_Customertypename_Z ;
      private GXBCLevelCollection<SdtCustomer_Manager> gxTv_SdtCustomer_Manager=null ;
      private GXBCLevelCollection<SdtCustomer_Locations> gxTv_SdtCustomer_Locations=null ;
   }

   [DataContract(Name = @"Customer", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_RESTInterface : GxGenericCollectionItem<SdtCustomer>
   {
      public SdtCustomer_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_RESTInterface( SdtCustomer psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerid
      {
         get {
            return sdt.gxTpr_Customerid ;
         }

         set {
            sdt.gxTpr_Customerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerKvkNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Customerkvknumber
      {
         get {
            return sdt.gxTpr_Customerkvknumber ;
         }

         set {
            sdt.gxTpr_Customerkvknumber = value;
         }

      }

      [DataMember( Name = "CustomerName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customername
      {
         get {
            return sdt.gxTpr_Customername ;
         }

         set {
            sdt.gxTpr_Customername = value;
         }

      }

      [DataMember( Name = "CustomerPostalAddress" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customerpostaladdress
      {
         get {
            return sdt.gxTpr_Customerpostaladdress ;
         }

         set {
            sdt.gxTpr_Customerpostaladdress = value;
         }

      }

      [DataMember( Name = "CustomerEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customeremail
      {
         get {
            return sdt.gxTpr_Customeremail ;
         }

         set {
            sdt.gxTpr_Customeremail = value;
         }

      }

      [DataMember( Name = "CustomerVisitingAddress" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Customervisitingaddress
      {
         get {
            return sdt.gxTpr_Customervisitingaddress ;
         }

         set {
            sdt.gxTpr_Customervisitingaddress = value;
         }

      }

      [DataMember( Name = "CustomerPhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Customerphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customerphone) ;
         }

         set {
            sdt.gxTpr_Customerphone = value;
         }

      }

      [DataMember( Name = "CustomerVatNumber" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Customervatnumber
      {
         get {
            return sdt.gxTpr_Customervatnumber ;
         }

         set {
            sdt.gxTpr_Customervatnumber = value;
         }

      }

      [DataMember( Name = "CustomerTypeId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customertypeid
      {
         get {
            return sdt.gxTpr_Customertypeid ;
         }

         set {
            sdt.gxTpr_Customertypeid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerTypeName" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Customertypename
      {
         get {
            return sdt.gxTpr_Customertypename ;
         }

         set {
            sdt.gxTpr_Customertypename = value;
         }

      }

      [DataMember( Name = "CustomerLastLine" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlastline
      {
         get {
            return sdt.gxTpr_Customerlastline ;
         }

         set {
            sdt.gxTpr_Customerlastline = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerLastLineLocation" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlastlinelocation
      {
         get {
            return sdt.gxTpr_Customerlastlinelocation ;
         }

         set {
            sdt.gxTpr_Customerlastlinelocation = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Manager" , Order = 12 )]
      public GxGenericCollection<SdtCustomer_Manager_RESTInterface> gxTpr_Manager
      {
         get {
            return new GxGenericCollection<SdtCustomer_Manager_RESTInterface>(sdt.gxTpr_Manager) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Manager);
         }

      }

      [DataMember( Name = "Locations" , Order = 13 )]
      public GxGenericCollection<SdtCustomer_Locations_RESTInterface> gxTpr_Locations
      {
         get {
            return new GxGenericCollection<SdtCustomer_Locations_RESTInterface>(sdt.gxTpr_Locations) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Locations);
         }

      }

      public SdtCustomer sdt
      {
         get {
            return (SdtCustomer)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCustomer() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Customer", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_RESTLInterface : GxGenericCollectionItem<SdtCustomer>
   {
      public SdtCustomer_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_RESTLInterface( SdtCustomer psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerKvkNumber" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Customerkvknumber
      {
         get {
            return sdt.gxTpr_Customerkvknumber ;
         }

         set {
            sdt.gxTpr_Customerkvknumber = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCustomer sdt
      {
         get {
            return (SdtCustomer)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCustomer() ;
         }
      }

   }

}
