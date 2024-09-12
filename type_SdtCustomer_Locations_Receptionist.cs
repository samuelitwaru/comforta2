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
   [XmlRoot(ElementName = "Customer.Locations.Receptionist" )]
   [XmlType(TypeName =  "Customer.Locations.Receptionist" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer_Locations_Receptionist : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCustomer_Locations_Receptionist( )
      {
      }

      public SdtCustomer_Locations_Receptionist( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"CustomerLocationReceptionistId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Receptionist");
         metadata.Set("BT", "CustomerLocationReceptionist");
         metadata.Set("PK", "[ \"CustomerLocationReceptionistId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerLocationReceptionistId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\",\"CustomerLocationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Customerlocationreceptionistid_Z");
         state.Add("gxTpr_Customerlocationreceptionistgivenname_Z");
         state.Add("gxTpr_Customerlocationreceptionistlastname_Z");
         state.Add("gxTpr_Customerlocationreceptionistinitials_Z");
         state.Add("gxTpr_Customerlocationreceptionistemail_Z");
         state.Add("gxTpr_Customerlocationreceptionistaddress_Z");
         state.Add("gxTpr_Customerlocationreceptionistphone_Z");
         state.Add("gxTpr_Customerlocationreceptionistgamguid_Z");
         state.Add("gxTpr_Customerlocationreceptionistinitials_N");
         state.Add("gxTpr_Customerlocationreceptionistaddress_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer_Locations_Receptionist sdt;
         sdt = (SdtCustomer_Locations_Receptionist)(source);
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid ;
         gxTv_SdtCustomer_Locations_Receptionist_Mode = sdt.gxTv_SdtCustomer_Locations_Receptionist_Mode ;
         gxTv_SdtCustomer_Locations_Receptionist_Modified = sdt.gxTv_SdtCustomer_Locations_Receptionist_Modified ;
         gxTv_SdtCustomer_Locations_Receptionist_Initialized = sdt.gxTv_SdtCustomer_Locations_Receptionist_Initialized ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N ;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N ;
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
         AddObjectProperty("CustomerLocationReceptionistId", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistGivenName", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistLastName", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistInitials", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistInitials_N", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistEmail", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistAddress", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistAddress_N", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistPhone", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationReceptionistGAMGUID", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Locations_Receptionist_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCustomer_Locations_Receptionist_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Locations_Receptionist_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistId_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistGivenName_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistLastName_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistInitials_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistEmail_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistAddress_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistPhone_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistGAMGUID_Z", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistInitials_N", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationReceptionistAddress_N", gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer_Locations_Receptionist sdt )
      {
         if ( sdt.IsDirty("CustomerLocationReceptionistId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistInitials") )
         {
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = (short)(sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistAddress") )
         {
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = (short)(sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone ;
         }
         if ( sdt.IsDirty("CustomerLocationReceptionistGAMGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid = sdt.gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistId" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistId"   )]
      public short gxTpr_Customerlocationreceptionistid
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistid");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistGivenName" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistGivenName"   )]
      public string gxTpr_Customerlocationreceptionistgivenname
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistgivenname");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistLastName" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistLastName"   )]
      public string gxTpr_Customerlocationreceptionistlastname
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistlastname");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistInitials" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistInitials"   )]
      public string gxTpr_Customerlocationreceptionistinitials
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials ;
         }

         set {
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistinitials");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = 1;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials = "";
         SetDirty("Customerlocationreceptionistinitials");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistEmail" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistEmail"   )]
      public string gxTpr_Customerlocationreceptionistemail
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistemail");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistAddress" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistAddress"   )]
      public string gxTpr_Customerlocationreceptionistaddress
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress ;
         }

         set {
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistaddress");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = 1;
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress = "";
         SetDirty("Customerlocationreceptionistaddress");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_IsNull( )
      {
         return (gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistPhone" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistPhone"   )]
      public string gxTpr_Customerlocationreceptionistphone
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistphone");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistGAMGUID" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistGAMGUID"   )]
      public string gxTpr_Customerlocationreceptionistgamguid
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistgamguid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Modified_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Initialized = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistId_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistId_Z"   )]
      public short gxTpr_Customerlocationreceptionistid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z = 0;
         SetDirty("Customerlocationreceptionistid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistGivenName_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistGivenName_Z"   )]
      public string gxTpr_Customerlocationreceptionistgivenname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistgivenname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z = "";
         SetDirty("Customerlocationreceptionistgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistLastName_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistLastName_Z"   )]
      public string gxTpr_Customerlocationreceptionistlastname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistlastname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z = "";
         SetDirty("Customerlocationreceptionistlastname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistInitials_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistInitials_Z"   )]
      public string gxTpr_Customerlocationreceptionistinitials_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistinitials_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z = "";
         SetDirty("Customerlocationreceptionistinitials_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistEmail_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistEmail_Z"   )]
      public string gxTpr_Customerlocationreceptionistemail_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistemail_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z = "";
         SetDirty("Customerlocationreceptionistemail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistAddress_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistAddress_Z"   )]
      public string gxTpr_Customerlocationreceptionistaddress_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistaddress_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z = "";
         SetDirty("Customerlocationreceptionistaddress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistPhone_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistPhone_Z"   )]
      public string gxTpr_Customerlocationreceptionistphone_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z = "";
         SetDirty("Customerlocationreceptionistphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistGAMGUID_Z" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistGAMGUID_Z"   )]
      public string gxTpr_Customerlocationreceptionistgamguid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistgamguid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z = "";
         SetDirty("Customerlocationreceptionistgamguid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistInitials_N" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistInitials_N"   )]
      public short gxTpr_Customerlocationreceptionistinitials_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistinitials_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N = 0;
         SetDirty("Customerlocationreceptionistinitials_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationReceptionistAddress_N" )]
      [  XmlElement( ElementName = "CustomerLocationReceptionistAddress_N"   )]
      public short gxTpr_Customerlocationreceptionistaddress_N
      {
         get {
            return gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = value;
            gxTv_SdtCustomer_Locations_Receptionist_Modified = 1;
            SetDirty("Customerlocationreceptionistaddress_N");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N = 0;
         SetDirty("Customerlocationreceptionistaddress_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N_IsNull( )
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
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid = "";
         gxTv_SdtCustomer_Locations_Receptionist_Mode = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z = "";
         gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Locations_Receptionist_Modified ;
      private short gxTv_SdtCustomer_Locations_Receptionist_Initialized ;
      private short gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistid_Z ;
      private short gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_N ;
      private short gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_N ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Mode ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistinitials_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistphone_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgivenname_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistlastname_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistemail_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistaddress_Z ;
      private string gxTv_SdtCustomer_Locations_Receptionist_Customerlocationreceptionistgamguid_Z ;
   }

   [DataContract(Name = @"Customer.Locations.Receptionist", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Receptionist_RESTInterface : GxGenericCollectionItem<SdtCustomer_Locations_Receptionist>
   {
      public SdtCustomer_Locations_Receptionist_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Receptionist_RESTInterface( SdtCustomer_Locations_Receptionist psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerLocationReceptionistId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlocationreceptionistid
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistid ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistGivenName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistgivenname
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistgivenname ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistgivenname = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistLastName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistlastname
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistlastname ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistlastname = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistInitials" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistinitials) ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistinitials = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistemail
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistemail ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistemail = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistAddress" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistaddress
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistaddress ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistaddress = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistPhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customerlocationreceptionistphone) ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistphone = value;
         }

      }

      [DataMember( Name = "CustomerLocationReceptionistGAMGUID" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationreceptionistgamguid
      {
         get {
            return sdt.gxTpr_Customerlocationreceptionistgamguid ;
         }

         set {
            sdt.gxTpr_Customerlocationreceptionistgamguid = value;
         }

      }

      public SdtCustomer_Locations_Receptionist sdt
      {
         get {
            return (SdtCustomer_Locations_Receptionist)Sdt ;
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
            sdt = new SdtCustomer_Locations_Receptionist() ;
         }
      }

   }

   [DataContract(Name = @"Customer.Locations.Receptionist", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Receptionist_RESTLInterface : GxGenericCollectionItem<SdtCustomer_Locations_Receptionist>
   {
      public SdtCustomer_Locations_Receptionist_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Receptionist_RESTLInterface( SdtCustomer_Locations_Receptionist psdt ) : base(psdt)
      {
      }

      public SdtCustomer_Locations_Receptionist sdt
      {
         get {
            return (SdtCustomer_Locations_Receptionist)Sdt ;
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
            sdt = new SdtCustomer_Locations_Receptionist() ;
         }
      }

   }

}
