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
   public class amenitiestypeamenitieswc : GXWebComponent
   {
      public amenitiestypeamenitieswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public amenitiestypeamenitieswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AmenitiesTypeId )
      {
         this.AV8AmenitiesTypeId = aP0_AmenitiesTypeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV8AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesTypeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV8AmenitiesTypeId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV8AmenitiesTypeId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesTypeId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV33Pgmname = GetPar( "Pgmname");
         AV28IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV30IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV31IsAuthorized_AmenitiesName = StringUtil.StrToBool( GetPar( "IsAuthorized_AmenitiesName"));
         AV32IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA352( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV33Pgmname = "AmenitiesTypeAmenitiesWC";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_35_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_35_Refreshing);
               WS352( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Amenities Type Amenities WC", "")) ;
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
         }
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("amenitiestypeamenitieswc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8AmenitiesTypeId,4,0))}, new string[] {"AmenitiesTypeId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_AMENITIESNAME", AV31IsAuthorized_AmenitiesName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_AMENITIESNAME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_AmenitiesName, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV32IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV32IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV26GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8AmenitiesTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_AMENITIESNAME", AV31IsAuthorized_AmenitiesName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_AMENITIESNAME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_AmenitiesName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV32IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV32IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vAMENITIESTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm352( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "AmenitiesTypeAmenitiesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Amenities Type Amenities WC", "") ;
      }

      protected void WB350( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "amenitiestypeamenitieswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmenitiesTypeAmenitiesWC.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_AmenitiesTypeAmenitiesWC.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV24GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV25GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV26GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtAmenitiesTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A99AmenitiesTypeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmenitiesTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtAmenitiesTypeId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AmenitiesTypeAmenitiesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START352( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Amenities Type Amenities WC", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP350( ) ;
            }
         }
      }

      protected void WS352( )
      {
         START352( ) ;
         EVT352( ) ;
      }

      protected void EVT352( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E15352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV27Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV27Update);
                              AV29Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV29Delete);
                              A98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A101AmenitiesName = cgiGet( edtAmenitiesName_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16352 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E17352 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E18352 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP350( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE352( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm352( ) ;
            }
         }
      }

      protected void PA352( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       short AV8AmenitiesTypeId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV33Pgmname ,
                                       bool AV28IsAuthorized_Update ,
                                       bool AV30IsAuthorized_Delete ,
                                       bool AV31IsAuthorized_AmenitiesName ,
                                       bool AV32IsAuthorized_Insert ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF352( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_AMENITIESID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"AMENITIESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, ".", "")));
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
         RF352( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV33Pgmname = "AmenitiesTypeAmenitiesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF352( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E17352 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_352( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16FilterFullText ,
                                                 A98AmenitiesId ,
                                                 A101AmenitiesName ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A99AmenitiesTypeId ,
                                                 AV8AmenitiesTypeId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
            lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
            /* Using cursor H00352 */
            pr_default.execute(0, new Object[] {AV8AmenitiesTypeId, lV16FilterFullText, lV16FilterFullText, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A99AmenitiesTypeId = H00352_A99AmenitiesTypeId[0];
               AssignAttri(sPrefix, false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
               A101AmenitiesName = H00352_A101AmenitiesName[0];
               A98AmenitiesId = H00352_A98AmenitiesId[0];
               /* Execute user event: Grid.Load */
               E18352 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WB350( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes352( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_AMENITIESNAME", AV31IsAuthorized_AmenitiesName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_AMENITIESNAME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_AmenitiesName, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_INSERT", AV32IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV32IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_AMENITIESID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sPrefix+sGXsfl_35_idx, context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV16FilterFullText ,
                                              A98AmenitiesId ,
                                              A101AmenitiesName ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A99AmenitiesTypeId ,
                                              AV8AmenitiesTypeId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
         lV16FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV16FilterFullText), "%", "");
         /* Using cursor H00353 */
         pr_default.execute(1, new Object[] {AV8AmenitiesTypeId, lV16FilterFullText, lV16FilterFullText});
         GRID_nRecordCount = H00353_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8AmenitiesTypeId, AV20ManageFiltersExecutionStep, AV33Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, AV31IsAuthorized_AmenitiesName, AV32IsAuthorized_Insert, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV33Pgmname = "AmenitiesTypeAmenitiesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtAmenitiesId_Enabled = 0;
         edtAmenitiesName_Enabled = 0;
         edtAmenitiesTypeId_Enabled = 0;
         AssignProp(sPrefix, false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP350( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16352 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV24GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8AmenitiesTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A99AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E16352 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16352( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean1 = AV31IsAuthorized_AmenitiesName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "amenitiesview_Execute", out  GXt_boolean1) ;
         AV31IsAuthorized_AmenitiesName = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV31IsAuthorized_AmenitiesName", AV31IsAuthorized_AmenitiesName);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_AMENITIESNAME", GetSecureSignedToken( sPrefix, AV31IsAuthorized_AmenitiesName, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtAmenitiesTypeId_Visible = 0;
         AssignProp(sPrefix, false, edtAmenitiesTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Visible), 5, 0), true);
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
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17352( )
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
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
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
         AV24GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV24GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV24GridCurrentPage), 10, 0));
         AV25GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV25GridPageCount", StringUtil.LTrimStr( (decimal)(AV25GridPageCount), 10, 0));
         GXt_char3 = AV26GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV33Pgmname, out  GXt_char3) ;
         AV26GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV26GridAppliedFilters", AV26GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E12352( )
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
            AV23PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV23PageToGo) ;
         }
      }

      protected void E13352( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14352( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18352( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV27Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV27Update);
         if ( AV28IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("amenities.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A98AmenitiesId,4,0))}, new string[] {"Mode","AmenitiesId"}) ;
         }
         AV29Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV29Delete);
         if ( AV30IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("amenities.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A98AmenitiesId,4,0))}, new string[] {"Mode","AmenitiesId"}) ;
         }
         if ( AV31IsAuthorized_AmenitiesName )
         {
            edtAmenitiesName_Link = formatLink("amenitiesview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A98AmenitiesId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"AmenitiesId","TabCode"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 35;
         }
         sendrow_352( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11352( )
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("AmenitiesTypeAmenitiesWCFilters")),UrlEncode(StringUtil.RTrim(AV33Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("AmenitiesTypeAmenitiesWCFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "AmenitiesTypeAmenitiesWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV19ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV33Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E15352( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV32IsAuthorized_Insert )
         {
            CallWebObject(formatLink("amenities.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","AmenitiesId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV28IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "amenities_Update", out  GXt_boolean1) ;
         AV28IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV28IsAuthorized_Update", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         if ( ! ( AV28IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_35_Refreshing);
         }
         GXt_boolean1 = AV30IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "amenities_Delete", out  GXt_boolean1) ;
         AV30IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV30IsAuthorized_Delete", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         if ( ! ( AV30IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_35_Refreshing);
         }
         GXt_boolean1 = AV32IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "amenities_Insert", out  GXt_boolean1) ;
         AV32IsAuthorized_Insert = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV32IsAuthorized_Insert", AV32IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( sPrefix, AV32IsAuthorized_Insert, context));
         if ( ! ( AV32IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "AmenitiesTypeAmenitiesWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV33Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV33Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV33Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV34GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            AV34GXV1 = (int)(AV34GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV33Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV33Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV33Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Amenities";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "AmenitiesTypeId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8AmenitiesTypeId), 4, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8AmenitiesTypeId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV8AmenitiesTypeId), 4, 0));
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
         PA352( ) ;
         WS352( ) ;
         WE352( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV8AmenitiesTypeId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA352( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "amenitiestypeamenitieswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA352( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8AmenitiesTypeId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV8AmenitiesTypeId), 4, 0));
         }
         wcpOAV8AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8AmenitiesTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8AmenitiesTypeId != wcpOAV8AmenitiesTypeId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8AmenitiesTypeId = AV8AmenitiesTypeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8AmenitiesTypeId = cgiGet( sPrefix+"AV8AmenitiesTypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV8AmenitiesTypeId) > 0 )
         {
            AV8AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8AmenitiesTypeId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV8AmenitiesTypeId), 4, 0));
         }
         else
         {
            AV8AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8AmenitiesTypeId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA352( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS352( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS352( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8AmenitiesTypeId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8AmenitiesTypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8AmenitiesTypeId_CTRL", StringUtil.RTrim( sCtrlAV8AmenitiesTypeId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE352( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315534683", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("amenitiestypeamenitieswc.js", "?202491315534684", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_35_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_35_idx;
         edtAmenitiesId_Internalname = sPrefix+"AMENITIESID_"+sGXsfl_35_idx;
         edtAmenitiesName_Internalname = sPrefix+"AMENITIESNAME_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_35_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_35_fel_idx;
         edtAmenitiesId_Internalname = sPrefix+"AMENITIESID_"+sGXsfl_35_fel_idx;
         edtAmenitiesName_Internalname = sPrefix+"AMENITIESNAME_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB350( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV27Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV29Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmenitiesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmenitiesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmenitiesName_Internalname,(string)A101AmenitiesName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtAmenitiesName_Link,(string)"",(string)"",(string)"",(string)edtAmenitiesName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes352( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A101AmenitiesName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAmenitiesName_Link));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtAmenitiesId_Internalname = sPrefix+"AMENITIESID";
         edtAmenitiesName_Internalname = sPrefix+"AMENITIESNAME";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtAmenitiesTypeId_Internalname = sPrefix+"AMENITIESTYPEID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtAmenitiesName_Jsonclick = "";
         edtAmenitiesName_Link = "";
         edtAmenitiesId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtAmenitiesTypeId_Enabled = 0;
         edtAmenitiesName_Enabled = 0;
         edtAmenitiesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtAmenitiesTypeId_Jsonclick = "";
         edtAmenitiesTypeId_Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1";
         Ddo_grid_Columnids = "2:AmenitiesId|3:AmenitiesName";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
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
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"sPrefix"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12352","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13352","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14352","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E18352","iparms":[{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A98AmenitiesId","fld":"AMENITIESID","pic":"ZZZ9","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV27Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV29Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtAmenitiesName_Link","ctrl":"AMENITIESNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11352","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E15352","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV8AmenitiesTypeId","fld":"vAMENITIESTYPEID","pic":"ZZZ9"},{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV33Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV31IsAuthorized_AmenitiesName","fld":"vISAUTHORIZED_AMENITIESNAME","hsh":true},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"sPrefix"},{"av":"A98AmenitiesId","fld":"AMENITIESID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV20ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV25GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV26GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV28IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV30IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV32IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV18ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Amenitiesname","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV33Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26GridAppliedFilters = "";
         AV21DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27Update = "";
         AV29Delete = "";
         A101AmenitiesName = "";
         lV16FilterFullText = "";
         H00352_A99AmenitiesTypeId = new short[1] ;
         H00352_A101AmenitiesName = new string[] {""} ;
         H00352_A98AmenitiesId = new short[1] ;
         H00353_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_char3 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8AmenitiesTypeId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amenitiestypeamenitieswc__default(),
            new Object[][] {
                new Object[] {
               H00352_A99AmenitiesTypeId, H00352_A101AmenitiesName, H00352_A98AmenitiesId
               }
               , new Object[] {
               H00353_AGRID_nRecordCount
               }
            }
         );
         AV33Pgmname = "AmenitiesTypeAmenitiesWC";
         /* GeneXus formulas. */
         AV33Pgmname = "AmenitiesTypeAmenitiesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short AV8AmenitiesTypeId ;
      private short wcpOAV8AmenitiesTypeId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short A99AmenitiesTypeId ;
      private short nDraw ;
      private short nDoneStart ;
      private short A98AmenitiesId ;
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
      private int nRC_GXsfl_35 ;
      private int nGXsfl_35_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int edtAmenitiesTypeId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAmenitiesId_Enabled ;
      private int edtAmenitiesName_Enabled ;
      private int edtAmenitiesTypeId_Enabled ;
      private int AV23PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV34GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV24GridCurrentPage ;
      private long AV25GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_35_idx="0001" ;
      private string AV33Pgmname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
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
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string edtAmenitiesTypeId_Internalname ;
      private string edtAmenitiesTypeId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27Update ;
      private string AV29Delete ;
      private string edtAmenitiesId_Internalname ;
      private string edtAmenitiesName_Internalname ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtAmenitiesName_Link ;
      private string GXt_char3 ;
      private string sCtrlAV8AmenitiesTypeId ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtAmenitiesId_Jsonclick ;
      private string edtAmenitiesName_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV28IsAuthorized_Update ;
      private bool AV30IsAuthorized_Delete ;
      private bool AV31IsAuthorized_AmenitiesName ;
      private bool AV32IsAuthorized_Insert ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV26GridAppliedFilters ;
      private string A101AmenitiesName ;
      private string lV16FilterFullText ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H00352_A99AmenitiesTypeId ;
      private string[] H00352_A101AmenitiesName ;
      private short[] H00352_A98AmenitiesId ;
      private long[] H00353_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class amenitiestypeamenitieswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00352( IGxContext context ,
                                             string AV16FilterFullText ,
                                             short A98AmenitiesId ,
                                             string A101AmenitiesName ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             short A99AmenitiesTypeId ,
                                             short AV8AmenitiesTypeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " AmenitiesTypeId, AmenitiesName, AmenitiesId";
         sFromString = " FROM Amenities";
         sOrderString = "";
         AddWhere(sWhereString, "(AmenitiesTypeId = :AV8AmenitiesTypeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(AmenitiesId,'9999'), 2) like '%' || :lV16FilterFullText) or ( AmenitiesName like '%' || :lV16FilterFullText))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AmenitiesTypeId, AmenitiesName, AmenitiesId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AmenitiesTypeId DESC, AmenitiesName DESC, AmenitiesId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AmenitiesTypeId, AmenitiesId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AmenitiesTypeId DESC, AmenitiesId DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY AmenitiesId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00353( IGxContext context ,
                                             string AV16FilterFullText ,
                                             short A98AmenitiesId ,
                                             string A101AmenitiesName ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             short A99AmenitiesTypeId ,
                                             short AV8AmenitiesTypeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[3];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Amenities";
         AddWhere(sWhereString, "(AmenitiesTypeId = :AV8AmenitiesTypeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(AmenitiesId,'9999'), 2) like '%' || :lV16FilterFullText) or ( AmenitiesName like '%' || :lV16FilterFullText))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00352(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_H00353(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmH00352;
          prmH00352 = new Object[] {
          new ParDef("AV8AmenitiesTypeId",GXType.Int16,4,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00353;
          prmH00353 = new Object[] {
          new ParDef("AV8AmenitiesTypeId",GXType.Int16,4,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV16FilterFullText",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00352", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00352,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00353", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00353,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
