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
   public class page : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A1CustomerId) ;
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
               AV7PageId = (short)(Math.Round(NumberUtil.Val( GetPar( "PageId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PageId", StringUtil.LTrimStr( (decimal)(AV7PageId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PageId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Page", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public page( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public page( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PageId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PageId = aP1_PageId;
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
            return "page_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, divTablecontent_Width, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_Page.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableform_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageName_Internalname, context.GetMessage( "Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageName_Internalname, A104PageName, StringUtil.RTrim( context.localUtil.Format( A104PageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPageName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcustomerid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcustomerid_Internalname, context.GetMessage( "Customer", ""), "", "", lblTextblockcustomerid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_customerid.SetProperty("Caption", Combo_customerid_Caption);
         ucCombo_customerid.SetProperty("Cls", Combo_customerid_Cls);
         ucCombo_customerid.SetProperty("DataListProc", Combo_customerid_Datalistproc);
         ucCombo_customerid.SetProperty("DataListProcParametersPrefix", Combo_customerid_Datalistprocparametersprefix);
         ucCombo_customerid.SetProperty("EmptyItem", Combo_customerid_Emptyitem);
         ucCombo_customerid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_customerid.SetProperty("DropDownOptionsData", AV15CustomerId_Data);
         ucCombo_customerid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_customerid_Internalname, "COMBO_CUSTOMERIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerId_Internalname, context.GetMessage( "Customer Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerId_Visible, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, context.GetMessage( "Customer Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A3CustomerName, StringUtil.RTrim( context.localUtil.Format( A3CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerEmail_Internalname, context.GetMessage( "Customer Email", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerEmail_Internalname, A5CustomerEmail, StringUtil.RTrim( context.localUtil.Format( A5CustomerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A5CustomerEmail, "", "", "", edtCustomerEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Page.htm");
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
         GxWebStd.gx_div_start( context, divActionstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_customerid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocustomerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboCustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCombocustomerid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboCustomerId), "ZZZ9") : context.localUtil.Format( (decimal)(AV20ComboCustomerId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocustomerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocustomerid_Visible, edtavCombocustomerid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A103PageId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPageId_Enabled!=0) ? context.localUtil.Format( (decimal)(A103PageId), "ZZZ9") : context.localUtil.Format( (decimal)(A103PageId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPageId_Jsonclick, 0, "Attribute", "", "", "", "", edtPageId_Visible, edtPageId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Page.htm");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageHtmlContent_Internalname, A105PageHtmlContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", 0, edtPageHtmlContent_Visible, edtPageHtmlContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "5242880", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Page.htm");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageJsonContent_Internalname, A106PageJsonContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", 0, edtPageJsonContent_Visible, edtPageJsonContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Page.htm");
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
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCUSTOMERID_DATA"), AV15CustomerId_Data);
               /* Read saved values. */
               Z103PageId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z103PageId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z104PageName = cgiGet( "Z104PageName");
               Z1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7PageId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPAGEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A112PageCssContent = cgiGet( "PAGECSSCONTENT");
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_customerid_Objectcall = cgiGet( "COMBO_CUSTOMERID_Objectcall");
               Combo_customerid_Class = cgiGet( "COMBO_CUSTOMERID_Class");
               Combo_customerid_Icontype = cgiGet( "COMBO_CUSTOMERID_Icontype");
               Combo_customerid_Icon = cgiGet( "COMBO_CUSTOMERID_Icon");
               Combo_customerid_Caption = cgiGet( "COMBO_CUSTOMERID_Caption");
               Combo_customerid_Tooltip = cgiGet( "COMBO_CUSTOMERID_Tooltip");
               Combo_customerid_Cls = cgiGet( "COMBO_CUSTOMERID_Cls");
               Combo_customerid_Selectedvalue_set = cgiGet( "COMBO_CUSTOMERID_Selectedvalue_set");
               Combo_customerid_Selectedvalue_get = cgiGet( "COMBO_CUSTOMERID_Selectedvalue_get");
               Combo_customerid_Selectedtext_set = cgiGet( "COMBO_CUSTOMERID_Selectedtext_set");
               Combo_customerid_Selectedtext_get = cgiGet( "COMBO_CUSTOMERID_Selectedtext_get");
               Combo_customerid_Gamoauthtoken = cgiGet( "COMBO_CUSTOMERID_Gamoauthtoken");
               Combo_customerid_Ddointernalname = cgiGet( "COMBO_CUSTOMERID_Ddointernalname");
               Combo_customerid_Titlecontrolalign = cgiGet( "COMBO_CUSTOMERID_Titlecontrolalign");
               Combo_customerid_Dropdownoptionstype = cgiGet( "COMBO_CUSTOMERID_Dropdownoptionstype");
               Combo_customerid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Enabled"));
               Combo_customerid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Visible"));
               Combo_customerid_Titlecontrolidtoreplace = cgiGet( "COMBO_CUSTOMERID_Titlecontrolidtoreplace");
               Combo_customerid_Datalisttype = cgiGet( "COMBO_CUSTOMERID_Datalisttype");
               Combo_customerid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Allowmultipleselection"));
               Combo_customerid_Datalistfixedvalues = cgiGet( "COMBO_CUSTOMERID_Datalistfixedvalues");
               Combo_customerid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Isgriditem"));
               Combo_customerid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Hasdescription"));
               Combo_customerid_Datalistproc = cgiGet( "COMBO_CUSTOMERID_Datalistproc");
               Combo_customerid_Datalistprocparametersprefix = cgiGet( "COMBO_CUSTOMERID_Datalistprocparametersprefix");
               Combo_customerid_Remoteservicesparameters = cgiGet( "COMBO_CUSTOMERID_Remoteservicesparameters");
               Combo_customerid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CUSTOMERID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_customerid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Includeonlyselectedoption"));
               Combo_customerid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Includeselectalloption"));
               Combo_customerid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Emptyitem"));
               Combo_customerid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CUSTOMERID_Includeaddnewoption"));
               Combo_customerid_Htmltemplate = cgiGet( "COMBO_CUSTOMERID_Htmltemplate");
               Combo_customerid_Multiplevaluestype = cgiGet( "COMBO_CUSTOMERID_Multiplevaluestype");
               Combo_customerid_Loadingdata = cgiGet( "COMBO_CUSTOMERID_Loadingdata");
               Combo_customerid_Noresultsfound = cgiGet( "COMBO_CUSTOMERID_Noresultsfound");
               Combo_customerid_Emptyitemtext = cgiGet( "COMBO_CUSTOMERID_Emptyitemtext");
               Combo_customerid_Onlyselectedvalues = cgiGet( "COMBO_CUSTOMERID_Onlyselectedvalues");
               Combo_customerid_Selectalltext = cgiGet( "COMBO_CUSTOMERID_Selectalltext");
               Combo_customerid_Multiplevaluesseparator = cgiGet( "COMBO_CUSTOMERID_Multiplevaluesseparator");
               Combo_customerid_Addnewoptiontext = cgiGet( "COMBO_CUSTOMERID_Addnewoptiontext");
               Combo_customerid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CUSTOMERID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A104PageName = cgiGet( edtPageName_Internalname);
               AssignAttri("", false, "A104PageName", A104PageName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1CustomerId = 0;
                  AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               }
               else
               {
                  A1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
               }
               A3CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A3CustomerName", A3CustomerName);
               A5CustomerEmail = cgiGet( edtCustomerEmail_Internalname);
               n5CustomerEmail = false;
               AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
               AV20ComboCustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocustomerid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboCustomerId", StringUtil.LTrimStr( (decimal)(AV20ComboCustomerId), 4, 0));
               A103PageId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
               A105PageHtmlContent = cgiGet( edtPageHtmlContent_Internalname);
               AssignAttri("", false, "A105PageHtmlContent", A105PageHtmlContent);
               A106PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
               AssignAttri("", false, "A106PageJsonContent", A106PageJsonContent);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Page");
               A103PageId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPageId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
               forbiddenHiddens.Add("PageId", context.localUtil.Format( (decimal)(A103PageId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A103PageId != Z103PageId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("page:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A103PageId = (short)(Math.Round(NumberUtil.Val( GetPar( "PageId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
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
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAGEID");
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
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
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
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
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E24( ) ;
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
            DisableAttributes0E24( ) ;
         }
         AssignProp("", false, edtavCombocustomerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocustomerid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E24( ) ;
            }
            else
            {
               CheckExtendedTable0E24( ) ;
               CloseExtendedTableCursors0E24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         divTablecontent_Width = 900;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_customerid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "GAMOAuthToken", Combo_customerid_Gamoauthtoken);
         edtCustomerId_Visible = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerId_Visible), 5, 0), true);
         AV20ComboCustomerId = 0;
         AssignAttri("", false, "AV20ComboCustomerId", StringUtil.LTrimStr( (decimal)(AV20ComboCustomerId), 4, 0));
         edtavCombocustomerid_Visible = 0;
         AssignProp("", false, edtavCombocustomerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocustomerid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCUSTOMERID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV13Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV13Insert_CustomerId), 4, 0));
                  if ( ! (0==AV13Insert_CustomerId) )
                  {
                     AV20ComboCustomerId = AV13Insert_CustomerId;
                     AssignAttri("", false, "AV20ComboCustomerId", StringUtil.LTrimStr( (decimal)(AV20ComboCustomerId), 4, 0));
                     Combo_customerid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboCustomerId), 4, 0));
                     ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "SelectedValue_set", Combo_customerid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new pageloaddvcombo(context ).execute(  "CustomerId",  "GET",  false,  AV7PageId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_customerid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "SelectedText_set", Combo_customerid_Selectedtext_set);
                     Combo_customerid_Enabled = false;
                     ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_customerid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtPageId_Visible = 0;
         AssignProp("", false, edtPageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageId_Visible), 5, 0), true);
         edtPageHtmlContent_Visible = 0;
         AssignProp("", false, edtPageHtmlContent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageHtmlContent_Visible), 5, 0), true);
         edtPageJsonContent_Visible = 0;
         AssignProp("", false, edtPageJsonContent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Visible), 5, 0), true);
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("pageww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCUSTOMERID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new pageloaddvcombo(context ).execute(  "CustomerId",  Gx_mode,  false,  AV7PageId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_customerid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "SelectedValue_set", Combo_customerid_Selectedvalue_set);
         Combo_customerid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "SelectedText_set", Combo_customerid_Selectedtext_set);
         AV20ComboCustomerId = (short)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboCustomerId", StringUtil.LTrimStr( (decimal)(AV20ComboCustomerId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_customerid_Enabled = false;
            ucCombo_customerid.SendProperty(context, "", false, Combo_customerid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_customerid_Enabled));
         }
      }

      protected void ZM0E24( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z104PageName = T000E3_A104PageName[0];
               Z1CustomerId = T000E3_A1CustomerId[0];
            }
            else
            {
               Z104PageName = A104PageName;
               Z1CustomerId = A1CustomerId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z103PageId = A103PageId;
            Z104PageName = A104PageName;
            Z105PageHtmlContent = A105PageHtmlContent;
            Z112PageCssContent = A112PageCssContent;
            Z106PageJsonContent = A106PageJsonContent;
            Z1CustomerId = A1CustomerId;
            Z3CustomerName = A3CustomerName;
            Z5CustomerEmail = A5CustomerEmail;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), true);
         AV23Pgmname = "Page";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PageId) )
         {
            A103PageId = AV7PageId;
            AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CustomerId) )
         {
            edtCustomerId_Enabled = 0;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerId_Enabled = 1;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CustomerId) )
         {
            A1CustomerId = AV13Insert_CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         else
         {
            A1CustomerId = AV20ComboCustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
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
            /* Using cursor T000E4 */
            pr_default.execute(2, new Object[] {A1CustomerId});
            A3CustomerName = T000E4_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A5CustomerEmail = T000E4_A5CustomerEmail[0];
            n5CustomerEmail = T000E4_n5CustomerEmail[0];
            AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
            pr_default.close(2);
         }
      }

      protected void Load0E24( )
      {
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A103PageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound24 = 1;
            A104PageName = T000E5_A104PageName[0];
            AssignAttri("", false, "A104PageName", A104PageName);
            A105PageHtmlContent = T000E5_A105PageHtmlContent[0];
            AssignAttri("", false, "A105PageHtmlContent", A105PageHtmlContent);
            A112PageCssContent = T000E5_A112PageCssContent[0];
            A106PageJsonContent = T000E5_A106PageJsonContent[0];
            AssignAttri("", false, "A106PageJsonContent", A106PageJsonContent);
            A3CustomerName = T000E5_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A5CustomerEmail = T000E5_A5CustomerEmail[0];
            n5CustomerEmail = T000E5_n5CustomerEmail[0];
            AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
            A1CustomerId = T000E5_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            ZM0E24( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0E24( ) ;
      }

      protected void OnLoadActions0E24( )
      {
      }

      protected void CheckExtendedTable0E24( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000E4_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         A5CustomerEmail = T000E4_A5CustomerEmail[0];
         n5CustomerEmail = T000E4_n5CustomerEmail[0];
         AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0E24( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( short A1CustomerId )
      {
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000E6_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         A5CustomerEmail = T000E6_A5CustomerEmail[0];
         n5CustomerEmail = T000E6_n5CustomerEmail[0];
         AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A3CustomerName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A5CustomerEmail)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0E24( )
      {
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A103PageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A103PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E24( 8) ;
            RcdFound24 = 1;
            A103PageId = T000E3_A103PageId[0];
            AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
            A104PageName = T000E3_A104PageName[0];
            AssignAttri("", false, "A104PageName", A104PageName);
            A105PageHtmlContent = T000E3_A105PageHtmlContent[0];
            AssignAttri("", false, "A105PageHtmlContent", A105PageHtmlContent);
            A112PageCssContent = T000E3_A112PageCssContent[0];
            A106PageJsonContent = T000E3_A106PageJsonContent[0];
            AssignAttri("", false, "A106PageJsonContent", A106PageJsonContent);
            A1CustomerId = T000E3_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            Z103PageId = A103PageId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0E24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0E24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0E24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E24( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {A103PageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000E8_A103PageId[0] < A103PageId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000E8_A103PageId[0] > A103PageId ) ) )
            {
               A103PageId = T000E8_A103PageId[0];
               AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {A103PageId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000E9_A103PageId[0] > A103PageId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000E9_A103PageId[0] < A103PageId ) ) )
            {
               A103PageId = T000E9_A103PageId[0];
               AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A103PageId != Z103PageId )
               {
                  A103PageId = Z103PageId;
                  AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtPageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0E24( ) ;
                  GX_FocusControl = edtPageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A103PageId != Z103PageId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPageName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E24( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPageName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E24( ) ;
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
         if ( A103PageId != Z103PageId )
         {
            A103PageId = Z103PageId;
            AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGEID");
            AnyError = 1;
            GX_FocusControl = edtPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0E24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A103PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z104PageName, T000E2_A104PageName[0]) != 0 ) || ( Z1CustomerId != T000E2_A1CustomerId[0] ) )
            {
               if ( StringUtil.StrCmp(Z104PageName, T000E2_A104PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("page:[seudo value changed for attri]"+"PageName");
                  GXUtil.WriteLogRaw("Old: ",Z104PageName);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A104PageName[0]);
               }
               if ( Z1CustomerId != T000E2_A1CustomerId[0] )
               {
                  GXUtil.WriteLog("page:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z1CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A1CustomerId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E24( )
      {
         if ( ! IsAuthorized("page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E24( 0) ;
            CheckOptimisticConcurrency0E24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E10 */
                     pr_default.execute(8, new Object[] {A104PageName, A105PageHtmlContent, A112PageCssContent, A106PageJsonContent, A1CustomerId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000E11 */
                     pr_default.execute(9);
                     A103PageId = T000E11_A103PageId[0];
                     AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Page");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E24( ) ;
            }
            EndLevel0E24( ) ;
         }
         CloseExtendedTableCursors0E24( ) ;
      }

      protected void Update0E24( )
      {
         if ( ! IsAuthorized("page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E12 */
                     pr_default.execute(10, new Object[] {A104PageName, A105PageHtmlContent, A112PageCssContent, A106PageJsonContent, A1CustomerId, A103PageId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Page");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E24( ) ;
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
            EndLevel0E24( ) ;
         }
         CloseExtendedTableCursors0E24( ) ;
      }

      protected void DeferredUpdate0E24( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E24( ) ;
            AfterConfirm0E24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E13 */
                  pr_default.execute(11, new Object[] {A103PageId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Page");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E24( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000E14 */
            pr_default.execute(12, new Object[] {A1CustomerId});
            A3CustomerName = T000E14_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A5CustomerEmail = T000E14_A5CustomerEmail[0];
            n5CustomerEmail = T000E14_n5CustomerEmail[0];
            AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
            pr_default.close(12);
         }
      }

      protected void EndLevel0E24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("page",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("page",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E24( )
      {
         /* Scan By routine */
         /* Using cursor T000E15 */
         pr_default.execute(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A103PageId = T000E15_A103PageId[0];
            AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E24( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A103PageId = T000E15_A103PageId[0];
            AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
         }
      }

      protected void ScanEnd0E24( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0E24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E24( )
      {
         edtPageName_Enabled = 0;
         AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         edtCustomerEmail_Enabled = 0;
         AssignProp("", false, edtCustomerEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerEmail_Enabled), 5, 0), true);
         edtavCombocustomerid_Enabled = 0;
         AssignProp("", false, edtavCombocustomerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocustomerid_Enabled), 5, 0), true);
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), true);
         edtPageHtmlContent_Enabled = 0;
         AssignProp("", false, edtPageHtmlContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageHtmlContent_Enabled), 5, 0), true);
         edtPageJsonContent_Enabled = 0;
         AssignProp("", false, edtPageJsonContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E24( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("page.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PageId,4,0))}, new string[] {"Gx_mode","PageId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Page");
         forbiddenHiddens.Add("PageId", context.localUtil.Format( (decimal)(A103PageId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("page:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z103PageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103PageId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z104PageName", Z104PageName);
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMERID_DATA", AV15CustomerId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMERID_DATA", AV15CustomerId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPAGEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PageId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAGEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PageId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAGECSSCONTENT", A112PageCssContent);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Objectcall", StringUtil.RTrim( Combo_customerid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Cls", StringUtil.RTrim( Combo_customerid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Selectedvalue_set", StringUtil.RTrim( Combo_customerid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Selectedtext_set", StringUtil.RTrim( Combo_customerid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Gamoauthtoken", StringUtil.RTrim( Combo_customerid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Enabled", StringUtil.BoolToStr( Combo_customerid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Datalistproc", StringUtil.RTrim( Combo_customerid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_customerid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CUSTOMERID_Emptyitem", StringUtil.BoolToStr( Combo_customerid_Emptyitem));
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
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
         return formatLink("page.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PageId,4,0))}, new string[] {"Gx_mode","PageId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Page" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Page", "") ;
      }

      protected void InitializeNonKey0E24( )
      {
         A1CustomerId = 0;
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         A104PageName = "";
         AssignAttri("", false, "A104PageName", A104PageName);
         A105PageHtmlContent = "";
         AssignAttri("", false, "A105PageHtmlContent", A105PageHtmlContent);
         A112PageCssContent = "";
         AssignAttri("", false, "A112PageCssContent", A112PageCssContent);
         A106PageJsonContent = "";
         AssignAttri("", false, "A106PageJsonContent", A106PageJsonContent);
         A3CustomerName = "";
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         A5CustomerEmail = "";
         n5CustomerEmail = false;
         AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
         Z104PageName = "";
         Z1CustomerId = 0;
      }

      protected void InitAll0E24( )
      {
         A103PageId = 0;
         AssignAttri("", false, "A103PageId", StringUtil.LTrimStr( (decimal)(A103PageId), 4, 0));
         InitializeNonKey0E24( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315535489", true, true);
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
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("page.js", "?202491315535492", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPageName_Internalname = "PAGENAME";
         lblTextblockcustomerid_Internalname = "TEXTBLOCKCUSTOMERID";
         Combo_customerid_Internalname = "COMBO_CUSTOMERID";
         edtCustomerId_Internalname = "CUSTOMERID";
         divTablesplittedcustomerid_Internalname = "TABLESPLITTEDCUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         edtCustomerEmail_Internalname = "CUSTOMEREMAIL";
         divTableform_Internalname = "TABLEFORM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocustomerid_Internalname = "vCOMBOCUSTOMERID";
         divSectionattribute_customerid_Internalname = "SECTIONATTRIBUTE_CUSTOMERID";
         edtPageId_Internalname = "PAGEID";
         edtPageHtmlContent_Internalname = "PAGEHTMLCONTENT";
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT";
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
         Form.Caption = context.GetMessage( "Page", "");
         edtPageJsonContent_Enabled = 1;
         edtPageJsonContent_Visible = 1;
         edtPageHtmlContent_Enabled = 1;
         edtPageHtmlContent_Visible = 1;
         edtPageId_Jsonclick = "";
         edtPageId_Enabled = 0;
         edtPageId_Visible = 1;
         edtavCombocustomerid_Jsonclick = "";
         edtavCombocustomerid_Enabled = 0;
         edtavCombocustomerid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCustomerEmail_Jsonclick = "";
         edtCustomerEmail_Enabled = 0;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtCustomerId_Visible = 1;
         Combo_customerid_Emptyitem = Convert.ToBoolean( 0);
         Combo_customerid_Datalistprocparametersprefix = " \"ComboName\": \"CustomerId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PageId\": 0";
         Combo_customerid_Datalistproc = "PageLoadDVCombo";
         Combo_customerid_Cls = "ExtendedCombo Attribute";
         Combo_customerid_Caption = "";
         Combo_customerid_Enabled = Convert.ToBoolean( -1);
         edtPageName_Jsonclick = "";
         edtPageName_Enabled = 1;
         divTablecontent_Width = 0;
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

      public void Valid_Customerid( )
      {
         n5CustomerEmail = false;
         /* Using cursor T000E14 */
         pr_default.execute(12, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A3CustomerName = T000E14_A3CustomerName[0];
         A5CustomerEmail = T000E14_A5CustomerEmail[0];
         n5CustomerEmail = T000E14_n5CustomerEmail[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         AssignAttri("", false, "A5CustomerEmail", A5CustomerEmail);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7PageId","fld":"vPAGEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7PageId","fld":"vPAGEID","pic":"ZZZ9","hsh":true},{"av":"A103PageId","fld":"PAGEID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120E2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A3CustomerName","fld":"CUSTOMERNAME"},{"av":"A5CustomerEmail","fld":"CUSTOMEREMAIL"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A3CustomerName","fld":"CUSTOMERNAME"},{"av":"A5CustomerEmail","fld":"CUSTOMEREMAIL"}]}""");
         setEventMetadata("VALIDV_COMBOCUSTOMERID","""{"handler":"Validv_Combocustomerid","iparms":[]}""");
         setEventMetadata("VALID_PAGEID","""{"handler":"Valid_Pageid","iparms":[]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z104PageName = "";
         Combo_customerid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A104PageName = "";
         lblTextblockcustomerid_Jsonclick = "";
         ucCombo_customerid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15CustomerId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A3CustomerName = "";
         A5CustomerEmail = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A105PageHtmlContent = "";
         A106PageJsonContent = "";
         A112PageCssContent = "";
         AV23Pgmname = "";
         Combo_customerid_Objectcall = "";
         Combo_customerid_Class = "";
         Combo_customerid_Icontype = "";
         Combo_customerid_Icon = "";
         Combo_customerid_Tooltip = "";
         Combo_customerid_Selectedvalue_set = "";
         Combo_customerid_Selectedtext_set = "";
         Combo_customerid_Selectedtext_get = "";
         Combo_customerid_Gamoauthtoken = "";
         Combo_customerid_Ddointernalname = "";
         Combo_customerid_Titlecontrolalign = "";
         Combo_customerid_Dropdownoptionstype = "";
         Combo_customerid_Titlecontrolidtoreplace = "";
         Combo_customerid_Datalisttype = "";
         Combo_customerid_Datalistfixedvalues = "";
         Combo_customerid_Remoteservicesparameters = "";
         Combo_customerid_Htmltemplate = "";
         Combo_customerid_Multiplevaluestype = "";
         Combo_customerid_Loadingdata = "";
         Combo_customerid_Noresultsfound = "";
         Combo_customerid_Emptyitemtext = "";
         Combo_customerid_Onlyselectedvalues = "";
         Combo_customerid_Selectalltext = "";
         Combo_customerid_Multiplevaluesseparator = "";
         Combo_customerid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z105PageHtmlContent = "";
         Z112PageCssContent = "";
         Z106PageJsonContent = "";
         Z3CustomerName = "";
         Z5CustomerEmail = "";
         T000E4_A3CustomerName = new string[] {""} ;
         T000E4_A5CustomerEmail = new string[] {""} ;
         T000E4_n5CustomerEmail = new bool[] {false} ;
         T000E5_A103PageId = new short[1] ;
         T000E5_A104PageName = new string[] {""} ;
         T000E5_A105PageHtmlContent = new string[] {""} ;
         T000E5_A112PageCssContent = new string[] {""} ;
         T000E5_A106PageJsonContent = new string[] {""} ;
         T000E5_A3CustomerName = new string[] {""} ;
         T000E5_A5CustomerEmail = new string[] {""} ;
         T000E5_n5CustomerEmail = new bool[] {false} ;
         T000E5_A1CustomerId = new short[1] ;
         T000E6_A3CustomerName = new string[] {""} ;
         T000E6_A5CustomerEmail = new string[] {""} ;
         T000E6_n5CustomerEmail = new bool[] {false} ;
         T000E7_A103PageId = new short[1] ;
         T000E3_A103PageId = new short[1] ;
         T000E3_A104PageName = new string[] {""} ;
         T000E3_A105PageHtmlContent = new string[] {""} ;
         T000E3_A112PageCssContent = new string[] {""} ;
         T000E3_A106PageJsonContent = new string[] {""} ;
         T000E3_A1CustomerId = new short[1] ;
         T000E8_A103PageId = new short[1] ;
         T000E9_A103PageId = new short[1] ;
         T000E2_A103PageId = new short[1] ;
         T000E2_A104PageName = new string[] {""} ;
         T000E2_A105PageHtmlContent = new string[] {""} ;
         T000E2_A112PageCssContent = new string[] {""} ;
         T000E2_A106PageJsonContent = new string[] {""} ;
         T000E2_A1CustomerId = new short[1] ;
         T000E11_A103PageId = new short[1] ;
         T000E14_A3CustomerName = new string[] {""} ;
         T000E14_A5CustomerEmail = new string[] {""} ;
         T000E14_n5CustomerEmail = new bool[] {false} ;
         T000E15_A103PageId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.page__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.page__default(),
            new Object[][] {
                new Object[] {
               T000E2_A103PageId, T000E2_A104PageName, T000E2_A105PageHtmlContent, T000E2_A112PageCssContent, T000E2_A106PageJsonContent, T000E2_A1CustomerId
               }
               , new Object[] {
               T000E3_A103PageId, T000E3_A104PageName, T000E3_A105PageHtmlContent, T000E3_A112PageCssContent, T000E3_A106PageJsonContent, T000E3_A1CustomerId
               }
               , new Object[] {
               T000E4_A3CustomerName, T000E4_A5CustomerEmail, T000E4_n5CustomerEmail
               }
               , new Object[] {
               T000E5_A103PageId, T000E5_A104PageName, T000E5_A105PageHtmlContent, T000E5_A112PageCssContent, T000E5_A106PageJsonContent, T000E5_A3CustomerName, T000E5_A5CustomerEmail, T000E5_n5CustomerEmail, T000E5_A1CustomerId
               }
               , new Object[] {
               T000E6_A3CustomerName, T000E6_A5CustomerEmail, T000E6_n5CustomerEmail
               }
               , new Object[] {
               T000E7_A103PageId
               }
               , new Object[] {
               T000E8_A103PageId
               }
               , new Object[] {
               T000E9_A103PageId
               }
               , new Object[] {
               }
               , new Object[] {
               T000E11_A103PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E14_A3CustomerName, T000E14_A5CustomerEmail, T000E14_n5CustomerEmail
               }
               , new Object[] {
               T000E15_A103PageId
               }
            }
         );
         AV23Pgmname = "Page";
      }

      private short wcpOAV7PageId ;
      private short Z103PageId ;
      private short Z1CustomerId ;
      private short N1CustomerId ;
      private short GxWebError ;
      private short A1CustomerId ;
      private short AV7PageId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV20ComboCustomerId ;
      private short A103PageId ;
      private short AV13Insert_CustomerId ;
      private short RcdFound24 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int divTablecontent_Width ;
      private int edtPageName_Enabled ;
      private int edtCustomerId_Visible ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Enabled ;
      private int edtCustomerEmail_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocustomerid_Enabled ;
      private int edtavCombocustomerid_Visible ;
      private int edtPageId_Enabled ;
      private int edtPageId_Visible ;
      private int edtPageHtmlContent_Visible ;
      private int edtPageHtmlContent_Enabled ;
      private int edtPageJsonContent_Visible ;
      private int edtPageJsonContent_Enabled ;
      private int Combo_customerid_Datalistupdateminimumcharacters ;
      private int Combo_customerid_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_customerid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPageName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableform_Internalname ;
      private string TempTags ;
      private string edtPageName_Jsonclick ;
      private string divTablesplittedcustomerid_Internalname ;
      private string lblTextblockcustomerid_Internalname ;
      private string lblTextblockcustomerid_Jsonclick ;
      private string Combo_customerid_Caption ;
      private string Combo_customerid_Cls ;
      private string Combo_customerid_Datalistproc ;
      private string Combo_customerid_Datalistprocparametersprefix ;
      private string Combo_customerid_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerName_Jsonclick ;
      private string edtCustomerEmail_Internalname ;
      private string edtCustomerEmail_Jsonclick ;
      private string divActionstable_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_customerid_Internalname ;
      private string edtavCombocustomerid_Internalname ;
      private string edtavCombocustomerid_Jsonclick ;
      private string edtPageId_Internalname ;
      private string edtPageId_Jsonclick ;
      private string edtPageHtmlContent_Internalname ;
      private string edtPageJsonContent_Internalname ;
      private string AV23Pgmname ;
      private string Combo_customerid_Objectcall ;
      private string Combo_customerid_Class ;
      private string Combo_customerid_Icontype ;
      private string Combo_customerid_Icon ;
      private string Combo_customerid_Tooltip ;
      private string Combo_customerid_Selectedvalue_set ;
      private string Combo_customerid_Selectedtext_set ;
      private string Combo_customerid_Selectedtext_get ;
      private string Combo_customerid_Gamoauthtoken ;
      private string Combo_customerid_Ddointernalname ;
      private string Combo_customerid_Titlecontrolalign ;
      private string Combo_customerid_Dropdownoptionstype ;
      private string Combo_customerid_Titlecontrolidtoreplace ;
      private string Combo_customerid_Datalisttype ;
      private string Combo_customerid_Datalistfixedvalues ;
      private string Combo_customerid_Remoteservicesparameters ;
      private string Combo_customerid_Htmltemplate ;
      private string Combo_customerid_Multiplevaluestype ;
      private string Combo_customerid_Loadingdata ;
      private string Combo_customerid_Noresultsfound ;
      private string Combo_customerid_Emptyitemtext ;
      private string Combo_customerid_Onlyselectedvalues ;
      private string Combo_customerid_Selectalltext ;
      private string Combo_customerid_Multiplevaluesseparator ;
      private string Combo_customerid_Addnewoptiontext ;
      private string hsh ;
      private string sMode24 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_customerid_Emptyitem ;
      private bool Combo_customerid_Enabled ;
      private bool Combo_customerid_Visible ;
      private bool Combo_customerid_Allowmultipleselection ;
      private bool Combo_customerid_Isgriditem ;
      private bool Combo_customerid_Hasdescription ;
      private bool Combo_customerid_Includeonlyselectedoption ;
      private bool Combo_customerid_Includeselectalloption ;
      private bool Combo_customerid_Includeaddnewoption ;
      private bool n5CustomerEmail ;
      private bool returnInSub ;
      private string A105PageHtmlContent ;
      private string A106PageJsonContent ;
      private string A112PageCssContent ;
      private string AV19Combo_DataJson ;
      private string Z105PageHtmlContent ;
      private string Z112PageCssContent ;
      private string Z106PageJsonContent ;
      private string Z104PageName ;
      private string A104PageName ;
      private string A3CustomerName ;
      private string A5CustomerEmail ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z3CustomerName ;
      private string Z5CustomerEmail ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_customerid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15CustomerId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000E4_A3CustomerName ;
      private string[] T000E4_A5CustomerEmail ;
      private bool[] T000E4_n5CustomerEmail ;
      private short[] T000E5_A103PageId ;
      private string[] T000E5_A104PageName ;
      private string[] T000E5_A105PageHtmlContent ;
      private string[] T000E5_A112PageCssContent ;
      private string[] T000E5_A106PageJsonContent ;
      private string[] T000E5_A3CustomerName ;
      private string[] T000E5_A5CustomerEmail ;
      private bool[] T000E5_n5CustomerEmail ;
      private short[] T000E5_A1CustomerId ;
      private string[] T000E6_A3CustomerName ;
      private string[] T000E6_A5CustomerEmail ;
      private bool[] T000E6_n5CustomerEmail ;
      private short[] T000E7_A103PageId ;
      private short[] T000E3_A103PageId ;
      private string[] T000E3_A104PageName ;
      private string[] T000E3_A105PageHtmlContent ;
      private string[] T000E3_A112PageCssContent ;
      private string[] T000E3_A106PageJsonContent ;
      private short[] T000E3_A1CustomerId ;
      private short[] T000E8_A103PageId ;
      private short[] T000E9_A103PageId ;
      private short[] T000E2_A103PageId ;
      private string[] T000E2_A104PageName ;
      private string[] T000E2_A105PageHtmlContent ;
      private string[] T000E2_A112PageCssContent ;
      private string[] T000E2_A106PageJsonContent ;
      private short[] T000E2_A1CustomerId ;
      private short[] T000E11_A103PageId ;
      private string[] T000E14_A3CustomerName ;
      private string[] T000E14_A5CustomerEmail ;
      private bool[] T000E14_n5CustomerEmail ;
      private short[] T000E15_A103PageId ;
      private IDataStoreProvider pr_gam ;
   }

   public class page__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class page__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new ParDef("PageName",GXType.VarChar,40,0) ,
        new ParDef("PageHtmlContent",GXType.LongVarChar,5242880,0) ,
        new ParDef("PageCssContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        };
        Object[] prmT000E12;
        prmT000E12 = new Object[] {
        new ParDef("PageName",GXType.VarChar,40,0) ,
        new ParDef("PageHtmlContent",GXType.LongVarChar,5242880,0) ,
        new ParDef("PageCssContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E13;
        prmT000E13 = new Object[] {
        new ParDef("PageId",GXType.Int16,4,0)
        };
        Object[] prmT000E14;
        prmT000E14 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000E15;
        prmT000E15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT PageId, PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId FROM Page WHERE PageId = :PageId  FOR UPDATE OF Page NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT PageId, PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId FROM Page WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT CustomerName, CustomerEmail FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT TM1.PageId, TM1.PageName, TM1.PageHtmlContent, TM1.PageCssContent, TM1.PageJsonContent, T2.CustomerName, T2.CustomerEmail, TM1.CustomerId FROM (Page TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.PageId = :PageId ORDER BY TM1.PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT CustomerName, CustomerEmail FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E7", "SELECT PageId FROM Page WHERE PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E8", "SELECT PageId FROM Page WHERE ( PageId > :PageId) ORDER BY PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E9", "SELECT PageId FROM Page WHERE ( PageId < :PageId) ORDER BY PageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E10", "SAVEPOINT gxupdate;INSERT INTO Page(PageName, PageHtmlContent, PageCssContent, PageJsonContent, CustomerId) VALUES(:PageName, :PageHtmlContent, :PageCssContent, :PageJsonContent, :CustomerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000E10)
           ,new CursorDef("T000E11", "SELECT currval('PageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E12", "SAVEPOINT gxupdate;UPDATE Page SET PageName=:PageName, PageHtmlContent=:PageHtmlContent, PageCssContent=:PageCssContent, PageJsonContent=:PageJsonContent, CustomerId=:CustomerId  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E12)
           ,new CursorDef("T000E13", "SAVEPOINT gxupdate;DELETE FROM Page  WHERE PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E13)
           ,new CursorDef("T000E14", "SELECT CustomerName, CustomerEmail FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E15", "SELECT PageId FROM Page ORDER BY PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
