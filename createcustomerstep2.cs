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
   public class createcustomerstep2 : GXWebComponent
   {
      public createcustomerstep2( )
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

      public createcustomerstep2( IGxContext context )
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
         this.AV39WebSessionKey = aP0_WebSessionKey;
         this.AV37PreviousStep = aP1_PreviousStep;
         this.AV20GoingBack = aP2_GoingBack;
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
         cmbavCustomermanagergender = new GXCombobox();
         cmbavCustomermanagersdts__customermanagergender = new GXCombobox();
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
                  AV39WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV39WebSessionKey", AV39WebSessionKey);
                  AV37PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV37PreviousStep", AV37PreviousStep);
                  AV20GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV20GoingBack", AV20GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV39WebSessionKey,(string)AV37PreviousStep,(bool)AV20GoingBack});
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
         nRC_GXsfl_49 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_49"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_49_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_49_idx = GetPar( "sGXsfl_49_idx");
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
         AV28HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
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
            PA2F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavCustomermanagersdts__customermanagergivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdts__customermanagergivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdts__customermanagergivenname_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavCustomermanagersdts__customermanagerlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdts__customermanagerlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdts__customermanagerlastname_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavCustomermanagersdt_customermanagerinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdt_customermanagerinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdt_customermanagerinitials_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavCustomermanagersdts__customermanageremail_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdts__customermanageremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdts__customermanageremail_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavCustomermanagersdts__customermanagerphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdts__customermanagerphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdts__customermanagerphone_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               cmbavCustomermanagersdts__customermanagergender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavCustomermanagersdts__customermanagergender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCustomermanagersdts__customermanagergender.Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavCustomermanagersdt_customermanagergamguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavCustomermanagersdt_customermanagergamguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCustomermanagersdt_customermanagergamguid_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               edtavDeleterecord_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeleterecord_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleterecord_Enabled), 5, 0), !bGXsfl_49_Refreshing);
               WS2F2( ) ;
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
            context.SendWebValue( "Create Customer Step2") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createcustomerstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV39WebSessionKey)),UrlEncode(StringUtil.RTrim(AV37PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV20GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV28HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV28HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Customermanagersdts", AV17CustomerManagerSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Customermanagersdts", AV17CustomerManagerSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Customermanagersdt", AV16CustomerManagerSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Customermanagersdt", AV16CustomerManagerSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_49", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_49), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridsCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridsPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV24GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV39WebSessionKey", wcpOAV39WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37PreviousStep", wcpOAV37PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV20GoingBack", wcpOAV20GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV43CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV28HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV28HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV39WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCUSTOMERMANAGERSDTS", AV17CustomerManagerSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCUSTOMERMANAGERSDTS", AV17CustomerManagerSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCUSTOMER", AV6Customer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCUSTOMER", AV6Customer);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV40WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV40WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"CUSTOMERMANAGEREMAIL", A10CustomerManagerEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV37PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV20GoingBack);
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

      protected void RenderHtmlCloseForm2F2( )
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
         return "CreateCustomerStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return "Create Customer Step2" ;
      }

      protected void WB2F0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createcustomerstep2.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomermanagergivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomermanagergivenname_Internalname, "Given Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagergivenname_Internalname, AV11CustomerManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV11CustomerManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomermanagergivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomermanagerlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomermanagerlastname_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagerlastname_Internalname, AV14CustomerManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV14CustomerManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomermanagerlastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomermanageremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomermanageremail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanageremail_Internalname, AV8CustomerManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV8CustomerManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanageremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomermanageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomermanagerphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomermanagerphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagerphone_Internalname, StringUtil.RTrim( AV15CustomerManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV15CustomerManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagerphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomermanagerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCustomermanagergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCustomermanagergender_Internalname, "Gender", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCustomermanagergender, cmbavCustomermanagergender_Internalname, StringUtil.RTrim( AV10CustomerManagerGender), 1, cmbavCustomermanagergender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavCustomermanagergender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_CreateCustomerStep2.htm");
            cmbavCustomermanagergender.CurrentValue = StringUtil.RTrim( AV10CustomerManagerGender);
            AssignProp(sPrefix, false, cmbavCustomermanagergender_Internalname, "Values", (string)(cmbavCustomermanagergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionbtntable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Add", bttBtnsave_Jsonclick, 5, "Add", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSAVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            StartGridControl49( ) ;
         }
         if ( wbEnd == 49 )
         {
            wbEnd = 0;
            nRC_GXsfl_49 = (int)(nGXsfl_49_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV44GXV1 = nGXsfl_49_idx;
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
            ucGridspaginationbar.SetProperty("CurrentPage", AV25GridsCurrentPage);
            ucGridspaginationbar.SetProperty("PageCount", AV26GridsPageCount);
            ucGridspaginationbar.SetProperty("AppliedFilters", AV24GridsAppliedFilters);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Previous", bttBtnwizardprevious_Jsonclick, 5, "Previous", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateCustomerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinish_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Finish", bttBtnfinish_Jsonclick, 5, "Finish", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFINISH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateCustomerStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CustomerManagerId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12CustomerManagerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomermanagerid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateCustomerStep2.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagerinitials_Internalname, StringUtil.RTrim( AV13CustomerManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV13CustomerManagerInitials, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomermanagerinitials_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomermanagergamguid_Internalname, AV9CustomerManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( AV9CustomerManagerGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomermanagergamguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomermanagergamguid_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_CreateCustomerStep2.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 49 )
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
                  AV44GXV1 = nGXsfl_49_idx;
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

      protected void START2F2( )
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
            Form.Meta.addItem("description", "Create Customer Step2", 0) ;
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
               STRUP2F0( ) ;
            }
         }
      }

      protected void WS2F2( )
      {
         START2F2( ) ;
         EVT2F2( ) ;
      }

      protected void EVT2F2( )
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
                                 STRUP2F0( ) ;
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
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E112F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E122F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E132F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFINISH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFinish' */
                                    E142F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoSave' */
                                    E152F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
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
                                 STRUP2F0( ) ;
                              }
                              nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
                              SubsflControlProps_492( ) ;
                              AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
                              {
                                 AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
                                 AV16CustomerManagerSDT.gxTpr_Customermanagerinitials = cgiGet( edtavCustomermanagersdt_customermanagerinitials_Internalname);
                                 AV16CustomerManagerSDT.gxTpr_Customermanagergamguid = cgiGet( edtavCustomermanagersdt_customermanagergamguid_Internalname);
                                 AV41DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
                                 AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV41DeleteRecord);
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
                                          GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162F2 ();
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
                                          GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172F2 ();
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
                                          GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E182F2 ();
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
                                                E192F2 ();
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
                                          GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E202F2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2F0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavCustomermanagersdts__customermanagergivenname_Internalname;
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

      protected void WE2F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2F2( ) ;
            }
         }
      }

      protected void PA2F2( )
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
               GX_FocusControl = edtavCustomermanagergivenname_Internalname;
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
         SubsflControlProps_492( ) ;
         while ( nGXsfl_49_idx <= nRC_GXsfl_49 )
         {
            sendrow_492( ) ;
            nGXsfl_49_idx = ((subGrids_Islastpage==1)&&(nGXsfl_49_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV28HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2F2( ) ;
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
         if ( cmbavCustomermanagergender.ItemCount > 0 )
         {
            AV10CustomerManagerGender = cmbavCustomermanagergender.getValidValue(AV10CustomerManagerGender);
            AssignAttri(sPrefix, false, "AV10CustomerManagerGender", AV10CustomerManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCustomermanagergender.CurrentValue = StringUtil.RTrim( AV10CustomerManagerGender);
            AssignProp(sPrefix, false, cmbavCustomermanagergender_Internalname, "Values", cmbavCustomermanagergender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCustomermanagersdts__customermanagergivenname_Enabled = 0;
         edtavCustomermanagersdts__customermanagerlastname_Enabled = 0;
         edtavCustomermanagersdt_customermanagerinitials_Enabled = 0;
         edtavCustomermanagersdts__customermanageremail_Enabled = 0;
         edtavCustomermanagersdts__customermanagerphone_Enabled = 0;
         cmbavCustomermanagersdts__customermanagergender.Enabled = 0;
         edtavCustomermanagersdt_customermanagergamguid_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      protected void RF2F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 49;
         /* Execute user event: Refresh */
         E172F2 ();
         nGXsfl_49_idx = 1;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         bGXsfl_49_Refreshing = true;
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
            SubsflControlProps_492( ) ;
            /* Execute user event: Grids.Load */
            E182F2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_49_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E182F2 ();
            }
            wbEnd = 49;
            WB2F0( ) ;
         }
         bGXsfl_49_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2F2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV28HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV28HasValidationErrors, context));
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
         return AV17CustomerManagerSDTs.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavCustomermanagersdts__customermanagergivenname_Enabled = 0;
         edtavCustomermanagersdts__customermanagerlastname_Enabled = 0;
         edtavCustomermanagersdt_customermanagerinitials_Enabled = 0;
         edtavCustomermanagersdts__customermanageremail_Enabled = 0;
         edtavCustomermanagersdts__customermanagerphone_Enabled = 0;
         cmbavCustomermanagersdts__customermanagergender.Enabled = 0;
         edtavCustomermanagersdt_customermanagergamguid_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162F2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Customermanagersdts"), AV17CustomerManagerSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Customermanagersdt"), AV16CustomerManagerSDT);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCUSTOMERMANAGERSDTS"), AV17CustomerManagerSDTs);
            /* Read saved values. */
            nRC_GXsfl_49 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_49"), ".", ","), 18, MidpointRounding.ToEven));
            AV25GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV26GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV24GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV39WebSessionKey = cgiGet( sPrefix+"wcpOAV39WebSessionKey");
            wcpOAV37PreviousStep = cgiGet( sPrefix+"wcpOAV37PreviousStep");
            wcpOAV20GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV20GoingBack"));
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
            nRC_GXsfl_49 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_49"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_49_fel_idx = 0;
            while ( nGXsfl_49_fel_idx < nRC_GXsfl_49 )
            {
               nGXsfl_49_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_49_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_fel_idx+1);
               sGXsfl_49_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_492( ) ;
               AV44GXV1 = (int)(nGXsfl_49_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
               {
                  AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
                  AV16CustomerManagerSDT.gxTpr_Customermanagerinitials = cgiGet( edtavCustomermanagersdt_customermanagerinitials_Internalname);
                  AV16CustomerManagerSDT.gxTpr_Customermanagergamguid = cgiGet( edtavCustomermanagersdt_customermanagergamguid_Internalname);
                  AV41DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
               }
            }
            if ( nGXsfl_49_fel_idx == 0 )
            {
               nGXsfl_49_idx = 1;
               sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
               SubsflControlProps_492( ) ;
            }
            nGXsfl_49_fel_idx = 1;
            /* Read variables values. */
            AV11CustomerManagerGivenName = cgiGet( edtavCustomermanagergivenname_Internalname);
            AssignAttri(sPrefix, false, "AV11CustomerManagerGivenName", AV11CustomerManagerGivenName);
            AV14CustomerManagerLastName = cgiGet( edtavCustomermanagerlastname_Internalname);
            AssignAttri(sPrefix, false, "AV14CustomerManagerLastName", AV14CustomerManagerLastName);
            AV8CustomerManagerEmail = cgiGet( edtavCustomermanageremail_Internalname);
            AssignAttri(sPrefix, false, "AV8CustomerManagerEmail", AV8CustomerManagerEmail);
            AV15CustomerManagerPhone = cgiGet( edtavCustomermanagerphone_Internalname);
            AssignAttri(sPrefix, false, "AV15CustomerManagerPhone", AV15CustomerManagerPhone);
            cmbavCustomermanagergender.Name = cmbavCustomermanagergender_Internalname;
            cmbavCustomermanagergender.CurrentValue = cgiGet( cmbavCustomermanagergender_Internalname);
            AV10CustomerManagerGender = cgiGet( cmbavCustomermanagergender_Internalname);
            AssignAttri(sPrefix, false, "AV10CustomerManagerGender", AV10CustomerManagerGender);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCustomermanagerid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCustomermanagerid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSTOMERMANAGERID");
               GX_FocusControl = edtavCustomermanagerid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12CustomerManagerId = 0;
               AssignAttri(sPrefix, false, "AV12CustomerManagerId", StringUtil.LTrimStr( (decimal)(AV12CustomerManagerId), 4, 0));
            }
            else
            {
               AV12CustomerManagerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCustomermanagerid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV12CustomerManagerId", StringUtil.LTrimStr( (decimal)(AV12CustomerManagerId), 4, 0));
            }
            AV13CustomerManagerInitials = cgiGet( edtavCustomermanagerinitials_Internalname);
            AssignAttri(sPrefix, false, "AV13CustomerManagerInitials", AV13CustomerManagerInitials);
            AV9CustomerManagerGAMGUID = cgiGet( edtavCustomermanagergamguid_Internalname);
            AssignAttri(sPrefix, false, "AV9CustomerManagerGAMGUID", AV9CustomerManagerGAMGUID);
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
         E162F2 ();
         if (returnInSub) return;
      }

      protected void E162F2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavCustomermanagerid_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomermanagerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomermanagerid_Visible), 5, 0), true);
         edtavCustomermanagerinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomermanagerinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomermanagerinitials_Visible), 5, 0), true);
         edtavCustomermanagergamguid_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomermanagergamguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomermanagergamguid_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV6Customer.gxTpr_Customeremail = AV40WizardData.gxTpr_Step1.gxTpr_Customeremail;
         AV6Customer.gxTpr_Customerkvknumber = AV40WizardData.gxTpr_Step1.gxTpr_Customerkvknumber;
         AV6Customer.gxTpr_Customername = AV40WizardData.gxTpr_Step1.gxTpr_Customername;
         AV6Customer.gxTpr_Customerphone = AV40WizardData.gxTpr_Step1.gxTpr_Customerphone;
         AV6Customer.gxTpr_Customerpostaladdress = AV40WizardData.gxTpr_Step1.gxTpr_Customerpostaladdress;
         AV6Customer.gxTpr_Customertypeid = AV40WizardData.gxTpr_Step1.gxTpr_Customertypeid;
         AV6Customer.gxTpr_Customervatnumber = AV40WizardData.gxTpr_Step1.gxTpr_Customervatnumber;
         AV6Customer.gxTpr_Customervisitingaddress = AV40WizardData.gxTpr_Step1.gxTpr_Customervisitingaddress;
      }

      protected void E172F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV25GridsCurrentPage = subGrids_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV25GridsCurrentPage", StringUtil.LTrimStr( (decimal)(AV25GridsCurrentPage), 10, 0));
         AV26GridsPageCount = subGrids_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV26GridsPageCount", StringUtil.LTrimStr( (decimal)(AV26GridsPageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      private void E182F2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV17CustomerManagerSDTs.Count )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
            AV41DeleteRecord = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV41DeleteRecord);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 49;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_492( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_49_Refreshing )
            {
               DoAjaxLoad(49, GridsRow);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112F2( )
      {
         /* Gridspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrids_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV36PageToGo = subGrids_fnc_Currentpage( );
            AV36PageToGo = (int)(AV36PageToGo+1);
            subgrids_gotopage( AV36PageToGo) ;
         }
         else
         {
            AV36PageToGo = (int)(Math.Round(NumberUtil.Val( Gridspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrids_gotopage( AV36PageToGo) ;
         }
      }

      protected void E122F2( )
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
         E192F2 ();
         if (returnInSub) return;
      }

      protected void E192F2( )
      {
         AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV43CheckRequiredFieldsResult && ! AV28HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV38WebSession.Remove(AV39WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV40WizardData", AV40WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6Customer", AV6Customer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17CustomerManagerSDTs", AV17CustomerManagerSDTs);
         nGXsfl_49_bak_idx = nGXsfl_49_idx;
         gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
         nGXsfl_49_idx = nGXsfl_49_bak_idx;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         cmbavCustomermanagergender.CurrentValue = StringUtil.RTrim( AV10CustomerManagerGender);
         AssignProp(sPrefix, false, cmbavCustomermanagergender_Internalname, "Values", cmbavCustomermanagergender.ToJavascriptSource(), true);
      }

      protected void E132F2( )
      {
         AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createcustomer.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV40WizardData", AV40WizardData);
      }

      protected void E142F2( )
      {
         AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
         }
         /* 'DoFinish' Routine */
         returnInSub = false;
         if ( AV17CustomerManagerSDTs.Count > 0 )
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
            GX_msglist.addItem("Add at least 1 manager");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV40WizardData", AV40WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6Customer", AV6Customer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17CustomerManagerSDTs", AV17CustomerManagerSDTs);
         nGXsfl_49_bak_idx = nGXsfl_49_idx;
         gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
         nGXsfl_49_idx = nGXsfl_49_bak_idx;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         cmbavCustomermanagergender.CurrentValue = StringUtil.RTrim( AV10CustomerManagerGender);
         AssignProp(sPrefix, false, cmbavCustomermanagergender_Internalname, "Values", cmbavCustomermanagergender.ToJavascriptSource(), true);
      }

      protected void E152F2( )
      {
         AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
         }
         /* 'DoSave' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV43CheckRequiredFieldsResult && ! AV28HasValidationErrors )
         {
            AV42isAlreadyAdded = false;
            AV52GXLvl131 = 0;
            /* Using cursor H002F2 */
            pr_default.execute(0, new Object[] {AV8CustomerManagerEmail});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A10CustomerManagerEmail = H002F2_A10CustomerManagerEmail[0];
               GXt_char1 = AV13CustomerManagerInitials;
               new getnameinitials(context ).execute(  AV11CustomerManagerGivenName,  AV14CustomerManagerLastName, out  GXt_char1) ;
               AV13CustomerManagerInitials = GXt_char1;
               AssignAttri(sPrefix, false, "AV13CustomerManagerInitials", AV13CustomerManagerInitials);
               AV52GXLvl131 = 1;
               AV42isAlreadyAdded = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV52GXLvl131 == 0 )
            {
               AV53GXV9 = 1;
               while ( AV53GXV9 <= AV17CustomerManagerSDTs.Count )
               {
                  AV18CustomerManagerSDTsItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV53GXV9));
                  if ( StringUtil.StrCmp(AV18CustomerManagerSDTsItem.gxTpr_Customermanageremail, AV8CustomerManagerEmail) == 0 )
                  {
                     AV42isAlreadyAdded = true;
                     if (true) break;
                  }
                  AV53GXV9 = (int)(AV53GXV9+1);
               }
            }
            if ( AV42isAlreadyAdded )
            {
               GX_msglist.addItem("This Manager email has already been added");
            }
            else
            {
               AV18CustomerManagerSDTsItem = new SdtCustomerManagerSDT(context);
               AV18CustomerManagerSDTsItem.gxTpr_Customermanageremail = AV8CustomerManagerEmail;
               AV18CustomerManagerSDTsItem.gxTpr_Customermanagergivenname = AV11CustomerManagerGivenName;
               AV18CustomerManagerSDTsItem.gxTpr_Customermanagergender = AV10CustomerManagerGender;
               AV18CustomerManagerSDTsItem.gxTpr_Customermanagerlastname = AV14CustomerManagerLastName;
               AV18CustomerManagerSDTsItem.gxTpr_Customermanagerphone = AV15CustomerManagerPhone;
               AV18CustomerManagerSDTsItem.gxTpr_Customermanagerinitials = AV13CustomerManagerInitials;
               AV17CustomerManagerSDTs.Add(AV18CustomerManagerSDTsItem, 0);
               gx_BV49 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17CustomerManagerSDTs", AV17CustomerManagerSDTs);
         nGXsfl_49_bak_idx = nGXsfl_49_idx;
         gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
         nGXsfl_49_idx = nGXsfl_49_bak_idx;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         cmbavCustomermanagergender.CurrentValue = StringUtil.RTrim( AV10CustomerManagerGender);
         AssignProp(sPrefix, false, cmbavCustomermanagergender_Internalname, "Values", cmbavCustomermanagergender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV40WizardData.FromJSonString(AV38WebSession.Get(AV39WebSessionKey), null);
         AV12CustomerManagerId = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerid;
         AssignAttri(sPrefix, false, "AV12CustomerManagerId", StringUtil.LTrimStr( (decimal)(AV12CustomerManagerId), 4, 0));
         AV11CustomerManagerGivenName = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergivenname;
         AssignAttri(sPrefix, false, "AV11CustomerManagerGivenName", AV11CustomerManagerGivenName);
         AV14CustomerManagerLastName = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerlastname;
         AssignAttri(sPrefix, false, "AV14CustomerManagerLastName", AV14CustomerManagerLastName);
         AV13CustomerManagerInitials = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerinitials;
         AssignAttri(sPrefix, false, "AV13CustomerManagerInitials", AV13CustomerManagerInitials);
         AV8CustomerManagerEmail = AV40WizardData.gxTpr_Step2.gxTpr_Customermanageremail;
         AssignAttri(sPrefix, false, "AV8CustomerManagerEmail", AV8CustomerManagerEmail);
         AV15CustomerManagerPhone = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerphone;
         AssignAttri(sPrefix, false, "AV15CustomerManagerPhone", AV15CustomerManagerPhone);
         AV10CustomerManagerGender = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergender;
         AssignAttri(sPrefix, false, "AV10CustomerManagerGender", AV10CustomerManagerGender);
         AV9CustomerManagerGAMGUID = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergamguid;
         AssignAttri(sPrefix, false, "AV9CustomerManagerGAMGUID", AV9CustomerManagerGAMGUID);
         AV17CustomerManagerSDTs = AV40WizardData.gxTpr_Step2.gxTpr_Customermanagersdts;
         gx_BV49 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV40WizardData.FromJSonString(AV38WebSession.Get(AV39WebSessionKey), null);
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerid = AV12CustomerManagerId;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergivenname = AV11CustomerManagerGivenName;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerlastname = AV14CustomerManagerLastName;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerinitials = AV13CustomerManagerInitials;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanageremail = AV8CustomerManagerEmail;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagerphone = AV15CustomerManagerPhone;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergender = AV10CustomerManagerGender;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagergamguid = AV9CustomerManagerGAMGUID;
         AV40WizardData.gxTpr_Step2.gxTpr_Customermanagersdts = AV17CustomerManagerSDTs;
         AV38WebSession.Set(AV39WebSessionKey, AV40WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV54GXV10 = 1;
         while ( AV54GXV10 <= AV17CustomerManagerSDTs.Count )
         {
            AV35ManagerSDTItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV54GXV10));
            AV7CustomerManager = new SdtCustomer_Manager(context);
            AV7CustomerManager.gxTpr_Customermanagergivenname = AV35ManagerSDTItem.gxTpr_Customermanagergivenname;
            AV7CustomerManager.gxTpr_Customermanagerlastname = AV35ManagerSDTItem.gxTpr_Customermanagerlastname;
            AV7CustomerManager.gxTpr_Customermanagerinitials = AV35ManagerSDTItem.gxTpr_Customermanagerinitials;
            AV7CustomerManager.gxTpr_Customermanagergender = AV35ManagerSDTItem.gxTpr_Customermanagergender;
            AV7CustomerManager.gxTpr_Customermanageremail = AV35ManagerSDTItem.gxTpr_Customermanageremail;
            AV7CustomerManager.gxTpr_Customermanagerphone = AV35ManagerSDTItem.gxTpr_Customermanagerphone;
            AV7CustomerManager.gxTpr_Customermanagergamguid = AV35ManagerSDTItem.gxTpr_Customermanagergamguid;
            AV6Customer.gxTpr_Manager.Add(AV7CustomerManager, 0);
            AV54GXV10 = (int)(AV54GXV10+1);
         }
         AV6Customer.Save();
         if ( AV6Customer.Success() )
         {
            context.CommitDataStores("createcustomerstep2",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S152 ();
            if (returnInSub) return;
            AV38WebSession.Remove(AV39WebSessionKey);
            AV17CustomerManagerSDTs.Clear();
            gx_BV49 = true;
            AV40WizardData.gxTpr_Step2.gxTpr_Customermanagersdts = AV17CustomerManagerSDTs;
            CallWebObject(formatLink("customerww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV19ErrorMessages = AV6Customer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV19ErrorMessages.Item(1)).gxTpr_Description);
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV43CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV43CheckRequiredFieldsResult", AV43CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11CustomerManagerGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Given Name", "", "", "", "", "", "", "", ""),  "error",  edtavCustomermanagergivenname_Internalname,  "true",  ""));
            AV43CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV43CheckRequiredFieldsResult", AV43CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14CustomerManagerLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Last Name", "", "", "", "", "", "", "", ""),  "error",  edtavCustomermanagerlastname_Internalname,  "true",  ""));
            AV43CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV43CheckRequiredFieldsResult", AV43CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8CustomerManagerEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavCustomermanageremail_Internalname,  "true",  ""));
            AV43CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV43CheckRequiredFieldsResult", AV43CheckRequiredFieldsResult);
         }
      }

      protected void E202F2( )
      {
         AV44GXV1 = (int)(nGXsfl_49_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) )
         {
            AV17CustomerManagerSDTs.CurrentItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1));
         }
         /* Deleterecord_Click Routine */
         returnInSub = false;
         AV30ManagerEmail = ((SdtCustomerManagerSDT)(AV17CustomerManagerSDTs.CurrentItem)).gxTpr_Customermanageremail;
         AV55Index = 1;
         AV56GXV11 = 1;
         while ( AV56GXV11 <= AV17CustomerManagerSDTs.Count )
         {
            AV35ManagerSDTItem = ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV56GXV11));
            if ( StringUtil.StrCmp(AV35ManagerSDTItem.gxTpr_Customermanageremail, AV30ManagerEmail) == 0 )
            {
               if (true) break;
            }
            else
            {
               AV55Index = (short)(AV55Index+1);
            }
            AV56GXV11 = (int)(AV56GXV11+1);
         }
         if ( AV55Index <= AV17CustomerManagerSDTs.Count )
         {
            AV17CustomerManagerSDTs.RemoveItem(AV55Index);
            gx_BV49 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17CustomerManagerSDTs", AV17CustomerManagerSDTs);
         nGXsfl_49_bak_idx = nGXsfl_49_idx;
         gxgrGrids_refresh( subGrids_Rows, AV28HasValidationErrors, sPrefix) ;
         nGXsfl_49_idx = nGXsfl_49_bak_idx;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
      }

      protected void S152( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV11CustomerManagerGivenName = "";
         AssignAttri(sPrefix, false, "AV11CustomerManagerGivenName", AV11CustomerManagerGivenName);
         AV14CustomerManagerLastName = "";
         AssignAttri(sPrefix, false, "AV14CustomerManagerLastName", AV14CustomerManagerLastName);
         AV13CustomerManagerInitials = "";
         AssignAttri(sPrefix, false, "AV13CustomerManagerInitials", AV13CustomerManagerInitials);
         AV10CustomerManagerGender = "";
         AssignAttri(sPrefix, false, "AV10CustomerManagerGender", AV10CustomerManagerGender);
         AV8CustomerManagerEmail = "";
         AssignAttri(sPrefix, false, "AV8CustomerManagerEmail", AV8CustomerManagerEmail);
         AV15CustomerManagerPhone = "";
         AssignAttri(sPrefix, false, "AV15CustomerManagerPhone", AV15CustomerManagerPhone);
         AV9CustomerManagerGAMGUID = "";
         AssignAttri(sPrefix, false, "AV9CustomerManagerGAMGUID", AV9CustomerManagerGAMGUID);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV39WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV39WebSessionKey", AV39WebSessionKey);
         AV37PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV37PreviousStep", AV37PreviousStep);
         AV20GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV20GoingBack", AV20GoingBack);
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
         PA2F2( ) ;
         WS2F2( ) ;
         WE2F2( ) ;
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
         sCtrlAV39WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV37PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV20GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2F2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createcustomerstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2F2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV39WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV39WebSessionKey", AV39WebSessionKey);
            AV37PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV37PreviousStep", AV37PreviousStep);
            AV20GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV20GoingBack", AV20GoingBack);
         }
         wcpOAV39WebSessionKey = cgiGet( sPrefix+"wcpOAV39WebSessionKey");
         wcpOAV37PreviousStep = cgiGet( sPrefix+"wcpOAV37PreviousStep");
         wcpOAV20GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV20GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV39WebSessionKey, wcpOAV39WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV37PreviousStep, wcpOAV37PreviousStep) != 0 ) || ( AV20GoingBack != wcpOAV20GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV39WebSessionKey = AV39WebSessionKey;
         wcpOAV37PreviousStep = AV37PreviousStep;
         wcpOAV20GoingBack = AV20GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV39WebSessionKey = cgiGet( sPrefix+"AV39WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV39WebSessionKey) > 0 )
         {
            AV39WebSessionKey = cgiGet( sCtrlAV39WebSessionKey);
            AssignAttri(sPrefix, false, "AV39WebSessionKey", AV39WebSessionKey);
         }
         else
         {
            AV39WebSessionKey = cgiGet( sPrefix+"AV39WebSessionKey_PARM");
         }
         sCtrlAV37PreviousStep = cgiGet( sPrefix+"AV37PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV37PreviousStep) > 0 )
         {
            AV37PreviousStep = cgiGet( sCtrlAV37PreviousStep);
            AssignAttri(sPrefix, false, "AV37PreviousStep", AV37PreviousStep);
         }
         else
         {
            AV37PreviousStep = cgiGet( sPrefix+"AV37PreviousStep_PARM");
         }
         sCtrlAV20GoingBack = cgiGet( sPrefix+"AV20GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV20GoingBack) > 0 )
         {
            AV20GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV20GoingBack));
            AssignAttri(sPrefix, false, "AV20GoingBack", AV20GoingBack);
         }
         else
         {
            AV20GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV20GoingBack_PARM"));
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
         PA2F2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2F2( ) ;
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
         WS2F2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV39WebSessionKey_PARM", AV39WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV39WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV39WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV39WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37PreviousStep_PARM", AV37PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV37PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20GoingBack_PARM", StringUtil.BoolToStr( AV20GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20GoingBack_CTRL", StringUtil.RTrim( sCtrlAV20GoingBack));
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
         WE2F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912629499", true, true);
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
         context.AddJavascriptSource("createcustomerstep2.js", "?2024912629499", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_492( )
      {
         edtavCustomermanagersdts__customermanagergivenname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGIVENNAME_"+sGXsfl_49_idx;
         edtavCustomermanagersdts__customermanagerlastname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERLASTNAME_"+sGXsfl_49_idx;
         edtavCustomermanagersdt_customermanagerinitials_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERINITIALS_"+sGXsfl_49_idx;
         edtavCustomermanagersdts__customermanageremail_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGEREMAIL_"+sGXsfl_49_idx;
         edtavCustomermanagersdts__customermanagerphone_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERPHONE_"+sGXsfl_49_idx;
         cmbavCustomermanagersdts__customermanagergender_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGENDER_"+sGXsfl_49_idx;
         edtavCustomermanagersdt_customermanagergamguid_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERGAMGUID_"+sGXsfl_49_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_49_idx;
      }

      protected void SubsflControlProps_fel_492( )
      {
         edtavCustomermanagersdts__customermanagergivenname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGIVENNAME_"+sGXsfl_49_fel_idx;
         edtavCustomermanagersdts__customermanagerlastname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERLASTNAME_"+sGXsfl_49_fel_idx;
         edtavCustomermanagersdt_customermanagerinitials_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERINITIALS_"+sGXsfl_49_fel_idx;
         edtavCustomermanagersdts__customermanageremail_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGEREMAIL_"+sGXsfl_49_fel_idx;
         edtavCustomermanagersdts__customermanagerphone_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERPHONE_"+sGXsfl_49_fel_idx;
         cmbavCustomermanagersdts__customermanagergender_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGENDER_"+sGXsfl_49_fel_idx;
         edtavCustomermanagersdt_customermanagergamguid_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERGAMGUID_"+sGXsfl_49_fel_idx;
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_49_fel_idx;
      }

      protected void sendrow_492( )
      {
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         WB2F0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_49_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_49_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_49_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdts__customermanagergivenname_Internalname,((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdts__customermanagergivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCustomermanagersdts__customermanagergivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdts__customermanagerlastname_Internalname,((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagerlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdts__customermanagerlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCustomermanagersdts__customermanagerlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdt_customermanagerinitials_Internalname,StringUtil.RTrim( AV16CustomerManagerSDT.gxTpr_Customermanagerinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdt_customermanagerinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavCustomermanagersdt_customermanagerinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdts__customermanageremail_Internalname,((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanageremail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdts__customermanageremail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCustomermanagersdts__customermanageremail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdts__customermanagerphone_Internalname,StringUtil.RTrim( ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagerphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdts__customermanagerphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCustomermanagersdts__customermanagerphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            if ( ( cmbavCustomermanagersdts__customermanagergender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGENDER_" + sGXsfl_49_idx;
               cmbavCustomermanagersdts__customermanagergender.Name = GXCCtl;
               cmbavCustomermanagersdts__customermanagergender.WebTags = "";
               cmbavCustomermanagersdts__customermanagergender.addItem("Man", "Man", 0);
               cmbavCustomermanagersdts__customermanagergender.addItem("Woman", "Woman", 0);
               cmbavCustomermanagersdts__customermanagergender.addItem("Other", "Other", 0);
               if ( cmbavCustomermanagersdts__customermanagergender.ItemCount > 0 )
               {
                  if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender)) )
                  {
                     ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender = cmbavCustomermanagersdts__customermanagergender.getValidValue(((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender);
                  }
               }
            }
            /* ComboBox */
            GridsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavCustomermanagersdts__customermanagergender,(string)cmbavCustomermanagersdts__customermanagergender_Internalname,StringUtil.RTrim( ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender),(short)1,(string)cmbavCustomermanagersdts__customermanagergender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavCustomermanagersdts__customermanagergender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"",(bool)true,(short)0});
            cmbavCustomermanagersdts__customermanagergender.CurrentValue = StringUtil.RTrim( ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender);
            AssignProp(sPrefix, false, cmbavCustomermanagersdts__customermanagergender_Internalname, "Values", (string)(cmbavCustomermanagersdts__customermanagergender.ToJavascriptSource()), !bGXsfl_49_Refreshing);
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCustomermanagersdt_customermanagergamguid_Internalname,AV16CustomerManagerSDT.gxTpr_Customermanagergamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCustomermanagersdt_customermanagergamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavCustomermanagersdt_customermanagergamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleterecord_Internalname,StringUtil.RTrim( AV41DeleteRecord),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETERECORD.CLICK."+sGXsfl_49_idx+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDeleterecord_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleterecord_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2F2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_49_idx = ((subGrids_Islastpage==1)&&(nGXsfl_49_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         /* End function sendrow_492 */
      }

      protected void init_web_controls( )
      {
         cmbavCustomermanagergender.Name = "vCUSTOMERMANAGERGENDER";
         cmbavCustomermanagergender.WebTags = "";
         cmbavCustomermanagergender.addItem("Man", "Man", 0);
         cmbavCustomermanagergender.addItem("Woman", "Woman", 0);
         cmbavCustomermanagergender.addItem("Other", "Other", 0);
         if ( cmbavCustomermanagergender.ItemCount > 0 )
         {
         }
         GXCCtl = "CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGENDER_" + sGXsfl_49_idx;
         cmbavCustomermanagersdts__customermanagergender.Name = GXCCtl;
         cmbavCustomermanagersdts__customermanagergender.WebTags = "";
         cmbavCustomermanagersdts__customermanagergender.addItem("Man", "Man", 0);
         cmbavCustomermanagersdts__customermanagergender.addItem("Woman", "Woman", 0);
         cmbavCustomermanagersdts__customermanagergender.addItem("Other", "Other", 0);
         if ( cmbavCustomermanagersdts__customermanagergender.ItemCount > 0 )
         {
            if ( ( AV44GXV1 > 0 ) && ( AV17CustomerManagerSDTs.Count >= AV44GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtCustomerManagerSDT)AV17CustomerManagerSDTs.Item(AV44GXV1)).gxTpr_Customermanagergender)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl49( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"49\">") ;
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
            context.SendWebValue( "Given Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Initials") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Gender") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "GAMGUID") ;
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
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdts__customermanagergivenname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdts__customermanagerlastname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV16CustomerManagerSDT.gxTpr_Customermanagerinitials)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdt_customermanagerinitials_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdts__customermanageremail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdts__customermanagerphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavCustomermanagersdts__customermanagergender.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV16CustomerManagerSDT.gxTpr_Customermanagergamguid));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCustomermanagersdt_customermanagergamguid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41DeleteRecord)));
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
         edtavCustomermanagergivenname_Internalname = sPrefix+"vCUSTOMERMANAGERGIVENNAME";
         edtavCustomermanagerlastname_Internalname = sPrefix+"vCUSTOMERMANAGERLASTNAME";
         edtavCustomermanageremail_Internalname = sPrefix+"vCUSTOMERMANAGEREMAIL";
         edtavCustomermanagerphone_Internalname = sPrefix+"vCUSTOMERMANAGERPHONE";
         cmbavCustomermanagergender_Internalname = sPrefix+"vCUSTOMERMANAGERGENDER";
         bttBtnsave_Internalname = sPrefix+"BTNSAVE";
         divActionbtntable_Internalname = sPrefix+"ACTIONBTNTABLE";
         edtavCustomermanagersdts__customermanagergivenname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGIVENNAME";
         edtavCustomermanagersdts__customermanagerlastname_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERLASTNAME";
         edtavCustomermanagersdt_customermanagerinitials_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERINITIALS";
         edtavCustomermanagersdts__customermanageremail_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGEREMAIL";
         edtavCustomermanagersdts__customermanagerphone_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERPHONE";
         cmbavCustomermanagersdts__customermanagergender_Internalname = sPrefix+"CUSTOMERMANAGERSDTS__CUSTOMERMANAGERGENDER";
         edtavCustomermanagersdt_customermanagergamguid_Internalname = sPrefix+"CUSTOMERMANAGERSDT_CUSTOMERMANAGERGAMGUID";
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnfinish_Internalname = sPrefix+"BTNFINISH";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCustomermanagerid_Internalname = sPrefix+"vCUSTOMERMANAGERID";
         edtavCustomermanagerinitials_Internalname = sPrefix+"vCUSTOMERMANAGERINITIALS";
         edtavCustomermanagergamguid_Internalname = sPrefix+"vCUSTOMERMANAGERGAMGUID";
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
         edtavCustomermanagersdt_customermanagergamguid_Jsonclick = "";
         edtavCustomermanagersdt_customermanagergamguid_Enabled = 0;
         cmbavCustomermanagersdts__customermanagergender_Jsonclick = "";
         cmbavCustomermanagersdts__customermanagergender.Enabled = 0;
         edtavCustomermanagersdts__customermanagerphone_Jsonclick = "";
         edtavCustomermanagersdts__customermanagerphone_Enabled = 0;
         edtavCustomermanagersdts__customermanageremail_Jsonclick = "";
         edtavCustomermanagersdts__customermanageremail_Enabled = 0;
         edtavCustomermanagersdt_customermanagerinitials_Jsonclick = "";
         edtavCustomermanagersdt_customermanagerinitials_Enabled = 0;
         edtavCustomermanagersdts__customermanagerlastname_Jsonclick = "";
         edtavCustomermanagersdts__customermanagerlastname_Enabled = 0;
         edtavCustomermanagersdts__customermanagergivenname_Jsonclick = "";
         edtavCustomermanagersdts__customermanagergivenname_Enabled = 0;
         subGrids_Class = "GridWithPaginationBar WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavCustomermanagergamguid_Jsonclick = "";
         edtavCustomermanagergamguid_Visible = 1;
         edtavCustomermanagerinitials_Jsonclick = "";
         edtavCustomermanagerinitials_Visible = 1;
         edtavCustomermanagerid_Jsonclick = "";
         edtavCustomermanagerid_Visible = 1;
         cmbavCustomermanagergender_Jsonclick = "";
         cmbavCustomermanagergender.Enabled = 1;
         edtavCustomermanagerphone_Jsonclick = "";
         edtavCustomermanagerphone_Enabled = 1;
         edtavCustomermanageremail_Jsonclick = "";
         edtavCustomermanageremail_Enabled = 1;
         edtavCustomermanagerlastname_Jsonclick = "";
         edtavCustomermanagerlastname_Enabled = 1;
         edtavCustomermanagergivenname_Jsonclick = "";
         edtavCustomermanagergivenname_Enabled = 1;
         Gridspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridspaginationbar_Emptygridcaption = "No manager records added.";
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
         edtavCustomermanagersdt_customermanagergamguid_Enabled = -1;
         cmbavCustomermanagersdts__customermanagergender.Enabled = -1;
         edtavCustomermanagersdts__customermanagerphone_Enabled = -1;
         edtavCustomermanagersdts__customermanageremail_Enabled = -1;
         edtavCustomermanagersdt_customermanagerinitials_Enabled = -1;
         edtavCustomermanagersdts__customermanagerlastname_Enabled = -1;
         edtavCustomermanagersdts__customermanagergivenname_Enabled = -1;
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

      public void Validv_Customermanagerlastname( )
      {
         GXt_char1 = AV13CustomerManagerInitials;
         new getnameinitials(context ).execute(  AV11CustomerManagerGivenName,  AV14CustomerManagerLastName, out  GXt_char1) ;
         AV13CustomerManagerInitials = GXt_char1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "AV13CustomerManagerInitials", StringUtil.RTrim( AV13CustomerManagerInitials));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV25GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E182F2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV41DeleteRecord","fld":"vDELETERECORD"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112F2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122F2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("ENTER","""{"handler":"E192F2","iparms":[{"av":"AV43CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV39WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV12CustomerManagerId","fld":"vCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV6Customer","fld":"vCUSTOMER"},{"av":"AV40WizardData","fld":"vWIZARDDATA"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV43CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV40WizardData","fld":"vWIZARDDATA"},{"av":"AV6Customer","fld":"vCUSTOMER"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E132F2","iparms":[{"av":"AV39WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12CustomerManagerId","fld":"vCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV40WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOFINISH'","""{"handler":"E142F2","iparms":[{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV39WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12CustomerManagerId","fld":"vCUSTOMERMANAGERID","pic":"ZZZ9"},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"},{"av":"AV6Customer","fld":"vCUSTOMER"},{"av":"AV40WizardData","fld":"vWIZARDDATA"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOFINISH'",""","oparms":[{"av":"AV40WizardData","fld":"vWIZARDDATA"},{"av":"AV6Customer","fld":"vCUSTOMER"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"}]}""");
         setEventMetadata("'DOSAVE'","""{"handler":"E152F2","iparms":[{"av":"AV43CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"A10CustomerManagerEmail","fld":"CUSTOMERMANAGEREMAIL"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOSAVE'",""","oparms":[{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"AV43CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"},{"av":"cmbavCustomermanagergender"},{"av":"AV10CustomerManagerGender","fld":"vCUSTOMERMANAGERGENDER"},{"av":"AV8CustomerManagerEmail","fld":"vCUSTOMERMANAGEREMAIL"},{"av":"AV15CustomerManagerPhone","fld":"vCUSTOMERMANAGERPHONE"},{"av":"AV9CustomerManagerGAMGUID","fld":"vCUSTOMERMANAGERGAMGUID"}]}""");
         setEventMetadata("VDELETERECORD.CLICK","""{"handler":"E202F2","iparms":[{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV28HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VDELETERECORD.CLICK",""","oparms":[{"av":"AV17CustomerManagerSDTs","fld":"vCUSTOMERMANAGERSDTS","grid":49},{"av":"nGXsfl_49_idx","ctrl":"GRID","prop":"GridCurrRow","grid":49},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_49","ctrl":"GRIDS","prop":"GridRC","grid":49}]}""");
         setEventMetadata("VALIDV_CUSTOMERMANAGERGIVENNAME","""{"handler":"Validv_Customermanagergivenname","iparms":[]}""");
         setEventMetadata("VALIDV_CUSTOMERMANAGERLASTNAME","""{"handler":"Validv_Customermanagerlastname","iparms":[{"av":"AV11CustomerManagerGivenName","fld":"vCUSTOMERMANAGERGIVENNAME"},{"av":"AV14CustomerManagerLastName","fld":"vCUSTOMERMANAGERLASTNAME"},{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"}]""");
         setEventMetadata("VALIDV_CUSTOMERMANAGERLASTNAME",""","oparms":[{"av":"AV13CustomerManagerInitials","fld":"vCUSTOMERMANAGERINITIALS"}]}""");
         setEventMetadata("VALIDV_CUSTOMERMANAGEREMAIL","""{"handler":"Validv_Customermanageremail","iparms":[]}""");
         setEventMetadata("VALIDV_CUSTOMERMANAGERGENDER","""{"handler":"Validv_Customermanagergender","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
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
         wcpOAV39WebSessionKey = "";
         wcpOAV37PreviousStep = "";
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17CustomerManagerSDTs = new GXBaseCollection<SdtCustomerManagerSDT>( context, "CustomerManagerSDT", "");
         AV16CustomerManagerSDT = new SdtCustomerManagerSDT(context);
         AV24GridsAppliedFilters = "";
         AV6Customer = new SdtCustomer(context);
         AV40WizardData = new SdtCreateCustomerData(context);
         A10CustomerManagerEmail = "";
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV11CustomerManagerGivenName = "";
         AV14CustomerManagerLastName = "";
         AV8CustomerManagerEmail = "";
         AV15CustomerManagerPhone = "";
         AV10CustomerManagerGender = "";
         bttBtnsave_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridspaginationbar = new GXUserControl();
         bttBtnwizardprevious_Jsonclick = "";
         bttBtnfinish_Jsonclick = "";
         AV13CustomerManagerInitials = "";
         AV9CustomerManagerGAMGUID = "";
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41DeleteRecord = "";
         GridsRow = new GXWebRow();
         AV38WebSession = context.GetSession();
         H002F2_A1CustomerId = new short[1] ;
         H002F2_A15CustomerManagerId = new short[1] ;
         H002F2_A10CustomerManagerEmail = new string[] {""} ;
         AV18CustomerManagerSDTsItem = new SdtCustomerManagerSDT(context);
         AV35ManagerSDTItem = new SdtCustomerManagerSDT(context);
         AV7CustomerManager = new SdtCustomer_Manager(context);
         AV19ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV30ManagerEmail = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV39WebSessionKey = "";
         sCtrlAV37PreviousStep = "";
         sCtrlAV20GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridsColumn = new GXWebColumn();
         GXt_char1 = "";
         ZV13CustomerManagerInitials = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createcustomerstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createcustomerstep2__default(),
            new Object[][] {
                new Object[] {
               H002F2_A1CustomerId, H002F2_A15CustomerManagerId, H002F2_A10CustomerManagerEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavCustomermanagersdts__customermanagergivenname_Enabled = 0;
         edtavCustomermanagersdts__customermanagerlastname_Enabled = 0;
         edtavCustomermanagersdt_customermanagerinitials_Enabled = 0;
         edtavCustomermanagersdts__customermanageremail_Enabled = 0;
         edtavCustomermanagersdts__customermanagerphone_Enabled = 0;
         cmbavCustomermanagersdts__customermanagergender.Enabled = 0;
         edtavCustomermanagersdt_customermanagergamguid_Enabled = 0;
         edtavDeleterecord_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV12CustomerManagerId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV52GXLvl131 ;
      private short AV55Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_49 ;
      private int subGrids_Rows ;
      private int nGXsfl_49_idx=1 ;
      private int edtavCustomermanagersdts__customermanagergivenname_Enabled ;
      private int edtavCustomermanagersdts__customermanagerlastname_Enabled ;
      private int edtavCustomermanagersdt_customermanagerinitials_Enabled ;
      private int edtavCustomermanagersdts__customermanageremail_Enabled ;
      private int edtavCustomermanagersdts__customermanagerphone_Enabled ;
      private int edtavCustomermanagersdt_customermanagergamguid_Enabled ;
      private int edtavDeleterecord_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int edtavCustomermanagergivenname_Enabled ;
      private int edtavCustomermanagerlastname_Enabled ;
      private int edtavCustomermanageremail_Enabled ;
      private int edtavCustomermanagerphone_Enabled ;
      private int AV44GXV1 ;
      private int edtavCustomermanagerid_Visible ;
      private int edtavCustomermanagerinitials_Visible ;
      private int edtavCustomermanagergamguid_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_49_fel_idx=1 ;
      private int AV36PageToGo ;
      private int nGXsfl_49_bak_idx=1 ;
      private int AV53GXV9 ;
      private int AV54GXV10 ;
      private int AV56GXV11 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long AV25GridsCurrentPage ;
      private long AV26GridsPageCount ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Gridspaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_49_idx="0001" ;
      private string edtavCustomermanagersdts__customermanagergivenname_Internalname ;
      private string edtavCustomermanagersdts__customermanagerlastname_Internalname ;
      private string edtavCustomermanagersdt_customermanagerinitials_Internalname ;
      private string edtavCustomermanagersdts__customermanageremail_Internalname ;
      private string edtavCustomermanagersdts__customermanagerphone_Internalname ;
      private string cmbavCustomermanagersdts__customermanagergender_Internalname ;
      private string edtavCustomermanagersdt_customermanagergamguid_Internalname ;
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
      private string edtavCustomermanagergivenname_Internalname ;
      private string TempTags ;
      private string edtavCustomermanagergivenname_Jsonclick ;
      private string edtavCustomermanagerlastname_Internalname ;
      private string edtavCustomermanagerlastname_Jsonclick ;
      private string edtavCustomermanageremail_Internalname ;
      private string edtavCustomermanageremail_Jsonclick ;
      private string edtavCustomermanagerphone_Internalname ;
      private string AV15CustomerManagerPhone ;
      private string edtavCustomermanagerphone_Jsonclick ;
      private string cmbavCustomermanagergender_Internalname ;
      private string AV10CustomerManagerGender ;
      private string cmbavCustomermanagergender_Jsonclick ;
      private string divActionbtntable_Internalname ;
      private string bttBtnsave_Internalname ;
      private string bttBtnsave_Jsonclick ;
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
      private string edtavCustomermanagerid_Internalname ;
      private string edtavCustomermanagerid_Jsonclick ;
      private string edtavCustomermanagerinitials_Internalname ;
      private string AV13CustomerManagerInitials ;
      private string edtavCustomermanagerinitials_Jsonclick ;
      private string edtavCustomermanagergamguid_Internalname ;
      private string edtavCustomermanagergamguid_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV41DeleteRecord ;
      private string sGXsfl_49_fel_idx="0001" ;
      private string sCtrlAV39WebSessionKey ;
      private string sCtrlAV37PreviousStep ;
      private string sCtrlAV20GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavCustomermanagersdts__customermanagergivenname_Jsonclick ;
      private string edtavCustomermanagersdts__customermanagerlastname_Jsonclick ;
      private string edtavCustomermanagersdt_customermanagerinitials_Jsonclick ;
      private string edtavCustomermanagersdts__customermanageremail_Jsonclick ;
      private string edtavCustomermanagersdts__customermanagerphone_Jsonclick ;
      private string GXCCtl ;
      private string cmbavCustomermanagersdts__customermanagergender_Jsonclick ;
      private string edtavCustomermanagersdt_customermanagergamguid_Jsonclick ;
      private string edtavDeleterecord_Jsonclick ;
      private string subGrids_Header ;
      private string GXt_char1 ;
      private string ZV13CustomerManagerInitials ;
      private bool AV20GoingBack ;
      private bool wcpOAV20GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV28HasValidationErrors ;
      private bool bGXsfl_49_Refreshing=false ;
      private bool AV43CheckRequiredFieldsResult ;
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
      private bool AV42isAlreadyAdded ;
      private bool gx_BV49 ;
      private string AV39WebSessionKey ;
      private string AV37PreviousStep ;
      private string wcpOAV39WebSessionKey ;
      private string wcpOAV37PreviousStep ;
      private string AV24GridsAppliedFilters ;
      private string A10CustomerManagerEmail ;
      private string AV11CustomerManagerGivenName ;
      private string AV14CustomerManagerLastName ;
      private string AV8CustomerManagerEmail ;
      private string AV9CustomerManagerGAMGUID ;
      private string AV30ManagerEmail ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV38WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCustomermanagergender ;
      private GXCombobox cmbavCustomermanagersdts__customermanagergender ;
      private GXBaseCollection<SdtCustomerManagerSDT> AV17CustomerManagerSDTs ;
      private SdtCustomerManagerSDT AV16CustomerManagerSDT ;
      private SdtCustomer AV6Customer ;
      private SdtCreateCustomerData AV40WizardData ;
      private IDataStoreProvider pr_default ;
      private short[] H002F2_A1CustomerId ;
      private short[] H002F2_A15CustomerManagerId ;
      private string[] H002F2_A10CustomerManagerEmail ;
      private SdtCustomerManagerSDT AV18CustomerManagerSDTsItem ;
      private SdtCustomerManagerSDT AV35ManagerSDTItem ;
      private SdtCustomer_Manager AV7CustomerManager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19ErrorMessages ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class createcustomerstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createcustomerstep2__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH002F2;
        prmH002F2 = new Object[] {
        new ParDef("AV8CustomerManagerEmail",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002F2", "SELECT CustomerId, CustomerManagerId, CustomerManagerEmail FROM CustomerManager WHERE CustomerManagerEmail = ( :AV8CustomerManagerEmail) ORDER BY CustomerId, CustomerManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002F2,1, GxCacheFrequency.OFF ,true,true )
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
              return;
     }
  }

}

}
