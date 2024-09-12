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
   public class supplier_genww : GXDataArea
   {
      public supplier_genww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supplier_genww( IGxContext context )
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
         AV52Pgmname = GetPar( "Pgmname");
         AV29TFSupplier_GenCompanyName = GetPar( "TFSupplier_GenCompanyName");
         AV30TFSupplier_GenCompanyName_Sel = GetPar( "TFSupplier_GenCompanyName_Sel");
         AV35TFSupplier_GenContactName = GetPar( "TFSupplier_GenContactName");
         AV36TFSupplier_GenContactName_Sel = GetPar( "TFSupplier_GenContactName_Sel");
         AV37TFSupplier_GenContactPhone = GetPar( "TFSupplier_GenContactPhone");
         AV38TFSupplier_GenContactPhone_Sel = GetPar( "TFSupplier_GenContactPhone_Sel");
         AV31TFSupplier_GenVisitingAddress = GetPar( "TFSupplier_GenVisitingAddress");
         AV32TFSupplier_GenVisitingAddress_Sel = GetPar( "TFSupplier_GenVisitingAddress_Sel");
         AV33TFSupplier_GenPostalAddress = GetPar( "TFSupplier_GenPostalAddress");
         AV34TFSupplier_GenPostalAddress_Sel = GetPar( "TFSupplier_GenPostalAddress_Sel");
         AV47IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV49IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV51IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
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
            return "supplier_genww_Execute" ;
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
         PA1M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1M2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier_genww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV45GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCOMPANYNAME", AV29TFSupplier_GenCompanyName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCOMPANYNAME_SEL", AV30TFSupplier_GenCompanyName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCONTACTNAME", AV35TFSupplier_GenContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCONTACTNAME_SEL", AV36TFSupplier_GenContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCONTACTPHONE", StringUtil.RTrim( AV37TFSupplier_GenContactPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENCONTACTPHONE_SEL", StringUtil.RTrim( AV38TFSupplier_GenContactPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENVISITINGADDRESS", AV31TFSupplier_GenVisitingAddress);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENVISITINGADDRESS_SEL", AV32TFSupplier_GenVisitingAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENPOSTALADDRESS", AV33TFSupplier_GenPostalAddress);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIER_GENPOSTALADDRESS_SEL", AV34TFSupplier_GenPostalAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1M2( ) ;
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
         return formatLink("supplier_genww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Supplier_GenWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " General Suppliers" ;
      }

      protected void WB1M0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_GenWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier_GenWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Supplier_GenWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV43GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV44GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV45GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV19ColumnsSelector);
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

      protected void START1M2( )
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
         Form.Meta.addItem("description", " General Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1M0( ) ;
      }

      protected void WS1M2( )
      {
         START1M2( ) ;
         EVT1M2( ) ;
      }

      protected void EVT1M2( )
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
                              E111M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E141M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E151M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E161M2 ();
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
                              A64Supplier_GenId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplier_GenId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A65Supplier_GenKvKNumber = cgiGet( edtSupplier_GenKvKNumber_Internalname);
                              A66Supplier_GenCompanyName = cgiGet( edtSupplier_GenCompanyName_Internalname);
                              A69Supplier_GenContactName = cgiGet( edtSupplier_GenContactName_Internalname);
                              n69Supplier_GenContactName = false;
                              A70Supplier_GenContactPhone = cgiGet( edtSupplier_GenContactPhone_Internalname);
                              n70Supplier_GenContactPhone = false;
                              A67Supplier_GenVisitingAddress = cgiGet( edtSupplier_GenVisitingAddress_Internalname);
                              n67Supplier_GenVisitingAddress = false;
                              A68Supplier_GenPostalAddress = cgiGet( edtSupplier_GenPostalAddress_Internalname);
                              n68Supplier_GenPostalAddress = false;
                              AV46Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV46Update);
                              AV48Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV48Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E191M2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1M2( )
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

      protected void PA1M2( )
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
                                       string AV52Pgmname ,
                                       string AV29TFSupplier_GenCompanyName ,
                                       string AV30TFSupplier_GenCompanyName_Sel ,
                                       string AV35TFSupplier_GenContactName ,
                                       string AV36TFSupplier_GenContactName_Sel ,
                                       string AV37TFSupplier_GenContactPhone ,
                                       string AV38TFSupplier_GenContactPhone_Sel ,
                                       string AV31TFSupplier_GenVisitingAddress ,
                                       string AV32TFSupplier_GenVisitingAddress_Sel ,
                                       string AV33TFSupplier_GenPostalAddress ,
                                       string AV34TFSupplier_GenPostalAddress_Sel ,
                                       bool AV47IsAuthorized_Update ,
                                       bool AV49IsAuthorized_Delete ,
                                       bool AV51IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_GENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIER_GENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", "")));
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
         RF1M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "Supplier_GenWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF1M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181M2 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV53Supplier_genwwds_1_filterfulltext ,
                                                 AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                                 AV54Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                                 AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                                 AV56Supplier_genwwds_4_tfsupplier_gencontactname ,
                                                 AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                                 AV58Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                                 AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                                 AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                                 AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                                 AV62Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                                 A66Supplier_GenCompanyName ,
                                                 A69Supplier_GenContactName ,
                                                 A70Supplier_GenContactPhone ,
                                                 A67Supplier_GenVisitingAddress ,
                                                 A68Supplier_GenPostalAddress ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
            lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
            lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
            lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
            lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
            lV54Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
            lV56Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV56Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
            lV58Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV58Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
            lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
            lV62Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV62Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
            /* Using cursor H001M2 */
            pr_default.execute(0, new Object[] {lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV54Supplier_genwwds_2_tfsupplier_gencompanyname, AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV56Supplier_genwwds_4_tfsupplier_gencontactname, AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV58Supplier_genwwds_6_tfsupplier_gencontactphone, AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV62Supplier_genwwds_10_tfsupplier_genpostaladdress, AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A68Supplier_GenPostalAddress = H001M2_A68Supplier_GenPostalAddress[0];
               n68Supplier_GenPostalAddress = H001M2_n68Supplier_GenPostalAddress[0];
               A67Supplier_GenVisitingAddress = H001M2_A67Supplier_GenVisitingAddress[0];
               n67Supplier_GenVisitingAddress = H001M2_n67Supplier_GenVisitingAddress[0];
               A70Supplier_GenContactPhone = H001M2_A70Supplier_GenContactPhone[0];
               n70Supplier_GenContactPhone = H001M2_n70Supplier_GenContactPhone[0];
               A69Supplier_GenContactName = H001M2_A69Supplier_GenContactName[0];
               n69Supplier_GenContactName = H001M2_n69Supplier_GenContactName[0];
               A66Supplier_GenCompanyName = H001M2_A66Supplier_GenCompanyName[0];
               A65Supplier_GenKvKNumber = H001M2_A65Supplier_GenKvKNumber[0];
               A64Supplier_GenId = H001M2_A64Supplier_GenId[0];
               /* Execute user event: Grid.Load */
               E191M2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1M0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1M2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIER_GENID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9"), context));
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
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Supplier_genwwds_1_filterfulltext ,
                                              AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                              AV54Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                              AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                              AV56Supplier_genwwds_4_tfsupplier_gencontactname ,
                                              AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                              AV58Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                              AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                              AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                              AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                              AV62Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                              A66Supplier_GenCompanyName ,
                                              A69Supplier_GenContactName ,
                                              A70Supplier_GenContactPhone ,
                                              A67Supplier_GenVisitingAddress ,
                                              A68Supplier_GenPostalAddress ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
         lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
         lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
         lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
         lV53Supplier_genwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext), "%", "");
         lV54Supplier_genwwds_2_tfsupplier_gencompanyname = StringUtil.Concat( StringUtil.RTrim( AV54Supplier_genwwds_2_tfsupplier_gencompanyname), "%", "");
         lV56Supplier_genwwds_4_tfsupplier_gencontactname = StringUtil.Concat( StringUtil.RTrim( AV56Supplier_genwwds_4_tfsupplier_gencontactname), "%", "");
         lV58Supplier_genwwds_6_tfsupplier_gencontactphone = StringUtil.PadR( StringUtil.RTrim( AV58Supplier_genwwds_6_tfsupplier_gencontactphone), 20, "%");
         lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress), "%", "");
         lV62Supplier_genwwds_10_tfsupplier_genpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV62Supplier_genwwds_10_tfsupplier_genpostaladdress), "%", "");
         /* Using cursor H001M3 */
         pr_default.execute(1, new Object[] {lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV53Supplier_genwwds_1_filterfulltext, lV54Supplier_genwwds_2_tfsupplier_gencompanyname, AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, lV56Supplier_genwwds_4_tfsupplier_gencontactname, AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, lV58Supplier_genwwds_6_tfsupplier_gencontactphone, AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress, AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, lV62Supplier_genwwds_10_tfsupplier_genpostaladdress, AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel});
         GRID_nRecordCount = H001M3_AGRID_nRecordCount[0];
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
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV52Pgmname, AV29TFSupplier_GenCompanyName, AV30TFSupplier_GenCompanyName_Sel, AV35TFSupplier_GenContactName, AV36TFSupplier_GenContactName_Sel, AV37TFSupplier_GenContactPhone, AV38TFSupplier_GenContactPhone_Sel, AV31TFSupplier_GenVisitingAddress, AV32TFSupplier_GenVisitingAddress_Sel, AV33TFSupplier_GenPostalAddress, AV34TFSupplier_GenPostalAddress_Sel, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV51IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV52Pgmname = "Supplier_GenWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSupplier_GenId_Enabled = 0;
         edtSupplier_GenKvKNumber_Enabled = 0;
         edtSupplier_GenCompanyName_Enabled = 0;
         edtSupplier_GenContactName_Enabled = 0;
         edtSupplier_GenContactPhone_Enabled = 0;
         edtSupplier_GenVisitingAddress_Enabled = 0;
         edtSupplier_GenPostalAddress_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV43GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV44GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV45GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
         E171M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171M2( )
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
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV41GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV40GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " General Suppliers";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181M2( )
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
         if ( StringUtil.StrCmp(AV21Session.Get("Supplier_GenWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("Supplier_GenWWColumnsSelector");
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
         edtSupplier_GenCompanyName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_GenCompanyName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenCompanyName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_GenContactName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_GenContactName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_GenContactPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_GenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenContactPhone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_GenVisitingAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_GenVisitingAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenVisitingAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtSupplier_GenPostalAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplier_GenPostalAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_GenPostalAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV43GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV43GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV43GridCurrentPage), 10, 0));
         AV44GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV44GridPageCount", StringUtil.LTrimStr( (decimal)(AV44GridPageCount), 10, 0));
         GXt_char2 = AV45GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV52Pgmname, out  GXt_char2) ;
         AV45GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV45GridAppliedFilters", AV45GridAppliedFilters);
         AV53Supplier_genwwds_1_filterfulltext = AV16FilterFullText;
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = AV29TFSupplier_GenCompanyName;
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = AV30TFSupplier_GenCompanyName_Sel;
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = AV35TFSupplier_GenContactName;
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = AV36TFSupplier_GenContactName_Sel;
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = AV37TFSupplier_GenContactPhone;
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = AV38TFSupplier_GenContactPhone_Sel;
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = AV31TFSupplier_GenVisitingAddress;
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = AV32TFSupplier_GenVisitingAddress_Sel;
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = AV33TFSupplier_GenPostalAddress;
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = AV34TFSupplier_GenPostalAddress_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E121M2( )
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
            AV42PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV42PageToGo) ;
         }
      }

      protected void E131M2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141M2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_GenCompanyName") == 0 )
            {
               AV29TFSupplier_GenCompanyName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFSupplier_GenCompanyName", AV29TFSupplier_GenCompanyName);
               AV30TFSupplier_GenCompanyName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFSupplier_GenCompanyName_Sel", AV30TFSupplier_GenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_GenContactName") == 0 )
            {
               AV35TFSupplier_GenContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFSupplier_GenContactName", AV35TFSupplier_GenContactName);
               AV36TFSupplier_GenContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFSupplier_GenContactName_Sel", AV36TFSupplier_GenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_GenContactPhone") == 0 )
            {
               AV37TFSupplier_GenContactPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFSupplier_GenContactPhone", AV37TFSupplier_GenContactPhone);
               AV38TFSupplier_GenContactPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFSupplier_GenContactPhone_Sel", AV38TFSupplier_GenContactPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_GenVisitingAddress") == 0 )
            {
               AV31TFSupplier_GenVisitingAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFSupplier_GenVisitingAddress", AV31TFSupplier_GenVisitingAddress);
               AV32TFSupplier_GenVisitingAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFSupplier_GenVisitingAddress_Sel", AV32TFSupplier_GenVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Supplier_GenPostalAddress") == 0 )
            {
               AV33TFSupplier_GenPostalAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFSupplier_GenPostalAddress", AV33TFSupplier_GenPostalAddress);
               AV34TFSupplier_GenPostalAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFSupplier_GenPostalAddress_Sel", AV34TFSupplier_GenPostalAddress_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191M2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV46Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV46Update);
         if ( AV47IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("supplier_gen.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A64Supplier_GenId,4,0))}, new string[] {"Mode","Supplier_GenId"}) ;
         }
         AV48Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV48Delete);
         if ( AV49IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("supplier_gen.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A64Supplier_GenId,4,0))}, new string[] {"Mode","Supplier_GenId"}) ;
         }
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

      protected void E151M2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "Supplier_GenWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E111M2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("Supplier_GenWWFilters")),UrlEncode(StringUtil.RTrim(AV52Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("Supplier_GenWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Supplier_GenWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV23ManageFiltersXml = GXt_char2;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV23ManageFiltersXml) ;
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

      protected void E161M2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV51IsAuthorized_Insert )
         {
            CallWebObject(formatLink("supplier_gen.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","Supplier_GenId"}) );
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_GenCompanyName",  "",  "Company Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_GenContactName",  "",  "Contact Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_GenContactPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_GenVisitingAddress",  "",  "Visiting Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "Supplier_GenPostalAddress",  "",  "Postal Address",  true,  "") ;
         GXt_char2 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "Supplier_GenWWColumnsSelector", out  GXt_char2) ;
         AV18UserCustomValue = GXt_char2;
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
         GXt_boolean3 = AV47IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_gen_Update", out  GXt_boolean3) ;
         AV47IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV47IsAuthorized_Update", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         if ( ! ( AV47IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV49IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_gen_Delete", out  GXt_boolean3) ;
         AV49IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV49IsAuthorized_Delete", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         if ( ! ( AV49IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV51IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_gen_Insert", out  GXt_boolean3) ;
         AV51IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV51IsAuthorized_Insert", AV51IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV51IsAuthorized_Insert, context));
         if ( ! ( AV51IsAuthorized_Insert ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Supplier_GenWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV29TFSupplier_GenCompanyName = "";
         AssignAttri("", false, "AV29TFSupplier_GenCompanyName", AV29TFSupplier_GenCompanyName);
         AV30TFSupplier_GenCompanyName_Sel = "";
         AssignAttri("", false, "AV30TFSupplier_GenCompanyName_Sel", AV30TFSupplier_GenCompanyName_Sel);
         AV35TFSupplier_GenContactName = "";
         AssignAttri("", false, "AV35TFSupplier_GenContactName", AV35TFSupplier_GenContactName);
         AV36TFSupplier_GenContactName_Sel = "";
         AssignAttri("", false, "AV36TFSupplier_GenContactName_Sel", AV36TFSupplier_GenContactName_Sel);
         AV37TFSupplier_GenContactPhone = "";
         AssignAttri("", false, "AV37TFSupplier_GenContactPhone", AV37TFSupplier_GenContactPhone);
         AV38TFSupplier_GenContactPhone_Sel = "";
         AssignAttri("", false, "AV38TFSupplier_GenContactPhone_Sel", AV38TFSupplier_GenContactPhone_Sel);
         AV31TFSupplier_GenVisitingAddress = "";
         AssignAttri("", false, "AV31TFSupplier_GenVisitingAddress", AV31TFSupplier_GenVisitingAddress);
         AV32TFSupplier_GenVisitingAddress_Sel = "";
         AssignAttri("", false, "AV32TFSupplier_GenVisitingAddress_Sel", AV32TFSupplier_GenVisitingAddress_Sel);
         AV33TFSupplier_GenPostalAddress = "";
         AssignAttri("", false, "AV33TFSupplier_GenPostalAddress", AV33TFSupplier_GenPostalAddress);
         AV34TFSupplier_GenPostalAddress_Sel = "";
         AssignAttri("", false, "AV34TFSupplier_GenPostalAddress_Sel", AV34TFSupplier_GenPostalAddress_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV52Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV52Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV52Pgmname+"GridState"), null, "", "");
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
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCOMPANYNAME") == 0 )
            {
               AV29TFSupplier_GenCompanyName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFSupplier_GenCompanyName", AV29TFSupplier_GenCompanyName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCOMPANYNAME_SEL") == 0 )
            {
               AV30TFSupplier_GenCompanyName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFSupplier_GenCompanyName_Sel", AV30TFSupplier_GenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTNAME") == 0 )
            {
               AV35TFSupplier_GenContactName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFSupplier_GenContactName", AV35TFSupplier_GenContactName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTNAME_SEL") == 0 )
            {
               AV36TFSupplier_GenContactName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFSupplier_GenContactName_Sel", AV36TFSupplier_GenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTPHONE") == 0 )
            {
               AV37TFSupplier_GenContactPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFSupplier_GenContactPhone", AV37TFSupplier_GenContactPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENCONTACTPHONE_SEL") == 0 )
            {
               AV38TFSupplier_GenContactPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFSupplier_GenContactPhone_Sel", AV38TFSupplier_GenContactPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENVISITINGADDRESS") == 0 )
            {
               AV31TFSupplier_GenVisitingAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFSupplier_GenVisitingAddress", AV31TFSupplier_GenVisitingAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENVISITINGADDRESS_SEL") == 0 )
            {
               AV32TFSupplier_GenVisitingAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFSupplier_GenVisitingAddress_Sel", AV32TFSupplier_GenVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENPOSTALADDRESS") == 0 )
            {
               AV33TFSupplier_GenPostalAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSupplier_GenPostalAddress", AV33TFSupplier_GenPostalAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIER_GENPOSTALADDRESS_SEL") == 0 )
            {
               AV34TFSupplier_GenPostalAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFSupplier_GenPostalAddress_Sel", AV34TFSupplier_GenPostalAddress_Sel);
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplier_GenCompanyName_Sel)),  AV30TFSupplier_GenCompanyName_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplier_GenContactName_Sel)),  AV36TFSupplier_GenContactName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplier_GenContactPhone_Sel)),  AV38TFSupplier_GenContactPhone_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplier_GenVisitingAddress_Sel)),  AV32TFSupplier_GenVisitingAddress_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplier_GenPostalAddress_Sel)),  AV34TFSupplier_GenPostalAddress_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplier_GenCompanyName)),  AV29TFSupplier_GenCompanyName, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplier_GenContactName)),  AV35TFSupplier_GenContactName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplier_GenContactPhone)),  AV37TFSupplier_GenContactPhone, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplier_GenVisitingAddress)),  AV31TFSupplier_GenVisitingAddress, out  GXt_char5) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplier_GenPostalAddress)),  AV33TFSupplier_GenPostalAddress, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV52Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_GENCOMPANYNAME",  "Company Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplier_GenCompanyName)),  0,  AV29TFSupplier_GenCompanyName,  AV29TFSupplier_GenCompanyName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplier_GenCompanyName_Sel)),  AV30TFSupplier_GenCompanyName_Sel,  AV30TFSupplier_GenCompanyName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_GENCONTACTNAME",  "Contact Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSupplier_GenContactName)),  0,  AV35TFSupplier_GenContactName,  AV35TFSupplier_GenContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSupplier_GenContactName_Sel)),  AV36TFSupplier_GenContactName_Sel,  AV36TFSupplier_GenContactName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_GENCONTACTPHONE",  "Phone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSupplier_GenContactPhone)),  0,  AV37TFSupplier_GenContactPhone,  AV37TFSupplier_GenContactPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSupplier_GenContactPhone_Sel)),  AV38TFSupplier_GenContactPhone_Sel,  AV38TFSupplier_GenContactPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_GENVISITINGADDRESS",  "Visiting Address",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplier_GenVisitingAddress)),  0,  AV31TFSupplier_GenVisitingAddress,  AV31TFSupplier_GenVisitingAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplier_GenVisitingAddress_Sel)),  AV32TFSupplier_GenVisitingAddress_Sel,  AV32TFSupplier_GenVisitingAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIER_GENPOSTALADDRESS",  "Postal Address",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplier_GenPostalAddress)),  0,  AV33TFSupplier_GenPostalAddress,  AV33TFSupplier_GenPostalAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplier_GenPostalAddress_Sel)),  AV34TFSupplier_GenPostalAddress_Sel,  AV34TFSupplier_GenPostalAddress_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV52Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Supplier_Gen";
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
         PA1M2( ) ;
         WS1M2( ) ;
         WE1M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126312887", true, true);
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
         context.AddJavascriptSource("supplier_genww.js", "?20249126312889", false, true);
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
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_37_idx;
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER_"+sGXsfl_37_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_37_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_37_idx;
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_37_idx;
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_37_idx;
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID_"+sGXsfl_37_fel_idx;
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME_"+sGXsfl_37_fel_idx;
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME_"+sGXsfl_37_fel_idx;
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE_"+sGXsfl_37_fel_idx;
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_37_fel_idx;
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB1M0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A64Supplier_GenId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenKvKNumber_Internalname,(string)A65Supplier_GenKvKNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenKvKNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_GenCompanyName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenCompanyName_Internalname,(string)A66Supplier_GenCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_GenCompanyName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_GenContactName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenContactName_Internalname,(string)A69Supplier_GenContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplier_GenContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_GenContactName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_GenContactPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A70Supplier_GenContactPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenContactPhone_Internalname,StringUtil.RTrim( A70Supplier_GenContactPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplier_GenContactPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_GenContactPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_GenVisitingAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenVisitingAddress_Internalname,(string)A67Supplier_GenVisitingAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A67Supplier_GenVisitingAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_GenVisitingAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_GenVisitingAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplier_GenPostalAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplier_GenPostalAddress_Internalname,(string)A68Supplier_GenPostalAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A68Supplier_GenPostalAddress),(string)"_blank",(string)"",(string)"",(string)edtSupplier_GenPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSupplier_GenPostalAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV46Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV48Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1M2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_GenCompanyName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Company Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_GenContactName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Contact Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_GenContactPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_GenVisitingAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Visiting Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplier_GenPostalAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Postal Address") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64Supplier_GenId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A65Supplier_GenKvKNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A66Supplier_GenCompanyName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenCompanyName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A69Supplier_GenContactName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A70Supplier_GenContactPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenContactPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A67Supplier_GenVisitingAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenVisitingAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A68Supplier_GenPostalAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplier_GenPostalAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV48Delete)));
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
         edtSupplier_GenId_Internalname = "SUPPLIER_GENID";
         edtSupplier_GenKvKNumber_Internalname = "SUPPLIER_GENKVKNUMBER";
         edtSupplier_GenCompanyName_Internalname = "SUPPLIER_GENCOMPANYNAME";
         edtSupplier_GenContactName_Internalname = "SUPPLIER_GENCONTACTNAME";
         edtSupplier_GenContactPhone_Internalname = "SUPPLIER_GENCONTACTPHONE";
         edtSupplier_GenVisitingAddress_Internalname = "SUPPLIER_GENVISITINGADDRESS";
         edtSupplier_GenPostalAddress_Internalname = "SUPPLIER_GENPOSTALADDRESS";
         edtavUpdate_Internalname = "vUPDATE";
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
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtSupplier_GenPostalAddress_Jsonclick = "";
         edtSupplier_GenVisitingAddress_Jsonclick = "";
         edtSupplier_GenContactPhone_Jsonclick = "";
         edtSupplier_GenContactName_Jsonclick = "";
         edtSupplier_GenCompanyName_Jsonclick = "";
         edtSupplier_GenKvKNumber_Jsonclick = "";
         edtSupplier_GenId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtSupplier_GenPostalAddress_Visible = -1;
         edtSupplier_GenVisitingAddress_Visible = -1;
         edtSupplier_GenContactPhone_Visible = -1;
         edtSupplier_GenContactName_Visible = -1;
         edtSupplier_GenCompanyName_Visible = -1;
         edtSupplier_GenPostalAddress_Enabled = 0;
         edtSupplier_GenVisitingAddress_Enabled = 0;
         edtSupplier_GenContactPhone_Enabled = 0;
         edtSupplier_GenContactName_Enabled = 0;
         edtSupplier_GenCompanyName_Enabled = 0;
         edtSupplier_GenKvKNumber_Enabled = 0;
         edtSupplier_GenId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "Supplier_GenWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6";
         Ddo_grid_Columnids = "2:Supplier_GenCompanyName|3:Supplier_GenContactName|4:Supplier_GenContactPhone|5:Supplier_GenVisitingAddress|6:Supplier_GenPostalAddress";
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
         Form.Caption = " General Suppliers";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplier_GenCompanyName_Visible","ctrl":"SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"av":"edtSupplier_GenContactName_Visible","ctrl":"SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"av":"edtSupplier_GenContactPhone_Visible","ctrl":"SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"av":"edtSupplier_GenVisitingAddress_Visible","ctrl":"SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"av":"edtSupplier_GenPostalAddress_Visible","ctrl":"SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E121M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E131M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E141M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E191M2","iparms":[{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV46Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV48Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E151M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtSupplier_GenCompanyName_Visible","ctrl":"SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"av":"edtSupplier_GenContactName_Visible","ctrl":"SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"av":"edtSupplier_GenContactPhone_Visible","ctrl":"SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"av":"edtSupplier_GenVisitingAddress_Visible","ctrl":"SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"av":"edtSupplier_GenPostalAddress_Visible","ctrl":"SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E111M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplier_GenCompanyName_Visible","ctrl":"SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"av":"edtSupplier_GenContactName_Visible","ctrl":"SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"av":"edtSupplier_GenContactPhone_Visible","ctrl":"SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"av":"edtSupplier_GenVisitingAddress_Visible","ctrl":"SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"av":"edtSupplier_GenPostalAddress_Visible","ctrl":"SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E161M2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFSupplier_GenCompanyName","fld":"vTFSUPPLIER_GENCOMPANYNAME"},{"av":"AV30TFSupplier_GenCompanyName_Sel","fld":"vTFSUPPLIER_GENCOMPANYNAME_SEL"},{"av":"AV35TFSupplier_GenContactName","fld":"vTFSUPPLIER_GENCONTACTNAME"},{"av":"AV36TFSupplier_GenContactName_Sel","fld":"vTFSUPPLIER_GENCONTACTNAME_SEL"},{"av":"AV37TFSupplier_GenContactPhone","fld":"vTFSUPPLIER_GENCONTACTPHONE"},{"av":"AV38TFSupplier_GenContactPhone_Sel","fld":"vTFSUPPLIER_GENCONTACTPHONE_SEL"},{"av":"AV31TFSupplier_GenVisitingAddress","fld":"vTFSUPPLIER_GENVISITINGADDRESS"},{"av":"AV32TFSupplier_GenVisitingAddress_Sel","fld":"vTFSUPPLIER_GENVISITINGADDRESS_SEL"},{"av":"AV33TFSupplier_GenPostalAddress","fld":"vTFSUPPLIER_GENPOSTALADDRESS"},{"av":"AV34TFSupplier_GenPostalAddress_Sel","fld":"vTFSUPPLIER_GENPOSTALADDRESS_SEL"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A64Supplier_GenId","fld":"SUPPLIER_GENID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtSupplier_GenCompanyName_Visible","ctrl":"SUPPLIER_GENCOMPANYNAME","prop":"Visible"},{"av":"edtSupplier_GenContactName_Visible","ctrl":"SUPPLIER_GENCONTACTNAME","prop":"Visible"},{"av":"edtSupplier_GenContactPhone_Visible","ctrl":"SUPPLIER_GENCONTACTPHONE","prop":"Visible"},{"av":"edtSupplier_GenVisitingAddress_Visible","ctrl":"SUPPLIER_GENVISITINGADDRESS","prop":"Visible"},{"av":"edtSupplier_GenPostalAddress_Visible","ctrl":"SUPPLIER_GENPOSTALADDRESS","prop":"Visible"},{"av":"AV43GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV44GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV45GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV51IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
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
         AV52Pgmname = "";
         AV29TFSupplier_GenCompanyName = "";
         AV30TFSupplier_GenCompanyName_Sel = "";
         AV35TFSupplier_GenContactName = "";
         AV36TFSupplier_GenContactName_Sel = "";
         AV37TFSupplier_GenContactPhone = "";
         AV38TFSupplier_GenContactPhone_Sel = "";
         AV31TFSupplier_GenVisitingAddress = "";
         AV32TFSupplier_GenVisitingAddress_Sel = "";
         AV33TFSupplier_GenPostalAddress = "";
         AV34TFSupplier_GenPostalAddress_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV45GridAppliedFilters = "";
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
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
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A65Supplier_GenKvKNumber = "";
         A66Supplier_GenCompanyName = "";
         A69Supplier_GenContactName = "";
         A70Supplier_GenContactPhone = "";
         A67Supplier_GenVisitingAddress = "";
         A68Supplier_GenPostalAddress = "";
         AV46Update = "";
         AV48Delete = "";
         lV53Supplier_genwwds_1_filterfulltext = "";
         lV54Supplier_genwwds_2_tfsupplier_gencompanyname = "";
         lV56Supplier_genwwds_4_tfsupplier_gencontactname = "";
         lV58Supplier_genwwds_6_tfsupplier_gencontactphone = "";
         lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = "";
         lV62Supplier_genwwds_10_tfsupplier_genpostaladdress = "";
         AV53Supplier_genwwds_1_filterfulltext = "";
         AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel = "";
         AV54Supplier_genwwds_2_tfsupplier_gencompanyname = "";
         AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel = "";
         AV56Supplier_genwwds_4_tfsupplier_gencontactname = "";
         AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel = "";
         AV58Supplier_genwwds_6_tfsupplier_gencontactphone = "";
         AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel = "";
         AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress = "";
         AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel = "";
         AV62Supplier_genwwds_10_tfsupplier_genpostaladdress = "";
         H001M2_A68Supplier_GenPostalAddress = new string[] {""} ;
         H001M2_n68Supplier_GenPostalAddress = new bool[] {false} ;
         H001M2_A67Supplier_GenVisitingAddress = new string[] {""} ;
         H001M2_n67Supplier_GenVisitingAddress = new bool[] {false} ;
         H001M2_A70Supplier_GenContactPhone = new string[] {""} ;
         H001M2_n70Supplier_GenContactPhone = new bool[] {false} ;
         H001M2_A69Supplier_GenContactName = new string[] {""} ;
         H001M2_n69Supplier_GenContactName = new bool[] {false} ;
         H001M2_A66Supplier_GenCompanyName = new string[] {""} ;
         H001M2_A65Supplier_GenKvKNumber = new string[] {""} ;
         H001M2_A64Supplier_GenId = new short[1] ;
         H001M3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV40GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV41GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_genww__default(),
            new Object[][] {
                new Object[] {
               H001M2_A68Supplier_GenPostalAddress, H001M2_n68Supplier_GenPostalAddress, H001M2_A67Supplier_GenVisitingAddress, H001M2_n67Supplier_GenVisitingAddress, H001M2_A70Supplier_GenContactPhone, H001M2_n70Supplier_GenContactPhone, H001M2_A69Supplier_GenContactName, H001M2_n69Supplier_GenContactName, H001M2_A66Supplier_GenCompanyName, H001M2_A65Supplier_GenKvKNumber,
               H001M2_A64Supplier_GenId
               }
               , new Object[] {
               H001M3_AGRID_nRecordCount
               }
            }
         );
         AV52Pgmname = "Supplier_GenWW";
         /* GeneXus formulas. */
         AV52Pgmname = "Supplier_GenWW";
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
      private short A64Supplier_GenId ;
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
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplier_GenId_Enabled ;
      private int edtSupplier_GenKvKNumber_Enabled ;
      private int edtSupplier_GenCompanyName_Enabled ;
      private int edtSupplier_GenContactName_Enabled ;
      private int edtSupplier_GenContactPhone_Enabled ;
      private int edtSupplier_GenVisitingAddress_Enabled ;
      private int edtSupplier_GenPostalAddress_Enabled ;
      private int edtSupplier_GenCompanyName_Visible ;
      private int edtSupplier_GenContactName_Visible ;
      private int edtSupplier_GenContactPhone_Visible ;
      private int edtSupplier_GenVisitingAddress_Visible ;
      private int edtSupplier_GenPostalAddress_Visible ;
      private int AV42PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV64GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV43GridCurrentPage ;
      private long AV44GridPageCount ;
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
      private string AV52Pgmname ;
      private string AV37TFSupplier_GenContactPhone ;
      private string AV38TFSupplier_GenContactPhone_Sel ;
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
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSupplier_GenId_Internalname ;
      private string edtSupplier_GenKvKNumber_Internalname ;
      private string edtSupplier_GenCompanyName_Internalname ;
      private string edtSupplier_GenContactName_Internalname ;
      private string A70Supplier_GenContactPhone ;
      private string edtSupplier_GenContactPhone_Internalname ;
      private string edtSupplier_GenVisitingAddress_Internalname ;
      private string edtSupplier_GenPostalAddress_Internalname ;
      private string AV46Update ;
      private string edtavUpdate_Internalname ;
      private string AV48Delete ;
      private string edtavDelete_Internalname ;
      private string lV58Supplier_genwwds_6_tfsupplier_gencontactphone ;
      private string AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel ;
      private string AV58Supplier_genwwds_6_tfsupplier_gencontactphone ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSupplier_GenId_Jsonclick ;
      private string edtSupplier_GenKvKNumber_Jsonclick ;
      private string edtSupplier_GenCompanyName_Jsonclick ;
      private string edtSupplier_GenContactName_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplier_GenContactPhone_Jsonclick ;
      private string edtSupplier_GenVisitingAddress_Jsonclick ;
      private string edtSupplier_GenPostalAddress_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV47IsAuthorized_Update ;
      private bool AV49IsAuthorized_Delete ;
      private bool AV51IsAuthorized_Insert ;
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
      private bool n69Supplier_GenContactName ;
      private bool n70Supplier_GenContactPhone ;
      private bool n67Supplier_GenVisitingAddress ;
      private bool n68Supplier_GenPostalAddress ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV29TFSupplier_GenCompanyName ;
      private string AV30TFSupplier_GenCompanyName_Sel ;
      private string AV35TFSupplier_GenContactName ;
      private string AV36TFSupplier_GenContactName_Sel ;
      private string AV31TFSupplier_GenVisitingAddress ;
      private string AV32TFSupplier_GenVisitingAddress_Sel ;
      private string AV33TFSupplier_GenPostalAddress ;
      private string AV34TFSupplier_GenPostalAddress_Sel ;
      private string AV45GridAppliedFilters ;
      private string A65Supplier_GenKvKNumber ;
      private string A66Supplier_GenCompanyName ;
      private string A69Supplier_GenContactName ;
      private string A67Supplier_GenVisitingAddress ;
      private string A68Supplier_GenPostalAddress ;
      private string lV53Supplier_genwwds_1_filterfulltext ;
      private string lV54Supplier_genwwds_2_tfsupplier_gencompanyname ;
      private string lV56Supplier_genwwds_4_tfsupplier_gencontactname ;
      private string lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ;
      private string lV62Supplier_genwwds_10_tfsupplier_genpostaladdress ;
      private string AV53Supplier_genwwds_1_filterfulltext ;
      private string AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel ;
      private string AV54Supplier_genwwds_2_tfsupplier_gencompanyname ;
      private string AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel ;
      private string AV56Supplier_genwwds_4_tfsupplier_gencontactname ;
      private string AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ;
      private string AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ;
      private string AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ;
      private string AV62Supplier_genwwds_10_tfsupplier_genpostaladdress ;
      private IGxSession AV21Session ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H001M2_A68Supplier_GenPostalAddress ;
      private bool[] H001M2_n68Supplier_GenPostalAddress ;
      private string[] H001M2_A67Supplier_GenVisitingAddress ;
      private bool[] H001M2_n67Supplier_GenVisitingAddress ;
      private string[] H001M2_A70Supplier_GenContactPhone ;
      private bool[] H001M2_n70Supplier_GenContactPhone ;
      private string[] H001M2_A69Supplier_GenContactName ;
      private bool[] H001M2_n69Supplier_GenContactName ;
      private string[] H001M2_A66Supplier_GenCompanyName ;
      private string[] H001M2_A65Supplier_GenKvKNumber ;
      private short[] H001M2_A64Supplier_GenId ;
      private long[] H001M3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV40GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV41GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class supplier_genww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001M2( IGxContext context ,
                                             string AV53Supplier_genwwds_1_filterfulltext ,
                                             string AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV54Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV56Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV58Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV62Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Supplier_GenPostalAddress, Supplier_GenVisitingAddress, Supplier_GenContactPhone, Supplier_GenContactName, Supplier_GenCompanyName, Supplier_GenKvKNumber, Supplier_GenId";
         sFromString = " FROM Supplier_Gen";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV53Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV54Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV56Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV58Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV62Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY Supplier_GenId DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_GenCompanyName, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_GenCompanyName DESC, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_GenContactName, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_GenContactName DESC, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_GenContactPhone, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_GenContactPhone DESC, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_GenVisitingAddress, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_GenVisitingAddress DESC, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY Supplier_GenPostalAddress, Supplier_GenId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY Supplier_GenPostalAddress DESC, Supplier_GenId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY Supplier_GenId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H001M3( IGxContext context ,
                                             string AV53Supplier_genwwds_1_filterfulltext ,
                                             string AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel ,
                                             string AV54Supplier_genwwds_2_tfsupplier_gencompanyname ,
                                             string AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel ,
                                             string AV56Supplier_genwwds_4_tfsupplier_gencontactname ,
                                             string AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel ,
                                             string AV58Supplier_genwwds_6_tfsupplier_gencontactphone ,
                                             string AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel ,
                                             string AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress ,
                                             string AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel ,
                                             string AV62Supplier_genwwds_10_tfsupplier_genpostaladdress ,
                                             string A66Supplier_GenCompanyName ,
                                             string A69Supplier_GenContactName ,
                                             string A70Supplier_GenContactPhone ,
                                             string A67Supplier_GenVisitingAddress ,
                                             string A68Supplier_GenPostalAddress ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[15];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Supplier_Gen";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Supplier_genwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Supplier_GenCompanyName like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactName like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenContactPhone like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenVisitingAddress like '%' || :lV53Supplier_genwwds_1_filterfulltext) or ( Supplier_GenPostalAddress like '%' || :lV53Supplier_genwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Supplier_genwwds_2_tfsupplier_gencompanyname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName like :lV54Supplier_genwwds_2_tfsupplier_gencompanyname)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel)) && ! ( StringUtil.StrCmp(AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenCompanyName = ( :AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Supplier_GenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Supplier_genwwds_4_tfsupplier_gencontactname)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName like :lV56Supplier_genwwds_4_tfsupplier_gencontactname)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel)) && ! ( StringUtil.StrCmp(AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName = ( :AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactName IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Supplier_genwwds_6_tfsupplier_gencontactphone)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone like :lV58Supplier_genwwds_6_tfsupplier_gencontactphone)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel)) && ! ( StringUtil.StrCmp(AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone = ( :AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenContactPhone IS NULL or (char_length(trim(trailing ' ' from Supplier_GenContactPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Supplier_genwwds_8_tfsupplier_genvisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress like :lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress = ( :AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenVisitingAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Supplier_genwwds_10_tfsupplier_genpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress like :lV62Supplier_genwwds_10_tfsupplier_genpostaladdress)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress = ( :AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(Supplier_GenPostalAddress IS NULL or (char_length(trim(trailing ' ' from Supplier_GenPostalAddress))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H001M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH001M2;
          prmH001M2 = new Object[] {
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV58Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV62Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001M3;
          prmH001M3 = new Object[] {
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Supplier_genwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Supplier_genwwds_2_tfsupplier_gencompanyname",GXType.VarChar,40,0) ,
          new ParDef("AV55Supplier_genwwds_3_tfsupplier_gencompanyname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Supplier_genwwds_4_tfsupplier_gencontactname",GXType.VarChar,40,0) ,
          new ParDef("AV57Supplier_genwwds_5_tfsupplier_gencontactname_sel",GXType.VarChar,40,0) ,
          new ParDef("lV58Supplier_genwwds_6_tfsupplier_gencontactphone",GXType.Char,20,0) ,
          new ParDef("AV59Supplier_genwwds_7_tfsupplier_gencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("lV60Supplier_genwwds_8_tfsupplier_genvisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV61Supplier_genwwds_9_tfsupplier_genvisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV62Supplier_genwwds_10_tfsupplier_genpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV63Supplier_genwwds_11_tfsupplier_genpostaladdress_sel",GXType.VarChar,1024,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001M2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001M3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((short[]) buf[10])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
