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
   [XmlRoot(ElementName = "Resident" )]
   [XmlType(TypeName =  "Resident" , Namespace = "Comforta2" )]
   [Serializable]
   public class SdtResident : GxSilentTrnSdt
   {
      public SdtResident( )
      {
      }

      public SdtResident( IGxContext context )
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

      public void Load( short AV31ResidentId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV31ResidentId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ResidentId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Resident");
         metadata.Set("BT", "Resident");
         metadata.Set("PK", "[ \"ResidentId\" ]");
         metadata.Set("PKAssigned", "[ \"ResidentId\" ]");
         metadata.Set("Levels", "[ \"INCompany\",\"INIndividual\",\"ProductService\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Resident\",\"ResidentLastLineCompany\",\"ResidentINCompanyId\",\"ResidentId\",\"ResidentId\" ],[ \"Same\",\"Resident\",\"ResidentLastLineIndividual\",\"ResidentINIndividualId\",\"ResidentId\",\"ResidentId\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\",\"CustomerLocationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ResidentTypeId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Residentid_Z");
         state.Add("gxTpr_Residentbsnnumber_Z");
         state.Add("gxTpr_Residentgivenname_Z");
         state.Add("gxTpr_Residentlastname_Z");
         state.Add("gxTpr_Residentinitials_Z");
         state.Add("gxTpr_Residentemail_Z");
         state.Add("gxTpr_Residentgender_Z");
         state.Add("gxTpr_Residentaddress_Z");
         state.Add("gxTpr_Residentphone_Z");
         state.Add("gxTpr_Residentgamguid_Z");
         state.Add("gxTpr_Residenttypeid_Z");
         state.Add("gxTpr_Residenttypename_Z");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customerlocationid_Z");
         state.Add("gxTpr_Residentlastlineindividual_Z");
         state.Add("gxTpr_Residentlastlinecompany_Z");
         state.Add("gxTpr_Residentinitials_N");
         state.Add("gxTpr_Residentaddress_N");
         state.Add("gxTpr_Residentphone_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtResident sdt;
         sdt = (SdtResident)(source);
         gxTv_SdtResident_Residentid = sdt.gxTv_SdtResident_Residentid ;
         gxTv_SdtResident_Residentbsnnumber = sdt.gxTv_SdtResident_Residentbsnnumber ;
         gxTv_SdtResident_Residentgivenname = sdt.gxTv_SdtResident_Residentgivenname ;
         gxTv_SdtResident_Residentlastname = sdt.gxTv_SdtResident_Residentlastname ;
         gxTv_SdtResident_Residentinitials = sdt.gxTv_SdtResident_Residentinitials ;
         gxTv_SdtResident_Residentemail = sdt.gxTv_SdtResident_Residentemail ;
         gxTv_SdtResident_Residentgender = sdt.gxTv_SdtResident_Residentgender ;
         gxTv_SdtResident_Residentaddress = sdt.gxTv_SdtResident_Residentaddress ;
         gxTv_SdtResident_Residentphone = sdt.gxTv_SdtResident_Residentphone ;
         gxTv_SdtResident_Residentgamguid = sdt.gxTv_SdtResident_Residentgamguid ;
         gxTv_SdtResident_Residenttypeid = sdt.gxTv_SdtResident_Residenttypeid ;
         gxTv_SdtResident_Residenttypename = sdt.gxTv_SdtResident_Residenttypename ;
         gxTv_SdtResident_Customerid = sdt.gxTv_SdtResident_Customerid ;
         gxTv_SdtResident_Customername = sdt.gxTv_SdtResident_Customername ;
         gxTv_SdtResident_Customerlocationid = sdt.gxTv_SdtResident_Customerlocationid ;
         gxTv_SdtResident_Residentlastlineindividual = sdt.gxTv_SdtResident_Residentlastlineindividual ;
         gxTv_SdtResident_Residentlastlinecompany = sdt.gxTv_SdtResident_Residentlastlinecompany ;
         gxTv_SdtResident_Inindividual = sdt.gxTv_SdtResident_Inindividual ;
         gxTv_SdtResident_Incompany = sdt.gxTv_SdtResident_Incompany ;
         gxTv_SdtResident_Productservice = sdt.gxTv_SdtResident_Productservice ;
         gxTv_SdtResident_Mode = sdt.gxTv_SdtResident_Mode ;
         gxTv_SdtResident_Initialized = sdt.gxTv_SdtResident_Initialized ;
         gxTv_SdtResident_Residentid_Z = sdt.gxTv_SdtResident_Residentid_Z ;
         gxTv_SdtResident_Residentbsnnumber_Z = sdt.gxTv_SdtResident_Residentbsnnumber_Z ;
         gxTv_SdtResident_Residentgivenname_Z = sdt.gxTv_SdtResident_Residentgivenname_Z ;
         gxTv_SdtResident_Residentlastname_Z = sdt.gxTv_SdtResident_Residentlastname_Z ;
         gxTv_SdtResident_Residentinitials_Z = sdt.gxTv_SdtResident_Residentinitials_Z ;
         gxTv_SdtResident_Residentemail_Z = sdt.gxTv_SdtResident_Residentemail_Z ;
         gxTv_SdtResident_Residentgender_Z = sdt.gxTv_SdtResident_Residentgender_Z ;
         gxTv_SdtResident_Residentaddress_Z = sdt.gxTv_SdtResident_Residentaddress_Z ;
         gxTv_SdtResident_Residentphone_Z = sdt.gxTv_SdtResident_Residentphone_Z ;
         gxTv_SdtResident_Residentgamguid_Z = sdt.gxTv_SdtResident_Residentgamguid_Z ;
         gxTv_SdtResident_Residenttypeid_Z = sdt.gxTv_SdtResident_Residenttypeid_Z ;
         gxTv_SdtResident_Residenttypename_Z = sdt.gxTv_SdtResident_Residenttypename_Z ;
         gxTv_SdtResident_Customerid_Z = sdt.gxTv_SdtResident_Customerid_Z ;
         gxTv_SdtResident_Customername_Z = sdt.gxTv_SdtResident_Customername_Z ;
         gxTv_SdtResident_Customerlocationid_Z = sdt.gxTv_SdtResident_Customerlocationid_Z ;
         gxTv_SdtResident_Residentlastlineindividual_Z = sdt.gxTv_SdtResident_Residentlastlineindividual_Z ;
         gxTv_SdtResident_Residentlastlinecompany_Z = sdt.gxTv_SdtResident_Residentlastlinecompany_Z ;
         gxTv_SdtResident_Residentinitials_N = sdt.gxTv_SdtResident_Residentinitials_N ;
         gxTv_SdtResident_Residentaddress_N = sdt.gxTv_SdtResident_Residentaddress_N ;
         gxTv_SdtResident_Residentphone_N = sdt.gxTv_SdtResident_Residentphone_N ;
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
         AddObjectProperty("ResidentId", gxTv_SdtResident_Residentid, false, includeNonInitialized);
         AddObjectProperty("ResidentBsnNumber", gxTv_SdtResident_Residentbsnnumber, false, includeNonInitialized);
         AddObjectProperty("ResidentGivenName", gxTv_SdtResident_Residentgivenname, false, includeNonInitialized);
         AddObjectProperty("ResidentLastName", gxTv_SdtResident_Residentlastname, false, includeNonInitialized);
         AddObjectProperty("ResidentInitials", gxTv_SdtResident_Residentinitials, false, includeNonInitialized);
         AddObjectProperty("ResidentInitials_N", gxTv_SdtResident_Residentinitials_N, false, includeNonInitialized);
         AddObjectProperty("ResidentEmail", gxTv_SdtResident_Residentemail, false, includeNonInitialized);
         AddObjectProperty("ResidentGender", gxTv_SdtResident_Residentgender, false, includeNonInitialized);
         AddObjectProperty("ResidentAddress", gxTv_SdtResident_Residentaddress, false, includeNonInitialized);
         AddObjectProperty("ResidentAddress_N", gxTv_SdtResident_Residentaddress_N, false, includeNonInitialized);
         AddObjectProperty("ResidentPhone", gxTv_SdtResident_Residentphone, false, includeNonInitialized);
         AddObjectProperty("ResidentPhone_N", gxTv_SdtResident_Residentphone_N, false, includeNonInitialized);
         AddObjectProperty("ResidentGAMGUID", gxTv_SdtResident_Residentgamguid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeId", gxTv_SdtResident_Residenttypeid, false, includeNonInitialized);
         AddObjectProperty("ResidentTypeName", gxTv_SdtResident_Residenttypename, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtResident_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtResident_Customername, false, includeNonInitialized);
         AddObjectProperty("CustomerLocationId", gxTv_SdtResident_Customerlocationid, false, includeNonInitialized);
         AddObjectProperty("ResidentLastLineIndividual", gxTv_SdtResident_Residentlastlineindividual, false, includeNonInitialized);
         AddObjectProperty("ResidentLastLineCompany", gxTv_SdtResident_Residentlastlinecompany, false, includeNonInitialized);
         if ( gxTv_SdtResident_Inindividual != null )
         {
            AddObjectProperty("INIndividual", gxTv_SdtResident_Inindividual, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtResident_Incompany != null )
         {
            AddObjectProperty("INCompany", gxTv_SdtResident_Incompany, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtResident_Productservice != null )
         {
            AddObjectProperty("ProductService", gxTv_SdtResident_Productservice, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtResident_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtResident_Initialized, false, includeNonInitialized);
            AddObjectProperty("ResidentId_Z", gxTv_SdtResident_Residentid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentBsnNumber_Z", gxTv_SdtResident_Residentbsnnumber_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGivenName_Z", gxTv_SdtResident_Residentgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastName_Z", gxTv_SdtResident_Residentlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentInitials_Z", gxTv_SdtResident_Residentinitials_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentEmail_Z", gxTv_SdtResident_Residentemail_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGender_Z", gxTv_SdtResident_Residentgender_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentAddress_Z", gxTv_SdtResident_Residentaddress_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentPhone_Z", gxTv_SdtResident_Residentphone_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentGAMGUID_Z", gxTv_SdtResident_Residentgamguid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeId_Z", gxTv_SdtResident_Residenttypeid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentTypeName_Z", gxTv_SdtResident_Residenttypename_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtResident_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtResident_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerLocationId_Z", gxTv_SdtResident_Customerlocationid_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastLineIndividual_Z", gxTv_SdtResident_Residentlastlineindividual_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentLastLineCompany_Z", gxTv_SdtResident_Residentlastlinecompany_Z, false, includeNonInitialized);
            AddObjectProperty("ResidentInitials_N", gxTv_SdtResident_Residentinitials_N, false, includeNonInitialized);
            AddObjectProperty("ResidentAddress_N", gxTv_SdtResident_Residentaddress_N, false, includeNonInitialized);
            AddObjectProperty("ResidentPhone_N", gxTv_SdtResident_Residentphone_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtResident sdt )
      {
         if ( sdt.IsDirty("ResidentId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentid = sdt.gxTv_SdtResident_Residentid ;
         }
         if ( sdt.IsDirty("ResidentBsnNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentbsnnumber = sdt.gxTv_SdtResident_Residentbsnnumber ;
         }
         if ( sdt.IsDirty("ResidentGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgivenname = sdt.gxTv_SdtResident_Residentgivenname ;
         }
         if ( sdt.IsDirty("ResidentLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastname = sdt.gxTv_SdtResident_Residentlastname ;
         }
         if ( sdt.IsDirty("ResidentInitials") )
         {
            gxTv_SdtResident_Residentinitials_N = (short)(sdt.gxTv_SdtResident_Residentinitials_N);
            sdtIsNull = 0;
            gxTv_SdtResident_Residentinitials = sdt.gxTv_SdtResident_Residentinitials ;
         }
         if ( sdt.IsDirty("ResidentEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentemail = sdt.gxTv_SdtResident_Residentemail ;
         }
         if ( sdt.IsDirty("ResidentGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgender = sdt.gxTv_SdtResident_Residentgender ;
         }
         if ( sdt.IsDirty("ResidentAddress") )
         {
            gxTv_SdtResident_Residentaddress_N = (short)(sdt.gxTv_SdtResident_Residentaddress_N);
            sdtIsNull = 0;
            gxTv_SdtResident_Residentaddress = sdt.gxTv_SdtResident_Residentaddress ;
         }
         if ( sdt.IsDirty("ResidentPhone") )
         {
            gxTv_SdtResident_Residentphone_N = (short)(sdt.gxTv_SdtResident_Residentphone_N);
            sdtIsNull = 0;
            gxTv_SdtResident_Residentphone = sdt.gxTv_SdtResident_Residentphone ;
         }
         if ( sdt.IsDirty("ResidentGAMGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgamguid = sdt.gxTv_SdtResident_Residentgamguid ;
         }
         if ( sdt.IsDirty("ResidentTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypeid = sdt.gxTv_SdtResident_Residenttypeid ;
         }
         if ( sdt.IsDirty("ResidentTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypename = sdt.gxTv_SdtResident_Residenttypename ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerid = sdt.gxTv_SdtResident_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Customername = sdt.gxTv_SdtResident_Customername ;
         }
         if ( sdt.IsDirty("CustomerLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerlocationid = sdt.gxTv_SdtResident_Customerlocationid ;
         }
         if ( sdt.IsDirty("ResidentLastLineIndividual") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlineindividual = sdt.gxTv_SdtResident_Residentlastlineindividual ;
         }
         if ( sdt.IsDirty("ResidentLastLineCompany") )
         {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlinecompany = sdt.gxTv_SdtResident_Residentlastlinecompany ;
         }
         if ( gxTv_SdtResident_Inindividual != null )
         {
            GXBCLevelCollection<SdtResident_INIndividual> newCollectionInindividual = sdt.gxTpr_Inindividual;
            SdtResident_INIndividual currItemInindividual;
            SdtResident_INIndividual newItemInindividual;
            short idx = 1;
            while ( idx <= newCollectionInindividual.Count )
            {
               newItemInindividual = ((SdtResident_INIndividual)newCollectionInindividual.Item(idx));
               currItemInindividual = gxTv_SdtResident_Inindividual.GetByKey(newItemInindividual.gxTpr_Residentinindividualid);
               if ( StringUtil.StrCmp(currItemInindividual.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemInindividual.UpdateDirties(newItemInindividual);
                  if ( StringUtil.StrCmp(newItemInindividual.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemInindividual.gxTpr_Mode = "DLT";
                  }
                  currItemInindividual.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtResident_Inindividual.Add(newItemInindividual, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtResident_Incompany != null )
         {
            GXBCLevelCollection<SdtResident_INCompany> newCollectionIncompany = sdt.gxTpr_Incompany;
            SdtResident_INCompany currItemIncompany;
            SdtResident_INCompany newItemIncompany;
            short idx = 1;
            while ( idx <= newCollectionIncompany.Count )
            {
               newItemIncompany = ((SdtResident_INCompany)newCollectionIncompany.Item(idx));
               currItemIncompany = gxTv_SdtResident_Incompany.GetByKey(newItemIncompany.gxTpr_Residentincompanyid);
               if ( StringUtil.StrCmp(currItemIncompany.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemIncompany.UpdateDirties(newItemIncompany);
                  if ( StringUtil.StrCmp(newItemIncompany.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemIncompany.gxTpr_Mode = "DLT";
                  }
                  currItemIncompany.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtResident_Incompany.Add(newItemIncompany, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtResident_Productservice != null )
         {
            GXBCLevelCollection<SdtResident_ProductService> newCollectionProductservice = sdt.gxTpr_Productservice;
            SdtResident_ProductService currItemProductservice;
            SdtResident_ProductService newItemProductservice;
            short idx = 1;
            while ( idx <= newCollectionProductservice.Count )
            {
               newItemProductservice = ((SdtResident_ProductService)newCollectionProductservice.Item(idx));
               currItemProductservice = gxTv_SdtResident_Productservice.GetByKey(newItemProductservice.gxTpr_Productserviceid);
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
                  gxTv_SdtResident_Productservice.Add(newItemProductservice, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "ResidentId" )]
      [  XmlElement( ElementName = "ResidentId"   )]
      public short gxTpr_Residentid
      {
         get {
            return gxTv_SdtResident_Residentid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtResident_Residentid != value )
            {
               gxTv_SdtResident_Mode = "INS";
               this.gxTv_SdtResident_Residentid_Z_SetNull( );
               this.gxTv_SdtResident_Residentbsnnumber_Z_SetNull( );
               this.gxTv_SdtResident_Residentgivenname_Z_SetNull( );
               this.gxTv_SdtResident_Residentlastname_Z_SetNull( );
               this.gxTv_SdtResident_Residentinitials_Z_SetNull( );
               this.gxTv_SdtResident_Residentemail_Z_SetNull( );
               this.gxTv_SdtResident_Residentgender_Z_SetNull( );
               this.gxTv_SdtResident_Residentaddress_Z_SetNull( );
               this.gxTv_SdtResident_Residentphone_Z_SetNull( );
               this.gxTv_SdtResident_Residentgamguid_Z_SetNull( );
               this.gxTv_SdtResident_Residenttypeid_Z_SetNull( );
               this.gxTv_SdtResident_Residenttypename_Z_SetNull( );
               this.gxTv_SdtResident_Customerid_Z_SetNull( );
               this.gxTv_SdtResident_Customername_Z_SetNull( );
               this.gxTv_SdtResident_Customerlocationid_Z_SetNull( );
               this.gxTv_SdtResident_Residentlastlineindividual_Z_SetNull( );
               this.gxTv_SdtResident_Residentlastlinecompany_Z_SetNull( );
               if ( gxTv_SdtResident_Inindividual != null )
               {
                  GXBCLevelCollection<SdtResident_INIndividual> collectionInindividual = gxTv_SdtResident_Inindividual;
                  SdtResident_INIndividual currItemInindividual;
                  short idx = 1;
                  while ( idx <= collectionInindividual.Count )
                  {
                     currItemInindividual = ((SdtResident_INIndividual)collectionInindividual.Item(idx));
                     currItemInindividual.gxTpr_Mode = "INS";
                     currItemInindividual.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtResident_Incompany != null )
               {
                  GXBCLevelCollection<SdtResident_INCompany> collectionIncompany = gxTv_SdtResident_Incompany;
                  SdtResident_INCompany currItemIncompany;
                  short idx = 1;
                  while ( idx <= collectionIncompany.Count )
                  {
                     currItemIncompany = ((SdtResident_INCompany)collectionIncompany.Item(idx));
                     currItemIncompany.gxTpr_Mode = "INS";
                     currItemIncompany.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtResident_Productservice != null )
               {
                  GXBCLevelCollection<SdtResident_ProductService> collectionProductservice = gxTv_SdtResident_Productservice;
                  SdtResident_ProductService currItemProductservice;
                  short idx = 1;
                  while ( idx <= collectionProductservice.Count )
                  {
                     currItemProductservice = ((SdtResident_ProductService)collectionProductservice.Item(idx));
                     currItemProductservice.gxTpr_Mode = "INS";
                     currItemProductservice.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtResident_Residentid = value;
            SetDirty("Residentid");
         }

      }

      [  SoapElement( ElementName = "ResidentBsnNumber" )]
      [  XmlElement( ElementName = "ResidentBsnNumber"   )]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return gxTv_SdtResident_Residentbsnnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentbsnnumber = value;
            SetDirty("Residentbsnnumber");
         }

      }

      [  SoapElement( ElementName = "ResidentGivenName" )]
      [  XmlElement( ElementName = "ResidentGivenName"   )]
      public string gxTpr_Residentgivenname
      {
         get {
            return gxTv_SdtResident_Residentgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgivenname = value;
            SetDirty("Residentgivenname");
         }

      }

      [  SoapElement( ElementName = "ResidentLastName" )]
      [  XmlElement( ElementName = "ResidentLastName"   )]
      public string gxTpr_Residentlastname
      {
         get {
            return gxTv_SdtResident_Residentlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastname = value;
            SetDirty("Residentlastname");
         }

      }

      [  SoapElement( ElementName = "ResidentInitials" )]
      [  XmlElement( ElementName = "ResidentInitials"   )]
      public string gxTpr_Residentinitials
      {
         get {
            return gxTv_SdtResident_Residentinitials ;
         }

         set {
            gxTv_SdtResident_Residentinitials_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_Residentinitials = value;
            SetDirty("Residentinitials");
         }

      }

      public void gxTv_SdtResident_Residentinitials_SetNull( )
      {
         gxTv_SdtResident_Residentinitials_N = 1;
         gxTv_SdtResident_Residentinitials = "";
         SetDirty("Residentinitials");
         return  ;
      }

      public bool gxTv_SdtResident_Residentinitials_IsNull( )
      {
         return (gxTv_SdtResident_Residentinitials_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentEmail" )]
      [  XmlElement( ElementName = "ResidentEmail"   )]
      public string gxTpr_Residentemail
      {
         get {
            return gxTv_SdtResident_Residentemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentemail = value;
            SetDirty("Residentemail");
         }

      }

      [  SoapElement( ElementName = "ResidentGender" )]
      [  XmlElement( ElementName = "ResidentGender"   )]
      public string gxTpr_Residentgender
      {
         get {
            return gxTv_SdtResident_Residentgender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgender = value;
            SetDirty("Residentgender");
         }

      }

      [  SoapElement( ElementName = "ResidentAddress" )]
      [  XmlElement( ElementName = "ResidentAddress"   )]
      public string gxTpr_Residentaddress
      {
         get {
            return gxTv_SdtResident_Residentaddress ;
         }

         set {
            gxTv_SdtResident_Residentaddress_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_Residentaddress = value;
            SetDirty("Residentaddress");
         }

      }

      public void gxTv_SdtResident_Residentaddress_SetNull( )
      {
         gxTv_SdtResident_Residentaddress_N = 1;
         gxTv_SdtResident_Residentaddress = "";
         SetDirty("Residentaddress");
         return  ;
      }

      public bool gxTv_SdtResident_Residentaddress_IsNull( )
      {
         return (gxTv_SdtResident_Residentaddress_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentPhone" )]
      [  XmlElement( ElementName = "ResidentPhone"   )]
      public string gxTpr_Residentphone
      {
         get {
            return gxTv_SdtResident_Residentphone ;
         }

         set {
            gxTv_SdtResident_Residentphone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtResident_Residentphone = value;
            SetDirty("Residentphone");
         }

      }

      public void gxTv_SdtResident_Residentphone_SetNull( )
      {
         gxTv_SdtResident_Residentphone_N = 1;
         gxTv_SdtResident_Residentphone = "";
         SetDirty("Residentphone");
         return  ;
      }

      public bool gxTv_SdtResident_Residentphone_IsNull( )
      {
         return (gxTv_SdtResident_Residentphone_N==1) ;
      }

      [  SoapElement( ElementName = "ResidentGAMGUID" )]
      [  XmlElement( ElementName = "ResidentGAMGUID"   )]
      public string gxTpr_Residentgamguid
      {
         get {
            return gxTv_SdtResident_Residentgamguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgamguid = value;
            SetDirty("Residentgamguid");
         }

      }

      [  SoapElement( ElementName = "ResidentTypeId" )]
      [  XmlElement( ElementName = "ResidentTypeId"   )]
      public short gxTpr_Residenttypeid
      {
         get {
            return gxTv_SdtResident_Residenttypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypeid = value;
            SetDirty("Residenttypeid");
         }

      }

      [  SoapElement( ElementName = "ResidentTypeName" )]
      [  XmlElement( ElementName = "ResidentTypeName"   )]
      public string gxTpr_Residenttypename
      {
         get {
            return gxTv_SdtResident_Residenttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypename = value;
            SetDirty("Residenttypename");
         }

      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtResident_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtResident_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CustomerLocationId" )]
      [  XmlElement( ElementName = "CustomerLocationId"   )]
      public short gxTpr_Customerlocationid
      {
         get {
            return gxTv_SdtResident_Customerlocationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerlocationid = value;
            SetDirty("Customerlocationid");
         }

      }

      [  SoapElement( ElementName = "ResidentLastLineIndividual" )]
      [  XmlElement( ElementName = "ResidentLastLineIndividual"   )]
      public short gxTpr_Residentlastlineindividual
      {
         get {
            return gxTv_SdtResident_Residentlastlineindividual ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlineindividual = value;
            SetDirty("Residentlastlineindividual");
         }

      }

      [  SoapElement( ElementName = "ResidentLastLineCompany" )]
      [  XmlElement( ElementName = "ResidentLastLineCompany"   )]
      public short gxTpr_Residentlastlinecompany
      {
         get {
            return gxTv_SdtResident_Residentlastlinecompany ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlinecompany = value;
            SetDirty("Residentlastlinecompany");
         }

      }

      [  SoapElement( ElementName = "INIndividual" )]
      [  XmlArray( ElementName = "INIndividual"  )]
      [  XmlArrayItemAttribute( ElementName= "Resident.INIndividual"  , IsNullable=false)]
      public GXBCLevelCollection<SdtResident_INIndividual> gxTpr_Inindividual_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtResident_Inindividual == null )
            {
               gxTv_SdtResident_Inindividual = new GXBCLevelCollection<SdtResident_INIndividual>( context, "Resident.INIndividual", "Comforta2");
            }
            return gxTv_SdtResident_Inindividual ;
         }

         set {
            if ( gxTv_SdtResident_Inindividual == null )
            {
               gxTv_SdtResident_Inindividual = new GXBCLevelCollection<SdtResident_INIndividual>( context, "Resident.INIndividual", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtResident_Inindividual = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtResident_INIndividual> gxTpr_Inindividual
      {
         get {
            if ( gxTv_SdtResident_Inindividual == null )
            {
               gxTv_SdtResident_Inindividual = new GXBCLevelCollection<SdtResident_INIndividual>( context, "Resident.INIndividual", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtResident_Inindividual ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Inindividual = value;
            SetDirty("Inindividual");
         }

      }

      public void gxTv_SdtResident_Inindividual_SetNull( )
      {
         gxTv_SdtResident_Inindividual = null;
         SetDirty("Inindividual");
         return  ;
      }

      public bool gxTv_SdtResident_Inindividual_IsNull( )
      {
         if ( gxTv_SdtResident_Inindividual == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "INCompany" )]
      [  XmlArray( ElementName = "INCompany"  )]
      [  XmlArrayItemAttribute( ElementName= "Resident.INCompany"  , IsNullable=false)]
      public GXBCLevelCollection<SdtResident_INCompany> gxTpr_Incompany_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtResident_Incompany == null )
            {
               gxTv_SdtResident_Incompany = new GXBCLevelCollection<SdtResident_INCompany>( context, "Resident.INCompany", "Comforta2");
            }
            return gxTv_SdtResident_Incompany ;
         }

         set {
            if ( gxTv_SdtResident_Incompany == null )
            {
               gxTv_SdtResident_Incompany = new GXBCLevelCollection<SdtResident_INCompany>( context, "Resident.INCompany", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtResident_Incompany = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtResident_INCompany> gxTpr_Incompany
      {
         get {
            if ( gxTv_SdtResident_Incompany == null )
            {
               gxTv_SdtResident_Incompany = new GXBCLevelCollection<SdtResident_INCompany>( context, "Resident.INCompany", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtResident_Incompany ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Incompany = value;
            SetDirty("Incompany");
         }

      }

      public void gxTv_SdtResident_Incompany_SetNull( )
      {
         gxTv_SdtResident_Incompany = null;
         SetDirty("Incompany");
         return  ;
      }

      public bool gxTv_SdtResident_Incompany_IsNull( )
      {
         if ( gxTv_SdtResident_Incompany == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "ProductService" )]
      [  XmlArray( ElementName = "ProductService"  )]
      [  XmlArrayItemAttribute( ElementName= "Resident.ProductService"  , IsNullable=false)]
      public GXBCLevelCollection<SdtResident_ProductService> gxTpr_Productservice_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtResident_Productservice == null )
            {
               gxTv_SdtResident_Productservice = new GXBCLevelCollection<SdtResident_ProductService>( context, "Resident.ProductService", "Comforta2");
            }
            return gxTv_SdtResident_Productservice ;
         }

         set {
            if ( gxTv_SdtResident_Productservice == null )
            {
               gxTv_SdtResident_Productservice = new GXBCLevelCollection<SdtResident_ProductService>( context, "Resident.ProductService", "Comforta2");
            }
            sdtIsNull = 0;
            gxTv_SdtResident_Productservice = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtResident_ProductService> gxTpr_Productservice
      {
         get {
            if ( gxTv_SdtResident_Productservice == null )
            {
               gxTv_SdtResident_Productservice = new GXBCLevelCollection<SdtResident_ProductService>( context, "Resident.ProductService", "Comforta2");
            }
            sdtIsNull = 0;
            return gxTv_SdtResident_Productservice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Productservice = value;
            SetDirty("Productservice");
         }

      }

      public void gxTv_SdtResident_Productservice_SetNull( )
      {
         gxTv_SdtResident_Productservice = null;
         SetDirty("Productservice");
         return  ;
      }

      public bool gxTv_SdtResident_Productservice_IsNull( )
      {
         if ( gxTv_SdtResident_Productservice == null )
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
            return gxTv_SdtResident_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtResident_Mode_SetNull( )
      {
         gxTv_SdtResident_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtResident_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtResident_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtResident_Initialized_SetNull( )
      {
         gxTv_SdtResident_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtResident_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentId_Z" )]
      [  XmlElement( ElementName = "ResidentId_Z"   )]
      public short gxTpr_Residentid_Z
      {
         get {
            return gxTv_SdtResident_Residentid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentid_Z = value;
            SetDirty("Residentid_Z");
         }

      }

      public void gxTv_SdtResident_Residentid_Z_SetNull( )
      {
         gxTv_SdtResident_Residentid_Z = 0;
         SetDirty("Residentid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentBsnNumber_Z" )]
      [  XmlElement( ElementName = "ResidentBsnNumber_Z"   )]
      public string gxTpr_Residentbsnnumber_Z
      {
         get {
            return gxTv_SdtResident_Residentbsnnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentbsnnumber_Z = value;
            SetDirty("Residentbsnnumber_Z");
         }

      }

      public void gxTv_SdtResident_Residentbsnnumber_Z_SetNull( )
      {
         gxTv_SdtResident_Residentbsnnumber_Z = "";
         SetDirty("Residentbsnnumber_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentbsnnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGivenName_Z" )]
      [  XmlElement( ElementName = "ResidentGivenName_Z"   )]
      public string gxTpr_Residentgivenname_Z
      {
         get {
            return gxTv_SdtResident_Residentgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgivenname_Z = value;
            SetDirty("Residentgivenname_Z");
         }

      }

      public void gxTv_SdtResident_Residentgivenname_Z_SetNull( )
      {
         gxTv_SdtResident_Residentgivenname_Z = "";
         SetDirty("Residentgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastName_Z" )]
      [  XmlElement( ElementName = "ResidentLastName_Z"   )]
      public string gxTpr_Residentlastname_Z
      {
         get {
            return gxTv_SdtResident_Residentlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastname_Z = value;
            SetDirty("Residentlastname_Z");
         }

      }

      public void gxTv_SdtResident_Residentlastname_Z_SetNull( )
      {
         gxTv_SdtResident_Residentlastname_Z = "";
         SetDirty("Residentlastname_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentInitials_Z" )]
      [  XmlElement( ElementName = "ResidentInitials_Z"   )]
      public string gxTpr_Residentinitials_Z
      {
         get {
            return gxTv_SdtResident_Residentinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentinitials_Z = value;
            SetDirty("Residentinitials_Z");
         }

      }

      public void gxTv_SdtResident_Residentinitials_Z_SetNull( )
      {
         gxTv_SdtResident_Residentinitials_Z = "";
         SetDirty("Residentinitials_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentEmail_Z" )]
      [  XmlElement( ElementName = "ResidentEmail_Z"   )]
      public string gxTpr_Residentemail_Z
      {
         get {
            return gxTv_SdtResident_Residentemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentemail_Z = value;
            SetDirty("Residentemail_Z");
         }

      }

      public void gxTv_SdtResident_Residentemail_Z_SetNull( )
      {
         gxTv_SdtResident_Residentemail_Z = "";
         SetDirty("Residentemail_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGender_Z" )]
      [  XmlElement( ElementName = "ResidentGender_Z"   )]
      public string gxTpr_Residentgender_Z
      {
         get {
            return gxTv_SdtResident_Residentgender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgender_Z = value;
            SetDirty("Residentgender_Z");
         }

      }

      public void gxTv_SdtResident_Residentgender_Z_SetNull( )
      {
         gxTv_SdtResident_Residentgender_Z = "";
         SetDirty("Residentgender_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentgender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddress_Z" )]
      [  XmlElement( ElementName = "ResidentAddress_Z"   )]
      public string gxTpr_Residentaddress_Z
      {
         get {
            return gxTv_SdtResident_Residentaddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentaddress_Z = value;
            SetDirty("Residentaddress_Z");
         }

      }

      public void gxTv_SdtResident_Residentaddress_Z_SetNull( )
      {
         gxTv_SdtResident_Residentaddress_Z = "";
         SetDirty("Residentaddress_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentaddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhone_Z" )]
      [  XmlElement( ElementName = "ResidentPhone_Z"   )]
      public string gxTpr_Residentphone_Z
      {
         get {
            return gxTv_SdtResident_Residentphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentphone_Z = value;
            SetDirty("Residentphone_Z");
         }

      }

      public void gxTv_SdtResident_Residentphone_Z_SetNull( )
      {
         gxTv_SdtResident_Residentphone_Z = "";
         SetDirty("Residentphone_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentGAMGUID_Z" )]
      [  XmlElement( ElementName = "ResidentGAMGUID_Z"   )]
      public string gxTpr_Residentgamguid_Z
      {
         get {
            return gxTv_SdtResident_Residentgamguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentgamguid_Z = value;
            SetDirty("Residentgamguid_Z");
         }

      }

      public void gxTv_SdtResident_Residentgamguid_Z_SetNull( )
      {
         gxTv_SdtResident_Residentgamguid_Z = "";
         SetDirty("Residentgamguid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentgamguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeId_Z" )]
      [  XmlElement( ElementName = "ResidentTypeId_Z"   )]
      public short gxTpr_Residenttypeid_Z
      {
         get {
            return gxTv_SdtResident_Residenttypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypeid_Z = value;
            SetDirty("Residenttypeid_Z");
         }

      }

      public void gxTv_SdtResident_Residenttypeid_Z_SetNull( )
      {
         gxTv_SdtResident_Residenttypeid_Z = 0;
         SetDirty("Residenttypeid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residenttypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentTypeName_Z" )]
      [  XmlElement( ElementName = "ResidentTypeName_Z"   )]
      public string gxTpr_Residenttypename_Z
      {
         get {
            return gxTv_SdtResident_Residenttypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residenttypename_Z = value;
            SetDirty("Residenttypename_Z");
         }

      }

      public void gxTv_SdtResident_Residenttypename_Z_SetNull( )
      {
         gxTv_SdtResident_Residenttypename_Z = "";
         SetDirty("Residenttypename_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residenttypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtResident_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtResident_Customerid_Z_SetNull( )
      {
         gxTv_SdtResident_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtResident_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtResident_Customername_Z_SetNull( )
      {
         gxTv_SdtResident_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerLocationId_Z" )]
      [  XmlElement( ElementName = "CustomerLocationId_Z"   )]
      public short gxTpr_Customerlocationid_Z
      {
         get {
            return gxTv_SdtResident_Customerlocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Customerlocationid_Z = value;
            SetDirty("Customerlocationid_Z");
         }

      }

      public void gxTv_SdtResident_Customerlocationid_Z_SetNull( )
      {
         gxTv_SdtResident_Customerlocationid_Z = 0;
         SetDirty("Customerlocationid_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Customerlocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastLineIndividual_Z" )]
      [  XmlElement( ElementName = "ResidentLastLineIndividual_Z"   )]
      public short gxTpr_Residentlastlineindividual_Z
      {
         get {
            return gxTv_SdtResident_Residentlastlineindividual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlineindividual_Z = value;
            SetDirty("Residentlastlineindividual_Z");
         }

      }

      public void gxTv_SdtResident_Residentlastlineindividual_Z_SetNull( )
      {
         gxTv_SdtResident_Residentlastlineindividual_Z = 0;
         SetDirty("Residentlastlineindividual_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentlastlineindividual_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentLastLineCompany_Z" )]
      [  XmlElement( ElementName = "ResidentLastLineCompany_Z"   )]
      public short gxTpr_Residentlastlinecompany_Z
      {
         get {
            return gxTv_SdtResident_Residentlastlinecompany_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentlastlinecompany_Z = value;
            SetDirty("Residentlastlinecompany_Z");
         }

      }

      public void gxTv_SdtResident_Residentlastlinecompany_Z_SetNull( )
      {
         gxTv_SdtResident_Residentlastlinecompany_Z = 0;
         SetDirty("Residentlastlinecompany_Z");
         return  ;
      }

      public bool gxTv_SdtResident_Residentlastlinecompany_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentInitials_N" )]
      [  XmlElement( ElementName = "ResidentInitials_N"   )]
      public short gxTpr_Residentinitials_N
      {
         get {
            return gxTv_SdtResident_Residentinitials_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentinitials_N = value;
            SetDirty("Residentinitials_N");
         }

      }

      public void gxTv_SdtResident_Residentinitials_N_SetNull( )
      {
         gxTv_SdtResident_Residentinitials_N = 0;
         SetDirty("Residentinitials_N");
         return  ;
      }

      public bool gxTv_SdtResident_Residentinitials_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentAddress_N" )]
      [  XmlElement( ElementName = "ResidentAddress_N"   )]
      public short gxTpr_Residentaddress_N
      {
         get {
            return gxTv_SdtResident_Residentaddress_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentaddress_N = value;
            SetDirty("Residentaddress_N");
         }

      }

      public void gxTv_SdtResident_Residentaddress_N_SetNull( )
      {
         gxTv_SdtResident_Residentaddress_N = 0;
         SetDirty("Residentaddress_N");
         return  ;
      }

      public bool gxTv_SdtResident_Residentaddress_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ResidentPhone_N" )]
      [  XmlElement( ElementName = "ResidentPhone_N"   )]
      public short gxTpr_Residentphone_N
      {
         get {
            return gxTv_SdtResident_Residentphone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtResident_Residentphone_N = value;
            SetDirty("Residentphone_N");
         }

      }

      public void gxTv_SdtResident_Residentphone_N_SetNull( )
      {
         gxTv_SdtResident_Residentphone_N = 0;
         SetDirty("Residentphone_N");
         return  ;
      }

      public bool gxTv_SdtResident_Residentphone_N_IsNull( )
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
         gxTv_SdtResident_Residentbsnnumber = "";
         gxTv_SdtResident_Residentgivenname = "";
         gxTv_SdtResident_Residentlastname = "";
         gxTv_SdtResident_Residentinitials = "";
         gxTv_SdtResident_Residentemail = "";
         gxTv_SdtResident_Residentgender = "";
         gxTv_SdtResident_Residentaddress = "";
         gxTv_SdtResident_Residentphone = "";
         gxTv_SdtResident_Residentgamguid = "";
         gxTv_SdtResident_Residenttypename = "";
         gxTv_SdtResident_Customername = "";
         gxTv_SdtResident_Mode = "";
         gxTv_SdtResident_Residentbsnnumber_Z = "";
         gxTv_SdtResident_Residentgivenname_Z = "";
         gxTv_SdtResident_Residentlastname_Z = "";
         gxTv_SdtResident_Residentinitials_Z = "";
         gxTv_SdtResident_Residentemail_Z = "";
         gxTv_SdtResident_Residentgender_Z = "";
         gxTv_SdtResident_Residentaddress_Z = "";
         gxTv_SdtResident_Residentphone_Z = "";
         gxTv_SdtResident_Residentgamguid_Z = "";
         gxTv_SdtResident_Residenttypename_Z = "";
         gxTv_SdtResident_Customername_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "resident", "GeneXus.Programs.resident_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtResident_Residentid ;
      private short sdtIsNull ;
      private short gxTv_SdtResident_Residenttypeid ;
      private short gxTv_SdtResident_Customerid ;
      private short gxTv_SdtResident_Customerlocationid ;
      private short gxTv_SdtResident_Residentlastlineindividual ;
      private short gxTv_SdtResident_Residentlastlinecompany ;
      private short gxTv_SdtResident_Initialized ;
      private short gxTv_SdtResident_Residentid_Z ;
      private short gxTv_SdtResident_Residenttypeid_Z ;
      private short gxTv_SdtResident_Customerid_Z ;
      private short gxTv_SdtResident_Customerlocationid_Z ;
      private short gxTv_SdtResident_Residentlastlineindividual_Z ;
      private short gxTv_SdtResident_Residentlastlinecompany_Z ;
      private short gxTv_SdtResident_Residentinitials_N ;
      private short gxTv_SdtResident_Residentaddress_N ;
      private short gxTv_SdtResident_Residentphone_N ;
      private string gxTv_SdtResident_Residentinitials ;
      private string gxTv_SdtResident_Residentgender ;
      private string gxTv_SdtResident_Residentphone ;
      private string gxTv_SdtResident_Mode ;
      private string gxTv_SdtResident_Residentinitials_Z ;
      private string gxTv_SdtResident_Residentgender_Z ;
      private string gxTv_SdtResident_Residentphone_Z ;
      private string gxTv_SdtResident_Residentbsnnumber ;
      private string gxTv_SdtResident_Residentgivenname ;
      private string gxTv_SdtResident_Residentlastname ;
      private string gxTv_SdtResident_Residentemail ;
      private string gxTv_SdtResident_Residentaddress ;
      private string gxTv_SdtResident_Residentgamguid ;
      private string gxTv_SdtResident_Residenttypename ;
      private string gxTv_SdtResident_Customername ;
      private string gxTv_SdtResident_Residentbsnnumber_Z ;
      private string gxTv_SdtResident_Residentgivenname_Z ;
      private string gxTv_SdtResident_Residentlastname_Z ;
      private string gxTv_SdtResident_Residentemail_Z ;
      private string gxTv_SdtResident_Residentaddress_Z ;
      private string gxTv_SdtResident_Residentgamguid_Z ;
      private string gxTv_SdtResident_Residenttypename_Z ;
      private string gxTv_SdtResident_Customername_Z ;
      private GXBCLevelCollection<SdtResident_INIndividual> gxTv_SdtResident_Inindividual=null ;
      private GXBCLevelCollection<SdtResident_INCompany> gxTv_SdtResident_Incompany=null ;
      private GXBCLevelCollection<SdtResident_ProductService> gxTv_SdtResident_Productservice=null ;
   }

   [DataContract(Name = @"Resident", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_RESTInterface : GxGenericCollectionItem<SdtResident>
   {
      public SdtResident_RESTInterface( ) : base()
      {
      }

      public SdtResident_RESTInterface( SdtResident psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residentid
      {
         get {
            return sdt.gxTpr_Residentid ;
         }

         set {
            sdt.gxTpr_Residentid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResidentBsnNumber" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return sdt.gxTpr_Residentbsnnumber ;
         }

         set {
            sdt.gxTpr_Residentbsnnumber = value;
         }

      }

      [DataMember( Name = "ResidentGivenName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Residentgivenname
      {
         get {
            return sdt.gxTpr_Residentgivenname ;
         }

         set {
            sdt.gxTpr_Residentgivenname = value;
         }

      }

      [DataMember( Name = "ResidentLastName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Residentlastname
      {
         get {
            return sdt.gxTpr_Residentlastname ;
         }

         set {
            sdt.gxTpr_Residentlastname = value;
         }

      }

      [DataMember( Name = "ResidentInitials" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Residentinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentinitials) ;
         }

         set {
            sdt.gxTpr_Residentinitials = value;
         }

      }

      [DataMember( Name = "ResidentEmail" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Residentemail
      {
         get {
            return sdt.gxTpr_Residentemail ;
         }

         set {
            sdt.gxTpr_Residentemail = value;
         }

      }

      [DataMember( Name = "ResidentGender" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Residentgender
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentgender) ;
         }

         set {
            sdt.gxTpr_Residentgender = value;
         }

      }

      [DataMember( Name = "ResidentAddress" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Residentaddress
      {
         get {
            return sdt.gxTpr_Residentaddress ;
         }

         set {
            sdt.gxTpr_Residentaddress = value;
         }

      }

      [DataMember( Name = "ResidentPhone" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Residentphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Residentphone) ;
         }

         set {
            sdt.gxTpr_Residentphone = value;
         }

      }

      [DataMember( Name = "ResidentGAMGUID" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Residentgamguid
      {
         get {
            return sdt.gxTpr_Residentgamguid ;
         }

         set {
            sdt.gxTpr_Residentgamguid = value;
         }

      }

      [DataMember( Name = "ResidentTypeId" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residenttypeid
      {
         get {
            return sdt.gxTpr_Residenttypeid ;
         }

         set {
            sdt.gxTpr_Residenttypeid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResidentTypeName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Residenttypename
      {
         get {
            return sdt.gxTpr_Residenttypename ;
         }

         set {
            sdt.gxTpr_Residenttypename = value;
         }

      }

      [DataMember( Name = "CustomerId" , Order = 12 )]
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

      [DataMember( Name = "CustomerName" , Order = 13 )]
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

      [DataMember( Name = "CustomerLocationId" , Order = 14 )]
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

      [DataMember( Name = "ResidentLastLineIndividual" , Order = 15 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residentlastlineindividual
      {
         get {
            return sdt.gxTpr_Residentlastlineindividual ;
         }

         set {
            sdt.gxTpr_Residentlastlineindividual = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ResidentLastLineCompany" , Order = 16 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Residentlastlinecompany
      {
         get {
            return sdt.gxTpr_Residentlastlinecompany ;
         }

         set {
            sdt.gxTpr_Residentlastlinecompany = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "INIndividual" , Order = 17 )]
      public GxGenericCollection<SdtResident_INIndividual_RESTInterface> gxTpr_Inindividual
      {
         get {
            return new GxGenericCollection<SdtResident_INIndividual_RESTInterface>(sdt.gxTpr_Inindividual) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Inindividual);
         }

      }

      [DataMember( Name = "INCompany" , Order = 18 )]
      public GxGenericCollection<SdtResident_INCompany_RESTInterface> gxTpr_Incompany
      {
         get {
            return new GxGenericCollection<SdtResident_INCompany_RESTInterface>(sdt.gxTpr_Incompany) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Incompany);
         }

      }

      [DataMember( Name = "ProductService" , Order = 19 )]
      public GxGenericCollection<SdtResident_ProductService_RESTInterface> gxTpr_Productservice
      {
         get {
            return new GxGenericCollection<SdtResident_ProductService_RESTInterface>(sdt.gxTpr_Productservice) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Productservice);
         }

      }

      public SdtResident sdt
      {
         get {
            return (SdtResident)Sdt ;
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
            sdt = new SdtResident() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 20 )]
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

   [DataContract(Name = @"Resident", Namespace = "Comforta2")]
   [GxJsonSerialization("default")]
   public class SdtResident_RESTLInterface : GxGenericCollectionItem<SdtResident>
   {
      public SdtResident_RESTLInterface( ) : base()
      {
      }

      public SdtResident_RESTLInterface( SdtResident psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ResidentBsnNumber" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Residentbsnnumber
      {
         get {
            return sdt.gxTpr_Residentbsnnumber ;
         }

         set {
            sdt.gxTpr_Residentbsnnumber = value;
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

      public SdtResident sdt
      {
         get {
            return (SdtResident)Sdt ;
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
            sdt = new SdtResident() ;
         }
      }

   }

}
