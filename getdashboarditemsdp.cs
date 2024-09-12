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
   public class getdashboarditemsdp : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public getdashboarditemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getdashboarditemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Comforta2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Locations";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-map-marker-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("customerlocations.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Customer Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "d085396f-788e-4174-bb1c-d2d0832ea599", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Customer Locations.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Receptionists";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-address-card";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("locationreceptionists.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Customer Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "8b339ea3-0806-4fdc-b87f-6f4b66cf669e", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Receptionisits/Location Managers";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Customers";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-people-roof";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("customerww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Customers";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Customer Types";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-gear";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("customertypeww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Customer Types";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Resident Types";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-gear";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("residenttypeww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Resident Types";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Product Types";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-gear";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("productservicetypeww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Manager";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Service Types";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Suppliers (Medical)";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-ambulance";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("locationagbsuppliers.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Suppliers (AGB)";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Suppliers (General)";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-shipping-fast";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("locationgensuppliers.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Suppliers (Generic)";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Products & Services";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fab fa-product-hunt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("productserviceww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Products and Services";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Residents";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-users";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("locationresidents.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Residents";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Agenda";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-calendar-days";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("agendacalendar.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Agenda";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Customization";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-eye-dropper";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Customer Manager";
         GXt_char1 = "";
         new getcustomercustomizationtrnmode(context ).execute( ref  GXt_char1) ;
         GXt_int2 = 0;
         new getcustomercustomizationid(context ).execute( out  GXt_int2) ;
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("customercustomization.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(GXt_char1)),GXUtil.UrlEncode(StringUtil.LTrimStr(GXt_int2,4,0))}, new string[] {"Mode","CustomerCustomizationId"}) ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Customization";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Amenities";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-tv";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("locationamenities.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "a245472c-9d22-48bd-b724-960d555d3688", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Amenities";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Page Templates";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Comforta Manager";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("pagetemplateww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Page Templates";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Application Design";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-mobile-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Rolename = "Receptionist";
         Gxm1homemodulessdt.gxTpr_Optionwclink = formatLink("pageww.aspx") ;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Application Design";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Contacts";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-phone-square";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Rolename = "All";
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Financial Partners";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-file-invoice-dollar";
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Financial Partners";
         Gxm1homemodulessdt.gxTpr_Rolename = "Customer Manager";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Payments";
         Gxm1homemodulessdt.gxTpr_Optiontype = 3;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 65;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Feedback";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-comments";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Mailbox";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-envelope";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Chat";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fab fa-whatsapp";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "My Profile";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-user-circle";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
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
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private string GXt_char1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem Gxm1homemodulessdt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol ;
   }

}
