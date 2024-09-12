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
   public class customerww : GXDataArea
   {
      public customerww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customerww( IGxContext context )
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
         AV60Pgmname = GetPar( "Pgmname");
         AV27TFCustomerKvkNumber = GetPar( "TFCustomerKvkNumber");
         AV28TFCustomerKvkNumber_Sel = GetPar( "TFCustomerKvkNumber_Sel");
         AV29TFCustomerName = GetPar( "TFCustomerName");
         AV30TFCustomerName_Sel = GetPar( "TFCustomerName_Sel");
         AV33TFCustomerEmail = GetPar( "TFCustomerEmail");
         AV34TFCustomerEmail_Sel = GetPar( "TFCustomerEmail_Sel");
         AV37TFCustomerPhone = GetPar( "TFCustomerPhone");
         AV38TFCustomerPhone_Sel = GetPar( "TFCustomerPhone_Sel");
         AV39TFCustomerVatNumber = GetPar( "TFCustomerVatNumber");
         AV40TFCustomerVatNumber_Sel = GetPar( "TFCustomerVatNumber_Sel");
         AV35TFCustomerVisitingAddress = GetPar( "TFCustomerVisitingAddress");
         AV36TFCustomerVisitingAddress_Sel = GetPar( "TFCustomerVisitingAddress_Sel");
         AV31TFCustomerPostalAddress = GetPar( "TFCustomerPostalAddress");
         AV32TFCustomerPostalAddress_Sel = GetPar( "TFCustomerPostalAddress_Sel");
         AV43TFCustomerTypeName = GetPar( "TFCustomerTypeName");
         AV44TFCustomerTypeName_Sel = GetPar( "TFCustomerTypeName_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
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
            return "customerww_Execute" ;
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
         PA1J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customerww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERKVKNUMBER", AV27TFCustomerKvkNumber);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERKVKNUMBER_SEL", AV28TFCustomerKvkNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERNAME", AV29TFCustomerName);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERNAME_SEL", AV30TFCustomerName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMEREMAIL", AV33TFCustomerEmail);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMEREMAIL_SEL", AV34TFCustomerEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERPHONE", StringUtil.RTrim( AV37TFCustomerPhone));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERPHONE_SEL", StringUtil.RTrim( AV38TFCustomerPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERVATNUMBER", AV39TFCustomerVatNumber);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERVATNUMBER_SEL", AV40TFCustomerVatNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERVISITINGADDRESS", AV35TFCustomerVisitingAddress);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERVISITINGADDRESS_SEL", AV36TFCustomerVisitingAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERPOSTALADDRESS", AV31TFCustomerPostalAddress);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERPOSTALADDRESS_SEL", AV32TFCustomerPostalAddress_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERTYPENAME", AV43TFCustomerTypeName);
         GxWebStd.gx_hidden_field( context, "vTFCUSTOMERTYPENAME_SEL", AV44TFCustomerTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE1J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1J2( ) ;
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
         return formatLink("customerww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CustomerWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Customers" ;
      }

      protected void WB1J0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtncreatecustomeraction_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtncreatecustomeraction_Jsonclick, 7, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111j1_client"+"'", TempTags, "", 2, "HLP_CustomerWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CustomerWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
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

      protected void START1J2( )
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
         Form.Meta.addItem("description", " Customers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1J0( ) ;
      }

      protected void WS1J2( )
      {
         START1J2( ) ;
         EVT1J2( ) ;
      }

      protected void EVT1J2( )
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
                              E121J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E131J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E141J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E151J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E161J2 ();
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
                              A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A41CustomerKvkNumber = cgiGet( edtCustomerKvkNumber_Internalname);
                              A3CustomerName = cgiGet( edtCustomerName_Internalname);
                              A5CustomerEmail = cgiGet( edtCustomerEmail_Internalname);
                              n5CustomerEmail = false;
                              A7CustomerPhone = cgiGet( edtCustomerPhone_Internalname);
                              n7CustomerPhone = false;
                              A14CustomerVatNumber = cgiGet( edtCustomerVatNumber_Internalname);
                              A6CustomerVisitingAddress = cgiGet( edtCustomerVisitingAddress_Internalname);
                              n6CustomerVisitingAddress = false;
                              A4CustomerPostalAddress = cgiGet( edtCustomerPostalAddress_Internalname);
                              n4CustomerPostalAddress = false;
                              A78CustomerTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n78CustomerTypeId = false;
                              A79CustomerTypeName = cgiGet( edtCustomerTypeName_Internalname);
                              A93CustomerLastLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerLastLine_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              AV58UpdateAction = cgiGet( edtavUpdateaction_Internalname);
                              AssignAttri("", false, edtavUpdateaction_Internalname, AV58UpdateAction);
                              AV59DeleteAction = cgiGet( edtavDeleteaction_Internalname);
                              AssignAttri("", false, edtavDeleteaction_Internalname, AV59DeleteAction);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E191J2 ();
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

      protected void WE1J2( )
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

      protected void PA1J2( )
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
                                       string AV60Pgmname ,
                                       string AV27TFCustomerKvkNumber ,
                                       string AV28TFCustomerKvkNumber_Sel ,
                                       string AV29TFCustomerName ,
                                       string AV30TFCustomerName_Sel ,
                                       string AV33TFCustomerEmail ,
                                       string AV34TFCustomerEmail_Sel ,
                                       string AV37TFCustomerPhone ,
                                       string AV38TFCustomerPhone_Sel ,
                                       string AV39TFCustomerVatNumber ,
                                       string AV40TFCustomerVatNumber_Sel ,
                                       string AV35TFCustomerVisitingAddress ,
                                       string AV36TFCustomerVisitingAddress_Sel ,
                                       string AV31TFCustomerPostalAddress ,
                                       string AV32TFCustomerPostalAddress_Sel ,
                                       string AV43TFCustomerTypeName ,
                                       string AV44TFCustomerTypeName_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1J2( ) ;
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
         RF1J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "CustomerWW";
         edtavUpdateaction_Enabled = 0;
         edtavDeleteaction_Enabled = 0;
      }

      protected void RF1J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181J2 ();
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
                                                 AV61Customerwwds_1_filterfulltext ,
                                                 AV63Customerwwds_3_tfcustomerkvknumber_sel ,
                                                 AV62Customerwwds_2_tfcustomerkvknumber ,
                                                 AV65Customerwwds_5_tfcustomername_sel ,
                                                 AV64Customerwwds_4_tfcustomername ,
                                                 AV67Customerwwds_7_tfcustomeremail_sel ,
                                                 AV66Customerwwds_6_tfcustomeremail ,
                                                 AV69Customerwwds_9_tfcustomerphone_sel ,
                                                 AV68Customerwwds_8_tfcustomerphone ,
                                                 AV71Customerwwds_11_tfcustomervatnumber_sel ,
                                                 AV70Customerwwds_10_tfcustomervatnumber ,
                                                 AV73Customerwwds_13_tfcustomervisitingaddress_sel ,
                                                 AV72Customerwwds_12_tfcustomervisitingaddress ,
                                                 AV75Customerwwds_15_tfcustomerpostaladdress_sel ,
                                                 AV74Customerwwds_14_tfcustomerpostaladdress ,
                                                 AV77Customerwwds_17_tfcustomertypename_sel ,
                                                 AV76Customerwwds_16_tfcustomertypename ,
                                                 A41CustomerKvkNumber ,
                                                 A3CustomerName ,
                                                 A5CustomerEmail ,
                                                 A7CustomerPhone ,
                                                 A14CustomerVatNumber ,
                                                 A6CustomerVisitingAddress ,
                                                 A4CustomerPostalAddress ,
                                                 A79CustomerTypeName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
            lV62Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV62Customerwwds_2_tfcustomerkvknumber), "%", "");
            lV64Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV64Customerwwds_4_tfcustomername), "%", "");
            lV66Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV66Customerwwds_6_tfcustomeremail), "%", "");
            lV68Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV68Customerwwds_8_tfcustomerphone), 20, "%");
            lV70Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV70Customerwwds_10_tfcustomervatnumber), "%", "");
            lV72Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV72Customerwwds_12_tfcustomervisitingaddress), "%", "");
            lV74Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV74Customerwwds_14_tfcustomerpostaladdress), "%", "");
            lV76Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV76Customerwwds_16_tfcustomertypename), "%", "");
            /* Using cursor H001J2 */
            pr_default.execute(0, new Object[] {lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV62Customerwwds_2_tfcustomerkvknumber, AV63Customerwwds_3_tfcustomerkvknumber_sel, lV64Customerwwds_4_tfcustomername, AV65Customerwwds_5_tfcustomername_sel, lV66Customerwwds_6_tfcustomeremail, AV67Customerwwds_7_tfcustomeremail_sel, lV68Customerwwds_8_tfcustomerphone, AV69Customerwwds_9_tfcustomerphone_sel, lV70Customerwwds_10_tfcustomervatnumber, AV71Customerwwds_11_tfcustomervatnumber_sel, lV72Customerwwds_12_tfcustomervisitingaddress, AV73Customerwwds_13_tfcustomervisitingaddress_sel, lV74Customerwwds_14_tfcustomerpostaladdress, AV75Customerwwds_15_tfcustomerpostaladdress_sel, lV76Customerwwds_16_tfcustomertypename, AV77Customerwwds_17_tfcustomertypename_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A93CustomerLastLine = H001J2_A93CustomerLastLine[0];
               A79CustomerTypeName = H001J2_A79CustomerTypeName[0];
               A78CustomerTypeId = H001J2_A78CustomerTypeId[0];
               n78CustomerTypeId = H001J2_n78CustomerTypeId[0];
               A4CustomerPostalAddress = H001J2_A4CustomerPostalAddress[0];
               n4CustomerPostalAddress = H001J2_n4CustomerPostalAddress[0];
               A6CustomerVisitingAddress = H001J2_A6CustomerVisitingAddress[0];
               n6CustomerVisitingAddress = H001J2_n6CustomerVisitingAddress[0];
               A14CustomerVatNumber = H001J2_A14CustomerVatNumber[0];
               A7CustomerPhone = H001J2_A7CustomerPhone[0];
               n7CustomerPhone = H001J2_n7CustomerPhone[0];
               A5CustomerEmail = H001J2_A5CustomerEmail[0];
               n5CustomerEmail = H001J2_n5CustomerEmail[0];
               A3CustomerName = H001J2_A3CustomerName[0];
               A41CustomerKvkNumber = H001J2_A41CustomerKvkNumber[0];
               A1CustomerId = H001J2_A1CustomerId[0];
               A79CustomerTypeName = H001J2_A79CustomerTypeName[0];
               /* Execute user event: Grid.Load */
               E191J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1J0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
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
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Customerwwds_1_filterfulltext ,
                                              AV63Customerwwds_3_tfcustomerkvknumber_sel ,
                                              AV62Customerwwds_2_tfcustomerkvknumber ,
                                              AV65Customerwwds_5_tfcustomername_sel ,
                                              AV64Customerwwds_4_tfcustomername ,
                                              AV67Customerwwds_7_tfcustomeremail_sel ,
                                              AV66Customerwwds_6_tfcustomeremail ,
                                              AV69Customerwwds_9_tfcustomerphone_sel ,
                                              AV68Customerwwds_8_tfcustomerphone ,
                                              AV71Customerwwds_11_tfcustomervatnumber_sel ,
                                              AV70Customerwwds_10_tfcustomervatnumber ,
                                              AV73Customerwwds_13_tfcustomervisitingaddress_sel ,
                                              AV72Customerwwds_12_tfcustomervisitingaddress ,
                                              AV75Customerwwds_15_tfcustomerpostaladdress_sel ,
                                              AV74Customerwwds_14_tfcustomerpostaladdress ,
                                              AV77Customerwwds_17_tfcustomertypename_sel ,
                                              AV76Customerwwds_16_tfcustomertypename ,
                                              A41CustomerKvkNumber ,
                                              A3CustomerName ,
                                              A5CustomerEmail ,
                                              A7CustomerPhone ,
                                              A14CustomerVatNumber ,
                                              A6CustomerVisitingAddress ,
                                              A4CustomerPostalAddress ,
                                              A79CustomerTypeName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV61Customerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Customerwwds_1_filterfulltext), "%", "");
         lV62Customerwwds_2_tfcustomerkvknumber = StringUtil.Concat( StringUtil.RTrim( AV62Customerwwds_2_tfcustomerkvknumber), "%", "");
         lV64Customerwwds_4_tfcustomername = StringUtil.Concat( StringUtil.RTrim( AV64Customerwwds_4_tfcustomername), "%", "");
         lV66Customerwwds_6_tfcustomeremail = StringUtil.Concat( StringUtil.RTrim( AV66Customerwwds_6_tfcustomeremail), "%", "");
         lV68Customerwwds_8_tfcustomerphone = StringUtil.PadR( StringUtil.RTrim( AV68Customerwwds_8_tfcustomerphone), 20, "%");
         lV70Customerwwds_10_tfcustomervatnumber = StringUtil.Concat( StringUtil.RTrim( AV70Customerwwds_10_tfcustomervatnumber), "%", "");
         lV72Customerwwds_12_tfcustomervisitingaddress = StringUtil.Concat( StringUtil.RTrim( AV72Customerwwds_12_tfcustomervisitingaddress), "%", "");
         lV74Customerwwds_14_tfcustomerpostaladdress = StringUtil.Concat( StringUtil.RTrim( AV74Customerwwds_14_tfcustomerpostaladdress), "%", "");
         lV76Customerwwds_16_tfcustomertypename = StringUtil.Concat( StringUtil.RTrim( AV76Customerwwds_16_tfcustomertypename), "%", "");
         /* Using cursor H001J3 */
         pr_default.execute(1, new Object[] {lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV61Customerwwds_1_filterfulltext, lV62Customerwwds_2_tfcustomerkvknumber, AV63Customerwwds_3_tfcustomerkvknumber_sel, lV64Customerwwds_4_tfcustomername, AV65Customerwwds_5_tfcustomername_sel, lV66Customerwwds_6_tfcustomeremail, AV67Customerwwds_7_tfcustomeremail_sel, lV68Customerwwds_8_tfcustomerphone, AV69Customerwwds_9_tfcustomerphone_sel, lV70Customerwwds_10_tfcustomervatnumber, AV71Customerwwds_11_tfcustomervatnumber_sel, lV72Customerwwds_12_tfcustomervisitingaddress, AV73Customerwwds_13_tfcustomervisitingaddress_sel, lV74Customerwwds_14_tfcustomerpostaladdress, AV75Customerwwds_15_tfcustomerpostaladdress_sel, lV76Customerwwds_16_tfcustomertypename, AV77Customerwwds_17_tfcustomertypename_sel});
         GRID_nRecordCount = H001J3_AGRID_nRecordCount[0];
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
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV60Pgmname, AV27TFCustomerKvkNumber, AV28TFCustomerKvkNumber_Sel, AV29TFCustomerName, AV30TFCustomerName_Sel, AV33TFCustomerEmail, AV34TFCustomerEmail_Sel, AV37TFCustomerPhone, AV38TFCustomerPhone_Sel, AV39TFCustomerVatNumber, AV40TFCustomerVatNumber_Sel, AV35TFCustomerVisitingAddress, AV36TFCustomerVisitingAddress_Sel, AV31TFCustomerPostalAddress, AV32TFCustomerPostalAddress_Sel, AV43TFCustomerTypeName, AV44TFCustomerTypeName_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "CustomerWW";
         edtavUpdateaction_Enabled = 0;
         edtavDeleteaction_Enabled = 0;
         edtCustomerId_Enabled = 0;
         edtCustomerKvkNumber_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerEmail_Enabled = 0;
         edtCustomerPhone_Enabled = 0;
         edtCustomerVatNumber_Enabled = 0;
         edtCustomerVisitingAddress_Enabled = 0;
         edtCustomerPostalAddress_Enabled = 0;
         edtCustomerTypeId_Enabled = 0;
         edtCustomerTypeName_Enabled = 0;
         edtCustomerLastLine_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV45DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV50GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
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
         E171J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171J2( )
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
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV47GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV46GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Customers";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV45DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV45DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV21Session.Get("CustomerWWColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("CustomerWWColumnsSelector");
            AV19ColumnsSelector.FromXml(AV17ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtCustomerKvkNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerKvkNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerKvkNumber_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerEmail_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerPhone_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerVatNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerVatNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerVatNumber_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerVisitingAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerVisitingAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerVisitingAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerPostalAddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerPostalAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerPostalAddress_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtCustomerTypeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCustomerTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerTypeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         AV50GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
         GXt_char2 = AV51GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV51GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         AV61Customerwwds_1_filterfulltext = AV16FilterFullText;
         AV62Customerwwds_2_tfcustomerkvknumber = AV27TFCustomerKvkNumber;
         AV63Customerwwds_3_tfcustomerkvknumber_sel = AV28TFCustomerKvkNumber_Sel;
         AV64Customerwwds_4_tfcustomername = AV29TFCustomerName;
         AV65Customerwwds_5_tfcustomername_sel = AV30TFCustomerName_Sel;
         AV66Customerwwds_6_tfcustomeremail = AV33TFCustomerEmail;
         AV67Customerwwds_7_tfcustomeremail_sel = AV34TFCustomerEmail_Sel;
         AV68Customerwwds_8_tfcustomerphone = AV37TFCustomerPhone;
         AV69Customerwwds_9_tfcustomerphone_sel = AV38TFCustomerPhone_Sel;
         AV70Customerwwds_10_tfcustomervatnumber = AV39TFCustomerVatNumber;
         AV71Customerwwds_11_tfcustomervatnumber_sel = AV40TFCustomerVatNumber_Sel;
         AV72Customerwwds_12_tfcustomervisitingaddress = AV35TFCustomerVisitingAddress;
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = AV36TFCustomerVisitingAddress_Sel;
         AV74Customerwwds_14_tfcustomerpostaladdress = AV31TFCustomerPostalAddress;
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = AV32TFCustomerPostalAddress_Sel;
         AV76Customerwwds_16_tfcustomertypename = AV43TFCustomerTypeName;
         AV77Customerwwds_17_tfcustomertypename_sel = AV44TFCustomerTypeName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E131J2( )
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
            AV48PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV48PageToGo) ;
         }
      }

      protected void E141J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E151J2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerKvkNumber") == 0 )
            {
               AV27TFCustomerKvkNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFCustomerKvkNumber", AV27TFCustomerKvkNumber);
               AV28TFCustomerKvkNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFCustomerKvkNumber_Sel", AV28TFCustomerKvkNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerName") == 0 )
            {
               AV29TFCustomerName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFCustomerName", AV29TFCustomerName);
               AV30TFCustomerName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFCustomerName_Sel", AV30TFCustomerName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerEmail") == 0 )
            {
               AV33TFCustomerEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFCustomerEmail", AV33TFCustomerEmail);
               AV34TFCustomerEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFCustomerEmail_Sel", AV34TFCustomerEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerPhone") == 0 )
            {
               AV37TFCustomerPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFCustomerPhone", AV37TFCustomerPhone);
               AV38TFCustomerPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFCustomerPhone_Sel", AV38TFCustomerPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerVatNumber") == 0 )
            {
               AV39TFCustomerVatNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFCustomerVatNumber", AV39TFCustomerVatNumber);
               AV40TFCustomerVatNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFCustomerVatNumber_Sel", AV40TFCustomerVatNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerVisitingAddress") == 0 )
            {
               AV35TFCustomerVisitingAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFCustomerVisitingAddress", AV35TFCustomerVisitingAddress);
               AV36TFCustomerVisitingAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFCustomerVisitingAddress_Sel", AV36TFCustomerVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerPostalAddress") == 0 )
            {
               AV31TFCustomerPostalAddress = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFCustomerPostalAddress", AV31TFCustomerPostalAddress);
               AV32TFCustomerPostalAddress_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFCustomerPostalAddress_Sel", AV32TFCustomerPostalAddress_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CustomerTypeName") == 0 )
            {
               AV43TFCustomerTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFCustomerTypeName", AV43TFCustomerTypeName);
               AV44TFCustomerTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFCustomerTypeName_Sel", AV44TFCustomerTypeName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV58UpdateAction = "<i class=\"disabledIconBtn fas fa-pen\"></i>";
         AssignAttri("", false, edtavUpdateaction_Internalname, AV58UpdateAction);
         AV59DeleteAction = "<i class=\"disabledIconBtn fas fa-xmark\"></i>";
         AssignAttri("", false, edtavDeleteaction_Internalname, AV59DeleteAction);
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

      protected void E161J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CustomerWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E121J2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerWWFilters")),UrlEncode(StringUtil.RTrim(AV60Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("CustomerWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV23ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CustomerWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV23ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV23ManageFiltersXml) ;
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
               S182 ();
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

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerKvkNumber",  "",  "KVK Number",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerVatNumber",  "",  "VAT",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerVisitingAddress",  "",  "Visiting Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerPostalAddress",  "",  "Postal Address",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "CustomerTypeName",  "",  "Type",  true,  "") ;
         GXt_char2 = AV18UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CustomerWWColumnsSelector", out  GXt_char2) ;
         AV18UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserCustomValue)) ) )
         {
            AV20ColumnsSelectorAux.FromXml(AV18UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV20ColumnsSelectorAux, ref  AV19ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV22ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CustomerWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFCustomerKvkNumber = "";
         AssignAttri("", false, "AV27TFCustomerKvkNumber", AV27TFCustomerKvkNumber);
         AV28TFCustomerKvkNumber_Sel = "";
         AssignAttri("", false, "AV28TFCustomerKvkNumber_Sel", AV28TFCustomerKvkNumber_Sel);
         AV29TFCustomerName = "";
         AssignAttri("", false, "AV29TFCustomerName", AV29TFCustomerName);
         AV30TFCustomerName_Sel = "";
         AssignAttri("", false, "AV30TFCustomerName_Sel", AV30TFCustomerName_Sel);
         AV33TFCustomerEmail = "";
         AssignAttri("", false, "AV33TFCustomerEmail", AV33TFCustomerEmail);
         AV34TFCustomerEmail_Sel = "";
         AssignAttri("", false, "AV34TFCustomerEmail_Sel", AV34TFCustomerEmail_Sel);
         AV37TFCustomerPhone = "";
         AssignAttri("", false, "AV37TFCustomerPhone", AV37TFCustomerPhone);
         AV38TFCustomerPhone_Sel = "";
         AssignAttri("", false, "AV38TFCustomerPhone_Sel", AV38TFCustomerPhone_Sel);
         AV39TFCustomerVatNumber = "";
         AssignAttri("", false, "AV39TFCustomerVatNumber", AV39TFCustomerVatNumber);
         AV40TFCustomerVatNumber_Sel = "";
         AssignAttri("", false, "AV40TFCustomerVatNumber_Sel", AV40TFCustomerVatNumber_Sel);
         AV35TFCustomerVisitingAddress = "";
         AssignAttri("", false, "AV35TFCustomerVisitingAddress", AV35TFCustomerVisitingAddress);
         AV36TFCustomerVisitingAddress_Sel = "";
         AssignAttri("", false, "AV36TFCustomerVisitingAddress_Sel", AV36TFCustomerVisitingAddress_Sel);
         AV31TFCustomerPostalAddress = "";
         AssignAttri("", false, "AV31TFCustomerPostalAddress", AV31TFCustomerPostalAddress);
         AV32TFCustomerPostalAddress_Sel = "";
         AssignAttri("", false, "AV32TFCustomerPostalAddress_Sel", AV32TFCustomerPostalAddress_Sel);
         AV43TFCustomerTypeName = "";
         AssignAttri("", false, "AV43TFCustomerTypeName", AV43TFCustomerTypeName);
         AV44TFCustomerTypeName_Sel = "";
         AssignAttri("", false, "AV44TFCustomerTypeName_Sel", AV44TFCustomerTypeName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
         S182 ();
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

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV78GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERKVKNUMBER") == 0 )
            {
               AV27TFCustomerKvkNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFCustomerKvkNumber", AV27TFCustomerKvkNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERKVKNUMBER_SEL") == 0 )
            {
               AV28TFCustomerKvkNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFCustomerKvkNumber_Sel", AV28TFCustomerKvkNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME") == 0 )
            {
               AV29TFCustomerName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFCustomerName", AV29TFCustomerName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERNAME_SEL") == 0 )
            {
               AV30TFCustomerName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFCustomerName_Sel", AV30TFCustomerName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMEREMAIL") == 0 )
            {
               AV33TFCustomerEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFCustomerEmail", AV33TFCustomerEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMEREMAIL_SEL") == 0 )
            {
               AV34TFCustomerEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFCustomerEmail_Sel", AV34TFCustomerEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPHONE") == 0 )
            {
               AV37TFCustomerPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCustomerPhone", AV37TFCustomerPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPHONE_SEL") == 0 )
            {
               AV38TFCustomerPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCustomerPhone_Sel", AV38TFCustomerPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVATNUMBER") == 0 )
            {
               AV39TFCustomerVatNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFCustomerVatNumber", AV39TFCustomerVatNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVATNUMBER_SEL") == 0 )
            {
               AV40TFCustomerVatNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFCustomerVatNumber_Sel", AV40TFCustomerVatNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVISITINGADDRESS") == 0 )
            {
               AV35TFCustomerVisitingAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFCustomerVisitingAddress", AV35TFCustomerVisitingAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERVISITINGADDRESS_SEL") == 0 )
            {
               AV36TFCustomerVisitingAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFCustomerVisitingAddress_Sel", AV36TFCustomerVisitingAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPOSTALADDRESS") == 0 )
            {
               AV31TFCustomerPostalAddress = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFCustomerPostalAddress", AV31TFCustomerPostalAddress);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERPOSTALADDRESS_SEL") == 0 )
            {
               AV32TFCustomerPostalAddress_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFCustomerPostalAddress_Sel", AV32TFCustomerPostalAddress_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERTYPENAME") == 0 )
            {
               AV43TFCustomerTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFCustomerTypeName", AV43TFCustomerTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCUSTOMERTYPENAME_SEL") == 0 )
            {
               AV44TFCustomerTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFCustomerTypeName_Sel", AV44TFCustomerTypeName_Sel);
            }
            AV78GXV1 = (int)(AV78GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCustomerKvkNumber_Sel)),  AV28TFCustomerKvkNumber_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCustomerName_Sel)),  AV30TFCustomerName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCustomerEmail_Sel)),  AV34TFCustomerEmail_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCustomerPhone_Sel)),  AV38TFCustomerPhone_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCustomerVatNumber_Sel)),  AV40TFCustomerVatNumber_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCustomerVisitingAddress_Sel)),  AV36TFCustomerVisitingAddress_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCustomerPostalAddress_Sel)),  AV32TFCustomerPostalAddress_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCustomerTypeName_Sel)),  AV44TFCustomerTypeName_Sel, out  GXt_char10) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCustomerKvkNumber)),  AV27TFCustomerKvkNumber, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCustomerName)),  AV29TFCustomerName, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCustomerEmail)),  AV33TFCustomerEmail, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCustomerPhone)),  AV37TFCustomerPhone, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCustomerVatNumber)),  AV39TFCustomerVatNumber, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCustomerVisitingAddress)),  AV35TFCustomerVisitingAddress, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCustomerPostalAddress)),  AV31TFCustomerPostalAddress, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCustomerTypeName)),  AV43TFCustomerTypeName, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERKVKNUMBER",  "KVK Number",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCustomerKvkNumber)),  0,  AV27TFCustomerKvkNumber,  AV27TFCustomerKvkNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCustomerKvkNumber_Sel)),  AV28TFCustomerKvkNumber_Sel,  AV28TFCustomerKvkNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERNAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCustomerName)),  0,  AV29TFCustomerName,  AV29TFCustomerName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCustomerName_Sel)),  AV30TFCustomerName_Sel,  AV30TFCustomerName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMEREMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCustomerEmail)),  0,  AV33TFCustomerEmail,  AV33TFCustomerEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCustomerEmail_Sel)),  AV34TFCustomerEmail_Sel,  AV34TFCustomerEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERPHONE",  "Phone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCustomerPhone)),  0,  AV37TFCustomerPhone,  AV37TFCustomerPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCustomerPhone_Sel)),  AV38TFCustomerPhone_Sel,  AV38TFCustomerPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERVATNUMBER",  "VAT",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCustomerVatNumber)),  0,  AV39TFCustomerVatNumber,  AV39TFCustomerVatNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCustomerVatNumber_Sel)),  AV40TFCustomerVatNumber_Sel,  AV40TFCustomerVatNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERVISITINGADDRESS",  "Visiting Address",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCustomerVisitingAddress)),  0,  AV35TFCustomerVisitingAddress,  AV35TFCustomerVisitingAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCustomerVisitingAddress_Sel)),  AV36TFCustomerVisitingAddress_Sel,  AV36TFCustomerVisitingAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERPOSTALADDRESS",  "Postal Address",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCustomerPostalAddress)),  0,  AV31TFCustomerPostalAddress,  AV31TFCustomerPostalAddress,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCustomerPostalAddress_Sel)),  AV32TFCustomerPostalAddress_Sel,  AV32TFCustomerPostalAddress_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCUSTOMERTYPENAME",  "Type",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCustomerTypeName)),  0,  AV43TFCustomerTypeName,  AV43TFCustomerTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCustomerTypeName_Sel)),  AV44TFCustomerTypeName_Sel,  AV44TFCustomerTypeName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Customer";
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
         PA1J2( ) ;
         WS1J2( ) ;
         WE1J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126313534", true, true);
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
         context.AddJavascriptSource("customerww.js", "?20249126313535", false, true);
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
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_idx;
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER_"+sGXsfl_37_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_idx;
         edtCustomerEmail_Internalname = "CUSTOMEREMAIL_"+sGXsfl_37_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_37_idx;
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER_"+sGXsfl_37_idx;
         edtCustomerVisitingAddress_Internalname = "CUSTOMERVISITINGADDRESS_"+sGXsfl_37_idx;
         edtCustomerPostalAddress_Internalname = "CUSTOMERPOSTALADDRESS_"+sGXsfl_37_idx;
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID_"+sGXsfl_37_idx;
         edtCustomerTypeName_Internalname = "CUSTOMERTYPENAME_"+sGXsfl_37_idx;
         edtCustomerLastLine_Internalname = "CUSTOMERLASTLINE_"+sGXsfl_37_idx;
         edtavUpdateaction_Internalname = "vUPDATEACTION_"+sGXsfl_37_idx;
         edtavDeleteaction_Internalname = "vDELETEACTION_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtCustomerId_Internalname = "CUSTOMERID_"+sGXsfl_37_fel_idx;
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER_"+sGXsfl_37_fel_idx;
         edtCustomerName_Internalname = "CUSTOMERNAME_"+sGXsfl_37_fel_idx;
         edtCustomerEmail_Internalname = "CUSTOMEREMAIL_"+sGXsfl_37_fel_idx;
         edtCustomerPhone_Internalname = "CUSTOMERPHONE_"+sGXsfl_37_fel_idx;
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER_"+sGXsfl_37_fel_idx;
         edtCustomerVisitingAddress_Internalname = "CUSTOMERVISITINGADDRESS_"+sGXsfl_37_fel_idx;
         edtCustomerPostalAddress_Internalname = "CUSTOMERPOSTALADDRESS_"+sGXsfl_37_fel_idx;
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID_"+sGXsfl_37_fel_idx;
         edtCustomerTypeName_Internalname = "CUSTOMERTYPENAME_"+sGXsfl_37_fel_idx;
         edtCustomerLastLine_Internalname = "CUSTOMERLASTLINE_"+sGXsfl_37_fel_idx;
         edtavUpdateaction_Internalname = "vUPDATEACTION_"+sGXsfl_37_fel_idx;
         edtavDeleteaction_Internalname = "vDELETEACTION_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB1J0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerKvkNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerKvkNumber_Internalname,(string)A41CustomerKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerKvkNumber_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerName_Internalname,(string)A3CustomerName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerEmail_Internalname,(string)A5CustomerEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A5CustomerEmail,(string)"",(string)"",(string)"",(string)edtCustomerEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A7CustomerPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerPhone_Internalname,StringUtil.RTrim( A7CustomerPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCustomerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerVatNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerVatNumber_Internalname,(string)A14CustomerVatNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerVatNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerVatNumber_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerVisitingAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerVisitingAddress_Internalname,(string)A6CustomerVisitingAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A6CustomerVisitingAddress),(string)"_blank",(string)"",(string)"",(string)edtCustomerVisitingAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerVisitingAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerPostalAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerPostalAddress_Internalname,(string)A4CustomerPostalAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4CustomerPostalAddress),(string)"_blank",(string)"",(string)"",(string)edtCustomerPostalAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerPostalAddress_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A78CustomerTypeId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCustomerTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerTypeName_Internalname,(string)A79CustomerTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCustomerTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCustomerLastLine_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A93CustomerLastLine), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A93CustomerLastLine), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCustomerLastLine_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdateaction_Internalname,StringUtil.RTrim( AV58UpdateAction),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUpdateaction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdateaction_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleteaction_Internalname,StringUtil.RTrim( AV59DeleteAction),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeleteaction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleteaction_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1J2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerKvkNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "KVK Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerVatNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "VAT") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerVisitingAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Visiting Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerPostalAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Postal Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCustomerTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A41CustomerKvkNumber));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerKvkNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A3CustomerName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CustomerEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A7CustomerPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A14CustomerVatNumber));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerVatNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A6CustomerVisitingAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerVisitingAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A4CustomerPostalAddress));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerPostalAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78CustomerTypeId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A79CustomerTypeName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCustomerTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A93CustomerLastLine), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58UpdateAction)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdateaction_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59DeleteAction)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleteaction_Enabled), 5, 0, ".", "")));
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
         bttBtncreatecustomeraction_Internalname = "BTNCREATECUSTOMERACTION";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerKvkNumber_Internalname = "CUSTOMERKVKNUMBER";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerEmail_Internalname = "CUSTOMEREMAIL";
         edtCustomerPhone_Internalname = "CUSTOMERPHONE";
         edtCustomerVatNumber_Internalname = "CUSTOMERVATNUMBER";
         edtCustomerVisitingAddress_Internalname = "CUSTOMERVISITINGADDRESS";
         edtCustomerPostalAddress_Internalname = "CUSTOMERPOSTALADDRESS";
         edtCustomerTypeId_Internalname = "CUSTOMERTYPEID";
         edtCustomerTypeName_Internalname = "CUSTOMERTYPENAME";
         edtCustomerLastLine_Internalname = "CUSTOMERLASTLINE";
         edtavUpdateaction_Internalname = "vUPDATEACTION";
         edtavDeleteaction_Internalname = "vDELETEACTION";
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
         edtavDeleteaction_Jsonclick = "";
         edtavDeleteaction_Enabled = 0;
         edtavUpdateaction_Jsonclick = "";
         edtavUpdateaction_Enabled = 0;
         edtCustomerLastLine_Jsonclick = "";
         edtCustomerTypeName_Jsonclick = "";
         edtCustomerTypeId_Jsonclick = "";
         edtCustomerPostalAddress_Jsonclick = "";
         edtCustomerVisitingAddress_Jsonclick = "";
         edtCustomerVatNumber_Jsonclick = "";
         edtCustomerPhone_Jsonclick = "";
         edtCustomerEmail_Jsonclick = "";
         edtCustomerName_Jsonclick = "";
         edtCustomerKvkNumber_Jsonclick = "";
         edtCustomerId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtCustomerTypeName_Visible = -1;
         edtCustomerPostalAddress_Visible = -1;
         edtCustomerVisitingAddress_Visible = -1;
         edtCustomerVatNumber_Visible = -1;
         edtCustomerPhone_Visible = -1;
         edtCustomerEmail_Visible = -1;
         edtCustomerName_Visible = -1;
         edtCustomerKvkNumber_Visible = -1;
         edtCustomerLastLine_Enabled = 0;
         edtCustomerTypeName_Enabled = 0;
         edtCustomerTypeId_Enabled = 0;
         edtCustomerPostalAddress_Enabled = 0;
         edtCustomerVisitingAddress_Enabled = 0;
         edtCustomerVatNumber_Enabled = 0;
         edtCustomerPhone_Enabled = 0;
         edtCustomerEmail_Enabled = 0;
         edtCustomerName_Enabled = 0;
         edtCustomerKvkNumber_Enabled = 0;
         edtCustomerId_Enabled = 0;
         subGrid_Sortable = 0;
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
         Ddo_grid_Datalistproc = "CustomerWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:CustomerKvkNumber|2:CustomerName|3:CustomerEmail|4:CustomerPhone|5:CustomerVatNumber|6:CustomerVisitingAddress|7:CustomerPostalAddress|9:CustomerTypeName";
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
         Form.Caption = " Customers";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtCustomerKvkNumber_Visible","ctrl":"CUSTOMERKVKNUMBER","prop":"Visible"},{"av":"edtCustomerName_Visible","ctrl":"CUSTOMERNAME","prop":"Visible"},{"av":"edtCustomerEmail_Visible","ctrl":"CUSTOMEREMAIL","prop":"Visible"},{"av":"edtCustomerPhone_Visible","ctrl":"CUSTOMERPHONE","prop":"Visible"},{"av":"edtCustomerVatNumber_Visible","ctrl":"CUSTOMERVATNUMBER","prop":"Visible"},{"av":"edtCustomerVisitingAddress_Visible","ctrl":"CUSTOMERVISITINGADDRESS","prop":"Visible"},{"av":"edtCustomerPostalAddress_Visible","ctrl":"CUSTOMERPOSTALADDRESS","prop":"Visible"},{"av":"edtCustomerTypeName_Visible","ctrl":"CUSTOMERTYPENAME","prop":"Visible"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV50GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E131J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E141J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E151J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E191J2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV58UpdateAction","fld":"vUPDATEACTION"},{"av":"AV59DeleteAction","fld":"vDELETEACTION"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E161J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtCustomerKvkNumber_Visible","ctrl":"CUSTOMERKVKNUMBER","prop":"Visible"},{"av":"edtCustomerName_Visible","ctrl":"CUSTOMERNAME","prop":"Visible"},{"av":"edtCustomerEmail_Visible","ctrl":"CUSTOMEREMAIL","prop":"Visible"},{"av":"edtCustomerPhone_Visible","ctrl":"CUSTOMERPHONE","prop":"Visible"},{"av":"edtCustomerVatNumber_Visible","ctrl":"CUSTOMERVATNUMBER","prop":"Visible"},{"av":"edtCustomerVisitingAddress_Visible","ctrl":"CUSTOMERVISITINGADDRESS","prop":"Visible"},{"av":"edtCustomerPostalAddress_Visible","ctrl":"CUSTOMERPOSTALADDRESS","prop":"Visible"},{"av":"edtCustomerTypeName_Visible","ctrl":"CUSTOMERTYPENAME","prop":"Visible"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV50GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E121J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27TFCustomerKvkNumber","fld":"vTFCUSTOMERKVKNUMBER"},{"av":"AV28TFCustomerKvkNumber_Sel","fld":"vTFCUSTOMERKVKNUMBER_SEL"},{"av":"AV29TFCustomerName","fld":"vTFCUSTOMERNAME"},{"av":"AV30TFCustomerName_Sel","fld":"vTFCUSTOMERNAME_SEL"},{"av":"AV33TFCustomerEmail","fld":"vTFCUSTOMEREMAIL"},{"av":"AV34TFCustomerEmail_Sel","fld":"vTFCUSTOMEREMAIL_SEL"},{"av":"AV37TFCustomerPhone","fld":"vTFCUSTOMERPHONE"},{"av":"AV38TFCustomerPhone_Sel","fld":"vTFCUSTOMERPHONE_SEL"},{"av":"AV39TFCustomerVatNumber","fld":"vTFCUSTOMERVATNUMBER"},{"av":"AV40TFCustomerVatNumber_Sel","fld":"vTFCUSTOMERVATNUMBER_SEL"},{"av":"AV35TFCustomerVisitingAddress","fld":"vTFCUSTOMERVISITINGADDRESS"},{"av":"AV36TFCustomerVisitingAddress_Sel","fld":"vTFCUSTOMERVISITINGADDRESS_SEL"},{"av":"AV31TFCustomerPostalAddress","fld":"vTFCUSTOMERPOSTALADDRESS"},{"av":"AV32TFCustomerPostalAddress_Sel","fld":"vTFCUSTOMERPOSTALADDRESS_SEL"},{"av":"AV43TFCustomerTypeName","fld":"vTFCUSTOMERTYPENAME"},{"av":"AV44TFCustomerTypeName_Sel","fld":"vTFCUSTOMERTYPENAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtCustomerKvkNumber_Visible","ctrl":"CUSTOMERKVKNUMBER","prop":"Visible"},{"av":"edtCustomerName_Visible","ctrl":"CUSTOMERNAME","prop":"Visible"},{"av":"edtCustomerEmail_Visible","ctrl":"CUSTOMEREMAIL","prop":"Visible"},{"av":"edtCustomerPhone_Visible","ctrl":"CUSTOMERPHONE","prop":"Visible"},{"av":"edtCustomerVatNumber_Visible","ctrl":"CUSTOMERVATNUMBER","prop":"Visible"},{"av":"edtCustomerVisitingAddress_Visible","ctrl":"CUSTOMERVISITINGADDRESS","prop":"Visible"},{"av":"edtCustomerPostalAddress_Visible","ctrl":"CUSTOMERPOSTALADDRESS","prop":"Visible"},{"av":"edtCustomerTypeName_Visible","ctrl":"CUSTOMERTYPENAME","prop":"Visible"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV50GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOCREATECUSTOMERACTION'","""{"handler":"E111J1","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERTYPEID","""{"handler":"Valid_Customertypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Deleteaction","iparms":[]}""");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV19ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV60Pgmname = "";
         AV27TFCustomerKvkNumber = "";
         AV28TFCustomerKvkNumber_Sel = "";
         AV29TFCustomerName = "";
         AV30TFCustomerName_Sel = "";
         AV33TFCustomerEmail = "";
         AV34TFCustomerEmail_Sel = "";
         AV37TFCustomerPhone = "";
         AV38TFCustomerPhone_Sel = "";
         AV39TFCustomerVatNumber = "";
         AV40TFCustomerVatNumber_Sel = "";
         AV35TFCustomerVisitingAddress = "";
         AV36TFCustomerVisitingAddress_Sel = "";
         AV31TFCustomerPostalAddress = "";
         AV32TFCustomerPostalAddress_Sel = "";
         AV43TFCustomerTypeName = "";
         AV44TFCustomerTypeName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51GridAppliedFilters = "";
         AV45DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         bttBtncreatecustomeraction_Jsonclick = "";
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
         A41CustomerKvkNumber = "";
         A3CustomerName = "";
         A5CustomerEmail = "";
         A7CustomerPhone = "";
         A14CustomerVatNumber = "";
         A6CustomerVisitingAddress = "";
         A4CustomerPostalAddress = "";
         A79CustomerTypeName = "";
         AV58UpdateAction = "";
         AV59DeleteAction = "";
         lV61Customerwwds_1_filterfulltext = "";
         lV62Customerwwds_2_tfcustomerkvknumber = "";
         lV64Customerwwds_4_tfcustomername = "";
         lV66Customerwwds_6_tfcustomeremail = "";
         lV68Customerwwds_8_tfcustomerphone = "";
         lV70Customerwwds_10_tfcustomervatnumber = "";
         lV72Customerwwds_12_tfcustomervisitingaddress = "";
         lV74Customerwwds_14_tfcustomerpostaladdress = "";
         lV76Customerwwds_16_tfcustomertypename = "";
         AV61Customerwwds_1_filterfulltext = "";
         AV63Customerwwds_3_tfcustomerkvknumber_sel = "";
         AV62Customerwwds_2_tfcustomerkvknumber = "";
         AV65Customerwwds_5_tfcustomername_sel = "";
         AV64Customerwwds_4_tfcustomername = "";
         AV67Customerwwds_7_tfcustomeremail_sel = "";
         AV66Customerwwds_6_tfcustomeremail = "";
         AV69Customerwwds_9_tfcustomerphone_sel = "";
         AV68Customerwwds_8_tfcustomerphone = "";
         AV71Customerwwds_11_tfcustomervatnumber_sel = "";
         AV70Customerwwds_10_tfcustomervatnumber = "";
         AV73Customerwwds_13_tfcustomervisitingaddress_sel = "";
         AV72Customerwwds_12_tfcustomervisitingaddress = "";
         AV75Customerwwds_15_tfcustomerpostaladdress_sel = "";
         AV74Customerwwds_14_tfcustomerpostaladdress = "";
         AV77Customerwwds_17_tfcustomertypename_sel = "";
         AV76Customerwwds_16_tfcustomertypename = "";
         H001J2_A93CustomerLastLine = new short[1] ;
         H001J2_A79CustomerTypeName = new string[] {""} ;
         H001J2_A78CustomerTypeId = new short[1] ;
         H001J2_n78CustomerTypeId = new bool[] {false} ;
         H001J2_A4CustomerPostalAddress = new string[] {""} ;
         H001J2_n4CustomerPostalAddress = new bool[] {false} ;
         H001J2_A6CustomerVisitingAddress = new string[] {""} ;
         H001J2_n6CustomerVisitingAddress = new bool[] {false} ;
         H001J2_A14CustomerVatNumber = new string[] {""} ;
         H001J2_A7CustomerPhone = new string[] {""} ;
         H001J2_n7CustomerPhone = new bool[] {false} ;
         H001J2_A5CustomerEmail = new string[] {""} ;
         H001J2_n5CustomerEmail = new bool[] {false} ;
         H001J2_A3CustomerName = new string[] {""} ;
         H001J2_A41CustomerKvkNumber = new string[] {""} ;
         H001J2_A1CustomerId = new short[1] ;
         H001J3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV47GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customerww__default(),
            new Object[][] {
                new Object[] {
               H001J2_A93CustomerLastLine, H001J2_A79CustomerTypeName, H001J2_A78CustomerTypeId, H001J2_n78CustomerTypeId, H001J2_A4CustomerPostalAddress, H001J2_n4CustomerPostalAddress, H001J2_A6CustomerVisitingAddress, H001J2_n6CustomerVisitingAddress, H001J2_A14CustomerVatNumber, H001J2_A7CustomerPhone,
               H001J2_n7CustomerPhone, H001J2_A5CustomerEmail, H001J2_n5CustomerEmail, H001J2_A3CustomerName, H001J2_A41CustomerKvkNumber, H001J2_A1CustomerId
               }
               , new Object[] {
               H001J3_AGRID_nRecordCount
               }
            }
         );
         AV60Pgmname = "CustomerWW";
         /* GeneXus formulas. */
         AV60Pgmname = "CustomerWW";
         edtavUpdateaction_Enabled = 0;
         edtavDeleteaction_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV24ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A1CustomerId ;
      private short A78CustomerTypeId ;
      private short A93CustomerLastLine ;
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
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdateaction_Enabled ;
      private int edtavDeleteaction_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerKvkNumber_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerEmail_Enabled ;
      private int edtCustomerPhone_Enabled ;
      private int edtCustomerVatNumber_Enabled ;
      private int edtCustomerVisitingAddress_Enabled ;
      private int edtCustomerPostalAddress_Enabled ;
      private int edtCustomerTypeId_Enabled ;
      private int edtCustomerTypeName_Enabled ;
      private int edtCustomerLastLine_Enabled ;
      private int edtCustomerKvkNumber_Visible ;
      private int edtCustomerName_Visible ;
      private int edtCustomerEmail_Visible ;
      private int edtCustomerPhone_Visible ;
      private int edtCustomerVatNumber_Visible ;
      private int edtCustomerVisitingAddress_Visible ;
      private int edtCustomerPostalAddress_Visible ;
      private int edtCustomerTypeName_Visible ;
      private int AV48PageToGo ;
      private int AV78GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV60Pgmname ;
      private string AV37TFCustomerPhone ;
      private string AV38TFCustomerPhone_Sel ;
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
      private string bttBtncreatecustomeraction_Internalname ;
      private string bttBtncreatecustomeraction_Jsonclick ;
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
      private string edtCustomerId_Internalname ;
      private string edtCustomerKvkNumber_Internalname ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerEmail_Internalname ;
      private string A7CustomerPhone ;
      private string edtCustomerPhone_Internalname ;
      private string edtCustomerVatNumber_Internalname ;
      private string edtCustomerVisitingAddress_Internalname ;
      private string edtCustomerPostalAddress_Internalname ;
      private string edtCustomerTypeId_Internalname ;
      private string edtCustomerTypeName_Internalname ;
      private string edtCustomerLastLine_Internalname ;
      private string AV58UpdateAction ;
      private string edtavUpdateaction_Internalname ;
      private string AV59DeleteAction ;
      private string edtavDeleteaction_Internalname ;
      private string lV68Customerwwds_8_tfcustomerphone ;
      private string AV69Customerwwds_9_tfcustomerphone_sel ;
      private string AV68Customerwwds_8_tfcustomerphone ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerKvkNumber_Jsonclick ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerEmail_Jsonclick ;
      private string gxphoneLink ;
      private string edtCustomerPhone_Jsonclick ;
      private string edtCustomerVatNumber_Jsonclick ;
      private string edtCustomerVisitingAddress_Jsonclick ;
      private string edtCustomerPostalAddress_Jsonclick ;
      private string edtCustomerTypeId_Jsonclick ;
      private string edtCustomerTypeName_Jsonclick ;
      private string edtCustomerLastLine_Jsonclick ;
      private string edtavUpdateaction_Jsonclick ;
      private string edtavDeleteaction_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
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
      private bool n5CustomerEmail ;
      private bool n7CustomerPhone ;
      private bool n6CustomerVisitingAddress ;
      private bool n4CustomerPostalAddress ;
      private bool n78CustomerTypeId ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV27TFCustomerKvkNumber ;
      private string AV28TFCustomerKvkNumber_Sel ;
      private string AV29TFCustomerName ;
      private string AV30TFCustomerName_Sel ;
      private string AV33TFCustomerEmail ;
      private string AV34TFCustomerEmail_Sel ;
      private string AV39TFCustomerVatNumber ;
      private string AV40TFCustomerVatNumber_Sel ;
      private string AV35TFCustomerVisitingAddress ;
      private string AV36TFCustomerVisitingAddress_Sel ;
      private string AV31TFCustomerPostalAddress ;
      private string AV32TFCustomerPostalAddress_Sel ;
      private string AV43TFCustomerTypeName ;
      private string AV44TFCustomerTypeName_Sel ;
      private string AV51GridAppliedFilters ;
      private string A41CustomerKvkNumber ;
      private string A3CustomerName ;
      private string A5CustomerEmail ;
      private string A14CustomerVatNumber ;
      private string A6CustomerVisitingAddress ;
      private string A4CustomerPostalAddress ;
      private string A79CustomerTypeName ;
      private string lV61Customerwwds_1_filterfulltext ;
      private string lV62Customerwwds_2_tfcustomerkvknumber ;
      private string lV64Customerwwds_4_tfcustomername ;
      private string lV66Customerwwds_6_tfcustomeremail ;
      private string lV70Customerwwds_10_tfcustomervatnumber ;
      private string lV72Customerwwds_12_tfcustomervisitingaddress ;
      private string lV74Customerwwds_14_tfcustomerpostaladdress ;
      private string lV76Customerwwds_16_tfcustomertypename ;
      private string AV61Customerwwds_1_filterfulltext ;
      private string AV63Customerwwds_3_tfcustomerkvknumber_sel ;
      private string AV62Customerwwds_2_tfcustomerkvknumber ;
      private string AV65Customerwwds_5_tfcustomername_sel ;
      private string AV64Customerwwds_4_tfcustomername ;
      private string AV67Customerwwds_7_tfcustomeremail_sel ;
      private string AV66Customerwwds_6_tfcustomeremail ;
      private string AV71Customerwwds_11_tfcustomervatnumber_sel ;
      private string AV70Customerwwds_10_tfcustomervatnumber ;
      private string AV73Customerwwds_13_tfcustomervisitingaddress_sel ;
      private string AV72Customerwwds_12_tfcustomervisitingaddress ;
      private string AV75Customerwwds_15_tfcustomerpostaladdress_sel ;
      private string AV74Customerwwds_14_tfcustomerpostaladdress ;
      private string AV77Customerwwds_17_tfcustomertypename_sel ;
      private string AV76Customerwwds_16_tfcustomertypename ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV45DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H001J2_A93CustomerLastLine ;
      private string[] H001J2_A79CustomerTypeName ;
      private short[] H001J2_A78CustomerTypeId ;
      private bool[] H001J2_n78CustomerTypeId ;
      private string[] H001J2_A4CustomerPostalAddress ;
      private bool[] H001J2_n4CustomerPostalAddress ;
      private string[] H001J2_A6CustomerVisitingAddress ;
      private bool[] H001J2_n6CustomerVisitingAddress ;
      private string[] H001J2_A14CustomerVatNumber ;
      private string[] H001J2_A7CustomerPhone ;
      private bool[] H001J2_n7CustomerPhone ;
      private string[] H001J2_A5CustomerEmail ;
      private bool[] H001J2_n5CustomerEmail ;
      private string[] H001J2_A3CustomerName ;
      private string[] H001J2_A41CustomerKvkNumber ;
      private short[] H001J2_A1CustomerId ;
      private long[] H001J3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV46GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV47GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class customerww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001J2( IGxContext context ,
                                             string AV61Customerwwds_1_filterfulltext ,
                                             string AV63Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV62Customerwwds_2_tfcustomerkvknumber ,
                                             string AV65Customerwwds_5_tfcustomername_sel ,
                                             string AV64Customerwwds_4_tfcustomername ,
                                             string AV67Customerwwds_7_tfcustomeremail_sel ,
                                             string AV66Customerwwds_6_tfcustomeremail ,
                                             string AV69Customerwwds_9_tfcustomerphone_sel ,
                                             string AV68Customerwwds_8_tfcustomerphone ,
                                             string AV71Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV70Customerwwds_10_tfcustomervatnumber ,
                                             string AV73Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV72Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV75Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV74Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV77Customerwwds_17_tfcustomertypename_sel ,
                                             string AV76Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[27];
         Object[] GXv_Object12 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.CustomerLastLine, T2.CustomerTypeName, T1.CustomerTypeId, T1.CustomerPostalAddress, T1.CustomerVisitingAddress, T1.CustomerVatNumber, T1.CustomerPhone, T1.CustomerEmail, T1.CustomerName, T1.CustomerKvkNumber, T1.CustomerId";
         sFromString = " FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV61Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV61Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV62Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV63Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV63Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV64Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV65Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV65Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV66Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV67Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV67Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV68Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV69Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV69Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV69Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV70Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV71Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV71Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV71Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV72Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV73Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV73Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV74Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV75Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV75Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV76Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV77Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV77Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerKvkNumber, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerKvkNumber DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerName, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerName DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerEmail, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerEmail DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerPhone, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerPhone DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerVatNumber, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerVatNumber DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerVisitingAddress, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerVisitingAddress DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CustomerPostalAddress, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CustomerPostalAddress DESC, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CustomerTypeName, T1.CustomerId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CustomerTypeName DESC, T1.CustomerId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.CustomerId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H001J3( IGxContext context ,
                                             string AV61Customerwwds_1_filterfulltext ,
                                             string AV63Customerwwds_3_tfcustomerkvknumber_sel ,
                                             string AV62Customerwwds_2_tfcustomerkvknumber ,
                                             string AV65Customerwwds_5_tfcustomername_sel ,
                                             string AV64Customerwwds_4_tfcustomername ,
                                             string AV67Customerwwds_7_tfcustomeremail_sel ,
                                             string AV66Customerwwds_6_tfcustomeremail ,
                                             string AV69Customerwwds_9_tfcustomerphone_sel ,
                                             string AV68Customerwwds_8_tfcustomerphone ,
                                             string AV71Customerwwds_11_tfcustomervatnumber_sel ,
                                             string AV70Customerwwds_10_tfcustomervatnumber ,
                                             string AV73Customerwwds_13_tfcustomervisitingaddress_sel ,
                                             string AV72Customerwwds_12_tfcustomervisitingaddress ,
                                             string AV75Customerwwds_15_tfcustomerpostaladdress_sel ,
                                             string AV74Customerwwds_14_tfcustomerpostaladdress ,
                                             string AV77Customerwwds_17_tfcustomertypename_sel ,
                                             string AV76Customerwwds_16_tfcustomertypename ,
                                             string A41CustomerKvkNumber ,
                                             string A3CustomerName ,
                                             string A5CustomerEmail ,
                                             string A7CustomerPhone ,
                                             string A14CustomerVatNumber ,
                                             string A6CustomerVisitingAddress ,
                                             string A4CustomerPostalAddress ,
                                             string A79CustomerTypeName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[24];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Customer T1 LEFT JOIN CustomerType T2 ON T2.CustomerTypeId = T1.CustomerTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Customerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CustomerKvkNumber like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerName like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerEmail like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerPhone like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerVatNumber like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerVisitingAddress like '%' || :lV61Customerwwds_1_filterfulltext) or ( T1.CustomerPostalAddress like '%' || :lV61Customerwwds_1_filterfulltext) or ( T2.CustomerTypeName like '%' || :lV61Customerwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_3_tfcustomerkvknumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Customerwwds_2_tfcustomerkvknumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber like :lV62Customerwwds_2_tfcustomerkvknumber)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Customerwwds_3_tfcustomerkvknumber_sel)) && ! ( StringUtil.StrCmp(AV63Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerKvkNumber = ( :AV63Customerwwds_3_tfcustomerkvknumber_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Customerwwds_3_tfcustomerkvknumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerKvkNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_5_tfcustomername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Customerwwds_4_tfcustomername)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName like :lV64Customerwwds_4_tfcustomername)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Customerwwds_5_tfcustomername_sel)) && ! ( StringUtil.StrCmp(AV65Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerName = ( :AV65Customerwwds_5_tfcustomername_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Customerwwds_5_tfcustomername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_7_tfcustomeremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Customerwwds_6_tfcustomeremail)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail like :lV66Customerwwds_6_tfcustomeremail)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Customerwwds_7_tfcustomeremail_sel)) && ! ( StringUtil.StrCmp(AV67Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail = ( :AV67Customerwwds_7_tfcustomeremail_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Customerwwds_7_tfcustomeremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerEmail IS NULL or (char_length(trim(trailing ' ' from T1.CustomerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_9_tfcustomerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Customerwwds_8_tfcustomerphone)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone like :lV68Customerwwds_8_tfcustomerphone)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Customerwwds_9_tfcustomerphone_sel)) && ! ( StringUtil.StrCmp(AV69Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone = ( :AV69Customerwwds_9_tfcustomerphone_sel))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV69Customerwwds_9_tfcustomerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPhone IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPhone))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_11_tfcustomervatnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Customerwwds_10_tfcustomervatnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber like :lV70Customerwwds_10_tfcustomervatnumber)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Customerwwds_11_tfcustomervatnumber_sel)) && ! ( StringUtil.StrCmp(AV71Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVatNumber = ( :AV71Customerwwds_11_tfcustomervatnumber_sel))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV71Customerwwds_11_tfcustomervatnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CustomerVatNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Customerwwds_13_tfcustomervisitingaddress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Customerwwds_12_tfcustomervisitingaddress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress like :lV72Customerwwds_12_tfcustomervisitingaddress)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Customerwwds_13_tfcustomervisitingaddress_sel)) && ! ( StringUtil.StrCmp(AV73Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress = ( :AV73Customerwwds_13_tfcustomervisitingaddress_sel))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV73Customerwwds_13_tfcustomervisitingaddress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerVisitingAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerVisitingAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Customerwwds_15_tfcustomerpostaladdress_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Customerwwds_14_tfcustomerpostaladdress)) ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress like :lV74Customerwwds_14_tfcustomerpostaladdress)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Customerwwds_15_tfcustomerpostaladdress_sel)) && ! ( StringUtil.StrCmp(AV75Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress = ( :AV75Customerwwds_15_tfcustomerpostaladdress_sel))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV75Customerwwds_15_tfcustomerpostaladdress_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CustomerPostalAddress IS NULL or (char_length(trim(trailing ' ' from T1.CustomerPostalAddress))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Customerwwds_17_tfcustomertypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Customerwwds_16_tfcustomertypename)) ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName like :lV76Customerwwds_16_tfcustomertypename)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Customerwwds_17_tfcustomertypename_sel)) && ! ( StringUtil.StrCmp(AV77Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName = ( :AV77Customerwwds_17_tfcustomertypename_sel))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV77Customerwwds_17_tfcustomertypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.CustomerTypeName IS NULL or (char_length(trim(trailing ' ' from T2.CustomerTypeName))=0))");
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
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
               case 1 :
                     return conditional_H001J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmH001J2;
          prmH001J2 = new Object[] {
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV63Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV64Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV65Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV67Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV69Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV70Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV71Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV72Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV73Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV74Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV75Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV76Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV77Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001J3;
          prmH001J3 = new Object[] {
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Customerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Customerwwds_2_tfcustomerkvknumber",GXType.VarChar,8,0) ,
          new ParDef("AV63Customerwwds_3_tfcustomerkvknumber_sel",GXType.VarChar,8,0) ,
          new ParDef("lV64Customerwwds_4_tfcustomername",GXType.VarChar,40,0) ,
          new ParDef("AV65Customerwwds_5_tfcustomername_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Customerwwds_6_tfcustomeremail",GXType.VarChar,100,0) ,
          new ParDef("AV67Customerwwds_7_tfcustomeremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Customerwwds_8_tfcustomerphone",GXType.Char,20,0) ,
          new ParDef("AV69Customerwwds_9_tfcustomerphone_sel",GXType.Char,20,0) ,
          new ParDef("lV70Customerwwds_10_tfcustomervatnumber",GXType.VarChar,14,0) ,
          new ParDef("AV71Customerwwds_11_tfcustomervatnumber_sel",GXType.VarChar,14,0) ,
          new ParDef("lV72Customerwwds_12_tfcustomervisitingaddress",GXType.VarChar,1024,0) ,
          new ParDef("AV73Customerwwds_13_tfcustomervisitingaddress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV74Customerwwds_14_tfcustomerpostaladdress",GXType.VarChar,1024,0) ,
          new ParDef("AV75Customerwwds_15_tfcustomerpostaladdress_sel",GXType.VarChar,1024,0) ,
          new ParDef("lV76Customerwwds_16_tfcustomertypename",GXType.VarChar,40,0) ,
          new ParDef("AV77Customerwwds_17_tfcustomertypename_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((short[]) buf[15])[0] = rslt.getShort(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
