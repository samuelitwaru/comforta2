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
   [XmlRoot(ElementName = "Customer.Locations.Amenities" )]
   [XmlType(TypeName =  "Customer.Locations.Amenities" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer_Locations_Amenities : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCustomer_Locations_Amenities( )
      {
      }

      public SdtCustomer_Locations_Amenities( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"AmenitiesId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Amenities");
         metadata.Set("BT", "CustomerLocationsAmenities");
         metadata.Set("PK", "[ \"AmenitiesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AmenitiesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CustomerId\",\"CustomerLocationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Amenitiesid_Z");
         state.Add("gxTpr_Amenitiesname_Z");
         state.Add("gxTpr_Amenitiestypeid_Z");
         state.Add("gxTpr_Amenitiestypename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer_Locations_Amenities sdt;
         sdt = (SdtCustomer_Locations_Amenities)(source);
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesid = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesid ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesname = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesname ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename ;
         gxTv_SdtCustomer_Locations_Amenities_Mode = sdt.gxTv_SdtCustomer_Locations_Amenities_Mode ;
         gxTv_SdtCustomer_Locations_Amenities_Modified = sdt.gxTv_SdtCustomer_Locations_Amenities_Modified ;
         gxTv_SdtCustomer_Locations_Amenities_Initialized = sdt.gxTv_SdtCustomer_Locations_Amenities_Initialized ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z ;
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z ;
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
         AddObjectProperty("AmenitiesId", gxTv_SdtCustomer_Locations_Amenities_Amenitiesid, false, includeNonInitialized);
         AddObjectProperty("AmenitiesName", gxTv_SdtCustomer_Locations_Amenities_Amenitiesname, false, includeNonInitialized);
         AddObjectProperty("AmenitiesTypeId", gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid, false, includeNonInitialized);
         AddObjectProperty("AmenitiesTypeName", gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Locations_Amenities_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCustomer_Locations_Amenities_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Locations_Amenities_Initialized, false, includeNonInitialized);
            AddObjectProperty("AmenitiesId_Z", gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z, false, includeNonInitialized);
            AddObjectProperty("AmenitiesName_Z", gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z, false, includeNonInitialized);
            AddObjectProperty("AmenitiesTypeId_Z", gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z, false, includeNonInitialized);
            AddObjectProperty("AmenitiesTypeName_Z", gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer_Locations_Amenities sdt )
      {
         if ( sdt.IsDirty("AmenitiesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesid = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesid ;
         }
         if ( sdt.IsDirty("AmenitiesName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesname = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiesname ;
         }
         if ( sdt.IsDirty("AmenitiesTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid ;
         }
         if ( sdt.IsDirty("AmenitiesTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename = sdt.gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AmenitiesId" )]
      [  XmlElement( ElementName = "AmenitiesId"   )]
      public short gxTpr_Amenitiesid
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiesid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesid = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiesid");
         }

      }

      [  SoapElement( ElementName = "AmenitiesName" )]
      [  XmlElement( ElementName = "AmenitiesName"   )]
      public string gxTpr_Amenitiesname
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiesname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesname = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiesname");
         }

      }

      [  SoapElement( ElementName = "AmenitiesTypeId" )]
      [  XmlElement( ElementName = "AmenitiesTypeId"   )]
      public short gxTpr_Amenitiestypeid
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiestypeid");
         }

      }

      [  SoapElement( ElementName = "AmenitiesTypeName" )]
      [  XmlElement( ElementName = "AmenitiesTypeName"   )]
      public string gxTpr_Amenitiestypename
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiestypename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Modified_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Initialized = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenitiesId_Z" )]
      [  XmlElement( ElementName = "AmenitiesId_Z"   )]
      public short gxTpr_Amenitiesid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiesid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z = 0;
         SetDirty("Amenitiesid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenitiesName_Z" )]
      [  XmlElement( ElementName = "AmenitiesName_Z"   )]
      public string gxTpr_Amenitiesname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiesname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z = "";
         SetDirty("Amenitiesname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenitiesTypeId_Z" )]
      [  XmlElement( ElementName = "AmenitiesTypeId_Z"   )]
      public short gxTpr_Amenitiestypeid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiestypeid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z = 0;
         SetDirty("Amenitiestypeid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AmenitiesTypeName_Z" )]
      [  XmlElement( ElementName = "AmenitiesTypeName_Z"   )]
      public string gxTpr_Amenitiestypename_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z = value;
            gxTv_SdtCustomer_Locations_Amenities_Modified = 1;
            SetDirty("Amenitiestypename_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z = "";
         SetDirty("Amenitiestypename_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z_IsNull( )
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
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesname = "";
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename = "";
         gxTv_SdtCustomer_Locations_Amenities_Mode = "";
         gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z = "";
         gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Locations_Amenities_Amenitiesid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid ;
      private short gxTv_SdtCustomer_Locations_Amenities_Modified ;
      private short gxTv_SdtCustomer_Locations_Amenities_Initialized ;
      private short gxTv_SdtCustomer_Locations_Amenities_Amenitiesid_Z ;
      private short gxTv_SdtCustomer_Locations_Amenities_Amenitiestypeid_Z ;
      private string gxTv_SdtCustomer_Locations_Amenities_Mode ;
      private string gxTv_SdtCustomer_Locations_Amenities_Amenitiesname ;
      private string gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename ;
      private string gxTv_SdtCustomer_Locations_Amenities_Amenitiesname_Z ;
      private string gxTv_SdtCustomer_Locations_Amenities_Amenitiestypename_Z ;
   }

   [DataContract(Name = @"Customer.Locations.Amenities", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Amenities_RESTInterface : GxGenericCollectionItem<SdtCustomer_Locations_Amenities>
   {
      public SdtCustomer_Locations_Amenities_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Amenities_RESTInterface( SdtCustomer_Locations_Amenities psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AmenitiesId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Amenitiesid
      {
         get {
            return sdt.gxTpr_Amenitiesid ;
         }

         set {
            sdt.gxTpr_Amenitiesid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AmenitiesName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Amenitiesname
      {
         get {
            return sdt.gxTpr_Amenitiesname ;
         }

         set {
            sdt.gxTpr_Amenitiesname = value;
         }

      }

      [DataMember( Name = "AmenitiesTypeId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Amenitiestypeid
      {
         get {
            return sdt.gxTpr_Amenitiestypeid ;
         }

         set {
            sdt.gxTpr_Amenitiestypeid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AmenitiesTypeName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Amenitiestypename
      {
         get {
            return sdt.gxTpr_Amenitiestypename ;
         }

         set {
            sdt.gxTpr_Amenitiestypename = value;
         }

      }

      public SdtCustomer_Locations_Amenities sdt
      {
         get {
            return (SdtCustomer_Locations_Amenities)Sdt ;
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
            sdt = new SdtCustomer_Locations_Amenities() ;
         }
      }

   }

   [DataContract(Name = @"Customer.Locations.Amenities", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_Amenities_RESTLInterface : GxGenericCollectionItem<SdtCustomer_Locations_Amenities>
   {
      public SdtCustomer_Locations_Amenities_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_Amenities_RESTLInterface( SdtCustomer_Locations_Amenities psdt ) : base(psdt)
      {
      }

      public SdtCustomer_Locations_Amenities sdt
      {
         get {
            return (SdtCustomer_Locations_Amenities)Sdt ;
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
            sdt = new SdtCustomer_Locations_Amenities() ;
         }
      }

   }

}
