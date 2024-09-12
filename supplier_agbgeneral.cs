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
   public class supplier_agbgeneral : GXWebComponent
   {
      public supplier_agbgeneral( )
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

      public supplier_agbgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Supplier_AgbId )
      {
         this.A55Supplier_AgbId = aP0_Supplier_AgbId;
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
               gxfirstwebparm = GetFirstPar( "Supplier_AgbId");
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
                  A55Supplier_AgbId = (short)(Math.Round(NumberUtil.Val( GetPar( "Supplier_AgbId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A55Supplier_AgbId", StringUtil.LTrimStr( (decimal)(A55Supplier_AgbId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A55Supplier_AgbId});
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
                  gxfirstwebparm = GetFirstPar( "Supplier_AgbId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Supplier_AgbId");
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
            PA272( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "Supplier_AgbGeneral";
               WS272( ) ;
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
            context.SendWebValue( "Supplier_Agb General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier_agbgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A55Supplier_AgbId,4,0))}, new string[] {"Supplier_AgbId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA55Supplier_AgbId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA55Supplier_AgbId), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm272( )
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
         return "Supplier_AgbGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Supplier_Agb General" ;
      }

      protected void WB270( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "supplier_agbgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbNumber_Internalname, "AGB Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbNumber_Internalname, A56Supplier_AgbNumber, StringUtil.RTrim( context.localUtil.Format( A56Supplier_AgbNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_AgbNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbNumber_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "AgbNumber", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbKvkNumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbKvkNumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbKvkNumber_Internalname, A58Supplier_AgbKvkNumber, StringUtil.RTrim( context.localUtil.Format( A58Supplier_AgbKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_AgbKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbKvkNumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbName_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbName_Internalname, A57Supplier_AgbName, StringUtil.RTrim( context.localUtil.Format( A57Supplier_AgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_AgbName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbEmail_Internalname, A61Supplier_AgbEmail, StringUtil.RTrim( context.localUtil.Format( A61Supplier_AgbEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A61Supplier_AgbEmail, "", "", "", edtSupplier_AgbEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbPhone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A62Supplier_AgbPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbPhone_Internalname, StringUtil.RTrim( A62Supplier_AgbPhone), StringUtil.RTrim( context.localUtil.Format( A62Supplier_AgbPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplier_AgbPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbContactName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbContactName_Internalname, "Contact Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbContactName_Internalname, A63Supplier_AgbContactName, StringUtil.RTrim( context.localUtil.Format( A63Supplier_AgbContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_AgbContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplier_AgbContactName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbVisitingAddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbVisitingAddress_Internalname, "Visiting Address", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSupplier_AgbVisitingAddress_Internalname, A59Supplier_AgbVisitingAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A59Supplier_AgbVisitingAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtSupplier_AgbVisitingAddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplier_AgbPostalAddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplier_AgbPostalAddress_Internalname, "Postal Address", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSupplier_AgbPostalAddress_Internalname, A60Supplier_AgbPostalAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A60Supplier_AgbPostalAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtSupplier_AgbPostalAddress_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Supplier_AgbGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11271_client"+"'", TempTags, "", 2, "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12271_client"+"'", TempTags, "", 2, "HLP_Supplier_AgbGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtSupplier_AgbId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A55Supplier_AgbId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplier_AgbId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplier_AgbId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Supplier_AgbGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START272( )
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
            Form.Meta.addItem("description", "Supplier_Agb General", 0) ;
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
               STRUP270( ) ;
            }
         }
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
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
                                 STRUP270( ) ;
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
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
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
                                 STRUP270( ) ;
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

      protected void WE272( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm272( ) ;
            }
         }
      }

      protected void PA272( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF272( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "Supplier_AgbGeneral";
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00272 */
            pr_default.execute(0, new Object[] {A55Supplier_AgbId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A60Supplier_AgbPostalAddress = H00272_A60Supplier_AgbPostalAddress[0];
               n60Supplier_AgbPostalAddress = H00272_n60Supplier_AgbPostalAddress[0];
               AssignAttri(sPrefix, false, "A60Supplier_AgbPostalAddress", A60Supplier_AgbPostalAddress);
               A59Supplier_AgbVisitingAddress = H00272_A59Supplier_AgbVisitingAddress[0];
               n59Supplier_AgbVisitingAddress = H00272_n59Supplier_AgbVisitingAddress[0];
               AssignAttri(sPrefix, false, "A59Supplier_AgbVisitingAddress", A59Supplier_AgbVisitingAddress);
               A63Supplier_AgbContactName = H00272_A63Supplier_AgbContactName[0];
               n63Supplier_AgbContactName = H00272_n63Supplier_AgbContactName[0];
               AssignAttri(sPrefix, false, "A63Supplier_AgbContactName", A63Supplier_AgbContactName);
               A62Supplier_AgbPhone = H00272_A62Supplier_AgbPhone[0];
               n62Supplier_AgbPhone = H00272_n62Supplier_AgbPhone[0];
               AssignAttri(sPrefix, false, "A62Supplier_AgbPhone", A62Supplier_AgbPhone);
               A61Supplier_AgbEmail = H00272_A61Supplier_AgbEmail[0];
               n61Supplier_AgbEmail = H00272_n61Supplier_AgbEmail[0];
               AssignAttri(sPrefix, false, "A61Supplier_AgbEmail", A61Supplier_AgbEmail);
               A57Supplier_AgbName = H00272_A57Supplier_AgbName[0];
               AssignAttri(sPrefix, false, "A57Supplier_AgbName", A57Supplier_AgbName);
               A58Supplier_AgbKvkNumber = H00272_A58Supplier_AgbKvkNumber[0];
               AssignAttri(sPrefix, false, "A58Supplier_AgbKvkNumber", A58Supplier_AgbKvkNumber);
               A56Supplier_AgbNumber = H00272_A56Supplier_AgbNumber[0];
               AssignAttri(sPrefix, false, "A56Supplier_AgbNumber", A56Supplier_AgbNumber);
               /* Execute user event: Load */
               E14272 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB270( ) ;
         }
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "Supplier_AgbGeneral";
         edtSupplier_AgbNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbNumber_Enabled), 5, 0), true);
         edtSupplier_AgbKvkNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbKvkNumber_Enabled), 5, 0), true);
         edtSupplier_AgbName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbName_Enabled), 5, 0), true);
         edtSupplier_AgbEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbEmail_Enabled), 5, 0), true);
         edtSupplier_AgbPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPhone_Enabled), 5, 0), true);
         edtSupplier_AgbContactName_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbContactName_Enabled), 5, 0), true);
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbVisitingAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbVisitingAddress_Enabled), 5, 0), true);
         edtSupplier_AgbPostalAddress_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbPostalAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbPostalAddress_Enabled), 5, 0), true);
         edtSupplier_AgbId_Enabled = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13272 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA55Supplier_AgbId"), ".", ","), 18, MidpointRounding.ToEven));
            AV13IsAuthorized_Delete = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_DELETE"));
            AV12IsAuthorized_Update = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_UPDATE"));
            /* Read variables values. */
            A56Supplier_AgbNumber = cgiGet( edtSupplier_AgbNumber_Internalname);
            AssignAttri(sPrefix, false, "A56Supplier_AgbNumber", A56Supplier_AgbNumber);
            A58Supplier_AgbKvkNumber = cgiGet( edtSupplier_AgbKvkNumber_Internalname);
            AssignAttri(sPrefix, false, "A58Supplier_AgbKvkNumber", A58Supplier_AgbKvkNumber);
            A57Supplier_AgbName = cgiGet( edtSupplier_AgbName_Internalname);
            AssignAttri(sPrefix, false, "A57Supplier_AgbName", A57Supplier_AgbName);
            A61Supplier_AgbEmail = cgiGet( edtSupplier_AgbEmail_Internalname);
            n61Supplier_AgbEmail = false;
            AssignAttri(sPrefix, false, "A61Supplier_AgbEmail", A61Supplier_AgbEmail);
            A62Supplier_AgbPhone = cgiGet( edtSupplier_AgbPhone_Internalname);
            n62Supplier_AgbPhone = false;
            AssignAttri(sPrefix, false, "A62Supplier_AgbPhone", A62Supplier_AgbPhone);
            A63Supplier_AgbContactName = cgiGet( edtSupplier_AgbContactName_Internalname);
            n63Supplier_AgbContactName = false;
            AssignAttri(sPrefix, false, "A63Supplier_AgbContactName", A63Supplier_AgbContactName);
            A59Supplier_AgbVisitingAddress = cgiGet( edtSupplier_AgbVisitingAddress_Internalname);
            n59Supplier_AgbVisitingAddress = false;
            AssignAttri(sPrefix, false, "A59Supplier_AgbVisitingAddress", A59Supplier_AgbVisitingAddress);
            A60Supplier_AgbPostalAddress = cgiGet( edtSupplier_AgbPostalAddress_Internalname);
            n60Supplier_AgbPostalAddress = false;
            AssignAttri(sPrefix, false, "A60Supplier_AgbPostalAddress", A60Supplier_AgbPostalAddress);
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
         E13272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13272( )
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

      protected void E14272( )
      {
         /* Load Routine */
         returnInSub = false;
         edtSupplier_AgbId_Visible = 0;
         AssignProp(sPrefix, false, edtSupplier_AgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplier_AgbId_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agb_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "supplier_agb_Delete", out  GXt_boolean1) ;
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
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Supplier_Agb";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A55Supplier_AgbId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A55Supplier_AgbId", StringUtil.LTrimStr( (decimal)(A55Supplier_AgbId), 4, 0));
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
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
         sCtrlA55Supplier_AgbId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA272( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "supplier_agbgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA272( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A55Supplier_AgbId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A55Supplier_AgbId", StringUtil.LTrimStr( (decimal)(A55Supplier_AgbId), 4, 0));
         }
         wcpOA55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA55Supplier_AgbId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A55Supplier_AgbId != wcpOA55Supplier_AgbId ) ) )
         {
            setjustcreated();
         }
         wcpOA55Supplier_AgbId = A55Supplier_AgbId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA55Supplier_AgbId = cgiGet( sPrefix+"A55Supplier_AgbId_CTRL");
         if ( StringUtil.Len( sCtrlA55Supplier_AgbId) > 0 )
         {
            A55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA55Supplier_AgbId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A55Supplier_AgbId", StringUtil.LTrimStr( (decimal)(A55Supplier_AgbId), 4, 0));
         }
         else
         {
            A55Supplier_AgbId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A55Supplier_AgbId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA272( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS272( ) ;
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
         WS272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A55Supplier_AgbId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55Supplier_AgbId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA55Supplier_AgbId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A55Supplier_AgbId_CTRL", StringUtil.RTrim( sCtrlA55Supplier_AgbId));
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
         WE272( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126295016", true, true);
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
         context.AddJavascriptSource("supplier_agbgeneral.js", "?20249126295016", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtSupplier_AgbNumber_Internalname = sPrefix+"SUPPLIER_AGBNUMBER";
         edtSupplier_AgbKvkNumber_Internalname = sPrefix+"SUPPLIER_AGBKVKNUMBER";
         edtSupplier_AgbName_Internalname = sPrefix+"SUPPLIER_AGBNAME";
         edtSupplier_AgbEmail_Internalname = sPrefix+"SUPPLIER_AGBEMAIL";
         edtSupplier_AgbPhone_Internalname = sPrefix+"SUPPLIER_AGBPHONE";
         edtSupplier_AgbContactName_Internalname = sPrefix+"SUPPLIER_AGBCONTACTNAME";
         edtSupplier_AgbVisitingAddress_Internalname = sPrefix+"SUPPLIER_AGBVISITINGADDRESS";
         edtSupplier_AgbPostalAddress_Internalname = sPrefix+"SUPPLIER_AGBPOSTALADDRESS";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtSupplier_AgbId_Internalname = sPrefix+"SUPPLIER_AGBID";
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
         edtSupplier_AgbId_Enabled = 0;
         edtSupplier_AgbId_Jsonclick = "";
         edtSupplier_AgbId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtSupplier_AgbPostalAddress_Enabled = 0;
         edtSupplier_AgbVisitingAddress_Enabled = 0;
         edtSupplier_AgbContactName_Jsonclick = "";
         edtSupplier_AgbContactName_Enabled = 0;
         edtSupplier_AgbPhone_Jsonclick = "";
         edtSupplier_AgbPhone_Enabled = 0;
         edtSupplier_AgbEmail_Jsonclick = "";
         edtSupplier_AgbEmail_Enabled = 0;
         edtSupplier_AgbName_Jsonclick = "";
         edtSupplier_AgbName_Enabled = 0;
         edtSupplier_AgbKvkNumber_Jsonclick = "";
         edtSupplier_AgbKvkNumber_Enabled = 0;
         edtSupplier_AgbNumber_Jsonclick = "";
         edtSupplier_AgbNumber_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A55Supplier_AgbId","fld":"SUPPLIER_AGBID","pic":"ZZZ9"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E11271","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A55Supplier_AgbId","fld":"SUPPLIER_AGBID","pic":"ZZZ9"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E12271","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A55Supplier_AgbId","fld":"SUPPLIER_AGBID","pic":"ZZZ9"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_SUPPLIER_AGBID","""{"handler":"Valid_Supplier_agbid","iparms":[]}""");
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
         AV14Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         A56Supplier_AgbNumber = "";
         A58Supplier_AgbKvkNumber = "";
         A57Supplier_AgbName = "";
         A61Supplier_AgbEmail = "";
         gxphoneLink = "";
         A62Supplier_AgbPhone = "";
         A63Supplier_AgbContactName = "";
         ClassString = "";
         StyleString = "";
         A59Supplier_AgbVisitingAddress = "";
         A60Supplier_AgbPostalAddress = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H00272_A55Supplier_AgbId = new short[1] ;
         H00272_A60Supplier_AgbPostalAddress = new string[] {""} ;
         H00272_n60Supplier_AgbPostalAddress = new bool[] {false} ;
         H00272_A59Supplier_AgbVisitingAddress = new string[] {""} ;
         H00272_n59Supplier_AgbVisitingAddress = new bool[] {false} ;
         H00272_A63Supplier_AgbContactName = new string[] {""} ;
         H00272_n63Supplier_AgbContactName = new bool[] {false} ;
         H00272_A62Supplier_AgbPhone = new string[] {""} ;
         H00272_n62Supplier_AgbPhone = new bool[] {false} ;
         H00272_A61Supplier_AgbEmail = new string[] {""} ;
         H00272_n61Supplier_AgbEmail = new bool[] {false} ;
         H00272_A57Supplier_AgbName = new string[] {""} ;
         H00272_A58Supplier_AgbKvkNumber = new string[] {""} ;
         H00272_A56Supplier_AgbNumber = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA55Supplier_AgbId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_agbgeneral__default(),
            new Object[][] {
                new Object[] {
               H00272_A55Supplier_AgbId, H00272_A60Supplier_AgbPostalAddress, H00272_n60Supplier_AgbPostalAddress, H00272_A59Supplier_AgbVisitingAddress, H00272_n59Supplier_AgbVisitingAddress, H00272_A63Supplier_AgbContactName, H00272_n63Supplier_AgbContactName, H00272_A62Supplier_AgbPhone, H00272_n62Supplier_AgbPhone, H00272_A61Supplier_AgbEmail,
               H00272_n61Supplier_AgbEmail, H00272_A57Supplier_AgbName, H00272_A58Supplier_AgbKvkNumber, H00272_A56Supplier_AgbNumber
               }
            }
         );
         AV14Pgmname = "Supplier_AgbGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "Supplier_AgbGeneral";
      }

      private short A55Supplier_AgbId ;
      private short wcpOA55Supplier_AgbId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtSupplier_AgbNumber_Enabled ;
      private int edtSupplier_AgbKvkNumber_Enabled ;
      private int edtSupplier_AgbName_Enabled ;
      private int edtSupplier_AgbEmail_Enabled ;
      private int edtSupplier_AgbPhone_Enabled ;
      private int edtSupplier_AgbContactName_Enabled ;
      private int edtSupplier_AgbVisitingAddress_Enabled ;
      private int edtSupplier_AgbPostalAddress_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtSupplier_AgbId_Visible ;
      private int edtSupplier_AgbId_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV14Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtSupplier_AgbNumber_Internalname ;
      private string TempTags ;
      private string edtSupplier_AgbNumber_Jsonclick ;
      private string edtSupplier_AgbKvkNumber_Internalname ;
      private string edtSupplier_AgbKvkNumber_Jsonclick ;
      private string edtSupplier_AgbName_Internalname ;
      private string edtSupplier_AgbName_Jsonclick ;
      private string edtSupplier_AgbEmail_Internalname ;
      private string edtSupplier_AgbEmail_Jsonclick ;
      private string edtSupplier_AgbPhone_Internalname ;
      private string gxphoneLink ;
      private string A62Supplier_AgbPhone ;
      private string edtSupplier_AgbPhone_Jsonclick ;
      private string edtSupplier_AgbContactName_Internalname ;
      private string edtSupplier_AgbContactName_Jsonclick ;
      private string edtSupplier_AgbVisitingAddress_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtSupplier_AgbPostalAddress_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSupplier_AgbId_Internalname ;
      private string edtSupplier_AgbId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA55Supplier_AgbId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n60Supplier_AgbPostalAddress ;
      private bool n59Supplier_AgbVisitingAddress ;
      private bool n63Supplier_AgbContactName ;
      private bool n62Supplier_AgbPhone ;
      private bool n61Supplier_AgbEmail ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A56Supplier_AgbNumber ;
      private string A58Supplier_AgbKvkNumber ;
      private string A57Supplier_AgbName ;
      private string A61Supplier_AgbEmail ;
      private string A63Supplier_AgbContactName ;
      private string A59Supplier_AgbVisitingAddress ;
      private string A60Supplier_AgbPostalAddress ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00272_A55Supplier_AgbId ;
      private string[] H00272_A60Supplier_AgbPostalAddress ;
      private bool[] H00272_n60Supplier_AgbPostalAddress ;
      private string[] H00272_A59Supplier_AgbVisitingAddress ;
      private bool[] H00272_n59Supplier_AgbVisitingAddress ;
      private string[] H00272_A63Supplier_AgbContactName ;
      private bool[] H00272_n63Supplier_AgbContactName ;
      private string[] H00272_A62Supplier_AgbPhone ;
      private bool[] H00272_n62Supplier_AgbPhone ;
      private string[] H00272_A61Supplier_AgbEmail ;
      private bool[] H00272_n61Supplier_AgbEmail ;
      private string[] H00272_A57Supplier_AgbName ;
      private string[] H00272_A58Supplier_AgbKvkNumber ;
      private string[] H00272_A56Supplier_AgbNumber ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class supplier_agbgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00272;
          prmH00272 = new Object[] {
          new ParDef("Supplier_AgbId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00272", "SELECT Supplier_AgbId, Supplier_AgbPostalAddress, Supplier_AgbVisitingAddress, Supplier_AgbContactName, Supplier_AgbPhone, Supplier_AgbEmail, Supplier_AgbName, Supplier_AgbKvkNumber, Supplier_AgbNumber FROM Supplier_AGB WHERE Supplier_AgbId = :Supplier_AgbId ORDER BY Supplier_AgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00272,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
