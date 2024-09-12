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
   public class pageeditor : GXDataArea
   {
      public pageeditor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pageeditor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_PageId ,
                           short aP1_PageTemplateId )
      {
         this.AV13PageId = aP0_PageId;
         this.AV11PageTemplateId = aP1_PageTemplateId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PageId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PageId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PageId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13PageId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13PageId", StringUtil.LTrimStr( (decimal)(AV13PageId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PageId), "ZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11PageTemplateId = (short)(Math.Round(NumberUtil.Val( GetPar( "PageTemplateId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11PageTemplateId", StringUtil.LTrimStr( (decimal)(AV11PageTemplateId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11PageTemplateId), "ZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "pageeditor_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA3E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3E2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.AddJavascriptSource("UserControls/UCAppToolBoxRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pageeditor.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13PageId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11PageTemplateId,4,0))}, new string[] {"PageId","PageTemplateId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPAGEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13PageId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PageId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11PageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11PageTemplateId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPAGEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13PageId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PageId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBCPAGE", AV5BCPage);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBCPAGE", AV5BCPage);
         }
         GxWebStd.gx_hidden_field( context, "vPAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11PageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11PageTemplateId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatehtml", StringUtil.RTrim( Ucpageeditor_Pagetemplatehtml));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatecss", StringUtil.RTrim( Ucpageeditor_Pagetemplatecss));
         GxWebStd.gx_hidden_field( context, "SAVEBTN_MODAL_Width", StringUtil.RTrim( Savebtn_modal_Width));
         GxWebStd.gx_hidden_field( context, "SAVEBTN_MODAL_Title", StringUtil.RTrim( Savebtn_modal_Title));
         GxWebStd.gx_hidden_field( context, "SAVEBTN_MODAL_Confirmtype", StringUtil.RTrim( Savebtn_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SAVEBTN_MODAL_Bodytype", StringUtil.RTrim( Savebtn_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatehtml", StringUtil.RTrim( Ucpageeditor_Pagetemplatehtml));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatecss", StringUtil.RTrim( Ucpageeditor_Pagetemplatecss));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatehtml", StringUtil.RTrim( Ucpageeditor_Pagetemplatehtml));
         GxWebStd.gx_hidden_field( context, "UCPAGEEDITOR_Pagetemplatecss", StringUtil.RTrim( Ucpageeditor_Pagetemplatecss));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("pageeditor.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13PageId,4,0)),UrlEncode(StringUtil.LTrimStr(AV11PageTemplateId,4,0))}, new string[] {"PageId","PageTemplateId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PageEditor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Page Editor" ;
      }

      protected void WB3E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcpageeditor.Render(context, "ucapptoolbox", Ucpageeditor_Internalname, "UCPAGEEDITORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsavebtn_Internalname, "", "Save", bttBtnsavebtn_Jsonclick, 7, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e113e1_client"+"'", TempTags, "", 2, "HLP_PageEditor.htm");
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
            wb_table1_22_3E2( true) ;
         }
         else
         {
            wb_table1_22_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0028"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0028"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0028"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3E2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Page Editor", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3E0( ) ;
      }

      protected void WS3E2( )
      {
         START3E2( ) ;
         EVT3E2( ) ;
      }

      protected void EVT3E2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "UCPAGEEDITOR.ONSAVE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ucpageeditor.Onsave */
                              E123E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SAVEBTN_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Savebtn_modal.Close */
                              E133E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E143E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E153E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 28 )
                        {
                           OldWwpaux_wc = cgiGet( "W0028");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0028", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA3E2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
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
         RF3E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E153E2 ();
            WB3E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3E2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ucpageeditor_Pagetemplatehtml = cgiGet( "UCPAGEEDITOR_Pagetemplatehtml");
            Ucpageeditor_Pagetemplatecss = cgiGet( "UCPAGEEDITOR_Pagetemplatecss");
            Savebtn_modal_Width = cgiGet( "SAVEBTN_MODAL_Width");
            Savebtn_modal_Title = cgiGet( "SAVEBTN_MODAL_Title");
            Savebtn_modal_Confirmtype = cgiGet( "SAVEBTN_MODAL_Confirmtype");
            Savebtn_modal_Bodytype = cgiGet( "SAVEBTN_MODAL_Bodytype");
            Ucpageeditor_Pagetemplatehtml = cgiGet( "UCPAGEEDITOR_Pagetemplatehtml");
            Ucpageeditor_Pagetemplatecss = cgiGet( "UCPAGEEDITOR_Pagetemplatecss");
            /* Read variables values. */
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
         E143E2 ();
         if (returnInSub) return;
      }

      protected void E143E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5BCPage = new SdtPage(context);
         if ( (0==AV13PageId) )
         {
            AV10PageTemplate.Load(AV11PageTemplateId);
            Ucpageeditor_Pagetemplatehtml = AV10PageTemplate.gxTpr_Pagetemplatehtml;
            ucUcpageeditor.SendProperty(context, "", false, Ucpageeditor_Internalname, "PageTemplateHtml", Ucpageeditor_Pagetemplatehtml);
            Ucpageeditor_Pagetemplatecss = AV10PageTemplate.gxTpr_Pagetemplatecss;
            ucUcpageeditor.SendProperty(context, "", false, Ucpageeditor_Internalname, "PageTemplateCss", Ucpageeditor_Pagetemplatecss);
         }
         else
         {
            AV5BCPage.Load(AV13PageId);
            Ucpageeditor_Pagetemplatehtml = AV5BCPage.gxTpr_Pagehtmlcontent;
            ucUcpageeditor.SendProperty(context, "", false, Ucpageeditor_Internalname, "PageTemplateHtml", Ucpageeditor_Pagetemplatehtml);
            Ucpageeditor_Pagetemplatecss = AV5BCPage.gxTpr_Pagecsscontent;
            ucUcpageeditor.SendProperty(context, "", false, Ucpageeditor_Internalname, "PageTemplateCss", Ucpageeditor_Pagetemplatecss);
            Form.Caption = Form.Caption+" - "+AV5BCPage.gxTpr_Pagename;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         }
      }

      protected void E133E2( )
      {
         /* Savebtn_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E123E2( )
      {
         /* Ucpageeditor_Onsave Routine */
         returnInSub = false;
         if ( (0==AV13PageId) )
         {
            /* Execute user subroutine: 'SAVEPAGE' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'UPDATEPAGE' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5BCPage", AV5BCPage);
      }

      protected void S112( )
      {
         /* 'SAVEPAGE' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "SAVEBTN_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S122( )
      {
         /* 'UPDATEPAGE' Routine */
         returnInSub = false;
         AV5BCPage.gxTpr_Pageid = AV13PageId;
         AV5BCPage.gxTpr_Pagehtmlcontent = Ucpageeditor_Pagetemplatehtml;
         AV5BCPage.gxTpr_Pagecsscontent = Ucpageeditor_Pagetemplatecss;
         AV5BCPage.gxTpr_Pagejsoncontent = Ucpageeditor_Pagetemplatehtml;
         GXt_int1 = 0;
         new getloggedinusercustomerid(context ).execute( out  GXt_int1) ;
         AV5BCPage.gxTpr_Customerid = GXt_int1;
         if ( AV5BCPage.Update() )
         {
            context.CommitDataStores("pageeditor",pr_default);
            GX_msglist.addItem("Page saved successfully.");
         }
         else
         {
            AV15GXV2 = 1;
            AV14GXV1 = AV5BCPage.GetMessages();
            while ( AV15GXV2 <= AV14GXV1.Count )
            {
               AV7Message = ((GeneXus.Utils.SdtMessages_Message)AV14GXV1.Item(AV15GXV2));
               GX_msglist.addItem(AV7Message.gxTpr_Description);
               AV15GXV2 = (int)(AV15GXV2+1);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E153E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_22_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesavebtn_modal_Internalname, tblTablesavebtn_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSavebtn_modal.SetProperty("Width", Savebtn_modal_Width);
            ucSavebtn_modal.SetProperty("Title", Savebtn_modal_Title);
            ucSavebtn_modal.SetProperty("ConfirmType", Savebtn_modal_Confirmtype);
            ucSavebtn_modal.SetProperty("BodyType", Savebtn_modal_Bodytype);
            ucSavebtn_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Savebtn_modal_Internalname, "SAVEBTN_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"SAVEBTN_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_3E2e( true) ;
         }
         else
         {
            wb_table1_22_3E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13PageId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13PageId", StringUtil.LTrimStr( (decimal)(AV13PageId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PageId), "ZZZ9"), context));
         AV11PageTemplateId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV11PageTemplateId", StringUtil.LTrimStr( (decimal)(AV11PageTemplateId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11PageTemplateId), "ZZZ9"), context));
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
         PA3E2( ) ;
         WS3E2( ) ;
         WE3E2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126315088", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("pageeditor.js", "?20249126315088", false, true);
         context.AddJavascriptSource("UserControls/UCAppToolBoxRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Ucpageeditor_Internalname = "UCPAGEEDITOR";
         bttBtnsavebtn_Internalname = "BTNSAVEBTN";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Savebtn_modal_Internalname = "SAVEBTN_MODAL";
         tblTablesavebtn_modal_Internalname = "TABLESAVEBTN_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Savebtn_modal_Bodytype = "WebComponent";
         Savebtn_modal_Confirmtype = "";
         Savebtn_modal_Title = "Create Page";
         Savebtn_modal_Width = "400";
         Ucpageeditor_Pagetemplatecss = "";
         Ucpageeditor_Pagetemplatehtml = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Page Editor";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13PageId","fld":"vPAGEID","pic":"ZZZ9","hsh":true},{"av":"AV11PageTemplateId","fld":"vPAGETEMPLATEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("'DOSAVEBTN'","""{"handler":"E113E1","iparms":[]}""");
         setEventMetadata("SAVEBTN_MODAL.CLOSE","""{"handler":"E133E2","iparms":[]}""");
         setEventMetadata("UCPAGEEDITOR.ONSAVE","""{"handler":"E123E2","iparms":[{"av":"AV13PageId","fld":"vPAGEID","pic":"ZZZ9","hsh":true},{"av":"AV5BCPage","fld":"vBCPAGE"},{"av":"Ucpageeditor_Pagetemplatehtml","ctrl":"UCPAGEEDITOR","prop":"PageTemplateHtml"},{"av":"Ucpageeditor_Pagetemplatecss","ctrl":"UCPAGEEDITOR","prop":"PageTemplateCss"}]""");
         setEventMetadata("UCPAGEEDITOR.ONSAVE",""","oparms":[{"av":"AV5BCPage","fld":"vBCPAGE"}]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5BCPage = new SdtPage(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucUcpageeditor = new GXUserControl();
         TempTags = "";
         bttBtnsavebtn_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10PageTemplate = new SdtPageTemplate(context);
         AV14GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV7Message = new GeneXus.Utils.SdtMessages_Message(context);
         sStyleString = "";
         ucSavebtn_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.pageeditor__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pageeditor__default(),
            new Object[][] {
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV13PageId ;
      private short AV11PageTemplateId ;
      private short wcpOAV13PageId ;
      private short wcpOAV11PageTemplateId ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private int AV15GXV2 ;
      private int idxLst ;
      private string Ucpageeditor_Pagetemplatehtml ;
      private string Ucpageeditor_Pagetemplatecss ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Savebtn_modal_Width ;
      private string Savebtn_modal_Title ;
      private string Savebtn_modal_Confirmtype ;
      private string Savebtn_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Ucpageeditor_Internalname ;
      private string TempTags ;
      private string bttBtnsavebtn_Internalname ;
      private string bttBtnsavebtn_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sStyleString ;
      private string tblTablesavebtn_modal_Internalname ;
      private string Savebtn_modal_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucUcpageeditor ;
      private GXUserControl ucSavebtn_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtPage AV5BCPage ;
      private SdtPageTemplate AV10PageTemplate ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV7Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class pageeditor__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class pageeditor__default : DataStoreHelperBase, IDataStoreHelper
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
