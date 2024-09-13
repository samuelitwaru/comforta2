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
   public class amenities : GXDataArea
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
            A99AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesTypeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A99AmenitiesTypeId) ;
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
               AV7AmenitiesId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7AmenitiesId", StringUtil.LTrimStr( (decimal)(AV7AmenitiesId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AmenitiesId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Amenities", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAmenitiesName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public amenities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amenities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_AmenitiesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AmenitiesId = aP1_AmenitiesId;
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
            return "amenities_Execute" ;
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "", 1, 0, "px", 0, "px", "Group", "", "HLP_Amenities.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAmenitiesName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmenitiesName_Internalname, context.GetMessage( "Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmenitiesName_Internalname, A101AmenitiesName, StringUtil.RTrim( context.localUtil.Format( A101AmenitiesName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmenitiesName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmenitiesName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Amenities.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedamenitiestypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockamenitiestypeid_Internalname, context.GetMessage( "Amenity Type", ""), "", "", lblTextblockamenitiestypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Amenities.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_amenitiestypeid.SetProperty("Caption", Combo_amenitiestypeid_Caption);
         ucCombo_amenitiestypeid.SetProperty("Cls", Combo_amenitiestypeid_Cls);
         ucCombo_amenitiestypeid.SetProperty("DataListProc", Combo_amenitiestypeid_Datalistproc);
         ucCombo_amenitiestypeid.SetProperty("DataListProcParametersPrefix", Combo_amenitiestypeid_Datalistprocparametersprefix);
         ucCombo_amenitiestypeid.SetProperty("EmptyItem", Combo_amenitiestypeid_Emptyitem);
         ucCombo_amenitiestypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_amenitiestypeid.SetProperty("DropDownOptionsData", AV15AmenitiesTypeId_Data);
         ucCombo_amenitiestypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_amenitiestypeid_Internalname, "COMBO_AMENITIESTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmenitiesTypeId_Internalname, context.GetMessage( "Amenities Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmenitiesTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A99AmenitiesTypeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmenitiesTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtAmenitiesTypeId_Visible, edtAmenitiesTypeId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Amenities.htm");
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
         GxWebStd.gx_div_start( context, divActionstable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Amenities.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Amenities.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Amenities.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_amenitiestypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboamenitiestypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboAmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavComboamenitiestypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboAmenitiesTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(AV20ComboAmenitiesTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboamenitiestypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboamenitiestypeid_Visible, edtavComboamenitiestypeid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Amenities.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmenitiesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAmenitiesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9") : context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmenitiesId_Jsonclick, 0, "Attribute", "", "", "", "", edtAmenitiesId_Visible, edtAmenitiesId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Amenities.htm");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vAMENITIESTYPEID_DATA"), AV15AmenitiesTypeId_Data);
               /* Read saved values. */
               Z98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z98AmenitiesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z101AmenitiesName = cgiGet( "Z101AmenitiesName");
               Z99AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z99AmenitiesTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N99AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N99AmenitiesTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vAMENITIESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_AMENITIESTYPEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A100AmenitiesTypeName = cgiGet( "AMENITIESTYPENAME");
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_amenitiestypeid_Objectcall = cgiGet( "COMBO_AMENITIESTYPEID_Objectcall");
               Combo_amenitiestypeid_Class = cgiGet( "COMBO_AMENITIESTYPEID_Class");
               Combo_amenitiestypeid_Icontype = cgiGet( "COMBO_AMENITIESTYPEID_Icontype");
               Combo_amenitiestypeid_Icon = cgiGet( "COMBO_AMENITIESTYPEID_Icon");
               Combo_amenitiestypeid_Caption = cgiGet( "COMBO_AMENITIESTYPEID_Caption");
               Combo_amenitiestypeid_Tooltip = cgiGet( "COMBO_AMENITIESTYPEID_Tooltip");
               Combo_amenitiestypeid_Cls = cgiGet( "COMBO_AMENITIESTYPEID_Cls");
               Combo_amenitiestypeid_Selectedvalue_set = cgiGet( "COMBO_AMENITIESTYPEID_Selectedvalue_set");
               Combo_amenitiestypeid_Selectedvalue_get = cgiGet( "COMBO_AMENITIESTYPEID_Selectedvalue_get");
               Combo_amenitiestypeid_Selectedtext_set = cgiGet( "COMBO_AMENITIESTYPEID_Selectedtext_set");
               Combo_amenitiestypeid_Selectedtext_get = cgiGet( "COMBO_AMENITIESTYPEID_Selectedtext_get");
               Combo_amenitiestypeid_Gamoauthtoken = cgiGet( "COMBO_AMENITIESTYPEID_Gamoauthtoken");
               Combo_amenitiestypeid_Ddointernalname = cgiGet( "COMBO_AMENITIESTYPEID_Ddointernalname");
               Combo_amenitiestypeid_Titlecontrolalign = cgiGet( "COMBO_AMENITIESTYPEID_Titlecontrolalign");
               Combo_amenitiestypeid_Dropdownoptionstype = cgiGet( "COMBO_AMENITIESTYPEID_Dropdownoptionstype");
               Combo_amenitiestypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Enabled"));
               Combo_amenitiestypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Visible"));
               Combo_amenitiestypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_AMENITIESTYPEID_Titlecontrolidtoreplace");
               Combo_amenitiestypeid_Datalisttype = cgiGet( "COMBO_AMENITIESTYPEID_Datalisttype");
               Combo_amenitiestypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Allowmultipleselection"));
               Combo_amenitiestypeid_Datalistfixedvalues = cgiGet( "COMBO_AMENITIESTYPEID_Datalistfixedvalues");
               Combo_amenitiestypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Isgriditem"));
               Combo_amenitiestypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Hasdescription"));
               Combo_amenitiestypeid_Datalistproc = cgiGet( "COMBO_AMENITIESTYPEID_Datalistproc");
               Combo_amenitiestypeid_Datalistprocparametersprefix = cgiGet( "COMBO_AMENITIESTYPEID_Datalistprocparametersprefix");
               Combo_amenitiestypeid_Remoteservicesparameters = cgiGet( "COMBO_AMENITIESTYPEID_Remoteservicesparameters");
               Combo_amenitiestypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_AMENITIESTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_amenitiestypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Includeonlyselectedoption"));
               Combo_amenitiestypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Includeselectalloption"));
               Combo_amenitiestypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Emptyitem"));
               Combo_amenitiestypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_AMENITIESTYPEID_Includeaddnewoption"));
               Combo_amenitiestypeid_Htmltemplate = cgiGet( "COMBO_AMENITIESTYPEID_Htmltemplate");
               Combo_amenitiestypeid_Multiplevaluestype = cgiGet( "COMBO_AMENITIESTYPEID_Multiplevaluestype");
               Combo_amenitiestypeid_Loadingdata = cgiGet( "COMBO_AMENITIESTYPEID_Loadingdata");
               Combo_amenitiestypeid_Noresultsfound = cgiGet( "COMBO_AMENITIESTYPEID_Noresultsfound");
               Combo_amenitiestypeid_Emptyitemtext = cgiGet( "COMBO_AMENITIESTYPEID_Emptyitemtext");
               Combo_amenitiestypeid_Onlyselectedvalues = cgiGet( "COMBO_AMENITIESTYPEID_Onlyselectedvalues");
               Combo_amenitiestypeid_Selectalltext = cgiGet( "COMBO_AMENITIESTYPEID_Selectalltext");
               Combo_amenitiestypeid_Multiplevaluesseparator = cgiGet( "COMBO_AMENITIESTYPEID_Multiplevaluesseparator");
               Combo_amenitiestypeid_Addnewoptiontext = cgiGet( "COMBO_AMENITIESTYPEID_Addnewoptiontext");
               Combo_amenitiestypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_AMENITIESTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A101AmenitiesName = cgiGet( edtAmenitiesName_Internalname);
               AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAmenitiesTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAmenitiesTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMENITIESTYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtAmenitiesTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A99AmenitiesTypeId = 0;
                  AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
               }
               else
               {
                  A99AmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
               }
               AV20ComboAmenitiesTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboamenitiestypeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboAmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboAmenitiesTypeId), 4, 0));
               A98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Amenities");
               A98AmenitiesId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAmenitiesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
               forbiddenHiddens.Add("AmenitiesId", context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A98AmenitiesId != Z98AmenitiesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("amenities:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A98AmenitiesId = (short)(Math.Round(NumberUtil.Val( GetPar( "AmenitiesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AMENITIESID");
                        AnyError = 1;
                        GX_FocusControl = edtAmenitiesId_Internalname;
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
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C22( ) ;
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
            DisableAttributes0C22( ) ;
         }
         AssignProp("", false, edtavComboamenitiestypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboamenitiestypeid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C22( ) ;
            }
            else
            {
               CheckExtendedTable0C22( ) ;
               CloseExtendedTableCursors0C22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
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
         Combo_amenitiestypeid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "GAMOAuthToken", Combo_amenitiestypeid_Gamoauthtoken);
         edtAmenitiesTypeId_Visible = 0;
         AssignProp("", false, edtAmenitiesTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Visible), 5, 0), true);
         AV20ComboAmenitiesTypeId = 0;
         AssignAttri("", false, "AV20ComboAmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboAmenitiesTypeId), 4, 0));
         edtavComboamenitiestypeid_Visible = 0;
         AssignProp("", false, edtavComboamenitiestypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboamenitiestypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOAMENITIESTYPEID' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "AmenitiesTypeId") == 0 )
               {
                  AV13Insert_AmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV13Insert_AmenitiesTypeId), 4, 0));
                  if ( ! (0==AV13Insert_AmenitiesTypeId) )
                  {
                     AV20ComboAmenitiesTypeId = AV13Insert_AmenitiesTypeId;
                     AssignAttri("", false, "AV20ComboAmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboAmenitiesTypeId), 4, 0));
                     Combo_amenitiestypeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboAmenitiesTypeId), 4, 0));
                     ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "SelectedValue_set", Combo_amenitiestypeid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new amenitiesloaddvcombo(context ).execute(  "AmenitiesTypeId",  "GET",  false,  AV7AmenitiesId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_amenitiestypeid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "SelectedText_set", Combo_amenitiestypeid_Selectedtext_set);
                     Combo_amenitiestypeid_Enabled = false;
                     ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_amenitiestypeid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtAmenitiesId_Visible = 0;
         AssignProp("", false, edtAmenitiesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Visible), 5, 0), true);
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("amenitiesww.aspx") );
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
         /* 'LOADCOMBOAMENITIESTYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new amenitiesloaddvcombo(context ).execute(  "AmenitiesTypeId",  Gx_mode,  false,  AV7AmenitiesId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_amenitiestypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "SelectedValue_set", Combo_amenitiestypeid_Selectedvalue_set);
         Combo_amenitiestypeid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "SelectedText_set", Combo_amenitiestypeid_Selectedtext_set);
         AV20ComboAmenitiesTypeId = (short)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboAmenitiesTypeId", StringUtil.LTrimStr( (decimal)(AV20ComboAmenitiesTypeId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_amenitiestypeid_Enabled = false;
            ucCombo_amenitiestypeid.SendProperty(context, "", false, Combo_amenitiestypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_amenitiestypeid_Enabled));
         }
      }

      protected void ZM0C22( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z101AmenitiesName = T000C3_A101AmenitiesName[0];
               Z99AmenitiesTypeId = T000C3_A99AmenitiesTypeId[0];
            }
            else
            {
               Z101AmenitiesName = A101AmenitiesName;
               Z99AmenitiesTypeId = A99AmenitiesTypeId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z98AmenitiesId = A98AmenitiesId;
            Z101AmenitiesName = A101AmenitiesName;
            Z99AmenitiesTypeId = A99AmenitiesTypeId;
            Z100AmenitiesTypeName = A100AmenitiesTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAmenitiesId_Enabled = 0;
         AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), true);
         AV23Pgmname = "Amenities";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtAmenitiesId_Enabled = 0;
         AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AmenitiesId) )
         {
            A98AmenitiesId = AV7AmenitiesId;
            AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_AmenitiesTypeId) )
         {
            edtAmenitiesTypeId_Enabled = 0;
            AssignProp("", false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtAmenitiesTypeId_Enabled = 1;
            AssignProp("", false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_AmenitiesTypeId) )
         {
            A99AmenitiesTypeId = AV13Insert_AmenitiesTypeId;
            AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
         }
         else
         {
            A99AmenitiesTypeId = AV20ComboAmenitiesTypeId;
            AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
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
            /* Using cursor T000C4 */
            pr_default.execute(2, new Object[] {A99AmenitiesTypeId});
            A100AmenitiesTypeName = T000C4_A100AmenitiesTypeName[0];
            pr_default.close(2);
         }
      }

      protected void Load0C22( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
            A101AmenitiesName = T000C5_A101AmenitiesName[0];
            AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
            A100AmenitiesTypeName = T000C5_A100AmenitiesTypeName[0];
            A99AmenitiesTypeId = T000C5_A99AmenitiesTypeId[0];
            AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
            ZM0C22( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0C22( ) ;
      }

      protected void OnLoadActions0C22( )
      {
      }

      protected void CheckExtendedTable0C22( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AMENITIESTYPEID");
            AnyError = 1;
            GX_FocusControl = edtAmenitiesTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A100AmenitiesTypeName = T000C4_A100AmenitiesTypeName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C22( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( short A99AmenitiesTypeId )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AMENITIESTYPEID");
            AnyError = 1;
            GX_FocusControl = edtAmenitiesTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A100AmenitiesTypeName = T000C6_A100AmenitiesTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A100AmenitiesTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0C22( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C22( 8) ;
            RcdFound22 = 1;
            A98AmenitiesId = T000C3_A98AmenitiesId[0];
            AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
            A101AmenitiesName = T000C3_A101AmenitiesName[0];
            AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
            A99AmenitiesTypeId = T000C3_A99AmenitiesTypeId[0];
            AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
            Z98AmenitiesId = A98AmenitiesId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0C22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0C22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000C8_A98AmenitiesId[0] < A98AmenitiesId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000C8_A98AmenitiesId[0] > A98AmenitiesId ) ) )
            {
               A98AmenitiesId = T000C8_A98AmenitiesId[0];
               AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A98AmenitiesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A98AmenitiesId[0] > A98AmenitiesId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A98AmenitiesId[0] < A98AmenitiesId ) ) )
            {
               A98AmenitiesId = T000C9_A98AmenitiesId[0];
               AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAmenitiesName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A98AmenitiesId != Z98AmenitiesId )
               {
                  A98AmenitiesId = Z98AmenitiesId;
                  AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AMENITIESID");
                  AnyError = 1;
                  GX_FocusControl = edtAmenitiesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAmenitiesName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C22( ) ;
                  GX_FocusControl = edtAmenitiesName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A98AmenitiesId != Z98AmenitiesId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAmenitiesName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AMENITIESID");
                     AnyError = 1;
                     GX_FocusControl = edtAmenitiesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAmenitiesName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C22( ) ;
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
         if ( A98AmenitiesId != Z98AmenitiesId )
         {
            A98AmenitiesId = Z98AmenitiesId;
            AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AMENITIESID");
            AnyError = 1;
            GX_FocusControl = edtAmenitiesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAmenitiesName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A98AmenitiesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Amenities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z101AmenitiesName, T000C2_A101AmenitiesName[0]) != 0 ) || ( Z99AmenitiesTypeId != T000C2_A99AmenitiesTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z101AmenitiesName, T000C2_A101AmenitiesName[0]) != 0 )
               {
                  GXUtil.WriteLog("amenities:[seudo value changed for attri]"+"AmenitiesName");
                  GXUtil.WriteLogRaw("Old: ",Z101AmenitiesName);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A101AmenitiesName[0]);
               }
               if ( Z99AmenitiesTypeId != T000C2_A99AmenitiesTypeId[0] )
               {
                  GXUtil.WriteLog("amenities:[seudo value changed for attri]"+"AmenitiesTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z99AmenitiesTypeId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A99AmenitiesTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Amenities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C22( )
      {
         if ( ! IsAuthorized("amenities_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C22( 0) ;
            CheckOptimisticConcurrency0C22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {A101AmenitiesName, A99AmenitiesTypeId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000C11 */
                     pr_default.execute(9);
                     A98AmenitiesId = T000C11_A98AmenitiesId[0];
                     AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Amenities");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
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
               Load0C22( ) ;
            }
            EndLevel0C22( ) ;
         }
         CloseExtendedTableCursors0C22( ) ;
      }

      protected void Update0C22( )
      {
         if ( ! IsAuthorized("amenities_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C12 */
                     pr_default.execute(10, new Object[] {A101AmenitiesName, A99AmenitiesTypeId, A98AmenitiesId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Amenities");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Amenities"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C22( ) ;
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
            EndLevel0C22( ) ;
         }
         CloseExtendedTableCursors0C22( ) ;
      }

      protected void DeferredUpdate0C22( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("amenities_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C22( ) ;
            AfterConfirm0C22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C13 */
                  pr_default.execute(11, new Object[] {A98AmenitiesId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Amenities");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {A99AmenitiesTypeId});
            A100AmenitiesTypeName = T000C14_A100AmenitiesTypeName[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C15 */
            pr_default.execute(13, new Object[] {A98AmenitiesId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "CustomerLocationsAmenities", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0C22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C22( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("amenities",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("amenities",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C22( )
      {
         /* Scan By routine */
         /* Using cursor T000C16 */
         pr_default.execute(14);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound22 = 1;
            A98AmenitiesId = T000C16_A98AmenitiesId[0];
            AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C22( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound22 = 1;
            A98AmenitiesId = T000C16_A98AmenitiesId[0];
            AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
         }
      }

      protected void ScanEnd0C22( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0C22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C22( )
      {
         edtAmenitiesName_Enabled = 0;
         AssignProp("", false, edtAmenitiesName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesName_Enabled), 5, 0), true);
         edtAmenitiesTypeId_Enabled = 0;
         AssignProp("", false, edtAmenitiesTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesTypeId_Enabled), 5, 0), true);
         edtavComboamenitiestypeid_Enabled = 0;
         AssignProp("", false, edtavComboamenitiestypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboamenitiestypeid_Enabled), 5, 0), true);
         edtAmenitiesId_Enabled = 0;
         AssignProp("", false, edtAmenitiesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmenitiesId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("amenities.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AmenitiesId,4,0))}, new string[] {"Gx_mode","AmenitiesId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Amenities");
         forbiddenHiddens.Add("AmenitiesId", context.localUtil.Format( (decimal)(A98AmenitiesId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("amenities:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z98AmenitiesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z101AmenitiesName", Z101AmenitiesName);
         GxWebStd.gx_hidden_field( context, "Z99AmenitiesTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N99AmenitiesTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAMENITIESTYPEID_DATA", AV15AmenitiesTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAMENITIESTYPEID_DATA", AV15AmenitiesTypeId_Data);
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
         GxWebStd.gx_hidden_field( context, "vAMENITIESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AmenitiesId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMENITIESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AmenitiesId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_AMENITIESTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_AmenitiesTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "AMENITIESTYPENAME", A100AmenitiesTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Objectcall", StringUtil.RTrim( Combo_amenitiestypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Cls", StringUtil.RTrim( Combo_amenitiestypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_amenitiestypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_amenitiestypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_amenitiestypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Enabled", StringUtil.BoolToStr( Combo_amenitiestypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Datalistproc", StringUtil.RTrim( Combo_amenitiestypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_amenitiestypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_AMENITIESTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_amenitiestypeid_Emptyitem));
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
         return formatLink("amenities.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AmenitiesId,4,0))}, new string[] {"Gx_mode","AmenitiesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Amenities" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Amenities", "") ;
      }

      protected void InitializeNonKey0C22( )
      {
         A99AmenitiesTypeId = 0;
         AssignAttri("", false, "A99AmenitiesTypeId", StringUtil.LTrimStr( (decimal)(A99AmenitiesTypeId), 4, 0));
         A101AmenitiesName = "";
         AssignAttri("", false, "A101AmenitiesName", A101AmenitiesName);
         A100AmenitiesTypeName = "";
         AssignAttri("", false, "A100AmenitiesTypeName", A100AmenitiesTypeName);
         Z101AmenitiesName = "";
         Z99AmenitiesTypeId = 0;
      }

      protected void InitAll0C22( )
      {
         A98AmenitiesId = 0;
         AssignAttri("", false, "A98AmenitiesId", StringUtil.LTrimStr( (decimal)(A98AmenitiesId), 4, 0));
         InitializeNonKey0C22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315535338", true, true);
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
         context.AddJavascriptSource("amenities.js", "?202491315535340", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAmenitiesName_Internalname = "AMENITIESNAME";
         lblTextblockamenitiestypeid_Internalname = "TEXTBLOCKAMENITIESTYPEID";
         Combo_amenitiestypeid_Internalname = "COMBO_AMENITIESTYPEID";
         edtAmenitiesTypeId_Internalname = "AMENITIESTYPEID";
         divTablesplittedamenitiestypeid_Internalname = "TABLESPLITTEDAMENITIESTYPEID";
         divTableform_Internalname = "TABLEFORM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divActionstable_Internalname = "ACTIONSTABLE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboamenitiestypeid_Internalname = "vCOMBOAMENITIESTYPEID";
         divSectionattribute_amenitiestypeid_Internalname = "SECTIONATTRIBUTE_AMENITIESTYPEID";
         edtAmenitiesId_Internalname = "AMENITIESID";
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
         Form.Caption = context.GetMessage( "Amenities", "");
         edtAmenitiesId_Jsonclick = "";
         edtAmenitiesId_Enabled = 0;
         edtAmenitiesId_Visible = 1;
         edtavComboamenitiestypeid_Jsonclick = "";
         edtavComboamenitiestypeid_Enabled = 0;
         edtavComboamenitiestypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtAmenitiesTypeId_Jsonclick = "";
         edtAmenitiesTypeId_Enabled = 1;
         edtAmenitiesTypeId_Visible = 1;
         Combo_amenitiestypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_amenitiestypeid_Datalistprocparametersprefix = " \"ComboName\": \"AmenitiesTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AmenitiesId\": 0";
         Combo_amenitiestypeid_Datalistproc = "AmenitiesLoadDVCombo";
         Combo_amenitiestypeid_Cls = "ExtendedCombo Attribute";
         Combo_amenitiestypeid_Caption = "";
         Combo_amenitiestypeid_Enabled = Convert.ToBoolean( -1);
         edtAmenitiesName_Jsonclick = "";
         edtAmenitiesName_Enabled = 1;
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

      public void Valid_Amenitiestypeid( )
      {
         /* Using cursor T000C14 */
         pr_default.execute(12, new Object[] {A99AmenitiesTypeId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AmenitiesType", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AMENITIESTYPEID");
            AnyError = 1;
            GX_FocusControl = edtAmenitiesTypeId_Internalname;
         }
         A100AmenitiesTypeName = T000C14_A100AmenitiesTypeName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A100AmenitiesTypeName", A100AmenitiesTypeName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7AmenitiesId","fld":"vAMENITIESID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7AmenitiesId","fld":"vAMENITIESID","pic":"ZZZ9","hsh":true},{"av":"A98AmenitiesId","fld":"AMENITIESID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120C2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_AMENITIESTYPEID","""{"handler":"Valid_Amenitiestypeid","iparms":[{"av":"A99AmenitiesTypeId","fld":"AMENITIESTYPEID","pic":"ZZZ9"},{"av":"A100AmenitiesTypeName","fld":"AMENITIESTYPENAME"}]""");
         setEventMetadata("VALID_AMENITIESTYPEID",""","oparms":[{"av":"A100AmenitiesTypeName","fld":"AMENITIESTYPENAME"}]}""");
         setEventMetadata("VALIDV_COMBOAMENITIESTYPEID","""{"handler":"Validv_Comboamenitiestypeid","iparms":[]}""");
         setEventMetadata("VALID_AMENITIESID","""{"handler":"Valid_Amenitiesid","iparms":[]}""");
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
         Z101AmenitiesName = "";
         Combo_amenitiestypeid_Selectedvalue_get = "";
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
         A101AmenitiesName = "";
         lblTextblockamenitiestypeid_Jsonclick = "";
         ucCombo_amenitiestypeid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15AmenitiesTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A100AmenitiesTypeName = "";
         AV23Pgmname = "";
         Combo_amenitiestypeid_Objectcall = "";
         Combo_amenitiestypeid_Class = "";
         Combo_amenitiestypeid_Icontype = "";
         Combo_amenitiestypeid_Icon = "";
         Combo_amenitiestypeid_Tooltip = "";
         Combo_amenitiestypeid_Selectedvalue_set = "";
         Combo_amenitiestypeid_Selectedtext_set = "";
         Combo_amenitiestypeid_Selectedtext_get = "";
         Combo_amenitiestypeid_Gamoauthtoken = "";
         Combo_amenitiestypeid_Ddointernalname = "";
         Combo_amenitiestypeid_Titlecontrolalign = "";
         Combo_amenitiestypeid_Dropdownoptionstype = "";
         Combo_amenitiestypeid_Titlecontrolidtoreplace = "";
         Combo_amenitiestypeid_Datalisttype = "";
         Combo_amenitiestypeid_Datalistfixedvalues = "";
         Combo_amenitiestypeid_Remoteservicesparameters = "";
         Combo_amenitiestypeid_Htmltemplate = "";
         Combo_amenitiestypeid_Multiplevaluestype = "";
         Combo_amenitiestypeid_Loadingdata = "";
         Combo_amenitiestypeid_Noresultsfound = "";
         Combo_amenitiestypeid_Emptyitemtext = "";
         Combo_amenitiestypeid_Onlyselectedvalues = "";
         Combo_amenitiestypeid_Selectalltext = "";
         Combo_amenitiestypeid_Multiplevaluesseparator = "";
         Combo_amenitiestypeid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
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
         Z100AmenitiesTypeName = "";
         T000C4_A100AmenitiesTypeName = new string[] {""} ;
         T000C5_A98AmenitiesId = new short[1] ;
         T000C5_A101AmenitiesName = new string[] {""} ;
         T000C5_A100AmenitiesTypeName = new string[] {""} ;
         T000C5_A99AmenitiesTypeId = new short[1] ;
         T000C6_A100AmenitiesTypeName = new string[] {""} ;
         T000C7_A98AmenitiesId = new short[1] ;
         T000C3_A98AmenitiesId = new short[1] ;
         T000C3_A101AmenitiesName = new string[] {""} ;
         T000C3_A99AmenitiesTypeId = new short[1] ;
         T000C8_A98AmenitiesId = new short[1] ;
         T000C9_A98AmenitiesId = new short[1] ;
         T000C2_A98AmenitiesId = new short[1] ;
         T000C2_A101AmenitiesName = new string[] {""} ;
         T000C2_A99AmenitiesTypeId = new short[1] ;
         T000C11_A98AmenitiesId = new short[1] ;
         T000C14_A100AmenitiesTypeName = new string[] {""} ;
         T000C15_A1CustomerId = new short[1] ;
         T000C15_A18CustomerLocationId = new short[1] ;
         T000C15_A98AmenitiesId = new short[1] ;
         T000C16_A98AmenitiesId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.amenities__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amenities__default(),
            new Object[][] {
                new Object[] {
               T000C2_A98AmenitiesId, T000C2_A101AmenitiesName, T000C2_A99AmenitiesTypeId
               }
               , new Object[] {
               T000C3_A98AmenitiesId, T000C3_A101AmenitiesName, T000C3_A99AmenitiesTypeId
               }
               , new Object[] {
               T000C4_A100AmenitiesTypeName
               }
               , new Object[] {
               T000C5_A98AmenitiesId, T000C5_A101AmenitiesName, T000C5_A100AmenitiesTypeName, T000C5_A99AmenitiesTypeId
               }
               , new Object[] {
               T000C6_A100AmenitiesTypeName
               }
               , new Object[] {
               T000C7_A98AmenitiesId
               }
               , new Object[] {
               T000C8_A98AmenitiesId
               }
               , new Object[] {
               T000C9_A98AmenitiesId
               }
               , new Object[] {
               }
               , new Object[] {
               T000C11_A98AmenitiesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C14_A100AmenitiesTypeName
               }
               , new Object[] {
               T000C15_A1CustomerId, T000C15_A18CustomerLocationId, T000C15_A98AmenitiesId
               }
               , new Object[] {
               T000C16_A98AmenitiesId
               }
            }
         );
         AV23Pgmname = "Amenities";
      }

      private short wcpOAV7AmenitiesId ;
      private short Z98AmenitiesId ;
      private short Z99AmenitiesTypeId ;
      private short N99AmenitiesTypeId ;
      private short GxWebError ;
      private short A99AmenitiesTypeId ;
      private short AV7AmenitiesId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV20ComboAmenitiesTypeId ;
      private short A98AmenitiesId ;
      private short AV13Insert_AmenitiesTypeId ;
      private short RcdFound22 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int divTablecontent_Width ;
      private int edtAmenitiesName_Enabled ;
      private int edtAmenitiesTypeId_Visible ;
      private int edtAmenitiesTypeId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboamenitiestypeid_Enabled ;
      private int edtavComboamenitiestypeid_Visible ;
      private int edtAmenitiesId_Enabled ;
      private int edtAmenitiesId_Visible ;
      private int Combo_amenitiestypeid_Datalistupdateminimumcharacters ;
      private int Combo_amenitiestypeid_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_amenitiestypeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAmenitiesName_Internalname ;
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
      private string edtAmenitiesName_Jsonclick ;
      private string divTablesplittedamenitiestypeid_Internalname ;
      private string lblTextblockamenitiestypeid_Internalname ;
      private string lblTextblockamenitiestypeid_Jsonclick ;
      private string Combo_amenitiestypeid_Caption ;
      private string Combo_amenitiestypeid_Cls ;
      private string Combo_amenitiestypeid_Datalistproc ;
      private string Combo_amenitiestypeid_Datalistprocparametersprefix ;
      private string Combo_amenitiestypeid_Internalname ;
      private string edtAmenitiesTypeId_Internalname ;
      private string edtAmenitiesTypeId_Jsonclick ;
      private string divActionstable_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_amenitiestypeid_Internalname ;
      private string edtavComboamenitiestypeid_Internalname ;
      private string edtavComboamenitiestypeid_Jsonclick ;
      private string edtAmenitiesId_Internalname ;
      private string edtAmenitiesId_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_amenitiestypeid_Objectcall ;
      private string Combo_amenitiestypeid_Class ;
      private string Combo_amenitiestypeid_Icontype ;
      private string Combo_amenitiestypeid_Icon ;
      private string Combo_amenitiestypeid_Tooltip ;
      private string Combo_amenitiestypeid_Selectedvalue_set ;
      private string Combo_amenitiestypeid_Selectedtext_set ;
      private string Combo_amenitiestypeid_Selectedtext_get ;
      private string Combo_amenitiestypeid_Gamoauthtoken ;
      private string Combo_amenitiestypeid_Ddointernalname ;
      private string Combo_amenitiestypeid_Titlecontrolalign ;
      private string Combo_amenitiestypeid_Dropdownoptionstype ;
      private string Combo_amenitiestypeid_Titlecontrolidtoreplace ;
      private string Combo_amenitiestypeid_Datalisttype ;
      private string Combo_amenitiestypeid_Datalistfixedvalues ;
      private string Combo_amenitiestypeid_Remoteservicesparameters ;
      private string Combo_amenitiestypeid_Htmltemplate ;
      private string Combo_amenitiestypeid_Multiplevaluestype ;
      private string Combo_amenitiestypeid_Loadingdata ;
      private string Combo_amenitiestypeid_Noresultsfound ;
      private string Combo_amenitiestypeid_Emptyitemtext ;
      private string Combo_amenitiestypeid_Onlyselectedvalues ;
      private string Combo_amenitiestypeid_Selectalltext ;
      private string Combo_amenitiestypeid_Multiplevaluesseparator ;
      private string Combo_amenitiestypeid_Addnewoptiontext ;
      private string hsh ;
      private string sMode22 ;
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
      private bool Combo_amenitiestypeid_Emptyitem ;
      private bool Combo_amenitiestypeid_Enabled ;
      private bool Combo_amenitiestypeid_Visible ;
      private bool Combo_amenitiestypeid_Allowmultipleselection ;
      private bool Combo_amenitiestypeid_Isgriditem ;
      private bool Combo_amenitiestypeid_Hasdescription ;
      private bool Combo_amenitiestypeid_Includeonlyselectedoption ;
      private bool Combo_amenitiestypeid_Includeselectalloption ;
      private bool Combo_amenitiestypeid_Includeaddnewoption ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z101AmenitiesName ;
      private string A101AmenitiesName ;
      private string A100AmenitiesTypeName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z100AmenitiesTypeName ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_amenitiestypeid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15AmenitiesTypeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000C4_A100AmenitiesTypeName ;
      private short[] T000C5_A98AmenitiesId ;
      private string[] T000C5_A101AmenitiesName ;
      private string[] T000C5_A100AmenitiesTypeName ;
      private short[] T000C5_A99AmenitiesTypeId ;
      private string[] T000C6_A100AmenitiesTypeName ;
      private short[] T000C7_A98AmenitiesId ;
      private short[] T000C3_A98AmenitiesId ;
      private string[] T000C3_A101AmenitiesName ;
      private short[] T000C3_A99AmenitiesTypeId ;
      private short[] T000C8_A98AmenitiesId ;
      private short[] T000C9_A98AmenitiesId ;
      private short[] T000C2_A98AmenitiesId ;
      private string[] T000C2_A101AmenitiesName ;
      private short[] T000C2_A99AmenitiesTypeId ;
      private short[] T000C11_A98AmenitiesId ;
      private string[] T000C14_A100AmenitiesTypeName ;
      private short[] T000C15_A1CustomerId ;
      private short[] T000C15_A18CustomerLocationId ;
      private short[] T000C15_A98AmenitiesId ;
      private short[] T000C16_A98AmenitiesId ;
      private IDataStoreProvider pr_gam ;
   }

   public class amenities__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class amenities__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000C2;
        prmT000C2 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C3;
        prmT000C3 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C4;
        prmT000C4 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000C5;
        prmT000C5 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C6;
        prmT000C6 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000C7;
        prmT000C7 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C8;
        prmT000C8 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C9;
        prmT000C9 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C10;
        prmT000C10 = new Object[] {
        new ParDef("AmenitiesName",GXType.VarChar,40,0) ,
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000C11;
        prmT000C11 = new Object[] {
        };
        Object[] prmT000C12;
        prmT000C12 = new Object[] {
        new ParDef("AmenitiesName",GXType.VarChar,40,0) ,
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0) ,
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C13;
        prmT000C13 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C14;
        prmT000C14 = new Object[] {
        new ParDef("AmenitiesTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000C15;
        prmT000C15 = new Object[] {
        new ParDef("AmenitiesId",GXType.Int16,4,0)
        };
        Object[] prmT000C16;
        prmT000C16 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000C2", "SELECT AmenitiesId, AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId  FOR UPDATE OF Amenities NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C3", "SELECT AmenitiesId, AmenitiesName, AmenitiesTypeId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C4", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C5", "SELECT TM1.AmenitiesId, TM1.AmenitiesName, T2.AmenitiesTypeName, TM1.AmenitiesTypeId FROM (Amenities TM1 INNER JOIN AmenitiesType T2 ON T2.AmenitiesTypeId = TM1.AmenitiesTypeId) WHERE TM1.AmenitiesId = :AmenitiesId ORDER BY TM1.AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C6", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C7", "SELECT AmenitiesId FROM Amenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C8", "SELECT AmenitiesId FROM Amenities WHERE ( AmenitiesId > :AmenitiesId) ORDER BY AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C9", "SELECT AmenitiesId FROM Amenities WHERE ( AmenitiesId < :AmenitiesId) ORDER BY AmenitiesId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C10", "SAVEPOINT gxupdate;INSERT INTO Amenities(AmenitiesName, AmenitiesTypeId) VALUES(:AmenitiesName, :AmenitiesTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000C10)
           ,new CursorDef("T000C11", "SELECT currval('AmenitiesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C12", "SAVEPOINT gxupdate;UPDATE Amenities SET AmenitiesName=:AmenitiesName, AmenitiesTypeId=:AmenitiesTypeId  WHERE AmenitiesId = :AmenitiesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C12)
           ,new CursorDef("T000C13", "SAVEPOINT gxupdate;DELETE FROM Amenities  WHERE AmenitiesId = :AmenitiesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C13)
           ,new CursorDef("T000C14", "SELECT AmenitiesTypeName FROM AmenitiesType WHERE AmenitiesTypeId = :AmenitiesTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C15", "SELECT CustomerId, CustomerLocationId, AmenitiesId FROM CustomerLocationsAmenities WHERE AmenitiesId = :AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C16", "SELECT AmenitiesId FROM Amenities ORDER BY AmenitiesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
