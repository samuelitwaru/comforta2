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
   public class createcustomerstep1 : GXWebComponent
   {
      public createcustomerstep1( )
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

      public createcustomerstep1( IGxContext context )
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
         this.AV18PreviousStep = aP1_PreviousStep;
         this.AV16GoingBack = aP2_GoingBack;
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
         dynavCustomertypeid = new GXCombobox();
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
                  AV18PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV18PreviousStep", AV18PreviousStep);
                  AV16GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV16GoingBack", AV16GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV21WebSessionKey,(string)AV18PreviousStep,(bool)AV16GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCUSTOMERTYPEID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvCUSTOMERTYPEID2E2( ) ;
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
            PA2E2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               GXVvCUSTOMERTYPEID_html2E2( ) ;
               WS2E2( ) ;
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
            context.SendWebValue( "Create Customer Step1") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createcustomerstep1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21WebSessionKey)),UrlEncode(StringUtil.RTrim(AV18PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV16GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV17HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV17HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21WebSessionKey", wcpOAV21WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV18PreviousStep", wcpOAV18PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV16GoingBack", wcpOAV16GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV16GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV25CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV17HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV17HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV21WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV18PreviousStep);
      }

      protected void RenderHtmlCloseForm2E2( )
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
         return "CreateCustomerStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Create Customer Step1" ;
      }

      protected void WB2E0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createcustomerstep1.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerkvknumber_Internalname, "KvkNumber", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerkvknumber_Internalname, AV8CustomerKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV8CustomerKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomername_Internalname, "Customer Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomername_Internalname, AV9CustomerName, StringUtil.RTrim( context.localUtil.Format( AV9CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomername_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomervatnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomervatnumber_Internalname, "VAT", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomervatnumber_Internalname, AV14CustomerVatNumber, StringUtil.RTrim( context.localUtil.Format( AV14CustomerVatNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomervatnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomervatnumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavCustomertypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCustomertypeid_Internalname, "Customer Type", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCustomertypeid, dynavCustomertypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12CustomerTypeId), 4, 0)), 1, dynavCustomertypeid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCustomertypeid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_CreateCustomerStep1.htm");
            dynavCustomertypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12CustomerTypeId), 4, 0));
            AssignProp(sPrefix, false, dynavCustomertypeid_Internalname, "Values", (string)(dynavCustomertypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomeremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomeremail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomeremail_Internalname, AV6CustomerEmail, StringUtil.RTrim( context.localUtil.Format( AV6CustomerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomeremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomeremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerphone_Internalname, StringUtil.RTrim( AV10CustomerPhone), StringUtil.RTrim( context.localUtil.Format( AV10CustomerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCustomerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomerpostaladdress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomerpostaladdress_Internalname, "Postal Address", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavCustomerpostaladdress_Internalname, AV11CustomerPostalAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavCustomerpostaladdress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", "", 0, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCustomervisitingaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCustomervisitingaddress_Internalname, "Visiting Address", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavCustomervisitingaddress_Internalname, AV15CustomerVisitingAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtavCustomervisitingaddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", "", 0, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CreateCustomerStep1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnwizardfirstprevious_Internalname, "", "Cancel", bttBtnwizardfirstprevious_Jsonclick, 5, "Cancel", "", StyleString, ClassString, bttBtnwizardfirstprevious_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "", "Next", bttBtnwizardnext_Jsonclick, 5, "Next", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateCustomerStep1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCustomerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CustomerId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCustomerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCustomerid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateCustomerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2E2( )
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
            Form.Meta.addItem("description", "Create Customer Step1", 0) ;
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
               STRUP2E0( ) ;
            }
         }
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                                 STRUP2E0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E122E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
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
                                          E132E2 ();
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
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E142E2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E152E2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2E0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCustomerkvknumber_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2E2( ) ;
            }
         }
      }

      protected void PA2E2( )
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
               GX_FocusControl = edtavCustomerkvknumber_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCUSTOMERTYPEID2E2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCUSTOMERTYPEID_data2E2( ) ;
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

      protected void GXVvCUSTOMERTYPEID_html2E2( )
      {
         short gxdynajaxvalue;
         GXDLVvCUSTOMERTYPEID_data2E2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCustomertypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCustomertypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCUSTOMERTYPEID_data2E2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Select Type");
         /* Using cursor H002E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002E2_A78CustomerTypeId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002E2_A79CustomerTypeName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvCUSTOMERTYPEID_html2E2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCustomertypeid.ItemCount > 0 )
         {
            AV12CustomerTypeId = (short)(Math.Round(NumberUtil.Val( dynavCustomertypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12CustomerTypeId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12CustomerTypeId", StringUtil.LTrimStr( (decimal)(AV12CustomerTypeId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCustomertypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12CustomerTypeId), 4, 0));
            AssignProp(sPrefix, false, dynavCustomertypeid_Internalname, "Values", dynavCustomertypeid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122E2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152E2 ();
            WB2E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV17HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV17HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         GXVvCUSTOMERTYPEID_html2E2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112E2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV21WebSessionKey = cgiGet( sPrefix+"wcpOAV21WebSessionKey");
            wcpOAV18PreviousStep = cgiGet( sPrefix+"wcpOAV18PreviousStep");
            wcpOAV16GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV16GoingBack"));
            /* Read variables values. */
            AV8CustomerKvkNumber = cgiGet( edtavCustomerkvknumber_Internalname);
            AssignAttri(sPrefix, false, "AV8CustomerKvkNumber", AV8CustomerKvkNumber);
            AV9CustomerName = cgiGet( edtavCustomername_Internalname);
            AssignAttri(sPrefix, false, "AV9CustomerName", AV9CustomerName);
            AV14CustomerVatNumber = cgiGet( edtavCustomervatnumber_Internalname);
            AssignAttri(sPrefix, false, "AV14CustomerVatNumber", AV14CustomerVatNumber);
            dynavCustomertypeid.CurrentValue = cgiGet( dynavCustomertypeid_Internalname);
            AV12CustomerTypeId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavCustomertypeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12CustomerTypeId", StringUtil.LTrimStr( (decimal)(AV12CustomerTypeId), 4, 0));
            AV6CustomerEmail = cgiGet( edtavCustomeremail_Internalname);
            AssignAttri(sPrefix, false, "AV6CustomerEmail", AV6CustomerEmail);
            AV10CustomerPhone = cgiGet( edtavCustomerphone_Internalname);
            AssignAttri(sPrefix, false, "AV10CustomerPhone", AV10CustomerPhone);
            AV11CustomerPostalAddress = cgiGet( edtavCustomerpostaladdress_Internalname);
            AssignAttri(sPrefix, false, "AV11CustomerPostalAddress", AV11CustomerPostalAddress);
            AV15CustomerVisitingAddress = cgiGet( edtavCustomervisitingaddress_Internalname);
            AssignAttri(sPrefix, false, "AV15CustomerVisitingAddress", AV15CustomerVisitingAddress);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCustomerid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCustomerid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSTOMERID");
               GX_FocusControl = edtavCustomerid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7CustomerId = 0;
               AssignAttri(sPrefix, false, "AV7CustomerId", StringUtil.LTrimStr( (decimal)(AV7CustomerId), 4, 0));
            }
            else
            {
               AV7CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCustomerid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV7CustomerId", StringUtil.LTrimStr( (decimal)(AV7CustomerId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvCUSTOMERTYPEID_html2E2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E112E2 ();
         if (returnInSub) return;
      }

      protected void E112E2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavCustomerid_Visible = 0;
         AssignProp(sPrefix, false, edtavCustomerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCustomerid_Visible), 5, 0), true);
      }

      protected void E122E2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E132E2 ();
         if (returnInSub) return;
      }

      protected void E132E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV25CheckRequiredFieldsResult && ! AV17HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            CallWebObject(formatLink("createcustomer.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E142E2( )
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

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV16GoingBack ) )
         {
            bttBtnwizardfirstprevious_Visible = 0;
            AssignProp(sPrefix, false, bttBtnwizardfirstprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardfirstprevious_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV22WizardData.FromJSonString(AV20WebSession.Get(AV21WebSessionKey), null);
         AV7CustomerId = AV22WizardData.gxTpr_Step1.gxTpr_Customerid;
         AssignAttri(sPrefix, false, "AV7CustomerId", StringUtil.LTrimStr( (decimal)(AV7CustomerId), 4, 0));
         AV8CustomerKvkNumber = AV22WizardData.gxTpr_Step1.gxTpr_Customerkvknumber;
         AssignAttri(sPrefix, false, "AV8CustomerKvkNumber", AV8CustomerKvkNumber);
         AV9CustomerName = AV22WizardData.gxTpr_Step1.gxTpr_Customername;
         AssignAttri(sPrefix, false, "AV9CustomerName", AV9CustomerName);
         AV14CustomerVatNumber = AV22WizardData.gxTpr_Step1.gxTpr_Customervatnumber;
         AssignAttri(sPrefix, false, "AV14CustomerVatNumber", AV14CustomerVatNumber);
         AV12CustomerTypeId = AV22WizardData.gxTpr_Step1.gxTpr_Customertypeid;
         AssignAttri(sPrefix, false, "AV12CustomerTypeId", StringUtil.LTrimStr( (decimal)(AV12CustomerTypeId), 4, 0));
         AV6CustomerEmail = AV22WizardData.gxTpr_Step1.gxTpr_Customeremail;
         AssignAttri(sPrefix, false, "AV6CustomerEmail", AV6CustomerEmail);
         AV10CustomerPhone = AV22WizardData.gxTpr_Step1.gxTpr_Customerphone;
         AssignAttri(sPrefix, false, "AV10CustomerPhone", AV10CustomerPhone);
         AV11CustomerPostalAddress = AV22WizardData.gxTpr_Step1.gxTpr_Customerpostaladdress;
         AssignAttri(sPrefix, false, "AV11CustomerPostalAddress", AV11CustomerPostalAddress);
         AV15CustomerVisitingAddress = AV22WizardData.gxTpr_Step1.gxTpr_Customervisitingaddress;
         AssignAttri(sPrefix, false, "AV15CustomerVisitingAddress", AV15CustomerVisitingAddress);
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV22WizardData.FromJSonString(AV20WebSession.Get(AV21WebSessionKey), null);
         AV22WizardData.gxTpr_Step1.gxTpr_Customerid = AV7CustomerId;
         AV22WizardData.gxTpr_Step1.gxTpr_Customerkvknumber = AV8CustomerKvkNumber;
         AV22WizardData.gxTpr_Step1.gxTpr_Customername = AV9CustomerName;
         AV22WizardData.gxTpr_Step1.gxTpr_Customervatnumber = AV14CustomerVatNumber;
         AV22WizardData.gxTpr_Step1.gxTpr_Customertypeid = AV12CustomerTypeId;
         AV22WizardData.gxTpr_Step1.gxTpr_Customeremail = AV6CustomerEmail;
         AV22WizardData.gxTpr_Step1.gxTpr_Customerphone = AV10CustomerPhone;
         AV22WizardData.gxTpr_Step1.gxTpr_Customerpostaladdress = AV11CustomerPostalAddress;
         AV22WizardData.gxTpr_Step1.gxTpr_Customervisitingaddress = AV15CustomerVisitingAddress;
         AV20WebSession.Set(AV21WebSessionKey, AV22WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV25CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV25CheckRequiredFieldsResult", AV25CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8CustomerKvkNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "KvkNumber", "", "", "", "", "", "", "", ""),  "error",  edtavCustomerkvknumber_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV25CheckRequiredFieldsResult", AV25CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9CustomerName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Customer Name", "", "", "", "", "", "", "", ""),  "error",  edtavCustomername_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV25CheckRequiredFieldsResult", AV25CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14CustomerVatNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "VAT", "", "", "", "", "", "", "", ""),  "error",  edtavCustomervatnumber_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV25CheckRequiredFieldsResult", AV25CheckRequiredFieldsResult);
         }
         if ( (0==AV12CustomerTypeId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Customer Type is required",  "error",  dynavCustomertypeid_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV25CheckRequiredFieldsResult", AV25CheckRequiredFieldsResult);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E152E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
         AV18PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV18PreviousStep", AV18PreviousStep);
         AV16GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV16GoingBack", AV16GoingBack);
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
         sCtrlAV18PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV16GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2E2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createcustomerstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2E2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV21WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV21WebSessionKey", AV21WebSessionKey);
            AV18PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV18PreviousStep", AV18PreviousStep);
            AV16GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV16GoingBack", AV16GoingBack);
         }
         wcpOAV21WebSessionKey = cgiGet( sPrefix+"wcpOAV21WebSessionKey");
         wcpOAV18PreviousStep = cgiGet( sPrefix+"wcpOAV18PreviousStep");
         wcpOAV16GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV16GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV21WebSessionKey, wcpOAV21WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV18PreviousStep, wcpOAV18PreviousStep) != 0 ) || ( AV16GoingBack != wcpOAV16GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV21WebSessionKey = AV21WebSessionKey;
         wcpOAV18PreviousStep = AV18PreviousStep;
         wcpOAV16GoingBack = AV16GoingBack;
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
         sCtrlAV18PreviousStep = cgiGet( sPrefix+"AV18PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV18PreviousStep) > 0 )
         {
            AV18PreviousStep = cgiGet( sCtrlAV18PreviousStep);
            AssignAttri(sPrefix, false, "AV18PreviousStep", AV18PreviousStep);
         }
         else
         {
            AV18PreviousStep = cgiGet( sPrefix+"AV18PreviousStep_PARM");
         }
         sCtrlAV16GoingBack = cgiGet( sPrefix+"AV16GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV16GoingBack) > 0 )
         {
            AV16GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV16GoingBack));
            AssignAttri(sPrefix, false, "AV16GoingBack", AV16GoingBack);
         }
         else
         {
            AV16GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV16GoingBack_PARM"));
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
         PA2E2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2E2( ) ;
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
         WS2E2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18PreviousStep_PARM", AV18PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV18PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16GoingBack_PARM", StringUtil.BoolToStr( AV16GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16GoingBack_CTRL", StringUtil.RTrim( sCtrlAV16GoingBack));
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
         WE2E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912629321", true, true);
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
         context.AddJavascriptSource("createcustomerstep1.js", "?2024912629321", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavCustomertypeid.Name = "vCUSTOMERTYPEID";
         dynavCustomertypeid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavCustomerkvknumber_Internalname = sPrefix+"vCUSTOMERKVKNUMBER";
         edtavCustomername_Internalname = sPrefix+"vCUSTOMERNAME";
         edtavCustomervatnumber_Internalname = sPrefix+"vCUSTOMERVATNUMBER";
         dynavCustomertypeid_Internalname = sPrefix+"vCUSTOMERTYPEID";
         edtavCustomeremail_Internalname = sPrefix+"vCUSTOMEREMAIL";
         edtavCustomerphone_Internalname = sPrefix+"vCUSTOMERPHONE";
         edtavCustomerpostaladdress_Internalname = sPrefix+"vCUSTOMERPOSTALADDRESS";
         edtavCustomervisitingaddress_Internalname = sPrefix+"vCUSTOMERVISITINGADDRESS";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         bttBtnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavCustomerid_Internalname = sPrefix+"vCUSTOMERID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtavCustomerid_Jsonclick = "";
         edtavCustomerid_Visible = 1;
         bttBtnwizardfirstprevious_Visible = 1;
         edtavCustomervisitingaddress_Enabled = 1;
         edtavCustomerpostaladdress_Enabled = 1;
         edtavCustomerphone_Jsonclick = "";
         edtavCustomerphone_Enabled = 1;
         edtavCustomeremail_Jsonclick = "";
         edtavCustomeremail_Enabled = 1;
         dynavCustomertypeid_Jsonclick = "";
         dynavCustomertypeid.Enabled = 1;
         edtavCustomervatnumber_Jsonclick = "";
         edtavCustomervatnumber_Enabled = 1;
         edtavCustomername_Jsonclick = "";
         edtavCustomername_Enabled = 1;
         edtavCustomerkvknumber_Jsonclick = "";
         edtavCustomerkvknumber_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV16GoingBack","fld":"vGOINGBACK"},{"av":"dynavCustomertypeid"},{"av":"AV12CustomerTypeId","fld":"vCUSTOMERTYPEID","pic":"ZZZ9"},{"av":"AV17HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E132E2","iparms":[{"av":"AV25CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV17HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV8CustomerKvkNumber","fld":"vCUSTOMERKVKNUMBER"},{"av":"AV9CustomerName","fld":"vCUSTOMERNAME"},{"av":"AV14CustomerVatNumber","fld":"vCUSTOMERVATNUMBER"},{"av":"dynavCustomertypeid"},{"av":"AV12CustomerTypeId","fld":"vCUSTOMERTYPEID","pic":"ZZZ9"},{"av":"AV21WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV7CustomerId","fld":"vCUSTOMERID","pic":"ZZZ9"},{"av":"AV6CustomerEmail","fld":"vCUSTOMEREMAIL"},{"av":"AV10CustomerPhone","fld":"vCUSTOMERPHONE"},{"av":"AV11CustomerPostalAddress","fld":"vCUSTOMERPOSTALADDRESS"},{"av":"AV15CustomerVisitingAddress","fld":"vCUSTOMERVISITINGADDRESS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV25CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E142E2","iparms":[]}""");
         setEventMetadata("VALIDV_CUSTOMEREMAIL","""{"handler":"Validv_Customeremail","iparms":[]}""");
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
         wcpOAV18PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV8CustomerKvkNumber = "";
         AV9CustomerName = "";
         AV14CustomerVatNumber = "";
         AV6CustomerEmail = "";
         AV10CustomerPhone = "";
         AV11CustomerPostalAddress = "";
         AV15CustomerVisitingAddress = "";
         bttBtnwizardfirstprevious_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002E2_A78CustomerTypeId = new short[1] ;
         H002E2_A79CustomerTypeName = new string[] {""} ;
         AV22WizardData = new SdtCreateCustomerData(context);
         AV20WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV21WebSessionKey = "";
         sCtrlAV18PreviousStep = "";
         sCtrlAV16GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createcustomerstep1__default(),
            new Object[][] {
                new Object[] {
               H002E2_A78CustomerTypeId, H002E2_A79CustomerTypeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV12CustomerTypeId ;
      private short AV7CustomerId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavCustomerkvknumber_Enabled ;
      private int edtavCustomername_Enabled ;
      private int edtavCustomervatnumber_Enabled ;
      private int edtavCustomeremail_Enabled ;
      private int edtavCustomerphone_Enabled ;
      private int edtavCustomerpostaladdress_Enabled ;
      private int edtavCustomervisitingaddress_Enabled ;
      private int bttBtnwizardfirstprevious_Visible ;
      private int edtavCustomerid_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavCustomerkvknumber_Internalname ;
      private string TempTags ;
      private string edtavCustomerkvknumber_Jsonclick ;
      private string edtavCustomername_Internalname ;
      private string edtavCustomername_Jsonclick ;
      private string edtavCustomervatnumber_Internalname ;
      private string edtavCustomervatnumber_Jsonclick ;
      private string dynavCustomertypeid_Internalname ;
      private string dynavCustomertypeid_Jsonclick ;
      private string edtavCustomeremail_Internalname ;
      private string edtavCustomeremail_Jsonclick ;
      private string edtavCustomerphone_Internalname ;
      private string AV10CustomerPhone ;
      private string edtavCustomerphone_Jsonclick ;
      private string edtavCustomerpostaladdress_Internalname ;
      private string edtavCustomervisitingaddress_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtnwizardfirstprevious_Internalname ;
      private string bttBtnwizardfirstprevious_Jsonclick ;
      private string bttBtnwizardnext_Internalname ;
      private string bttBtnwizardnext_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavCustomerid_Internalname ;
      private string edtavCustomerid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string sCtrlAV21WebSessionKey ;
      private string sCtrlAV18PreviousStep ;
      private string sCtrlAV16GoingBack ;
      private bool AV16GoingBack ;
      private bool wcpOAV16GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17HasValidationErrors ;
      private bool AV25CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV21WebSessionKey ;
      private string AV18PreviousStep ;
      private string wcpOAV21WebSessionKey ;
      private string wcpOAV18PreviousStep ;
      private string AV8CustomerKvkNumber ;
      private string AV9CustomerName ;
      private string AV14CustomerVatNumber ;
      private string AV6CustomerEmail ;
      private string AV11CustomerPostalAddress ;
      private string AV15CustomerVisitingAddress ;
      private IGxSession AV20WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCustomertypeid ;
      private IDataStoreProvider pr_default ;
      private short[] H002E2_A78CustomerTypeId ;
      private string[] H002E2_A79CustomerTypeName ;
      private SdtCreateCustomerData AV22WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class createcustomerstep1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002E2;
          prmH002E2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002E2", "SELECT CustomerTypeId, CustomerTypeName FROM CustomerType ORDER BY CustomerTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E2,0, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
