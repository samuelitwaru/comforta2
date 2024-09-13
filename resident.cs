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
   public class resident : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action16") == 0 )
         {
            A36ResidentEmail = GetPar( "ResidentEmail");
            AssignAttri("", false, "A36ResidentEmail", A36ResidentEmail);
            A33ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
            A34ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_16_025( A36ResidentEmail, A33ResidentGivenName, A34ResidentLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action17") == 0 )
         {
            A33ResidentGivenName = GetPar( "ResidentGivenName");
            AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
            A34ResidentLastName = GetPar( "ResidentLastName");
            AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_17_025( A33ResidentGivenName, A34ResidentLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"CUSTOMERLOCATIONID") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLACUSTOMERLOCATIONID025( A1CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A82ResidentTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "ResidentTypeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A82ResidentTypeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A1CustomerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A1CustomerId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerLocationId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A1CustomerId, A18CustomerLocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A73ProductServiceId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A73ProductServiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A71ProductServiceTypeId = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductServiceTypeId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A71ProductServiceTypeId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_inindividual") == 0 )
         {
            gxnrGridlevel_inindividual_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_incompany") == 0 )
         {
            gxnrGridlevel_incompany_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_productservice") == 0 )
         {
            gxnrGridlevel_productservice_newrow_invoke( ) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7ResidentId = (short)(Math.Round(NumberUtil.Val( GetPar( "ResidentId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ResidentId", StringUtil.LTrimStr( (decimal)(AV7ResidentId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ResidentId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Resident", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_inindividual_newrow_invoke( )
      {
         nRC_GXsfl_82 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_82"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_82_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_82_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_82_idx = GetPar( "sGXsfl_82_idx");
         A96ResidentLastLineIndividual = (short)(Math.Round(NumberUtil.Val( GetPar( "ResidentLastLineIndividual"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_inindividual_newrow( ) ;
         /* End function gxnrGridlevel_inindividual_newrow_invoke */
      }

      protected void gxnrGridlevel_incompany_newrow_invoke( )
      {
         nRC_GXsfl_101 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_101"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_101_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_101_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_101_idx = GetPar( "sGXsfl_101_idx");
         A97ResidentLastLineCompany = (short)(Math.Round(NumberUtil.Val( GetPar( "ResidentLastLineCompany"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_incompany_newrow( ) ;
         /* End function gxnrGridlevel_incompany_newrow_invoke */
      }

      protected void gxnrGridlevel_productservice_newrow_invoke( )
      {
         nRC_GXsfl_117 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_117"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_117_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_117_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_117_idx = GetPar( "sGXsfl_117_idx");
         edtProductServiceId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_117_Refreshing);
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_productservice_newrow( ) ;
         /* End function gxnrGridlevel_productservice_newrow_invoke */
      }

      public resident( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public resident( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ResidentId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ResidentId = aP1_ResidentId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynCustomerLocationId = new GXCombobox();
         cmbResidentINIndividualGender = new GXCombobox();
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
            return "resident_Execute" ;
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
         if ( dynCustomerLocationId.ItemCount > 0 )
         {
            A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCustomerLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0));
            AssignProp("", false, dynCustomerLocationId_Internalname, "Values", dynCustomerLocationId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableWizardMainWithShadow", "start", "top", "", "", "div");
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
         /* User Defined Control */
         ucGxuitabspanel_steps.SetProperty("PageCount", Gxuitabspanel_steps_Pagecount);
         ucGxuitabspanel_steps.SetProperty("Class", Gxuitabspanel_steps_Class);
         ucGxuitabspanel_steps.SetProperty("HistoryManagement", Gxuitabspanel_steps_Historymanagement);
         ucGxuitabspanel_steps.Render(context, "tab", Gxuitabspanel_steps_Internalname, "GXUITABSPANEL_STEPSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "Resident Information", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "tabGeneral") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentBsnNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentBsnNumber_Internalname, context.GetMessage( "BSN Number", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentBsnNumber_Internalname, A40ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( A40ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentBsnNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentBsnNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "BsnNumber", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentGivenName_Internalname, context.GetMessage( "Given Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGivenName_Internalname, A33ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( A33ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGivenName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentLastName_Internalname, context.GetMessage( "Last Name", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentLastName_Internalname, A34ResidentLastName, StringUtil.RTrim( context.localUtil.Format( A34ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentLastName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentInitials_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentInitials_Internalname, context.GetMessage( "Initials", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentInitials_Internalname, StringUtil.RTrim( A35ResidentInitials), StringUtil.RTrim( context.localUtil.Format( A35ResidentInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentInitials_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentEmail_Internalname, context.GetMessage( "Email", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentEmail_Internalname, A36ResidentEmail, StringUtil.RTrim( context.localUtil.Format( A36ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A36ResidentEmail, "", "", "", edtResidentEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentPhone_Internalname, context.GetMessage( "Phone", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A38ResidentPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentPhone_Internalname, StringUtil.RTrim( A38ResidentPhone), StringUtil.RTrim( context.localUtil.Format( A38ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtResidentPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedresidenttypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockresidenttypeid_Internalname, context.GetMessage( "Resident Type", ""), "", "", lblTextblockresidenttypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_residenttypeid.SetProperty("Caption", Combo_residenttypeid_Caption);
         ucCombo_residenttypeid.SetProperty("Cls", Combo_residenttypeid_Cls);
         ucCombo_residenttypeid.SetProperty("DataListProc", Combo_residenttypeid_Datalistproc);
         ucCombo_residenttypeid.SetProperty("DataListProcParametersPrefix", Combo_residenttypeid_Datalistprocparametersprefix);
         ucCombo_residenttypeid.SetProperty("EmptyItem", Combo_residenttypeid_Emptyitem);
         ucCombo_residenttypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_residenttypeid.SetProperty("DropDownOptionsData", AV25ResidentTypeId_Data);
         ucCombo_residenttypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residenttypeid_Internalname, "COMBO_RESIDENTTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentTypeId_Internalname, context.GetMessage( "Resident Type Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A82ResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A82ResidentTypeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentTypeId_Visible, edtResidentTypeId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynCustomerLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynCustomerLocationId_Internalname, context.GetMessage( "Location", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCustomerLocationId, dynCustomerLocationId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0)), 1, dynCustomerLocationId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCustomerLocationId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_Resident.htm");
         dynCustomerLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0));
         AssignProp("", false, dynCustomerLocationId_Internalname, "Values", (string)(dynCustomerLocationId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentGAMGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentGAMGUID_Internalname, context.GetMessage( "GAMGUID", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentGAMGUID_Internalname, A39ResidentGAMGUID, StringUtil.RTrim( context.localUtil.Format( A39ResidentGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtResidentGAMGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtResidentAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResidentAddress_Internalname, context.GetMessage( "Address", ""), " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtResidentAddress_Internalname, A37ResidentAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A37ResidentAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", 0, 1, edtResidentAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_inindividual_title_Internalname, context.GetMessage( "INIndividual", ""), "", "", lblTablevel_inindividual_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_INIndividual") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_inindividual_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_inindividual_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_inindividual( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_incompany_title_Internalname, context.GetMessage( "INCompany", ""), "", "", lblTablevel_incompany_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_INCompany") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_incompany_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_incompany_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_incompany( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"title4"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_productservice_title_Internalname, context.GetMessage( "Product Service", ""), "", "", lblTablevel_productservice_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Resident.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_ProductService") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_STEPSContainer"+"panel4"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_productservice_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_productservice_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_productservice( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WizardTrnActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "BtnDefault ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "", context.GetMessage( "GXM_previous", ""), bttBtnwizardprevious_Jsonclick, 7, context.GetMessage( "GXM_previous", ""), "", StyleString, ClassString, bttBtnwizardprevious_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11025_client"+"'", TempTags, "", 2, "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         ClassString = "Button ButtonWizard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "", context.GetMessage( "GXM_next", ""), bttBtnwizardnext_Jsonclick, 7, context.GetMessage( "GXM_next", ""), "", StyleString, ClassString, bttBtnwizardnext_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12025_client"+"'", TempTags, "", 2, "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Resident.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_residenttypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboresidenttypeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ComboResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavComboresidenttypeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ComboResidentTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(AV26ComboResidentTypeId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboresidenttypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboresidenttypeid_Visible, edtavComboresidenttypeid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Resident.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* User Defined Control */
         ucCombo_productserviceid.SetProperty("Caption", Combo_productserviceid_Caption);
         ucCombo_productserviceid.SetProperty("Cls", Combo_productserviceid_Cls);
         ucCombo_productserviceid.SetProperty("IsGridItem", Combo_productserviceid_Isgriditem);
         ucCombo_productserviceid.SetProperty("HasDescription", Combo_productserviceid_Hasdescription);
         ucCombo_productserviceid.SetProperty("DataListProc", Combo_productserviceid_Datalistproc);
         ucCombo_productserviceid.SetProperty("DataListProcParametersPrefix", Combo_productserviceid_Datalistprocparametersprefix);
         ucCombo_productserviceid.SetProperty("EmptyItem", Combo_productserviceid_Emptyitem);
         ucCombo_productserviceid.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_productserviceid.SetProperty("DropDownOptionsData", AV18ProductServiceId_Data);
         ucCombo_productserviceid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_productserviceid_Internalname, "COMBO_PRODUCTSERVICEIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResidentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtResidentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9") : context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResidentId_Jsonclick, 0, "Attribute", "", "", "", "", edtResidentId_Visible, edtResidentId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1CustomerId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerId_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerId_Visible, edtCustomerId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Resident.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerName_Internalname, A3CustomerName, StringUtil.RTrim( context.localUtil.Format( A3CustomerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerName_Jsonclick, 0, "Attribute", "", "", "", "", edtCustomerName_Visible, edtCustomerName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Resident.htm");
         /* User Defined Control */
         ucWizard_steps.Render(context, "dvelop.dvtabstransform", Wizard_steps_Internalname, "WIZARD_STEPSContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_inindividual( )
      {
         /*  Grid Control  */
         StartGridControl82( ) ;
         nGXsfl_82_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount6 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_6 = 1;
               ScanStart026( ) ;
               while ( RcdFound6 != 0 )
               {
                  init_level_properties6( ) ;
                  getByPrimaryKey026( ) ;
                  AddRow026( ) ;
                  ScanNext026( ) ;
               }
               ScanEnd026( ) ;
               nBlankRcdCount6 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            standaloneNotModal026( ) ;
            standaloneModal026( ) ;
            sMode6 = Gx_mode;
            while ( nGXsfl_82_idx < nRC_GXsfl_82 )
            {
               bGXsfl_82_Refreshing = true;
               ReadRow026( ) ;
               edtResidentINIndividualId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualId_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualBsnNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               edtResidentINIndividualAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINIndividualAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0), !bGXsfl_82_Refreshing);
               cmbResidentINIndividualGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbResidentINIndividualGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0), !bGXsfl_82_Refreshing);
               if ( ( nRcdExists_6 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal026( ) ;
               }
               SendRow026( ) ;
               bGXsfl_82_Refreshing = false;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount6 = 5;
            nRcdExists_6 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart026( ) ;
               while ( RcdFound6 != 0 )
               {
                  sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_826( ) ;
                  init_level_properties6( ) ;
                  standaloneNotModal026( ) ;
                  getByPrimaryKey026( ) ;
                  standaloneModal026( ) ;
                  AddRow026( ) ;
                  ScanNext026( ) ;
               }
               ScanEnd026( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode6 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx+1), 4, 0), 4, "0");
            SubsflControlProps_826( ) ;
            InitAll026( ) ;
            init_level_properties6( ) ;
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            nRcdExists_6 = 0;
            nIsMod_6 = 0;
            nRcdDeleted_6 = 0;
            nBlankRcdCount6 = (short)(nBlankRcdUsr6+nBlankRcdCount6);
            fRowAdded = 0;
            while ( nBlankRcdCount6 > 0 )
            {
               standaloneNotModal026( ) ;
               standaloneModal026( ) ;
               AddRow026( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtResidentINIndividualId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount6 = (short)(nBlankRcdCount6-1);
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_inindividualContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_inindividual", Gridlevel_inindividualContainer, subGridlevel_inindividual_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_inindividualContainerData", Gridlevel_inindividualContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_inindividualContainerData"+"V", Gridlevel_inindividualContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_inindividualContainerData"+"V"+"\" value='"+Gridlevel_inindividualContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_incompany( )
      {
         /*  Grid Control  */
         StartGridControl101( ) ;
         nGXsfl_101_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount7 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_7 = 1;
               ScanStart027( ) ;
               while ( RcdFound7 != 0 )
               {
                  init_level_properties7( ) ;
                  getByPrimaryKey027( ) ;
                  AddRow027( ) ;
                  ScanNext027( ) ;
               }
               ScanEnd027( ) ;
               nBlankRcdCount7 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            standaloneNotModal027( ) ;
            standaloneModal027( ) ;
            sMode7 = Gx_mode;
            while ( nGXsfl_101_idx < nRC_GXsfl_101 )
            {
               bGXsfl_101_Refreshing = true;
               ReadRow027( ) ;
               edtResidentINCompanyId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYID_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyId_Enabled), 5, 0), !bGXsfl_101_Refreshing);
               edtResidentINCompanyKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINCompanyKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0), !bGXsfl_101_Refreshing);
               edtResidentINCompanyName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyName_Enabled), 5, 0), !bGXsfl_101_Refreshing);
               edtResidentINCompanyEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINCompanyEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0), !bGXsfl_101_Refreshing);
               edtResidentINCompanyPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtResidentINCompanyPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0), !bGXsfl_101_Refreshing);
               if ( ( nRcdExists_7 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal027( ) ;
               }
               SendRow027( ) ;
               bGXsfl_101_Refreshing = false;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount7 = 5;
            nRcdExists_7 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart027( ) ;
               while ( RcdFound7 != 0 )
               {
                  sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_1017( ) ;
                  init_level_properties7( ) ;
                  standaloneNotModal027( ) ;
                  getByPrimaryKey027( ) ;
                  standaloneModal027( ) ;
                  AddRow027( ) ;
                  ScanNext027( ) ;
               }
               ScanEnd027( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode7 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx+1), 4, 0), 4, "0");
            SubsflControlProps_1017( ) ;
            InitAll027( ) ;
            init_level_properties7( ) ;
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            nRcdExists_7 = 0;
            nIsMod_7 = 0;
            nRcdDeleted_7 = 0;
            nBlankRcdCount7 = (short)(nBlankRcdUsr7+nBlankRcdCount7);
            fRowAdded = 0;
            while ( nBlankRcdCount7 > 0 )
            {
               standaloneNotModal027( ) ;
               standaloneModal027( ) ;
               AddRow027( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtResidentINCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount7 = (short)(nBlankRcdCount7-1);
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_incompanyContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_incompany", Gridlevel_incompanyContainer, subGridlevel_incompany_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_incompanyContainerData", Gridlevel_incompanyContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_incompanyContainerData"+"V", Gridlevel_incompanyContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_incompanyContainerData"+"V"+"\" value='"+Gridlevel_incompanyContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_productservice( )
      {
         /*  Grid Control  */
         StartGridControl117( ) ;
         nGXsfl_117_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount18 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_18 = 1;
               ScanStart0218( ) ;
               while ( RcdFound18 != 0 )
               {
                  init_level_properties18( ) ;
                  getByPrimaryKey0218( ) ;
                  AddRow0218( ) ;
                  ScanNext0218( ) ;
               }
               ScanEnd0218( ) ;
               nBlankRcdCount18 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            standaloneNotModal0218( ) ;
            standaloneModal0218( ) ;
            sMode18 = Gx_mode;
            while ( nGXsfl_117_idx < nRC_GXsfl_117 )
            {
               bGXsfl_117_Refreshing = true;
               ReadRow0218( ) ;
               edtProductServiceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               edtProductServiceId_Horizontalalignment = cgiGet( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Horizontalalignment");
               AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_117_Refreshing);
               edtProductServiceDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               edtProductServiceQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               edtProductServicePicture_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServicePicture_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServicePicture_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               edtProductServiceTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               edtProductServiceTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductServiceTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeName_Enabled), 5, 0), !bGXsfl_117_Refreshing);
               if ( ( nRcdExists_18 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0218( ) ;
               }
               SendRow0218( ) ;
               bGXsfl_117_Refreshing = false;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount18 = 5;
            nRcdExists_18 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0218( ) ;
               while ( RcdFound18 != 0 )
               {
                  sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_11718( ) ;
                  init_level_properties18( ) ;
                  standaloneNotModal0218( ) ;
                  getByPrimaryKey0218( ) ;
                  standaloneModal0218( ) ;
                  AddRow0218( ) ;
                  ScanNext0218( ) ;
               }
               ScanEnd0218( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode18 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx+1), 4, 0), 4, "0");
            SubsflControlProps_11718( ) ;
            InitAll0218( ) ;
            init_level_properties18( ) ;
            B97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            B96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            nRcdExists_18 = 0;
            nIsMod_18 = 0;
            nRcdDeleted_18 = 0;
            nBlankRcdCount18 = (short)(nBlankRcdUsr18+nBlankRcdCount18);
            fRowAdded = 0;
            while ( nBlankRcdCount18 > 0 )
            {
               standaloneNotModal0218( ) ;
               standaloneModal0218( ) ;
               AddRow0218( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount18 = (short)(nBlankRcdCount18-1);
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A97ResidentLastLineCompany = B97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            A96ResidentLastLineIndividual = B96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_productserviceContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_productservice", Gridlevel_productserviceContainer, subGridlevel_productservice_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_productserviceContainerData", Gridlevel_productserviceContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_productserviceContainerData"+"V", Gridlevel_productserviceContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_productserviceContainerData"+"V"+"\" value='"+Gridlevel_productserviceContainer.GridValuesHidden()+"'/>") ;
         }
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
         E13022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vRESIDENTTYPEID_DATA"), AV25ResidentTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSERVICEID_DATA"), AV18ProductServiceId_Data);
               /* Read saved values. */
               Z31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z31ResidentId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z39ResidentGAMGUID = cgiGet( "Z39ResidentGAMGUID");
               Z35ResidentInitials = cgiGet( "Z35ResidentInitials");
               n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
               Z40ResidentBsnNumber = cgiGet( "Z40ResidentBsnNumber");
               Z33ResidentGivenName = cgiGet( "Z33ResidentGivenName");
               Z34ResidentLastName = cgiGet( "Z34ResidentLastName");
               Z36ResidentEmail = cgiGet( "Z36ResidentEmail");
               Z102ResidentGender = cgiGet( "Z102ResidentGender");
               Z37ResidentAddress = cgiGet( "Z37ResidentAddress");
               n37ResidentAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A37ResidentAddress)) ? true : false);
               Z38ResidentPhone = cgiGet( "Z38ResidentPhone");
               n38ResidentPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A38ResidentPhone)) ? true : false);
               Z96ResidentLastLineIndividual = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z96ResidentLastLineIndividual"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z97ResidentLastLineCompany = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z97ResidentLastLineCompany"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z82ResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z82ResidentTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z18CustomerLocationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A102ResidentGender = cgiGet( "Z102ResidentGender");
               A96ResidentLastLineIndividual = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z96ResidentLastLineIndividual"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A97ResidentLastLineCompany = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z97ResidentLastLineCompany"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O97ResidentLastLineCompany = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O97ResidentLastLineCompany"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O96ResidentLastLineIndividual = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O96ResidentLastLineIndividual"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_82 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_82"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_101 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_117 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_117"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N82ResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N82ResidentTypeId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N1CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N1CustomerId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N18CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N18CustomerLocationId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV17TabsActivePage = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vTABSACTIVEPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "vMODE");
               AV15CheckRequiredFieldsResult = StringUtil.StrToBool( cgiGet( "vCHECKREQUIREDFIELDSRESULT"));
               AV7ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vRESIDENTID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_ResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_RESIDENTTYPEID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV27Insert_CustomerId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV28Insert_CustomerLocationId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERLOCATIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A102ResidentGender = cgiGet( "RESIDENTGENDER");
               A96ResidentLastLineIndividual = (short)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTLASTLINEINDIVIDUAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A97ResidentLastLineCompany = (short)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTLASTLINECOMPANY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A83ResidentTypeName = cgiGet( "RESIDENTTYPENAME");
               AV35Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A74ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServicePicture_GXI = cgiGet( "PRODUCTSERVICEPICTURE_GXI");
               Combo_residenttypeid_Objectcall = cgiGet( "COMBO_RESIDENTTYPEID_Objectcall");
               Combo_residenttypeid_Class = cgiGet( "COMBO_RESIDENTTYPEID_Class");
               Combo_residenttypeid_Icontype = cgiGet( "COMBO_RESIDENTTYPEID_Icontype");
               Combo_residenttypeid_Icon = cgiGet( "COMBO_RESIDENTTYPEID_Icon");
               Combo_residenttypeid_Caption = cgiGet( "COMBO_RESIDENTTYPEID_Caption");
               Combo_residenttypeid_Tooltip = cgiGet( "COMBO_RESIDENTTYPEID_Tooltip");
               Combo_residenttypeid_Cls = cgiGet( "COMBO_RESIDENTTYPEID_Cls");
               Combo_residenttypeid_Selectedvalue_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_set");
               Combo_residenttypeid_Selectedvalue_get = cgiGet( "COMBO_RESIDENTTYPEID_Selectedvalue_get");
               Combo_residenttypeid_Selectedtext_set = cgiGet( "COMBO_RESIDENTTYPEID_Selectedtext_set");
               Combo_residenttypeid_Selectedtext_get = cgiGet( "COMBO_RESIDENTTYPEID_Selectedtext_get");
               Combo_residenttypeid_Gamoauthtoken = cgiGet( "COMBO_RESIDENTTYPEID_Gamoauthtoken");
               Combo_residenttypeid_Ddointernalname = cgiGet( "COMBO_RESIDENTTYPEID_Ddointernalname");
               Combo_residenttypeid_Titlecontrolalign = cgiGet( "COMBO_RESIDENTTYPEID_Titlecontrolalign");
               Combo_residenttypeid_Dropdownoptionstype = cgiGet( "COMBO_RESIDENTTYPEID_Dropdownoptionstype");
               Combo_residenttypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Enabled"));
               Combo_residenttypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Visible"));
               Combo_residenttypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_RESIDENTTYPEID_Titlecontrolidtoreplace");
               Combo_residenttypeid_Datalisttype = cgiGet( "COMBO_RESIDENTTYPEID_Datalisttype");
               Combo_residenttypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Allowmultipleselection"));
               Combo_residenttypeid_Datalistfixedvalues = cgiGet( "COMBO_RESIDENTTYPEID_Datalistfixedvalues");
               Combo_residenttypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Isgriditem"));
               Combo_residenttypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Hasdescription"));
               Combo_residenttypeid_Datalistproc = cgiGet( "COMBO_RESIDENTTYPEID_Datalistproc");
               Combo_residenttypeid_Datalistprocparametersprefix = cgiGet( "COMBO_RESIDENTTYPEID_Datalistprocparametersprefix");
               Combo_residenttypeid_Remoteservicesparameters = cgiGet( "COMBO_RESIDENTTYPEID_Remoteservicesparameters");
               Combo_residenttypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTTYPEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_residenttypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeonlyselectedoption"));
               Combo_residenttypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeselectalloption"));
               Combo_residenttypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Emptyitem"));
               Combo_residenttypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESIDENTTYPEID_Includeaddnewoption"));
               Combo_residenttypeid_Htmltemplate = cgiGet( "COMBO_RESIDENTTYPEID_Htmltemplate");
               Combo_residenttypeid_Multiplevaluestype = cgiGet( "COMBO_RESIDENTTYPEID_Multiplevaluestype");
               Combo_residenttypeid_Loadingdata = cgiGet( "COMBO_RESIDENTTYPEID_Loadingdata");
               Combo_residenttypeid_Noresultsfound = cgiGet( "COMBO_RESIDENTTYPEID_Noresultsfound");
               Combo_residenttypeid_Emptyitemtext = cgiGet( "COMBO_RESIDENTTYPEID_Emptyitemtext");
               Combo_residenttypeid_Onlyselectedvalues = cgiGet( "COMBO_RESIDENTTYPEID_Onlyselectedvalues");
               Combo_residenttypeid_Selectalltext = cgiGet( "COMBO_RESIDENTTYPEID_Selectalltext");
               Combo_residenttypeid_Multiplevaluesseparator = cgiGet( "COMBO_RESIDENTTYPEID_Multiplevaluesseparator");
               Combo_residenttypeid_Addnewoptiontext = cgiGet( "COMBO_RESIDENTTYPEID_Addnewoptiontext");
               Combo_residenttypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RESIDENTTYPEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Objectcall = cgiGet( "GXUITABSPANEL_STEPS_Objectcall");
               Gxuitabspanel_steps_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Enabled"));
               Gxuitabspanel_steps_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_STEPS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Activepagecontrolname = cgiGet( "GXUITABSPANEL_STEPS_Activepagecontrolname");
               Gxuitabspanel_steps_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_STEPS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_steps_Class = cgiGet( "GXUITABSPANEL_STEPS_Class");
               Gxuitabspanel_steps_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Historymanagement"));
               Gxuitabspanel_steps_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_STEPS_Visible"));
               Combo_productserviceid_Objectcall = cgiGet( "COMBO_PRODUCTSERVICEID_Objectcall");
               Combo_productserviceid_Class = cgiGet( "COMBO_PRODUCTSERVICEID_Class");
               Combo_productserviceid_Icontype = cgiGet( "COMBO_PRODUCTSERVICEID_Icontype");
               Combo_productserviceid_Icon = cgiGet( "COMBO_PRODUCTSERVICEID_Icon");
               Combo_productserviceid_Caption = cgiGet( "COMBO_PRODUCTSERVICEID_Caption");
               Combo_productserviceid_Tooltip = cgiGet( "COMBO_PRODUCTSERVICEID_Tooltip");
               Combo_productserviceid_Cls = cgiGet( "COMBO_PRODUCTSERVICEID_Cls");
               Combo_productserviceid_Selectedvalue_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_set");
               Combo_productserviceid_Selectedvalue_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_get");
               Combo_productserviceid_Selectedtext_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_set");
               Combo_productserviceid_Selectedtext_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_get");
               Combo_productserviceid_Gamoauthtoken = cgiGet( "COMBO_PRODUCTSERVICEID_Gamoauthtoken");
               Combo_productserviceid_Ddointernalname = cgiGet( "COMBO_PRODUCTSERVICEID_Ddointernalname");
               Combo_productserviceid_Titlecontrolalign = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolalign");
               Combo_productserviceid_Dropdownoptionstype = cgiGet( "COMBO_PRODUCTSERVICEID_Dropdownoptionstype");
               Combo_productserviceid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Enabled"));
               Combo_productserviceid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Visible"));
               Combo_productserviceid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolidtoreplace");
               Combo_productserviceid_Datalisttype = cgiGet( "COMBO_PRODUCTSERVICEID_Datalisttype");
               Combo_productserviceid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Allowmultipleselection"));
               Combo_productserviceid_Datalistfixedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistfixedvalues");
               Combo_productserviceid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Isgriditem"));
               Combo_productserviceid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Hasdescription"));
               Combo_productserviceid_Datalistproc = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistproc");
               Combo_productserviceid_Datalistprocparametersprefix = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix");
               Combo_productserviceid_Remoteservicesparameters = cgiGet( "COMBO_PRODUCTSERVICEID_Remoteservicesparameters");
               Combo_productserviceid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_productserviceid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeonlyselectedoption"));
               Combo_productserviceid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeselectalloption"));
               Combo_productserviceid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitem"));
               Combo_productserviceid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeaddnewoption"));
               Combo_productserviceid_Htmltemplate = cgiGet( "COMBO_PRODUCTSERVICEID_Htmltemplate");
               Combo_productserviceid_Multiplevaluestype = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluestype");
               Combo_productserviceid_Loadingdata = cgiGet( "COMBO_PRODUCTSERVICEID_Loadingdata");
               Combo_productserviceid_Noresultsfound = cgiGet( "COMBO_PRODUCTSERVICEID_Noresultsfound");
               Combo_productserviceid_Emptyitemtext = cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitemtext");
               Combo_productserviceid_Onlyselectedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Onlyselectedvalues");
               Combo_productserviceid_Selectalltext = cgiGet( "COMBO_PRODUCTSERVICEID_Selectalltext");
               Combo_productserviceid_Multiplevaluesseparator = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluesseparator");
               Combo_productserviceid_Addnewoptiontext = cgiGet( "COMBO_PRODUCTSERVICEID_Addnewoptiontext");
               Combo_productserviceid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Wizard_steps_Objectcall = cgiGet( "WIZARD_STEPS_Objectcall");
               Wizard_steps_Class = cgiGet( "WIZARD_STEPS_Class");
               Wizard_steps_Enabled = StringUtil.StrToBool( cgiGet( "WIZARD_STEPS_Enabled"));
               Wizard_steps_Tabsinternalname = cgiGet( "WIZARD_STEPS_Tabsinternalname");
               Wizard_steps_Allowsteptitleclick = cgiGet( "WIZARD_STEPS_Allowsteptitleclick");
               Wizard_steps_Transformtype = cgiGet( "WIZARD_STEPS_Transformtype");
               Wizard_steps_Wizardarrowselectedunselectedimage = cgiGet( "WIZARD_STEPS_Wizardarrowselectedunselectedimage");
               Wizard_steps_Wizardarrowunselectedselectedimage = cgiGet( "WIZARD_STEPS_Wizardarrowunselectedselectedimage");
               Wizard_steps_Visible = StringUtil.StrToBool( cgiGet( "WIZARD_STEPS_Visible"));
               /* Read variables values. */
               A40ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
               AssignAttri("", false, "A40ResidentBsnNumber", A40ResidentBsnNumber);
               A33ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
               AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
               A34ResidentLastName = cgiGet( edtResidentLastName_Internalname);
               AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
               A35ResidentInitials = cgiGet( edtResidentInitials_Internalname);
               n35ResidentInitials = false;
               AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
               n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
               A36ResidentEmail = cgiGet( edtResidentEmail_Internalname);
               AssignAttri("", false, "A36ResidentEmail", A36ResidentEmail);
               A38ResidentPhone = cgiGet( edtResidentPhone_Internalname);
               n38ResidentPhone = false;
               AssignAttri("", false, "A38ResidentPhone", A38ResidentPhone);
               n38ResidentPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A38ResidentPhone)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtResidentTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResidentTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESIDENTTYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A82ResidentTypeId = 0;
                  AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
               }
               else
               {
                  A82ResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
               }
               dynCustomerLocationId.Name = dynCustomerLocationId_Internalname;
               dynCustomerLocationId.CurrentValue = cgiGet( dynCustomerLocationId_Internalname);
               A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynCustomerLocationId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
               A39ResidentGAMGUID = cgiGet( edtResidentGAMGUID_Internalname);
               AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
               A37ResidentAddress = cgiGet( edtResidentAddress_Internalname);
               n37ResidentAddress = false;
               AssignAttri("", false, "A37ResidentAddress", A37ResidentAddress);
               n37ResidentAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A37ResidentAddress)) ? true : false);
               AV26ComboResidentTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboresidenttypeid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26ComboResidentTypeId", StringUtil.LTrimStr( (decimal)(AV26ComboResidentTypeId), 4, 0));
               A31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Resident");
               A31ResidentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
               forbiddenHiddens.Add("ResidentId", context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ResidentGender", StringUtil.RTrim( context.localUtil.Format( A102ResidentGender, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A31ResidentId != Z31ResidentId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("resident:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A31ResidentId = (short)(Math.Round(NumberUtil.Val( GetPar( "ResidentId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RESIDENTID");
                        AnyError = 1;
                        GX_FocusControl = edtResidentId_Internalname;
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
                           E13022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E14022 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E14022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll025( ) ;
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
            DisableAttributes025( ) ;
         }
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Enabled), 5, 0), true);
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

      protected void CONFIRM_020( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls025( ) ;
            }
            else
            {
               CheckExtendedTable025( ) ;
               CloseExtendedTableCursors025( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode5 = Gx_mode;
            CONFIRM_026( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_027( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0218( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     IsConfirmed = 1;
                     AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0218( )
      {
         nGXsfl_117_idx = 0;
         while ( nGXsfl_117_idx < nRC_GXsfl_117 )
         {
            ReadRow0218( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0218( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0218( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0218( ) ;
                        CloseExtendedTableCursors0218( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( nRcdDeleted_18 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0218( ) ;
                        Load0218( ) ;
                        BeforeValidate0218( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0218( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0218( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0218( ) ;
                              CloseExtendedTableCursors0218( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductServiceId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductServiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServiceDescription_Internalname, A75ProductServiceDescription) ;
            ChangePostValue( edtProductServiceQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServicePicture_Internalname, A77ProductServicePicture) ;
            ChangePostValue( edtProductServiceTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServiceTypeName_Internalname, A72ProductServiceTypeName) ;
            ChangePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment)) ;
               ChangePostValue( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_027( )
      {
         s97ResidentLastLineCompany = O97ResidentLastLineCompany;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         nGXsfl_101_idx = 0;
         while ( nGXsfl_101_idx < nRC_GXsfl_101 )
         {
            ReadRow027( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               GetKey027( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  if ( RcdFound7 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate027( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable027( ) ;
                        CloseExtendedTableCursors027( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                        AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "RESIDENTINCOMPANYID_" + sGXsfl_101_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtResidentINCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( nRcdDeleted_7 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey027( ) ;
                        Load027( ) ;
                        BeforeValidate027( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls027( ) ;
                           O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                           AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate027( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable027( ) ;
                              CloseExtendedTableCursors027( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                              AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "RESIDENTINCOMPANYID_" + sGXsfl_101_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtResidentINCompanyId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtResidentINCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtResidentINCompanyKvkNumber_Internalname, A51ResidentINCompanyKvkNumber) ;
            ChangePostValue( edtResidentINCompanyName_Internalname, A52ResidentINCompanyName) ;
            ChangePostValue( edtResidentINCompanyEmail_Internalname, A53ResidentINCompanyEmail) ;
            ChangePostValue( edtResidentINCompanyPhone_Internalname, StringUtil.RTrim( A54ResidentINCompanyPhone)) ;
            ChangePostValue( "ZT_"+"Z50ResidentINCompanyId_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z51ResidentINCompanyKvkNumber_"+sGXsfl_101_idx, Z51ResidentINCompanyKvkNumber) ;
            ChangePostValue( "ZT_"+"Z52ResidentINCompanyName_"+sGXsfl_101_idx, Z52ResidentINCompanyName) ;
            ChangePostValue( "ZT_"+"Z53ResidentINCompanyEmail_"+sGXsfl_101_idx, Z53ResidentINCompanyEmail) ;
            ChangePostValue( "ZT_"+"Z54ResidentINCompanyPhone_"+sGXsfl_101_idx, StringUtil.RTrim( Z54ResidentINCompanyPhone)) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "RESIDENTINCOMPANYID_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O97ResidentLastLineCompany = s97ResidentLastLineCompany;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_026( )
      {
         s96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         nGXsfl_82_idx = 0;
         while ( nGXsfl_82_idx < nRC_GXsfl_82 )
         {
            ReadRow026( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               GetKey026( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  if ( RcdFound6 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate026( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable026( ) ;
                        CloseExtendedTableCursors026( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                        AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "RESIDENTININDIVIDUALID_" + sGXsfl_82_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtResidentINIndividualId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( nRcdDeleted_6 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey026( ) ;
                        Load026( ) ;
                        BeforeValidate026( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls026( ) ;
                           O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                           AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate026( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable026( ) ;
                              CloseExtendedTableCursors026( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                              AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "RESIDENTININDIVIDUALID_" + sGXsfl_82_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtResidentINIndividualId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtResidentINIndividualId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtResidentINIndividualBsnNumber_Internalname, A43ResidentINIndividualBsnNumber) ;
            ChangePostValue( edtResidentINIndividualGivenName_Internalname, A44ResidentINIndividualGivenName) ;
            ChangePostValue( edtResidentINIndividualLastName_Internalname, A45ResidentINIndividualLastName) ;
            ChangePostValue( edtResidentINIndividualEmail_Internalname, A46ResidentINIndividualEmail) ;
            ChangePostValue( edtResidentINIndividualPhone_Internalname, StringUtil.RTrim( A47ResidentINIndividualPhone)) ;
            ChangePostValue( edtResidentINIndividualAddress_Internalname, A48ResidentINIndividualAddress) ;
            ChangePostValue( cmbResidentINIndividualGender_Internalname, StringUtil.RTrim( A49ResidentINIndividualGender)) ;
            ChangePostValue( "ZT_"+"Z42ResidentINIndividualId_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z43ResidentINIndividualBsnNumber_"+sGXsfl_82_idx, Z43ResidentINIndividualBsnNumber) ;
            ChangePostValue( "ZT_"+"Z44ResidentINIndividualGivenName_"+sGXsfl_82_idx, Z44ResidentINIndividualGivenName) ;
            ChangePostValue( "ZT_"+"Z45ResidentINIndividualLastName_"+sGXsfl_82_idx, Z45ResidentINIndividualLastName) ;
            ChangePostValue( "ZT_"+"Z46ResidentINIndividualEmail_"+sGXsfl_82_idx, Z46ResidentINIndividualEmail) ;
            ChangePostValue( "ZT_"+"Z47ResidentINIndividualPhone_"+sGXsfl_82_idx, StringUtil.RTrim( Z47ResidentINIndividualPhone)) ;
            ChangePostValue( "ZT_"+"Z48ResidentINIndividualAddress_"+sGXsfl_82_idx, Z48ResidentINIndividualAddress) ;
            ChangePostValue( "ZT_"+"Z49ResidentINIndividualGender_"+sGXsfl_82_idx, StringUtil.RTrim( Z49ResidentINIndividualGender)) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E13022( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            Wizard_steps_Tabsinternalname = "GXUITabsPanel_Steps";
            ucWizard_steps.SendProperty(context, "", false, Wizard_steps_Internalname, "TabsInternalName", Wizard_steps_Tabsinternalname);
            if ( StringUtil.StrCmp(AV16HTTPRequest.Method, "GET") == 0 )
            {
               bttBtnwizardprevious_Visible = 0;
               AssignProp("", false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
         }
         else
         {
            bttBtnwizardprevious_Visible = 0;
            AssignProp("", false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
            bttBtnwizardnext_Visible = 0;
            AssignProp("", false, bttBtnwizardnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardnext_Visible), 5, 0), true);
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV24GAMErrors);
         Combo_productserviceid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "GAMOAuthToken", Combo_productserviceid_Gamoauthtoken);
         Combo_productserviceid_Titlecontrolidtoreplace = edtProductServiceId_Internalname;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "TitleControlIdToReplace", Combo_productserviceid_Titlecontrolidtoreplace);
         edtProductServiceId_Horizontalalignment = "Left";
         AssignProp("", false, edtProductServiceId_Internalname, "Horizontalalignment", edtProductServiceId_Horizontalalignment, !bGXsfl_117_Refreshing);
         Combo_residenttypeid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "GAMOAuthToken", Combo_residenttypeid_Gamoauthtoken);
         edtResidentTypeId_Visible = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Visible), 5, 0), true);
         AV26ComboResidentTypeId = 0;
         AssignAttri("", false, "AV26ComboResidentTypeId", StringUtil.LTrimStr( (decimal)(AV26ComboResidentTypeId), 4, 0));
         edtavComboresidenttypeid_Visible = 0;
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESIDENTTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV35Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV36GXV1 = 1;
            AssignAttri("", false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            while ( AV36GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ResidentTypeId") == 0 )
               {
                  AV13Insert_ResidentTypeId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ResidentTypeId", StringUtil.LTrimStr( (decimal)(AV13Insert_ResidentTypeId), 4, 0));
                  if ( ! (0==AV13Insert_ResidentTypeId) )
                  {
                     AV26ComboResidentTypeId = AV13Insert_ResidentTypeId;
                     AssignAttri("", false, "AV26ComboResidentTypeId", StringUtil.LTrimStr( (decimal)(AV26ComboResidentTypeId), 4, 0));
                     Combo_residenttypeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ComboResidentTypeId), 4, 0));
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new residentloaddvcombo(context ).execute(  "ResidentTypeId",  "GET",  false,  AV7ResidentId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_residenttypeid_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedText_set", Combo_residenttypeid_Selectedtext_set);
                     Combo_residenttypeid_Enabled = false;
                     ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerId") == 0 )
               {
                  AV27Insert_CustomerId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV27Insert_CustomerId", StringUtil.LTrimStr( (decimal)(AV27Insert_CustomerId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CustomerLocationId") == 0 )
               {
                  AV28Insert_CustomerLocationId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV28Insert_CustomerLocationId", StringUtil.LTrimStr( (decimal)(AV28Insert_CustomerLocationId), 4, 0));
               }
               AV36GXV1 = (int)(AV36GXV1+1);
               AssignAttri("", false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            }
         }
         edtResidentId_Visible = 0;
         AssignProp("", false, edtResidentId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtResidentId_Visible), 5, 0), true);
         edtCustomerId_Visible = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerId_Visible), 5, 0), true);
         edtCustomerName_Visible = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCustomerName_Visible), 5, 0), true);
      }

      protected void E14022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            context.PopUp(formatLink("residentqrcode.aspx", new object[] {UrlEncode(StringUtil.RTrim(A36ResidentEmail))}, new string[] {"ResidentEmail"}) , new Object[] {});
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("residentww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S152( )
      {
         /* 'UPDATE WIZARD STEPS BUTTONS VISIBILITY' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            bttBtnwizardprevious_Visible = (((Gxuitabspanel_steps_Activepage!=1)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
            bttBtntrn_cancel_Visible = (((Gxuitabspanel_steps_Activepage==1)) ? 1 : 0);
            AssignProp("", false, bttBtntrn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_cancel_Visible), 5, 0), true);
            bttBtnwizardnext_Visible = (((Gxuitabspanel_steps_Activepage!=4)) ? 1 : 0);
            AssignProp("", false, bttBtnwizardnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardnext_Visible), 5, 0), true);
            bttBtntrn_enter_Visible = (((Gxuitabspanel_steps_Activepage==4)) ? 1 : 0);
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS_TABGENERAL' Routine */
         returnInSub = false;
         AV15CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS_TABLEVEL_ININDIVIDUAL' Routine */
         returnInSub = false;
         AV15CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS_TABLEVEL_INCOMPANY' Routine */
         returnInSub = false;
         AV15CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESIDENTTYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new residentloaddvcombo(context ).execute(  "ResidentTypeId",  Gx_mode,  false,  AV7ResidentId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_residenttypeid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedValue_set", Combo_residenttypeid_Selectedvalue_set);
         Combo_residenttypeid_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "SelectedText_set", Combo_residenttypeid_Selectedtext_set);
         AV26ComboResidentTypeId = (short)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV26ComboResidentTypeId", StringUtil.LTrimStr( (decimal)(AV26ComboResidentTypeId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_residenttypeid_Enabled = false;
            ucCombo_residenttypeid.SendProperty(context, "", false, Combo_residenttypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         }
      }

      protected void ZM025( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z39ResidentGAMGUID = T000211_A39ResidentGAMGUID[0];
               Z35ResidentInitials = T000211_A35ResidentInitials[0];
               Z40ResidentBsnNumber = T000211_A40ResidentBsnNumber[0];
               Z33ResidentGivenName = T000211_A33ResidentGivenName[0];
               Z34ResidentLastName = T000211_A34ResidentLastName[0];
               Z36ResidentEmail = T000211_A36ResidentEmail[0];
               Z102ResidentGender = T000211_A102ResidentGender[0];
               Z37ResidentAddress = T000211_A37ResidentAddress[0];
               Z38ResidentPhone = T000211_A38ResidentPhone[0];
               Z96ResidentLastLineIndividual = T000211_A96ResidentLastLineIndividual[0];
               Z97ResidentLastLineCompany = T000211_A97ResidentLastLineCompany[0];
               Z82ResidentTypeId = T000211_A82ResidentTypeId[0];
               Z1CustomerId = T000211_A1CustomerId[0];
               Z18CustomerLocationId = T000211_A18CustomerLocationId[0];
            }
            else
            {
               Z39ResidentGAMGUID = A39ResidentGAMGUID;
               Z35ResidentInitials = A35ResidentInitials;
               Z40ResidentBsnNumber = A40ResidentBsnNumber;
               Z33ResidentGivenName = A33ResidentGivenName;
               Z34ResidentLastName = A34ResidentLastName;
               Z36ResidentEmail = A36ResidentEmail;
               Z102ResidentGender = A102ResidentGender;
               Z37ResidentAddress = A37ResidentAddress;
               Z38ResidentPhone = A38ResidentPhone;
               Z96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
               Z97ResidentLastLineCompany = A97ResidentLastLineCompany;
               Z82ResidentTypeId = A82ResidentTypeId;
               Z1CustomerId = A1CustomerId;
               Z18CustomerLocationId = A18CustomerLocationId;
            }
         }
         if ( GX_JID == -25 )
         {
            Z31ResidentId = A31ResidentId;
            Z39ResidentGAMGUID = A39ResidentGAMGUID;
            Z35ResidentInitials = A35ResidentInitials;
            Z40ResidentBsnNumber = A40ResidentBsnNumber;
            Z33ResidentGivenName = A33ResidentGivenName;
            Z34ResidentLastName = A34ResidentLastName;
            Z36ResidentEmail = A36ResidentEmail;
            Z102ResidentGender = A102ResidentGender;
            Z37ResidentAddress = A37ResidentAddress;
            Z38ResidentPhone = A38ResidentPhone;
            Z96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            Z97ResidentLastLineCompany = A97ResidentLastLineCompany;
            Z82ResidentTypeId = A82ResidentTypeId;
            Z1CustomerId = A1CustomerId;
            Z18CustomerLocationId = A18CustomerLocationId;
            Z83ResidentTypeName = A83ResidentTypeName;
            Z3CustomerName = A3CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         AV35Pgmname = "Resident";
         AssignAttri("", false, "AV35Pgmname", AV35Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ResidentId) )
         {
            A31ResidentId = AV7ResidentId;
            AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ResidentTypeId) )
         {
            edtResidentTypeId_Enabled = 0;
            AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtResidentTypeId_Enabled = 1;
            AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_CustomerId) )
         {
            edtCustomerId_Enabled = 0;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerId_Enabled = 1;
            AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_CustomerLocationId) )
         {
            dynCustomerLocationId.Enabled = 0;
            AssignProp("", false, dynCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCustomerLocationId.Enabled), 5, 0), true);
         }
         else
         {
            dynCustomerLocationId.Enabled = 1;
            AssignProp("", false, dynCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCustomerLocationId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_CustomerLocationId) )
         {
            A18CustomerLocationId = AV28Insert_CustomerLocationId;
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_CustomerId) )
         {
            A1CustomerId = AV27Insert_CustomerId;
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ResidentTypeId) )
         {
            A82ResidentTypeId = AV13Insert_ResidentTypeId;
            AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
         }
         else
         {
            A82ResidentTypeId = AV26ComboResidentTypeId;
            AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
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
            /* Using cursor T000213 */
            pr_default.execute(11, new Object[] {A1CustomerId});
            A3CustomerName = T000213_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            pr_default.close(11);
            GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
            /* Using cursor T000212 */
            pr_default.execute(10, new Object[] {A82ResidentTypeId});
            A83ResidentTypeName = T000212_A83ResidentTypeName[0];
            pr_default.close(10);
         }
      }

      protected void Load025( )
      {
         /* Using cursor T000215 */
         pr_default.execute(13, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1;
            A39ResidentGAMGUID = T000215_A39ResidentGAMGUID[0];
            AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
            A35ResidentInitials = T000215_A35ResidentInitials[0];
            n35ResidentInitials = T000215_n35ResidentInitials[0];
            AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
            A40ResidentBsnNumber = T000215_A40ResidentBsnNumber[0];
            AssignAttri("", false, "A40ResidentBsnNumber", A40ResidentBsnNumber);
            A33ResidentGivenName = T000215_A33ResidentGivenName[0];
            AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
            A34ResidentLastName = T000215_A34ResidentLastName[0];
            AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
            A36ResidentEmail = T000215_A36ResidentEmail[0];
            AssignAttri("", false, "A36ResidentEmail", A36ResidentEmail);
            A102ResidentGender = T000215_A102ResidentGender[0];
            A37ResidentAddress = T000215_A37ResidentAddress[0];
            n37ResidentAddress = T000215_n37ResidentAddress[0];
            AssignAttri("", false, "A37ResidentAddress", A37ResidentAddress);
            A38ResidentPhone = T000215_A38ResidentPhone[0];
            n38ResidentPhone = T000215_n38ResidentPhone[0];
            AssignAttri("", false, "A38ResidentPhone", A38ResidentPhone);
            A83ResidentTypeName = T000215_A83ResidentTypeName[0];
            A3CustomerName = T000215_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            A96ResidentLastLineIndividual = T000215_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = T000215_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = T000215_A82ResidentTypeId[0];
            AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
            A1CustomerId = T000215_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = T000215_A18CustomerLocationId[0];
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            ZM025( -25) ;
         }
         pr_default.close(13);
         OnLoadActions025( ) ;
      }

      protected void OnLoadActions025( )
      {
         GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
      }

      protected void CheckExtendedTable025( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000216 */
         pr_default.execute(14, new Object[] {A40ResidentBsnNumber, A31ResidentId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Resident Bsn Number", "")}), 1, "RESIDENTBSNNUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         new getnameinitials(context ).execute(  A33ResidentGivenName,  A34ResidentLastName, out  A35ResidentInitials) ;
         AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
         n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
         if ( ! ( GxRegex.IsMatch(A36ResidentEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RESIDENTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtResidentEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {A82ResidentTypeId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A83ResidentTypeName = T000212_A83ResidentTypeName[0];
         pr_default.close(10);
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000213_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         pr_default.close(11);
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CustomerLocation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
      }

      protected void CloseExtendedTableCursors025( )
      {
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_27( short A82ResidentTypeId )
      {
         /* Using cursor T000217 */
         pr_default.execute(15, new Object[] {A82ResidentTypeId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A83ResidentTypeName = T000217_A83ResidentTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A83ResidentTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_28( short A1CustomerId )
      {
         /* Using cursor T000218 */
         pr_default.execute(16, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3CustomerName = T000218_A3CustomerName[0];
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A3CustomerName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_29( short A1CustomerId ,
                                short A18CustomerLocationId )
      {
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CustomerLocation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey025( )
      {
         /* Using cursor T000220 */
         pr_default.execute(18, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM025( 25) ;
            RcdFound5 = 1;
            A31ResidentId = T000211_A31ResidentId[0];
            AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
            A39ResidentGAMGUID = T000211_A39ResidentGAMGUID[0];
            AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
            A35ResidentInitials = T000211_A35ResidentInitials[0];
            n35ResidentInitials = T000211_n35ResidentInitials[0];
            AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
            A40ResidentBsnNumber = T000211_A40ResidentBsnNumber[0];
            AssignAttri("", false, "A40ResidentBsnNumber", A40ResidentBsnNumber);
            A33ResidentGivenName = T000211_A33ResidentGivenName[0];
            AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
            A34ResidentLastName = T000211_A34ResidentLastName[0];
            AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
            A36ResidentEmail = T000211_A36ResidentEmail[0];
            AssignAttri("", false, "A36ResidentEmail", A36ResidentEmail);
            A102ResidentGender = T000211_A102ResidentGender[0];
            A37ResidentAddress = T000211_A37ResidentAddress[0];
            n37ResidentAddress = T000211_n37ResidentAddress[0];
            AssignAttri("", false, "A37ResidentAddress", A37ResidentAddress);
            A38ResidentPhone = T000211_A38ResidentPhone[0];
            n38ResidentPhone = T000211_n38ResidentPhone[0];
            AssignAttri("", false, "A38ResidentPhone", A38ResidentPhone);
            A96ResidentLastLineIndividual = T000211_A96ResidentLastLineIndividual[0];
            A97ResidentLastLineCompany = T000211_A97ResidentLastLineCompany[0];
            A82ResidentTypeId = T000211_A82ResidentTypeId[0];
            AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
            A1CustomerId = T000211_A1CustomerId[0];
            AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
            A18CustomerLocationId = T000211_A18CustomerLocationId[0];
            AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
            O97ResidentLastLineCompany = A97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            Z31ResidentId = A31ResidentId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load025( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey025( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey025( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(9);
      }

      protected void getEqualNoModal( )
      {
         GetKey025( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000221 */
         pr_default.execute(19, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( T000221_A31ResidentId[0] < A31ResidentId ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( T000221_A31ResidentId[0] > A31ResidentId ) ) )
            {
               A31ResidentId = T000221_A31ResidentId[0];
               AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000222 */
         pr_default.execute(20, new Object[] {A31ResidentId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( T000222_A31ResidentId[0] > A31ResidentId ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( T000222_A31ResidentId[0] < A31ResidentId ) ) )
            {
               A31ResidentId = T000222_A31ResidentId[0];
               AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey025( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            A97ResidentLastLineCompany = O97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert025( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A31ResidentId != Z31ResidentId )
               {
                  A31ResidentId = Z31ResidentId;
                  AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESIDENTID");
                  AnyError = 1;
                  GX_FocusControl = edtResidentId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                  Update025( ) ;
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A31ResidentId != Z31ResidentId )
               {
                  /* Insert record */
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                  GX_FocusControl = edtResidentBsnNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert025( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESIDENTID");
                     AnyError = 1;
                     GX_FocusControl = edtResidentId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                     AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                     A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                     AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                     GX_FocusControl = edtResidentBsnNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert025( ) ;
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
         if ( A31ResidentId != Z31ResidentId )
         {
            A31ResidentId = Z31ResidentId;
            AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESIDENTID");
            AnyError = 1;
            GX_FocusControl = edtResidentId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            A97ResidentLastLineCompany = O97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtResidentBsnNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency025( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000210 */
            pr_default.execute(8, new Object[] {A31ResidentId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resident"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z39ResidentGAMGUID, T000210_A39ResidentGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z35ResidentInitials, T000210_A35ResidentInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z40ResidentBsnNumber, T000210_A40ResidentBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z33ResidentGivenName, T000210_A33ResidentGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z34ResidentLastName, T000210_A34ResidentLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z36ResidentEmail, T000210_A36ResidentEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z102ResidentGender, T000210_A102ResidentGender[0]) != 0 ) || ( StringUtil.StrCmp(Z37ResidentAddress, T000210_A37ResidentAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z38ResidentPhone, T000210_A38ResidentPhone[0]) != 0 ) || ( Z96ResidentLastLineIndividual != T000210_A96ResidentLastLineIndividual[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z97ResidentLastLineCompany != T000210_A97ResidentLastLineCompany[0] ) || ( Z82ResidentTypeId != T000210_A82ResidentTypeId[0] ) || ( Z1CustomerId != T000210_A1CustomerId[0] ) || ( Z18CustomerLocationId != T000210_A18CustomerLocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z39ResidentGAMGUID, T000210_A39ResidentGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z39ResidentGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000210_A39ResidentGAMGUID[0]);
               }
               if ( StringUtil.StrCmp(Z35ResidentInitials, T000210_A35ResidentInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentInitials");
                  GXUtil.WriteLogRaw("Old: ",Z35ResidentInitials);
                  GXUtil.WriteLogRaw("Current: ",T000210_A35ResidentInitials[0]);
               }
               if ( StringUtil.StrCmp(Z40ResidentBsnNumber, T000210_A40ResidentBsnNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentBsnNumber");
                  GXUtil.WriteLogRaw("Old: ",Z40ResidentBsnNumber);
                  GXUtil.WriteLogRaw("Current: ",T000210_A40ResidentBsnNumber[0]);
               }
               if ( StringUtil.StrCmp(Z33ResidentGivenName, T000210_A33ResidentGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z33ResidentGivenName);
                  GXUtil.WriteLogRaw("Current: ",T000210_A33ResidentGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z34ResidentLastName, T000210_A34ResidentLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentLastName");
                  GXUtil.WriteLogRaw("Old: ",Z34ResidentLastName);
                  GXUtil.WriteLogRaw("Current: ",T000210_A34ResidentLastName[0]);
               }
               if ( StringUtil.StrCmp(Z36ResidentEmail, T000210_A36ResidentEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentEmail");
                  GXUtil.WriteLogRaw("Old: ",Z36ResidentEmail);
                  GXUtil.WriteLogRaw("Current: ",T000210_A36ResidentEmail[0]);
               }
               if ( StringUtil.StrCmp(Z102ResidentGender, T000210_A102ResidentGender[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentGender");
                  GXUtil.WriteLogRaw("Old: ",Z102ResidentGender);
                  GXUtil.WriteLogRaw("Current: ",T000210_A102ResidentGender[0]);
               }
               if ( StringUtil.StrCmp(Z37ResidentAddress, T000210_A37ResidentAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentAddress");
                  GXUtil.WriteLogRaw("Old: ",Z37ResidentAddress);
                  GXUtil.WriteLogRaw("Current: ",T000210_A37ResidentAddress[0]);
               }
               if ( StringUtil.StrCmp(Z38ResidentPhone, T000210_A38ResidentPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentPhone");
                  GXUtil.WriteLogRaw("Old: ",Z38ResidentPhone);
                  GXUtil.WriteLogRaw("Current: ",T000210_A38ResidentPhone[0]);
               }
               if ( Z96ResidentLastLineIndividual != T000210_A96ResidentLastLineIndividual[0] )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentLastLineIndividual");
                  GXUtil.WriteLogRaw("Old: ",Z96ResidentLastLineIndividual);
                  GXUtil.WriteLogRaw("Current: ",T000210_A96ResidentLastLineIndividual[0]);
               }
               if ( Z97ResidentLastLineCompany != T000210_A97ResidentLastLineCompany[0] )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentLastLineCompany");
                  GXUtil.WriteLogRaw("Old: ",Z97ResidentLastLineCompany);
                  GXUtil.WriteLogRaw("Current: ",T000210_A97ResidentLastLineCompany[0]);
               }
               if ( Z82ResidentTypeId != T000210_A82ResidentTypeId[0] )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z82ResidentTypeId);
                  GXUtil.WriteLogRaw("Current: ",T000210_A82ResidentTypeId[0]);
               }
               if ( Z1CustomerId != T000210_A1CustomerId[0] )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"CustomerId");
                  GXUtil.WriteLogRaw("Old: ",Z1CustomerId);
                  GXUtil.WriteLogRaw("Current: ",T000210_A1CustomerId[0]);
               }
               if ( Z18CustomerLocationId != T000210_A18CustomerLocationId[0] )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"CustomerLocationId");
                  GXUtil.WriteLogRaw("Old: ",Z18CustomerLocationId);
                  GXUtil.WriteLogRaw("Current: ",T000210_A18CustomerLocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Resident"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert025( )
      {
         if ( ! IsAuthorized("resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM025( 0) ;
            CheckOptimisticConcurrency025( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm025( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert025( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000223 */
                     pr_default.execute(21, new Object[] {A39ResidentGAMGUID, n35ResidentInitials, A35ResidentInitials, A40ResidentBsnNumber, A33ResidentGivenName, A34ResidentLastName, A36ResidentEmail, A102ResidentGender, n37ResidentAddress, A37ResidentAddress, n38ResidentPhone, A38ResidentPhone, A96ResidentLastLineIndividual, A97ResidentLastLineCompany, A82ResidentTypeId, A1CustomerId, A18CustomerLocationId});
                     pr_default.close(21);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000224 */
                     pr_default.execute(22);
                     A31ResidentId = T000224_A31ResidentId[0];
                     AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel025( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption020( ) ;
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
            else
            {
               Load025( ) ;
            }
            EndLevel025( ) ;
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void Update025( )
      {
         if ( ! IsAuthorized("resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency025( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm025( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate025( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000225 */
                     pr_default.execute(23, new Object[] {A39ResidentGAMGUID, n35ResidentInitials, A35ResidentInitials, A40ResidentBsnNumber, A33ResidentGivenName, A34ResidentLastName, A36ResidentEmail, A102ResidentGender, n37ResidentAddress, A37ResidentAddress, n38ResidentPhone, A38ResidentPhone, A96ResidentLastLineIndividual, A97ResidentLastLineCompany, A82ResidentTypeId, A1CustomerId, A18CustomerLocationId, A31ResidentId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
                     if ( (pr_default.getStatus(23) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Resident"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate025( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel025( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel025( ) ;
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void DeferredUpdate025( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency025( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls025( ) ;
            AfterConfirm025( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete025( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0218( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0218( ) ;
                     Delete0218( ) ;
                     ScanNext0218( ) ;
                  }
                  ScanEnd0218( ) ;
                  A97ResidentLastLineCompany = O97ResidentLastLineCompany;
                  AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                  ScanStart027( ) ;
                  while ( RcdFound7 != 0 )
                  {
                     getByPrimaryKey027( ) ;
                     Delete027( ) ;
                     ScanNext027( ) ;
                     O97ResidentLastLineCompany = A97ResidentLastLineCompany;
                     AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
                  }
                  ScanEnd027( ) ;
                  A96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
                  AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                  ScanStart026( ) ;
                  while ( RcdFound6 != 0 )
                  {
                     getByPrimaryKey026( ) ;
                     Delete026( ) ;
                     ScanNext026( ) ;
                     O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
                     AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
                  }
                  ScanEnd026( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000226 */
                     pr_default.execute(24, new Object[] {A31ResidentId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Resident");
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
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel025( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls025( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000227 */
            pr_default.execute(25, new Object[] {A82ResidentTypeId});
            A83ResidentTypeName = T000227_A83ResidentTypeName[0];
            pr_default.close(25);
            /* Using cursor T000228 */
            pr_default.execute(26, new Object[] {A1CustomerId});
            A3CustomerName = T000228_A3CustomerName[0];
            AssignAttri("", false, "A3CustomerName", A3CustomerName);
            pr_default.close(26);
            GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
         }
      }

      protected void ProcessNestedLevel026( )
      {
         s96ResidentLastLineIndividual = O96ResidentLastLineIndividual;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         nGXsfl_82_idx = 0;
         while ( nGXsfl_82_idx < nRC_GXsfl_82 )
         {
            ReadRow026( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               standaloneNotModal026( ) ;
               GetKey026( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert026( ) ;
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( ( nRcdDeleted_6 != 0 ) && ( nRcdExists_6 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete026( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update026( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "RESIDENTININDIVIDUALID_" + sGXsfl_82_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtResidentINIndividualId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
               AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            }
            ChangePostValue( edtResidentINIndividualId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtResidentINIndividualBsnNumber_Internalname, A43ResidentINIndividualBsnNumber) ;
            ChangePostValue( edtResidentINIndividualGivenName_Internalname, A44ResidentINIndividualGivenName) ;
            ChangePostValue( edtResidentINIndividualLastName_Internalname, A45ResidentINIndividualLastName) ;
            ChangePostValue( edtResidentINIndividualEmail_Internalname, A46ResidentINIndividualEmail) ;
            ChangePostValue( edtResidentINIndividualPhone_Internalname, StringUtil.RTrim( A47ResidentINIndividualPhone)) ;
            ChangePostValue( edtResidentINIndividualAddress_Internalname, A48ResidentINIndividualAddress) ;
            ChangePostValue( cmbResidentINIndividualGender_Internalname, StringUtil.RTrim( A49ResidentINIndividualGender)) ;
            ChangePostValue( "ZT_"+"Z42ResidentINIndividualId_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z43ResidentINIndividualBsnNumber_"+sGXsfl_82_idx, Z43ResidentINIndividualBsnNumber) ;
            ChangePostValue( "ZT_"+"Z44ResidentINIndividualGivenName_"+sGXsfl_82_idx, Z44ResidentINIndividualGivenName) ;
            ChangePostValue( "ZT_"+"Z45ResidentINIndividualLastName_"+sGXsfl_82_idx, Z45ResidentINIndividualLastName) ;
            ChangePostValue( "ZT_"+"Z46ResidentINIndividualEmail_"+sGXsfl_82_idx, Z46ResidentINIndividualEmail) ;
            ChangePostValue( "ZT_"+"Z47ResidentINIndividualPhone_"+sGXsfl_82_idx, StringUtil.RTrim( Z47ResidentINIndividualPhone)) ;
            ChangePostValue( "ZT_"+"Z48ResidentINIndividualAddress_"+sGXsfl_82_idx, Z48ResidentINIndividualAddress) ;
            ChangePostValue( "ZT_"+"Z49ResidentINIndividualGender_"+sGXsfl_82_idx, StringUtil.RTrim( Z49ResidentINIndividualGender)) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_82_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll026( ) ;
         if ( AnyError != 0 )
         {
            O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
         nRcdDeleted_6 = 0;
      }

      protected void ProcessNestedLevel027( )
      {
         s97ResidentLastLineCompany = O97ResidentLastLineCompany;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         nGXsfl_101_idx = 0;
         while ( nGXsfl_101_idx < nRC_GXsfl_101 )
         {
            ReadRow027( ) ;
            if ( ( nRcdExists_7 != 0 ) || ( nIsMod_7 != 0 ) )
            {
               standaloneNotModal027( ) ;
               GetKey027( ) ;
               if ( ( nRcdExists_7 == 0 ) && ( nRcdDeleted_7 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert027( ) ;
               }
               else
               {
                  if ( RcdFound7 != 0 )
                  {
                     if ( ( nRcdDeleted_7 != 0 ) && ( nRcdExists_7 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete027( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_7 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update027( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_7 == 0 )
                     {
                        GXCCtl = "RESIDENTINCOMPANYID_" + sGXsfl_101_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtResidentINCompanyId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O97ResidentLastLineCompany = A97ResidentLastLineCompany;
               AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
            }
            ChangePostValue( edtResidentINCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtResidentINCompanyKvkNumber_Internalname, A51ResidentINCompanyKvkNumber) ;
            ChangePostValue( edtResidentINCompanyName_Internalname, A52ResidentINCompanyName) ;
            ChangePostValue( edtResidentINCompanyEmail_Internalname, A53ResidentINCompanyEmail) ;
            ChangePostValue( edtResidentINCompanyPhone_Internalname, StringUtil.RTrim( A54ResidentINCompanyPhone)) ;
            ChangePostValue( "ZT_"+"Z50ResidentINCompanyId_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z51ResidentINCompanyKvkNumber_"+sGXsfl_101_idx, Z51ResidentINCompanyKvkNumber) ;
            ChangePostValue( "ZT_"+"Z52ResidentINCompanyName_"+sGXsfl_101_idx, Z52ResidentINCompanyName) ;
            ChangePostValue( "ZT_"+"Z53ResidentINCompanyEmail_"+sGXsfl_101_idx, Z53ResidentINCompanyEmail) ;
            ChangePostValue( "ZT_"+"Z54ResidentINCompanyPhone_"+sGXsfl_101_idx, StringUtil.RTrim( Z54ResidentINCompanyPhone)) ;
            ChangePostValue( "nRcdDeleted_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_7_"+sGXsfl_101_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_7 != 0 )
            {
               ChangePostValue( "RESIDENTINCOMPANYID_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll027( ) ;
         if ( AnyError != 0 )
         {
            O97ResidentLastLineCompany = s97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         }
         nRcdExists_7 = 0;
         nIsMod_7 = 0;
         nRcdDeleted_7 = 0;
      }

      protected void ProcessNestedLevel0218( )
      {
         nGXsfl_117_idx = 0;
         while ( nGXsfl_117_idx < nRC_GXsfl_117 )
         {
            ReadRow0218( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0218( ) ;
               GetKey0218( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0218( ) ;
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( ( nRcdDeleted_18 != 0 ) && ( nRcdExists_18 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0218( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0218( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductServiceId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductServiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServiceDescription_Internalname, A75ProductServiceDescription) ;
            ChangePostValue( edtProductServiceQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServicePicture_Internalname, A77ProductServicePicture) ;
            ChangePostValue( edtProductServiceTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProductServiceTypeName_Internalname, A72ProductServiceTypeName) ;
            ChangePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_117_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment)) ;
               ChangePostValue( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0218( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
         nRcdDeleted_18 = 0;
      }

      protected void ProcessLevel025( )
      {
         /* Save parent mode. */
         sMode5 = Gx_mode;
         ProcessNestedLevel026( ) ;
         ProcessNestedLevel027( ) ;
         ProcessNestedLevel0218( ) ;
         if ( AnyError != 0 )
         {
            O96ResidentLastLineIndividual = s96ResidentLastLineIndividual;
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
            O97ResidentLastLineCompany = s97ResidentLastLineCompany;
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000229 */
         pr_default.execute(27, new Object[] {A97ResidentLastLineCompany, A96ResidentLastLineIndividual, A31ResidentId});
         pr_default.close(27);
         pr_default.SmartCacheProvider.SetUpdated("Resident");
      }

      protected void EndLevel025( )
      {
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete025( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("resident",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("resident",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart025( )
      {
         /* Scan By routine */
         /* Using cursor T000230 */
         pr_default.execute(28);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound5 = 1;
            A31ResidentId = T000230_A31ResidentId[0];
            AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext025( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound5 = 1;
            A31ResidentId = T000230_A31ResidentId[0];
            AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
         }
      }

      protected void ScanEnd025( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm025( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert025( )
      {
         /* Before Insert Rules */
         new createuseraccount(context ).execute(  A36ResidentEmail,  A33ResidentGivenName,  A34ResidentLastName,  "Resident", out  A39ResidentGAMGUID) ;
         AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
      }

      protected void BeforeUpdate025( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete025( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete025( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate025( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes025( )
      {
         edtResidentBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentBsnNumber_Enabled), 5, 0), true);
         edtResidentGivenName_Enabled = 0;
         AssignProp("", false, edtResidentGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGivenName_Enabled), 5, 0), true);
         edtResidentLastName_Enabled = 0;
         AssignProp("", false, edtResidentLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentLastName_Enabled), 5, 0), true);
         edtResidentInitials_Enabled = 0;
         AssignProp("", false, edtResidentInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentInitials_Enabled), 5, 0), true);
         edtResidentEmail_Enabled = 0;
         AssignProp("", false, edtResidentEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentEmail_Enabled), 5, 0), true);
         edtResidentPhone_Enabled = 0;
         AssignProp("", false, edtResidentPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentPhone_Enabled), 5, 0), true);
         edtResidentTypeId_Enabled = 0;
         AssignProp("", false, edtResidentTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentTypeId_Enabled), 5, 0), true);
         dynCustomerLocationId.Enabled = 0;
         AssignProp("", false, dynCustomerLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCustomerLocationId.Enabled), 5, 0), true);
         edtResidentGAMGUID_Enabled = 0;
         AssignProp("", false, edtResidentGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentGAMGUID_Enabled), 5, 0), true);
         edtResidentAddress_Enabled = 0;
         AssignProp("", false, edtResidentAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentAddress_Enabled), 5, 0), true);
         edtavComboresidenttypeid_Enabled = 0;
         AssignProp("", false, edtavComboresidenttypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboresidenttypeid_Enabled), 5, 0), true);
         edtResidentId_Enabled = 0;
         AssignProp("", false, edtResidentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentId_Enabled), 5, 0), true);
         edtCustomerId_Enabled = 0;
         AssignProp("", false, edtCustomerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerId_Enabled), 5, 0), true);
         edtCustomerName_Enabled = 0;
         AssignProp("", false, edtCustomerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerName_Enabled), 5, 0), true);
      }

      protected void ZM026( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43ResidentINIndividualBsnNumber = T00029_A43ResidentINIndividualBsnNumber[0];
               Z44ResidentINIndividualGivenName = T00029_A44ResidentINIndividualGivenName[0];
               Z45ResidentINIndividualLastName = T00029_A45ResidentINIndividualLastName[0];
               Z46ResidentINIndividualEmail = T00029_A46ResidentINIndividualEmail[0];
               Z47ResidentINIndividualPhone = T00029_A47ResidentINIndividualPhone[0];
               Z48ResidentINIndividualAddress = T00029_A48ResidentINIndividualAddress[0];
               Z49ResidentINIndividualGender = T00029_A49ResidentINIndividualGender[0];
            }
            else
            {
               Z43ResidentINIndividualBsnNumber = A43ResidentINIndividualBsnNumber;
               Z44ResidentINIndividualGivenName = A44ResidentINIndividualGivenName;
               Z45ResidentINIndividualLastName = A45ResidentINIndividualLastName;
               Z46ResidentINIndividualEmail = A46ResidentINIndividualEmail;
               Z47ResidentINIndividualPhone = A47ResidentINIndividualPhone;
               Z48ResidentINIndividualAddress = A48ResidentINIndividualAddress;
               Z49ResidentINIndividualGender = A49ResidentINIndividualGender;
            }
         }
         if ( GX_JID == -30 )
         {
            Z31ResidentId = A31ResidentId;
            Z42ResidentINIndividualId = A42ResidentINIndividualId;
            Z43ResidentINIndividualBsnNumber = A43ResidentINIndividualBsnNumber;
            Z44ResidentINIndividualGivenName = A44ResidentINIndividualGivenName;
            Z45ResidentINIndividualLastName = A45ResidentINIndividualLastName;
            Z46ResidentINIndividualEmail = A46ResidentINIndividualEmail;
            Z47ResidentINIndividualPhone = A47ResidentINIndividualPhone;
            Z48ResidentINIndividualAddress = A48ResidentINIndividualAddress;
            Z49ResidentINIndividualGender = A49ResidentINIndividualGender;
         }
      }

      protected void standaloneNotModal026( )
      {
      }

      protected void standaloneModal026( )
      {
         if ( IsIns( )  )
         {
            A96ResidentLastLineIndividual = (short)(O96ResidentLastLineIndividual+1);
            AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A42ResidentINIndividualId = A96ResidentLastLineIndividual;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtResidentINIndividualId_Enabled = 0;
            AssignProp("", false, edtResidentINIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualId_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         }
         else
         {
            edtResidentINIndividualId_Enabled = 1;
            AssignProp("", false, edtResidentINIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualId_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         }
      }

      protected void Load026( )
      {
         /* Using cursor T000231 */
         pr_default.execute(29, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound6 = 1;
            A43ResidentINIndividualBsnNumber = T000231_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = T000231_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = T000231_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = T000231_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = T000231_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = T000231_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = T000231_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = T000231_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = T000231_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = T000231_A49ResidentINIndividualGender[0];
            ZM026( -30) ;
         }
         pr_default.close(29);
         OnLoadActions026( ) ;
      }

      protected void OnLoadActions026( )
      {
      }

      protected void CheckExtendedTable026( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal026( ) ;
         if ( ! ( GxRegex.IsMatch(A46ResidentINIndividualEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A46ResidentINIndividualEmail)) ) )
         {
            GXCCtl = "RESIDENTININDIVIDUALEMAIL_" + sGXsfl_82_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident INIndividual Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtResidentINIndividualEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Man") == 0 ) || ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Woman") == 0 ) || ( StringUtil.StrCmp(A49ResidentINIndividualGender, "Other") == 0 ) ) )
         {
            GXCCtl = "RESIDENTININDIVIDUALGENDER_" + sGXsfl_82_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Resident INIndividual Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbResidentINIndividualGender_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors026( )
      {
      }

      protected void enableDisable026( )
      {
      }

      protected void GetKey026( )
      {
         /* Using cursor T000232 */
         pr_default.execute(30, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(30);
      }

      protected void getByPrimaryKey026( )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A31ResidentId, A42ResidentINIndividualId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM026( 30) ;
            RcdFound6 = 1;
            InitializeNonKey026( ) ;
            A42ResidentINIndividualId = T00029_A42ResidentINIndividualId[0];
            A43ResidentINIndividualBsnNumber = T00029_A43ResidentINIndividualBsnNumber[0];
            A44ResidentINIndividualGivenName = T00029_A44ResidentINIndividualGivenName[0];
            A45ResidentINIndividualLastName = T00029_A45ResidentINIndividualLastName[0];
            A46ResidentINIndividualEmail = T00029_A46ResidentINIndividualEmail[0];
            n46ResidentINIndividualEmail = T00029_n46ResidentINIndividualEmail[0];
            A47ResidentINIndividualPhone = T00029_A47ResidentINIndividualPhone[0];
            n47ResidentINIndividualPhone = T00029_n47ResidentINIndividualPhone[0];
            A48ResidentINIndividualAddress = T00029_A48ResidentINIndividualAddress[0];
            n48ResidentINIndividualAddress = T00029_n48ResidentINIndividualAddress[0];
            A49ResidentINIndividualGender = T00029_A49ResidentINIndividualGender[0];
            Z31ResidentId = A31ResidentId;
            Z42ResidentINIndividualId = A42ResidentINIndividualId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load026( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey026( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal026( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes026( ) ;
         }
         pr_default.close(7);
      }

      protected void CheckOptimisticConcurrency026( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00028 */
            pr_default.execute(6, new Object[] {A31ResidentId, A42ResidentINIndividualId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z43ResidentINIndividualBsnNumber, T00028_A43ResidentINIndividualBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44ResidentINIndividualGivenName, T00028_A44ResidentINIndividualGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z45ResidentINIndividualLastName, T00028_A45ResidentINIndividualLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z46ResidentINIndividualEmail, T00028_A46ResidentINIndividualEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z47ResidentINIndividualPhone, T00028_A47ResidentINIndividualPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z48ResidentINIndividualAddress, T00028_A48ResidentINIndividualAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z49ResidentINIndividualGender, T00028_A49ResidentINIndividualGender[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z43ResidentINIndividualBsnNumber, T00028_A43ResidentINIndividualBsnNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualBsnNumber");
                  GXUtil.WriteLogRaw("Old: ",Z43ResidentINIndividualBsnNumber);
                  GXUtil.WriteLogRaw("Current: ",T00028_A43ResidentINIndividualBsnNumber[0]);
               }
               if ( StringUtil.StrCmp(Z44ResidentINIndividualGivenName, T00028_A44ResidentINIndividualGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z44ResidentINIndividualGivenName);
                  GXUtil.WriteLogRaw("Current: ",T00028_A44ResidentINIndividualGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z45ResidentINIndividualLastName, T00028_A45ResidentINIndividualLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualLastName");
                  GXUtil.WriteLogRaw("Old: ",Z45ResidentINIndividualLastName);
                  GXUtil.WriteLogRaw("Current: ",T00028_A45ResidentINIndividualLastName[0]);
               }
               if ( StringUtil.StrCmp(Z46ResidentINIndividualEmail, T00028_A46ResidentINIndividualEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualEmail");
                  GXUtil.WriteLogRaw("Old: ",Z46ResidentINIndividualEmail);
                  GXUtil.WriteLogRaw("Current: ",T00028_A46ResidentINIndividualEmail[0]);
               }
               if ( StringUtil.StrCmp(Z47ResidentINIndividualPhone, T00028_A47ResidentINIndividualPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualPhone");
                  GXUtil.WriteLogRaw("Old: ",Z47ResidentINIndividualPhone);
                  GXUtil.WriteLogRaw("Current: ",T00028_A47ResidentINIndividualPhone[0]);
               }
               if ( StringUtil.StrCmp(Z48ResidentINIndividualAddress, T00028_A48ResidentINIndividualAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualAddress");
                  GXUtil.WriteLogRaw("Old: ",Z48ResidentINIndividualAddress);
                  GXUtil.WriteLogRaw("Current: ",T00028_A48ResidentINIndividualAddress[0]);
               }
               if ( StringUtil.StrCmp(Z49ResidentINIndividualGender, T00028_A49ResidentINIndividualGender[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINIndividualGender");
                  GXUtil.WriteLogRaw("Old: ",Z49ResidentINIndividualGender);
                  GXUtil.WriteLogRaw("Current: ",T00028_A49ResidentINIndividualGender[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentINIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert026( )
      {
         if ( ! IsAuthorized("resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable026( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM026( 0) ;
            CheckOptimisticConcurrency026( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm026( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert026( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000233 */
                     pr_default.execute(31, new Object[] {A31ResidentId, A42ResidentINIndividualId, A43ResidentINIndividualBsnNumber, A44ResidentINIndividualGivenName, A45ResidentINIndividualLastName, n46ResidentINIndividualEmail, A46ResidentINIndividualEmail, n47ResidentINIndividualPhone, A47ResidentINIndividualPhone, n48ResidentINIndividualAddress, A48ResidentINIndividualAddress, A49ResidentINIndividualGender});
                     pr_default.close(31);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
                     if ( (pr_default.getStatus(31) == 1) )
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
               Load026( ) ;
            }
            EndLevel026( ) ;
         }
         CloseExtendedTableCursors026( ) ;
      }

      protected void Update026( )
      {
         if ( ! IsAuthorized("resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable026( ) ;
         }
         if ( ( nIsMod_6 != 0 ) || ( nIsDirty_6 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency026( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm026( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate026( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000234 */
                        pr_default.execute(32, new Object[] {A43ResidentINIndividualBsnNumber, A44ResidentINIndividualGivenName, A45ResidentINIndividualLastName, n46ResidentINIndividualEmail, A46ResidentINIndividualEmail, n47ResidentINIndividualPhone, A47ResidentINIndividualPhone, n48ResidentINIndividualAddress, A48ResidentINIndividualAddress, A49ResidentINIndividualGender, A31ResidentId, A42ResidentINIndividualId});
                        pr_default.close(32);
                        pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
                        if ( (pr_default.getStatus(32) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINIndividual"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate026( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey026( ) ;
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
               EndLevel026( ) ;
            }
         }
         CloseExtendedTableCursors026( ) ;
      }

      protected void DeferredUpdate026( )
      {
      }

      protected void Delete026( )
      {
         if ( ! IsAuthorized("resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate026( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency026( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls026( ) ;
            AfterConfirm026( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete026( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000235 */
                  pr_default.execute(33, new Object[] {A31ResidentId, A42ResidentINIndividualId});
                  pr_default.close(33);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentINIndividual");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel026( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls026( )
      {
         standaloneModal026( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel026( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart026( )
      {
         /* Scan By routine */
         /* Using cursor T000236 */
         pr_default.execute(34, new Object[] {A31ResidentId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound6 = 1;
            A42ResidentINIndividualId = T000236_A42ResidentINIndividualId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext026( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound6 = 1;
            A42ResidentINIndividualId = T000236_A42ResidentINIndividualId[0];
         }
      }

      protected void ScanEnd026( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm026( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert026( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate026( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete026( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete026( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate026( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes026( )
      {
         edtResidentINIndividualId_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualId_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualBsnNumber_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualBsnNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualGivenName_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualLastName_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualEmail_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualPhone_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         edtResidentINIndividualAddress_Enabled = 0;
         AssignProp("", false, edtResidentINIndividualAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0), !bGXsfl_82_Refreshing);
         cmbResidentINIndividualGender.Enabled = 0;
         AssignProp("", false, cmbResidentINIndividualGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0), !bGXsfl_82_Refreshing);
      }

      protected void send_integrity_lvl_hashes026( )
      {
      }

      protected void ZM027( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z51ResidentINCompanyKvkNumber = T00027_A51ResidentINCompanyKvkNumber[0];
               Z52ResidentINCompanyName = T00027_A52ResidentINCompanyName[0];
               Z53ResidentINCompanyEmail = T00027_A53ResidentINCompanyEmail[0];
               Z54ResidentINCompanyPhone = T00027_A54ResidentINCompanyPhone[0];
            }
            else
            {
               Z51ResidentINCompanyKvkNumber = A51ResidentINCompanyKvkNumber;
               Z52ResidentINCompanyName = A52ResidentINCompanyName;
               Z53ResidentINCompanyEmail = A53ResidentINCompanyEmail;
               Z54ResidentINCompanyPhone = A54ResidentINCompanyPhone;
            }
         }
         if ( GX_JID == -31 )
         {
            Z31ResidentId = A31ResidentId;
            Z50ResidentINCompanyId = A50ResidentINCompanyId;
            Z51ResidentINCompanyKvkNumber = A51ResidentINCompanyKvkNumber;
            Z52ResidentINCompanyName = A52ResidentINCompanyName;
            Z53ResidentINCompanyEmail = A53ResidentINCompanyEmail;
            Z54ResidentINCompanyPhone = A54ResidentINCompanyPhone;
         }
      }

      protected void standaloneNotModal027( )
      {
      }

      protected void standaloneModal027( )
      {
         if ( IsIns( )  )
         {
            A97ResidentLastLineCompany = (short)(O97ResidentLastLineCompany+1);
            AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A50ResidentINCompanyId = A97ResidentLastLineCompany;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtResidentINCompanyId_Enabled = 0;
            AssignProp("", false, edtResidentINCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyId_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         }
         else
         {
            edtResidentINCompanyId_Enabled = 1;
            AssignProp("", false, edtResidentINCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyId_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         }
      }

      protected void Load027( )
      {
         /* Using cursor T000237 */
         pr_default.execute(35, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound7 = 1;
            A51ResidentINCompanyKvkNumber = T000237_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = T000237_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = T000237_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = T000237_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = T000237_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = T000237_n54ResidentINCompanyPhone[0];
            ZM027( -31) ;
         }
         pr_default.close(35);
         OnLoadActions027( ) ;
      }

      protected void OnLoadActions027( )
      {
      }

      protected void CheckExtendedTable027( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal027( ) ;
         if ( ! ( GxRegex.IsMatch(A53ResidentINCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A53ResidentINCompanyEmail)) ) )
         {
            GXCCtl = "RESIDENTINCOMPANYEMAIL_" + sGXsfl_101_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Resident INCompany Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtResidentINCompanyEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors027( )
      {
      }

      protected void enableDisable027( )
      {
      }

      protected void GetKey027( )
      {
         /* Using cursor T000238 */
         pr_default.execute(36, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(36);
      }

      protected void getByPrimaryKey027( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A31ResidentId, A50ResidentINCompanyId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM027( 31) ;
            RcdFound7 = 1;
            InitializeNonKey027( ) ;
            A50ResidentINCompanyId = T00027_A50ResidentINCompanyId[0];
            A51ResidentINCompanyKvkNumber = T00027_A51ResidentINCompanyKvkNumber[0];
            A52ResidentINCompanyName = T00027_A52ResidentINCompanyName[0];
            A53ResidentINCompanyEmail = T00027_A53ResidentINCompanyEmail[0];
            n53ResidentINCompanyEmail = T00027_n53ResidentINCompanyEmail[0];
            A54ResidentINCompanyPhone = T00027_A54ResidentINCompanyPhone[0];
            n54ResidentINCompanyPhone = T00027_n54ResidentINCompanyPhone[0];
            Z31ResidentId = A31ResidentId;
            Z50ResidentINCompanyId = A50ResidentINCompanyId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load027( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey027( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal027( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes027( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency027( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00026 */
            pr_default.execute(4, new Object[] {A31ResidentId, A50ResidentINCompanyId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z51ResidentINCompanyKvkNumber, T00026_A51ResidentINCompanyKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z52ResidentINCompanyName, T00026_A52ResidentINCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z53ResidentINCompanyEmail, T00026_A53ResidentINCompanyEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z54ResidentINCompanyPhone, T00026_A54ResidentINCompanyPhone[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z51ResidentINCompanyKvkNumber, T00026_A51ResidentINCompanyKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINCompanyKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z51ResidentINCompanyKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00026_A51ResidentINCompanyKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z52ResidentINCompanyName, T00026_A52ResidentINCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z52ResidentINCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T00026_A52ResidentINCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z53ResidentINCompanyEmail, T00026_A53ResidentINCompanyEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINCompanyEmail");
                  GXUtil.WriteLogRaw("Old: ",Z53ResidentINCompanyEmail);
                  GXUtil.WriteLogRaw("Current: ",T00026_A53ResidentINCompanyEmail[0]);
               }
               if ( StringUtil.StrCmp(Z54ResidentINCompanyPhone, T00026_A54ResidentINCompanyPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("resident:[seudo value changed for attri]"+"ResidentINCompanyPhone");
                  GXUtil.WriteLogRaw("Old: ",Z54ResidentINCompanyPhone);
                  GXUtil.WriteLogRaw("Current: ",T00026_A54ResidentINCompanyPhone[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentINCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert027( )
      {
         if ( ! IsAuthorized("resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable027( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM027( 0) ;
            CheckOptimisticConcurrency027( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm027( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert027( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000239 */
                     pr_default.execute(37, new Object[] {A31ResidentId, A50ResidentINCompanyId, A51ResidentINCompanyKvkNumber, A52ResidentINCompanyName, n53ResidentINCompanyEmail, A53ResidentINCompanyEmail, n54ResidentINCompanyPhone, A54ResidentINCompanyPhone});
                     pr_default.close(37);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
                     if ( (pr_default.getStatus(37) == 1) )
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
               Load027( ) ;
            }
            EndLevel027( ) ;
         }
         CloseExtendedTableCursors027( ) ;
      }

      protected void Update027( )
      {
         if ( ! IsAuthorized("resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable027( ) ;
         }
         if ( ( nIsMod_7 != 0 ) || ( nIsDirty_7 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency027( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm027( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate027( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000240 */
                        pr_default.execute(38, new Object[] {A51ResidentINCompanyKvkNumber, A52ResidentINCompanyName, n53ResidentINCompanyEmail, A53ResidentINCompanyEmail, n54ResidentINCompanyPhone, A54ResidentINCompanyPhone, A31ResidentId, A50ResidentINCompanyId});
                        pr_default.close(38);
                        pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
                        if ( (pr_default.getStatus(38) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentINCompany"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate027( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey027( ) ;
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
               EndLevel027( ) ;
            }
         }
         CloseExtendedTableCursors027( ) ;
      }

      protected void DeferredUpdate027( )
      {
      }

      protected void Delete027( )
      {
         if ( ! IsAuthorized("resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate027( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency027( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls027( ) ;
            AfterConfirm027( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete027( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000241 */
                  pr_default.execute(39, new Object[] {A31ResidentId, A50ResidentINCompanyId});
                  pr_default.close(39);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentINCompany");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel027( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls027( )
      {
         standaloneModal027( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel027( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart027( )
      {
         /* Scan By routine */
         /* Using cursor T000242 */
         pr_default.execute(40, new Object[] {A31ResidentId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound7 = 1;
            A50ResidentINCompanyId = T000242_A50ResidentINCompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext027( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound7 = 1;
            A50ResidentINCompanyId = T000242_A50ResidentINCompanyId[0];
         }
      }

      protected void ScanEnd027( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm027( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert027( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate027( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete027( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete027( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate027( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes027( )
      {
         edtResidentINCompanyId_Enabled = 0;
         AssignProp("", false, edtResidentINCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyId_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtResidentINCompanyKvkNumber_Enabled = 0;
         AssignProp("", false, edtResidentINCompanyKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtResidentINCompanyName_Enabled = 0;
         AssignProp("", false, edtResidentINCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyName_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtResidentINCompanyEmail_Enabled = 0;
         AssignProp("", false, edtResidentINCompanyEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtResidentINCompanyPhone_Enabled = 0;
         AssignProp("", false, edtResidentINCompanyPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0), !bGXsfl_101_Refreshing);
      }

      protected void send_integrity_lvl_hashes027( )
      {
      }

      protected void ZM0218( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -32 )
         {
            Z31ResidentId = A31ResidentId;
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

      protected void standaloneNotModal0218( )
      {
      }

      protected void standaloneModal0218( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         }
      }

      protected void Load0218( )
      {
         /* Using cursor T000243 */
         pr_default.execute(41, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound18 = 1;
            A74ProductServiceName = T000243_A74ProductServiceName[0];
            A75ProductServiceDescription = T000243_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = T000243_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = T000243_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A72ProductServiceTypeName = T000243_A72ProductServiceTypeName[0];
            A71ProductServiceTypeId = T000243_A71ProductServiceTypeId[0];
            A77ProductServicePicture = T000243_A77ProductServicePicture[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            ZM0218( -32) ;
         }
         pr_default.close(41);
         OnLoadActions0218( ) ;
      }

      protected void OnLoadActions0218( )
      {
      }

      protected void CheckExtendedTable0218( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0218( ) ;
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A74ProductServiceName = T00024_A74ProductServiceName[0];
         A75ProductServiceDescription = T00024_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T00024_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T00024_A40000ProductServicePicture_GXI[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = T00024_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T00024_A77ProductServicePicture[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         pr_default.close(2);
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "PRODUCTSERVICETYPEID_" + sGXsfl_117_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A72ProductServiceTypeName = T00025_A72ProductServiceTypeName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0218( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0218( )
      {
      }

      protected void gxLoad_33( short A73ProductServiceId )
      {
         /* Using cursor T000244 */
         pr_default.execute(42, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A74ProductServiceName = T000244_A74ProductServiceName[0];
         A75ProductServiceDescription = T000244_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T000244_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T000244_A40000ProductServicePicture_GXI[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = T000244_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T000244_A77ProductServicePicture[0];
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A74ProductServiceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A75ProductServiceDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A77ProductServicePicture)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProductServicePicture_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(42) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(42);
      }

      protected void gxLoad_34( short A71ProductServiceTypeId )
      {
         /* Using cursor T000245 */
         pr_default.execute(43, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            GXCCtl = "PRODUCTSERVICETYPEID_" + sGXsfl_117_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A72ProductServiceTypeName = T000245_A72ProductServiceTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A72ProductServiceTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(43) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(43);
      }

      protected void GetKey0218( )
      {
         /* Using cursor T000246 */
         pr_default.execute(44, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(44);
      }

      protected void getByPrimaryKey0218( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A31ResidentId, A73ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0218( 32) ;
            RcdFound18 = 1;
            InitializeNonKey0218( ) ;
            A73ProductServiceId = T00023_A73ProductServiceId[0];
            Z31ResidentId = A31ResidentId;
            Z73ProductServiceId = A73ProductServiceId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0218( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0218( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0218( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0218( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0218( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A31ResidentId, A73ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResidentProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResidentProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0218( )
      {
         if ( ! IsAuthorized("resident_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0218( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0218( 0) ;
            CheckOptimisticConcurrency0218( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0218( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0218( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000247 */
                     pr_default.execute(45, new Object[] {A31ResidentId, A73ProductServiceId});
                     pr_default.close(45);
                     pr_default.SmartCacheProvider.SetUpdated("ResidentProductService");
                     if ( (pr_default.getStatus(45) == 1) )
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
               Load0218( ) ;
            }
            EndLevel0218( ) ;
         }
         CloseExtendedTableCursors0218( ) ;
      }

      protected void Update0218( )
      {
         if ( ! IsAuthorized("resident_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0218( ) ;
         }
         if ( ( nIsMod_18 != 0 ) || ( nIsDirty_18 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0218( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0218( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0218( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table ResidentProductService */
                        DeferredUpdate0218( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0218( ) ;
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
               EndLevel0218( ) ;
            }
         }
         CloseExtendedTableCursors0218( ) ;
      }

      protected void DeferredUpdate0218( )
      {
      }

      protected void Delete0218( )
      {
         if ( ! IsAuthorized("resident_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0218( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0218( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0218( ) ;
            AfterConfirm0218( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0218( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000248 */
                  pr_default.execute(46, new Object[] {A31ResidentId, A73ProductServiceId});
                  pr_default.close(46);
                  pr_default.SmartCacheProvider.SetUpdated("ResidentProductService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0218( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0218( )
      {
         standaloneModal0218( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000249 */
            pr_default.execute(47, new Object[] {A73ProductServiceId});
            A74ProductServiceName = T000249_A74ProductServiceName[0];
            A75ProductServiceDescription = T000249_A75ProductServiceDescription[0];
            A76ProductServiceQuantity = T000249_A76ProductServiceQuantity[0];
            A40000ProductServicePicture_GXI = T000249_A40000ProductServicePicture_GXI[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            A71ProductServiceTypeId = T000249_A71ProductServiceTypeId[0];
            A77ProductServicePicture = T000249_A77ProductServicePicture[0];
            AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
            AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
            pr_default.close(47);
            /* Using cursor T000250 */
            pr_default.execute(48, new Object[] {A71ProductServiceTypeId});
            A72ProductServiceTypeName = T000250_A72ProductServiceTypeName[0];
            pr_default.close(48);
         }
      }

      protected void EndLevel0218( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0218( )
      {
         /* Scan By routine */
         /* Using cursor T000251 */
         pr_default.execute(49, new Object[] {A31ResidentId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(49) != 101) )
         {
            RcdFound18 = 1;
            A73ProductServiceId = T000251_A73ProductServiceId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0218( )
      {
         /* Scan next routine */
         pr_default.readNext(49);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(49) != 101) )
         {
            RcdFound18 = 1;
            A73ProductServiceId = T000251_A73ProductServiceId[0];
         }
      }

      protected void ScanEnd0218( )
      {
         pr_default.close(49);
      }

      protected void AfterConfirm0218( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0218( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0218( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0218( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0218( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0218( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0218( )
      {
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         edtProductServiceQuantity_Enabled = 0;
         AssignProp("", false, edtProductServiceQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceQuantity_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         edtProductServicePicture_Enabled = 0;
         AssignProp("", false, edtProductServicePicture_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServicePicture_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         edtProductServiceTypeId_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
         edtProductServiceTypeName_Enabled = 0;
         AssignProp("", false, edtProductServiceTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTypeName_Enabled), 5, 0), !bGXsfl_117_Refreshing);
      }

      protected void send_integrity_lvl_hashes0218( )
      {
      }

      protected void send_integrity_lvl_hashes025( )
      {
      }

      protected void SubsflControlProps_826( )
      {
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx;
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx;
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx;
         edtResidentINIndividualLastName_Internalname = "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx;
         edtResidentINIndividualEmail_Internalname = "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx;
         edtResidentINIndividualPhone_Internalname = "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx;
         edtResidentINIndividualAddress_Internalname = "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx;
         cmbResidentINIndividualGender_Internalname = "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx;
      }

      protected void SubsflControlProps_fel_826( )
      {
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualLastName_Internalname = "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualEmail_Internalname = "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualPhone_Internalname = "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_fel_idx;
         edtResidentINIndividualAddress_Internalname = "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_fel_idx;
         cmbResidentINIndividualGender_Internalname = "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_fel_idx;
      }

      protected void AddRow026( )
      {
         nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_826( ) ;
         SendRow026( ) ;
      }

      protected void SendRow026( )
      {
         Gridlevel_inindividualRow = GXWebRow.GetNew(context);
         if ( subGridlevel_inindividual_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_inindividual_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_inindividual_Class, "") != 0 )
            {
               subGridlevel_inindividual_Linesclass = subGridlevel_inindividual_Class+"Odd";
            }
         }
         else if ( subGridlevel_inindividual_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_inindividual_Backstyle = 0;
            subGridlevel_inindividual_Backcolor = subGridlevel_inindividual_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_inindividual_Class, "") != 0 )
            {
               subGridlevel_inindividual_Linesclass = subGridlevel_inindividual_Class+"Uniform";
            }
         }
         else if ( subGridlevel_inindividual_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_inindividual_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_inindividual_Class, "") != 0 )
            {
               subGridlevel_inindividual_Linesclass = subGridlevel_inindividual_Class+"Odd";
            }
            subGridlevel_inindividual_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_inindividual_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_inindividual_Backstyle = 1;
            if ( ((int)((nGXsfl_82_idx) % (2))) == 0 )
            {
               subGridlevel_inindividual_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_inindividual_Class, "") != 0 )
               {
                  subGridlevel_inindividual_Linesclass = subGridlevel_inindividual_Class+"Even";
               }
            }
            else
            {
               subGridlevel_inindividual_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_inindividual_Class, "") != 0 )
               {
                  subGridlevel_inindividual_Linesclass = subGridlevel_inindividual_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A42ResidentINIndividualId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,83);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualBsnNumber_Internalname,(string)A43ResidentINIndividualBsnNumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualBsnNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualBsnNumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"BsnNumber",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualGivenName_Internalname,(string)A44ResidentINIndividualGivenName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualGivenName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualLastName_Internalname,(string)A45ResidentINIndividualLastName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINIndividualLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualLastName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualEmail_Internalname,(string)A46ResidentINIndividualEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A46ResidentINIndividualEmail,(string)"",(string)"",(string)"",(string)edtResidentINIndividualEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A47ResidentINIndividualPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualPhone_Internalname,StringUtil.RTrim( A47ResidentINIndividualPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtResidentINIndividualPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_82_idx + "',82)\"";
         ROClassString = "Attribute";
         Gridlevel_inindividualRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINIndividualAddress_Internalname,(string)A48ResidentINIndividualAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A48ResidentINIndividualAddress),(string)"_blank",(string)"",(string)"",(string)edtResidentINIndividualAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINIndividualAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)82,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_82_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_82_idx + "',82)\"";
         if ( ( cmbResidentINIndividualGender.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "RESIDENTININDIVIDUALGENDER_" + sGXsfl_82_idx;
            cmbResidentINIndividualGender.Name = GXCCtl;
            cmbResidentINIndividualGender.WebTags = "";
            cmbResidentINIndividualGender.addItem("Man", context.GetMessage( "Man", ""), 0);
            cmbResidentINIndividualGender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
            cmbResidentINIndividualGender.addItem("Other", context.GetMessage( "Other", ""), 0);
            if ( cmbResidentINIndividualGender.ItemCount > 0 )
            {
               A49ResidentINIndividualGender = cmbResidentINIndividualGender.getValidValue(A49ResidentINIndividualGender);
            }
         }
         /* ComboBox */
         Gridlevel_inindividualRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbResidentINIndividualGender,(string)cmbResidentINIndividualGender_Internalname,StringUtil.RTrim( A49ResidentINIndividualGender),(short)1,(string)cmbResidentINIndividualGender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbResidentINIndividualGender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"",(bool)true,(short)0});
         cmbResidentINIndividualGender.CurrentValue = StringUtil.RTrim( A49ResidentINIndividualGender);
         AssignProp("", false, cmbResidentINIndividualGender_Internalname, "Values", (string)(cmbResidentINIndividualGender.ToJavascriptSource()), !bGXsfl_82_Refreshing);
         ajax_sending_grid_row(Gridlevel_inindividualRow);
         send_integrity_lvl_hashes026( ) ;
         GXCCtl = "Z42ResidentINIndividualId_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42ResidentINIndividualId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z43ResidentINIndividualBsnNumber_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z43ResidentINIndividualBsnNumber);
         GXCCtl = "Z44ResidentINIndividualGivenName_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z44ResidentINIndividualGivenName);
         GXCCtl = "Z45ResidentINIndividualLastName_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z45ResidentINIndividualLastName);
         GXCCtl = "Z46ResidentINIndividualEmail_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z46ResidentINIndividualEmail);
         GXCCtl = "Z47ResidentINIndividualPhone_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z47ResidentINIndividualPhone));
         GXCCtl = "Z48ResidentINIndividualAddress_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z48ResidentINIndividualAddress);
         GXCCtl = "Z49ResidentINIndividualGender_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z49ResidentINIndividualGender));
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_6_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_6_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_82_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_82_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vRESIDENTID_" + sGXsfl_82_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_inindividualContainer.AddRow(Gridlevel_inindividualRow);
      }

      protected void ReadRow026( )
      {
         nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_826( ) ;
         edtResidentINIndividualId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALID_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualBsnNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALBSNNUMBER_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualGivenName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALGIVENNAME_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualLastName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALLASTNAME_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALEMAIL_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALPHONE_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINIndividualAddress_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALADDRESS_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbResidentINIndividualGender.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTININDIVIDUALGENDER_"+sGXsfl_82_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtResidentINIndividualId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResidentINIndividualId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RESIDENTININDIVIDUALID_" + sGXsfl_82_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtResidentINIndividualId_Internalname;
            wbErr = true;
            A42ResidentINIndividualId = 0;
         }
         else
         {
            A42ResidentINIndividualId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentINIndividualId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A43ResidentINIndividualBsnNumber = cgiGet( edtResidentINIndividualBsnNumber_Internalname);
         A44ResidentINIndividualGivenName = cgiGet( edtResidentINIndividualGivenName_Internalname);
         A45ResidentINIndividualLastName = cgiGet( edtResidentINIndividualLastName_Internalname);
         A46ResidentINIndividualEmail = cgiGet( edtResidentINIndividualEmail_Internalname);
         n46ResidentINIndividualEmail = false;
         n46ResidentINIndividualEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A46ResidentINIndividualEmail)) ? true : false);
         A47ResidentINIndividualPhone = cgiGet( edtResidentINIndividualPhone_Internalname);
         n47ResidentINIndividualPhone = false;
         n47ResidentINIndividualPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A47ResidentINIndividualPhone)) ? true : false);
         A48ResidentINIndividualAddress = cgiGet( edtResidentINIndividualAddress_Internalname);
         n48ResidentINIndividualAddress = false;
         n48ResidentINIndividualAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A48ResidentINIndividualAddress)) ? true : false);
         cmbResidentINIndividualGender.Name = cmbResidentINIndividualGender_Internalname;
         cmbResidentINIndividualGender.CurrentValue = cgiGet( cmbResidentINIndividualGender_Internalname);
         A49ResidentINIndividualGender = cgiGet( cmbResidentINIndividualGender_Internalname);
         GXCCtl = "Z42ResidentINIndividualId_" + sGXsfl_82_idx;
         Z42ResidentINIndividualId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z43ResidentINIndividualBsnNumber_" + sGXsfl_82_idx;
         Z43ResidentINIndividualBsnNumber = cgiGet( GXCCtl);
         GXCCtl = "Z44ResidentINIndividualGivenName_" + sGXsfl_82_idx;
         Z44ResidentINIndividualGivenName = cgiGet( GXCCtl);
         GXCCtl = "Z45ResidentINIndividualLastName_" + sGXsfl_82_idx;
         Z45ResidentINIndividualLastName = cgiGet( GXCCtl);
         GXCCtl = "Z46ResidentINIndividualEmail_" + sGXsfl_82_idx;
         Z46ResidentINIndividualEmail = cgiGet( GXCCtl);
         n46ResidentINIndividualEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A46ResidentINIndividualEmail)) ? true : false);
         GXCCtl = "Z47ResidentINIndividualPhone_" + sGXsfl_82_idx;
         Z47ResidentINIndividualPhone = cgiGet( GXCCtl);
         n47ResidentINIndividualPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A47ResidentINIndividualPhone)) ? true : false);
         GXCCtl = "Z48ResidentINIndividualAddress_" + sGXsfl_82_idx;
         Z48ResidentINIndividualAddress = cgiGet( GXCCtl);
         n48ResidentINIndividualAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A48ResidentINIndividualAddress)) ? true : false);
         GXCCtl = "Z49ResidentINIndividualGender_" + sGXsfl_82_idx;
         Z49ResidentINIndividualGender = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_82_idx;
         nRcdDeleted_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_6_" + sGXsfl_82_idx;
         nRcdExists_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_6_" + sGXsfl_82_idx;
         nIsMod_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_1017( )
      {
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID_"+sGXsfl_101_idx;
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx;
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx;
         edtResidentINCompanyEmail_Internalname = "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx;
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx;
      }

      protected void SubsflControlProps_fel_1017( )
      {
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID_"+sGXsfl_101_fel_idx;
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_fel_idx;
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME_"+sGXsfl_101_fel_idx;
         edtResidentINCompanyEmail_Internalname = "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_fel_idx;
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_fel_idx;
      }

      protected void AddRow027( )
      {
         nGXsfl_101_idx = (int)(nGXsfl_101_idx+1);
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1017( ) ;
         SendRow027( ) ;
      }

      protected void SendRow027( )
      {
         Gridlevel_incompanyRow = GXWebRow.GetNew(context);
         if ( subGridlevel_incompany_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_incompany_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_incompany_Class, "") != 0 )
            {
               subGridlevel_incompany_Linesclass = subGridlevel_incompany_Class+"Odd";
            }
         }
         else if ( subGridlevel_incompany_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_incompany_Backstyle = 0;
            subGridlevel_incompany_Backcolor = subGridlevel_incompany_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_incompany_Class, "") != 0 )
            {
               subGridlevel_incompany_Linesclass = subGridlevel_incompany_Class+"Uniform";
            }
         }
         else if ( subGridlevel_incompany_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_incompany_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_incompany_Class, "") != 0 )
            {
               subGridlevel_incompany_Linesclass = subGridlevel_incompany_Class+"Odd";
            }
            subGridlevel_incompany_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_incompany_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_incompany_Backstyle = 1;
            if ( ((int)((nGXsfl_101_idx) % (2))) == 0 )
            {
               subGridlevel_incompany_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_incompany_Class, "") != 0 )
               {
                  subGridlevel_incompany_Linesclass = subGridlevel_incompany_Class+"Even";
               }
            }
            else
            {
               subGridlevel_incompany_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_incompany_Class, "") != 0 )
               {
                  subGridlevel_incompany_Linesclass = subGridlevel_incompany_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_101_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_101_idx + "',101)\"";
         ROClassString = "Attribute";
         Gridlevel_incompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50ResidentINCompanyId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,102);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINCompanyId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINCompanyId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_101_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_101_idx + "',101)\"";
         ROClassString = "Attribute";
         Gridlevel_incompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyKvkNumber_Internalname,(string)A51ResidentINCompanyKvkNumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINCompanyKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINCompanyKvkNumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_101_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_101_idx + "',101)\"";
         ROClassString = "Attribute";
         Gridlevel_incompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyName_Internalname,(string)A52ResidentINCompanyName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentINCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINCompanyName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_101_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_101_idx + "',101)\"";
         ROClassString = "Attribute";
         Gridlevel_incompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyEmail_Internalname,(string)A53ResidentINCompanyEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A53ResidentINCompanyEmail,(string)"",(string)"",(string)"",(string)edtResidentINCompanyEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINCompanyEmail_Enabled,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A54ResidentINCompanyPhone);
         }
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_7_" + sGXsfl_101_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_101_idx + "',101)\"";
         ROClassString = "Attribute";
         Gridlevel_incompanyRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentINCompanyPhone_Internalname,StringUtil.RTrim( A54ResidentINCompanyPhone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtResidentINCompanyPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtResidentINCompanyPhone_Enabled,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_incompanyRow);
         send_integrity_lvl_hashes027( ) ;
         GXCCtl = "Z50ResidentINCompanyId_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50ResidentINCompanyId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z51ResidentINCompanyKvkNumber_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z51ResidentINCompanyKvkNumber);
         GXCCtl = "Z52ResidentINCompanyName_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z52ResidentINCompanyName);
         GXCCtl = "Z53ResidentINCompanyEmail_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z53ResidentINCompanyEmail);
         GXCCtl = "Z54ResidentINCompanyPhone_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z54ResidentINCompanyPhone));
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_7), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_7_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_7), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_7_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_7), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_101_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_101_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vRESIDENTID_" + sGXsfl_101_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYID_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_incompanyContainer.AddRow(Gridlevel_incompanyRow);
      }

      protected void ReadRow027( )
      {
         nGXsfl_101_idx = (int)(nGXsfl_101_idx+1);
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1017( ) ;
         edtResidentINCompanyId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYID_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINCompanyKvkNumber_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYKVKNUMBER_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINCompanyName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYNAME_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINCompanyEmail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYEMAIL_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtResidentINCompanyPhone_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESIDENTINCOMPANYPHONE_"+sGXsfl_101_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtResidentINCompanyId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResidentINCompanyId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RESIDENTINCOMPANYID_" + sGXsfl_101_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtResidentINCompanyId_Internalname;
            wbErr = true;
            A50ResidentINCompanyId = 0;
         }
         else
         {
            A50ResidentINCompanyId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtResidentINCompanyId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A51ResidentINCompanyKvkNumber = cgiGet( edtResidentINCompanyKvkNumber_Internalname);
         A52ResidentINCompanyName = cgiGet( edtResidentINCompanyName_Internalname);
         A53ResidentINCompanyEmail = cgiGet( edtResidentINCompanyEmail_Internalname);
         n53ResidentINCompanyEmail = false;
         n53ResidentINCompanyEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A53ResidentINCompanyEmail)) ? true : false);
         A54ResidentINCompanyPhone = cgiGet( edtResidentINCompanyPhone_Internalname);
         n54ResidentINCompanyPhone = false;
         n54ResidentINCompanyPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A54ResidentINCompanyPhone)) ? true : false);
         GXCCtl = "Z50ResidentINCompanyId_" + sGXsfl_101_idx;
         Z50ResidentINCompanyId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z51ResidentINCompanyKvkNumber_" + sGXsfl_101_idx;
         Z51ResidentINCompanyKvkNumber = cgiGet( GXCCtl);
         GXCCtl = "Z52ResidentINCompanyName_" + sGXsfl_101_idx;
         Z52ResidentINCompanyName = cgiGet( GXCCtl);
         GXCCtl = "Z53ResidentINCompanyEmail_" + sGXsfl_101_idx;
         Z53ResidentINCompanyEmail = cgiGet( GXCCtl);
         n53ResidentINCompanyEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A53ResidentINCompanyEmail)) ? true : false);
         GXCCtl = "Z54ResidentINCompanyPhone_" + sGXsfl_101_idx;
         Z54ResidentINCompanyPhone = cgiGet( GXCCtl);
         n54ResidentINCompanyPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A54ResidentINCompanyPhone)) ? true : false);
         GXCCtl = "nRcdDeleted_7_" + sGXsfl_101_idx;
         nRcdDeleted_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_7_" + sGXsfl_101_idx;
         nRcdExists_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_7_" + sGXsfl_101_idx;
         nIsMod_7 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_11718( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_117_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx;
      }

      protected void SubsflControlProps_fel_11718( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_117_fel_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_fel_idx;
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_fel_idx;
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE_"+sGXsfl_117_fel_idx;
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID_"+sGXsfl_117_fel_idx;
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME_"+sGXsfl_117_fel_idx;
      }

      protected void AddRow0218( )
      {
         nGXsfl_117_idx = (int)(nGXsfl_117_idx+1);
         sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx), 4, 0), 4, "0");
         SubsflControlProps_11718( ) ;
         SendRow0218( ) ;
      }

      protected void SendRow0218( )
      {
         Gridlevel_productserviceRow = GXWebRow.GetNew(context);
         if ( subGridlevel_productservice_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_productservice_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_productservice_Class, "") != 0 )
            {
               subGridlevel_productservice_Linesclass = subGridlevel_productservice_Class+"Odd";
            }
         }
         else if ( subGridlevel_productservice_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_productservice_Backstyle = 0;
            subGridlevel_productservice_Backcolor = subGridlevel_productservice_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_productservice_Class, "") != 0 )
            {
               subGridlevel_productservice_Linesclass = subGridlevel_productservice_Class+"Uniform";
            }
         }
         else if ( subGridlevel_productservice_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_productservice_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_productservice_Class, "") != 0 )
            {
               subGridlevel_productservice_Linesclass = subGridlevel_productservice_Class+"Odd";
            }
            subGridlevel_productservice_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_productservice_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_productservice_Backstyle = 1;
            if ( ((int)((nGXsfl_117_idx) % (2))) == 0 )
            {
               subGridlevel_productservice_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_productservice_Class, "") != 0 )
               {
                  subGridlevel_productservice_Linesclass = subGridlevel_productservice_Class+"Even";
               }
            }
            else
            {
               subGridlevel_productservice_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_productservice_Class, "") != 0 )
               {
                  subGridlevel_productservice_Linesclass = subGridlevel_productservice_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A73ProductServiceId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,118);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)117,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtProductServiceId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceDescription_Internalname,(string)A75ProductServiceDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)117,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProductServiceQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A76ProductServiceQuantity), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,120);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)117,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ClassString = "Attribute";
         StyleString = "";
         A77ProductServicePicture_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServicePicture_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture));
         Gridlevel_productserviceRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServicePicture_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtProductServicePicture_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"",(string)"",(string)"",(short)0,(bool)A77ProductServicePicture_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         AssignProp("", false, edtProductServicePicture_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.PathToRelativeUrl( A77ProductServicePicture)), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "IsBlob", StringUtil.BoolToStr( A77ProductServicePicture_IsBlob), !bGXsfl_117_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProductServiceTypeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9") : context.localUtil.Format( (decimal)(A71ProductServiceTypeId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,122);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceTypeId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)117,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_117_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_117_idx + "',117)\"";
         ROClassString = "Attribute";
         Gridlevel_productserviceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTypeName_Internalname,(string)A72ProductServiceTypeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProductServiceTypeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)117,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_productserviceRow);
         send_integrity_lvl_hashes0218( ) ;
         GXCCtl = "Z73ProductServiceId_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73ProductServiceId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_18_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_18_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_117_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCHECKREQUIREDFIELDSRESULT_" + sGXsfl_117_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, AV15CheckRequiredFieldsResult);
         GXCCtl = "vRESIDENTID_" + sGXsfl_117_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "PRODUCTSERVICEPICTURE_" + sGXsfl_117_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A77ProductServicePicture);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_productserviceContainer.AddRow(Gridlevel_productserviceRow);
      }

      protected void ReadRow0218( )
      {
         nGXsfl_117_idx = (int)(nGXsfl_117_idx+1);
         sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx), 4, 0), 4, "0");
         SubsflControlProps_11718( ) ;
         edtProductServiceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceId_Horizontalalignment = cgiGet( "PRODUCTSERVICEID_"+sGXsfl_117_idx+"Horizontalalignment");
         edtProductServiceDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEQUANTITY_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServicePicture_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICEPICTURE_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceTypeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPEID_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProductServiceTypeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSERVICETYPENAME_"+sGXsfl_117_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTSERVICEID_" + sGXsfl_117_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            wbErr = true;
            A73ProductServiceId = 0;
         }
         else
         {
            A73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A75ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
         A76ProductServiceQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceQuantity_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A77ProductServicePicture = cgiGet( edtProductServicePicture_Internalname);
         A71ProductServiceTypeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductServiceTypeId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A72ProductServiceTypeName = cgiGet( edtProductServiceTypeName_Internalname);
         GXCCtl = "Z73ProductServiceId_" + sGXsfl_117_idx;
         Z73ProductServiceId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_117_idx;
         nRcdDeleted_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_18_" + sGXsfl_117_idx;
         nRcdExists_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_18_" + sGXsfl_117_idx;
         nIsMod_18 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtProductServicePicture_Internalname, ref  A77ProductServicePicture, ref  A40000ProductServicePicture_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtProductServiceId_Enabled = edtProductServiceId_Enabled;
         defedtResidentINCompanyId_Enabled = edtResidentINCompanyId_Enabled;
         defedtResidentINIndividualId_Enabled = edtResidentINIndividualId_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_82_idx = 0;
         sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
         SubsflControlProps_826( ) ;
         while ( nGXsfl_82_idx < nRC_GXsfl_82 )
         {
            nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_826( ) ;
            ChangePostValue( "Z42ResidentINIndividualId_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z42ResidentINIndividualId_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z42ResidentINIndividualId_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z43ResidentINIndividualBsnNumber_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z43ResidentINIndividualBsnNumber_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z43ResidentINIndividualBsnNumber_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z44ResidentINIndividualGivenName_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z44ResidentINIndividualGivenName_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z44ResidentINIndividualGivenName_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z45ResidentINIndividualLastName_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z45ResidentINIndividualLastName_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z45ResidentINIndividualLastName_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z46ResidentINIndividualEmail_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z46ResidentINIndividualEmail_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z46ResidentINIndividualEmail_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z47ResidentINIndividualPhone_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z47ResidentINIndividualPhone_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z47ResidentINIndividualPhone_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z48ResidentINIndividualAddress_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z48ResidentINIndividualAddress_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z48ResidentINIndividualAddress_"+sGXsfl_82_idx) ;
            ChangePostValue( "Z49ResidentINIndividualGender_"+sGXsfl_82_idx, cgiGet( "ZT_"+"Z49ResidentINIndividualGender_"+sGXsfl_82_idx)) ;
            DeletePostValue( "ZT_"+"Z49ResidentINIndividualGender_"+sGXsfl_82_idx) ;
         }
         nGXsfl_101_idx = 0;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1017( ) ;
         while ( nGXsfl_101_idx < nRC_GXsfl_101 )
         {
            nGXsfl_101_idx = (int)(nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1017( ) ;
            ChangePostValue( "Z50ResidentINCompanyId_"+sGXsfl_101_idx, cgiGet( "ZT_"+"Z50ResidentINCompanyId_"+sGXsfl_101_idx)) ;
            DeletePostValue( "ZT_"+"Z50ResidentINCompanyId_"+sGXsfl_101_idx) ;
            ChangePostValue( "Z51ResidentINCompanyKvkNumber_"+sGXsfl_101_idx, cgiGet( "ZT_"+"Z51ResidentINCompanyKvkNumber_"+sGXsfl_101_idx)) ;
            DeletePostValue( "ZT_"+"Z51ResidentINCompanyKvkNumber_"+sGXsfl_101_idx) ;
            ChangePostValue( "Z52ResidentINCompanyName_"+sGXsfl_101_idx, cgiGet( "ZT_"+"Z52ResidentINCompanyName_"+sGXsfl_101_idx)) ;
            DeletePostValue( "ZT_"+"Z52ResidentINCompanyName_"+sGXsfl_101_idx) ;
            ChangePostValue( "Z53ResidentINCompanyEmail_"+sGXsfl_101_idx, cgiGet( "ZT_"+"Z53ResidentINCompanyEmail_"+sGXsfl_101_idx)) ;
            DeletePostValue( "ZT_"+"Z53ResidentINCompanyEmail_"+sGXsfl_101_idx) ;
            ChangePostValue( "Z54ResidentINCompanyPhone_"+sGXsfl_101_idx, cgiGet( "ZT_"+"Z54ResidentINCompanyPhone_"+sGXsfl_101_idx)) ;
            DeletePostValue( "ZT_"+"Z54ResidentINCompanyPhone_"+sGXsfl_101_idx) ;
         }
         nGXsfl_117_idx = 0;
         sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx), 4, 0), 4, "0");
         SubsflControlProps_11718( ) ;
         while ( nGXsfl_117_idx < nRC_GXsfl_117 )
         {
            nGXsfl_117_idx = (int)(nGXsfl_117_idx+1);
            sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx), 4, 0), 4, "0");
            SubsflControlProps_11718( ) ;
            ChangePostValue( "Z73ProductServiceId_"+sGXsfl_117_idx, cgiGet( "ZT_"+"Z73ProductServiceId_"+sGXsfl_117_idx)) ;
            DeletePostValue( "ZT_"+"Z73ProductServiceId_"+sGXsfl_117_idx) ;
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("resident.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ResidentId,4,0))}, new string[] {"Gx_mode","ResidentId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Resident");
         forbiddenHiddens.Add("ResidentId", context.localUtil.Format( (decimal)(A31ResidentId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ResidentGender", StringUtil.RTrim( context.localUtil.Format( A102ResidentGender, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("resident:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z31ResidentId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z39ResidentGAMGUID", Z39ResidentGAMGUID);
         GxWebStd.gx_hidden_field( context, "Z35ResidentInitials", StringUtil.RTrim( Z35ResidentInitials));
         GxWebStd.gx_hidden_field( context, "Z40ResidentBsnNumber", Z40ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "Z33ResidentGivenName", Z33ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "Z34ResidentLastName", Z34ResidentLastName);
         GxWebStd.gx_hidden_field( context, "Z36ResidentEmail", Z36ResidentEmail);
         GxWebStd.gx_hidden_field( context, "Z102ResidentGender", StringUtil.RTrim( Z102ResidentGender));
         GxWebStd.gx_hidden_field( context, "Z37ResidentAddress", Z37ResidentAddress);
         GxWebStd.gx_hidden_field( context, "Z38ResidentPhone", StringUtil.RTrim( Z38ResidentPhone));
         GxWebStd.gx_hidden_field( context, "Z96ResidentLastLineIndividual", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z96ResidentLastLineIndividual), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z97ResidentLastLineCompany", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z97ResidentLastLineCompany), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z82ResidentTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z82ResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O97ResidentLastLineCompany", StringUtil.LTrim( StringUtil.NToC( (decimal)(O97ResidentLastLineCompany), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O96ResidentLastLineIndividual", StringUtil.LTrim( StringUtil.NToC( (decimal)(O96ResidentLastLineIndividual), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_82", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_82_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_101", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_101_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_117", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_117_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N82ResidentTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A82ResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N1CustomerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESIDENTTYPEID_DATA", AV25ResidentTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESIDENTTYPEID_DATA", AV25ResidentTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSERVICEID_DATA", AV18ProductServiceId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSERVICEID_DATA", AV18ProductServiceId_Data);
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
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV15CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vTABSACTIVEPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TabsActivePage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vRESIDENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResidentId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRESIDENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ResidentId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_RESIDENTTYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ResidentTypeId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Insert_CustomerId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Insert_CustomerLocationId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTGENDER", StringUtil.RTrim( A102ResidentGender));
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTLINEINDIVIDUAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A96ResidentLastLineIndividual), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTLINECOMPANY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A97ResidentLastLineCompany), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A83ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A74ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEPICTURE_GXI", A40000ProductServicePicture_GXI);
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Objectcall", StringUtil.RTrim( Combo_residenttypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Cls", StringUtil.RTrim( Combo_residenttypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_residenttypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_residenttypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_residenttypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Enabled", StringUtil.BoolToStr( Combo_residenttypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Datalistproc", StringUtil.RTrim( Combo_residenttypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_residenttypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RESIDENTTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_residenttypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Objectcall", StringUtil.RTrim( Gxuitabspanel_steps_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_steps_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_steps_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Class", StringUtil.RTrim( Gxuitabspanel_steps_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_STEPS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_steps_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Objectcall", StringUtil.RTrim( Combo_productserviceid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Cls", StringUtil.RTrim( Combo_productserviceid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Gamoauthtoken", StringUtil.RTrim( Combo_productserviceid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_productserviceid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Isgriditem", StringUtil.BoolToStr( Combo_productserviceid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Hasdescription", StringUtil.BoolToStr( Combo_productserviceid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistproc", StringUtil.RTrim( Combo_productserviceid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_productserviceid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Emptyitem", StringUtil.BoolToStr( Combo_productserviceid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "WIZARD_STEPS_Objectcall", StringUtil.RTrim( Wizard_steps_Objectcall));
         GxWebStd.gx_hidden_field( context, "WIZARD_STEPS_Enabled", StringUtil.BoolToStr( Wizard_steps_Enabled));
         GxWebStd.gx_hidden_field( context, "WIZARD_STEPS_Tabsinternalname", StringUtil.RTrim( Wizard_steps_Tabsinternalname));
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
         return formatLink("resident.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ResidentId,4,0))}, new string[] {"Gx_mode","ResidentId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Resident" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Resident", "") ;
      }

      protected void InitializeNonKey025( )
      {
         A82ResidentTypeId = 0;
         AssignAttri("", false, "A82ResidentTypeId", StringUtil.LTrimStr( (decimal)(A82ResidentTypeId), 4, 0));
         A1CustomerId = 0;
         AssignAttri("", false, "A1CustomerId", StringUtil.LTrimStr( (decimal)(A1CustomerId), 4, 0));
         A18CustomerLocationId = 0;
         AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrimStr( (decimal)(A18CustomerLocationId), 4, 0));
         A39ResidentGAMGUID = "";
         AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
         A35ResidentInitials = "";
         n35ResidentInitials = false;
         AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
         n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
         A40ResidentBsnNumber = "";
         AssignAttri("", false, "A40ResidentBsnNumber", A40ResidentBsnNumber);
         A33ResidentGivenName = "";
         AssignAttri("", false, "A33ResidentGivenName", A33ResidentGivenName);
         A34ResidentLastName = "";
         AssignAttri("", false, "A34ResidentLastName", A34ResidentLastName);
         A36ResidentEmail = "";
         AssignAttri("", false, "A36ResidentEmail", A36ResidentEmail);
         A102ResidentGender = "";
         AssignAttri("", false, "A102ResidentGender", A102ResidentGender);
         A37ResidentAddress = "";
         n37ResidentAddress = false;
         AssignAttri("", false, "A37ResidentAddress", A37ResidentAddress);
         n37ResidentAddress = (String.IsNullOrEmpty(StringUtil.RTrim( A37ResidentAddress)) ? true : false);
         A38ResidentPhone = "";
         n38ResidentPhone = false;
         AssignAttri("", false, "A38ResidentPhone", A38ResidentPhone);
         n38ResidentPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A38ResidentPhone)) ? true : false);
         A83ResidentTypeName = "";
         AssignAttri("", false, "A83ResidentTypeName", A83ResidentTypeName);
         A3CustomerName = "";
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         A96ResidentLastLineIndividual = 0;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         A97ResidentLastLineCompany = 0;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         O97ResidentLastLineCompany = A97ResidentLastLineCompany;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
         O96ResidentLastLineIndividual = A96ResidentLastLineIndividual;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
         Z39ResidentGAMGUID = "";
         Z35ResidentInitials = "";
         Z40ResidentBsnNumber = "";
         Z33ResidentGivenName = "";
         Z34ResidentLastName = "";
         Z36ResidentEmail = "";
         Z102ResidentGender = "";
         Z37ResidentAddress = "";
         Z38ResidentPhone = "";
         Z96ResidentLastLineIndividual = 0;
         Z97ResidentLastLineCompany = 0;
         Z82ResidentTypeId = 0;
         Z1CustomerId = 0;
         Z18CustomerLocationId = 0;
      }

      protected void InitAll025( )
      {
         A31ResidentId = 0;
         AssignAttri("", false, "A31ResidentId", StringUtil.LTrimStr( (decimal)(A31ResidentId), 4, 0));
         InitializeNonKey025( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey026( )
      {
         A43ResidentINIndividualBsnNumber = "";
         A44ResidentINIndividualGivenName = "";
         A45ResidentINIndividualLastName = "";
         A46ResidentINIndividualEmail = "";
         n46ResidentINIndividualEmail = false;
         A47ResidentINIndividualPhone = "";
         n47ResidentINIndividualPhone = false;
         A48ResidentINIndividualAddress = "";
         n48ResidentINIndividualAddress = false;
         A49ResidentINIndividualGender = "";
         Z43ResidentINIndividualBsnNumber = "";
         Z44ResidentINIndividualGivenName = "";
         Z45ResidentINIndividualLastName = "";
         Z46ResidentINIndividualEmail = "";
         Z47ResidentINIndividualPhone = "";
         Z48ResidentINIndividualAddress = "";
         Z49ResidentINIndividualGender = "";
      }

      protected void InitAll026( )
      {
         A42ResidentINIndividualId = 0;
         InitializeNonKey026( ) ;
      }

      protected void StandaloneModalInsert026( )
      {
         A96ResidentLastLineIndividual = i96ResidentLastLineIndividual;
         AssignAttri("", false, "A96ResidentLastLineIndividual", StringUtil.LTrimStr( (decimal)(A96ResidentLastLineIndividual), 4, 0));
      }

      protected void InitializeNonKey027( )
      {
         A51ResidentINCompanyKvkNumber = "";
         A52ResidentINCompanyName = "";
         A53ResidentINCompanyEmail = "";
         n53ResidentINCompanyEmail = false;
         A54ResidentINCompanyPhone = "";
         n54ResidentINCompanyPhone = false;
         Z51ResidentINCompanyKvkNumber = "";
         Z52ResidentINCompanyName = "";
         Z53ResidentINCompanyEmail = "";
         Z54ResidentINCompanyPhone = "";
      }

      protected void InitAll027( )
      {
         A50ResidentINCompanyId = 0;
         InitializeNonKey027( ) ;
      }

      protected void StandaloneModalInsert027( )
      {
         A97ResidentLastLineCompany = i97ResidentLastLineCompany;
         AssignAttri("", false, "A97ResidentLastLineCompany", StringUtil.LTrimStr( (decimal)(A97ResidentLastLineCompany), 4, 0));
      }

      protected void InitializeNonKey0218( )
      {
         A74ProductServiceName = "";
         AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
         A75ProductServiceDescription = "";
         A76ProductServiceQuantity = 0;
         A77ProductServicePicture = "";
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A40000ProductServicePicture_GXI = "";
         AssignProp("", false, edtProductServicePicture_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A77ProductServicePicture)) ? A40000ProductServicePicture_GXI : context.convertURL( context.PathToRelativeUrl( A77ProductServicePicture))), !bGXsfl_117_Refreshing);
         AssignProp("", false, edtProductServicePicture_Internalname, "SrcSet", context.GetImageSrcSet( A77ProductServicePicture), true);
         A71ProductServiceTypeId = 0;
         A72ProductServiceTypeName = "";
      }

      protected void InitAll0218( )
      {
         A73ProductServiceId = 0;
         InitializeNonKey0218( ) ;
      }

      protected void StandaloneModalInsert0218( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202491315523811", true, true);
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
         context.AddJavascriptSource("resident.js", "?202491315523814", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties6( )
      {
         edtResidentINIndividualId_Enabled = defedtResidentINIndividualId_Enabled;
         AssignProp("", false, edtResidentINIndividualId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINIndividualId_Enabled), 5, 0), !bGXsfl_82_Refreshing);
      }

      protected void init_level_properties7( )
      {
         edtResidentINCompanyId_Enabled = defedtResidentINCompanyId_Enabled;
         AssignProp("", false, edtResidentINCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResidentINCompanyId_Enabled), 5, 0), !bGXsfl_101_Refreshing);
      }

      protected void init_level_properties18( )
      {
         edtProductServiceId_Enabled = defedtProductServiceId_Enabled;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), !bGXsfl_117_Refreshing);
      }

      protected void StartGridControl82( )
      {
         Gridlevel_inindividualContainer.AddObjectProperty("GridName", "Gridlevel_inindividual");
         Gridlevel_inindividualContainer.AddObjectProperty("Header", subGridlevel_inindividual_Header);
         Gridlevel_inindividualContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_inindividualContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_inindividualContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42ResidentINIndividualId), 4, 0, ".", ""))));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualId_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A43ResidentINIndividualBsnNumber));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualBsnNumber_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A44ResidentINIndividualGivenName));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualGivenName_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A45ResidentINIndividualLastName));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualLastName_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A46ResidentINIndividualEmail));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A47ResidentINIndividualPhone)));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A48ResidentINIndividualAddress));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINIndividualAddress_Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_inindividualColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A49ResidentINIndividualGender)));
         Gridlevel_inindividualColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbResidentINIndividualGender.Enabled), 5, 0, ".", "")));
         Gridlevel_inindividualContainer.AddColumnProperties(Gridlevel_inindividualColumn);
         Gridlevel_inindividualContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Selectedindex), 4, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Allowselection), 1, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Allowhovering), 1, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_inindividualContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_inindividual_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl101( )
      {
         Gridlevel_incompanyContainer.AddObjectProperty("GridName", "Gridlevel_incompany");
         Gridlevel_incompanyContainer.AddObjectProperty("Header", subGridlevel_incompany_Header);
         Gridlevel_incompanyContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_incompanyContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_incompanyContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_incompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_incompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ResidentINCompanyId), 4, 0, ".", ""))));
         Gridlevel_incompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyId_Enabled), 5, 0, ".", "")));
         Gridlevel_incompanyContainer.AddColumnProperties(Gridlevel_incompanyColumn);
         Gridlevel_incompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_incompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A51ResidentINCompanyKvkNumber));
         Gridlevel_incompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyKvkNumber_Enabled), 5, 0, ".", "")));
         Gridlevel_incompanyContainer.AddColumnProperties(Gridlevel_incompanyColumn);
         Gridlevel_incompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_incompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52ResidentINCompanyName));
         Gridlevel_incompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyName_Enabled), 5, 0, ".", "")));
         Gridlevel_incompanyContainer.AddColumnProperties(Gridlevel_incompanyColumn);
         Gridlevel_incompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_incompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A53ResidentINCompanyEmail));
         Gridlevel_incompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyEmail_Enabled), 5, 0, ".", "")));
         Gridlevel_incompanyContainer.AddColumnProperties(Gridlevel_incompanyColumn);
         Gridlevel_incompanyColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_incompanyColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A54ResidentINCompanyPhone)));
         Gridlevel_incompanyColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtResidentINCompanyPhone_Enabled), 5, 0, ".", "")));
         Gridlevel_incompanyContainer.AddColumnProperties(Gridlevel_incompanyColumn);
         Gridlevel_incompanyContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Selectedindex), 4, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Allowselection), 1, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Allowhovering), 1, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_incompanyContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_incompany_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl117( )
      {
         Gridlevel_productserviceContainer.AddObjectProperty("GridName", "Gridlevel_productservice");
         Gridlevel_productserviceContainer.AddObjectProperty("Header", subGridlevel_productservice_Header);
         Gridlevel_productserviceContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_productserviceContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_productserviceContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A73ProductServiceId), 4, 0, ".", ""))));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceId_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtProductServiceId_Horizontalalignment));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A75ProductServiceDescription));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceDescription_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", ""))));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceQuantity_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", context.convertURL( A77ProductServicePicture));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServicePicture_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", ""))));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeId_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_productserviceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A72ProductServiceTypeName));
         Gridlevel_productserviceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductServiceTypeName_Enabled), 5, 0, ".", "")));
         Gridlevel_productserviceContainer.AddColumnProperties(Gridlevel_productserviceColumn);
         Gridlevel_productserviceContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Selectedindex), 4, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Allowselection), 1, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Allowhovering), 1, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_productserviceContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_productservice_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         lblTextblockresidenttypeid_Internalname = "TEXTBLOCKRESIDENTTYPEID";
         Combo_residenttypeid_Internalname = "COMBO_RESIDENTTYPEID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         divTablesplittedresidenttypeid_Internalname = "TABLESPLITTEDRESIDENTTYPEID";
         dynCustomerLocationId_Internalname = "CUSTOMERLOCATIONID";
         edtResidentGAMGUID_Internalname = "RESIDENTGAMGUID";
         edtResidentAddress_Internalname = "RESIDENTADDRESS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_inindividual_title_Internalname = "TABLEVEL_ININDIVIDUAL_TITLE";
         edtResidentINIndividualId_Internalname = "RESIDENTININDIVIDUALID";
         edtResidentINIndividualBsnNumber_Internalname = "RESIDENTININDIVIDUALBSNNUMBER";
         edtResidentINIndividualGivenName_Internalname = "RESIDENTININDIVIDUALGIVENNAME";
         edtResidentINIndividualLastName_Internalname = "RESIDENTININDIVIDUALLASTNAME";
         edtResidentINIndividualEmail_Internalname = "RESIDENTININDIVIDUALEMAIL";
         edtResidentINIndividualPhone_Internalname = "RESIDENTININDIVIDUALPHONE";
         edtResidentINIndividualAddress_Internalname = "RESIDENTININDIVIDUALADDRESS";
         cmbResidentINIndividualGender_Internalname = "RESIDENTININDIVIDUALGENDER";
         divTableleaflevel_inindividual_Internalname = "TABLELEAFLEVEL_ININDIVIDUAL";
         divTabtablelevel_inindividual_Internalname = "TABTABLELEVEL_ININDIVIDUAL";
         lblTablevel_incompany_title_Internalname = "TABLEVEL_INCOMPANY_TITLE";
         edtResidentINCompanyId_Internalname = "RESIDENTINCOMPANYID";
         edtResidentINCompanyKvkNumber_Internalname = "RESIDENTINCOMPANYKVKNUMBER";
         edtResidentINCompanyName_Internalname = "RESIDENTINCOMPANYNAME";
         edtResidentINCompanyEmail_Internalname = "RESIDENTINCOMPANYEMAIL";
         edtResidentINCompanyPhone_Internalname = "RESIDENTINCOMPANYPHONE";
         divTableleaflevel_incompany_Internalname = "TABLELEAFLEVEL_INCOMPANY";
         divTabtablelevel_incompany_Internalname = "TABTABLELEVEL_INCOMPANY";
         lblTablevel_productservice_title_Internalname = "TABLEVEL_PRODUCTSERVICE_TITLE";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         edtProductServiceQuantity_Internalname = "PRODUCTSERVICEQUANTITY";
         edtProductServicePicture_Internalname = "PRODUCTSERVICEPICTURE";
         edtProductServiceTypeId_Internalname = "PRODUCTSERVICETYPEID";
         edtProductServiceTypeName_Internalname = "PRODUCTSERVICETYPENAME";
         divTableleaflevel_productservice_Internalname = "TABLELEAFLEVEL_PRODUCTSERVICE";
         divTabtablelevel_productservice_Internalname = "TABTABLELEVEL_PRODUCTSERVICE";
         Gxuitabspanel_steps_Internalname = "GXUITABSPANEL_STEPS";
         bttBtnwizardprevious_Internalname = "BTNWIZARDPREVIOUS";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtnwizardnext_Internalname = "BTNWIZARDNEXT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboresidenttypeid_Internalname = "vCOMBORESIDENTTYPEID";
         divSectionattribute_residenttypeid_Internalname = "SECTIONATTRIBUTE_RESIDENTTYPEID";
         Combo_productserviceid_Internalname = "COMBO_PRODUCTSERVICEID";
         edtResidentId_Internalname = "RESIDENTID";
         edtCustomerId_Internalname = "CUSTOMERID";
         edtCustomerName_Internalname = "CUSTOMERNAME";
         Wizard_steps_Internalname = "WIZARD_STEPS";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_inindividual_Internalname = "GRIDLEVEL_ININDIVIDUAL";
         subGridlevel_incompany_Internalname = "GRIDLEVEL_INCOMPANY";
         subGridlevel_productservice_Internalname = "GRIDLEVEL_PRODUCTSERVICE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_productservice_Allowcollapsing = 0;
         subGridlevel_productservice_Allowselection = 0;
         subGridlevel_productservice_Header = "";
         subGridlevel_incompany_Allowcollapsing = 0;
         subGridlevel_incompany_Allowselection = 0;
         subGridlevel_incompany_Header = "";
         subGridlevel_inindividual_Allowcollapsing = 0;
         subGridlevel_inindividual_Allowselection = 0;
         subGridlevel_inindividual_Header = "";
         Combo_productserviceid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Resident", "");
         edtProductServiceTypeName_Jsonclick = "";
         edtProductServiceTypeId_Jsonclick = "";
         edtProductServiceQuantity_Jsonclick = "";
         edtProductServiceDescription_Jsonclick = "";
         edtProductServiceId_Jsonclick = "";
         subGridlevel_productservice_Class = "WorkWith";
         subGridlevel_productservice_Backcolorstyle = 0;
         edtResidentINCompanyPhone_Jsonclick = "";
         edtResidentINCompanyEmail_Jsonclick = "";
         edtResidentINCompanyName_Jsonclick = "";
         edtResidentINCompanyKvkNumber_Jsonclick = "";
         edtResidentINCompanyId_Jsonclick = "";
         subGridlevel_incompany_Class = "WorkWith";
         subGridlevel_incompany_Backcolorstyle = 0;
         cmbResidentINIndividualGender_Jsonclick = "";
         edtResidentINIndividualAddress_Jsonclick = "";
         edtResidentINIndividualPhone_Jsonclick = "";
         edtResidentINIndividualEmail_Jsonclick = "";
         edtResidentINIndividualLastName_Jsonclick = "";
         edtResidentINIndividualGivenName_Jsonclick = "";
         edtResidentINIndividualBsnNumber_Jsonclick = "";
         edtResidentINIndividualId_Jsonclick = "";
         subGridlevel_inindividual_Class = "WorkWith";
         subGridlevel_inindividual_Backcolorstyle = 0;
         Combo_productserviceid_Titlecontrolidtoreplace = "";
         Wizard_steps_Tabsinternalname = "";
         edtProductServiceTypeName_Enabled = 0;
         edtProductServiceTypeId_Enabled = 0;
         edtProductServicePicture_Enabled = 0;
         edtProductServiceQuantity_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceId_Enabled = 1;
         edtResidentINCompanyPhone_Enabled = 1;
         edtResidentINCompanyEmail_Enabled = 1;
         edtResidentINCompanyName_Enabled = 1;
         edtResidentINCompanyKvkNumber_Enabled = 1;
         edtResidentINCompanyId_Enabled = 1;
         cmbResidentINIndividualGender.Enabled = 1;
         edtResidentINIndividualAddress_Enabled = 1;
         edtResidentINIndividualPhone_Enabled = 1;
         edtResidentINIndividualEmail_Enabled = 1;
         edtResidentINIndividualLastName_Enabled = 1;
         edtResidentINIndividualGivenName_Enabled = 1;
         edtResidentINIndividualBsnNumber_Enabled = 1;
         edtResidentINIndividualId_Enabled = 1;
         edtCustomerName_Jsonclick = "";
         edtCustomerName_Enabled = 0;
         edtCustomerName_Visible = 1;
         edtCustomerId_Jsonclick = "";
         edtCustomerId_Enabled = 1;
         edtCustomerId_Visible = 1;
         edtResidentId_Jsonclick = "";
         edtResidentId_Enabled = 0;
         edtResidentId_Visible = 1;
         Combo_productserviceid_Emptyitem = Convert.ToBoolean( 0);
         Combo_productserviceid_Datalistprocparametersprefix = " \"ComboName\": \"ProductServiceId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": 0";
         Combo_productserviceid_Datalistproc = "ResidentLoadDVCombo";
         Combo_productserviceid_Hasdescription = Convert.ToBoolean( -1);
         Combo_productserviceid_Isgriditem = Convert.ToBoolean( -1);
         Combo_productserviceid_Cls = "ExtendedCombo";
         Combo_productserviceid_Caption = "";
         edtavComboresidenttypeid_Jsonclick = "";
         edtavComboresidenttypeid_Enabled = 0;
         edtavComboresidenttypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         bttBtnwizardnext_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtnwizardprevious_Visible = 1;
         edtResidentAddress_Enabled = 1;
         edtResidentGAMGUID_Jsonclick = "";
         edtResidentGAMGUID_Enabled = 1;
         dynCustomerLocationId_Jsonclick = "";
         dynCustomerLocationId.Enabled = 1;
         edtResidentTypeId_Jsonclick = "";
         edtResidentTypeId_Enabled = 1;
         edtResidentTypeId_Visible = 1;
         Combo_residenttypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_residenttypeid_Datalistprocparametersprefix = " \"ComboName\": \"ResidentTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ResidentId\": 0";
         Combo_residenttypeid_Datalistproc = "ResidentLoadDVCombo";
         Combo_residenttypeid_Cls = "ExtendedCombo Attribute";
         Combo_residenttypeid_Caption = "";
         Combo_residenttypeid_Enabled = Convert.ToBoolean( -1);
         edtResidentPhone_Jsonclick = "";
         edtResidentPhone_Enabled = 1;
         edtResidentEmail_Jsonclick = "";
         edtResidentEmail_Enabled = 1;
         edtResidentInitials_Jsonclick = "";
         edtResidentInitials_Enabled = 1;
         edtResidentLastName_Jsonclick = "";
         edtResidentLastName_Enabled = 1;
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Enabled = 1;
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentBsnNumber_Enabled = 1;
         Gxuitabspanel_steps_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_steps_Class = "Tab";
         Gxuitabspanel_steps_Pagecount = 4;
         divLayoutmaintable_Class = "Table";
         edtProductServiceId_Horizontalalignment = "end";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
         /* End function dynload_actions */
      }

      protected void GXDLACUSTOMERLOCATIONID025( short A1CustomerId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACUSTOMERLOCATIONID_data025( A1CustomerId) ;
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

      protected void GXACUSTOMERLOCATIONID_html025( short A1CustomerId )
      {
         short gxdynajaxvalue;
         GXDLACUSTOMERLOCATIONID_data025( A1CustomerId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCustomerLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynCustomerLocationId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLACUSTOMERLOCATIONID_data025( short A1CustomerId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000252 */
         pr_default.execute(50, new Object[] {A1CustomerId});
         while ( (pr_default.getStatus(50) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000252_A18CustomerLocationId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000252_A134CustomerLocationName[0]);
            pr_default.readNext(50);
         }
         pr_default.close(50);
      }

      protected void XC_16_025( string A36ResidentEmail ,
                                string A33ResidentGivenName ,
                                string A34ResidentLastName )
      {
         new createuseraccount(context ).execute(  A36ResidentEmail,  A33ResidentGivenName,  A34ResidentLastName,  "Resident", out  A39ResidentGAMGUID) ;
         AssignAttri("", false, "A39ResidentGAMGUID", A39ResidentGAMGUID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A39ResidentGAMGUID)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_17_025( string A33ResidentGivenName ,
                                string A34ResidentLastName )
      {
         new getnameinitials(context ).execute(  A33ResidentGivenName,  A34ResidentLastName, out  A35ResidentInitials) ;
         AssignAttri("", false, "A35ResidentInitials", A35ResidentInitials);
         n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A35ResidentInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_inindividual_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_826( ) ;
         while ( nGXsfl_82_idx <= nRC_GXsfl_82 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal026( ) ;
            standaloneModal026( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow026( ) ;
            nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
            sGXsfl_82_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_82_idx), 4, 0), 4, "0");
            SubsflControlProps_826( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_inindividualContainer)) ;
         /* End function gxnrGridlevel_inindividual_newrow */
      }

      protected void gxnrGridlevel_incompany_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1017( ) ;
         while ( nGXsfl_101_idx <= nRC_GXsfl_101 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal027( ) ;
            standaloneModal027( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow027( ) ;
            nGXsfl_101_idx = (int)(nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1017( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_incompanyContainer)) ;
         /* End function gxnrGridlevel_incompany_newrow */
      }

      protected void gxnrGridlevel_productservice_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_11718( ) ;
         while ( nGXsfl_117_idx <= nRC_GXsfl_117 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0218( ) ;
            standaloneModal0218( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0218( ) ;
            nGXsfl_117_idx = (int)(nGXsfl_117_idx+1);
            sGXsfl_117_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_117_idx), 4, 0), 4, "0");
            SubsflControlProps_11718( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_productserviceContainer)) ;
         /* End function gxnrGridlevel_productservice_newrow */
      }

      protected void init_web_controls( )
      {
         dynCustomerLocationId.Name = "CUSTOMERLOCATIONID";
         dynCustomerLocationId.WebTags = "";
         GXCCtl = "RESIDENTININDIVIDUALGENDER_" + sGXsfl_82_idx;
         cmbResidentINIndividualGender.Name = GXCCtl;
         cmbResidentINIndividualGender.WebTags = "";
         cmbResidentINIndividualGender.addItem("Man", context.GetMessage( "Man", ""), 0);
         cmbResidentINIndividualGender.addItem("Woman", context.GetMessage( "Woman", ""), 0);
         cmbResidentINIndividualGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbResidentINIndividualGender.ItemCount > 0 )
         {
            A49ResidentINIndividualGender = cmbResidentINIndividualGender.getValidValue(A49ResidentINIndividualGender);
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

      public void Valid_Residentbsnnumber( )
      {
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000253 */
         pr_default.execute(51, new Object[] {A40ResidentBsnNumber, A31ResidentId});
         if ( (pr_default.getStatus(51) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Resident Bsn Number", "")}), 1, "RESIDENTBSNNUMBER");
            AnyError = 1;
            GX_FocusControl = edtResidentBsnNumber_Internalname;
         }
         pr_default.close(51);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Residentlastname( )
      {
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n35ResidentInitials = false;
         new getnameinitials(context ).execute(  A33ResidentGivenName,  A34ResidentLastName, out  A35ResidentInitials) ;
         n35ResidentInitials = (String.IsNullOrEmpty(StringUtil.RTrim( A35ResidentInitials)) ? true : false);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A35ResidentInitials", StringUtil.RTrim( A35ResidentInitials));
      }

      public void Valid_Residenttypeid( )
      {
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000254 */
         pr_default.execute(52, new Object[] {A82ResidentTypeId});
         if ( (pr_default.getStatus(52) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RESIDENTTYPEID");
            AnyError = 1;
            GX_FocusControl = edtResidentTypeId_Internalname;
         }
         A83ResidentTypeName = T000254_A83ResidentTypeName[0];
         pr_default.close(52);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A83ResidentTypeName", A83ResidentTypeName);
      }

      public void Valid_Customerid( )
      {
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000255 */
         pr_default.execute(53, new Object[] {A1CustomerId});
         if ( (pr_default.getStatus(53) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Customer", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         A3CustomerName = T000255_A3CustomerName[0];
         pr_default.close(53);
         /* Using cursor T000256 */
         pr_default.execute(54, new Object[] {A1CustomerId, A18CustomerLocationId});
         if ( (pr_default.getStatus(54) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CustomerLocation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CUSTOMERLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCustomerId_Internalname;
         }
         pr_default.close(54);
         GXACUSTOMERLOCATIONID_html025( A1CustomerId) ;
         dynload_actions( ) ;
         if ( dynCustomerLocationId.ItemCount > 0 )
         {
            A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCustomerLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A3CustomerName", A3CustomerName);
         AssignAttri("", false, "A18CustomerLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18CustomerLocationId), 4, 0, ".", "")));
         dynCustomerLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A18CustomerLocationId), 4, 0));
         AssignProp("", false, dynCustomerLocationId_Internalname, "Values", dynCustomerLocationId.ToJavascriptSource(), true);
      }

      public void Valid_Productserviceid( )
      {
         A18CustomerLocationId = (short)(Math.Round(NumberUtil.Val( dynCustomerLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000249 */
         pr_default.execute(47, new Object[] {A73ProductServiceId});
         if ( (pr_default.getStatus(47) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
         }
         A74ProductServiceName = T000249_A74ProductServiceName[0];
         A75ProductServiceDescription = T000249_A75ProductServiceDescription[0];
         A76ProductServiceQuantity = T000249_A76ProductServiceQuantity[0];
         A40000ProductServicePicture_GXI = T000249_A40000ProductServicePicture_GXI[0];
         A71ProductServiceTypeId = T000249_A71ProductServiceTypeId[0];
         A77ProductServicePicture = T000249_A77ProductServicePicture[0];
         pr_default.close(47);
         /* Using cursor T000250 */
         pr_default.execute(48, new Object[] {A71ProductServiceTypeId});
         if ( (pr_default.getStatus(48) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Product Service Type", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PRODUCTSERVICETYPEID");
            AnyError = 1;
         }
         A72ProductServiceTypeName = T000250_A72ProductServiceTypeName[0];
         pr_default.close(48);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A74ProductServiceName", A74ProductServiceName);
         AssignAttri("", false, "A75ProductServiceDescription", A75ProductServiceDescription);
         AssignAttri("", false, "A76ProductServiceQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A76ProductServiceQuantity), 4, 0, ".", "")));
         AssignAttri("", false, "A77ProductServicePicture", context.PathToRelativeUrl( A77ProductServicePicture));
         GXCCtl = "PRODUCTSERVICEPICTURE_" + sGXsfl_117_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A77ProductServicePicture));
         AssignAttri("", false, "A40000ProductServicePicture_GXI", A40000ProductServicePicture_GXI);
         AssignAttri("", false, "A71ProductServiceTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A71ProductServiceTypeId), 4, 0, ".", "")));
         AssignAttri("", false, "A72ProductServiceTypeName", A72ProductServiceTypeName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ResidentId","fld":"vRESIDENTID","pic":"ZZZ9","hsh":true},{"av":"A31ResidentId","fld":"RESIDENTID","pic":"ZZZ9"},{"av":"A102ResidentGender","fld":"RESIDENTGENDER"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E14022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"A36ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("'WIZARDNEXT'","""{"handler":"E12025","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"},{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]""");
         setEventMetadata("'WIZARDNEXT'",""","oparms":[{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E11025","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"}]}""");
         setEventMetadata("VALID_RESIDENTBSNNUMBER","""{"handler":"Valid_Residentbsnnumber","iparms":[{"av":"A40ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A31ResidentId","fld":"RESIDENTID","pic":"ZZZ9"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_RESIDENTGIVENNAME","""{"handler":"Valid_Residentgivenname","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTLASTNAME","""{"handler":"Valid_Residentlastname","iparms":[{"av":"A33ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A34ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"A35ResidentInitials","fld":"RESIDENTINITIALS"}]""");
         setEventMetadata("VALID_RESIDENTLASTNAME",""","oparms":[{"av":"A35ResidentInitials","fld":"RESIDENTINITIALS"}]}""");
         setEventMetadata("VALID_RESIDENTEMAIL","""{"handler":"Valid_Residentemail","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTTYPEID","""{"handler":"Valid_Residenttypeid","iparms":[{"av":"A82ResidentTypeId","fld":"RESIDENTTYPEID","pic":"ZZZ9"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"A83ResidentTypeName","fld":"RESIDENTTYPENAME"}]""");
         setEventMetadata("VALID_RESIDENTTYPEID",""","oparms":[{"av":"A83ResidentTypeName","fld":"RESIDENTTYPENAME"}]}""");
         setEventMetadata("VALID_CUSTOMERLOCATIONID","""{"handler":"Valid_Customerlocationid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBORESIDENTTYPEID","""{"handler":"Validv_Comboresidenttypeid","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTID","""{"handler":"Valid_Residentid","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"A3CustomerName","fld":"CUSTOMERNAME"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A3CustomerName","fld":"CUSTOMERNAME"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_RESIDENTININDIVIDUALID","""{"handler":"Valid_Residentinindividualid","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTININDIVIDUALEMAIL","""{"handler":"Valid_Residentinindividualemail","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTININDIVIDUALGENDER","""{"handler":"Valid_Residentinindividualgender","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTINCOMPANYID","""{"handler":"Valid_Residentincompanyid","iparms":[]}""");
         setEventMetadata("VALID_RESIDENTINCOMPANYEMAIL","""{"handler":"Valid_Residentincompanyemail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Residentincompanyphone","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"A73ProductServiceId","fld":"PRODUCTSERVICEID","pic":"ZZZ9"},{"av":"A71ProductServiceTypeId","fld":"PRODUCTSERVICETYPEID","pic":"ZZZ9"},{"av":"A1CustomerId","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"dynCustomerLocationId"},{"av":"A18CustomerLocationId","fld":"CUSTOMERLOCATIONID","pic":"ZZZ9"},{"av":"A74ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A76ProductServiceQuantity","fld":"PRODUCTSERVICEQUANTITY","pic":"ZZZ9"},{"av":"A77ProductServicePicture","fld":"PRODUCTSERVICEPICTURE"},{"av":"A40000ProductServicePicture_GXI","fld":"PRODUCTSERVICEPICTURE_GXI"},{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEID",""","oparms":[{"av":"A74ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A75ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A76ProductServiceQuantity","fld":"PRODUCTSERVICEQUANTITY","pic":"ZZZ9"},{"av":"A77ProductServicePicture","fld":"PRODUCTSERVICEPICTURE"},{"av":"A40000ProductServicePicture_GXI","fld":"PRODUCTSERVICEPICTURE_GXI"},{"av":"A71ProductServiceTypeId","fld":"PRODUCTSERVICETYPEID","pic":"ZZZ9"},{"av":"A72ProductServiceTypeName","fld":"PRODUCTSERVICETYPENAME"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICETYPEID","""{"handler":"Valid_Productservicetypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Productservicetypename","iparms":[]}""");
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
         pr_default.close(47);
         pr_default.close(48);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(52);
         pr_default.close(25);
         pr_default.close(53);
         pr_default.close(26);
         pr_default.close(54);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z39ResidentGAMGUID = "";
         Z35ResidentInitials = "";
         Z40ResidentBsnNumber = "";
         Z33ResidentGivenName = "";
         Z34ResidentLastName = "";
         Z36ResidentEmail = "";
         Z102ResidentGender = "";
         Z37ResidentAddress = "";
         Z38ResidentPhone = "";
         Combo_residenttypeid_Selectedvalue_get = "";
         Z43ResidentINIndividualBsnNumber = "";
         Z44ResidentINIndividualGivenName = "";
         Z45ResidentINIndividualLastName = "";
         Z46ResidentINIndividualEmail = "";
         Z47ResidentINIndividualPhone = "";
         Z48ResidentINIndividualAddress = "";
         Z49ResidentINIndividualGender = "";
         Z51ResidentINCompanyKvkNumber = "";
         Z52ResidentINCompanyName = "";
         Z53ResidentINCompanyEmail = "";
         Z54ResidentINCompanyPhone = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A36ResidentEmail = "";
         A33ResidentGivenName = "";
         A34ResidentLastName = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_steps = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         A40ResidentBsnNumber = "";
         A35ResidentInitials = "";
         gxphoneLink = "";
         A38ResidentPhone = "";
         lblTextblockresidenttypeid_Jsonclick = "";
         ucCombo_residenttypeid = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV25ResidentTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A39ResidentGAMGUID = "";
         A37ResidentAddress = "";
         lblTablevel_inindividual_title_Jsonclick = "";
         lblTablevel_incompany_title_Jsonclick = "";
         lblTablevel_productservice_title_Jsonclick = "";
         bttBtnwizardprevious_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_productserviceid = new GXUserControl();
         AV18ProductServiceId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A3CustomerName = "";
         ucWizard_steps = new GXUserControl();
         Gridlevel_inindividualContainer = new GXWebGrid( context);
         sMode6 = "";
         sStyleString = "";
         Gridlevel_incompanyContainer = new GXWebGrid( context);
         sMode7 = "";
         Gridlevel_productserviceContainer = new GXWebGrid( context);
         sMode18 = "";
         A102ResidentGender = "";
         A83ResidentTypeName = "";
         AV35Pgmname = "";
         A74ProductServiceName = "";
         A40000ProductServicePicture_GXI = "";
         Combo_residenttypeid_Objectcall = "";
         Combo_residenttypeid_Class = "";
         Combo_residenttypeid_Icontype = "";
         Combo_residenttypeid_Icon = "";
         Combo_residenttypeid_Tooltip = "";
         Combo_residenttypeid_Selectedvalue_set = "";
         Combo_residenttypeid_Selectedtext_set = "";
         Combo_residenttypeid_Selectedtext_get = "";
         Combo_residenttypeid_Gamoauthtoken = "";
         Combo_residenttypeid_Ddointernalname = "";
         Combo_residenttypeid_Titlecontrolalign = "";
         Combo_residenttypeid_Dropdownoptionstype = "";
         Combo_residenttypeid_Titlecontrolidtoreplace = "";
         Combo_residenttypeid_Datalisttype = "";
         Combo_residenttypeid_Datalistfixedvalues = "";
         Combo_residenttypeid_Remoteservicesparameters = "";
         Combo_residenttypeid_Htmltemplate = "";
         Combo_residenttypeid_Multiplevaluestype = "";
         Combo_residenttypeid_Loadingdata = "";
         Combo_residenttypeid_Noresultsfound = "";
         Combo_residenttypeid_Emptyitemtext = "";
         Combo_residenttypeid_Onlyselectedvalues = "";
         Combo_residenttypeid_Selectalltext = "";
         Combo_residenttypeid_Multiplevaluesseparator = "";
         Combo_residenttypeid_Addnewoptiontext = "";
         Gxuitabspanel_steps_Objectcall = "";
         Gxuitabspanel_steps_Activepagecontrolname = "";
         Combo_productserviceid_Objectcall = "";
         Combo_productserviceid_Class = "";
         Combo_productserviceid_Icontype = "";
         Combo_productserviceid_Icon = "";
         Combo_productserviceid_Tooltip = "";
         Combo_productserviceid_Selectedvalue_set = "";
         Combo_productserviceid_Selectedvalue_get = "";
         Combo_productserviceid_Selectedtext_set = "";
         Combo_productserviceid_Selectedtext_get = "";
         Combo_productserviceid_Gamoauthtoken = "";
         Combo_productserviceid_Ddointernalname = "";
         Combo_productserviceid_Titlecontrolalign = "";
         Combo_productserviceid_Dropdownoptionstype = "";
         Combo_productserviceid_Datalisttype = "";
         Combo_productserviceid_Datalistfixedvalues = "";
         Combo_productserviceid_Remoteservicesparameters = "";
         Combo_productserviceid_Htmltemplate = "";
         Combo_productserviceid_Multiplevaluestype = "";
         Combo_productserviceid_Loadingdata = "";
         Combo_productserviceid_Noresultsfound = "";
         Combo_productserviceid_Emptyitemtext = "";
         Combo_productserviceid_Onlyselectedvalues = "";
         Combo_productserviceid_Selectalltext = "";
         Combo_productserviceid_Multiplevaluesseparator = "";
         Combo_productserviceid_Addnewoptiontext = "";
         Wizard_steps_Objectcall = "";
         Wizard_steps_Class = "";
         Wizard_steps_Allowsteptitleclick = "";
         Wizard_steps_Transformtype = "";
         Wizard_steps_Wizardarrowselectedunselectedimage = "";
         Wizard_steps_Wizardarrowunselectedselectedimage = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A75ProductServiceDescription = "";
         A77ProductServicePicture = "";
         A72ProductServiceTypeName = "";
         A51ResidentINCompanyKvkNumber = "";
         A52ResidentINCompanyName = "";
         A53ResidentINCompanyEmail = "";
         A54ResidentINCompanyPhone = "";
         A43ResidentINIndividualBsnNumber = "";
         A44ResidentINIndividualGivenName = "";
         A45ResidentINIndividualLastName = "";
         A46ResidentINIndividualEmail = "";
         A47ResidentINIndividualPhone = "";
         A48ResidentINIndividualAddress = "";
         A49ResidentINIndividualGender = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV24GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         GXt_char2 = "";
         Z83ResidentTypeName = "";
         Z3CustomerName = "";
         T000213_A3CustomerName = new string[] {""} ;
         T000212_A83ResidentTypeName = new string[] {""} ;
         T000215_A31ResidentId = new short[1] ;
         T000215_A39ResidentGAMGUID = new string[] {""} ;
         T000215_A35ResidentInitials = new string[] {""} ;
         T000215_n35ResidentInitials = new bool[] {false} ;
         T000215_A40ResidentBsnNumber = new string[] {""} ;
         T000215_A33ResidentGivenName = new string[] {""} ;
         T000215_A34ResidentLastName = new string[] {""} ;
         T000215_A36ResidentEmail = new string[] {""} ;
         T000215_A102ResidentGender = new string[] {""} ;
         T000215_A37ResidentAddress = new string[] {""} ;
         T000215_n37ResidentAddress = new bool[] {false} ;
         T000215_A38ResidentPhone = new string[] {""} ;
         T000215_n38ResidentPhone = new bool[] {false} ;
         T000215_A83ResidentTypeName = new string[] {""} ;
         T000215_A3CustomerName = new string[] {""} ;
         T000215_A96ResidentLastLineIndividual = new short[1] ;
         T000215_A97ResidentLastLineCompany = new short[1] ;
         T000215_A82ResidentTypeId = new short[1] ;
         T000215_A1CustomerId = new short[1] ;
         T000215_A18CustomerLocationId = new short[1] ;
         T000216_A40ResidentBsnNumber = new string[] {""} ;
         T000214_A1CustomerId = new short[1] ;
         T000217_A83ResidentTypeName = new string[] {""} ;
         T000218_A3CustomerName = new string[] {""} ;
         T000219_A1CustomerId = new short[1] ;
         T000220_A31ResidentId = new short[1] ;
         T000211_A31ResidentId = new short[1] ;
         T000211_A39ResidentGAMGUID = new string[] {""} ;
         T000211_A35ResidentInitials = new string[] {""} ;
         T000211_n35ResidentInitials = new bool[] {false} ;
         T000211_A40ResidentBsnNumber = new string[] {""} ;
         T000211_A33ResidentGivenName = new string[] {""} ;
         T000211_A34ResidentLastName = new string[] {""} ;
         T000211_A36ResidentEmail = new string[] {""} ;
         T000211_A102ResidentGender = new string[] {""} ;
         T000211_A37ResidentAddress = new string[] {""} ;
         T000211_n37ResidentAddress = new bool[] {false} ;
         T000211_A38ResidentPhone = new string[] {""} ;
         T000211_n38ResidentPhone = new bool[] {false} ;
         T000211_A96ResidentLastLineIndividual = new short[1] ;
         T000211_A97ResidentLastLineCompany = new short[1] ;
         T000211_A82ResidentTypeId = new short[1] ;
         T000211_A1CustomerId = new short[1] ;
         T000211_A18CustomerLocationId = new short[1] ;
         T000221_A31ResidentId = new short[1] ;
         T000222_A31ResidentId = new short[1] ;
         T000210_A31ResidentId = new short[1] ;
         T000210_A39ResidentGAMGUID = new string[] {""} ;
         T000210_A35ResidentInitials = new string[] {""} ;
         T000210_n35ResidentInitials = new bool[] {false} ;
         T000210_A40ResidentBsnNumber = new string[] {""} ;
         T000210_A33ResidentGivenName = new string[] {""} ;
         T000210_A34ResidentLastName = new string[] {""} ;
         T000210_A36ResidentEmail = new string[] {""} ;
         T000210_A102ResidentGender = new string[] {""} ;
         T000210_A37ResidentAddress = new string[] {""} ;
         T000210_n37ResidentAddress = new bool[] {false} ;
         T000210_A38ResidentPhone = new string[] {""} ;
         T000210_n38ResidentPhone = new bool[] {false} ;
         T000210_A96ResidentLastLineIndividual = new short[1] ;
         T000210_A97ResidentLastLineCompany = new short[1] ;
         T000210_A82ResidentTypeId = new short[1] ;
         T000210_A1CustomerId = new short[1] ;
         T000210_A18CustomerLocationId = new short[1] ;
         T000224_A31ResidentId = new short[1] ;
         T000227_A83ResidentTypeName = new string[] {""} ;
         T000228_A3CustomerName = new string[] {""} ;
         T000230_A31ResidentId = new short[1] ;
         T000231_A31ResidentId = new short[1] ;
         T000231_A42ResidentINIndividualId = new short[1] ;
         T000231_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         T000231_A44ResidentINIndividualGivenName = new string[] {""} ;
         T000231_A45ResidentINIndividualLastName = new string[] {""} ;
         T000231_A46ResidentINIndividualEmail = new string[] {""} ;
         T000231_n46ResidentINIndividualEmail = new bool[] {false} ;
         T000231_A47ResidentINIndividualPhone = new string[] {""} ;
         T000231_n47ResidentINIndividualPhone = new bool[] {false} ;
         T000231_A48ResidentINIndividualAddress = new string[] {""} ;
         T000231_n48ResidentINIndividualAddress = new bool[] {false} ;
         T000231_A49ResidentINIndividualGender = new string[] {""} ;
         T000232_A31ResidentId = new short[1] ;
         T000232_A42ResidentINIndividualId = new short[1] ;
         T00029_A31ResidentId = new short[1] ;
         T00029_A42ResidentINIndividualId = new short[1] ;
         T00029_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         T00029_A44ResidentINIndividualGivenName = new string[] {""} ;
         T00029_A45ResidentINIndividualLastName = new string[] {""} ;
         T00029_A46ResidentINIndividualEmail = new string[] {""} ;
         T00029_n46ResidentINIndividualEmail = new bool[] {false} ;
         T00029_A47ResidentINIndividualPhone = new string[] {""} ;
         T00029_n47ResidentINIndividualPhone = new bool[] {false} ;
         T00029_A48ResidentINIndividualAddress = new string[] {""} ;
         T00029_n48ResidentINIndividualAddress = new bool[] {false} ;
         T00029_A49ResidentINIndividualGender = new string[] {""} ;
         T00028_A31ResidentId = new short[1] ;
         T00028_A42ResidentINIndividualId = new short[1] ;
         T00028_A43ResidentINIndividualBsnNumber = new string[] {""} ;
         T00028_A44ResidentINIndividualGivenName = new string[] {""} ;
         T00028_A45ResidentINIndividualLastName = new string[] {""} ;
         T00028_A46ResidentINIndividualEmail = new string[] {""} ;
         T00028_n46ResidentINIndividualEmail = new bool[] {false} ;
         T00028_A47ResidentINIndividualPhone = new string[] {""} ;
         T00028_n47ResidentINIndividualPhone = new bool[] {false} ;
         T00028_A48ResidentINIndividualAddress = new string[] {""} ;
         T00028_n48ResidentINIndividualAddress = new bool[] {false} ;
         T00028_A49ResidentINIndividualGender = new string[] {""} ;
         T000236_A31ResidentId = new short[1] ;
         T000236_A42ResidentINIndividualId = new short[1] ;
         T000237_A31ResidentId = new short[1] ;
         T000237_A50ResidentINCompanyId = new short[1] ;
         T000237_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         T000237_A52ResidentINCompanyName = new string[] {""} ;
         T000237_A53ResidentINCompanyEmail = new string[] {""} ;
         T000237_n53ResidentINCompanyEmail = new bool[] {false} ;
         T000237_A54ResidentINCompanyPhone = new string[] {""} ;
         T000237_n54ResidentINCompanyPhone = new bool[] {false} ;
         T000238_A31ResidentId = new short[1] ;
         T000238_A50ResidentINCompanyId = new short[1] ;
         T00027_A31ResidentId = new short[1] ;
         T00027_A50ResidentINCompanyId = new short[1] ;
         T00027_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         T00027_A52ResidentINCompanyName = new string[] {""} ;
         T00027_A53ResidentINCompanyEmail = new string[] {""} ;
         T00027_n53ResidentINCompanyEmail = new bool[] {false} ;
         T00027_A54ResidentINCompanyPhone = new string[] {""} ;
         T00027_n54ResidentINCompanyPhone = new bool[] {false} ;
         T00026_A31ResidentId = new short[1] ;
         T00026_A50ResidentINCompanyId = new short[1] ;
         T00026_A51ResidentINCompanyKvkNumber = new string[] {""} ;
         T00026_A52ResidentINCompanyName = new string[] {""} ;
         T00026_A53ResidentINCompanyEmail = new string[] {""} ;
         T00026_n53ResidentINCompanyEmail = new bool[] {false} ;
         T00026_A54ResidentINCompanyPhone = new string[] {""} ;
         T00026_n54ResidentINCompanyPhone = new bool[] {false} ;
         T000242_A31ResidentId = new short[1] ;
         T000242_A50ResidentINCompanyId = new short[1] ;
         Z74ProductServiceName = "";
         Z75ProductServiceDescription = "";
         Z77ProductServicePicture = "";
         Z40000ProductServicePicture_GXI = "";
         Z72ProductServiceTypeName = "";
         T000243_A31ResidentId = new short[1] ;
         T000243_A74ProductServiceName = new string[] {""} ;
         T000243_A75ProductServiceDescription = new string[] {""} ;
         T000243_A76ProductServiceQuantity = new short[1] ;
         T000243_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000243_A72ProductServiceTypeName = new string[] {""} ;
         T000243_A73ProductServiceId = new short[1] ;
         T000243_A71ProductServiceTypeId = new short[1] ;
         T000243_A77ProductServicePicture = new string[] {""} ;
         T00024_A74ProductServiceName = new string[] {""} ;
         T00024_A75ProductServiceDescription = new string[] {""} ;
         T00024_A76ProductServiceQuantity = new short[1] ;
         T00024_A40000ProductServicePicture_GXI = new string[] {""} ;
         T00024_A71ProductServiceTypeId = new short[1] ;
         T00024_A77ProductServicePicture = new string[] {""} ;
         T00025_A72ProductServiceTypeName = new string[] {""} ;
         T000244_A74ProductServiceName = new string[] {""} ;
         T000244_A75ProductServiceDescription = new string[] {""} ;
         T000244_A76ProductServiceQuantity = new short[1] ;
         T000244_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000244_A71ProductServiceTypeId = new short[1] ;
         T000244_A77ProductServicePicture = new string[] {""} ;
         T000245_A72ProductServiceTypeName = new string[] {""} ;
         T000246_A31ResidentId = new short[1] ;
         T000246_A73ProductServiceId = new short[1] ;
         T00023_A31ResidentId = new short[1] ;
         T00023_A73ProductServiceId = new short[1] ;
         T00022_A31ResidentId = new short[1] ;
         T00022_A73ProductServiceId = new short[1] ;
         T000249_A74ProductServiceName = new string[] {""} ;
         T000249_A75ProductServiceDescription = new string[] {""} ;
         T000249_A76ProductServiceQuantity = new short[1] ;
         T000249_A40000ProductServicePicture_GXI = new string[] {""} ;
         T000249_A71ProductServiceTypeId = new short[1] ;
         T000249_A77ProductServicePicture = new string[] {""} ;
         T000250_A72ProductServiceTypeName = new string[] {""} ;
         T000251_A31ResidentId = new short[1] ;
         T000251_A73ProductServiceId = new short[1] ;
         Gridlevel_inindividualRow = new GXWebRow();
         subGridlevel_inindividual_Linesclass = "";
         ROClassString = "";
         Gridlevel_incompanyRow = new GXWebRow();
         subGridlevel_incompany_Linesclass = "";
         Gridlevel_productserviceRow = new GXWebRow();
         subGridlevel_productservice_Linesclass = "";
         sImgUrl = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_inindividualColumn = new GXWebColumn();
         Gridlevel_incompanyColumn = new GXWebColumn();
         Gridlevel_productserviceColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000252_A1CustomerId = new short[1] ;
         T000252_A18CustomerLocationId = new short[1] ;
         T000252_A134CustomerLocationName = new string[] {""} ;
         T000253_A40ResidentBsnNumber = new string[] {""} ;
         T000254_A83ResidentTypeName = new string[] {""} ;
         T000255_A3CustomerName = new string[] {""} ;
         T000256_A1CustomerId = new short[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.resident__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.resident__default(),
            new Object[][] {
                new Object[] {
               T00022_A31ResidentId, T00022_A73ProductServiceId
               }
               , new Object[] {
               T00023_A31ResidentId, T00023_A73ProductServiceId
               }
               , new Object[] {
               T00024_A74ProductServiceName, T00024_A75ProductServiceDescription, T00024_A76ProductServiceQuantity, T00024_A40000ProductServicePicture_GXI, T00024_A71ProductServiceTypeId, T00024_A77ProductServicePicture
               }
               , new Object[] {
               T00025_A72ProductServiceTypeName
               }
               , new Object[] {
               T00026_A31ResidentId, T00026_A50ResidentINCompanyId, T00026_A51ResidentINCompanyKvkNumber, T00026_A52ResidentINCompanyName, T00026_A53ResidentINCompanyEmail, T00026_n53ResidentINCompanyEmail, T00026_A54ResidentINCompanyPhone, T00026_n54ResidentINCompanyPhone
               }
               , new Object[] {
               T00027_A31ResidentId, T00027_A50ResidentINCompanyId, T00027_A51ResidentINCompanyKvkNumber, T00027_A52ResidentINCompanyName, T00027_A53ResidentINCompanyEmail, T00027_n53ResidentINCompanyEmail, T00027_A54ResidentINCompanyPhone, T00027_n54ResidentINCompanyPhone
               }
               , new Object[] {
               T00028_A31ResidentId, T00028_A42ResidentINIndividualId, T00028_A43ResidentINIndividualBsnNumber, T00028_A44ResidentINIndividualGivenName, T00028_A45ResidentINIndividualLastName, T00028_A46ResidentINIndividualEmail, T00028_n46ResidentINIndividualEmail, T00028_A47ResidentINIndividualPhone, T00028_n47ResidentINIndividualPhone, T00028_A48ResidentINIndividualAddress,
               T00028_n48ResidentINIndividualAddress, T00028_A49ResidentINIndividualGender
               }
               , new Object[] {
               T00029_A31ResidentId, T00029_A42ResidentINIndividualId, T00029_A43ResidentINIndividualBsnNumber, T00029_A44ResidentINIndividualGivenName, T00029_A45ResidentINIndividualLastName, T00029_A46ResidentINIndividualEmail, T00029_n46ResidentINIndividualEmail, T00029_A47ResidentINIndividualPhone, T00029_n47ResidentINIndividualPhone, T00029_A48ResidentINIndividualAddress,
               T00029_n48ResidentINIndividualAddress, T00029_A49ResidentINIndividualGender
               }
               , new Object[] {
               T000210_A31ResidentId, T000210_A39ResidentGAMGUID, T000210_A35ResidentInitials, T000210_n35ResidentInitials, T000210_A40ResidentBsnNumber, T000210_A33ResidentGivenName, T000210_A34ResidentLastName, T000210_A36ResidentEmail, T000210_A102ResidentGender, T000210_A37ResidentAddress,
               T000210_n37ResidentAddress, T000210_A38ResidentPhone, T000210_n38ResidentPhone, T000210_A96ResidentLastLineIndividual, T000210_A97ResidentLastLineCompany, T000210_A82ResidentTypeId, T000210_A1CustomerId, T000210_A18CustomerLocationId
               }
               , new Object[] {
               T000211_A31ResidentId, T000211_A39ResidentGAMGUID, T000211_A35ResidentInitials, T000211_n35ResidentInitials, T000211_A40ResidentBsnNumber, T000211_A33ResidentGivenName, T000211_A34ResidentLastName, T000211_A36ResidentEmail, T000211_A102ResidentGender, T000211_A37ResidentAddress,
               T000211_n37ResidentAddress, T000211_A38ResidentPhone, T000211_n38ResidentPhone, T000211_A96ResidentLastLineIndividual, T000211_A97ResidentLastLineCompany, T000211_A82ResidentTypeId, T000211_A1CustomerId, T000211_A18CustomerLocationId
               }
               , new Object[] {
               T000212_A83ResidentTypeName
               }
               , new Object[] {
               T000213_A3CustomerName
               }
               , new Object[] {
               T000214_A1CustomerId
               }
               , new Object[] {
               T000215_A31ResidentId, T000215_A39ResidentGAMGUID, T000215_A35ResidentInitials, T000215_n35ResidentInitials, T000215_A40ResidentBsnNumber, T000215_A33ResidentGivenName, T000215_A34ResidentLastName, T000215_A36ResidentEmail, T000215_A102ResidentGender, T000215_A37ResidentAddress,
               T000215_n37ResidentAddress, T000215_A38ResidentPhone, T000215_n38ResidentPhone, T000215_A83ResidentTypeName, T000215_A3CustomerName, T000215_A96ResidentLastLineIndividual, T000215_A97ResidentLastLineCompany, T000215_A82ResidentTypeId, T000215_A1CustomerId, T000215_A18CustomerLocationId
               }
               , new Object[] {
               T000216_A40ResidentBsnNumber
               }
               , new Object[] {
               T000217_A83ResidentTypeName
               }
               , new Object[] {
               T000218_A3CustomerName
               }
               , new Object[] {
               T000219_A1CustomerId
               }
               , new Object[] {
               T000220_A31ResidentId
               }
               , new Object[] {
               T000221_A31ResidentId
               }
               , new Object[] {
               T000222_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               T000224_A31ResidentId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000227_A83ResidentTypeName
               }
               , new Object[] {
               T000228_A3CustomerName
               }
               , new Object[] {
               }
               , new Object[] {
               T000230_A31ResidentId
               }
               , new Object[] {
               T000231_A31ResidentId, T000231_A42ResidentINIndividualId, T000231_A43ResidentINIndividualBsnNumber, T000231_A44ResidentINIndividualGivenName, T000231_A45ResidentINIndividualLastName, T000231_A46ResidentINIndividualEmail, T000231_n46ResidentINIndividualEmail, T000231_A47ResidentINIndividualPhone, T000231_n47ResidentINIndividualPhone, T000231_A48ResidentINIndividualAddress,
               T000231_n48ResidentINIndividualAddress, T000231_A49ResidentINIndividualGender
               }
               , new Object[] {
               T000232_A31ResidentId, T000232_A42ResidentINIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000236_A31ResidentId, T000236_A42ResidentINIndividualId
               }
               , new Object[] {
               T000237_A31ResidentId, T000237_A50ResidentINCompanyId, T000237_A51ResidentINCompanyKvkNumber, T000237_A52ResidentINCompanyName, T000237_A53ResidentINCompanyEmail, T000237_n53ResidentINCompanyEmail, T000237_A54ResidentINCompanyPhone, T000237_n54ResidentINCompanyPhone
               }
               , new Object[] {
               T000238_A31ResidentId, T000238_A50ResidentINCompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000242_A31ResidentId, T000242_A50ResidentINCompanyId
               }
               , new Object[] {
               T000243_A31ResidentId, T000243_A74ProductServiceName, T000243_A75ProductServiceDescription, T000243_A76ProductServiceQuantity, T000243_A40000ProductServicePicture_GXI, T000243_A72ProductServiceTypeName, T000243_A73ProductServiceId, T000243_A71ProductServiceTypeId, T000243_A77ProductServicePicture
               }
               , new Object[] {
               T000244_A74ProductServiceName, T000244_A75ProductServiceDescription, T000244_A76ProductServiceQuantity, T000244_A40000ProductServicePicture_GXI, T000244_A71ProductServiceTypeId, T000244_A77ProductServicePicture
               }
               , new Object[] {
               T000245_A72ProductServiceTypeName
               }
               , new Object[] {
               T000246_A31ResidentId, T000246_A73ProductServiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000249_A74ProductServiceName, T000249_A75ProductServiceDescription, T000249_A76ProductServiceQuantity, T000249_A40000ProductServicePicture_GXI, T000249_A71ProductServiceTypeId, T000249_A77ProductServicePicture
               }
               , new Object[] {
               T000250_A72ProductServiceTypeName
               }
               , new Object[] {
               T000251_A31ResidentId, T000251_A73ProductServiceId
               }
               , new Object[] {
               T000252_A1CustomerId, T000252_A18CustomerLocationId, T000252_A134CustomerLocationName
               }
               , new Object[] {
               T000253_A40ResidentBsnNumber
               }
               , new Object[] {
               T000254_A83ResidentTypeName
               }
               , new Object[] {
               T000255_A3CustomerName
               }
               , new Object[] {
               T000256_A1CustomerId
               }
            }
         );
         AV35Pgmname = "Resident";
      }

      private short wcpOAV7ResidentId ;
      private short Z31ResidentId ;
      private short Z96ResidentLastLineIndividual ;
      private short Z97ResidentLastLineCompany ;
      private short Z82ResidentTypeId ;
      private short Z1CustomerId ;
      private short Z18CustomerLocationId ;
      private short O97ResidentLastLineCompany ;
      private short O96ResidentLastLineIndividual ;
      private short N82ResidentTypeId ;
      private short N1CustomerId ;
      private short N18CustomerLocationId ;
      private short Z42ResidentINIndividualId ;
      private short nRcdDeleted_6 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short Z50ResidentINCompanyId ;
      private short nRcdDeleted_7 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short Z73ProductServiceId ;
      private short nRcdDeleted_18 ;
      private short nRcdExists_18 ;
      private short nIsMod_18 ;
      private short GxWebError ;
      private short A1CustomerId ;
      private short A82ResidentTypeId ;
      private short A18CustomerLocationId ;
      private short A73ProductServiceId ;
      private short A71ProductServiceTypeId ;
      private short AV7ResidentId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A96ResidentLastLineIndividual ;
      private short Gx_BScreen ;
      private short A97ResidentLastLineCompany ;
      private short AV26ComboResidentTypeId ;
      private short A31ResidentId ;
      private short nBlankRcdCount6 ;
      private short RcdFound6 ;
      private short B97ResidentLastLineCompany ;
      private short B96ResidentLastLineIndividual ;
      private short nBlankRcdUsr6 ;
      private short nBlankRcdCount7 ;
      private short RcdFound7 ;
      private short nBlankRcdUsr7 ;
      private short nBlankRcdCount18 ;
      private short RcdFound18 ;
      private short nBlankRcdUsr18 ;
      private short AV17TabsActivePage ;
      private short AV13Insert_ResidentTypeId ;
      private short AV27Insert_CustomerId ;
      private short AV28Insert_CustomerLocationId ;
      private short RcdFound5 ;
      private short A76ProductServiceQuantity ;
      private short s97ResidentLastLineCompany ;
      private short A50ResidentINCompanyId ;
      private short s96ResidentLastLineIndividual ;
      private short A42ResidentINIndividualId ;
      private short nIsDirty_6 ;
      private short nIsDirty_7 ;
      private short Z76ProductServiceQuantity ;
      private short Z71ProductServiceTypeId ;
      private short nIsDirty_18 ;
      private short subGridlevel_inindividual_Backcolorstyle ;
      private short subGridlevel_inindividual_Backstyle ;
      private short subGridlevel_incompany_Backcolorstyle ;
      private short subGridlevel_incompany_Backstyle ;
      private short subGridlevel_productservice_Backcolorstyle ;
      private short subGridlevel_productservice_Backstyle ;
      private short gxajaxcallmode ;
      private short i96ResidentLastLineIndividual ;
      private short i97ResidentLastLineCompany ;
      private short subGridlevel_inindividual_Allowselection ;
      private short subGridlevel_inindividual_Allowhovering ;
      private short subGridlevel_inindividual_Allowcollapsing ;
      private short subGridlevel_inindividual_Collapsed ;
      private short subGridlevel_incompany_Allowselection ;
      private short subGridlevel_incompany_Allowhovering ;
      private short subGridlevel_incompany_Allowcollapsing ;
      private short subGridlevel_incompany_Collapsed ;
      private short subGridlevel_productservice_Allowselection ;
      private short subGridlevel_productservice_Allowhovering ;
      private short subGridlevel_productservice_Allowcollapsing ;
      private short subGridlevel_productservice_Collapsed ;
      private int nRC_GXsfl_82 ;
      private int nGXsfl_82_idx=1 ;
      private int nRC_GXsfl_101 ;
      private int nGXsfl_101_idx=1 ;
      private int nRC_GXsfl_117 ;
      private int nGXsfl_117_idx=1 ;
      private int Gxuitabspanel_steps_Activepage ;
      private int trnEnded ;
      private int Gxuitabspanel_steps_Pagecount ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentTypeId_Visible ;
      private int edtResidentTypeId_Enabled ;
      private int edtResidentGAMGUID_Enabled ;
      private int edtResidentAddress_Enabled ;
      private int bttBtnwizardprevious_Visible ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtnwizardnext_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboresidenttypeid_Enabled ;
      private int edtavComboresidenttypeid_Visible ;
      private int edtResidentId_Enabled ;
      private int edtResidentId_Visible ;
      private int edtCustomerId_Visible ;
      private int edtCustomerId_Enabled ;
      private int edtCustomerName_Visible ;
      private int edtCustomerName_Enabled ;
      private int edtResidentINIndividualId_Enabled ;
      private int edtResidentINIndividualBsnNumber_Enabled ;
      private int edtResidentINIndividualGivenName_Enabled ;
      private int edtResidentINIndividualLastName_Enabled ;
      private int edtResidentINIndividualEmail_Enabled ;
      private int edtResidentINIndividualPhone_Enabled ;
      private int edtResidentINIndividualAddress_Enabled ;
      private int fRowAdded ;
      private int edtResidentINCompanyId_Enabled ;
      private int edtResidentINCompanyKvkNumber_Enabled ;
      private int edtResidentINCompanyName_Enabled ;
      private int edtResidentINCompanyEmail_Enabled ;
      private int edtResidentINCompanyPhone_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int edtProductServiceQuantity_Enabled ;
      private int edtProductServicePicture_Enabled ;
      private int edtProductServiceTypeId_Enabled ;
      private int edtProductServiceTypeName_Enabled ;
      private int Combo_residenttypeid_Datalistupdateminimumcharacters ;
      private int Combo_residenttypeid_Gxcontroltype ;
      private int Combo_productserviceid_Datalistupdateminimumcharacters ;
      private int Combo_productserviceid_Gxcontroltype ;
      private int AV36GXV1 ;
      private int subGridlevel_inindividual_Backcolor ;
      private int subGridlevel_inindividual_Allbackcolor ;
      private int subGridlevel_incompany_Backcolor ;
      private int subGridlevel_incompany_Allbackcolor ;
      private int subGridlevel_productservice_Backcolor ;
      private int subGridlevel_productservice_Allbackcolor ;
      private int defedtProductServiceId_Enabled ;
      private int defedtResidentINCompanyId_Enabled ;
      private int defedtResidentINIndividualId_Enabled ;
      private int idxLst ;
      private int subGridlevel_inindividual_Selectedindex ;
      private int subGridlevel_inindividual_Selectioncolor ;
      private int subGridlevel_inindividual_Hoveringcolor ;
      private int subGridlevel_incompany_Selectedindex ;
      private int subGridlevel_incompany_Selectioncolor ;
      private int subGridlevel_incompany_Hoveringcolor ;
      private int subGridlevel_productservice_Selectedindex ;
      private int subGridlevel_productservice_Selectioncolor ;
      private int subGridlevel_productservice_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long GRIDLEVEL_ININDIVIDUAL_nFirstRecordOnPage ;
      private long GRIDLEVEL_INCOMPANY_nFirstRecordOnPage ;
      private long GRIDLEVEL_PRODUCTSERVICE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z35ResidentInitials ;
      private string Z102ResidentGender ;
      private string Z38ResidentPhone ;
      private string Combo_residenttypeid_Selectedvalue_get ;
      private string Z47ResidentINIndividualPhone ;
      private string Z49ResidentINIndividualGender ;
      private string Z54ResidentINCompanyPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtResidentBsnNumber_Internalname ;
      private string sGXsfl_82_idx="0001" ;
      private string sGXsfl_101_idx="0001" ;
      private string sGXsfl_117_idx="0001" ;
      private string edtProductServiceId_Horizontalalignment ;
      private string edtProductServiceId_Internalname ;
      private string dynCustomerLocationId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_steps_Class ;
      private string Gxuitabspanel_steps_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Internalname ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentInitials_Internalname ;
      private string A35ResidentInitials ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentEmail_Internalname ;
      private string edtResidentEmail_Jsonclick ;
      private string edtResidentPhone_Internalname ;
      private string gxphoneLink ;
      private string A38ResidentPhone ;
      private string edtResidentPhone_Jsonclick ;
      private string divTablesplittedresidenttypeid_Internalname ;
      private string lblTextblockresidenttypeid_Internalname ;
      private string lblTextblockresidenttypeid_Jsonclick ;
      private string Combo_residenttypeid_Caption ;
      private string Combo_residenttypeid_Cls ;
      private string Combo_residenttypeid_Datalistproc ;
      private string Combo_residenttypeid_Datalistprocparametersprefix ;
      private string Combo_residenttypeid_Internalname ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeId_Jsonclick ;
      private string dynCustomerLocationId_Jsonclick ;
      private string edtResidentGAMGUID_Internalname ;
      private string edtResidentGAMGUID_Jsonclick ;
      private string edtResidentAddress_Internalname ;
      private string lblTablevel_inindividual_title_Internalname ;
      private string lblTablevel_inindividual_title_Jsonclick ;
      private string divTabtablelevel_inindividual_Internalname ;
      private string divTableleaflevel_inindividual_Internalname ;
      private string lblTablevel_incompany_title_Internalname ;
      private string lblTablevel_incompany_title_Jsonclick ;
      private string divTabtablelevel_incompany_Internalname ;
      private string divTableleaflevel_incompany_Internalname ;
      private string lblTablevel_productservice_title_Internalname ;
      private string lblTablevel_productservice_title_Jsonclick ;
      private string divTabtablelevel_productservice_Internalname ;
      private string divTableleaflevel_productservice_Internalname ;
      private string bttBtnwizardprevious_Internalname ;
      private string bttBtnwizardprevious_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtnwizardnext_Internalname ;
      private string bttBtnwizardnext_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_residenttypeid_Internalname ;
      private string edtavComboresidenttypeid_Internalname ;
      private string edtavComboresidenttypeid_Jsonclick ;
      private string Combo_productserviceid_Caption ;
      private string Combo_productserviceid_Cls ;
      private string Combo_productserviceid_Datalistproc ;
      private string Combo_productserviceid_Datalistprocparametersprefix ;
      private string Combo_productserviceid_Internalname ;
      private string edtResidentId_Internalname ;
      private string edtResidentId_Jsonclick ;
      private string edtCustomerId_Internalname ;
      private string edtCustomerId_Jsonclick ;
      private string edtCustomerName_Internalname ;
      private string edtCustomerName_Jsonclick ;
      private string Wizard_steps_Internalname ;
      private string sMode6 ;
      private string edtResidentINIndividualId_Internalname ;
      private string edtResidentINIndividualBsnNumber_Internalname ;
      private string edtResidentINIndividualGivenName_Internalname ;
      private string edtResidentINIndividualLastName_Internalname ;
      private string edtResidentINIndividualEmail_Internalname ;
      private string edtResidentINIndividualPhone_Internalname ;
      private string edtResidentINIndividualAddress_Internalname ;
      private string cmbResidentINIndividualGender_Internalname ;
      private string sStyleString ;
      private string subGridlevel_inindividual_Internalname ;
      private string sMode7 ;
      private string edtResidentINCompanyId_Internalname ;
      private string edtResidentINCompanyKvkNumber_Internalname ;
      private string edtResidentINCompanyName_Internalname ;
      private string edtResidentINCompanyEmail_Internalname ;
      private string edtResidentINCompanyPhone_Internalname ;
      private string subGridlevel_incompany_Internalname ;
      private string sMode18 ;
      private string edtProductServiceDescription_Internalname ;
      private string edtProductServiceQuantity_Internalname ;
      private string edtProductServicePicture_Internalname ;
      private string edtProductServiceTypeId_Internalname ;
      private string edtProductServiceTypeName_Internalname ;
      private string subGridlevel_productservice_Internalname ;
      private string A102ResidentGender ;
      private string AV35Pgmname ;
      private string Combo_residenttypeid_Objectcall ;
      private string Combo_residenttypeid_Class ;
      private string Combo_residenttypeid_Icontype ;
      private string Combo_residenttypeid_Icon ;
      private string Combo_residenttypeid_Tooltip ;
      private string Combo_residenttypeid_Selectedvalue_set ;
      private string Combo_residenttypeid_Selectedtext_set ;
      private string Combo_residenttypeid_Selectedtext_get ;
      private string Combo_residenttypeid_Gamoauthtoken ;
      private string Combo_residenttypeid_Ddointernalname ;
      private string Combo_residenttypeid_Titlecontrolalign ;
      private string Combo_residenttypeid_Dropdownoptionstype ;
      private string Combo_residenttypeid_Titlecontrolidtoreplace ;
      private string Combo_residenttypeid_Datalisttype ;
      private string Combo_residenttypeid_Datalistfixedvalues ;
      private string Combo_residenttypeid_Remoteservicesparameters ;
      private string Combo_residenttypeid_Htmltemplate ;
      private string Combo_residenttypeid_Multiplevaluestype ;
      private string Combo_residenttypeid_Loadingdata ;
      private string Combo_residenttypeid_Noresultsfound ;
      private string Combo_residenttypeid_Emptyitemtext ;
      private string Combo_residenttypeid_Onlyselectedvalues ;
      private string Combo_residenttypeid_Selectalltext ;
      private string Combo_residenttypeid_Multiplevaluesseparator ;
      private string Combo_residenttypeid_Addnewoptiontext ;
      private string Gxuitabspanel_steps_Objectcall ;
      private string Gxuitabspanel_steps_Activepagecontrolname ;
      private string Combo_productserviceid_Objectcall ;
      private string Combo_productserviceid_Class ;
      private string Combo_productserviceid_Icontype ;
      private string Combo_productserviceid_Icon ;
      private string Combo_productserviceid_Tooltip ;
      private string Combo_productserviceid_Selectedvalue_set ;
      private string Combo_productserviceid_Selectedvalue_get ;
      private string Combo_productserviceid_Selectedtext_set ;
      private string Combo_productserviceid_Selectedtext_get ;
      private string Combo_productserviceid_Gamoauthtoken ;
      private string Combo_productserviceid_Ddointernalname ;
      private string Combo_productserviceid_Titlecontrolalign ;
      private string Combo_productserviceid_Dropdownoptionstype ;
      private string Combo_productserviceid_Titlecontrolidtoreplace ;
      private string Combo_productserviceid_Datalisttype ;
      private string Combo_productserviceid_Datalistfixedvalues ;
      private string Combo_productserviceid_Remoteservicesparameters ;
      private string Combo_productserviceid_Htmltemplate ;
      private string Combo_productserviceid_Multiplevaluestype ;
      private string Combo_productserviceid_Loadingdata ;
      private string Combo_productserviceid_Noresultsfound ;
      private string Combo_productserviceid_Emptyitemtext ;
      private string Combo_productserviceid_Onlyselectedvalues ;
      private string Combo_productserviceid_Selectalltext ;
      private string Combo_productserviceid_Multiplevaluesseparator ;
      private string Combo_productserviceid_Addnewoptiontext ;
      private string Wizard_steps_Objectcall ;
      private string Wizard_steps_Class ;
      private string Wizard_steps_Tabsinternalname ;
      private string Wizard_steps_Allowsteptitleclick ;
      private string Wizard_steps_Transformtype ;
      private string Wizard_steps_Wizardarrowselectedunselectedimage ;
      private string Wizard_steps_Wizardarrowunselectedselectedimage ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A54ResidentINCompanyPhone ;
      private string A47ResidentINIndividualPhone ;
      private string A49ResidentINIndividualGender ;
      private string GXt_char2 ;
      private string sGXsfl_82_fel_idx="0001" ;
      private string subGridlevel_inindividual_Class ;
      private string subGridlevel_inindividual_Linesclass ;
      private string ROClassString ;
      private string edtResidentINIndividualId_Jsonclick ;
      private string edtResidentINIndividualBsnNumber_Jsonclick ;
      private string edtResidentINIndividualGivenName_Jsonclick ;
      private string edtResidentINIndividualLastName_Jsonclick ;
      private string edtResidentINIndividualEmail_Jsonclick ;
      private string edtResidentINIndividualPhone_Jsonclick ;
      private string edtResidentINIndividualAddress_Jsonclick ;
      private string cmbResidentINIndividualGender_Jsonclick ;
      private string sGXsfl_101_fel_idx="0001" ;
      private string subGridlevel_incompany_Class ;
      private string subGridlevel_incompany_Linesclass ;
      private string edtResidentINCompanyId_Jsonclick ;
      private string edtResidentINCompanyKvkNumber_Jsonclick ;
      private string edtResidentINCompanyName_Jsonclick ;
      private string edtResidentINCompanyEmail_Jsonclick ;
      private string edtResidentINCompanyPhone_Jsonclick ;
      private string sGXsfl_117_fel_idx="0001" ;
      private string subGridlevel_productservice_Class ;
      private string subGridlevel_productservice_Linesclass ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceDescription_Jsonclick ;
      private string edtProductServiceQuantity_Jsonclick ;
      private string sImgUrl ;
      private string edtProductServiceTypeId_Jsonclick ;
      private string edtProductServiceTypeName_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_inindividual_Header ;
      private string subGridlevel_incompany_Header ;
      private string subGridlevel_productservice_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_117_Refreshing=false ;
      private bool Gxuitabspanel_steps_Historymanagement ;
      private bool Combo_residenttypeid_Emptyitem ;
      private bool Combo_productserviceid_Isgriditem ;
      private bool Combo_productserviceid_Hasdescription ;
      private bool Combo_productserviceid_Emptyitem ;
      private bool bGXsfl_82_Refreshing=false ;
      private bool bGXsfl_101_Refreshing=false ;
      private bool n35ResidentInitials ;
      private bool n37ResidentAddress ;
      private bool n38ResidentPhone ;
      private bool AV15CheckRequiredFieldsResult ;
      private bool Combo_residenttypeid_Enabled ;
      private bool Combo_residenttypeid_Visible ;
      private bool Combo_residenttypeid_Allowmultipleselection ;
      private bool Combo_residenttypeid_Isgriditem ;
      private bool Combo_residenttypeid_Hasdescription ;
      private bool Combo_residenttypeid_Includeonlyselectedoption ;
      private bool Combo_residenttypeid_Includeselectalloption ;
      private bool Combo_residenttypeid_Includeaddnewoption ;
      private bool Gxuitabspanel_steps_Enabled ;
      private bool Gxuitabspanel_steps_Visible ;
      private bool Combo_productserviceid_Enabled ;
      private bool Combo_productserviceid_Visible ;
      private bool Combo_productserviceid_Allowmultipleselection ;
      private bool Combo_productserviceid_Includeonlyselectedoption ;
      private bool Combo_productserviceid_Includeselectalloption ;
      private bool Combo_productserviceid_Includeaddnewoption ;
      private bool Wizard_steps_Enabled ;
      private bool Wizard_steps_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool n46ResidentINIndividualEmail ;
      private bool n47ResidentINIndividualPhone ;
      private bool n48ResidentINIndividualAddress ;
      private bool n53ResidentINCompanyEmail ;
      private bool n54ResidentINCompanyPhone ;
      private bool A77ProductServicePicture_IsBlob ;
      private bool gxdyncontrolsrefreshing ;
      private string AV22Combo_DataJson ;
      private string Z39ResidentGAMGUID ;
      private string Z40ResidentBsnNumber ;
      private string Z33ResidentGivenName ;
      private string Z34ResidentLastName ;
      private string Z36ResidentEmail ;
      private string Z37ResidentAddress ;
      private string Z43ResidentINIndividualBsnNumber ;
      private string Z44ResidentINIndividualGivenName ;
      private string Z45ResidentINIndividualLastName ;
      private string Z46ResidentINIndividualEmail ;
      private string Z48ResidentINIndividualAddress ;
      private string Z51ResidentINCompanyKvkNumber ;
      private string Z52ResidentINCompanyName ;
      private string Z53ResidentINCompanyEmail ;
      private string A36ResidentEmail ;
      private string A33ResidentGivenName ;
      private string A34ResidentLastName ;
      private string A40ResidentBsnNumber ;
      private string A39ResidentGAMGUID ;
      private string A37ResidentAddress ;
      private string A3CustomerName ;
      private string A83ResidentTypeName ;
      private string A74ProductServiceName ;
      private string A40000ProductServicePicture_GXI ;
      private string A75ProductServiceDescription ;
      private string A72ProductServiceTypeName ;
      private string A51ResidentINCompanyKvkNumber ;
      private string A52ResidentINCompanyName ;
      private string A53ResidentINCompanyEmail ;
      private string A43ResidentINIndividualBsnNumber ;
      private string A44ResidentINIndividualGivenName ;
      private string A45ResidentINIndividualLastName ;
      private string A46ResidentINIndividualEmail ;
      private string A48ResidentINIndividualAddress ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z83ResidentTypeName ;
      private string Z3CustomerName ;
      private string Z74ProductServiceName ;
      private string Z75ProductServiceDescription ;
      private string Z40000ProductServicePicture_GXI ;
      private string Z72ProductServiceTypeName ;
      private string A77ProductServicePicture ;
      private string Z77ProductServicePicture ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_inindividualContainer ;
      private GXWebGrid Gridlevel_incompanyContainer ;
      private GXWebGrid Gridlevel_productserviceContainer ;
      private GXWebRow Gridlevel_inindividualRow ;
      private GXWebRow Gridlevel_incompanyRow ;
      private GXWebRow Gridlevel_productserviceRow ;
      private GXWebColumn Gridlevel_inindividualColumn ;
      private GXWebColumn Gridlevel_incompanyColumn ;
      private GXWebColumn Gridlevel_productserviceColumn ;
      private GXUserControl ucGxuitabspanel_steps ;
      private GXUserControl ucCombo_residenttypeid ;
      private GXUserControl ucCombo_productserviceid ;
      private GXUserControl ucWizard_steps ;
      private GxHttpRequest AV16HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynCustomerLocationId ;
      private GXCombobox cmbResidentINIndividualGender ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25ResidentTypeId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18ProductServiceId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV23GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000213_A3CustomerName ;
      private string[] T000212_A83ResidentTypeName ;
      private short[] T000215_A31ResidentId ;
      private string[] T000215_A39ResidentGAMGUID ;
      private string[] T000215_A35ResidentInitials ;
      private bool[] T000215_n35ResidentInitials ;
      private string[] T000215_A40ResidentBsnNumber ;
      private string[] T000215_A33ResidentGivenName ;
      private string[] T000215_A34ResidentLastName ;
      private string[] T000215_A36ResidentEmail ;
      private string[] T000215_A102ResidentGender ;
      private string[] T000215_A37ResidentAddress ;
      private bool[] T000215_n37ResidentAddress ;
      private string[] T000215_A38ResidentPhone ;
      private bool[] T000215_n38ResidentPhone ;
      private string[] T000215_A83ResidentTypeName ;
      private string[] T000215_A3CustomerName ;
      private short[] T000215_A96ResidentLastLineIndividual ;
      private short[] T000215_A97ResidentLastLineCompany ;
      private short[] T000215_A82ResidentTypeId ;
      private short[] T000215_A1CustomerId ;
      private short[] T000215_A18CustomerLocationId ;
      private string[] T000216_A40ResidentBsnNumber ;
      private short[] T000214_A1CustomerId ;
      private string[] T000217_A83ResidentTypeName ;
      private string[] T000218_A3CustomerName ;
      private short[] T000219_A1CustomerId ;
      private short[] T000220_A31ResidentId ;
      private short[] T000211_A31ResidentId ;
      private string[] T000211_A39ResidentGAMGUID ;
      private string[] T000211_A35ResidentInitials ;
      private bool[] T000211_n35ResidentInitials ;
      private string[] T000211_A40ResidentBsnNumber ;
      private string[] T000211_A33ResidentGivenName ;
      private string[] T000211_A34ResidentLastName ;
      private string[] T000211_A36ResidentEmail ;
      private string[] T000211_A102ResidentGender ;
      private string[] T000211_A37ResidentAddress ;
      private bool[] T000211_n37ResidentAddress ;
      private string[] T000211_A38ResidentPhone ;
      private bool[] T000211_n38ResidentPhone ;
      private short[] T000211_A96ResidentLastLineIndividual ;
      private short[] T000211_A97ResidentLastLineCompany ;
      private short[] T000211_A82ResidentTypeId ;
      private short[] T000211_A1CustomerId ;
      private short[] T000211_A18CustomerLocationId ;
      private short[] T000221_A31ResidentId ;
      private short[] T000222_A31ResidentId ;
      private short[] T000210_A31ResidentId ;
      private string[] T000210_A39ResidentGAMGUID ;
      private string[] T000210_A35ResidentInitials ;
      private bool[] T000210_n35ResidentInitials ;
      private string[] T000210_A40ResidentBsnNumber ;
      private string[] T000210_A33ResidentGivenName ;
      private string[] T000210_A34ResidentLastName ;
      private string[] T000210_A36ResidentEmail ;
      private string[] T000210_A102ResidentGender ;
      private string[] T000210_A37ResidentAddress ;
      private bool[] T000210_n37ResidentAddress ;
      private string[] T000210_A38ResidentPhone ;
      private bool[] T000210_n38ResidentPhone ;
      private short[] T000210_A96ResidentLastLineIndividual ;
      private short[] T000210_A97ResidentLastLineCompany ;
      private short[] T000210_A82ResidentTypeId ;
      private short[] T000210_A1CustomerId ;
      private short[] T000210_A18CustomerLocationId ;
      private short[] T000224_A31ResidentId ;
      private string[] T000227_A83ResidentTypeName ;
      private string[] T000228_A3CustomerName ;
      private short[] T000230_A31ResidentId ;
      private short[] T000231_A31ResidentId ;
      private short[] T000231_A42ResidentINIndividualId ;
      private string[] T000231_A43ResidentINIndividualBsnNumber ;
      private string[] T000231_A44ResidentINIndividualGivenName ;
      private string[] T000231_A45ResidentINIndividualLastName ;
      private string[] T000231_A46ResidentINIndividualEmail ;
      private bool[] T000231_n46ResidentINIndividualEmail ;
      private string[] T000231_A47ResidentINIndividualPhone ;
      private bool[] T000231_n47ResidentINIndividualPhone ;
      private string[] T000231_A48ResidentINIndividualAddress ;
      private bool[] T000231_n48ResidentINIndividualAddress ;
      private string[] T000231_A49ResidentINIndividualGender ;
      private short[] T000232_A31ResidentId ;
      private short[] T000232_A42ResidentINIndividualId ;
      private short[] T00029_A31ResidentId ;
      private short[] T00029_A42ResidentINIndividualId ;
      private string[] T00029_A43ResidentINIndividualBsnNumber ;
      private string[] T00029_A44ResidentINIndividualGivenName ;
      private string[] T00029_A45ResidentINIndividualLastName ;
      private string[] T00029_A46ResidentINIndividualEmail ;
      private bool[] T00029_n46ResidentINIndividualEmail ;
      private string[] T00029_A47ResidentINIndividualPhone ;
      private bool[] T00029_n47ResidentINIndividualPhone ;
      private string[] T00029_A48ResidentINIndividualAddress ;
      private bool[] T00029_n48ResidentINIndividualAddress ;
      private string[] T00029_A49ResidentINIndividualGender ;
      private short[] T00028_A31ResidentId ;
      private short[] T00028_A42ResidentINIndividualId ;
      private string[] T00028_A43ResidentINIndividualBsnNumber ;
      private string[] T00028_A44ResidentINIndividualGivenName ;
      private string[] T00028_A45ResidentINIndividualLastName ;
      private string[] T00028_A46ResidentINIndividualEmail ;
      private bool[] T00028_n46ResidentINIndividualEmail ;
      private string[] T00028_A47ResidentINIndividualPhone ;
      private bool[] T00028_n47ResidentINIndividualPhone ;
      private string[] T00028_A48ResidentINIndividualAddress ;
      private bool[] T00028_n48ResidentINIndividualAddress ;
      private string[] T00028_A49ResidentINIndividualGender ;
      private short[] T000236_A31ResidentId ;
      private short[] T000236_A42ResidentINIndividualId ;
      private short[] T000237_A31ResidentId ;
      private short[] T000237_A50ResidentINCompanyId ;
      private string[] T000237_A51ResidentINCompanyKvkNumber ;
      private string[] T000237_A52ResidentINCompanyName ;
      private string[] T000237_A53ResidentINCompanyEmail ;
      private bool[] T000237_n53ResidentINCompanyEmail ;
      private string[] T000237_A54ResidentINCompanyPhone ;
      private bool[] T000237_n54ResidentINCompanyPhone ;
      private short[] T000238_A31ResidentId ;
      private short[] T000238_A50ResidentINCompanyId ;
      private short[] T00027_A31ResidentId ;
      private short[] T00027_A50ResidentINCompanyId ;
      private string[] T00027_A51ResidentINCompanyKvkNumber ;
      private string[] T00027_A52ResidentINCompanyName ;
      private string[] T00027_A53ResidentINCompanyEmail ;
      private bool[] T00027_n53ResidentINCompanyEmail ;
      private string[] T00027_A54ResidentINCompanyPhone ;
      private bool[] T00027_n54ResidentINCompanyPhone ;
      private short[] T00026_A31ResidentId ;
      private short[] T00026_A50ResidentINCompanyId ;
      private string[] T00026_A51ResidentINCompanyKvkNumber ;
      private string[] T00026_A52ResidentINCompanyName ;
      private string[] T00026_A53ResidentINCompanyEmail ;
      private bool[] T00026_n53ResidentINCompanyEmail ;
      private string[] T00026_A54ResidentINCompanyPhone ;
      private bool[] T00026_n54ResidentINCompanyPhone ;
      private short[] T000242_A31ResidentId ;
      private short[] T000242_A50ResidentINCompanyId ;
      private short[] T000243_A31ResidentId ;
      private string[] T000243_A74ProductServiceName ;
      private string[] T000243_A75ProductServiceDescription ;
      private short[] T000243_A76ProductServiceQuantity ;
      private string[] T000243_A40000ProductServicePicture_GXI ;
      private string[] T000243_A72ProductServiceTypeName ;
      private short[] T000243_A73ProductServiceId ;
      private short[] T000243_A71ProductServiceTypeId ;
      private string[] T000243_A77ProductServicePicture ;
      private string[] T00024_A74ProductServiceName ;
      private string[] T00024_A75ProductServiceDescription ;
      private short[] T00024_A76ProductServiceQuantity ;
      private string[] T00024_A40000ProductServicePicture_GXI ;
      private short[] T00024_A71ProductServiceTypeId ;
      private string[] T00024_A77ProductServicePicture ;
      private string[] T00025_A72ProductServiceTypeName ;
      private string[] T000244_A74ProductServiceName ;
      private string[] T000244_A75ProductServiceDescription ;
      private short[] T000244_A76ProductServiceQuantity ;
      private string[] T000244_A40000ProductServicePicture_GXI ;
      private short[] T000244_A71ProductServiceTypeId ;
      private string[] T000244_A77ProductServicePicture ;
      private string[] T000245_A72ProductServiceTypeName ;
      private short[] T000246_A31ResidentId ;
      private short[] T000246_A73ProductServiceId ;
      private short[] T00023_A31ResidentId ;
      private short[] T00023_A73ProductServiceId ;
      private short[] T00022_A31ResidentId ;
      private short[] T00022_A73ProductServiceId ;
      private string[] T000249_A74ProductServiceName ;
      private string[] T000249_A75ProductServiceDescription ;
      private short[] T000249_A76ProductServiceQuantity ;
      private string[] T000249_A40000ProductServicePicture_GXI ;
      private short[] T000249_A71ProductServiceTypeId ;
      private string[] T000249_A77ProductServicePicture ;
      private string[] T000250_A72ProductServiceTypeName ;
      private short[] T000251_A31ResidentId ;
      private short[] T000251_A73ProductServiceId ;
      private short[] T000252_A1CustomerId ;
      private short[] T000252_A18CustomerLocationId ;
      private string[] T000252_A134CustomerLocationName ;
      private string[] T000253_A40ResidentBsnNumber ;
      private string[] T000254_A83ResidentTypeName ;
      private string[] T000255_A3CustomerName ;
      private short[] T000256_A1CustomerId ;
      private IDataStoreProvider pr_gam ;
   }

   public class resident__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class resident__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new UpdateCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new UpdateCursor(def[45])
       ,new UpdateCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000212;
        prmT000212 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000213;
        prmT000213 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000214;
        prmT000214 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000215;
        prmT000215 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000216;
        prmT000216 = new Object[] {
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000217;
        prmT000217 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000218;
        prmT000218 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000219;
        prmT000219 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000220;
        prmT000220 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000221;
        prmT000221 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000222;
        prmT000222 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000223;
        prmT000223 = new Object[] {
        new ParDef("ResidentGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ResidentInitials",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
        new ParDef("ResidentGender",GXType.Char,20,0) ,
        new ParDef("ResidentAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentTypeId",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        Object[] prmT000224;
        prmT000224 = new Object[] {
        };
        Object[] prmT000225;
        prmT000225 = new Object[] {
        new ParDef("ResidentGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ResidentInitials",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentEmail",GXType.VarChar,100,0) ,
        new ParDef("ResidentGender",GXType.Char,20,0) ,
        new ParDef("ResidentAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentTypeId",GXType.Int16,4,0) ,
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000226;
        prmT000226 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000227;
        prmT000227 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000228;
        prmT000228 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000229;
        prmT000229 = new Object[] {
        new ParDef("ResidentLastLineCompany",GXType.Int16,4,0) ,
        new ParDef("ResidentLastLineIndividual",GXType.Int16,4,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000230;
        prmT000230 = new Object[] {
        };
        Object[] prmT000231;
        prmT000231 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT000232;
        prmT000232 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT000233;
        prmT000233 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINIndividualPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentINIndividualAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentINIndividualGender",GXType.Char,20,0)
        };
        Object[] prmT000234;
        prmT000234 = new Object[] {
        new ParDef("ResidentINIndividualBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualGivenName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualLastName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINIndividualEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINIndividualPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentINIndividualAddress",GXType.VarChar,1024,0){Nullable=true} ,
        new ParDef("ResidentINIndividualGender",GXType.Char,20,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT000235;
        prmT000235 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINIndividualId",GXType.Int16,4,0)
        };
        Object[] prmT000236;
        prmT000236 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000237;
        prmT000237 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT000238;
        prmT000238 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT000239;
        prmT000239 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("ResidentINCompanyName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINCompanyEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINCompanyPhone",GXType.Char,20,0){Nullable=true}
        };
        Object[] prmT000240;
        prmT000240 = new Object[] {
        new ParDef("ResidentINCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("ResidentINCompanyName",GXType.VarChar,40,0) ,
        new ParDef("ResidentINCompanyEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("ResidentINCompanyPhone",GXType.Char,20,0){Nullable=true} ,
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT000241;
        prmT000241 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ResidentINCompanyId",GXType.Int16,4,0)
        };
        Object[] prmT000242;
        prmT000242 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000243;
        prmT000243 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000244;
        prmT000244 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000245;
        prmT000245 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000246;
        prmT000246 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000247;
        prmT000247 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000248;
        prmT000248 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0) ,
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000249;
        prmT000249 = new Object[] {
        new ParDef("ProductServiceId",GXType.Int16,4,0)
        };
        Object[] prmT000250;
        prmT000250 = new Object[] {
        new ParDef("ProductServiceTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000251;
        prmT000251 = new Object[] {
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000252;
        prmT000252 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000253;
        prmT000253 = new Object[] {
        new ParDef("ResidentBsnNumber",GXType.VarChar,40,0) ,
        new ParDef("ResidentId",GXType.Int16,4,0)
        };
        Object[] prmT000254;
        prmT000254 = new Object[] {
        new ParDef("ResidentTypeId",GXType.Int16,4,0)
        };
        Object[] prmT000255;
        prmT000255 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0)
        };
        Object[] prmT000256;
        prmT000256 = new Object[] {
        new ParDef("CustomerId",GXType.Int16,4,0) ,
        new ParDef("CustomerLocationId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId  FOR UPDATE OF ResidentProductService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId  FOR UPDATE OF ResidentINCompany NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00027", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId  FOR UPDATE OF ResidentINIndividual NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00029", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000210", "SELECT ResidentId, ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId FROM Resident WHERE ResidentId = :ResidentId  FOR UPDATE OF Resident NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000211", "SELECT ResidentId, ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId FROM Resident WHERE ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000212", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000213", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000214", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000215", "SELECT TM1.ResidentId, TM1.ResidentGAMGUID, TM1.ResidentInitials, TM1.ResidentBsnNumber, TM1.ResidentGivenName, TM1.ResidentLastName, TM1.ResidentEmail, TM1.ResidentGender, TM1.ResidentAddress, TM1.ResidentPhone, T2.ResidentTypeName, T3.CustomerName, TM1.ResidentLastLineIndividual, TM1.ResidentLastLineCompany, TM1.ResidentTypeId, TM1.CustomerId, TM1.CustomerLocationId FROM ((Resident TM1 INNER JOIN ResidentType T2 ON T2.ResidentTypeId = TM1.ResidentTypeId) INNER JOIN Customer T3 ON T3.CustomerId = TM1.CustomerId) WHERE TM1.ResidentId = :ResidentId ORDER BY TM1.ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000216", "SELECT ResidentBsnNumber FROM Resident WHERE (ResidentBsnNumber = :ResidentBsnNumber) AND (Not ( ResidentId = :ResidentId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000217", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000218", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000219", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000220", "SELECT ResidentId FROM Resident WHERE ResidentId = :ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000221", "SELECT ResidentId FROM Resident WHERE ( ResidentId > :ResidentId) ORDER BY ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000222", "SELECT ResidentId FROM Resident WHERE ( ResidentId < :ResidentId) ORDER BY ResidentId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000223", "SAVEPOINT gxupdate;INSERT INTO Resident(ResidentGAMGUID, ResidentInitials, ResidentBsnNumber, ResidentGivenName, ResidentLastName, ResidentEmail, ResidentGender, ResidentAddress, ResidentPhone, ResidentLastLineIndividual, ResidentLastLineCompany, ResidentTypeId, CustomerId, CustomerLocationId) VALUES(:ResidentGAMGUID, :ResidentInitials, :ResidentBsnNumber, :ResidentGivenName, :ResidentLastName, :ResidentEmail, :ResidentGender, :ResidentAddress, :ResidentPhone, :ResidentLastLineIndividual, :ResidentLastLineCompany, :ResidentTypeId, :CustomerId, :CustomerLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000223)
           ,new CursorDef("T000224", "SELECT currval('ResidentId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000225", "SAVEPOINT gxupdate;UPDATE Resident SET ResidentGAMGUID=:ResidentGAMGUID, ResidentInitials=:ResidentInitials, ResidentBsnNumber=:ResidentBsnNumber, ResidentGivenName=:ResidentGivenName, ResidentLastName=:ResidentLastName, ResidentEmail=:ResidentEmail, ResidentGender=:ResidentGender, ResidentAddress=:ResidentAddress, ResidentPhone=:ResidentPhone, ResidentLastLineIndividual=:ResidentLastLineIndividual, ResidentLastLineCompany=:ResidentLastLineCompany, ResidentTypeId=:ResidentTypeId, CustomerId=:CustomerId, CustomerLocationId=:CustomerLocationId  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000225)
           ,new CursorDef("T000226", "SAVEPOINT gxupdate;DELETE FROM Resident  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000226)
           ,new CursorDef("T000227", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000227,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000228", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000228,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000229", "SAVEPOINT gxupdate;UPDATE Resident SET ResidentLastLineCompany=:ResidentLastLineCompany, ResidentLastLineIndividual=:ResidentLastLineIndividual  WHERE ResidentId = :ResidentId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000229)
           ,new CursorDef("T000230", "SELECT ResidentId FROM Resident ORDER BY ResidentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000231", "SELECT ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender FROM ResidentINIndividual WHERE ResidentId = :ResidentId and ResidentINIndividualId = :ResidentINIndividualId ORDER BY ResidentId, ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000232", "SELECT ResidentId, ResidentINIndividualId FROM ResidentINIndividual WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000233", "SAVEPOINT gxupdate;INSERT INTO ResidentINIndividual(ResidentId, ResidentINIndividualId, ResidentINIndividualBsnNumber, ResidentINIndividualGivenName, ResidentINIndividualLastName, ResidentINIndividualEmail, ResidentINIndividualPhone, ResidentINIndividualAddress, ResidentINIndividualGender) VALUES(:ResidentId, :ResidentINIndividualId, :ResidentINIndividualBsnNumber, :ResidentINIndividualGivenName, :ResidentINIndividualLastName, :ResidentINIndividualEmail, :ResidentINIndividualPhone, :ResidentINIndividualAddress, :ResidentINIndividualGender);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000233)
           ,new CursorDef("T000234", "SAVEPOINT gxupdate;UPDATE ResidentINIndividual SET ResidentINIndividualBsnNumber=:ResidentINIndividualBsnNumber, ResidentINIndividualGivenName=:ResidentINIndividualGivenName, ResidentINIndividualLastName=:ResidentINIndividualLastName, ResidentINIndividualEmail=:ResidentINIndividualEmail, ResidentINIndividualPhone=:ResidentINIndividualPhone, ResidentINIndividualAddress=:ResidentINIndividualAddress, ResidentINIndividualGender=:ResidentINIndividualGender  WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000234)
           ,new CursorDef("T000235", "SAVEPOINT gxupdate;DELETE FROM ResidentINIndividual  WHERE ResidentId = :ResidentId AND ResidentINIndividualId = :ResidentINIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000235)
           ,new CursorDef("T000236", "SELECT ResidentId, ResidentINIndividualId FROM ResidentINIndividual WHERE ResidentId = :ResidentId ORDER BY ResidentId, ResidentINIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000236,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000237", "SELECT ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone FROM ResidentINCompany WHERE ResidentId = :ResidentId and ResidentINCompanyId = :ResidentINCompanyId ORDER BY ResidentId, ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000237,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000238", "SELECT ResidentId, ResidentINCompanyId FROM ResidentINCompany WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000238,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000239", "SAVEPOINT gxupdate;INSERT INTO ResidentINCompany(ResidentId, ResidentINCompanyId, ResidentINCompanyKvkNumber, ResidentINCompanyName, ResidentINCompanyEmail, ResidentINCompanyPhone) VALUES(:ResidentId, :ResidentINCompanyId, :ResidentINCompanyKvkNumber, :ResidentINCompanyName, :ResidentINCompanyEmail, :ResidentINCompanyPhone);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000239)
           ,new CursorDef("T000240", "SAVEPOINT gxupdate;UPDATE ResidentINCompany SET ResidentINCompanyKvkNumber=:ResidentINCompanyKvkNumber, ResidentINCompanyName=:ResidentINCompanyName, ResidentINCompanyEmail=:ResidentINCompanyEmail, ResidentINCompanyPhone=:ResidentINCompanyPhone  WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000240)
           ,new CursorDef("T000241", "SAVEPOINT gxupdate;DELETE FROM ResidentINCompany  WHERE ResidentId = :ResidentId AND ResidentINCompanyId = :ResidentINCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000241)
           ,new CursorDef("T000242", "SELECT ResidentId, ResidentINCompanyId FROM ResidentINCompany WHERE ResidentId = :ResidentId ORDER BY ResidentId, ResidentINCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000242,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000243", "SELECT T1.ResidentId, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceQuantity, T2.ProductServicePicture_GXI, T3.ProductServiceTypeName, T1.ProductServiceId, T2.ProductServiceTypeId, T2.ProductServicePicture FROM ((ResidentProductService T1 INNER JOIN ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN ProductServiceType T3 ON T3.ProductServiceTypeId = T2.ProductServiceTypeId) WHERE T1.ResidentId = :ResidentId and T1.ProductServiceId = :ProductServiceId ORDER BY T1.ResidentId, T1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000243,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000244", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000244,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000245", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000245,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000246", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000246,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000247", "SAVEPOINT gxupdate;INSERT INTO ResidentProductService(ResidentId, ProductServiceId) VALUES(:ResidentId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000247)
           ,new CursorDef("T000248", "SAVEPOINT gxupdate;DELETE FROM ResidentProductService  WHERE ResidentId = :ResidentId AND ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000248)
           ,new CursorDef("T000249", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceQuantity, ProductServicePicture_GXI, ProductServiceTypeId, ProductServicePicture FROM ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000249,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000250", "SELECT ProductServiceTypeName FROM ProductServiceType WHERE ProductServiceTypeId = :ProductServiceTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000250,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000251", "SELECT ResidentId, ProductServiceId FROM ResidentProductService WHERE ResidentId = :ResidentId ORDER BY ResidentId, ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000251,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000252", "SELECT CustomerId, CustomerLocationId, CustomerLocationName FROM CustomerLocation WHERE CustomerId = :CustomerId ORDER BY CustomerLocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000252,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000253", "SELECT ResidentBsnNumber FROM Resident WHERE (ResidentBsnNumber = :ResidentBsnNumber) AND (Not ( ResidentId = :ResidentId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000253,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000254", "SELECT ResidentTypeName FROM ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000254,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000255", "SELECT CustomerName FROM Customer WHERE CustomerId = :CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000255,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000256", "SELECT CustomerId FROM CustomerLocation WHERE CustomerId = :CustomerId AND CustomerLocationId = :CustomerLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000256,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((short[]) buf[13])[0] = rslt.getShort(11);
              ((short[]) buf[14])[0] = rslt.getShort(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((short[]) buf[13])[0] = rslt.getShort(11);
              ((short[]) buf[14])[0] = rslt.getShort(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getVarchar(11);
              ((string[]) buf[14])[0] = rslt.getVarchar(12);
              ((short[]) buf[15])[0] = rslt.getShort(13);
              ((short[]) buf[16])[0] = rslt.getShort(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((short[]) buf[18])[0] = rslt.getShort(16);
              ((short[]) buf[19])[0] = rslt.getShort(17);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 18 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 34 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 35 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 36 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 40 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 41 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 44 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 49 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 50 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 54 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
