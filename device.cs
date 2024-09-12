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
   public class device : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         Form.Meta.addItem("description", "Device", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public device( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public device( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbDeviceType = new GXCombobox();
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
            return "device_Execute" ;
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
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A136DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
            AssignProp("", false, cmbDeviceType_Internalname, "Values", cmbDeviceType.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Device", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceId_Internalname, StringUtil.RTrim( A135DeviceId), StringUtil.RTrim( context.localUtil.Format( A135DeviceId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceId_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDeviceType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDeviceType_Internalname, "Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDeviceType, cmbDeviceType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0)), 1, cmbDeviceType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbDeviceType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Device.htm");
         cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         AssignProp("", false, cmbDeviceType_Internalname, "Values", (string)(cmbDeviceType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceToken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceToken_Internalname, "Token", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDeviceToken_Internalname, StringUtil.RTrim( A137DeviceToken), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtDeviceToken_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceName_Internalname, StringUtil.RTrim( A138DeviceName), StringUtil.RTrim( context.localUtil.Format( A138DeviceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDeviceUserGuid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDeviceUserGuid_Internalname, "User Guid", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDeviceUserGuid_Internalname, A139DeviceUserGuid, StringUtil.RTrim( context.localUtil.Format( A139DeviceUserGuid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDeviceUserGuid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDeviceUserGuid_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Device.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Device.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z135DeviceId = cgiGet( "Z135DeviceId");
            Z136DeviceType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z136DeviceType"), ".", ","), 18, MidpointRounding.ToEven));
            Z137DeviceToken = cgiGet( "Z137DeviceToken");
            Z138DeviceName = cgiGet( "Z138DeviceName");
            Z139DeviceUserGuid = cgiGet( "Z139DeviceUserGuid");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A135DeviceId = cgiGet( edtDeviceId_Internalname);
            AssignAttri("", false, "A135DeviceId", A135DeviceId);
            cmbDeviceType.CurrentValue = cgiGet( cmbDeviceType_Internalname);
            A136DeviceType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbDeviceType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
            A137DeviceToken = cgiGet( edtDeviceToken_Internalname);
            AssignAttri("", false, "A137DeviceToken", A137DeviceToken);
            A138DeviceName = cgiGet( edtDeviceName_Internalname);
            AssignAttri("", false, "A138DeviceName", A138DeviceName);
            A139DeviceUserGuid = cgiGet( edtDeviceUserGuid_Internalname);
            AssignAttri("", false, "A139DeviceUserGuid", A139DeviceUserGuid);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A135DeviceId = GetPar( "DeviceId");
               AssignAttri("", false, "A135DeviceId", A135DeviceId);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I28( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0I28( ) ;
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

      protected void ResetCaption0I0( )
      {
      }

      protected void ZM0I28( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z136DeviceType = T000I3_A136DeviceType[0];
               Z137DeviceToken = T000I3_A137DeviceToken[0];
               Z138DeviceName = T000I3_A138DeviceName[0];
               Z139DeviceUserGuid = T000I3_A139DeviceUserGuid[0];
            }
            else
            {
               Z136DeviceType = A136DeviceType;
               Z137DeviceToken = A137DeviceToken;
               Z138DeviceName = A138DeviceName;
               Z139DeviceUserGuid = A139DeviceUserGuid;
            }
         }
         if ( GX_JID == -2 )
         {
            Z135DeviceId = A135DeviceId;
            Z136DeviceType = A136DeviceType;
            Z137DeviceToken = A137DeviceToken;
            Z138DeviceName = A138DeviceName;
            Z139DeviceUserGuid = A139DeviceUserGuid;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0I28( )
      {
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound28 = 1;
            A136DeviceType = T000I4_A136DeviceType[0];
            AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
            A137DeviceToken = T000I4_A137DeviceToken[0];
            AssignAttri("", false, "A137DeviceToken", A137DeviceToken);
            A138DeviceName = T000I4_A138DeviceName[0];
            AssignAttri("", false, "A138DeviceName", A138DeviceName);
            A139DeviceUserGuid = T000I4_A139DeviceUserGuid[0];
            AssignAttri("", false, "A139DeviceUserGuid", A139DeviceUserGuid);
            ZM0I28( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0I28( ) ;
      }

      protected void OnLoadActions0I28( )
      {
      }

      protected void CheckExtendedTable0I28( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A136DeviceType == 0 ) || ( A136DeviceType == 1 ) || ( A136DeviceType == 2 ) || ( A136DeviceType == 3 ) ) )
         {
            GX_msglist.addItem("Field Device Type is out of range", "OutOfRange", 1, "DEVICETYPE");
            AnyError = 1;
            GX_FocusControl = cmbDeviceType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0I28( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I28( )
      {
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I28( 2) ;
            RcdFound28 = 1;
            A135DeviceId = T000I3_A135DeviceId[0];
            AssignAttri("", false, "A135DeviceId", A135DeviceId);
            A136DeviceType = T000I3_A136DeviceType[0];
            AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
            A137DeviceToken = T000I3_A137DeviceToken[0];
            AssignAttri("", false, "A137DeviceToken", A137DeviceToken);
            A138DeviceName = T000I3_A138DeviceName[0];
            AssignAttri("", false, "A138DeviceName", A138DeviceName);
            A139DeviceUserGuid = T000I3_A139DeviceUserGuid[0];
            AssignAttri("", false, "A139DeviceUserGuid", A139DeviceUserGuid);
            Z135DeviceId = A135DeviceId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0I28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0I28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0I28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000I6_A135DeviceId[0], A135DeviceId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000I6_A135DeviceId[0], A135DeviceId) > 0 ) ) )
            {
               A135DeviceId = T000I6_A135DeviceId[0];
               AssignAttri("", false, "A135DeviceId", A135DeviceId);
               RcdFound28 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {A135DeviceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000I7_A135DeviceId[0], A135DeviceId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000I7_A135DeviceId[0], A135DeviceId) < 0 ) ) )
            {
               A135DeviceId = T000I7_A135DeviceId[0];
               AssignAttri("", false, "A135DeviceId", A135DeviceId);
               RcdFound28 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
               {
                  A135DeviceId = Z135DeviceId;
                  AssignAttri("", false, "A135DeviceId", A135DeviceId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DEVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0I28( ) ;
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDeviceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DEVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtDeviceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDeviceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I28( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A135DeviceId, Z135DeviceId) != 0 )
         {
            A135DeviceId = Z135DeviceId;
            AssignAttri("", false, "A135DeviceId", A135DeviceId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DEVICEID");
            AnyError = 1;
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DEVICEID");
            AnyError = 1;
            GX_FocusControl = edtDeviceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0I28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound28 != 0 )
            {
               ScanNext0I28( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0I28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0I28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A135DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z136DeviceType != T000I2_A136DeviceType[0] ) || ( StringUtil.StrCmp(Z137DeviceToken, T000I2_A137DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z138DeviceName, T000I2_A138DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z139DeviceUserGuid, T000I2_A139DeviceUserGuid[0]) != 0 ) )
            {
               if ( Z136DeviceType != T000I2_A136DeviceType[0] )
               {
                  GXUtil.WriteLog("device:[seudo value changed for attri]"+"DeviceType");
                  GXUtil.WriteLogRaw("Old: ",Z136DeviceType);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A136DeviceType[0]);
               }
               if ( StringUtil.StrCmp(Z137DeviceToken, T000I2_A137DeviceToken[0]) != 0 )
               {
                  GXUtil.WriteLog("device:[seudo value changed for attri]"+"DeviceToken");
                  GXUtil.WriteLogRaw("Old: ",Z137DeviceToken);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A137DeviceToken[0]);
               }
               if ( StringUtil.StrCmp(Z138DeviceName, T000I2_A138DeviceName[0]) != 0 )
               {
                  GXUtil.WriteLog("device:[seudo value changed for attri]"+"DeviceName");
                  GXUtil.WriteLogRaw("Old: ",Z138DeviceName);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A138DeviceName[0]);
               }
               if ( StringUtil.StrCmp(Z139DeviceUserGuid, T000I2_A139DeviceUserGuid[0]) != 0 )
               {
                  GXUtil.WriteLog("device:[seudo value changed for attri]"+"DeviceUserGuid");
                  GXUtil.WriteLogRaw("Old: ",Z139DeviceUserGuid);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A139DeviceUserGuid[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I28( )
      {
         if ( ! IsAuthorized("device_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I28( 0) ;
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I8 */
                     pr_default.execute(6, new Object[] {A135DeviceId, A136DeviceType, A137DeviceToken, A138DeviceName, A139DeviceUserGuid});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
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
                           ResetCaption0I0( ) ;
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
               Load0I28( ) ;
            }
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void Update0I28( )
      {
         if ( ! IsAuthorized("device_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I9 */
                     pr_default.execute(7, new Object[] {A136DeviceType, A137DeviceToken, A138DeviceName, A139DeviceUserGuid, A135DeviceId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0I0( ) ;
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
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void DeferredUpdate0I28( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("device_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I28( ) ;
            AfterConfirm0I28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I10 */
                  pr_default.execute(8, new Object[] {A135DeviceId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Device");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound28 == 0 )
                        {
                           InitAll0I28( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0I0( ) ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I28( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0I28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("device",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("device",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I28( )
      {
         /* Using cursor T000I11 */
         pr_default.execute(9);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound28 = 1;
            A135DeviceId = T000I11_A135DeviceId[0];
            AssignAttri("", false, "A135DeviceId", A135DeviceId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I28( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound28 = 1;
            A135DeviceId = T000I11_A135DeviceId[0];
            AssignAttri("", false, "A135DeviceId", A135DeviceId);
         }
      }

      protected void ScanEnd0I28( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0I28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I28( )
      {
         edtDeviceId_Enabled = 0;
         AssignProp("", false, edtDeviceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceId_Enabled), 5, 0), true);
         cmbDeviceType.Enabled = 0;
         AssignProp("", false, cmbDeviceType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDeviceType.Enabled), 5, 0), true);
         edtDeviceToken_Enabled = 0;
         AssignProp("", false, edtDeviceToken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceToken_Enabled), 5, 0), true);
         edtDeviceName_Enabled = 0;
         AssignProp("", false, edtDeviceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceName_Enabled), 5, 0), true);
         edtDeviceUserGuid_Enabled = 0;
         AssignProp("", false, edtDeviceUserGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDeviceUserGuid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("device.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z135DeviceId", StringUtil.RTrim( Z135DeviceId));
         GxWebStd.gx_hidden_field( context, "Z136DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136DeviceType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z137DeviceToken", StringUtil.RTrim( Z137DeviceToken));
         GxWebStd.gx_hidden_field( context, "Z138DeviceName", StringUtil.RTrim( Z138DeviceName));
         GxWebStd.gx_hidden_field( context, "Z139DeviceUserGuid", Z139DeviceUserGuid);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("device.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Device" ;
      }

      public override string GetPgmdesc( )
      {
         return "Device" ;
      }

      protected void InitializeNonKey0I28( )
      {
         A136DeviceType = 0;
         AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         A137DeviceToken = "";
         AssignAttri("", false, "A137DeviceToken", A137DeviceToken);
         A138DeviceName = "";
         AssignAttri("", false, "A138DeviceName", A138DeviceName);
         A139DeviceUserGuid = "";
         AssignAttri("", false, "A139DeviceUserGuid", A139DeviceUserGuid);
         Z136DeviceType = 0;
         Z137DeviceToken = "";
         Z138DeviceName = "";
         Z139DeviceUserGuid = "";
      }

      protected void InitAll0I28( )
      {
         A135DeviceId = "";
         AssignAttri("", false, "A135DeviceId", A135DeviceId);
         InitializeNonKey0I28( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126301331", true, true);
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
         context.AddJavascriptSource("device.js", "?20249126301331", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtDeviceId_Internalname = "DEVICEID";
         cmbDeviceType_Internalname = "DEVICETYPE";
         edtDeviceToken_Internalname = "DEVICETOKEN";
         edtDeviceName_Internalname = "DEVICENAME";
         edtDeviceUserGuid_Internalname = "DEVICEUSERGUID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = "Device";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDeviceUserGuid_Jsonclick = "";
         edtDeviceUserGuid_Enabled = 1;
         edtDeviceName_Jsonclick = "";
         edtDeviceName_Enabled = 1;
         edtDeviceToken_Enabled = 1;
         cmbDeviceType_Jsonclick = "";
         cmbDeviceType.Enabled = 1;
         edtDeviceId_Jsonclick = "";
         edtDeviceId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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
         cmbDeviceType.Name = "DEVICETYPE";
         cmbDeviceType.WebTags = "";
         cmbDeviceType.addItem("0", "iOS", 0);
         cmbDeviceType.addItem("1", "Android", 0);
         cmbDeviceType.addItem("2", "Blackberry", 0);
         cmbDeviceType.addItem("3", "Windows", 0);
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A136DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A136DeviceType", StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = cmbDeviceType_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Deviceid( )
      {
         A136DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbDeviceType.CurrentValue = StringUtil.Str( (decimal)(A136DeviceType), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbDeviceType.ItemCount > 0 )
         {
            A136DeviceType = (short)(Math.Round(NumberUtil.Val( cmbDeviceType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbDeviceType.CurrentValue = StringUtil.Str( (decimal)(A136DeviceType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A136DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A136DeviceType), 1, 0, ".", "")));
         cmbDeviceType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136DeviceType), 1, 0));
         AssignProp("", false, cmbDeviceType_Internalname, "Values", cmbDeviceType.ToJavascriptSource(), true);
         AssignAttri("", false, "A137DeviceToken", StringUtil.RTrim( A137DeviceToken));
         AssignAttri("", false, "A138DeviceName", StringUtil.RTrim( A138DeviceName));
         AssignAttri("", false, "A139DeviceUserGuid", A139DeviceUserGuid);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z135DeviceId", StringUtil.RTrim( Z135DeviceId));
         GxWebStd.gx_hidden_field( context, "Z136DeviceType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136DeviceType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z137DeviceToken", StringUtil.RTrim( Z137DeviceToken));
         GxWebStd.gx_hidden_field( context, "Z138DeviceName", StringUtil.RTrim( Z138DeviceName));
         GxWebStd.gx_hidden_field( context, "Z139DeviceUserGuid", Z139DeviceUserGuid);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_DEVICEID","""{"handler":"Valid_Deviceid","iparms":[{"av":"cmbDeviceType"},{"av":"A136DeviceType","fld":"DEVICETYPE","pic":"9"},{"av":"A135DeviceId","fld":"DEVICEID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_DEVICEID",""","oparms":[{"av":"cmbDeviceType"},{"av":"A136DeviceType","fld":"DEVICETYPE","pic":"9"},{"av":"A137DeviceToken","fld":"DEVICETOKEN"},{"av":"A138DeviceName","fld":"DEVICENAME"},{"av":"A139DeviceUserGuid","fld":"DEVICEUSERGUID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z135DeviceId"},{"av":"Z136DeviceType"},{"av":"Z137DeviceToken"},{"av":"Z138DeviceName"},{"av":"Z139DeviceUserGuid"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_DEVICETYPE","""{"handler":"Valid_Devicetype","iparms":[]}""");
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
         Z135DeviceId = "";
         Z137DeviceToken = "";
         Z138DeviceName = "";
         Z139DeviceUserGuid = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A135DeviceId = "";
         A137DeviceToken = "";
         A138DeviceName = "";
         A139DeviceUserGuid = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000I4_A135DeviceId = new string[] {""} ;
         T000I4_A136DeviceType = new short[1] ;
         T000I4_A137DeviceToken = new string[] {""} ;
         T000I4_A138DeviceName = new string[] {""} ;
         T000I4_A139DeviceUserGuid = new string[] {""} ;
         T000I5_A135DeviceId = new string[] {""} ;
         T000I3_A135DeviceId = new string[] {""} ;
         T000I3_A136DeviceType = new short[1] ;
         T000I3_A137DeviceToken = new string[] {""} ;
         T000I3_A138DeviceName = new string[] {""} ;
         T000I3_A139DeviceUserGuid = new string[] {""} ;
         sMode28 = "";
         T000I6_A135DeviceId = new string[] {""} ;
         T000I7_A135DeviceId = new string[] {""} ;
         T000I2_A135DeviceId = new string[] {""} ;
         T000I2_A136DeviceType = new short[1] ;
         T000I2_A137DeviceToken = new string[] {""} ;
         T000I2_A138DeviceName = new string[] {""} ;
         T000I2_A139DeviceUserGuid = new string[] {""} ;
         T000I11_A135DeviceId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ135DeviceId = "";
         ZZ137DeviceToken = "";
         ZZ138DeviceName = "";
         ZZ139DeviceUserGuid = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.device__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.device__default(),
            new Object[][] {
                new Object[] {
               T000I2_A135DeviceId, T000I2_A136DeviceType, T000I2_A137DeviceToken, T000I2_A138DeviceName, T000I2_A139DeviceUserGuid
               }
               , new Object[] {
               T000I3_A135DeviceId, T000I3_A136DeviceType, T000I3_A137DeviceToken, T000I3_A138DeviceName, T000I3_A139DeviceUserGuid
               }
               , new Object[] {
               T000I4_A135DeviceId, T000I4_A136DeviceType, T000I4_A137DeviceToken, T000I4_A138DeviceName, T000I4_A139DeviceUserGuid
               }
               , new Object[] {
               T000I5_A135DeviceId
               }
               , new Object[] {
               T000I6_A135DeviceId
               }
               , new Object[] {
               T000I7_A135DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I11_A135DeviceId
               }
            }
         );
      }

      private short Z136DeviceType ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A136DeviceType ;
      private short RcdFound28 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ136DeviceType ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtDeviceId_Enabled ;
      private int edtDeviceToken_Enabled ;
      private int edtDeviceName_Enabled ;
      private int edtDeviceUserGuid_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z135DeviceId ;
      private string Z137DeviceToken ;
      private string Z138DeviceName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDeviceId_Internalname ;
      private string cmbDeviceType_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string A135DeviceId ;
      private string edtDeviceId_Jsonclick ;
      private string cmbDeviceType_Jsonclick ;
      private string edtDeviceToken_Internalname ;
      private string A137DeviceToken ;
      private string edtDeviceName_Internalname ;
      private string A138DeviceName ;
      private string edtDeviceName_Jsonclick ;
      private string edtDeviceUserGuid_Internalname ;
      private string edtDeviceUserGuid_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode28 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ135DeviceId ;
      private string ZZ137DeviceToken ;
      private string ZZ138DeviceName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z139DeviceUserGuid ;
      private string A139DeviceUserGuid ;
      private string ZZ139DeviceUserGuid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDeviceType ;
      private IDataStoreProvider pr_default ;
      private string[] T000I4_A135DeviceId ;
      private short[] T000I4_A136DeviceType ;
      private string[] T000I4_A137DeviceToken ;
      private string[] T000I4_A138DeviceName ;
      private string[] T000I4_A139DeviceUserGuid ;
      private string[] T000I5_A135DeviceId ;
      private string[] T000I3_A135DeviceId ;
      private short[] T000I3_A136DeviceType ;
      private string[] T000I3_A137DeviceToken ;
      private string[] T000I3_A138DeviceName ;
      private string[] T000I3_A139DeviceUserGuid ;
      private string[] T000I6_A135DeviceId ;
      private string[] T000I7_A135DeviceId ;
      private string[] T000I2_A135DeviceId ;
      private short[] T000I2_A136DeviceType ;
      private string[] T000I2_A137DeviceToken ;
      private string[] T000I2_A138DeviceName ;
      private string[] T000I2_A139DeviceUserGuid ;
      private string[] T000I11_A135DeviceId ;
      private IDataStoreProvider pr_gam ;
   }

   public class device__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class device__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000I2;
        prmT000I2 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I3;
        prmT000I3 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I4;
        prmT000I4 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I5;
        prmT000I5 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I6;
        prmT000I6 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I7;
        prmT000I7 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I8;
        prmT000I8 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0) ,
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,128,0) ,
        new ParDef("DeviceUserGuid",GXType.VarChar,100,60)
        };
        Object[] prmT000I9;
        prmT000I9 = new Object[] {
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,128,0) ,
        new ParDef("DeviceUserGuid",GXType.VarChar,100,60) ,
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I10;
        prmT000I10 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmT000I11;
        prmT000I11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000I2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid FROM Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Device NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I3", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I4", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserGuid FROM Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I5", "SELECT DeviceId FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I6", "SELECT DeviceId FROM Device WHERE ( DeviceId > ( :DeviceId)) ORDER BY DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I7", "SELECT DeviceId FROM Device WHERE ( DeviceId < ( :DeviceId)) ORDER BY DeviceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I8", "SAVEPOINT gxupdate;INSERT INTO Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserGuid) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserGuid);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000I8)
           ,new CursorDef("T000I9", "SAVEPOINT gxupdate;UPDATE Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserGuid=:DeviceUserGuid  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I9)
           ,new CursorDef("T000I10", "SAVEPOINT gxupdate;DELETE FROM Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I10)
           ,new CursorDef("T000I11", "SELECT DeviceId FROM Device ORDER BY DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 128);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
     }
  }

}

}
