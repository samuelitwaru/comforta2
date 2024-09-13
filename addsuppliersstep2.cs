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
   public class addsuppliersstep2 : GXWebComponent
   {
      public addsuppliersstep2( )
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

      public addsuppliersstep2( IGxContext context )
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
         this.AV45WebSessionKey = aP0_WebSessionKey;
         this.AV27PreviousStep = aP1_PreviousStep;
         this.AV18GoingBack = aP2_GoingBack;
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
                  AV45WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV45WebSessionKey", AV45WebSessionKey);
                  AV27PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV27PreviousStep", AV27PreviousStep);
                  AV18GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV45WebSessionKey,(string)AV27PreviousStep,(bool)AV18GoingBack});
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
                  GXDLVvLOCATIONOPTION2S2( ) ;
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
         nRC_GXsfl_27 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
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
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV24LocationOption = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOption"), "."), 18, MidpointRounding.ToEven));
         AV19HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
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
            PA2S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_genid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genid_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_gencontactname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
               AssignProp(sPrefix, false, edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               GXVvLOCATIONOPTION_html2S2( ) ;
               WS2S2( ) ;
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
            context.SendWebValue( context.GetMessage( "Add Suppliers Step2", "")) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("addsuppliersstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV45WebSessionKey)),UrlEncode(StringUtil.RTrim(AV27PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV18GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV19HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV19HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Locationgensupplierssdts", AV23LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Locationgensupplierssdts", AV23LocationGenSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERGENOPTIONS_DATA", AV41SupplierGenOptions_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERGENOPTIONS_DATA", AV41SupplierGenOptions_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV45WebSessionKey", wcpOAV45WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27PreviousStep", wcpOAV27PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV18GoingBack", wcpOAV18GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV19HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV19HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV45WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERGENOPTIONS", AV40SupplierGenOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERGENOPTIONS", AV40SupplierGenOptions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONGENSUPPLIERSSDTS", AV23LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONGENSUPPLIERSSDTS", AV23LocationGenSuppliersSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCUSTOMER", AV11Customer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCUSTOMER", AV11Customer);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONAGBSUPPLIERSSDTS", AV21LocationAGBSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONAGBSUPPLIERSSDTS", AV21LocationAGBSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV27PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV18GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENOPTIONS_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenoptions_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm2S2( )
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
         return "AddSuppliersStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Add Suppliers Step2", "") ;
      }

      protected void WB2S0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "addsuppliersstep2.aspx");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24LocationOption), 4, 0)), 1, dynavLocationoption_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,12);\"", "", true, 0, "HLP_AddSuppliersStep2.htm");
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24LocationOption), 4, 0));
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_suppliergenoptions.SetProperty("Caption", Combo_suppliergenoptions_Caption);
            ucCombo_suppliergenoptions.SetProperty("Cls", Combo_suppliergenoptions_Cls);
            ucCombo_suppliergenoptions.SetProperty("AllowMultipleSelection", Combo_suppliergenoptions_Allowmultipleselection);
            ucCombo_suppliergenoptions.SetProperty("DataListProc", Combo_suppliergenoptions_Datalistproc);
            ucCombo_suppliergenoptions.SetProperty("DataListProcParametersPrefix", Combo_suppliergenoptions_Datalistprocparametersprefix);
            ucCombo_suppliergenoptions.SetProperty("IncludeOnlySelectedOption", Combo_suppliergenoptions_Includeonlyselectedoption);
            ucCombo_suppliergenoptions.SetProperty("MultipleValuesType", Combo_suppliergenoptions_Multiplevaluestype);
            ucCombo_suppliergenoptions.SetProperty("EmptyItemText", Combo_suppliergenoptions_Emptyitemtext);
            ucCombo_suppliergenoptions.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_suppliergenoptions.SetProperty("DropDownOptionsData", AV41SupplierGenOptions_Data);
            ucCombo_suppliergenoptions.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenoptions_Internalname, sPrefix+"COMBO_SUPPLIERGENOPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "     ", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddSuppliersStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-start;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsertgensupplier_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(27), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtninsertgensupplier_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERTGENSUPPLIER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AddSuppliersStep2.htm");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl27( ) ;
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV47GXV1 = nGXsfl_27_idx;
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
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("Caption", Btnwizardlastnext_Caption);
            ucBtnwizardlastnext.SetProperty("Class", Btnwizardlastnext_Class);
            ucBtnwizardlastnext.Render(context, "wwp_iconbutton", Btnwizardlastnext_Internalname, sPrefix+"BTNWIZARDLASTNEXTContainer");
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
         if ( wbEnd == 27 )
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
                  AV47GXV1 = nGXsfl_27_idx;
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

      protected void START2S2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Add Suppliers Step2", ""), 0) ;
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
               STRUP2S0( ) ;
            }
         }
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
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
                                 STRUP2S0( ) ;
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
                                 STRUP2S0( ) ;
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
                                          E112S2 ();
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
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E122S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTGENSUPPLIER'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsertGenSupplier' */
                                    E132S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
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
                                 STRUP2S0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              AV47GXV1 = (int)(nGXsfl_27_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) && ( AV47GXV1 > 0 ) )
                              {
                                 AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
                                 AV43UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV43UDelete);
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
                                          E142S2 ();
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
                                          E152S2 ();
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
                                          E162S2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2S0( ) ;
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

      protected void WE2S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2S2( ) ;
            }
         }
      }

      protected void PA2S2( )
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

      protected void GXDLVvLOCATIONOPTION2S2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data2S2( ) ;
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

      protected void GXVvLOCATIONOPTION_html2S2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data2S2( ) ;
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
            AV24LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24LocationOption", StringUtil.LTrimStr( (decimal)(AV24LocationOption), 4, 0));
         }
      }

      protected void GXDLVvLOCATIONOPTION_data2S2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002S2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H002S2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002S2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H002S2_A19CustomerLocationVisitingAddres[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subGrids_Islastpage==1)&&(nGXsfl_27_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        short AV24LocationOption ,
                                        bool AV19HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2S2( ) ;
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
            GXVvLOCATIONOPTION_html2S2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV24LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24LocationOption", StringUtil.LTrimStr( (decimal)(AV24LocationOption), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24LocationOption), 4, 0));
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 27;
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
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
            SubsflControlProps_272( ) ;
            /* Execute user event: Grids.Load */
            E152S2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_27_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E152S2 ();
            }
            wbEnd = 27;
            WB2S0( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV19HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV19HasValidationErrors, context));
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
         return AV23LocationGenSuppliersSDTs.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         GXVvLOCATIONOPTION_html2S2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Locationgensupplierssdts"), AV23LocationGenSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERGENOPTIONS_DATA"), AV41SupplierGenOptions_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONGENSUPPLIERSSDTS"), AV23LocationGenSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERGENOPTIONS"), AV40SupplierGenOptions);
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_27"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV45WebSessionKey = cgiGet( sPrefix+"wcpOAV45WebSessionKey");
            wcpOAV27PreviousStep = cgiGet( sPrefix+"wcpOAV27PreviousStep");
            wcpOAV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV18GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_27 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_27"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_27_fel_idx = 0;
            while ( nGXsfl_27_fel_idx < nRC_GXsfl_27 )
            {
               nGXsfl_27_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_27_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_fel_idx+1);
               sGXsfl_27_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_272( ) ;
               AV47GXV1 = (int)(nGXsfl_27_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) && ( AV47GXV1 > 0 ) )
               {
                  AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
                  AV43UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_27_fel_idx == 0 )
            {
               nGXsfl_27_idx = 1;
               sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
               SubsflControlProps_272( ) ;
            }
            nGXsfl_27_fel_idx = 1;
            /* Read variables values. */
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV24LocationOption = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24LocationOption", StringUtil.LTrimStr( (decimal)(AV24LocationOption), 4, 0));
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
         E142S2 ();
         if (returnInSub) return;
      }

      protected void E142S2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV15GAMErrors);
         Combo_suppliergenoptions_Gamoauthtoken = AV16GAMSession.gxTpr_Token;
         ucCombo_suppliergenoptions.SendProperty(context, sPrefix, false, Combo_suppliergenoptions_Internalname, "GAMOAuthToken", Combo_suppliergenoptions_Gamoauthtoken);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENOPTIONS' */
         S122 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GXt_int2 = AV5CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int2) ;
         AV5CustomerId = GXt_int2;
         AV11Customer.Load(AV5CustomerId);
         GXt_SdtGAMUser3 = AV17GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser3) ;
         AV17GAMUser = GXt_SdtGAMUser3;
         if ( AV17GAMUser.checkrole(context.GetMessage( "Customer Manager", "")) )
         {
            dynavLocationoption.Visible = 1;
            AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV17GAMUser.checkrole(context.GetMessage( "Receptionist", "")) )
            {
               GXt_int2 = AV24LocationOption;
               new getreceptionistlocationid(context ).execute( out  GXt_int2) ;
               AV24LocationOption = GXt_int2;
               AssignAttri(sPrefix, false, "AV24LocationOption", StringUtil.LTrimStr( (decimal)(AV24LocationOption), 4, 0));
               dynavLocationoption.Visible = 0;
               AssignProp(sPrefix, false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      private void E152S2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV23LocationGenSuppliersSDTs.Count )
         {
            AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
            AV43UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV43UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 27;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_272( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
            {
               DoAjaxLoad(27, GridsRow);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E112S2 ();
         if (returnInSub) return;
      }

      protected void E112S2( )
      {
         AV47GXV1 = (int)(nGXsfl_27_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV47GXV1 > 0 ) && ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) )
         {
            AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV19HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV44WebSession.Remove(AV45WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11Customer", AV11Customer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21LocationAGBSuppliersSDTs", AV21LocationAGBSuppliersSDTs);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23LocationGenSuppliersSDTs", AV23LocationGenSuppliersSDTs);
         nGXsfl_27_bak_idx = nGXsfl_27_idx;
         gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
         nGXsfl_27_idx = nGXsfl_27_bak_idx;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
      }

      protected void E122S2( )
      {
         AV47GXV1 = (int)(nGXsfl_27_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV47GXV1 > 0 ) && ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) )
         {
            AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         CallWebObject(formatLink("addsuppliers.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.BoolToStr(true))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E132S2( )
      {
         AV47GXV1 = (int)(nGXsfl_27_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV47GXV1 > 0 ) && ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) )
         {
            AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
         }
         /* 'DoInsertGenSupplier' Routine */
         returnInSub = false;
         AV55GXV9 = 1;
         while ( AV55GXV9 <= AV40SupplierGenOptions.Count )
         {
            AV28selectedSupplierId = (short)(AV40SupplierGenOptions.GetNumeric(AV55GXV9));
            AV38SupplierGen.Load(AV28selectedSupplierId);
            AV22LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_genid = AV38SupplierGen.gxTpr_Supplier_genid;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_genkvknumber = AV38SupplierGen.gxTpr_Supplier_genkvknumber;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_gencompanyname = AV38SupplierGen.gxTpr_Supplier_gencompanyname;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_gencontactname = AV38SupplierGen.gxTpr_Supplier_gencontactname;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_gencontactphone = AV38SupplierGen.gxTpr_Supplier_gencontactphone;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_genpostaladdress = AV38SupplierGen.gxTpr_Supplier_genpostaladdress;
            AV22LocationGenSuppliersSDT.gxTpr_Supplier_genvisitingaddress = AV38SupplierGen.gxTpr_Supplier_genvisitingaddress;
            AV23LocationGenSuppliersSDTs.Add(AV22LocationGenSuppliersSDT, 0);
            gx_BV27 = true;
            AV55GXV9 = (int)(AV55GXV9+1);
         }
         AV40SupplierGenOptions.Clear();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23LocationGenSuppliersSDTs", AV23LocationGenSuppliersSDTs);
         nGXsfl_27_bak_idx = nGXsfl_27_idx;
         gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
         nGXsfl_27_idx = nGXsfl_27_bak_idx;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV40SupplierGenOptions", AV40SupplierGenOptions);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV46WizardData.FromJSonString(AV44WebSession.Get(AV45WebSessionKey), null);
         AV24LocationOption = AV46WizardData.gxTpr_Step2.gxTpr_Locationoption;
         AssignAttri(sPrefix, false, "AV24LocationOption", StringUtil.LTrimStr( (decimal)(AV24LocationOption), 4, 0));
         AV40SupplierGenOptions = AV46WizardData.gxTpr_Step2.gxTpr_Suppliergenoptions;
         AV23LocationGenSuppliersSDTs = AV46WizardData.gxTpr_Step2.gxTpr_Locationgensupplierssdts;
         gx_BV27 = true;
         AV21LocationAGBSuppliersSDTs = AV46WizardData.gxTpr_Step1.gxTpr_Locationagbsupplierssdts;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV46WizardData.FromJSonString(AV44WebSession.Get(AV45WebSessionKey), null);
         AV46WizardData.gxTpr_Step2.gxTpr_Locationoption = AV24LocationOption;
         AV46WizardData.gxTpr_Step2.gxTpr_Suppliergenoptions = AV40SupplierGenOptions;
         AV46WizardData.gxTpr_Step2.gxTpr_Locationgensupplierssdts = AV23LocationGenSuppliersSDTs;
         AV44WebSession.Set(AV45WebSessionKey, AV46WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV56GXV10 = 1;
         while ( AV56GXV10 <= AV23LocationGenSuppliersSDTs.Count )
         {
            AV22LocationGenSuppliersSDT = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV56GXV10));
            AV26LocationSupplierGen = new SdtCustomer_Locations_Supplier_Gen(context);
            AV26LocationSupplierGen.gxTpr_Supplier_genid = AV22LocationGenSuppliersSDT.gxTpr_Supplier_genid;
            AV11Customer.gxTpr_Locations.GetByKey(AV24LocationOption).gxTpr_Supplier_gen.Add(AV26LocationSupplierGen, 0);
            AV56GXV10 = (int)(AV56GXV10+1);
         }
         AV57GXV11 = 1;
         while ( AV57GXV11 <= AV21LocationAGBSuppliersSDTs.Count )
         {
            AV20LocationAGBSuppliersSDT = ((SdtLocationAGBSuppliersSDT)AV21LocationAGBSuppliersSDTs.Item(AV57GXV11));
            AV25LocationSupplierAGB = new SdtCustomer_Locations_Supplier_Agb(context);
            AV25LocationSupplierAGB.gxTpr_Supplier_agbid = AV20LocationAGBSuppliersSDT.gxTpr_Supplier_agbid;
            AV11Customer.gxTpr_Locations.GetByKey(AV24LocationOption).gxTpr_Supplier_agb.Add(AV25LocationSupplierAGB, 0);
            AV57GXV11 = (int)(AV57GXV11+1);
         }
         if ( AV11Customer.Update() )
         {
            context.CommitDataStores("addsuppliersstep2",pr_default);
            AV21LocationAGBSuppliersSDTs.Clear();
            AV23LocationGenSuppliersSDTs.Clear();
            gx_BV27 = true;
         }
         else
         {
            AV14ErrorMessages = AV11Customer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV14ErrorMessages.Item(1)).gxTpr_Description);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGENOPTIONS' Routine */
         returnInSub = false;
         AV29SelectedTextCol = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV58GXV12 = 1;
         while ( AV58GXV12 <= AV40SupplierGenOptions.Count )
         {
            AV42SupplierGenOptionsKey = (short)(AV40SupplierGenOptions.GetNumeric(AV58GXV12));
            AssignAttri(sPrefix, false, "AV42SupplierGenOptionsKey", StringUtil.LTrimStr( (decimal)(AV42SupplierGenOptionsKey), 4, 0));
            AV59GXLvl177 = 0;
            /* Using cursor H002S3 */
            pr_default.execute(1, new Object[] {AV42SupplierGenOptionsKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A64Supplier_GenId = H002S3_A64Supplier_GenId[0];
               A66Supplier_GenCompanyName = H002S3_A66Supplier_GenCompanyName[0];
               AV59GXLvl177 = 1;
               AV29SelectedTextCol.Add(A66Supplier_GenCompanyName, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV59GXLvl177 == 0 )
            {
               AV29SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV42SupplierGenOptionsKey), 4, 0)), 0);
            }
            AV58GXV12 = (int)(AV58GXV12+1);
         }
         Combo_suppliergenoptions_Selectedtext_set = AV29SelectedTextCol.ToJSonString(false);
         ucCombo_suppliergenoptions.SendProperty(context, sPrefix, false, Combo_suppliergenoptions_Internalname, "SelectedText_set", Combo_suppliergenoptions_Selectedtext_set);
         Combo_suppliergenoptions_Selectedvalue_set = AV40SupplierGenOptions.ToJSonString(false);
         ucCombo_suppliergenoptions.SendProperty(context, sPrefix, false, Combo_suppliergenoptions_Internalname, "SelectedValue_set", Combo_suppliergenoptions_Selectedvalue_set);
      }

      protected void E162S2( )
      {
         AV47GXV1 = (int)(nGXsfl_27_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV47GXV1 > 0 ) && ( AV23LocationGenSuppliersSDTs.Count >= AV47GXV1 ) )
         {
            AV23LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV39SupplierGenId = ((SdtLocationGenSuppliersSDT)(AV23LocationGenSuppliersSDTs.CurrentItem)).gxTpr_Supplier_genid;
         AV60Index = 1;
         AV61GXV13 = 1;
         while ( AV61GXV13 <= AV23LocationGenSuppliersSDTs.Count )
         {
            AV22LocationGenSuppliersSDT = ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV61GXV13));
            if ( AV22LocationGenSuppliersSDT.gxTpr_Supplier_genid == AV39SupplierGenId )
            {
               if (true) break;
            }
            else
            {
               AV60Index = (short)(AV60Index+1);
            }
            AV61GXV13 = (int)(AV61GXV13+1);
         }
         if ( AV60Index <= AV23LocationGenSuppliersSDTs.Count )
         {
            AV23LocationGenSuppliersSDTs.RemoveItem(AV60Index);
            gx_BV27 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23LocationGenSuppliersSDTs", AV23LocationGenSuppliersSDTs);
         nGXsfl_27_bak_idx = nGXsfl_27_idx;
         gxgrGrids_refresh( subGrids_Rows, AV24LocationOption, AV19HasValidationErrors, sPrefix) ;
         nGXsfl_27_idx = nGXsfl_27_bak_idx;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV45WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV45WebSessionKey", AV45WebSessionKey);
         AV27PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV27PreviousStep", AV27PreviousStep);
         AV18GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
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
         sCtrlAV45WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV27PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV18GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "addsuppliersstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV45WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV45WebSessionKey", AV45WebSessionKey);
            AV27PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV27PreviousStep", AV27PreviousStep);
            AV18GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
         }
         wcpOAV45WebSessionKey = cgiGet( sPrefix+"wcpOAV45WebSessionKey");
         wcpOAV27PreviousStep = cgiGet( sPrefix+"wcpOAV27PreviousStep");
         wcpOAV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV18GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV45WebSessionKey, wcpOAV45WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV27PreviousStep, wcpOAV27PreviousStep) != 0 ) || ( AV18GoingBack != wcpOAV18GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV45WebSessionKey = AV45WebSessionKey;
         wcpOAV27PreviousStep = AV27PreviousStep;
         wcpOAV18GoingBack = AV18GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV45WebSessionKey = cgiGet( sPrefix+"AV45WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV45WebSessionKey) > 0 )
         {
            AV45WebSessionKey = cgiGet( sCtrlAV45WebSessionKey);
            AssignAttri(sPrefix, false, "AV45WebSessionKey", AV45WebSessionKey);
         }
         else
         {
            AV45WebSessionKey = cgiGet( sPrefix+"AV45WebSessionKey_PARM");
         }
         sCtrlAV27PreviousStep = cgiGet( sPrefix+"AV27PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV27PreviousStep) > 0 )
         {
            AV27PreviousStep = cgiGet( sCtrlAV27PreviousStep);
            AssignAttri(sPrefix, false, "AV27PreviousStep", AV27PreviousStep);
         }
         else
         {
            AV27PreviousStep = cgiGet( sPrefix+"AV27PreviousStep_PARM");
         }
         sCtrlAV18GoingBack = cgiGet( sPrefix+"AV18GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV18GoingBack) > 0 )
         {
            AV18GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV18GoingBack));
            AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
         }
         else
         {
            AV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV18GoingBack_PARM"));
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
         PA2S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2S2( ) ;
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
         WS2S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV45WebSessionKey_PARM", AV45WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV45WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV45WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV45WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27PreviousStep_PARM", AV27PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV27PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18GoingBack_PARM", StringUtil.BoolToStr( AV18GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18GoingBack_CTRL", StringUtil.RTrim( sCtrlAV18GoingBack));
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
         WE2S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315533938", true, true);
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
         context.AddJavascriptSource("addsuppliersstep2.js", "?202491315533943", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_genid_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_27_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_272( )
      {
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_genid_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_27_fel_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_27_fel_idx;
      }

      protected void sendrow_272( )
      {
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         WB2S0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_27_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_27_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV43UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_27_idx+"'",(string)"",(string)"",context.GetMessage( "Delete item", ""),(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavLocationgensupplierssdts__supplier_genid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname,((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_gencompanyname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname,((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genkvknumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactname_Internalname,((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_gencontactname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencontactname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname,StringUtil.RTrim( ((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_gencontactphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname,((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genpostaladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_27_idx + "',27)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname,((SdtLocationGenSuppliersSDT)AV23LocationGenSuppliersSDTs.Item(AV47GXV1)).gxTpr_Supplier_genvisitingaddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2S2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_27_idx = ((subGrids_Islastpage==1)&&(nGXsfl_27_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         /* End function sendrow_272 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl27( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"27\">") ;
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
            context.SendWebValue( context.GetMessage( "Supplier_Gen Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Company Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "KvKNumber", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Phone", "")) ;
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
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV43UDelete)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled), 5, 0, ".", "")));
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
         Combo_suppliergenoptions_Internalname = sPrefix+"COMBO_SUPPLIERGENOPTIONS";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         bttBtninsertgensupplier_Internalname = sPrefix+"BTNINSERTGENSUPPLIER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         edtavLocationgensupplierssdts__supplier_genid_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER";
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = sPrefix+"LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
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
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         Btnwizardlastnext_Class = "Button ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         Combo_suppliergenoptions_Emptyitemtext = "Select AGB Supplier to add";
         Combo_suppliergenoptions_Multiplevaluestype = "Tags";
         Combo_suppliergenoptions_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_suppliergenoptions_Datalistprocparametersprefix = " \"ComboName\": \"AddSuppliersStep2_SupplierGenOptions\"";
         Combo_suppliergenoptions_Datalistproc = "AddSuppliersLoadDVCombo";
         Combo_suppliergenoptions_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_suppliergenoptions_Cls = "ExtendedCombo Attribute";
         Combo_suppliergenoptions_Caption = "";
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E152S2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV43UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E112S2","iparms":[{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV45WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV40SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"AV11Customer","fld":"vCUSTOMER"},{"av":"AV21LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11Customer","fld":"vCUSTOMER"},{"av":"AV21LocationAGBSuppliersSDTs","fld":"vLOCATIONAGBSUPPLIERSSDTS"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E122S2","iparms":[{"av":"AV45WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV40SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27}]}""");
         setEventMetadata("'DOINSERTGENSUPPLIER'","""{"handler":"E132S2","iparms":[{"av":"AV40SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOINSERTGENSUPPLIER'",""","oparms":[{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"AV40SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E162S2","iparms":[{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27}]}""");
         setEventMetadata("GRIDS_FIRSTPAGE","""{"handler":"subgrids_firstpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_PREVPAGE","""{"handler":"subgrids_previouspage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_NEXTPAGE","""{"handler":"subgrids_nextpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_LASTPAGE","""{"handler":"subgrids_lastpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":27},{"av":"nGXsfl_27_idx","ctrl":"GRID","prop":"GridCurrRow","grid":27},{"av":"nRC_GXsfl_27","ctrl":"GRIDS","prop":"GridRC","grid":27},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV19HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"dynavLocationoption"},{"av":"AV24LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
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
         wcpOAV45WebSessionKey = "";
         wcpOAV27PreviousStep = "";
         Combo_suppliergenoptions_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV23LocationGenSuppliersSDTs = new GXBaseCollection<SdtLocationGenSuppliersSDT>( context, "LocationGenSuppliersSDT", "");
         AV13DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41SupplierGenOptions_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV40SupplierGenOptions = new GxSimpleCollection<short>();
         AV11Customer = new SdtCustomer(context);
         AV21LocationAGBSuppliersSDTs = new GXBaseCollection<SdtLocationAGBSuppliersSDT>( context, "LocationAGBSuppliersSDT", "");
         GX_FocusControl = "";
         TempTags = "";
         ucCombo_suppliergenoptions = new GXUserControl();
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtninsertgensupplier_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV43UDelete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002S2_A18CustomerLocationId = new short[1] ;
         H002S2_A19CustomerLocationVisitingAddres = new string[] {""} ;
         H002S2_A1CustomerId = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV15GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         Combo_suppliergenoptions_Gamoauthtoken = "";
         Grids_empowerer_Gridinternalname = "";
         AV17GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser3 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridsRow = new GXWebRow();
         AV44WebSession = context.GetSession();
         AV38SupplierGen = new SdtSupplier_Gen(context);
         AV22LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
         AV46WizardData = new SdtAddSuppliersData(context);
         AV26LocationSupplierGen = new SdtCustomer_Locations_Supplier_Gen(context);
         AV20LocationAGBSuppliersSDT = new SdtLocationAGBSuppliersSDT(context);
         AV25LocationSupplierAGB = new SdtCustomer_Locations_Supplier_Agb(context);
         AV14ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV29SelectedTextCol = new GxSimpleCollection<string>();
         H002S3_A64Supplier_GenId = new short[1] ;
         H002S3_A66Supplier_GenCompanyName = new string[] {""} ;
         A66Supplier_GenCompanyName = "";
         Combo_suppliergenoptions_Selectedtext_set = "";
         Combo_suppliergenoptions_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV45WebSessionKey = "";
         sCtrlAV27PreviousStep = "";
         sCtrlAV18GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.addsuppliersstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.addsuppliersstep2__default(),
            new Object[][] {
                new Object[] {
               H002S2_A18CustomerLocationId, H002S2_A19CustomerLocationVisitingAddres, H002S2_A1CustomerId
               }
               , new Object[] {
               H002S3_A64Supplier_GenId, H002S3_A66Supplier_GenCompanyName
               }
            }
         );
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV24LocationOption ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV5CustomerId ;
      private short GXt_int2 ;
      private short AV28selectedSupplierId ;
      private short AV42SupplierGenOptionsKey ;
      private short AV59GXLvl177 ;
      private short A64Supplier_GenId ;
      private short AV39SupplierGenId ;
      private short AV60Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_27 ;
      private int subGrids_Rows ;
      private int nGXsfl_27_idx=1 ;
      private int edtavUdelete_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genid_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled ;
      private int AV47GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_27_fel_idx=1 ;
      private int nGXsfl_27_bak_idx=1 ;
      private int AV55GXV9 ;
      private int AV56GXV10 ;
      private int AV57GXV11 ;
      private int AV58GXV12 ;
      private int AV61GXV13 ;
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
      private string Combo_suppliergenoptions_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_27_idx="0001" ;
      private string edtavUdelete_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genid_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string dynavLocationoption_Internalname ;
      private string TempTags ;
      private string dynavLocationoption_Jsonclick ;
      private string Combo_suppliergenoptions_Caption ;
      private string Combo_suppliergenoptions_Cls ;
      private string Combo_suppliergenoptions_Datalistproc ;
      private string Combo_suppliergenoptions_Datalistprocparametersprefix ;
      private string Combo_suppliergenoptions_Multiplevaluestype ;
      private string Combo_suppliergenoptions_Emptyitemtext ;
      private string Combo_suppliergenoptions_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsertgensupplier_Internalname ;
      private string bttBtninsertgensupplier_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV43UDelete ;
      private string gxwrpcisep ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string Combo_suppliergenoptions_Gamoauthtoken ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_suppliergenoptions_Selectedtext_set ;
      private string Combo_suppliergenoptions_Selectedvalue_set ;
      private string sCtrlAV45WebSessionKey ;
      private string sCtrlAV27PreviousStep ;
      private string sCtrlAV18GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavUdelete_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genid_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick ;
      private string subGrids_Header ;
      private bool AV18GoingBack ;
      private bool wcpOAV18GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19HasValidationErrors ;
      private bool bGXsfl_27_Refreshing=false ;
      private bool wbLoad ;
      private bool Combo_suppliergenoptions_Allowmultipleselection ;
      private bool Combo_suppliergenoptions_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV27 ;
      private string AV45WebSessionKey ;
      private string AV27PreviousStep ;
      private string wcpOAV45WebSessionKey ;
      private string wcpOAV27PreviousStep ;
      private string A66Supplier_GenCompanyName ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_suppliergenoptions ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV44WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXBaseCollection<SdtLocationGenSuppliersSDT> AV23LocationGenSuppliersSDTs ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41SupplierGenOptions_Data ;
      private GxSimpleCollection<short> AV40SupplierGenOptions ;
      private SdtCustomer AV11Customer ;
      private GXBaseCollection<SdtLocationAGBSuppliersSDT> AV21LocationAGBSuppliersSDTs ;
      private IDataStoreProvider pr_default ;
      private short[] H002S2_A18CustomerLocationId ;
      private string[] H002S2_A19CustomerLocationVisitingAddres ;
      private short[] H002S2_A1CustomerId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV16GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser3 ;
      private SdtSupplier_Gen AV38SupplierGen ;
      private SdtLocationGenSuppliersSDT AV22LocationGenSuppliersSDT ;
      private SdtAddSuppliersData AV46WizardData ;
      private SdtCustomer_Locations_Supplier_Gen AV26LocationSupplierGen ;
      private SdtLocationAGBSuppliersSDT AV20LocationAGBSuppliersSDT ;
      private SdtCustomer_Locations_Supplier_Agb AV25LocationSupplierAGB ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14ErrorMessages ;
      private GxSimpleCollection<string> AV29SelectedTextCol ;
      private short[] H002S3_A64Supplier_GenId ;
      private string[] H002S3_A66Supplier_GenCompanyName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class addsuppliersstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class addsuppliersstep2__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH002S2;
        prmH002S2 = new Object[] {
        };
        Object[] prmH002S3;
        prmH002S3 = new Object[] {
        new ParDef("AV42SupplierGenOptionsKey",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002S2", "SELECT CustomerLocationId, CustomerLocationVisitingAddres, CustomerId FROM CustomerLocation ORDER BY CustomerLocationVisitingAddres ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002S3", "SELECT Supplier_GenId, Supplier_GenCompanyName FROM Supplier_Gen WHERE Supplier_GenId = :AV42SupplierGenOptionsKey ORDER BY Supplier_GenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S3,1, GxCacheFrequency.OFF ,false,true )
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
