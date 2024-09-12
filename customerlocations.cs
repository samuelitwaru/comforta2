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
   public class customerlocations : GXDataArea
   {
      public customerlocations( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customerlocations( IGxContext context )
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
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ColumnsSelector);
         AV43Pgmname = GetPar( "Pgmname");
         AV11FilterFullText = GetPar( "FilterFullText");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
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
            return "customerlocations_Execute" ;
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
         PA2J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customerlocations.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Customerlocationsdts", AV8CustomerLocationSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Customerlocationsdts", AV8CustomerLocationSDTs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV12GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV5ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV5ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV15GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV15GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMERLOCATIONSDTS", AV8CustomerLocationSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMERLOCATIONSDTS", AV8CustomerLocationSDTs);
         }
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
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
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2J2( ) ;
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
         return formatLink("customerlocations.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CustomerLocations" ;
      }

      public override string GetPgmdesc( )
      {
         return "Customer Locations" ;
      }

      protected void WB2J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsertlocation_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtninsertlocation_Jsonclick, 7, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112j1_client"+"'", TempTags, "", 2, "HLP_CustomerLocations.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerLocations.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV19ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV11FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV11FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CustomerLocations.htm");
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
               AV33GXV1 = nGXsfl_37_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV13GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV14GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV12GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV5ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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
                  AV33GXV1 = nGXsfl_37_idx;
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

      protected void START2J2( )
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
         Form.Meta.addItem("description", "Customer Locations", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2J0( ) ;
      }

      protected void WS2J2( )
      {
         START2J2( ) ;
         EVT2J2( ) ;
      }

      protected void EVT2J2( )
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
                              E122J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E132J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E142J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E152J2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VUPDATEACTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VUPDATEACTION.CLICK") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV33GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV8CustomerLocationSDTs.Count >= AV33GXV1 ) && ( AV33GXV1 > 0 ) )
                              {
                                 AV8CustomerLocationSDTs.CurrentItem = ((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1));
                                 AV31UpdateAction = cgiGet( edtavUpdateaction_Internalname);
                                 AssignAttri("", false, edtavUpdateaction_Internalname, AV31UpdateAction);
                                 AV10Delete = cgiGet( edtavDelete_Internalname);
                                 AssignAttri("", false, edtavDelete_Internalname, AV10Delete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E162J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E172J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E182J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATEACTION.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192J2 ();
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2J2( )
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

      protected void PA2J2( )
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
                                       short AV20ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV5ColumnsSelector ,
                                       string AV43Pgmname ,
                                       string AV11FilterFullText )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF2J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV43Pgmname = "CustomerLocations";
         edtavCustomerlocationsdts__customerid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationname_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationemail_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationphone_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled = 0;
         edtavUpdateaction_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF2J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E172J2 ();
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            /* Execute user event: Grid.Load */
            E182J2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_37_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E182J2 ();
            }
            wbEnd = 37;
            WB2J0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
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
         return AV8CustomerLocationSDTs.Count ;
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV43Pgmname = "CustomerLocations";
         edtavCustomerlocationsdts__customerid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationname_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationemail_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationphone_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled = 0;
         edtavUpdateaction_Enabled = 0;
         edtavDelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Customerlocationsdts"), AV8CustomerLocationSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV19ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV9DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV5ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vCUSTOMERLOCATIONSDTS"), AV8CustomerLocationSDTs);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV13GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV14GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV12GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
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
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_37_fel_idx = 0;
            while ( nGXsfl_37_fel_idx < nRC_GXsfl_37 )
            {
               nGXsfl_37_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_fel_idx+1);
               sGXsfl_37_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_372( ) ;
               AV33GXV1 = (int)(nGXsfl_37_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV8CustomerLocationSDTs.Count >= AV33GXV1 ) && ( AV33GXV1 > 0 ) )
               {
                  AV8CustomerLocationSDTs.CurrentItem = ((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1));
                  AV31UpdateAction = cgiGet( edtavUpdateaction_Internalname);
                  AV10Delete = cgiGet( edtavDelete_Internalname);
               }
            }
            if ( nGXsfl_37_fel_idx == 0 )
            {
               nGXsfl_37_idx = 1;
               sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
               SubsflControlProps_372( ) ;
            }
            nGXsfl_37_fel_idx = 1;
            /* Read variables values. */
            AV11FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV11FilterFullText", AV11FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E162J2 ();
         if (returnInSub) return;
      }

      protected void E162J2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV17HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Customer Locations";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV9DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV9DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV42Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         /* Using cursor H002J2 */
         pr_default.execute(0, new Object[] {AV42Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CustomerId = H002J2_A1CustomerId[0];
            A18CustomerLocationId = H002J2_A18CustomerLocationId[0];
            A21CustomerLocationEmail = H002J2_A21CustomerLocationEmail[0];
            A134CustomerLocationName = H002J2_A134CustomerLocationName[0];
            A133CustomerLocationDescription = H002J2_A133CustomerLocationDescription[0];
            A22CustomerLocationPhone = H002J2_A22CustomerLocationPhone[0];
            A20CustomerLocationPostalAddress = H002J2_A20CustomerLocationPostalAddress[0];
            A19CustomerLocationVisitingAddres = H002J2_A19CustomerLocationVisitingAddres[0];
            AV30CustomerLocationSDT = new SdtCustomerLocationSDT(context);
            AV30CustomerLocationSDT.gxTpr_Customerlocationid = A18CustomerLocationId;
            AV30CustomerLocationSDT.gxTpr_Customerlocationemail = A21CustomerLocationEmail;
            AV30CustomerLocationSDT.gxTpr_Customerlocationname = A134CustomerLocationName;
            AV30CustomerLocationSDT.gxTpr_Customerlocationdescription = A133CustomerLocationDescription;
            AV30CustomerLocationSDT.gxTpr_Customerlocationphone = A22CustomerLocationPhone;
            AV30CustomerLocationSDT.gxTpr_Customerlocationpostaladdress = A20CustomerLocationPostalAddress;
            AV30CustomerLocationSDT.gxTpr_Customerlocationvisitingaddress = A19CustomerLocationVisitingAddres;
            AV30CustomerLocationSDT.gxTpr_Customerid = A1CustomerId;
            AV8CustomerLocationSDTs.Add(AV30CustomerLocationSDT, 0);
            gx_BV37 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void E172J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV24Session.Get("CustomerLocationsColumnsSelector"), "") != 0 )
         {
            AV7ColumnsSelectorXML = AV24Session.Get("CustomerLocationsColumnsSelector");
            AV5ColumnsSelector.FromXml(AV7ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S142 ();
            if (returnInSub) return;
         }
         edtavCustomerlocationsdts__customerlocationname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV5ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavCustomerlocationsdts__customerlocationname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationsdts__customerlocationname_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavCustomerlocationsdts__customerlocationemail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV5ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavCustomerlocationsdts__customerlocationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationsdts__customerlocationemail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavCustomerlocationsdts__customerlocationphone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV5ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavCustomerlocationsdts__customerlocationphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationsdts__customerlocationphone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV5ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavCustomerlocationsdts__customerlocationpostaladdress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV5ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationsdts__customerlocationpostaladdress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV13GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV13GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV13GridCurrentPage), 10, 0));
         AV14GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV14GridPageCount", StringUtil.LTrimStr( (decimal)(AV14GridPageCount), 10, 0));
         GXt_char2 = AV12GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV43Pgmname, out  GXt_char2) ;
         AV12GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV12GridAppliedFilters", AV12GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ColumnsSelector", AV5ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E132J2( )
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
            AV22PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV22PageToGo) ;
         }
      }

      protected void E142J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E182J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV8CustomerLocationSDTs.Count )
         {
            AV8CustomerLocationSDTs.CurrentItem = ((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1));
            AV31UpdateAction = "<i class=\"fas fa-pen\"></i>";
            AssignAttri("", false, edtavUpdateaction_Internalname, AV31UpdateAction);
            AV10Delete = "<i class=\"disabledIconBtn fas fa-xmark\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV10Delete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_372( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
            {
               DoAjaxLoad(37, GridRow);
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E152J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV7ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV5ColumnsSelector.FromJSonString(AV7ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CustomerLocationsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV7ColumnsSelectorXML)) ? "" : AV5ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ColumnsSelector", AV5ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E122J2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S132 ();
            if (returnInSub) return;
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerLocationsFilters")),UrlEncode(StringUtil.RTrim(AV43Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerLocationsFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV21ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CustomerLocationsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV21ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV43Pgmname+"GridState",  AV21ManageFiltersXml) ;
               AV15GridState.FromXml(AV21ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5ColumnsSelector", AV5ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ManageFiltersData", AV19ManageFiltersData);
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV5ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV5ColumnsSelector,  "CustomerLocationSDTs__CustomerLocationName",  "",  "Location Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV5ColumnsSelector,  "CustomerLocationSDTs__CustomerLocationEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV5ColumnsSelector,  "CustomerLocationSDTs__CustomerLocationPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV5ColumnsSelector,  "CustomerLocationSDTs__CustomerLocationVisitingAddress",  "",  "Visiting Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV5ColumnsSelector,  "CustomerLocationSDTs__CustomerLocationPostalAddress",  "",  "Postal Address",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CustomerLocationsColumnsSelector", out  GXt_char2) ;
         AV28UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV6ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV6ColumnsSelectorAux, ref  AV5ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV19ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CustomerLocationsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV19ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV11FilterFullText = "";
         AssignAttri("", false, "AV11FilterFullText", AV11FilterFullText);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get(AV43Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV43Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV24Session.Get(AV43Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV44GXV9 = 1;
         while ( AV44GXV9 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV44GXV9));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV11FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV11FilterFullText", AV11FilterFullText);
            }
            AV44GXV9 = (int)(AV44GXV9+1);
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV24Session.Get(AV43Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV11FilterFullText)),  0,  AV11FilterFullText,  AV11FilterFullText,  false,  "",  "") ;
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV43Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void E192J2( )
      {
         AV33GXV1 = (int)(nGXsfl_37_idx+GRID_nFirstRecordOnPage);
         if ( ( AV33GXV1 > 0 ) && ( AV8CustomerLocationSDTs.Count >= AV33GXV1 ) )
         {
            AV8CustomerLocationSDTs.CurrentItem = ((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1));
         }
         /* Updateaction_Click Routine */
         returnInSub = false;
         CallWebObject(formatLink("updatelocation.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.BoolToStr(false)),UrlEncode(StringUtil.LTrimStr(((SdtCustomerLocationSDT)(AV8CustomerLocationSDTs.CurrentItem)).gxTpr_Customerlocationid,4,0))}, new string[] {"PreviousStep","CurrentStep","GoingBack","LocationId"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8CustomerLocationSDTs", AV8CustomerLocationSDTs);
         nGXsfl_37_bak_idx = nGXsfl_37_idx;
         gxgrGrid_refresh( subGrid_Rows, AV20ManageFiltersExecutionStep, AV5ColumnsSelector, AV43Pgmname, AV11FilterFullText) ;
         nGXsfl_37_idx = nGXsfl_37_bak_idx;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
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
         PA2J2( ) ;
         WS2J2( ) ;
         WE2J2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126314118", true, true);
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
         context.AddJavascriptSource("customerlocations.js", "?20249126314118", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
         edtavCustomerlocationsdts__customerid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERID_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationname_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONID_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationemail_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationphone_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS_"+sGXsfl_37_idx;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_37_idx;
         edtavUpdateaction_Internalname = "vUPDATEACTION_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavCustomerlocationsdts__customerid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERID_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationname_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONID_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationemail_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationphone_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS_"+sGXsfl_37_fel_idx;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS_"+sGXsfl_37_fel_idx;
         edtavUpdateaction_Internalname = "vUPDATEACTION_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB2J0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerid), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCustomerlocationsdts__customerid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavCustomerlocationsdts__customerid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavCustomerlocationsdts__customerlocationname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationname_Internalname,((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavCustomerlocationsdts__customerlocationname_Visible,(int)edtavCustomerlocationsdts__customerlocationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationid), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCustomerlocationsdts__customerlocationid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavCustomerlocationsdts__customerlocationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavCustomerlocationsdts__customerlocationemail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationemail_Internalname,((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavCustomerlocationsdts__customerlocationemail_Visible,(int)edtavCustomerlocationsdts__customerlocationemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavCustomerlocationsdts__customerlocationphone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationphone_Internalname,StringUtil.RTrim( ((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavCustomerlocationsdts__customerlocationphone_Visible,(int)edtavCustomerlocationsdts__customerlocationphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname,((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationvisitingaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible,(int)edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavCustomerlocationsdts__customerlocationpostaladdress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname,((SdtCustomerLocationSDT)AV8CustomerLocationSDTs.Item(AV33GXV1)).gxTpr_Customerlocationpostaladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomerlocationsdts__customerlocationpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavCustomerlocationsdts__customerlocationpostaladdress_Visible,(int)edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdateaction_Internalname,StringUtil.RTrim( AV31UpdateAction),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"","'"+""+"'"+",false,"+"'"+"EVUPDATEACTION.CLICK."+sGXsfl_37_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUpdateaction_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdateaction_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV10Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2J2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavCustomerlocationsdts__customerlocationname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Location Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavCustomerlocationsdts__customerlocationemail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavCustomerlocationsdts__customerlocationphone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Visiting Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavCustomerlocationsdts__customerlocationpostaladdress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Postal Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationemail_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationemail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationphone_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationphone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomerlocationsdts__customerlocationpostaladdress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31UpdateAction)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdateaction_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV10Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
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
         bttBtninsertlocation_Internalname = "BTNINSERTLOCATION";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavCustomerlocationsdts__customerid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERID";
         edtavCustomerlocationsdts__customerlocationname_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME";
         edtavCustomerlocationsdts__customerlocationid_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONID";
         edtavCustomerlocationsdts__customerlocationemail_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL";
         edtavCustomerlocationsdts__customerlocationphone_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE";
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS";
         edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname = "CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS";
         edtavUpdateaction_Internalname = "vUPDATEACTION";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtavDelete_Enabled = 1;
         edtavUpdateaction_Jsonclick = "";
         edtavUpdateaction_Enabled = 1;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Visible = -1;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible = -1;
         edtavCustomerlocationsdts__customerlocationphone_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationphone_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationphone_Visible = -1;
         edtavCustomerlocationsdts__customerlocationemail_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationemail_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationemail_Visible = -1;
         edtavCustomerlocationsdts__customerlocationid_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationname_Jsonclick = "";
         edtavCustomerlocationsdts__customerlocationname_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationname_Visible = -1;
         edtavCustomerlocationsdts__customerid_Jsonclick = "";
         edtavCustomerlocationsdts__customerid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Visible = -1;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible = -1;
         edtavCustomerlocationsdts__customerlocationphone_Visible = -1;
         edtavCustomerlocationsdts__customerlocationemail_Visible = -1;
         edtavCustomerlocationsdts__customerlocationname_Visible = -1;
         subGrid_Sortable = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled = -1;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled = -1;
         edtavCustomerlocationsdts__customerlocationphone_Enabled = -1;
         edtavCustomerlocationsdts__customerlocationemail_Enabled = -1;
         edtavCustomerlocationsdts__customerlocationid_Enabled = -1;
         edtavCustomerlocationsdts__customerlocationname_Enabled = -1;
         edtavCustomerlocationsdts__customerid_Enabled = -1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Columnssortvalues = "||||";
         Ddo_grid_Columnids = "1:CustomerLocationSDTs__CustomerLocationName|3:CustomerLocationSDTs__CustomerLocationEmail|4:CustomerLocationSDTs__CustomerLocationPhone|5:CustomerLocationSDTs__CustomerLocationVisitingAddress|6:CustomerLocationSDTs__CustomerLocationPostalAddress";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = "Customer Locations";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS","prop":"Visible"},{"av":"AV13GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV14GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV12GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E132J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E142J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E182J2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV31UpdateAction","fld":"vUPDATEACTION"},{"av":"AV10Delete","fld":"vDELETE"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E152J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS","prop":"Visible"},{"av":"AV13GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV14GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV12GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E122J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONNAME","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONEMAIL","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPHONE","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONVISITINGADDRESS","prop":"Visible"},{"ctrl":"CUSTOMERLOCATIONSDTS__CUSTOMERLOCATIONPOSTALADDRESS","prop":"Visible"},{"av":"AV13GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV14GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV12GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV19ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERTLOCATION'","""{"handler":"E112J1","iparms":[]}""");
         setEventMetadata("VUPDATEACTION.CLICK","""{"handler":"E192J2","iparms":[{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37},{"av":"GRID_nEOF"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV5ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11FilterFullText","fld":"vFILTERFULLTEXT"}]""");
         setEventMetadata("VUPDATEACTION.CLICK",""","oparms":[{"av":"AV8CustomerLocationSDTs","fld":"vCUSTOMERLOCATIONSDTS","grid":37},{"av":"nGXsfl_37_idx","ctrl":"GRID","prop":"GridCurrRow","grid":37},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_37","ctrl":"GRID","prop":"GridRC","grid":37}]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV5ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV43Pgmname = "";
         AV11FilterFullText = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8CustomerLocationSDTs = new GXBaseCollection<SdtCustomerLocationSDT>( context, "CustomerLocationSDT", "Comforta2");
         AV19ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridAppliedFilters = "";
         AV9DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsertlocation_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31UpdateAction = "";
         AV10Delete = "";
         AV17HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H002J2_A1CustomerId = new short[1] ;
         H002J2_A18CustomerLocationId = new short[1] ;
         H002J2_A21CustomerLocationEmail = new string[] {""} ;
         H002J2_A134CustomerLocationName = new string[] {""} ;
         H002J2_A133CustomerLocationDescription = new string[] {""} ;
         H002J2_A22CustomerLocationPhone = new string[] {""} ;
         H002J2_A20CustomerLocationPostalAddress = new string[] {""} ;
         H002J2_A19CustomerLocationVisitingAddres = new string[] {""} ;
         A21CustomerLocationEmail = "";
         A134CustomerLocationName = "";
         A133CustomerLocationDescription = "";
         A22CustomerLocationPhone = "";
         A20CustomerLocationPostalAddress = "";
         A19CustomerLocationVisitingAddres = "";
         AV30CustomerLocationSDT = new SdtCustomerLocationSDT(context);
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV7ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV21ManageFiltersXml = "";
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV6ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customerlocations__default(),
            new Object[][] {
                new Object[] {
               H002J2_A1CustomerId, H002J2_A18CustomerLocationId, H002J2_A21CustomerLocationEmail, H002J2_A134CustomerLocationName, H002J2_A133CustomerLocationDescription, H002J2_A22CustomerLocationPhone, H002J2_A20CustomerLocationPostalAddress, H002J2_A19CustomerLocationVisitingAddres
               }
            }
         );
         AV43Pgmname = "CustomerLocations";
         /* GeneXus formulas. */
         AV43Pgmname = "CustomerLocations";
         edtavCustomerlocationsdts__customerid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationname_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationid_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationemail_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationphone_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled = 0;
         edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled = 0;
         edtavUpdateaction_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV20ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV42Udparg1 ;
      private short A1CustomerId ;
      private short A18CustomerLocationId ;
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
      private int edtavFilterfulltext_Enabled ;
      private int AV33GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavCustomerlocationsdts__customerid_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationname_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationid_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationemail_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationphone_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationvisitingaddress_Enabled ;
      private int edtavCustomerlocationsdts__customerlocationpostaladdress_Enabled ;
      private int edtavUpdateaction_Enabled ;
      private int edtavDelete_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_37_fel_idx=1 ;
      private int edtavCustomerlocationsdts__customerlocationname_Visible ;
      private int edtavCustomerlocationsdts__customerlocationemail_Visible ;
      private int edtavCustomerlocationsdts__customerlocationphone_Visible ;
      private int edtavCustomerlocationsdts__customerlocationvisitingaddress_Visible ;
      private int edtavCustomerlocationsdts__customerlocationpostaladdress_Visible ;
      private int AV22PageToGo ;
      private int AV44GXV9 ;
      private int nGXsfl_37_bak_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV13GridCurrentPage ;
      private long AV14GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV43Pgmname ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Fixable ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
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
      private string bttBtninsertlocation_Internalname ;
      private string bttBtninsertlocation_Jsonclick ;
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
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV31UpdateAction ;
      private string edtavUpdateaction_Internalname ;
      private string AV10Delete ;
      private string edtavDelete_Internalname ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string A22CustomerLocationPhone ;
      private string edtavCustomerlocationsdts__customerlocationname_Internalname ;
      private string edtavCustomerlocationsdts__customerlocationemail_Internalname ;
      private string edtavCustomerlocationsdts__customerlocationphone_Internalname ;
      private string edtavCustomerlocationsdts__customerlocationvisitingaddress_Internalname ;
      private string edtavCustomerlocationsdts__customerlocationpostaladdress_Internalname ;
      private string GXt_char2 ;
      private string edtavCustomerlocationsdts__customerid_Internalname ;
      private string edtavCustomerlocationsdts__customerlocationid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavCustomerlocationsdts__customerid_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationname_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationid_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationemail_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationphone_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationvisitingaddress_Jsonclick ;
      private string edtavCustomerlocationsdts__customerlocationpostaladdress_Jsonclick ;
      private string edtavUpdateaction_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV37 ;
      private bool gx_refresh_fired ;
      private string AV7ColumnsSelectorXML ;
      private string AV21ManageFiltersXml ;
      private string AV28UserCustomValue ;
      private string AV11FilterFullText ;
      private string AV12GridAppliedFilters ;
      private string A21CustomerLocationEmail ;
      private string A134CustomerLocationName ;
      private string A133CustomerLocationDescription ;
      private string A20CustomerLocationPostalAddress ;
      private string A19CustomerLocationVisitingAddres ;
      private IGxSession AV24Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV17HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV5ColumnsSelector ;
      private GXBaseCollection<SdtCustomerLocationSDT> AV8CustomerLocationSDTs ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV19ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV9DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV15GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private IDataStoreProvider pr_default ;
      private short[] H002J2_A1CustomerId ;
      private short[] H002J2_A18CustomerLocationId ;
      private string[] H002J2_A21CustomerLocationEmail ;
      private string[] H002J2_A134CustomerLocationName ;
      private string[] H002J2_A133CustomerLocationDescription ;
      private string[] H002J2_A22CustomerLocationPhone ;
      private string[] H002J2_A20CustomerLocationPostalAddress ;
      private string[] H002J2_A19CustomerLocationVisitingAddres ;
      private SdtCustomerLocationSDT AV30CustomerLocationSDT ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV6ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class customerlocations__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002J2;
          prmH002J2 = new Object[] {
          new ParDef("AV42Udparg1",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002J2", "SELECT CustomerId, CustomerLocationId, CustomerLocationEmail, CustomerLocationName, CustomerLocationDescription, CustomerLocationPhone, CustomerLocationPostalAddress, CustomerLocationVisitingAddres FROM CustomerLocation WHERE CustomerId = :AV42Udparg1 ORDER BY CustomerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
