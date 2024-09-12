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
   [XmlRoot(ElementName = "Customer.Manager" )]
   [XmlType(TypeName =  "Customer.Manager" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer_Manager : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCustomer_Manager( )
      {
      }

      public SdtCustomer_Manager( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"CustomerManagerId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Manager");
         metadata.Set("BT", "CustomerManager");
         metadata.Set("PK", "[ \"CustomerManagerId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerManagerId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Customermanagerid_Z");
         state.Add("gxTpr_Customermanagergivenname_Z");
         state.Add("gxTpr_Customermanagerlastname_Z");
         state.Add("gxTpr_Customermanagerinitials_Z");
         state.Add("gxTpr_Customermanageremail_Z");
         state.Add("gxTpr_Customermanagerphone_Z");
         state.Add("gxTpr_Customermanagergender_Z");
         state.Add("gxTpr_Customermanagergamguid_Z");
         state.Add("gxTpr_Customermanagerinitials_N");
         state.Add("gxTpr_Customermanagerphone_N");
         state.Add("gxTpr_Customermanagergender_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer_Manager sdt;
         sdt = (SdtCustomer_Manager)(source);
         gxTv_SdtCustomer_Manager_Customermanagerid = sdt.gxTv_SdtCustomer_Manager_Customermanagerid ;
         gxTv_SdtCustomer_Manager_Customermanagergivenname = sdt.gxTv_SdtCustomer_Manager_Customermanagergivenname ;
         gxTv_SdtCustomer_Manager_Customermanagerlastname = sdt.gxTv_SdtCustomer_Manager_Customermanagerlastname ;
         gxTv_SdtCustomer_Manager_Customermanagerinitials = sdt.gxTv_SdtCustomer_Manager_Customermanagerinitials ;
         gxTv_SdtCustomer_Manager_Customermanageremail = sdt.gxTv_SdtCustomer_Manager_Customermanageremail ;
         gxTv_SdtCustomer_Manager_Customermanagerphone = sdt.gxTv_SdtCustomer_Manager_Customermanagerphone ;
         gxTv_SdtCustomer_Manager_Customermanagergender = sdt.gxTv_SdtCustomer_Manager_Customermanagergender ;
         gxTv_SdtCustomer_Manager_Customermanagergamguid = sdt.gxTv_SdtCustomer_Manager_Customermanagergamguid ;
         gxTv_SdtCustomer_Manager_Mode = sdt.gxTv_SdtCustomer_Manager_Mode ;
         gxTv_SdtCustomer_Manager_Modified = sdt.gxTv_SdtCustomer_Manager_Modified ;
         gxTv_SdtCustomer_Manager_Initialized = sdt.gxTv_SdtCustomer_Manager_Initialized ;
         gxTv_SdtCustomer_Manager_Customermanagerid_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagerid_Z ;
         gxTv_SdtCustomer_Manager_Customermanagergivenname_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagergivenname_Z ;
         gxTv_SdtCustomer_Manager_Customermanagerlastname_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagerlastname_Z ;
         gxTv_SdtCustomer_Manager_Customermanagerinitials_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagerinitials_Z ;
         gxTv_SdtCustomer_Manager_Customermanageremail_Z = sdt.gxTv_SdtCustomer_Manager_Customermanageremail_Z ;
         gxTv_SdtCustomer_Manager_Customermanagerphone_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagerphone_Z ;
         gxTv_SdtCustomer_Manager_Customermanagergender_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagergender_Z ;
         gxTv_SdtCustomer_Manager_Customermanagergamguid_Z = sdt.gxTv_SdtCustomer_Manager_Customermanagergamguid_Z ;
         gxTv_SdtCustomer_Manager_Customermanagerinitials_N = sdt.gxTv_SdtCustomer_Manager_Customermanagerinitials_N ;
         gxTv_SdtCustomer_Manager_Customermanagerphone_N = sdt.gxTv_SdtCustomer_Manager_Customermanagerphone_N ;
         gxTv_SdtCustomer_Manager_Customermanagergender_N = sdt.gxTv_SdtCustomer_Manager_Customermanagergender_N ;
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
         AddObjectProperty("CustomerManagerId", gxTv_SdtCustomer_Manager_Customermanagerid, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerGivenName", gxTv_SdtCustomer_Manager_Customermanagergivenname, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerLastName", gxTv_SdtCustomer_Manager_Customermanagerlastname, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerInitials", gxTv_SdtCustomer_Manager_Customermanagerinitials, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerInitials_N", gxTv_SdtCustomer_Manager_Customermanagerinitials_N, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerEmail", gxTv_SdtCustomer_Manager_Customermanageremail, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerPhone", gxTv_SdtCustomer_Manager_Customermanagerphone, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerPhone_N", gxTv_SdtCustomer_Manager_Customermanagerphone_N, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerGender", gxTv_SdtCustomer_Manager_Customermanagergender, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerGender_N", gxTv_SdtCustomer_Manager_Customermanagergender_N, false, includeNonInitialized);
         AddObjectProperty("CustomerManagerGAMGUID", gxTv_SdtCustomer_Manager_Customermanagergamguid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Manager_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCustomer_Manager_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Manager_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerId_Z", gxTv_SdtCustomer_Manager_Customermanagerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerGivenName_Z", gxTv_SdtCustomer_Manager_Customermanagergivenname_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerLastName_Z", gxTv_SdtCustomer_Manager_Customermanagerlastname_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerInitials_Z", gxTv_SdtCustomer_Manager_Customermanagerinitials_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerEmail_Z", gxTv_SdtCustomer_Manager_Customermanageremail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerPhone_Z", gxTv_SdtCustomer_Manager_Customermanagerphone_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerGender_Z", gxTv_SdtCustomer_Manager_Customermanagergender_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerGAMGUID_Z", gxTv_SdtCustomer_Manager_Customermanagergamguid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerInitials_N", gxTv_SdtCustomer_Manager_Customermanagerinitials_N, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerPhone_N", gxTv_SdtCustomer_Manager_Customermanagerphone_N, false, includeNonInitialized);
            AddObjectProperty("CustomerManagerGender_N", gxTv_SdtCustomer_Manager_Customermanagergender_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer_Manager sdt )
      {
         if ( sdt.IsDirty("CustomerManagerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerid = sdt.gxTv_SdtCustomer_Manager_Customermanagerid ;
         }
         if ( sdt.IsDirty("CustomerManagerGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergivenname = sdt.gxTv_SdtCustomer_Manager_Customermanagergivenname ;
         }
         if ( sdt.IsDirty("CustomerManagerLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerlastname = sdt.gxTv_SdtCustomer_Manager_Customermanagerlastname ;
         }
         if ( sdt.IsDirty("CustomerManagerInitials") )
         {
            gxTv_SdtCustomer_Manager_Customermanagerinitials_N = (short)(sdt.gxTv_SdtCustomer_Manager_Customermanagerinitials_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerinitials = sdt.gxTv_SdtCustomer_Manager_Customermanagerinitials ;
         }
         if ( sdt.IsDirty("CustomerManagerEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanageremail = sdt.gxTv_SdtCustomer_Manager_Customermanageremail ;
         }
         if ( sdt.IsDirty("CustomerManagerPhone") )
         {
            gxTv_SdtCustomer_Manager_Customermanagerphone_N = (short)(sdt.gxTv_SdtCustomer_Manager_Customermanagerphone_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerphone = sdt.gxTv_SdtCustomer_Manager_Customermanagerphone ;
         }
         if ( sdt.IsDirty("CustomerManagerGender") )
         {
            gxTv_SdtCustomer_Manager_Customermanagergender_N = (short)(sdt.gxTv_SdtCustomer_Manager_Customermanagergender_N);
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergender = sdt.gxTv_SdtCustomer_Manager_Customermanagergender ;
         }
         if ( sdt.IsDirty("CustomerManagerGAMGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergamguid = sdt.gxTv_SdtCustomer_Manager_Customermanagergamguid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerManagerId" )]
      [  XmlElement( ElementName = "CustomerManagerId"   )]
      public short gxTpr_Customermanagerid
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerid = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerid");
         }

      }

      [  SoapElement( ElementName = "CustomerManagerGivenName" )]
      [  XmlElement( ElementName = "CustomerManagerGivenName"   )]
      public string gxTpr_Customermanagergivenname
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergivenname = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergivenname");
         }

      }

      [  SoapElement( ElementName = "CustomerManagerLastName" )]
      [  XmlElement( ElementName = "CustomerManagerLastName"   )]
      public string gxTpr_Customermanagerlastname
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerlastname = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerlastname");
         }

      }

      [  SoapElement( ElementName = "CustomerManagerInitials" )]
      [  XmlElement( ElementName = "CustomerManagerInitials"   )]
      public string gxTpr_Customermanagerinitials
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerinitials ;
         }

         set {
            gxTv_SdtCustomer_Manager_Customermanagerinitials_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerinitials = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerinitials");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerinitials_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerinitials_N = 1;
         gxTv_SdtCustomer_Manager_Customermanagerinitials = "";
         SetDirty("Customermanagerinitials");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerinitials_IsNull( )
      {
         return (gxTv_SdtCustomer_Manager_Customermanagerinitials_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerManagerEmail" )]
      [  XmlElement( ElementName = "CustomerManagerEmail"   )]
      public string gxTpr_Customermanageremail
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanageremail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanageremail = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanageremail");
         }

      }

      [  SoapElement( ElementName = "CustomerManagerPhone" )]
      [  XmlElement( ElementName = "CustomerManagerPhone"   )]
      public string gxTpr_Customermanagerphone
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerphone ;
         }

         set {
            gxTv_SdtCustomer_Manager_Customermanagerphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerphone = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerphone");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerphone_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerphone_N = 1;
         gxTv_SdtCustomer_Manager_Customermanagerphone = "";
         SetDirty("Customermanagerphone");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerphone_IsNull( )
      {
         return (gxTv_SdtCustomer_Manager_Customermanagerphone_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerManagerGender" )]
      [  XmlElement( ElementName = "CustomerManagerGender"   )]
      public string gxTpr_Customermanagergender
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergender ;
         }

         set {
            gxTv_SdtCustomer_Manager_Customermanagergender_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergender = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergender");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagergender_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagergender_N = 1;
         gxTv_SdtCustomer_Manager_Customermanagergender = "";
         SetDirty("Customermanagergender");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagergender_IsNull( )
      {
         return (gxTv_SdtCustomer_Manager_Customermanagergender_N==1) ;
      }

      [  SoapElement( ElementName = "CustomerManagerGAMGUID" )]
      [  XmlElement( ElementName = "CustomerManagerGAMGUID"   )]
      public string gxTpr_Customermanagergamguid
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergamguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergamguid = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergamguid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Manager_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Manager_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCustomer_Manager_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCustomer_Manager_Modified_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Manager_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Initialized = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Manager_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerId_Z" )]
      [  XmlElement( ElementName = "CustomerManagerId_Z"   )]
      public short gxTpr_Customermanagerid_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerid_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerid_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerid_Z = 0;
         SetDirty("Customermanagerid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerGivenName_Z" )]
      [  XmlElement( ElementName = "CustomerManagerGivenName_Z"   )]
      public string gxTpr_Customermanagergivenname_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergivenname_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergivenname_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagergivenname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagergivenname_Z = "";
         SetDirty("Customermanagergivenname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagergivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerLastName_Z" )]
      [  XmlElement( ElementName = "CustomerManagerLastName_Z"   )]
      public string gxTpr_Customermanagerlastname_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerlastname_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerlastname_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerlastname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerlastname_Z = "";
         SetDirty("Customermanagerlastname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerInitials_Z" )]
      [  XmlElement( ElementName = "CustomerManagerInitials_Z"   )]
      public string gxTpr_Customermanagerinitials_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerinitials_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerinitials_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerinitials_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerinitials_Z = "";
         SetDirty("Customermanagerinitials_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerEmail_Z" )]
      [  XmlElement( ElementName = "CustomerManagerEmail_Z"   )]
      public string gxTpr_Customermanageremail_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanageremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanageremail_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanageremail_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanageremail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanageremail_Z = "";
         SetDirty("Customermanageremail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanageremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerPhone_Z" )]
      [  XmlElement( ElementName = "CustomerManagerPhone_Z"   )]
      public string gxTpr_Customermanagerphone_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerphone_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerphone_Z = "";
         SetDirty("Customermanagerphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerGender_Z" )]
      [  XmlElement( ElementName = "CustomerManagerGender_Z"   )]
      public string gxTpr_Customermanagergender_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergender_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergender_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagergender_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagergender_Z = "";
         SetDirty("Customermanagergender_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagergender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerGAMGUID_Z" )]
      [  XmlElement( ElementName = "CustomerManagerGAMGUID_Z"   )]
      public string gxTpr_Customermanagergamguid_Z
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergamguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergamguid_Z = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergamguid_Z");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagergamguid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagergamguid_Z = "";
         SetDirty("Customermanagergamguid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagergamguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerInitials_N" )]
      [  XmlElement( ElementName = "CustomerManagerInitials_N"   )]
      public short gxTpr_Customermanagerinitials_N
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerinitials_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerinitials_N = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerinitials_N");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerinitials_N_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerinitials_N = 0;
         SetDirty("Customermanagerinitials_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerinitials_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerPhone_N" )]
      [  XmlElement( ElementName = "CustomerManagerPhone_N"   )]
      public short gxTpr_Customermanagerphone_N
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagerphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagerphone_N = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagerphone_N");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagerphone_N_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagerphone_N = 0;
         SetDirty("Customermanagerphone_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagerphone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerManagerGender_N" )]
      [  XmlElement( ElementName = "CustomerManagerGender_N"   )]
      public short gxTpr_Customermanagergender_N
      {
         get {
            return gxTv_SdtCustomer_Manager_Customermanagergender_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Manager_Customermanagergender_N = value;
            gxTv_SdtCustomer_Manager_Modified = 1;
            SetDirty("Customermanagergender_N");
         }

      }

      public void gxTv_SdtCustomer_Manager_Customermanagergender_N_SetNull( )
      {
         gxTv_SdtCustomer_Manager_Customermanagergender_N = 0;
         SetDirty("Customermanagergender_N");
         return  ;
      }

      public bool gxTv_SdtCustomer_Manager_Customermanagergender_N_IsNull( )
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
         gxTv_SdtCustomer_Manager_Customermanagergivenname = "";
         gxTv_SdtCustomer_Manager_Customermanagerlastname = "";
         gxTv_SdtCustomer_Manager_Customermanagerinitials = "";
         gxTv_SdtCustomer_Manager_Customermanageremail = "";
         gxTv_SdtCustomer_Manager_Customermanagerphone = "";
         gxTv_SdtCustomer_Manager_Customermanagergender = "";
         gxTv_SdtCustomer_Manager_Customermanagergamguid = "";
         gxTv_SdtCustomer_Manager_Mode = "";
         gxTv_SdtCustomer_Manager_Customermanagergivenname_Z = "";
         gxTv_SdtCustomer_Manager_Customermanagerlastname_Z = "";
         gxTv_SdtCustomer_Manager_Customermanagerinitials_Z = "";
         gxTv_SdtCustomer_Manager_Customermanageremail_Z = "";
         gxTv_SdtCustomer_Manager_Customermanagerphone_Z = "";
         gxTv_SdtCustomer_Manager_Customermanagergender_Z = "";
         gxTv_SdtCustomer_Manager_Customermanagergamguid_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Manager_Customermanagerid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Manager_Modified ;
      private short gxTv_SdtCustomer_Manager_Initialized ;
      private short gxTv_SdtCustomer_Manager_Customermanagerid_Z ;
      private short gxTv_SdtCustomer_Manager_Customermanagerinitials_N ;
      private short gxTv_SdtCustomer_Manager_Customermanagerphone_N ;
      private short gxTv_SdtCustomer_Manager_Customermanagergender_N ;
      private string gxTv_SdtCustomer_Manager_Customermanagerinitials ;
      private string gxTv_SdtCustomer_Manager_Customermanagerphone ;
      private string gxTv_SdtCustomer_Manager_Customermanagergender ;
      private string gxTv_SdtCustomer_Manager_Mode ;
      private string gxTv_SdtCustomer_Manager_Customermanagerinitials_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanagerphone_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanagergender_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanagergivenname ;
      private string gxTv_SdtCustomer_Manager_Customermanagerlastname ;
      private string gxTv_SdtCustomer_Manager_Customermanageremail ;
      private string gxTv_SdtCustomer_Manager_Customermanagergamguid ;
      private string gxTv_SdtCustomer_Manager_Customermanagergivenname_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanagerlastname_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanageremail_Z ;
      private string gxTv_SdtCustomer_Manager_Customermanagergamguid_Z ;
   }

   [DataContract(Name = @"Customer.Manager", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Manager_RESTInterface : GxGenericCollectionItem<SdtCustomer_Manager>
   {
      public SdtCustomer_Manager_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_Manager_RESTInterface( SdtCustomer_Manager psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerManagerId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customermanagerid
      {
         get {
            return sdt.gxTpr_Customermanagerid ;
         }

         set {
            sdt.gxTpr_Customermanagerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerManagerGivenName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Customermanagergivenname
      {
         get {
            return sdt.gxTpr_Customermanagergivenname ;
         }

         set {
            sdt.gxTpr_Customermanagergivenname = value;
         }

      }

      [DataMember( Name = "CustomerManagerLastName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customermanagerlastname
      {
         get {
            return sdt.gxTpr_Customermanagerlastname ;
         }

         set {
            sdt.gxTpr_Customermanagerlastname = value;
         }

      }

      [DataMember( Name = "CustomerManagerInitials" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customermanagerinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customermanagerinitials) ;
         }

         set {
            sdt.gxTpr_Customermanagerinitials = value;
         }

      }

      [DataMember( Name = "CustomerManagerEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customermanageremail
      {
         get {
            return sdt.gxTpr_Customermanageremail ;
         }

         set {
            sdt.gxTpr_Customermanageremail = value;
         }

      }

      [DataMember( Name = "CustomerManagerPhone" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Customermanagerphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customermanagerphone) ;
         }

         set {
            sdt.gxTpr_Customermanagerphone = value;
         }

      }

      [DataMember( Name = "CustomerManagerGender" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Customermanagergender
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customermanagergender) ;
         }

         set {
            sdt.gxTpr_Customermanagergender = value;
         }

      }

      [DataMember( Name = "CustomerManagerGAMGUID" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Customermanagergamguid
      {
         get {
            return sdt.gxTpr_Customermanagergamguid ;
         }

         set {
            sdt.gxTpr_Customermanagergamguid = value;
         }

      }

      public SdtCustomer_Manager sdt
      {
         get {
            return (SdtCustomer_Manager)Sdt ;
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
            sdt = new SdtCustomer_Manager() ;
         }
      }

   }

   [DataContract(Name = @"Customer.Manager", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Manager_RESTLInterface : GxGenericCollectionItem<SdtCustomer_Manager>
   {
      public SdtCustomer_Manager_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_Manager_RESTLInterface( SdtCustomer_Manager psdt ) : base(psdt)
      {
      }

      public SdtCustomer_Manager sdt
      {
         get {
            return (SdtCustomer_Manager)Sdt ;
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
            sdt = new SdtCustomer_Manager() ;
         }
      }

   }

}
