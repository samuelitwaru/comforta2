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
   [XmlRoot(ElementName = "CustomerCustomization" )]
   [XmlType(TypeName =  "CustomerCustomization" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomerCustomization : GxSilentTrnSdt
   {
      public SdtCustomerCustomization( )
      {
      }

      public SdtCustomerCustomization( IGxContext context )
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

      public void Load( short AV128CustomerCustomizationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV128CustomerCustomizationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CustomerCustomizationId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CustomerCustomization");
         metadata.Set("BT", "CustomerCustomization");
         metadata.Set("PK", "[ \"CustomerCustomizationId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerCustomizationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Customercustomizationlogo_gxi");
         state.Add("gxTpr_Customercustomizationfavicon_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Customercustomizationid_Z");
         state.Add("gxTpr_Customercustomizationbasecolor_Z");
         state.Add("gxTpr_Customercustomizationfontsize_Z");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customercustomizationlogo_gxi_Z");
         state.Add("gxTpr_Customercustomizationfavicon_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomerCustomization sdt;
         sdt = (SdtCustomerCustomization)(source);
         gxTv_SdtCustomerCustomization_Customercustomizationid = sdt.gxTv_SdtCustomerCustomization_Customercustomizationid ;
         gxTv_SdtCustomerCustomization_Customercustomizationlogo = sdt.gxTv_SdtCustomerCustomization_Customercustomizationlogo ;
         gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi = sdt.gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi ;
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfavicon ;
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi ;
         gxTv_SdtCustomerCustomization_Customercustomizationbasecolor = sdt.gxTv_SdtCustomerCustomization_Customercustomizationbasecolor ;
         gxTv_SdtCustomerCustomization_Customercustomizationfontsize = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfontsize ;
         gxTv_SdtCustomerCustomization_Customerid = sdt.gxTv_SdtCustomerCustomization_Customerid ;
         gxTv_SdtCustomerCustomization_Customername = sdt.gxTv_SdtCustomerCustomization_Customername ;
         gxTv_SdtCustomerCustomization_Mode = sdt.gxTv_SdtCustomerCustomization_Mode ;
         gxTv_SdtCustomerCustomization_Initialized = sdt.gxTv_SdtCustomerCustomization_Initialized ;
         gxTv_SdtCustomerCustomization_Customercustomizationid_Z = sdt.gxTv_SdtCustomerCustomization_Customercustomizationid_Z ;
         gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z = sdt.gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z ;
         gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z ;
         gxTv_SdtCustomerCustomization_Customerid_Z = sdt.gxTv_SdtCustomerCustomization_Customerid_Z ;
         gxTv_SdtCustomerCustomization_Customername_Z = sdt.gxTv_SdtCustomerCustomization_Customername_Z ;
         gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z = sdt.gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z ;
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z ;
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
         AddObjectProperty("CustomerCustomizationId", gxTv_SdtCustomerCustomization_Customercustomizationid, false, includeNonInitialized);
         AddObjectProperty("CustomerCustomizationLogo", gxTv_SdtCustomerCustomization_Customercustomizationlogo, false, includeNonInitialized);
         AddObjectProperty("CustomerCustomizationFavicon", gxTv_SdtCustomerCustomization_Customercustomizationfavicon, false, includeNonInitialized);
         AddObjectProperty("CustomerCustomizationBaseColor", gxTv_SdtCustomerCustomization_Customercustomizationbasecolor, false, includeNonInitialized);
         AddObjectProperty("CustomerCustomizationFontSize", gxTv_SdtCustomerCustomization_Customercustomizationfontsize, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtCustomerCustomization_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtCustomerCustomization_Customername, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("CustomerCustomizationLogo_GXI", gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationFavicon_GXI", gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtCustomerCustomization_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomerCustomization_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationId_Z", gxTv_SdtCustomerCustomization_Customercustomizationid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationBaseColor_Z", gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationFontSize_Z", gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtCustomerCustomization_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtCustomerCustomization_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationLogo_GXI_Z", gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerCustomizationFavicon_GXI_Z", gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomerCustomization sdt )
      {
         if ( sdt.IsDirty("CustomerCustomizationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationid = sdt.gxTv_SdtCustomerCustomization_Customercustomizationid ;
         }
         if ( sdt.IsDirty("CustomerCustomizationLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationlogo = sdt.gxTv_SdtCustomerCustomization_Customercustomizationlogo ;
         }
         if ( sdt.IsDirty("CustomerCustomizationLogo") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi = sdt.gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi ;
         }
         if ( sdt.IsDirty("CustomerCustomizationFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfavicon = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfavicon ;
         }
         if ( sdt.IsDirty("CustomerCustomizationFavicon") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi ;
         }
         if ( sdt.IsDirty("CustomerCustomizationBaseColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationbasecolor = sdt.gxTv_SdtCustomerCustomization_Customercustomizationbasecolor ;
         }
         if ( sdt.IsDirty("CustomerCustomizationFontSize") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfontsize = sdt.gxTv_SdtCustomerCustomization_Customercustomizationfontsize ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customerid = sdt.gxTv_SdtCustomerCustomization_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customername = sdt.gxTv_SdtCustomerCustomization_Customername ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationId" )]
      [  XmlElement( ElementName = "CustomerCustomizationId"   )]
      public short gxTpr_Customercustomizationid
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCustomerCustomization_Customercustomizationid != value )
            {
               gxTv_SdtCustomerCustomization_Mode = "INS";
               this.gxTv_SdtCustomerCustomization_Customercustomizationid_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customerid_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customername_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z_SetNull( );
               this.gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z_SetNull( );
            }
            gxTv_SdtCustomerCustomization_Customercustomizationid = value;
            SetDirty("Customercustomizationid");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationLogo" )]
      [  XmlElement( ElementName = "CustomerCustomizationLogo"   )]
      [GxUpload()]
      public string gxTpr_Customercustomizationlogo
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationlogo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationlogo = value;
            SetDirty("Customercustomizationlogo");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationLogo_GXI" )]
      [  XmlElement( ElementName = "CustomerCustomizationLogo_GXI"   )]
      public string gxTpr_Customercustomizationlogo_gxi
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi = value;
            SetDirty("Customercustomizationlogo_gxi");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationFavicon" )]
      [  XmlElement( ElementName = "CustomerCustomizationFavicon"   )]
      [GxUpload()]
      public string gxTpr_Customercustomizationfavicon
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationfavicon ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfavicon = value;
            SetDirty("Customercustomizationfavicon");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationFavicon_GXI" )]
      [  XmlElement( ElementName = "CustomerCustomizationFavicon_GXI"   )]
      public string gxTpr_Customercustomizationfavicon_gxi
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi = value;
            SetDirty("Customercustomizationfavicon_gxi");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationBaseColor" )]
      [  XmlElement( ElementName = "CustomerCustomizationBaseColor"   )]
      public string gxTpr_Customercustomizationbasecolor
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationbasecolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationbasecolor = value;
            SetDirty("Customercustomizationbasecolor");
         }

      }

      [  SoapElement( ElementName = "CustomerCustomizationFontSize" )]
      [  XmlElement( ElementName = "CustomerCustomizationFontSize"   )]
      public string gxTpr_Customercustomizationfontsize
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationfontsize ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfontsize = value;
            SetDirty("Customercustomizationfontsize");
         }

      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtCustomerCustomization_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtCustomerCustomization_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomerCustomization_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomerCustomization_Mode_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomerCustomization_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomerCustomization_Initialized_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationId_Z" )]
      [  XmlElement( ElementName = "CustomerCustomizationId_Z"   )]
      public short gxTpr_Customercustomizationid_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationid_Z = value;
            SetDirty("Customercustomizationid_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customercustomizationid_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customercustomizationid_Z = 0;
         SetDirty("Customercustomizationid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customercustomizationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationBaseColor_Z" )]
      [  XmlElement( ElementName = "CustomerCustomizationBaseColor_Z"   )]
      public string gxTpr_Customercustomizationbasecolor_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z = value;
            SetDirty("Customercustomizationbasecolor_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z = "";
         SetDirty("Customercustomizationbasecolor_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationFontSize_Z" )]
      [  XmlElement( ElementName = "CustomerCustomizationFontSize_Z"   )]
      public string gxTpr_Customercustomizationfontsize_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z = value;
            SetDirty("Customercustomizationfontsize_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z = "";
         SetDirty("Customercustomizationfontsize_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customerid_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customername_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationLogo_GXI_Z" )]
      [  XmlElement( ElementName = "CustomerCustomizationLogo_GXI_Z"   )]
      public string gxTpr_Customercustomizationlogo_gxi_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z = value;
            SetDirty("Customercustomizationlogo_gxi_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z = "";
         SetDirty("Customercustomizationlogo_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerCustomizationFavicon_GXI_Z" )]
      [  XmlElement( ElementName = "CustomerCustomizationFavicon_GXI_Z"   )]
      public string gxTpr_Customercustomizationfavicon_gxi_Z
      {
         get {
            return gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z = value;
            SetDirty("Customercustomizationfavicon_gxi_Z");
         }

      }

      public void gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z_SetNull( )
      {
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z = "";
         SetDirty("Customercustomizationfavicon_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z_IsNull( )
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
         gxTv_SdtCustomerCustomization_Customercustomizationlogo = "";
         gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi = "";
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon = "";
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi = "";
         gxTv_SdtCustomerCustomization_Customercustomizationbasecolor = "";
         gxTv_SdtCustomerCustomization_Customercustomizationfontsize = "";
         gxTv_SdtCustomerCustomization_Customername = "";
         gxTv_SdtCustomerCustomization_Mode = "";
         gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z = "";
         gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z = "";
         gxTv_SdtCustomerCustomization_Customername_Z = "";
         gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z = "";
         gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "customercustomization", "GeneXus.Programs.customercustomization_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtCustomerCustomization_Customercustomizationid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomerCustomization_Customerid ;
      private short gxTv_SdtCustomerCustomization_Initialized ;
      private short gxTv_SdtCustomerCustomization_Customercustomizationid_Z ;
      private short gxTv_SdtCustomerCustomization_Customerid_Z ;
      private string gxTv_SdtCustomerCustomization_Mode ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationbasecolor ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationfontsize ;
      private string gxTv_SdtCustomerCustomization_Customername ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationbasecolor_Z ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationfontsize_Z ;
      private string gxTv_SdtCustomerCustomization_Customername_Z ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationlogo_gxi_Z ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationfavicon_gxi_Z ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationlogo ;
      private string gxTv_SdtCustomerCustomization_Customercustomizationfavicon ;
   }

   [DataContract(Name = @"CustomerCustomization", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomerCustomization_RESTInterface : GxGenericCollectionItem<SdtCustomerCustomization>
   {
      public SdtCustomerCustomization_RESTInterface( ) : base()
      {
      }

      public SdtCustomerCustomization_RESTInterface( SdtCustomerCustomization psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerCustomizationId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customercustomizationid
      {
         get {
            return sdt.gxTpr_Customercustomizationid ;
         }

         set {
            sdt.gxTpr_Customercustomizationid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerCustomizationLogo" , Order = 1 )]
      [GxUpload()]
      public string gxTpr_Customercustomizationlogo
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Customercustomizationlogo)) ? PathUtil.RelativeURL( sdt.gxTpr_Customercustomizationlogo) : StringUtil.RTrim( sdt.gxTpr_Customercustomizationlogo_gxi)) ;
         }

         set {
            sdt.gxTpr_Customercustomizationlogo = value;
         }

      }

      [DataMember( Name = "CustomerCustomizationFavicon" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Customercustomizationfavicon
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Customercustomizationfavicon)) ? PathUtil.RelativeURL( sdt.gxTpr_Customercustomizationfavicon) : StringUtil.RTrim( sdt.gxTpr_Customercustomizationfavicon_gxi)) ;
         }

         set {
            sdt.gxTpr_Customercustomizationfavicon = value;
         }

      }

      [DataMember( Name = "CustomerCustomizationBaseColor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customercustomizationbasecolor
      {
         get {
            return sdt.gxTpr_Customercustomizationbasecolor ;
         }

         set {
            sdt.gxTpr_Customercustomizationbasecolor = value;
         }

      }

      [DataMember( Name = "CustomerCustomizationFontSize" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customercustomizationfontsize
      {
         get {
            return sdt.gxTpr_Customercustomizationfontsize ;
         }

         set {
            sdt.gxTpr_Customercustomizationfontsize = value;
         }

      }

      [DataMember( Name = "CustomerId" , Order = 5 )]
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

      [DataMember( Name = "CustomerName" , Order = 6 )]
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

      public SdtCustomerCustomization sdt
      {
         get {
            return (SdtCustomerCustomization)Sdt ;
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
            sdt = new SdtCustomerCustomization() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"CustomerCustomization", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomerCustomization_RESTLInterface : GxGenericCollectionItem<SdtCustomerCustomization>
   {
      public SdtCustomerCustomization_RESTLInterface( ) : base()
      {
      }

      public SdtCustomerCustomization_RESTLInterface( SdtCustomerCustomization psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerCustomizationBaseColor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Customercustomizationbasecolor
      {
         get {
            return sdt.gxTpr_Customercustomizationbasecolor ;
         }

         set {
            sdt.gxTpr_Customercustomizationbasecolor = value;
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

      public SdtCustomerCustomization sdt
      {
         get {
            return (SdtCustomerCustomization)Sdt ;
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
            sdt = new SdtCustomerCustomization() ;
         }
      }

   }

}
