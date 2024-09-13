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
   public class createresidentstep4 : GXWebComponent
   {
      public createresidentstep4( )
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

      public createresidentstep4( IGxContext context )
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
         this.AV29WebSessionKey = aP0_WebSessionKey;
         this.AV20PreviousStep = aP1_PreviousStep;
         this.AV12GoingBack = aP2_GoingBack;
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
         dynavProductserviceid = new GXCombobox();
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
                  AV29WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV29WebSessionKey", AV29WebSessionKey);
                  AV20PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
                  AV12GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV29WebSessionKey,(string)AV20PreviousStep,(bool)AV12GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPRODUCTSERVICEID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvPRODUCTSERVICEID2X2( ) ;
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
         nRC_GXsfl_30 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_30"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_30_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_30_idx = GetPar( "sGXsfl_30_idx");
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
         dynavProductserviceid.FromJSonString( GetNextPar( ));
         AV22ProductServiceId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceId"), "."), 18, MidpointRounding.ToEven));
         AV16HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
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
            PA2X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavDeleterecord_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeleterecord_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleterecord_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productserviceid_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productserviceid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productservicename_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productservicename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productservicename_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productservicedescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productservicedescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productservicedescription_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productservicequantity_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productservicequantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productservicequantity_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productservicetypename_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productservicetypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productservicetypename_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               edtavResidentproductservicesdts__productservicetypeid_Enabled = 0;
               AssignProp(sPrefix, false, edtavResidentproductservicesdts__productservicetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResidentproductservicesdts__productservicetypeid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
               GXVvPRODUCTSERVICEID_html2X2( ) ;
               WS2X2( ) ;
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
            context.SendWebValue( context.GetMessage( "Create Resident Step4", "")) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createresidentstep4.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV29WebSessionKey)),UrlEncode(StringUtil.RTrim(AV20PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV12GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV16HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV16HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Residentproductservicesdts", AV26ResidentProductServiceSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Residentproductservicesdts", AV26ResidentProductServiceSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_30", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_30), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14GridsCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15GridsPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSAPPLIEDFILTERS", AV13GridsAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29WebSessionKey", wcpOAV29WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20PreviousStep", wcpOAV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV12GoingBack", wcpOAV12GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV16HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV16HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV29WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTPRODUCTSERVICESDTS", AV26ResidentProductServiceSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTPRODUCTSERVICESDTS", AV26ResidentProductServiceSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV30WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV30WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENT", AV23Resident);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENT", AV23Resident);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADDEDPRODUCTSSERVICES", AV8AddedProductsServices);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADDEDPRODUCTSSERVICES", AV8AddedProductsServices);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICENAME", A74ProductServiceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEDESCRIPTION", A75ProductServiceDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICETYPENAME", A72ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEPICTURE", A77ProductServicePicture);
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTSERVICEPICTURE_GXI", A40000ProductServicePicture_GXI);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV12GoingBack);
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

      protected void RenderHtmlCloseForm2X2( )
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
         return "CreateResidentStep4" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Create Resident Step4", "") ;
      }

      protected void WB2X0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createresidentstep4.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavProductserviceid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProductserviceid_Internalname, context.GetMessage( "Product / Service", ""), " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProductserviceid, dynavProductserviceid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0)), 1, dynavProductserviceid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProductserviceid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_CreateResidentStep4.htm");
            dynavProductserviceid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0));
            AssignProp(sPrefix, false, dynavProductserviceid_Internalname, "Values", (string)(dynavProductserviceid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActionbtntable_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddproductservice_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtnaddproductservice_Jsonclick, 5, context.GetMessage( "Add", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADDPRODUCTSERVICE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep4.htm");
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
            StartGridControl30( ) ;
         }
         if ( wbEnd == 30 )
         {
            wbEnd = 0;
            nRC_GXsfl_30 = (int)(nGXsfl_30_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV34GXV1 = nGXsfl_30_idx;
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
            ucGridspaginationbar.SetProperty("CurrentPage", AV14GridsCurrentPage);
            ucGridspaginationbar.SetProperty("PageCount", AV15GridsPageCount);
            ucGridspaginationbar.SetProperty("AppliedFilters", AV13GridsAppliedFilters);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 5, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep4.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinish_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", context.GetMessage( "Finish", ""), bttBtnfinish_Jsonclick, 5, context.GetMessage( "Finish", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFINISH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep4.htm");
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
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 30 )
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
                  AV34GXV1 = nGXsfl_30_idx;
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

      protected void START2X2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Create Resident Step4", ""), 0) ;
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
               STRUP2X0( ) ;
            }
         }
      }

      protected void WS2X2( )
      {
         START2X2( ) ;
         EVT2X2( ) ;
      }

      protected void EVT2X2( )
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
                                 STRUP2X0( ) ;
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
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changepage */
                                    E112X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridspaginationbar.Changerowsperpage */
                                    E122X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E132X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFINISH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFinish' */
                                    E142X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDPRODUCTSERVICE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAddProductService' */
                                    E152X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDeleterecord_Internalname;
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
                                 STRUP2X0( ) ;
                              }
                              nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
                              SubsflControlProps_302( ) ;
                              AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) && ( AV34GXV1 > 0 ) )
                              {
                                 AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
                                 AV31DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
                                 AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV31DeleteRecord);
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
                                          GX_FocusControl = edtavDeleterecord_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162X2 ();
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
                                          GX_FocusControl = edtavDeleterecord_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172X2 ();
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
                                          GX_FocusControl = edtavDeleterecord_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E182X2 ();
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
                                                E192X2 ();
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
                                          GX_FocusControl = edtavDeleterecord_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E202X2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2X0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDeleterecord_Internalname;
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

      protected void WE2X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2X2( ) ;
            }
         }
      }

      protected void PA2X2( )
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
               GX_FocusControl = dynavProductserviceid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvPRODUCTSERVICEID2X2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPRODUCTSERVICEID_data2X2( ) ;
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

      protected void GXVvPRODUCTSERVICEID_html2X2( )
      {
         short gxdynajaxvalue;
         GXDLVvPRODUCTSERVICEID_data2X2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProductserviceid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavProductserviceid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPRODUCTSERVICEID_data2X2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Option", ""));
         /* Using cursor H002X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002X2_A73ProductServiceId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002X2_A74ProductServiceName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_302( ) ;
         while ( nGXsfl_30_idx <= nRC_GXsfl_30 )
         {
            sendrow_302( ) ;
            nGXsfl_30_idx = ((subGrids_Islastpage==1)&&(nGXsfl_30_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        short AV22ProductServiceId ,
                                        bool AV16HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2X2( ) ;
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
            GXVvPRODUCTSERVICEID_html2X2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavProductserviceid.ItemCount > 0 )
         {
            AV22ProductServiceId = (short)(Math.Round(NumberUtil.Val( dynavProductserviceid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22ProductServiceId", StringUtil.LTrimStr( (decimal)(AV22ProductServiceId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProductserviceid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0));
            AssignProp(sPrefix, false, dynavProductserviceid_Internalname, "Values", dynavProductserviceid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavDeleterecord_Enabled = 0;
         edtavResidentproductservicesdts__productserviceid_Enabled = 0;
         edtavResidentproductservicesdts__productservicename_Enabled = 0;
         edtavResidentproductservicesdts__productservicedescription_Enabled = 0;
         edtavResidentproductservicesdts__productservicequantity_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypename_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypeid_Enabled = 0;
      }

      protected void RF2X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 30;
         /* Execute user event: Refresh */
         E172X2 ();
         nGXsfl_30_idx = 1;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         bGXsfl_30_Refreshing = true;
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
            SubsflControlProps_302( ) ;
            /* Execute user event: Grids.Load */
            E182X2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_30_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E182X2 ();
            }
            wbEnd = 30;
            WB2X0( ) ;
         }
         bGXsfl_30_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2X2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV16HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV16HasValidationErrors, context));
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
         return AV26ResidentProductServiceSDTs.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavDeleterecord_Enabled = 0;
         edtavResidentproductservicesdts__productserviceid_Enabled = 0;
         edtavResidentproductservicesdts__productservicename_Enabled = 0;
         edtavResidentproductservicesdts__productservicedescription_Enabled = 0;
         edtavResidentproductservicesdts__productservicequantity_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypename_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypeid_Enabled = 0;
         GXVvPRODUCTSERVICEID_html2X2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Residentproductservicesdts"), AV26ResidentProductServiceSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTPRODUCTSERVICESDTS"), AV26ResidentProductServiceSDTs);
            /* Read saved values. */
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_30"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV14GridsCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV15GridsPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDSPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV13GridsAppliedFilters = cgiGet( sPrefix+"vGRIDSAPPLIEDFILTERS");
            wcpOAV29WebSessionKey = cgiGet( sPrefix+"wcpOAV29WebSessionKey");
            wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
            wcpOAV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12GoingBack"));
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
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_30"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_30_fel_idx = 0;
            while ( nGXsfl_30_fel_idx < nRC_GXsfl_30 )
            {
               nGXsfl_30_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_30_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_fel_idx+1);
               sGXsfl_30_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_302( ) ;
               AV34GXV1 = (int)(nGXsfl_30_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) && ( AV34GXV1 > 0 ) )
               {
                  AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
                  AV31DeleteRecord = cgiGet( edtavDeleterecord_Internalname);
               }
            }
            if ( nGXsfl_30_fel_idx == 0 )
            {
               nGXsfl_30_idx = 1;
               sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
               SubsflControlProps_302( ) ;
            }
            nGXsfl_30_fel_idx = 1;
            /* Read variables values. */
            dynavProductserviceid.Name = dynavProductserviceid_Internalname;
            dynavProductserviceid.CurrentValue = cgiGet( dynavProductserviceid_Internalname);
            AV22ProductServiceId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavProductserviceid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22ProductServiceId", StringUtil.LTrimStr( (decimal)(AV22ProductServiceId), 4, 0));
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
         E162X2 ();
         if (returnInSub) return;
      }

      protected void E162X2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Gridspaginationbar_Rowsperpageselectedvalue = subGrids_Rows;
         ucGridspaginationbar.SendProperty(context, sPrefix, false, Gridspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridspaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_int1 = AV11CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int1) ;
         AV11CustomerId = GXt_int1;
         GXt_int1 = AV6LocationId;
         new getreceptionistlocationid(context ).execute( out  GXt_int1) ;
         AV6LocationId = GXt_int1;
         if ( (0==AV11CustomerId) )
         {
            AV11CustomerId = 1;
         }
         if ( (0==AV6LocationId) )
         {
            AV6LocationId = 1;
         }
         AV23Resident.gxTpr_Residentbsnnumber = AV30WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber;
         AV23Resident.gxTpr_Residentgivenname = AV30WizardData.gxTpr_Step1.gxTpr_Residentgivenname;
         AV23Resident.gxTpr_Residentlastname = AV30WizardData.gxTpr_Step1.gxTpr_Residentlastname;
         AV23Resident.gxTpr_Residentinitials = AV30WizardData.gxTpr_Step1.gxTpr_Residentinitials;
         AV23Resident.gxTpr_Residentemail = AV30WizardData.gxTpr_Step1.gxTpr_Residentemail;
         AV23Resident.gxTpr_Residentgender = AV30WizardData.gxTpr_Step1.gxTpr_Residentgender;
         AV23Resident.gxTpr_Residentphone = AV30WizardData.gxTpr_Step1.gxTpr_Residentphone;
         AV23Resident.gxTpr_Residenttypeid = AV30WizardData.gxTpr_Step1.gxTpr_Residenttypeid;
         AV23Resident.gxTpr_Residentaddress = AV30WizardData.gxTpr_Step1.gxTpr_Residentaddress;
         AV23Resident.gxTpr_Customerid = AV11CustomerId;
         AV23Resident.gxTpr_Customerlocationid = AV6LocationId;
      }

      protected void E172X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV14GridsCurrentPage = subGrids_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV14GridsCurrentPage", StringUtil.LTrimStr( (decimal)(AV14GridsCurrentPage), 10, 0));
         AV15GridsPageCount = subGrids_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV15GridsPageCount", StringUtil.LTrimStr( (decimal)(AV15GridsPageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      private void E182X2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV26ResidentProductServiceSDTs.Count )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
            AV31DeleteRecord = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDeleterecord_Internalname, AV31DeleteRecord);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 30;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_302( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_30_Refreshing )
            {
               DoAjaxLoad(30, GridsRow);
            }
            AV34GXV1 = (int)(AV34GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112X2( )
      {
         /* Gridspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrids_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV19PageToGo = subGrids_fnc_Currentpage( );
            AV19PageToGo = (int)(AV19PageToGo+1);
            subgrids_gotopage( AV19PageToGo) ;
         }
         else
         {
            AV19PageToGo = (int)(Math.Round(NumberUtil.Val( Gridspaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrids_gotopage( AV19PageToGo) ;
         }
      }

      protected void E122X2( )
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
         E192X2 ();
         if (returnInSub) return;
      }

      protected void E192X2( )
      {
         AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV16HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S132 ();
            if (returnInSub) return;
            AV28WebSession.Remove(AV29WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WizardData", AV30WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23Resident", AV23Resident);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ResidentProductServiceSDTs", AV26ResidentProductServiceSDTs);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8AddedProductsServices", AV8AddedProductsServices);
         dynavProductserviceid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0));
         AssignProp(sPrefix, false, dynavProductserviceid_Internalname, "Values", dynavProductserviceid.ToJavascriptSource(), true);
      }

      protected void E132X2( )
      {
         AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S122 ();
         if (returnInSub) return;
         CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step4")),UrlEncode(StringUtil.RTrim("Step3")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WizardData", AV30WizardData);
      }

      protected void E142X2( )
      {
         AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
         }
         /* 'DoFinish' Routine */
         returnInSub = false;
         if ( AV26ResidentProductServiceSDTs.Count < 1 )
         {
            GX_msglist.addItem(context.GetMessage( "Add at least 1 product/service to the resident", ""));
         }
         else
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30WizardData", AV30WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23Resident", AV23Resident);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ResidentProductServiceSDTs", AV26ResidentProductServiceSDTs);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8AddedProductsServices", AV8AddedProductsServices);
         dynavProductserviceid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0));
         AssignProp(sPrefix, false, dynavProductserviceid_Internalname, "Values", dynavProductserviceid.ToJavascriptSource(), true);
      }

      protected void E152X2( )
      {
         AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
         }
         /* 'DoAddProductService' Routine */
         returnInSub = false;
         /* Using cursor H002X3 */
         pr_default.execute(1, new Object[] {AV22ProductServiceId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A71ProductServiceTypeId = H002X3_A71ProductServiceTypeId[0];
            A73ProductServiceId = H002X3_A73ProductServiceId[0];
            A40000ProductServicePicture_GXI = H002X3_A40000ProductServicePicture_GXI[0];
            A74ProductServiceName = H002X3_A74ProductServiceName[0];
            A75ProductServiceDescription = H002X3_A75ProductServiceDescription[0];
            A72ProductServiceTypeName = H002X3_A72ProductServiceTypeName[0];
            A76ProductServiceQuantity = H002X3_A76ProductServiceQuantity[0];
            A77ProductServicePicture = H002X3_A77ProductServicePicture[0];
            A72ProductServiceTypeName = H002X3_A72ProductServiceTypeName[0];
            if ( (AV8AddedProductsServices.IndexOf(AV22ProductServiceId)>0) )
            {
               GX_msglist.addItem(context.GetMessage( "Product/Service already added", ""));
            }
            else
            {
               AV27ResidentProductServiceSDTsItem = new SdtResidentProductServiceSDT(context);
               AV27ResidentProductServiceSDTsItem.gxTpr_Productserviceid = AV22ProductServiceId;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicename = A74ProductServiceName;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicedescription = A75ProductServiceDescription;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicetypename = A72ProductServiceTypeName;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicequantity = A76ProductServiceQuantity;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicepicture = A77ProductServicePicture;
               AV27ResidentProductServiceSDTsItem.gxTpr_Productservicepicture_gxi = A40000ProductServicePicture_GXI;
               AV26ResidentProductServiceSDTs.Add(AV27ResidentProductServiceSDTsItem, 0);
               gx_BV30 = true;
               AV8AddedProductsServices.Add(AV22ProductServiceId, 0);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Execute user subroutine: 'CLEARFORMVALUES' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ResidentProductServiceSDTs", AV26ResidentProductServiceSDTs);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8AddedProductsServices", AV8AddedProductsServices);
         dynavProductserviceid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProductServiceId), 4, 0));
         AssignProp(sPrefix, false, dynavProductserviceid_Internalname, "Values", dynavProductserviceid.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV30WizardData.FromJSonString(AV28WebSession.Get(AV29WebSessionKey), null);
         AV22ProductServiceId = AV30WizardData.gxTpr_Step4.gxTpr_Productserviceid;
         AssignAttri(sPrefix, false, "AV22ProductServiceId", StringUtil.LTrimStr( (decimal)(AV22ProductServiceId), 4, 0));
         AV26ResidentProductServiceSDTs = AV30WizardData.gxTpr_Step4.gxTpr_Residentproductservicesdts;
         gx_BV30 = true;
      }

      protected void S122( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV30WizardData.FromJSonString(AV28WebSession.Get(AV29WebSessionKey), null);
         AV30WizardData.gxTpr_Step4.gxTpr_Productserviceid = AV22ProductServiceId;
         AV30WizardData.gxTpr_Step4.gxTpr_Residentproductservicesdts = AV26ResidentProductServiceSDTs;
         AV28WebSession.Set(AV29WebSessionKey, AV30WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV43GXV9 = 1;
         while ( AV43GXV9 <= AV30WizardData.gxTpr_Step2.gxTpr_Residentinindividualsdts.Count )
         {
            AV25ResidentIndividual = ((SdtResidentINIndividualSDT)AV30WizardData.gxTpr_Step2.gxTpr_Residentinindividualsdts.Item(AV43GXV9));
            AV18Individual = new SdtResident_INIndividual(context);
            AV18Individual.gxTpr_Residentinindividualbsnnumber = AV25ResidentIndividual.gxTpr_Residentinindividualbsnnumber;
            AV18Individual.gxTpr_Residentinindividualgivenname = AV25ResidentIndividual.gxTpr_Residentinindividualgivenname;
            AV18Individual.gxTpr_Residentinindividuallastname = AV25ResidentIndividual.gxTpr_Residentinindividuallastname;
            AV18Individual.gxTpr_Residentinindividualemail = AV25ResidentIndividual.gxTpr_Residentinindividualemail;
            AV18Individual.gxTpr_Residentinindividualphone = AV25ResidentIndividual.gxTpr_Residentinindividualphone;
            AV18Individual.gxTpr_Residentinindividualgender = AV25ResidentIndividual.gxTpr_Residentinindividualgender;
            AV18Individual.gxTpr_Residentinindividualaddress = AV25ResidentIndividual.gxTpr_Residentinindividualaddress;
            AV23Resident.gxTpr_Inindividual.Add(AV18Individual, 0);
            AV43GXV9 = (int)(AV43GXV9+1);
         }
         AV44GXV10 = 1;
         while ( AV44GXV10 <= AV30WizardData.gxTpr_Step3.gxTpr_Residentincompanysdts.Count )
         {
            AV24ResidentCompany = ((SdtResidentINCompanySDT)AV30WizardData.gxTpr_Step3.gxTpr_Residentincompanysdts.Item(AV44GXV10));
            AV9Company = new SdtResident_INCompany(context);
            AV9Company.gxTpr_Residentincompanykvknumber = AV24ResidentCompany.gxTpr_Residentincompanykvknumber;
            AV9Company.gxTpr_Residentincompanyname = AV24ResidentCompany.gxTpr_Residentincompanyname;
            AV9Company.gxTpr_Residentincompanyemail = AV24ResidentCompany.gxTpr_Residentincompanyemail;
            AV9Company.gxTpr_Residentincompanyphone = AV24ResidentCompany.gxTpr_Residentincompanyphone;
            AV23Resident.gxTpr_Incompany.Add(AV9Company, 0);
            AV44GXV10 = (int)(AV44GXV10+1);
         }
         AV45GXV11 = 1;
         while ( AV45GXV11 <= AV26ResidentProductServiceSDTs.Count )
         {
            AV7ResidentProductService = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV45GXV11));
            AV21ProductService = new SdtResident_ProductService(context);
            AV21ProductService.gxTpr_Productserviceid = AV7ResidentProductService.gxTpr_Productserviceid;
            AV23Resident.gxTpr_Productservice.Add(AV21ProductService, 0);
            AV45GXV11 = (int)(AV45GXV11+1);
         }
         AV23Resident.Save();
         if ( AV23Resident.Success() )
         {
            context.CommitDataStores("createresidentstep4",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S142 ();
            if (returnInSub) return;
            AV30WizardData.gxTpr_Step2.gxTpr_Residentinindividualsdts.Clear();
            AV30WizardData.gxTpr_Step3.gxTpr_Residentincompanysdts.Clear();
            AV30WizardData.gxTpr_Step4.gxTpr_Residentproductservicesdts.Clear();
            AV26ResidentProductServiceSDTs.Clear();
            gx_BV30 = true;
            AV8AddedProductsServices.Clear();
            CallWebObject(formatLink("locationresidents.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.RollbackDataStores("createresidentstep4",pr_default);
            AV5ErrorMessages = AV23Resident.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV5ErrorMessages.Item(1)).gxTpr_Description);
         }
      }

      protected void E202X2( )
      {
         AV34GXV1 = (int)(nGXsfl_30_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV34GXV1 > 0 ) && ( AV26ResidentProductServiceSDTs.Count >= AV34GXV1 ) )
         {
            AV26ResidentProductServiceSDTs.CurrentItem = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1));
         }
         /* Deleterecord_Click Routine */
         returnInSub = false;
         AV32ServiceProductId = ((SdtResidentProductServiceSDT)(AV26ResidentProductServiceSDTs.CurrentItem)).gxTpr_Productserviceid;
         AV33Index = 1;
         AV46GXV12 = 1;
         while ( AV46GXV12 <= AV26ResidentProductServiceSDTs.Count )
         {
            AV7ResidentProductService = ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV46GXV12));
            if ( AV7ResidentProductService.gxTpr_Productserviceid == AV32ServiceProductId )
            {
               if (true) break;
            }
            else
            {
               AV33Index = (short)(AV33Index+1);
            }
            AV46GXV12 = (int)(AV46GXV12+1);
         }
         if ( AV33Index <= AV26ResidentProductServiceSDTs.Count )
         {
            AV26ResidentProductServiceSDTs.RemoveItem(AV33Index);
            gx_BV30 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ResidentProductServiceSDTs", AV26ResidentProductServiceSDTs);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrids_refresh( subGrids_Rows, AV22ProductServiceId, AV16HasValidationErrors, sPrefix) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
      }

      protected void S142( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV22ProductServiceId = 0;
         AssignAttri(sPrefix, false, "AV22ProductServiceId", StringUtil.LTrimStr( (decimal)(AV22ProductServiceId), 4, 0));
         AV28WebSession.Remove(AV29WebSessionKey);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV29WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV29WebSessionKey", AV29WebSessionKey);
         AV20PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         AV12GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
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
         PA2X2( ) ;
         WS2X2( ) ;
         WE2X2( ) ;
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
         sCtrlAV29WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV20PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV12GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createresidentstep4", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV29WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV29WebSessionKey", AV29WebSessionKey);
            AV20PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
            AV12GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
         }
         wcpOAV29WebSessionKey = cgiGet( sPrefix+"wcpOAV29WebSessionKey");
         wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
         wcpOAV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV29WebSessionKey, wcpOAV29WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV20PreviousStep, wcpOAV20PreviousStep) != 0 ) || ( AV12GoingBack != wcpOAV12GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV29WebSessionKey = AV29WebSessionKey;
         wcpOAV20PreviousStep = AV20PreviousStep;
         wcpOAV12GoingBack = AV12GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV29WebSessionKey = cgiGet( sPrefix+"AV29WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV29WebSessionKey) > 0 )
         {
            AV29WebSessionKey = cgiGet( sCtrlAV29WebSessionKey);
            AssignAttri(sPrefix, false, "AV29WebSessionKey", AV29WebSessionKey);
         }
         else
         {
            AV29WebSessionKey = cgiGet( sPrefix+"AV29WebSessionKey_PARM");
         }
         sCtrlAV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV20PreviousStep) > 0 )
         {
            AV20PreviousStep = cgiGet( sCtrlAV20PreviousStep);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         }
         else
         {
            AV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_PARM");
         }
         sCtrlAV12GoingBack = cgiGet( sPrefix+"AV12GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV12GoingBack) > 0 )
         {
            AV12GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV12GoingBack));
            AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
         }
         else
         {
            AV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV12GoingBack_PARM"));
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
         PA2X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2X2( ) ;
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
         WS2X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29WebSessionKey_PARM", AV29WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV29WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_PARM", AV20PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV20PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12GoingBack_PARM", StringUtil.BoolToStr( AV12GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12GoingBack_CTRL", StringUtil.RTrim( sCtrlAV12GoingBack));
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
         WE2X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315522150", true, true);
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
         context.AddJavascriptSource("createresidentstep4.js", "?202491315522151", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_302( )
      {
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productserviceid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEID_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICENAME_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicedescription_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEDESCRIPTION_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicequantity_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEQUANTITY_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicetypename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPENAME_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicepicture_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEPICTURE_"+sGXsfl_30_idx;
         edtavResidentproductservicesdts__productservicetypeid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPEID_"+sGXsfl_30_idx;
      }

      protected void SubsflControlProps_fel_302( )
      {
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productserviceid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEID_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICENAME_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicedescription_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEDESCRIPTION_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicequantity_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEQUANTITY_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicetypename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPENAME_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicepicture_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEPICTURE_"+sGXsfl_30_fel_idx;
         edtavResidentproductservicesdts__productservicetypeid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPEID_"+sGXsfl_30_fel_idx;
      }

      protected void sendrow_302( )
      {
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         WB2X0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_30_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_30_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_30_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',30)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleterecord_Internalname,StringUtil.RTrim( AV31DeleteRecord),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETERECORD.CLICK."+sGXsfl_30_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeleterecord_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeleterecord_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productserviceid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productserviceid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavResidentproductservicesdts__productserviceid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productserviceid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productserviceid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productserviceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavResidentproductservicesdts__productserviceid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',30)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicename_Internalname,((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicename,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productservicename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentproductservicesdts__productservicename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',30)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicedescription_Internalname,((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicedescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productservicedescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentproductservicesdts__productservicedescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicequantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicequantity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavResidentproductservicesdts__productservicequantity_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicequantity), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicequantity), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productservicequantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavResidentproductservicesdts__productservicequantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_30_idx + "',30)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicetypename_Internalname,((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicetypename,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productservicetypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResidentproductservicesdts__productservicetypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(edtavResidentproductservicesdts__productservicepicture_gximage, "")==0) ? "" : "GX_Image_"+edtavResidentproductservicesdts__productservicepicture_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicepicture)) ? ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicepicture_gxi : context.PathToRelativeUrl( ((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicepicture));
            GridsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicepicture_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResidentproductservicesdts__productservicetypeid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicetypeid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavResidentproductservicesdts__productservicetypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicetypeid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtResidentProductServiceSDT)AV26ResidentProductServiceSDTs.Item(AV34GXV1)).gxTpr_Productservicetypeid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResidentproductservicesdts__productservicetypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavResidentproductservicesdts__productservicetypeid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2X2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_30_idx = ((subGrids_Islastpage==1)&&(nGXsfl_30_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         /* End function sendrow_302 */
      }

      protected void init_web_controls( )
      {
         dynavProductserviceid.Name = "vPRODUCTSERVICEID";
         dynavProductserviceid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl30( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"30\">") ;
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Quantity", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+" "+((StringUtil.StrCmp(edtavResidentproductservicesdts__productservicepicture_gximage, "")==0) ? "" : "GX_Image_"+edtavResidentproductservicesdts__productservicepicture_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Picture", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Type Id", "")) ;
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
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31DeleteRecord)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleterecord_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productserviceid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productservicename_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productservicedescription_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productservicequantity_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productservicetypename_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResidentproductservicesdts__productservicetypeid_Enabled), 5, 0, ".", "")));
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
         dynavProductserviceid_Internalname = sPrefix+"vPRODUCTSERVICEID";
         bttBtnaddproductservice_Internalname = sPrefix+"BTNADDPRODUCTSERVICE";
         divActionbtntable_Internalname = sPrefix+"ACTIONBTNTABLE";
         edtavDeleterecord_Internalname = sPrefix+"vDELETERECORD";
         edtavResidentproductservicesdts__productserviceid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEID";
         edtavResidentproductservicesdts__productservicename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICENAME";
         edtavResidentproductservicesdts__productservicedescription_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEDESCRIPTION";
         edtavResidentproductservicesdts__productservicequantity_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEQUANTITY";
         edtavResidentproductservicesdts__productservicetypename_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPENAME";
         edtavResidentproductservicesdts__productservicepicture_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICEPICTURE";
         edtavResidentproductservicesdts__productservicetypeid_Internalname = sPrefix+"RESIDENTPRODUCTSERVICESDTS__PRODUCTSERVICETYPEID";
         Gridspaginationbar_Internalname = sPrefix+"GRIDSPAGINATIONBAR";
         divGridstablewithpaginationbar_Internalname = sPrefix+"GRIDSTABLEWITHPAGINATIONBAR";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnfinish_Internalname = sPrefix+"BTNFINISH";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavResidentproductservicesdts__productservicetypeid_Jsonclick = "";
         edtavResidentproductservicesdts__productservicetypeid_Enabled = 0;
         edtavResidentproductservicesdts__productservicepicture_gximage = "";
         edtavResidentproductservicesdts__productservicetypename_Jsonclick = "";
         edtavResidentproductservicesdts__productservicetypename_Enabled = 0;
         edtavResidentproductservicesdts__productservicequantity_Jsonclick = "";
         edtavResidentproductservicesdts__productservicequantity_Enabled = 0;
         edtavResidentproductservicesdts__productservicedescription_Jsonclick = "";
         edtavResidentproductservicesdts__productservicedescription_Enabled = 0;
         edtavResidentproductservicesdts__productservicename_Jsonclick = "";
         edtavResidentproductservicesdts__productservicename_Enabled = 0;
         edtavResidentproductservicesdts__productserviceid_Jsonclick = "";
         edtavResidentproductservicesdts__productserviceid_Enabled = 0;
         edtavDeleterecord_Jsonclick = "";
         edtavDeleterecord_Enabled = 1;
         subGrids_Class = "GridWithPaginationBar WorkWith";
         subGrids_Backcolorstyle = 0;
         dynavProductserviceid_Jsonclick = "";
         dynavProductserviceid.Enabled = 1;
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
         edtavResidentproductservicesdts__productservicetypeid_Enabled = -1;
         edtavResidentproductservicesdts__productservicetypename_Enabled = -1;
         edtavResidentproductservicesdts__productservicequantity_Enabled = -1;
         edtavResidentproductservicesdts__productservicedescription_Enabled = -1;
         edtavResidentproductservicesdts__productservicename_Enabled = -1;
         edtavResidentproductservicesdts__productserviceid_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV14GridsCurrentPage","fld":"vGRIDSCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV15GridsPageCount","fld":"vGRIDSPAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E182X2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV31DeleteRecord","fld":"vDELETERECORD"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112X2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Selectedpage","ctrl":"GRIDSPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122X2","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"Gridspaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDSPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDSPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]}""");
         setEventMetadata("ENTER","""{"handler":"E192X2","iparms":[{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV29WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV30WizardData","fld":"vWIZARDDATA"},{"av":"AV23Resident","fld":"vRESIDENT"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV30WizardData","fld":"vWIZARDDATA"},{"av":"AV23Resident","fld":"vRESIDENT"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV8AddedProductsServices","fld":"vADDEDPRODUCTSSERVICES"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E132X2","iparms":[{"av":"AV29WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV30WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOFINISH'","""{"handler":"E142X2","iparms":[{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV29WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV30WizardData","fld":"vWIZARDDATA"},{"av":"AV23Resident","fld":"vRESIDENT"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOFINISH'",""","oparms":[{"av":"AV30WizardData","fld":"vWIZARDDATA"},{"av":"AV23Resident","fld":"vRESIDENT"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV8AddedProductsServices","fld":"vADDEDPRODUCTSSERVICES"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOADDPRODUCTSERVICE'","""{"handler":"E152X2","iparms":[{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV8AddedProductsServices","fld":"vADDEDPRODUCTSSERVICES"},{"av":"A74ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"},{"av":"A76ProductServiceQuantity","fld":"PRODUCTSERVICEQUANTITY","pic":"ZZZ9"},{"av":"A77ProductServicePicture","fld":"PRODUCTSERVICEPICTURE"},{"av":"A40000ProductServicePicture_GXI","fld":"PRODUCTSERVICEPICTURE_GXI"},{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV29WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOADDPRODUCTSERVICE'",""","oparms":[{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"AV8AddedProductsServices","fld":"vADDEDPRODUCTSSERVICES"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"}]}""");
         setEventMetadata("VDELETERECORD.CLICK","""{"handler":"E202X2","iparms":[{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"dynavProductserviceid"},{"av":"AV22ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9"},{"av":"AV16HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VDELETERECORD.CLICK",""","oparms":[{"av":"AV26ResidentProductServiceSDTs","fld":"vRESIDENTPRODUCTSERVICESDTS","grid":30},{"av":"nGXsfl_30_idx","ctrl":"GRID","prop":"GridCurrRow","grid":30},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_30","ctrl":"GRIDS","prop":"GridRC","grid":30}]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEID","""{"handler":"Validv_Productserviceid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv8","iparms":[]}""");
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
         wcpOAV29WebSessionKey = "";
         wcpOAV20PreviousStep = "";
         Gridspaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26ResidentProductServiceSDTs = new GXBaseCollection<SdtResidentProductServiceSDT>( context, "ResidentProductServiceSDT", "");
         AV13GridsAppliedFilters = "";
         AV30WizardData = new SdtCreateResidentData(context);
         AV23Resident = new SdtResident(context);
         AV8AddedProductsServices = new GxSimpleCollection<short>();
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         A72ProductServiceTypeName = "";
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         Grids_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnaddproductservice_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridspaginationbar = new GXUserControl();
         bttBtnwizardprevious_Jsonclick = "";
         bttBtnfinish_Jsonclick = "";
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31DeleteRecord = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002X2_A73ProductServiceId = new short[1] ;
         H002X2_A74ProductServiceName = new string[] {""} ;
         GridsRow = new GXWebRow();
         AV28WebSession = context.GetSession();
         H002X3_A71ProductServiceTypeId = new short[1] ;
         H002X3_A73ProductServiceId = new short[1] ;
         H002X3_A40000ProductServicePicture_GXI = new string[] {""} ;
         H002X3_A74ProductServiceName = new string[] {""} ;
         H002X3_A75ProductServiceDescription = new string[] {""} ;
         H002X3_A72ProductServiceTypeName = new string[] {""} ;
         H002X3_A76ProductServiceQuantity = new short[1] ;
         H002X3_A77ProductServicePicture = new string[] {""} ;
         AV27ResidentProductServiceSDTsItem = new SdtResidentProductServiceSDT(context);
         AV25ResidentIndividual = new SdtResidentINIndividualSDT(context);
         AV18Individual = new SdtResident_INIndividual(context);
         AV24ResidentCompany = new SdtResidentINCompanySDT(context);
         AV9Company = new SdtResident_INCompany(context);
         AV7ResidentProductService = new SdtResidentProductServiceSDT(context);
         AV21ProductService = new SdtResident_ProductService(context);
         AV5ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV29WebSessionKey = "";
         sCtrlAV20PreviousStep = "";
         sCtrlAV12GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createresidentstep4__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createresidentstep4__default(),
            new Object[][] {
                new Object[] {
               H002X2_A73ProductServiceId, H002X2_A74ProductServiceName
               }
               , new Object[] {
               H002X3_A71ProductServiceTypeId, H002X3_A73ProductServiceId, H002X3_A40000ProductServicePicture_GXI, H002X3_A74ProductServiceName, H002X3_A75ProductServiceDescription, H002X3_A72ProductServiceTypeName, H002X3_A76ProductServiceQuantity, H002X3_A77ProductServicePicture
               }
            }
         );
         /* GeneXus formulas. */
         edtavDeleterecord_Enabled = 0;
         edtavResidentproductservicesdts__productserviceid_Enabled = 0;
         edtavResidentproductservicesdts__productservicename_Enabled = 0;
         edtavResidentproductservicesdts__productservicedescription_Enabled = 0;
         edtavResidentproductservicesdts__productservicequantity_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypename_Enabled = 0;
         edtavResidentproductservicesdts__productservicetypeid_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV22ProductServiceId ;
      private short A73ProductServiceId ;
      private short A76ProductServiceQuantity ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV11CustomerId ;
      private short AV6LocationId ;
      private short GXt_int1 ;
      private short A71ProductServiceTypeId ;
      private short AV32ServiceProductId ;
      private short AV33Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int Gridspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_30 ;
      private int subGrids_Rows ;
      private int nGXsfl_30_idx=1 ;
      private int edtavDeleterecord_Enabled ;
      private int edtavResidentproductservicesdts__productserviceid_Enabled ;
      private int edtavResidentproductservicesdts__productservicename_Enabled ;
      private int edtavResidentproductservicesdts__productservicedescription_Enabled ;
      private int edtavResidentproductservicesdts__productservicequantity_Enabled ;
      private int edtavResidentproductservicesdts__productservicetypename_Enabled ;
      private int edtavResidentproductservicesdts__productservicetypeid_Enabled ;
      private int Gridspaginationbar_Pagestoshow ;
      private int AV34GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_30_fel_idx=1 ;
      private int AV19PageToGo ;
      private int nGXsfl_30_bak_idx=1 ;
      private int AV43GXV9 ;
      private int AV44GXV10 ;
      private int AV45GXV11 ;
      private int AV46GXV12 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long AV14GridsCurrentPage ;
      private long AV15GridsPageCount ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Gridspaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_30_idx="0001" ;
      private string edtavDeleterecord_Internalname ;
      private string edtavResidentproductservicesdts__productserviceid_Internalname ;
      private string edtavResidentproductservicesdts__productservicename_Internalname ;
      private string edtavResidentproductservicesdts__productservicedescription_Internalname ;
      private string edtavResidentproductservicesdts__productservicequantity_Internalname ;
      private string edtavResidentproductservicesdts__productservicetypename_Internalname ;
      private string edtavResidentproductservicesdts__productservicetypeid_Internalname ;
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
      private string dynavProductserviceid_Internalname ;
      private string TempTags ;
      private string dynavProductserviceid_Jsonclick ;
      private string divActionbtntable_Internalname ;
      private string bttBtnaddproductservice_Internalname ;
      private string bttBtnaddproductservice_Jsonclick ;
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
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV31DeleteRecord ;
      private string gxwrpcisep ;
      private string sGXsfl_30_fel_idx="0001" ;
      private string sCtrlAV29WebSessionKey ;
      private string sCtrlAV20PreviousStep ;
      private string sCtrlAV12GoingBack ;
      private string edtavResidentproductservicesdts__productservicepicture_Internalname ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavDeleterecord_Jsonclick ;
      private string edtavResidentproductservicesdts__productserviceid_Jsonclick ;
      private string edtavResidentproductservicesdts__productservicename_Jsonclick ;
      private string edtavResidentproductservicesdts__productservicedescription_Jsonclick ;
      private string edtavResidentproductservicesdts__productservicequantity_Jsonclick ;
      private string edtavResidentproductservicesdts__productservicetypename_Jsonclick ;
      private string edtavResidentproductservicesdts__productservicepicture_gximage ;
      private string sImgUrl ;
      private string edtavResidentproductservicesdts__productservicetypeid_Jsonclick ;
      private string subGrids_Header ;
      private bool AV12GoingBack ;
      private bool wcpOAV12GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16HasValidationErrors ;
      private bool bGXsfl_30_Refreshing=false ;
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
      private bool gx_BV30 ;
      private string AV29WebSessionKey ;
      private string AV20PreviousStep ;
      private string wcpOAV29WebSessionKey ;
      private string wcpOAV20PreviousStep ;
      private string AV13GridsAppliedFilters ;
      private string A74ProductServiceName ;
      private string A75ProductServiceDescription ;
      private string A72ProductServiceTypeName ;
      private string A40000ProductServicePicture_GXI ;
      private string A77ProductServicePicture ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucGridspaginationbar ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV28WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavProductserviceid ;
      private GXBaseCollection<SdtResidentProductServiceSDT> AV26ResidentProductServiceSDTs ;
      private SdtCreateResidentData AV30WizardData ;
      private SdtResident AV23Resident ;
      private GxSimpleCollection<short> AV8AddedProductsServices ;
      private IDataStoreProvider pr_default ;
      private short[] H002X2_A73ProductServiceId ;
      private string[] H002X2_A74ProductServiceName ;
      private short[] H002X3_A71ProductServiceTypeId ;
      private short[] H002X3_A73ProductServiceId ;
      private string[] H002X3_A40000ProductServicePicture_GXI ;
      private string[] H002X3_A74ProductServiceName ;
      private string[] H002X3_A75ProductServiceDescription ;
      private string[] H002X3_A72ProductServiceTypeName ;
      private short[] H002X3_A76ProductServiceQuantity ;
      private string[] H002X3_A77ProductServicePicture ;
      private SdtResidentProductServiceSDT AV27ResidentProductServiceSDTsItem ;
      private SdtResidentINIndividualSDT AV25ResidentIndividual ;
      private SdtResident_INIndividual AV18Individual ;
      private SdtResidentINCompanySDT AV24ResidentCompany ;
      private SdtResident_INCompany AV9Company ;
      private SdtResidentProductServiceSDT AV7ResidentProductService ;
      private SdtResident_ProductService AV21ProductService ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5ErrorMessages ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class createresidentstep4__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createresidentstep4__default : DataStoreHelperBase, IDataStoreHelper
 {
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
        Object[] prmH002X2;
        prmH002X2 = new Object[] {
        };
        Object[] prmH002X3;
        prmH002X3 = new Object[] {
        new ParDef("AV22ProductServiceId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002X2", "SELECT ProductServiceId, ProductServiceName FROM ProductService ORDER BY ProductServiceName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002X3", "SELECT T1.ProductServiceTypeId, T1.ProductServiceId, T1.ProductServicePicture_GXI, T1.ProductServiceName, T1.ProductServiceDescription, T2.ProductServiceTypeName, T1.ProductServiceQuantity, T1.ProductServicePicture FROM (ProductService T1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = T1.ProductServiceTypeId) WHERE T1.ProductServiceId = :AV22ProductServiceId ORDER BY T1.ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X3,1, GxCacheFrequency.OFF ,false,true )
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
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              return;
     }
  }

}

}
