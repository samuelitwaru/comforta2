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
   public class createlocationstep3 : GXWebComponent
   {
      public createlocationstep3( )
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

      public createlocationstep3( IGxContext context )
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
         this.AV23PreviousStep = aP1_PreviousStep;
         this.AV14GoingBack = aP2_GoingBack;
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
                  AV25WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
                  AV23PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV23PreviousStep", AV23PreviousStep);
                  AV14GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV25WebSessionKey,(string)AV23PreviousStep,(bool)AV14GoingBack});
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
         nRC_GXsfl_51 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_51"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_51_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_51_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_51_idx = GetPar( "sGXsfl_51_idx");
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
         AV18HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
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
            PA2Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistemail_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistphone_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               edtavDeleterecord_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeleterecord_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleterecord_Enabled), 5, 0), !bGXsfl_51_Refreshing);
               WS2Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "Create Location Step3", "")) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createlocationstep3.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV25WebSessionKey)),UrlEncode(StringUtil.RTrim(AV23PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV14GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV18HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV18HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Locationreceptionistsdts", AV20LocationReceptionistSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Locationreceptionistsdts", AV20LocationReceptionistSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_51", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_51), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16GridsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV15GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25WebSessionKey", wcpOAV25WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV23PreviousStep", wcpOAV23PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV14GoingBack", wcpOAV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV37CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV18HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV18HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV25WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONRECEPTIONISTSDTS", AV20LocationReceptionistSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONRECEPTIONISTSDTS", AV20LocationReceptionistSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV26WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV26WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCUSTOMERLOCATION", AV29CustomerLocation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCUSTOMERLOCATION", AV29CustomerLocation);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMYCUSTOMER", AV21MyCustomer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMYCUSTOMER", AV21MyCustomer);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV23PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV14GoingBack);
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

      protected void RenderHtmlCloseForm2Q2( )
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
         return "CreateLocationStep3" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Create Location Step3", "") ;
      }

      protected void WB2Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createlocationstep3.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerlocationreceptionistgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerlocationreceptionistgivenname_Internalname, context.GetMessage( "Given Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistgivenname_Internalname, AV9CustomerLocationReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( AV9CustomerLocationReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerlocationreceptionistgivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerlocationreceptionistlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerlocationreceptionistlastname_Internalname, context.GetMessage( "Last Name", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistlastname_Internalname, AV12CustomerLocationReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( AV12CustomerLocationReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerlocationreceptionistlastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerlocationreceptionistemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerlocationreceptionistemail_Internalname, context.GetMessage( "Email", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistemail_Internalname, AV8CustomerLocationReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( AV8CustomerLocationReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerlocationreceptionistemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerlocationreceptionistphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerlocationreceptionistphone_Internalname, context.GetMessage( "Phone", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistphone_Internalname, StringUtil.RTrim( AV13CustomerLocationReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( AV13CustomerLocationReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerlocationreceptionistphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerlocationreceptionistaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerlocationreceptionistaddress_Internalname, context.GetMessage( "Address", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavCustomerlocationreceptionistaddress_Internalname, AV7CustomerLocationReceptionistAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtavCustomerlocationreceptionistaddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", "", 0, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsaveactionbtn_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(51), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtnsaveactionbtn_Jsonclick, 5, context.GetMessage( "Add", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSAVEACTIONBTN\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
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
            StartGridControl51( ) ;
         }
         if ( wbEnd == 51 )
         {
            wbEnd = 0;
            nRC_GXsfl_51 = (int)(nGXsfl_51_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV39GXV1 = nGXsfl_51_idx;
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
            ucGridspaginationbar.SetProperty("CurrentPage", AV16GridsCurrentPage);
            ucGridspaginationbar.SetProperty("PageCount", AV17GridsPageCount);
            ucGridspaginationbar.SetProperty("AppliedFilters", AV15GridsAppliedFilters);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(51), 2, 0)+","+"null"+");", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 5, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateLocationStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinish_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(51), 2, 0)+","+"null"+");", context.GetMessage( "Finish", ""), bttBtnfinish_Jsonclick, 5, context.GetMessage( "Finish", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFINISH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateLocationStep3.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CustomerLocationReceptionistId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10CustomerLocationReceptionistId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomerlocationreceptionistid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateLocationStep3.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerlocationreceptionistinitials_Internalname, StringUtil.RTrim( AV11CustomerLocationReceptionistInitials), StringUtil.RTrim( context.localUtil.Format( AV11CustomerLocationReceptionistInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerlocationreceptionistinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomerlocationreceptionistinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateLocationStep3.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 51 )
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
                  AV39GXV1 = nGXsfl_51_idx;
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

      protected void START2Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Create Location Step3", ""), 0) ;
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
               STRUP2Q0( ) ;
            }
         }
      }

      protected void WS2Q2( )
      {
         START2Q2( ) ;
         EVT2Q2( ) ;
      }

      protected void EVT2Q2( )
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
                                 STRUP2Q0( ) ;
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
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E112Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E122Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E132Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFINISH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFinish' */
                                    E142Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVEACTIONBTN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSaveActionBtn' */
                                    E152Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
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
                                 STRUP2Q0( ) ;
                              }
                              nGXsfl_51_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
                              SubsflControlProps_512( ) ;
                              AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) && ( AV39GXV1 > 0 ) )
                              {
                                 AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
                                 AV34DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
                                 AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV34DeleteRecord);
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
                                          GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162Q2 ();
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
                                          GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172Q2 ();
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
                                          GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E182Q2 ();
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
                                                E192Q2 ();
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
                                          GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E202Q2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2Q0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname;
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

      protected void WE2Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Q2( ) ;
            }
         }
      }

      protected void PA2Q2( )
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
               GX_FocusControl = edtavCustomerlocationreceptionistgivenname_Internalname;
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
         SubsflControlProps_512( ) ;
         while ( nGXsfl_51_idx <= nRC_GXsfl_51 )
         {
            sendrow_512( ) ;
            nGXsfl_51_idx = ((subGrids_Islastpage==1)&&(nGXsfl_51_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_512( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV18HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2Q2( ) ;
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
         RF2Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      protected void RF2Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 51;
         /* Execute user event: Refresh */
         E172Q2 ();
         nGXsfl_51_idx = 1;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
         bGXsfl_51_Refreshing = true;
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
            SubsflControlProps_512( ) ;
            /* Execute user event: Grids.Load */
            E182Q2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_51_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E182Q2 ();
            }
            wbEnd = 51;
            WB2Q0( ) ;
         }
         bGXsfl_51_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV18HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV18HasValidationErrors, context));
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
         return AV20LocationReceptionistSDTs.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Locationreceptionistsdts"), AV20LocationReceptionistSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONRECEPTIONISTSDTS"), AV20LocationReceptionistSDTs);
            /* Read saved values. */
            nRC_GXsfl_51 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_51"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV15GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
            wcpOAV23PreviousStep = cgiGet( sPrefix+"wcpOAV23PreviousStep");
            wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
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
            nRC_GXsfl_51 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_51"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_51_fel_idx = 0;
            while ( nGXsfl_51_fel_idx < nRC_GXsfl_51 )
            {
               nGXsfl_51_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_51_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_51_fel_idx+1);
               sGXsfl_51_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_512( ) ;
               AV39GXV1 = (int)(nGXsfl_51_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) && ( AV39GXV1 > 0 ) )
               {
                  AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
                  AV34DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
               }
            }
            if ( nGXsfl_51_fel_idx == 0 )
            {
               nGXsfl_51_idx = 1;
               sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
               SubsflControlProps_512( ) ;
            }
            nGXsfl_51_fel_idx = 1;
            /* Read variables values. */
            AV9CustomerLocationReceptionistGivenName = cgiGet( edtavCustomerlocationreceptionistgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV9CustomerLocationReceptionistGivenName", AV9CustomerLocationReceptionistGivenName);
            AV12CustomerLocationReceptionistLastName = cgiGet( edtavCustomerlocationreceptionistlastname_Internalname);
            AssignAttri(sPrefix, false, "AV12CustomerLocationReceptionistLastName", AV12CustomerLocationReceptionistLastName);
            AV8CustomerLocationReceptionistEmail = cgiGet( edtavCustomerlocationreceptionistemail_Internalname);
            AssignAttri(sPrefix, false, "AV8CustomerLocationReceptionistEmail", AV8CustomerLocationReceptionistEmail);
            AV13CustomerLocationReceptionistPhone = cgiGet( edtavCustomerlocationreceptionistphone_Internalname);
            AssignAttri(sPrefix, false, "AV13CustomerLocationReceptionistPhone", AV13CustomerLocationReceptionistPhone);
            AV7CustomerLocationReceptionistAddress = cgiGet( edtavCustomerlocationreceptionistaddress_Internalname);
            AssignAttri(sPrefix, false, "AV7CustomerLocationReceptionistAddress", AV7CustomerLocationReceptionistAddress);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCustomerlocationreceptionistid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCustomerlocationreceptionistid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSTOMERLOCATIONRECEPTIONISTID");
               GX_FocusControl = edtavCustomerlocationreceptionistid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10CustomerLocationReceptionistId = 0;
               AssignAttri(sPrefix, false, "AV10CustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV10CustomerLocationReceptionistId), 4, 0));
            }
            else
            {
               AV10CustomerLocationReceptionistId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCustomerlocationreceptionistid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV10CustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV10CustomerLocationReceptionistId), 4, 0));
            }
            AV11CustomerLocationReceptionistInitials = cgiGet( edtavCustomerlocationreceptionistinitials_Internalname);
            AssignAttri(sPrefix, false, "AV11CustomerLocationReceptionistInitials", AV11CustomerLocationReceptionistInitials);
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
         E162Q2 ();
         if (returnInSub) return;
      }

      protected void E162Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavCustomerlocationreceptionistid_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomerlocationreceptionistid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationreceptionistid_Visible), 5, 0), true);
         edtavCustomerlocationreceptionistinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomerlocationreceptionistinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerlocationreceptionistinitials_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
         new getloggedincustomermanagerid(context ).execute( out  AV5CManagerId, out  AV21MyCustomer) ;
      }

      protected void E172Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV16GridsCurrentPage = subGrids_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV16GridsCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridsCurrentPage), 10, 0));
         AV17GridsPageCount = subGrids_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV17GridsPageCount", StringUtil.LTrimStr( (decimal)(AV17GridsPageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      private void E182Q2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV20LocationReceptionistSDTs.Count )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
            AV34DeleteRecord = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV34DeleteRecord);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 51;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_512( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_51_Refreshing )
            {
               DoAjaxLoad(51, GridsRow);
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112Q2( )
      {
         /* Gridspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrids_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV22PageToGo = subGrids_fnc_Currentpage( );
            AV22PageToGo = (int)(AV22PageToGo+1);
            subgrids_gotopage( AV22PageToGo) ;
         }
         else
         {
            AV22PageToGo = (int)(Math.Round(NumberUtil.Val( Gridspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrids_gotopage( AV22PageToGo) ;
         }
      }

      protected void E122Q2( )
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
         E192Q2 ();
         if (returnInSub) return;
      }

      protected void E192Q2( )
      {
         AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV37CheckRequiredFieldsResult && ! AV18HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV24WebSession.Remove(AV25WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26WizardData", AV26WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29CustomerLocation", AV29CustomerLocation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21MyCustomer", AV21MyCustomer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20LocationReceptionistSDTs", AV20LocationReceptionistSDTs);
         nGXsfl_51_bak_idx = nGXsfl_51_idx;
         gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
         nGXsfl_51_idx = nGXsfl_51_bak_idx;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
      }

      protected void E132Q2( )
      {
         AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createlocation.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26WizardData", AV26WizardData);
      }

      protected void E142Q2( )
      {
         AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
         }
         /* 'DoFinish' Routine */
         returnInSub = false;
         if ( AV20LocationReceptionistSDTs.Count > 0 )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Add at least 1 receptionist", ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26WizardData", AV26WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29CustomerLocation", AV29CustomerLocation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21MyCustomer", AV21MyCustomer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20LocationReceptionistSDTs", AV20LocationReceptionistSDTs);
         nGXsfl_51_bak_idx = nGXsfl_51_idx;
         gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
         nGXsfl_51_idx = nGXsfl_51_bak_idx;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
      }

      protected void E152Q2( )
      {
         AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
         }
         /* 'DoSaveActionBtn' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV37CheckRequiredFieldsResult && ! AV18HasValidationErrors )
         {
            AV36isAlreadyAdded = false;
            AV46GXV8 = 1;
            while ( AV46GXV8 <= AV20LocationReceptionistSDTs.Count )
            {
               AV27LocationReceptionistSDT = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV46GXV8));
               if ( StringUtil.StrCmp(AV27LocationReceptionistSDT.gxTpr_Locationreceptionistemail, AV8CustomerLocationReceptionistEmail) == 0 )
               {
                  AV36isAlreadyAdded = true;
                  if (true) break;
               }
               AV46GXV8 = (int)(AV46GXV8+1);
            }
            if ( AV36isAlreadyAdded )
            {
               GX_msglist.addItem(context.GetMessage( "The receptionist email has already been added", ""));
            }
            else
            {
               AV27LocationReceptionistSDT = new SdtLocationReceptionistSDT(context);
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistemail = AV8CustomerLocationReceptionistEmail;
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistgivenname = AV9CustomerLocationReceptionistGivenName;
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistlastname = AV12CustomerLocationReceptionistLastName;
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistinitials = AV11CustomerLocationReceptionistInitials;
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistaddress = AV7CustomerLocationReceptionistAddress;
               AV27LocationReceptionistSDT.gxTpr_Locationreceptionistphone = AV13CustomerLocationReceptionistPhone;
               AV20LocationReceptionistSDTs.Add(AV27LocationReceptionistSDT, 0);
               gx_BV51 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20LocationReceptionistSDTs", AV20LocationReceptionistSDTs);
         nGXsfl_51_bak_idx = nGXsfl_51_idx;
         gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
         nGXsfl_51_idx = nGXsfl_51_bak_idx;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV10CustomerLocationReceptionistId = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistid;
         AssignAttri(sPrefix, false, "AV10CustomerLocationReceptionistId", StringUtil.LTrimStr( (decimal)(AV10CustomerLocationReceptionistId), 4, 0));
         AV9CustomerLocationReceptionistGivenName = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistgivenname;
         AssignAttri(sPrefix, false, "AV9CustomerLocationReceptionistGivenName", AV9CustomerLocationReceptionistGivenName);
         AV12CustomerLocationReceptionistLastName = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistlastname;
         AssignAttri(sPrefix, false, "AV12CustomerLocationReceptionistLastName", AV12CustomerLocationReceptionistLastName);
         AV11CustomerLocationReceptionistInitials = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistinitials;
         AssignAttri(sPrefix, false, "AV11CustomerLocationReceptionistInitials", AV11CustomerLocationReceptionistInitials);
         AV8CustomerLocationReceptionistEmail = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistemail;
         AssignAttri(sPrefix, false, "AV8CustomerLocationReceptionistEmail", AV8CustomerLocationReceptionistEmail);
         AV13CustomerLocationReceptionistPhone = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistphone;
         AssignAttri(sPrefix, false, "AV13CustomerLocationReceptionistPhone", AV13CustomerLocationReceptionistPhone);
         AV7CustomerLocationReceptionistAddress = AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistaddress;
         AssignAttri(sPrefix, false, "AV7CustomerLocationReceptionistAddress", AV7CustomerLocationReceptionistAddress);
         AV20LocationReceptionistSDTs = AV26WizardData.gxTpr_Step3.gxTpr_Locationreceptionistsdts;
         gx_BV51 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV26WizardData.FromJSonString(AV24WebSession.Get(AV25WebSessionKey), null);
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistid = AV10CustomerLocationReceptionistId;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistgivenname = AV9CustomerLocationReceptionistGivenName;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistlastname = AV12CustomerLocationReceptionistLastName;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistinitials = AV11CustomerLocationReceptionistInitials;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistemail = AV8CustomerLocationReceptionistEmail;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistphone = AV13CustomerLocationReceptionistPhone;
         AV26WizardData.gxTpr_Step3.gxTpr_Customerlocationreceptionistaddress = AV7CustomerLocationReceptionistAddress;
         AV26WizardData.gxTpr_Step3.gxTpr_Locationreceptionistsdts = AV20LocationReceptionistSDTs;
         AV24WebSession.Set(AV25WebSessionKey, AV26WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV29CustomerLocation.gxTpr_Customerlocationemail = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationemail;
         AV29CustomerLocation.gxTpr_Customerlocationphone = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationphone;
         AV29CustomerLocation.gxTpr_Customerlocationpostaladdress = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationpostaladdress;
         AV29CustomerLocation.gxTpr_Customerlocationvisitingaddress = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationvisitingaddress;
         AV29CustomerLocation.gxTpr_Customerlocationname = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationname;
         AV29CustomerLocation.gxTpr_Customerlocationdescription = AV26WizardData.gxTpr_Step1.gxTpr_Customerlocationdescription;
         AV47GXV9 = 1;
         while ( AV47GXV9 <= AV26WizardData.gxTpr_Step2.gxTpr_Grid.Count )
         {
            AV31Amenity = ((SdtCreateLocationData_Step2_GridItem)AV26WizardData.gxTpr_Step2.gxTpr_Grid.Item(AV47GXV9));
            AV32AmenityBC = new SdtCustomer_Locations_Amenities(context);
            AV32AmenityBC.gxTpr_Amenitiesid = AV31Amenity.gxTpr_Amenitiesid;
            AV29CustomerLocation.gxTpr_Amenities.Add(AV32AmenityBC, 0);
            AV47GXV9 = (int)(AV47GXV9+1);
         }
         AV48GXV10 = 1;
         while ( AV48GXV10 <= AV20LocationReceptionistSDTs.Count )
         {
            AV27LocationReceptionistSDT = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV48GXV10));
            AV28LocationReceptionist = new SdtCustomer_Locations_Receptionist(context);
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistemail = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistemail;
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistgivenname = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistgivenname;
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistlastname = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistlastname;
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistinitials = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistinitials;
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistphone = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistphone;
            AV28LocationReceptionist.gxTpr_Customerlocationreceptionistaddress = AV27LocationReceptionistSDT.gxTpr_Locationreceptionistaddress;
            AV29CustomerLocation.gxTpr_Receptionist.Add(AV28LocationReceptionist, 0);
            AV48GXV10 = (int)(AV48GXV10+1);
         }
         AV21MyCustomer.gxTpr_Locations.Add(AV29CustomerLocation, 0);
         if ( AV21MyCustomer.Update() )
         {
            context.CommitDataStores("createlocationstep3",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S152 ();
            if (returnInSub) return;
            AV24WebSession.Remove(AV25WebSessionKey);
            AV20LocationReceptionistSDTs.Clear();
            gx_BV51 = true;
            CallWebObject(formatLink("customerlocations.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV30ErrorMessages = AV21MyCustomer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV30ErrorMessages.Item(1)).gxTpr_Description);
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV37CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9CustomerLocationReceptionistGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Given Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCustomerlocationreceptionistgivenname_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12CustomerLocationReceptionistLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCustomerlocationreceptionistlastname_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8CustomerLocationReceptionistEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCustomerlocationreceptionistemail_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13CustomerLocationReceptionistPhone)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Phone", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCustomerlocationreceptionistphone_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
      }

      protected void E202Q2( )
      {
         AV39GXV1 = (int)(nGXsfl_51_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV20LocationReceptionistSDTs.Count >= AV39GXV1 ) )
         {
            AV20LocationReceptionistSDTs.CurrentItem = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1));
         }
         /* Deleterecord_Click Routine */
         returnInSub = false;
         AV35receptionistEmail = ((SdtLocationReceptionistSDT)(AV20LocationReceptionistSDTs.CurrentItem)).gxTpr_Locationreceptionistemail;
         AV38Index = 1;
         AV49GXV11 = 1;
         while ( AV49GXV11 <= AV20LocationReceptionistSDTs.Count )
         {
            AV27LocationReceptionistSDT = ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV49GXV11));
            if ( StringUtil.StrCmp(AV27LocationReceptionistSDT.gxTpr_Locationreceptionistemail, AV35receptionistEmail) == 0 )
            {
               if (true) break;
            }
            else
            {
               AV38Index = (short)(AV38Index+1);
            }
            AV49GXV11 = (int)(AV49GXV11+1);
         }
         if ( AV38Index <= AV20LocationReceptionistSDTs.Count )
         {
            AV20LocationReceptionistSDTs.RemoveItem(AV38Index);
            gx_BV51 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20LocationReceptionistSDTs", AV20LocationReceptionistSDTs);
         nGXsfl_51_bak_idx = nGXsfl_51_idx;
         gxgrGrids_refresh( subGrids_Rows, AV18HasValidationErrors, sPrefix) ;
         nGXsfl_51_idx = nGXsfl_51_bak_idx;
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
      }

      protected void S152( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV8CustomerLocationReceptionistEmail = "";
         AssignAttri(sPrefix, false, "AV8CustomerLocationReceptionistEmail", AV8CustomerLocationReceptionistEmail);
         AV9CustomerLocationReceptionistGivenName = "";
         AssignAttri(sPrefix, false, "AV9CustomerLocationReceptionistGivenName", AV9CustomerLocationReceptionistGivenName);
         AV12CustomerLocationReceptionistLastName = "";
         AssignAttri(sPrefix, false, "AV12CustomerLocationReceptionistLastName", AV12CustomerLocationReceptionistLastName);
         AV13CustomerLocationReceptionistPhone = "";
         AssignAttri(sPrefix, false, "AV13CustomerLocationReceptionistPhone", AV13CustomerLocationReceptionistPhone);
         AV7CustomerLocationReceptionistAddress = "";
         AssignAttri(sPrefix, false, "AV7CustomerLocationReceptionistAddress", AV7CustomerLocationReceptionistAddress);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
         AV23PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV23PreviousStep", AV23PreviousStep);
         AV14GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
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
         PA2Q2( ) ;
         WS2Q2( ) ;
         WE2Q2( ) ;
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
         sCtrlAV23PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV14GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createlocationstep3", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV25WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV25WebSessionKey", AV25WebSessionKey);
            AV23PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV23PreviousStep", AV23PreviousStep);
            AV14GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         wcpOAV25WebSessionKey = cgiGet( sPrefix+"wcpOAV25WebSessionKey");
         wcpOAV23PreviousStep = cgiGet( sPrefix+"wcpOAV23PreviousStep");
         wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV25WebSessionKey, wcpOAV25WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV23PreviousStep, wcpOAV23PreviousStep) != 0 ) || ( AV14GoingBack != wcpOAV14GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV25WebSessionKey = AV25WebSessionKey;
         wcpOAV23PreviousStep = AV23PreviousStep;
         wcpOAV14GoingBack = AV14GoingBack;
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
         sCtrlAV23PreviousStep = cgiGet( sPrefix+"AV23PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV23PreviousStep) > 0 )
         {
            AV23PreviousStep = cgiGet( sCtrlAV23PreviousStep);
            AssignAttri(sPrefix, false, "AV23PreviousStep", AV23PreviousStep);
         }
         else
         {
            AV23PreviousStep = cgiGet( sPrefix+"AV23PreviousStep_PARM");
         }
         sCtrlAV14GoingBack = cgiGet( sPrefix+"AV14GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV14GoingBack) > 0 )
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV14GoingBack));
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         else
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV14GoingBack_PARM"));
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
         PA2Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Q2( ) ;
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
         WS2Q2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV23PreviousStep_PARM", AV23PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV23PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV23PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV23PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_PARM", StringUtil.BoolToStr( AV14GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_CTRL", StringUtil.RTrim( sCtrlAV14GoingBack));
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
         WE2Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249131552764", true, true);
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
         context.AddJavascriptSource("createlocationstep3.js", "?20249131552764", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_512( )
      {
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME_"+sGXsfl_51_idx;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME_"+sGXsfl_51_idx;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS_"+sGXsfl_51_idx;
         edtavLocationreceptionistsdts__locationreceptionistemail_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL_"+sGXsfl_51_idx;
         edtavLocationreceptionistsdts__locationreceptionistphone_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE_"+sGXsfl_51_idx;
         edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS_"+sGXsfl_51_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_51_idx;
      }

      protected void SubsflControlProps_fel_512( )
      {
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME_"+sGXsfl_51_fel_idx;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME_"+sGXsfl_51_fel_idx;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS_"+sGXsfl_51_fel_idx;
         edtavLocationreceptionistsdts__locationreceptionistemail_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL_"+sGXsfl_51_fel_idx;
         edtavLocationreceptionistsdts__locationreceptionistphone_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE_"+sGXsfl_51_fel_idx;
         edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS_"+sGXsfl_51_fel_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_51_fel_idx;
      }

      protected void sendrow_512( )
      {
         sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
         SubsflControlProps_512( ) ;
         WB2Q0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_51_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_51_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_51_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname,((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname,((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname,StringUtil.RTrim( ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistemail_Internalname,((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationreceptionistsdts__locationreceptionistemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistphone_Internalname,StringUtil.RTrim( ((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationreceptionistsdts__locationreceptionistphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname,((SdtLocationReceptionistSDT)AV20LocationReceptionistSDTs.Item(AV39GXV1)).gxTpr_Locationreceptionistaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationreceptionistsdts__locationreceptionistaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)51,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_51_idx + "',51)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleterecord_Internalname,StringUtil.RTrim( AV34DeleteRecord),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETERECORD.CLICK."+sGXsfl_51_idx+"'",(string)"",(string)"",context.GetMessage( "Delete Item", ""),(string)"",(string)edtavDeleterecord_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleterecord_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)51,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2Q2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_51_idx = ((subGrids_Islastpage==1)&&(nGXsfl_51_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_51_idx+1);
            sGXsfl_51_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_51_idx), 4, 0), 4, "0");
            SubsflControlProps_512( ) ;
         }
         /* End function sendrow_512 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl51( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"51\">") ;
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
            context.SendWebValue( context.GetMessage( "Given Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Customer Location Receptionist Initials", "")) ;
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
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34DeleteRecord)));
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
         edtavCustomerlocationreceptionistgivenname_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME";
         edtavCustomerlocationreceptionistlastname_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME";
         edtavCustomerlocationreceptionistemail_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTEMAIL";
         edtavCustomerlocationreceptionistphone_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTPHONE";
         edtavCustomerlocationreceptionistaddress_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTADDRESS";
         bttBtnsaveactionbtn_Internalname = sPrefix+"BTNSAVEACTIONBTN";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTGIVENNAME";
         edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTLASTNAME";
         edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTINITIALS";
         edtavLocationreceptionistsdts__locationreceptionistemail_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTEMAIL";
         edtavLocationreceptionistsdts__locationreceptionistphone_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTPHONE";
         edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname = sPrefix+"LOCATIONRECEPTIONISTSDTS__LOCATIONRECEPTIONISTADDRESS";
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnfinish_Internalname = sPrefix+"BTNFINISH";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCustomerlocationreceptionistid_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTID";
         edtavCustomerlocationreceptionistinitials_Internalname = sPrefix+"vCUSTOMERLOCATIONRECEPTIONISTINITIALS";
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
         edtavLocationreceptionistsdts__locationreceptionistaddress_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistphone_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistemail_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Jsonclick = "";
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = 0;
         subGrids_Class = "GridWithPaginationBar WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavCustomerlocationreceptionistinitials_Jsonclick = "";
         edtavCustomerlocationreceptionistinitials_Visible = 1;
         edtavCustomerlocationreceptionistid_Jsonclick = "";
         edtavCustomerlocationreceptionistid_Visible = 1;
         edtavCustomerlocationreceptionistaddress_Enabled = 1;
         edtavCustomerlocationreceptionistphone_Jsonclick = "";
         edtavCustomerlocationreceptionistphone_Enabled = 1;
         edtavCustomerlocationreceptionistemail_Jsonclick = "";
         edtavCustomerlocationreceptionistemail_Enabled = 1;
         edtavCustomerlocationreceptionistlastname_Jsonclick = "";
         edtavCustomerlocationreceptionistlastname_Enabled = 1;
         edtavCustomerlocationreceptionistgivenname_Jsonclick = "";
         edtavCustomerlocationreceptionistgivenname_Enabled = 1;
         Gridspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridspaginationbar_Emptygridcaption = "No receptionist record added";
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
         edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = -1;
         edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = -1;
         edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = -1;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = -1;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = -1;
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV16GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E182Q2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV34DeleteRecord","fld":"vDELETERECORD"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112Q2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122Q2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("ENTER","""{"handler":"E192Q2","iparms":[{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV10CustomerLocationReceptionistId","fld":"vCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV11CustomerLocationReceptionistInitials","fld":"vCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV26WizardData","fld":"vWIZARDDATA"},{"av":"AV29CustomerLocation","fld":"vCUSTOMERLOCATION"},{"av":"AV21MyCustomer","fld":"vMYCUSTOMER"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV26WizardData","fld":"vWIZARDDATA"},{"av":"AV29CustomerLocation","fld":"vCUSTOMERLOCATION"},{"av":"AV21MyCustomer","fld":"vMYCUSTOMER"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E132Q2","iparms":[{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV10CustomerLocationReceptionistId","fld":"vCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV11CustomerLocationReceptionistInitials","fld":"vCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV26WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOFINISH'","""{"handler":"E142Q2","iparms":[{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV25WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV10CustomerLocationReceptionistId","fld":"vCUSTOMERLOCATIONRECEPTIONISTID","pic":"ZZZ9"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV11CustomerLocationReceptionistInitials","fld":"vCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"},{"av":"AV26WizardData","fld":"vWIZARDDATA"},{"av":"AV29CustomerLocation","fld":"vCUSTOMERLOCATION"},{"av":"AV21MyCustomer","fld":"vMYCUSTOMER"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOFINISH'",""","oparms":[{"av":"AV26WizardData","fld":"vWIZARDDATA"},{"av":"AV29CustomerLocation","fld":"vCUSTOMERLOCATION"},{"av":"AV21MyCustomer","fld":"vMYCUSTOMER"},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"}]}""");
         setEventMetadata("'DOSAVEACTIONBTN'","""{"handler":"E152Q2","iparms":[{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV11CustomerLocationReceptionistInitials","fld":"vCUSTOMERLOCATIONRECEPTIONISTINITIALS"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOSAVEACTIONBTN'",""","oparms":[{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV8CustomerLocationReceptionistEmail","fld":"vCUSTOMERLOCATIONRECEPTIONISTEMAIL"},{"av":"AV9CustomerLocationReceptionistGivenName","fld":"vCUSTOMERLOCATIONRECEPTIONISTGIVENNAME"},{"av":"AV12CustomerLocationReceptionistLastName","fld":"vCUSTOMERLOCATIONRECEPTIONISTLASTNAME"},{"av":"AV13CustomerLocationReceptionistPhone","fld":"vCUSTOMERLOCATIONRECEPTIONISTPHONE"},{"av":"AV7CustomerLocationReceptionistAddress","fld":"vCUSTOMERLOCATIONRECEPTIONISTADDRESS"}]}""");
         setEventMetadata("VDELETERECORD.CLICK","""{"handler":"E202Q2","iparms":[{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV18HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VDELETERECORD.CLICK",""","oparms":[{"av":"AV20LocationReceptionistSDTs","fld":"vLOCATIONRECEPTIONISTSDTS","grid":51},{"av":"nGXsfl_51_idx","ctrl":"GRID","prop":"GridCurrRow","grid":51},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_51","ctrl":"GRIDS","prop":"GridRC","grid":51}]}""");
         setEventMetadata("VALIDV_CUSTOMERLOCATIONRECEPTIONISTEMAIL","""{"handler":"Validv_Customerlocationreceptionistemail","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
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
         wcpOAV23PreviousStep = "";
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20LocationReceptionistSDTs = new GXBaseCollection<SdtLocationReceptionistSDT>( context, "LocationReceptionistSDT", "");
         AV15GridsAppliedFilters = "";
         AV26WizardData = new SdtCreateLocationData(context);
         AV29CustomerLocation = new SdtCustomer_Locations(context);
         AV21MyCustomer = new SdtCustomer(context);
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV9CustomerLocationReceptionistGivenName = "";
         AV12CustomerLocationReceptionistLastName = "";
         AV8CustomerLocationReceptionistEmail = "";
         AV13CustomerLocationReceptionistPhone = "";
         AV7CustomerLocationReceptionistAddress = "";
         bttBtnsaveactionbtn_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridspaginationbar = new GXUserControl();
         bttBtnwizardprevious_Jsonclick = "";
         bttBtnfinish_Jsonclick = "";
         AV11CustomerLocationReceptionistInitials = "";
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34DeleteRecord = "";
         GridsRow = new GXWebRow();
         AV24WebSession = context.GetSession();
         AV27LocationReceptionistSDT = new SdtLocationReceptionistSDT(context);
         AV31Amenity = new SdtCreateLocationData_Step2_GridItem(context);
         AV32AmenityBC = new SdtCustomer_Locations_Amenities(context);
         AV28LocationReceptionist = new SdtCustomer_Locations_Receptionist(context);
         AV30ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV35receptionistEmail = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV25WebSessionKey = "";
         sCtrlAV23PreviousStep = "";
         sCtrlAV14GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createlocationstep3__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createlocationstep3__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistemail_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistphone_Enabled = 0;
         edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV10CustomerLocationReceptionistId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV5CManagerId ;
      private short AV38Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_51 ;
      private int subGrids_Rows ;
      private int nGXsfl_51_idx=1 ;
      private int edtavLocationreceptionistsdts__locationreceptionistgivenname_Enabled ;
      private int edtavLocationreceptionistsdts__locationreceptionistlastname_Enabled ;
      private int edtavLocationreceptionistsdts__locationreceptionistinitials_Enabled ;
      private int edtavLocationreceptionistsdts__locationreceptionistemail_Enabled ;
      private int edtavLocationreceptionistsdts__locationreceptionistphone_Enabled ;
      private int edtavLocationreceptionistsdts__locationreceptionistaddress_Enabled ;
      private int edtavDeleterecord_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int edtavCustomerlocationreceptionistgivenname_Enabled ;
      private int edtavCustomerlocationreceptionistlastname_Enabled ;
      private int edtavCustomerlocationreceptionistemail_Enabled ;
      private int edtavCustomerlocationreceptionistphone_Enabled ;
      private int edtavCustomerlocationreceptionistaddress_Enabled ;
      private int AV39GXV1 ;
      private int edtavCustomerlocationreceptionistid_Visible ;
      private int edtavCustomerlocationreceptionistinitials_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_51_fel_idx=1 ;
      private int AV22PageToGo ;
      private int nGXsfl_51_bak_idx=1 ;
      private int AV46GXV8 ;
      private int AV47GXV9 ;
      private int AV48GXV10 ;
      private int AV49GXV11 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long AV16GridsCurrentPage ;
      private long AV17GridsPageCount ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Gridspaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_51_idx="0001" ;
      private string edtavLocationreceptionistsdts__locationreceptionistgivenname_Internalname ;
      private string edtavLocationreceptionistsdts__locationreceptionistlastname_Internalname ;
      private string edtavLocationreceptionistsdts__locationreceptionistinitials_Internalname ;
      private string edtavLocationreceptionistsdts__locationreceptionistemail_Internalname ;
      private string edtavLocationreceptionistsdts__locationreceptionistphone_Internalname ;
      private string edtavLocationreceptionistsdts__locationreceptionistaddress_Internalname ;
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
      private string edtavCustomerlocationreceptionistgivenname_Internalname ;
      private string TempTags ;
      private string edtavCustomerlocationreceptionistgivenname_Jsonclick ;
      private string edtavCustomerlocationreceptionistlastname_Internalname ;
      private string edtavCustomerlocationreceptionistlastname_Jsonclick ;
      private string edtavCustomerlocationreceptionistemail_Internalname ;
      private string edtavCustomerlocationreceptionistemail_Jsonclick ;
      private string edtavCustomerlocationreceptionistphone_Internalname ;
      private string AV13CustomerLocationReceptionistPhone ;
      private string edtavCustomerlocationreceptionistphone_Jsonclick ;
      private string edtavCustomerlocationreceptionistaddress_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string bttBtnsaveactionbtn_Internalname ;
      private string bttBtnsaveactionbtn_Jsonclick ;
      private string divGridstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string Gridspaginationbar_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtnwizardprevious_Internalname ;
      private string bttBtnwizardprevious_Jsonclick ;
      private string bttBtnfinish_Internalname ;
      private string bttBtnfinish_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavCustomerlocationreceptionistid_Internalname ;
      private string edtavCustomerlocationreceptionistid_Jsonclick ;
      private string edtavCustomerlocationreceptionistinitials_Internalname ;
      private string AV11CustomerLocationReceptionistInitials ;
      private string edtavCustomerlocationreceptionistinitials_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV34DeleteRecord ;
      private string sGXsfl_51_fel_idx="0001" ;
      private string sCtrlAV25WebSessionKey ;
      private string sCtrlAV23PreviousStep ;
      private string sCtrlAV14GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavLocationreceptionistsdts__locationreceptionistgivenname_Jsonclick ;
      private string edtavLocationreceptionistsdts__locationreceptionistlastname_Jsonclick ;
      private string edtavLocationreceptionistsdts__locationreceptionistinitials_Jsonclick ;
      private string edtavLocationreceptionistsdts__locationreceptionistemail_Jsonclick ;
      private string edtavLocationreceptionistsdts__locationreceptionistphone_Jsonclick ;
      private string edtavLocationreceptionistsdts__locationreceptionistaddress_Jsonclick ;
      private string edtavDeleterecord_Jsonclick ;
      private string subGrids_Header ;
      private bool AV14GoingBack ;
      private bool wcpOAV14GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18HasValidationErrors ;
      private bool bGXsfl_51_Refreshing=false ;
      private bool AV37CheckRequiredFieldsResult ;
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
      private bool AV36isAlreadyAdded ;
      private bool gx_BV51 ;
      private string AV25WebSessionKey ;
      private string AV23PreviousStep ;
      private string wcpOAV25WebSessionKey ;
      private string wcpOAV23PreviousStep ;
      private string AV15GridsAppliedFilters ;
      private string AV9CustomerLocationReceptionistGivenName ;
      private string AV12CustomerLocationReceptionistLastName ;
      private string AV8CustomerLocationReceptionistEmail ;
      private string AV7CustomerLocationReceptionistAddress ;
      private string AV35receptionistEmail ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV24WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtLocationReceptionistSDT> AV20LocationReceptionistSDTs ;
      private SdtCreateLocationData AV26WizardData ;
      private SdtCustomer_Locations AV29CustomerLocation ;
      private SdtCustomer AV21MyCustomer ;
      private SdtLocationReceptionistSDT AV27LocationReceptionistSDT ;
      private SdtCreateLocationData_Step2_GridItem AV31Amenity ;
      private SdtCustomer_Locations_Amenities AV32AmenityBC ;
      private SdtCustomer_Locations_Receptionist AV28LocationReceptionist ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV30ErrorMessages ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class createlocationstep3__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class createlocationstep3__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
