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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class workwithplusmasterpage : GXMasterPage
   {
      public workwithplusmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplusmasterpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0X2( ) ;
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV18DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV18DVelop_Menu);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_USERDATA_MPAGE", AV10DVelop_Menu_UserData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_USERDATA_MPAGE", AV10DVelop_Menu_UserData);
         }
         GxWebStd.gx_hidden_field( context, "DDC_CHANGELANGUAGE_MPAGE_Caption", StringUtil.RTrim( Ddc_changelanguage_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_CHANGELANGUAGE_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_changelanguage_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icon", StringUtil.RTrim( Ddc_adminag_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Cls", StringUtil.RTrim( Ddc_adminag_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_adminag_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Sidebarmainclass", StringUtil.RTrim( Ucmenu_Sidebarmainclass));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Scrollwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollalwaysvisible", StringUtil.BoolToStr( Ucmenu_Scrollalwaysvisible));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Hidescrollincompactmenu", StringUtil.BoolToStr( Ucmenu_Hidescrollincompactmenu));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Empowertabs", StringUtil.BoolToStr( Wwputilities_Empowertabs));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus", StringUtil.BoolToStr( Wwputilities_Enableupdaterowselectionstatus));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumndragging", StringUtil.BoolToStr( Wwputilities_Allowcolumndragging));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Pagbarincludegoto", StringUtil.BoolToStr( Wwputilities_Pagbarincludegoto));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?20249126304343", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "HeaderImageCell", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Header Image", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(imgavHeaderimage_gximage, "")==0) ? "" : "GX_Image_"+imgavHeaderimage_gximage+"_Class");
            StyleString = "";
            AV32HeaderImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV37Headerimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)) ? AV37Headerimage_GXI : context.PathToRelativeUrl( AV32HeaderImage));
            GxWebStd.gx_bitmap( context, imgavHeaderimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV32HeaderImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblShowmenu_Internalname, "<i class=\"fa fa-bars ImageMenuIcon\"></i>", "", "", lblShowmenu_Jsonclick, "'"+""+"'"+",true,"+"'"+"e110x1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdc_changelanguage.SetProperty("Caption", Ddc_changelanguage_Caption);
            ucDdc_changelanguage.SetProperty("ComponentWidth", Ddc_changelanguage_Componentwidth);
            ucDdc_changelanguage.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_changelanguage_Internalname, "DDC_CHANGELANGUAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_adminag.SetProperty("Caption", Ddc_adminag_Caption);
            ucDdc_adminag.SetProperty("Cls", Ddc_adminag_Cls);
            ucDdc_adminag.SetProperty("ComponentWidth", Ddc_adminag_Componentwidth);
            ucDdc_adminag.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_adminag_Internalname, "DDC_ADMINAG_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentMaster CellTableContentWithFooter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "page-content MaterialStyle", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTitleMaster", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktitle_Internalname, lblTextblocktitle_Caption, "", "", lblTextblocktitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockTitleMaster", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellContentHolder", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmenu.SetProperty("SidebarMainClass", Ucmenu_Sidebarmainclass);
            ucUcmenu.SetProperty("ScrollWidth", Ucmenu_Scrollwidth);
            ucUcmenu.SetProperty("ScrollAlwaysVisible", Ucmenu_Scrollalwaysvisible);
            ucUcmenu.SetProperty("HideScrollInCompactMenu", Ucmenu_Hidescrollincompactmenu);
            ucUcmenu.SetProperty("SidebarMenuOptionsData", AV18DVelop_Menu);
            ucUcmenu.SetProperty("SidebarMenuUserData", AV10DVelop_Menu_UserData);
            ucUcmenu.Render(context, "dvelop.gxbootstrap.sidebarmenu", Ucmenu_Internalname, "UCMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUctooltip.Render(context, "dvelop.gxbootstrap.tooltip", Uctooltip_Internalname, "UCTOOLTIP_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EmpowerTabs", Wwputilities_Empowertabs);
            ucWwputilities.SetProperty("EnableUpdateRowSelectionStatus", Wwputilities_Enableupdaterowselectionstatus);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnDragging", Wwputilities_Allowcolumndragging);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("PagBarIncludeGoTo", Wwputilities_Pagbarincludegoto);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwpdatepicker.Render(context, "wwp.datepicker", Wwpdatepicker_Internalname, "WWPDATEPICKER_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV27PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV27PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0055"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0055"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0055"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E120X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E130X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E140X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 55 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0055");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0055", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E130X2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     WebComp_Wwpaux_wc.componentstart();
                  }
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140X2 ();
            WB0X0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV18DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_USERDATA_MPAGE"), AV10DVelop_Menu_UserData);
            /* Read saved values. */
            Ddc_changelanguage_Caption = cgiGet( "DDC_CHANGELANGUAGE_MPAGE_Caption");
            Ddc_changelanguage_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_CHANGELANGUAGE_MPAGE_Componentwidth"), ".", ","), 18, MidpointRounding.ToEven));
            Ddc_adminag_Icon = cgiGet( "DDC_ADMINAG_MPAGE_Icon");
            Ddc_adminag_Cls = cgiGet( "DDC_ADMINAG_MPAGE_Cls");
            Ddc_adminag_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_ADMINAG_MPAGE_Componentwidth"), ".", ","), 18, MidpointRounding.ToEven));
            Ucmenu_Sidebarmainclass = cgiGet( "UCMENU_MPAGE_Sidebarmainclass");
            Ucmenu_Scrollwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Scrollwidth"), ".", ","), 18, MidpointRounding.ToEven));
            Ucmenu_Scrollalwaysvisible = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Scrollalwaysvisible"));
            Ucmenu_Hidescrollincompactmenu = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Hidescrollincompactmenu"));
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_MPAGE_Stoponerror"));
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefixobjectfitcover"));
            Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Empowertabs"));
            Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnreordering"));
            Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumndragging"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnsrestore"));
            Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Pagbarincludegoto"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_MPAGE_Comboloadtype");
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = cgiGet( "FORM_MPAGE_Caption");
            /* Read variables values. */
            AV32HeaderImage = cgiGet( imgavHeaderimage_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Picker Dummy Variable"}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV27PickerDummyVariable", context.localUtil.Format(AV27PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV27PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), 1);
               AssignAttri("", true, "AV27PickerDummyVariable", context.localUtil.Format(AV27PickerDummyVariable, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120X2 ();
         if (returnInSub) return;
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcustomercustomizationvalues(context ).execute( out  AV30CustomerCustomizationSDTValues) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationfavicon)) )
         {
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "2a13ba77-7b8c-4328-99d8-e8c998630c79", "", context.GetTheme( ))))+"\">";
         }
         else
         {
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationfavicon_gxi+"\">";
         }
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_objcol_SdtDVelop_Menu_Item1 = AV18DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV18DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new GeneXus.Programs.wwpbaseobjects.getmenuauthorizedoptions(context ).execute( ref  AV18DVelop_Menu) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationlogo)) )
         {
            imgImagelogo_gximage = "LogoLogin";
            AssignProp("", true, imgImagelogo_Internalname, "gximage", imgImagelogo_gximage, true);
            AV33ImageLogo = context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( ));
            AV36Imagelogo_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )), context);
            AV32HeaderImage = AV33ImageLogo;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)) ? AV37Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV32HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV32HeaderImage), true);
            AV37Headerimage_GXI = AV36Imagelogo_GXI;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)) ? AV37Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV32HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV32HeaderImage), true);
         }
         else
         {
            AV34Resized = AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationlogo;
            AV38Resized_GXI = AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationlogo_gxi;
            AV32HeaderImage = AV34Resized;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)) ? AV37Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV32HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV32HeaderImage), true);
            AV37Headerimage_GXI = AV38Resized_GXI;
            AssignProp("", true, imgavHeaderimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32HeaderImage)) ? AV37Headerimage_GXI : context.convertURL( context.PathToRelativeUrl( AV32HeaderImage))), true);
            AssignProp("", true, imgavHeaderimage_Internalname, "SrcSet", context.GetImageSrcSet( AV32HeaderImage), true);
         }
         Ddc_adminag_Icon = context.convertURL( (string)(context.GetImagePath( "cd132e7c-3222-4be1-9123-4cad0b17f9cf", "", context.GetTheme( ))));
         ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Icon", Ddc_adminag_Icon);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<link rel=\"stylesheet\" href=\"Resources/UCGrapes/grapes.min.css\">"+"<script src=\"Resources/UCGrapes/grapes.min.js\"></script>";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV19UserName = (String.IsNullOrEmpty(StringUtil.RTrim( AV9GAMUser.gxTpr_Firstname)) ? AV9GAMUser.gxTpr_Name : StringUtil.Trim( AV9GAMUser.gxTpr_Firstname)+" "+StringUtil.Trim( AV9GAMUser.gxTpr_Lastname));
         AV5GAMRoleCollection = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).getroles(out  AV7GAMErrorCollection);
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV5GAMRoleCollection.Count )
         {
            AV6GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5GAMRoleCollection.Item(AV39GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20RolesDescriptions)) )
            {
               AV20RolesDescriptions += ", ";
               AssignAttri("", true, "AV20RolesDescriptions", AV20RolesDescriptions);
            }
            AV20RolesDescriptions += (String.IsNullOrEmpty(StringUtil.RTrim( AV6GAMRole.gxTpr_Description)) ? AV6GAMRole.gxTpr_Name : AV6GAMRole.gxTpr_Description);
            AssignAttri("", true, "AV20RolesDescriptions", AV20RolesDescriptions);
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         if ( StringUtil.StrCmp(AV24Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings2 = AV11WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings2) ;
            AV11WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationbasecolor)) )
            {
               this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",(string)"Teal"}, false);
            }
            else
            {
               this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationbasecolor}, false);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationfontsize)) )
            {
               this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",(string)"Medium"}, false);
            }
            else
            {
               this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV30CustomerCustomizationSDTValues.gxTpr_Customercustomizationfontsize}, false);
            }
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV11WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV11WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         Ddc_changelanguage_Caption = context.GetLanguage( );
         ucDdc_changelanguage.SendProperty(context, "", true, Ddc_changelanguage_Internalname, "Caption", Ddc_changelanguage_Caption);
      }

      protected void E130X2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblTextblocktitle_Caption = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignProp("", true, lblTextblocktitle_Internalname, "Caption", lblTextblocktitle_Caption, true);
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E140X2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20249126304834", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?20249126304835", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgavHeaderimage_Internalname = "vHEADERIMAGE_MPAGE";
         lblShowmenu_Internalname = "SHOWMENU_MPAGE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         Ddc_changelanguage_Internalname = "DDC_CHANGELANGUAGE_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         lblTextblocktitle_Internalname = "TEXTBLOCKTITLE_MPAGE";
         divTabletitle_Internalname = "TABLETITLE_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         Ucmenu_Internalname = "UCMENU_MPAGE";
         Ucmessage_Internalname = "UCMESSAGE_MPAGE";
         Uctooltip_Internalname = "UCTOOLTIP_MPAGE";
         Wwputilities_Internalname = "WWPUTILITIES_MPAGE";
         Wwpdatepicker_Internalname = "WWPDATEPICKER_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPickerdummyvariable_Jsonclick = "";
         lblTextblocktitle_Caption = " Title";
         Ddc_adminag_Caption = "";
         imgavHeaderimage_gximage = "";
         divLayoutmaintable_Class = "Table";
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Pagbarincludegoto = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumndragging = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enableupdaterowselectionstatus = Convert.ToBoolean( -1);
         Wwputilities_Empowertabs = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmenu_Hidescrollincompactmenu = Convert.ToBoolean( 0);
         Ucmenu_Scrollalwaysvisible = Convert.ToBoolean( -1);
         Ucmenu_Scrollwidth = 5;
         Ucmenu_Sidebarmainclass = "page-sidebar sidebar-fixed MaterialStyle";
         Ddc_adminag_Componentwidth = 260;
         Ddc_adminag_Cls = "ActionGroupHeader ActionGroupHeaderSquare";
         Ddc_adminag_Icon = "";
         Ddc_changelanguage_Componentwidth = 160;
         Ddc_changelanguage_Caption = "Change Language";
         Contentholder.setDataArea(getDataAreaObject());
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH_MPAGE","""{"handler":"Refresh","iparms":[{"ctrl":"FORM_MPAGE","prop":"Caption"}]""");
         setEventMetadata("REFRESH_MPAGE",""","oparms":[{"av":"lblTextblocktitle_Caption","ctrl":"TEXTBLOCKTITLE_MPAGE","prop":"Caption"}]}""");
         setEventMetadata("DOSHOWMENU_MPAGE","""{"handler":"E110X1","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Contentholder = new GXDataAreaControl();
         GXKey = "";
         AV18DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Comforta2");
         AV10DVelop_Menu_UserData = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData(context);
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         AV32HeaderImage = "";
         AV37Headerimage_GXI = "";
         sImgUrl = "";
         lblShowmenu_Jsonclick = "";
         ucDdc_changelanguage = new GXUserControl();
         ucDdc_adminag = new GXUserControl();
         lblTextblocktitle_Jsonclick = "";
         ucUcmenu = new GXUserControl();
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         TempTags = "";
         AV27PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV30CustomerCustomizationSDTValues = new SdtCustomerCustomizationSDT(context);
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Comforta2");
         AV33ImageLogo = "";
         imgImagelogo_gximage = "";
         imgImagelogo_Internalname = "";
         AV36Imagelogo_GXI = "";
         AV34Resized = "";
         AV38Resized_GXI = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV19UserName = "";
         AV5GAMRoleCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV7GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV20RolesDescriptions = "";
         AV24Httprequest = new GxHttpRequest( context);
         AV11WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings2 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Ddc_changelanguage_Componentwidth ;
      private int Ddc_adminag_Componentwidth ;
      private int Ucmenu_Scrollwidth ;
      private int AV39GXV1 ;
      private int idxLst ;
      private string GXKey ;
      private string Ddc_changelanguage_Caption ;
      private string Ddc_adminag_Icon ;
      private string Ddc_adminag_Cls ;
      private string Ucmenu_Sidebarmainclass ;
      private string Wwputilities_Comboloadtype ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string imgavHeaderimage_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgavHeaderimage_Internalname ;
      private string lblShowmenu_Internalname ;
      private string lblShowmenu_Jsonclick ;
      private string divTableuserrole_Internalname ;
      private string Ddc_changelanguage_Internalname ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTabletitle_Internalname ;
      private string lblTextblocktitle_Internalname ;
      private string lblTextblocktitle_Caption ;
      private string lblTextblocktitle_Jsonclick ;
      private string Ucmenu_Internalname ;
      private string Ucmessage_Internalname ;
      private string Uctooltip_Internalname ;
      private string Wwputilities_Internalname ;
      private string Wwpdatepicker_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string imgImagelogo_gximage ;
      private string imgImagelogo_Internalname ;
      private string sDynURL ;
      private DateTime AV27PickerDummyVariable ;
      private bool Ucmenu_Scrollalwaysvisible ;
      private bool Ucmenu_Hidescrollincompactmenu ;
      private bool Ucmessage_Stoponerror ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool wbLoad ;
      private bool AV32HeaderImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV37Headerimage_GXI ;
      private string AV36Imagelogo_GXI ;
      private string AV38Resized_GXI ;
      private string AV19UserName ;
      private string AV20RolesDescriptions ;
      private string AV32HeaderImage ;
      private string AV33ImageLogo ;
      private string AV34Resized ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_changelanguage ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucUcmenu ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GxHttpRequest AV24Httprequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV18DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData AV10DVelop_Menu_UserData ;
      private SdtCustomerCustomizationSDT AV30CustomerCustomizationSDTValues ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV5GAMRoleCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV6GAMRole ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV11WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
