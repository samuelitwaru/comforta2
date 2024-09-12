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
   [XmlRoot(ElementName = "Resident.INIndividual" )]
   [XmlType(TypeName =  "Resident.INIndividual" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtResident_INIndividual : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtResident_INIndividual( )
      {
      }

      public SdtResident_INIndividual( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ResidentINIndividualId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "INIndividual");
         metadata.Set("BT", "ResidentINIndividual");
         metadata.Set("PK", "[ \"ResidentINIndividualId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentINIndividualId\" ]");
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
         state.Add("gxTpr_Residentinindividualid_Z");
         state.Add("gxTpr_Residentinindividualbsnnumber_Z");
         state.Add("gxTpr_Residentinindividualgivenname_Z");
         state.Add("gxTpr_Residentinindividuallastname_Z");
         state.Add("gxTpr_Residentinindividualemail_Z");
         state.Add("gxTpr_Residentinindividualphone_Z");
         state.Add("gxTpr_Residentinindividualaddress_Z");
         state.Add("gxTpr_Residentinindividualgender_Z");
         state.Add("gxTpr_Residentinindividualemail_N");
         state.Add("gxTpr_Residentinindividualphone_N");
         state.Add("gxTpr_Residentinindividualaddress_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtResident_INIndividual sdt;
         sdt = (SdtResident_INIndividual)(source);
         gxTv_SdtResident_INIndividual_Residentinindividualid = sdt.gxTv_SdtResident_INIndividual_Residentinindividualid ;
         gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber = sdt.gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber ;
         gxTv_SdtResident_INIndividual_Residentinindividualgivenname = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgivenname ;
         gxTv_SdtResident_INIndividual_Residentinindividuallastname = sdt.gxTv_SdtResident_INIndividual_Residentinindividuallastname ;
         gxTv_SdtResident_INIndividual_Residentinindividualemail = sdt.gxTv_SdtResident_INIndividual_Residentinindividualemail ;
         gxTv_SdtResident_INIndividual_Residentinindividualphone = sdt.gxTv_SdtResident_INIndividual_Residentinindividualphone ;
         gxTv_SdtResident_INIndividual_Residentinindividualaddress = sdt.gxTv_SdtResident_INIndividual_Residentinindividualaddress ;
         gxTv_SdtResident_INIndividual_Residentinindividualgender = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgender ;
         gxTv_SdtResident_INIndividual_Mode = sdt.gxTv_SdtResident_INIndividual_Mode ;
         gxTv_SdtResident_INIndividual_Modified = sdt.gxTv_SdtResident_INIndividual_Modified ;
         gxTv_SdtResident_INIndividual_Initialized = sdt.gxTv_SdtResident_INIndividual_Initialized ;
         gxTv_SdtResident_INIndividual_Residentinindividualid_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualid_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualemail_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualemail_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualphone_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualphone_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualgender_Z = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgender_Z ;
         gxTv_SdtResident_INIndividual_Residentinindividualemail_N = sdt.gxTv_SdtResident_INIndividual_Residentinindividualemail_N ;
         gxTv_SdtResident_INIndividual_Residentinindividualphone_N = sdt.gxTv_SdtResident_INIndividual_Residentinindividualphone_N ;
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = sdt.gxTv_SdtResident_INIndividual_Residentinindividualaddress_N ;
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
         AddObjectProperty("ResidentINIndividualId", gxTv_SdtResident_INIndividual_Residentinindividualid, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualBsnNumber", gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualGivenName", gxTv_SdtResident_INIndividual_Residentinindividualgivenname, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualLastName", gxTv_SdtResident_INIndividual_Residentinindividuallastname, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualEmail", gxTv_SdtResident_INIndividual_Residentinindividualemail, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualEmail_N", gxTv_SdtResident_INIndividual_Residentinindividualemail_N, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualPhone", gxTv_SdtResident_INIndividual_Residentinindividualphone, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualPhone_N", gxTv_SdtResident_INIndividual_Residentinindividualphone_N, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualAddress", gxTv_SdtResident_INIndividual_Residentinindividualaddress, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualAddress_N", gxTv_SdtResident_INIndividual_Residentinindividualaddress_N, false, includeNonInitialized);
         AddObjectProperty("ResidentINIndividualGender", gxTv_SdtResident_INIndividual_Residentinindividualgender, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtResident_INIndividual_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtResident_INIndividual_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtResident_INIndividual_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualId_Z", gxTv_SdtResident_INIndividual_Residentinindividualid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualBsnNumber_Z", gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualGivenName_Z", gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualLastName_Z", gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualEmail_Z", gxTv_SdtResident_INIndividual_Residentinindividualemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualPhone_Z", gxTv_SdtResident_INIndividual_Residentinindividualphone_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualAddress_Z", gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualGender_Z", gxTv_SdtResident_INIndividual_Residentinindividualgender_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualEmail_N", gxTv_SdtResident_INIndividual_Residentinindividualemail_N, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualPhone_N", gxTv_SdtResident_INIndividual_Residentinindividualphone_N, false, includeNonInitialized);
            AddObjectProperty("ResidentINIndividualAddress_N", gxTv_SdtResident_INIndividual_Residentinindividualaddress_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtResident_INIndividual sdt )
      {
         if ( sdt.IsDirty("ResidentINIndividualId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualid = sdt.gxTv_SdtResident_INIndividual_Residentinindividualid ;
         }
         if ( sdt.IsDirty("ResidentINIndividualBsnNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber = sdt.gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber ;
         }
         if ( sdt.IsDirty("ResidentINIndividualGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgivenname = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgivenname ;
         }
         if ( sdt.IsDirty("ResidentINIndividualLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividuallastname = sdt.gxTv_SdtResident_INIndividual_Residentinindividuallastname ;
         }
         if ( sdt.IsDirty("ResidentINIndividualEmail") )
         {
            gxTv_SdtResident_INIndividual_Residentinindividualemail_N = (short)(sdt.gxTv_SdtResident_INIndividual_Residentinindividualemail_N);
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualemail = sdt.gxTv_SdtResident_INIndividual_Residentinindividualemail ;
         }
         if ( sdt.IsDirty("ResidentINIndividualPhone") )
         {
            gxTv_SdtResident_INIndividual_Residentinindividualphone_N = (short)(sdt.gxTv_SdtResident_INIndividual_Residentinindividualphone_N);
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualphone = sdt.gxTv_SdtResident_INIndividual_Residentinindividualphone ;
         }
         if ( sdt.IsDirty("ResidentINIndividualAddress") )
         {
            gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = (short)(sdt.gxTv_SdtResident_INIndividual_Residentinindividualaddress_N);
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualaddress = sdt.gxTv_SdtResident_INIndividual_Residentinindividualaddress ;
         }
         if ( sdt.IsDirty("ResidentINIndividualGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgender = sdt.gxTv_SdtResident_INIndividual_Residentinindividualgender ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualId" )]
      [  XmlElement( ElementName = "ResidentINIndividualId"   )]
      public short gxTpr_Residentinindividualid
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualid = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualid");
         }

      }

      [  SoapElement( ElementName = "ResidentINIndividualBsnNumber" )]
      [  XmlElement( ElementName = "ResidentINIndividualBsnNumber"   )]
      public string gxTpr_Residentinindividualbsnnumber
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualbsnnumber");
         }

      }

      [  SoapElement( ElementName = "ResidentINIndividualGivenName" )]
      [  XmlElement( ElementName = "ResidentINIndividualGivenName"   )]
      public string gxTpr_Residentinindividualgivenname
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgivenname = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualgivenname");
         }

      }

      [  SoapElement( ElementName = "ResidentINIndividualLastName" )]
      [  XmlElement( ElementName = "ResidentINIndividualLastName"   )]
      public string gxTpr_Residentinindividuallastname
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividuallastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividuallastname = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividuallastname");
         }

      }

      [  SoapElement( ElementName = "ResidentINIndividualEmail" )]
      [  XmlElement( ElementName = "ResidentINIndividualEmail"   )]
      public string gxTpr_Residentinindividualemail
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualemail ;
         }

         set {
            gxTv_SdtResident_INIndividual_Residentinindividualemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualemail = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualemail");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualemail_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualemail_N = 1;
         gxTv_SdtResident_INIndividual_Residentinindividualemail = "";
         SetDirty("Residentinindividualemail");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualemail_IsNull( )
      {
         return (gxTv_SdtResident_INIndividual_Residentinindividualemail_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualPhone" )]
      [  XmlElement( ElementName = "ResidentINIndividualPhone"   )]
      public string gxTpr_Residentinindividualphone
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualphone ;
         }

         set {
            gxTv_SdtResident_INIndividual_Residentinindividualphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualphone = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualphone");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualphone_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualphone_N = 1;
         gxTv_SdtResident_INIndividual_Residentinindividualphone = "";
         SetDirty("Residentinindividualphone");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualphone_IsNull( )
      {
         return (gxTv_SdtResident_INIndividual_Residentinindividualphone_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualAddress" )]
      [  XmlElement( ElementName = "ResidentINIndividualAddress"   )]
      public string gxTpr_Residentinindividualaddress
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualaddress ;
         }

         set {
            gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualaddress = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualaddress");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualaddress_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = 1;
         gxTv_SdtResident_INIndividual_Residentinindividualaddress = "";
         SetDirty("Residentinindividualaddress");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualaddress_IsNull( )
      {
         return (gxTv_SdtResident_INIndividual_Residentinindividualaddress_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualGender" )]
      [  XmlElement( ElementName = "ResidentINIndividualGender"   )]
      public string gxTpr_Residentinindividualgender
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualgender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgender = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualgender");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtResident_INIndividual_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtResident_INIndividual_Mode_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtResident_INIndividual_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtResident_INIndividual_Modified_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtResident_INIndividual_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Initialized = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtResident_INIndividual_Initialized_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualId_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualId_Z"   )]
      public short gxTpr_Residentinindividualid_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualid_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualid_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualid_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualid_Z = 0;
         SetDirty("Residentinindividualid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualBsnNumber_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualBsnNumber_Z"   )]
      public string gxTpr_Residentinindividualbsnnumber_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualbsnnumber_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z = "";
         SetDirty("Residentinindividualbsnnumber_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualGivenName_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualGivenName_Z"   )]
      public string gxTpr_Residentinindividualgivenname_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualgivenname_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z = "";
         SetDirty("Residentinindividualgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualLastName_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualLastName_Z"   )]
      public string gxTpr_Residentinindividuallastname_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividuallastname_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z = "";
         SetDirty("Residentinindividuallastname_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualEmail_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualEmail_Z"   )]
      public string gxTpr_Residentinindividualemail_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualemail_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualemail_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualemail_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualemail_Z = "";
         SetDirty("Residentinindividualemail_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualPhone_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualPhone_Z"   )]
      public string gxTpr_Residentinindividualphone_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualphone_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualphone_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualphone_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualphone_Z = "";
         SetDirty("Residentinindividualphone_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualAddress_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualAddress_Z"   )]
      public string gxTpr_Residentinindividualaddress_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualaddress_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z = "";
         SetDirty("Residentinindividualaddress_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualGender_Z" )]
      [  XmlElement( ElementName = "ResidentINIndividualGender_Z"   )]
      public string gxTpr_Residentinindividualgender_Z
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualgender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualgender_Z = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualgender_Z");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualgender_Z_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualgender_Z = "";
         SetDirty("Residentinindividualgender_Z");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualgender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualEmail_N" )]
      [  XmlElement( ElementName = "ResidentINIndividualEmail_N"   )]
      public short gxTpr_Residentinindividualemail_N
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualemail_N = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualemail_N");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualemail_N_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualemail_N = 0;
         SetDirty("Residentinindividualemail_N");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualPhone_N" )]
      [  XmlElement( ElementName = "ResidentINIndividualPhone_N"   )]
      public short gxTpr_Residentinindividualphone_N
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualphone_N = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualphone_N");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualphone_N_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualphone_N = 0;
         SetDirty("Residentinindividualphone_N");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualphone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentINIndividualAddress_N" )]
      [  XmlElement( ElementName = "ResidentINIndividualAddress_N"   )]
      public short gxTpr_Residentinindividualaddress_N
      {
         get {
            return gxTv_SdtResident_INIndividual_Residentinindividualaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = value;
            gxTv_SdtResident_INIndividual_Modified = 1;
            SetDirty("Residentinindividualaddress_N");
         }

      }

      public void gxTv_SdtResident_INIndividual_Residentinindividualaddress_N_SetNull( )
      {
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_N = 0;
         SetDirty("Residentinindividualaddress_N");
         return  ;
      }

      public bool gxTv_SdtResident_INIndividual_Residentinindividualaddress_N_IsNull( )
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
         gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber = "";
         gxTv_SdtResident_INIndividual_Residentinindividualgivenname = "";
         gxTv_SdtResident_INIndividual_Residentinindividuallastname = "";
         gxTv_SdtResident_INIndividual_Residentinindividualemail = "";
         gxTv_SdtResident_INIndividual_Residentinindividualphone = "";
         gxTv_SdtResident_INIndividual_Residentinindividualaddress = "";
         gxTv_SdtResident_INIndividual_Residentinindividualgender = "";
         gxTv_SdtResident_INIndividual_Mode = "";
         gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividualemail_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividualphone_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z = "";
         gxTv_SdtResident_INIndividual_Residentinindividualgender_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtResident_INIndividual_Residentinindividualid ;
      private short sdtIsNull ;
      private short gxTv_SdtResident_INIndividual_Modified ;
      private short gxTv_SdtResident_INIndividual_Initialized ;
      private short gxTv_SdtResident_INIndividual_Residentinindividualid_Z ;
      private short gxTv_SdtResident_INIndividual_Residentinindividualemail_N ;
      private short gxTv_SdtResident_INIndividual_Residentinindividualphone_N ;
      private short gxTv_SdtResident_INIndividual_Residentinindividualaddress_N ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualphone ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualgender ;
      private string gxTv_SdtResident_INIndividual_Mode ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualphone_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualgender_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualgivenname ;
      private string gxTv_SdtResident_INIndividual_Residentinindividuallastname ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualemail ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualaddress ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualbsnnumber_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualgivenname_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividuallastname_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualemail_Z ;
      private string gxTv_SdtResident_INIndividual_Residentinindividualaddress_Z ;
   }

   [DataContract(Name = @"Resident.INIndividual", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_INIndividual_RESTInterface : GxGenericCollectionItem<SdtResident_INIndividual>
   {
      public SdtResident_INIndividual_RESTInterface( ) : base()
      {
      }

      public SdtResident_INIndividual_RESTInterface( SdtResident_INIndividual psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentINIndividualId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residentinindividualid
      {
         get {
            return sdt.gxTpr_Residentinindividualid ;
         }

         set {
            sdt.gxTpr_Residentinindividualid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResidentINIndividualBsnNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualbsnnumber
      {
         get {
            return sdt.gxTpr_Residentinindividualbsnnumber ;
         }

         set {
            sdt.gxTpr_Residentinindividualbsnnumber = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualGivenName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualgivenname
      {
         get {
            return sdt.gxTpr_Residentinindividualgivenname ;
         }

         set {
            sdt.gxTpr_Residentinindividualgivenname = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualLastName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividuallastname
      {
         get {
            return sdt.gxTpr_Residentinindividuallastname ;
         }

         set {
            sdt.gxTpr_Residentinindividuallastname = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualemail
      {
         get {
            return sdt.gxTpr_Residentinindividualemail ;
         }

         set {
            sdt.gxTpr_Residentinindividualemail = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualPhone" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentinindividualphone) ;
         }

         set {
            sdt.gxTpr_Residentinindividualphone = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualAddress" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualaddress
      {
         get {
            return sdt.gxTpr_Residentinindividualaddress ;
         }

         set {
            sdt.gxTpr_Residentinindividualaddress = value;
         }

      }

      [DataMember( Name = "ResidentINIndividualGender" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Residentinindividualgender
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentinindividualgender) ;
         }

         set {
            sdt.gxTpr_Residentinindividualgender = value;
         }

      }

      public SdtResident_INIndividual sdt
      {
         get {
            return (SdtResident_INIndividual)Sdt ;
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
            sdt = new SdtResident_INIndividual() ;
         }
      }

   }

   [DataContract(Name = @"Resident.INIndividual", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_INIndividual_RESTLInterface : GxGenericCollectionItem<SdtResident_INIndividual>
   {
      public SdtResident_INIndividual_RESTLInterface( ) : base()
      {
      }

      public SdtResident_INIndividual_RESTLInterface( SdtResident_INIndividual psdt ) : base(psdt)
      {
      }

      public SdtResident_INIndividual sdt
      {
         get {
            return (SdtResident_INIndividual)Sdt ;
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
            sdt = new SdtResident_INIndividual() ;
         }
      }

   }

}
