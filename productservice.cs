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
   public class productservice : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A71ProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceTypeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A71ProductServiceTypeId) ;
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
               AV7ProductServiceId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductServiceId", StringUtil.LTrimStr( (decimal)(AV7ProductServiceId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductServiceId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Product/Service", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public productservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ProductServiceId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductServiceId = aP1_ProductServiceId;
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
            return "productservice_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_ProductService.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, "Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A74ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A74ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceDescription_Internalname, "Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A75ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", 1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedproductservicetypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproductservicetypeid_Internalname, "Type", "", "", lblTextblockproductservicetypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_productservicetypeid.SetProperty("Caption", Combo_productservicetypeid_Caption);
         ucCombo_productservicetypeid.SetProperty("Cls", Combo_productservicetypeid_Cls);
         ucCombo_productservicetypeid.SetProperty("DataListProc", Combo_productservicetypeid_Datalistproc);
         ucCombo_productservicetypeid.SetProperty("DataListProcParametersPrefix", Combo_productservicetypeid_Datalistprocparametersprefix);
         ucCombo_productservicetypeid.SetProperty("EmptyItem", Combo_productservicetypeid_Emptyitem);
         ucCombo_productservicetypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_productservicetypeid.SetProperty("DropDownOptionsData", AV15ProductServiceTypeId_Data);
         ucCombo_productservicetypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_productservicetypeid_Internalname, "COMBO_PRODUCTSERVICETYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceTypeId_Internalname, "Product Service Type Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceTypeId_Visible, edtProductServiceTypeId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductServicePicture_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Picture", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A77ProductServicePicture_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServicePicture_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture));
         GxWebStd.gx_bitmap( context, imgProductServicePicture_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServicePicture_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", "", "", 0, A77ProductServicePicture_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProductService.htm");
         AssignProp("", false, imgProductServicePicture_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture)), true);
         AssignProp("", false, imgProductServicePicture_Internalname, "IsBlob", StringUtil.BoolToStr( A77ProductServicePicture_IsBlob), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductService.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_productservicetypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboproductservicetypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboProductServiceTypeId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavComboproductservicetypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboProductServiceTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(AV20ComboProductServiceTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboproductservicetypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboproductservicetypeid_Visible, edtavComboproductservicetypeid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductServiceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9") : context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, edtProductServiceId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductServiceQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceQuantity_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceQuantity_Visible, edtProductServiceQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProductService.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSERVICETYPEID_DATA"), AV15ProductServiceTypeId_Data);
               /* Read saved values. */
               Z73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z73ProductServiceId"), ".", ","), 18, MidpointRounding.ToEven));
               Z74ProductServiceName = cgiGet( "Z74ProductServiceName");
               Z75ProductServiceDescription = cgiGet( "Z75ProductServiceDescription");
               Z76ProductServiceQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z76ProductServiceQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               Z71ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z71ProductServiceTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N71ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N71ProductServiceTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTSERVICEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTSERVICETYPEID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000ProductServicePicture_GXI = cgiGet( "PRODUCTSERVICEPICTURE_GXI");
               A72ProductServiceTypeName = cgiGet( "PRODUCTSERVICETYPENAME");
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_productservicetypeid_Objectcall = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Objectcall");
               Combo_productservicetypeid_Class = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Class");
               Combo_productservicetypeid_Icontype = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Icontype");
               Combo_productservicetypeid_Icon = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Icon");
               Combo_productservicetypeid_Caption = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Caption");
               Combo_productservicetypeid_Tooltip = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Tooltip");
               Combo_productservicetypeid_Cls = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Cls");
               Combo_productservicetypeid_Selectedvalue_set = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Selectedvalue_set");
               Combo_productservicetypeid_Selectedvalue_get = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Selectedvalue_get");
               Combo_productservicetypeid_Selectedtext_set = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Selectedtext_set");
               Combo_productservicetypeid_Selectedtext_get = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Selectedtext_get");
               Combo_productservicetypeid_Gamoauthtoken = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Gamoauthtoken");
               Combo_productservicetypeid_Ddointernalname = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Ddointernalname");
               Combo_productservicetypeid_Titlecontrolalign = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Titlecontrolalign");
               Combo_productservicetypeid_Dropdownoptionstype = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Dropdownoptionstype");
               Combo_productservicetypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Enabled"));
               Combo_productservicetypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Visible"));
               Combo_productservicetypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Titlecontrolidtoreplace");
               Combo_productservicetypeid_Datalisttype = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Datalisttype");
               Combo_productservicetypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Allowmultipleselection"));
               Combo_productservicetypeid_Datalistfixedvalues = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Datalistfixedvalues");
               Combo_productservicetypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Isgriditem"));
               Combo_productservicetypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Hasdescription"));
               Combo_productservicetypeid_Datalistproc = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Datalistproc");
               Combo_productservicetypeid_Datalistprocparametersprefix = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Datalistprocparametersprefix");
               Combo_productservicetypeid_Remoteservicesparameters = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Remoteservicesparameters");
               Combo_productservicetypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_productservicetypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Includeonlyselectedoption"));
               Combo_productservicetypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Includeselectalloption"));
               Combo_productservicetypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Emptyitem"));
               Combo_productservicetypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Includeaddnewoption"));
               Combo_productservicetypeid_Htmltemplate = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Htmltemplate");
               Combo_productservicetypeid_Multiplevaluestype = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Multiplevaluestype");
               Combo_productservicetypeid_Loadingdata = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Loadingdata");
               Combo_productservicetypeid_Noresultsfound = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Noresultsfound");
               Combo_productservicetypeid_Emptyitemtext = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Emptyitemtext");
               Combo_productservicetypeid_Onlyselectedvalues = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Onlyselectedvalues");
               Combo_productservicetypeid_Selectalltext = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Selectalltext");
               Combo_productservicetypeid_Multiplevaluesseparator = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Multiplevaluesseparator");
               Combo_productservicetypeid_Addnewoptiontext = cgiGet( "COMBO_PRODUCTSERVICETYPEID_Addnewoptiontext");
               Combo_productservicetypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICETYPEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A74ProductServiceName = cgiGet( edtProductServiceName_Internalname);
               AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
               A75ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
               AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductServiceTypeId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductServiceTypeId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTSERVICETYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtProductServiceTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A71ProductServiceTypeId = 0;
                  AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
               }
               else
               {
                  A71ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
               }
               A77ProductServicePicture = cgiGet( imgProductServicePicture_Internalname);
               AssignAttri("", false, "A77ProductServicePicture", A77ProductServicePicture);
               AV20ComboProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboproductservicetypeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboProductServiceTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboProductServiceTypeId), 4, 0));
               A73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductServiceQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductServiceQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTSERVICEQUANTITY");
                  AnyError = 1;
                  GX_FocusControl = edtProductServiceQuantity_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A76ProductServiceQuantity = 0;
                  AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrimStr( (decimal)(A76ProductServiceQuantity), 4, 0));
               }
               else
               {
                  A76ProductServiceQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrimStr( (decimal)(A76ProductServiceQuantity), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServicePicture_Internalname, ref  A77ProductServicePicture, ref  A40000ProductServicePicture_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ProductService");
               A73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
               forbiddenHiddens.Add("ProductServiceId", context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A73ProductServiceId != Z73ProductServiceId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("productservice:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A73ProductServiceId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
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
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode11;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTSERVICEID");
                        AnyError = 1;
                        GX_FocusControl = edtProductServiceId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0611( ) ;
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
            DisableAttributes0611( ) ;
         }
         AssignProp("", false, edtavComboproductservicetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductservicetypeid_Enabled), 5, 0), true);
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

      protected void CONFIRM_060( )
      {
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0611( ) ;
            }
            else
            {
               CheckExtendedTable0611( ) ;
               CloseExtendedTableCursors0611( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
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
         Combo_productservicetypeid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "GAMOAuthToken", Combo_productservicetypeid_Gamoauthtoken);
         edtProductServiceTypeId_Visible = 0;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Visible), 5, 0), true);
         AV20ComboProductServiceTypeId = 0;
         AssignAttri("", false, "AV20ComboProductServiceTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboProductServiceTypeId), 4, 0));
         edtavComboproductservicetypeid_Visible = 0;
         AssignProp("", false, edtavComboproductservicetypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboproductservicetypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPRODUCTSERVICETYPEID' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProductServiceTypeId") == 0 )
               {
                  AV13Insert_ProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(AV13Insert_ProductServiceTypeId), 4, 0));
                  if ( ! (0==AV13Insert_ProductServiceTypeId) )
                  {
                     AV20ComboProductServiceTypeId = AV13Insert_ProductServiceTypeId;
                     AssignAttri("", false, "AV20ComboProductServiceTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboProductServiceTypeId), 4, 0));
                     Combo_productservicetypeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboProductServiceTypeId), 4, 0));
                     ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "SelectedValue_set", Combo_productservicetypeid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new productserviceloaddvcombo(context ).execute(  "ProductServiceTypeId",  "GET",  false,  AV7ProductServiceId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_productservicetypeid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "SelectedText_set", Combo_productservicetypeid_Selectedtext_set);
                     Combo_productservicetypeid_Enabled = false;
                     ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productservicetypeid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtProductServiceId_Visible = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         edtProductServiceQuantity_Visible = 0;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Visible), 5, 0), true);
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("productserviceww.aspx") );
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
         /* 'LOADCOMBOPRODUCTSERVICETYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new productserviceloaddvcombo(context ).execute(  "ProductServiceTypeId",  Gx_mode,  false,  AV7ProductServiceId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_productservicetypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "SelectedValue_set", Combo_productservicetypeid_Selectedvalue_set);
         Combo_productservicetypeid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "SelectedText_set", Combo_productservicetypeid_Selectedtext_set);
         AV20ComboProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboProductServiceTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboProductServiceTypeId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_productservicetypeid_Enabled = false;
            ucCombo_productservicetypeid.SendProperty(context, "", false, Combo_productservicetypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productservicetypeid_Enabled));
         }
      }

      protected void ZM0611( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z74ProductServiceName = T00063_A74ProductServiceName[0];
               Z75ProductServiceDescription = T00063_A75ProductServiceDescription[0];
               Z76ProductServiceQuantity = T00063_A76ProductServiceQuantity[0];
               Z71ProductServiceTypeId = T00063_A71ProductServiceTypeId[0];
            }
            else
            {
               Z74ProductServiceName = A74ProductServiceName;
               Z75ProductServiceDescription = A75ProductServiceDescription;
               Z76ProductServiceQuantity = A76ProductServiceQuantity;
               Z71ProductServiceTypeId = A71ProductServiceTypeId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z73ProductServiceId = A73ProductServiceId;
            Z74ProductServiceName = A74ProductServiceName;
            Z75ProductServiceDescription = A75ProductServiceDescription;
            Z76ProductServiceQuantity = A76ProductServiceQuantity;
            Z77ProductServicePicture = A77ProductServicePicture;
            Z40000ProductServicePicture_GXI = A40000ProductServicePicture_GXI;
            Z71ProductServiceTypeId = A71ProductServiceTypeId;
            Z72ProductServiceTypeName = A72ProductServiceTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         AV23Pgmname = "ProductService";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProductServiceId) )
         {
            A73ProductServiceId = AV7ProductServiceId;
            AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProductServiceTypeId) )
         {
            edtProductServiceTypeId_Enabled = 0;
            AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductServiceTypeId_Enabled = 1;
            AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProductServiceTypeId) )
         {
            A71ProductServiceTypeId = AV13Insert_ProductServiceTypeId;
            AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
         }
         else
         {
            A71ProductServiceTypeId = AV20ComboProductServiceTypeId;
            AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
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
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = T00064_A72ProductServiceTypeName[0];
            pr_default.close(2);
         }
      }

      protected void Load0611( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A74ProductServiceName = T00065_A74ProductServiceName[0];
            AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
            A75ProductServiceDescription = T00065_A75ProductServiceDescription[0];
            AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
            A76ProductServiceQuantity = T00065_A76ProductServiceQuantity[0];
            AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrimStr( (decimal)(A76ProductServiceQuantity), 4, 0));
            A40000ProductServicePicture_GXI = T00065_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
            AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A72ProductServiceTypeName = T00065_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = T00065_A71ProductServiceTypeId[0];
            AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
            A77ProductServicePicture = T00065_A77ProductServicePicture[0];
            AssignAttri("", false, "A77ProductServicePicture", A77ProductServicePicture);
            AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
            AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            ZM0611( -11) ;
         }
         pr_default.close(3);
         OnLoadActions0611( ) ;
      }

      protected void OnLoadActions0611( )
      {
      }

      protected void CheckExtendedTable0611( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A74ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Product Service Name", "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICENAME");
            AnyError = 1;
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A75ProductServiceDescription)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Product Service Description", "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICEDESCRIPTION");
            AnyError = 1;
            GX_FocusControl = edtProductServiceDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Service Type'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ProductServiceTypeName = T00064_A72ProductServiceTypeName[0];
         pr_default.close(2);
         if ( (0==A71ProductServiceTypeId) )
         {
            GX_msglist.addItem("Product/Service Type is required", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0611( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( short A71ProductServiceTypeId )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Service Type'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A72ProductServiceTypeName = T00066_A72ProductServiceTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A72ProductServiceTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0611( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0611( 11) ;
            RcdFound11 = 1;
            A73ProductServiceId = T00063_A73ProductServiceId[0];
            AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
            A74ProductServiceName = T00063_A74ProductServiceName[0];
            AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
            A75ProductServiceDescription = T00063_A75ProductServiceDescription[0];
            AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
            A76ProductServiceQuantity = T00063_A76ProductServiceQuantity[0];
            AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrimStr( (decimal)(A76ProductServiceQuantity), 4, 0));
            A40000ProductServicePicture_GXI = T00063_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
            AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A71ProductServiceTypeId = T00063_A71ProductServiceTypeId[0];
            AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
            A77ProductServicePicture = T00063_A77ProductServicePicture[0];
            AssignAttri("", false, "A77ProductServicePicture", A77ProductServicePicture);
            AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
            AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            Z73ProductServiceId = A73ProductServiceId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0611( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0611( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0611( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0611( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00068_A73ProductServiceId[0] < A73ProductServiceId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00068_A73ProductServiceId[0] > A73ProductServiceId ) ) )
            {
               A73ProductServiceId = T00068_A73ProductServiceId[0];
               AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00069_A73ProductServiceId[0] > A73ProductServiceId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00069_A73ProductServiceId[0] < A73ProductServiceId ) ) )
            {
               A73ProductServiceId = T00069_A73ProductServiceId[0];
               AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0611( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0611( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A73ProductServiceId != Z73ProductServiceId )
               {
                  A73ProductServiceId = Z73ProductServiceId;
                  AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTSERVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0611( ) ;
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A73ProductServiceId != Z73ProductServiceId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0611( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductServiceName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0611( ) ;
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
         if ( A73ProductServiceId != Z73ProductServiceId )
         {
            A73ProductServiceId = Z73ProductServiceId;
            AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0611( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z74ProductServiceName, T00062_A74ProductServiceName[0]) != 0 ) || ( StringUtil.StrCmp(Z75ProductServiceDescription, T00062_A75ProductServiceDescription[0]) != 0 ) || ( Z76ProductServiceQuantity != T00062_A76ProductServiceQuantity[0] ) || ( Z71ProductServiceTypeId != T00062_A71ProductServiceTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z74ProductServiceName, T00062_A74ProductServiceName[0]) != 0 )
               {
                  GXUtil.WriteLog("productservice:[seudo value changed for attri]"+"ProductServiceName");
                  GXUtil.WriteLogRaw("Old: ",Z74ProductServiceName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A74ProductServiceName[0]);
               }
               if ( StringUtil.StrCmp(Z75ProductServiceDescription, T00062_A75ProductServiceDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("productservice:[seudo value changed for attri]"+"ProductServiceDescription");
                  GXUtil.WriteLogRaw("Old: ",Z75ProductServiceDescription);
                  GXUtil.WriteLogRaw("Current: ",T00062_A75ProductServiceDescription[0]);
               }
               if ( Z76ProductServiceQuantity != T00062_A76ProductServiceQuantity[0] )
               {
                  GXUtil.WriteLog("productservice:[seudo value changed for attri]"+"ProductServiceQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z76ProductServiceQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00062_A76ProductServiceQuantity[0]);
               }
               if ( Z71ProductServiceTypeId != T00062_A71ProductServiceTypeId[0] )
               {
                  GXUtil.WriteLog("productservice:[seudo value changed for attri]"+"ProductServiceTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z71ProductServiceTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A71ProductServiceTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0611( )
      {
         if ( ! IsAuthorized("productservice_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0611( 0) ;
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {A74ProductServiceName, A75ProductServiceDescription, A76ProductServiceQuantity, A77ProductServicePicture, A40000ProductServicePicture_GXI, A71ProductServiceTypeId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000611 */
                     pr_default.execute(9);
                     A73ProductServiceId = T000611_A73ProductServiceId[0];
                     AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ProductService");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load0611( ) ;
            }
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void Update0611( )
      {
         if ( ! IsAuthorized("productservice_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0611( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0611( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0611( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000612 */
                     pr_default.execute(10, new Object[] {A74ProductServiceName, A75ProductServiceDescription, A76ProductServiceQuantity, A71ProductServiceTypeId, A73ProductServiceId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ProductService");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProductService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0611( ) ;
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
            EndLevel0611( ) ;
         }
         CloseExtendedTableCursors0611( ) ;
      }

      protected void DeferredUpdate0611( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {A77ProductServicePicture, A40000ProductServicePicture_GXI, A73ProductServiceId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("ProductService");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("productservice_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0611( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0611( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0611( ) ;
            AfterConfirm0611( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0611( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000614 */
                  pr_default.execute(12, new Object[] {A73ProductServiceId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("ProductService");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0611( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0611( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = T000615_A72ProductServiceTypeName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {A73ProductServiceId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product Service"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000617 */
            pr_default.execute(15, new Object[] {A73ProductServiceId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product Service"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000618 */
            pr_default.execute(16, new Object[] {A73ProductServiceId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product Service"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel0611( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0611( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("productservice",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("productservice",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0611( )
      {
         /* Scan By routine */
         /* Using cursor T000619 */
         pr_default.execute(17);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound11 = 1;
            A73ProductServiceId = T000619_A73ProductServiceId[0];
            AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0611( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound11 = 1;
            A73ProductServiceId = T000619_A73ProductServiceId[0];
            AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
         }
      }

      protected void ScanEnd0611( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0611( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0611( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0611( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0611( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0611( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0611( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0611( )
      {
         edtProductServiceName_Enabled = 0;
         AssignProp("", false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         edtProductServiceTypeId_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), true);
         imgProductServicePicture_Enabled = 0;
         AssignProp("", false, imgProductServicePicture_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServicePicture_Enabled), 5, 0), true);
         edtavComboproductservicetypeid_Enabled = 0;
         AssignProp("", false, edtavComboproductservicetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductservicetypeid_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtProductServiceQuantity_Enabled = 0;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0611( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productservice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductServiceId,4,0))}, new string[] {"Gx_mode","ProductServiceId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProductService");
         forbiddenHiddens.Add("ProductServiceId", context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("productservice:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z73ProductServiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z74ProductServiceName", Z74ProductServiceName);
         GxWebStd.gx_hidden_field( context, "Z75ProductServiceDescription", Z75ProductServiceDescription);
         GxWebStd.gx_hidden_field( context, "Z76ProductServiceQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76ProductServiceQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71ProductServiceTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z71ProductServiceTypeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N71ProductServiceTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSERVICETYPEID_DATA", AV15ProductServiceTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSERVICETYPEID_DATA", AV15ProductServiceTypeId_Data);
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
         GxWebStd.gx_hidden_field( context, "vPRODUCTSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductServiceId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductServiceId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTSERVICETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ProductServiceTypeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEPICTURE_GXI", A40000ProductServicePicture_GXI);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICETYPENAME", A72ProductServiceTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEPICTURE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A77ProductServicePicture);
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Objectcall", StringUtil.RTrim( Combo_productservicetypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Cls", StringUtil.RTrim( Combo_productservicetypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_productservicetypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Selectedtext_set", StringUtil.RTrim( Combo_productservicetypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_productservicetypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Enabled", StringUtil.BoolToStr( Combo_productservicetypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Datalistproc", StringUtil.RTrim( Combo_productservicetypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_productservicetypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICETYPEID_Emptyitem", StringUtil.BoolToStr( Combo_productservicetypeid_Emptyitem));
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
         return formatLink("productservice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductServiceId,4,0))}, new string[] {"Gx_mode","ProductServiceId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ProductService" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product/Service" ;
      }

      protected void InitializeNonKey0611( )
      {
         A71ProductServiceTypeId = 0;
         AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrimStr( (decimal)(A71ProductServiceTypeId), 4, 0));
         A74ProductServiceName = "";
         AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
         A75ProductServiceDescription = "";
         AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
         A76ProductServiceQuantity = 0;
         AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrimStr( (decimal)(A76ProductServiceQuantity), 4, 0));
         A77ProductServicePicture = "";
         AssignAttri("", false, "A77ProductServicePicture", A77ProductServicePicture);
         AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
         AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A40000ProductServicePicture_GXI = "";
         AssignProp("", false, imgProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), true);
         AssignProp("", false, imgProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A72ProductServiceTypeName = "";
         AssignAttri("", false, "A72ProductServiceTypeName", A72ProductServiceTypeName);
         Z74ProductServiceName = "";
         Z75ProductServiceDescription = "";
         Z76ProductServiceQuantity = 0;
         Z71ProductServiceTypeId = 0;
      }

      protected void InitAll0611( )
      {
         A73ProductServiceId = 0;
         AssignAttri("", false, "A73ProductServiceId", StringUtil.LTrimStr( (decimal)(A73ProductServiceId), 4, 0));
         InitializeNonKey0611( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249126295976", true, true);
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
         context.AddJavascriptSource("productservice.js", "?20249126295977", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         lblTextblockproductservicetypeid_Internalname = "TEXTBLOCKPRODUCTSERVICETYPEID";
         Combo_productservicetypeid_Internalname = "COMBO_PRODUCTSERVICETYPEID";
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID";
         divTablesplittedproductservicetypeid_Internalname = "TABLESPLITTEDPRODUCTSERVICETYPEID";
         imgProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE";
         divTableform_Internalname = "TABLEFORM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboproductservicetypeid_Internalname = "vCOMBOPRODUCTSERVICETYPEID";
         divSectionattribute_productservicetypeid_Internalname = "SECTIONATTRIBUTE_PRODUCTSERVICETYPEID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY";
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
         Form.Caption = "Product/Service";
         edtProductServiceQuantity_Jsonclick = "";
         edtProductServiceQuantity_Enabled = 1;
         edtProductServiceQuantity_Visible = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 0;
         edtProductServiceId_Visible = 1;
         edtavComboproductservicetypeid_Jsonclick = "";
         edtavComboproductservicetypeid_Enabled = 0;
         edtavComboproductservicetypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgProductServicePicture_Enabled = 1;
         edtProductServiceTypeId_Jsonclick = "";
         edtProductServiceTypeId_Enabled = 1;
         edtProductServiceTypeId_Visible = 1;
         Combo_productservicetypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_productservicetypeid_Datalistprocparametersprefix = " \"ComboName\": \"ProductServiceTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProductServiceId\": 0";
         Combo_productservicetypeid_Datalistproc = "ProductServiceLoadDVCombo";
         Combo_productservicetypeid_Cls = "ExtendedCombo Attribute";
         Combo_productservicetypeid_Caption = "";
         Combo_productservicetypeid_Enabled = Convert.ToBoolean( -1);
         edtProductServiceDescription_Enabled = 1;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Enabled = 1;
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

      public void Valid_Productservicetypeid( )
      {
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Service Type'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTypeId_Internalname;
         }
         A72ProductServiceTypeName = T000615_A72ProductServiceTypeName[0];
         pr_default.close(13);
         if ( (0==A71ProductServiceTypeId) )
         {
            GX_msglist.addItem("Product/Service Type is required", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTypeId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A72ProductServiceTypeName", A72ProductServiceTypeName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ProductServiceId","fld":"vPRODUCTSERVICEID","pic":"ZZZ9","hsh":true},{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12062","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PRODUCTSERVICENAME","""{"handler":"Valid_Productservicename","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEDESCRIPTION","""{"handler":"Valid_Productservicedescription","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICETYPEID","""{"handler":"Valid_Productservicetypeid","iparms":[{"av":"A71ProductServiceTypeId","fld":"PRODUCTSERVICETYPEID","pic":"ZZZ9"},{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"}]""");
         setEventMetadata("VALID_PRODUCTSERVICETYPEID",""","oparms":[{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"}]}""");
         setEventMetadata("VALIDV_COMBOPRODUCTSERVICETYPEID","""{"handler":"Validv_Comboproductservicetypeid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z74ProductServiceName = "";
         Z75ProductServiceDescription = "";
         Combo_productservicetypeid_Selectedvalue_get = "";
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
         A74ProductServiceName = "";
         A75ProductServiceDescription = "";
         lblTextblockproductservicetypeid_Jsonclick = "";
         ucCombo_productservicetypeid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15ProductServiceTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A77ProductServicePicture = "";
         A40000ProductServicePicture_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A72ProductServiceTypeName = "";
         AV23Pgmname = "";
         Combo_productservicetypeid_Objectcall = "";
         Combo_productservicetypeid_Class = "";
         Combo_productservicetypeid_Icontype = "";
         Combo_productservicetypeid_Icon = "";
         Combo_productservicetypeid_Tooltip = "";
         Combo_productservicetypeid_Selectedvalue_set = "";
         Combo_productservicetypeid_Selectedtext_set = "";
         Combo_productservicetypeid_Selectedtext_get = "";
         Combo_productservicetypeid_Gamoauthtoken = "";
         Combo_productservicetypeid_Ddointernalname = "";
         Combo_productservicetypeid_Titlecontrolalign = "";
         Combo_productservicetypeid_Dropdownoptionstype = "";
         Combo_productservicetypeid_Titlecontrolidtoreplace = "";
         Combo_productservicetypeid_Datalisttype = "";
         Combo_productservicetypeid_Datalistfixedvalues = "";
         Combo_productservicetypeid_Remoteservicesparameters = "";
         Combo_productservicetypeid_Htmltemplate = "";
         Combo_productservicetypeid_Multiplevaluestype = "";
         Combo_productservicetypeid_Loadingdata = "";
         Combo_productservicetypeid_Noresultsfound = "";
         Combo_productservicetypeid_Emptyitemtext = "";
         Combo_productservicetypeid_Onlyselectedvalues = "";
         Combo_productservicetypeid_Selectalltext = "";
         Combo_productservicetypeid_Multiplevaluesseparator = "";
         Combo_productservicetypeid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode11 = "";
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
         Z77ProductServicePicture = "";
         Z40000ProductServicePicture_GXI = "";
         Z72ProductServiceTypeName = "";
         T00064_A72ProductServiceTypeName = new string[] {""} ;
         T00065_A73ProductServiceId = new short[1] ;
         T00065_A74ProductServiceName = new string[] {""} ;
         T00065_A75ProductServiceDescription = new string[] {""} ;
         T00065_A76ProductServiceQuantity = new short[1] ;
         T00065_A40000ProductServicePicture_GXI = new string[] {""} ;
         T00065_A72ProductServiceTypeName = new string[] {""} ;
         T00065_A71ProductServiceTypeId = new short[1] ;
         T00065_A77ProductServicePicture = new string[] {""} ;
         T00066_A72ProductServiceTypeName = new string[] {""} ;
         T00067_A73ProductServiceId = new short[1] ;
         T00063_A73ProductServiceId = new short[1] ;
         T00063_A74ProductServiceName = new string[] {""} ;
         T00063_A75ProductServiceDescription = new string[] {""} ;
         T00063_A76ProductServiceQuantity = new short[1] ;
         T00063_A40000ProductServicePicture_GXI = new string[] {""} ;
         T00063_A71ProductServiceTypeId = new short[1] ;
         T00063_A77ProductServicePicture = new string[] {""} ;
         T00068_A73ProductServiceId = new short[1] ;
         T00069_A73ProductServiceId = new short[1] ;
         T00062_A73ProductServiceId = new short[1] ;
         T00062_A74ProductServiceName = new string[] {""} ;
         T00062_A75ProductServiceDescription = new string[] {""} ;
         T00062_A76ProductServiceQuantity = new short[1] ;
         T00062_A40000ProductServicePicture_GXI = new string[] {""} ;
         T00062_A71ProductServiceTypeId = new short[1] ;
         T00062_A77ProductServicePicture = new string[] {""} ;
         T000611_A73ProductServiceId = new short[1] ;
         T000615_A72ProductServiceTypeName = new string[] {""} ;
         T000616_A31ResidentId = new short[1] ;
         T000616_A73ProductServiceId = new short[1] ;
         T000617_A55Supplier_AgbId = new short[1] ;
         T000617_A73ProductServiceId = new short[1] ;
         T000618_A64Supplier_GenId = new short[1] ;
         T000618_A73ProductServiceId = new short[1] ;
         T000619_A73ProductServiceId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.productservice__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productservice__default(),
            new Object[][] {
                new Object[] {
               T00062_A73ProductServiceId, T00062_A74ProductServiceName, T00062_A75ProductServiceDescription, T00062_A76ProductServiceQuantity, T00062_A40000ProductServicePicture_GXI, T00062_A71ProductServiceTypeId, T00062_A77ProductServicePicture
               }
               , new Object[] {
               T00063_A73ProductServiceId, T00063_A74ProductServiceName, T00063_A75ProductServiceDescription, T00063_A76ProductServiceQuantity, T00063_A40000ProductServicePicture_GXI, T00063_A71ProductServiceTypeId, T00063_A77ProductServicePicture
               }
               , new Object[] {
               T00064_A72ProductServiceTypeName
               }
               , new Object[] {
               T00065_A73ProductServiceId, T00065_A74ProductServiceName, T00065_A75ProductServiceDescription, T00065_A76ProductServiceQuantity, T00065_A40000ProductServicePicture_GXI, T00065_A72ProductServiceTypeName, T00065_A71ProductServiceTypeId, T00065_A77ProductServicePicture
               }
               , new Object[] {
               T00066_A72ProductServiceTypeName
               }
               , new Object[] {
               T00067_A73ProductServiceId
               }
               , new Object[] {
               T00068_A73ProductServiceId
               }
               , new Object[] {
               T00069_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               T000611_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000615_A72ProductServiceTypeName
               }
               , new Object[] {
               T000616_A31ResidentId, T000616_A73ProductServiceId
               }
               , new Object[] {
               T000617_A55Supplier_AgbId, T000617_A73ProductServiceId
               }
               , new Object[] {
               T000618_A64Supplier_GenId, T000618_A73ProductServiceId
               }
               , new Object[] {
               T000619_A73ProductServiceId
               }
            }
         );
         AV23Pgmname = "ProductService";
      }

      private short wcpOAV7ProductServiceId ;
      private short Z73ProductServiceId ;
      private short Z76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short N71ProductServiceTypeId ;
      private short GxWebError ;
      private short A71ProductServiceTypeId ;
      private short AV7ProductServiceId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV20ComboProductServiceTypeId ;
      private short A73ProductServiceId ;
      private short A76ProductServiceQuantity ;
      private short AV13Insert_ProductServiceTypeId ;
      private short RcdFound11 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int divTablecontent_Width ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int edtProductServiceTypeId_Visible ;
      private int edtProductServiceTypeId_Enabled ;
      private int imgProductServicePicture_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboproductservicetypeid_Enabled ;
      private int edtavComboproductservicetypeid_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceId_Visible ;
      private int edtProductServiceQuantity_Enabled ;
      private int edtProductServiceQuantity_Visible ;
      private int Combo_productservicetypeid_Datalistupdateminimumcharacters ;
      private int Combo_productservicetypeid_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_productservicetypeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductServiceName_Internalname ;
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
      private string edtProductServiceName_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string divTablesplittedproductservicetypeid_Internalname ;
      private string lblTextblockproductservicetypeid_Internalname ;
      private string lblTextblockproductservicetypeid_Jsonclick ;
      private string Combo_productservicetypeid_Caption ;
      private string Combo_productservicetypeid_Cls ;
      private string Combo_productservicetypeid_Datalistproc ;
      private string Combo_productservicetypeid_Datalistprocparametersprefix ;
      private string Combo_productservicetypeid_Internalname ;
      private string edtProductServiceTypeId_Internalname ;
      private string edtProductServiceTypeId_Jsonclick ;
      private string imgProductServicePicture_Internalname ;
      private string sImgUrl ;
      private string divActionstable_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_productservicetypeid_Internalname ;
      private string edtavComboproductservicetypeid_Internalname ;
      private string edtavComboproductservicetypeid_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceQuantity_Internalname ;
      private string edtProductServiceQuantity_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_productservicetypeid_Objectcall ;
      private string Combo_productservicetypeid_Class ;
      private string Combo_productservicetypeid_Icontype ;
      private string Combo_productservicetypeid_Icon ;
      private string Combo_productservicetypeid_Tooltip ;
      private string Combo_productservicetypeid_Selectedvalue_set ;
      private string Combo_productservicetypeid_Selectedtext_set ;
      private string Combo_productservicetypeid_Selectedtext_get ;
      private string Combo_productservicetypeid_Gamoauthtoken ;
      private string Combo_productservicetypeid_Ddointernalname ;
      private string Combo_productservicetypeid_Titlecontrolalign ;
      private string Combo_productservicetypeid_Dropdownoptionstype ;
      private string Combo_productservicetypeid_Titlecontrolidtoreplace ;
      private string Combo_productservicetypeid_Datalisttype ;
      private string Combo_productservicetypeid_Datalistfixedvalues ;
      private string Combo_productservicetypeid_Remoteservicesparameters ;
      private string Combo_productservicetypeid_Htmltemplate ;
      private string Combo_productservicetypeid_Multiplevaluestype ;
      private string Combo_productservicetypeid_Loadingdata ;
      private string Combo_productservicetypeid_Noresultsfound ;
      private string Combo_productservicetypeid_Emptyitemtext ;
      private string Combo_productservicetypeid_Onlyselectedvalues ;
      private string Combo_productservicetypeid_Selectalltext ;
      private string Combo_productservicetypeid_Multiplevaluesseparator ;
      private string Combo_productservicetypeid_Addnewoptiontext ;
      private string hsh ;
      private string sMode11 ;
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
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_productservicetypeid_Emptyitem ;
      private bool A77ProductServicePicture_IsBlob ;
      private bool Combo_productservicetypeid_Enabled ;
      private bool Combo_productservicetypeid_Visible ;
      private bool Combo_productservicetypeid_Allowmultipleselection ;
      private bool Combo_productservicetypeid_Isgriditem ;
      private bool Combo_productservicetypeid_Hasdescription ;
      private bool Combo_productservicetypeid_Includeonlyselectedoption ;
      private bool Combo_productservicetypeid_Includeselectalloption ;
      private bool Combo_productservicetypeid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z74ProductServiceName ;
      private string Z75ProductServiceDescription ;
      private string A74ProductServiceName ;
      private string A75ProductServiceDescription ;
      private string A40000ProductServicePicture_GXI ;
      private string A72ProductServiceTypeName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z40000ProductServicePicture_GXI ;
      private string Z72ProductServiceTypeName ;
      private string A77ProductServicePicture ;
      private string Z77ProductServicePicture ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_productservicetypeid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15ProductServiceTypeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00064_A72ProductServiceTypeName ;
      private short[] T00065_A73ProductServiceId ;
      private string[] T00065_A74ProductServiceName ;
      private string[] T00065_A75ProductServiceDescription ;
      private short[] T00065_A76ProductServiceQuantity ;
      private string[] T00065_A40000ProductServicePicture_GXI ;
      private string[] T00065_A72ProductServiceTypeName ;
      private short[] T00065_A71ProductServiceTypeId ;
      private string[] T00065_A77ProductServicePicture ;
      private string[] T00066_A72ProductServiceTypeName ;
      private short[] T00067_A73ProductServiceId ;
      private short[] T00063_A73ProductServiceId ;
      private string[] T00063_A74ProductServiceName ;
      private string[] T00063_A75ProductServiceDescription ;
      private short[] T00063_A76ProductServiceQuantity ;
      private string[] T00063_A40000ProductServicePicture_GXI ;
      private short[] T00063_A71ProductServiceTypeId ;
      private string[] T00063_A77ProductServicePicture ;
      private short[] T00068_A73ProductServiceId ;
      private short[] T00069_A73ProductServiceId ;
      private short[] T00062_A73ProductServiceId ;
      private string[] T00062_A74ProductServiceName ;
      private string[] T00062_A75ProductServiceDescription ;
      private short[] T00062_A76ProductServiceQuantity ;
      private string[] T00062_A40000ProductServicePicture_GXI ;
      private short[] T00062_A71ProductServiceTypeId ;
      private string[] T00062_A77ProductServicePicture ;
      private short[] T000611_A73ProductServiceId ;
      private string[] T000615_A72ProductServiceTypeName ;
      private short[] T000616_A31ResidentId ;
      private short[] T000616_A73ProductServiceId ;
      private short[] T000617_A55Supplier_AgbId ;
      private short[] T000617_A73ProductServiceId ;
      private short[] T000618_A64Supplier_GenId ;
      private short[] T000618_A73ProductServiceId ;
      private short[] T000619_A73ProductServiceId ;
      private IDataStoreProvider pr_gam ;
   }

   public class productservice__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class productservice__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new ParDef("ProductServiceName",GXType.VarChar,40,0) ,
        new ParDef("ProductServiceDescription",GXType.VarChar,200,0) ,
        new ParDef("ProductServiceQuantity",GXType.Int16,4,0) ,
        new ParDef("ProductServicePicture",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServicePicture_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="ProductService", Fld="ProductServicePicture"} ,
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new ParDef("ProductServiceName",GXType.VarChar,40,0) ,
        new ParDef("ProductServiceDescription",GXType.VarChar,200,0) ,
        new ParDef("ProductServiceQuantity",GXType.Int16,4,0) ,
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        new ParDef("ProductServicePicture",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServicePicture_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="ProductService", Fld="ProductServicePicture"} ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000615;
        prmT000615 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000616;
        prmT000616 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000617;
        prmT000617 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000618;
        prmT000618 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000619;
        prmT000619 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT ProductServiceId, ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId  FOR UPDATE OF ProductService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT ProductServiceId, ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT TM1.ProductServiceId, TM1.ProductServiceName, TM1.ProductServiceDescription, TM1.ProductServiceQuantity, TM1.ProductServicePicture_GXI, T2.ProductServiceTypeName, TM1.ProductServiceTypeId, TM1.ProductServicePicture FROM (ProductService TM1 INNER JOIN ProductServiceType T2 ON T2.ProductServiceTypeId = TM1.ProductServiceTypeId) WHERE TM1.ProductServiceId = :ProductServiceId ORDER BY TM1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00067", "SELECT ProductServiceId FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00068", "SELECT ProductServiceId FROM ProductService WHERE ( ProductServiceId > :ProductServiceId) ORDER BY ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00069", "SELECT ProductServiceId FROM ProductService WHERE ( ProductServiceId < :ProductServiceId) ORDER BY ProductServiceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000610", "SAVEPOINT gxupdate;INSERT INTO ProductService(ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture, ProductServicePicture_GXI, ProductServiceTypeId) VALUES(:ProductServiceName, :ProductServiceDescription, :ProductServiceQuantity, :ProductServicePicture, :ProductServicePicture_GXI, :ProductServiceTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000610)
           ,new CursorDef("T000611", "SELECT currval('ProductServiceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000612", "SAVEPOINT gxupdate;UPDATE ProductService SET ProductServiceName=:ProductServiceName, ProductServiceDescription=:ProductServiceDescription, ProductServiceQuantity=:ProductServiceQuantity, ProductServiceTypeId=:ProductServiceTypeId  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000612)
           ,new CursorDef("T000613", "SAVEPOINT gxupdate;UPDATE ProductService SET ProductServicePicture=:ProductServicePicture, ProductServicePicture_GXI=:ProductServicePicture_GXI  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000613)
           ,new CursorDef("T000614", "SAVEPOINT gxupdate;DELETE FROM ProductService  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000614)
           ,new CursorDef("T000615", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000616", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000617", "SELECT Supplier_AgbId, ProductServiceId FROM Supplier_AgbProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000618", "SELECT Supplier_GenId, ProductServiceId FROM Supplier_GenProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000619", "SELECT ProductServiceId FROM ProductService ORDER BY ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
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
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
