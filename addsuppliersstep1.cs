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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class addsuppliersstep1 : GXWebComponent
   {
      public addsuppliersstep1( )
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

      public addsuppliersstep1( IGxContext context )
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
         this.AV42WebSessionKey = aP0_WebSessionKey;
         this.AV20PreviousStep = aP1_PreviousStep;
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
         dynavLocationoption = new GXCombobox();
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
                  AV42WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV42WebSessionKey", AV42WebSessionKey);
                  AV20PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
                  AV14GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV42WebSessionKey,(string)AV20PreviousStep,(bool)AV14GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvLOCATIONOPTION2R2( ) ;
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
         nRC_GXsfl_29 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
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
         AV14GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV19LocationOption = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOption"), "."), 18, MidpointRounding.ToEven));
         AV15HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
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
            PA2R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbid_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbname_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbemail_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbphone_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               GXVvLOCATIONOPTION_html2R2( ) ;
               WS2R2( ) ;
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
            context.SendWebValue( context.GetMessage( "Add Suppliers Step1", "")) ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("addsuppliersstep1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV42WebSessionKey)),UrlEncode(StringUtil.RTrim(AV20PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV14GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Locationagbsupplierssdts", AV18LocationAGBSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Locationagbsupplierssdts", AV18LocationAGBSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_29", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_29), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV10DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV10DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERAGBOPTIONS_DATA", AV35SupplierAGBOptions_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERAGBOPTIONS_DATA", AV35SupplierAGBOptions_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV42WebSessionKey", wcpOAV42WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20PreviousStep", wcpOAV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV14GoingBack", wcpOAV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV42WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERAGBOPTIONS", AV34SupplierAGBOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERAGBOPTIONS", AV34SupplierAGBOptions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONAGBSUPPLIERSSDTS", AV18LocationAGBSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONAGBSUPPLIERSSDTS", AV18LocationAGBSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV20PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBOPTIONS_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragboptions_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm2R2( )
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
         return "AddSuppliersStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Add Suppliers Step1", "") ;
      }

      protected void WB2R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "addsuppliersstep1.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0)), 1, dynavLocationoption_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "", true, 0, "HLP_AddSuppliersStep1.htm");
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0));
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer1_Internalname, "     ", "", "", lblSpacer1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddSuppliersStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_supplieragboptions.SetProperty("Caption", Combo_supplieragboptions_Caption);
            ucCombo_supplieragboptions.SetProperty("Cls", Combo_supplieragboptions_Cls);
            ucCombo_supplieragboptions.SetProperty("AllowMultipleSelection", Combo_supplieragboptions_Allowmultipleselection);
            ucCombo_supplieragboptions.SetProperty("DataListProc", Combo_supplieragboptions_Datalistproc);
            ucCombo_supplieragboptions.SetProperty("DataListProcParametersPrefix", Combo_supplieragboptions_Datalistprocparametersprefix);
            ucCombo_supplieragboptions.SetProperty("IncludeOnlySelectedOption", Combo_supplieragboptions_Includeonlyselectedoption);
            ucCombo_supplieragboptions.SetProperty("MultipleValuesType", Combo_supplieragboptions_Multiplevaluestype);
            ucCombo_supplieragboptions.SetProperty("EmptyItemText", Combo_supplieragboptions_Emptyitemtext);
            ucCombo_supplieragboptions.SetProperty("DropDownOptionsTitleSettingsIcons", AV10DDO_TitleSettingsIcons);
            ucCombo_supplieragboptions.SetProperty("DropDownOptionsData", AV35SupplierAGBOptions_Data);
            ucCombo_supplieragboptions.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragboptions_Internalname, sPrefix+"COMBO_SUPPLIERAGBOPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer2_Internalname, "     ", "", "", lblSpacer2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddSuppliersStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-start;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsertagbsupplier_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtninsertagbsupplier_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERTAGBSUPPLIER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AddSuppliersStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl29( ) ;
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            nRC_GXsfl_29 = (int)(nGXsfl_29_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV44GXV1 = nGXsfl_29_idx;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
         if ( wbEnd == 29 )
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
                  GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
                  GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
                  AV44GXV1 = nGXsfl_29_idx;
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

      protected void START2R2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Add Suppliers Step1", ""), 0) ;
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
               STRUP2R0( ) ;
            }
         }
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
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
                                 STRUP2R0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
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
                                          E112R2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E122R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTAGBSUPPLIER'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsertAGBSupplier' */
                                    E132R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavUdelete_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrids_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrids_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrids_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrids_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2R0( ) ;
                              }
                              nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
                              SubsflControlProps_292( ) ;
                              AV44GXV1 = (int)(nGXsfl_29_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV18LocationAGBSuppliersSDTs.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
                              {
                                 AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
                                 AV37UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV37UDelete);
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
                                          GX_FocusControl = edtavUdelete_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E142R2 ();
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
                                          GX_FocusControl = edtavUdelete_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E152R2 ();
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
                                          GX_FocusControl = edtavUdelete_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E162R2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUDELETE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUdelete_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E172R2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2R0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUdelete_Internalname;
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

      protected void WE2R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2R2( ) ;
            }
         }
      }

      protected void PA2R2( )
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
               GX_FocusControl = dynavLocationoption_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONOPTION2R2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data2R2( ) ;
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

      protected void GXVvLOCATIONOPTION_html2R2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data2R2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLocationoption.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
         }
      }

      protected void GXDLVvLOCATIONOPTION_data2R2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H002R2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002R2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H002R2_A19CustomerLocationVisitingAddres[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_292( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_292( ) ;
            nGXsfl_29_idx = ((subGrids_Islastpage==1)&&(nGXsfl_29_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV14GoingBack ,
                                        short AV19LocationOption ,
                                        bool AV15HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2R2( ) ;
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
            GXVvLOCATIONOPTION_html2R2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19LocationOption), 4, 0));
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 29;
         /* Execute user event: Refresh */
         E152R2 ();
         nGXsfl_29_idx = 1;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         bGXsfl_29_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_292( ) ;
            /* Execute user event: Grids.Load */
            E162R2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_29_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E162R2 ();
            }
            wbEnd = 29;
            WB2R0( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
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
         return AV18LocationAGBSuppliersSDTs.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavUdelete_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
         GXVvLOCATIONOPTION_html2R2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142R2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Locationagbsupplierssdts"), AV18LocationAGBSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV10DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERAGBOPTIONS_DATA"), AV35SupplierAGBOptions_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONAGBSUPPLIERSSDTS"), AV18LocationAGBSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERAGBOPTIONS"), AV34SupplierAGBOptions);
            /* Read saved values. */
            nRC_GXsfl_29 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_29"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV42WebSessionKey = cgiGet( sPrefix+"wcpOAV42WebSessionKey");
            wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
            wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_29 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_29"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_29_fel_idx = 0;
            while ( nGXsfl_29_fel_idx < nRC_GXsfl_29 )
            {
               nGXsfl_29_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_29_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_fel_idx+1);
               sGXsfl_29_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_292( ) ;
               AV44GXV1 = (int)(nGXsfl_29_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV18LocationAGBSuppliersSDTs.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
               {
                  AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
                  AV37UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_29_fel_idx == 0 )
            {
               nGXsfl_29_idx = 1;
               sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
               SubsflControlProps_292( ) ;
            }
            nGXsfl_29_fel_idx = 1;
            /* Read variables values. */
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV19LocationOption = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
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
         E142R2 ();
         if (returnInSub) return;
      }

      protected void E142R2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV10DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV10DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV12GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV11GAMErrors);
         Combo_supplieragboptions_Gamoauthtoken = AV12GAMSession.gxTpr_Token;
         ucCombo_supplieragboptions.SendProperty(context, sPrefix, false, Combo_supplieragboptions_Internalname, "GAMOAuthToken", Combo_supplieragboptions_Gamoauthtoken);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBOPTIONS' */
         S122 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GXt_SdtGAMUser2 = AV13GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser2) ;
         AV13GAMUser = GXt_SdtGAMUser2;
         if ( AV13GAMUser.checkrole(context.GetMessage( "Customer Manager", "")) )
         {
            dynavLocationoption.Visible = 1;
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV13GAMUser.checkrole(context.GetMessage( "Receptionist", "")) )
            {
               GXt_int3 = AV19LocationOption;
               new getreceptionistlocationid(context ).execute( out  GXt_int3) ;
               AV19LocationOption = GXt_int3;
               AssignAttri(sPrefix, false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
               dynavLocationoption.Visible = 0;
               AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      protected void E152R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E162R2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
            AV37UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV37UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 29;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_292( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
            {
               DoAjaxLoad(29, GridsRow);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E112R2 ();
         if (returnInSub) return;
      }

      protected void E112R2( )
      {
         AV44GXV1 = (int)(nGXsfl_29_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV44GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV15HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            CallWebObject(formatLink("addsuppliers.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E122R2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E132R2( )
      {
         AV44GXV1 = (int)(nGXsfl_29_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV44GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
         }
         /* 'DoInsertAGBSupplier' Routine */
         returnInSub = false;
         AV54GXV11 = 1;
         while ( AV54GXV11 <= AV34SupplierAGBOptions.Count )
         {
            AV21selectedSupplierId = (short)(AV34SupplierAGBOptions.GetNumeric(AV54GXV11));
            AV32SupplierAGB.Load(AV21selectedSupplierId);
            AV17LocationAGBSuppliersSDT = new SdtLocationAGBSuppliersSDT(context);
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbid = AV32SupplierAGB.gxTpr_Supplier_agbid;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbkvknumber = AV32SupplierAGB.gxTpr_Supplier_agbkvknumber;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbnumber = AV32SupplierAGB.gxTpr_Supplier_agbnumber;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbemail = AV32SupplierAGB.gxTpr_Supplier_agbemail;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbname = AV32SupplierAGB.gxTpr_Supplier_agbname;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbphone = AV32SupplierAGB.gxTpr_Supplier_agbphone;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbcontactname = AV32SupplierAGB.gxTpr_Supplier_agbcontactname;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbpostaladdress = AV32SupplierAGB.gxTpr_Supplier_agbpostaladdress;
            AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbvisitingaddress = AV32SupplierAGB.gxTpr_Supplier_agbvisitingaddress;
            AV18LocationAGBSuppliersSDTs.Add(AV17LocationAGBSuppliersSDT, 0);
            gx_BV29 = true;
            AV54GXV11 = (int)(AV54GXV11+1);
         }
         AV34SupplierAGBOptions.Clear();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18LocationAGBSuppliersSDTs", AV18LocationAGBSuppliersSDTs);
         nGXsfl_29_bak_idx = nGXsfl_29_idx;
         gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
         nGXsfl_29_idx = nGXsfl_29_bak_idx;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SupplierAGBOptions", AV34SupplierAGBOptions);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV14GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV43WizardData.FromJSonString(AV41WebSession.Get(AV42WebSessionKey), null);
         AV19LocationOption = AV43WizardData.gxTpr_Step1.gxTpr_Locationoption;
         AssignAttri(sPrefix, false, "AV19LocationOption", StringUtil.LTrimStr( (decimal)(AV19LocationOption), 4, 0));
         AV34SupplierAGBOptions = AV43WizardData.gxTpr_Step1.gxTpr_Supplieragboptions;
         AV18LocationAGBSuppliersSDTs = AV43WizardData.gxTpr_Step1.gxTpr_Locationagbsupplierssdts;
         gx_BV29 = true;
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV43WizardData.FromJSonString(AV41WebSession.Get(AV42WebSessionKey), null);
         AV43WizardData.gxTpr_Step1.gxTpr_Locationoption = AV19LocationOption;
         AV43WizardData.gxTpr_Step1.gxTpr_Supplieragboptions = AV34SupplierAGBOptions;
         AV43WizardData.gxTpr_Step1.gxTpr_Locationagbsupplierssdts = AV18LocationAGBSuppliersSDTs;
         AV41WebSession.Set(AV42WebSessionKey, AV43WizardData.ToJSonString(false, true));
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBOPTIONS' Routine */
         returnInSub = false;
         AV22SelectedTextCol = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV55GXV12 = 1;
         while ( AV55GXV12 <= AV34SupplierAGBOptions.Count )
         {
            AV36SupplierAGBOptionsKey = (short)(AV34SupplierAGBOptions.GetNumeric(AV55GXV12));
            AssignAttri(sPrefix, false, "AV36SupplierAGBOptionsKey", StringUtil.LTrimStr( (decimal)(AV36SupplierAGBOptionsKey), 4, 0));
            AV56GXLvl160 = 0;
            /* Using cursor H002R3 */
            pr_default.execute(1, new Object[] {AV36SupplierAGBOptionsKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A55Supplier_AgbId = H002R3_A55Supplier_AgbId[0];
               A57Supplier_AgbName = H002R3_A57Supplier_AgbName[0];
               AV56GXLvl160 = 1;
               AV22SelectedTextCol.Add(A57Supplier_AgbName, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV56GXLvl160 == 0 )
            {
               AV22SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV36SupplierAGBOptionsKey), 4, 0)), 0);
            }
            AV55GXV12 = (int)(AV55GXV12+1);
         }
         Combo_supplieragboptions_Selectedtext_set = AV22SelectedTextCol.ToJSonString(false);
         ucCombo_supplieragboptions.SendProperty(context, sPrefix, false, Combo_supplieragboptions_Internalname, "SelectedText_set", Combo_supplieragboptions_Selectedtext_set);
         Combo_supplieragboptions_Selectedvalue_set = AV34SupplierAGBOptions.ToJSonString(false);
         ucCombo_supplieragboptions.SendProperty(context, sPrefix, false, Combo_supplieragboptions_Internalname, "SelectedValue_set", Combo_supplieragboptions_Selectedvalue_set);
      }

      protected void E172R2( )
      {
         AV44GXV1 = (int)(nGXsfl_29_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV44GXV1 > 0 ) && ( AV18LocationAGBSuppliersSDTs.Count >= AV44GXV1 ) )
         {
            AV18LocationAGBSuppliersSDTs.CurrentItem = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV33SupplierAgbId = ((SdtLocationAGBSuppliersSDT)(AV18LocationAGBSuppliersSDTs.CurrentItem)).gxTpr_Supplier_agbid;
         AV16Index = 1;
         AV57GXV13 = 1;
         while ( AV57GXV13 <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV17LocationAGBSuppliersSDT = ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV57GXV13));
            if ( AV17LocationAGBSuppliersSDT.gxTpr_Supplier_agbid == AV33SupplierAgbId )
            {
               if (true) break;
            }
            else
            {
               AV16Index = (short)(AV16Index+1);
            }
            AV57GXV13 = (int)(AV57GXV13+1);
         }
         if ( AV16Index <= AV18LocationAGBSuppliersSDTs.Count )
         {
            AV18LocationAGBSuppliersSDTs.RemoveItem(AV16Index);
            gx_BV29 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18LocationAGBSuppliersSDTs", AV18LocationAGBSuppliersSDTs);
         nGXsfl_29_bak_idx = nGXsfl_29_idx;
         gxgrGrids_refresh( subGrids_Rows, AV14GoingBack, AV19LocationOption, AV15HasValidationErrors, sPrefix) ;
         nGXsfl_29_idx = nGXsfl_29_bak_idx;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV42WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV42WebSessionKey", AV42WebSessionKey);
         AV20PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
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
         sCtrlAV42WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV20PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV14GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "addsuppliersstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2R2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV42WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV42WebSessionKey", AV42WebSessionKey);
            AV20PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
            AV14GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         wcpOAV42WebSessionKey = cgiGet( sPrefix+"wcpOAV42WebSessionKey");
         wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
         wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV42WebSessionKey, wcpOAV42WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV20PreviousStep, wcpOAV20PreviousStep) != 0 ) || ( AV14GoingBack != wcpOAV14GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV42WebSessionKey = AV42WebSessionKey;
         wcpOAV20PreviousStep = AV20PreviousStep;
         wcpOAV14GoingBack = AV14GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV42WebSessionKey = cgiGet( sPrefix+"AV42WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV42WebSessionKey) > 0 )
         {
            AV42WebSessionKey = cgiGet( sCtrlAV42WebSessionKey);
            AssignAttri(sPrefix, false, "AV42WebSessionKey", AV42WebSessionKey);
         }
         else
         {
            AV42WebSessionKey = cgiGet( sPrefix+"AV42WebSessionKey_PARM");
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
         PA2R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2R2( ) ;
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
         WS2R2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV42WebSessionKey_PARM", AV42WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV42WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV42WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV42WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_PARM", AV20PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV20PreviousStep));
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
         WE2R2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315525670", true, true);
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
         context.AddJavascriptSource("addsuppliersstep1.js", "?202491315525674", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_292( )
      {
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_29_idx;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_292( )
      {
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS_"+sGXsfl_29_fel_idx;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_292( )
      {
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         WB2R0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_29_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_29_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV37UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_29_idx+"'",(string)"",(string)"",context.GetMessage( "Delete item", ""),(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavLocationagbsupplierssdts__supplier_agbid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationagbsupplierssdts__supplier_agbid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbname_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbnumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbkvknumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbemail_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbphone_Internalname,StringUtil.RTrim( ((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbcontactname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbpostaladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname,((SdtLocationAGBSuppliersSDT)AV18LocationAGBSuppliersSDTs.Item(AV44GXV1)).gxTpr_Supplier_agbvisitingaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2R2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_29_idx = ((subGrids_Islastpage==1)&&(nGXsfl_29_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         /* End function sendrow_292 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl29( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"29\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.SendWebValue( context.GetMessage( "Supplier_Agb Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "KvKNumber", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Postal Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Visiting Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV37UDelete)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled), 5, 0, ".", "")));
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
         dynavLocationoption_Internalname = sPrefix+"vLOCATIONOPTION";
         lblSpacer1_Internalname = sPrefix+"SPACER1";
         Combo_supplieragboptions_Internalname = sPrefix+"COMBO_SUPPLIERAGBOPTIONS";
         lblSpacer2_Internalname = sPrefix+"SPACER2";
         bttBtninsertagbsupplier_Internalname = sPrefix+"BTNINSERTAGBSUPPLIER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         edtavLocationagbsupplierssdts__supplier_agbid_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBID";
         edtavLocationagbsupplierssdts__supplier_agbname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNAME";
         edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBNUMBER";
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBKVKNUMBER";
         edtavLocationagbsupplierssdts__supplier_agbemail_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBEMAIL";
         edtavLocationagbsupplierssdts__supplier_agbphone_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPHONE";
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBCONTACTNAME";
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBPOSTALADDRESS";
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname = sPrefix+"LOCATIONAGBSUPPLIERSSDTS__SUPPLIER_AGBVISITINGADDRESS";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
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
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick = "";
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_supplieragboptions_Emptyitemtext = "Select AGB Supplier to add";
         Combo_supplieragboptions_Multiplevaluestype = "Tags";
         Combo_supplieragboptions_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_supplieragboptions_Datalistprocparametersprefix = " \"ComboName\": \"AddSuppliersStep1_SupplierAGBOptions\"";
         Combo_supplieragboptions_Datalistproc = "AddSuppliersLoadDVCombo";
         Combo_supplieragboptions_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_supplieragboptions_Cls = "ExtendedCombo Attribute";
         Combo_supplieragboptions_Caption = "";
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = -1;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E162R2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV37UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E112R2","iparms":[{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV42WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV34SupplierAGBOptions","fld":"vSUPPLIERAGBOPTIONS"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E122R2","iparms":[]}""");
         setEventMetadata("'DOINSERTAGBSUPPLIER'","""{"handler":"E132R2","iparms":[{"av":"AV34SupplierAGBOptions","fld":"vSUPPLIERAGBOPTIONS"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOINSERTAGBSUPPLIER'",""","oparms":[{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"AV34SupplierAGBOptions","fld":"vSUPPLIERAGBOPTIONS"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E172R2","iparms":[{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29}]}""");
         setEventMetadata("GRIDS_FIRSTPAGE","""{"handler":"subgrids_firstpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("GRIDS_FIRSTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRIDS_PREVPAGE","""{"handler":"subgrids_previouspage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("GRIDS_PREVPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRIDS_NEXTPAGE","""{"handler":"subgrids_nextpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("GRIDS_NEXTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRIDS_LASTPAGE","""{"handler":"subgrids_lastpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV18LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS","grid":29},{"av":"nGXsfl_29_idx","ctrl":"GRID","prop":"GridCurrRow","grid":29},{"av":"nRC_GXsfl_29","ctrl":"GRIDS","prop":"GridRC","grid":29},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"dynavLocationoption"},{"av":"AV19LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("GRIDS_LASTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv10","iparms":[]}""");
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
         wcpOAV42WebSessionKey = "";
         wcpOAV20PreviousStep = "";
         Combo_supplieragboptions_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18LocationAGBSuppliersSDTs = new GXBaseCollection<SdtLocationAGBSuppliersSDT>( context, "LocationAGBSuppliersSDT", "");
         AV10DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV35SupplierAGBOptions_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV34SupplierAGBOptions = new GxSimpleCollection<short>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblSpacer1_Jsonclick = "";
         ucCombo_supplieragboptions = new GXUserControl();
         lblSpacer2_Jsonclick = "";
         bttBtninsertagbsupplier_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV37UDelete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002R2_A18CustomerLocationId = new short[1] ;
         H002R2_A19CustomerLocationVisitingAddres = new string[] {""} ;
         H002R2_A1CustomerId = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV11GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         Combo_supplieragboptions_Gamoauthtoken = "";
         Grids_empowerer_Gridinternalname = "";
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser2 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridsRow = new GXWebRow();
         AV32SupplierAGB = new SdtSupplier_Agb(context);
         AV17LocationAGBSuppliersSDT = new SdtLocationAGBSuppliersSDT(context);
         AV43WizardData = new SdtAddSuppliersData(context);
         AV41WebSession = context.GetSession();
         AV22SelectedTextCol = new GxSimpleCollection<string>();
         H002R3_A55Supplier_AgbId = new short[1] ;
         H002R3_A57Supplier_AgbName = new string[] {""} ;
         A57Supplier_AgbName = "";
         Combo_supplieragboptions_Selectedtext_set = "";
         Combo_supplieragboptions_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV42WebSessionKey = "";
         sCtrlAV20PreviousStep = "";
         sCtrlAV14GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.addsuppliersstep1__default(),
            new Object[][] {
                new Object[] {
               H002R2_A18CustomerLocationId, H002R2_A19CustomerLocationVisitingAddres, H002R2_A1CustomerId
               }
               , new Object[] {
               H002R3_A55Supplier_AgbId, H002R3_A57Supplier_AgbName
               }
            }
         );
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbid_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbemail_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbphone_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled = 0;
         edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV19LocationOption ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short GXt_int3 ;
      private short AV21selectedSupplierId ;
      private short AV36SupplierAGBOptionsKey ;
      private short AV56GXLvl160 ;
      private short A55Supplier_AgbId ;
      private short AV33SupplierAgbId ;
      private short AV16Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_29 ;
      private int subGrids_Rows ;
      private int nGXsfl_29_idx=1 ;
      private int edtavUdelete_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbid_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbname_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbnumber_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbkvknumber_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbemail_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbphone_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbcontactname_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Enabled ;
      private int edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Enabled ;
      private int AV44GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_29_fel_idx=1 ;
      private int AV54GXV11 ;
      private int nGXsfl_29_bak_idx=1 ;
      private int AV55GXV12 ;
      private int AV57GXV13 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Combo_supplieragboptions_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_29_idx="0001" ;
      private string edtavUdelete_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbid_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbname_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbnumber_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbkvknumber_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbemail_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbphone_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbcontactname_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Internalname ;
      private string edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string dynavLocationoption_Internalname ;
      private string TempTags ;
      private string dynavLocationoption_Jsonclick ;
      private string lblSpacer1_Internalname ;
      private string lblSpacer1_Jsonclick ;
      private string Combo_supplieragboptions_Caption ;
      private string Combo_supplieragboptions_Cls ;
      private string Combo_supplieragboptions_Datalistproc ;
      private string Combo_supplieragboptions_Datalistprocparametersprefix ;
      private string Combo_supplieragboptions_Multiplevaluestype ;
      private string Combo_supplieragboptions_Emptyitemtext ;
      private string Combo_supplieragboptions_Internalname ;
      private string lblSpacer2_Internalname ;
      private string lblSpacer2_Jsonclick ;
      private string bttBtninsertagbsupplier_Internalname ;
      private string bttBtninsertagbsupplier_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV37UDelete ;
      private string gxwrpcisep ;
      private string sGXsfl_29_fel_idx="0001" ;
      private string Combo_supplieragboptions_Gamoauthtoken ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_supplieragboptions_Selectedtext_set ;
      private string Combo_supplieragboptions_Selectedvalue_set ;
      private string sCtrlAV42WebSessionKey ;
      private string sCtrlAV20PreviousStep ;
      private string sCtrlAV14GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavUdelete_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbid_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbname_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbnumber_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbkvknumber_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbemail_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbphone_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbcontactname_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbpostaladdress_Jsonclick ;
      private string edtavLocationagbsupplierssdts__supplier_agbvisitingaddress_Jsonclick ;
      private string subGrids_Header ;
      private bool AV14GoingBack ;
      private bool wcpOAV14GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15HasValidationErrors ;
      private bool bGXsfl_29_Refreshing=false ;
      private bool wbLoad ;
      private bool Combo_supplieragboptions_Allowmultipleselection ;
      private bool Combo_supplieragboptions_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV29 ;
      private bool Btnwizardfirstprevious_Visible ;
      private string AV42WebSessionKey ;
      private string AV20PreviousStep ;
      private string wcpOAV42WebSessionKey ;
      private string wcpOAV20PreviousStep ;
      private string A57Supplier_AgbName ;
      private IGxSession AV41WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_supplieragboptions ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXBaseCollection<SdtLocationAGBSuppliersSDT> AV18LocationAGBSuppliersSDTs ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV10DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV35SupplierAGBOptions_Data ;
      private GxSimpleCollection<short> AV34SupplierAGBOptions ;
      private IDataStoreProvider pr_default ;
      private short[] H002R2_A18CustomerLocationId ;
      private string[] H002R2_A19CustomerLocationVisitingAddres ;
      private short[] H002R2_A1CustomerId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV12GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser2 ;
      private SdtSupplier_Agb AV32SupplierAGB ;
      private SdtLocationAGBSuppliersSDT AV17LocationAGBSuppliersSDT ;
      private SdtAddSuppliersData AV43WizardData ;
      private GxSimpleCollection<string> AV22SelectedTextCol ;
      private short[] H002R3_A55Supplier_AgbId ;
      private string[] H002R3_A57Supplier_AgbName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class addsuppliersstep1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          };
          Object[] prmH002R3;
          prmH002R3 = new Object[] {
          new ParDef("AV36SupplierAGBOptionsKey",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "SELECT CustomerLocationId, CustomerLocationVisitingAddres, CustomerId FROM CustomerLocation ORDER BY CustomerLocationVisitingAddres ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002R3", "SELECT Supplier_AgbId, Supplier_AgbName FROM Supplier_AGB WHERE Supplier_AgbId = :AV36SupplierAGBOptionsKey ORDER BY Supplier_AgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
