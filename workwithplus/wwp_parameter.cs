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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter : GXDataArea
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
               AV7WWPParameterKey = GetPar( "WWPParameterKey");
               AssignAttri("", false, "AV7WWPParameterKey", AV7WWPParameterKey);
               GxWebStd.gx_hidden_field( context, "gxhash_vWWPPARAMETERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPParameterKey, "")), context));
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
         Form.Meta.addItem("description", "Parameter", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPParameterKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_parameter( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameter( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_WWPParameterKey )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WWPParameterKey = aP1_WWPParameterKey;
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
            return "wwp_parameter_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPParameterKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPParameterKey_Internalname, "Key", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPParameterKey_Internalname, A84WWPParameterKey, StringUtil.RTrim( context.localUtil.Format( A84WWPParameterKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPParameterKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPParameterKey_Enabled, 1, "text", "", 80, "chr", 1, "row", 300, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPParameterCategory_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPParameterCategory_Internalname, "Category", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPParameterCategory_Internalname, A86WWPParameterCategory, StringUtil.RTrim( context.localUtil.Format( A86WWPParameterCategory, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPParameterCategory_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPParameterCategory_Enabled, 0, "text", "", 80, "chr", 1, "row", 200, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPParameterDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPParameterDescription_Internalname, "Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPParameterDescription_Internalname, A87WWPParameterDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtWWPParameterDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPParameterValue_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPParameterValue_Internalname, "Value", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPParameterValue_Internalname, A85WWPParameterValue, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", 0, 1, edtWWPParameterValue_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_Parameter.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_Parameter.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E110A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z84WWPParameterKey = cgiGet( "Z84WWPParameterKey");
               Z86WWPParameterCategory = cgiGet( "Z86WWPParameterCategory");
               Z87WWPParameterDescription = cgiGet( "Z87WWPParameterDescription");
               Z88WWPParameterDisableDelete = StringUtil.StrToBool( cgiGet( "Z88WWPParameterDisableDelete"));
               A88WWPParameterDisableDelete = StringUtil.StrToBool( cgiGet( "Z88WWPParameterDisableDelete"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A89WWPParameterValueTrimmed = cgiGet( "WWPPARAMETERVALUETRIMMED");
               AV7WWPParameterKey = cgiGet( "vWWPPARAMETERKEY");
               A88WWPParameterDisableDelete = StringUtil.StrToBool( cgiGet( "WWPPARAMETERDISABLEDELETE"));
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
               /* Read variables values. */
               A84WWPParameterKey = cgiGet( edtWWPParameterKey_Internalname);
               AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
               A86WWPParameterCategory = cgiGet( edtWWPParameterCategory_Internalname);
               AssignAttri("", false, "A86WWPParameterCategory", A86WWPParameterCategory);
               A87WWPParameterDescription = cgiGet( edtWWPParameterDescription_Internalname);
               AssignAttri("", false, "A87WWPParameterDescription", A87WWPParameterDescription);
               A85WWPParameterValue = cgiGet( edtWWPParameterValue_Internalname);
               AssignAttri("", false, "A85WWPParameterValue", A85WWPParameterValue);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_Parameter");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("WWPParameterDisableDelete", StringUtil.BoolToStr( A88WWPParameterDisableDelete));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workwithplus\\wwp_parameter:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A84WWPParameterKey = GetPar( "WWPParameterKey");
                  AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
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
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WWPPARAMETERKEY");
                        AnyError = 1;
                        GX_FocusControl = edtWWPParameterKey_Internalname;
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
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120A2 ();
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
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A19( ) ;
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
            DisableAttributes0A19( ) ;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A19( ) ;
            }
            else
            {
               CheckExtendedTable0A19( ) ;
               CloseExtendedTableCursors0A19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("workwithplus.wwp_parameterww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A19( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z86WWPParameterCategory = T000A3_A86WWPParameterCategory[0];
               Z87WWPParameterDescription = T000A3_A87WWPParameterDescription[0];
               Z88WWPParameterDisableDelete = T000A3_A88WWPParameterDisableDelete[0];
            }
            else
            {
               Z86WWPParameterCategory = A86WWPParameterCategory;
               Z87WWPParameterDescription = A87WWPParameterDescription;
               Z88WWPParameterDisableDelete = A88WWPParameterDisableDelete;
            }
         }
         if ( GX_JID == -6 )
         {
            Z84WWPParameterKey = A84WWPParameterKey;
            Z86WWPParameterCategory = A86WWPParameterCategory;
            Z87WWPParameterDescription = A87WWPParameterDescription;
            Z85WWPParameterValue = A85WWPParameterValue;
            Z88WWPParameterDisableDelete = A88WWPParameterDisableDelete;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7WWPParameterKey)) )
         {
            A84WWPParameterKey = AV7WWPParameterKey;
            AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7WWPParameterKey)) )
         {
            edtWWPParameterKey_Enabled = 0;
            AssignProp("", false, edtWWPParameterKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterKey_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPParameterKey_Enabled = 1;
            AssignProp("", false, edtWWPParameterKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterKey_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7WWPParameterKey)) )
         {
            edtWWPParameterKey_Enabled = 0;
            AssignProp("", false, edtWWPParameterKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterKey_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A19( )
      {
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A86WWPParameterCategory = T000A4_A86WWPParameterCategory[0];
            AssignAttri("", false, "A86WWPParameterCategory", A86WWPParameterCategory);
            A87WWPParameterDescription = T000A4_A87WWPParameterDescription[0];
            AssignAttri("", false, "A87WWPParameterDescription", A87WWPParameterDescription);
            A85WWPParameterValue = T000A4_A85WWPParameterValue[0];
            AssignAttri("", false, "A85WWPParameterValue", A85WWPParameterValue);
            A88WWPParameterDisableDelete = T000A4_A88WWPParameterDisableDelete[0];
            ZM0A19( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0A19( ) ;
      }

      protected void OnLoadActions0A19( )
      {
         if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
         {
            A89WWPParameterValueTrimmed = A85WWPParameterValue;
            AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
         }
         else
         {
            A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
            AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
         }
      }

      protected void CheckExtendedTable0A19( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A84WWPParameterKey)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Parameter Key", "", "", "", "", "", "", "", ""), 1, "WWPPARAMETERKEY");
            AnyError = 1;
            GX_FocusControl = edtWWPParameterKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
         {
            A89WWPParameterValueTrimmed = A85WWPParameterValue;
            AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
         }
         else
         {
            A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
            AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
         }
      }

      protected void CloseExtendedTableCursors0A19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A19( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A19( 6) ;
            RcdFound19 = 1;
            A84WWPParameterKey = T000A3_A84WWPParameterKey[0];
            AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
            A86WWPParameterCategory = T000A3_A86WWPParameterCategory[0];
            AssignAttri("", false, "A86WWPParameterCategory", A86WWPParameterCategory);
            A87WWPParameterDescription = T000A3_A87WWPParameterDescription[0];
            AssignAttri("", false, "A87WWPParameterDescription", A87WWPParameterDescription);
            A85WWPParameterValue = T000A3_A85WWPParameterValue[0];
            AssignAttri("", false, "A85WWPParameterValue", A85WWPParameterValue);
            A88WWPParameterDisableDelete = T000A3_A88WWPParameterDisableDelete[0];
            Z84WWPParameterKey = A84WWPParameterKey;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0A19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0A19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000A6_A84WWPParameterKey[0], A84WWPParameterKey) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000A6_A84WWPParameterKey[0], A84WWPParameterKey) > 0 ) ) )
            {
               A84WWPParameterKey = T000A6_A84WWPParameterKey[0];
               AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
               RcdFound19 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A84WWPParameterKey});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000A7_A84WWPParameterKey[0], A84WWPParameterKey) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000A7_A84WWPParameterKey[0], A84WWPParameterKey) < 0 ) ) )
            {
               A84WWPParameterKey = T000A7_A84WWPParameterKey[0];
               AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
               RcdFound19 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPParameterKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
               {
                  A84WWPParameterKey = Z84WWPParameterKey;
                  AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPPARAMETERKEY");
                  AnyError = 1;
                  GX_FocusControl = edtWWPParameterKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPParameterKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0A19( ) ;
                  GX_FocusControl = edtWWPParameterKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtWWPParameterKey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPPARAMETERKEY");
                     AnyError = 1;
                     GX_FocusControl = edtWWPParameterKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWWPParameterKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A19( ) ;
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
         if ( StringUtil.StrCmp(A84WWPParameterKey, Z84WWPParameterKey) != 0 )
         {
            A84WWPParameterKey = Z84WWPParameterKey;
            AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPPARAMETERKEY");
            AnyError = 1;
            GX_FocusControl = edtWWPParameterKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPParameterKey_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0A19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A84WWPParameterKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z86WWPParameterCategory, T000A2_A86WWPParameterCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z87WWPParameterDescription, T000A2_A87WWPParameterDescription[0]) != 0 ) || ( Z88WWPParameterDisableDelete != T000A2_A88WWPParameterDisableDelete[0] ) )
            {
               if ( StringUtil.StrCmp(Z86WWPParameterCategory, T000A2_A86WWPParameterCategory[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.wwp_parameter:[seudo value changed for attri]"+"WWPParameterCategory");
                  GXUtil.WriteLogRaw("Old: ",Z86WWPParameterCategory);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A86WWPParameterCategory[0]);
               }
               if ( StringUtil.StrCmp(Z87WWPParameterDescription, T000A2_A87WWPParameterDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.wwp_parameter:[seudo value changed for attri]"+"WWPParameterDescription");
                  GXUtil.WriteLogRaw("Old: ",Z87WWPParameterDescription);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A87WWPParameterDescription[0]);
               }
               if ( Z88WWPParameterDisableDelete != T000A2_A88WWPParameterDisableDelete[0] )
               {
                  GXUtil.WriteLog("workwithplus.wwp_parameter:[seudo value changed for attri]"+"WWPParameterDisableDelete");
                  GXUtil.WriteLogRaw("Old: ",Z88WWPParameterDisableDelete);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A88WWPParameterDisableDelete[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Parameter"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A19( )
      {
         if ( ! IsAuthorized("wwp_parameter_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A19( 0) ;
            CheckOptimisticConcurrency0A19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A8 */
                     pr_default.execute(6, new Object[] {A84WWPParameterKey, A86WWPParameterCategory, A87WWPParameterDescription, A85WWPParameterValue, A88WWPParameterDisableDelete});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
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
               Load0A19( ) ;
            }
            EndLevel0A19( ) ;
         }
         CloseExtendedTableCursors0A19( ) ;
      }

      protected void Update0A19( )
      {
         if ( ! IsAuthorized("wwp_parameter_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A9 */
                     pr_default.execute(7, new Object[] {A86WWPParameterCategory, A87WWPParameterDescription, A85WWPParameterValue, A88WWPParameterDisableDelete, A84WWPParameterKey});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A19( ) ;
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
            EndLevel0A19( ) ;
         }
         CloseExtendedTableCursors0A19( ) ;
      }

      protected void DeferredUpdate0A19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_parameter_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A19( ) ;
            AfterConfirm0A19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A10 */
                  pr_default.execute(8, new Object[] {A84WWPParameterKey});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.Len( A85WWPParameterValue) <= 30 )
            {
               A89WWPParameterValueTrimmed = A85WWPParameterValue;
               AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
            }
            else
            {
               A89WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A85WWPParameterValue, 1, 27)) + "...";
               AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
            }
         }
      }

      protected void EndLevel0A19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A19( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("workwithplus.wwp_parameter",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("workwithplus.wwp_parameter",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A19( )
      {
         /* Scan By routine */
         /* Using cursor T000A11 */
         pr_default.execute(9);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A84WWPParameterKey = T000A11_A84WWPParameterKey[0];
            AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A19( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A84WWPParameterKey = T000A11_A84WWPParameterKey[0];
            AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
         }
      }

      protected void ScanEnd0A19( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0A19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A19( )
      {
         edtWWPParameterKey_Enabled = 0;
         AssignProp("", false, edtWWPParameterKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterKey_Enabled), 5, 0), true);
         edtWWPParameterCategory_Enabled = 0;
         AssignProp("", false, edtWWPParameterCategory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterCategory_Enabled), 5, 0), true);
         edtWWPParameterDescription_Enabled = 0;
         AssignProp("", false, edtWWPParameterDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterDescription_Enabled), 5, 0), true);
         edtWWPParameterValue_Enabled = 0;
         AssignProp("", false, edtWWPParameterValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPParameterValue_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.wwp_parameter.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV7WWPParameterKey))}, new string[] {"Gx_mode","WWPParameterKey"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_Parameter");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("WWPParameterDisableDelete", StringUtil.BoolToStr( A88WWPParameterDisableDelete));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\wwp_parameter:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z84WWPParameterKey", Z84WWPParameterKey);
         GxWebStd.gx_hidden_field( context, "Z86WWPParameterCategory", Z86WWPParameterCategory);
         GxWebStd.gx_hidden_field( context, "Z87WWPParameterDescription", Z87WWPParameterDescription);
         GxWebStd.gx_boolean_hidden_field( context, "Z88WWPParameterDisableDelete", Z88WWPParameterDisableDelete);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "WWPPARAMETERVALUETRIMMED", A89WWPParameterValueTrimmed);
         GxWebStd.gx_hidden_field( context, "vWWPPARAMETERKEY", AV7WWPParameterKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPPARAMETERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7WWPParameterKey, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "WWPPARAMETERDISABLEDELETE", A88WWPParameterDisableDelete);
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         return formatLink("workwithplus.wwp_parameter.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV7WWPParameterKey))}, new string[] {"Gx_mode","WWPParameterKey"})  ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.WWP_Parameter" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parameter" ;
      }

      protected void InitializeNonKey0A19( )
      {
         A89WWPParameterValueTrimmed = "";
         AssignAttri("", false, "A89WWPParameterValueTrimmed", A89WWPParameterValueTrimmed);
         A86WWPParameterCategory = "";
         AssignAttri("", false, "A86WWPParameterCategory", A86WWPParameterCategory);
         A87WWPParameterDescription = "";
         AssignAttri("", false, "A87WWPParameterDescription", A87WWPParameterDescription);
         A85WWPParameterValue = "";
         AssignAttri("", false, "A85WWPParameterValue", A85WWPParameterValue);
         A88WWPParameterDisableDelete = false;
         AssignAttri("", false, "A88WWPParameterDisableDelete", A88WWPParameterDisableDelete);
         Z86WWPParameterCategory = "";
         Z87WWPParameterDescription = "";
         Z88WWPParameterDisableDelete = false;
      }

      protected void InitAll0A19( )
      {
         A84WWPParameterKey = "";
         AssignAttri("", false, "A84WWPParameterKey", A84WWPParameterKey);
         InitializeNonKey0A19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912630455", true, true);
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
         context.AddJavascriptSource("workwithplus/wwp_parameter.js", "?2024912630456", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY";
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY";
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION";
         edtWWPParameterValue_Internalname = "WWPPARAMETERVALUE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Parameter";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWWPParameterValue_Enabled = 1;
         edtWWPParameterDescription_Enabled = 1;
         edtWWPParameterCategory_Jsonclick = "";
         edtWWPParameterCategory_Enabled = 1;
         edtWWPParameterKey_Jsonclick = "";
         edtWWPParameterKey_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "DVBootstrapResponsivePanel";
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7WWPParameterKey","fld":"vWWPPARAMETERKEY","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7WWPParameterKey","fld":"vWWPPARAMETERKEY","hsh":true},{"av":"A88WWPParameterDisableDelete","fld":"WWPPARAMETERDISABLEDELETE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120A2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_WWPPARAMETERKEY","""{"handler":"Valid_Wwpparameterkey","iparms":[]}""");
         setEventMetadata("VALID_WWPPARAMETERVALUE","""{"handler":"Valid_Wwpparametervalue","iparms":[]}""");
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
         wcpOAV7WWPParameterKey = "";
         Z84WWPParameterKey = "";
         Z86WWPParameterCategory = "";
         Z87WWPParameterDescription = "";
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
         A84WWPParameterKey = "";
         A86WWPParameterCategory = "";
         A87WWPParameterDescription = "";
         A85WWPParameterValue = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A89WWPParameterValueTrimmed = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode19 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z85WWPParameterValue = "";
         T000A4_A84WWPParameterKey = new string[] {""} ;
         T000A4_A86WWPParameterCategory = new string[] {""} ;
         T000A4_A87WWPParameterDescription = new string[] {""} ;
         T000A4_A85WWPParameterValue = new string[] {""} ;
         T000A4_A88WWPParameterDisableDelete = new bool[] {false} ;
         T000A5_A84WWPParameterKey = new string[] {""} ;
         T000A3_A84WWPParameterKey = new string[] {""} ;
         T000A3_A86WWPParameterCategory = new string[] {""} ;
         T000A3_A87WWPParameterDescription = new string[] {""} ;
         T000A3_A85WWPParameterValue = new string[] {""} ;
         T000A3_A88WWPParameterDisableDelete = new bool[] {false} ;
         T000A6_A84WWPParameterKey = new string[] {""} ;
         T000A7_A84WWPParameterKey = new string[] {""} ;
         T000A2_A84WWPParameterKey = new string[] {""} ;
         T000A2_A86WWPParameterCategory = new string[] {""} ;
         T000A2_A87WWPParameterDescription = new string[] {""} ;
         T000A2_A85WWPParameterValue = new string[] {""} ;
         T000A2_A88WWPParameterDisableDelete = new bool[] {false} ;
         T000A11_A84WWPParameterKey = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter__default(),
            new Object[][] {
                new Object[] {
               T000A2_A84WWPParameterKey, T000A2_A86WWPParameterCategory, T000A2_A87WWPParameterDescription, T000A2_A85WWPParameterValue, T000A2_A88WWPParameterDisableDelete
               }
               , new Object[] {
               T000A3_A84WWPParameterKey, T000A3_A86WWPParameterCategory, T000A3_A87WWPParameterDescription, T000A3_A85WWPParameterValue, T000A3_A88WWPParameterDisableDelete
               }
               , new Object[] {
               T000A4_A84WWPParameterKey, T000A4_A86WWPParameterCategory, T000A4_A87WWPParameterDescription, T000A4_A85WWPParameterValue, T000A4_A88WWPParameterDisableDelete
               }
               , new Object[] {
               T000A5_A84WWPParameterKey
               }
               , new Object[] {
               T000A6_A84WWPParameterKey
               }
               , new Object[] {
               T000A7_A84WWPParameterKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A11_A84WWPParameterKey
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound19 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtWWPParameterKey_Enabled ;
      private int edtWWPParameterCategory_Enabled ;
      private int edtWWPParameterDescription_Enabled ;
      private int edtWWPParameterValue_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPParameterKey_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtWWPParameterKey_Jsonclick ;
      private string edtWWPParameterCategory_Internalname ;
      private string edtWWPParameterCategory_Jsonclick ;
      private string edtWWPParameterDescription_Internalname ;
      private string edtWWPParameterValue_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode19 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z88WWPParameterDisableDelete ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A88WWPParameterDisableDelete ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string A85WWPParameterValue ;
      private string Z85WWPParameterValue ;
      private string wcpOAV7WWPParameterKey ;
      private string Z84WWPParameterKey ;
      private string Z86WWPParameterCategory ;
      private string Z87WWPParameterDescription ;
      private string AV7WWPParameterKey ;
      private string A84WWPParameterKey ;
      private string A86WWPParameterCategory ;
      private string A87WWPParameterDescription ;
      private string A89WWPParameterValueTrimmed ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T000A4_A84WWPParameterKey ;
      private string[] T000A4_A86WWPParameterCategory ;
      private string[] T000A4_A87WWPParameterDescription ;
      private string[] T000A4_A85WWPParameterValue ;
      private bool[] T000A4_A88WWPParameterDisableDelete ;
      private string[] T000A5_A84WWPParameterKey ;
      private string[] T000A3_A84WWPParameterKey ;
      private string[] T000A3_A86WWPParameterCategory ;
      private string[] T000A3_A87WWPParameterDescription ;
      private string[] T000A3_A85WWPParameterValue ;
      private bool[] T000A3_A88WWPParameterDisableDelete ;
      private string[] T000A6_A84WWPParameterKey ;
      private string[] T000A7_A84WWPParameterKey ;
      private string[] T000A2_A84WWPParameterKey ;
      private string[] T000A2_A86WWPParameterCategory ;
      private string[] T000A2_A87WWPParameterDescription ;
      private string[] T000A2_A85WWPParameterValue ;
      private bool[] T000A2_A88WWPParameterDisableDelete ;
      private string[] T000A11_A84WWPParameterKey ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_parameter__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_parameter__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000A2;
        prmT000A2 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A3;
        prmT000A3 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A4;
        prmT000A4 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A5;
        prmT000A5 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A6;
        prmT000A6 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A7;
        prmT000A7 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A8;
        prmT000A8 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0) ,
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0)
        };
        Object[] prmT000A9;
        prmT000A9 = new Object[] {
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0) ,
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A10;
        prmT000A10 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmT000A11;
        prmT000A11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000A2", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey  FOR UPDATE OF WWP_Parameter NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A3", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A4", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A5", "SELECT WWPParameterKey FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A6", "SELECT WWPParameterKey FROM WWP_Parameter WHERE ( WWPParameterKey > ( :WWPParameterKey)) ORDER BY WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A7", "SELECT WWPParameterKey FROM WWP_Parameter WHERE ( WWPParameterKey < ( :WWPParameterKey)) ORDER BY WWPParameterKey DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A8", "SAVEPOINT gxupdate;INSERT INTO WWP_Parameter(WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete) VALUES(:WWPParameterKey, :WWPParameterCategory, :WWPParameterDescription, :WWPParameterValue, :WWPParameterDisableDelete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000A8)
           ,new CursorDef("T000A9", "SAVEPOINT gxupdate;UPDATE WWP_Parameter SET WWPParameterCategory=:WWPParameterCategory, WWPParameterDescription=:WWPParameterDescription, WWPParameterValue=:WWPParameterValue, WWPParameterDisableDelete=:WWPParameterDisableDelete  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A9)
           ,new CursorDef("T000A10", "SAVEPOINT gxupdate;DELETE FROM WWP_Parameter  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A10)
           ,new CursorDef("T000A11", "SELECT WWPParameterKey FROM WWP_Parameter ORDER BY WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
