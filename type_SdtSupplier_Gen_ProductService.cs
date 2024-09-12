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
   [XmlRoot(ElementName = "Supplier_Gen.ProductService" )]
   [XmlType(TypeName =  "Supplier_Gen.ProductService" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtSupplier_Gen_ProductService : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtSupplier_Gen_ProductService( )
      {
      }

      public SdtSupplier_Gen_ProductService( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProductServiceId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ProductService");
         metadata.Set("BT", "Supplier_GenProductService");
         metadata.Set("PK", "[ \"ProductServiceId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductServiceId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Supplier_GenId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productservicepicture_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Productservicename_Z");
         state.Add("gxTpr_Productservicedescription_Z");
         state.Add("gxTpr_Productservicequantity_Z");
         state.Add("gxTpr_Productservicetypeid_Z");
         state.Add("gxTpr_Productservicetypename_Z");
         state.Add("gxTpr_Productservicepicture_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSupplier_Gen_ProductService sdt;
         sdt = (SdtSupplier_Gen_ProductService)(source);
         gxTv_SdtSupplier_Gen_ProductService_Productserviceid = sdt.gxTv_SdtSupplier_Gen_ProductService_Productserviceid ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicename = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicename ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicedescription = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicedescription ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicequantity = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicequantity ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicepicture ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypename = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypename ;
         gxTv_SdtSupplier_Gen_ProductService_Mode = sdt.gxTv_SdtSupplier_Gen_ProductService_Mode ;
         gxTv_SdtSupplier_Gen_ProductService_Modified = sdt.gxTv_SdtSupplier_Gen_ProductService_Modified ;
         gxTv_SdtSupplier_Gen_ProductService_Initialized = sdt.gxTv_SdtSupplier_Gen_ProductService_Initialized ;
         gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z ;
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z ;
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
         AddObjectProperty("ProductServiceId", gxTv_SdtSupplier_Gen_ProductService_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceName", gxTv_SdtSupplier_Gen_ProductService_Productservicename, false, includeNonInitialized);
         AddObjectProperty("ProductServiceDescription", gxTv_SdtSupplier_Gen_ProductService_Productservicedescription, false, includeNonInitialized);
         AddObjectProperty("ProductServiceQuantity", gxTv_SdtSupplier_Gen_ProductService_Productservicequantity, false, includeNonInitialized);
         AddObjectProperty("ProductServicePicture", gxTv_SdtSupplier_Gen_ProductService_Productservicepicture, false, includeNonInitialized);
         AddObjectProperty("ProductServiceTypeId", gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceTypeName", gxTv_SdtSupplier_Gen_ProductService_Productservicetypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductServicePicture_GXI", gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtSupplier_Gen_ProductService_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtSupplier_Gen_ProductService_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSupplier_Gen_ProductService_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceName_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceDescription_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceQuantity_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceTypeId_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceTypeName_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServicePicture_GXI_Z", gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSupplier_Gen_ProductService sdt )
      {
         if ( sdt.IsDirty("ProductServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productserviceid = sdt.gxTv_SdtSupplier_Gen_ProductService_Productserviceid ;
         }
         if ( sdt.IsDirty("ProductServiceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicename = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicename ;
         }
         if ( sdt.IsDirty("ProductServiceDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicedescription = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicedescription ;
         }
         if ( sdt.IsDirty("ProductServiceQuantity") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicequantity = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicequantity ;
         }
         if ( sdt.IsDirty("ProductServicePicture") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicepicture = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicepicture ;
         }
         if ( sdt.IsDirty("ProductServicePicture") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi ;
         }
         if ( sdt.IsDirty("ProductServiceTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid ;
         }
         if ( sdt.IsDirty("ProductServiceTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypename = sdt.gxTv_SdtSupplier_Gen_ProductService_Productservicetypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductServiceId" )]
      [  XmlElement( ElementName = "ProductServiceId"   )]
      public short gxTpr_Productserviceid
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productserviceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productserviceid = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productserviceid");
         }

      }

      [  SoapElement( ElementName = "ProductServiceName" )]
      [  XmlElement( ElementName = "ProductServiceName"   )]
      public string gxTpr_Productservicename
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicename = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicename");
         }

      }

      [  SoapElement( ElementName = "ProductServiceDescription" )]
      [  XmlElement( ElementName = "ProductServiceDescription"   )]
      public string gxTpr_Productservicedescription
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicedescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicedescription = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicedescription");
         }

      }

      [  SoapElement( ElementName = "ProductServiceQuantity" )]
      [  XmlElement( ElementName = "ProductServiceQuantity"   )]
      public short gxTpr_Productservicequantity
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicequantity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicequantity = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicequantity");
         }

      }

      [  SoapElement( ElementName = "ProductServicePicture" )]
      [  XmlElement( ElementName = "ProductServicePicture"   )]
      [GxUpload()]
      public string gxTpr_Productservicepicture
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicepicture ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicepicture = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicepicture");
         }

      }

      [  SoapElement( ElementName = "ProductServicePicture_GXI" )]
      [  XmlElement( ElementName = "ProductServicePicture_GXI"   )]
      public string gxTpr_Productservicepicture_gxi
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicepicture_gxi");
         }

      }

      [  SoapElement( ElementName = "ProductServiceTypeId" )]
      [  XmlElement( ElementName = "ProductServiceTypeId"   )]
      public short gxTpr_Productservicetypeid
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicetypeid");
         }

      }

      [  SoapElement( ElementName = "ProductServiceTypeName" )]
      [  XmlElement( ElementName = "ProductServiceTypeName"   )]
      public string gxTpr_Productservicetypename
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicetypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypename = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicetypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Mode_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Modified_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Initialized = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Initialized_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_Z" )]
      [  XmlElement( ElementName = "ProductServiceId_Z"   )]
      public short gxTpr_Productserviceid_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productserviceid_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z = 0;
         SetDirty("Productserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceName_Z" )]
      [  XmlElement( ElementName = "ProductServiceName_Z"   )]
      public string gxTpr_Productservicename_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicename_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z = "";
         SetDirty("Productservicename_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceDescription_Z" )]
      [  XmlElement( ElementName = "ProductServiceDescription_Z"   )]
      public string gxTpr_Productservicedescription_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicedescription_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z = "";
         SetDirty("Productservicedescription_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceQuantity_Z" )]
      [  XmlElement( ElementName = "ProductServiceQuantity_Z"   )]
      public short gxTpr_Productservicequantity_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicequantity_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z = 0;
         SetDirty("Productservicequantity_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceTypeId_Z" )]
      [  XmlElement( ElementName = "ProductServiceTypeId_Z"   )]
      public short gxTpr_Productservicetypeid_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicetypeid_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z = 0;
         SetDirty("Productservicetypeid_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceTypeName_Z" )]
      [  XmlElement( ElementName = "ProductServiceTypeName_Z"   )]
      public string gxTpr_Productservicetypename_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicetypename_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z = "";
         SetDirty("Productservicetypename_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServicePicture_GXI_Z" )]
      [  XmlElement( ElementName = "ProductServicePicture_GXI_Z"   )]
      public string gxTpr_Productservicepicture_gxi_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z = value;
            gxTv_SdtSupplier_Gen_ProductService_Modified = 1;
            SetDirty("Productservicepicture_gxi_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z = "";
         SetDirty("Productservicepicture_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z_IsNull( )
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
         gxTv_SdtSupplier_Gen_ProductService_Productservicename = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicedescription = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypename = "";
         gxTv_SdtSupplier_Gen_ProductService_Mode = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z = "";
         gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtSupplier_Gen_ProductService_Productserviceid ;
      private short sdtIsNull ;
      private short gxTv_SdtSupplier_Gen_ProductService_Productservicequantity ;
      private short gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid ;
      private short gxTv_SdtSupplier_Gen_ProductService_Modified ;
      private short gxTv_SdtSupplier_Gen_ProductService_Initialized ;
      private short gxTv_SdtSupplier_Gen_ProductService_Productserviceid_Z ;
      private short gxTv_SdtSupplier_Gen_ProductService_Productservicequantity_Z ;
      private short gxTv_SdtSupplier_Gen_ProductService_Productservicetypeid_Z ;
      private string gxTv_SdtSupplier_Gen_ProductService_Mode ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicename ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicedescription ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicetypename ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicename_Z ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicedescription_Z ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicetypename_Z ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicepicture_gxi_Z ;
      private string gxTv_SdtSupplier_Gen_ProductService_Productservicepicture ;
   }

   [DataContract(Name = @"Supplier_Gen.ProductService", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtSupplier_Gen_ProductService_RESTInterface : GxGenericCollectionItem<SdtSupplier_Gen_ProductService>
   {
      public SdtSupplier_Gen_ProductService_RESTInterface( ) : base()
      {
      }

      public SdtSupplier_Gen_ProductService_RESTInterface( SdtSupplier_Gen_ProductService psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductServiceId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productserviceid
      {
         get {
            return sdt.gxTpr_Productserviceid ;
         }

         set {
            sdt.gxTpr_Productserviceid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductServiceName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productservicename
      {
         get {
            return sdt.gxTpr_Productservicename ;
         }

         set {
            sdt.gxTpr_Productservicename = value;
         }

      }

      [DataMember( Name = "ProductServiceDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productservicedescription
      {
         get {
            return sdt.gxTpr_Productservicedescription ;
         }

         set {
            sdt.gxTpr_Productservicedescription = value;
         }

      }

      [DataMember( Name = "ProductServiceQuantity" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productservicequantity
      {
         get {
            return sdt.gxTpr_Productservicequantity ;
         }

         set {
            sdt.gxTpr_Productservicequantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductServicePicture" , Order = 4 )]
      [GxUpload()]
      public string gxTpr_Productservicepicture
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productservicepicture)) ? PathUtil.RelativeURL( sdt.gxTpr_Productservicepicture) : StringUtil.RTrim( sdt.gxTpr_Productservicepicture_gxi)) ;
         }

         set {
            sdt.gxTpr_Productservicepicture = value;
         }

      }

      [DataMember( Name = "ProductServiceTypeId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productservicetypeid
      {
         get {
            return sdt.gxTpr_Productservicetypeid ;
         }

         set {
            sdt.gxTpr_Productservicetypeid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductServiceTypeName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Productservicetypename
      {
         get {
            return sdt.gxTpr_Productservicetypename ;
         }

         set {
            sdt.gxTpr_Productservicetypename = value;
         }

      }

      public SdtSupplier_Gen_ProductService sdt
      {
         get {
            return (SdtSupplier_Gen_ProductService)Sdt ;
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
            sdt = new SdtSupplier_Gen_ProductService() ;
         }
      }

   }

   [DataContract(Name = @"Supplier_Gen.ProductService", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtSupplier_Gen_ProductService_RESTLInterface : GxGenericCollectionItem<SdtSupplier_Gen_ProductService>
   {
      public SdtSupplier_Gen_ProductService_RESTLInterface( ) : base()
      {
      }

      public SdtSupplier_Gen_ProductService_RESTLInterface( SdtSupplier_Gen_ProductService psdt ) : base(psdt)
      {
      }

      public SdtSupplier_Gen_ProductService sdt
      {
         get {
            return (SdtSupplier_Gen_ProductService)Sdt ;
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
            sdt = new SdtSupplier_Gen_ProductService() ;
         }
      }

   }

}
