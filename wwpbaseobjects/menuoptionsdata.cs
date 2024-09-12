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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuoptionsdata : GXProcedure
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public menuoptionsdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public menuoptionsdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Comforta2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Comforta2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("home.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = "Dashboard";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("agendacalendar.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-calendar-days";
         Gxm1dvelop_menu.gxTpr_Caption = "Agenda";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("customerww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-people-roof";
         Gxm1dvelop_menu.gxTpr_Caption = "Customers";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("customerlocations.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-map-marker-alt";
         Gxm1dvelop_menu.gxTpr_Caption = "Locations";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("locationreceptionists.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon far fa-address-card";
         Gxm1dvelop_menu.gxTpr_Caption = "Receptionists";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("locationresidents.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-users";
         Gxm1dvelop_menu.gxTpr_Caption = "Residents";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("supplier_genww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-shipping-fast";
         Gxm1dvelop_menu.gxTpr_Caption = "General Suppliers";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("supplier_agbww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-ambulance";
         Gxm1dvelop_menu.gxTpr_Caption = "AGB Suppliers";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("productserviceww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fab fa-product-hunt";
         Gxm1dvelop_menu.gxTpr_Caption = "Products/Services";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-truck-field";
         Gxm1dvelop_menu.gxTpr_Caption = "My Suppliers";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("locationgensuppliers.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "My Suppliers (General)";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("locationagbsuppliers.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "My Suppliers (AGB)";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-cog";
         Gxm1dvelop_menu.gxTpr_Caption = "Settings";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("customertypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Customer Types";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("residenttypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Resident Types";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("productservicetypeww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Product/Service Types";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("pagetemplateww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-file";
         Gxm1dvelop_menu.gxTpr_Caption = "Page Templates";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("pageww.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-mobile-alt";
         Gxm1dvelop_menu.gxTpr_Caption = "Application Design";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         GXt_char1 = "";
         new getcustomercustomizationtrnmode(context ).execute( ref  GXt_char1) ;
         GXt_int2 = 0;
         new getcustomercustomizationid(context ).execute( out  GXt_int2) ;
         Gxm1dvelop_menu.gxTpr_Link = formatLink("customercustomization.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(GXt_char1)),GXUtil.UrlEncode(StringUtil.LTrimStr(GXt_int2,4,0))}, new string[] {"Mode","CustomerCustomizationId"}) ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-eye-dropper";
         Gxm1dvelop_menu.gxTpr_Caption = "Customization";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "Security of the application";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("gam_dashboard.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "_blank";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm1dvelop_menu.gxTpr_Caption = "GAM Security";
         Gxm1dvelop_menu.gxTpr_Authorizationkey = "is_gam_administrator";
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
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private short AV5id ;
      private short GXt_int2 ;
      private string GXt_char1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm3dvelop_menu_subitems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
   }

}
