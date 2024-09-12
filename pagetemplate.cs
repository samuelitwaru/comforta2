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
   public class pagetemplate : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7PageTemplateId = (short)(Math.Round(NumberUtil.Val( GetPar( "PageTemplateId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PageTemplateId", StringUtil.LTrimStr( (decimal)(AV7PageTemplateId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PageTemplateId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Page Template", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPageTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pagetemplate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pagetemplate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PageTemplateId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PageTemplateId = aP1_PageTemplateId;
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
            return "pagetemplate_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.masterpageframe", "GeneXus.Programs.wwpbaseobjects.masterpageframe", new Object[] {context});
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPanelNoBorderSplitScreenTabs", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageTemplateName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageTemplateName_Internalname, "Template Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageTemplateName_Internalname, A108PageTemplateName, StringUtil.RTrim( context.localUtil.Format( A108PageTemplateName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageTemplateName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPageTemplateName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPageTemplateImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Template Image", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A110PageTemplateImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PageTemplateImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.PathToRelativeUrl( A110PageTemplateImage));
         GxWebStd.gx_bitmap( context, imgPageTemplateImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPageTemplateImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", "", "", 0, A110PageTemplateImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_PageTemplate.htm");
         AssignProp("", false, imgPageTemplateImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.PathToRelativeUrl( A110PageTemplateImage)), true);
         AssignProp("", false, imgPageTemplateImage_Internalname, "IsBlob", StringUtil.BoolToStr( A110PageTemplateImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageTemplateDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageTemplateDescription_Internalname, "Template Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageTemplateDescription_Internalname, A111PageTemplateDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtPageTemplateDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageTemplateHtml_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageTemplateHtml_Internalname, "Template Html", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageTemplateHtml_Internalname, A114PageTemplateHtml, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", 1, 1, edtPageTemplateHtml_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageTemplateCSS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageTemplateCSS_Internalname, "Template CSS", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageTemplateCSS_Internalname, A113PageTemplateCSS, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", 0, 1, edtPageTemplateCSS_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 7, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110f25_client"+"'", TempTags, "", 2, "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PageTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageTemplateId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A107PageTemplateId), 4, 0, ".", "")), StringUtil.LTrim( ((edtPageTemplateId_Enabled!=0) ? context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9") : context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageTemplateId_Jsonclick, 0, "Attribute", "", "", "", "", edtPageTemplateId_Visible, edtPageTemplateId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PageTemplate.htm");
         /* User Defined Control */
         ucWwputilities.Render(context, "dvelop.workwithplusutilities", Wwputilities_Internalname, "WWPUTILITIESContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDETAILWCINFO"), AV13DetailWCInfo);
               /* Read saved values. */
               Z107PageTemplateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z107PageTemplateId"), ".", ","), 18, MidpointRounding.ToEven));
               Z108PageTemplateName = cgiGet( "Z108PageTemplateName");
               Z111PageTemplateDescription = cgiGet( "Z111PageTemplateDescription");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               Gx_mode = cgiGet( "vMODE");
               AV14CurrentTab_ReturnUrl = cgiGet( "vCURRENTTAB_RETURNURL");
               AV7PageTemplateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPAGETEMPLATEID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000PageTemplateImage_GXI = cgiGet( "PAGETEMPLATEIMAGE_GXI");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Wwputilities_Objectcall = cgiGet( "WWPUTILITIES_Objectcall");
               Wwputilities_Class = cgiGet( "WWPUTILITIES_Class");
               Wwputilities_Enabled = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enabled"));
               Wwputilities_Enableautoupdatefromdocumenttitle = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enableautoupdatefromdocumenttitle"));
               Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enablefixobjectfitcover"));
               Wwputilities_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enablefloatinglabels"));
               Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Empowertabs"));
               Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enableupdaterowselectionstatus"));
               Wwputilities_Currenttab_returnurl = cgiGet( "WWPUTILITIES_Currenttab_returnurl");
               Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enableconvertcombotobootstrapselect"));
               Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnresizing"));
               Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnreordering"));
               Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumndragging"));
               Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnsrestore"));
               Wwputilities_Restorecolumnsiconclass = cgiGet( "WWPUTILITIES_Restorecolumnsiconclass");
               Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Pagbarincludegoto"));
               Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_Comboloadtype");
               Wwputilities_Infinitescrollingpage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPUTILITIES_Infinitescrollingpage"), ".", ","), 18, MidpointRounding.ToEven));
               Wwputilities_Updatebuttontext = cgiGet( "WWPUTILITIES_Updatebuttontext");
               Wwputilities_Addnewoption = cgiGet( "WWPUTILITIES_Addnewoption");
               Wwputilities_Onlyselectedvalues = cgiGet( "WWPUTILITIES_Onlyselectedvalues");
               Wwputilities_Multiplevaluesseparator = cgiGet( "WWPUTILITIES_Multiplevaluesseparator");
               Wwputilities_Selectall = cgiGet( "WWPUTILITIES_Selectall");
               Wwputilities_Sortasc = cgiGet( "WWPUTILITIES_Sortasc");
               Wwputilities_Sortdsc = cgiGet( "WWPUTILITIES_Sortdsc");
               Wwputilities_Allowgrouptext = cgiGet( "WWPUTILITIES_Allowgrouptext");
               Wwputilities_Fixlefttext = cgiGet( "WWPUTILITIES_Fixlefttext");
               Wwputilities_Fixrighttext = cgiGet( "WWPUTILITIES_Fixrighttext");
               Wwputilities_Loadingdata = cgiGet( "WWPUTILITIES_Loadingdata");
               Wwputilities_Cleanfilter = cgiGet( "WWPUTILITIES_Cleanfilter");
               Wwputilities_Rangefilterfrom = cgiGet( "WWPUTILITIES_Rangefilterfrom");
               Wwputilities_Rangefilterto = cgiGet( "WWPUTILITIES_Rangefilterto");
               Wwputilities_Rangepickerinvitemessage = cgiGet( "WWPUTILITIES_Rangepickerinvitemessage");
               Wwputilities_Noresultsfound = cgiGet( "WWPUTILITIES_Noresultsfound");
               Wwputilities_Searchbuttontext = cgiGet( "WWPUTILITIES_Searchbuttontext");
               Wwputilities_Searchmultiplevaluesbuttontext = cgiGet( "WWPUTILITIES_Searchmultiplevaluesbuttontext");
               Wwputilities_Columnselectorfixedleftcategory = cgiGet( "WWPUTILITIES_Columnselectorfixedleftcategory");
               Wwputilities_Columnselectorfixedrightcategory = cgiGet( "WWPUTILITIES_Columnselectorfixedrightcategory");
               Wwputilities_Columnselectornotfixedcategory = cgiGet( "WWPUTILITIES_Columnselectornotfixedcategory");
               Wwputilities_Columnselectornocategorytext = cgiGet( "WWPUTILITIES_Columnselectornocategorytext");
               Wwputilities_Columnselectorfixedempty = cgiGet( "WWPUTILITIES_Columnselectorfixedempty");
               Wwputilities_Columnselectorrestoretooltip = cgiGet( "WWPUTILITIES_Columnselectorrestoretooltip");
               Wwputilities_Pagbargotocaption = cgiGet( "WWPUTILITIES_Pagbargotocaption");
               Wwputilities_Pagbargotoiconclass = cgiGet( "WWPUTILITIES_Pagbargotoiconclass");
               Wwputilities_Pagbargototooltip = cgiGet( "WWPUTILITIES_Pagbargototooltip");
               Wwputilities_Pagbaremptyfilteredgridcaption = cgiGet( "WWPUTILITIES_Pagbaremptyfilteredgridcaption");
               Wwputilities_Includelineseparator = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Includelineseparator"));
               Wwputilities_Visible = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Visible"));
               Wwputilities_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPUTILITIES_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A108PageTemplateName = cgiGet( edtPageTemplateName_Internalname);
               AssignAttri("", false, "A108PageTemplateName", A108PageTemplateName);
               A110PageTemplateImage = cgiGet( imgPageTemplateImage_Internalname);
               AssignAttri("", false, "A110PageTemplateImage", A110PageTemplateImage);
               A111PageTemplateDescription = cgiGet( edtPageTemplateDescription_Internalname);
               AssignAttri("", false, "A111PageTemplateDescription", A111PageTemplateDescription);
               A114PageTemplateHtml = cgiGet( edtPageTemplateHtml_Internalname);
               AssignAttri("", false, "A114PageTemplateHtml", A114PageTemplateHtml);
               A113PageTemplateCSS = cgiGet( edtPageTemplateCSS_Internalname);
               AssignAttri("", false, "A113PageTemplateCSS", A113PageTemplateCSS);
               A107PageTemplateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPageTemplateId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPageTemplateImage_Internalname, ref  A110PageTemplateImage, ref  A40000PageTemplateImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PageTemplate");
               A107PageTemplateId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPageTemplateId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
               forbiddenHiddens.Add("PageTemplateId", context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A107PageTemplateId != Z107PageTemplateId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("pagetemplate:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A107PageTemplateId = (short)(Math.Round(NumberUtil.Val( GetPar( "PageTemplateId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAGETEMPLATEID");
                        AnyError = 1;
                        GX_FocusControl = edtPageTemplateId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E120F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E130F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E130F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F25( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0F25( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F25( ) ;
            }
            else
            {
               CheckExtendedTable0F25( ) ;
               CloseExtendedTableCursors0F25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtPageTemplateId_Visible = 0;
         AssignProp("", false, edtPageTemplateId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Visible), 5, 0), true);
      }

      protected void E130F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13DetailWCInfo.gxTpr_Link = formatLink("pagetemplateview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A107PageTemplateId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PageTemplateId","TabCode"}) ;
            AV13DetailWCInfo.gxTpr_Title = A108PageTemplateName;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "SplitScreenWithTabs_UpdateTab", new Object[] {(short)3,(GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo)AV13DetailWCInfo,(bool)true,(string)"pagetemplate"}, true);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13DetailWCInfo.gxTpr_Link = formatLink("pagetemplateview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A107PageTemplateId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PageTemplateId","TabCode"}) ;
            AV13DetailWCInfo.gxTpr_Title = A108PageTemplateName;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "SplitScreenWithTabs_UpdateTab", new Object[] {(short)5,(GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo)AV13DetailWCInfo,(bool)true,(string)"pagetemplate"}, true);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13DetailWCInfo.gxTpr_Link = formatLink("pagetemplateview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A107PageTemplateId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PageTemplateId","TabCode"}) ;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "SplitScreenWithTabs_UpdateTab", new Object[] {(short)4,(GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo)AV13DetailWCInfo,(bool)true,(string)"pagetemplate"}, true);
         }
         this.executeUsercontrolMethod("", false, "WWPUTILITIESContainer", "CurrentTab_Return", "", new Object[] {});
         AV14CurrentTab_ReturnUrl = Wwputilities_Currenttab_returnurl;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CurrentTab_ReturnUrl)) )
         {
            CallWebObject(formatLink(AV14CurrentTab_ReturnUrl) );
            context.wjLocDisableFrm = 0;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13DetailWCInfo", AV13DetailWCInfo);
      }

      protected void ZM0F25( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z108PageTemplateName = T000F3_A108PageTemplateName[0];
               Z111PageTemplateDescription = T000F3_A111PageTemplateDescription[0];
            }
            else
            {
               Z108PageTemplateName = A108PageTemplateName;
               Z111PageTemplateDescription = A111PageTemplateDescription;
            }
         }
         if ( GX_JID == -6 )
         {
            Z107PageTemplateId = A107PageTemplateId;
            Z108PageTemplateName = A108PageTemplateName;
            Z111PageTemplateDescription = A111PageTemplateDescription;
            Z114PageTemplateHtml = A114PageTemplateHtml;
            Z113PageTemplateCSS = A113PageTemplateCSS;
            Z110PageTemplateImage = A110PageTemplateImage;
            Z40000PageTemplateImage_GXI = A40000PageTemplateImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPageTemplateId_Enabled = 0;
         AssignProp("", false, edtPageTemplateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Enabled), 5, 0), true);
         edtPageTemplateId_Enabled = 0;
         AssignProp("", false, edtPageTemplateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PageTemplateId) )
         {
            A107PageTemplateId = AV7PageTemplateId;
            AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0F25( )
      {
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A108PageTemplateName = T000F4_A108PageTemplateName[0];
            AssignAttri("", false, "A108PageTemplateName", A108PageTemplateName);
            A111PageTemplateDescription = T000F4_A111PageTemplateDescription[0];
            AssignAttri("", false, "A111PageTemplateDescription", A111PageTemplateDescription);
            A114PageTemplateHtml = T000F4_A114PageTemplateHtml[0];
            AssignAttri("", false, "A114PageTemplateHtml", A114PageTemplateHtml);
            A113PageTemplateCSS = T000F4_A113PageTemplateCSS[0];
            AssignAttri("", false, "A113PageTemplateCSS", A113PageTemplateCSS);
            A40000PageTemplateImage_GXI = T000F4_A40000PageTemplateImage_GXI[0];
            AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
            AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
            A110PageTemplateImage = T000F4_A110PageTemplateImage[0];
            AssignAttri("", false, "A110PageTemplateImage", A110PageTemplateImage);
            AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
            AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
            ZM0F25( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0F25( ) ;
      }

      protected void OnLoadActions0F25( )
      {
      }

      protected void CheckExtendedTable0F25( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108PageTemplateName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Name", "", "", "", "", "", "", "", ""), 1, "PAGETEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtPageTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A111PageTemplateDescription)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Description", "", "", "", "", "", "", "", ""), 1, "PAGETEMPLATEDESCRIPTION");
            AnyError = 1;
            GX_FocusControl = edtPageTemplateDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000PageTemplateImage_GXI)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Page Template Image", "", "", "", "", "", "", "", ""), 1, "PAGETEMPLATEIMAGE");
            AnyError = 1;
            GX_FocusControl = imgPageTemplateImage_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0F25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F25( )
      {
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F25( 6) ;
            RcdFound25 = 1;
            A107PageTemplateId = T000F3_A107PageTemplateId[0];
            AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
            A108PageTemplateName = T000F3_A108PageTemplateName[0];
            AssignAttri("", false, "A108PageTemplateName", A108PageTemplateName);
            A111PageTemplateDescription = T000F3_A111PageTemplateDescription[0];
            AssignAttri("", false, "A111PageTemplateDescription", A111PageTemplateDescription);
            A114PageTemplateHtml = T000F3_A114PageTemplateHtml[0];
            AssignAttri("", false, "A114PageTemplateHtml", A114PageTemplateHtml);
            A113PageTemplateCSS = T000F3_A113PageTemplateCSS[0];
            AssignAttri("", false, "A113PageTemplateCSS", A113PageTemplateCSS);
            A40000PageTemplateImage_GXI = T000F3_A40000PageTemplateImage_GXI[0];
            AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
            AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
            A110PageTemplateImage = T000F3_A110PageTemplateImage[0];
            AssignAttri("", false, "A110PageTemplateImage", A110PageTemplateImage);
            AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
            AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
            Z107PageTemplateId = A107PageTemplateId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0F25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0F25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A107PageTemplateId[0] < A107PageTemplateId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A107PageTemplateId[0] > A107PageTemplateId ) ) )
            {
               A107PageTemplateId = T000F6_A107PageTemplateId[0];
               AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A107PageTemplateId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A107PageTemplateId[0] > A107PageTemplateId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A107PageTemplateId[0] < A107PageTemplateId ) ) )
            {
               A107PageTemplateId = T000F7_A107PageTemplateId[0];
               AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPageTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A107PageTemplateId != Z107PageTemplateId )
               {
                  A107PageTemplateId = Z107PageTemplateId;
                  AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGETEMPLATEID");
                  AnyError = 1;
                  GX_FocusControl = edtPageTemplateId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPageTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F25( ) ;
                  GX_FocusControl = edtPageTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A107PageTemplateId != Z107PageTemplateId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPageTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F25( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGETEMPLATEID");
                     AnyError = 1;
                     GX_FocusControl = edtPageTemplateId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPageTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F25( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A107PageTemplateId != Z107PageTemplateId )
         {
            A107PageTemplateId = Z107PageTemplateId;
            AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGETEMPLATEID");
            AnyError = 1;
            GX_FocusControl = edtPageTemplateId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPageTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A107PageTemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z108PageTemplateName, T000F2_A108PageTemplateName[0]) != 0 ) || ( StringUtil.StrCmp(Z111PageTemplateDescription, T000F2_A111PageTemplateDescription[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z108PageTemplateName, T000F2_A108PageTemplateName[0]) != 0 )
               {
                  GXUtil.WriteLog("pagetemplate:[seudo value changed for attri]"+"PageTemplateName");
                  GXUtil.WriteLogRaw("Old: ",Z108PageTemplateName);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A108PageTemplateName[0]);
               }
               if ( StringUtil.StrCmp(Z111PageTemplateDescription, T000F2_A111PageTemplateDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("pagetemplate:[seudo value changed for attri]"+"PageTemplateDescription");
                  GXUtil.WriteLogRaw("Old: ",Z111PageTemplateDescription);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A111PageTemplateDescription[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PageTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F25( )
      {
         if ( ! IsAuthorized("pagetemplate_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F25( 0) ;
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F8 */
                     pr_default.execute(6, new Object[] {A108PageTemplateName, A111PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A110PageTemplateImage, A40000PageTemplateImage_GXI});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000F9 */
                     pr_default.execute(7);
                     A107PageTemplateId = T000F9_A107PageTemplateId[0];
                     AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0F25( ) ;
            }
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void Update0F25( )
      {
         if ( ! IsAuthorized("pagetemplate_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F10 */
                     pr_default.execute(8, new Object[] {A108PageTemplateName, A111PageTemplateDescription, A114PageTemplateHtml, A113PageTemplateCSS, A107PageTemplateId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PageTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0F25( ) ;
         }
         CloseExtendedTableCursors0F25( ) ;
      }

      protected void DeferredUpdate0F25( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000F11 */
            pr_default.execute(9, new Object[] {A110PageTemplateImage, A40000PageTemplateImage_GXI, A107PageTemplateId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("pagetemplate_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F25( ) ;
            AfterConfirm0F25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F12 */
                  pr_default.execute(10, new Object[] {A107PageTemplateId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("PageTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("pagetemplate",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("pagetemplate",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F25( )
      {
         /* Scan By routine */
         /* Using cursor T000F13 */
         pr_default.execute(11);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound25 = 1;
            A107PageTemplateId = T000F13_A107PageTemplateId[0];
            AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F25( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound25 = 1;
            A107PageTemplateId = T000F13_A107PageTemplateId[0];
            AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
         }
      }

      protected void ScanEnd0F25( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0F25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F25( )
      {
         edtPageTemplateName_Enabled = 0;
         AssignProp("", false, edtPageTemplateName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateName_Enabled), 5, 0), true);
         imgPageTemplateImage_Enabled = 0;
         AssignProp("", false, imgPageTemplateImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPageTemplateImage_Enabled), 5, 0), true);
         edtPageTemplateDescription_Enabled = 0;
         AssignProp("", false, edtPageTemplateDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateDescription_Enabled), 5, 0), true);
         edtPageTemplateHtml_Enabled = 0;
         AssignProp("", false, edtPageTemplateHtml_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateHtml_Enabled), 5, 0), true);
         edtPageTemplateCSS_Enabled = 0;
         AssignProp("", false, edtPageTemplateCSS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateCSS_Enabled), 5, 0), true);
         edtPageTemplateId_Enabled = 0;
         AssignProp("", false, edtPageTemplateId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageTemplateId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
      {
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
         MasterPageObj.master_styles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormSplitScreen\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormSplitScreen\" data-gx-class=\"form-horizontal FormSplitScreen\" novalidate action=\""+formatLink("pagetemplate.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PageTemplateId,4,0))}, new string[] {"Gx_mode","PageTemplateId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormSplitScreen", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"PageTemplate");
         forbiddenHiddens.Add("PageTemplateId", context.localUtil.Format( (decimal)(A107PageTemplateId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pagetemplate:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z107PageTemplateId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z107PageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z108PageTemplateName", Z108PageTemplateName);
         GxWebStd.gx_hidden_field( context, "Z111PageTemplateDescription", Z111PageTemplateDescription);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILWCINFO", AV13DetailWCInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILWCINFO", AV13DetailWCInfo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDETAILWCINFO", GetSecureSignedToken( "", AV13DetailWCInfo, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTTAB_RETURNURL", AV14CurrentTab_ReturnUrl);
         GxWebStd.gx_hidden_field( context, "vPAGETEMPLATEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PageTemplateId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGETEMPLATEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PageTemplateId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PAGETEMPLATEIMAGE_GXI", A40000PageTemplateImage_GXI);
         GXCCtlgxBlob = "PAGETEMPLATEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A110PageTemplateImage);
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Objectcall", StringUtil.RTrim( Wwputilities_Objectcall));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Enabled", StringUtil.BoolToStr( Wwputilities_Enabled));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormSplitScreen" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("pagetemplate.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PageTemplateId,4,0))}, new string[] {"Gx_mode","PageTemplateId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PageTemplate" ;
      }

      public override string GetPgmdesc( )
      {
         return "Page Template" ;
      }

      protected void InitializeNonKey0F25( )
      {
         A108PageTemplateName = "";
         AssignAttri("", false, "A108PageTemplateName", A108PageTemplateName);
         A111PageTemplateDescription = "";
         AssignAttri("", false, "A111PageTemplateDescription", A111PageTemplateDescription);
         A114PageTemplateHtml = "";
         AssignAttri("", false, "A114PageTemplateHtml", A114PageTemplateHtml);
         A113PageTemplateCSS = "";
         AssignAttri("", false, "A113PageTemplateCSS", A113PageTemplateCSS);
         A110PageTemplateImage = "";
         AssignAttri("", false, "A110PageTemplateImage", A110PageTemplateImage);
         AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
         AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
         A40000PageTemplateImage_GXI = "";
         AssignProp("", false, imgPageTemplateImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A110PageTemplateImage)) ? A40000PageTemplateImage_GXI : context.convertURL( context.PathToRelativeUrl( A110PageTemplateImage))), true);
         AssignProp("", false, imgPageTemplateImage_Internalname, "SrcSet", context.GetImageSrcSet( A110PageTemplateImage), true);
         Z108PageTemplateName = "";
         Z111PageTemplateDescription = "";
      }

      protected void InitAll0F25( )
      {
         A107PageTemplateId = 0;
         AssignAttri("", false, "A107PageTemplateId", StringUtil.LTrimStr( (decimal)(A107PageTemplateId), 4, 0));
         InitializeNonKey0F25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome/font-awesome.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912630892", true, true);
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
         context.AddJavascriptSource("pagetemplate.js", "?2024912630892", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPageTemplateName_Internalname = "PAGETEMPLATENAME";
         imgPageTemplateImage_Internalname = "PAGETEMPLATEIMAGE";
         edtPageTemplateDescription_Internalname = "PAGETEMPLATEDESCRIPTION";
         edtPageTemplateHtml_Internalname = "PAGETEMPLATEHTML";
         edtPageTemplateCSS_Internalname = "PAGETEMPLATECSS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtPageTemplateId_Internalname = "PAGETEMPLATEID";
         Wwputilities_Internalname = "WWPUTILITIES";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Page Template";
         edtPageTemplateId_Jsonclick = "";
         edtPageTemplateId_Enabled = 0;
         edtPageTemplateId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPageTemplateCSS_Enabled = 1;
         edtPageTemplateHtml_Enabled = 1;
         edtPageTemplateDescription_Enabled = 1;
         imgPageTemplateImage_Enabled = 1;
         edtPageTemplateName_Jsonclick = "";
         edtPageTemplateName_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7PageTemplateId","fld":"vPAGETEMPLATEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13DetailWCInfo","fld":"vDETAILWCINFO","hsh":true},{"av":"AV7PageTemplateId","fld":"vPAGETEMPLATEID","pic":"ZZZ9","hsh":true},{"av":"A107PageTemplateId","fld":"PAGETEMPLATEID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E130F2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A107PageTemplateId","fld":"PAGETEMPLATEID","pic":"ZZZ9"},{"av":"AV13DetailWCInfo","fld":"vDETAILWCINFO","hsh":true},{"av":"A108PageTemplateName","fld":"PAGETEMPLATENAME"},{"av":"Wwputilities_Currenttab_returnurl","ctrl":"WWPUTILITIES","prop":"CurrentTab_ReturnUrl"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"AV13DetailWCInfo","fld":"vDETAILWCINFO","hsh":true}]}""");
         setEventMetadata("'CANCEL'","""{"handler":"E110F25","iparms":[{"av":"Wwputilities_Currenttab_returnurl","ctrl":"WWPUTILITIES","prop":"CurrentTab_ReturnUrl"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13DetailWCInfo","fld":"vDETAILWCINFO","hsh":true}]}""");
         setEventMetadata("VALID_PAGETEMPLATENAME","""{"handler":"Valid_Pagetemplatename","iparms":[]}""");
         setEventMetadata("VALID_PAGETEMPLATEIMAGE","""{"handler":"Valid_Pagetemplateimage","iparms":[]}""");
         setEventMetadata("VALID_PAGETEMPLATEDESCRIPTION","""{"handler":"Valid_Pagetemplatedescription","iparms":[]}""");
         setEventMetadata("VALID_PAGETEMPLATEID","""{"handler":"Valid_Pagetemplateid","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z108PageTemplateName = "";
         Z111PageTemplateDescription = "";
         Wwputilities_Currenttab_returnurl = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A108PageTemplateName = "";
         A110PageTemplateImage = "";
         A40000PageTemplateImage_GXI = "";
         sImgUrl = "";
         A111PageTemplateDescription = "";
         A114PageTemplateHtml = "";
         A113PageTemplateCSS = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucWwputilities = new GXUserControl();
         AV13DetailWCInfo = new GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo(context);
         AV14CurrentTab_ReturnUrl = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Wwputilities_Objectcall = "";
         Wwputilities_Class = "";
         Wwputilities_Restorecolumnsiconclass = "";
         Wwputilities_Comboloadtype = "";
         Wwputilities_Updatebuttontext = "";
         Wwputilities_Addnewoption = "";
         Wwputilities_Onlyselectedvalues = "";
         Wwputilities_Multiplevaluesseparator = "";
         Wwputilities_Selectall = "";
         Wwputilities_Sortasc = "";
         Wwputilities_Sortdsc = "";
         Wwputilities_Allowgrouptext = "";
         Wwputilities_Fixlefttext = "";
         Wwputilities_Fixrighttext = "";
         Wwputilities_Loadingdata = "";
         Wwputilities_Cleanfilter = "";
         Wwputilities_Rangefilterfrom = "";
         Wwputilities_Rangefilterto = "";
         Wwputilities_Rangepickerinvitemessage = "";
         Wwputilities_Noresultsfound = "";
         Wwputilities_Searchbuttontext = "";
         Wwputilities_Searchmultiplevaluesbuttontext = "";
         Wwputilities_Columnselectorfixedleftcategory = "";
         Wwputilities_Columnselectorfixedrightcategory = "";
         Wwputilities_Columnselectornotfixedcategory = "";
         Wwputilities_Columnselectornocategorytext = "";
         Wwputilities_Columnselectorfixedempty = "";
         Wwputilities_Columnselectorrestoretooltip = "";
         Wwputilities_Pagbargotocaption = "";
         Wwputilities_Pagbargotoiconclass = "";
         Wwputilities_Pagbargototooltip = "";
         Wwputilities_Pagbaremptyfilteredgridcaption = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z114PageTemplateHtml = "";
         Z113PageTemplateCSS = "";
         Z110PageTemplateImage = "";
         Z40000PageTemplateImage_GXI = "";
         T000F4_A107PageTemplateId = new short[1] ;
         T000F4_A108PageTemplateName = new string[] {""} ;
         T000F4_A111PageTemplateDescription = new string[] {""} ;
         T000F4_A114PageTemplateHtml = new string[] {""} ;
         T000F4_A113PageTemplateCSS = new string[] {""} ;
         T000F4_A40000PageTemplateImage_GXI = new string[] {""} ;
         T000F4_A110PageTemplateImage = new string[] {""} ;
         T000F5_A107PageTemplateId = new short[1] ;
         T000F3_A107PageTemplateId = new short[1] ;
         T000F3_A108PageTemplateName = new string[] {""} ;
         T000F3_A111PageTemplateDescription = new string[] {""} ;
         T000F3_A114PageTemplateHtml = new string[] {""} ;
         T000F3_A113PageTemplateCSS = new string[] {""} ;
         T000F3_A40000PageTemplateImage_GXI = new string[] {""} ;
         T000F3_A110PageTemplateImage = new string[] {""} ;
         T000F6_A107PageTemplateId = new short[1] ;
         T000F7_A107PageTemplateId = new short[1] ;
         T000F2_A107PageTemplateId = new short[1] ;
         T000F2_A108PageTemplateName = new string[] {""} ;
         T000F2_A111PageTemplateDescription = new string[] {""} ;
         T000F2_A114PageTemplateHtml = new string[] {""} ;
         T000F2_A113PageTemplateCSS = new string[] {""} ;
         T000F2_A40000PageTemplateImage_GXI = new string[] {""} ;
         T000F2_A110PageTemplateImage = new string[] {""} ;
         T000F9_A107PageTemplateId = new short[1] ;
         T000F13_A107PageTemplateId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagetemplate__default(),
            new Object[][] {
                new Object[] {
               T000F2_A107PageTemplateId, T000F2_A108PageTemplateName, T000F2_A111PageTemplateDescription, T000F2_A114PageTemplateHtml, T000F2_A113PageTemplateCSS, T000F2_A40000PageTemplateImage_GXI, T000F2_A110PageTemplateImage
               }
               , new Object[] {
               T000F3_A107PageTemplateId, T000F3_A108PageTemplateName, T000F3_A111PageTemplateDescription, T000F3_A114PageTemplateHtml, T000F3_A113PageTemplateCSS, T000F3_A40000PageTemplateImage_GXI, T000F3_A110PageTemplateImage
               }
               , new Object[] {
               T000F4_A107PageTemplateId, T000F4_A108PageTemplateName, T000F4_A111PageTemplateDescription, T000F4_A114PageTemplateHtml, T000F4_A113PageTemplateCSS, T000F4_A40000PageTemplateImage_GXI, T000F4_A110PageTemplateImage
               }
               , new Object[] {
               T000F5_A107PageTemplateId
               }
               , new Object[] {
               T000F6_A107PageTemplateId
               }
               , new Object[] {
               T000F7_A107PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               T000F9_A107PageTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F13_A107PageTemplateId
               }
            }
         );
      }

      private short wcpOAV7PageTemplateId ;
      private short Z107PageTemplateId ;
      private short GxWebError ;
      private short AV7PageTemplateId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A107PageTemplateId ;
      private short RcdFound25 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtPageTemplateName_Enabled ;
      private int imgPageTemplateImage_Enabled ;
      private int edtPageTemplateDescription_Enabled ;
      private int edtPageTemplateHtml_Enabled ;
      private int edtPageTemplateCSS_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtPageTemplateId_Enabled ;
      private int edtPageTemplateId_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Wwputilities_Infinitescrollingpage ;
      private int Wwputilities_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Wwputilities_Currenttab_returnurl ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPageTemplateName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtPageTemplateName_Jsonclick ;
      private string imgPageTemplateImage_Internalname ;
      private string sImgUrl ;
      private string edtPageTemplateDescription_Internalname ;
      private string edtPageTemplateHtml_Internalname ;
      private string edtPageTemplateCSS_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPageTemplateId_Internalname ;
      private string edtPageTemplateId_Jsonclick ;
      private string Wwputilities_Internalname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Wwputilities_Objectcall ;
      private string Wwputilities_Class ;
      private string Wwputilities_Restorecolumnsiconclass ;
      private string Wwputilities_Comboloadtype ;
      private string Wwputilities_Updatebuttontext ;
      private string Wwputilities_Addnewoption ;
      private string Wwputilities_Onlyselectedvalues ;
      private string Wwputilities_Multiplevaluesseparator ;
      private string Wwputilities_Selectall ;
      private string Wwputilities_Sortasc ;
      private string Wwputilities_Sortdsc ;
      private string Wwputilities_Allowgrouptext ;
      private string Wwputilities_Fixlefttext ;
      private string Wwputilities_Fixrighttext ;
      private string Wwputilities_Loadingdata ;
      private string Wwputilities_Cleanfilter ;
      private string Wwputilities_Rangefilterfrom ;
      private string Wwputilities_Rangefilterto ;
      private string Wwputilities_Rangepickerinvitemessage ;
      private string Wwputilities_Noresultsfound ;
      private string Wwputilities_Searchbuttontext ;
      private string Wwputilities_Searchmultiplevaluesbuttontext ;
      private string Wwputilities_Columnselectorfixedleftcategory ;
      private string Wwputilities_Columnselectorfixedrightcategory ;
      private string Wwputilities_Columnselectornotfixedcategory ;
      private string Wwputilities_Columnselectornocategorytext ;
      private string Wwputilities_Columnselectorfixedempty ;
      private string Wwputilities_Columnselectorrestoretooltip ;
      private string Wwputilities_Pagbargotocaption ;
      private string Wwputilities_Pagbargotoiconclass ;
      private string Wwputilities_Pagbargototooltip ;
      private string Wwputilities_Pagbaremptyfilteredgridcaption ;
      private string hsh ;
      private string sMode25 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A110PageTemplateImage_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Wwputilities_Enabled ;
      private bool Wwputilities_Enableautoupdatefromdocumenttitle ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enablefloatinglabels ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool Wwputilities_Includelineseparator ;
      private bool Wwputilities_Visible ;
      private bool returnInSub ;
      private string A114PageTemplateHtml ;
      private string A113PageTemplateCSS ;
      private string Z114PageTemplateHtml ;
      private string Z113PageTemplateCSS ;
      private string Z108PageTemplateName ;
      private string Z111PageTemplateDescription ;
      private string A108PageTemplateName ;
      private string A40000PageTemplateImage_GXI ;
      private string A111PageTemplateDescription ;
      private string AV14CurrentTab_ReturnUrl ;
      private string Z40000PageTemplateImage_GXI ;
      private string A110PageTemplateImage ;
      private string Z110PageTemplateImage ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucWwputilities ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtSplitScreenDetailInfo AV13DetailWCInfo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000F4_A107PageTemplateId ;
      private string[] T000F4_A108PageTemplateName ;
      private string[] T000F4_A111PageTemplateDescription ;
      private string[] T000F4_A114PageTemplateHtml ;
      private string[] T000F4_A113PageTemplateCSS ;
      private string[] T000F4_A40000PageTemplateImage_GXI ;
      private string[] T000F4_A110PageTemplateImage ;
      private short[] T000F5_A107PageTemplateId ;
      private short[] T000F3_A107PageTemplateId ;
      private string[] T000F3_A108PageTemplateName ;
      private string[] T000F3_A111PageTemplateDescription ;
      private string[] T000F3_A114PageTemplateHtml ;
      private string[] T000F3_A113PageTemplateCSS ;
      private string[] T000F3_A40000PageTemplateImage_GXI ;
      private string[] T000F3_A110PageTemplateImage ;
      private short[] T000F6_A107PageTemplateId ;
      private short[] T000F7_A107PageTemplateId ;
      private short[] T000F2_A107PageTemplateId ;
      private string[] T000F2_A108PageTemplateName ;
      private string[] T000F2_A111PageTemplateDescription ;
      private string[] T000F2_A114PageTemplateHtml ;
      private string[] T000F2_A113PageTemplateCSS ;
      private string[] T000F2_A40000PageTemplateImage_GXI ;
      private string[] T000F2_A110PageTemplateImage ;
      private short[] T000F9_A107PageTemplateId ;
      private short[] T000F13_A107PageTemplateId ;
      private IDataStoreProvider pr_gam ;
   }

   public class pagetemplate__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class pagetemplate__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="PageTemplate", Fld="PageTemplateImage"}
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new ParDef("PageTemplateName",GXType.VarChar,40,0) ,
        new ParDef("PageTemplateDescription",GXType.VarChar,200,0) ,
        new ParDef("PageTemplateHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateCSS",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new ParDef("PageTemplateImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("PageTemplateImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="PageTemplate", Fld="PageTemplateImage"} ,
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        new ParDef("PageTemplateId",GXType.Int16,4,0)
        };
        Object[] prmT000F13;
        prmT000F13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId  FOR UPDATE OF PageTemplate NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT PageTemplateId, PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage_GXI, PageTemplateImage FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT TM1.PageTemplateId, TM1.PageTemplateName, TM1.PageTemplateDescription, TM1.PageTemplateHtml, TM1.PageTemplateCSS, TM1.PageTemplateImage_GXI, TM1.PageTemplateImage FROM PageTemplate TM1 WHERE TM1.PageTemplateId = :PageTemplateId ORDER BY TM1.PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT PageTemplateId FROM PageTemplate WHERE PageTemplateId = :PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT PageTemplateId FROM PageTemplate WHERE ( PageTemplateId > :PageTemplateId) ORDER BY PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F7", "SELECT PageTemplateId FROM PageTemplate WHERE ( PageTemplateId < :PageTemplateId) ORDER BY PageTemplateId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F8", "SAVEPOINT gxupdate;INSERT INTO PageTemplate(PageTemplateName, PageTemplateDescription, PageTemplateHtml, PageTemplateCSS, PageTemplateImage, PageTemplateImage_GXI) VALUES(:PageTemplateName, :PageTemplateDescription, :PageTemplateHtml, :PageTemplateCSS, :PageTemplateImage, :PageTemplateImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F8)
           ,new CursorDef("T000F9", "SELECT currval('PageTemplateId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F10", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateName=:PageTemplateName, PageTemplateDescription=:PageTemplateDescription, PageTemplateHtml=:PageTemplateHtml, PageTemplateCSS=:PageTemplateCSS  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F10)
           ,new CursorDef("T000F11", "SAVEPOINT gxupdate;UPDATE PageTemplate SET PageTemplateImage=:PageTemplateImage, PageTemplateImage_GXI=:PageTemplateImage_GXI  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F11)
           ,new CursorDef("T000F12", "SAVEPOINT gxupdate;DELETE FROM PageTemplate  WHERE PageTemplateId = :PageTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F12)
           ,new CursorDef("T000F13", "SELECT PageTemplateId FROM PageTemplate ORDER BY PageTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
