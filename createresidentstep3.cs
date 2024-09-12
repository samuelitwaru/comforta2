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
   public class createresidentstep3 : GXWebComponent
   {
      public createresidentstep3( )
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

      public createresidentstep3( IGxContext context )
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
         this.AV21WebSessionKey = aP0_WebSessionKey;
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
                  AV21WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
                  AV13PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
                  AV6GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV21WebSessionKey,(string)AV13PreviousStep,(bool)AV6GoingBack});
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
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
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
            PA2W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavResidentincompanysdts__residentincompanykvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentincompanysdts__residentincompanykvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentincompanysdts__residentincompanykvknumber_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtavResidentincompanysdts__residentincompanyname_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentincompanysdts__residentincompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentincompanysdts__residentincompanyname_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtavResidentincompanysdts__residentincompanyemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentincompanysdts__residentincompanyemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentincompanysdts__residentincompanyemail_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtavResidentincompanysdts__residentincompanyphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentincompanysdts__residentincompanyphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentincompanysdts__residentincompanyphone_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtavDeleterecord_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeleterecord_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleterecord_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               WS2W2( ) ;
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
            context.SendWebValue( "Create Resident Step3") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createresidentstep3.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21WebSessionKey)),UrlEncode(StringUtil.RTrim(AV13PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV6GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Residentincompanysdts", AV19ResidentINCompanySDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Residentincompanysdts", AV19ResidentINCompanySDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8GridsCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9GridsPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV7GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21WebSessionKey", wcpOAV21WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13PreviousStep", wcpOAV13PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV6GoingBack", wcpOAV6GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV28CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV21WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTINCOMPANYSDTS", AV19ResidentINCompanySDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTINCOMPANYSDTS", AV19ResidentINCompanySDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV13PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV6GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
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

      protected void RenderHtmlCloseForm2W2( )
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
         return "CreateResidentStep3" ;
      }

      public override string GetPgmdesc( )
      {
         return "Create Resident Step3" ;
      }

      protected void WB2W0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createresidentstep3.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentincompanyname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentincompanyname_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentincompanyname_Internalname, AV17ResidentINCompanyName, StringUtil.RTrim( context.localUtil.Format( AV17ResidentINCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentincompanyname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentincompanyname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentincompanykvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentincompanykvknumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentincompanykvknumber_Internalname, AV16ResidentINCompanyKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV16ResidentINCompanyKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentincompanykvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentincompanykvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentincompanyemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentincompanyemail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentincompanyemail_Internalname, AV14ResidentINCompanyEmail, StringUtil.RTrim( context.localUtil.Format( AV14ResidentINCompanyEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentincompanyemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentincompanyemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentincompanyphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentincompanyphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentincompanyphone_Internalname, StringUtil.RTrim( AV18ResidentINCompanyPhone), StringUtil.RTrim( context.localUtil.Format( AV18ResidentINCompanyPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentincompanyphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentincompanyphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionbtntable_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsavecompany_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Add", bttBtnsavecompany_Jsonclick, 5, "Add", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSAVECOMPANY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV29GXV1 = nGXsfl_43_idx;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Previous", bttBtnwizardprevious_Jsonclick, 5, "Previous", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnnext_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Next", bttBtnnext_Jsonclick, 5, "Next", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DONEXT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep3.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentincompanyid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ResidentINCompanyId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15ResidentINCompanyId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentincompanyid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentincompanyid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateResidentStep3.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 43 )
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
                  AV29GXV1 = nGXsfl_43_idx;
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

      protected void START2W2( )
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
            Form.Meta.addItem("description", "Create Resident Step3", 0) ;
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
               STRUP2W0( ) ;
            }
         }
      }

      protected void WS2W2( )
      {
         START2W2( ) ;
         EVT2W2( ) ;
      }

      protected void EVT2W2( )
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
                                 STRUP2W0( ) ;
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
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E112W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E122W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E132W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E142W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVECOMPANY'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSaveCompany' */
                                    E152W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
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
                                 STRUP2W0( ) ;
                              }
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
                              {
                                 AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
                                 AV24DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
                                 AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV24DeleteRecord);
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
                                          GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162W2 ();
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
                                          GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172W2 ();
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
                                          GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E182W2 ();
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
                                                E192W2 ();
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
                                          GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E202W2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2W0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavResidentincompanysdts__residentincompanykvknumber_Internalname;
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

      protected void WE2W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2W2( ) ;
            }
         }
      }

      protected void PA2W2( )
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
               GX_FocusControl = edtavResidentincompanyname_Internalname;
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
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrids_Islastpage==1)&&(nGXsfl_43_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
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
         RF2W2( ) ;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavResidentincompanysdts__residentincompanykvknumber_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyname_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyemail_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyphone_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      protected void RF2W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E172W2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
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
            SubsflControlProps_432( ) ;
            /* Execute user event: Grids.Load */
            E182W2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_43_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E182W2 ();
            }
            wbEnd = 43;
            WB2W0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2W2( )
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
         return AV19ResidentINCompanySDTs.Count ;
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
         edtavResidentincompanysdts__residentincompanykvknumber_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyname_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyemail_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyphone_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162W2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Residentincompanysdts"), AV19ResidentINCompanySDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTINCOMPANYSDTS"), AV19ResidentINCompanySDTs);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_43"), ".", ","), 18, MidpointRounding.ToEven));
            AV8GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV9GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV7GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV21WebSessionKey = cgiGet( sPrefix+"wcpOAV21WebSessionKey");
            wcpOAV13PreviousStep = cgiGet( sPrefix+"wcpOAV13PreviousStep");
            wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            Gridspaginationbar_Class = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Class");
            Gridspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showfirst"));
            Gridspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showprevious"));
            Gridspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Shownext"));
            Gridspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Showlast"));
            Gridspaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingbuttonsposition");
            Gridspaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Pagingcaptionposition");
            Gridspaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridclass");
            Gridspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselector"));
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridspaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageoptions");
            Gridspaginationbar_Previous = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Previous");
            Gridspaginationbar_Next = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Next");
            Gridspaginationbar_Caption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Caption");
            Gridspaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Emptygridcaption");
            Gridspaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpagecaption");
            Grids_empowerer_Gridinternalname = cgiGet( sPrefix+"GRIDS_EMPOWERER_Gridinternalname");
            Gridspaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Selectedpage");
            Gridspaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_43"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_43_fel_idx = 0;
            while ( nGXsfl_43_fel_idx < nRC_GXsfl_43 )
            {
               nGXsfl_43_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_43_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_fel_idx+1);
               sGXsfl_43_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_432( ) ;
               AV29GXV1 = (int)(nGXsfl_43_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
               {
                  AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
                  AV24DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
               }
            }
            if ( nGXsfl_43_fel_idx == 0 )
            {
               nGXsfl_43_idx = 1;
               sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
               SubsflControlProps_432( ) ;
            }
            nGXsfl_43_fel_idx = 1;
            /* Read variables values. */
            AV17ResidentINCompanyName = cgiGet( edtavResidentincompanyname_Internalname);
            AssignAttri(sPrefix, false, "AV17ResidentINCompanyName", AV17ResidentINCompanyName);
            AV16ResidentINCompanyKvkNumber = cgiGet( edtavResidentincompanykvknumber_Internalname);
            AssignAttri(sPrefix, false, "AV16ResidentINCompanyKvkNumber", AV16ResidentINCompanyKvkNumber);
            AV14ResidentINCompanyEmail = cgiGet( edtavResidentincompanyemail_Internalname);
            AssignAttri(sPrefix, false, "AV14ResidentINCompanyEmail", AV14ResidentINCompanyEmail);
            AV18ResidentINCompanyPhone = cgiGet( edtavResidentincompanyphone_Internalname);
            AssignAttri(sPrefix, false, "AV18ResidentINCompanyPhone", AV18ResidentINCompanyPhone);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResidentincompanyid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResidentincompanyid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESIDENTINCOMPANYID");
               GX_FocusControl = edtavResidentincompanyid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ResidentINCompanyId = 0;
               AssignAttri(sPrefix, false, "AV15ResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV15ResidentINCompanyId), 4, 0));
            }
            else
            {
               AV15ResidentINCompanyId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResidentincompanyid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV15ResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV15ResidentINCompanyId), 4, 0));
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
         E162W2 ();
         if (returnInSub) return;
      }

      protected void E162W2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavResidentincompanyid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentincompanyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentincompanyid_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E172W2( )
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

      private void E182W2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV19ResidentINCompanySDTs.Count )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
            AV24DeleteRecord = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV24DeleteRecord);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_432( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
            {
               DoAjaxLoad(43, GridsRow);
            }
            AV29GXV1 = (int)(AV29GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112W2( )
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

      protected void E122W2( )
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
         E192W2 ();
         if (returnInSub) return;
      }

      protected void E192W2( )
      {
         AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV28CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.RTrim("Step4")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E132W2( )
      {
         AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E142W2( )
      {
         AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
         }
         /* 'DoNext' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.RTrim("Step4")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E152W2( )
      {
         AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
         }
         /* 'DoSaveCompany' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV28CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            AV27isAlreadyAdded = false;
            AV34GXV6 = 1;
            while ( AV34GXV6 <= AV19ResidentINCompanySDTs.Count )
            {
               AV23ResidentINCompanySDTsItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV34GXV6));
               if ( StringUtil.StrCmp(AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanykvknumber, AV16ResidentINCompanyKvkNumber) == 0 )
               {
                  AV27isAlreadyAdded = true;
                  if (true) break;
               }
               AV34GXV6 = (int)(AV34GXV6+1);
            }
            if ( AV27isAlreadyAdded )
            {
               GX_msglist.addItem("This Company KVKNumber has already been added");
            }
            else
            {
               AV23ResidentINCompanySDTsItem = new SdtResidentINCompanySDT(context);
               AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanykvknumber = AV16ResidentINCompanyKvkNumber;
               AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanyname = AV17ResidentINCompanyName;
               AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanyemail = AV14ResidentINCompanyEmail;
               AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanyphone = AV18ResidentINCompanyPhone;
               AV19ResidentINCompanySDTs.Add(AV23ResidentINCompanySDTsItem, 0);
               gx_BV43 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S142 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ResidentINCompanySDTs", AV19ResidentINCompanySDTs);
         nGXsfl_43_bak_idx = nGXsfl_43_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_43_idx = nGXsfl_43_bak_idx;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV22WizardData.FromJSonString(AV20WebSession.Get(AV21WebSessionKey), null);
         AV15ResidentINCompanyId = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyid;
         AssignAttri(sPrefix, false, "AV15ResidentINCompanyId", StringUtil.LTrimStr( (decimal)(AV15ResidentINCompanyId), 4, 0));
         AV17ResidentINCompanyName = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyname;
         AssignAttri(sPrefix, false, "AV17ResidentINCompanyName", AV17ResidentINCompanyName);
         AV16ResidentINCompanyKvkNumber = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanykvknumber;
         AssignAttri(sPrefix, false, "AV16ResidentINCompanyKvkNumber", AV16ResidentINCompanyKvkNumber);
         AV14ResidentINCompanyEmail = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyemail;
         AssignAttri(sPrefix, false, "AV14ResidentINCompanyEmail", AV14ResidentINCompanyEmail);
         AV18ResidentINCompanyPhone = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyphone;
         AssignAttri(sPrefix, false, "AV18ResidentINCompanyPhone", AV18ResidentINCompanyPhone);
         AV19ResidentINCompanySDTs = AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanysdts;
         gx_BV43 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV22WizardData.FromJSonString(AV20WebSession.Get(AV21WebSessionKey), null);
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyid = AV15ResidentINCompanyId;
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyname = AV17ResidentINCompanyName;
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanykvknumber = AV16ResidentINCompanyKvkNumber;
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyemail = AV14ResidentINCompanyEmail;
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanyphone = AV18ResidentINCompanyPhone;
         AV22WizardData.gxTpr_Step3.gxTpr_Residentincompanysdts = AV19ResidentINCompanySDTs;
         AV20WebSession.Set(AV21WebSessionKey, AV22WizardData.ToJSonString(false, true));
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV28CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ResidentINCompanyName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Name is required",  "error",  edtavResidentincompanyname_Internalname,  "true",  ""));
            AV28CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ResidentINCompanyKvkNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "KVK Number is required",  "error",  edtavResidentincompanykvknumber_Internalname,  "true",  ""));
            AV28CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ResidentINCompanyEmail)) && ! GxRegex.IsMatch(AV14ResidentINCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") )
         {
            AV28CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
      }

      protected void E202W2( )
      {
         AV29GXV1 = (int)(nGXsfl_43_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV19ResidentINCompanySDTs.Count >= AV29GXV1 ) )
         {
            AV19ResidentINCompanySDTs.CurrentItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1));
         }
         /* Deleterecord_Click Routine */
         returnInSub = false;
         AV25CompanyKvkNumber = ((SdtResidentINCompanySDT)(AV19ResidentINCompanySDTs.CurrentItem)).gxTpr_Residentincompanykvknumber;
         AV26Index = 1;
         AV35GXV7 = 1;
         while ( AV35GXV7 <= AV19ResidentINCompanySDTs.Count )
         {
            AV23ResidentINCompanySDTsItem = ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV35GXV7));
            if ( StringUtil.StrCmp(AV23ResidentINCompanySDTsItem.gxTpr_Residentincompanykvknumber, AV25CompanyKvkNumber) == 0 )
            {
               if (true) break;
            }
            else
            {
               AV26Index = (short)(AV26Index+1);
            }
            AV35GXV7 = (int)(AV35GXV7+1);
         }
         if ( AV26Index <= AV19ResidentINCompanySDTs.Count )
         {
            AV19ResidentINCompanySDTs.RemoveItem(AV26Index);
            gx_BV43 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ResidentINCompanySDTs", AV19ResidentINCompanySDTs);
         nGXsfl_43_bak_idx = nGXsfl_43_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_43_idx = nGXsfl_43_bak_idx;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
      }

      protected void S142( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV16ResidentINCompanyKvkNumber = "";
         AssignAttri(sPrefix, false, "AV16ResidentINCompanyKvkNumber", AV16ResidentINCompanyKvkNumber);
         AV17ResidentINCompanyName = "";
         AssignAttri(sPrefix, false, "AV17ResidentINCompanyName", AV17ResidentINCompanyName);
         AV14ResidentINCompanyEmail = "";
         AssignAttri(sPrefix, false, "AV14ResidentINCompanyEmail", AV14ResidentINCompanyEmail);
         AV18ResidentINCompanyPhone = "";
         AssignAttri(sPrefix, false, "AV18ResidentINCompanyPhone", AV18ResidentINCompanyPhone);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
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
         PA2W2( ) ;
         WS2W2( ) ;
         WE2W2( ) ;
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
         sCtrlAV21WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV13PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV6GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2W2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createresidentstep3", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2W2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV21WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
            AV13PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV13PreviousStep", AV13PreviousStep);
            AV6GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
         }
         wcpOAV21WebSessionKey = cgiGet( sPrefix+"wcpOAV21WebSessionKey");
         wcpOAV13PreviousStep = cgiGet( sPrefix+"wcpOAV13PreviousStep");
         wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV21WebSessionKey, wcpOAV21WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV13PreviousStep, wcpOAV13PreviousStep) != 0 ) || ( AV6GoingBack != wcpOAV6GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV21WebSessionKey = AV21WebSessionKey;
         wcpOAV13PreviousStep = AV13PreviousStep;
         wcpOAV6GoingBack = AV6GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV21WebSessionKey = cgiGet( sPrefix+"AV21WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV21WebSessionKey) > 0 )
         {
            AV21WebSessionKey = cgiGet( sCtrlAV21WebSessionKey);
            AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
         }
         else
         {
            AV21WebSessionKey = cgiGet( sPrefix+"AV21WebSessionKey_PARM");
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
         PA2W2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2W2( ) ;
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
         WS2W2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21WebSessionKey_PARM", AV21WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV21WebSessionKey));
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
         WE2W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126284063", true, true);
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
         context.AddJavascriptSource("createresidentstep3.js", "?20249126284063", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavResidentincompanysdts__residentincompanykvknumber_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_43_idx;
         edtavResidentincompanysdts__residentincompanyname_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME_"+sGXsfl_43_idx;
         edtavResidentincompanysdts__residentincompanyemail_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL_"+sGXsfl_43_idx;
         edtavResidentincompanysdts__residentincompanyphone_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE_"+sGXsfl_43_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavResidentincompanysdts__residentincompanykvknumber_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_43_fel_idx;
         edtavResidentincompanysdts__residentincompanyname_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME_"+sGXsfl_43_fel_idx;
         edtavResidentincompanysdts__residentincompanyemail_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL_"+sGXsfl_43_fel_idx;
         edtavResidentincompanysdts__residentincompanyphone_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE_"+sGXsfl_43_fel_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WB2W0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentincompanysdts__residentincompanykvknumber_Internalname,((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1)).gxTpr_Residentincompanykvknumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentincompanysdts__residentincompanykvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentincompanysdts__residentincompanykvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentincompanysdts__residentincompanyname_Internalname,((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1)).gxTpr_Residentincompanyname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentincompanysdts__residentincompanyname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentincompanysdts__residentincompanyname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentincompanysdts__residentincompanyemail_Internalname,((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1)).gxTpr_Residentincompanyemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentincompanysdts__residentincompanyemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentincompanysdts__residentincompanyemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentincompanysdts__residentincompanyphone_Internalname,StringUtil.RTrim( ((SdtResidentINCompanySDT)AV19ResidentINCompanySDTs.Item(AV29GXV1)).gxTpr_Residentincompanyphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentincompanysdts__residentincompanyphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentincompanysdts__residentincompanyphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleterecord_Internalname,StringUtil.RTrim( AV24DeleteRecord),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETERECORD.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDeleterecord_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleterecord_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2W2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_43_idx = ((subGrids_Islastpage==1)&&(nGXsfl_43_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.SendWebValue( "KVK Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
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
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentincompanysdts__residentincompanykvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentincompanysdts__residentincompanyname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentincompanysdts__residentincompanyemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentincompanysdts__residentincompanyphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24DeleteRecord)));
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
         edtavResidentincompanyname_Internalname = sPrefix+"vRESIDENTINCOMPANYNAME";
         edtavResidentincompanykvknumber_Internalname = sPrefix+"vRESIDENTINCOMPANYKVKNUMBER";
         edtavResidentincompanyemail_Internalname = sPrefix+"vRESIDENTINCOMPANYEMAIL";
         edtavResidentincompanyphone_Internalname = sPrefix+"vRESIDENTINCOMPANYPHONE";
         bttBtnsavecompany_Internalname = sPrefix+"BTNSAVECOMPANY";
         divActionbtntable_Internalname = sPrefix+"ACTIONBTNTABLE";
         edtavResidentincompanysdts__residentincompanykvknumber_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYKVKNUMBER";
         edtavResidentincompanysdts__residentincompanyname_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYNAME";
         edtavResidentincompanysdts__residentincompanyemail_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYEMAIL";
         edtavResidentincompanysdts__residentincompanyphone_Internalname = sPrefix+"RESIDENTINCOMPANYSDTS__RESIDENTINCOMPANYPHONE";
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnnext_Internalname = sPrefix+"BTNNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResidentincompanyid_Internalname = sPrefix+"vRESIDENTINCOMPANYID";
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
         edtavResidentincompanysdts__residentincompanyphone_Jsonclick = "";
         edtavResidentincompanysdts__residentincompanyphone_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyemail_Jsonclick = "";
         edtavResidentincompanysdts__residentincompanyemail_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyname_Jsonclick = "";
         edtavResidentincompanysdts__residentincompanyname_Enabled = 0;
         edtavResidentincompanysdts__residentincompanykvknumber_Jsonclick = "";
         edtavResidentincompanysdts__residentincompanykvknumber_Enabled = 0;
         subGrids_Class = "GridWithPaginationBar WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavResidentincompanyid_Jsonclick = "";
         edtavResidentincompanyid_Visible = 1;
         edtavResidentincompanyphone_Jsonclick = "";
         edtavResidentincompanyphone_Enabled = 1;
         edtavResidentincompanyemail_Jsonclick = "";
         edtavResidentincompanyemail_Enabled = 1;
         edtavResidentincompanykvknumber_Jsonclick = "";
         edtavResidentincompanykvknumber_Enabled = 1;
         edtavResidentincompanyname_Jsonclick = "";
         edtavResidentincompanyname_Enabled = 1;
         Gridspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridspaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridspaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
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
         edtavResidentincompanysdts__residentincompanyphone_Enabled = -1;
         edtavResidentincompanysdts__residentincompanyemail_Enabled = -1;
         edtavResidentincompanysdts__residentincompanyname_Enabled = -1;
         edtavResidentincompanysdts__residentincompanykvknumber_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV8GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV9GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E182W2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV24DeleteRecord","fld":"vDELETERECORD"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112W2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122W2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("ENTER","""{"handler":"E192W2","iparms":[{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV17ResidentINCompanyName","fld":"vRESIDENTINCOMPANYNAME"},{"av":"AV16ResidentINCompanyKvkNumber","fld":"vRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV14ResidentINCompanyEmail","fld":"vRESIDENTINCOMPANYEMAIL"},{"av":"AV21WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV15ResidentINCompanyId","fld":"vRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV18ResidentINCompanyPhone","fld":"vRESIDENTINCOMPANYPHONE"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E132W2","iparms":[{"av":"AV21WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV15ResidentINCompanyId","fld":"vRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV17ResidentINCompanyName","fld":"vRESIDENTINCOMPANYNAME"},{"av":"AV16ResidentINCompanyKvkNumber","fld":"vRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV14ResidentINCompanyEmail","fld":"vRESIDENTINCOMPANYEMAIL"},{"av":"AV18ResidentINCompanyPhone","fld":"vRESIDENTINCOMPANYPHONE"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43}]}""");
         setEventMetadata("'DONEXT'","""{"handler":"E142W2","iparms":[{"av":"AV21WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV15ResidentINCompanyId","fld":"vRESIDENTINCOMPANYID","pic":"ZZZ9"},{"av":"AV17ResidentINCompanyName","fld":"vRESIDENTINCOMPANYNAME"},{"av":"AV16ResidentINCompanyKvkNumber","fld":"vRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV14ResidentINCompanyEmail","fld":"vRESIDENTINCOMPANYEMAIL"},{"av":"AV18ResidentINCompanyPhone","fld":"vRESIDENTINCOMPANYPHONE"},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43}]}""");
         setEventMetadata("'DOSAVECOMPANY'","""{"handler":"E152W2","iparms":[{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"AV16ResidentINCompanyKvkNumber","fld":"vRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV17ResidentINCompanyName","fld":"vRESIDENTINCOMPANYNAME"},{"av":"AV14ResidentINCompanyEmail","fld":"vRESIDENTINCOMPANYEMAIL"},{"av":"AV18ResidentINCompanyPhone","fld":"vRESIDENTINCOMPANYPHONE"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOSAVECOMPANY'",""","oparms":[{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16ResidentINCompanyKvkNumber","fld":"vRESIDENTINCOMPANYKVKNUMBER"},{"av":"AV17ResidentINCompanyName","fld":"vRESIDENTINCOMPANYNAME"},{"av":"AV14ResidentINCompanyEmail","fld":"vRESIDENTINCOMPANYEMAIL"},{"av":"AV18ResidentINCompanyPhone","fld":"vRESIDENTINCOMPANYPHONE"}]}""");
         setEventMetadata("VDELETERECORD.CLICK","""{"handler":"E202W2","iparms":[{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VDELETERECORD.CLICK",""","oparms":[{"av":"AV19ResidentINCompanySDTs","fld":"vRESIDENTINCOMPANYSDTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRIDS","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VALIDV_RESIDENTINCOMPANYEMAIL","""{"handler":"Validv_Residentincompanyemail","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
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
         wcpOAV21WebSessionKey = "";
         wcpOAV13PreviousStep = "";
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV19ResidentINCompanySDTs = new GXBaseCollection<SdtResidentINCompanySDT>( context, "ResidentINCompanySDT", "");
         AV7GridsAppliedFilters = "";
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV17ResidentINCompanyName = "";
         AV16ResidentINCompanyKvkNumber = "";
         AV14ResidentINCompanyEmail = "";
         AV18ResidentINCompanyPhone = "";
         bttBtnsavecompany_Jsonclick = "";
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
         AV24DeleteRecord = "";
         GridsRow = new GXWebRow();
         AV23ResidentINCompanySDTsItem = new SdtResidentINCompanySDT(context);
         AV22WizardData = new SdtCreateResidentData(context);
         AV20WebSession = context.GetSession();
         AV25CompanyKvkNumber = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV21WebSessionKey = "";
         sCtrlAV13PreviousStep = "";
         sCtrlAV6GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavResidentincompanysdts__residentincompanykvknumber_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyname_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyemail_Enabled = 0;
         edtavResidentincompanysdts__residentincompanyphone_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV15ResidentINCompanyId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV26Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int subGrids_Rows ;
      private int nGXsfl_43_idx=1 ;
      private int edtavResidentincompanysdts__residentincompanykvknumber_Enabled ;
      private int edtavResidentincompanysdts__residentincompanyname_Enabled ;
      private int edtavResidentincompanysdts__residentincompanyemail_Enabled ;
      private int edtavResidentincompanysdts__residentincompanyphone_Enabled ;
      private int edtavDeleterecord_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int edtavResidentincompanyname_Enabled ;
      private int edtavResidentincompanykvknumber_Enabled ;
      private int edtavResidentincompanyemail_Enabled ;
      private int edtavResidentincompanyphone_Enabled ;
      private int AV29GXV1 ;
      private int edtavResidentincompanyid_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_43_fel_idx=1 ;
      private int AV12PageToGo ;
      private int AV34GXV6 ;
      private int nGXsfl_43_bak_idx=1 ;
      private int AV35GXV7 ;
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
      private string sGXsfl_43_idx="0001" ;
      private string edtavResidentincompanysdts__residentincompanykvknumber_Internalname ;
      private string edtavResidentincompanysdts__residentincompanyname_Internalname ;
      private string edtavResidentincompanysdts__residentincompanyemail_Internalname ;
      private string edtavResidentincompanysdts__residentincompanyphone_Internalname ;
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
      private string edtavResidentincompanyname_Internalname ;
      private string TempTags ;
      private string edtavResidentincompanyname_Jsonclick ;
      private string edtavResidentincompanykvknumber_Internalname ;
      private string edtavResidentincompanykvknumber_Jsonclick ;
      private string edtavResidentincompanyemail_Internalname ;
      private string edtavResidentincompanyemail_Jsonclick ;
      private string edtavResidentincompanyphone_Internalname ;
      private string AV18ResidentINCompanyPhone ;
      private string edtavResidentincompanyphone_Jsonclick ;
      private string divActionbtntable_Internalname ;
      private string bttBtnsavecompany_Internalname ;
      private string bttBtnsavecompany_Jsonclick ;
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
      private string edtavResidentincompanyid_Internalname ;
      private string edtavResidentincompanyid_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV24DeleteRecord ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string sCtrlAV21WebSessionKey ;
      private string sCtrlAV13PreviousStep ;
      private string sCtrlAV6GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavResidentincompanysdts__residentincompanykvknumber_Jsonclick ;
      private string edtavResidentincompanysdts__residentincompanyname_Jsonclick ;
      private string edtavResidentincompanysdts__residentincompanyemail_Jsonclick ;
      private string edtavResidentincompanysdts__residentincompanyphone_Jsonclick ;
      private string edtavDeleterecord_Jsonclick ;
      private string subGrids_Header ;
      private bool AV6GoingBack ;
      private bool wcpOAV6GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool AV28CheckRequiredFieldsResult ;
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
      private bool AV27isAlreadyAdded ;
      private bool gx_BV43 ;
      private string AV21WebSessionKey ;
      private string AV13PreviousStep ;
      private string wcpOAV21WebSessionKey ;
      private string wcpOAV13PreviousStep ;
      private string AV7GridsAppliedFilters ;
      private string AV17ResidentINCompanyName ;
      private string AV16ResidentINCompanyKvkNumber ;
      private string AV14ResidentINCompanyEmail ;
      private string AV25CompanyKvkNumber ;
      private IGxSession AV20WebSession ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtResidentINCompanySDT> AV19ResidentINCompanySDTs ;
      private SdtResidentINCompanySDT AV23ResidentINCompanySDTsItem ;
      private SdtCreateResidentData AV22WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
