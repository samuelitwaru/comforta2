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
   [XmlRoot(ElementName = "Page" )]
   [XmlType(TypeName =  "Page" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtPage : GxSilentTrnSdt
   {
      public SdtPage( )
      {
      }

      public SdtPage( IGxContext context )
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

      public void Load( short AV103PageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV103PageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PageId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Page");
         metadata.Set("BT", "Page");
         metadata.Set("PK", "[ \"PageId\" ]");
         metadata.Set("PKAssigned", "[ \"PageId\" ]");
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
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Pageid_Z");
         state.Add("gxTpr_Pagename_Z");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customeremail_Z");
         state.Add("gxTpr_Customeremail_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPage sdt;
         sdt = (SdtPage)(source);
         gxTv_SdtPage_Pageid = sdt.gxTv_SdtPage_Pageid ;
         gxTv_SdtPage_Pagename = sdt.gxTv_SdtPage_Pagename ;
         gxTv_SdtPage_Pagehtmlcontent = sdt.gxTv_SdtPage_Pagehtmlcontent ;
         gxTv_SdtPage_Pagecsscontent = sdt.gxTv_SdtPage_Pagecsscontent ;
         gxTv_SdtPage_Pagejsoncontent = sdt.gxTv_SdtPage_Pagejsoncontent ;
         gxTv_SdtPage_Customerid = sdt.gxTv_SdtPage_Customerid ;
         gxTv_SdtPage_Customername = sdt.gxTv_SdtPage_Customername ;
         gxTv_SdtPage_Customeremail = sdt.gxTv_SdtPage_Customeremail ;
         gxTv_SdtPage_Mode = sdt.gxTv_SdtPage_Mode ;
         gxTv_SdtPage_Initialized = sdt.gxTv_SdtPage_Initialized ;
         gxTv_SdtPage_Pageid_Z = sdt.gxTv_SdtPage_Pageid_Z ;
         gxTv_SdtPage_Pagename_Z = sdt.gxTv_SdtPage_Pagename_Z ;
         gxTv_SdtPage_Customerid_Z = sdt.gxTv_SdtPage_Customerid_Z ;
         gxTv_SdtPage_Customername_Z = sdt.gxTv_SdtPage_Customername_Z ;
         gxTv_SdtPage_Customeremail_Z = sdt.gxTv_SdtPage_Customeremail_Z ;
         gxTv_SdtPage_Customeremail_N = sdt.gxTv_SdtPage_Customeremail_N ;
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
         AddObjectProperty("PageId", gxTv_SdtPage_Pageid, false, includeNonInitialized);
         AddObjectProperty("PageName", gxTv_SdtPage_Pagename, false, includeNonInitialized);
         AddObjectProperty("PageHtmlContent", gxTv_SdtPage_Pagehtmlcontent, false, includeNonInitialized);
         AddObjectProperty("PageCssContent", gxTv_SdtPage_Pagecsscontent, false, includeNonInitialized);
         AddObjectProperty("PageJsonContent", gxTv_SdtPage_Pagejsoncontent, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtPage_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtPage_Customername, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail", gxTv_SdtPage_Customeremail, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail_N", gxTv_SdtPage_Customeremail_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPage_Initialized, false, includeNonInitialized);
            AddObjectProperty("PageId_Z", gxTv_SdtPage_Pageid_Z, false, includeNonInitialized);
            AddObjectProperty("PageName_Z", gxTv_SdtPage_Pagename_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtPage_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtPage_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_Z", gxTv_SdtPage_Customeremail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_N", gxTv_SdtPage_Customeremail_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPage sdt )
      {
         if ( sdt.IsDirty("PageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Pageid = sdt.gxTv_SdtPage_Pageid ;
         }
         if ( sdt.IsDirty("PageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagename = sdt.gxTv_SdtPage_Pagename ;
         }
         if ( sdt.IsDirty("PageHtmlContent") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagehtmlcontent = sdt.gxTv_SdtPage_Pagehtmlcontent ;
         }
         if ( sdt.IsDirty("PageCssContent") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagecsscontent = sdt.gxTv_SdtPage_Pagecsscontent ;
         }
         if ( sdt.IsDirty("PageJsonContent") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagejsoncontent = sdt.gxTv_SdtPage_Pagejsoncontent ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Customerid = sdt.gxTv_SdtPage_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtPage_Customername = sdt.gxTv_SdtPage_Customername ;
         }
         if ( sdt.IsDirty("CustomerEmail") )
         {
            gxTv_SdtPage_Customeremail_N = (short)(sdt.gxTv_SdtPage_Customeremail_N);
            sdtIsNull = 0;
            gxTv_SdtPage_Customeremail = sdt.gxTv_SdtPage_Customeremail ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PageId" )]
      [  XmlElement( ElementName = "PageId"   )]
      public short gxTpr_Pageid
      {
         get {
            return gxTv_SdtPage_Pageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPage_Pageid != value )
            {
               gxTv_SdtPage_Mode = "INS";
               this.gxTv_SdtPage_Pageid_Z_SetNull( );
               this.gxTv_SdtPage_Pagename_Z_SetNull( );
               this.gxTv_SdtPage_Customerid_Z_SetNull( );
               this.gxTv_SdtPage_Customername_Z_SetNull( );
               this.gxTv_SdtPage_Customeremail_Z_SetNull( );
            }
            gxTv_SdtPage_Pageid = value;
            SetDirty("Pageid");
         }

      }

      [  SoapElement( ElementName = "PageName" )]
      [  XmlElement( ElementName = "PageName"   )]
      public string gxTpr_Pagename
      {
         get {
            return gxTv_SdtPage_Pagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagename = value;
            SetDirty("Pagename");
         }

      }

      [  SoapElement( ElementName = "PageHtmlContent" )]
      [  XmlElement( ElementName = "PageHtmlContent"   )]
      public string gxTpr_Pagehtmlcontent
      {
         get {
            return gxTv_SdtPage_Pagehtmlcontent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagehtmlcontent = value;
            SetDirty("Pagehtmlcontent");
         }

      }

      [  SoapElement( ElementName = "PageCssContent" )]
      [  XmlElement( ElementName = "PageCssContent"   )]
      public string gxTpr_Pagecsscontent
      {
         get {
            return gxTv_SdtPage_Pagecsscontent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagecsscontent = value;
            SetDirty("Pagecsscontent");
         }

      }

      [  SoapElement( ElementName = "PageJsonContent" )]
      [  XmlElement( ElementName = "PageJsonContent"   )]
      public string gxTpr_Pagejsoncontent
      {
         get {
            return gxTv_SdtPage_Pagejsoncontent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagejsoncontent = value;
            SetDirty("Pagejsoncontent");
         }

      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtPage_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtPage_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CustomerEmail" )]
      [  XmlElement( ElementName = "CustomerEmail"   )]
      public string gxTpr_Customeremail
      {
         get {
            return gxTv_SdtPage_Customeremail ;
         }

         set {
            gxTv_SdtPage_Customeremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPage_Customeremail = value;
            SetDirty("Customeremail");
         }

      }

      public void gxTv_SdtPage_Customeremail_SetNull( )
      {
         gxTv_SdtPage_Customeremail_N = 1;
         gxTv_SdtPage_Customeremail = "";
         SetDirty("Customeremail");
         return  ;
      }

      public bool gxTv_SdtPage_Customeremail_IsNull( )
      {
         return (gxTv_SdtPage_Customeremail_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPage_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPage_Mode_SetNull( )
      {
         gxTv_SdtPage_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPage_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPage_Initialized_SetNull( )
      {
         gxTv_SdtPage_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageId_Z" )]
      [  XmlElement( ElementName = "PageId_Z"   )]
      public short gxTpr_Pageid_Z
      {
         get {
            return gxTv_SdtPage_Pageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pageid_Z = value;
            SetDirty("Pageid_Z");
         }

      }

      public void gxTv_SdtPage_Pageid_Z_SetNull( )
      {
         gxTv_SdtPage_Pageid_Z = 0;
         SetDirty("Pageid_Z");
         return  ;
      }

      public bool gxTv_SdtPage_Pageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PageName_Z" )]
      [  XmlElement( ElementName = "PageName_Z"   )]
      public string gxTpr_Pagename_Z
      {
         get {
            return gxTv_SdtPage_Pagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Pagename_Z = value;
            SetDirty("Pagename_Z");
         }

      }

      public void gxTv_SdtPage_Pagename_Z_SetNull( )
      {
         gxTv_SdtPage_Pagename_Z = "";
         SetDirty("Pagename_Z");
         return  ;
      }

      public bool gxTv_SdtPage_Pagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtPage_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtPage_Customerid_Z_SetNull( )
      {
         gxTv_SdtPage_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtPage_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtPage_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtPage_Customername_Z_SetNull( )
      {
         gxTv_SdtPage_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtPage_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_Z" )]
      [  XmlElement( ElementName = "CustomerEmail_Z"   )]
      public string gxTpr_Customeremail_Z
      {
         get {
            return gxTv_SdtPage_Customeremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customeremail_Z = value;
            SetDirty("Customeremail_Z");
         }

      }

      public void gxTv_SdtPage_Customeremail_Z_SetNull( )
      {
         gxTv_SdtPage_Customeremail_Z = "";
         SetDirty("Customeremail_Z");
         return  ;
      }

      public bool gxTv_SdtPage_Customeremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_N" )]
      [  XmlElement( ElementName = "CustomerEmail_N"   )]
      public short gxTpr_Customeremail_N
      {
         get {
            return gxTv_SdtPage_Customeremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPage_Customeremail_N = value;
            SetDirty("Customeremail_N");
         }

      }

      public void gxTv_SdtPage_Customeremail_N_SetNull( )
      {
         gxTv_SdtPage_Customeremail_N = 0;
         SetDirty("Customeremail_N");
         return  ;
      }

      public bool gxTv_SdtPage_Customeremail_N_IsNull( )
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
         gxTv_SdtPage_Pagename = "";
         gxTv_SdtPage_Pagehtmlcontent = "";
         gxTv_SdtPage_Pagecsscontent = "";
         gxTv_SdtPage_Pagejsoncontent = "";
         gxTv_SdtPage_Customername = "";
         gxTv_SdtPage_Customeremail = "";
         gxTv_SdtPage_Mode = "";
         gxTv_SdtPage_Pagename_Z = "";
         gxTv_SdtPage_Customername_Z = "";
         gxTv_SdtPage_Customeremail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "page", "GeneXus.Programs.page_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtPage_Pageid ;
      private short sdtIsNull ;
      private short gxTv_SdtPage_Customerid ;
      private short gxTv_SdtPage_Initialized ;
      private short gxTv_SdtPage_Pageid_Z ;
      private short gxTv_SdtPage_Customerid_Z ;
      private short gxTv_SdtPage_Customeremail_N ;
      private string gxTv_SdtPage_Mode ;
      private string gxTv_SdtPage_Pagehtmlcontent ;
      private string gxTv_SdtPage_Pagecsscontent ;
      private string gxTv_SdtPage_Pagejsoncontent ;
      private string gxTv_SdtPage_Pagename ;
      private string gxTv_SdtPage_Customername ;
      private string gxTv_SdtPage_Customeremail ;
      private string gxTv_SdtPage_Pagename_Z ;
      private string gxTv_SdtPage_Customername_Z ;
      private string gxTv_SdtPage_Customeremail_Z ;
   }

   [DataContract(Name = @"Page", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtPage_RESTInterface : GxGenericCollectionItem<SdtPage>
   {
      public SdtPage_RESTInterface( ) : base()
      {
      }

      public SdtPage_RESTInterface( SdtPage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PageId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Pageid
      {
         get {
            return sdt.gxTpr_Pageid ;
         }

         set {
            sdt.gxTpr_Pageid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PageName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Pagename
      {
         get {
            return sdt.gxTpr_Pagename ;
         }

         set {
            sdt.gxTpr_Pagename = value;
         }

      }

      [DataMember( Name = "PageHtmlContent" , Order = 2 )]
      public string gxTpr_Pagehtmlcontent
      {
         get {
            return sdt.gxTpr_Pagehtmlcontent ;
         }

         set {
            sdt.gxTpr_Pagehtmlcontent = value;
         }

      }

      [DataMember( Name = "PageCssContent" , Order = 3 )]
      public string gxTpr_Pagecsscontent
      {
         get {
            return sdt.gxTpr_Pagecsscontent ;
         }

         set {
            sdt.gxTpr_Pagecsscontent = value;
         }

      }

      [DataMember( Name = "PageJsonContent" , Order = 4 )]
      public string gxTpr_Pagejsoncontent
      {
         get {
            return sdt.gxTpr_Pagejsoncontent ;
         }

         set {
            sdt.gxTpr_Pagejsoncontent = value;
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

      [DataMember( Name = "CustomerEmail" , Order = 7 )]
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

      public SdtPage sdt
      {
         get {
            return (SdtPage)Sdt ;
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
            sdt = new SdtPage() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"Page", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtPage_RESTLInterface : GxGenericCollectionItem<SdtPage>
   {
      public SdtPage_RESTLInterface( ) : base()
      {
      }

      public SdtPage_RESTLInterface( SdtPage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PageName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Pagename
      {
         get {
            return sdt.gxTpr_Pagename ;
         }

         set {
            sdt.gxTpr_Pagename = value;
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

      public SdtPage sdt
      {
         get {
            return (SdtPage)Sdt ;
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
            sdt = new SdtPage() ;
         }
      }

   }

}
