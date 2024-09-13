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
   public class createresidentstep2 : GXWebComponent
   {
      public createresidentstep2( )
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

      public createresidentstep2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV25WebSessionKey = aP0_WebSessionKey;
         this.AV13PreviousStep = aP1_PreviousStep;
         this.AV6GoingBack = aP2_GoingBack;
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
         cmbavResidentinindividualgender = new GXCombobox();
         cmbavResidentinindividualsdts__residentinindividualgender = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
                  AV25WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
                  AV13PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
                  AV6GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV25WebSessionKey,(string)AV13PreviousStep,(bool)AV6GoingBack});
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
               {
                  gxnrGrids_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
               {
                  gxgrGrids_refresh_invoke( ) ;
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

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_57 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_57_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         subGrids_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrids_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
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
            PA2V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividualgivenname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavResidentinindividualsdts__residentinindividuallastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividuallastname_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavResidentinindividualsdts__residentinindividualemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividualemail_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavResidentinindividualsdts__residentinindividualphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividualphone_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavResidentinindividualsdts__residentinindividualaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentinindividualsdts__residentinindividualaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualsdts__residentinindividualaddress_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               cmbavResidentinindividualsdts__residentinindividualgender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavResidentinindividualsdts__residentinindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResidentinindividualsdts__residentinindividualgender.Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtavDeleterecord_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeleterecord_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleterecord_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               WS2V2( ) ;
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
            context.SendWebValue( context.GetMessage( "Create Resident Step2", "")) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createresidentstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV25WebSessionKey)),UrlEncode(StringUtil.RTrim(AV13PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV6GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Residentinindividualsdts", AV22ResidentINIndividualSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Residentinindividualsdts", AV22ResidentINIndividualSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_57), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8GridsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9GridsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV7GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WebSessionKey", wcpOAV25WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13PreviousStep", wcpOAV13PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV6GoingBack", wcpOAV6GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV30CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV25WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTININDIVIDUALSDTS", AV22ResidentINIndividualSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTININDIVIDUALSDTS", AV22ResidentINIndividualSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV13PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV6GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Class", StringUtil.RTrim( Gridspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Next", StringUtil.RTrim( Gridspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grids_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2V2( )
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
         return "CreateResidentStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Create Resident Step2", "") ;
      }

      protected void WB2V0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createresidentstep2.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividualgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividualgivenname_Internalname, context.GetMessage( "Given Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividualgivenname_Internalname, AV18ResidentINIndividualGivenName, StringUtil.RTrim( context.localUtil.Format( AV18ResidentINIndividualGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividualgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentinindividualgivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividuallastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividuallastname_Internalname, context.GetMessage( "Last Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividuallastname_Internalname, AV20ResidentINIndividualLastName, StringUtil.RTrim( context.localUtil.Format( AV20ResidentINIndividualLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividuallastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentinindividuallastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividualbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividualbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividualbsnnumber_Internalname, AV15ResidentINIndividualBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV15ResidentINIndividualBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividualbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentinindividualbsnnumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentinindividualgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentinindividualgender_Internalname, context.GetMessage( "Gender", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentinindividualgender, cmbavResidentinindividualgender_Internalname, StringUtil.RTrim( AV17ResidentINIndividualGender), 1, cmbavResidentinindividualgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavResidentinindividualgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_CreateResidentStep2.htm");
            cmbavResidentinindividualgender.CurrentValue = StringUtil.RTrim( AV17ResidentINIndividualGender);
            AssignProp(sPrefix, false, cmbavResidentinindividualgender_Internalname, "Values", (string)(cmbavResidentinindividualgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividualemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividualemail_Internalname, context.GetMessage( "Email", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividualemail_Internalname, AV16ResidentINIndividualEmail, StringUtil.RTrim( context.localUtil.Format( AV16ResidentINIndividualEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividualemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentinindividualemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividualphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividualphone_Internalname, context.GetMessage( "Phone", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividualphone_Internalname, StringUtil.RTrim( AV21ResidentINIndividualPhone), StringUtil.RTrim( context.localUtil.Format( AV21ResidentINIndividualPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividualphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentinindividualphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentinindividualaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentinindividualaddress_Internalname, context.GetMessage( "Address", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavResidentinindividualaddress_Internalname, AV14ResidentINIndividualAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavResidentinindividualaddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", "", 0, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionbtntable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsaveindividual_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtnsaveindividual_Jsonclick, 5, context.GetMessage( "Add", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSAVEINDIVIDUAL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl57( ) ;
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            nRC_GXsfl_57 = (int)(nGXsfl_57_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV32GXV1 = nGXsfl_57_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridspaginationbar.SetProperty("Class", Gridspaginationbar_Class);
            ucGridspaginationbar.SetProperty("ShowFirst", Gridspaginationbar_Showfirst);
            ucGridspaginationbar.SetProperty("ShowPrevious", Gridspaginationbar_Showprevious);
            ucGridspaginationbar.SetProperty("ShowNext", Gridspaginationbar_Shownext);
            ucGridspaginationbar.SetProperty("ShowLast", Gridspaginationbar_Showlast);
            ucGridspaginationbar.SetProperty("PagesToShow", Gridspaginationbar_Pagestoshow);
            ucGridspaginationbar.SetProperty("PagingButtonsPosition", Gridspaginationbar_Pagingbuttonsposition);
            ucGridspaginationbar.SetProperty("PagingCaptionPosition", Gridspaginationbar_Pagingcaptionposition);
            ucGridspaginationbar.SetProperty("EmptyGridClass", Gridspaginationbar_Emptygridclass);
            ucGridspaginationbar.SetProperty("RowsPerPageSelector", Gridspaginationbar_Rowsperpageselector);
            ucGridspaginationbar.SetProperty("RowsPerPageOptions", Gridspaginationbar_Rowsperpageoptions);
            ucGridspaginationbar.SetProperty("Previous", Gridspaginationbar_Previous);
            ucGridspaginationbar.SetProperty("Next", Gridspaginationbar_Next);
            ucGridspaginationbar.SetProperty("Caption", Gridspaginationbar_Caption);
            ucGridspaginationbar.SetProperty("EmptyGridCaption", Gridspaginationbar_Emptygridcaption);
            ucGridspaginationbar.SetProperty("RowsPerPageCaption", Gridspaginationbar_Rowsperpagecaption);
            ucGridspaginationbar.SetProperty("CurrentPage", AV8GridsCurrentPage);
            ucGridspaginationbar.SetProperty("PageCount", AV9GridsPageCount);
            ucGridspaginationbar.SetProperty("AppliedFilters", AV7GridsAppliedFilters);
            ucGridspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridspaginationbar_Internalname, sPrefix+"GRIDSPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 5, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnnext_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(57), 2, 0)+","+"null"+");", context.GetMessage( "Next", ""), bttBtnnext_Jsonclick, 5, context.GetMessage( "Next", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep2.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinindividualid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19ResidentINIndividualId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinindividualid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentinindividualid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateResidentStep2.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 57 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV32GXV1 = nGXsfl_57_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2V2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Create Resident Step2", ""), 0) ;
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
               STRUP2V0( ) ;
            }
         }
      }

      protected void WS2V2( )
      {
         START2V2( ) ;
         EVT2V2( ) ;
      }

      protected void EVT2V2( )
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
                                 STRUP2V0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E112V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E122V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E132V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E142V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVEINDIVIDUAL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSaveIndividual' */
                                    E152V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VDELETERECORD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VDELETERECORD.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2V0( ) ;
                              }
                              nGXsfl_57_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
                              SubsflControlProps_572( ) ;
                              AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
                              {
                                 AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
                                 AV27DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
                                 AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV27DeleteRecord);
                              }
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
                                          GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162V2 ();
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
                                          GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172V2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E182V2 ();
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
                                             if ( ! Rfr0gs )
                                             {
                                                /* Execute user event: Enter */
                                                E192V2 ();
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETERECORD.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E202V2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2V0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname;
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

      protected void WE2V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2V2( ) ;
            }
         }
      }

      protected void PA2V2( )
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
               GX_FocusControl = edtavResidentinindividualgivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_572( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            sendrow_572( ) ;
            nGXsfl_57_idx = ((subGrids_Islastpage==1)&&(nGXsfl_57_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV10HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrids_refresh */
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
         if ( cmbavResidentinindividualgender.ItemCount > 0 )
         {
            AV17ResidentINIndividualGender = cmbavResidentinindividualgender.getValidValue(AV17ResidentINIndividualGender);
            AssignAttri(sPrefix, false, "AV17ResidentINIndividualGender", AV17ResidentINIndividualGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentinindividualgender.CurrentValue = StringUtil.RTrim( AV17ResidentINIndividualGender);
            AssignProp(sPrefix, false, cmbavResidentinindividualgender_Internalname, "Values", cmbavResidentinindividualgender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividuallastname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualemail_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualphone_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualaddress_Enabled = 0;
         cmbavResidentinindividualsdts__residentinindividualgender.Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      protected void RF2V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 57;
         /* Execute user event: Refresh */
         E172V2 ();
         nGXsfl_57_idx = 1;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         bGXsfl_57_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_572( ) ;
            /* Execute user event: Grids.Load */
            E182V2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_57_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E182V2 ();
            }
            wbEnd = 57;
            WB2V0( ) ;
         }
         bGXsfl_57_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2V2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected int subGrids_fnc_Pagecount( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return AV22ResidentINIndividualSDTs.Count ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         if ( subGrids_Rows > 0 )
         {
            return subGrids_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nFirstRecordOnPage/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrids_firstpage( )
      {
         GRIDS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_nextpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ( GRIDS_nRecordCount >= subGrids_fnc_Recordsperpage( ) ) && ( GRIDS_nEOF == 0 ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrids_previouspage( )
      {
         if ( GRIDS_nFirstRecordOnPage >= subGrids_fnc_Recordsperpage( ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage-subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_lastpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( GRIDS_nRecordCount > subGrids_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-subGrids_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrids_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDS_nFirstRecordOnPage = (long)(subGrids_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividuallastname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualemail_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualphone_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualaddress_Enabled = 0;
         cmbavResidentinindividualsdts__residentinindividualgender.Enabled = 0;
         edtavDeleterecord_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Residentinindividualsdts"), AV22ResidentINIndividualSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTININDIVIDUALSDTS"), AV22ResidentINIndividualSDTs);
            /* Read saved values. */
            nRC_GXsfl_57 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_57"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV8GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV9GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV7GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
            wcpOAV13PreviousStep = cgiGet( sPrefix+"wcpOAV13PreviousStep");
            wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            Gridspaginationbar_Class = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Class");
            Gridspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showfirst"));
            Gridspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showprevious"));
            Gridspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Shownext"));
            Gridspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showlast"));
            Gridspaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingbuttonsposition");
            Gridspaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingcaptionposition");
            Gridspaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridclass");
            Gridspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselector"));
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageoptions");
            Gridspaginationbar_Previous = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Previous");
            Gridspaginationbar_Next = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Next");
            Gridspaginationbar_Caption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Caption");
            Gridspaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridcaption");
            Gridspaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpagecaption");
            Grids_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDS_EMPOWERER_Gridinternalname");
            Gridspaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Selectedpage");
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_57 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_57"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_57_fel_idx = 0;
            while ( nGXsfl_57_fel_idx < nRC_GXsfl_57 )
            {
               nGXsfl_57_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_57_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_fel_idx+1);
               sGXsfl_57_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_572( ) ;
               AV32GXV1 = (int)(nGXsfl_57_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
               {
                  AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
                  AV27DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
               }
            }
            if ( nGXsfl_57_fel_idx == 0 )
            {
               nGXsfl_57_idx = 1;
               sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
               SubsflControlProps_572( ) ;
            }
            nGXsfl_57_fel_idx = 1;
            /* Read variables values. */
            AV18ResidentINIndividualGivenName = cgiGet( edtavResidentinindividualgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV18ResidentINIndividualGivenName", AV18ResidentINIndividualGivenName);
            AV20ResidentINIndividualLastName = cgiGet( edtavResidentinindividuallastname_Internalname);
            AssignAttri(sPrefix, false, "AV20ResidentINIndividualLastName", AV20ResidentINIndividualLastName);
            AV15ResidentINIndividualBsnNumber = cgiGet( edtavResidentinindividualbsnnumber_Internalname);
            AssignAttri(sPrefix, false, "AV15ResidentINIndividualBsnNumber", AV15ResidentINIndividualBsnNumber);
            cmbavResidentinindividualgender.Name = cmbavResidentinindividualgender_Internalname;
            cmbavResidentinindividualgender.CurrentValue = cgiGet( cmbavResidentinindividualgender_Internalname);
            AV17ResidentINIndividualGender = cgiGet( cmbavResidentinindividualgender_Internalname);
            AssignAttri(sPrefix, false, "AV17ResidentINIndividualGender", AV17ResidentINIndividualGender);
            AV16ResidentINIndividualEmail = cgiGet( edtavResidentinindividualemail_Internalname);
            AssignAttri(sPrefix, false, "AV16ResidentINIndividualEmail", AV16ResidentINIndividualEmail);
            AV21ResidentINIndividualPhone = cgiGet( edtavResidentinindividualphone_Internalname);
            AssignAttri(sPrefix, false, "AV21ResidentINIndividualPhone", AV21ResidentINIndividualPhone);
            AV14ResidentINIndividualAddress = cgiGet( edtavResidentinindividualaddress_Internalname);
            AssignAttri(sPrefix, false, "AV14ResidentINIndividualAddress", AV14ResidentINIndividualAddress);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESIDENTININDIVIDUALID");
               GX_FocusControl = edtavResidentinindividualid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ResidentINIndividualId = 0;
               AssignAttri(sPrefix, false, "AV19ResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV19ResidentINIndividualId), 4, 0));
            }
            else
            {
               AV19ResidentINIndividualId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResidentinindividualid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19ResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV19ResidentINIndividualId), 4, 0));
            }
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
         E162V2 ();
         if (returnInSub) return;
      }

      protected void E162V2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavResidentinindividualid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentinindividualid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentinindividualid_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E172V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV8GridsCurrentPage = subGrids_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV8GridsCurrentPage", StringUtil.LTrimStr( (decimal)(AV8GridsCurrentPage), 10, 0));
         AV9GridsPageCount = subGrids_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV9GridsPageCount", StringUtil.LTrimStr( (decimal)(AV9GridsPageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      private void E182V2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV22ResidentINIndividualSDTs.Count )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
            AV27DeleteRecord = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV27DeleteRecord);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 57;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_572( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_57_Refreshing )
            {
               DoAjaxLoad(57, GridsRow);
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112V2( )
      {
         /* Gridspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrids_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV12PageToGo = subGrids_fnc_Currentpage( );
            AV12PageToGo = (int)(AV12PageToGo+1);
            subgrids_gotopage( AV12PageToGo) ;
         }
         else
         {
            AV12PageToGo = (int)(Math.Round(NumberUtil.Val( Gridspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrids_gotopage( AV12PageToGo) ;
         }
      }

      protected void E122V2( )
      {
         /* Gridspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrids_Rows = Gridspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         subgrids_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E192V2 ();
         if (returnInSub) return;
      }

      protected void E192V2( )
      {
         AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV30CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E132V2( )
      {
         AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E142V2( )
      {
         AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
         }
         /* 'DoNext' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E152V2( )
      {
         AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
         }
         /* 'DoSaveIndividual' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV30CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            AV29isAlreadyAdded = false;
            AV40GXV9 = 1;
            while ( AV40GXV9 <= AV22ResidentINIndividualSDTs.Count )
            {
               AV23ResidentINIndividualSDTsItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV40GXV9));
               if ( StringUtil.StrCmp(AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualbsnnumber, AV15ResidentINIndividualBsnNumber) == 0 )
               {
                  AV29isAlreadyAdded = true;
                  if (true) break;
               }
               AV40GXV9 = (int)(AV40GXV9+1);
            }
            if ( AV29isAlreadyAdded )
            {
               GX_msglist.addItem("This BSN Number has already been added");
            }
            else
            {
               AV23ResidentINIndividualSDTsItem = new SdtResidentINIndividualSDT(context);
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualbsnnumber = AV15ResidentINIndividualBsnNumber;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualgivenname = AV18ResidentINIndividualGivenName;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividuallastname = AV20ResidentINIndividualLastName;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualemail = AV16ResidentINIndividualEmail;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualphone = AV21ResidentINIndividualPhone;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualgender = AV17ResidentINIndividualGender;
               AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualaddress = AV14ResidentINIndividualAddress;
               AV22ResidentINIndividualSDTs.Add(AV23ResidentINIndividualSDTsItem, 0);
               gx_BV57 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S142 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22ResidentINIndividualSDTs", AV22ResidentINIndividualSDTs);
         nGXsfl_57_bak_idx = nGXsfl_57_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_57_idx = nGXsfl_57_bak_idx;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         cmbavResidentinindividualgender.CurrentValue = StringUtil.RTrim( AV17ResidentINIndividualGender);
         AssignProp(sPrefix, false, cmbavResidentinindividualgender_Internalname, "Values", cmbavResidentinindividualgender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV19ResidentINIndividualId = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualid;
         AssignAttri(sPrefix, false, "AV19ResidentINIndividualId", StringUtil.LTrimStr( (decimal)(AV19ResidentINIndividualId), 4, 0));
         AV18ResidentINIndividualGivenName = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualgivenname;
         AssignAttri(sPrefix, false, "AV18ResidentINIndividualGivenName", AV18ResidentINIndividualGivenName);
         AV20ResidentINIndividualLastName = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividuallastname;
         AssignAttri(sPrefix, false, "AV20ResidentINIndividualLastName", AV20ResidentINIndividualLastName);
         AV15ResidentINIndividualBsnNumber = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualbsnnumber;
         AssignAttri(sPrefix, false, "AV15ResidentINIndividualBsnNumber", AV15ResidentINIndividualBsnNumber);
         AV17ResidentINIndividualGender = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualgender;
         AssignAttri(sPrefix, false, "AV17ResidentINIndividualGender", AV17ResidentINIndividualGender);
         AV16ResidentINIndividualEmail = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualemail;
         AssignAttri(sPrefix, false, "AV16ResidentINIndividualEmail", AV16ResidentINIndividualEmail);
         AV21ResidentINIndividualPhone = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualphone;
         AssignAttri(sPrefix, false, "AV21ResidentINIndividualPhone", AV21ResidentINIndividualPhone);
         AV14ResidentINIndividualAddress = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualaddress;
         AssignAttri(sPrefix, false, "AV14ResidentINIndividualAddress", AV14ResidentINIndividualAddress);
         AV22ResidentINIndividualSDTs = AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualsdts;
         gx_BV57 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualid = AV19ResidentINIndividualId;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualgivenname = AV18ResidentINIndividualGivenName;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividuallastname = AV20ResidentINIndividualLastName;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualbsnnumber = AV15ResidentINIndividualBsnNumber;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualgender = AV17ResidentINIndividualGender;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualemail = AV16ResidentINIndividualEmail;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualphone = AV21ResidentINIndividualPhone;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualaddress = AV14ResidentINIndividualAddress;
         AV26WizardData.gxTpr_Step2.gxTpr_Residentinindividualsdts = AV22ResidentINIndividualSDTs;
         AV24WebSession.Set(AV25WebSessionKey, AV26WizardData.ToJSonString(false, true));
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV30CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV30CheckRequiredFieldsResult", AV30CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ResidentINIndividualGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Given Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentinindividualgivenname_Internalname,  "true",  ""));
            AV30CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV30CheckRequiredFieldsResult", AV30CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ResidentINIndividualLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentinindividuallastname_Internalname,  "true",  ""));
            AV30CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV30CheckRequiredFieldsResult", AV30CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ResidentINIndividualGender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Gender", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavResidentinindividualgender_Internalname,  "true",  ""));
            AV30CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV30CheckRequiredFieldsResult", AV30CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ResidentINIndividualEmail)) && ! GxRegex.IsMatch(AV16ResidentINIndividualEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV30CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV30CheckRequiredFieldsResult", AV30CheckRequiredFieldsResult);
         }
      }

      protected void E202V2( )
      {
         AV32GXV1 = (int)(nGXsfl_57_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) )
         {
            AV22ResidentINIndividualSDTs.CurrentItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1));
         }
         /* Deleterecord_Click Routine */
         returnInSub = false;
         AV28UserBsnNumber = ((SdtResidentINIndividualSDT)(AV22ResidentINIndividualSDTs.CurrentItem)).gxTpr_Residentinindividualbsnnumber;
         AV31Index = 1;
         AV41GXV10 = 1;
         while ( AV41GXV10 <= AV22ResidentINIndividualSDTs.Count )
         {
            AV23ResidentINIndividualSDTsItem = ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV41GXV10));
            if ( StringUtil.StrCmp(AV23ResidentINIndividualSDTsItem.gxTpr_Residentinindividualbsnnumber, AV28UserBsnNumber) == 0 )
            {
               if (true) break;
            }
            else
            {
               AV31Index = (short)(AV31Index+1);
            }
            AV41GXV10 = (int)(AV41GXV10+1);
         }
         if ( AV31Index <= AV22ResidentINIndividualSDTs.Count )
         {
            AV22ResidentINIndividualSDTs.RemoveItem(AV31Index);
            gx_BV57 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22ResidentINIndividualSDTs", AV22ResidentINIndividualSDTs);
         nGXsfl_57_bak_idx = nGXsfl_57_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_57_idx = nGXsfl_57_bak_idx;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
      }

      protected void S142( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV15ResidentINIndividualBsnNumber = "";
         AssignAttri(sPrefix, false, "AV15ResidentINIndividualBsnNumber", AV15ResidentINIndividualBsnNumber);
         AV18ResidentINIndividualGivenName = "";
         AssignAttri(sPrefix, false, "AV18ResidentINIndividualGivenName", AV18ResidentINIndividualGivenName);
         AV20ResidentINIndividualLastName = "";
         AssignAttri(sPrefix, false, "AV20ResidentINIndividualLastName", AV20ResidentINIndividualLastName);
         AV16ResidentINIndividualEmail = "";
         AssignAttri(sPrefix, false, "AV16ResidentINIndividualEmail", AV16ResidentINIndividualEmail);
         AV21ResidentINIndividualPhone = "";
         AssignAttri(sPrefix, false, "AV21ResidentINIndividualPhone", AV21ResidentINIndividualPhone);
         AV17ResidentINIndividualGender = "";
         AssignAttri(sPrefix, false, "AV17ResidentINIndividualGender", AV17ResidentINIndividualGender);
         AV14ResidentINIndividualAddress = "";
         AssignAttri(sPrefix, false, "AV14ResidentINIndividualAddress", AV14ResidentINIndividualAddress);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
         AV13PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
         AV6GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
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
         PA2V2( ) ;
         WS2V2( ) ;
         WE2V2( ) ;
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
         sCtrlAV25WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV13PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV6GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createresidentstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV25WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
            AV13PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
            AV6GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
         }
         wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
         wcpOAV13PreviousStep = cgiGet( sPrefix+"wcpOAV13PreviousStep");
         wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV25WebSessionKey, wcpOAV25WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV13PreviousStep, wcpOAV13PreviousStep) != 0 ) || ( AV6GoingBack != wcpOAV6GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV25WebSessionKey = AV25WebSessionKey;
         wcpOAV13PreviousStep = AV13PreviousStep;
         wcpOAV6GoingBack = AV6GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV25WebSessionKey = cgiGet( sPrefix+"AV25WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV25WebSessionKey) > 0 )
         {
            AV25WebSessionKey = cgiGet( sCtrlAV25WebSessionKey);
            AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
         }
         else
         {
            AV25WebSessionKey = cgiGet( sPrefix+"AV25WebSessionKey_PARM");
         }
         sCtrlAV13PreviousStep = cgiGet( sPrefix+"AV13PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV13PreviousStep) > 0 )
         {
            AV13PreviousStep = cgiGet( sCtrlAV13PreviousStep);
            AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
         }
         else
         {
            AV13PreviousStep = cgiGet( sPrefix+"AV13PreviousStep_PARM");
         }
         sCtrlAV6GoingBack = cgiGet( sPrefix+"AV6GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV6GoingBack) > 0 )
         {
            AV6GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV6GoingBack));
            AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
         }
         else
         {
            AV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV6GoingBack_PARM"));
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
         PA2V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2V2( ) ;
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
         WS2V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25WebSessionKey_PARM", AV25WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV25WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13PreviousStep_PARM", AV13PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV13PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6GoingBack_PARM", StringUtil.BoolToStr( AV6GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6GoingBack_CTRL", StringUtil.RTrim( sCtrlAV6GoingBack));
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
         WE2V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315512970", true, true);
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
         context.AddJavascriptSource("createresidentstep2.js", "?202491315512971", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_572( )
      {
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_57_idx;
         edtavResidentinindividualsdts__residentinindividualgivenname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_57_idx;
         edtavResidentinindividualsdts__residentinindividuallastname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_57_idx;
         edtavResidentinindividualsdts__residentinindividualemail_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL_"+sGXsfl_57_idx;
         edtavResidentinindividualsdts__residentinindividualphone_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE_"+sGXsfl_57_idx;
         edtavResidentinindividualsdts__residentinindividualaddress_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS_"+sGXsfl_57_idx;
         cmbavResidentinindividualsdts__residentinindividualgender_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER_"+sGXsfl_57_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_572( )
      {
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_57_fel_idx;
         edtavResidentinindividualsdts__residentinindividualgivenname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_57_fel_idx;
         edtavResidentinindividualsdts__residentinindividuallastname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_57_fel_idx;
         edtavResidentinindividualsdts__residentinindividualemail_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL_"+sGXsfl_57_fel_idx;
         edtavResidentinindividualsdts__residentinindividualphone_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE_"+sGXsfl_57_fel_idx;
         edtavResidentinindividualsdts__residentinindividualaddress_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS_"+sGXsfl_57_fel_idx;
         cmbavResidentinindividualsdts__residentinindividualgender_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER_"+sGXsfl_57_fel_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_57_fel_idx;
      }

      protected void sendrow_572( )
      {
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_572( ) ;
         WB2V0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_57_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsRow = GXWebRow.GetNew(context,GridsContainer);
            if ( subGrids_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrids_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
            else if ( subGrids_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrids_Backstyle = 0;
               subGrids_Backcolor = subGrids_Allbackcolor;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Uniform";
               }
            }
            else if ( subGrids_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
               subGrids_Backcolor = (int)(0x0);
            }
            else if ( subGrids_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Even";
                  }
               }
               else
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Odd";
                  }
               }
            }
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_57_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname,((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualbsnnumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividualbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividualgivenname_Internalname,((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividualgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividualgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividuallastname_Internalname,((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividuallastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividuallastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividuallastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividualemail_Internalname,((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividualemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividualemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividualphone_Internalname,StringUtil.RTrim( ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividualphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividualphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentinindividualsdts__residentinindividualaddress_Internalname,((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentinindividualsdts__residentinindividualaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentinindividualsdts__residentinindividualaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            if ( ( cmbavResidentinindividualsdts__residentinindividualgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER_" + sGXsfl_57_idx;
               cmbavResidentinindividualsdts__residentinindividualgender.Name = GXCCtl;
               cmbavResidentinindividualsdts__residentinindividualgender.WebTags = "";
               cmbavResidentinindividualsdts__residentinindividualgender.addItem("Man", context.GetMessage( "Man", ""), 0);
               cmbavResidentinindividualsdts__residentinindividualgender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
               cmbavResidentinindividualsdts__residentinindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavResidentinindividualsdts__residentinindividualgender.ItemCount > 0 )
               {
                  if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender)) )
                  {
                     ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender = cmbavResidentinindividualsdts__residentinindividualgender.getValidValue(((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender);
                  }
               }
            }
            /* ComboBox */
            GridsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavResidentinindividualsdts__residentinindividualgender,(string)cmbavResidentinindividualsdts__residentinindividualgender_Internalname,StringUtil.RTrim( ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender),(short)1,(string)cmbavResidentinindividualsdts__residentinindividualgender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavResidentinindividualsdts__residentinindividualgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"",(bool)true,(short)0});
            cmbavResidentinindividualsdts__residentinindividualgender.CurrentValue = StringUtil.RTrim( ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender);
            AssignProp(sPrefix, false, cmbavResidentinindividualsdts__residentinindividualgender_Internalname, "Values", (string)(cmbavResidentinindividualsdts__residentinindividualgender.ToJavascriptSource()), !bGXsfl_57_Refreshing);
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'" + sGXsfl_57_idx + "',57)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleterecord_Internalname,StringUtil.RTrim( AV27DeleteRecord),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETERECORD.CLICK."+sGXsfl_57_idx+"'",(string)"",(string)"",context.GetMessage( "Delete", ""),(string)"",(string)edtavDeleterecord_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleterecord_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2V2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_57_idx = ((subGrids_Islastpage==1)&&(nGXsfl_57_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_572( ) ;
         }
         /* End function sendrow_572 */
      }

      protected void init_web_controls( )
      {
         cmbavResidentinindividualgender.Name = "vRESIDENTININDIVIDUALGENDER";
         cmbavResidentinindividualgender.WebTags = "";
         cmbavResidentinindividualgender.addItem("Man", context.GetMessage( "Man", ""), 0);
         cmbavResidentinindividualgender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
         cmbavResidentinindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentinindividualgender.ItemCount > 0 )
         {
         }
         GXCCtl = "RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER_" + sGXsfl_57_idx;
         cmbavResidentinindividualsdts__residentinindividualgender.Name = GXCCtl;
         cmbavResidentinindividualsdts__residentinindividualgender.WebTags = "";
         cmbavResidentinindividualsdts__residentinindividualgender.addItem("Man", context.GetMessage( "Man", ""), 0);
         cmbavResidentinindividualsdts__residentinindividualgender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
         cmbavResidentinindividualsdts__residentinindividualgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentinindividualsdts__residentinindividualgender.ItemCount > 0 )
         {
            if ( ( AV32GXV1 > 0 ) && ( AV22ResidentINIndividualSDTs.Count >= AV32GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtResidentINIndividualSDT)AV22ResidentINIndividualSDTs.Item(AV32GXV1)).gxTpr_Residentinindividualgender)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl57( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"57\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrids_Backcolorstyle == 0 )
            {
               subGrids_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrids_Class) > 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Title";
               }
            }
            else
            {
               subGrids_Titlebackstyle = 1;
               if ( subGrids_Backcolorstyle == 1 )
               {
                  subGrids_Titlebackcolor = subGrids_Allbackcolor;
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BSN Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Given Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividualgivenname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividuallastname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividualemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividualphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentinindividualsdts__residentinindividualaddress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavResidentinindividualsdts__residentinindividualgender.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27DeleteRecord)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleterecord_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavResidentinindividualgivenname_Internalname = sPrefix+"vRESIDENTININDIVIDUALGIVENNAME";
         edtavResidentinindividuallastname_Internalname = sPrefix+"vRESIDENTININDIVIDUALLASTNAME";
         edtavResidentinindividualbsnnumber_Internalname = sPrefix+"vRESIDENTININDIVIDUALBSNNUMBER";
         cmbavResidentinindividualgender_Internalname = sPrefix+"vRESIDENTININDIVIDUALGENDER";
         edtavResidentinindividualemail_Internalname = sPrefix+"vRESIDENTININDIVIDUALEMAIL";
         edtavResidentinindividualphone_Internalname = sPrefix+"vRESIDENTININDIVIDUALPHONE";
         edtavResidentinindividualaddress_Internalname = sPrefix+"vRESIDENTININDIVIDUALADDRESS";
         bttBtnsaveindividual_Internalname = sPrefix+"BTNSAVEINDIVIDUAL";
         divActionbtntable_Internalname = sPrefix+"ACTIONBTNTABLE";
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALBSNNUMBER";
         edtavResidentinindividualsdts__residentinindividualgivenname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGIVENNAME";
         edtavResidentinindividualsdts__residentinindividuallastname_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALLASTNAME";
         edtavResidentinindividualsdts__residentinindividualemail_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALEMAIL";
         edtavResidentinindividualsdts__residentinindividualphone_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALPHONE";
         edtavResidentinindividualsdts__residentinindividualaddress_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALADDRESS";
         cmbavResidentinindividualsdts__residentinindividualgender_Internalname = sPrefix+"RESIDENTININDIVIDUALSDTS__RESIDENTININDIVIDUALGENDER";
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnnext_Internalname = sPrefix+"BTNNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResidentinindividualid_Internalname = sPrefix+"vRESIDENTININDIVIDUALID";
         Grids_empowerer_Internalname = sPrefix+"GRIDS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrids_Internalname = sPrefix+"GRIDS";
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
         subGrids_Allowcollapsing = 0;
         subGrids_Allowselection = 0;
         subGrids_Header = "";
         edtavDeleterecord_Jsonclick = "";
         edtavDeleterecord_Enabled = 1;
         cmbavResidentinindividualsdts__residentinindividualgender_Jsonclick = "";
         cmbavResidentinindividualsdts__residentinindividualgender.Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualaddress_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividualaddress_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualphone_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividualphone_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualemail_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividualemail_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividuallastname_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividuallastname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualgivenname_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Jsonclick = "";
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = 0;
         subGrids_Class = "GridWithPaginationBar WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavResidentinindividualid_Jsonclick = "";
         edtavResidentinindividualid_Visible = 1;
         edtavResidentinindividualaddress_Enabled = 1;
         edtavResidentinindividualphone_Jsonclick = "";
         edtavResidentinindividualphone_Enabled = 1;
         edtavResidentinindividualemail_Jsonclick = "";
         edtavResidentinindividualemail_Enabled = 1;
         cmbavResidentinindividualgender_Jsonclick = "";
         cmbavResidentinindividualgender.Enabled = 1;
         edtavResidentinindividualbsnnumber_Jsonclick = "";
         edtavResidentinindividualbsnnumber_Enabled = 1;
         edtavResidentinindividuallastname_Jsonclick = "";
         edtavResidentinindividuallastname_Enabled = 1;
         edtavResidentinindividualgivenname_Jsonclick = "";
         edtavResidentinindividualgivenname_Enabled = 1;
         Gridspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridspaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridspaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridspaginationbar_Next = "WWP_PagingNextCaption";
         Gridspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridspaginationbar_Rowsperpageselectedvalue = 10;
         Gridspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridspaginationbar_Pagingcaptionposition = "Left";
         Gridspaginationbar_Pagingbuttonsposition = "Right";
         Gridspaginationbar_Pagestoshow = 5;
         Gridspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridspaginationbar_Class = "PaginationBar";
         cmbavResidentinindividualsdts__residentinindividualgender.Enabled = -1;
         edtavResidentinindividualsdts__residentinindividualaddress_Enabled = -1;
         edtavResidentinindividualsdts__residentinindividualphone_Enabled = -1;
         edtavResidentinindividualsdts__residentinindividualemail_Enabled = -1;
         edtavResidentinindividualsdts__residentinindividuallastname_Enabled = -1;
         edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = -1;
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = -1;
         subGrids_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV8GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV9GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E182V2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV27DeleteRecord","fld":"vDELETERECORD"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112V2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122V2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("ENTER","""{"handler":"E192V2","iparms":[{"av":"AV30CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV18ResidentINIndividualGivenName","fld":"vRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV20ResidentINIndividualLastName","fld":"vRESIDENTININDIVIDUALLASTNAME"},{"av":"cmbavResidentinindividualgender"},{"av":"AV17ResidentINIndividualGender","fld":"vRESIDENTININDIVIDUALGENDER"},{"av":"AV16ResidentINIndividualEmail","fld":"vRESIDENTININDIVIDUALEMAIL"},{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV19ResidentINIndividualId","fld":"vRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV15ResidentINIndividualBsnNumber","fld":"vRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV21ResidentINIndividualPhone","fld":"vRESIDENTININDIVIDUALPHONE"},{"av":"AV14ResidentINIndividualAddress","fld":"vRESIDENTININDIVIDUALADDRESS"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV30CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E132V2","iparms":[{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV19ResidentINIndividualId","fld":"vRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV18ResidentINIndividualGivenName","fld":"vRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV20ResidentINIndividualLastName","fld":"vRESIDENTININDIVIDUALLASTNAME"},{"av":"AV15ResidentINIndividualBsnNumber","fld":"vRESIDENTININDIVIDUALBSNNUMBER"},{"av":"cmbavResidentinindividualgender"},{"av":"AV17ResidentINIndividualGender","fld":"vRESIDENTININDIVIDUALGENDER"},{"av":"AV16ResidentINIndividualEmail","fld":"vRESIDENTININDIVIDUALEMAIL"},{"av":"AV21ResidentINIndividualPhone","fld":"vRESIDENTININDIVIDUALPHONE"},{"av":"AV14ResidentINIndividualAddress","fld":"vRESIDENTININDIVIDUALADDRESS"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57}]}""");
         setEventMetadata("'DONEXT'","""{"handler":"E142V2","iparms":[{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV19ResidentINIndividualId","fld":"vRESIDENTININDIVIDUALID","pic":"ZZZ9"},{"av":"AV18ResidentINIndividualGivenName","fld":"vRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV20ResidentINIndividualLastName","fld":"vRESIDENTININDIVIDUALLASTNAME"},{"av":"AV15ResidentINIndividualBsnNumber","fld":"vRESIDENTININDIVIDUALBSNNUMBER"},{"av":"cmbavResidentinindividualgender"},{"av":"AV17ResidentINIndividualGender","fld":"vRESIDENTININDIVIDUALGENDER"},{"av":"AV16ResidentINIndividualEmail","fld":"vRESIDENTININDIVIDUALEMAIL"},{"av":"AV21ResidentINIndividualPhone","fld":"vRESIDENTININDIVIDUALPHONE"},{"av":"AV14ResidentINIndividualAddress","fld":"vRESIDENTININDIVIDUALADDRESS"},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57}]}""");
         setEventMetadata("'DOSAVEINDIVIDUAL'","""{"handler":"E152V2","iparms":[{"av":"AV30CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"AV15ResidentINIndividualBsnNumber","fld":"vRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV18ResidentINIndividualGivenName","fld":"vRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV20ResidentINIndividualLastName","fld":"vRESIDENTININDIVIDUALLASTNAME"},{"av":"AV16ResidentINIndividualEmail","fld":"vRESIDENTININDIVIDUALEMAIL"},{"av":"AV21ResidentINIndividualPhone","fld":"vRESIDENTININDIVIDUALPHONE"},{"av":"cmbavResidentinindividualgender"},{"av":"AV17ResidentINIndividualGender","fld":"vRESIDENTININDIVIDUALGENDER"},{"av":"AV14ResidentINIndividualAddress","fld":"vRESIDENTININDIVIDUALADDRESS"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOSAVEINDIVIDUAL'",""","oparms":[{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"AV30CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV15ResidentINIndividualBsnNumber","fld":"vRESIDENTININDIVIDUALBSNNUMBER"},{"av":"AV18ResidentINIndividualGivenName","fld":"vRESIDENTININDIVIDUALGIVENNAME"},{"av":"AV20ResidentINIndividualLastName","fld":"vRESIDENTININDIVIDUALLASTNAME"},{"av":"AV16ResidentINIndividualEmail","fld":"vRESIDENTININDIVIDUALEMAIL"},{"av":"AV21ResidentINIndividualPhone","fld":"vRESIDENTININDIVIDUALPHONE"},{"av":"cmbavResidentinindividualgender"},{"av":"AV17ResidentINIndividualGender","fld":"vRESIDENTININDIVIDUALGENDER"},{"av":"AV14ResidentINIndividualAddress","fld":"vRESIDENTININDIVIDUALADDRESS"}]}""");
         setEventMetadata("VDELETERECORD.CLICK","""{"handler":"E202V2","iparms":[{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VDELETERECORD.CLICK",""","oparms":[{"av":"AV22ResidentINIndividualSDTs","fld":"vRESIDENTININDIVIDUALSDTS","grid":57},{"av":"nGXsfl_57_idx","ctrl":"GRID","prop":"GridCurrRow","grid":57},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_57","ctrl":"GRIDS","prop":"GridRC","grid":57}]}""");
         setEventMetadata("VALIDV_RESIDENTININDIVIDUALGENDER","""{"handler":"Validv_Residentinindividualgender","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTININDIVIDUALEMAIL","""{"handler":"Validv_Residentinindividualemail","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV8","""{"handler":"Validv_Gxv8","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Deleterecord","iparms":[]}""");
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
         wcpOAV25WebSessionKey = "";
         wcpOAV13PreviousStep = "";
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ResidentINIndividualSDTs = new GXBaseCollection<SdtResidentINIndividualSDT>( context, "ResidentINIndividualSDT", "");
         AV7GridsAppliedFilters = "";
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV18ResidentINIndividualGivenName = "";
         AV20ResidentINIndividualLastName = "";
         AV15ResidentINIndividualBsnNumber = "";
         AV17ResidentINIndividualGender = "";
         AV16ResidentINIndividualEmail = "";
         AV21ResidentINIndividualPhone = "";
         AV14ResidentINIndividualAddress = "";
         bttBtnsaveindividual_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridspaginationbar = new GXUserControl();
         bttBtnwizardprevious_Jsonclick = "";
         bttBtnnext_Jsonclick = "";
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27DeleteRecord = "";
         GridsRow = new GXWebRow();
         AV23ResidentINIndividualSDTsItem = new SdtResidentINIndividualSDT(context);
         AV26WizardData = new SdtCreateResidentData(context);
         AV24WebSession = context.GetSession();
         AV28UserBsnNumber = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV25WebSessionKey = "";
         sCtrlAV13PreviousStep = "";
         sCtrlAV6GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridsColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualgivenname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividuallastname_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualemail_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualphone_Enabled = 0;
         edtavResidentinindividualsdts__residentinindividualaddress_Enabled = 0;
         cmbavResidentinindividualsdts__residentinindividualgender.Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV19ResidentINIndividualId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV31Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_57 ;
      private int subGrids_Rows ;
      private int nGXsfl_57_idx=1 ;
      private int edtavResidentinindividualsdts__residentinindividualbsnnumber_Enabled ;
      private int edtavResidentinindividualsdts__residentinindividualgivenname_Enabled ;
      private int edtavResidentinindividualsdts__residentinindividuallastname_Enabled ;
      private int edtavResidentinindividualsdts__residentinindividualemail_Enabled ;
      private int edtavResidentinindividualsdts__residentinindividualphone_Enabled ;
      private int edtavResidentinindividualsdts__residentinindividualaddress_Enabled ;
      private int edtavDeleterecord_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int edtavResidentinindividualgivenname_Enabled ;
      private int edtavResidentinindividuallastname_Enabled ;
      private int edtavResidentinindividualbsnnumber_Enabled ;
      private int edtavResidentinindividualemail_Enabled ;
      private int edtavResidentinindividualphone_Enabled ;
      private int edtavResidentinindividualaddress_Enabled ;
      private int AV32GXV1 ;
      private int edtavResidentinindividualid_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_57_fel_idx=1 ;
      private int AV12PageToGo ;
      private int AV40GXV9 ;
      private int nGXsfl_57_bak_idx=1 ;
      private int AV41GXV10 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long AV8GridsCurrentPage ;
      private long AV9GridsPageCount ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Gridspaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_57_idx="0001" ;
      private string edtavResidentinindividualsdts__residentinindividualbsnnumber_Internalname ;
      private string edtavResidentinindividualsdts__residentinindividualgivenname_Internalname ;
      private string edtavResidentinindividualsdts__residentinindividuallastname_Internalname ;
      private string edtavResidentinindividualsdts__residentinindividualemail_Internalname ;
      private string edtavResidentinindividualsdts__residentinindividualphone_Internalname ;
      private string edtavResidentinindividualsdts__residentinindividualaddress_Internalname ;
      private string cmbavResidentinindividualsdts__residentinindividualgender_Internalname ;
      private string edtavDeleterecord_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gridspaginationbar_Class ;
      private string Gridspaginationbar_Pagingbuttonsposition ;
      private string Gridspaginationbar_Pagingcaptionposition ;
      private string Gridspaginationbar_Emptygridclass ;
      private string Gridspaginationbar_Rowsperpageoptions ;
      private string Gridspaginationbar_Previous ;
      private string Gridspaginationbar_Next ;
      private string Gridspaginationbar_Caption ;
      private string Gridspaginationbar_Emptygridcaption ;
      private string Gridspaginationbar_Rowsperpagecaption ;
      private string Grids_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavResidentinindividualgivenname_Internalname ;
      private string TempTags ;
      private string edtavResidentinindividualgivenname_Jsonclick ;
      private string edtavResidentinindividuallastname_Internalname ;
      private string edtavResidentinindividuallastname_Jsonclick ;
      private string edtavResidentinindividualbsnnumber_Internalname ;
      private string edtavResidentinindividualbsnnumber_Jsonclick ;
      private string cmbavResidentinindividualgender_Internalname ;
      private string AV17ResidentINIndividualGender ;
      private string cmbavResidentinindividualgender_Jsonclick ;
      private string edtavResidentinindividualemail_Internalname ;
      private string edtavResidentinindividualemail_Jsonclick ;
      private string edtavResidentinindividualphone_Internalname ;
      private string AV21ResidentINIndividualPhone ;
      private string edtavResidentinindividualphone_Jsonclick ;
      private string edtavResidentinindividualaddress_Internalname ;
      private string divActionbtntable_Internalname ;
      private string bttBtnsaveindividual_Internalname ;
      private string bttBtnsaveindividual_Jsonclick ;
      private string divGridstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string Gridspaginationbar_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtnwizardprevious_Internalname ;
      private string bttBtnwizardprevious_Jsonclick ;
      private string bttBtnnext_Internalname ;
      private string bttBtnnext_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentinindividualid_Internalname ;
      private string edtavResidentinindividualid_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27DeleteRecord ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string sCtrlAV25WebSessionKey ;
      private string sCtrlAV13PreviousStep ;
      private string sCtrlAV6GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavResidentinindividualsdts__residentinindividualbsnnumber_Jsonclick ;
      private string edtavResidentinindividualsdts__residentinindividualgivenname_Jsonclick ;
      private string edtavResidentinindividualsdts__residentinindividuallastname_Jsonclick ;
      private string edtavResidentinindividualsdts__residentinindividualemail_Jsonclick ;
      private string edtavResidentinindividualsdts__residentinindividualphone_Jsonclick ;
      private string edtavResidentinindividualsdts__residentinindividualaddress_Jsonclick ;
      private string GXCCtl ;
      private string cmbavResidentinindividualsdts__residentinindividualgender_Jsonclick ;
      private string edtavDeleterecord_Jsonclick ;
      private string subGrids_Header ;
      private bool AV6GoingBack ;
      private bool wcpOAV6GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool AV30CheckRequiredFieldsResult ;
      private bool Gridspaginationbar_Showfirst ;
      private bool Gridspaginationbar_Showprevious ;
      private bool Gridspaginationbar_Shownext ;
      private bool Gridspaginationbar_Showlast ;
      private bool Gridspaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV29isAlreadyAdded ;
      private bool gx_BV57 ;
      private string AV25WebSessionKey ;
      private string AV13PreviousStep ;
      private string wcpOAV25WebSessionKey ;
      private string wcpOAV13PreviousStep ;
      private string AV7GridsAppliedFilters ;
      private string AV18ResidentINIndividualGivenName ;
      private string AV20ResidentINIndividualLastName ;
      private string AV15ResidentINIndividualBsnNumber ;
      private string AV16ResidentINIndividualEmail ;
      private string AV14ResidentINIndividualAddress ;
      private string AV28UserBsnNumber ;
      private IGxSession AV24WebSession ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResidentinindividualgender ;
      private GXCombobox cmbavResidentinindividualsdts__residentinindividualgender ;
      private GXBaseCollection<SdtResidentINIndividualSDT> AV22ResidentINIndividualSDTs ;
      private SdtResidentINIndividualSDT AV23ResidentINIndividualSDTsItem ;
      private SdtCreateResidentData AV26WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
