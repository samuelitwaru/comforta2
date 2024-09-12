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
   public class createresidentstep1 : GXWebComponent
   {
      public createresidentstep1( )
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

      public createresidentstep1( IGxContext context )
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
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
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
         cmbavResidentgender = new GXCombobox();
         dynavResidenttypeid = new GXCombobox();
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
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vRESIDENTTYPEID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLVvRESIDENTTYPEID2U2( ) ;
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
            PA2U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               GXVvRESIDENTTYPEID_html2U2( ) ;
               WS2U2( ) ;
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
            context.SendWebValue( "Create Resident Step1") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createresidentstep1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6WebSessionKey)),UrlEncode(StringUtil.RTrim(AV8PreviousStep)),UrlEncode(StringUtil.BoolToStr(AV7GoingBack))}, new string[] {"WebSessionKey","PreviousStep","GoingBack"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV22CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
      }

      protected void RenderHtmlCloseForm2U2( )
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
         return "CreateResidentStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Create Resident Step1" ;
      }

      protected void WB2U0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "createresidentstep1.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbsnnumber_Internalname, "BSN Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentbsnnumber_Internalname, AV13ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV13ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentbsnnumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentgivenname_Internalname, "Given Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentgivenname_Internalname, AV14ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( AV14ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentgivenname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentlastname_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentlastname_Internalname, AV15ResidentLastName, StringUtil.RTrim( context.localUtil.Format( AV15ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentlastname_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentgender_Internalname, "Gender", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentgender, cmbavResidentgender_Internalname, StringUtil.RTrim( AV21ResidentGender), 1, cmbavResidentgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavResidentgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_CreateResidentStep1.htm");
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV21ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", (string)(cmbavResidentgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentemail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentemail_Internalname, AV17ResidentEmail, StringUtil.RTrim( context.localUtil.Format( AV17ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphone_Internalname, StringUtil.RTrim( AV18ResidentPhone), StringUtil.RTrim( context.localUtil.Format( AV18ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavResidenttypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavResidenttypeid_Internalname, "Type", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavResidenttypeid, dynavResidenttypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResidentTypeId), 4, 0)), 1, dynavResidenttypeid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavResidenttypeid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_CreateResidentStep1.htm");
            dynavResidenttypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResidentTypeId), 4, 0));
            AssignProp(sPrefix, false, dynavResidenttypeid_Internalname, "Values", (string)(dynavResidenttypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddress_Internalname, "Address", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavResidentaddress_Internalname, AV20ResidentAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtavResidentaddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", "", 0, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CreateResidentStep1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnwizardfirstprevious_Internalname, "", "Cancel", bttBtnwizardfirstprevious_Jsonclick, 5, "Cancel", "", StyleString, ClassString, bttBtnwizardfirstprevious_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDPREVIOUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "", "Next", bttBtnwizardnext_Jsonclick, 5, "Next", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateResidentStep1.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavResidentid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ResidentId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12ResidentId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateResidentStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentinitials_Internalname, StringUtil.RTrim( AV16ResidentInitials), StringUtil.RTrim( context.localUtil.Format( AV16ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateResidentStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2U2( )
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
            Form.Meta.addItem("description", "Create Resident Step1", 0) ;
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
               STRUP2U0( ) ;
            }
         }
      }

      protected void WS2U2( )
      {
         START2U2( ) ;
         EVT2U2( ) ;
      }

      protected void EVT2U2( )
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
                                 STRUP2U0( ) ;
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
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E122U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
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
                                          E132U2 ();
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
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E142U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E152U2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResidentbsnnumber_Internalname;
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

      protected void WE2U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2U2( ) ;
            }
         }
      }

      protected void PA2U2( )
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
               GX_FocusControl = edtavResidentbsnnumber_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvRESIDENTTYPEID2U2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvRESIDENTTYPEID_data2U2( ) ;
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

      protected void GXVvRESIDENTTYPEID_html2U2( )
      {
         short gxdynajaxvalue;
         GXDLVvRESIDENTTYPEID_data2U2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavResidenttypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavResidenttypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvRESIDENTTYPEID_data2U2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Select Type");
         /* Using cursor H002U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002U2_A82ResidentTypeId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002U2_A83ResidentTypeName[0]);
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
            GXVvRESIDENTTYPEID_html2U2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavResidentgender.ItemCount > 0 )
         {
            AV21ResidentGender = cmbavResidentgender.getValidValue(AV21ResidentGender);
            AssignAttri(sPrefix, false, "AV21ResidentGender", AV21ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV21ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", cmbavResidentgender.ToJavascriptSource(), true);
         }
         if ( dynavResidenttypeid.ItemCount > 0 )
         {
            AV19ResidentTypeId = (short)(Math.Round(NumberUtil.Val( dynavResidenttypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResidentTypeId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19ResidentTypeId", StringUtil.LTrimStr( (decimal)(AV19ResidentTypeId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavResidenttypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResidentTypeId), 4, 0));
            AssignProp(sPrefix, false, dynavResidenttypeid_Internalname, "Values", dynavResidenttypeid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122U2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152U2 ();
            WB2U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2U2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         GXVvRESIDENTTYPEID_html2U2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112U2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            /* Read variables values. */
            AV13ResidentBsnNumber = cgiGet( edtavResidentbsnnumber_Internalname);
            AssignAttri(sPrefix, false, "AV13ResidentBsnNumber", AV13ResidentBsnNumber);
            AV14ResidentGivenName = cgiGet( edtavResidentgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV14ResidentGivenName", AV14ResidentGivenName);
            AV15ResidentLastName = cgiGet( edtavResidentlastname_Internalname);
            AssignAttri(sPrefix, false, "AV15ResidentLastName", AV15ResidentLastName);
            cmbavResidentgender.CurrentValue = cgiGet( cmbavResidentgender_Internalname);
            AV21ResidentGender = cgiGet( cmbavResidentgender_Internalname);
            AssignAttri(sPrefix, false, "AV21ResidentGender", AV21ResidentGender);
            AV17ResidentEmail = cgiGet( edtavResidentemail_Internalname);
            AssignAttri(sPrefix, false, "AV17ResidentEmail", AV17ResidentEmail);
            AV18ResidentPhone = cgiGet( edtavResidentphone_Internalname);
            AssignAttri(sPrefix, false, "AV18ResidentPhone", AV18ResidentPhone);
            dynavResidenttypeid.CurrentValue = cgiGet( dynavResidenttypeid_Internalname);
            AV19ResidentTypeId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavResidenttypeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19ResidentTypeId", StringUtil.LTrimStr( (decimal)(AV19ResidentTypeId), 4, 0));
            AV20ResidentAddress = cgiGet( edtavResidentaddress_Internalname);
            AssignAttri(sPrefix, false, "AV20ResidentAddress", AV20ResidentAddress);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResidentid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResidentid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESIDENTID");
               GX_FocusControl = edtavResidentid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ResidentId = 0;
               AssignAttri(sPrefix, false, "AV12ResidentId", StringUtil.LTrimStr( (decimal)(AV12ResidentId), 4, 0));
            }
            else
            {
               AV12ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResidentid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV12ResidentId", StringUtil.LTrimStr( (decimal)(AV12ResidentId), 4, 0));
            }
            AV16ResidentInitials = cgiGet( edtavResidentinitials_Internalname);
            AssignAttri(sPrefix, false, "AV16ResidentInitials", AV16ResidentInitials);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvRESIDENTTYPEID_html2U2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E112U2 ();
         if (returnInSub) return;
      }

      protected void E112U2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavResidentid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentid_Visible), 5, 0), true);
         edtavResidentinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentinitials_Visible), 5, 0), true);
      }

      protected void E122U2( )
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
         E132U2 ();
         if (returnInSub) return;
      }

      protected void E132U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV22CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            CallWebObject(formatLink("createresident.aspx", new object[] {UrlEncode(StringUtil.RTrim("Step1")),UrlEncode(StringUtil.RTrim("Step2")),UrlEncode(StringUtil.BoolToStr(false))}, new string[] {"PreviousStep","CurrentStep","GoingBack"}) );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E142U2( )
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
         if ( ! ( ! AV7GoingBack ) )
         {
            bttBtnwizardfirstprevious_Visible = 0;
            AssignProp(sPrefix, false, bttBtnwizardfirstprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardfirstprevious_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12ResidentId = AV11WizardData.gxTpr_Step1.gxTpr_Residentid;
         AssignAttri(sPrefix, false, "AV12ResidentId", StringUtil.LTrimStr( (decimal)(AV12ResidentId), 4, 0));
         AV13ResidentBsnNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber;
         AssignAttri(sPrefix, false, "AV13ResidentBsnNumber", AV13ResidentBsnNumber);
         AV14ResidentGivenName = AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname;
         AssignAttri(sPrefix, false, "AV14ResidentGivenName", AV14ResidentGivenName);
         AV15ResidentLastName = AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname;
         AssignAttri(sPrefix, false, "AV15ResidentLastName", AV15ResidentLastName);
         AV21ResidentGender = AV11WizardData.gxTpr_Step1.gxTpr_Residentgender;
         AssignAttri(sPrefix, false, "AV21ResidentGender", AV21ResidentGender);
         AV16ResidentInitials = AV11WizardData.gxTpr_Step1.gxTpr_Residentinitials;
         AssignAttri(sPrefix, false, "AV16ResidentInitials", AV16ResidentInitials);
         AV17ResidentEmail = AV11WizardData.gxTpr_Step1.gxTpr_Residentemail;
         AssignAttri(sPrefix, false, "AV17ResidentEmail", AV17ResidentEmail);
         AV18ResidentPhone = AV11WizardData.gxTpr_Step1.gxTpr_Residentphone;
         AssignAttri(sPrefix, false, "AV18ResidentPhone", AV18ResidentPhone);
         AV19ResidentTypeId = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid;
         AssignAttri(sPrefix, false, "AV19ResidentTypeId", StringUtil.LTrimStr( (decimal)(AV19ResidentTypeId), 4, 0));
         AV20ResidentAddress = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddress;
         AssignAttri(sPrefix, false, "AV20ResidentAddress", AV20ResidentAddress);
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Residentid = AV12ResidentId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber = AV13ResidentBsnNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname = AV14ResidentGivenName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname = AV15ResidentLastName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgender = AV21ResidentGender;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentinitials = AV16ResidentInitials;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentemail = AV17ResidentEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphone = AV18ResidentPhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid = AV19ResidentTypeId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentaddress = AV20ResidentAddress;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV22CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ResidentBsnNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "BSN Number", "", "", "", "", "", "", "", ""),  "error",  edtavResidentbsnnumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ResidentGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Given Name", "", "", "", "", "", "", "", ""),  "error",  edtavResidentgivenname_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ResidentLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Last Name", "", "", "", "", "", "", "", ""),  "error",  edtavResidentlastname_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21ResidentGender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Gender", "", "", "", "", "", "", "", ""),  "error",  cmbavResidentgender_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ResidentEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( (0==AV19ResidentTypeId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Resident Type is required",  "error",  dynavResidenttypeid_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E152U2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA2U2( ) ;
         WS2U2( ) ;
         WE2U2( ) ;
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
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "createresidentstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2U2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
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
         PA2U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2U2( ) ;
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
         WS2U2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
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
         WE2U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912628404", true, true);
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
         context.AddJavascriptSource("createresidentstep1.js", "?2024912628405", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResidentgender.Name = "vRESIDENTGENDER";
         cmbavResidentgender.WebTags = "";
         cmbavResidentgender.addItem("Man", "Man", 0);
         cmbavResidentgender.addItem("Woman", "Woman", 0);
         cmbavResidentgender.addItem("Other", "Other", 0);
         if ( cmbavResidentgender.ItemCount > 0 )
         {
         }
         dynavResidenttypeid.Name = "vRESIDENTTYPEID";
         dynavResidenttypeid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavResidentbsnnumber_Internalname = sPrefix+"vRESIDENTBSNNUMBER";
         edtavResidentgivenname_Internalname = sPrefix+"vRESIDENTGIVENNAME";
         edtavResidentlastname_Internalname = sPrefix+"vRESIDENTLASTNAME";
         cmbavResidentgender_Internalname = sPrefix+"vRESIDENTGENDER";
         edtavResidentemail_Internalname = sPrefix+"vRESIDENTEMAIL";
         edtavResidentphone_Internalname = sPrefix+"vRESIDENTPHONE";
         dynavResidenttypeid_Internalname = sPrefix+"vRESIDENTTYPEID";
         edtavResidentaddress_Internalname = sPrefix+"vRESIDENTADDRESS";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         bttBtnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResidentid_Internalname = sPrefix+"vRESIDENTID";
         edtavResidentinitials_Internalname = sPrefix+"vRESIDENTINITIALS";
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
         edtavResidentinitials_Jsonclick = "";
         edtavResidentinitials_Visible = 1;
         edtavResidentid_Jsonclick = "";
         edtavResidentid_Visible = 1;
         bttBtnwizardfirstprevious_Visible = 1;
         edtavResidentaddress_Enabled = 1;
         dynavResidenttypeid_Jsonclick = "";
         dynavResidenttypeid.Enabled = 1;
         edtavResidentphone_Jsonclick = "";
         edtavResidentphone_Enabled = 1;
         edtavResidentemail_Jsonclick = "";
         edtavResidentemail_Enabled = 1;
         cmbavResidentgender_Jsonclick = "";
         cmbavResidentgender.Enabled = 1;
         edtavResidentlastname_Jsonclick = "";
         edtavResidentlastname_Enabled = 1;
         edtavResidentgivenname_Jsonclick = "";
         edtavResidentgivenname_Enabled = 1;
         edtavResidentbsnnumber_Jsonclick = "";
         edtavResidentbsnnumber_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"dynavResidenttypeid"},{"av":"AV19ResidentTypeId","fld":"vRESIDENTTYPEID","pic":"ZZZ9"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E132U2","iparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV13ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"},{"av":"AV14ResidentGivenName","fld":"vRESIDENTGIVENNAME"},{"av":"AV15ResidentLastName","fld":"vRESIDENTLASTNAME"},{"av":"cmbavResidentgender"},{"av":"AV21ResidentGender","fld":"vRESIDENTGENDER"},{"av":"AV17ResidentEmail","fld":"vRESIDENTEMAIL"},{"av":"dynavResidenttypeid"},{"av":"AV19ResidentTypeId","fld":"vRESIDENTTYPEID","pic":"ZZZ9"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV12ResidentId","fld":"vRESIDENTID","pic":"ZZZ9"},{"av":"AV16ResidentInitials","fld":"vRESIDENTINITIALS"},{"av":"AV18ResidentPhone","fld":"vRESIDENTPHONE"},{"av":"AV20ResidentAddress","fld":"vRESIDENTADDRESS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E142U2","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTGENDER","""{"handler":"Validv_Residentgender","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTEMAIL","""{"handler":"Validv_Residentemail","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
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
         AV13ResidentBsnNumber = "";
         AV14ResidentGivenName = "";
         AV15ResidentLastName = "";
         AV21ResidentGender = "";
         AV17ResidentEmail = "";
         AV18ResidentPhone = "";
         AV20ResidentAddress = "";
         bttBtnwizardfirstprevious_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         AV16ResidentInitials = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002U2_A82ResidentTypeId = new short[1] ;
         H002U2_A83ResidentTypeName = new string[] {""} ;
         AV11WizardData = new SdtCreateResidentData(context);
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createresidentstep1__default(),
            new Object[][] {
                new Object[] {
               H002U2_A82ResidentTypeId, H002U2_A83ResidentTypeName
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
      private short AV19ResidentTypeId ;
      private short AV12ResidentId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavResidentbsnnumber_Enabled ;
      private int edtavResidentgivenname_Enabled ;
      private int edtavResidentlastname_Enabled ;
      private int edtavResidentemail_Enabled ;
      private int edtavResidentphone_Enabled ;
      private int edtavResidentaddress_Enabled ;
      private int bttBtnwizardfirstprevious_Visible ;
      private int edtavResidentid_Visible ;
      private int edtavResidentinitials_Visible ;
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
      private string edtavResidentbsnnumber_Internalname ;
      private string TempTags ;
      private string edtavResidentbsnnumber_Jsonclick ;
      private string edtavResidentgivenname_Internalname ;
      private string edtavResidentgivenname_Jsonclick ;
      private string edtavResidentlastname_Internalname ;
      private string edtavResidentlastname_Jsonclick ;
      private string cmbavResidentgender_Internalname ;
      private string AV21ResidentGender ;
      private string cmbavResidentgender_Jsonclick ;
      private string edtavResidentemail_Internalname ;
      private string edtavResidentemail_Jsonclick ;
      private string edtavResidentphone_Internalname ;
      private string AV18ResidentPhone ;
      private string edtavResidentphone_Jsonclick ;
      private string dynavResidenttypeid_Internalname ;
      private string dynavResidenttypeid_Jsonclick ;
      private string edtavResidentaddress_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtnwizardfirstprevious_Internalname ;
      private string bttBtnwizardfirstprevious_Jsonclick ;
      private string bttBtnwizardnext_Internalname ;
      private string bttBtnwizardnext_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResidentid_Internalname ;
      private string edtavResidentid_Jsonclick ;
      private string edtavResidentinitials_Internalname ;
      private string AV16ResidentInitials ;
      private string edtavResidentinitials_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV22CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV13ResidentBsnNumber ;
      private string AV14ResidentGivenName ;
      private string AV15ResidentLastName ;
      private string AV17ResidentEmail ;
      private string AV20ResidentAddress ;
      private IGxSession AV5WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResidentgender ;
      private GXCombobox dynavResidenttypeid ;
      private IDataStoreProvider pr_default ;
      private short[] H002U2_A82ResidentTypeId ;
      private string[] H002U2_A83ResidentTypeName ;
      private SdtCreateResidentData AV11WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class createresidentstep1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002U2;
          prmH002U2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002U2", "SELECT ResidentTypeId, ResidentTypeName FROM ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U2,0, GxCacheFrequency.OFF ,true,false )
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
