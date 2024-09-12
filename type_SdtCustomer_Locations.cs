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
   [XmlRoot(ElementName = "Customer.Locations" )]
   [XmlType(TypeName =  "Customer.Locations" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtCustomer_Locations : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCustomer_Locations( )
      {
      }

      public SdtCustomer_Locations( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"CustomerLocationId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Locations");
         metadata.Set("BT", "CustomerLocation");
         metadata.Set("PK", "[ \"CustomerLocationId\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerLocationId\" ]");
         metadata.Set("Levels", "[ \"Amenities\",\"Receptionist\",\"Supplier_Agb\",\"Supplier_Gen\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"CustomerLocation\",\"CustomerLocationLastLine\",\"CustomerLocationReceptionistId\",\"CustomerId\",\"CustomerId\",\"CustomerLocationId\",\"CustomerLocationId\" ] ]");
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
         state.Add("gxTpr_Customerlocationid_Z");
         state.Add("gxTpr_Customerlocationvisitingaddress_Z");
         state.Add("gxTpr_Customerlocationpostaladdress_Z");
         state.Add("gxTpr_Customerlocationemail_Z");
         state.Add("gxTpr_Customerlocationphone_Z");
         state.Add("gxTpr_Customerlocationlastline_Z");
         state.Add("gxTpr_Customerlocationdescription_Z");
         state.Add("gxTpr_Customerlocationname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCustomer_Locations sdt;
         sdt = (SdtCustomer_Locations)(source);
         gxTv_SdtCustomer_Locations_Customerlocationid = sdt.gxTv_SdtCustomer_Locations_Customerlocationid ;
         gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress = sdt.gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress ;
         gxTv_SdtCustomer_Locations_Customerlocationpostaladdress = sdt.gxTv_SdtCustomer_Locations_Customerlocationpostaladdress ;
         gxTv_SdtCustomer_Locations_Customerlocationemail = sdt.gxTv_SdtCustomer_Locations_Customerlocationemail ;
         gxTv_SdtCustomer_Locations_Customerlocationphone = sdt.gxTv_SdtCustomer_Locations_Customerlocationphone ;
         gxTv_SdtCustomer_Locations_Customerlocationlastline = sdt.gxTv_SdtCustomer_Locations_Customerlocationlastline ;
         gxTv_SdtCustomer_Locations_Customerlocationdescription = sdt.gxTv_SdtCustomer_Locations_Customerlocationdescription ;
         gxTv_SdtCustomer_Locations_Customerlocationname = sdt.gxTv_SdtCustomer_Locations_Customerlocationname ;
         gxTv_SdtCustomer_Locations_Receptionist = sdt.gxTv_SdtCustomer_Locations_Receptionist ;
         gxTv_SdtCustomer_Locations_Supplier_agb = sdt.gxTv_SdtCustomer_Locations_Supplier_agb ;
         gxTv_SdtCustomer_Locations_Supplier_gen = sdt.gxTv_SdtCustomer_Locations_Supplier_gen ;
         gxTv_SdtCustomer_Locations_Amenities = sdt.gxTv_SdtCustomer_Locations_Amenities ;
         gxTv_SdtCustomer_Locations_Mode = sdt.gxTv_SdtCustomer_Locations_Mode ;
         gxTv_SdtCustomer_Locations_Modified = sdt.gxTv_SdtCustomer_Locations_Modified ;
         gxTv_SdtCustomer_Locations_Initialized = sdt.gxTv_SdtCustomer_Locations_Initialized ;
         gxTv_SdtCustomer_Locations_Customerlocationid_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationid_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationemail_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationemail_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationphone_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationphone_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationlastline_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationlastline_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationdescription_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationdescription_Z ;
         gxTv_SdtCustomer_Locations_Customerlocationname_Z = sdt.gxTv_SdtCustomer_Locations_Customerlocationname_Z ;
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
         AddObjectProperty("CustomerLocationId", gxTv_SdtCustomer_Locations_Customerlocationid, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationVisitingAddress", gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationPostalAddress", gxTv_SdtCustomer_Locations_Customerlocationpostaladdress, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationEmail", gxTv_SdtCustomer_Locations_Customerlocationemail, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationPhone", gxTv_SdtCustomer_Locations_Customerlocationphone, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationLastLine", gxTv_SdtCustomer_Locations_Customerlocationlastline, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationDescription", gxTv_SdtCustomer_Locations_Customerlocationdescription, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationName", gxTv_SdtCustomer_Locations_Customerlocationname, false, includeNonInitialized);
         if ( gxTv_SdtCustomer_Locations_Receptionist != null )
         {
            AddObjectProperty("Receptionist", gxTv_SdtCustomer_Locations_Receptionist, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtCustomer_Locations_Supplier_agb != null )
         {
            AddObjectProperty("Supplier_Agb", gxTv_SdtCustomer_Locations_Supplier_agb, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtCustomer_Locations_Supplier_gen != null )
         {
            AddObjectProperty("Supplier_Gen", gxTv_SdtCustomer_Locations_Supplier_gen, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtCustomer_Locations_Amenities != null )
         {
            AddObjectProperty("Amenities", gxTv_SdtCustomer_Locations_Amenities, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCustomer_Locations_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCustomer_Locations_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCustomer_Locations_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationId_Z", gxTv_SdtCustomer_Locations_Customerlocationid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationVisitingAddress_Z", gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationPostalAddress_Z", gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationEmail_Z", gxTv_SdtCustomer_Locations_Customerlocationemail_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationPhone_Z", gxTv_SdtCustomer_Locations_Customerlocationphone_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationLastLine_Z", gxTv_SdtCustomer_Locations_Customerlocationlastline_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationDescription_Z", gxTv_SdtCustomer_Locations_Customerlocationdescription_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationName_Z", gxTv_SdtCustomer_Locations_Customerlocationname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCustomer_Locations sdt )
      {
         if ( sdt.IsDirty("CustomerLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationid = sdt.gxTv_SdtCustomer_Locations_Customerlocationid ;
         }
         if ( sdt.IsDirty("CustomerLocationVisitingAddress") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress = sdt.gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress ;
         }
         if ( sdt.IsDirty("CustomerLocationPostalAddress") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationpostaladdress = sdt.gxTv_SdtCustomer_Locations_Customerlocationpostaladdress ;
         }
         if ( sdt.IsDirty("CustomerLocationEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationemail = sdt.gxTv_SdtCustomer_Locations_Customerlocationemail ;
         }
         if ( sdt.IsDirty("CustomerLocationPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationphone = sdt.gxTv_SdtCustomer_Locations_Customerlocationphone ;
         }
         if ( sdt.IsDirty("CustomerLocationLastLine") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationlastline = sdt.gxTv_SdtCustomer_Locations_Customerlocationlastline ;
         }
         if ( sdt.IsDirty("CustomerLocationDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationdescription = sdt.gxTv_SdtCustomer_Locations_Customerlocationdescription ;
         }
         if ( sdt.IsDirty("CustomerLocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationname = sdt.gxTv_SdtCustomer_Locations_Customerlocationname ;
         }
         if ( gxTv_SdtCustomer_Locations_Receptionist != null )
         {
            GXBCLevelCollection<SdtCustomer_Locations_Receptionist> newCollectionReceptionist = sdt.gxTpr_Receptionist;
            SdtCustomer_Locations_Receptionist currItemReceptionist;
            SdtCustomer_Locations_Receptionist newItemReceptionist;
            short idx = 1;
            while ( idx <= newCollectionReceptionist.Count )
            {
               newItemReceptionist = ((SdtCustomer_Locations_Receptionist)newCollectionReceptionist.Item(idx));
               currItemReceptionist = gxTv_SdtCustomer_Locations_Receptionist.GetByKey(newItemReceptionist.gxTpr_Customerlocationreceptionistid);
               if ( StringUtil.StrCmp(currItemReceptionist.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemReceptionist.UpdateDirties(newItemReceptionist);
                  if ( StringUtil.StrCmp(newItemReceptionist.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemReceptionist.gxTpr_Mode = "DLT";
                  }
                  currItemReceptionist.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Locations_Receptionist.Add(newItemReceptionist, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtCustomer_Locations_Supplier_agb != null )
         {
            GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb> newCollectionSupplier_agb = sdt.gxTpr_Supplier_agb;
            SdtCustomer_Locations_Supplier_Agb currItemSupplier_agb;
            SdtCustomer_Locations_Supplier_Agb newItemSupplier_agb;
            short idx = 1;
            while ( idx <= newCollectionSupplier_agb.Count )
            {
               newItemSupplier_agb = ((SdtCustomer_Locations_Supplier_Agb)newCollectionSupplier_agb.Item(idx));
               currItemSupplier_agb = gxTv_SdtCustomer_Locations_Supplier_agb.GetByKey(newItemSupplier_agb.gxTpr_Supplier_agbid);
               if ( StringUtil.StrCmp(currItemSupplier_agb.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemSupplier_agb.UpdateDirties(newItemSupplier_agb);
                  if ( StringUtil.StrCmp(newItemSupplier_agb.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemSupplier_agb.gxTpr_Mode = "DLT";
                  }
                  currItemSupplier_agb.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Locations_Supplier_agb.Add(newItemSupplier_agb, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtCustomer_Locations_Supplier_gen != null )
         {
            GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen> newCollectionSupplier_gen = sdt.gxTpr_Supplier_gen;
            SdtCustomer_Locations_Supplier_Gen currItemSupplier_gen;
            SdtCustomer_Locations_Supplier_Gen newItemSupplier_gen;
            short idx = 1;
            while ( idx <= newCollectionSupplier_gen.Count )
            {
               newItemSupplier_gen = ((SdtCustomer_Locations_Supplier_Gen)newCollectionSupplier_gen.Item(idx));
               currItemSupplier_gen = gxTv_SdtCustomer_Locations_Supplier_gen.GetByKey(newItemSupplier_gen.gxTpr_Supplier_genid);
               if ( StringUtil.StrCmp(currItemSupplier_gen.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemSupplier_gen.UpdateDirties(newItemSupplier_gen);
                  if ( StringUtil.StrCmp(newItemSupplier_gen.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemSupplier_gen.gxTpr_Mode = "DLT";
                  }
                  currItemSupplier_gen.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Locations_Supplier_gen.Add(newItemSupplier_gen, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtCustomer_Locations_Amenities != null )
         {
            GXBCLevelCollection<SdtCustomer_Locations_Amenities> newCollectionAmenities = sdt.gxTpr_Amenities;
            SdtCustomer_Locations_Amenities currItemAmenities;
            SdtCustomer_Locations_Amenities newItemAmenities;
            short idx = 1;
            while ( idx <= newCollectionAmenities.Count )
            {
               newItemAmenities = ((SdtCustomer_Locations_Amenities)newCollectionAmenities.Item(idx));
               currItemAmenities = gxTv_SdtCustomer_Locations_Amenities.GetByKey(newItemAmenities.gxTpr_Amenitiesid);
               if ( StringUtil.StrCmp(currItemAmenities.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemAmenities.UpdateDirties(newItemAmenities);
                  if ( StringUtil.StrCmp(newItemAmenities.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemAmenities.gxTpr_Mode = "DLT";
                  }
                  currItemAmenities.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCustomer_Locations_Amenities.Add(newItemAmenities, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerLocationId" )]
      [  XmlElement( ElementName = "CustomerLocationId"   )]
      public short gxTpr_Customerlocationid
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationid = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationid");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationVisitingAddress" )]
      [  XmlElement( ElementName = "CustomerLocationVisitingAddress"   )]
      public string gxTpr_Customerlocationvisitingaddress
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationvisitingaddress");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationPostalAddress" )]
      [  XmlElement( ElementName = "CustomerLocationPostalAddress"   )]
      public string gxTpr_Customerlocationpostaladdress
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationpostaladdress ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationpostaladdress = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationpostaladdress");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationEmail" )]
      [  XmlElement( ElementName = "CustomerLocationEmail"   )]
      public string gxTpr_Customerlocationemail
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationemail = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationemail");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationPhone" )]
      [  XmlElement( ElementName = "CustomerLocationPhone"   )]
      public string gxTpr_Customerlocationphone
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationphone = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationphone");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationLastLine" )]
      [  XmlElement( ElementName = "CustomerLocationLastLine"   )]
      public short gxTpr_Customerlocationlastline
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationlastline ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationlastline = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationlastline");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationDescription" )]
      [  XmlElement( ElementName = "CustomerLocationDescription"   )]
      public string gxTpr_Customerlocationdescription
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationdescription = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationdescription");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationName" )]
      [  XmlElement( ElementName = "CustomerLocationName"   )]
      public string gxTpr_Customerlocationname
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationname = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationname");
         }

      }

      [  SoapElement( ElementName = "Receptionist" )]
      [  XmlArray( ElementName = "Receptionist"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Locations.Receptionist"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Locations_Receptionist> gxTpr_Receptionist_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Receptionist == null )
            {
               gxTv_SdtCustomer_Locations_Receptionist = new GXBCLevelCollection<SdtCustomer_Locations_Receptionist>( context, "Customer.Locations.Receptionist", "");
            }
            return gxTv_SdtCustomer_Locations_Receptionist ;
         }

         set {
            if ( gxTv_SdtCustomer_Locations_Receptionist == null )
            {
               gxTv_SdtCustomer_Locations_Receptionist = new GXBCLevelCollection<SdtCustomer_Locations_Receptionist>( context, "Customer.Locations.Receptionist", "");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Locations_Receptionist> gxTpr_Receptionist
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Receptionist == null )
            {
               gxTv_SdtCustomer_Locations_Receptionist = new GXBCLevelCollection<SdtCustomer_Locations_Receptionist>( context, "Customer.Locations.Receptionist", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Locations_Receptionist ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Receptionist = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Receptionist");
         }

      }

      public void gxTv_SdtCustomer_Locations_Receptionist_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Receptionist = null;
         SetDirty("Receptionist");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Receptionist_IsNull( )
      {
         if ( gxTv_SdtCustomer_Locations_Receptionist == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_Agb" )]
      [  XmlArray( ElementName = "Supplier_Agb"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Locations.Supplier_Agb"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb> gxTpr_Supplier_agb_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Supplier_agb == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_agb = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb>( context, "Customer.Locations.Supplier_Agb", "");
            }
            return gxTv_SdtCustomer_Locations_Supplier_agb ;
         }

         set {
            if ( gxTv_SdtCustomer_Locations_Supplier_agb == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_agb = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb>( context, "Customer.Locations.Supplier_Agb", "");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_agb = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb> gxTpr_Supplier_agb
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Supplier_agb == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_agb = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb>( context, "Customer.Locations.Supplier_Agb", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Locations_Supplier_agb ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_agb = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Supplier_agb");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_agb_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_agb = null;
         SetDirty("Supplier_agb");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_agb_IsNull( )
      {
         if ( gxTv_SdtCustomer_Locations_Supplier_agb == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Supplier_Gen" )]
      [  XmlArray( ElementName = "Supplier_Gen"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Locations.Supplier_Gen"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen> gxTpr_Supplier_gen_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Supplier_gen == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_gen = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen>( context, "Customer.Locations.Supplier_Gen", "");
            }
            return gxTv_SdtCustomer_Locations_Supplier_gen ;
         }

         set {
            if ( gxTv_SdtCustomer_Locations_Supplier_gen == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_gen = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen>( context, "Customer.Locations.Supplier_Gen", "");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_gen = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen> gxTpr_Supplier_gen
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Supplier_gen == null )
            {
               gxTv_SdtCustomer_Locations_Supplier_gen = new GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen>( context, "Customer.Locations.Supplier_Gen", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Locations_Supplier_gen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Supplier_gen = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Supplier_gen");
         }

      }

      public void gxTv_SdtCustomer_Locations_Supplier_gen_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Supplier_gen = null;
         SetDirty("Supplier_gen");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Supplier_gen_IsNull( )
      {
         if ( gxTv_SdtCustomer_Locations_Supplier_gen == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Amenities" )]
      [  XmlArray( ElementName = "Amenities"  )]
      [  XmlArrayItemAttribute( ElementName= "Customer.Locations.Amenities"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCustomer_Locations_Amenities> gxTpr_Amenities_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Amenities == null )
            {
               gxTv_SdtCustomer_Locations_Amenities = new GXBCLevelCollection<SdtCustomer_Locations_Amenities>( context, "Customer.Locations.Amenities", "");
            }
            return gxTv_SdtCustomer_Locations_Amenities ;
         }

         set {
            if ( gxTv_SdtCustomer_Locations_Amenities == null )
            {
               gxTv_SdtCustomer_Locations_Amenities = new GXBCLevelCollection<SdtCustomer_Locations_Amenities>( context, "Customer.Locations.Amenities", "");
            }
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCustomer_Locations_Amenities> gxTpr_Amenities
      {
         get {
            if ( gxTv_SdtCustomer_Locations_Amenities == null )
            {
               gxTv_SdtCustomer_Locations_Amenities = new GXBCLevelCollection<SdtCustomer_Locations_Amenities>( context, "Customer.Locations.Amenities", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtCustomer_Locations_Amenities ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Amenities = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Amenities");
         }

      }

      public void gxTv_SdtCustomer_Locations_Amenities_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Amenities = null;
         SetDirty("Amenities");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Amenities_IsNull( )
      {
         if ( gxTv_SdtCustomer_Locations_Amenities == null )
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
            return gxTv_SdtCustomer_Locations_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCustomer_Locations_Mode_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCustomer_Locations_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCustomer_Locations_Modified_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCustomer_Locations_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Initialized = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCustomer_Locations_Initialized_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationId_Z" )]
      [  XmlElement( ElementName = "CustomerLocationId_Z"   )]
      public short gxTpr_Customerlocationid_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationid_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationid_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationid_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationid_Z = 0;
         SetDirty("Customerlocationid_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationVisitingAddress_Z" )]
      [  XmlElement( ElementName = "CustomerLocationVisitingAddress_Z"   )]
      public string gxTpr_Customerlocationvisitingaddress_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationvisitingaddress_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z = "";
         SetDirty("Customerlocationvisitingaddress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationPostalAddress_Z" )]
      [  XmlElement( ElementName = "CustomerLocationPostalAddress_Z"   )]
      public string gxTpr_Customerlocationpostaladdress_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationpostaladdress_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z = "";
         SetDirty("Customerlocationpostaladdress_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationEmail_Z" )]
      [  XmlElement( ElementName = "CustomerLocationEmail_Z"   )]
      public string gxTpr_Customerlocationemail_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationemail_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationemail_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationemail_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationemail_Z = "";
         SetDirty("Customerlocationemail_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationPhone_Z" )]
      [  XmlElement( ElementName = "CustomerLocationPhone_Z"   )]
      public string gxTpr_Customerlocationphone_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationphone_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationphone_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationphone_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationphone_Z = "";
         SetDirty("Customerlocationphone_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationLastLine_Z" )]
      [  XmlElement( ElementName = "CustomerLocationLastLine_Z"   )]
      public short gxTpr_Customerlocationlastline_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationlastline_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationlastline_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationlastline_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationlastline_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationlastline_Z = 0;
         SetDirty("Customerlocationlastline_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationlastline_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationDescription_Z" )]
      [  XmlElement( ElementName = "CustomerLocationDescription_Z"   )]
      public string gxTpr_Customerlocationdescription_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationdescription_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationdescription_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationdescription_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationdescription_Z = "";
         SetDirty("Customerlocationdescription_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationName_Z" )]
      [  XmlElement( ElementName = "CustomerLocationName_Z"   )]
      public string gxTpr_Customerlocationname_Z
      {
         get {
            return gxTv_SdtCustomer_Locations_Customerlocationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCustomer_Locations_Customerlocationname_Z = value;
            gxTv_SdtCustomer_Locations_Modified = 1;
            SetDirty("Customerlocationname_Z");
         }

      }

      public void gxTv_SdtCustomer_Locations_Customerlocationname_Z_SetNull( )
      {
         gxTv_SdtCustomer_Locations_Customerlocationname_Z = "";
         SetDirty("Customerlocationname_Z");
         return  ;
      }

      public bool gxTv_SdtCustomer_Locations_Customerlocationname_Z_IsNull( )
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
         gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress = "";
         gxTv_SdtCustomer_Locations_Customerlocationpostaladdress = "";
         gxTv_SdtCustomer_Locations_Customerlocationemail = "";
         gxTv_SdtCustomer_Locations_Customerlocationphone = "";
         gxTv_SdtCustomer_Locations_Customerlocationdescription = "";
         gxTv_SdtCustomer_Locations_Customerlocationname = "";
         gxTv_SdtCustomer_Locations_Mode = "";
         gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z = "";
         gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z = "";
         gxTv_SdtCustomer_Locations_Customerlocationemail_Z = "";
         gxTv_SdtCustomer_Locations_Customerlocationphone_Z = "";
         gxTv_SdtCustomer_Locations_Customerlocationdescription_Z = "";
         gxTv_SdtCustomer_Locations_Customerlocationname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCustomer_Locations_Customerlocationid ;
      private short sdtIsNull ;
      private short gxTv_SdtCustomer_Locations_Customerlocationlastline ;
      private short gxTv_SdtCustomer_Locations_Modified ;
      private short gxTv_SdtCustomer_Locations_Initialized ;
      private short gxTv_SdtCustomer_Locations_Customerlocationid_Z ;
      private short gxTv_SdtCustomer_Locations_Customerlocationlastline_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationphone ;
      private string gxTv_SdtCustomer_Locations_Mode ;
      private string gxTv_SdtCustomer_Locations_Customerlocationphone_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress ;
      private string gxTv_SdtCustomer_Locations_Customerlocationpostaladdress ;
      private string gxTv_SdtCustomer_Locations_Customerlocationemail ;
      private string gxTv_SdtCustomer_Locations_Customerlocationdescription ;
      private string gxTv_SdtCustomer_Locations_Customerlocationname ;
      private string gxTv_SdtCustomer_Locations_Customerlocationvisitingaddress_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationpostaladdress_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationemail_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationdescription_Z ;
      private string gxTv_SdtCustomer_Locations_Customerlocationname_Z ;
      private GXBCLevelCollection<SdtCustomer_Locations_Receptionist> gxTv_SdtCustomer_Locations_Receptionist=null ;
      private GXBCLevelCollection<SdtCustomer_Locations_Supplier_Agb> gxTv_SdtCustomer_Locations_Supplier_agb=null ;
      private GXBCLevelCollection<SdtCustomer_Locations_Supplier_Gen> gxTv_SdtCustomer_Locations_Supplier_gen=null ;
      private GXBCLevelCollection<SdtCustomer_Locations_Amenities> gxTv_SdtCustomer_Locations_Amenities=null ;
   }

   [DataContract(Name = @"Customer.Locations", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_RESTInterface : GxGenericCollectionItem<SdtCustomer_Locations>
   {
      public SdtCustomer_Locations_RESTInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_RESTInterface( SdtCustomer_Locations psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerLocationId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlocationid
      {
         get {
            return sdt.gxTpr_Customerlocationid ;
         }

         set {
            sdt.gxTpr_Customerlocationid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerLocationVisitingAddress" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationvisitingaddress
      {
         get {
            return sdt.gxTpr_Customerlocationvisitingaddress ;
         }

         set {
            sdt.gxTpr_Customerlocationvisitingaddress = value;
         }

      }

      [DataMember( Name = "CustomerLocationPostalAddress" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationpostaladdress
      {
         get {
            return sdt.gxTpr_Customerlocationpostaladdress ;
         }

         set {
            sdt.gxTpr_Customerlocationpostaladdress = value;
         }

      }

      [DataMember( Name = "CustomerLocationEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationemail
      {
         get {
            return sdt.gxTpr_Customerlocationemail ;
         }

         set {
            sdt.gxTpr_Customerlocationemail = value;
         }

      }

      [DataMember( Name = "CustomerLocationPhone" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customerlocationphone) ;
         }

         set {
            sdt.gxTpr_Customerlocationphone = value;
         }

      }

      [DataMember( Name = "CustomerLocationLastLine" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerlocationlastline
      {
         get {
            return sdt.gxTpr_Customerlocationlastline ;
         }

         set {
            sdt.gxTpr_Customerlocationlastline = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerLocationDescription" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationdescription
      {
         get {
            return sdt.gxTpr_Customerlocationdescription ;
         }

         set {
            sdt.gxTpr_Customerlocationdescription = value;
         }

      }

      [DataMember( Name = "CustomerLocationName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Customerlocationname
      {
         get {
            return sdt.gxTpr_Customerlocationname ;
         }

         set {
            sdt.gxTpr_Customerlocationname = value;
         }

      }

      [DataMember( Name = "Receptionist" , Order = 8 )]
      public GxGenericCollection<SdtCustomer_Locations_Receptionist_RESTInterface> gxTpr_Receptionist
      {
         get {
            return new GxGenericCollection<SdtCustomer_Locations_Receptionist_RESTInterface>(sdt.gxTpr_Receptionist) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Receptionist);
         }

      }

      [DataMember( Name = "Supplier_Agb" , Order = 9 )]
      public GxGenericCollection<SdtCustomer_Locations_Supplier_Agb_RESTInterface> gxTpr_Supplier_agb
      {
         get {
            return new GxGenericCollection<SdtCustomer_Locations_Supplier_Agb_RESTInterface>(sdt.gxTpr_Supplier_agb) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Supplier_agb);
         }

      }

      [DataMember( Name = "Supplier_Gen" , Order = 10 )]
      public GxGenericCollection<SdtCustomer_Locations_Supplier_Gen_RESTInterface> gxTpr_Supplier_gen
      {
         get {
            return new GxGenericCollection<SdtCustomer_Locations_Supplier_Gen_RESTInterface>(sdt.gxTpr_Supplier_gen) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Supplier_gen);
         }

      }

      [DataMember( Name = "Amenities" , Order = 11 )]
      public GxGenericCollection<SdtCustomer_Locations_Amenities_RESTInterface> gxTpr_Amenities
      {
         get {
            return new GxGenericCollection<SdtCustomer_Locations_Amenities_RESTInterface>(sdt.gxTpr_Amenities) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Amenities);
         }

      }

      public SdtCustomer_Locations sdt
      {
         get {
            return (SdtCustomer_Locations)Sdt ;
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
            sdt = new SdtCustomer_Locations() ;
         }
      }

   }

   [DataContract(Name = @"Customer.Locations", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtCustomer_Locations_RESTLInterface : GxGenericCollectionItem<SdtCustomer_Locations>
   {
      public SdtCustomer_Locations_RESTLInterface( ) : base()
      {
      }

      public SdtCustomer_Locations_RESTLInterface( SdtCustomer_Locations psdt ) : base(psdt)
      {
      }

      public SdtCustomer_Locations sdt
      {
         get {
            return (SdtCustomer_Locations)Sdt ;
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
            sdt = new SdtCustomer_Locations() ;
         }
      }

   }

}
