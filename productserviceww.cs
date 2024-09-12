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
namespace GeneXus.Programs {
   public class productserviceww : GXDataArea
   {
      public productserviceww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productserviceww( IGxContext context )
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
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV24ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19ColumnsSelector);
         AV53Pgmname = GetPar( "Pgmname");
         AV27TFProductServiceName = GetPar( "TFProductServiceName");
         AV28TFProductServiceName_Sel = GetPar( "TFProductServiceName_Sel");
         AV35TFProductServiceTypeName = GetPar( "TFProductServiceTypeName");
         AV36TFProductServiceTypeName_Sel = GetPar( "TFProductServiceTypeName_Sel");
         AV45IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV47IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV48IsAuthorized_ProductServiceName = StringUtil.StrToBool( GetPar( "IsAuthorized_ProductServiceName"));
         AV50IsAuthorized_ProductServiceTypeName = StringUtil.StrToBool( GetPar( "IsAuthorized_ProductServiceTypeName"));
         AV49IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "productserviceww_Execute" ;
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
         PA1O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1O2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productserviceww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV48IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV48IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICETYPENAME", AV50IsAuthorized_ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICETYPENAME", GetSecureSignedToken( "", AV50IsAuthorized_ProductServiceTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV49IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV49IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV43GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME", AV27TFProductServiceName);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME_SEL", AV28TFProductServiceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICETYPENAME", AV35TFProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICETYPENAME_SEL", AV36TFProductServiceTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV48IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV48IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICETYPENAME", AV50IsAuthorized_ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICETYPENAME", GetSecureSignedToken( "", AV50IsAuthorized_ProductServiceTypeName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV49IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV49IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Gridinternalname", StringUtil.RTrim( Popover_productservicedescriptionvar_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Iteminternalname", StringUtil.RTrim( Popover_productservicedescriptionvar_Iteminternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Isgriditem", StringUtil.BoolToStr( Popover_productservicedescriptionvar_Isgriditem));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Trigger", StringUtil.RTrim( Popover_productservicedescriptionvar_Trigger));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Triggerelement", StringUtil.RTrim( Popover_productservicedescriptionvar_Triggerelement));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_productservicedescriptionvar_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Position", StringUtil.RTrim( Popover_productservicedescriptionvar_Position));
         GxWebStd.gx_hidden_field( context, "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Keepopened", StringUtil.BoolToStr( Popover_productservicedescriptionvar_Keepopened));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Popoversingrid", StringUtil.RTrim( Grid_empowerer_Popoversingrid));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1O2( ) ;
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
         return formatLink("productserviceww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProductServiceWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Products/Services" ;
      }

      protected void WB1O0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV22ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProductServiceWW.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV41GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV42GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV43GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucPopover_productservicedescriptionvar.SetProperty("IsGridItem", Popover_productservicedescriptionvar_Isgriditem);
            ucPopover_productservicedescriptionvar.SetProperty("Trigger", Popover_productservicedescriptionvar_Trigger);
            ucPopover_productservicedescriptionvar.SetProperty("TriggerElement", Popover_productservicedescriptionvar_Triggerelement);
            ucPopover_productservicedescriptionvar.SetProperty("PopoverWidth", Popover_productservicedescriptionvar_Popoverwidth);
            ucPopover_productservicedescriptionvar.SetProperty("Position", Popover_productservicedescriptionvar_Position);
            ucPopover_productservicedescriptionvar.SetProperty("KeepOpened", Popover_productservicedescriptionvar_Keepopened);
            ucPopover_productservicedescriptionvar.Render(context, "dvelop.wwppopover", Popover_productservicedescriptionvar_Internalname, "POPOVER_PRODUCTSERVICEDESCRIPTIONVARContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV19ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("PopoversInGrid", Grid_empowerer_Popoversingrid);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
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
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1O2( )
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
         Form.Meta.addItem("description", " Products/Services", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1O0( ) ;
      }

      protected void WS1O2( )
      {
         START1O2( ) ;
         EVT1O2( ) ;
      }

      protected void EVT1O2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E111O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E141O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E151O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E161O2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A74ProductServiceName = cgiGet( edtProductServiceName_Internalname);
                              AV52ProductServiceDescriptionVarWithTags = cgiGet( edtavProductservicedescriptionvarwithtags_Internalname);
                              AssignAttri("", false, edtavProductservicedescriptionvarwithtags_Internalname, AV52ProductServiceDescriptionVarWithTags);
                              AV51ProductServiceDescriptionVar = cgiGet( edtavProductservicedescriptionvar_Internalname);
                              AssignAttri("", false, edtavProductservicedescriptionvar_Internalname, AV51ProductServiceDescriptionVar);
                              A75ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
                              A76ProductServiceQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A72ProductServiceTypeName = cgiGet( edtProductServiceTypeName_Internalname);
                              A77ProductServicePicture = cgiGet( edtProductServicePicture_Internalname);
                              AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_37_Refreshing);
                              AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
                              A71ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              AV44Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV44Update);
                              AV46Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E191O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 60 )
                        {
                           OldWwpaux_wc = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0060", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1O2( )
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

      protected void PA1O2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16FilterFullText ,
                                       short AV24ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ,
                                       string AV53Pgmname ,
                                       string AV27TFProductServiceName ,
                                       string AV28TFProductServiceName_Sel ,
                                       string AV35TFProductServiceTypeName ,
                                       string AV36TFProductServiceTypeName_Sel ,
                                       bool AV45IsAuthorized_Update ,
                                       bool AV47IsAuthorized_Delete ,
                                       bool AV48IsAuthorized_ProductServiceName ,
                                       bool AV50IsAuthorized_ProductServiceTypeName ,
                                       bool AV49IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A75ProductServiceDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION", A75ProductServiceDescription);
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
         RF1O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "ProductServiceWW";
         edtavProductservicedescriptionvarwithtags_Enabled = 0;
         edtavProductservicedescriptionvar_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF1O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181O2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
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
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV54Productservicewwds_1_filterfulltext ,
                                                 AV56Productservicewwds_3_tfproductservicename_sel ,
                                                 AV55Productservicewwds_2_tfproductservicename ,
                                                 AV58Productservicewwds_5_tfproductservicetypename_sel ,
                                                 AV57Productservicewwds_4_tfproductservicetypename ,
                                                 A74ProductServiceName ,
                                                 A72ProductServiceTypeName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext), "%", "");
            lV54Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext), "%", "");
            lV55Productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV55Productservicewwds_2_tfproductservicename), "%", "");
            lV57Productservicewwds_4_tfproductservicetypename = StringUtil.Concat( StringUtil.RTrim( AV57Productservicewwds_4_tfproductservicetypename), "%", "");
            /* Using cursor H001O2 */
            pr_default.execute(0, new Object[] {lV54Productservicewwds_1_filterfulltext, lV54Productservicewwds_1_filterfulltext, lV55Productservicewwds_2_tfproductservicename, AV56Productservicewwds_3_tfproductservicename_sel, lV57Productservicewwds_4_tfproductservicetypename, AV58Productservicewwds_5_tfproductservicetypename_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A71ProductServiceTypeId = H001O2_A71ProductServiceTypeId[0];
               A40000ProductServicePicture_GXI = H001O2_A40000ProductServicePicture_GXI[0];
               AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
               A72ProductServiceTypeName = H001O2_A72ProductServiceTypeName[0];
               A76ProductServiceQuantity = H001O2_A76ProductServiceQuantity[0];
               A75ProductServiceDescription = H001O2_A75ProductServiceDescription[0];
               A74ProductServiceName = H001O2_A74ProductServiceName[0];
               A73ProductServiceId = H001O2_A73ProductServiceId[0];
               A77ProductServicePicture = H001O2_A77ProductServicePicture[0];
               AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
               A72ProductServiceTypeName = H001O2_A72ProductServiceTypeName[0];
               /* Execute user event: Grid.Load */
               E191O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1O0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV48IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV48IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICETYPENAME", AV50IsAuthorized_ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICETYPENAME", GetSecureSignedToken( "", AV50IsAuthorized_ProductServiceTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV49IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV49IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEDESCRIPTION"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A75ProductServiceDescription, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Productservicewwds_1_filterfulltext ,
                                              AV56Productservicewwds_3_tfproductservicename_sel ,
                                              AV55Productservicewwds_2_tfproductservicename ,
                                              AV58Productservicewwds_5_tfproductservicetypename_sel ,
                                              AV57Productservicewwds_4_tfproductservicetypename ,
                                              A74ProductServiceName ,
                                              A72ProductServiceTypeName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext), "%", "");
         lV54Productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext), "%", "");
         lV55Productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV55Productservicewwds_2_tfproductservicename), "%", "");
         lV57Productservicewwds_4_tfproductservicetypename = StringUtil.Concat( StringUtil.RTrim( AV57Productservicewwds_4_tfproductservicetypename), "%", "");
         /* Using cursor H001O3 */
         pr_default.execute(1, new Object[] {lV54Productservicewwds_1_filterfulltext, lV54Productservicewwds_1_filterfulltext, lV55Productservicewwds_2_tfproductservicename, AV56Productservicewwds_3_tfproductservicename_sel, lV57Productservicewwds_4_tfproductservicetypename, AV58Productservicewwds_5_tfproductservicetypename_sel});
         GRID_nRecordCount = H001O3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV53Pgmname, AV27TFProductServiceName, AV28TFProductServiceName_Sel, AV35TFProductServiceTypeName, AV36TFProductServiceTypeName_Sel, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV48IsAuthorized_ProductServiceName, AV50IsAuthorized_ProductServiceTypeName, AV49IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "ProductServiceWW";
         edtavProductservicedescriptionvarwithtags_Enabled = 0;
         edtavProductservicedescriptionvar_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceQuantity_Enabled = 0;
         edtProductServiceTypeName_Enabled = 0;
         edtProductServicePicture_Enabled = 0;
         edtProductServiceTypeId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV37DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV41GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV42GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV43GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Popover_productservicedescriptionvar_Gridinternalname = cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Gridinternalname");
            Popover_productservicedescriptionvar_Iteminternalname = cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Iteminternalname");
            Popover_productservicedescriptionvar_Isgriditem = StringUtil.StrToBool( cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Isgriditem"));
            Popover_productservicedescriptionvar_Trigger = cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Trigger");
            Popover_productservicedescriptionvar_Triggerelement = cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Triggerelement");
            Popover_productservicedescriptionvar_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Popoverwidth"), ".", ","), 18, MidpointRounding.ToEven));
            Popover_productservicedescriptionvar_Position = cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Position");
            Popover_productservicedescriptionvar_Keepopened = StringUtil.StrToBool( cgiGet( "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR_Keepopened"));
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Popoversingrid = cgiGet( "GRID_EMPOWERER_Popoversingrid");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E171O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171O2( )
      {
         /* Start Routine */
         returnInSub = false;
         Popover_productservicedescriptionvar_Gridinternalname = subGrid_Internalname;
         ucPopover_productservicedescriptionvar.SendProperty(context, "", false, Popover_productservicedescriptionvar_Internalname, "GridInternalName", Popover_productservicedescriptionvar_Gridinternalname);
         Popover_productservicedescriptionvar_Iteminternalname = edtavProductservicedescriptionvarwithtags_Internalname;
         ucPopover_productservicedescriptionvar.SendProperty(context, "", false, Popover_productservicedescriptionvar_Internalname, "ItemInternalName", Popover_productservicedescriptionvar_Iteminternalname);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_boolean1 = AV48IsAuthorized_ProductServiceName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "productserviceview_Execute", out  GXt_boolean1) ;
         AV48IsAuthorized_ProductServiceName = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_ProductServiceName", AV48IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV48IsAuthorized_ProductServiceName, context));
         GXt_boolean1 = AV50IsAuthorized_ProductServiceTypeName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "productservicetypeview_Execute", out  GXt_boolean1) ;
         AV50IsAuthorized_ProductServiceTypeName = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_ProductServiceTypeName", AV50IsAuthorized_ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICETYPENAME", GetSecureSignedToken( "", AV50IsAuthorized_ProductServiceTypeName, context));
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV39GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV38GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Products/Services";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV37DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV37DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV24ManageFiltersExecutionStep == 1 )
         {
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV24ManageFiltersExecutionStep == 2 )
         {
            AV24ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV21Session.Get("ProductServiceWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("ProductServiceWWColumnsSelector");
            AV19ColumnsSelector.FromXml(AV17ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtProductServiceName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProductServiceName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavProductservicedescriptionvarwithtags_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavProductservicedescriptionvarwithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductservicedescriptionvarwithtags_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtProductServiceTypeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProductServiceTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtProductServicePicture_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProductServicePicture_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServicePicture_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV41GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV41GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV41GridCurrentPage), 10, 0));
         AV42GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV42GridPageCount", StringUtil.LTrimStr( (decimal)(AV42GridPageCount), 10, 0));
         GXt_char3 = AV43GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV53Pgmname, out  GXt_char3) ;
         AV43GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV43GridAppliedFilters", AV43GridAppliedFilters);
         AV54Productservicewwds_1_filterfulltext = AV16FilterFullText;
         AV55Productservicewwds_2_tfproductservicename = AV27TFProductServiceName;
         AV56Productservicewwds_3_tfproductservicename_sel = AV28TFProductServiceName_Sel;
         AV57Productservicewwds_4_tfproductservicetypename = AV35TFProductServiceTypeName;
         AV58Productservicewwds_5_tfproductservicetypename_sel = AV36TFProductServiceTypeName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E121O2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV40PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV40PageToGo) ;
         }
      }

      protected void E131O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141O2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceName") == 0 )
            {
               AV27TFProductServiceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFProductServiceName", AV27TFProductServiceName);
               AV28TFProductServiceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFProductServiceName_Sel", AV28TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceTypeName") == 0 )
            {
               AV35TFProductServiceTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFProductServiceTypeName", AV35TFProductServiceTypeName);
               AV36TFProductServiceTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFProductServiceTypeName_Sel", AV36TFProductServiceTypeName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.Len( A75ProductServiceDescription) > 30 )
         {
            AV51ProductServiceDescriptionVar = StringUtil.Substring( A75ProductServiceDescription, 1, 30) + "...";
            AssignAttri("", false, edtavProductservicedescriptionvar_Internalname, AV51ProductServiceDescriptionVar);
         }
         else
         {
            AV51ProductServiceDescriptionVar = A75ProductServiceDescription;
            AssignAttri("", false, edtavProductservicedescriptionvar_Internalname, AV51ProductServiceDescriptionVar);
         }
         AV44Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV44Update);
         if ( AV45IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("productservice.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A73ProductServiceId,4,0))}, new string[] {"Mode","ProductServiceId"}) ;
         }
         AV46Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
         if ( AV47IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("productservice.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A73ProductServiceId,4,0))}, new string[] {"Mode","ProductServiceId"}) ;
         }
         if ( AV48IsAuthorized_ProductServiceName )
         {
            edtProductServiceName_Link = formatLink("productserviceview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A73ProductServiceId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProductServiceId","TabCode"}) ;
         }
         if ( AV50IsAuthorized_ProductServiceTypeName )
         {
            edtProductServiceTypeName_Link = formatLink("productservicetypeview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A71ProductServiceTypeId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProductServiceTypeId","TabCode"}) ;
         }
         AV52ProductServiceDescriptionVarWithTags = AV51ProductServiceDescriptionVar;
         AssignAttri("", false, edtavProductservicedescriptionvarwithtags_Internalname, AV52ProductServiceDescriptionVarWithTags);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E151O2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ProductServiceWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E111O2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("ProductServiceWWFilters")),UrlEncode(StringUtil.RTrim(AV53Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("ProductServiceWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ProductServiceWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV23ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV23ManageFiltersXml) ;
               AV11GridState.FromXml(AV23ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
      }

      protected void E161O2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_Insert )
         {
            CallWebObject(formatLink("productservice.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","ProductServiceId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ProductServiceName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "&ProductServiceDescriptionVar",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ProductServiceTypeName",  "",  "Type",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "ProductServicePicture",  "",  "Picture",  true,  "") ;
         GXt_char3 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProductServiceWWColumnsSelector", out  GXt_char3) ;
         AV18UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserCustomValue)) ) )
         {
            AV20ColumnsSelectorAux.FromXml(AV18UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV20ColumnsSelectorAux, ref  AV19ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV45IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "productservice_Update", out  GXt_boolean1) ;
         AV45IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_Update", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         if ( ! ( AV45IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV47IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "productservice_Delete", out  GXt_boolean1) ;
         AV47IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Delete", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         if ( ! ( AV47IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV49IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "productservice_Insert", out  GXt_boolean1) ;
         AV49IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Insert", AV49IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV49IsAuthorized_Insert, context));
         if ( ! ( AV49IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV22ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ProductServiceWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFProductServiceName = "";
         AssignAttri("", false, "AV27TFProductServiceName", AV27TFProductServiceName);
         AV28TFProductServiceName_Sel = "";
         AssignAttri("", false, "AV28TFProductServiceName_Sel", AV28TFProductServiceName_Sel);
         AV35TFProductServiceTypeName = "";
         AssignAttri("", false, "AV35TFProductServiceTypeName", AV35TFProductServiceTypeName);
         AV36TFProductServiceTypeName_Sel = "";
         AssignAttri("", false, "AV36TFProductServiceTypeName_Sel", AV36TFProductServiceTypeName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV53Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV53Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV53Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV27TFProductServiceName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFProductServiceName", AV27TFProductServiceName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV28TFProductServiceName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFProductServiceName_Sel", AV28TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME") == 0 )
            {
               AV35TFProductServiceTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFProductServiceTypeName", AV35TFProductServiceTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETYPENAME_SEL") == 0 )
            {
               AV36TFProductServiceTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFProductServiceTypeName_Sel", AV36TFProductServiceTypeName_Sel);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProductServiceName_Sel)),  AV28TFProductServiceName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFProductServiceTypeName_Sel)),  AV36TFProductServiceTypeName_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"||"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProductServiceName)),  AV27TFProductServiceName, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFProductServiceTypeName)),  AV35TFProductServiceTypeName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"||"+GXt_char3+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV53Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICENAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProductServiceName)),  0,  AV27TFProductServiceName,  AV27TFProductServiceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProductServiceName_Sel)),  AV28TFProductServiceName_Sel,  AV28TFProductServiceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICETYPENAME",  "Type",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFProductServiceTypeName)),  0,  AV35TFProductServiceTypeName,  AV35TFProductServiceTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFProductServiceTypeName_Sel)),  AV36TFProductServiceTypeName_Sel,  AV36TFProductServiceTypeName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV53Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ProductService";
         AV21Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA1O2( ) ;
         WS1O2( ) ;
         WE1O2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126313671", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("productserviceww.js", "?20249126313673", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_idx;
         edtavProductservicedescriptionvarwithtags_Internalname = "vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS_"+sGXsfl_37_idx;
         edtavProductservicedescriptionvar_Internalname = "vPRODUCTSERVICEDESCRIPTIONVAR_"+sGXsfl_37_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_37_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_37_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_37_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_fel_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_fel_idx;
         edtavProductservicedescriptionvarwithtags_Internalname = "vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS_"+sGXsfl_37_fel_idx;
         edtavProductservicedescriptionvar_Internalname = "vPRODUCTSERVICEDESCRIPTIONVAR_"+sGXsfl_37_fel_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_37_fel_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_37_fel_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_37_fel_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB1O0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProductServiceName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceName_Internalname,(string)A74ProductServiceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductServiceName_Link,(string)"",(string)"",(string)"",(string)edtProductServiceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProductServiceName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavProductservicedescriptionvarwithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductservicedescriptionvarwithtags_Internalname,(string)AV52ProductServiceDescriptionVarWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductservicedescriptionvarwithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavProductservicedescriptionvarwithtags_Visible,(int)edtavProductservicedescriptionvarwithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductservicedescriptionvar_Internalname,(string)AV51ProductServiceDescriptionVar,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+"e201o2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductservicedescriptionvar_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavProductservicedescriptionvar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceDescription_Internalname,(string)A75ProductServiceDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProductServiceTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeName_Internalname,(string)A72ProductServiceTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductServiceTypeName_Link,(string)"",(string)"",(string)"",(string)edtProductServiceTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtProductServiceTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtProductServicePicture_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A77ProductServicePicture_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServicePicture_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServicePicture_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtProductServicePicture_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A77ProductServicePicture_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV44Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV46Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1O2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProductServiceName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavProductservicedescriptionvarwithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProductServiceTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProductServicePicture_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Picture") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A74ProductServiceName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProductServiceName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV52ProductServiceDescriptionVarWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProductservicedescriptionvarwithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProductservicedescriptionvarwithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV51ProductServiceDescriptionVar));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProductservicedescriptionvar_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A75ProductServiceDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A72ProductServiceTypeName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProductServiceTypeName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A77ProductServicePicture));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV44Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         edtavProductservicedescriptionvarwithtags_Internalname = "vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS";
         edtavProductservicedescriptionvar_Internalname = "vPRODUCTSERVICEDESCRIPTIONVAR";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY";
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME";
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE";
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Popover_productservicedescriptionvar_Internalname = "POPOVER_PRODUCTSERVICEDESCRIPTIONVAR";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtProductServiceTypeId_Jsonclick = "";
         edtProductServiceTypeName_Jsonclick = "";
         edtProductServiceTypeName_Link = "";
         edtProductServiceQuantity_Jsonclick = "";
         edtProductServiceDescription_Jsonclick = "";
         edtavProductservicedescriptionvar_Jsonclick = "";
         edtavProductservicedescriptionvar_Enabled = 1;
         edtavProductservicedescriptionvarwithtags_Jsonclick = "";
         edtavProductservicedescriptionvarwithtags_Enabled = 1;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Link = "";
         edtProductServiceId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtProductServicePicture_Visible = -1;
         edtProductServiceTypeName_Visible = -1;
         edtavProductservicedescriptionvarwithtags_Visible = -1;
         edtProductServiceName_Visible = -1;
         edtProductServiceTypeId_Enabled = 0;
         edtProductServicePicture_Enabled = 0;
         edtProductServiceTypeName_Enabled = 0;
         edtProductServiceQuantity_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Popoversingrid = "Popover_ProductServiceDescriptionVar";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "ProductServiceWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic|";
         Ddo_grid_Includedatalist = "T||T|";
         Ddo_grid_Filtertype = "Character||Character|";
         Ddo_grid_Includefilter = "T||T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T||T|";
         Ddo_grid_Columnssortvalues = "1||2|";
         Ddo_grid_Columnids = "1:ProductServiceName|2:ProductServiceDescriptionVar|6:ProductServiceTypeName|7:ProductServicePicture";
         Ddo_grid_Gridinternalname = "";
         Popover_productservicedescriptionvar_Keepopened = Convert.ToBoolean( 0);
         Popover_productservicedescriptionvar_Position = "Bottom";
         Popover_productservicedescriptionvar_Popoverwidth = 400;
         Popover_productservicedescriptionvar_Triggerelement = "Value";
         Popover_productservicedescriptionvar_Trigger = "Click";
         Popover_productservicedescriptionvar_Isgriditem = Convert.ToBoolean( -1);
         Popover_productservicedescriptionvar_Iteminternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Products/Services";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtProductServiceName_Visible","ctrl":"PRODUCTSERVICENAME","prop":"Visible"},{"av":"edtavProductservicedescriptionvarwithtags_Visible","ctrl":"vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS","prop":"Visible"},{"av":"edtProductServiceTypeName_Visible","ctrl":"PRODUCTSERVICETYPENAME","prop":"Visible"},{"av":"edtProductServicePicture_Visible","ctrl":"PRODUCTSERVICEPICTURE","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E121O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E131O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E141O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E191O2","iparms":[{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"A71ProductServiceTypeId","fld":"PRODUCTSERVICETYPEID","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV51ProductServiceDescriptionVar","fld":"vPRODUCTSERVICEDESCRIPTIONVAR"},{"av":"AV44Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV46Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtProductServiceName_Link","ctrl":"PRODUCTSERVICENAME","prop":"Link"},{"av":"edtProductServiceTypeName_Link","ctrl":"PRODUCTSERVICETYPENAME","prop":"Link"},{"av":"AV52ProductServiceDescriptionVarWithTags","fld":"vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E151O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtProductServiceName_Visible","ctrl":"PRODUCTSERVICENAME","prop":"Visible"},{"av":"edtavProductservicedescriptionvarwithtags_Visible","ctrl":"vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS","prop":"Visible"},{"av":"edtProductServiceTypeName_Visible","ctrl":"PRODUCTSERVICETYPENAME","prop":"Visible"},{"av":"edtProductServicePicture_Visible","ctrl":"PRODUCTSERVICEPICTURE","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E111O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtProductServiceName_Visible","ctrl":"PRODUCTSERVICENAME","prop":"Visible"},{"av":"edtavProductservicedescriptionvarwithtags_Visible","ctrl":"vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS","prop":"Visible"},{"av":"edtProductServiceTypeName_Visible","ctrl":"PRODUCTSERVICETYPENAME","prop":"Visible"},{"av":"edtProductServicePicture_Visible","ctrl":"PRODUCTSERVICEPICTURE","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E161O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV28TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV35TFProductServiceTypeName","fld":"vTFPRODUCTSERVICETYPENAME"},{"av":"AV36TFProductServiceTypeName_Sel","fld":"vTFPRODUCTSERVICETYPENAME_SEL"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV48IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV50IsAuthorized_ProductServiceTypeName","fld":"vISAUTHORIZED_PRODUCTSERVICETYPENAME","hsh":true},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtProductServiceName_Visible","ctrl":"PRODUCTSERVICENAME","prop":"Visible"},{"av":"edtavProductservicedescriptionvarwithtags_Visible","ctrl":"vPRODUCTSERVICEDESCRIPTIONVARWITHTAGS","prop":"Visible"},{"av":"edtProductServiceTypeName_Visible","ctrl":"PRODUCTSERVICETYPENAME","prop":"Visible"},{"av":"edtProductServicePicture_Visible","ctrl":"PRODUCTSERVICEPICTURE","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV49IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VPRODUCTSERVICEDESCRIPTIONVAR.CLICK","""{"handler":"E201O2","iparms":[{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION","hsh":true}]""");
         setEventMetadata("VPRODUCTSERVICEDESCRIPTIONVAR.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICETYPEID","""{"handler":"Valid_Productservicetypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV53Pgmname = "";
         AV27TFProductServiceName = "";
         AV28TFProductServiceName_Sel = "";
         AV35TFProductServiceTypeName = "";
         AV36TFProductServiceTypeName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV43GridAppliedFilters = "";
         AV37DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Popover_productservicedescriptionvar_Gridinternalname = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucPopover_productservicedescriptionvar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A74ProductServiceName = "";
         AV52ProductServiceDescriptionVarWithTags = "";
         AV51ProductServiceDescriptionVar = "";
         A75ProductServiceDescription = "";
         A72ProductServiceTypeName = "";
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         AV44Update = "";
         AV46Delete = "";
         lV54Productservicewwds_1_filterfulltext = "";
         lV55Productservicewwds_2_tfproductservicename = "";
         lV57Productservicewwds_4_tfproductservicetypename = "";
         AV54Productservicewwds_1_filterfulltext = "";
         AV56Productservicewwds_3_tfproductservicename_sel = "";
         AV55Productservicewwds_2_tfproductservicename = "";
         AV58Productservicewwds_5_tfproductservicetypename_sel = "";
         AV57Productservicewwds_4_tfproductservicetypename = "";
         H001O2_A71ProductServiceTypeId = new short[1] ;
         H001O2_A40000ProductServicePicture_GXI = new string[] {""} ;
         H001O2_A72ProductServiceTypeName = new string[] {""} ;
         H001O2_A76ProductServiceQuantity = new short[1] ;
         H001O2_A75ProductServiceDescription = new string[] {""} ;
         H001O2_A74ProductServiceName = new string[] {""} ;
         H001O2_A73ProductServiceId = new short[1] ;
         H001O2_A77ProductServicePicture = new string[] {""} ;
         H001O3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV39GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productserviceww__default(),
            new Object[][] {
                new Object[] {
               H001O2_A71ProductServiceTypeId, H001O2_A40000ProductServicePicture_GXI, H001O2_A72ProductServiceTypeName, H001O2_A76ProductServiceQuantity, H001O2_A75ProductServiceDescription, H001O2_A74ProductServiceName, H001O2_A73ProductServiceId, H001O2_A77ProductServicePicture
               }
               , new Object[] {
               H001O3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV53Pgmname = "ProductServiceWW";
         /* GeneXus formulas. */
         AV53Pgmname = "ProductServiceWW";
         edtavProductservicedescriptionvarwithtags_Enabled = 0;
         edtavProductservicedescriptionvar_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV24ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A73ProductServiceId ;
      private short A76ProductServiceQuantity ;
      private short A71ProductServiceTypeId ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Popover_productservicedescriptionvar_Popoverwidth ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavProductservicedescriptionvarwithtags_Enabled ;
      private int edtavProductservicedescriptionvar_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int edtProductServiceQuantity_Enabled ;
      private int edtProductServiceTypeName_Enabled ;
      private int edtProductServicePicture_Enabled ;
      private int edtProductServiceTypeId_Enabled ;
      private int edtProductServiceName_Visible ;
      private int edtavProductservicedescriptionvarwithtags_Visible ;
      private int edtProductServiceTypeName_Visible ;
      private int edtProductServicePicture_Visible ;
      private int AV40PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV59GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41GridCurrentPage ;
      private long AV42GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV53Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Popover_productservicedescriptionvar_Gridinternalname ;
      private string Popover_productservicedescriptionvar_Iteminternalname ;
      private string Popover_productservicedescriptionvar_Trigger ;
      private string Popover_productservicedescriptionvar_Triggerelement ;
      private string Popover_productservicedescriptionvar_Position ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Popoversingrid ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Popover_productservicedescriptionvar_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceName_Internalname ;
      private string edtavProductservicedescriptionvarwithtags_Internalname ;
      private string edtavProductservicedescriptionvar_Internalname ;
      private string edtProductServiceDescription_Internalname ;
      private string edtProductServiceQuantity_Internalname ;
      private string edtProductServiceTypeName_Internalname ;
      private string edtProductServicePicture_Internalname ;
      private string edtProductServiceTypeId_Internalname ;
      private string AV44Update ;
      private string edtavUpdate_Internalname ;
      private string AV46Delete ;
      private string edtavDelete_Internalname ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtProductServiceName_Link ;
      private string edtProductServiceTypeName_Link ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceName_Jsonclick ;
      private string edtavProductservicedescriptionvarwithtags_Jsonclick ;
      private string edtavProductservicedescriptionvar_Jsonclick ;
      private string edtProductServiceDescription_Jsonclick ;
      private string edtProductServiceQuantity_Jsonclick ;
      private string edtProductServiceTypeName_Jsonclick ;
      private string sImgUrl ;
      private string edtProductServiceTypeId_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV45IsAuthorized_Update ;
      private bool AV47IsAuthorized_Delete ;
      private bool AV48IsAuthorized_ProductServiceName ;
      private bool AV50IsAuthorized_ProductServiceTypeName ;
      private bool AV49IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Popover_productservicedescriptionvar_Isgriditem ;
      private bool Popover_productservicedescriptionvar_Keepopened ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private bool A77ProductServicePicture_IsBlob ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV27TFProductServiceName ;
      private string AV28TFProductServiceName_Sel ;
      private string AV35TFProductServiceTypeName ;
      private string AV36TFProductServiceTypeName_Sel ;
      private string AV43GridAppliedFilters ;
      private string A74ProductServiceName ;
      private string AV52ProductServiceDescriptionVarWithTags ;
      private string AV51ProductServiceDescriptionVar ;
      private string A75ProductServiceDescription ;
      private string A72ProductServiceTypeName ;
      private string A40000ProductServicePicture_GXI ;
      private string lV54Productservicewwds_1_filterfulltext ;
      private string lV55Productservicewwds_2_tfproductservicename ;
      private string lV57Productservicewwds_4_tfproductservicetypename ;
      private string AV54Productservicewwds_1_filterfulltext ;
      private string AV56Productservicewwds_3_tfproductservicename_sel ;
      private string AV55Productservicewwds_2_tfproductservicename ;
      private string AV58Productservicewwds_5_tfproductservicetypename_sel ;
      private string AV57Productservicewwds_4_tfproductservicetypename ;
      private string A77ProductServicePicture ;
      private IGxSession AV21Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucPopover_productservicedescriptionvar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV37DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H001O2_A71ProductServiceTypeId ;
      private string[] H001O2_A40000ProductServicePicture_GXI ;
      private string[] H001O2_A72ProductServiceTypeName ;
      private short[] H001O2_A76ProductServiceQuantity ;
      private string[] H001O2_A75ProductServiceDescription ;
      private string[] H001O2_A74ProductServiceName ;
      private short[] H001O2_A73ProductServiceId ;
      private string[] H001O2_A77ProductServicePicture ;
      private long[] H001O3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV38GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV39GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class productserviceww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001O2( IGxContext context ,
                                             string AV54Productservicewwds_1_filterfulltext ,
                                             string AV56Productservicewwds_3_tfproductservicename_sel ,
                                             string AV55Productservicewwds_2_tfproductservicename ,
                                             string AV58Productservicewwds_5_tfproductservicetypename_sel ,
                                             string AV57Productservicewwds_4_tfproductservicetypename ,
                                             string A74ProductServiceName ,
                                             string A72ProductServiceTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ProductServiceTypeId, T1.ProductServicePicture_GXI, T2.ProductServiceTypeName, T1.ProductServiceQuantity, T1.ProductServiceDescription, T1.ProductServiceName, T1.ProductServiceId, T1.ProductServicePicture";
         sFromString = " FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ProductServiceName like '%' || :lV54Productservicewwds_1_filterfulltext) or ( T2.ProductServiceTypeName like '%' || :lV54Productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV55Productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV56Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV56Productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV56Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Productservicewwds_5_tfproductservicetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Productservicewwds_4_tfproductservicetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName like :lV57Productservicewwds_4_tfproductservicetypename)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Productservicewwds_5_tfproductservicetypename_sel)) && ! ( StringUtil.StrCmp(AV58Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName = ( :AV58Productservicewwds_5_tfproductservicetypename_sel))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV58Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProductServiceTypeName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ProductServiceName, T1.ProductServiceId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ProductServiceName DESC, T1.ProductServiceId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ProductServiceTypeName, T1.ProductServiceId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ProductServiceTypeName DESC, T1.ProductServiceId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ProductServiceId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H001O3( IGxContext context ,
                                             string AV54Productservicewwds_1_filterfulltext ,
                                             string AV56Productservicewwds_3_tfproductservicename_sel ,
                                             string AV55Productservicewwds_2_tfproductservicename ,
                                             string AV58Productservicewwds_5_tfproductservicetypename_sel ,
                                             string AV57Productservicewwds_4_tfproductservicetypename ,
                                             string A74ProductServiceName ,
                                             string A72ProductServiceTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ProductServiceName like '%' || :lV54Productservicewwds_1_filterfulltext) or ( T2.ProductServiceTypeName like '%' || :lV54Productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV55Productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV56Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV56Productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV56Productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Productservicewwds_5_tfproductservicetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Productservicewwds_4_tfproductservicetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName like :lV57Productservicewwds_4_tfproductservicetypename)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Productservicewwds_5_tfproductservicetypename_sel)) && ! ( StringUtil.StrCmp(AV58Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceTypeName = ( :AV58Productservicewwds_5_tfproductservicetypename_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV58Productservicewwds_5_tfproductservicetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProductServiceTypeName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
               case 1 :
                     return conditional_H001O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001O2;
          prmH001O2 = new Object[] {
          new ParDef("lV54Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Productservicewwds_2_tfproductservicename",GXType.VarChar,40,0) ,
          new ParDef("AV56Productservicewwds_3_tfproductservicename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Productservicewwds_4_tfproductservicetypename",GXType.VarChar,40,0) ,
          new ParDef("AV58Productservicewwds_5_tfproductservicetypename_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001O3;
          prmH001O3 = new Object[] {
          new ParDef("lV54Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Productservicewwds_2_tfproductservicename",GXType.VarChar,40,0) ,
          new ParDef("AV56Productservicewwds_3_tfproductservicename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Productservicewwds_4_tfproductservicetypename",GXType.VarChar,40,0) ,
          new ParDef("AV58Productservicewwds_5_tfproductservicetypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(2));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
