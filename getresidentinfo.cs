using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class getresidentinfo : GXProcedure
   {
      public getresidentinfo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getresidentinfo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_userId ,
                           out SdtResidentDetails aP1_ResidentDetails )
      {
         this.AV9userId = aP0_userId;
         this.AV10ResidentDetails = new SdtResidentDetails(context) ;
         initialize();
         ExecuteImpl();
         aP1_ResidentDetails=this.AV10ResidentDetails;
      }

      public SdtResidentDetails executeUdp( string aP0_userId )
      {
         execute(aP0_userId, out aP1_ResidentDetails);
         return AV10ResidentDetails ;
      }

      public void executeSubmit( string aP0_userId ,
                                 out SdtResidentDetails aP1_ResidentDetails )
      {
         this.AV9userId = aP0_userId;
         this.AV10ResidentDetails = new SdtResidentDetails(context) ;
         SubmitImpl();
         aP1_ResidentDetails=this.AV10ResidentDetails;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P002R2 */
         pr_default.execute(0, new Object[] {AV9userId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A31ResidentId = P002R2_A31ResidentId[0];
            A39ResidentGAMGUID = P002R2_A39ResidentGAMGUID[0];
            A33ResidentGivenName = P002R2_A33ResidentGivenName[0];
            A34ResidentLastName = P002R2_A34ResidentLastName[0];
            A36ResidentEmail = P002R2_A36ResidentEmail[0];
            A37ResidentAddress = P002R2_A37ResidentAddress[0];
            n37ResidentAddress = P002R2_n37ResidentAddress[0];
            A38ResidentPhone = P002R2_A38ResidentPhone[0];
            n38ResidentPhone = P002R2_n38ResidentPhone[0];
            A35ResidentInitials = P002R2_A35ResidentInitials[0];
            n35ResidentInitials = P002R2_n35ResidentInitials[0];
            A40ResidentBsnNumber = P002R2_A40ResidentBsnNumber[0];
            A82ResidentTypeId = P002R2_A82ResidentTypeId[0];
            A83ResidentTypeName = P002R2_A83ResidentTypeName[0];
            A1CustomerId = P002R2_A1CustomerId[0];
            A18CustomerLocationId = P002R2_A18CustomerLocationId[0];
            A83ResidentTypeName = P002R2_A83ResidentTypeName[0];
            AV10ResidentDetails.gxTpr_Residentid = A39ResidentGAMGUID;
            AV10ResidentDetails.gxTpr_Residentgivenname = A33ResidentGivenName;
            AV10ResidentDetails.gxTpr_Residentlastname = A34ResidentLastName;
            AV10ResidentDetails.gxTpr_Residentemail = A36ResidentEmail;
            AV10ResidentDetails.gxTpr_Residentaddress = A37ResidentAddress;
            AV10ResidentDetails.gxTpr_Residentphone = A38ResidentPhone;
            AV10ResidentDetails.gxTpr_Residentinitials = A35ResidentInitials;
            AV10ResidentDetails.gxTpr_Residentbsnnumber = A40ResidentBsnNumber;
            AV10ResidentDetails.gxTpr_Residenttypeid = A82ResidentTypeId;
            AV10ResidentDetails.gxTpr_Residenttypename = A83ResidentTypeName;
            AV14CustomerId = A1CustomerId;
            AV15LocationId = A18CustomerLocationId;
            /* Using cursor P002R3 */
            pr_default.execute(1, new Object[] {A31ResidentId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A43ResidentINIndividualBsnNumber = P002R3_A43ResidentINIndividualBsnNumber[0];
               A44ResidentINIndividualGivenName = P002R3_A44ResidentINIndividualGivenName[0];
               A45ResidentINIndividualLastName = P002R3_A45ResidentINIndividualLastName[0];
               A49ResidentINIndividualGender = P002R3_A49ResidentINIndividualGender[0];
               A46ResidentINIndividualEmail = P002R3_A46ResidentINIndividualEmail[0];
               n46ResidentINIndividualEmail = P002R3_n46ResidentINIndividualEmail[0];
               A47ResidentINIndividualPhone = P002R3_A47ResidentINIndividualPhone[0];
               n47ResidentINIndividualPhone = P002R3_n47ResidentINIndividualPhone[0];
               A48ResidentINIndividualAddress = P002R3_A48ResidentINIndividualAddress[0];
               n48ResidentINIndividualAddress = P002R3_n48ResidentINIndividualAddress[0];
               A42ResidentINIndividualId = P002R3_A42ResidentINIndividualId[0];
               AV11ResidentNetworkIndividual = new SdtResidentDetails_ResidentNetworkIndividualsItem(context);
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualbsnnumber = A43ResidentINIndividualBsnNumber;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualgivenname = A44ResidentINIndividualGivenName;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividuallastname = A45ResidentINIndividualLastName;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualgender = A49ResidentINIndividualGender;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualemail = A46ResidentINIndividualEmail;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualphone = A47ResidentINIndividualPhone;
               AV11ResidentNetworkIndividual.gxTpr_Residentinindividualaddress = A48ResidentINIndividualAddress;
               AV10ResidentDetails.gxTpr_Residentnetworkindividuals.Add(AV11ResidentNetworkIndividual, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P002R4 */
            pr_default.execute(2, new Object[] {A31ResidentId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A51ResidentINCompanyKvkNumber = P002R4_A51ResidentINCompanyKvkNumber[0];
               A52ResidentINCompanyName = P002R4_A52ResidentINCompanyName[0];
               A53ResidentINCompanyEmail = P002R4_A53ResidentINCompanyEmail[0];
               n53ResidentINCompanyEmail = P002R4_n53ResidentINCompanyEmail[0];
               A54ResidentINCompanyPhone = P002R4_A54ResidentINCompanyPhone[0];
               n54ResidentINCompanyPhone = P002R4_n54ResidentINCompanyPhone[0];
               A50ResidentINCompanyId = P002R4_A50ResidentINCompanyId[0];
               AV12ResidentNetworkCompany = new SdtResidentDetails_ResidentNetworkCompaniesItem(context);
               AV12ResidentNetworkCompany.gxTpr_Residentincompanykvknumber = A51ResidentINCompanyKvkNumber;
               AV12ResidentNetworkCompany.gxTpr_Residentincompanyname = A52ResidentINCompanyName;
               AV12ResidentNetworkCompany.gxTpr_Residentincompanyemail = A53ResidentINCompanyEmail;
               AV12ResidentNetworkCompany.gxTpr_Residentincompanyphone = A54ResidentINCompanyPhone;
               AV10ResidentDetails.gxTpr_Residentnetworkcompanies.Add(AV12ResidentNetworkCompany, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Using cursor P002R5 */
            pr_default.execute(3, new Object[] {A31ResidentId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A73ProductServiceId = P002R5_A73ProductServiceId[0];
               A40000ProductServicePicture_GXI = P002R5_A40000ProductServicePicture_GXI[0];
               A74ProductServiceName = P002R5_A74ProductServiceName[0];
               A75ProductServiceDescription = P002R5_A75ProductServiceDescription[0];
               A76ProductServiceQuantity = P002R5_A76ProductServiceQuantity[0];
               A71ProductServiceTypeId = P002R5_A71ProductServiceTypeId[0];
               A72ProductServiceTypeName = P002R5_A72ProductServiceTypeName[0];
               A77ProductServicePicture = P002R5_A77ProductServicePicture[0];
               A40000ProductServicePicture_GXI = P002R5_A40000ProductServicePicture_GXI[0];
               A74ProductServiceName = P002R5_A74ProductServiceName[0];
               A75ProductServiceDescription = P002R5_A75ProductServiceDescription[0];
               A76ProductServiceQuantity = P002R5_A76ProductServiceQuantity[0];
               A71ProductServiceTypeId = P002R5_A71ProductServiceTypeId[0];
               A77ProductServicePicture = P002R5_A77ProductServicePicture[0];
               A72ProductServiceTypeName = P002R5_A72ProductServiceTypeName[0];
               AV13ResidentService = new SdtResidentDetails_ResidentServicesAndProductsItem(context);
               AV13ResidentService.gxTpr_Productservicename = A74ProductServiceName;
               AV13ResidentService.gxTpr_Productservicedescription = A75ProductServiceDescription;
               AV13ResidentService.gxTpr_Productservicequantity = A76ProductServiceQuantity;
               AV13ResidentService.gxTpr_Productservicepicture = A77ProductServicePicture;
               AV13ResidentService.gxTpr_Productservicepicture_gxi = A40000ProductServicePicture_GXI;
               AV13ResidentService.gxTpr_Productservicetypeid = A71ProductServiceTypeId;
               AV13ResidentService.gxTpr_Productservicetypename = A72ProductServiceTypeName;
               AV10ResidentDetails.gxTpr_Residentservicesandproducts.Add(AV13ResidentService, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P002R6 */
         pr_default.execute(4, new Object[] {AV14CustomerId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A1CustomerId = P002R6_A1CustomerId[0];
            A41CustomerKvkNumber = P002R6_A41CustomerKvkNumber[0];
            A3CustomerName = P002R6_A3CustomerName[0];
            A5CustomerEmail = P002R6_A5CustomerEmail[0];
            n5CustomerEmail = P002R6_n5CustomerEmail[0];
            A7CustomerPhone = P002R6_A7CustomerPhone[0];
            n7CustomerPhone = P002R6_n7CustomerPhone[0];
            A4CustomerPostalAddress = P002R6_A4CustomerPostalAddress[0];
            n4CustomerPostalAddress = P002R6_n4CustomerPostalAddress[0];
            A6CustomerVisitingAddress = P002R6_A6CustomerVisitingAddress[0];
            n6CustomerVisitingAddress = P002R6_n6CustomerVisitingAddress[0];
            A14CustomerVatNumber = P002R6_A14CustomerVatNumber[0];
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customerkvknumber = A41CustomerKvkNumber;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customername = A3CustomerName;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customeremail = A5CustomerEmail;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customerphone = A7CustomerPhone;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customerpostaladdress = A4CustomerPostalAddress;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customervisitingaddress = A6CustomerVisitingAddress;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Customervatnumber = A14CustomerVatNumber;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         /* Using cursor P002R7 */
         pr_default.execute(5, new Object[] {AV14CustomerId, AV15LocationId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A18CustomerLocationId = P002R7_A18CustomerLocationId[0];
            A1CustomerId = P002R7_A1CustomerId[0];
            A21CustomerLocationEmail = P002R7_A21CustomerLocationEmail[0];
            A22CustomerLocationPhone = P002R7_A22CustomerLocationPhone[0];
            A20CustomerLocationPostalAddress = P002R7_A20CustomerLocationPostalAddress[0];
            A134CustomerLocationName = P002R7_A134CustomerLocationName[0];
            A133CustomerLocationDescription = P002R7_A133CustomerLocationDescription[0];
            A19CustomerLocationVisitingAddres = P002R7_A19CustomerLocationVisitingAddres[0];
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationid = A18CustomerLocationId;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationemail = A21CustomerLocationEmail;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationphone = A22CustomerLocationPhone;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationpostaladdress = A20CustomerLocationPostalAddress;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationname = A134CustomerLocationName;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationdescription = A133CustomerLocationDescription;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Customerlocationvisitingaddress = A19CustomerLocationVisitingAddres;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         /* Using cursor P002R8 */
         pr_default.execute(6, new Object[] {AV14CustomerId, AV15LocationId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A98AmenitiesId = P002R8_A98AmenitiesId[0];
            A18CustomerLocationId = P002R8_A18CustomerLocationId[0];
            A1CustomerId = P002R8_A1CustomerId[0];
            A101AmenitiesName = P002R8_A101AmenitiesName[0];
            A101AmenitiesName = P002R8_A101AmenitiesName[0];
            AV18LocationAmenity = new SdtResidentDetails_Customer_Location_AmenitiesItem(context);
            if ( StringUtil.StrCmp(A101AmenitiesName, "The Restaurant") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "Restaurant";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Activity Center") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "ActivityCenter";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Laundrette") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "Laundrette";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Business Centre") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "BusinessCentre";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Crafts Workshop") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "CraftsWorkshop";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Social Lounge") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "SocialLounge";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Car Parking") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "CarParking";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Terras") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "Terras";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Park and Recreation") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "ParkAndRecreation";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "e-Bike Charging points") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "Ebike";
            }
            else if ( StringUtil.StrCmp(A101AmenitiesName, "Vegetable Garden") == 0 )
            {
               AV18LocationAmenity.gxTpr_Amenityid = "VegetableGarden";
            }
            else
            {
               AV18LocationAmenity.gxTpr_Amenityid = "";
            }
            AV18LocationAmenity.gxTpr_Amenityname = A101AmenitiesName;
            AV18LocationAmenity.gxTpr_Isavailable = true;
            AV10ResidentDetails.gxTpr_Customer.gxTpr_Location.gxTpr_Amenities.Add(AV18LocationAmenity, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10ResidentDetails = new SdtResidentDetails(context);
         P002R2_A31ResidentId = new short[1] ;
         P002R2_A39ResidentGAMGUID = new string[] {""} ;
         P002R2_A33ResidentGivenName = new string[] {""} ;
         P002R2_A34ResidentLastName = new string[] {""} ;
         P002R2_A36ResidentEmail = new string[] {""} ;
         P002R2_A37ResidentAddress = new string[] {""} ;
         P002R2_n37ResidentAddress = new bool[] {false} ;
         P002R2_A38ResidentPhone = new string[] {""} ;
         P002R2_n38ResidentPhone = new bool[] {false} ;
         P002R2_A35ResidentInitials = new string[] {""} ;
         P002R2_n35ResidentInitials = new bool[] {false} ;
         P002R2_A40ResidentBsnNumber = new string[] {""} ;
         P002R2_A82ResidentTypeId = new short[1] ;
         P002R2_A83ResidentTypeName = new string[] {""} ;
         P002R2_A1CustomerId = new short[1] ;
         P002R2_A18CustomerLocationId = new short[1] ;
         A39ResidentGAMGUID = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         A36ResidentEmail = "";
         A37ResidentAddress = "";
         A38ResidentPhone = "";
         A35ResidentInitials = "";
         A40ResidentBsnNumber = "";
         A83ResidentTypeName = "";
         P002R3_A31ResidentId = new short[1] ;
         P002R3_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         P002R3_A44ResidentINIndividualGivenName = new string[] {""} ;
         P002R3_A45ResidentINIndividualLastName = new string[] {""} ;
         P002R3_A49ResidentINIndividualGender = new string[] {""} ;
         P002R3_A46ResidentINIndividualEmail = new string[] {""} ;
         P002R3_n46ResidentINIndividualEmail = new bool[] {false} ;
         P002R3_A47ResidentINIndividualPhone = new string[] {""} ;
         P002R3_n47ResidentINIndividualPhone = new bool[] {false} ;
         P002R3_A48ResidentINIndividualAddress = new string[] {""} ;
         P002R3_n48ResidentINIndividualAddress = new bool[] {false} ;
         P002R3_A42ResidentINIndividualId = new short[1] ;
         A43ResidentINIndividualBsnNumber = "";
         A44ResidentINIndividualGivenName = "";
         A45ResidentINIndividualLastName = "";
         A49ResidentINIndividualGender = "";
         A46ResidentINIndividualEmail = "";
         A47ResidentINIndividualPhone = "";
         A48ResidentINIndividualAddress = "";
         AV11ResidentNetworkIndividual = new SdtResidentDetails_ResidentNetworkIndividualsItem(context);
         P002R4_A31ResidentId = new short[1] ;
         P002R4_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         P002R4_A52ResidentINCompanyName = new string[] {""} ;
         P002R4_A53ResidentINCompanyEmail = new string[] {""} ;
         P002R4_n53ResidentINCompanyEmail = new bool[] {false} ;
         P002R4_A54ResidentINCompanyPhone = new string[] {""} ;
         P002R4_n54ResidentINCompanyPhone = new bool[] {false} ;
         P002R4_A50ResidentINCompanyId = new short[1] ;
         A51ResidentINCompanyKvkNumber = "";
         A52ResidentINCompanyName = "";
         A53ResidentINCompanyEmail = "";
         A54ResidentINCompanyPhone = "";
         AV12ResidentNetworkCompany = new SdtResidentDetails_ResidentNetworkCompaniesItem(context);
         P002R5_A73ProductServiceId = new short[1] ;
         P002R5_A31ResidentId = new short[1] ;
         P002R5_A40000ProductServicePicture_GXI = new string[] {""} ;
         P002R5_A74ProductServiceName = new string[] {""} ;
         P002R5_A75ProductServiceDescription = new string[] {""} ;
         P002R5_A76ProductServiceQuantity = new short[1] ;
         P002R5_A71ProductServiceTypeId = new short[1] ;
         P002R5_A72ProductServiceTypeName = new string[] {""} ;
         P002R5_A77ProductServicePicture = new string[] {""} ;
         A40000ProductServicePicture_GXI = "";
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         A72ProductServiceTypeName = "";
         A77ProductServicePicture = "";
         AV13ResidentService = new SdtResidentDetails_ResidentServicesAndProductsItem(context);
         P002R6_A1CustomerId = new short[1] ;
         P002R6_A41CustomerKvkNumber = new string[] {""} ;
         P002R6_A3CustomerName = new string[] {""} ;
         P002R6_A5CustomerEmail = new string[] {""} ;
         P002R6_n5CustomerEmail = new bool[] {false} ;
         P002R6_A7CustomerPhone = new string[] {""} ;
         P002R6_n7CustomerPhone = new bool[] {false} ;
         P002R6_A4CustomerPostalAddress = new string[] {""} ;
         P002R6_n4CustomerPostalAddress = new bool[] {false} ;
         P002R6_A6CustomerVisitingAddress = new string[] {""} ;
         P002R6_n6CustomerVisitingAddress = new bool[] {false} ;
         P002R6_A14CustomerVatNumber = new string[] {""} ;
         A41CustomerKvkNumber = "";
         A3CustomerName = "";
         A5CustomerEmail = "";
         A7CustomerPhone = "";
         A4CustomerPostalAddress = "";
         A6CustomerVisitingAddress = "";
         A14CustomerVatNumber = "";
         P002R7_A18CustomerLocationId = new short[1] ;
         P002R7_A1CustomerId = new short[1] ;
         P002R7_A21CustomerLocationEmail = new string[] {""} ;
         P002R7_A22CustomerLocationPhone = new string[] {""} ;
         P002R7_A20CustomerLocationPostalAddress = new string[] {""} ;
         P002R7_A134CustomerLocationName = new string[] {""} ;
         P002R7_A133CustomerLocationDescription = new string[] {""} ;
         P002R7_A19CustomerLocationVisitingAddres = new string[] {""} ;
         A21CustomerLocationEmail = "";
         A22CustomerLocationPhone = "";
         A20CustomerLocationPostalAddress = "";
         A134CustomerLocationName = "";
         A133CustomerLocationDescription = "";
         A19CustomerLocationVisitingAddres = "";
         P002R8_A98AmenitiesId = new short[1] ;
         P002R8_A18CustomerLocationId = new short[1] ;
         P002R8_A1CustomerId = new short[1] ;
         P002R8_A101AmenitiesName = new string[] {""} ;
         A101AmenitiesName = "";
         AV18LocationAmenity = new SdtResidentDetails_Customer_Location_AmenitiesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getresidentinfo__default(),
            new Object[][] {
                new Object[] {
               P002R2_A31ResidentId, P002R2_A39ResidentGAMGUID, P002R2_A33ResidentGivenName, P002R2_A34ResidentLastName, P002R2_A36ResidentEmail, P002R2_A37ResidentAddress, P002R2_n37ResidentAddress, P002R2_A38ResidentPhone, P002R2_n38ResidentPhone, P002R2_A35ResidentInitials,
               P002R2_n35ResidentInitials, P002R2_A40ResidentBsnNumber, P002R2_A82ResidentTypeId, P002R2_A83ResidentTypeName, P002R2_A1CustomerId, P002R2_A18CustomerLocationId
               }
               , new Object[] {
               P002R3_A31ResidentId, P002R3_A43ResidentINIndividualBsnNumber, P002R3_A44ResidentINIndividualGivenName, P002R3_A45ResidentINIndividualLastName, P002R3_A49ResidentINIndividualGender, P002R3_A46ResidentINIndividualEmail, P002R3_n46ResidentINIndividualEmail, P002R3_A47ResidentINIndividualPhone, P002R3_n47ResidentINIndividualPhone, P002R3_A48ResidentINIndividualAddress,
               P002R3_n48ResidentINIndividualAddress, P002R3_A42ResidentINIndividualId
               }
               , new Object[] {
               P002R4_A31ResidentId, P002R4_A51ResidentINCompanyKvkNumber, P002R4_A52ResidentINCompanyName, P002R4_A53ResidentINCompanyEmail, P002R4_n53ResidentINCompanyEmail, P002R4_A54ResidentINCompanyPhone, P002R4_n54ResidentINCompanyPhone, P002R4_A50ResidentINCompanyId
               }
               , new Object[] {
               P002R5_A73ProductServiceId, P002R5_A31ResidentId, P002R5_A40000ProductServicePicture_GXI, P002R5_A74ProductServiceName, P002R5_A75ProductServiceDescription, P002R5_A76ProductServiceQuantity, P002R5_A71ProductServiceTypeId, P002R5_A72ProductServiceTypeName, P002R5_A77ProductServicePicture
               }
               , new Object[] {
               P002R6_A1CustomerId, P002R6_A41CustomerKvkNumber, P002R6_A3CustomerName, P002R6_A5CustomerEmail, P002R6_n5CustomerEmail, P002R6_A7CustomerPhone, P002R6_n7CustomerPhone, P002R6_A4CustomerPostalAddress, P002R6_n4CustomerPostalAddress, P002R6_A6CustomerVisitingAddress,
               P002R6_n6CustomerVisitingAddress, P002R6_A14CustomerVatNumber
               }
               , new Object[] {
               P002R7_A18CustomerLocationId, P002R7_A1CustomerId, P002R7_A21CustomerLocationEmail, P002R7_A22CustomerLocationPhone, P002R7_A20CustomerLocationPostalAddress, P002R7_A134CustomerLocationName, P002R7_A133CustomerLocationDescription, P002R7_A19CustomerLocationVisitingAddres
               }
               , new Object[] {
               P002R8_A98AmenitiesId, P002R8_A18CustomerLocationId, P002R8_A1CustomerId, P002R8_A101AmenitiesName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A31ResidentId ;
      private short A82ResidentTypeId ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
      private short AV14CustomerId ;
      private short AV15LocationId ;
      private short A42ResidentINIndividualId ;
      private short A50ResidentINCompanyId ;
      private short A73ProductServiceId ;
      private short A76ProductServiceQuantity ;
      private short A71ProductServiceTypeId ;
      private short A98AmenitiesId ;
      private string A38ResidentPhone ;
      private string A35ResidentInitials ;
      private string A49ResidentINIndividualGender ;
      private string A47ResidentINIndividualPhone ;
      private string A54ResidentINCompanyPhone ;
      private string A7CustomerPhone ;
      private string A22CustomerLocationPhone ;
      private bool n37ResidentAddress ;
      private bool n38ResidentPhone ;
      private bool n35ResidentInitials ;
      private bool n46ResidentINIndividualEmail ;
      private bool n47ResidentINIndividualPhone ;
      private bool n48ResidentINIndividualAddress ;
      private bool n53ResidentINCompanyEmail ;
      private bool n54ResidentINCompanyPhone ;
      private bool n5CustomerEmail ;
      private bool n7CustomerPhone ;
      private bool n4CustomerPostalAddress ;
      private bool n6CustomerVisitingAddress ;
      private string AV9userId ;
      private string A39ResidentGAMGUID ;
      private string A33ResidentGivenName ;
      private string A34ResidentLastName ;
      private string A36ResidentEmail ;
      private string A37ResidentAddress ;
      private string A40ResidentBsnNumber ;
      private string A83ResidentTypeName ;
      private string A43ResidentINIndividualBsnNumber ;
      private string A44ResidentINIndividualGivenName ;
      private string A45ResidentINIndividualLastName ;
      private string A46ResidentINIndividualEmail ;
      private string A48ResidentINIndividualAddress ;
      private string A51ResidentINCompanyKvkNumber ;
      private string A52ResidentINCompanyName ;
      private string A53ResidentINCompanyEmail ;
      private string A40000ProductServicePicture_GXI ;
      private string A74ProductServiceName ;
      private string A75ProductServiceDescription ;
      private string A72ProductServiceTypeName ;
      private string A41CustomerKvkNumber ;
      private string A3CustomerName ;
      private string A5CustomerEmail ;
      private string A4CustomerPostalAddress ;
      private string A6CustomerVisitingAddress ;
      private string A14CustomerVatNumber ;
      private string A21CustomerLocationEmail ;
      private string A20CustomerLocationPostalAddress ;
      private string A134CustomerLocationName ;
      private string A133CustomerLocationDescription ;
      private string A19CustomerLocationVisitingAddres ;
      private string A101AmenitiesName ;
      private string A77ProductServicePicture ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtResidentDetails AV10ResidentDetails ;
      private IDataStoreProvider pr_default ;
      private short[] P002R2_A31ResidentId ;
      private string[] P002R2_A39ResidentGAMGUID ;
      private string[] P002R2_A33ResidentGivenName ;
      private string[] P002R2_A34ResidentLastName ;
      private string[] P002R2_A36ResidentEmail ;
      private string[] P002R2_A37ResidentAddress ;
      private bool[] P002R2_n37ResidentAddress ;
      private string[] P002R2_A38ResidentPhone ;
      private bool[] P002R2_n38ResidentPhone ;
      private string[] P002R2_A35ResidentInitials ;
      private bool[] P002R2_n35ResidentInitials ;
      private string[] P002R2_A40ResidentBsnNumber ;
      private short[] P002R2_A82ResidentTypeId ;
      private string[] P002R2_A83ResidentTypeName ;
      private short[] P002R2_A1CustomerId ;
      private short[] P002R2_A18CustomerLocationId ;
      private short[] P002R3_A31ResidentId ;
      private string[] P002R3_A43ResidentINIndividualBsnNumber ;
      private string[] P002R3_A44ResidentINIndividualGivenName ;
      private string[] P002R3_A45ResidentINIndividualLastName ;
      private string[] P002R3_A49ResidentINIndividualGender ;
      private string[] P002R3_A46ResidentINIndividualEmail ;
      private bool[] P002R3_n46ResidentINIndividualEmail ;
      private string[] P002R3_A47ResidentINIndividualPhone ;
      private bool[] P002R3_n47ResidentINIndividualPhone ;
      private string[] P002R3_A48ResidentINIndividualAddress ;
      private bool[] P002R3_n48ResidentINIndividualAddress ;
      private short[] P002R3_A42ResidentINIndividualId ;
      private SdtResidentDetails_ResidentNetworkIndividualsItem AV11ResidentNetworkIndividual ;
      private short[] P002R4_A31ResidentId ;
      private string[] P002R4_A51ResidentINCompanyKvkNumber ;
      private string[] P002R4_A52ResidentINCompanyName ;
      private string[] P002R4_A53ResidentINCompanyEmail ;
      private bool[] P002R4_n53ResidentINCompanyEmail ;
      private string[] P002R4_A54ResidentINCompanyPhone ;
      private bool[] P002R4_n54ResidentINCompanyPhone ;
      private short[] P002R4_A50ResidentINCompanyId ;
      private SdtResidentDetails_ResidentNetworkCompaniesItem AV12ResidentNetworkCompany ;
      private short[] P002R5_A73ProductServiceId ;
      private short[] P002R5_A31ResidentId ;
      private string[] P002R5_A40000ProductServicePicture_GXI ;
      private string[] P002R5_A74ProductServiceName ;
      private string[] P002R5_A75ProductServiceDescription ;
      private short[] P002R5_A76ProductServiceQuantity ;
      private short[] P002R5_A71ProductServiceTypeId ;
      private string[] P002R5_A72ProductServiceTypeName ;
      private string[] P002R5_A77ProductServicePicture ;
      private SdtResidentDetails_ResidentServicesAndProductsItem AV13ResidentService ;
      private short[] P002R6_A1CustomerId ;
      private string[] P002R6_A41CustomerKvkNumber ;
      private string[] P002R6_A3CustomerName ;
      private string[] P002R6_A5CustomerEmail ;
      private bool[] P002R6_n5CustomerEmail ;
      private string[] P002R6_A7CustomerPhone ;
      private bool[] P002R6_n7CustomerPhone ;
      private string[] P002R6_A4CustomerPostalAddress ;
      private bool[] P002R6_n4CustomerPostalAddress ;
      private string[] P002R6_A6CustomerVisitingAddress ;
      private bool[] P002R6_n6CustomerVisitingAddress ;
      private string[] P002R6_A14CustomerVatNumber ;
      private short[] P002R7_A18CustomerLocationId ;
      private short[] P002R7_A1CustomerId ;
      private string[] P002R7_A21CustomerLocationEmail ;
      private string[] P002R7_A22CustomerLocationPhone ;
      private string[] P002R7_A20CustomerLocationPostalAddress ;
      private string[] P002R7_A134CustomerLocationName ;
      private string[] P002R7_A133CustomerLocationDescription ;
      private string[] P002R7_A19CustomerLocationVisitingAddres ;
      private short[] P002R8_A98AmenitiesId ;
      private short[] P002R8_A18CustomerLocationId ;
      private short[] P002R8_A1CustomerId ;
      private string[] P002R8_A101AmenitiesName ;
      private SdtResidentDetails_Customer_Location_AmenitiesItem AV18LocationAmenity ;
      private SdtResidentDetails aP1_ResidentDetails ;
   }

   public class getresidentinfo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002R2;
          prmP002R2 = new Object[] {
          new ParDef("AV9userId",GXType.VarChar,40,0)
          };
          Object[] prmP002R3;
          prmP002R3 = new Object[] {
          new ParDef("ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002R4;
          prmP002R4 = new Object[] {
          new ParDef("ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002R5;
          prmP002R5 = new Object[] {
          new ParDef("ResidentId",GXType.Int16,4,0)
          };
          Object[] prmP002R6;
          prmP002R6 = new Object[] {
          new ParDef("AV14CustomerId",GXType.Int16,4,0)
          };
          Object[] prmP002R7;
          prmP002R7 = new Object[] {
          new ParDef("AV14CustomerId",GXType.Int16,4,0) ,
          new ParDef("AV15LocationId",GXType.Int16,4,0)
          };
          Object[] prmP002R8;
          prmP002R8 = new Object[] {
          new ParDef("AV14CustomerId",GXType.Int16,4,0) ,
          new ParDef("AV15LocationId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002R2", "SELECT T1.ResidentId, T1.ResidentGAMGUID, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentEmail, T1.ResidentAddress, T1.ResidentPhone, T1.ResidentInitials, T1.ResidentBsnNumber, T1.ResidentTypeId, T2.ResidentTypeName, T1.CustomerId, T1.CustomerLocationId FROM (Resident T1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) WHERE T1.ResidentGAMGUID = ( :AV9userId) ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002R3", "SELECT ResidentId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualGender, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualId FROM ResidentINIndividual WHERE ResidentId = :ResidentId ORDER BY ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002R4", "SELECT ResidentId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone, ResidentINCompanyId FROM ResidentINCompany WHERE ResidentId = :ResidentId ORDER BY ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002R5", "SELECT T1.ProductServiceId, T1.ResidentId, T2.ProductServicePicture_GXI, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServiceTypeId, T3.ProductServiceTypeName, T2.ProductServicePicture FROM ((ResidentProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.ResidentId = :ResidentId ORDER BY T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002R6", "SELECT CustomerId, CustomerKvkNumber, CustomerName, CustomerEmail, CustomerPhone, CustomerPostalAddress, CustomerVisitingAddress, CustomerVatNumber FROM Customer WHERE CustomerId = :AV14CustomerId ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002R7", "SELECT CustomerLocationId, CustomerId, CustomerLocationEmail, CustomerLocationPhone, CustomerLocationPostalAddress, CustomerLocationName, CustomerLocationDescription, CustomerLocationVisitingAddres FROM CustomerLocation WHERE CustomerId = :AV14CustomerId and CustomerLocationId = :AV15LocationId ORDER BY CustomerId, CustomerLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002R8", "SELECT T1.AmenitiesId, T1.CustomerLocationId, T1.CustomerId, T2.AmenitiesName FROM (CustomerLocationsAmenities T1 INNER JOIN Amenities T2 ON T2.AmenitiesId = T1.AmenitiesId) WHERE T1.CustomerId = :AV14CustomerId and T1.CustomerLocationId = :AV15LocationId ORDER BY T1.CustomerId, T1.CustomerLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R8,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((short[]) buf[12])[0] = rslt.getShort(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((short[]) buf[14])[0] = rslt.getShort(12);
                ((short[]) buf[15])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
