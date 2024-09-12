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
   public class locationgensuppliers : GXDataArea
   {
      public locationgensuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public locationgensuppliers( IGxContext context )
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
         dynavLocationoptions = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTIONS") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTIONS2L2( ) ;
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
         nRC_GXsfl_45 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_45"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_45_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_45_idx = GetPar( "sGXsfl_45_idx");
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
         AV22ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV17ColumnsSelector);
         AV41Pgmname = GetPar( "Pgmname");
         AV13FilterFullText = GetPar( "FilterFullText");
         A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
         AV43Udparg1 = (short)(Math.Round(NumberUtil.Val( GetPar( "Udparg1"), "."), 18, MidpointRounding.ToEven));
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLocationId"), "."), 18, MidpointRounding.ToEven));
         dynavLocationoptions.FromJSonString( GetNextPar( ));
         AV30LocationOptions = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOptions"), "."), 18, MidpointRounding.ToEven));
         A64Supplier_GenId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_GenId"), "."), 18, MidpointRounding.ToEven));
         A65Supplier_GenKvKNumber = GetPar( "Supplier_GenKvKNumber");
         A66Supplier_GenCompanyName = GetPar( "Supplier_GenCompanyName");
         A69Supplier_GenContactName = GetPar( "Supplier_GenContactName");
         n69Supplier_GenContactName = false;
         A70Supplier_GenContactPhone = GetPar( "Supplier_GenContactPhone");
         n70Supplier_GenContactPhone = false;
         A68Supplier_GenPostalAddress = GetPar( "Supplier_GenPostalAddress");
         n68Supplier_GenPostalAddress = false;
         A67Supplier_GenVisitingAddress = GetPar( "Supplier_GenVisitingAddress");
         n67Supplier_GenVisitingAddress = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
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
            return "locationgensuppliers_Execute" ;
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
         PA2L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2L2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("locationgensuppliers.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43Udparg1), "9999"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Locationgensupplierssdts", AV14LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Locationgensupplierssdts", AV14LocationGenSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_45", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_45), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV20ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV20ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV27GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV17ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV17ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43Udparg1), "9999"), context));
         GxWebStd.gx_hidden_field( context, "CUSTOMERLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENKVKNUMBER", A65Supplier_GenKvKNumber);
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCOMPANYNAME", A66Supplier_GenCompanyName);
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTNAME", A69Supplier_GenContactName);
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENCONTACTPHONE", StringUtil.RTrim( A70Supplier_GenContactPhone));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENPOSTALADDRESS", A68Supplier_GenPostalAddress);
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENVISITINGADDRESS", A67Supplier_GenVisitingAddress);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONGENSUPPLIERSSDTS", AV14LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONGENSUPPLIERSSDTS", AV14LocationGenSuppliersSDTs);
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
            WE2L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2L2( ) ;
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
         return formatLink("locationgensuppliers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LocationGenSuppliers" ;
      }

      public override string GetPgmdesc( )
      {
         return "My General Suppliers" ;
      }

      protected void WB2L0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsertgensupplier_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", "Insert", bttBtninsertgensupplier_Jsonclick, 7, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112l1_client"+"'", TempTags, "", 2, "HLP_LocationGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LocationGenSuppliers.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV20ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_45_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_LocationGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelocationoptions_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_6_25", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklocationoptions_Internalname, "", "", "", lblTextblocklocationoptions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LocationGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_93_75", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoptions_Internalname, "Location Options", "col-sm-3 AddressAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_45_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoptions, dynavLocationoptions_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30LocationOptions), 4, 0)), 1, dynavLocationoptions_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoptions.Visible, dynavLocationoptions.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_LocationGenSuppliers.htm");
            dynavLocationoptions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30LocationOptions), 4, 0));
            AssignProp("", false, dynavLocationoptions_Internalname, "Values", (string)(dynavLocationoptions.ToJavascriptSource()), true);
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
            StartGridControl45( ) ;
         }
         if ( wbEnd == 45 )
         {
            wbEnd = 0;
            nRC_GXsfl_45 = (int)(nGXsfl_45_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV33GXV1 = nGXsfl_45_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV25GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV26GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV27GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV17ColumnsSelector);
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
         if ( wbEnd == 45 )
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
                  AV33GXV1 = nGXsfl_45_idx;
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

      protected void START2L2( )
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
         Form.Meta.addItem("description", "My General Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2L0( ) ;
      }

      protected void WS2L2( )
      {
         START2L2( ) ;
         EVT2L2( ) ;
      }

      protected void EVT2L2( )
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
                              E122L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E132L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E142L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E152L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONOPTIONS.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E162L2 ();
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
                              nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
                              SubsflControlProps_452( ) ;
                              AV33GXV1 = (int)(nGXsfl_45_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV14LocationGenSuppliersSDTs.Count >= AV33GXV1 ) && ( AV33GXV1 > 0 ) )
                              {
                                 AV14LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1));
                                 AV29Delete = cgiGet( edtavDelete_Internalname);
                                 AssignAttri("", false, edtavDelete_Internalname, AV29Delete);
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
                                    E172L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E182L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E192L2 ();
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

      protected void WE2L2( )
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

      protected void PA2L2( )
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

      protected void GXDLVvLOCATIONOPTIONS2L2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTIONS_data2L2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTIONS_html2L2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTIONS_data2L2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoptions.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLocationoptions.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONOPTIONS_data2L2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Select Location");
         /* Using cursor H002L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H002L2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002L2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H002L2_A134CustomerLocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_452( ) ;
         while ( nGXsfl_45_idx <= nRC_GXsfl_45 )
         {
            sendrow_452( ) ;
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV22ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV17ColumnsSelector ,
                                       string AV41Pgmname ,
                                       string AV13FilterFullText ,
                                       short A1CustomerId ,
                                       short AV43Udparg1 ,
                                       short A18CustomerLocationId ,
                                       short AV30LocationOptions ,
                                       short A64Supplier_GenId ,
                                       string A65Supplier_GenKvKNumber ,
                                       string A66Supplier_GenCompanyName ,
                                       string A69Supplier_GenContactName ,
                                       string A70Supplier_GenContactPhone ,
                                       string A68Supplier_GenPostalAddress ,
                                       string A67Supplier_GenVisitingAddress )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2L2( ) ;
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
            GXVvLOCATIONOPTIONS_html2L2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoptions.ItemCount > 0 )
         {
            AV30LocationOptions = (short)(Math.Round(NumberUtil.Val( dynavLocationoptions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30LocationOptions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30LocationOptions", StringUtil.LTrimStr( (decimal)(AV30LocationOptions), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoptions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30LocationOptions), 4, 0));
            AssignProp("", false, dynavLocationoptions_Internalname, "Values", dynavLocationoptions.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV41Pgmname = "LocationGenSuppliers";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF2L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 45;
         /* Execute user event: Refresh */
         E182L2 ();
         nGXsfl_45_idx = 1;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         bGXsfl_45_Refreshing = true;
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
            SubsflControlProps_452( ) ;
            /* Execute user event: Grid.Load */
            E192L2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_45_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E192L2 ();
            }
            wbEnd = 45;
            WB2L0( ) ;
         }
         bGXsfl_45_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2L2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43Udparg1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43Udparg1), "9999"), context));
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
         return AV14LocationGenSuppliersSDTs.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV41Pgmname = "LocationGenSuppliers";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavDelete_Enabled = 0;
         GXVvLOCATIONOPTIONS_html2L2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Locationgensupplierssdts"), AV14LocationGenSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV20ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV23DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV17ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONGENSUPPLIERSSDTS"), AV14LocationGenSuppliersSDTs);
            /* Read saved values. */
            nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), ".", ","), 18, MidpointRounding.ToEven));
            AV25GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV26GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV27GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_45_fel_idx = 0;
            while ( nGXsfl_45_fel_idx < nRC_GXsfl_45 )
            {
               nGXsfl_45_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_fel_idx+1);
               sGXsfl_45_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_452( ) ;
               AV33GXV1 = (int)(nGXsfl_45_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV14LocationGenSuppliersSDTs.Count >= AV33GXV1 ) && ( AV33GXV1 > 0 ) )
               {
                  AV14LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1));
                  AV29Delete = cgiGet( edtavDelete_Internalname);
               }
            }
            if ( nGXsfl_45_fel_idx == 0 )
            {
               nGXsfl_45_idx = 1;
               sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
               SubsflControlProps_452( ) ;
            }
            nGXsfl_45_fel_idx = 1;
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            dynavLocationoptions.Name = dynavLocationoptions_Internalname;
            dynavLocationoptions.CurrentValue = cgiGet( dynavLocationoptions_Internalname);
            AV30LocationOptions = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoptions_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30LocationOptions", StringUtil.LTrimStr( (decimal)(AV30LocationOptions), 4, 0));
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
         E172L2 ();
         if (returnInSub) return;
      }

      protected void E172L2( )
      {
         /* Start Routine */
         returnInSub = false;
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
            if (returnInSub) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "My General Suppliers";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV23DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV23DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_SdtGAMUser2 = AV32GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser2) ;
         AV32GAMUser = GXt_SdtGAMUser2;
         if ( AV32GAMUser.checkrole("Customer Manager") )
         {
            dynavLocationoptions.Visible = 1;
            AssignProp("", false, dynavLocationoptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoptions.Visible), 5, 0), true);
         }
         else
         {
            if ( AV32GAMUser.checkrole("Receptionist") )
            {
               GXt_int3 = AV30LocationOptions;
               new getreceptionistlocationid(context ).execute( out  GXt_int3) ;
               AV30LocationOptions = GXt_int3;
               AssignAttri("", false, "AV30LocationOptions", StringUtil.LTrimStr( (decimal)(AV30LocationOptions), 4, 0));
               dynavLocationoptions.Visible = 0;
               AssignProp("", false, dynavLocationoptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoptions.Visible), 5, 0), true);
            }
         }
      }

      protected void E182L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV22ManageFiltersExecutionStep == 1 )
         {
            AV22ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV22ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV22ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV22ManageFiltersExecutionStep == 2 )
         {
            AV22ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV22ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV22ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV19Session.Get("LocationGenSuppliersColumnsSelector"), "") != 0 )
         {
            AV15ColumnsSelectorXML = AV19Session.Get("LocationGenSuppliersColumnsSelector");
            AV17ColumnsSelector.FromXml(AV15ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S142 ();
            if (returnInSub) return;
         }
         edtavLocationgensupplierssdts__supplier_gencompanyname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV17ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavLocationgensupplierssdts__supplier_gencontactname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV17ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLocationgensupplierssdts__supplier_gencontactname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavLocationgensupplierssdts__supplier_gencontactphone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV17ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV17ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV17ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible), 5, 0), !bGXsfl_45_Refreshing);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV25GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV25GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV25GridCurrentPage), 10, 0));
         AV26GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV26GridPageCount", StringUtil.LTrimStr( (decimal)(AV26GridPageCount), 10, 0));
         GXt_char4 = AV27GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV41Pgmname, out  GXt_char4) ;
         AV27GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV27GridAppliedFilters", AV27GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ColumnsSelector", AV17ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ManageFiltersData", AV20ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14LocationGenSuppliersSDTs", AV14LocationGenSuppliersSDTs);
      }

      protected void E132L2( )
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
            AV24PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV24PageToGo) ;
         }
      }

      protected void E142L2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E192L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV14LocationGenSuppliersSDTs.Count )
         {
            AV14LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1));
            AV29Delete = "<i class=\"disabledIconBtn fas fa-xmark\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV29Delete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 45;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_452( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_45_Refreshing )
            {
               DoAjaxLoad(45, GridRow);
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E152L2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV15ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV17ColumnsSelector.FromJSonString(AV15ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "LocationGenSuppliersColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV15ColumnsSelectorXML)) ? "" : AV17ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ColumnsSelector", AV17ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ManageFiltersData", AV20ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14LocationGenSuppliersSDTs", AV14LocationGenSuppliersSDTs);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
      }

      protected void E122L2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("LocationGenSuppliersFilters")),UrlEncode(StringUtil.RTrim(AV41Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV22ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV22ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV22ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("LocationGenSuppliersFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV22ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV22ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV22ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char4 = AV21ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "LocationGenSuppliersFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV21ManageFiltersXml = GXt_char4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV41Pgmname+"GridState",  AV21ManageFiltersXml) ;
               AV11GridState.FromXml(AV21ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ColumnsSelector", AV17ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ManageFiltersData", AV20ManageFiltersData);
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14LocationGenSuppliersSDTs", AV14LocationGenSuppliersSDTs);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV14LocationGenSuppliersSDTs.Clear();
         gx_BV45 = true;
         AV43Udparg1 = new getloggedinusercustomerid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV30LocationOptions ,
                                              A18CustomerLocationId ,
                                              AV43Udparg1 ,
                                              A1CustomerId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H002L3 */
         pr_default.execute(1, new Object[] {AV43Udparg1, AV30LocationOptions});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18CustomerLocationId = H002L3_A18CustomerLocationId[0];
            A1CustomerId = H002L3_A1CustomerId[0];
            A64Supplier_GenId = H002L3_A64Supplier_GenId[0];
            A65Supplier_GenKvKNumber = H002L3_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = H002L3_A66Supplier_GenCompanyName[0];
            A69Supplier_GenContactName = H002L3_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = H002L3_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = H002L3_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = H002L3_n70Supplier_GenContactPhone[0];
            A68Supplier_GenPostalAddress = H002L3_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = H002L3_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = H002L3_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = H002L3_n67Supplier_GenVisitingAddress[0];
            A65Supplier_GenKvKNumber = H002L3_A65Supplier_GenKvKNumber[0];
            A66Supplier_GenCompanyName = H002L3_A66Supplier_GenCompanyName[0];
            A69Supplier_GenContactName = H002L3_A69Supplier_GenContactName[0];
            n69Supplier_GenContactName = H002L3_n69Supplier_GenContactName[0];
            A70Supplier_GenContactPhone = H002L3_A70Supplier_GenContactPhone[0];
            n70Supplier_GenContactPhone = H002L3_n70Supplier_GenContactPhone[0];
            A68Supplier_GenPostalAddress = H002L3_A68Supplier_GenPostalAddress[0];
            n68Supplier_GenPostalAddress = H002L3_n68Supplier_GenPostalAddress[0];
            A67Supplier_GenVisitingAddress = H002L3_A67Supplier_GenVisitingAddress[0];
            n67Supplier_GenVisitingAddress = H002L3_n67Supplier_GenVisitingAddress[0];
            AV31LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_genid = A64Supplier_GenId;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_genkvknumber = A65Supplier_GenKvKNumber;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_gencompanyname = A66Supplier_GenCompanyName;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_gencontactname = A69Supplier_GenContactName;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_gencontactphone = A70Supplier_GenContactPhone;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_genpostaladdress = A68Supplier_GenPostalAddress;
            AV31LocationGenSuppliersSDT.gxTpr_Supplier_genvisitingaddress = A67Supplier_GenVisitingAddress;
            AV14LocationGenSuppliersSDTs.Add(AV31LocationGenSuppliersSDT, 0);
            gx_BV45 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S142( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV17ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV17ColumnsSelector,  "LocationGenSuppliersSDTs__Supplier_GenCompanyName",  "",  "Company",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV17ColumnsSelector,  "LocationGenSuppliersSDTs__Supplier_GenContactName",  "",  "Contact Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV17ColumnsSelector,  "LocationGenSuppliersSDTs__Supplier_GenContactPhone",  "",  "Contact Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV17ColumnsSelector,  "LocationGenSuppliersSDTs__Supplier_GenVisitingAddress",  "",  "Visiting Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV17ColumnsSelector,  "LocationGenSuppliersSDTs__Supplier_GenPostalAddress",  "",  "Postal Address",  true,  "") ;
         GXt_char4 = AV16UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "LocationGenSuppliersColumnsSelector", out  GXt_char4) ;
         AV16UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV16UserCustomValue)) ) )
         {
            AV18ColumnsSelectorAux.FromXml(AV16UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV18ColumnsSelectorAux, ref  AV17ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV20ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "LocationGenSuppliersFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV20ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV19Session.Get(AV41Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV41Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV19Session.Get(AV41Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV44GXV9 = 1;
         while ( AV44GXV9 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV44GXV9));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            }
            AV44GXV9 = (int)(AV44GXV9+1);
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV19Session.Get(AV41Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV41Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void E162L2( )
      {
         /* Locationoptions_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV45 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14LocationGenSuppliersSDTs", AV14LocationGenSuppliersSDTs);
            nGXsfl_45_bak_idx = nGXsfl_45_idx;
            gxgrGrid_refresh( subGrid_Rows, AV22ManageFiltersExecutionStep, AV17ColumnsSelector, AV41Pgmname, AV13FilterFullText, A1CustomerId, AV43Udparg1, A18CustomerLocationId, AV30LocationOptions, A64Supplier_GenId, A65Supplier_GenKvKNumber, A66Supplier_GenCompanyName, A69Supplier_GenContactName, A70Supplier_GenContactPhone, A68Supplier_GenPostalAddress, A67Supplier_GenVisitingAddress) ;
            nGXsfl_45_idx = nGXsfl_45_bak_idx;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
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
         PA2L2( ) ;
         WS2L2( ) ;
         WE2L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126314988", true, true);
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
         context.AddJavascriptSource("locationgensuppliers.js", "?20249126314989", false, true);
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

      protected void SubsflControlProps_452( )
      {
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_45_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_45_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_45_idx;
      }

      protected void SubsflControlProps_fel_452( )
      {
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_45_fel_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_45_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_45_fel_idx;
      }

      protected void sendrow_452( )
      {
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         WB2L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_45_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_45_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_45_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genid), 4, 0, ".", "")),StringUtil.LTrim( ((edtavLocationgensupplierssdts__supplier_genid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLocationgensupplierssdts__supplier_gencompanyname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname,((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_gencompanyname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLocationgensupplierssdts__supplier_gencompanyname_Visible,(int)edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname,((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genkvknumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLocationgensupplierssdts__supplier_gencontactname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactname_Internalname,((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_gencontactname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLocationgensupplierssdts__supplier_gencontactname_Visible,(int)edtavLocationgensupplierssdts__supplier_gencontactname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLocationgensupplierssdts__supplier_gencontactphone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname,StringUtil.RTrim( ((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_gencontactphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLocationgensupplierssdts__supplier_gencontactphone_Visible,(int)edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname,((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genvisitingaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible,(int)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname,((SdtLocationGenSuppliersSDT)AV14LocationGenSuppliersSDTs.Item(AV33GXV1)).gxTpr_Supplier_genpostaladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible,(int)edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_45_idx + "',45)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV29Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         /* End function sendrow_452 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoptions.Name = "vLOCATIONOPTIONS";
         dynavLocationoptions.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl45( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"45\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLocationgensupplierssdts__supplier_gencompanyname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Company") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLocationgensupplierssdts__supplier_gencontactname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Contact Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLocationgensupplierssdts__supplier_gencontactphone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Contact Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Visiting Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Postal Address") ;
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29Delete)));
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
         bttBtninsertgensupplier_Internalname = "BTNINSERTGENSUPPLIER";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         lblTextblocklocationoptions_Internalname = "TEXTBLOCKLOCATIONOPTIONS";
         dynavLocationoptions_Internalname = "vLOCATIONOPTIONS";
         divUnnamedtablelocationoptions_Internalname = "UNNAMEDTABLELOCATIONOPTIONS";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER";
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS";
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
         edtavDelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible = -1;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible = -1;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Visible = -1;
         edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Visible = -1;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Visible = -1;
         edtavLocationgensupplierssdts__supplier_genid_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible = -1;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible = -1;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Visible = -1;
         edtavLocationgensupplierssdts__supplier_gencontactname_Visible = -1;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Visible = -1;
         subGrid_Sortable = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = -1;
         dynavLocationoptions_Jsonclick = "";
         dynavLocationoptions.Visible = 1;
         dynavLocationoptions.Enabled = 1;
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
         Ddo_grid_Columnids = "1:LocationGenSuppliersSDTs__Supplier_GenCompanyName|3:LocationGenSuppliersSDTs__Supplier_GenContactName|4:LocationGenSuppliersSDTs__Supplier_GenContactPhone|5:LocationGenSuppliersSDTs__Supplier_GenVisitingAddress|6:LocationGenSuppliersSDTs__Supplier_GenPostalAddress";
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
         Form.Caption = "My General Suppliers";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV20ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E132L2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E142L2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E192L2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV29Delete","fld":"vDELETE"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E152L2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV20ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E122L2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"ctrl":"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV20ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
         setEventMetadata("'DOINSERTGENSUPPLIER'","""{"handler":"E112L1","iparms":[]}""");
         setEventMetadata("VLOCATIONOPTIONS.CONTROLVALUECHANGED","""{"handler":"E162L2","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"AV43Udparg1","fld":"vUDPARG1","pic":"9999","hsh":true},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"dynavLocationoptions"},{"av":"AV30LocationOptions","fld":"vLOCATIONOPTIONS","pic":"ZZZ9"},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9"},{"av":"A65Supplier_GenKvKNumber","fld":"SUPPLIER_GENKVKNUMBER"},{"av":"A66Supplier_GenCompanyName","fld":"SUPPLIER_GENCOMPANYNAME"},{"av":"A69Supplier_GenContactName","fld":"SUPPLIER_GENCONTACTNAME"},{"av":"A70Supplier_GenContactPhone","fld":"SUPPLIER_GENCONTACTPHONE"},{"av":"A68Supplier_GenPostalAddress","fld":"SUPPLIER_GENPOSTALADDRESS"},{"av":"A67Supplier_GenVisitingAddress","fld":"SUPPLIER_GENVISITINGADDRESS"},{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45},{"av":"GRID_nEOF"},{"av":"AV22ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"}]""");
         setEventMetadata("VLOCATIONOPTIONS.CONTROLVALUECHANGED",""","oparms":[{"av":"AV14LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":45},{"av":"nGXsfl_45_idx","ctrl":"GRID","prop":"GridCurrRow","grid":45},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_45","ctrl":"GRID","prop":"GridRC","grid":45}]}""");
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
         AV17ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41Pgmname = "";
         AV13FilterFullText = "";
         A65Supplier_GenKvKNumber = "";
         A66Supplier_GenCompanyName = "";
         A69Supplier_GenContactName = "";
         A70Supplier_GenContactPhone = "";
         A68Supplier_GenPostalAddress = "";
         A67Supplier_GenVisitingAddress = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV14LocationGenSuppliersSDTs = new GXBaseCollection<SdtLocationGenSuppliersSDT>( context, "LocationGenSuppliersSDT", "Comforta2");
         AV20ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV27GridAppliedFilters = "";
         AV23DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsertgensupplier_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblTextblocklocationoptions_Jsonclick = "";
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
         AV29Delete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002L2_A18CustomerLocationId = new short[1] ;
         H002L2_A134CustomerLocationName = new string[] {""} ;
         H002L2_A1CustomerId = new short[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV32GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser2 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV19Session = context.GetSession();
         AV15ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV21ManageFiltersXml = "";
         H002L3_A18CustomerLocationId = new short[1] ;
         H002L3_A1CustomerId = new short[1] ;
         H002L3_A64Supplier_GenId = new short[1] ;
         H002L3_A65Supplier_GenKvKNumber = new string[] {""} ;
         H002L3_A66Supplier_GenCompanyName = new string[] {""} ;
         H002L3_A69Supplier_GenContactName = new string[] {""} ;
         H002L3_n69Supplier_GenContactName = new bool[] {false} ;
         H002L3_A70Supplier_GenContactPhone = new string[] {""} ;
         H002L3_n70Supplier_GenContactPhone = new bool[] {false} ;
         H002L3_A68Supplier_GenPostalAddress = new string[] {""} ;
         H002L3_n68Supplier_GenPostalAddress = new bool[] {false} ;
         H002L3_A67Supplier_GenVisitingAddress = new string[] {""} ;
         H002L3_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         AV31LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
         AV16UserCustomValue = "";
         GXt_char4 = "";
         AV18ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.locationgensuppliers__default(),
            new Object[][] {
                new Object[] {
               H002L2_A18CustomerLocationId, H002L2_A134CustomerLocationName, H002L2_A1CustomerId
               }
               , new Object[] {
               H002L3_A18CustomerLocationId, H002L3_A1CustomerId, H002L3_A64Supplier_GenId, H002L3_A65Supplier_GenKvKNumber, H002L3_A66Supplier_GenCompanyName, H002L3_A69Supplier_GenContactName, H002L3_n69Supplier_GenContactName, H002L3_A70Supplier_GenContactPhone, H002L3_n70Supplier_GenContactPhone, H002L3_A68Supplier_GenPostalAddress,
               H002L3_n68Supplier_GenPostalAddress, H002L3_A67Supplier_GenVisitingAddress, H002L3_n67Supplier_GenVisitingAddress
               }
            }
         );
         AV41Pgmname = "LocationGenSuppliers";
         /* GeneXus formulas. */
         AV41Pgmname = "LocationGenSuppliers";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV22ManageFiltersExecutionStep ;
      private short A1CustomerId ;
      private short AV43Udparg1 ;
      private short A18CustomerLocationId ;
      private short AV30LocationOptions ;
      private short A64Supplier_GenId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_45 ;
      private int nGXsfl_45_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int AV33GXV1 ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavLocationgensupplierssdts__supplier_genid_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled ;
      private int edtavDelete_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_45_fel_idx=1 ;
      private int edtavLocationgensupplierssdts__supplier_gencompanyname_Visible ;
      private int edtavLocationgensupplierssdts__supplier_gencontactname_Visible ;
      private int edtavLocationgensupplierssdts__supplier_gencontactphone_Visible ;
      private int edtavLocationgensupplierssdts__supplier_genvisitingaddress_Visible ;
      private int edtavLocationgensupplierssdts__supplier_genpostaladdress_Visible ;
      private int AV24PageToGo ;
      private int nGXsfl_45_bak_idx=1 ;
      private int AV44GXV9 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV25GridCurrentPage ;
      private long AV26GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_45_idx="0001" ;
      private string AV41Pgmname ;
      private string A70Supplier_GenContactPhone ;
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
      private string bttBtninsertgensupplier_Internalname ;
      private string bttBtninsertgensupplier_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divUnnamedtablelocationoptions_Internalname ;
      private string lblTextblocklocationoptions_Internalname ;
      private string lblTextblocklocationoptions_Jsonclick ;
      private string dynavLocationoptions_Internalname ;
      private string dynavLocationoptions_Jsonclick ;
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
      private string AV29Delete ;
      private string edtavDelete_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_45_fel_idx="0001" ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname ;
      private string GXt_char4 ;
      private string edtavLocationgensupplierssdts__supplier_genid_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavLocationgensupplierssdts__supplier_genid_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private bool n68Supplier_GenPostalAddress ;
      private bool n67Supplier_GenVisitingAddress ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_45_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV45 ;
      private string AV15ColumnsSelectorXML ;
      private string AV21ManageFiltersXml ;
      private string AV16UserCustomValue ;
      private string AV13FilterFullText ;
      private string A65Supplier_GenKvKNumber ;
      private string A66Supplier_GenCompanyName ;
      private string A69Supplier_GenContactName ;
      private string A68Supplier_GenPostalAddress ;
      private string A67Supplier_GenVisitingAddress ;
      private string AV27GridAppliedFilters ;
      private IGxSession AV19Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV17ColumnsSelector ;
      private GXBaseCollection<SdtLocationGenSuppliersSDT> AV14LocationGenSuppliersSDTs ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV20ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV23DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H002L2_A18CustomerLocationId ;
      private string[] H002L2_A134CustomerLocationName ;
      private short[] H002L2_A1CustomerId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV32GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private short[] H002L3_A18CustomerLocationId ;
      private short[] H002L3_A1CustomerId ;
      private short[] H002L3_A64Supplier_GenId ;
      private string[] H002L3_A65Supplier_GenKvKNumber ;
      private string[] H002L3_A66Supplier_GenCompanyName ;
      private string[] H002L3_A69Supplier_GenContactName ;
      private bool[] H002L3_n69Supplier_GenContactName ;
      private string[] H002L3_A70Supplier_GenContactPhone ;
      private bool[] H002L3_n70Supplier_GenContactPhone ;
      private string[] H002L3_A68Supplier_GenPostalAddress ;
      private bool[] H002L3_n68Supplier_GenPostalAddress ;
      private string[] H002L3_A67Supplier_GenVisitingAddress ;
      private bool[] H002L3_n67Supplier_GenVisitingAddress ;
      private SdtLocationGenSuppliersSDT AV31LocationGenSuppliersSDT ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV18ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class locationgensuppliers__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002L3( IGxContext context ,
                                             short AV30LocationOptions ,
                                             short A18CustomerLocationId ,
                                             short AV43Udparg1 ,
                                             short A1CustomerId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[2];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.CustomerLocationId, T1.CustomerId, T1.Supplier_GenId, T2.Supplier_GenKvKNumber, T2.Supplier_GenCompanyName, T2.Supplier_GenContactName, T2.Supplier_GenContactPhone, T2.Supplier_GenPostalAddress, T2.Supplier_GenVisitingAddress FROM (CustomerLocationSupplier_Gen T1 INNER JOIN Supplier_Gen T2 ON T2.Supplier_GenId = T1.Supplier_GenId)";
         AddWhere(sWhereString, "(T1.CustomerId = :AV43Udparg1)");
         if ( ! (0==AV30LocationOptions) )
         {
            AddWhere(sWhereString, "(T1.CustomerLocationId = :AV30LocationOptions)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CustomerId";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H002L3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmH002L2;
          prmH002L2 = new Object[] {
          };
          Object[] prmH002L3;
          prmH002L3 = new Object[] {
          new ParDef("AV43Udparg1",GXType.Int16,4,0) ,
          new ParDef("AV30LocationOptions",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002L2", "SELECT CustomerLocationId, CustomerLocationName, CustomerId FROM CustomerLocation ORDER BY CustomerLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
