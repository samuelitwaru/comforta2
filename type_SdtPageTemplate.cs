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
   [XmlRoot(ElementName = "PageTemplate" )]
   [XmlType(TypeName =  "PageTemplate" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtPageTemplate : GxSilentTrnSdt
   {
      public SdtPageTemplate( )
      {
      }

      public SdtPageTemplate( IGxContext context )
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

      public void Load( short AV107PageTemplateId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV107PageTemplateId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PageTemplateId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PageTemplate");
         metadata.Set("BT", "PageTemplate");
         metadata.Set("PK", "[ \"PageTemplateId\" ]");
         metadata.Set("PKAssigned", "[ \"PageTemplateId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Pagetemplateimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Pagetemplateid_Z");
         state.Add("gxTpr_Pagetemplatename_Z");
         state.Add("gxTpr_Pagetemplatedescription_Z");
         state.Add("gxTpr_Pagetemplateimage_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPageTemplate sdt;
         sdt = (SdtPageTemplate)(source);
         gxTv_SdtPageTemplate_Pagetemplateid = sdt.gxTv_SdtPageTemplate_Pagetemplateid ;
         gxTv_SdtPageTemplate_Pagetemplatename = sdt.gxTv_SdtPageTemplate_Pagetemplatename ;
         gxTv_SdtPageTemplate_Pagetemplatedescription = sdt.gxTv_SdtPageTemplate_Pagetemplatedescription ;
         gxTv_SdtPageTemplate_Pagetemplatehtml = sdt.gxTv_SdtPageTemplate_Pagetemplatehtml ;
         gxTv_SdtPageTemplate_Pagetemplatecss = sdt.gxTv_SdtPageTemplate_Pagetemplatecss ;
         gxTv_SdtPageTemplate_Pagetemplateimage = sdt.gxTv_SdtPageTemplate_Pagetemplateimage ;
         gxTv_SdtPageTemplate_Pagetemplateimage_gxi = sdt.gxTv_SdtPageTemplate_Pagetemplateimage_gxi ;
         gxTv_SdtPageTemplate_Mode = sdt.gxTv_SdtPageTemplate_Mode ;
         gxTv_SdtPageTemplate_Initialized = sdt.gxTv_SdtPageTemplate_Initialized ;
         gxTv_SdtPageTemplate_Pagetemplateid_Z = sdt.gxTv_SdtPageTemplate_Pagetemplateid_Z ;
         gxTv_SdtPageTemplate_Pagetemplatename_Z = sdt.gxTv_SdtPageTemplate_Pagetemplatename_Z ;
         gxTv_SdtPageTemplate_Pagetemplatedescription_Z = sdt.gxTv_SdtPageTemplate_Pagetemplatedescription_Z ;
         gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z = sdt.gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z ;
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
         AddObjectProperty("PageTemplateId", gxTv_SdtPageTemplate_Pagetemplateid, false, includeNonInitialized);
         AddObjectProperty("PageTemplateName", gxTv_SdtPageTemplate_Pagetemplatename, false, includeNonInitialized);
         AddObjectProperty("PageTemplateDescription", gxTv_SdtPageTemplate_Pagetemplatedescription, false, includeNonInitialized);
         AddObjectProperty("PageTemplateHtml", gxTv_SdtPageTemplate_Pagetemplatehtml, false, includeNonInitialized);
         AddObjectProperty("PageTemplateCSS", gxTv_SdtPageTemplate_Pagetemplatecss, false, includeNonInitialized);
         AddObjectProperty("PageTemplateImage", gxTv_SdtPageTemplate_Pagetemplateimage, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PageTemplateImage_GXI", gxTv_SdtPageTemplate_Pagetemplateimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPageTemplate_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPageTemplate_Initialized, false, includeNonInitialized);
            AddObjectProperty("PageTemplateId_Z", gxTv_SdtPageTemplate_Pagetemplateid_Z, false, includeNonInitialized);
            AddObjectProperty("PageTemplateName_Z", gxTv_SdtPageTemplate_Pagetemplatename_Z, false, includeNonInitialized);
            AddObjectProperty("PageTemplateDescription_Z", gxTv_SdtPageTemplate_Pagetemplatedescription_Z, false, includeNonInitialized);
            AddObjectProperty("PageTemplateImage_GXI_Z", gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPageTemplate sdt )
      {
         if ( sdt.IsDirty("PageTemplateId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateid = sdt.gxTv_SdtPageTemplate_Pagetemplateid ;
         }
         if ( sdt.IsDirty("PageTemplateName") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatename = sdt.gxTv_SdtPageTemplate_Pagetemplatename ;
         }
         if ( sdt.IsDirty("PageTemplateDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatedescription = sdt.gxTv_SdtPageTemplate_Pagetemplatedescription ;
         }
         if ( sdt.IsDirty("PageTemplateHtml") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatehtml = sdt.gxTv_SdtPageTemplate_Pagetemplatehtml ;
         }
         if ( sdt.IsDirty("PageTemplateCSS") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatecss = sdt.gxTv_SdtPageTemplate_Pagetemplatecss ;
         }
         if ( sdt.IsDirty("PageTemplateImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateimage = sdt.gxTv_SdtPageTemplate_Pagetemplateimage ;
         }
         if ( sdt.IsDirty("PageTemplateImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateimage_gxi = sdt.gxTv_SdtPageTemplate_Pagetemplateimage_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PageTemplateId" )]
      [  XmlElement( ElementName = "PageTemplateId"   )]
      public short gxTpr_Pagetemplateid
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplateid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPageTemplate_Pagetemplateid != value )
            {
               gxTv_SdtPageTemplate_Mode = "INS";
               this.gxTv_SdtPageTemplate_Pagetemplateid_Z_SetNull( );
               this.gxTv_SdtPageTemplate_Pagetemplatename_Z_SetNull( );
               this.gxTv_SdtPageTemplate_Pagetemplatedescription_Z_SetNull( );
               this.gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z_SetNull( );
            }
            gxTv_SdtPageTemplate_Pagetemplateid = value;
            SetDirty("Pagetemplateid");
         }

      }

      [  SoapElement( ElementName = "PageTemplateName" )]
      [  XmlElement( ElementName = "PageTemplateName"   )]
      public string gxTpr_Pagetemplatename
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatename = value;
            SetDirty("Pagetemplatename");
         }

      }

      [  SoapElement( ElementName = "PageTemplateDescription" )]
      [  XmlElement( ElementName = "PageTemplateDescription"   )]
      public string gxTpr_Pagetemplatedescription
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatedescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatedescription = value;
            SetDirty("Pagetemplatedescription");
         }

      }

      [  SoapElement( ElementName = "PageTemplateHtml" )]
      [  XmlElement( ElementName = "PageTemplateHtml"   )]
      public string gxTpr_Pagetemplatehtml
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatehtml ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatehtml = value;
            SetDirty("Pagetemplatehtml");
         }

      }

      [  SoapElement( ElementName = "PageTemplateCSS" )]
      [  XmlElement( ElementName = "PageTemplateCSS"   )]
      public string gxTpr_Pagetemplatecss
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatecss ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatecss = value;
            SetDirty("Pagetemplatecss");
         }

      }

      [  SoapElement( ElementName = "PageTemplateImage" )]
      [  XmlElement( ElementName = "PageTemplateImage"   )]
      [GxUpload()]
      public string gxTpr_Pagetemplateimage
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplateimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateimage = value;
            SetDirty("Pagetemplateimage");
         }

      }

      [  SoapElement( ElementName = "PageTemplateImage_GXI" )]
      [  XmlElement( ElementName = "PageTemplateImage_GXI"   )]
      public string gxTpr_Pagetemplateimage_gxi
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplateimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateimage_gxi = value;
            SetDirty("Pagetemplateimage_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPageTemplate_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPageTemplate_Mode_SetNull( )
      {
         gxTv_SdtPageTemplate_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPageTemplate_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPageTemplate_Initialized_SetNull( )
      {
         gxTv_SdtPageTemplate_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageTemplateId_Z" )]
      [  XmlElement( ElementName = "PageTemplateId_Z"   )]
      public short gxTpr_Pagetemplateid_Z
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplateid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateid_Z = value;
            SetDirty("Pagetemplateid_Z");
         }

      }

      public void gxTv_SdtPageTemplate_Pagetemplateid_Z_SetNull( )
      {
         gxTv_SdtPageTemplate_Pagetemplateid_Z = 0;
         SetDirty("Pagetemplateid_Z");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Pagetemplateid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageTemplateName_Z" )]
      [  XmlElement( ElementName = "PageTemplateName_Z"   )]
      public string gxTpr_Pagetemplatename_Z
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatename_Z = value;
            SetDirty("Pagetemplatename_Z");
         }

      }

      public void gxTv_SdtPageTemplate_Pagetemplatename_Z_SetNull( )
      {
         gxTv_SdtPageTemplate_Pagetemplatename_Z = "";
         SetDirty("Pagetemplatename_Z");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Pagetemplatename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageTemplateDescription_Z" )]
      [  XmlElement( ElementName = "PageTemplateDescription_Z"   )]
      public string gxTpr_Pagetemplatedescription_Z
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplatedescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplatedescription_Z = value;
            SetDirty("Pagetemplatedescription_Z");
         }

      }

      public void gxTv_SdtPageTemplate_Pagetemplatedescription_Z_SetNull( )
      {
         gxTv_SdtPageTemplate_Pagetemplatedescription_Z = "";
         SetDirty("Pagetemplatedescription_Z");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Pagetemplatedescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageTemplateImage_GXI_Z" )]
      [  XmlElement( ElementName = "PageTemplateImage_GXI_Z"   )]
      public string gxTpr_Pagetemplateimage_gxi_Z
      {
         get {
            return gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z = value;
            SetDirty("Pagetemplateimage_gxi_Z");
         }

      }

      public void gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z_SetNull( )
      {
         gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z = "";
         SetDirty("Pagetemplateimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z_IsNull( )
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
         gxTv_SdtPageTemplate_Pagetemplatename = "";
         gxTv_SdtPageTemplate_Pagetemplatedescription = "";
         gxTv_SdtPageTemplate_Pagetemplatehtml = "";
         gxTv_SdtPageTemplate_Pagetemplatecss = "";
         gxTv_SdtPageTemplate_Pagetemplateimage = "";
         gxTv_SdtPageTemplate_Pagetemplateimage_gxi = "";
         gxTv_SdtPageTemplate_Mode = "";
         gxTv_SdtPageTemplate_Pagetemplatename_Z = "";
         gxTv_SdtPageTemplate_Pagetemplatedescription_Z = "";
         gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pagetemplate", "GeneXus.Programs.pagetemplate_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtPageTemplate_Pagetemplateid ;
      private short sdtIsNull ;
      private short gxTv_SdtPageTemplate_Initialized ;
      private short gxTv_SdtPageTemplate_Pagetemplateid_Z ;
      private string gxTv_SdtPageTemplate_Mode ;
      private string gxTv_SdtPageTemplate_Pagetemplatehtml ;
      private string gxTv_SdtPageTemplate_Pagetemplatecss ;
      private string gxTv_SdtPageTemplate_Pagetemplatename ;
      private string gxTv_SdtPageTemplate_Pagetemplatedescription ;
      private string gxTv_SdtPageTemplate_Pagetemplateimage_gxi ;
      private string gxTv_SdtPageTemplate_Pagetemplatename_Z ;
      private string gxTv_SdtPageTemplate_Pagetemplatedescription_Z ;
      private string gxTv_SdtPageTemplate_Pagetemplateimage_gxi_Z ;
      private string gxTv_SdtPageTemplate_Pagetemplateimage ;
   }

   [DataContract(Name = @"PageTemplate", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtPageTemplate_RESTInterface : GxGenericCollectionItem<SdtPageTemplate>
   {
      public SdtPageTemplate_RESTInterface( ) : base()
      {
      }

      public SdtPageTemplate_RESTInterface( SdtPageTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PageTemplateId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Pagetemplateid
      {
         get {
            return sdt.gxTpr_Pagetemplateid ;
         }

         set {
            sdt.gxTpr_Pagetemplateid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PageTemplateName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Pagetemplatename
      {
         get {
            return sdt.gxTpr_Pagetemplatename ;
         }

         set {
            sdt.gxTpr_Pagetemplatename = value;
         }

      }

      [DataMember( Name = "PageTemplateDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Pagetemplatedescription
      {
         get {
            return sdt.gxTpr_Pagetemplatedescription ;
         }

         set {
            sdt.gxTpr_Pagetemplatedescription = value;
         }

      }

      [DataMember( Name = "PageTemplateHtml" , Order = 3 )]
      public string gxTpr_Pagetemplatehtml
      {
         get {
            return sdt.gxTpr_Pagetemplatehtml ;
         }

         set {
            sdt.gxTpr_Pagetemplatehtml = value;
         }

      }

      [DataMember( Name = "PageTemplateCSS" , Order = 4 )]
      public string gxTpr_Pagetemplatecss
      {
         get {
            return sdt.gxTpr_Pagetemplatecss ;
         }

         set {
            sdt.gxTpr_Pagetemplatecss = value;
         }

      }

      [DataMember( Name = "PageTemplateImage" , Order = 5 )]
      [GxUpload()]
      public string gxTpr_Pagetemplateimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Pagetemplateimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Pagetemplateimage) : StringUtil.RTrim( sdt.gxTpr_Pagetemplateimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Pagetemplateimage = value;
         }

      }

      public SdtPageTemplate sdt
      {
         get {
            return (SdtPageTemplate)Sdt ;
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
            sdt = new SdtPageTemplate() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"PageTemplate", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtPageTemplate_RESTLInterface : GxGenericCollectionItem<SdtPageTemplate>
   {
      public SdtPageTemplate_RESTLInterface( ) : base()
      {
      }

      public SdtPageTemplate_RESTLInterface( SdtPageTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PageTemplateName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Pagetemplatename
      {
         get {
            return sdt.gxTpr_Pagetemplatename ;
         }

         set {
            sdt.gxTpr_Pagetemplatename = value;
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

      public SdtPageTemplate sdt
      {
         get {
            return (SdtPageTemplate)Sdt ;
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
            sdt = new SdtPageTemplate() ;
         }
      }

   }

}
