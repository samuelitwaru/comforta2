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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class amenitiestypeview : GXDataArea
   {
      public amenitiestypeview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amenitiestypeview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AmenitiesTypeId ,
                           string aP1_TabCode )
      {
         this.AV10AmenitiesTypeId = aP0_AmenitiesTypeId;
         this.AV8TabCode = aP1_TabCode;
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
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AmenitiesTypeId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AmenitiesTypeId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AmenitiesTypeId");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV10AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV10AmenitiesTypeId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10AmenitiesTypeId), "ZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8TabCode = GetPar( "TabCode");
                  AssignAttri("", false, "AV8TabCode", AV8TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "amenitiestypeview_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA332( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START332( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("amenitiestypeview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10AmenitiesTypeId,4,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"AmenitiesTypeId","TabCode"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vAMENITIESTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10AmenitiesTypeId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV12SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vAMENITIESTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10AmenitiesTypeId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Width", StringUtil.RTrim( Panel_general_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autowidth", StringUtil.BoolToStr( Panel_general_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoheight", StringUtil.BoolToStr( Panel_general_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Cls", StringUtil.RTrim( Panel_general_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Title", StringUtil.RTrim( Panel_general_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsible", StringUtil.BoolToStr( Panel_general_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsed", StringUtil.BoolToStr( Panel_general_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Showcollapseicon", StringUtil.BoolToStr( Panel_general_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Iconposition", StringUtil.RTrim( Panel_general_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoscroll", StringUtil.BoolToStr( Panel_general_Autoscroll));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            WebComp_Webcomponent_general.componentjscripts();
         }
         if ( ! ( WebComp_Amenitieswc == null ) )
         {
            WebComp_Amenitieswc.componentjscripts();
         }
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE332( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT332( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("amenitiestypeview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10AmenitiesTypeId,4,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"AmenitiesTypeId","TabCode"})  ;
      }

      public override string GetPgmname( )
      {
         return "AmenitiesTypeView" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Amenities Type View", "") ;
      }

      protected void WB330( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLinkPanel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, context.GetMessage( "Go to Amenities Type", ""), lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_AmenitiesTypeView.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAmenitiestypegeneral_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_general.SetProperty("Width", Panel_general_Width);
            ucPanel_general.SetProperty("AutoWidth", Panel_general_Autowidth);
            ucPanel_general.SetProperty("AutoHeight", Panel_general_Autoheight);
            ucPanel_general.SetProperty("Cls", Panel_general_Cls);
            ucPanel_general.SetProperty("Title", Panel_general_Title);
            ucPanel_general.SetProperty("Collapsible", Panel_general_Collapsible);
            ucPanel_general.SetProperty("Collapsed", Panel_general_Collapsed);
            ucPanel_general.SetProperty("ShowCollapseIcon", Panel_general_Showcollapseicon);
            ucPanel_general.SetProperty("IconPosition", Panel_general_Iconposition);
            ucPanel_general.SetProperty("AutoScroll", Panel_general_Autoscroll);
            ucPanel_general.Render(context, "dvelop.gxbootstrap.panel_al", Panel_general_Internalname, "PANEL_GENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_GENERALContainer"+"TablePanel_General"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_general_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0019"+"", StringUtil.RTrim( WebComp_Webcomponent_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
                  }
                  WebComp_Webcomponent_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAmenities_title_Internalname, context.GetMessage( "Amenities", ""), "", "", lblAmenities_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AmenitiesTypeView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Amenities") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableamenities_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Amenitieswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Amenitieswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldAmenitieswc), StringUtil.Lower( WebComp_Amenitieswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Amenitieswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldAmenitieswc), StringUtil.Lower( WebComp_Amenitieswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START332( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Amenities Type View", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP330( ) ;
      }

      protected void WS332( )
      {
         START332( ) ;
         EVT332( ) ;
      }

      protected void EVT332( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12332 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 19 )
                        {
                           OldWebcomponent_general = cgiGet( "W0019");
                           if ( ( StringUtil.Len( OldWebcomponent_general) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_general, WebComp_Webcomponent_general_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_general, new Object[] {context} );
                              WebComp_Webcomponent_general.ComponentInit();
                              WebComp_Webcomponent_general.Name = "OldWebcomponent_general";
                              WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
                           {
                              WebComp_Webcomponent_general.componentprocess("W0019", "", sEvt);
                           }
                           WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                        }
                        else if ( nCmpId == 33 )
                        {
                           OldAmenitieswc = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldAmenitieswc) == 0 ) || ( StringUtil.StrCmp(OldAmenitieswc, WebComp_Amenitieswc_Component) != 0 ) )
                           {
                              WebComp_Amenitieswc = getWebComponent(GetType(), "GeneXus.Programs", OldAmenitieswc, new Object[] {context} );
                              WebComp_Amenitieswc.ComponentInit();
                              WebComp_Amenitieswc.Name = "OldAmenitieswc";
                              WebComp_Amenitieswc_Component = OldAmenitieswc;
                           }
                           if ( StringUtil.Len( WebComp_Amenitieswc_Component) != 0 )
                           {
                              WebComp_Amenitieswc.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Amenitieswc_Component = OldAmenitieswc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE332( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA332( )
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
         RF332( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF332( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  WebComp_Webcomponent_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Amenitieswc_Component) != 0 )
               {
                  WebComp_Amenitieswc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12332 ();
            WB330( ) ;
         }
      }

      protected void send_integrity_lvl_hashes332( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP330( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11332 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV10AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vAMENITIESTYPEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV11LoadAllTabs = StringUtil.StrToBool( cgiGet( "vLOADALLTABS"));
            AV12SelectedTabCode = cgiGet( "vSELECTEDTABCODE");
            Panel_general_Width = cgiGet( "PANEL_GENERAL_Width");
            Panel_general_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autowidth"));
            Panel_general_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoheight"));
            Panel_general_Cls = cgiGet( "PANEL_GENERAL_Cls");
            Panel_general_Title = cgiGet( "PANEL_GENERAL_Title");
            Panel_general_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsible"));
            Panel_general_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsed"));
            Panel_general_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Showcollapseicon"));
            Panel_general_Iconposition = cgiGet( "PANEL_GENERAL_Iconposition");
            Panel_general_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoscroll"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            /* Read variables values. */
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
         E11332 ();
         if (returnInSub) return;
      }

      protected void E11332( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("amenitiestypeww.aspx") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV14GXLvl9 = 0;
         /* Using cursor H00332 */
         pr_default.execute(0, new Object[] {AV10AmenitiesTypeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A99AmenitiesTypeId = H00332_A99AmenitiesTypeId[0];
            A100AmenitiesTypeName = H00332_A100AmenitiesTypeName[0];
            AV14GXLvl9 = 1;
            Form.Caption = A100AmenitiesTypeName;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl9 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV12SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
            Tabs_Activepagecontrolname = AV12SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADFIXEDTABS' */
            S112 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'LOADTABS' */
            S122 ();
            if (returnInSub) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12332( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'LOADFIXEDTABS' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_general = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_general_Component), StringUtil.Lower( "AmenitiesTypeGeneral")) != 0 )
         {
            WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", "amenitiestypegeneral", new Object[] {context} );
            WebComp_Webcomponent_general.ComponentInit();
            WebComp_Webcomponent_general.Name = "AmenitiesTypeGeneral";
            WebComp_Webcomponent_general_Component = "AmenitiesTypeGeneral";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
         {
            WebComp_Webcomponent_general.setjustcreated();
            WebComp_Webcomponent_general.componentprepare(new Object[] {(string)"W0019",(string)"",(short)AV10AmenitiesTypeId});
            WebComp_Webcomponent_general.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_general )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
            WebComp_Webcomponent_general.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      protected void S122( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV12SelectedTabCode, "Amenities") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Amenitieswc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Amenitieswc_Component), StringUtil.Lower( "AmenitiesTypeAmenitiesWC")) != 0 )
            {
               WebComp_Amenitieswc = getWebComponent(GetType(), "GeneXus.Programs", "amenitiestypeamenitieswc", new Object[] {context} );
               WebComp_Amenitieswc.ComponentInit();
               WebComp_Amenitieswc.Name = "AmenitiesTypeAmenitiesWC";
               WebComp_Amenitieswc_Component = "AmenitiesTypeAmenitiesWC";
            }
            if ( StringUtil.Len( WebComp_Amenitieswc_Component) != 0 )
            {
               WebComp_Amenitieswc.setjustcreated();
               WebComp_Amenitieswc.componentprepare(new Object[] {(string)"W0033",(string)"",(short)AV10AmenitiesTypeId});
               WebComp_Amenitieswc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Amenitieswc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
               WebComp_Amenitieswc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10AmenitiesTypeId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV10AmenitiesTypeId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESTYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10AmenitiesTypeId), "ZZZ9"), context));
         AV8TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA332( ) ;
         WS332( ) ;
         WE332( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
            {
               WebComp_Webcomponent_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Amenitieswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Amenitieswc_Component) != 0 )
            {
               WebComp_Amenitieswc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249131556440", true, true);
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
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("amenitiestypeview.js", "?20249131556441", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWorkwithlink_Internalname = "WORKWITHLINK";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         divTablepanel_general_Internalname = "TABLEPANEL_GENERAL";
         Panel_general_Internalname = "PANEL_GENERAL";
         divAmenitiestypegeneral_cell_Internalname = "AMENITIESTYPEGENERAL_CELL";
         lblAmenities_title_Internalname = "AMENITIES_TITLE";
         divUnnamedtableamenities_Internalname = "UNNAMEDTABLEAMENITIES";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblWorkwithlink_Link = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 1;
         Panel_general_Autoscroll = Convert.ToBoolean( 0);
         Panel_general_Iconposition = "Right";
         Panel_general_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_general_Collapsed = Convert.ToBoolean( 0);
         Panel_general_Collapsible = Convert.ToBoolean( -1);
         Panel_general_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Panel_general_Cls = "DVBootstrapResponsivePanel";
         Panel_general_Autoheight = Convert.ToBoolean( -1);
         Panel_general_Autowidth = Convert.ToBoolean( 0);
         Panel_general_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Amenities Type View", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9","hsh":true},{"av":"AV8TabCode","fld":"vTABCODE","hsh":true}]}""");
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
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWorkwithlink_Jsonclick = "";
         ucPanel_general = new GXUserControl();
         WebComp_Webcomponent_general_Component = "";
         OldWebcomponent_general = "";
         ucTabs = new GXUserControl();
         lblAmenities_title_Jsonclick = "";
         WebComp_Amenitieswc_Component = "";
         OldAmenitieswc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00332_A99AmenitiesTypeId = new short[1] ;
         H00332_A100AmenitiesTypeName = new string[] {""} ;
         A100AmenitiesTypeName = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amenitiestypeview__default(),
            new Object[][] {
                new Object[] {
               H00332_A99AmenitiesTypeId, H00332_A100AmenitiesTypeName
               }
            }
         );
         WebComp_Webcomponent_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Amenitieswc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV10AmenitiesTypeId ;
      private short wcpOAV10AmenitiesTypeId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV14GXLvl9 ;
      private short A99AmenitiesTypeId ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV12SelectedTabCode ;
      private string Panel_general_Width ;
      private string Panel_general_Cls ;
      private string Panel_general_Title ;
      private string Panel_general_Iconposition ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string lblWorkwithlink_Internalname ;
      private string lblWorkwithlink_Link ;
      private string lblWorkwithlink_Jsonclick ;
      private string divAmenitiestypegeneral_cell_Internalname ;
      private string Panel_general_Internalname ;
      private string divTablepanel_general_Internalname ;
      private string WebComp_Webcomponent_general_Component ;
      private string OldWebcomponent_general ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblAmenities_title_Internalname ;
      private string lblAmenities_title_Jsonclick ;
      private string divUnnamedtableamenities_Internalname ;
      private string WebComp_Amenitieswc_Component ;
      private string OldAmenitieswc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Panel_general_Autowidth ;
      private bool Panel_general_Autoheight ;
      private bool Panel_general_Collapsible ;
      private bool Panel_general_Collapsed ;
      private bool Panel_general_Showcollapseicon ;
      private bool Panel_general_Autoscroll ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool bDynCreated_Webcomponent_general ;
      private bool bDynCreated_Amenitieswc ;
      private string A100AmenitiesTypeName ;
      private GXWebComponent WebComp_Webcomponent_general ;
      private GXWebComponent WebComp_Amenitieswc ;
      private GXUserControl ucPanel_general ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private short[] H00332_A99AmenitiesTypeId ;
      private string[] H00332_A100AmenitiesTypeName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class amenitiestypeview__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00332;
          prmH00332 = new Object[] {
          new ParDef("AV10AmenitiesTypeId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00332", "SELECT AmenitiesTypeId, AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AV10AmenitiesTypeId ORDER BY AmenitiesTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00332,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
