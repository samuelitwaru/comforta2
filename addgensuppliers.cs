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
   public class addgensuppliers : GXDataArea
   {
      public addgensuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public addgensuppliers( IGxContext context )
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
         dynavLocationoption = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION2M2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
            {
               gxnrGrids_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
            {
               gxgrGrids_refresh_invoke( ) ;
               return  ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         subGrids_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrids_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV26LocationOption = (short)(Math.Round(NumberUtil.Val( GetPar( "LocationOption"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
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
            return "addgensuppliers_Execute" ;
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
         PA2M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2M2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("addgensuppliers.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Locationgensupplierssdts", AV25LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Locationgensupplierssdts", AV25LocationGenSuppliersSDTs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENOPTIONS_DATA", AV47SupplierGenOptions_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENOPTIONS_DATA", AV47SupplierGenOptions_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOCATIONGENSUPPLIERSSDTS", AV25LocationGenSuppliersSDTs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOCATIONGENSUPPLIERSSDTS", AV25LocationGenSuppliersSDTs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCUSTOMER", AV11Customer);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCUSTOMER", AV11Customer);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENOPTIONS", AV46SupplierGenOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENOPTIONS", AV46SupplierGenOptions);
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENOPTIONS_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenoptions_Selectedvalue_get));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2M2( ) ;
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
         return formatLink("addgensuppliers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AddGenSuppliers" ;
      }

      public override string GetPgmdesc( )
      {
         return "Add General Suppliers" ;
      }

      protected void WB2M0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, "Location Option", "gx-form-item AddressAttributeLabel AttirbuteLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26LocationOption), 4, 0)), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 30, "em", 0, "", "", "AddressAttribute Attirbute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_AddGenSuppliers.htm");
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer1_Internalname, "     ", "", "", lblSpacer1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_suppliergenoptions.SetProperty("Caption", Combo_suppliergenoptions_Caption);
            ucCombo_suppliergenoptions.SetProperty("Cls", Combo_suppliergenoptions_Cls);
            ucCombo_suppliergenoptions.SetProperty("AllowMultipleSelection", Combo_suppliergenoptions_Allowmultipleselection);
            ucCombo_suppliergenoptions.SetProperty("DataListProc", Combo_suppliergenoptions_Datalistproc);
            ucCombo_suppliergenoptions.SetProperty("DataListProcParametersPrefix", Combo_suppliergenoptions_Datalistprocparametersprefix);
            ucCombo_suppliergenoptions.SetProperty("IncludeOnlySelectedOption", Combo_suppliergenoptions_Includeonlyselectedoption);
            ucCombo_suppliergenoptions.SetProperty("MultipleValuesType", Combo_suppliergenoptions_Multiplevaluestype);
            ucCombo_suppliergenoptions.SetProperty("EmptyItemText", Combo_suppliergenoptions_Emptyitemtext);
            ucCombo_suppliergenoptions.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_suppliergenoptions.SetProperty("DropDownOptionsData", AV47SupplierGenOptions_Data);
            ucCombo_suppliergenoptions.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenoptions_Internalname, "COMBO_SUPPLIERGENOPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacer2_Internalname, "     ", "", "", lblSpacer2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "MainContainer", 0, "", 1, 1, 0, 0, "HLP_AddGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-start;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsertgensupplier_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Add", bttBtninsertgensupplier_Jsonclick, 5, "Add new item", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERTGENSUPPLIER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AddGenSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV58GXV1 = nGXsfl_35_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucBtnback.SetProperty("TooltipText", Btnback_Tooltiptext);
            ucBtnback.SetProperty("Caption", Btnback_Caption);
            ucBtnback.SetProperty("Class", Btnback_Class);
            ucBtnback.Render(context, "wwp_iconbutton", Btnback_Internalname, "BTNBACKContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnenter.SetProperty("TooltipText", Btnenter_Tooltiptext);
            ucBtnenter.SetProperty("Caption", Btnenter_Caption);
            ucBtnenter.SetProperty("Class", Btnenter_Class);
            ucBtnenter.Render(context, "wwp_iconbutton", Btnenter_Internalname, "BTNENTERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, "GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
                  GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
                  AV58GXV1 = nGXsfl_35_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2M2( )
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
         Form.Meta.addItem("description", "Add General Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2M0( ) ;
      }

      protected void WS2M2( )
      {
         START2M2( ) ;
         EVT2M2( ) ;
      }

      protected void EVT2M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOBACK'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBack' */
                              E112M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E122M2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTGENSUPPLIER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsertGenSupplier' */
                              E132M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrids_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrids_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrids_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrids_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV58GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV25LocationGenSuppliersSDTs.Count >= AV58GXV1 ) && ( AV58GXV1 > 0 ) )
                              {
                                 AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
                                 AV49UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri("", false, edtavUdelete_Internalname, AV49UDelete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E142M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grids.Load */
                                    E152M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162M2 ();
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2M2( )
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

      protected void PA2M2( )
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
               GX_FocusControl = dynavLocationoption_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvLOCATIONOPTION2M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data2M2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTION_html2M2( )
      {
         short gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data2M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLocationoption.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV26LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26LocationOption", StringUtil.LTrimStr( (decimal)(AV26LocationOption), 4, 0));
         }
      }

      protected void GXDLVvLOCATIONOPTION_data2M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H002M2_A1CustomerId[0] == new getloggedinusercustomerid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002M2_A18CustomerLocationId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H002M2_A134CustomerLocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        short AV26LocationOption )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF2M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrids_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONOPTION_html2M2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV26LocationOption = (short)(Math.Round(NumberUtil.Val( dynavLocationoption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26LocationOption), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26LocationOption", StringUtil.LTrimStr( (decimal)(AV26LocationOption), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26LocationOption), 4, 0));
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
      }

      protected void RF2M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 35;
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", "");
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            /* Execute user event: Grids.Load */
            E152M2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_35_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E152M2 ();
            }
            wbEnd = 35;
            WB2M0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2M2( )
      {
      }

      protected int subGrids_fnc_Pagecount( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return AV25LocationGenSuppliersSDTs.Count ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         if ( subGrids_Rows > 0 )
         {
            return subGrids_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nFirstRecordOnPage/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrids_firstpage( )
      {
         GRIDS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_nextpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ( GRIDS_nRecordCount >= subGrids_fnc_Recordsperpage( ) ) && ( GRIDS_nEOF == 0 ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrids_previouspage( )
      {
         if ( GRIDS_nFirstRecordOnPage >= subGrids_fnc_Recordsperpage( ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage-subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_lastpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( GRIDS_nRecordCount > subGrids_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-subGrids_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrids_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDS_nFirstRecordOnPage = (long)(subGrids_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         GXVvLOCATIONOPTION_html2M2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Locationgensupplierssdts"), AV25LocationGenSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENOPTIONS_DATA"), AV47SupplierGenOptions_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vLOCATIONGENSUPPLIERSSDTS"), AV25LocationGenSuppliersSDTs);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENOPTIONS"), AV46SupplierGenOptions);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_35_fel_idx = 0;
            while ( nGXsfl_35_fel_idx < nRC_GXsfl_35 )
            {
               nGXsfl_35_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_fel_idx+1);
               sGXsfl_35_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_352( ) ;
               AV58GXV1 = (int)(nGXsfl_35_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV25LocationGenSuppliersSDTs.Count >= AV58GXV1 ) && ( AV58GXV1 > 0 ) )
               {
                  AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
                  AV49UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_35_fel_idx == 0 )
            {
               nGXsfl_35_idx = 1;
               sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
               SubsflControlProps_352( ) ;
            }
            nGXsfl_35_fel_idx = 1;
            /* Read variables values. */
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV26LocationOption = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavLocationoption_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26LocationOption", StringUtil.LTrimStr( (decimal)(AV26LocationOption), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E142M2 ();
         if (returnInSub) return;
      }

      protected void E142M2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV15GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV14GAMErrors);
         Combo_suppliergenoptions_Gamoauthtoken = AV15GAMSession.gxTpr_Token;
         ucCombo_suppliergenoptions.SendProperty(context, "", false, Combo_suppliergenoptions_Internalname, "GAMOAuthToken", Combo_suppliergenoptions_Gamoauthtoken);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENOPTIONS' */
         S112 ();
         if (returnInSub) return;
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, "", false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GXt_int2 = AV12CustomerId;
         new getloggedinusercustomerid(context ).execute( out  GXt_int2) ;
         AV12CustomerId = GXt_int2;
         AV11Customer.Load(AV12CustomerId);
         GXt_SdtGAMUser3 = AV16GAMUser;
         new getloggedinuser(context ).execute( out  GXt_SdtGAMUser3) ;
         AV16GAMUser = GXt_SdtGAMUser3;
         if ( AV16GAMUser.checkrole("Customer Manager") )
         {
            dynavLocationoption.Visible = 1;
            AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV16GAMUser.checkrole("Receptionist") )
            {
               GXt_int2 = AV26LocationOption;
               new getreceptionistlocationid(context ).execute( out  GXt_int2) ;
               AV26LocationOption = GXt_int2;
               AssignAttri("", false, "AV26LocationOption", StringUtil.LTrimStr( (decimal)(AV26LocationOption), 4, 0));
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      private void E152M2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV25LocationGenSuppliersSDTs.Count )
         {
            AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
            AV49UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavUdelete_Internalname, AV49UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_352( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
            {
               DoAjaxLoad(35, GridsRow);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E112M2( )
      {
         /* 'DoBack' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E122M2 ();
         if (returnInSub) return;
      }

      protected void E122M2( )
      {
         AV58GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV58GXV1 > 0 ) && ( AV25LocationGenSuppliersSDTs.Count >= AV58GXV1 ) )
         {
            AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         AV66GXV9 = 1;
         while ( AV66GXV9 <= AV25LocationGenSuppliersSDTs.Count )
         {
            AV24LocationGenSuppliersSDT = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV66GXV9));
            AV27LocationSupplierGen = new SdtCustomer_Locations_Supplier_Gen(context);
            AV27LocationSupplierGen.gxTpr_Supplier_genid = AV24LocationGenSuppliersSDT.gxTpr_Supplier_genid;
            AV11Customer.gxTpr_Locations.GetByKey(AV26LocationOption).gxTpr_Supplier_gen.Add(AV27LocationSupplierGen, 0);
            AV66GXV9 = (int)(AV66GXV9+1);
         }
         if ( AV11Customer.Update() )
         {
            context.CommitDataStores("addgensuppliers",pr_default);
            AV25LocationGenSuppliersSDTs.Clear();
            gx_BV35 = true;
            CallWebObject(formatLink("locationgensuppliers.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV5ErrorMessages = AV11Customer.GetMessages();
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV5ErrorMessages.Item(1)).gxTpr_Description);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Customer", AV11Customer);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25LocationGenSuppliersSDTs", AV25LocationGenSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
      }

      protected void E132M2( )
      {
         AV58GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV58GXV1 > 0 ) && ( AV25LocationGenSuppliersSDTs.Count >= AV58GXV1 ) )
         {
            AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
         }
         /* 'DoInsertGenSupplier' Routine */
         returnInSub = false;
         AV67GXV10 = 1;
         while ( AV67GXV10 <= AV46SupplierGenOptions.Count )
         {
            AV30selectedSupplierId = (short)(AV46SupplierGenOptions.GetNumeric(AV67GXV10));
            AV57SupplierGen.Load(AV30selectedSupplierId);
            AV24LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_genid = AV57SupplierGen.gxTpr_Supplier_genid;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_genkvknumber = AV57SupplierGen.gxTpr_Supplier_genkvknumber;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_gencompanyname = AV57SupplierGen.gxTpr_Supplier_gencompanyname;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_gencontactname = AV57SupplierGen.gxTpr_Supplier_gencontactname;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_gencontactphone = AV57SupplierGen.gxTpr_Supplier_gencontactphone;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_genpostaladdress = AV57SupplierGen.gxTpr_Supplier_genpostaladdress;
            AV24LocationGenSuppliersSDT.gxTpr_Supplier_genvisitingaddress = AV57SupplierGen.gxTpr_Supplier_genvisitingaddress;
            AV25LocationGenSuppliersSDTs.Add(AV24LocationGenSuppliersSDT, 0);
            gx_BV35 = true;
            AV67GXV10 = (int)(AV67GXV10+1);
         }
         AV46SupplierGenOptions.Clear();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25LocationGenSuppliersSDTs", AV25LocationGenSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SupplierGenOptions", AV46SupplierGenOptions);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENOPTIONS' Routine */
         returnInSub = false;
         AV31SelectedTextCol = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV68GXV11 = 1;
         while ( AV68GXV11 <= AV46SupplierGenOptions.Count )
         {
            AV48SupplierGenOptionsKey = (short)(AV46SupplierGenOptions.GetNumeric(AV68GXV11));
            AssignAttri("", false, "AV48SupplierGenOptionsKey", StringUtil.LTrimStr( (decimal)(AV48SupplierGenOptionsKey), 4, 0));
            AV69GXLvl125 = 0;
            /* Using cursor H002M3 */
            pr_default.execute(1, new Object[] {AV48SupplierGenOptionsKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A64Supplier_GenId = H002M3_A64Supplier_GenId[0];
               A66Supplier_GenCompanyName = H002M3_A66Supplier_GenCompanyName[0];
               AV69GXLvl125 = 1;
               AV31SelectedTextCol.Add(A66Supplier_GenCompanyName, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV69GXLvl125 == 0 )
            {
               AV31SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV48SupplierGenOptionsKey), 4, 0)), 0);
            }
            AV68GXV11 = (int)(AV68GXV11+1);
         }
         Combo_suppliergenoptions_Selectedtext_set = AV31SelectedTextCol.ToJSonString(false);
         ucCombo_suppliergenoptions.SendProperty(context, "", false, Combo_suppliergenoptions_Internalname, "SelectedText_set", Combo_suppliergenoptions_Selectedtext_set);
         Combo_suppliergenoptions_Selectedvalue_set = AV46SupplierGenOptions.ToJSonString(false);
         ucCombo_suppliergenoptions.SendProperty(context, "", false, Combo_suppliergenoptions_Internalname, "SelectedValue_set", Combo_suppliergenoptions_Selectedvalue_set);
      }

      protected void E162M2( )
      {
         AV58GXV1 = (int)(nGXsfl_35_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV58GXV1 > 0 ) && ( AV25LocationGenSuppliersSDTs.Count >= AV58GXV1 ) )
         {
            AV25LocationGenSuppliersSDTs.CurrentItem = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV56SupplierGenId = ((SdtLocationGenSuppliersSDT)(AV25LocationGenSuppliersSDTs.CurrentItem)).gxTpr_Supplier_genid;
         AV20Index = 1;
         AV70GXV12 = 1;
         while ( AV70GXV12 <= AV25LocationGenSuppliersSDTs.Count )
         {
            AV24LocationGenSuppliersSDT = ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV70GXV12));
            if ( AV24LocationGenSuppliersSDT.gxTpr_Supplier_genid == AV56SupplierGenId )
            {
               if (true) break;
            }
            else
            {
               AV20Index = (short)(AV20Index+1);
            }
            AV70GXV12 = (int)(AV70GXV12+1);
         }
         if ( AV20Index <= AV25LocationGenSuppliersSDTs.Count )
         {
            AV25LocationGenSuppliersSDTs.RemoveItem(AV20Index);
            gx_BV35 = true;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25LocationGenSuppliersSDTs", AV25LocationGenSuppliersSDTs);
         nGXsfl_35_bak_idx = nGXsfl_35_idx;
         gxgrGrids_refresh( subGrids_Rows, AV26LocationOption) ;
         nGXsfl_35_idx = nGXsfl_35_bak_idx;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2M2( ) ;
         WS2M2( ) ;
         WE2M2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024912632780", true, true);
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
         context.AddJavascriptSource("addgensuppliers.js", "?2024912632782", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtavUdelete_Internalname = "vUDELETE_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_35_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtavUdelete_Internalname = "vUDELETE_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS_"+sGXsfl_35_fel_idx;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB2M0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsRow = GXWebRow.GetNew(context,GridsContainer);
            if ( subGrids_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrids_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
            else if ( subGrids_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrids_Backstyle = 0;
               subGrids_Backcolor = subGrids_Allbackcolor;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Uniform";
               }
            }
            else if ( subGrids_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
               subGrids_Backcolor = (int)(0x0);
            }
            else if ( subGrids_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Even";
                  }
               }
               else
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Odd";
                  }
               }
            }
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV49UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"","'"+""+"'"+",false,"+"'"+"EVUDELETE.CLICK."+sGXsfl_35_idx+"'",(string)"",(string)"",(string)"Delete item",(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genid), 4, 0, ".", "")),StringUtil.LTrim( ((edtavLocationgensupplierssdts__supplier_genid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genid), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genid), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname,((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_gencompanyname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname,((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genkvknumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactname_Internalname,((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_gencontactname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencontactname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname,StringUtil.RTrim( ((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_gencontactphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname,((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genpostaladdress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname,((SdtLocationGenSuppliersSDT)AV25LocationGenSuppliersSDTs.Item(AV58GXV1)).gxTpr_Supplier_genvisitingaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2M2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_35_idx = ((subGrids_Islastpage==1)&&(nGXsfl_35_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridsContainer"+"DivS\" data-gxgridid=\"35\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrids_Backcolorstyle == 0 )
            {
               subGrids_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrids_Class) > 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Title";
               }
            }
            else
            {
               subGrids_Titlebackstyle = 1;
               if ( subGrids_Backcolorstyle == 1 )
               {
                  subGrids_Titlebackcolor = subGrids_Allbackcolor;
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Supplier_Gen Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Company Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "KvKNumber") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contact Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contact Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Postal Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Visiting Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", "");
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV49UDelete)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         lblSpacer1_Internalname = "SPACER1";
         Combo_suppliergenoptions_Internalname = "COMBO_SUPPLIERGENOPTIONS";
         lblSpacer2_Internalname = "SPACER2";
         bttBtninsertgensupplier_Internalname = "BTNINSERTGENSUPPLIER";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavUdelete_Internalname = "vUDELETE";
         edtavLocationgensupplierssdts__supplier_genid_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENID";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCOMPANYNAME";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENKVKNUMBER";
         edtavLocationgensupplierssdts__supplier_gencontactname_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTNAME";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENCONTACTPHONE";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENPOSTALADDRESS";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname = "LOCATIONGENSUPPLIERSSDTS__SUPPLIER_GENVISITINGADDRESS";
         divTablegrid_Internalname = "TABLEGRID";
         Btnback_Internalname = "BTNBACK";
         Btnenter_Internalname = "BTNENTER";
         divTableactions_Internalname = "TABLEACTIONS";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Grids_empowerer_Internalname = "GRIDS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrids_Internalname = "GRIDS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrids_Allowcollapsing = 0;
         subGrids_Allowselection = 0;
         subGrids_Header = "";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Jsonclick = "";
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = -1;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = -1;
         Btnenter_Class = "Button";
         Btnenter_Caption = "Confirm";
         Btnenter_Tooltiptext = "";
         Btnback_Class = "BtnDefault";
         Btnback_Caption = "Cancel";
         Btnback_Tooltiptext = "";
         Combo_suppliergenoptions_Emptyitemtext = "Select General Supplier to add";
         Combo_suppliergenoptions_Multiplevaluestype = "Tags";
         Combo_suppliergenoptions_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_suppliergenoptions_Datalistprocparametersprefix = " \"ComboName\": \"SupplierGenOptions\"";
         Combo_suppliergenoptions_Datalistproc = "AddGenSuppliersLoadDVCombo";
         Combo_suppliergenoptions_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_suppliergenoptions_Cls = "ExtendedCombo AddressAttribute";
         Combo_suppliergenoptions_Caption = "";
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Add General Suppliers";
         subGrids_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E152M2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV49UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("'DOBACK'","""{"handler":"E112M2","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E122M2","iparms":[{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"},{"av":"AV11Customer","fld":"vCUSTOMER"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11Customer","fld":"vCUSTOMER"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35}]}""");
         setEventMetadata("'DOINSERTGENSUPPLIER'","""{"handler":"E132M2","iparms":[{"av":"AV46SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("'DOINSERTGENSUPPLIER'",""","oparms":[{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"AV46SupplierGenOptions","fld":"vSUPPLIERGENOPTIONS"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E162M2","iparms":[{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35}]}""");
         setEventMetadata("GRIDS_FIRSTPAGE","""{"handler":"subgrids_firstpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_PREVPAGE","""{"handler":"subgrids_previouspage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_NEXTPAGE","""{"handler":"subgrids_nextpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("GRIDS_LASTPAGE","""{"handler":"subgrids_lastpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV25LocationGenSuppliersSDTs","fld":"vLOCATIONGENSUPPLIERSSDTS","grid":35},{"av":"nGXsfl_35_idx","ctrl":"GRID","prop":"GridCurrRow","grid":35},{"av":"nRC_GXsfl_35","ctrl":"GRIDS","prop":"GridRC","grid":35},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"dynavLocationoption"},{"av":"AV26LocationOption","fld":"vLOCATIONOPTION","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv8","iparms":[]}""");
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
         Combo_suppliergenoptions_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV25LocationGenSuppliersSDTs = new GXBaseCollection<SdtLocationGenSuppliersSDT>( context, "LocationGenSuppliersSDT", "");
         AV13DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47SupplierGenOptions_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11Customer = new SdtCustomer(context);
         AV46SupplierGenOptions = new GxSimpleCollection<short>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblSpacer1_Jsonclick = "";
         ucCombo_suppliergenoptions = new GXUserControl();
         lblSpacer2_Jsonclick = "";
         bttBtninsertgensupplier_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnback = new GXUserControl();
         ucBtnenter = new GXUserControl();
         ucGrids_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV49UDelete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002M2_A18CustomerLocationId = new short[1] ;
         H002M2_A134CustomerLocationName = new string[] {""} ;
         H002M2_A1CustomerId = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV14GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         Combo_suppliergenoptions_Gamoauthtoken = "";
         Grids_empowerer_Gridinternalname = "";
         AV16GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser3 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridsRow = new GXWebRow();
         AV24LocationGenSuppliersSDT = new SdtLocationGenSuppliersSDT(context);
         AV27LocationSupplierGen = new SdtCustomer_Locations_Supplier_Gen(context);
         AV5ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV57SupplierGen = new SdtSupplier_Gen(context);
         AV31SelectedTextCol = new GxSimpleCollection<string>();
         H002M3_A64Supplier_GenId = new short[1] ;
         H002M3_A66Supplier_GenCompanyName = new string[] {""} ;
         A66Supplier_GenCompanyName = "";
         Combo_suppliergenoptions_Selectedtext_set = "";
         Combo_suppliergenoptions_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.addgensuppliers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.addgensuppliers__default(),
            new Object[][] {
                new Object[] {
               H002M2_A18CustomerLocationId, H002M2_A134CustomerLocationName, H002M2_A1CustomerId
               }
               , new Object[] {
               H002M3_A64Supplier_GenId, H002M3_A66Supplier_GenCompanyName
               }
            }
         );
         /* GeneXus formulas. */
         edtavUdelete_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genid_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactname_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled = 0;
         edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26LocationOption ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrids_Backcolorstyle ;
      private short AV12CustomerId ;
      private short GXt_int2 ;
      private short AV30selectedSupplierId ;
      private short AV48SupplierGenOptionsKey ;
      private short AV69GXLvl125 ;
      private short A64Supplier_GenId ;
      private short AV56SupplierGenId ;
      private short AV20Index ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_35 ;
      private int subGrids_Rows ;
      private int nGXsfl_35_idx=1 ;
      private int AV58GXV1 ;
      private int gxdynajaxindex ;
      private int subGrids_Islastpage ;
      private int edtavUdelete_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genid_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencompanyname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genkvknumber_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactname_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_gencontactphone_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genpostaladdress_Enabled ;
      private int edtavLocationgensupplierssdts__supplier_genvisitingaddress_Enabled ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_35_fel_idx=1 ;
      private int AV66GXV9 ;
      private int nGXsfl_35_bak_idx=1 ;
      private int AV67GXV10 ;
      private int AV68GXV11 ;
      private int AV70GXV12 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Combo_suppliergenoptions_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string dynavLocationoption_Internalname ;
      private string TempTags ;
      private string dynavLocationoption_Jsonclick ;
      private string lblSpacer1_Internalname ;
      private string lblSpacer1_Jsonclick ;
      private string Combo_suppliergenoptions_Caption ;
      private string Combo_suppliergenoptions_Cls ;
      private string Combo_suppliergenoptions_Datalistproc ;
      private string Combo_suppliergenoptions_Datalistprocparametersprefix ;
      private string Combo_suppliergenoptions_Multiplevaluestype ;
      private string Combo_suppliergenoptions_Emptyitemtext ;
      private string Combo_suppliergenoptions_Internalname ;
      private string lblSpacer2_Internalname ;
      private string lblSpacer2_Jsonclick ;
      private string bttBtninsertgensupplier_Internalname ;
      private string bttBtninsertgensupplier_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnback_Tooltiptext ;
      private string Btnback_Caption ;
      private string Btnback_Class ;
      private string Btnback_Internalname ;
      private string Btnenter_Tooltiptext ;
      private string Btnenter_Caption ;
      private string Btnenter_Class ;
      private string Btnenter_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grids_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV49UDelete ;
      private string edtavUdelete_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string Combo_suppliergenoptions_Gamoauthtoken ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_suppliergenoptions_Selectedtext_set ;
      private string Combo_suppliergenoptions_Selectedvalue_set ;
      private string edtavLocationgensupplierssdts__supplier_genid_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Internalname ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Internalname ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavUdelete_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genid_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencompanyname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genkvknumber_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactname_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_gencontactphone_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genpostaladdress_Jsonclick ;
      private string edtavLocationgensupplierssdts__supplier_genvisitingaddress_Jsonclick ;
      private string subGrids_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Combo_suppliergenoptions_Allowmultipleselection ;
      private bool Combo_suppliergenoptions_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV35 ;
      private string A66Supplier_GenCompanyName ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_suppliergenoptions ;
      private GXUserControl ucBtnback ;
      private GXUserControl ucBtnenter ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXBaseCollection<SdtLocationGenSuppliersSDT> AV25LocationGenSuppliersSDTs ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV47SupplierGenOptions_Data ;
      private SdtCustomer AV11Customer ;
      private GxSimpleCollection<short> AV46SupplierGenOptions ;
      private IDataStoreProvider pr_default ;
      private short[] H002M2_A18CustomerLocationId ;
      private string[] H002M2_A134CustomerLocationName ;
      private short[] H002M2_A1CustomerId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV15GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV16GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser3 ;
      private SdtLocationGenSuppliersSDT AV24LocationGenSuppliersSDT ;
      private SdtCustomer_Locations_Supplier_Gen AV27LocationSupplierGen ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5ErrorMessages ;
      private SdtSupplier_Gen AV57SupplierGen ;
      private GxSimpleCollection<string> AV31SelectedTextCol ;
      private short[] H002M3_A64Supplier_GenId ;
      private string[] H002M3_A66Supplier_GenCompanyName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class addgensuppliers__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class addgensuppliers__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH002M2;
        prmH002M2 = new Object[] {
        };
        Object[] prmH002M3;
        prmH002M3 = new Object[] {
        new ParDef("AV48SupplierGenOptionsKey",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H002M2", "SELECT CustomerLocationId, CustomerLocationName, CustomerId FROM CustomerLocation ORDER BY CustomerLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002M2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002M3", "SELECT Supplier_GenId, Supplier_GenCompanyName FROM Supplier_Gen WHERE Supplier_GenId = :AV48SupplierGenOptionsKey ORDER BY Supplier_GenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002M3,1, GxCacheFrequency.OFF ,false,true )
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
              return;
     }
  }

}

}
