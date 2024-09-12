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
   [XmlRoot(ElementName = "Resident.INCompany" )]
   [XmlType(TypeName =  "Resident.INCompany" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtResident_INCompany : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtResident_INCompany( )
      {
      }

      public SdtResident_INCompany( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ResidentINCompanyId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "INCompany");
         metadata.Set("BT", "ResidentINCompany");
         metadata.Set("PK", "[ \"ResidentINCompanyId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentINCompanyId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ResidentId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Residentincompanyid_Z");
         state.Add("gxTpr_Residentincompanykvknumber_Z");
         state.Add("gxTpr_Residentincompanyname_Z");
         state.Add("gxTpr_Residentincompanyemail_Z");
         state.Add("gxTpr_Residentincompanyphone_Z");
         state.Add("gxTpr_Residentincompanyemail_N");
         state.Add("gxTpr_Residentincompanyphone_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtResident_INCompany sdt;
         sdt = (SdtResident_INCompany)(source);
         gxTv_SdtResident_INCompany_Residentincompanyid = sdt.gxTv_SdtResident_INCompany_Residentincompanyid ;
         gxTv_SdtResident_INCompany_Residentincompanykvknumber = sdt.gxTv_SdtResident_INCompany_Residentincompanykvknumber ;
         gxTv_SdtResident_INCompany_Residentincompanyname = sdt.gxTv_SdtResident_INCompany_Residentincompanyname ;
         gxTv_SdtResident_INCompany_Residentincompanyemail = sdt.gxTv_SdtResident_INCompany_Residentincompanyemail ;
         gxTv_SdtResident_INCompany_Residentincompanyphone = sdt.gxTv_SdtResident_INCompany_Residentincompanyphone ;
         gxTv_SdtResident_INCompany_Mode = sdt.gxTv_SdtResident_INCompany_Mode ;
         gxTv_SdtResident_INCompany_Modified = sdt.gxTv_SdtResident_INCompany_Modified ;
         gxTv_SdtResident_INCompany_Initialized = sdt.gxTv_SdtResident_INCompany_Initialized ;
         gxTv_SdtResident_INCompany_Residentincompanyid_Z = sdt.gxTv_SdtResident_INCompany_Residentincompanyid_Z ;
         gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z = sdt.gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z ;
         gxTv_SdtResident_INCompany_Residentincompanyname_Z = sdt.gxTv_SdtResident_INCompany_Residentincompanyname_Z ;
         gxTv_SdtResident_INCompany_Residentincompanyemail_Z = sdt.gxTv_SdtResident_INCompany_Residentincompanyemail_Z ;
         gxTv_SdtResident_INCompany_Residentincompanyphone_Z = sdt.gxTv_SdtResident_INCompany_Residentincompanyphone_Z ;
         gxTv_SdtResident_INCompany_Residentincompanyemail_N = sdt.gxTv_SdtResident_INCompany_Residentincompanyemail_N ;
         gxTv_SdtResident_INCompany_Residentincompanyphone_N = sdt.gxTv_SdtResident_INCompany_Residentincompanyphone_N ;
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
         AddObjectProperty("ResidentINCompanyId", gxTv_SdtResident_INCompany_Residentincompanyid, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyKvkNumber", gxTv_SdtResident_INCompany_Residentincompanykvknumber, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyName", gxTv_SdtResident_INCompany_Residentincompanyname, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyEmail", gxTv_SdtResident_INCompany_Residentincompanyemail, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyEmail_N", gxTv_SdtResident_INCompany_Residentincompanyemail_N, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyPhone", gxTv_SdtResident_INCompany_Residentincompanyphone, false, includeNonInitialized);
         AddObjectProperty("ResidentINCompanyPhone_N", gxTv_SdtResident_INCompany_Residentincompanyphone_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtResident_INCompany_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtResident_INCompany_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtResident_INCompany_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyId_Z", gxTv_SdtResident_INCompany_Residentincompanyid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyKvkNumber_Z", gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyName_Z", gxTv_SdtResident_INCompany_Residentincompanyname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyEmail_Z", gxTv_SdtResident_INCompany_Residentincompanyemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyPhone_Z", gxTv_SdtResident_INCompany_Residentincompanyphone_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyEmail_N", gxTv_SdtResident_INCompany_Residentincompanyemail_N, false, includeNonInitialized);
            AddObjectProperty("ResidentINCompanyPhone_N", gxTv_SdtResident_INCompany_Residentincompanyphone_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtResident_INCompany sdt )
      {
         if ( sdt.IsDirty("ResidentINCompanyId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyid = sdt.gxTv_SdtResident_INCompany_Residentincompanyid ;
         }
         if ( sdt.IsDirty("ResidentINCompanyKvkNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanykvknumber = sdt.gxTv_SdtResident_INCompany_Residentincompanykvknumber ;
         }
         if ( sdt.IsDirty("ResidentINCompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyname = sdt.gxTv_SdtResident_INCompany_Residentincompanyname ;
         }
         if ( sdt.IsDirty("ResidentINCompanyEmail") )
         {
            gxTv_SdtResident_INCompany_Residentincompanyemail_N = (short)(sdt.gxTv_SdtResident_INCompany_Residentincompanyemail_N);
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyemail = sdt.gxTv_SdtResident_INCompany_Residentincompanyemail ;
         }
         if ( sdt.IsDirty("ResidentINCompanyPhone") )
         {
            gxTv_SdtResident_INCompany_Residentincompanyphone_N = (short)(sdt.gxTv_SdtResident_INCompany_Residentincompanyphone_N);
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyphone = sdt.gxTv_SdtResident_INCompany_Residentincompanyphone ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyId" )]
      [  XmlElement( ElementName = "ResidentINCompanyId"   )]
      public short gxTpr_Residentincompanyid
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyid = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyid");
         }

      }

      [  SoapElement( ElementName = "ResidentINCompanyKvkNumber" )]
      [  XmlElement( ElementName = "ResidentINCompanyKvkNumber"   )]
      public string gxTpr_Residentincompanykvknumber
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanykvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanykvknumber = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanykvknumber");
         }

      }

      [  SoapElement( ElementName = "ResidentINCompanyName" )]
      [  XmlElement( ElementName = "ResidentINCompanyName"   )]
      public string gxTpr_Residentincompanyname
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyname = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyname");
         }

      }

      [  SoapElement( ElementName = "ResidentINCompanyEmail" )]
      [  XmlElement( ElementName = "ResidentINCompanyEmail"   )]
      public string gxTpr_Residentincompanyemail
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyemail ;
         }

         set {
            gxTv_SdtResident_INCompany_Residentincompanyemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyemail = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyemail");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyemail_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyemail_N = 1;
         gxTv_SdtResident_INCompany_Residentincompanyemail = "";
         SetDirty("Residentincompanyemail");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyemail_IsNull( )
      {
         return (gxTv_SdtResident_INCompany_Residentincompanyemail_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyPhone" )]
      [  XmlElement( ElementName = "ResidentINCompanyPhone"   )]
      public string gxTpr_Residentincompanyphone
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyphone ;
         }

         set {
            gxTv_SdtResident_INCompany_Residentincompanyphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyphone = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyphone");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyphone_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyphone_N = 1;
         gxTv_SdtResident_INCompany_Residentincompanyphone = "";
         SetDirty("Residentincompanyphone");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyphone_IsNull( )
      {
         return (gxTv_SdtResident_INCompany_Residentincompanyphone_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtResident_INCompany_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtResident_INCompany_Mode_SetNull( )
      {
         gxTv_SdtResident_INCompany_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtResident_INCompany_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtResident_INCompany_Modified_SetNull( )
      {
         gxTv_SdtResident_INCompany_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtResident_INCompany_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Initialized = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtResident_INCompany_Initialized_SetNull( )
      {
         gxTv_SdtResident_INCompany_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyId_Z" )]
      [  XmlElement( ElementName = "ResidentINCompanyId_Z"   )]
      public short gxTpr_Residentincompanyid_Z
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyid_Z = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyid_Z");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyid_Z_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyid_Z = 0;
         SetDirty("Residentincompanyid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyKvkNumber_Z" )]
      [  XmlElement( ElementName = "ResidentINCompanyKvkNumber_Z"   )]
      public string gxTpr_Residentincompanykvknumber_Z
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanykvknumber_Z");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z = "";
         SetDirty("Residentincompanykvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyName_Z" )]
      [  XmlElement( ElementName = "ResidentINCompanyName_Z"   )]
      public string gxTpr_Residentincompanyname_Z
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyname_Z = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyname_Z");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyname_Z_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyname_Z = "";
         SetDirty("Residentincompanyname_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyEmail_Z" )]
      [  XmlElement( ElementName = "ResidentINCompanyEmail_Z"   )]
      public string gxTpr_Residentincompanyemail_Z
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyemail_Z = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyemail_Z");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyemail_Z_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyemail_Z = "";
         SetDirty("Residentincompanyemail_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyPhone_Z" )]
      [  XmlElement( ElementName = "ResidentINCompanyPhone_Z"   )]
      public string gxTpr_Residentincompanyphone_Z
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyphone_Z = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyphone_Z");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyphone_Z_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyphone_Z = "";
         SetDirty("Residentincompanyphone_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyEmail_N" )]
      [  XmlElement( ElementName = "ResidentINCompanyEmail_N"   )]
      public short gxTpr_Residentincompanyemail_N
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyemail_N = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyemail_N");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyemail_N_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyemail_N = 0;
         SetDirty("Residentincompanyemail_N");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINCompanyPhone_N" )]
      [  XmlElement( ElementName = "ResidentINCompanyPhone_N"   )]
      public short gxTpr_Residentincompanyphone_N
      {
         get {
            return gxTv_SdtResident_INCompany_Residentincompanyphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INCompany_Residentincompanyphone_N = value;
            gxTv_SdtResident_INCompany_Modified = 1;
            SetDirty("Residentincompanyphone_N");
         }

      }

      public void gxTv_SdtResident_INCompany_Residentincompanyphone_N_SetNull( )
      {
         gxTv_SdtResident_INCompany_Residentincompanyphone_N = 0;
         SetDirty("Residentincompanyphone_N");
         return  ;
      }

      public bool gxTv_SdtResident_INCompany_Residentincompanyphone_N_IsNull( )
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
         gxTv_SdtResident_INCompany_Residentincompanykvknumber = "";
         gxTv_SdtResident_INCompany_Residentincompanyname = "";
         gxTv_SdtResident_INCompany_Residentincompanyemail = "";
         gxTv_SdtResident_INCompany_Residentincompanyphone = "";
         gxTv_SdtResident_INCompany_Mode = "";
         gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z = "";
         gxTv_SdtResident_INCompany_Residentincompanyname_Z = "";
         gxTv_SdtResident_INCompany_Residentincompanyemail_Z = "";
         gxTv_SdtResident_INCompany_Residentincompanyphone_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtResident_INCompany_Residentincompanyid ;
      private short sdtIsNull ;
      private short gxTv_SdtResident_INCompany_Modified ;
      private short gxTv_SdtResident_INCompany_Initialized ;
      private short gxTv_SdtResident_INCompany_Residentincompanyid_Z ;
      private short gxTv_SdtResident_INCompany_Residentincompanyemail_N ;
      private short gxTv_SdtResident_INCompany_Residentincompanyphone_N ;
      private string gxTv_SdtResident_INCompany_Residentincompanyphone ;
      private string gxTv_SdtResident_INCompany_Mode ;
      private string gxTv_SdtResident_INCompany_Residentincompanyphone_Z ;
      private string gxTv_SdtResident_INCompany_Residentincompanykvknumber ;
      private string gxTv_SdtResident_INCompany_Residentincompanyname ;
      private string gxTv_SdtResident_INCompany_Residentincompanyemail ;
      private string gxTv_SdtResident_INCompany_Residentincompanykvknumber_Z ;
      private string gxTv_SdtResident_INCompany_Residentincompanyname_Z ;
      private string gxTv_SdtResident_INCompany_Residentincompanyemail_Z ;
   }

   [DataContract(Name = @"Resident.INCompany", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_INCompany_RESTInterface : GxGenericCollectionItem<SdtResident_INCompany>
   {
      public SdtResident_INCompany_RESTInterface( ) : base()
      {
      }

      public SdtResident_INCompany_RESTInterface( SdtResident_INCompany psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentINCompanyId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residentincompanyid
      {
         get {
            return sdt.gxTpr_Residentincompanyid ;
         }

         set {
            sdt.gxTpr_Residentincompanyid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResidentINCompanyKvkNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Residentincompanykvknumber
      {
         get {
            return sdt.gxTpr_Residentincompanykvknumber ;
         }

         set {
            sdt.gxTpr_Residentincompanykvknumber = value;
         }

      }

      [DataMember( Name = "ResidentINCompanyName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Residentincompanyname
      {
         get {
            return sdt.gxTpr_Residentincompanyname ;
         }

         set {
            sdt.gxTpr_Residentincompanyname = value;
         }

      }

      [DataMember( Name = "ResidentINCompanyEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Residentincompanyemail
      {
         get {
            return sdt.gxTpr_Residentincompanyemail ;
         }

         set {
            sdt.gxTpr_Residentincompanyemail = value;
         }

      }

      [DataMember( Name = "ResidentINCompanyPhone" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Residentincompanyphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentincompanyphone) ;
         }

         set {
            sdt.gxTpr_Residentincompanyphone = value;
         }

      }

      public SdtResident_INCompany sdt
      {
         get {
            return (SdtResident_INCompany)Sdt ;
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
            sdt = new SdtResident_INCompany() ;
         }
      }

   }

   [DataContract(Name = @"Resident.INCompany", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_INCompany_RESTLInterface : GxGenericCollectionItem<SdtResident_INCompany>
   {
      public SdtResident_INCompany_RESTLInterface( ) : base()
      {
      }

      public SdtResident_INCompany_RESTLInterface( SdtResident_INCompany psdt ) : base(psdt)
      {
      }

      public SdtResident_INCompany sdt
      {
         get {
            return (SdtResident_INCompany)Sdt ;
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
            sdt = new SdtResident_INCompany() ;
         }
      }

   }

}
