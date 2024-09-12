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
   public class customercustomizationgeneral : GXWebComponent
   {
      public customercustomizationgeneral( )
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

      public customercustomizationgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CustomerCustomizationId )
      {
         this.A128CustomerCustomizationId = aP0_CustomerCustomizationId;
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
         cmbCustomerCustomizationFontSize = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "CustomerCustomizationId");
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
                  A128CustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerCustomizationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A128CustomerCustomizationId});
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
                  gxfirstwebparm = GetFirstPar( "CustomerCustomizationId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CustomerCustomizationId");
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
            PA3O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "CustomerCustomizationGeneral";
               WS3O2( ) ;
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
            context.SendWebValue( "Customer Customization General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customercustomizationgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A128CustomerCustomizationId,4,0))}, new string[] {"CustomerCustomizationId"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA128CustomerCustomizationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA128CustomerCustomizationId), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm3O2( )
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
         return "CustomerCustomizationGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Customer Customization General" ;
      }

      protected void WB3O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "customercustomizationgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCustomerName_Internalname, "Customer Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A3CustomerName, StringUtil.RTrim( context.localUtil.Format( A3CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_CustomerCustomizationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableform_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCustomerCustomizationLogo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Customer Logo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A129CustomerCustomizationLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CustomerCustomizationLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.PathToRelativeUrl( A129CustomerCustomizationLogo));
            GxWebStd.gx_bitmap( context, imgCustomerCustomizationLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A129CustomerCustomizationLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CustomerCustomizationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCustomerCustomizationFavicon_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Customization Favicon", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A130CustomerCustomizationFavicon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001CustomerCustomizationFavicon_G)))||!String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.PathToRelativeUrl( A130CustomerCustomizationFavicon));
            GxWebStd.gx_bitmap( context, imgCustomerCustomizationFavicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A130CustomerCustomizationFavicon_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CustomerCustomizationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCustomerCustomizationFontSize_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbCustomerCustomizationFontSize_Internalname, "Font Size", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbCustomerCustomizationFontSize, cmbCustomerCustomizationFontSize_Internalname, StringUtil.RTrim( A132CustomerCustomizationFontSize), 1, cmbCustomerCustomizationFontSize_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbCustomerCustomizationFontSize.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_CustomerCustomizationGeneral.htm");
            cmbCustomerCustomizationFontSize.CurrentValue = StringUtil.RTrim( A132CustomerCustomizationFontSize);
            AssignProp(sPrefix, false, cmbCustomerCustomizationFontSize_Internalname, "Values", (string)(cmbCustomerCustomizationFontSize.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock1_Internalname, "Color Theme", "", "", lblTransactiondetail_textblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_CustomerCustomizationGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTransactiondetail_actionstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e113o1_client"+"'", TempTags, "", 2, "HLP_CustomerCustomizationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e123o1_client"+"'", TempTags, "", 2, "HLP_CustomerCustomizationGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CustomerCustomizationGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCustomerCustomizationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerCustomizationId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerCustomizationId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CustomerCustomizationGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCustomerCustomizationBaseColor_Internalname, A131CustomerCustomizationBaseColor, StringUtil.RTrim( context.localUtil.Format( A131CustomerCustomizationBaseColor, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerCustomizationBaseColor_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerCustomizationBaseColor_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CustomerCustomizationGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3O2( )
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
            Form.Meta.addItem("description", "Customer Customization General", 0) ;
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
               STRUP3O0( ) ;
            }
         }
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                                 STRUP3O0( ) ;
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
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E133O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E143O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3O0( ) ;
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
                                 STRUP3O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE3O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3O2( ) ;
            }
         }
      }

      protected void PA3O2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         if ( cmbCustomerCustomizationFontSize.ItemCount > 0 )
         {
            A132CustomerCustomizationFontSize = cmbCustomerCustomizationFontSize.getValidValue(A132CustomerCustomizationFontSize);
            AssignAttri(sPrefix, false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCustomerCustomizationFontSize.CurrentValue = StringUtil.RTrim( A132CustomerCustomizationFontSize);
            AssignProp(sPrefix, false, cmbCustomerCustomizationFontSize_Internalname, "Values", cmbCustomerCustomizationFontSize.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "CustomerCustomizationGeneral";
      }

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003O2 */
            pr_default.execute(0, new Object[] {A128CustomerCustomizationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A131CustomerCustomizationBaseColor = H003O2_A131CustomerCustomizationBaseColor[0];
               AssignAttri(sPrefix, false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
               A1CustomerId = H003O2_A1CustomerId[0];
               AssignAttri(sPrefix, false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               A132CustomerCustomizationFontSize = H003O2_A132CustomerCustomizationFontSize[0];
               AssignAttri(sPrefix, false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
               A40001CustomerCustomizationFavicon_G = H003O2_A40001CustomerCustomizationFavicon_G[0];
               AssignProp(sPrefix, false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
               AssignProp(sPrefix, false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
               A40000CustomerCustomizationLogo_GXI = H003O2_A40000CustomerCustomizationLogo_GXI[0];
               AssignProp(sPrefix, false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
               AssignProp(sPrefix, false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
               A3CustomerName = H003O2_A3CustomerName[0];
               AssignAttri(sPrefix, false, "A3CustomerName", A3CustomerName);
               A130CustomerCustomizationFavicon = H003O2_A130CustomerCustomizationFavicon[0];
               AssignAttri(sPrefix, false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
               AssignProp(sPrefix, false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
               AssignProp(sPrefix, false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
               A129CustomerCustomizationLogo = H003O2_A129CustomerCustomizationLogo[0];
               AssignAttri(sPrefix, false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
               AssignProp(sPrefix, false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
               AssignProp(sPrefix, false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
               A3CustomerName = H003O2_A3CustomerName[0];
               AssignAttri(sPrefix, false, "A3CustomerName", A3CustomerName);
               /* Execute user event: Load */
               E143O2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "CustomerCustomizationGeneral";
         edtCustomerName_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         imgCustomerCustomizationLogo_Enabled = 0;
         AssignProp(sPrefix, false, imgCustomerCustomizationLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCustomerCustomizationLogo_Enabled), 5, 0), true);
         imgCustomerCustomizationFavicon_Enabled = 0;
         AssignProp(sPrefix, false, imgCustomerCustomizationFavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCustomerCustomizationFavicon_Enabled), 5, 0), true);
         cmbCustomerCustomizationFontSize.Enabled = 0;
         AssignProp(sPrefix, false, cmbCustomerCustomizationFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCustomerCustomizationFontSize.Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerCustomizationId_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerCustomizationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Enabled), 5, 0), true);
         edtCustomerCustomizationBaseColor_Enabled = 0;
         AssignProp(sPrefix, false, edtCustomerCustomizationBaseColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA128CustomerCustomizationId"), ".", ","), 18, MidpointRounding.ToEven));
            AV13IsAuthorized_Delete = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_DELETE"));
            AV12IsAuthorized_Update = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_UPDATE"));
            /* Read variables values. */
            A3CustomerName = cgiGet( edtCustomerName_Internalname);
            AssignAttri(sPrefix, false, "A3CustomerName", A3CustomerName);
            A129CustomerCustomizationLogo = cgiGet( imgCustomerCustomizationLogo_Internalname);
            AssignAttri(sPrefix, false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
            A130CustomerCustomizationFavicon = cgiGet( imgCustomerCustomizationFavicon_Internalname);
            AssignAttri(sPrefix, false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
            cmbCustomerCustomizationFontSize.CurrentValue = cgiGet( cmbCustomerCustomizationFontSize_Internalname);
            A132CustomerCustomizationFontSize = cgiGet( cmbCustomerCustomizationFontSize_Internalname);
            AssignAttri(sPrefix, false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
            A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A131CustomerCustomizationBaseColor = cgiGet( edtCustomerCustomizationBaseColor_Internalname);
            AssignAttri(sPrefix, false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E133O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E133O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E143O2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCustomerId_Visible = 0;
         AssignProp(sPrefix, false, edtCustomerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerId_Visible), 5, 0), true);
         edtCustomerCustomizationId_Visible = 0;
         AssignProp(sPrefix, false, edtCustomerCustomizationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Visible), 5, 0), true);
         edtCustomerCustomizationBaseColor_Visible = 0;
         AssignProp(sPrefix, false, edtCustomerCustomizationBaseColor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomization_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "customercustomization_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "CustomerCustomization";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A128CustomerCustomizationId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
         sCtrlA128CustomerCustomizationId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "customercustomizationgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A128CustomerCustomizationId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         }
         wcpOA128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA128CustomerCustomizationId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A128CustomerCustomizationId != wcpOA128CustomerCustomizationId ) ) )
         {
            setjustcreated();
         }
         wcpOA128CustomerCustomizationId = A128CustomerCustomizationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA128CustomerCustomizationId = cgiGet( sPrefix+"A128CustomerCustomizationId_CTRL");
         if ( StringUtil.Len( sCtrlA128CustomerCustomizationId) > 0 )
         {
            A128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA128CustomerCustomizationId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         }
         else
         {
            A128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A128CustomerCustomizationId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA3O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3O2( ) ;
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
         WS3O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A128CustomerCustomizationId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA128CustomerCustomizationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A128CustomerCustomizationId_CTRL", StringUtil.RTrim( sCtrlA128CustomerCustomizationId));
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
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126301238", true, true);
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
         context.AddJavascriptSource("customercustomizationgeneral.js", "?20249126301238", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbCustomerCustomizationFontSize.Name = "CUSTOMERCUSTOMIZATIONFONTSIZE";
         cmbCustomerCustomizationFontSize.WebTags = "";
         cmbCustomerCustomizationFontSize.addItem("", "Select Font Size", 0);
         cmbCustomerCustomizationFontSize.addItem("Small", "Small", 0);
         cmbCustomerCustomizationFontSize.addItem("Medium", "Medium", 0);
         cmbCustomerCustomizationFontSize.addItem("Large", "Large", 0);
         if ( cmbCustomerCustomizationFontSize.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtCustomerName_Internalname = sPrefix+"CUSTOMERNAME";
         imgCustomerCustomizationLogo_Internalname = sPrefix+"CUSTOMERCUSTOMIZATIONLOGO";
         imgCustomerCustomizationFavicon_Internalname = sPrefix+"CUSTOMERCUSTOMIZATIONFAVICON";
         cmbCustomerCustomizationFontSize_Internalname = sPrefix+"CUSTOMERCUSTOMIZATIONFONTSIZE";
         lblTransactiondetail_textblock1_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK1";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTransactiondetail_tableform_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEFORM";
         divTransactiondetail_actionstable_Internalname = sPrefix+"TRANSACTIONDETAIL_ACTIONSTABLE";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtCustomerId_Internalname = sPrefix+"CUSTOMERID";
         edtCustomerCustomizationId_Internalname = sPrefix+"CUSTOMERCUSTOMIZATIONID";
         edtCustomerCustomizationBaseColor_Internalname = sPrefix+"CUSTOMERCUSTOMIZATIONBASECOLOR";
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
         edtCustomerCustomizationBaseColor_Enabled = 0;
         edtCustomerCustomizationId_Enabled = 0;
         edtCustomerId_Enabled = 0;
         imgCustomerCustomizationFavicon_Enabled = 0;
         imgCustomerCustomizationLogo_Enabled = 0;
         edtCustomerCustomizationBaseColor_Jsonclick = "";
         edtCustomerCustomizationBaseColor_Visible = 1;
         edtCustomerCustomizationId_Jsonclick = "";
         edtCustomerCustomizationId_Visible = 1;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         cmbCustomerCustomizationFontSize_Jsonclick = "";
         cmbCustomerCustomizationFontSize.Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A128CustomerCustomizationId","fld":"CUSTOMERCUSTOMIZATIONID","pic":"ZZZ9"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E113O1","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A128CustomerCustomizationId","fld":"CUSTOMERCUSTOMIZATIONID","pic":"ZZZ9"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E123O1","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A128CustomerCustomizationId","fld":"CUSTOMERCUSTOMIZATIONID","pic":"ZZZ9"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERCUSTOMIZATIONID","""{"handler":"Valid_Customercustomizationid","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         A3CustomerName = "";
         ClassString = "";
         StyleString = "";
         A129CustomerCustomizationLogo = "";
         A40000CustomerCustomizationLogo_GXI = "";
         sImgUrl = "";
         A130CustomerCustomizationFavicon = "";
         A40001CustomerCustomizationFavicon_G = "";
         A132CustomerCustomizationFontSize = "";
         lblTransactiondetail_textblock1_Jsonclick = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A131CustomerCustomizationBaseColor = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H003O2_A128CustomerCustomizationId = new short[1] ;
         H003O2_A131CustomerCustomizationBaseColor = new string[] {""} ;
         H003O2_A1CustomerId = new short[1] ;
         H003O2_A132CustomerCustomizationFontSize = new string[] {""} ;
         H003O2_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         H003O2_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         H003O2_A3CustomerName = new string[] {""} ;
         H003O2_A130CustomerCustomizationFavicon = new string[] {""} ;
         H003O2_A129CustomerCustomizationLogo = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA128CustomerCustomizationId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customercustomizationgeneral__default(),
            new Object[][] {
                new Object[] {
               H003O2_A128CustomerCustomizationId, H003O2_A131CustomerCustomizationBaseColor, H003O2_A1CustomerId, H003O2_A132CustomerCustomizationFontSize, H003O2_A40001CustomerCustomizationFavicon_G, H003O2_A40000CustomerCustomizationLogo_GXI, H003O2_A3CustomerName, H003O2_A130CustomerCustomizationFavicon, H003O2_A129CustomerCustomizationLogo
               }
            }
         );
         AV17Pgmname = "CustomerCustomizationGeneral";
         /* GeneXus formulas. */
         AV17Pgmname = "CustomerCustomizationGeneral";
      }

      private short A128CustomerCustomizationId ;
      private short wcpOA128CustomerCustomizationId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A1CustomerId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtCustomerName_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtCustomerId_Visible ;
      private int edtCustomerCustomizationId_Visible ;
      private int edtCustomerCustomizationBaseColor_Visible ;
      private int imgCustomerCustomizationLogo_Enabled ;
      private int imgCustomerCustomizationFavicon_Enabled ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerCustomizationId_Enabled ;
      private int edtCustomerCustomizationBaseColor_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV17Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtCustomerName_Internalname ;
      private string TempTags ;
      private string edtCustomerName_Jsonclick ;
      private string divTransactiondetail_tableform_Internalname ;
      private string imgCustomerCustomizationLogo_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgCustomerCustomizationFavicon_Internalname ;
      private string cmbCustomerCustomizationFontSize_Internalname ;
      private string cmbCustomerCustomizationFontSize_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTransactiondetail_textblock1_Internalname ;
      private string lblTransactiondetail_textblock1_Jsonclick ;
      private string divTransactiondetail_actionstable_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerCustomizationId_Internalname ;
      private string edtCustomerCustomizationId_Jsonclick ;
      private string edtCustomerCustomizationBaseColor_Internalname ;
      private string edtCustomerCustomizationBaseColor_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA128CustomerCustomizationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A129CustomerCustomizationLogo_IsBlob ;
      private bool A130CustomerCustomizationFavicon_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A3CustomerName ;
      private string A40000CustomerCustomizationLogo_GXI ;
      private string A40001CustomerCustomizationFavicon_G ;
      private string A132CustomerCustomizationFontSize ;
      private string A131CustomerCustomizationBaseColor ;
      private string A129CustomerCustomizationLogo ;
      private string A130CustomerCustomizationFavicon ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCustomerCustomizationFontSize ;
      private IDataStoreProvider pr_default ;
      private short[] H003O2_A128CustomerCustomizationId ;
      private string[] H003O2_A131CustomerCustomizationBaseColor ;
      private short[] H003O2_A1CustomerId ;
      private string[] H003O2_A132CustomerCustomizationFontSize ;
      private string[] H003O2_A40001CustomerCustomizationFavicon_G ;
      private string[] H003O2_A40000CustomerCustomizationLogo_GXI ;
      private string[] H003O2_A3CustomerName ;
      private string[] H003O2_A130CustomerCustomizationFavicon ;
      private string[] H003O2_A129CustomerCustomizationLogo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class customercustomizationgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003O2;
          prmH003O2 = new Object[] {
          new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003O2", "SELECT T1.CustomerCustomizationId, T1.CustomerCustomizationBaseColor, T1.CustomerId, T1.CustomerCustomizationFontSize, T1.CustomerCustomizationFavicon_G, T1.CustomerCustomizationLogo_GXI, T2.CustomerName, T1.CustomerCustomizationFavicon, T1.CustomerCustomizationLogo FROM (CustomerCustomization T1 INNER JOIN Customer T2 ON T2.CustomerId = T1.CustomerId) WHERE T1.CustomerCustomizationId = :CustomerCustomizationId ORDER BY T1.CustomerCustomizationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003O2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
                return;
       }
    }

 }

}
