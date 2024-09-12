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
   [XmlRoot(ElementName = "Supplier_Gen" )]
   [XmlType(TypeName =  "Supplier_Gen" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtSupplier_Gen : GxSilentTrnSdt
   {
      public SdtSupplier_Gen( )
      {
      }

      public SdtSupplier_Gen( IGxContext context )
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

      public void Load( short AV64Supplier_GenId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV64Supplier_GenId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Supplier_GenId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Supplier_Gen");
         metadata.Set("BT", "Supplier_Gen");
         metadata.Set("PK", "[ \"Supplier_GenId\" ]");
         metadata.Set("PKAssigned", "[ \"Supplier_GenId\" ]");
         metadata.Set("Levels", "[ \"ProductService\" ]");
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
         state.Add("gxTpr_Supplier_genid_Z");
         state.Add("gxTpr_Supplier_genkvknumber_Z");
         state.Add("gxTpr_Supplier_gencompanyname_Z");
         state.Add("gxTpr_Supplier_genvisitingaddress_Z");
         state.Add("gxTpr_Supplier_genpostaladdress_Z");
         state.Add("gxTpr_Supplier_gencontactname_Z");
         state.Add("gxTpr_Supplier_gencontactphone_Z");
         state.Add("gxTpr_Supplier_genvisitingaddress_N");
         state.Add("gxTpr_Supplier_genpostaladdress_N");
         state.Add("gxTpr_Supplier_gencontactname_N");
         state.Add("gxTpr_Supplier_gencontactphone_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSupplier_Gen sdt;
         sdt = (SdtSupplier_Gen)(source);
         gxTv_SdtSupplier_Gen_Supplier_genid = sdt.gxTv_SdtSupplier_Gen_Supplier_genid ;
         gxTv_SdtSupplier_Gen_Supplier_genkvknumber = sdt.gxTv_SdtSupplier_Gen_Supplier_genkvknumber ;
         gxTv_SdtSupplier_Gen_Supplier_gencompanyname = sdt.gxTv_SdtSupplier_Gen_Supplier_gencompanyname ;
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress = sdt.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress ;
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress = sdt.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactname = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactname ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactphone ;
         gxTv_SdtSupplier_Gen_Productservice = sdt.gxTv_SdtSupplier_Gen_Productservice ;
         gxTv_SdtSupplier_Gen_Mode = sdt.gxTv_SdtSupplier_Gen_Mode ;
         gxTv_SdtSupplier_Gen_Initialized = sdt.gxTv_SdtSupplier_Gen_Initialized ;
         gxTv_SdtSupplier_Gen_Supplier_genid_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_genid_Z ;
         gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z ;
         gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z ;
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z ;
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z ;
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = sdt.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N ;
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = sdt.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactname_N ;
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N ;
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
         AddObjectProperty("Supplier_GenId", gxTv_SdtSupplier_Gen_Supplier_genid, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenKvKNumber", gxTv_SdtSupplier_Gen_Supplier_genkvknumber, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenCompanyName", gxTv_SdtSupplier_Gen_Supplier_gencompanyname, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenVisitingAddress", gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenVisitingAddress_N", gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenPostalAddress", gxTv_SdtSupplier_Gen_Supplier_genpostaladdress, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenPostalAddress_N", gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenContactName", gxTv_SdtSupplier_Gen_Supplier_gencontactname, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenContactName_N", gxTv_SdtSupplier_Gen_Supplier_gencontactname_N, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenContactPhone", gxTv_SdtSupplier_Gen_Supplier_gencontactphone, false, includeNonInitialized);
         AddObjectProperty("Supplier_GenContactPhone_N", gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N, false, includeNonInitialized);
         if ( gxTv_SdtSupplier_Gen_Productservice != null )
         {
            AddObjectProperty("ProductService", gxTv_SdtSupplier_Gen_Productservice, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSupplier_Gen_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSupplier_Gen_Initialized, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenId_Z", gxTv_SdtSupplier_Gen_Supplier_genid_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenKvKNumber_Z", gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenCompanyName_Z", gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenVisitingAddress_Z", gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenPostalAddress_Z", gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenContactName_Z", gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenContactPhone_Z", gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenVisitingAddress_N", gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenPostalAddress_N", gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenContactName_N", gxTv_SdtSupplier_Gen_Supplier_gencontactname_N, false, includeNonInitialized);
            AddObjectProperty("Supplier_GenContactPhone_N", gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSupplier_Gen sdt )
      {
         if ( sdt.IsDirty("Supplier_GenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genid = sdt.gxTv_SdtSupplier_Gen_Supplier_genid ;
         }
         if ( sdt.IsDirty("Supplier_GenKvKNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genkvknumber = sdt.gxTv_SdtSupplier_Gen_Supplier_genkvknumber ;
         }
         if ( sdt.IsDirty("Supplier_GenCompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencompanyname = sdt.gxTv_SdtSupplier_Gen_Supplier_gencompanyname ;
         }
         if ( sdt.IsDirty("Supplier_GenVisitingAddress") )
         {
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = (short)(sdt.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N);
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress = sdt.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress ;
         }
         if ( sdt.IsDirty("Supplier_GenPostalAddress") )
         {
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = (short)(sdt.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N);
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress = sdt.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress ;
         }
         if ( sdt.IsDirty("Supplier_GenContactName") )
         {
            gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = (short)(sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactname_N);
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactname = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactname ;
         }
         if ( sdt.IsDirty("Supplier_GenContactPhone") )
         {
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = (short)(sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N);
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone = sdt.gxTv_SdtSupplier_Gen_Supplier_gencontactphone ;
         }
         if ( gxTv_SdtSupplier_Gen_Productservice != null )
         {
            GXBCLevelCollection<SdtSupplier_Gen_ProductService> newCollectionProductservice = sdt.gxTpr_Productservice;
            SdtSupplier_Gen_ProductService currItemProductservice;
            SdtSupplier_Gen_ProductService newItemProductservice;
            short idx = 1;
            while ( idx <= newCollectionProductservice.Count )
            {
               newItemProductservice = ((SdtSupplier_Gen_ProductService)newCollectionProductservice.Item(idx));
               currItemProductservice = gxTv_SdtSupplier_Gen_Productservice.GetByKey(newItemProductservice.gxTpr_Productserviceid);
               if ( StringUtil.StrCmp(currItemProductservice.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProductservice.UpdateDirties(newItemProductservice);
                  if ( StringUtil.StrCmp(newItemProductservice.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProductservice.gxTpr_Mode = "DLT";
                  }
                  currItemProductservice.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtSupplier_Gen_Productservice.Add(newItemProductservice, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "Supplier_GenId" )]
      [  XmlElement( ElementName = "Supplier_GenId"   )]
      public short gxTpr_Supplier_genid
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSupplier_Gen_Supplier_genid != value )
            {
               gxTv_SdtSupplier_Gen_Mode = "INS";
               this.gxTv_SdtSupplier_Gen_Supplier_genid_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z_SetNull( );
               this.gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z_SetNull( );
               if ( gxTv_SdtSupplier_Gen_Productservice != null )
               {
                  GXBCLevelCollection<SdtSupplier_Gen_ProductService> collectionProductservice = gxTv_SdtSupplier_Gen_Productservice;
                  SdtSupplier_Gen_ProductService currItemProductservice;
                  short idx = 1;
                  while ( idx <= collectionProductservice.Count )
                  {
                     currItemProductservice = ((SdtSupplier_Gen_ProductService)collectionProductservice.Item(idx));
                     currItemProductservice.gxTpr_Mode = "INS";
                     currItemProductservice.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtSupplier_Gen_Supplier_genid = value;
            SetDirty("Supplier_genid");
         }

      }

      [  SoapElement( ElementName = "Supplier_GenKvKNumber" )]
      [  XmlElement( ElementName = "Supplier_GenKvKNumber"   )]
      public string gxTpr_Supplier_genkvknumber
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genkvknumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genkvknumber = value;
            SetDirty("Supplier_genkvknumber");
         }

      }

      [  SoapElement( ElementName = "Supplier_GenCompanyName" )]
      [  XmlElement( ElementName = "Supplier_GenCompanyName"   )]
      public string gxTpr_Supplier_gencompanyname
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencompanyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencompanyname = value;
            SetDirty("Supplier_gencompanyname");
         }

      }

      [  SoapElement( ElementName = "Supplier_GenVisitingAddress" )]
      [  XmlElement( ElementName = "Supplier_GenVisitingAddress"   )]
      public string gxTpr_Supplier_genvisitingaddress
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress ;
         }

         set {
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress = value;
            SetDirty("Supplier_genvisitingaddress");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = 1;
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress = "";
         SetDirty("Supplier_genvisitingaddress");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_IsNull( )
      {
         return (gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_GenPostalAddress" )]
      [  XmlElement( ElementName = "Supplier_GenPostalAddress"   )]
      public string gxTpr_Supplier_genpostaladdress
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genpostaladdress ;
         }

         set {
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress = value;
            SetDirty("Supplier_genpostaladdress");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = 1;
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress = "";
         SetDirty("Supplier_genpostaladdress");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_IsNull( )
      {
         return (gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactName" )]
      [  XmlElement( ElementName = "Supplier_GenContactName"   )]
      public string gxTpr_Supplier_gencontactname
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactname ;
         }

         set {
            gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactname = value;
            SetDirty("Supplier_gencontactname");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactname_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = 1;
         gxTv_SdtSupplier_Gen_Supplier_gencontactname = "";
         SetDirty("Supplier_gencontactname");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactname_IsNull( )
      {
         return (gxTv_SdtSupplier_Gen_Supplier_gencontactname_N==1) ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactPhone" )]
      [  XmlElement( ElementName = "Supplier_GenContactPhone"   )]
      public string gxTpr_Supplier_gencontactphone
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactphone ;
         }

         set {
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone = value;
            SetDirty("Supplier_gencontactphone");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactphone_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = 1;
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone = "";
         SetDirty("Supplier_gencontactphone");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactphone_IsNull( )
      {
         return (gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N==1) ;
      }

      [  SoapElement( ElementName = "ProductService" )]
      [  XmlArray( ElementName = "ProductService"  )]
      [  XmlArrayItemAttribute( ElementName= "Supplier_Gen.ProductService"  , IsNullable=false)]
      public GXBCLevelCollection<SdtSupplier_Gen_ProductService> gxTpr_Productservice_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtSupplier_Gen_Productservice == null )
            {
               gxTv_SdtSupplier_Gen_Productservice = new GXBCLevelCollection<SdtSupplier_Gen_ProductService>( context, "Supplier_Gen.ProductService", "Comforta2");
            }
            return gxTv_SdtSupplier_Gen_Productservice ;
         }

         set {
            if ( gxTv_SdtSupplier_Gen_Productservice == null )
            {
               gxTv_SdtSupplier_Gen_Productservice = new GXBCLevelCollection<SdtSupplier_Gen_ProductService>( context, "Supplier_Gen.ProductService", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Productservice = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtSupplier_Gen_ProductService> gxTpr_Productservice
      {
         get {
            if ( gxTv_SdtSupplier_Gen_Productservice == null )
            {
               gxTv_SdtSupplier_Gen_Productservice = new GXBCLevelCollection<SdtSupplier_Gen_ProductService>( context, "Supplier_Gen.ProductService", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtSupplier_Gen_Productservice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Productservice = value;
            SetDirty("Productservice");
         }

      }

      public void gxTv_SdtSupplier_Gen_Productservice_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Productservice = null;
         SetDirty("Productservice");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Productservice_IsNull( )
      {
         if ( gxTv_SdtSupplier_Gen_Productservice == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSupplier_Gen_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSupplier_Gen_Mode_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSupplier_Gen_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSupplier_Gen_Initialized_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenId_Z" )]
      [  XmlElement( ElementName = "Supplier_GenId_Z"   )]
      public short gxTpr_Supplier_genid_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genid_Z = value;
            SetDirty("Supplier_genid_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genid_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genid_Z = 0;
         SetDirty("Supplier_genid_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenKvKNumber_Z" )]
      [  XmlElement( ElementName = "Supplier_GenKvKNumber_Z"   )]
      public string gxTpr_Supplier_genkvknumber_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z = value;
            SetDirty("Supplier_genkvknumber_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z = "";
         SetDirty("Supplier_genkvknumber_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenCompanyName_Z" )]
      [  XmlElement( ElementName = "Supplier_GenCompanyName_Z"   )]
      public string gxTpr_Supplier_gencompanyname_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z = value;
            SetDirty("Supplier_gencompanyname_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z = "";
         SetDirty("Supplier_gencompanyname_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenVisitingAddress_Z" )]
      [  XmlElement( ElementName = "Supplier_GenVisitingAddress_Z"   )]
      public string gxTpr_Supplier_genvisitingaddress_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z = value;
            SetDirty("Supplier_genvisitingaddress_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z = "";
         SetDirty("Supplier_genvisitingaddress_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenPostalAddress_Z" )]
      [  XmlElement( ElementName = "Supplier_GenPostalAddress_Z"   )]
      public string gxTpr_Supplier_genpostaladdress_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z = value;
            SetDirty("Supplier_genpostaladdress_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z = "";
         SetDirty("Supplier_genpostaladdress_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactName_Z" )]
      [  XmlElement( ElementName = "Supplier_GenContactName_Z"   )]
      public string gxTpr_Supplier_gencontactname_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z = value;
            SetDirty("Supplier_gencontactname_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z = "";
         SetDirty("Supplier_gencontactname_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactPhone_Z" )]
      [  XmlElement( ElementName = "Supplier_GenContactPhone_Z"   )]
      public string gxTpr_Supplier_gencontactphone_Z
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z = value;
            SetDirty("Supplier_gencontactphone_Z");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z = "";
         SetDirty("Supplier_gencontactphone_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenVisitingAddress_N" )]
      [  XmlElement( ElementName = "Supplier_GenVisitingAddress_N"   )]
      public short gxTpr_Supplier_genvisitingaddress_N
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = value;
            SetDirty("Supplier_genvisitingaddress_N");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N = 0;
         SetDirty("Supplier_genvisitingaddress_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenPostalAddress_N" )]
      [  XmlElement( ElementName = "Supplier_GenPostalAddress_N"   )]
      public short gxTpr_Supplier_genpostaladdress_N
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = value;
            SetDirty("Supplier_genpostaladdress_N");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N = 0;
         SetDirty("Supplier_genpostaladdress_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactName_N" )]
      [  XmlElement( ElementName = "Supplier_GenContactName_N"   )]
      public short gxTpr_Supplier_gencontactname_N
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = value;
            SetDirty("Supplier_gencontactname_N");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactname_N_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_N = 0;
         SetDirty("Supplier_gencontactname_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_GenContactPhone_N" )]
      [  XmlElement( ElementName = "Supplier_GenContactPhone_N"   )]
      public short gxTpr_Supplier_gencontactphone_N
      {
         get {
            return gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = value;
            SetDirty("Supplier_gencontactphone_N");
         }

      }

      public void gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N_SetNull( )
      {
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N = 0;
         SetDirty("Supplier_gencontactphone_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N_IsNull( )
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
         gxTv_SdtSupplier_Gen_Supplier_genkvknumber = "";
         gxTv_SdtSupplier_Gen_Supplier_gencompanyname = "";
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress = "";
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress = "";
         gxTv_SdtSupplier_Gen_Supplier_gencontactname = "";
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone = "";
         gxTv_SdtSupplier_Gen_Mode = "";
         gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z = "";
         gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z = "";
         gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z = "";
         gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z = "";
         gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z = "";
         gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "supplier_gen", "GeneXus.Programs.supplier_gen_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtSupplier_Gen_Supplier_genid ;
      private short sdtIsNull ;
      private short gxTv_SdtSupplier_Gen_Initialized ;
      private short gxTv_SdtSupplier_Gen_Supplier_genid_Z ;
      private short gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_N ;
      private short gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_N ;
      private short gxTv_SdtSupplier_Gen_Supplier_gencontactname_N ;
      private short gxTv_SdtSupplier_Gen_Supplier_gencontactphone_N ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencontactphone ;
      private string gxTv_SdtSupplier_Gen_Mode ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencontactphone_Z ;
      private string gxTv_SdtSupplier_Gen_Supplier_genkvknumber ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencompanyname ;
      private string gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress ;
      private string gxTv_SdtSupplier_Gen_Supplier_genpostaladdress ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencontactname ;
      private string gxTv_SdtSupplier_Gen_Supplier_genkvknumber_Z ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencompanyname_Z ;
      private string gxTv_SdtSupplier_Gen_Supplier_genvisitingaddress_Z ;
      private string gxTv_SdtSupplier_Gen_Supplier_genpostaladdress_Z ;
      private string gxTv_SdtSupplier_Gen_Supplier_gencontactname_Z ;
      private GXBCLevelCollection<SdtSupplier_Gen_ProductService> gxTv_SdtSupplier_Gen_Productservice=null ;
   }

   [DataContract(Name = @"Supplier_Gen", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtSupplier_Gen_RESTInterface : GxGenericCollectionItem<SdtSupplier_Gen>
   {
      public SdtSupplier_Gen_RESTInterface( ) : base()
      {
      }

      public SdtSupplier_Gen_RESTInterface( SdtSupplier_Gen psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Supplier_GenId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Supplier_genid
      {
         get {
            return sdt.gxTpr_Supplier_genid ;
         }

         set {
            sdt.gxTpr_Supplier_genid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Supplier_GenKvKNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Supplier_genkvknumber
      {
         get {
            return sdt.gxTpr_Supplier_genkvknumber ;
         }

         set {
            sdt.gxTpr_Supplier_genkvknumber = value;
         }

      }

      [DataMember( Name = "Supplier_GenCompanyName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Supplier_gencompanyname
      {
         get {
            return sdt.gxTpr_Supplier_gencompanyname ;
         }

         set {
            sdt.gxTpr_Supplier_gencompanyname = value;
         }

      }

      [DataMember( Name = "Supplier_GenVisitingAddress" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Supplier_genvisitingaddress
      {
         get {
            return sdt.gxTpr_Supplier_genvisitingaddress ;
         }

         set {
            sdt.gxTpr_Supplier_genvisitingaddress = value;
         }

      }

      [DataMember( Name = "Supplier_GenPostalAddress" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Supplier_genpostaladdress
      {
         get {
            return sdt.gxTpr_Supplier_genpostaladdress ;
         }

         set {
            sdt.gxTpr_Supplier_genpostaladdress = value;
         }

      }

      [DataMember( Name = "Supplier_GenContactName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Supplier_gencontactname
      {
         get {
            return sdt.gxTpr_Supplier_gencontactname ;
         }

         set {
            sdt.gxTpr_Supplier_gencontactname = value;
         }

      }

      [DataMember( Name = "Supplier_GenContactPhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Supplier_gencontactphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Supplier_gencontactphone) ;
         }

         set {
            sdt.gxTpr_Supplier_gencontactphone = value;
         }

      }

      [DataMember( Name = "ProductService" , Order = 7 )]
      public GxGenericCollection<SdtSupplier_Gen_ProductService_RESTInterface> gxTpr_Productservice
      {
         get {
            return new GxGenericCollection<SdtSupplier_Gen_ProductService_RESTInterface>(sdt.gxTpr_Productservice) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Productservice);
         }

      }

      public SdtSupplier_Gen sdt
      {
         get {
            return (SdtSupplier_Gen)Sdt ;
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
            sdt = new SdtSupplier_Gen() ;
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

   [DataContract(Name = @"Supplier_Gen", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtSupplier_Gen_RESTLInterface : GxGenericCollectionItem<SdtSupplier_Gen>
   {
      public SdtSupplier_Gen_RESTLInterface( ) : base()
      {
      }

      public SdtSupplier_Gen_RESTLInterface( SdtSupplier_Gen psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Supplier_GenKvKNumber" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Supplier_genkvknumber
      {
         get {
            return sdt.gxTpr_Supplier_genkvknumber ;
         }

         set {
            sdt.gxTpr_Supplier_genkvknumber = value;
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

      public SdtSupplier_Gen sdt
      {
         get {
            return (SdtSupplier_Gen)Sdt ;
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
            sdt = new SdtSupplier_Gen() ;
         }
      }

   }

}
