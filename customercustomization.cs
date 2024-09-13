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
   public class customercustomization : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"CUSTOMERID") == 0 )
         {
            AV12Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "Insert_CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV12Insert_CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASACUSTOMERID0H27( AV12Insert_CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A1CustomerId) ;
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
               AV22CustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerCustomizationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(AV22CustomerCustomizationId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22CustomerCustomizationId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Customer Customization", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public customercustomization( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public customercustomization( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CustomerCustomizationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV22CustomerCustomizationId = aP1_CustomerCustomizationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCustomerCustomizationFontSize = new GXCombobox();
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
            return "customercustomization_Execute" ;
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
            MasterPageObj.setDataArea(this,true);
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
         if ( cmbCustomerCustomizationFontSize.ItemCount > 0 )
         {
            A132CustomerCustomizationFontSize = cmbCustomerCustomizationFontSize.getValidValue(A132CustomerCustomizationFontSize);
            AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCustomerCustomizationFontSize.CurrentValue = StringUtil.RTrim( A132CustomerCustomizationFontSize);
            AssignProp("", false, cmbCustomerCustomizationFontSize_Internalname, "Values", cmbCustomerCustomizationFontSize.ToJavascriptSource(), true);
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_CustomerCustomization.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerName_Internalname, context.GetMessage( "Customer Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A3CustomerName, StringUtil.RTrim( context.localUtil.Format( A3CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_CustomerCustomization.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCustomerCustomizationLogo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Customer Logo", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A129CustomerCustomizationLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CustomerCustomizationLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.PathToRelativeUrl( A129CustomerCustomizationLogo));
         GxWebStd.gx_bitmap( context, imgCustomerCustomizationLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCustomerCustomizationLogo_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", "", "", 0, A129CustomerCustomizationLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CustomerCustomization.htm");
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.PathToRelativeUrl( A129CustomerCustomizationLogo)), true);
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "IsBlob", StringUtil.BoolToStr( A129CustomerCustomizationLogo_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgCustomerCustomizationFavicon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Customization Favicon", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A130CustomerCustomizationFavicon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001CustomerCustomizationFavicon_G)))||!String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.PathToRelativeUrl( A130CustomerCustomizationFavicon));
         GxWebStd.gx_bitmap( context, imgCustomerCustomizationFavicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCustomerCustomizationFavicon_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", "", "", 0, A130CustomerCustomizationFavicon_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CustomerCustomization.htm");
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.PathToRelativeUrl( A130CustomerCustomizationFavicon)), true);
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "IsBlob", StringUtil.BoolToStr( A130CustomerCustomizationFavicon_IsBlob), true);
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
         GxWebStd.gx_label_element( context, cmbCustomerCustomizationFontSize_Internalname, context.GetMessage( "Font Size", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCustomerCustomizationFontSize, cmbCustomerCustomizationFontSize_Internalname, StringUtil.RTrim( A132CustomerCustomizationFontSize), 1, cmbCustomerCustomizationFontSize_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbCustomerCustomizationFontSize.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_CustomerCustomization.htm");
         cmbCustomerCustomizationFontSize.CurrentValue = StringUtil.RTrim( A132CustomerCustomizationFontSize);
         AssignProp("", false, cmbCustomerCustomizationFontSize_Internalname, "Values", (string)(cmbCustomerCustomizationFontSize.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Color Theme", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_CustomerCustomization.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
         /* User Defined Control */
         ucDdc_selectcolor.SetProperty("Caption", Ddc_selectcolor_Caption);
         ucDdc_selectcolor.SetProperty("ComponentWidth", Ddc_selectcolor_Componentwidth);
         ucDdc_selectcolor.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_selectcolor_Internalname, "DDC_SELECTCOLORContainer");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerCustomization.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerCustomization.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CustomerCustomization.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerId_Visible, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CustomerCustomization.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerCustomizationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCustomerCustomizationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9") : context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerCustomizationId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerCustomizationId_Visible, edtCustomerCustomizationId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CustomerCustomization.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerCustomizationBaseColor_Internalname, A131CustomerCustomizationBaseColor, StringUtil.RTrim( context.localUtil.Format( A131CustomerCustomizationBaseColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerCustomizationBaseColor_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerCustomizationBaseColor_Visible, edtCustomerCustomizationBaseColor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CustomerCustomization.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0063"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0063"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
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
         E110H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z128CustomerCustomizationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z131CustomerCustomizationBaseColor = cgiGet( "Z131CustomerCustomizationBaseColor");
               Z132CustomerCustomizationFontSize = cgiGet( "Z132CustomerCustomizationFontSize");
               Z1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV22CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCUSTOMERCUSTOMIZATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV12Insert_CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000CustomerCustomizationLogo_GXI = cgiGet( "CUSTOMERCUSTOMIZATIONLOGO_GXI");
               A40001CustomerCustomizationFavicon_G = cgiGet( "CUSTOMERCUSTOMIZATIONFAVICON_G");
               AV31Pgmname = cgiGet( "vPGMNAME");
               Ddc_selectcolor_Objectcall = cgiGet( "DDC_SELECTCOLOR_Objectcall");
               Ddc_selectcolor_Class = cgiGet( "DDC_SELECTCOLOR_Class");
               Ddc_selectcolor_Enabled = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Enabled"));
               Ddc_selectcolor_Icontype = cgiGet( "DDC_SELECTCOLOR_Icontype");
               Ddc_selectcolor_Icon = cgiGet( "DDC_SELECTCOLOR_Icon");
               Ddc_selectcolor_Caption = cgiGet( "DDC_SELECTCOLOR_Caption");
               Ddc_selectcolor_Tooltip = cgiGet( "DDC_SELECTCOLOR_Tooltip");
               Ddc_selectcolor_Cls = cgiGet( "DDC_SELECTCOLOR_Cls");
               Ddc_selectcolor_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_SELECTCOLOR_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Ddc_selectcolor_Titlecontrolalign = cgiGet( "DDC_SELECTCOLOR_Titlecontrolalign");
               Ddc_selectcolor_Dropdownoptionstype = cgiGet( "DDC_SELECTCOLOR_Dropdownoptionstype");
               Ddc_selectcolor_Visible = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Visible"));
               Ddc_selectcolor_Result = cgiGet( "DDC_SELECTCOLOR_Result");
               Ddc_selectcolor_Titlecontrolidtoreplace = cgiGet( "DDC_SELECTCOLOR_Titlecontrolidtoreplace");
               Ddc_selectcolor_Showloading = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Showloading"));
               Ddc_selectcolor_Load = cgiGet( "DDC_SELECTCOLOR_Load");
               Ddc_selectcolor_Keepopened = StringUtil.StrToBool( cgiGet( "DDC_SELECTCOLOR_Keepopened"));
               Ddc_selectcolor_Trigger = cgiGet( "DDC_SELECTCOLOR_Trigger");
               Ddc_selectcolor_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_SELECTCOLOR_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A3CustomerName = cgiGet( edtCustomerName_Internalname);
               AssignAttri("", false, "A3CustomerName", A3CustomerName);
               A129CustomerCustomizationLogo = cgiGet( imgCustomerCustomizationLogo_Internalname);
               AssignAttri("", false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
               A130CustomerCustomizationFavicon = cgiGet( imgCustomerCustomizationFavicon_Internalname);
               AssignAttri("", false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
               cmbCustomerCustomizationFontSize.CurrentValue = cgiGet( cmbCustomerCustomizationFontSize_Internalname);
               A132CustomerCustomizationFontSize = cgiGet( cmbCustomerCustomizationFontSize_Internalname);
               AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
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
               A128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerCustomizationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
               A131CustomerCustomizationBaseColor = cgiGet( edtCustomerCustomizationBaseColor_Internalname);
               AssignAttri("", false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgCustomerCustomizationLogo_Internalname, ref  A129CustomerCustomizationLogo, ref  A40000CustomerCustomizationLogo_GXI);
               getMultimediaValue(imgCustomerCustomizationFavicon_Internalname, ref  A130CustomerCustomizationFavicon, ref  A40001CustomerCustomizationFavicon_G);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CustomerCustomization");
               A128CustomerCustomizationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCustomerCustomizationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
               forbiddenHiddens.Add("CustomerCustomizationId", context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A128CustomerCustomizationId != Z128CustomerCustomizationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("customercustomization:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A128CustomerCustomizationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerCustomizationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
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
                     sMode27 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode27;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound27 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CUSTOMERCUSTOMIZATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtCustomerCustomizationId_Internalname;
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
                           E110H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "CUSTOMERCUSTOMIZATIONFONTSIZE.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E130H2 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 63 )
                     {
                        OldWwpaux_wc = cgiGet( "W0063");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("W0063", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
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
            E120H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H27( ) ;
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
            DisableAttributes0H27( ) ;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H27( ) ;
            }
            else
            {
               CheckExtendedTable0H27( ) ;
               CloseExtendedTableCursors0H27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         divTablecontent_Width = 900;
         AssignProp("", false, divTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablecontent_Width), 9, 0), true);
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV12Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV12Insert_CustomerId), 4, 0));
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
         edtCustomerId_Visible = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerId_Visible), 5, 0), true);
         edtCustomerCustomizationId_Visible = 0;
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Visible), 5, 0), true);
         edtCustomerCustomizationBaseColor_Visible = 0;
         AssignProp("", false, edtCustomerCustomizationBaseColor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Visible), 5, 0), true);
      }

      protected void E120H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV11WebSession.Remove(context.GetMessage( "SelectedBaseColor", ""));
         CallWebObject(formatLink("home.aspx") );
         context.wjLocDisableFrm = 1;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("customercustomizationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E130H2( )
      {
         /* CustomerCustomizationFontSize_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SELECTFONT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'SELECTFONT' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A132CustomerCustomizationFontSize)) )
         {
            GXt_SdtWWP_DesignSystemSettings1 = AV28WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings1) ;
            AV28WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings1;
            AV28WWP_DesignSystemSettings.gxTpr_Fontsize = A132CustomerCustomizationFontSize;
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV28WWP_DesignSystemSettings.ToJSonString(false, true)) ;
            this.executeExternalObjectMethod("", false, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV28WWP_DesignSystemSettings.gxTpr_Fontsize}, false);
            this.executeExternalObjectMethod("", false, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
      }

      protected void ZM0H27( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z131CustomerCustomizationBaseColor = T000H3_A131CustomerCustomizationBaseColor[0];
               Z132CustomerCustomizationFontSize = T000H3_A132CustomerCustomizationFontSize[0];
               Z1CustomerId = T000H3_A1CustomerId[0];
            }
            else
            {
               Z131CustomerCustomizationBaseColor = A131CustomerCustomizationBaseColor;
               Z132CustomerCustomizationFontSize = A132CustomerCustomizationFontSize;
               Z1CustomerId = A1CustomerId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
            Z131CustomerCustomizationBaseColor = A131CustomerCustomizationBaseColor;
            Z129CustomerCustomizationLogo = A129CustomerCustomizationLogo;
            Z40000CustomerCustomizationLogo_GXI = A40000CustomerCustomizationLogo_GXI;
            Z130CustomerCustomizationFavicon = A130CustomerCustomizationFavicon;
            Z40001CustomerCustomizationFavicon_G = A40001CustomerCustomizationFavicon_G;
            Z132CustomerCustomizationFontSize = A132CustomerCustomizationFontSize;
            Z1CustomerId = A1CustomerId;
            Z3CustomerName = A3CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCustomerCustomizationId_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Enabled), 5, 0), true);
         AV31Pgmname = "CustomerCustomization";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         edtCustomerCustomizationId_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV22CustomerCustomizationId) )
         {
            A128CustomerCustomizationId = AV22CustomerCustomizationId;
            AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CustomerId) )
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), "")))) )
         {
            A131CustomerCustomizationBaseColor = AV11WebSession.Get(context.GetMessage( context.GetMessage( "SelectedBaseColor", ""), ""));
            AssignAttri("", false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CustomerId) )
         {
            A1CustomerId = AV12Insert_CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         else
         {
            GXt_int2 = A1CustomerId;
            new getloggedinusercustomerid(context ).execute( out  GXt_int2) ;
            A1CustomerId = GXt_int2;
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
            /* Using cursor T000H4 */
            pr_default.execute(2, new Object[] {A1CustomerId});
            A3CustomerName = T000H4_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            pr_default.close(2);
         }
      }

      protected void Load0H27( )
      {
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
            A131CustomerCustomizationBaseColor = T000H5_A131CustomerCustomizationBaseColor[0];
            AssignAttri("", false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
            A40000CustomerCustomizationLogo_GXI = T000H5_A40000CustomerCustomizationLogo_GXI[0];
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
            A40001CustomerCustomizationFavicon_G = T000H5_A40001CustomerCustomizationFavicon_G[0];
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
            A132CustomerCustomizationFontSize = T000H5_A132CustomerCustomizationFontSize[0];
            AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
            A3CustomerName = T000H5_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A1CustomerId = T000H5_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A129CustomerCustomizationLogo = T000H5_A129CustomerCustomizationLogo[0];
            AssignAttri("", false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
            A130CustomerCustomizationFavicon = T000H5_A130CustomerCustomizationFavicon[0];
            AssignAttri("", false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
            ZM0H27( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0H27( ) ;
      }

      protected void OnLoadActions0H27( )
      {
      }

      protected void CheckExtendedTable0H27( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000H4_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( short A1CustomerId )
      {
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000H6_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A3CustomerName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0H27( )
      {
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H27( 9) ;
            RcdFound27 = 1;
            A128CustomerCustomizationId = T000H3_A128CustomerCustomizationId[0];
            AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
            A131CustomerCustomizationBaseColor = T000H3_A131CustomerCustomizationBaseColor[0];
            AssignAttri("", false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
            A40000CustomerCustomizationLogo_GXI = T000H3_A40000CustomerCustomizationLogo_GXI[0];
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
            A40001CustomerCustomizationFavicon_G = T000H3_A40001CustomerCustomizationFavicon_G[0];
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
            A132CustomerCustomizationFontSize = T000H3_A132CustomerCustomizationFontSize[0];
            AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
            A1CustomerId = T000H3_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A129CustomerCustomizationLogo = T000H3_A129CustomerCustomizationLogo[0];
            AssignAttri("", false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
            AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
            A130CustomerCustomizationFavicon = T000H3_A130CustomerCustomizationFavicon[0];
            AssignAttri("", false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
            AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
            Z128CustomerCustomizationId = A128CustomerCustomizationId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0H27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0H27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H27( ) ;
         if ( RcdFound27 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound27 = 0;
         /* Using cursor T000H8 */
         pr_default.execute(6, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000H8_A128CustomerCustomizationId[0] < A128CustomerCustomizationId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000H8_A128CustomerCustomizationId[0] > A128CustomerCustomizationId ) ) )
            {
               A128CustomerCustomizationId = T000H8_A128CustomerCustomizationId[0];
               AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A128CustomerCustomizationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000H9_A128CustomerCustomizationId[0] > A128CustomerCustomizationId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000H9_A128CustomerCustomizationId[0] < A128CustomerCustomizationId ) ) )
            {
               A128CustomerCustomizationId = T000H9_A128CustomerCustomizationId[0];
               AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
               {
                  A128CustomerCustomizationId = Z128CustomerCustomizationId;
                  AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUSTOMERCUSTOMIZATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerCustomizationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H27( ) ;
                  GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
               {
                  /* Insert record */
                  GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUSTOMERCUSTOMIZATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtCustomerCustomizationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H27( ) ;
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
         if ( A128CustomerCustomizationId != Z128CustomerCustomizationId )
         {
            A128CustomerCustomizationId = Z128CustomerCustomizationId;
            AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUSTOMERCUSTOMIZATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerCustomizationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = imgCustomerCustomizationLogo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A128CustomerCustomizationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerCustomization"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131CustomerCustomizationBaseColor, T000H2_A131CustomerCustomizationBaseColor[0]) != 0 ) || ( StringUtil.StrCmp(Z132CustomerCustomizationFontSize, T000H2_A132CustomerCustomizationFontSize[0]) != 0 ) || ( Z1CustomerId != T000H2_A1CustomerId[0] ) )
            {
               if ( StringUtil.StrCmp(Z131CustomerCustomizationBaseColor, T000H2_A131CustomerCustomizationBaseColor[0]) != 0 )
               {
                  GXUtil.WriteLog("customercustomization:[seudo value changed for attri]"+"CustomerCustomizationBaseColor");
                  GXUtil.WriteLogRaw("Old: ",Z131CustomerCustomizationBaseColor);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A131CustomerCustomizationBaseColor[0]);
               }
               if ( StringUtil.StrCmp(Z132CustomerCustomizationFontSize, T000H2_A132CustomerCustomizationFontSize[0]) != 0 )
               {
                  GXUtil.WriteLog("customercustomization:[seudo value changed for attri]"+"CustomerCustomizationFontSize");
                  GXUtil.WriteLogRaw("Old: ",Z132CustomerCustomizationFontSize);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A132CustomerCustomizationFontSize[0]);
               }
               if ( Z1CustomerId != T000H2_A1CustomerId[0] )
               {
                  GXUtil.WriteLog("customercustomization:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z1CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A1CustomerId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CustomerCustomization"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H27( )
      {
         if ( ! IsAuthorized("customercustomization_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H27( 0) ;
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H10 */
                     pr_default.execute(8, new Object[] {A131CustomerCustomizationBaseColor, A129CustomerCustomizationLogo, A40000CustomerCustomizationLogo_GXI, A130CustomerCustomizationFavicon, A40001CustomerCustomizationFavicon_G, A132CustomerCustomizationFontSize, A1CustomerId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000H11 */
                     pr_default.execute(9);
                     A128CustomerCustomizationId = T000H11_A128CustomerCustomizationId[0];
                     AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0H0( ) ;
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
               Load0H27( ) ;
            }
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void Update0H27( )
      {
         if ( ! IsAuthorized("customercustomization_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H12 */
                     pr_default.execute(10, new Object[] {A131CustomerCustomizationBaseColor, A132CustomerCustomizationFontSize, A1CustomerId, A128CustomerCustomizationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CustomerCustomization"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H27( ) ;
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
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void DeferredUpdate0H27( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000H13 */
            pr_default.execute(11, new Object[] {A129CustomerCustomizationLogo, A40000CustomerCustomizationLogo_GXI, A128CustomerCustomizationId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000H14 */
            pr_default.execute(12, new Object[] {A130CustomerCustomizationFavicon, A40001CustomerCustomizationFavicon_G, A128CustomerCustomizationId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("customercustomization_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H27( ) ;
            AfterConfirm0H27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H15 */
                  pr_default.execute(13, new Object[] {A128CustomerCustomizationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("CustomerCustomization");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H27( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000H16 */
            pr_default.execute(14, new Object[] {A1CustomerId});
            A3CustomerName = T000H16_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            pr_default.close(14);
         }
      }

      protected void EndLevel0H27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("customercustomization",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("customercustomization",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H27( )
      {
         /* Scan By routine */
         /* Using cursor T000H17 */
         pr_default.execute(15);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound27 = 1;
            A128CustomerCustomizationId = T000H17_A128CustomerCustomizationId[0];
            AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H27( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound27 = 1;
            A128CustomerCustomizationId = T000H17_A128CustomerCustomizationId[0];
            AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         }
      }

      protected void ScanEnd0H27( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0H27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H27( )
      {
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
         imgCustomerCustomizationLogo_Enabled = 0;
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCustomerCustomizationLogo_Enabled), 5, 0), true);
         imgCustomerCustomizationFavicon_Enabled = 0;
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCustomerCustomizationFavicon_Enabled), 5, 0), true);
         cmbCustomerCustomizationFontSize.Enabled = 0;
         AssignProp("", false, cmbCustomerCustomizationFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCustomerCustomizationFontSize.Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerCustomizationId_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationId_Enabled), 5, 0), true);
         edtCustomerCustomizationBaseColor_Enabled = 0;
         AssignProp("", false, edtCustomerCustomizationBaseColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerCustomizationBaseColor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("customercustomization.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV22CustomerCustomizationId,4,0))}, new string[] {"Gx_mode","CustomerCustomizationId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CustomerCustomization");
         forbiddenHiddens.Add("CustomerCustomizationId", context.localUtil.Format( (decimal)(A128CustomerCustomizationId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("customercustomization:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z128CustomerCustomizationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z131CustomerCustomizationBaseColor", Z131CustomerCustomizationBaseColor);
         GxWebStd.gx_hidden_field( context, "Z132CustomerCustomizationFontSize", Z132CustomerCustomizationFontSize);
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCUSTOMERCUSTOMIZATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22CustomerCustomizationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCUSTOMERCUSTOMIZATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22CustomerCustomizationId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERCUSTOMIZATIONLOGO_GXI", A40000CustomerCustomizationLogo_GXI);
         GxWebStd.gx_hidden_field( context, "CUSTOMERCUSTOMIZATIONFAVICON_G", A40001CustomerCustomizationFavicon_G);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GXCCtlgxBlob = "CUSTOMERCUSTOMIZATIONLOGO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A129CustomerCustomizationLogo);
         GXCCtlgxBlob = "CUSTOMERCUSTOMIZATIONFAVICON" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A130CustomerCustomizationFavicon);
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Objectcall", StringUtil.RTrim( Ddc_selectcolor_Objectcall));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Enabled", StringUtil.BoolToStr( Ddc_selectcolor_Enabled));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Caption", StringUtil.RTrim( Ddc_selectcolor_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SELECTCOLOR_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_selectcolor_Componentwidth), 9, 0, ".", "")));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
         return formatLink("customercustomization.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV22CustomerCustomizationId,4,0))}, new string[] {"Gx_mode","CustomerCustomizationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CustomerCustomization" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Customer Customization", "") ;
      }

      protected void InitializeNonKey0H27( )
      {
         A1CustomerId = 0;
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         A131CustomerCustomizationBaseColor = "";
         AssignAttri("", false, "A131CustomerCustomizationBaseColor", A131CustomerCustomizationBaseColor);
         A129CustomerCustomizationLogo = "";
         AssignAttri("", false, "A129CustomerCustomizationLogo", A129CustomerCustomizationLogo);
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
         A40000CustomerCustomizationLogo_GXI = "";
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A129CustomerCustomizationLogo)) ? A40000CustomerCustomizationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A129CustomerCustomizationLogo))), true);
         AssignProp("", false, imgCustomerCustomizationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A129CustomerCustomizationLogo), true);
         A130CustomerCustomizationFavicon = "";
         AssignAttri("", false, "A130CustomerCustomizationFavicon", A130CustomerCustomizationFavicon);
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
         A40001CustomerCustomizationFavicon_G = "";
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A130CustomerCustomizationFavicon)) ? A40001CustomerCustomizationFavicon_G : context.convertURL( context.PathToRelativeUrl( A130CustomerCustomizationFavicon))), true);
         AssignProp("", false, imgCustomerCustomizationFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A130CustomerCustomizationFavicon), true);
         A132CustomerCustomizationFontSize = "";
         AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
         A3CustomerName = "";
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         Z131CustomerCustomizationBaseColor = "";
         Z132CustomerCustomizationFontSize = "";
         Z1CustomerId = 0;
      }

      protected void InitAll0H27( )
      {
         A128CustomerCustomizationId = 0;
         AssignAttri("", false, "A128CustomerCustomizationId", StringUtil.LTrimStr( (decimal)(A128CustomerCustomizationId), 4, 0));
         InitializeNonKey0H27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249131554825", true, true);
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
         context.AddJavascriptSource("customercustomization.js", "?20249131554827", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCustomerName_Internalname = "CUSTOMERNAME";
         imgCustomerCustomizationLogo_Internalname = "CUSTOMERCUSTOMIZATIONLOGO";
         imgCustomerCustomizationFavicon_Internalname = "CUSTOMERCUSTOMIZATIONFAVICON";
         cmbCustomerCustomizationFontSize_Internalname = "CUSTOMERCUSTOMIZATIONFONTSIZE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         Ddc_selectcolor_Internalname = "DDC_SELECTCOLOR";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTableform_Internalname = "TABLEFORM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerCustomizationId_Internalname = "CUSTOMERCUSTOMIZATIONID";
         edtCustomerCustomizationBaseColor_Internalname = "CUSTOMERCUSTOMIZATIONBASECOLOR";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Customer Customization", "");
         edtCustomerCustomizationBaseColor_Jsonclick = "";
         edtCustomerCustomizationBaseColor_Enabled = 1;
         edtCustomerCustomizationBaseColor_Visible = 1;
         edtCustomerCustomizationId_Jsonclick = "";
         edtCustomerCustomizationId_Enabled = 0;
         edtCustomerCustomizationId_Visible = 1;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtCustomerId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Ddc_selectcolor_Componentwidth = 300;
         Ddc_selectcolor_Caption = context.GetMessage( "Select Color", "");
         cmbCustomerCustomizationFontSize_Jsonclick = "";
         cmbCustomerCustomizationFontSize.Enabled = 1;
         imgCustomerCustomizationFavicon_Enabled = 1;
         imgCustomerCustomizationLogo_Enabled = 1;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
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

      protected void GX5ASACUSTOMERID0H27( short AV12Insert_CustomerId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CustomerId) )
         {
            A1CustomerId = AV12Insert_CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         else
         {
            GXt_int2 = A1CustomerId;
            new getloggedinusercustomerid(context ).execute( out  GXt_int2) ;
            A1CustomerId = GXt_int2;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbCustomerCustomizationFontSize.Name = "CUSTOMERCUSTOMIZATIONFONTSIZE";
         cmbCustomerCustomizationFontSize.WebTags = "";
         cmbCustomerCustomizationFontSize.addItem("", context.GetMessage( "Select Font Size", ""), 0);
         cmbCustomerCustomizationFontSize.addItem("Small", context.GetMessage( "Small", ""), 0);
         cmbCustomerCustomizationFontSize.addItem("Medium", context.GetMessage( "Medium", ""), 0);
         cmbCustomerCustomizationFontSize.addItem("Large", context.GetMessage( "Large", ""), 0);
         if ( cmbCustomerCustomizationFontSize.ItemCount > 0 )
         {
            A132CustomerCustomizationFontSize = cmbCustomerCustomizationFontSize.getValidValue(A132CustomerCustomizationFontSize);
            AssignAttri("", false, "A132CustomerCustomizationFontSize", A132CustomerCustomizationFontSize);
         }
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
         /* Using cursor T000H16 */
         pr_default.execute(14, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A3CustomerName = T000H16_A3CustomerName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV22CustomerCustomizationId","fld":"vCUSTOMERCUSTOMIZATIONID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV22CustomerCustomizationId","fld":"vCUSTOMERCUSTOMIZATIONID","pic":"ZZZ9","hsh":true},{"av":"A128CustomerCustomizationId","fld":"CUSTOMERCUSTOMIZATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120H2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("CUSTOMERCUSTOMIZATIONFONTSIZE.CONTROLVALUECHANGED","""{"handler":"E130H2","iparms":[{"av":"cmbCustomerCustomizationFontSize"},{"av":"A132CustomerCustomizationFontSize","fld":"CUSTOMERCUSTOMIZATIONFONTSIZE"}]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A3CustomerName","fld":"CUSTOMERNAME"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A3CustomerName","fld":"CUSTOMERNAME"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z131CustomerCustomizationBaseColor = "";
         Z132CustomerCustomizationFontSize = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A132CustomerCustomizationFontSize = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A3CustomerName = "";
         A129CustomerCustomizationLogo = "";
         A40000CustomerCustomizationLogo_GXI = "";
         sImgUrl = "";
         A130CustomerCustomizationFavicon = "";
         A40001CustomerCustomizationFavicon_G = "";
         lblTextblock1_Jsonclick = "";
         ucDdc_selectcolor = new GXUserControl();
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A131CustomerCustomizationBaseColor = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV31Pgmname = "";
         Ddc_selectcolor_Objectcall = "";
         Ddc_selectcolor_Class = "";
         Ddc_selectcolor_Icontype = "";
         Ddc_selectcolor_Icon = "";
         Ddc_selectcolor_Tooltip = "";
         Ddc_selectcolor_Cls = "";
         Ddc_selectcolor_Titlecontrolalign = "";
         Ddc_selectcolor_Dropdownoptionstype = "";
         Ddc_selectcolor_Result = "";
         Ddc_selectcolor_Titlecontrolidtoreplace = "";
         Ddc_selectcolor_Load = "";
         Ddc_selectcolor_Trigger = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode27 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV28WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings1 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         Z129CustomerCustomizationLogo = "";
         Z40000CustomerCustomizationLogo_GXI = "";
         Z130CustomerCustomizationFavicon = "";
         Z40001CustomerCustomizationFavicon_G = "";
         Z3CustomerName = "";
         T000H4_A3CustomerName = new string[] {""} ;
         T000H5_A128CustomerCustomizationId = new short[1] ;
         T000H5_A131CustomerCustomizationBaseColor = new string[] {""} ;
         T000H5_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         T000H5_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         T000H5_A132CustomerCustomizationFontSize = new string[] {""} ;
         T000H5_A3CustomerName = new string[] {""} ;
         T000H5_A1CustomerId = new short[1] ;
         T000H5_A129CustomerCustomizationLogo = new string[] {""} ;
         T000H5_A130CustomerCustomizationFavicon = new string[] {""} ;
         T000H6_A3CustomerName = new string[] {""} ;
         T000H7_A128CustomerCustomizationId = new short[1] ;
         T000H3_A128CustomerCustomizationId = new short[1] ;
         T000H3_A131CustomerCustomizationBaseColor = new string[] {""} ;
         T000H3_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         T000H3_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         T000H3_A132CustomerCustomizationFontSize = new string[] {""} ;
         T000H3_A1CustomerId = new short[1] ;
         T000H3_A129CustomerCustomizationLogo = new string[] {""} ;
         T000H3_A130CustomerCustomizationFavicon = new string[] {""} ;
         T000H8_A128CustomerCustomizationId = new short[1] ;
         T000H9_A128CustomerCustomizationId = new short[1] ;
         T000H2_A128CustomerCustomizationId = new short[1] ;
         T000H2_A131CustomerCustomizationBaseColor = new string[] {""} ;
         T000H2_A40000CustomerCustomizationLogo_GXI = new string[] {""} ;
         T000H2_A40001CustomerCustomizationFavicon_G = new string[] {""} ;
         T000H2_A132CustomerCustomizationFontSize = new string[] {""} ;
         T000H2_A1CustomerId = new short[1] ;
         T000H2_A129CustomerCustomizationLogo = new string[] {""} ;
         T000H2_A130CustomerCustomizationFavicon = new string[] {""} ;
         T000H11_A128CustomerCustomizationId = new short[1] ;
         T000H16_A3CustomerName = new string[] {""} ;
         T000H17_A128CustomerCustomizationId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.customercustomization__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.customercustomization__default(),
            new Object[][] {
                new Object[] {
               T000H2_A128CustomerCustomizationId, T000H2_A131CustomerCustomizationBaseColor, T000H2_A40000CustomerCustomizationLogo_GXI, T000H2_A40001CustomerCustomizationFavicon_G, T000H2_A132CustomerCustomizationFontSize, T000H2_A1CustomerId, T000H2_A129CustomerCustomizationLogo, T000H2_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               T000H3_A128CustomerCustomizationId, T000H3_A131CustomerCustomizationBaseColor, T000H3_A40000CustomerCustomizationLogo_GXI, T000H3_A40001CustomerCustomizationFavicon_G, T000H3_A132CustomerCustomizationFontSize, T000H3_A1CustomerId, T000H3_A129CustomerCustomizationLogo, T000H3_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               T000H4_A3CustomerName
               }
               , new Object[] {
               T000H5_A128CustomerCustomizationId, T000H5_A131CustomerCustomizationBaseColor, T000H5_A40000CustomerCustomizationLogo_GXI, T000H5_A40001CustomerCustomizationFavicon_G, T000H5_A132CustomerCustomizationFontSize, T000H5_A3CustomerName, T000H5_A1CustomerId, T000H5_A129CustomerCustomizationLogo, T000H5_A130CustomerCustomizationFavicon
               }
               , new Object[] {
               T000H6_A3CustomerName
               }
               , new Object[] {
               T000H7_A128CustomerCustomizationId
               }
               , new Object[] {
               T000H8_A128CustomerCustomizationId
               }
               , new Object[] {
               T000H9_A128CustomerCustomizationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000H11_A128CustomerCustomizationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H16_A3CustomerName
               }
               , new Object[] {
               T000H17_A128CustomerCustomizationId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV31Pgmname = "CustomerCustomization";
      }

      private short wcpOAV22CustomerCustomizationId ;
      private short Z128CustomerCustomizationId ;
      private short Z1CustomerId ;
      private short N1CustomerId ;
      private short GxWebError ;
      private short AV12Insert_CustomerId ;
      private short A1CustomerId ;
      private short AV22CustomerCustomizationId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A128CustomerCustomizationId ;
      private short RcdFound27 ;
      private short nCmpId ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short GXt_int2 ;
      private int trnEnded ;
      private int divTablecontent_Width ;
      private int edtCustomerName_Enabled ;
      private int imgCustomerCustomizationLogo_Enabled ;
      private int imgCustomerCustomizationFavicon_Enabled ;
      private int Ddc_selectcolor_Componentwidth ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCustomerId_Visible ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerCustomizationId_Enabled ;
      private int edtCustomerCustomizationId_Visible ;
      private int edtCustomerCustomizationBaseColor_Visible ;
      private int edtCustomerCustomizationBaseColor_Enabled ;
      private int Ddc_selectcolor_Gxcontroltype ;
      private int AV32GXV1 ;
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
      private string imgCustomerCustomizationLogo_Internalname ;
      private string cmbCustomerCustomizationFontSize_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtCustomerName_Internalname ;
      private string TempTags ;
      private string edtCustomerName_Jsonclick ;
      private string divTableform_Internalname ;
      private string sImgUrl ;
      private string imgCustomerCustomizationFavicon_Internalname ;
      private string cmbCustomerCustomizationFontSize_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string Ddc_selectcolor_Caption ;
      private string Ddc_selectcolor_Internalname ;
      private string divActionstable_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerCustomizationId_Internalname ;
      private string edtCustomerCustomizationId_Jsonclick ;
      private string edtCustomerCustomizationBaseColor_Internalname ;
      private string edtCustomerCustomizationBaseColor_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string AV31Pgmname ;
      private string Ddc_selectcolor_Objectcall ;
      private string Ddc_selectcolor_Class ;
      private string Ddc_selectcolor_Icontype ;
      private string Ddc_selectcolor_Icon ;
      private string Ddc_selectcolor_Tooltip ;
      private string Ddc_selectcolor_Cls ;
      private string Ddc_selectcolor_Titlecontrolalign ;
      private string Ddc_selectcolor_Dropdownoptionstype ;
      private string Ddc_selectcolor_Result ;
      private string Ddc_selectcolor_Titlecontrolidtoreplace ;
      private string Ddc_selectcolor_Load ;
      private string Ddc_selectcolor_Trigger ;
      private string hsh ;
      private string sMode27 ;
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
      private bool A129CustomerCustomizationLogo_IsBlob ;
      private bool A130CustomerCustomizationFavicon_IsBlob ;
      private bool Ddc_selectcolor_Enabled ;
      private bool Ddc_selectcolor_Visible ;
      private bool Ddc_selectcolor_Showloading ;
      private bool Ddc_selectcolor_Keepopened ;
      private bool returnInSub ;
      private string Z131CustomerCustomizationBaseColor ;
      private string Z132CustomerCustomizationFontSize ;
      private string A132CustomerCustomizationFontSize ;
      private string A3CustomerName ;
      private string A40000CustomerCustomizationLogo_GXI ;
      private string A40001CustomerCustomizationFavicon_G ;
      private string A131CustomerCustomizationBaseColor ;
      private string Z40000CustomerCustomizationLogo_GXI ;
      private string Z40001CustomerCustomizationFavicon_G ;
      private string Z3CustomerName ;
      private string A129CustomerCustomizationLogo ;
      private string A130CustomerCustomizationFavicon ;
      private string Z129CustomerCustomizationLogo ;
      private string Z130CustomerCustomizationFavicon ;
      private IGxSession AV11WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDdc_selectcolor ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCustomerCustomizationFontSize ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV28WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings1 ;
      private IDataStoreProvider pr_default ;
      private string[] T000H4_A3CustomerName ;
      private short[] T000H5_A128CustomerCustomizationId ;
      private string[] T000H5_A131CustomerCustomizationBaseColor ;
      private string[] T000H5_A40000CustomerCustomizationLogo_GXI ;
      private string[] T000H5_A40001CustomerCustomizationFavicon_G ;
      private string[] T000H5_A132CustomerCustomizationFontSize ;
      private string[] T000H5_A3CustomerName ;
      private short[] T000H5_A1CustomerId ;
      private string[] T000H5_A129CustomerCustomizationLogo ;
      private string[] T000H5_A130CustomerCustomizationFavicon ;
      private string[] T000H6_A3CustomerName ;
      private short[] T000H7_A128CustomerCustomizationId ;
      private short[] T000H3_A128CustomerCustomizationId ;
      private string[] T000H3_A131CustomerCustomizationBaseColor ;
      private string[] T000H3_A40000CustomerCustomizationLogo_GXI ;
      private string[] T000H3_A40001CustomerCustomizationFavicon_G ;
      private string[] T000H3_A132CustomerCustomizationFontSize ;
      private short[] T000H3_A1CustomerId ;
      private string[] T000H3_A129CustomerCustomizationLogo ;
      private string[] T000H3_A130CustomerCustomizationFavicon ;
      private short[] T000H8_A128CustomerCustomizationId ;
      private short[] T000H9_A128CustomerCustomizationId ;
      private short[] T000H2_A128CustomerCustomizationId ;
      private string[] T000H2_A131CustomerCustomizationBaseColor ;
      private string[] T000H2_A40000CustomerCustomizationLogo_GXI ;
      private string[] T000H2_A40001CustomerCustomizationFavicon_G ;
      private string[] T000H2_A132CustomerCustomizationFontSize ;
      private short[] T000H2_A1CustomerId ;
      private string[] T000H2_A129CustomerCustomizationLogo ;
      private string[] T000H2_A130CustomerCustomizationFavicon ;
      private short[] T000H11_A128CustomerCustomizationId ;
      private string[] T000H16_A3CustomerName ;
      private short[] T000H17_A128CustomerCustomizationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class customercustomization__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class customercustomization__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000H2;
        prmT000H2 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H3;
        prmT000H3 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H4;
        prmT000H4 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000H5;
        prmT000H5 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H6;
        prmT000H6 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000H7;
        prmT000H7 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H8;
        prmT000H8 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H9;
        prmT000H9 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H10;
        prmT000H10 = new Object[] {
        new ParDef("CustomerCustomizationBaseColor",GXType.VarChar,40,0) ,
        new ParDef("CustomerCustomizationLogo",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="CustomerCustomization", Fld="CustomerCustomizationLogo"} ,
        new ParDef("CustomerCustomizationFavicon",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationFavicon_G",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="CustomerCustomization", Fld="CustomerCustomizationFavicon"} ,
        new ParDef("CustomerCustomizationFontSize",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000H11;
        prmT000H11 = new Object[] {
        };
        Object[] prmT000H12;
        prmT000H12 = new Object[] {
        new ParDef("CustomerCustomizationBaseColor",GXType.VarChar,40,0) ,
        new ParDef("CustomerCustomizationFontSize",GXType.VarChar,40,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H13;
        prmT000H13 = new Object[] {
        new ParDef("CustomerCustomizationLogo",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CustomerCustomization", Fld="CustomerCustomizationLogo"} ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H14;
        prmT000H14 = new Object[] {
        new ParDef("CustomerCustomizationFavicon",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("CustomerCustomizationFavicon_G",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CustomerCustomization", Fld="CustomerCustomizationFavicon"} ,
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H15;
        prmT000H15 = new Object[] {
        new ParDef("CustomerCustomizationId",GXType.Int16,4,0)
        };
        Object[] prmT000H16;
        prmT000H16 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000H17;
        prmT000H17 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000H2", "SELECT CustomerCustomizationId, CustomerCustomizationBaseColor, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId, CustomerCustomizationLogo, CustomerCustomizationFavicon FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId  FOR UPDATE OF CustomerCustomization NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H3", "SELECT CustomerCustomizationId, CustomerCustomizationBaseColor, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId, CustomerCustomizationLogo, CustomerCustomizationFavicon FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H4", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H5", "SELECT TM1.CustomerCustomizationId, TM1.CustomerCustomizationBaseColor, TM1.CustomerCustomizationLogo_GXI, TM1.CustomerCustomizationFavicon_G, TM1.CustomerCustomizationFontSize, T2.CustomerName, TM1.CustomerId, TM1.CustomerCustomizationLogo, TM1.CustomerCustomizationFavicon FROM (CustomerCustomization TM1 INNER JOIN Customer T2 ON T2.CustomerId = TM1.CustomerId) WHERE TM1.CustomerCustomizationId = :CustomerCustomizationId ORDER BY TM1.CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H6", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H7", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE CustomerCustomizationId = :CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H8", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE ( CustomerCustomizationId > :CustomerCustomizationId) ORDER BY CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H9", "SELECT CustomerCustomizationId FROM CustomerCustomization WHERE ( CustomerCustomizationId < :CustomerCustomizationId) ORDER BY CustomerCustomizationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H10", "SAVEPOINT gxupdate;INSERT INTO CustomerCustomization(CustomerCustomizationBaseColor, CustomerCustomizationLogo, CustomerCustomizationLogo_GXI, CustomerCustomizationFavicon, CustomerCustomizationFavicon_G, CustomerCustomizationFontSize, CustomerId) VALUES(:CustomerCustomizationBaseColor, :CustomerCustomizationLogo, :CustomerCustomizationLogo_GXI, :CustomerCustomizationFavicon, :CustomerCustomizationFavicon_G, :CustomerCustomizationFontSize, :CustomerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000H10)
           ,new CursorDef("T000H11", "SELECT currval('CustomerCustomizationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H12", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationBaseColor=:CustomerCustomizationBaseColor, CustomerCustomizationFontSize=:CustomerCustomizationFontSize, CustomerId=:CustomerId  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H12)
           ,new CursorDef("T000H13", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationLogo=:CustomerCustomizationLogo, CustomerCustomizationLogo_GXI=:CustomerCustomizationLogo_GXI  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H13)
           ,new CursorDef("T000H14", "SAVEPOINT gxupdate;UPDATE CustomerCustomization SET CustomerCustomizationFavicon=:CustomerCustomizationFavicon, CustomerCustomizationFavicon_G=:CustomerCustomizationFavicon_G  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H14)
           ,new CursorDef("T000H15", "SAVEPOINT gxupdate;DELETE FROM CustomerCustomization  WHERE CustomerCustomizationId = :CustomerCustomizationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H15)
           ,new CursorDef("T000H16", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H17", "SELECT CustomerCustomizationId FROM CustomerCustomization ORDER BY CustomerCustomizationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H17,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
