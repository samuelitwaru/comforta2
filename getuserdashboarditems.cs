using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class getuserdashboarditems : GXProcedure
   {
      public getuserdashboarditems( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getuserdashboarditems( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems )
      {
         this.AV12FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2") ;
         initialize();
         ExecuteImpl();
         aP0_FilteredDashboardItems=this.AV12FilteredDashboardItems;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_FilteredDashboardItems);
         return AV12FilteredDashboardItems ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems )
      {
         this.AV12FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2") ;
         SubmitImpl();
         aP0_FilteredDashboardItems=this.AV12FilteredDashboardItems;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtGAMUser1 = AV8GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV8GAMUser = GXt_SdtGAMUser1;
         if ( AV8GAMUser.checkrole("Receptionist") )
         {
            AV11UserRoleName = "Receptionist";
         }
         else if ( AV8GAMUser.checkrole("Customer Manager") )
         {
            AV11UserRoleName = "Customer Manager";
         }
         else if ( AV8GAMUser.checkrole("Comforta Manager") )
         {
            AV11UserRoleName = "Comforta Manager";
         }
         else
         {
            AV11UserRoleName = "Resident";
         }
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 = AV10DashboardItems;
         new getdashboarditemsdp(context ).execute( out  GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2) ;
         AV10DashboardItems = GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2;
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV10DashboardItems.Count )
         {
            AV9DashboardItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV10DashboardItems.Item(AV13GXV1));
            if ( StringUtil.StrCmp(AV11UserRoleName, AV9DashboardItem.gxTpr_Rolename) == 0 )
            {
               AV12FilteredDashboardItems.Add(AV9DashboardItem, 0);
            }
            else
            {
               if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DashboardItem.gxTpr_Rolename)) || ( StringUtil.StrCmp(AV9DashboardItem.gxTpr_Rolename, "All") == 0 ) ) && ( StringUtil.StrCmp(AV11UserRoleName, "Comforta Manager") != 0 ) )
               {
                  AV12FilteredDashboardItems.Add(AV9DashboardItem, 0);
               }
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
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
         AV12FilteredDashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2");
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11UserRoleName = "";
         AV10DashboardItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2");
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2");
         AV9DashboardItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private string AV11UserRoleName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV12FilteredDashboardItems ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV10DashboardItems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV9DashboardItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_FilteredDashboardItems ;
   }

}
