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
   [XmlRoot(ElementName = "Customer.Locations.Supplier_Agb" )]
   [XmlType(TypeName =  "Customer.Locations.Supplier_Agb" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer_Locations_Supplier_Agb : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCustomer_Locations_Supplier_Agb( )
      {
      }

      public SdtCustomer_Locations_Supplier_Agb( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Supplier_AgbId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Supplier_Agb");
         metadata.Set("BT", "CustomerLocationSupplier_Agb");
         metadata.Set("PK", "[ \"Supplier_AgbId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\",\"CustomerLocationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Supplier_AgbId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Supplier_agbid_Z");
         state.Add("gxTpr_Supplier_agbnumber_Z");
         state.Add("gxTpr_Supplier_agbname_Z");
         state.Add("gxTpr_Supplier_agbkvknumber_Z");
         state.Add("gxTpr_Supplier_agbvisitingaddress_Z");
         state.Add("gxTpr_Supplier_agbpostaladdress_Z");
         state.Add("gxTpr_Supplier_agbemail_Z");
         state.Add("gxTpr_Supplier_agbphone_Z");
         state.Add("gxTpr_Supplier_agbcontactname_Z");
         state.Add("gxTpr_Supplier_agbvisitingaddress_N");
         state.Add("gxTpr_Supplier_agbpostaladdress_N");
         state.Add("gxTpr_Supplier_agbemail_N");
         state.Add("gxTpr_Supplier_agbphone_N");
         state.Add("gxTpr_Supplier_agbcontactname_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer_Locations_Supplier_Agb sdt;
         sdt = (SdtCustomer_Locations_Supplier_Agb)(source);
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Mode = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Mode ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Modified ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N ;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N ;
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
         AddObjectProperty("Supplier_AgbId", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbNumber", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbName", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbKvkNumber", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbVisitingAddress", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbVisitingAddress_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbPostalAddress", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbPostalAddress_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbEmail", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbEmail_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbPhone", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbPhone_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbContactName", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname, false, includeNonInitialized);
         AddObjectProperty("Supplier_AgbContactName_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Locations_Supplier_Agb_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCustomer_Locations_Supplier_Agb_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbId_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbNumber_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbName_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbKvkNumber_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbVisitingAddress_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbPostalAddress_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbEmail_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbPhone_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbContactName_Z", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbVisitingAddress_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbPostalAddress_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbEmail_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbPhone_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_AgbContactName_N", gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer_Locations_Supplier_Agb sdt )
      {
         if ( sdt.IsDirty("Supplier_AgbId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid ;
         }
         if ( sdt.IsDirty("Supplier_AgbNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber ;
         }
         if ( sdt.IsDirty("Supplier_AgbName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname ;
         }
         if ( sdt.IsDirty("Supplier_AgbKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber ;
         }
         if ( sdt.IsDirty("Supplier_AgbVisitingAddress") )
         {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = (short)(sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress ;
         }
         if ( sdt.IsDirty("Supplier_AgbPostalAddress") )
         {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = (short)(sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress ;
         }
         if ( sdt.IsDirty("Supplier_AgbEmail") )
         {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = (short)(sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail ;
         }
         if ( sdt.IsDirty("Supplier_AgbPhone") )
         {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = (short)(sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone ;
         }
         if ( sdt.IsDirty("Supplier_AgbContactName") )
         {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = (short)(sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname = sdt.gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Supplier_AgbId" )]
      [  XmlElement( ElementName = "Supplier_AgbId"   )]
      public short gxTpr_Supplier_agbid
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbid");
         }

      }

      [  SoapElement( ElementName = "Supplier_AgbNumber" )]
      [  XmlElement( ElementName = "Supplier_AgbNumber"   )]
      public string gxTpr_Supplier_agbnumber
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbnumber");
         }

      }

      [  SoapElement( ElementName = "Supplier_AgbName" )]
      [  XmlElement( ElementName = "Supplier_AgbName"   )]
      public string gxTpr_Supplier_agbname
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbname");
         }

      }

      [  SoapElement( ElementName = "Supplier_AgbKvkNumber" )]
      [  XmlElement( ElementName = "Supplier_AgbKvkNumber"   )]
      public string gxTpr_Supplier_agbkvknumber
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbkvknumber");
         }

      }

      [  SoapElement( ElementName = "Supplier_AgbVisitingAddress" )]
      [  XmlElement( ElementName = "Supplier_AgbVisitingAddress"   )]
      public string gxTpr_Supplier_agbvisitingaddress
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress ;
         }

         set {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbvisitingaddress");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = 1;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress = "";
         SetDirty("Supplier_agbvisitingaddress");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPostalAddress" )]
      [  XmlElement( ElementName = "Supplier_AgbPostalAddress"   )]
      public string gxTpr_Supplier_agbpostaladdress
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress ;
         }

         set {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbpostaladdress");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = 1;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress = "";
         SetDirty("Supplier_agbpostaladdress");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_AgbEmail" )]
      [  XmlElement( ElementName = "Supplier_AgbEmail"   )]
      public string gxTpr_Supplier_agbemail
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail ;
         }

         set {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbemail");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = 1;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail = "";
         SetDirty("Supplier_agbemail");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPhone" )]
      [  XmlElement( ElementName = "Supplier_AgbPhone"   )]
      public string gxTpr_Supplier_agbphone
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone ;
         }

         set {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbphone");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = 1;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone = "";
         SetDirty("Supplier_agbphone");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_AgbContactName" )]
      [  XmlElement( ElementName = "Supplier_AgbContactName"   )]
      public string gxTpr_Supplier_agbcontactname
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname ;
         }

         set {
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbcontactname");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = 1;
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname = "";
         SetDirty("Supplier_agbcontactname");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Modified_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbId_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbId_Z"   )]
      public short gxTpr_Supplier_agbid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z = 0;
         SetDirty("Supplier_agbid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbNumber_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbNumber_Z"   )]
      public string gxTpr_Supplier_agbnumber_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbnumber_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z = "";
         SetDirty("Supplier_agbnumber_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbName_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbName_Z"   )]
      public string gxTpr_Supplier_agbname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z = "";
         SetDirty("Supplier_agbname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbKvkNumber_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbKvkNumber_Z"   )]
      public string gxTpr_Supplier_agbkvknumber_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbkvknumber_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z = "";
         SetDirty("Supplier_agbkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbVisitingAddress_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbVisitingAddress_Z"   )]
      public string gxTpr_Supplier_agbvisitingaddress_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbvisitingaddress_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z = "";
         SetDirty("Supplier_agbvisitingaddress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPostalAddress_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbPostalAddress_Z"   )]
      public string gxTpr_Supplier_agbpostaladdress_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbpostaladdress_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z = "";
         SetDirty("Supplier_agbpostaladdress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbEmail_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbEmail_Z"   )]
      public string gxTpr_Supplier_agbemail_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbemail_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z = "";
         SetDirty("Supplier_agbemail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPhone_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbPhone_Z"   )]
      public string gxTpr_Supplier_agbphone_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z = "";
         SetDirty("Supplier_agbphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbContactName_Z" )]
      [  XmlElement( ElementName = "Supplier_AgbContactName_Z"   )]
      public string gxTpr_Supplier_agbcontactname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbcontactname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z = "";
         SetDirty("Supplier_agbcontactname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbVisitingAddress_N" )]
      [  XmlElement( ElementName = "Supplier_AgbVisitingAddress_N"   )]
      public short gxTpr_Supplier_agbvisitingaddress_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbvisitingaddress_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N = 0;
         SetDirty("Supplier_agbvisitingaddress_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPostalAddress_N" )]
      [  XmlElement( ElementName = "Supplier_AgbPostalAddress_N"   )]
      public short gxTpr_Supplier_agbpostaladdress_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbpostaladdress_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N = 0;
         SetDirty("Supplier_agbpostaladdress_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbEmail_N" )]
      [  XmlElement( ElementName = "Supplier_AgbEmail_N"   )]
      public short gxTpr_Supplier_agbemail_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbemail_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N = 0;
         SetDirty("Supplier_agbemail_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbPhone_N" )]
      [  XmlElement( ElementName = "Supplier_AgbPhone_N"   )]
      public short gxTpr_Supplier_agbphone_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbphone_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N = 0;
         SetDirty("Supplier_agbphone_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_AgbContactName_N" )]
      [  XmlElement( ElementName = "Supplier_AgbContactName_N"   )]
      public short gxTpr_Supplier_agbcontactname_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = value;
            gxTv_SdtCustomer_Locations_Supplier_Agb_Modified = 1;
            SetDirty("Supplier_agbcontactname_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N = 0;
         SetDirty("Supplier_agbcontactname_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N_IsNull( )
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
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Mode = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z = "";
         gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Modified ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Initialized ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbid_Z ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_N ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_N ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_N ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_N ;
      private short gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_N ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Mode ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbphone_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbnumber_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbname_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbkvknumber_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbvisitingaddress_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbpostaladdress_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbemail_Z ;
      private string gxTv_SdtCustomer_Locations_Supplier_Agb_Supplier_agbcontactname_Z ;
   }

   [DataContract(Name = @"Customer.Locations.Supplier_Agb", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Supplier_Agb_RESTInterface : GxGenericCollectionItem<SdtCustomer_Locations_Supplier_Agb>
   {
      public SdtCustomer_Locations_Supplier_Agb_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Supplier_Agb_RESTInterface( SdtCustomer_Locations_Supplier_Agb psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Supplier_AgbId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Supplier_agbid
      {
         get {
            return sdt.gxTpr_Supplier_agbid ;
         }

         set {
            sdt.gxTpr_Supplier_agbid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Supplier_AgbNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbnumber
      {
         get {
            return sdt.gxTpr_Supplier_agbnumber ;
         }

         set {
            sdt.gxTpr_Supplier_agbnumber = value;
         }

      }

      [DataMember( Name = "Supplier_AgbName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbname
      {
         get {
            return sdt.gxTpr_Supplier_agbname ;
         }

         set {
            sdt.gxTpr_Supplier_agbname = value;
         }

      }

      [DataMember( Name = "Supplier_AgbKvkNumber" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbkvknumber
      {
         get {
            return sdt.gxTpr_Supplier_agbkvknumber ;
         }

         set {
            sdt.gxTpr_Supplier_agbkvknumber = value;
         }

      }

      [DataMember( Name = "Supplier_AgbVisitingAddress" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbvisitingaddress
      {
         get {
            return sdt.gxTpr_Supplier_agbvisitingaddress ;
         }

         set {
            sdt.gxTpr_Supplier_agbvisitingaddress = value;
         }

      }

      [DataMember( Name = "Supplier_AgbPostalAddress" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbpostaladdress
      {
         get {
            return sdt.gxTpr_Supplier_agbpostaladdress ;
         }

         set {
            sdt.gxTpr_Supplier_agbpostaladdress = value;
         }

      }

      [DataMember( Name = "Supplier_AgbEmail" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbemail
      {
         get {
            return sdt.gxTpr_Supplier_agbemail ;
         }

         set {
            sdt.gxTpr_Supplier_agbemail = value;
         }

      }

      [DataMember( Name = "Supplier_AgbPhone" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Supplier_agbphone) ;
         }

         set {
            sdt.gxTpr_Supplier_agbphone = value;
         }

      }

      [DataMember( Name = "Supplier_AgbContactName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Supplier_agbcontactname
      {
         get {
            return sdt.gxTpr_Supplier_agbcontactname ;
         }

         set {
            sdt.gxTpr_Supplier_agbcontactname = value;
         }

      }

      public SdtCustomer_Locations_Supplier_Agb sdt
      {
         get {
            return (SdtCustomer_Locations_Supplier_Agb)Sdt ;
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
            sdt = new SdtCustomer_Locations_Supplier_Agb() ;
         }
      }

   }

   [DataContract(Name = @"Customer.Locations.Supplier_Agb", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Supplier_Agb_RESTLInterface : GxGenericCollectionItem<SdtCustomer_Locations_Supplier_Agb>
   {
      public SdtCustomer_Locations_Supplier_Agb_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Supplier_Agb_RESTLInterface( SdtCustomer_Locations_Supplier_Agb psdt ) : base(psdt)
      {
      }

      public SdtCustomer_Locations_Supplier_Agb sdt
      {
         get {
            return (SdtCustomer_Locations_Supplier_Agb)Sdt ;
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
            sdt = new SdtCustomer_Locations_Supplier_Agb() ;
         }
      }

   }

}
